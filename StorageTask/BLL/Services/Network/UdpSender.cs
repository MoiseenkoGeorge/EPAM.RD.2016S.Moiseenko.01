using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Entities;

namespace BLL.Services.Network
{
    public class UdpSender<T> : IDisposable
    {
        private readonly Socket socket;
        private readonly IPEndPoint broadcastIpEndPoint;
        private readonly BinaryFormatter bf;

        public UdpSender(int port)
        {
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            broadcastIpEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
            bf = new BinaryFormatter();
        }

        public void SendData(MessageType type, T entity)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, new Packet<T>(type, entity));
                    socket.SendTo(ms.ToArray(), broadcastIpEndPoint);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Dispose()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Dispose();
        }
    }

    [Serializable]
    public enum MessageType
    {
        UserAdded = 1,
        UserDeleted
    }

    public struct Packet<T>
    {
        public MessageType MessageType;
        public T entity;

        public Packet(MessageType type, T entity)
        {
            MessageType = type;
            this.entity = entity;
        }
    }
}