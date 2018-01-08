using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mona
{
    public static class Input
    {
        public static ReadOnlyMemory<char> Empty() => "".AsReadOnlyMemory();
        
        public static ReadOnlyMemory<char> For(Uri uri)
        {
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

        public static ReadOnlyMemory<char> ForFile(Uri uri) => ForFile(uri: uri, encoding: null);
        
        public static ReadOnlyMemory<char> ForFile(Uri uri, Encoding encoding)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (!uri.IsFile)
            {
                throw new ArgumentException(nameof(uri), "URI must start with file://");
            }
            return ForFileInternal(uri, encoding);
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Data_URI_scheme
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static ReadOnlyMemory<char> ForData(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (uri.Scheme != "data")
            {
                throw new ArgumentException(nameof(uri), "URI must start with data://");
            }
            return ForDataInternal(uri);
        }

        static ReadOnlyMemory<char> ForDataInternal(Uri uri)
        {
            if (!uri.LocalPath.StartsWith(","))
            {
                throw new NotSupportedException("Only simplest 'data:,example%20ASCII%20string' format is supported");
            }
            var text = Uri.EscapeDataString(uri.LocalPath.TrimStart(','));
            using (var reader = new StringReader(text))
            {
                var input = new InputFeeds.ReadAllText(uri, reader, null);
                input.MoveNext();
                return input.Current;
            }
        }

        static ReadOnlyMemory<char> ForFileInternal(Uri uri, Encoding encoding)
        {
            using (var stream = File.OpenRead(uri.LocalPath))
            using (var reader = NewStreamReader(stream))
            {
                var input = new InputFeeds.ReadAllText(uri, reader, null);
                input.MoveNext();
                return input.Current;
            }

            StreamReader NewStreamReader(Stream stream) => 
            encoding != null ?
                new StreamReader(stream, encoding) : 
                new StreamReader(stream, true);
        }
    }
}
