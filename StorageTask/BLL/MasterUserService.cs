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

        public override event EventHandler<UserEventArgs> UserAdded = delegate { };
        public override event EventHandler<UserEventArgs> UserDeleted = delegate { };

        protected virtual void OnUserAdded(UserEventArgs e)
        {
            EventHandler<UserEventArgs> temp = Volatile.Read(ref UserAdded);
            temp.Invoke(this,e);
        }

        protected virtual void OnUserDeleted(UserEventArgs e)
        {
            EventHandler<UserEventArgs> temp = Volatile.Read(ref UserDeleted);
            temp.Invoke(this, e);
        }

        public MasterUserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override int AddUser(User user)
        {
            int result = 0;
            result = userRepository.Create(user);
            OnUserAdded(new UserEventArgs(user));
            return result;
        }

        public override void DeleteUser(User user)
        {
            userRepository.Delete(user);
            OnUserDeleted(new UserEventArgs(user));
        }

        public IEnumerable<int> FindUser(Func<User, bool>[] funcs)
        {
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}
