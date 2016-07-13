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
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public VisaRecord[] VisaRecords { get; set; }

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
