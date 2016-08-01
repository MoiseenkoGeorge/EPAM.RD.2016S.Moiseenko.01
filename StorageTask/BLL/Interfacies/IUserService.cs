using System;
using System.Collections.Generic;
using System.ServiceModel;
using Entities;
using Storage.Criterias;
using Storage.Criterias.Interfacies;

namespace BLL.Interfacies
{
    [ServiceContract]
    [ServiceKnownType(typeof(TrueCriteria))]
    [ServiceKnownType(typeof(BirthdayCriteria))]
    [ServiceKnownType(typeof(FirstNameCriteria))]
    [ServiceKnownType(typeof(GenderCriteria))]
    [ServiceKnownType(typeof(IdCriteria))]
    public interface IUserService
    {
        bool IsMaster { [OperationContract] get; }

        [OperationContract]
        int AddUser(User user);

        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        List<int> FindUsers(IUserCriteria[] funcs);
    }
}