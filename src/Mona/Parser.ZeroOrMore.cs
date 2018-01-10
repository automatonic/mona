// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     public static partial class Parser
//     {
//         /// <summary>
//         /// Creates a parser that expects zero or more occurrences of the nested parser to succeed
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <typeparam name="TResultNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <param name="parseSelector"></param>
//         /// <returns></returns>
//         public static IParser<TResultNode> ZeroOrMore< TNode, TResultNode>(
//             this IParser<TNode> parser, 
//             Func<IEnumerable<char>, IEnumerable<IParse<TNode>>, 
//             IParse<TResultNode>> parseSelector)
//         {
//             return Parser.Create< TResultNode>(
//                 parse: initialInput => {
                    
//                     var parses = new List<IParse<TNode>>();

//                     IParse<TNode> parse = null;
//                     IEnumerable<char> input = initialInput;
//                     while(true)
//                     {
//                         parse = parser.Parse(input);
//                         if (parse.Succeeded())
//                         {
//                             parses.Add(parse);
//                             input = parse.Remainder;
//                         }
//                         else
//                         {
//                             break;
//                         }
//                     }
                    
//                     return parseSelector(input, parses);
//                 }
//             );
//         }

//         /// <summary>
//         /// Creates a parser that expects zero or more occurrences of the nested parser to succeed
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <typeparam name="TResultNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <param name="nodeSelector"></param>
//         /// <returns></returns>
//         public static IParser<TResultNode> ZeroOrMore< TNode, TResultNode>(
//             this IParser<TNode> parser,
//             Func<IEnumerable<TNode>, TResultNode> nodeSelector)
//         {
//             return ZeroOrMore< TNode, TResultNode>(
//                 parser: parser,
//                 parseSelector: (input, nestedParses) =>
//                 {
//                     var remainder = input;
//                     var lastParse = nestedParses.LastOrDefault();
//                     if (lastParse != null)
//                     {
//                         remainder = lastParse.Remainder;
//                     }
//                     return new Parse< TResultNode>(
//                         nodeSelector(nestedParses.Select(nestedParse => nestedParse.Node)),
//                         remainder, null);
//                 });
//         }

//         /// <summary>
//         /// Creates a parser that expects zero or more occurrences of the nested parser to succeed
//         /// </summary>
//         /// <typeparam name="char"></typeparam>
//         /// <typeparam name="TNode"></typeparam>
//         /// <param name="parser"></param>
//         /// <returns></returns>
//         public static IParser<IEnumerable<TNode>> ZeroOrMore< TNode>(
//             this IParser<TNode> parser)
//         {
//             return ZeroOrMore< TNode, IEnumerable<TNode>>(
//                 parser: parser,
//                 parseSelector: (input, nestedParses) =>
//                 {
//                     var remainder = input;
//                     var lastParse = nestedParses.LastOrDefault();
//                     if (lastParse != null)
//                     {
//                         remainder = lastParse.Remainder;
//                     }
//                     return new Parse< IEnumerable<TNode>>(
//                         nestedParses.Select(nestedParse => nestedParse.Node),
//                         remainder, null);
//                 });
//         }
        
//     }
// }
