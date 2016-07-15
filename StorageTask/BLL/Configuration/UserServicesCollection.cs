using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuration
{
    [ConfigurationCollection(typeof(UserServiceElement))]
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

        public UserServiceElement this[int idx] => (UserServiceElement)BaseGet(idx);
    }
}
