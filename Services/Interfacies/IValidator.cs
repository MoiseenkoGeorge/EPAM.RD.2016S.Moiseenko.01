using System;
using Entities;
using Microsoft.Win32;

namespace Services.Interfacies
{
    public interface IValidator
    {
        bool Validate(User user);
        void ValidateBirthday(DateTime birthday);
    }
}