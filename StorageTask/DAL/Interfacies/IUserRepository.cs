using System;
using System.Collections.Generic;
using Entities;

namespace DAL.Interfacies
{
    public interface IUserRepository : IRepository<User>
    {
        List<int> GetUsersIdsByPredicate(Func<User, bool>[] func);
    }
}