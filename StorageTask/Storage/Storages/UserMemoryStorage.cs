using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;
using Entities;
using Storage.Generators.Interfacies;
using Storage.Storages.Interfacies;
using Storage.Validators;
using Storage.Validators.Interfacies;

namespace Storage.Storages
{
    public class UserMemoryStorage : MarshalByRefObject, IUserStorage
    {
        private readonly ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

        private readonly string filePath;

        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(StateContainer));

        private HashSet<User> storage;

        private readonly IGenerator<int> idGenerator;

        private readonly IUserValidator userValidator;

        public UserMemoryStorage(IGenerator<int> idGenerator, IUserValidator userValidator, string fileName)
        {
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            this.idGenerator = idGenerator;
            this.userValidator = userValidator;
            storage = new HashSet<User>();
        }

        public int Add(User entity)
        {
            var validationResult = userValidator.Validate(entity);
            if (!validationResult.IsValid)
                throw new ValidationException(new List<ValidationResult>() { validationResult });
            entity.Id = idGenerator.GetNewId();
            rwls.EnterWriteLock();
            try
            {
                storage.Add(entity);
            }
            finally
            {
                rwls.ExitWriteLock();
            }

            return entity.Id;
        }

        public void Delete(int id)
        {
            rwls.EnterReadLock();
            try
            {
                var user = storage.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    throw new InvalidOperationException();
                }
            }
            finally
            {
                rwls.ExitReadLock();
            }
            
            rwls.EnterWriteLock();
            try
            {
                storage.RemoveWhere(u => u.Id == id);
            }
            finally
            {
                rwls.ExitWriteLock();
            }
        }

        public IEnumerable<int> Search(Func<User, bool>[] funcs)
        {
            rwls.EnterReadLock();
            try
            {
                return storage.Where(u => funcs.All(f => f(u))).Select(u => u.Id);
            }
            finally
            {
                rwls.ExitReadLock();
            }
        }

        public IEnumerable<User> GetAll()
        {
            rwls.EnterReadLock();
            try
            {
                return storage;
            }
            finally
            {
                rwls.ExitReadLock();
            }

        }

        public void Save()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                rwls.EnterReadLock();
                try
                {
                    xmlSerializer.Serialize(fs, new StateContainer(storage, idGenerator.Current));
                }
                finally
                {
                    rwls.ExitReadLock();
                }
            }
        }

        public void Load()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StateContainer result = (StateContainer)xmlSerializer.Deserialize(fs);
                idGenerator.Init(result.id);
                rwls.EnterWriteLock();
                try
                {
                    storage = result.storage;
                }
                finally
                {
                    rwls.ExitWriteLock();
                }
            }
        }

    }

    [Serializable]
    public struct StateContainer
    {
        public HashSet<User> storage;
        public int id;

        public StateContainer(HashSet<User> storage, int id)
        {
            this.storage = storage;
            this.id = id;
        }
    }
}
