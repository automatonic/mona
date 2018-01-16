using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InputBuffer = System.Buffers.ReadOnlyBuffer<byte>;

namespace Mona
{
    /// <summary>
    /// Represents an observable source of zero or more input buffers
    /// </summary>
    public interface IInputProvider
    {
        bool TryObserve(Uri uri, out IObservable<InputBuffer> inputs);
    }
}
