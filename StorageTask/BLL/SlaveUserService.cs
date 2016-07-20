using System;
using System.Collections.Generic;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public class SlaveUserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

        public bool IsMaster => false;

        public event EventHandler<UserEventArgs> UserAdded
        {
            add
            {
                throw new InvalidOperationException();
            }
            remove
            {
                throw new InvalidOperationException();
            }
        }
        public event EventHandler<UserEventArgs> UserDeleted;

        
        protected void UserAddedHandler(object sender, UserEventArgs userEventArgs)
        {
        }

        protected void UserDeletedHandler(object sender, UserEventArgs userEventArgs)
        {
            throw new NotImplementedException();
        }

        public SlaveUserService(IUserRepository userRepository, IUserService userService, ILogger logger)
        {
            if (userRepository == null || userService == null)
                throw new ArgumentNullException();
                if (!(userService is MasterUserService))
                    throw new ArgumentException("UserService must be Master");
            userService.UserAdded += UserAddedHandler;
            userService.UserDeleted += UserDeletedHandler;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public int AddUser(User user)
        {
            logger.Error("Slave can't add users");
            throw new InvalidOperationException("Slave can't add users");
        }

        public void DeleteUser(User user)
        {
            logger.Error("Slave can't delete users");
            throw new InvalidOperationException("Slave can't delete users");
        }

        public IEnumerable<int> FindUser(Func<User, bool>[] funcs)
        {
            logger.Info("Slave find users by keys");
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}