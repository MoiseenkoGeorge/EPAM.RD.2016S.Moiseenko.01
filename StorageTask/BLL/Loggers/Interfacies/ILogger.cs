using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Loggers.Interfacies
{
    public interface ILogger
    {

        bool IsActivated { get; }

        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }

}
