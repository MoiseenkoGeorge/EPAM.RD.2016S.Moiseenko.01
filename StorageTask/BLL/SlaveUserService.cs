﻿using System;
using System.Collections.Generic;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using BLL.Services.Network;
using BLL.Services.Network.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public sealed class SlaveUserService : UserService
    {
        public override bool IsMaster => false;

        public SlaveUserService(IUserRepository userRepository, IUserTransmitter transmitter)
        {
            if (userRepository == null || transmitter == null)
                throw new ArgumentNullException();
            this.userRepository = userRepository;
            this.transmitter = transmitter;
            transmitter.UserAdded += AttachUser;
            transmitter.UserDeleted += DetachUser;
        }

        public override int AddUser(User user)
        {
            throw new InvalidOperationException("Slave can't add users");
        }

        public override void DeleteUser(User user)
        {
            throw new InvalidOperationException("Slave can't delete users");
        }

        private void AttachUser(object sender, UserEventArgs eventArgs)
        {
            userRepository.Attach(eventArgs.User);
        }

        private void DetachUser(object sender, UserEventArgs eventArgs)
        {
            userRepository.Detach(eventArgs.User);
        }
    }
}