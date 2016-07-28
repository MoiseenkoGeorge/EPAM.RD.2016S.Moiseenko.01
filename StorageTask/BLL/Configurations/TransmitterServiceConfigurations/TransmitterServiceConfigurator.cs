using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using BLL.Services.Network.Interfacies;

namespace BLL.Configurations.TransmitterServiceConfigurations
{
    public class TransmitterServiceConfigurator
    {
        private readonly TransmitterElement[] transmitterElements;

        public TransmitterServiceConfigurator()
        {
            var section = (TransmitterServiceConfigSection)ConfigurationManager.GetSection("TransmitterServices");
            if (section == null)
            {
                throw new InvalidOperationException("Section does not exist");
            }

            transmitterElements = section.TransmittersCollection.Cast<TransmitterElement>().ToArray();
        }

        public IUserTransmitter GetTransmitter(string name, AppDomain domain)
        {
            var transmitterElement = transmitterElements.SingleOrDefault(t => t.Name == name);
            if (transmitterElement == null)
                throw new InvalidOperationException("Transmitter with the same name is not exists");
            var transmitter = (IUserTransmitter)domain.CreateInstanceAndUnwrap("BLL", transmitterElement.Value
                , false, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance
                , null, new object[] { int.Parse(ConfigurationManager.AppSettings["Port"]) }, null, null);
            return transmitter;
        }
    }
}