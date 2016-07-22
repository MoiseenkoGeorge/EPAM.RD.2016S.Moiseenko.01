﻿using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using BLL.Interfacies;
using BLL.Services.Network;
using BLL.Services.Network.Interfacies;
using DAL;
using DAL.Interfacies;
using Storage.Storages;
using Storage.Storages.Interfacies;

namespace BLL.Configurations.UserServiceConfigurations
{
    public class UserServiceConfigurator
    {
        private readonly IUserStorage userStorage;

        private readonly int countOfMasters;
        private readonly int countOfSlaves;

        private UserServiceConfigSection section;

        public UserServiceConfigurator(IUserStorage userStorage)
        {
            if (userStorage == null)
            {
                throw new ArgumentNullException(nameof(userStorage));
            }

            this.userStorage = userStorage;

            section = (UserServiceConfigSection)ConfigurationManager.GetSection("UserServices");

            if (section == null)
            {
                throw new InvalidOperationException("Section does not exist");
            }

            UserServiceElement[] userServiceElements = section.UserServiceItems.Cast<UserServiceElement>().ToArray();

            countOfMasters = userServiceElements.Count(s => s.IsMaster);
            countOfSlaves = userServiceElements.Count(s => !s.IsMaster);
        }

        public UserServiceConfigurator(IUserStorage userStorage, int countOfMasters, int countOfSlaves)
        {
            if (userStorage == null)
                throw new ArgumentNullException(nameof(userStorage));
            this.userStorage = userStorage;
            this.countOfMasters = countOfMasters;
            this.countOfSlaves = countOfSlaves;
        }

        //public UserService[] GetServices()
        //{
        //    if (countOfMasters != 1)
        //    {
        //        throw new InvalidOperationException();
        //    }

        //    if (countOfSlaves < 1)
        //    {
        //        throw new InvalidOperationException("Require at least one slave");
        //    }

        //    UserService[] services = new UserService[countOfMasters + countOfSlaves];

        //    services[0] = new MasterUserService(userRepository, new UdpSender("255.255.255.255",11000));

        //    for (int i = 0; i < countOfSlaves; i++)
        //    {
        //        services[i + 1] = new SlaveUserService(userRepository, new UdpReceiver("255.255.255.255", 11000));
        //    }

        //    return services;
        //}

        public LoggibleUserService[] GetUserServices()
        {
            if (countOfMasters != 1)
            {
                throw new InvalidOperationException();
            }

            if (countOfSlaves < 1)
            {
                throw new InvalidOperationException("Require at least one slave");
            }

            UserServiceElement[] userServiceElements = section.UserServiceItems.Cast<UserServiceElement>().ToArray();

            var masterElement = userServiceElements.Single(s => s.IsMaster);

            var slaveElements = userServiceElements.Where(s => !s.IsMaster);

            LoggibleUserService[] services = new LoggibleUserService[countOfMasters + countOfSlaves];

            services[0] = CreateUserService(userStorage, masterElement);

            int i = 1;
            foreach (var config in slaveElements)
            {
                services[i++] = CreateUserService(userStorage, config);
            }

            return services;
        }

        private LoggibleUserService CreateUserService(IUserStorage userStorage, UserServiceElement serviceConfig)
        {
            AppDomain domain = AppDomain.CreateDomain(serviceConfig.AppDomainName + serviceConfig.Name);

            domain.Load("BLL");

            UserRepository userRepository = (UserRepository)domain.CreateInstanceAndUnwrap("DAL", "DAL.UserRepository",
                false, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance,
                null, new object[] { userStorage }, null, null);

            if (serviceConfig.IsMaster)
            {
                IUserTransmitter userTransmitter =
                    (UdpSender) domain.CreateInstanceAndUnwrap("BLL", serviceConfig.Transmitter,
                        false, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance,
                        null, new object[] {}, null, null);
            }
            return null;
        }
    }
}