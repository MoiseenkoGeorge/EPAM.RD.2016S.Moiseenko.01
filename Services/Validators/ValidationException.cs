using System;
using System.Collections.Generic;

namespace Services.Validators
{
    [Serializable]
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationResult> ValidationResults { get; private set; }

        public ValidationException(IEnumerable<ValidationResult> validationResults)
        {
            ValidationResults = validationResults;
        }  
    }
}