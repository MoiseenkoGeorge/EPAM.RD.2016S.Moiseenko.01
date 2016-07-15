using System.Configuration;

namespace BLL.Configuration
{
    class UserServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("UserServices")]
        public UserServicesCollection UserServiceItems => ((UserServicesCollection)(base["UserServices"]));
    }
}
