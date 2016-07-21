using System;
using System.Collections.Generic;
using DAL.Interfacies;
using Entities;

namespace BLL.Interfacies
{
    public abstract class UserService : IService
    {
        public abstract bool IsMaster { get; }

        protected IUserRepository userRepository;

        public abstract int AddUser(User user);
        public abstract void DeleteUser(User user);

        public virtual IEnumerable<int> FindUsers(Func<User, bool>[] funcs)
        {
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}