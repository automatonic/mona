using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mona
{
    /// <summary>
    /// Represents the ability to parse a stream of input and yield a tree, bound with a single local node
    /// </summary>
    /// <typeparam name="TNode">The type of the resulting tree node</typeparam>
    public interface IParser<TNode>
    {
        /// <summary>
        /// Parse as much of the input stream as possible, and return the result as a "Parse"
        /// </summary>
        /// <param name="input">An observable stream of input symbols</param>
        /// <returns></returns>
        IParse<TNode> Parse(ReadOnlyMemory<char> input);
    }
}
