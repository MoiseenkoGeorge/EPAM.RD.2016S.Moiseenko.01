using System;
using System.Runtime.Serialization;
using Entities;
using Storage.Criterias.Interfacies;

namespace Storage.Criterias
{
    [Serializable]
    public class TrueCriteria : IUserCriteria
    {
        public bool MeetCriteria(User entity)
        {
            return true;
        }
    }
}