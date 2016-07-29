using System;
using System.Collections.Generic;
using System.ServiceModel;
using Entities;

namespace BLL.Interfacies
{
    [ServiceContract]
    public interface IUserService : IService
    {
        [OperationContract]
        int AddUser(User user);

        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        List<int> FindUsers(Func<User, bool>[] funcs);
    }
}