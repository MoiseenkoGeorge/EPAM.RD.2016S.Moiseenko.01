using System;
using Entities;
using Storage.Criterias.Interfacies;

namespace Storage.Criterias
{
    [Serializable]
    public class FirstNameCriteria : IUserCriteria
    {
        public bool MeetCriteria(User entity)
        {
            return entity.FirstName == "Ivan";
        }
    }
}