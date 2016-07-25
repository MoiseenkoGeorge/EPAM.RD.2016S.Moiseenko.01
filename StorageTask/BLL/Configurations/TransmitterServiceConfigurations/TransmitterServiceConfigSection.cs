using System.Configuration;

namespace BLL.Configurations.TransmitterServiceConfigurations
{
    public class TransmitterServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Transmitters")]
        public TransmittersCollection TransmittersCollection => (TransmittersCollection) base["Transmitters"];
    }
}