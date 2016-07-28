using System;
using Entities;

namespace BLL.Services.Network.Interfacies
{
    [Serializable]
    public enum MessageType
    {
        TypeAdded = 1,
        TypeDeleted
    }

    public interface ITransmitter<T>
    {     
        void SendData(MessageType messageType, T entity);

        void ReceiveData();
    }
}