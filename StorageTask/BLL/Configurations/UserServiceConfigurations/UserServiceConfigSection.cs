using System.Configuration;

namespace BLL.Configurations.UserServiceConfigurations
{
    internal class UserServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Services")]
        public UserServicesCollection UserServiceItems => ((UserServicesCollection)(base["Services"]));
    }
}
