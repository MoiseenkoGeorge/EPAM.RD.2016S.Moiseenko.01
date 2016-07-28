using System;
using System.Collections.Generic;

namespace Storage.Validators
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> validationResults)
        {
            ValidationResults = validationResults;
        }

        public IEnumerable<ValidationResult> ValidationResults { get; private set; }
    }
}