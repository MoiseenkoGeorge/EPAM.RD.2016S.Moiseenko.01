using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using BLL.Services.Network.Interfacies;
using Entities;

namespace BLL.Services.Network
{
    public sealed class BroadcastReceiver : MarshalByRefObject, IDisposable, IUserTransmitter
    {
        private readonly Socket socket;

        private readonly IPEndPoint broadcastIpEndPoint;

        private readonly BinaryFormatter binaryFormatter;

        private readonly object locker = new object();

        public BroadcastReceiver(int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            broadcastIpEndPoint = new IPEndPoint(IPAddress.Any, port);
            socket.Bind(broadcastIpEndPoint);
            binaryFormatter = new BinaryFormatter();
            ReceiveData();
        }

        public event EventHandler<UserEventArgs> UserAdded = delegate { };

        public event EventHandler<UserEventArgs> UserDeleted = delegate { };

        public bool IsActivate { get; private set; }

        public void SendData(MessageType messageType, User entity)
        {
            throw new InvalidOperationException("receiver doesn't send data");
        }

        public void ReceiveData()
        {
            lock (locker)
            {
                if (!IsActivate)
                {
                    var thread = new Thread(InitReceive);
                    thread.Start();
                    IsActivate = true;
                }
                else
                {
                    throw new InvalidOperationException("receiver is already running");
                }
            }
        }

        public void Dispose()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Dispose();
        }

        private void InitReceive()
        {
            byte[] buffer = new byte[10240];
            try
            {
                    SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
                socketAsyncEventArgs.RemoteEndPoint = broadcastIpEndPoint;
                    socketAsyncEventArgs.SetBuffer(buffer,0,buffer.Length);
                    socketAsyncEventArgs.Completed += ReceiveCompleted;
                    var bytesRead = socket.ReceiveFromAsync(socketAsyncEventArgs);
            }
            catch (Exception e)
            {
                return;
            }
        }

        private void ReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            using (var ms = new MemoryStream(e.Buffer))
            {
                var packet = (Packet<User>)binaryFormatter.Deserialize(ms);
                if (packet.MessageType == MessageType.TypeAdded)
                {
                    OnUserAdded(new UserEventArgs(packet.Entity));
                }
                else
                {
                    OnUserDeleted(new UserEventArgs(packet.Entity));
                }
            }
            InitReceive();
        }

        private void OnUserAdded(UserEventArgs e)
        {
            EventHandler<UserEventArgs> temp = Volatile.Read(ref UserAdded);
            temp.Invoke(this, e);
        }

        private void OnUserDeleted(UserEventArgs e)
        {
            EventHandler<UserEventArgs> temp = Volatile.Read(ref UserDeleted);
            temp.Invoke(this, e);
        }
    }

    public class UserEventArgs : EventArgs
    {
        public UserEventArgs(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}