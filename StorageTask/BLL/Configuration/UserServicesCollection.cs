using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuration
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
