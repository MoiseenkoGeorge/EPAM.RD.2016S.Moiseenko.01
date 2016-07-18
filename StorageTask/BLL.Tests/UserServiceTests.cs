using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BLL.Configuration;
using DAL.Interfacies;
using DAL;
using Storage.Storages;
using Storage.Generators;
using Storage.Validators;
using Entities;

namespace BLL.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserRepository userRepository;

        private User validUser;
        [SetUp]
        public void Init()
        {
            userRepository = new UserRepository(new UserMemoryStorage(new Generator(), new Validator(), ConfigurationManager.AppSettings["FileName"]));
            validUser = new User()
            {
                FirstName = "asd",
                LastName = "asd",
                Birthday = DateTime.Now,
                Gender = Gender.Male
            };
        } 
        [Test]
        public void UserService_CreateUserServices_ReturnAnException()
        {
            Assert.Throws<InvalidOperationException>(() => new UserServiceConfigurator(userRepository, 2, 2));
        }

        [Test]
        public void UserService_CreateThreeUserServicesFromAppConfig_ReturnThreeServices()
        {
            var configurator = new UserServiceConfigurator(userRepository);
            var result = configurator.GetServices();
            Assert.AreEqual(3, result.Length);
        }

        [Test]
        public void UserService_AddUserThrowSlaveUserService_ThrowAnException()
        {
            var configurator = new UserServiceConfigurator(userRepository);
            var result = configurator.GetServices();
            Assert.Throws<InvalidOperationException>(() => result[1].AddUser(validUser));
        }

        [Test]
        public void UserService_AddUserThrowMasterUserService_SlaveUserServiceHandleEvent()
        {
            var configurator = new UserServiceConfigurator(userRepository);
            var result = configurator.GetServices();
            Assert.Throws<NotImplementedException>( ( ) => result[0].AddUser(validUser) );
        }
    }
}
