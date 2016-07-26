using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ConsoleTestApplication
{
    class Program
    {
        private User validUser1 = new User()
        {
            FirstName = "Ivan",
            LastName = "Ivanov",
            Birthday = DateTime.Today,
            Gender = Gender.Male
        };

        private User validUser2 = new User()
        {
            FirstName = "Viktorya",
            LastName = "Ivanova",
            Birthday = DateTime.Today,
            Gender = Gender.Female
        };

        static void Main()
        {
            

        }
    }
}
