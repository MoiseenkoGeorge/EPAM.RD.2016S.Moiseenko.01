using System.Configuration;

namespace BLL.Configurations.UserServiceConfigurations
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

        [ConfigurationProperty("appDomainName",IsKey = false, IsRequired = true)]
        public string AppDomainName
        {
            get { return ((string) (base["appDomainName"])); }
            set { base["appDomainName"] = value; }
        }

        [ConfigurationProperty("transmitter", IsKey = false, IsRequired = true)]
        public string Transmitter
        {
            get { return ((string) (base["transmitter"])); }
            set { base["transmitter"] = value; }
        }
    }
}
