﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using BLL.Services.Network.Interfacies;
using Entities;

namespace BLL.Services.Network
{
    [Serializable]
    public struct Packet<T>
    {
        public MessageType MessageType;

        public T Entity;

        public Packet(MessageType type, T entity)
        {
            MessageType = type;
            this.Entity = entity;
        }
    }

    public class BroadcastSender : MarshalByRefObject, IDisposable, IUserTransmitter
    {
        private readonly Socket socket;

        private readonly IPEndPoint broadcastIpEndPoint;

        private readonly BinaryFormatter bf;

        public BroadcastSender(int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            broadcastIpEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
            bf = new BinaryFormatter();
        }

        public event EventHandler<UserEventArgs> UserAdded
        {
            add { throw new InvalidOperationException(); }
            remove { throw new InvalidOperationException(); }
        }

        public event EventHandler<UserEventArgs> UserDeleted
        {
            add { throw new InvalidOperationException(); }
            remove { throw new InvalidOperationException(); }
        }

        public void SendData(MessageType type, User entity)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, new Packet<User>(type, entity));
                    SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs
                    {
                        RemoteEndPoint = broadcastIpEndPoint
                    };
                    socketAsyncEventArgs.SetBuffer(ms.ToArray(), 0, ms.ToArray().Length);
                    socket.SendToAsync(socketAsyncEventArgs);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void ReceiveData()
        {
            throw new InvalidOperationException("Sender doesn't accept data");
        }

        public void Dispose()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Dispose();
        }
    }
}