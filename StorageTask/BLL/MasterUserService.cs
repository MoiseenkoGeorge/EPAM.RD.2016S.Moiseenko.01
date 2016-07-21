using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public class MasterUserService : UserService
    {
        public override bool IsMaster => true;

        public MasterUserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override int AddUser(User user)
        {
            var result = userRepository.Create(user);
            return result;
        }

        public override void DeleteUser(User user)
        {
            userRepository.Delete(user);
        }
    }
}
