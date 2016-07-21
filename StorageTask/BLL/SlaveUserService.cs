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

        public SlaveUserService(IUserRepository userRepository, UserService userService)
        {
            if (userRepository == null || userService == null)
                throw new ArgumentNullException();
                if (!(userService is MasterUserService))
                    throw new ArgumentException("UserService must be Master");
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