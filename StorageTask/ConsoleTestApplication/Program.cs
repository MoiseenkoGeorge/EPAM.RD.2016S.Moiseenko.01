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
using Storage.Criterias;
using Storage.Criterias.Interfacies;
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
            var configurator = new UserServiceConfigurator(userStorage, logger);
            var userServices = configurator.GetUserServices();
            var master = userServices.Item1;
            var slaves = userServices.Item2;
            if (master != null)
            {
                Thread masterThread = new Thread(() =>
                {
                    while (true)
                    {
                        int id = master.AddUser(validUser1);
                        validUser1.Id = id;
                        Console.WriteLine(
                            $"Name of service : {master.Name}, Count of users : {master.FindUsers(new IUserCriteria[] {new TrueCriteria()}).Count}");
                        Thread.Sleep(2000);
                        master.AddUser(validUser2);
                        Console.WriteLine(
                            $"Name of service : {master.Name}, Count of users : {master.FindUsers(new IUserCriteria[] { new TrueCriteria()}).Count}");
                        Thread.Sleep(2000);
                        master.DeleteUser(validUser1);
                    }
                });
                masterThread.Start();
            }
            foreach (var slave in slaves)
            {
                Thread slaveThread = new Thread(() =>
                {
                    while (true)
                    {
                        Console.WriteLine(
                            $"Name of service : {slave.Name}, Count of users : {slave.FindUsers(new IUserCriteria[] { new TrueCriteria()}).Count}");
                        Thread.Sleep(1500);
                    }
                });
                slaveThread.Start();
            }
        }
    }
}
