using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BLL;
using BLL.Configurations.UserServiceConfigurations;
using BLL.Loggers;
using Entities;
using Storage.Generators;
using Storage.Storages;
using Storage.Validators;

namespace ConsoleTestApplication
{
    class Program
    {
        private static User validUser1 = new User()
        {
            FirstName = "Ivan",
            LastName = "Ivanov",
            Birthday = DateTime.Today,
            Gender = Gender.Male
        };

        private static User validUser2 = new User()
        {
            FirstName = "Viktorya",
            LastName = "Ivanova",
            Birthday = DateTime.Today,
            Gender = Gender.Female
        };

        static void Main()
        {
            var userStorage = new UserMemoryStorage(new Generator(), new Validator(), ConfigurationManager.AppSettings["FileName"]);
            var logger = new Logger();
            var configurator = new UserServiceConfigurator(userStorage,logger);
            var userServices = configurator.GetUserServices();
            for (int i = 0; i < 3; i++)
            {
                Thread masterThread = new Thread(() =>
                {
                    while (true)
                    {
                        int id = userServices[0].AddUser(validUser1);
                        validUser1.Id = id;
                        Console.WriteLine(
                            $"Name of service : {userServices[0].Name}, Count of users : {userServices[0].FindUsers(new Func<User, bool>[] {u => true}).Count}");
                        Thread.Sleep(1000);
                        userServices[0].DeleteUser(validUser1);
                    }
                });
                masterThread.Start();
            }
            for (int i = 0; i < 10; i++)
            {
                Thread slave1Thread = new Thread(() =>
                {
                    while (true)
                    {
                        Console.WriteLine(
                           $"Name of service : {userServices[1].Name}, Count of users : {userServices[1].FindUsers(new Func<User, bool>[] { u => true }).Count}");
                        Thread.Sleep(500);
                    }
                });
                slave1Thread.Start();
            }
        }
    }
}
