using System;
using System.Collections.Generic;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public class SlaveUserService : UserService
    {
        public override bool IsMaster => false;

        public override event EventHandler<UserEventArgs> UserAdded
        {
            add { throw new InvalidOperationException("UserAddedEvent is not availbale for slaveUserService"); }
            remove { throw new InvalidOperationException("UserAddedEvent is not availbale for slaveUserService"); }
        }
        public override event EventHandler<UserEventArgs> UserDeleted
        {
            add { throw new InvalidOperationException("UserDeletedEvent is not availbale for slaveUserService"); }
            remove { throw new InvalidOperationException("UserDeletedEvent is not availbale for slaveUserService"); }
        }

        
        protected void UserAddedHandler(object sender, UserEventArgs userEventArgs)
        {

        }

        protected void UserDeletedHandler(object sender, UserEventArgs userEventArgs)
        {
            throw new NotImplementedException();
        }

        public SlaveUserService(IUserRepository userRepository, UserService userService)
        {
            if (userRepository == null || userService == null)
                throw new ArgumentNullException();
                if (!(userService is MasterUserService))
                    throw new ArgumentException("UserService must be Master");
            userService.UserAdded += UserAddedHandler;
            userService.UserDeleted += UserDeletedHandler;
            this.userRepository = userRepository;
        }

        public override int AddUser(User user)
        {
            throw new InvalidOperationException("Slave can't add users");
        }

        public override void DeleteUser(User user)
        {
            throw new InvalidOperationException("Slave can't delete users");
        }

    }
}