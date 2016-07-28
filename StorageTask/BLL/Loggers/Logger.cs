using System;
using System.Configuration;
using System.Diagnostics;
using BLL.Loggers.Interfacies;

namespace BLL.Loggers
{
    public class Logger : MarshalByRefObject, ILogger
    {
        private readonly TraceSource traceSource;

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

        public bool IsActivated { get; }

        public void SendMessage(TraceEventType type, string message)
        {
            if (IsActivated)
                traceSource.TraceEvent(type, 1, message);
        }
    }
}
