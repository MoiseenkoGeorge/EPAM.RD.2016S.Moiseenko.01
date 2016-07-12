using System;
using System.Collections.Generic;
using Entities.Interfacies;

namespace Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserStorage userStorage;
         

        public UserRepository(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public IEnumerable<User> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public User GetById()
        {
            throw new NotImplementedException();
        }

        public User GetByPredicate(Func<User, bool> func)
        {
            throw new NotImplementedException();
        }

        public int Create(User entity)
        {
            return userStorage.Add(entity);
        }

        public void Delete(User entity)
        {
            userStorage.Delete(entity.Id);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}