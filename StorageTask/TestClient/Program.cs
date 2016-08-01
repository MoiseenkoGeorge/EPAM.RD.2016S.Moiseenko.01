using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            while (true)
            {
                if(client.get_IsMaster()) client.AddUser(validUser1);
                Thread.Sleep(1000);
                client.FindUsers(new object[] { new TrueCriteria() });
            }
            Console.ReadKey();
        }
    }
}
