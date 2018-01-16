using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using InputBuffer = System.Buffers.ReadOnlyBuffer<byte>;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Mona
{
    /// <summary>
    /// A delegate that observes zero or more input buffers within a logging context
    /// </summary>
    /// <param name="loggerFactoyr">The logger factory</param>
    /// <returns></returns>
    public delegate IObservable<InputBuffer> InputObserverDelegate(ILoggerFactory loggerFactory);

    /// <summary>
    /// A helper class that rolls up standard input cases
    /// </summary>
    public static class Input
    {
        public static InputBuffer Empty() => new ReadOnlyBuffer<byte>();
        
        public static async Task<InputBuffer> SingleOrDefaultAsync(Uri uri) => 
            await Observe(uri)
                .SingleOrDefaultAsync();

        public static IObservable<InputBuffer> Observe(Uri uri)
        {
            loggerFactory = Logging.LoggerFactory.EnsureDefault(loggerFactory);
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            switch (uri.Scheme)
            {
                case "file": return ForFileInternal(uri: uri, encoding: null);
                case "data": return ForDataInternal(uri);
                default: throw new NotSupportedException();
            }   
        }

    }
}
