﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Storage.Validators
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> validationErrors;

        public ValidationResult(IEnumerable<ValidationError> validationErrors)
        {
            this.validationErrors = validationErrors?.ToList() ?? new List<ValidationError>();
        }

        public ICollection<ValidationError> ValidationErrors => validationErrors;

        public bool IsValid => validationErrors.Count == 0;
    }
}
