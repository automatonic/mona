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
    public interface IParse<TNode>
    {
        /// <summary>
        /// The root/local node of the resulting tree
        /// </summary>
        TNode Node
        {
            get;
        }

        /// <summary>
        /// The remaining Input, if any
        /// </summary>
        ReadOnlyMemory<char> Remainder
        {
            get;
        }

        /// <summary>
        /// The exception, if one occurred. Null otherwise
        /// </summary>
        Exception Error
        {
            get;
        }
    }
}
