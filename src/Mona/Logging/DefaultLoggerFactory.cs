using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Mona.Logging
{
    public class DefaultLoggerFactory : ILoggerFactory
    {
        public DefaultLoggerFactory(ILoggerFactory internalLoggerFactory)
        {
            this.loggerFactory = internalLoggerFactory;
        }
        readonly ILoggerFactory loggerFactory;
        public void AddProvider(ILoggerProvider provider)
        {
            if (!disposedValue)
            {
                this.loggerFactory.AddProvider(provider);
            }
            else
            {
                throw new ObjectDisposedException(nameof(DefaultLoggerFactory));
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            if (!disposedValue)
            {
                var internalLogger = this.loggerFactory.CreateLogger(categoryName);
                return new DefaultLogger(internalLogger);
            }
            else
            {
                throw new ObjectDisposedException(nameof(DefaultLoggerFactory));
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    loggerFactory.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
