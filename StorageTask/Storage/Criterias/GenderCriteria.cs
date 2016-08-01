using System;
using Entities;
using Storage.Criterias.Interfacies;

namespace Storage.Criterias
{
    [Serializable]
    public class GenderCriteria : IUserCriteria
    {
        public bool MeetCriteria(User entity)
        {
            return entity.Gender == Gender.Male;
        }
    }
}