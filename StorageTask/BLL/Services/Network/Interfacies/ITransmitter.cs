using System;
using Entities;

namespace BLL.Services.Network.Interfacies
{
    public interface ITransmitter<T>
    {     
        void SendData(MessageType messageType, T entity);
        void ReceiveData();
    }

    [Serializable]
    public enum MessageType
    {
        TypeAdded = 1,
        TypeDeleted
    }
}