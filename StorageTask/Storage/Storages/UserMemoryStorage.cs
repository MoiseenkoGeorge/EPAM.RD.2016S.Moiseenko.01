using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            if(!validationResult.IsValid)
                throw new ValidationException(new List<ValidationResult>() {validationResult});
            entity.Id = idGenerator.GetNewId();
            storage.Add(entity);
            return entity.Id;
        }

        public void Delete(int id)
        {
            var user = storage.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new InvalidOperationException();
            }
            storage.RemoveWhere(u => u.Id == id);
        }

        public IEnumerable<int> Search(Func<User, bool>[] funcs)
        {
            return storage.Where(u => funcs.All(f => f(u))).Select(u => u.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return storage;
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(filePath,FileMode.OpenOrCreate,FileAccess.Write))
            {
                xmlSerializer.Serialize(fs,new StateContainer(storage, idGenerator.Current));
            }
        }

        public void Load()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate,FileAccess.Read))
            {
                StateContainer result = (StateContainer)xmlSerializer.Deserialize(fs);
                idGenerator.Init(result.id);
                storage = result.storage;
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
