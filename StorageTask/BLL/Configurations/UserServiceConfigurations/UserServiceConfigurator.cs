using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using BLL.Configurations.TransmitterServiceConfigurations;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using BLL.Services.Network;
using BLL.Services.Network.Interfacies;
using DAL;
using DAL.Interfacies;
using Storage.Storages.Interfacies;

namespace BLL.Configurations.UserServiceConfigurations
{
    public class UserServiceConfigurator
    {
        private readonly IUserStorage userStorage;
        private readonly ILogger logger;

        private readonly int countOfMasters;
        private readonly int countOfSlaves;

        private UserServiceConfigSection section;
        private TransmitterServiceConfigurator tsc;

        public UserServiceConfigurator(IUserStorage userStorage, ILogger logger)
        {
            if (userStorage == null || logger == null)
            {
                throw new ArgumentNullException(nameof(userStorage));
            }

            this.userStorage = userStorage;
            this.logger = logger;
            section = (UserServiceConfigSection)ConfigurationManager.GetSection("UserServices");

            if (section == null)
            {
                throw new InvalidOperationException("Section does not exist");
            }

            tsc = new TransmitterServiceConfigurator();

            UserServiceElement[] userServiceElements = section.UserServiceItems.Cast<UserServiceElement>().ToArray();

            countOfMasters = userServiceElements.Count(s => s.IsMaster);
            countOfSlaves = userServiceElements.Count(s => !s.IsMaster);
        }

        public UserServiceConfigurator(IUserStorage userStorage, ILogger logger, int countOfMasters, int countOfSlaves)
        {
            if (userStorage == null)
                throw new ArgumentNullException(nameof(userStorage));
            this.userStorage = userStorage;
            this.logger = logger;
            this.countOfMasters = countOfMasters;
            this.countOfSlaves = countOfSlaves;
        }

        public Tuple<LoggibleUserService,LoggibleUserService[]> GetUserServices()
        {
            if (countOfMasters > 1)
                throw new InvalidOperationException();
            LoggibleUserService master = null;
            UserServiceElement[] userServiceElements = section.UserServiceItems.Cast<UserServiceElement>().ToArray();
            var slaveElements = userServiceElements.Where(s => !s.IsMaster);

            LoggibleUserService[] slaveServices = new LoggibleUserService[countOfSlaves];

            var masterElement = userServiceElements.SingleOrDefault(s => s.IsMaster);
            if(masterElement != null)
                master = CreateUserService(userStorage, masterElement);
            int i = 0;
            foreach (var config in slaveElements)
            {
                slaveServices[i++] = CreateUserService(userStorage, config);
            }

            return new Tuple<LoggibleUserService, LoggibleUserService[]>(master, slaveServices);
        }

        private LoggibleUserService CreateUserService(IUserStorage userStorage, UserServiceElement serviceConfig)
        {
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDomain")
            };
            AppDomain domain = AppDomain.CreateDomain(serviceConfig.AppDomainName + serviceConfig.Name, null, appDomainSetup);
            domain.Load("BLL");

            UserRepository userRepository = (UserRepository)domain.CreateInstanceAndUnwrap("DAL", "DAL.UserRepository",
                false, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance,
                null, new object[] { userStorage }, null, null);

            IUserTransmitter userTransmitter = tsc.GetTransmitter(serviceConfig.TransmitterName, domain);

            var typeName = serviceConfig.IsMaster ? "BLL.MasterUserService" : "BLL.SlaveUserService";

            UserService userService = (UserService)domain.CreateInstanceAndUnwrap("BLL", typeName, false, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance,
                null, new object[] { serviceConfig.Name, userRepository, userTransmitter }, null, null);

            return new LoggibleUserService(logger, userService);
        }
    }
}