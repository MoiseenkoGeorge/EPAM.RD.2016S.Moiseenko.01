using System.Configuration;

namespace BLL.Configurations.TransmitterServiceConfigurations
{
    [ConfigurationCollection(typeof(TransmitterElement), AddItemName = "Transmitter")]
    public class TransmittersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TransmitterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TransmitterElement)(element)).Name;
        }
    }
}