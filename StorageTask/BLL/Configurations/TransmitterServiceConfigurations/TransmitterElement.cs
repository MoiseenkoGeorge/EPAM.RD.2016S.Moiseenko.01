using System.Configuration;

namespace BLL.Configurations.TransmitterServiceConfigurations
{
    public class TransmitterElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("name", IsKey = false, IsRequired = true)]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
    }
}