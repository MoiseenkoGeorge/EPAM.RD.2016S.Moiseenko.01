using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    [Serializable]
    public class ValidationResult
    {
        private readonly List<ValidationError> validationErrors;

        public ICollection<ValidationError> ValidationErrors => validationErrors;

        public bool IsValid => validationErrors.Count == 0;

        public ValidationResult(IEnumerable<ValidationError> validationErrors)
        {
            this.validationErrors = validationErrors?.ToList() ?? new List<ValidationError>();
        }
    }
}
