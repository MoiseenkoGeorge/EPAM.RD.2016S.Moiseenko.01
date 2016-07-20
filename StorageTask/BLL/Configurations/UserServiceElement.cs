using System.Configuration;

namespace BLL.Configurations
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
            get { return bool.Parse(base["isMaster"].ToString()); }
            set { base["isMaster"] = value; }
        }
    }
}
