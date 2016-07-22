using System;
using Entities;

namespace BLL.Services.Network.Interfacies
{
    public interface IUserTransmitter : ITransmitter<User>
    {
        event EventHandler<UserEventArgs> UserAdded;
        event EventHandler<UserEventArgs> UserDeleted;
    }
}