using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading;
using BLL.Services.Network;
using BLL.Services.Network.Interfacies;
using Entities;
using NUnit.Framework;
using Storage.Validators;

namespace BLL.Tests
{
    [TestFixture]
    public class NetworkServiceTests
    {
        private IUserTransmitter sender;

        private IUserTransmitter receiver;

        private List<User> users;

        private User validUser;

        private object locker = new object();

        [SetUp]
        public void Init()
        {
            validUser = new User()
            {
                FirstName = "asd",
                LastName = "asd",
                Birthday = DateTime.Now,
                Gender = Gender.Male
            };
            users = new List<User>();
            sender = new BroadcastSender(int.Parse(ConfigurationManager.AppSettings["Port"]));
            receiver = new BroadcastReceiver(11000);
            receiver.ReceiveData();
            receiver.UserAdded += (o, args) =>
            {
                lock (locker)
                {
                    users.Add(args.User);
                }
            };
            receiver.UserDeleted += (o, args) =>
            {
                lock (locker)
                {
                    users.Remove(args.User);
                }
            };
        }

        [Test]
        public void UdpReceiver_SendValidUserThrowSenderAndReceiveHimByReceiverAndAddToList_ReturnLengthOfListOne()
        {
            sender.SendData(MessageType.TypeAdded, validUser);
            Thread.Sleep(10);
            lock (locker)
            {
                Assert.AreEqual(users.Count, 1);
            }
        }

        [Test]
        public void UdpReciever_DeleteValidUserAndSendMessageAboutIt_ReturnLengthOfListZero()
        {
            sender.SendData(MessageType.TypeAdded, validUser);
            Thread.Sleep(10);
            sender.SendData(MessageType.TypeDeleted, validUser);
            Thread.Sleep(10);
            lock (locker)
            {
                Assert.AreEqual(0,users.Count);
            }
        }
    }
}