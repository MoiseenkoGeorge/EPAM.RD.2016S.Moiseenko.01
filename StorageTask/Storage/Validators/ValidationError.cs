using System;

namespace Storage.Validators
{
    [Serializable]
    public class ValidationError
    {
        private readonly string propertyName;

        private readonly string errorMessage;

        public ValidationError(string propertyName, string errorMessage)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }

        public string PropertyName => this.propertyName;

        public string ErrorMessage => this.errorMessage;
    }
}