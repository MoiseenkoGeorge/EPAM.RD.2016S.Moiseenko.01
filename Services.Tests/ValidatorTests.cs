using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using  NUnit.Framework;
using Services.Validators;

namespace Services.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        private Validator validator;

        [SetUp]
        public void Init()
        {
            validator = new Validator();
        }

        #region FirstAndLastName

        [Test]
        [TestCaseSource(nameof(UserFirstNameAndLastNameGoodCases))]
        [TestCaseSource(nameof(UserFirstNameAndLastNameBadCases))]
        public bool Validate_UserFirstNameAndLastName_ReturnIsValidationResultContainsFirstNameOrLastNameKeys(
            string firstName, string lastName)
        {
            var user = new User() {FirstName = firstName, LastName = lastName};
            var result = validator.Validate(user);
            return result.ValidationErrors.Any(x => x.PropertyName == nameof(user.FirstName)) ||
                   result.ValidationErrors.Any(x => x.PropertyName == nameof(user.LastName));
        }

        private static IEnumerable<TestCaseData> UserFirstNameAndLastNameBadCases()
        {
            yield return new TestCaseData("", "Ivan").Returns(true);
            yield return new TestCaseData("  ", "").Returns(true);
            yield return new TestCaseData("Ivan", "").Returns(true);
            yield return new TestCaseData("Ivan","   ").Returns(true);
        }

        private static IEnumerable<TestCaseData> UserFirstNameAndLastNameGoodCases()
        {
            yield return new TestCaseData("Ivan","Ivanov").Returns(false);
        }

        #endregion

        #region Birhday
        [Test]
        [TestCaseSource(nameof(UserBirthdayBadCases))]
        [TestCaseSource(nameof(UserBirthdayGoodCases))]
        public bool Validate_UserBirthday_ReturnIsValidationResultContainsBirtdayKey(DateTime birthday)
        {
            var user = new User() {Birthday = birthday};
            var result = validator.Validate(user);
            return result.ValidationErrors.Any(x => x.PropertyName == nameof(user.Birthday));
        }

        private static IEnumerable<TestCaseData> UserBirthdayBadCases()
        {
            yield return new TestCaseData(default(DateTime)).Returns(true);
        }

        private static IEnumerable<TestCaseData> UserBirthdayGoodCases()
        {
            yield return new TestCaseData(DateTime.Now).Returns(false);
        }

        #endregion

        [Test]
        [TestCaseSource(nameof(UserGenderBadCases))]
        [TestCaseSource(nameof(UserGenderGoodCases))]
        public bool Validate_Gender_ReturnIsValidationResultContainsGenderKeys(Gender gender)
        {
            var user = new User() {Gender = gender};
            var result = validator.Validate(user);
            return result.ValidationErrors.Any(x => x.PropertyName == nameof(user.Gender));
        }

        private static IEnumerable<TestCaseData> UserGenderBadCases()
        {
            yield return new TestCaseData(Gender.None).Returns(true);
        }

        private static IEnumerable<TestCaseData> UserGenderGoodCases()
        {
            yield return new TestCaseData(Gender.Male).Returns(false);
            yield return new TestCaseData(Gender.Female).Returns(false);
        } 
         
    }
        

        
}