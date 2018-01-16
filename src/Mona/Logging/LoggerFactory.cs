using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Mona.Logging
{
    public static class LoggerFactory
    {
        public static ILoggerFactory EnsureDefault() =>
            EnsureDefault(internalLoggerFactory: null);
        public static ILoggerFactory EnsureDefault(ILoggerFactory internalLoggerFactory)
        {
            return Default = Default ?? new DefaultLoggerFactory(
                internalLoggerFactory ?? new Microsoft.Extensions.Logging.LoggerFactory());
        }
        public static ILoggerFactory Default { get; private set; }
    }
}
