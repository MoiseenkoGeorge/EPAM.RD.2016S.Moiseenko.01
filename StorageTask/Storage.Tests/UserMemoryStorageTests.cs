using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Storage.Generators;
using Storage.Storages;
using Storage.Storages.Interfacies;
using Storage.Validators;

namespace Storage.Tests
{
    [TestFixture]
    public class UserMemoryStorageTests
    {
        private IUserStorage userStorage;

        private User validUser1 = new User()
        {
            FirstName = "Ivan",
            LastName = "Ivanov",
            Birthday = DateTime.Today,
            Gender = Gender.Male
        };

        private User validUser2 = new User()
        {
            FirstName = "Viktorya",
            LastName = "Ivanova",
            Birthday = DateTime.Today,
            Gender = Gender.Female
        };

        [SetUp]
        public void Init()
        {
            userStorage = new UserMemoryStorage(new Generator(), new Validator(),ConfigurationManager.AppSettings["FileName"]);
            userStorage.Add(validUser1);
            userStorage.Add(validUser2);
        }

        #region Add

        [Test]
        public void Add_NewValidUser_ReturnIdFour()
        {
            User valUser = new User() { FirstName = "sad", LastName = "asd", Gender = Gender.Male, Birthday = DateTime.Today };
            var result = userStorage.Add(valUser);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Add_NewInvalidUser_ReturnAnException()
        {
            User invalidUser = new User();
            Assert.Throws<ValidationException>(() => userStorage.Add(invalidUser));
        }

        #endregion

        #region Delete

        [Test]
        public void Delete_UnExistingUser_ReturnAnException()
        {
            Assert.Throws<InvalidOperationException>(() => userStorage.Delete(8));
        }

        #endregion

        #region Search

        [Test]
        public void Search_SearchById_returnOneId()
        {
            var result = userStorage.Search(new Func<User, bool>[] { u => u.Id == 0 });
            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void Search_searchUsersWithFirstNameIvanAndBirthdayToday_returnIds()
        {
            var result =
                userStorage.Search(new Func<User, bool>[]
                {u => u.FirstName == "Ivan", u => u.Birthday == DateTime.Today});
            Assert.AreEqual(result.Count(), 1);
        }
        #endregion

        #region

        [Test]
        public void Save_SaveCurrentStateOfStorage_ReturnTrue()
        {
            var currentStorage = userStorage.Search(new Func<User, bool>[] { u => true });

            userStorage.Save();
            userStorage.Load();

            var result = userStorage.Search(new Func<User, bool>[] { u => true });
            Assert.AreEqual(currentStorage.Count(), result.Count());
        }
        #endregion
    }
}
