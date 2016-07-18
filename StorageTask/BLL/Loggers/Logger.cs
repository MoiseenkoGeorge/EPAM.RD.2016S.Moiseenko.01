using System;
using System.Configuration;
using BLL.Loggers.Interfacies;
using System.Diagnostics;

namespace BLL.Loggers
{
    public class Logger : ILogger
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
        public void Info(string message)
        {
            if(IsActivated)
                traceSource.TraceEvent(TraceEventType.Information, 1, message);
        }

        public void Warning(string message)
        {
            if (IsActivated)
                traceSource.TraceEvent(TraceEventType.Warning, 1, message);
        }

        public void Error(string message)
        {
            if (IsActivated)
                traceSource.TraceEvent(TraceEventType.Error, 1, message);
        }


    }
}
