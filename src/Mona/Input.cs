using System;
using System.Diagnostics;

namespace Mona
{
    /// <summary>
    /// Input represents a contiguous region of memory that must be parsed in its entirety in order to be understood. 
    /// </summary>
    public readonly ref struct Input
    {
        internal Input(Uri uri, ReadOnlySpan<char> buffer)
        {
            Uri = uri;
            Buffer = buffer;
        }

        public readonly ReadOnlySpan<char> Buffer;
        public readonly Uri Uri;

        public override string ToString() => $"{Uri}:{Buffer}";
    }
}