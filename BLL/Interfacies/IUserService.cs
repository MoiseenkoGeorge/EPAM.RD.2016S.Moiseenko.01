using System;
using System.Collections.Generic;
using Entities;

namespace BLL.Interfacies
{
    public interface IUserService : IService
    {
        event EventHandler<UserEventArgs> UserAdded;
        event EventHandler<UserEventArgs> UserDeleted;

        int AddUser(User user);
        void DeleteUser(User user);
        IEnumerable<int> FindUser(Func<User, bool>[] funcs);
    }

    public class UserEventArgs : EventArgs
    {
        public User User { get; }

        public UserEventArgs(User user)
        {
            User = user;
        }
    }
}