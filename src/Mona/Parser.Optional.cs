// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     public static partial class Parser
//     {
//         /// <summary>
//         /// Creates a parser that makes the nested parser optional
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <typeparam name="TResultNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <param name="parseSelector"></param>
//         /// <returns></returns>
//         public static IParser<TResultNode> Optional< TNode, TResultNode>(this IParser<TNode> parser, Func<IParse<TNode>, IParse<TResultNode>> parseSelector)
//         {
//             return Parser.Create< TResultNode>(
//                 parse: input =>
//                 {
//                     var optionalParse = parser.Parse(input);
//                     return parseSelector(optionalParse);
//                 }
//             );
//         }

//         /// <summary>
//         /// Creates a parser that makes the nested parser optional
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <typeparam name="TResultNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <param name="nodeSelector"></param>
//         /// <returns></returns>
//         public static IParser<TResultNode> Optional< TNode, TResultNode>(this IParser<TNode> parser, Func<TNode, TResultNode> nodeSelector)
//         {
//             return Optional< TNode, TResultNode>(
//                 parser: parser,
//                 parseSelector: optionalParse =>
//                     new Parse< TResultNode>(nodeSelector(optionalParse.Node), optionalParse.Remainder, null)
//                     );
//         }
        
//     }
// }
