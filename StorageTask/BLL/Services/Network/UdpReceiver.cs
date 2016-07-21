using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Entities;

namespace BLL.Services.Network
{
    public class UdpReceiver
    {
        private readonly Socket socket;

        private readonly IPEndPoint broadcastIpEndPoint;

        private readonly BinaryFormatter binaryFormatter;

        private object locker = new object();

        public bool IsActivate { get; }

        public event EventHandler<UserEventArgs> UserAdded = delegate { };

        public event EventHandler<UserEventArgs> UserDeleted = delegate { }; 

        public UdpReceiver(int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            broadcastIpEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
            socket.Bind(broadcastIpEndPoint);
            binaryFormatter = new BinaryFormatter();
        }

        public void Init()
        {
            lock (locker)
            {
                if (!IsActivate)
                {
                    Thread thread = new Thread(Receive);
                    thread.Start();
                }
                else
                {
                    throw new InvalidOperationException("receiver is already running");
                }
            }
        }

        private void Receive()
        {
            byte[] buffer = {};
            EndPoint remotEndPoint = broadcastIpEndPoint;
            try
            {
                while (true)
                {
                    var data = socket.ReceiveFrom(buffer, ref remotEndPoint);
                    using (var ms = new MemoryStream(data))
                    {
                        var packet = (Packet<User>)binaryFormatter.Deserialize(ms);
                        if (packet.MessageType == MessageType.UserAdded)
                        {
                            OnUserAdded(new UserEventArgs(packet.entity));
                        }
                        else
                        {
                            OnUserDeleted(new UserEventArgs(packet.entity));
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        protected virtual void OnUserAdded(UserEventArgs e)
        {
            EventHandler<UserEventArgs> temp = Volatile.Read(ref UserAdded);
            temp.Invoke(this, e);
        }

        protected virtual void OnUserDeleted(UserEventArgs e)
        {
            EventHandler<UserEventArgs> temp = Volatile.Read(ref UserDeleted);
            temp.Invoke(this, e);
        }

    }


    public class UserEventArgs : EventArgs
    {
        public User User { get; }

        public UserEventArgs(User user)
        {
            User = user;
        }
    }
}