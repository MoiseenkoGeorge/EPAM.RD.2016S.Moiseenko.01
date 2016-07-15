using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuration
{
    class UserServiceElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("isMaster", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool IsMaster
        {
            get { return bool.Parse((string)base["isMaster"]); }
            set { base["isMaster"] = value; }
        }
    }
}
