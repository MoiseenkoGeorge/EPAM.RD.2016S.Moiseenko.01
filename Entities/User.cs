using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfacies;

namespace Entities
{
    public class User : IEntity
    {
        private readonly int id;

        public User(int id, string firstName, string lastName, DateTime birthday, Gender gender, VisaRecord[] visaRecords)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Gender = gender;
            VisaRecords = visaRecords;
        }

        public int Id => id;

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }

        public Gender Gender { get; private set; }

        public VisaRecord[] VisaRecords { get; private set; }

        public override int GetHashCode()
        {
            return Id ^ Birthday.Day ^ Birthday.Month ^ Birthday.Year;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            User user = (User)obj;
            return user.FirstName == FirstName && user.LastName == LastName;
        }
    }
}
