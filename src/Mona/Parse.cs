using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mona
{
    /// <summary>
    /// Extension methods for IParse
    /// </summary>
    public static class Parse
    {
        /// <summary>
        /// Creates a new parse object, but with the specified error
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="parse"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IParse<TNode> WithError<TNode>(this IParse<TNode> parse, Exception exception)
        {
            return new Parse<TNode>(parse.Node, parse.Remainder, exception);
        }

        /// <summary>
        /// Creates a new parse object based on the original, but with a new node type and value
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <typeparam name="TResultNode"></typeparam>
        /// <param name="parse"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IParse<TResultNode> WithNode<TNode, TResultNode>(this IParse<TNode> parse, TResultNode node)
        {
            return new Parse<TResultNode>(node, parse.Remainder, parse.Error);
        }


        /// <summary>
        /// Indicates if the parse was a failure
        /// </summary>
        /// <typeparam name="TNode">The type of the resulting node</typeparam>
        /// <param name="parse">The parse result</param>
        /// <returns></returns>
        public static bool Failed<TNode>(this IParse<TNode> parse)
        {
            return parse.Error != null;
        }

        /// <summary>
        /// Indicates if the parse was a success
        /// </summary>
        /// <typeparam name="TNode">The type of the resulting node</typeparam>
        /// <param name="parse">The parse result</param>
        /// <returns></returns>
        public static bool Succeeded<TNode>(this IParse<TNode> parse)
        {
            return parse.Error == null;
        }
    }
}
