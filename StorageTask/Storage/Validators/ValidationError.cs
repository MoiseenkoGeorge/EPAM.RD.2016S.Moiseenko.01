using System;

namespace Storage.Validators
{
    [Serializable]
    public class ValidationError
    {
        private readonly string propertyName;

        private readonly string errorMessage;

        public string PropertyName => propertyName;

        public string ErrorMessage => errorMessage;

        public ValidationError(string propertyName, string errorMessage)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }
}