using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Interfacies;
using DAL.Interfacies;
using Entities;

namespace BLL
{
    public class MasterUserService : IUserService
    {
        public bool IsMaster => true;
        public event EventHandler<UserEventArgs> UserAdded = delegate { };
        public event EventHandler<UserEventArgs> UserDeleted = delegate { };

        private readonly IUserRepository userRepository;

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

        public int AddUser(User user)
        {
            int result = 0;
            try
            {
                result = userRepository.Create(user);
            }
            catch (Exception e)
            {
                throw e;
            }
            OnUserAdded(new UserEventArgs(user));
            return result;
        }

        public void DeleteUser(User user)
        {
            try
            {
                userRepository.Delete(user);
            }
            catch (Exception e)
            {
                throw e;
            }
            OnUserDeleted(new UserEventArgs(user));
        }

        public IEnumerable<int> FindUser(Func<User, bool>[] funcs)
        {
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}
