// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     public static partial class Parser
//     {
//         /// <summary>
//         /// Given a parser, selects a variation based on applying the selector to the resulting parse
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <typeparam name="TResultNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <param name="selector"></param>
//         /// <returns></returns>
//         public static IParser<TResultNode> Select< TNode, TResultNode>(this IParser<TNode> parser, Func<IParse<TNode>, IParse<TResultNode>> selector)
//         {
//             return Create< TResultNode>(
//                 input =>
//                 {
//                     var parse = parser.Parse(input);
//                     return selector(parse);
//                 });
//         }

//         /// <summary>
//         /// Given a parser, selects a variation based on applying the selector to the resulting parse node
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <typeparam name="TResultNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <param name="selector"></param>
//         /// <returns></returns>
//         public static IParser<TResultNode> SelectNode< TNode, TResultNode>(this IParser<TNode> parser, Func<TNode, TResultNode> selector)
//         {
//             return Create< TResultNode>(
//                 input =>
//                 {
//                     var parse = parser.Parse(input);
//                     return parse.WithNode(selector(parse.Node));
//                 });
//         }
//     }
// }
