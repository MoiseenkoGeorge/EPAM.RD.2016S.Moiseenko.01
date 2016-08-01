using System;
using Entities;
using Storage.Criterias.Interfacies;

namespace Storage.Criterias
{
    [Serializable]
    public class BirthdayCriteria : IUserCriteria
    {
        public bool MeetCriteria(User entity)
        {
            return entity.Birthday == DateTime.MinValue;
        }
    }
}