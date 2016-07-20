using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using Entities;

namespace BLL
{
    public class LoggibleUserService : UserService
    {
        private ILogger logger;

        private readonly UserService userService;

        public override bool IsMaster => userService.IsMaster;
        public override event EventHandler<UserEventArgs> UserAdded
        {
            add { userService.UserAdded += value; }
            remove { userService.UserDeleted -= value; }
        }

        public override event EventHandler<UserEventArgs> UserDeleted
        {
            add { UserDeleted += value; }
            remove { UserDeleted -= value; }
        }

        public LoggibleUserService(ILogger logger, UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        public override int AddUser(User user)
        {
            try
            {
                userService.AddUser(user);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<int> FindUsers(Func<User, bool>[] funcs)
        {
            logger.SendMessage(TraceEventType.Information, "Find user by predicates");
            var result = userService.FindUsers(funcs);
            logger.SendMessage(TraceEventType.Information, $"Searched {result.Count()} users");
            return result;
        }
    }
}