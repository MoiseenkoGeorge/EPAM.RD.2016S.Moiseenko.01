using System;
using System.Collections.Generic;
using BLL.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public class SlaveUserService : IUserService
    {
        public bool IsMaster => false;

        public event EventHandler<UserEventArgs> UserAdded;
        public event EventHandler<UserEventArgs> UserDeleted;

        private readonly IUserRepository userRepository;

        protected void UserAddedHandler(object sender, UserEventArgs userEventArgs)
        {
            throw new NotImplementedException();
        }

        protected void UserDeletedHandler(object sender, UserEventArgs userEventArgs)
        {
            throw new NotImplementedException();
        }

        public SlaveUserService(IUserRepository userRepository, IUserService userService)
        {
            if (userRepository == null || userService == null)
                throw new ArgumentNullException();
                if (!(userService is MasterUserService))
                    throw new ArgumentException("UserService must be Master");
            userService.UserAdded += UserAddedHandler;
            userService.UserDeleted += UserDeletedHandler;
            this.userRepository = userRepository;
        }

        public int AddUser(User user)
        {
            throw new InvalidOperationException("Slave can't add users");
        }

        public void DeleteUser(User user)
        {
            throw new InvalidOperationException("Slave can't delete users");
        }

        public IEnumerable<int> FindUser(Func<User, bool>[] funcs)
        {
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}