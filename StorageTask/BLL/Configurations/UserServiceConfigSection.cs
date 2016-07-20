using System.Configuration;

namespace BLL.Configurations
{
    class UserServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Services")]
        public UserServicesCollection UserServiceItems => ((UserServicesCollection)(base["Services"]));
    }
}
