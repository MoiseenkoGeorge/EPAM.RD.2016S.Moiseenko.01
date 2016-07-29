using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using BLL.Services.Network.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL.Interfacies
{
    public abstract class UserService : MarshalByRefObject, IUserService
    {
        protected readonly string name;

        protected readonly ReaderWriterLockSlim rwls;

        protected IUserRepository userRepository;

        protected ITransmitter<User> transmitter;

        protected UserService(string name)
        {
            this.name = name;
            rwls = new ReaderWriterLockSlim();
        }

        public string Name => name;

        public abstract bool IsMaster { get; }

        public abstract int AddUser(User user);

        public abstract void DeleteUser(User user);

        public virtual List<int> FindUsers(Func<User, bool>[] funcs)
        {
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}