using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.UserServiceReference;
namespace TestClient
{
    class Program
    {
        private static User validUser1 = new User()
        {
            FirstNamek__BackingField = "Ivan",
            LastNamek__BackingField = "Ivanov",
            Birthdayk__BackingField = DateTime.Today,
            Genderk__BackingField = Gender.Male
        };

        static void Main(string[] args)
        {
            UserServiceClient client = new UserServiceClient();
            client.AddUser(validUser1);
            Console.ReadKey();
        }
    }
}
