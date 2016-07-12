using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfacies;
using Ninject;
using Storage;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IUserStorage>().To<UserStorage>();
        }
    }
}
