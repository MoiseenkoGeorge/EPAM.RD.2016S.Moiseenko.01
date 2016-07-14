using System;
using System.Collections.Generic;

namespace Entities.Interfacies
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<int> GetUsersIdsByPredicate(Func<User,bool>[] func);
    }
}