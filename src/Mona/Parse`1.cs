using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mona
{
    /// <summary>
    /// Represents the result of a parser's work
    /// </summary>
    /// <typeparam name="TNode">The type of the resulting tree node</typeparam>
    internal class Parse<TNode> : IParse<TNode>
    {
        public Parse(
            TNode node,
            ReadOnlyMemory<char> remainder,
            Exception error
            )
        {
            Node = node;
            Remainder = remainder;
            Error = error;
        }

        public TNode Node { get; }

        /// <summary>
        /// The remaining Input, if any
        /// </summary>
        public ReadOnlyMemory<char> Remainder { get; }

        /// <summary>
        /// The exception, if one occurred. Null otherwise
        /// </summary>
        public Exception Error { get; }
    }
}
