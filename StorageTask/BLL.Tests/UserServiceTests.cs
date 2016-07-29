using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Interfacies;
using DAL;
using Storage.Storages;
using Storage.Generators;
using Storage.Validators;
using Entities;
using System.Diagnostics;
using BLL.Configurations;
using BLL.Configurations.UserServiceConfigurations;
using BLL.Loggers;
using BLL.Loggers.Interfacies;
using Storage.Storages.Interfacies;

namespace BLL.Tests
{
    [Serializable]
    [TestFixture]
    public class UserServiceTests
    {
        private IUserStorage userStorage;
        private ILogger logger;

        private User validUser;
        [SetUp]
        public void Init()
        {
            //userStorage = AppDomain.CurrentDomain.CreateInstanceAndUnwrap("")
            userStorage = new UserMemoryStorage(new Generator(), new Validator(), ConfigurationManager.AppSettings["FileName"]);
            logger = new Logger();
            validUser = new User()
            {
                FirstName = "asd",
                LastName = "asd",
                Birthday = DateTime.Now,
                Gender = Gender.Male
            };
        }

        [Test]
        public void UserService_CreateUserServicesFromAppconfig_ReturnAllGood()
        {
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var userServices = configurator.GetUserServices();

        }


        [Test]
        public void UserService_CreateUserServicesWithTwoMasters_ReturnAnException()
        {
            var userServiceConfigurator = new UserServiceConfigurator(userStorage, logger, 2, 2);
            Assert.Throws<InvalidOperationException>(() => userServiceConfigurator.GetUserServices());
        }

        [Test]
        public void UserService_CreateThreeUserServicesFromAppConfig_ReturnThreeServices()
        {
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var result = configurator.GetUserServices();
            Assert.AreEqual(3, result.Item2.Length + 1);
        }

        [Test]
        public void UserService_AddUserThrowSlaveUserService_ThrowAnException()
        {
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var result = configurator.GetUserServices();
            Assert.Throws<InvalidOperationException>(() => result.Item1.AddUser(validUser));
        }

        [Test]
        public void UserService_AddUserThrowMasterUserService_SlaveUserServiceAttachUser()
        {
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var result = configurator.GetUserServices();
            result.Item1.AddUser(validUser);
            Assert.AreEqual(0, result.Item2[0].FindUsers(new Func<User, bool>[] { u => u.FirstName == validUser.FirstName }).ToArray()[0]);
        }

        [Test]
        public void UserService_DeleteUserThrowMasterUserService_SlaveUserDetachUser()
        {
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var result = configurator.GetUserServices();
            result.Item1.AddUser(validUser);
            result.Item1.DeleteUser(validUser);
            Assert.AreEqual(0, result.Item2[1].FindUsers(new Func<User, bool>[] { u => u.FirstName == validUser.FirstName }).Count);
        }
    }
}
