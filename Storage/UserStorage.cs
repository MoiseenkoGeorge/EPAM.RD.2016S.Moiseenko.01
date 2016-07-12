using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Interfacies;

namespace Storage
{
    public class UserStorage : IUserStorage
    {
        public int Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> Search(Func<User, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
