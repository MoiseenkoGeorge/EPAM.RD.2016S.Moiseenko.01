using System.Configuration;

namespace BLL.Configurations.UserServiceConfigurations
{
    [ConfigurationCollection(typeof(UserServiceElement), AddItemName = "Service")]
    class UserServicesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new UserServiceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UserServiceElement)(element)).Name;
        }
    }
}
