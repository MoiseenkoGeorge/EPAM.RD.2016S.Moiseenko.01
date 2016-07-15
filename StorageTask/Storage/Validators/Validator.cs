using System;
using System.Collections.Generic;
using Entities;
using Storage.Validators.Interfacies;

namespace Storage.Validators
{
    public class Validator : IUserValidator
    {
        public ValidationResult Validate(User entity)
        {
            if(entity == null)
                throw new ArgumentNullException();

            List<ValidationError> validationErrors = new List<ValidationError>();

            ValidateFirstName(entity.FirstName, nameof(entity.FirstName), validationErrors);
            ValidateLastName(entity.LastName, nameof(entity.LastName), validationErrors);
            ValidateGender(entity.Gender, nameof(entity.Gender), validationErrors);
            ValidateBirthday(entity.Birthday,nameof(entity.Birthday),validationErrors);

            return new ValidationResult(validationErrors);
        }

        private void ValidateFirstName(string firstName, string paramName, ICollection<ValidationError> validationErrors)
        {
            if(string.IsNullOrWhiteSpace(firstName))
                validationErrors.Add(new ValidationError(paramName, "FirstName is required"));
        }

        private void ValidateLastName(string lastName, string paramName, ICollection<ValidationError> validationErrors)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                validationErrors.Add(new ValidationError(paramName, "LastName is required"));
        }

        private void ValidateGender(Gender gender, string paramName, ICollection<ValidationError> validationErrors)
        {
            if (gender == Gender.None)
                validationErrors.Add(new ValidationError(paramName, "Gender is Required"));
        }

        private void ValidateBirthday(DateTime birthday, string paramName, ICollection<ValidationError> validationErrors)
        {
            if(birthday == default(DateTime))
                validationErrors.Add(new ValidationError(paramName,"Birthday is required"));
        }

    }
}