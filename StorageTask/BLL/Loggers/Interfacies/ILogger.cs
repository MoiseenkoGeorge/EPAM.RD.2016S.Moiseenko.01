using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Loggers.Interfacies
{
    public interface ILogger
    {

        bool IsActivated { get; }

        void SendMessage(TraceEventType type, string message);
    }

}
