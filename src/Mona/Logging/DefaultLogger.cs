using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Mona.Logging
{
    public class DefaultLogger : ILogger
    {
        public DefaultLogger(ILogger internalLogger)
        {
            this.internalLogger = internalLogger;
        }
        readonly ILogger internalLogger;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            internalLogger.Log(logLevel, eventId, state, exception, formatter);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return internalLogger.IsEnabled(logLevel);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return internalLogger.BeginScope(state);
        }
    }
}
