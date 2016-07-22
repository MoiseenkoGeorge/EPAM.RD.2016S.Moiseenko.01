using System.Configuration;

namespace BLL.Configurations.UserServiceConfigurations
{
    class UserServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Services")]
        public UserServicesCollection UserServiceItems => ((UserServicesCollection)(base["Services"]));
    }
}
