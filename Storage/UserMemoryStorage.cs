using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Entities;
using Entities.Interfacies;
using Services.Generators.Interfacies;
using Services.Validators;
using Services.Validators.Interfacies;

namespace Storage
{
    public class UserMemoryStorage : IUserStorage
    {
        private readonly string filePath = ConfigurationManager.AppSettings["FilePath"];

        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<User>));

        private HashSet<User> storage;

        private readonly IGenerator<int> idGenerator;

        private readonly IUserValidator userValidator;

        public UserMemoryStorage(IGenerator<int> idGenerator, IUserValidator userValidator)
        {
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

        public IEnumerable<int> Search(Func<User, bool> func)
        {
            return storage.Where(func).Select(u => u.Id);
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(filePath,FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs,storage);
            }
        }

        public void Load()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                storage = (HashSet<User>)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
