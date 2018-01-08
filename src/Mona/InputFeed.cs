using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mona
{
    public static class InputFeed
    {
        public static (Uri Uri, ReadOnlyMemory<char> Memory) FirstOrDefault(this IInputFeed inputFeed)
        {
            var uri = inputFeed.MoveNext();
            if (uri == null)
            {
                return (null, new ReadOnlyMemory<char>());
            }
            return (uri, inputFeed.Current);
        }

        public static bool TryGetFirst(this IInputFeed inputFeed, out (Uri Uri, ReadOnlyMemory<char> Memory) input)
        {
            var uri = inputFeed.MoveNext();
            if (uri == null)
            {
                input = (null, new ReadOnlyMemory<char>());
                return false;
            }
            input = (uri, inputFeed.Current);
            return true;
        }
    }
}
