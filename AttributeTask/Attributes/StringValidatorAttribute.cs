using System;

namespace Attributes
{
    // Should be applied to properties and fields.
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class StringValidatorAttribute : Attribute
    {
        private readonly int stringLength;

        public int MaxStringLength => stringLength;

        public StringValidatorAttribute(int stringLength)
        {
            this.stringLength = stringLength;
        }


    }
}
