using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using BLL;
using BLL.Configurations.UserServiceConfigurations;
using BLL.Loggers;
using Storage.Generators;
using Storage.Storages;
using Storage.Validators;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/service/";
            var userStorage = new UserMemoryStorage(new Generator(), new Validator(), ConfigurationManager.AppSettings["FileName"]);
            var logger = new Logger();
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var userServices = configurator.GetUserServices();
            var master = userServices.Item1;
            var slaves = userServices.Item2;
            var userServiceList = new List<LoggibleUserService>();
            if(slaves!= null) userServiceList.AddRange(slaves);
            if(master != null) userServiceList.Add(master);
            // Create the ServiceHost.
            foreach (var service in userServiceList)
            {
                ServiceHost host = new ServiceHost(service, new Uri(baseAddress + service.Name));
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
                };
                host.Description.Behaviors.Add(smb);

                host.Open();

                Console.WriteLine($"The  service is ready at {host.BaseAddresses[0]} " + (service.IsMaster ? "As Master" : "As Slave"));
            }
            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();
        }
    }
}
