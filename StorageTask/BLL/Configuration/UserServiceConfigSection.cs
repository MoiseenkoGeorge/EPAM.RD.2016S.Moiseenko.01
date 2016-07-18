using System.Configuration;

namespace BLL.Configuration
{
    class UserServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Services")]
        public UserServicesCollection UserServiceItems => ((UserServicesCollection)(base["Services"]));
    }
}
