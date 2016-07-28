using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using BLL.Services.Network.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public sealed class MasterUserService : UserService
    {
        public MasterUserService(string name, IUserRepository userRepository, IUserTransmitter transmitter) : base(name)
        {
            if (userRepository == null || transmitter == null)
                throw new ArgumentNullException();
            this.userRepository = userRepository;
            this.transmitter = transmitter;
        }

        public override bool IsMaster => true;

        public override int AddUser(User user)
        {
            var result = userRepository.Create(user);
            user.Id = result;
            transmitter.SendData(MessageType.TypeAdded, user);
            return result;
        }

        public override void DeleteUser(User user)
        {
            userRepository.Delete(user);
            transmitter.SendData(MessageType.TypeDeleted, user);
        }
    }
}
