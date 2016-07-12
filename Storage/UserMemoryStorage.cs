using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Interfacies;
using Services.Interfacies;

namespace Storage
{
    public class UserMemoryStorage : IUserStorage
    {
        private readonly HashSet<User> set;

        private readonly IGenerator<int> idGenerator;

        public UserMemoryStorage(IGenerator<int> idGenerator)
        {
            this.idGenerator = idGenerator;
            set = new HashSet<User>();
        }
         
        public int Add(User entity)
        {
            entity.Id = idGenerator.GetNewId();
            set.Add(entity);
            return entity.Id;
        }

        public void Delete(int id)
        {
            var user = set.SingleOrDefault(u => u.Id == id);
            if(user == null)
                throw new InvalidOperationException();
            set.RemoveWhere(u => u.Id == id);
        }

        public IEnumerable<int> Search(Func<User, bool> func)
        {
            return set.Where(func).Select(u => u.Id);
        }
    }
}
