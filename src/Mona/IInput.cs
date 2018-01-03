using System;

namespace Mona
{
    public interface IInput<T>
    {
        T Peek()
        Span<T> Slice();
    }
}
