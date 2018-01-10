// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     public static partial class Expect
//     {
//         /// <summary>
//         /// Creates a parser that parses a single symbol with the specified predicate and failure message
//         /// </summary>
//         /// <typeparam name="TNode">The type of the resulting tree/node</typeparam>
//         /// <param name="predicate">A function to test each input symbol for a condition</param>
//         /// <param name="nodeSelector">A function to select the resulting node/tree type</param>
//         /// <param name="failureMessage">An error message returned on failure</param>
//         /// <returns>The specified parser.</returns>
//         public static IParser<TNode> Single<TNode>(Func<char, bool> predicate, Func<char, TNode> nodeSelector, string failureMessage)
//         {
//             failureMessage = failureMessage ?? 
//                 Strings.ErrorSinglePredicateFormat.Interpolate(
//                     Strings.SymbolTypeSymbol,
//                     Strings.PredicateUnspecified);

//             return Parser.Create<TNode>(
//                 parse: input =>
//                 {
//                     if (input.Length > 0)
//                     {
//                         var span = input.Span;
//                         var first = span[0];
//                         if (!first.Equals(default(char)))
//                         {
//                             if (predicate == null || predicate(first))
//                             {
//                                 return
//                                     new Parse<TNode>(
//                                     node: nodeSelector(first),
//                                     remainder: input.Skip(1),
//                                     error: null);  //Success
//                             }
//                             else
//                             {
//                                 return
//                                     new Parse<TNode>(
//                                     node: default(TNode),
//                                     remainder: input, //resend the consumed symbol
//                                     error: new Exception(failureMessage));
//                             }
//                         }
//                     }
//                     else
//                     {
//                         return 
//                             new Parse<TNode>(
//                             node: default(TNode),
//                             remainder: input,
//                             error: new Exception(failureMessage) //Error
//                         );
//                     }
//                 }
//             );
//         }

//         /// <summary>
//         /// Creates a parser that parses a single symbol with the specified predicate
//         /// </summary>
//         /// <typeparam name="TNode">The type of the resulting tree/node</typeparam>
//         /// <param name="nodeSelector">A function to select the resulting node/tree type</param>
//         /// <param name="predicate">A function to test each input symbol for a condition</param>
//         /// <returns>The specified parser.</returns>
//         public static IParser<TNode> Single<TNode>(Func<char, bool> predicate, Func< TNode> nodeSelector)
//         {
//             return Single< TNode>(
//                 predicate: predicate, 
//                 nodeSelector: nodeSelector, 
//                 failureMessage: null);
//         }

//         /// <summary>
//         /// Creates a parser that parses a single symbol with the specified predicate and failure message
//         /// </summary>
//         /// <typeparam name="char">The type of the input symbol</typeparam>
//         /// <param name="predicate">A function to test each input symbol for a condition</param>
//         /// <param name="failureMessage">An error message returned on failure</param>
//         /// <returns>The specified parser.</returns>
//         public static IParser<char> Single(Func<char, bool> predicate, string failureMessage)
//         {
//             return Single(
//                 predicate: predicate,
//                 nodeSelector: input => input,
//                 failureMessage: failureMessage);
//         }
        
//         /// <summary>
//         /// Creates a parser that parses a single symbol with the specified predicate
//         /// </summary>
//         /// <param name="predicate">A function to test each input symbol for a condition</param>
//         /// <returns>The specified parser.</returns>
//         public static IParser<char> Single(Func<char, bool> predicate)
//         {
//             return Single(
//                 predicate: predicate, 
//                 failureMessage: null);
//         }

//         /// <summary>
//         /// Creates a parser that parses a single symbol
//         /// </summary>
//         /// <param name="failureMessage">An error message returned on failure</param>
//         /// <returns>The specified parser.</returns>
//         public static IParser<char> Single(string failureMessage)
//         {
//             failureMessage = failureMessage ??
//                 Strings.ErrorSinglePredicateFormat.Interpolate(
//                     Strings.SymbolTypeSymbol,
//                     Strings.PredicateUnspecified);

//             return Single(predicate: null, failureMessage: failureMessage);
//         }

//         /// <summary>
//         /// Creates a parser that parses a single symbol
//         /// </summary>
//         /// <typeparam name="char">The type of an input symbol</typeparam>
//         /// <returns>The specified parser.</returns>
//         public static IParser<char> Single()
//         {
//             return Single(failureMessage: null);
//         }

        
//     }
// }
