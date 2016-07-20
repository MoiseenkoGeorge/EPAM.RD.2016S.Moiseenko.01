using System;
using System.Configuration;
using System.Linq;
using BLL.Interfacies;
using BLL.Loggers;
using DAL.Interfacies;

namespace BLL.Configurations
{
    public class UserServiceConfigurator
    {
        private readonly IUserRepository userRepository;

        private readonly int countOfMasters;
        private readonly int countOfSlaves;


        public UserServiceConfigurator(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }

            this.userRepository = userRepository;

            UserServiceConfigSection section = (UserServiceConfigSection)ConfigurationManager.GetSection("UserServices");

            if (section == null)
            {
                throw new InvalidOperationException("Section does not exist");
            }

            UserServiceElement[] userServiceElements = section.UserServiceItems.Cast<UserServiceElement>().ToArray();

            this.countOfMasters = userServiceElements.Count(s => s.IsMaster);
            this.countOfSlaves = userServiceElements.Count(s => !s.IsMaster);
        }

        public UserServiceConfigurator(IUserRepository userRepository,int countOfMasters,int countOfSlaves)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            this.userRepository = userRepository;
            this.countOfMasters = countOfMasters;
            this.countOfSlaves = countOfSlaves;
        }
        public IUserService[] GetServices()
        {
            if (this.countOfMasters != 1)
            {
                throw new InvalidOperationException();
            }

            if (this.countOfSlaves < 1)
            {
                throw new InvalidOperationException("Require at least one slave");
            }

            IUserService[] services = new IUserService[this.countOfMasters + this.countOfSlaves];

            services[0] = new MasterUserService(this.userRepository, new Logger());

            for (int i = 0; i < this.countOfSlaves; i++)
            {
                services[i + 1] = new SlaveUserService(this.userRepository, services[0], new Logger());
            }

            return services;
        }
    }
}