using System;
using Entities;
using Storage.Criterias.Interfacies;

namespace Storage.Criterias
{
    [Serializable]
    public class IdCriteria : IUserCriteria
    {
        public bool MeetCriteria(User entity)
        {
            return entity.Id == 0;
        }
    }
}