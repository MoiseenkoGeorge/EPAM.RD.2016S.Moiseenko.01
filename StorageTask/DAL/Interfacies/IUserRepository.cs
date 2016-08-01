using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities;
using Storage.Criterias.Interfacies;

namespace DAL.Interfacies
{
    public interface IUserRepository : IRepository<User>
    {
        List<int> GetUsersIdsByPredicate(IUserCriteria[] func);
    }
}