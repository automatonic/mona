using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Mona.InputFeeds
{
    /// <summary>
    /// An input enumerator that reads all text of the specified text reader as a single input and always returns the specified URI
    /// </summary>
    public class ReadAllText : IInputFeed
    {
        string buffer;
        readonly Uri uri;
        readonly TextReader textReader;

        public ReadAllText(Uri uri, TextReader textReader, ILogger<ReadAllText> logger)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (textReader == null)
            {
                throw new ArgumentNullException(nameof(textReader));
            }
            Logger = logger;
            this.uri = uri;
            this.textReader = textReader;
        }

        public ILogger Logger { get; }

        public ReadOnlyMemory<char> Current => buffer.AsReadOnlyMemory();

        public Uri MoveNext()
        {
            if (buffer != null)
            {
                Logger?.LogDebug("Already Moved Once");
                return null;
            }
            try
            {
                this.buffer = textReader.ReadToEnd();
                return this.uri;
            }
            catch (ArgumentOutOfRangeException aoorX)
            {
                Logger?.LogError(aoorX,"The number of characters is larger than MaxValue.");
            }
            catch (ObjectDisposedException odX)
            {
                Logger?.LogError(odX,"The text reader has been disposed.");
            }
            catch (InvalidOperationException ioX)
            {
                Logger?.LogError(ioX,"The reader is currently in use by a previous read operation.");
            }	
            return null;
        }

        public async Task<Uri> MoveNextAsync()
        {
            if (buffer != null)
            {
                Logger?.LogDebug("Already Moved Once");
                return null;
            }
            try
            {
                this.buffer = await textReader.ReadToEndAsync();
                return this.uri;
            }
            catch (ArgumentOutOfRangeException aoorX)
            {
                Logger?.LogError(aoorX,"The number of characters is larger than MaxValue.");
            }
            catch (ObjectDisposedException odX)
            {
                Logger?.LogError(odX,"The text reader has been disposed.");
            }
            catch (InvalidOperationException ioX)
            {
                Logger?.LogError(ioX,"The reader is currently in use by a previous read operation.");
            }	
            return null;
        }
    }
}
