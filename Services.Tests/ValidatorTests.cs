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

        [Test]
        [TestCaseSource(nameof(UserFirstNameAndLastNameGoodCases))]
        [TestCaseSource(nameof(UserFirstNameAndLastNameBadCases))]
        public bool Validate_UserFirstNameAndLastName_ReturnValidationResultWhichContainsFirstNameOrLastNameKeys(string firstName, string lastName)
        { 
            var user = new User() {FirstName = firstName, LastName = lastName};
            var result = validator.Validate(user);
            return result.ValidationErrors.Any(x => x.PropertyName == nameof(user.FirstName)) || ;
        }

        private static IEnumerable<TestCaseData> UserFirstNameAndLastNameBadCases()
        {
            yield return new TestCaseData("","Ivan").Returns(false);
        }
        private static IEnumerable<TestCaseData> UserFirstNameAndLastNameGoodCases()
        {
            yield return new TestCaseData(new object()).Returns(false);
        }
}