using System;

namespace Attributes
{
    // Should be applied to .ctors.
    // Matches a .ctor parameter with property. Needs to get a default value from property field, and use this value for calling .ctor.
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true, Inherited = true)]
    public class MatchParameterWithPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public string Parametrname { get; set; }

        public MatchParameterWithPropertyAttribute(string paramName, string propertyName)
        {
            PropertyName = propertyName;
            Parametrname = paramName;
        }
    }
}
