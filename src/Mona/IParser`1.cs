using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InputBuffer = System.Buffers.ReadOnlyBuffer<byte>;

namespace Mona
{
    /// <summary>
    /// Represents the ability to parse a stream of input and yield a tree, bound with a single local node
    /// </summary>
    /// <typeparam name="TNode">The type of the resulting tree node</typeparam>
    public interface IParser<TNode>
    {
        ILoggerFactory LoggerFactory { get; }

        IEnumerable<IInputProvider> InputProviders { get; }

        Func<InputBuffer, Task<TNode>> ParseAsync { get;  }
    }
}
