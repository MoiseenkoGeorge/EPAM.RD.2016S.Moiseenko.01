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
    public class MasterUserService : IUserService
    {
        public bool IsMaster => true;
        public event EventHandler<UserEventArgs> UserAdded = delegate { };
        public event EventHandler<UserEventArgs> UserDeleted = delegate { };

        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

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

        public MasterUserService(IUserRepository userRepository, ILogger logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
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
                logger.Error($"error when create User, stacktrace - {e.StackTrace}");
                throw e;
            }
            logger.Info($"user has been added, his id = {result}");
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
                logger.Error($"error when delete User, stacktrace - {e.StackTrace}");
                throw e;
            }
            logger.Info($"User has been deleted, his id was = {user.Id}");
            OnUserDeleted(new UserEventArgs(user));
        }

        public IEnumerable<int> FindUser(Func<User, bool>[] funcs)
        {
            logger.Info("Master find users by key");
            return userRepository.GetUsersIdsByPredicate(funcs);
        }
    }
}
