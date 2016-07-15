using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfacies;
using Entities;
using Ninject;
using Storage;
using Storage.Generators;
using Storage.Generators.Interfacies;
using Storage.Storages;
using Storage.Storages.Interfacies;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IUserStorage>().To<UserMemoryStorage>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IGenerator<int>>().To<Generator>();
            kernel.Bind<ICollection<User>>().To<HashSet<User>>();
        }
    }
}
