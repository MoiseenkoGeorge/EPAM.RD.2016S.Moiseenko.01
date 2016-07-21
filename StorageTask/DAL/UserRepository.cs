using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfacies;
using Entities;
using Storage.Storages.Interfacies;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserStorage userStorage;

        private readonly ICollection<User> localUserStorage; 

        public UserRepository(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
            this.localUserStorage = GetAllEntities().ToList();
        }

        public IEnumerable<User> GetAllEntities()
        {
            return userStorage.GetAll();
        }

        public User GetById()
        {
            throw new NotImplementedException();
        }

        public User GetByPredicate(Func<User, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Attach(User entity)
        {
            var user = localUserStorage.SingleOrDefault(u => u.Id == entity.Id);
            if(user == null)
                localUserStorage.Add(entity);
            else throw new InvalidOperationException("The same user is already exists");
        }

        public void Detach(User entity)
        {
            var user = localUserStorage.SingleOrDefault(u => u.Id == entity.Id);
            if (user == null)
                throw new InvalidOperationException("user is not exists");
            else
            {
                localUserStorage.Remove(entity);
            }
        }

        public int Create(User entity)
        {
            var result = userStorage.Add(entity);
            entity.Id = result;
            Attach(entity);
            return result;
        }

        public void Delete(User entity)
        {
            userStorage.Delete(entity.Id);
            localUserStorage.Remove(entity);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetUsersIdsByPredicate(Func<User, bool>[] funcs)
        {
            return localUserStorage.Where(u => funcs.All(f => f(u))).Select(u => u.Id);
        }
    }
}