using System;
using System.Configuration;
using BLL.Loggers.Interfacies;
using System.Diagnostics;

namespace BLL.Loggers
{
    public class Logger : MarshalByRefObject, ILogger
    {
        private readonly TraceSource traceSource;
        public bool IsActivated { get; }

        public Logger(string traceSourceName)
        {
            this.traceSource = new TraceSource(traceSourceName);
            IsActivated = new BooleanSwitch("Activate", "Activate or disactivate logger").Enabled;
        }

        public Logger() : this(ConfigurationManager.AppSettings["TraceSourceName"])
        {
            
        }

        public Logger(bool isActivated)
        {
            IsActivated = isActivated;
        }

        public void SendMessage(TraceEventType type, string message)
        {
            if(IsActivated)
                traceSource.TraceEvent(type, 1, message);
        }

    }
}
