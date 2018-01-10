// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     public static partial class Expect
//     {
//         /// <summary>
//         /// Creates a parser that parses input symbols while the supplied predicate matches them
//         /// </summary>
//         /// <typeparam name="char">The type of an input symbol</typeparam>
//         /// <param name="predicate">A function to test each input symbol for a condition</param>
//         /// <param name="failureMessage">An error message returned on failure</param>
//         /// <returns>The parser.</returns>
//         public static IParser<ReadOnlyMemory<char>> While(Func<char, bool> predicate, string failureMessage)
//         {
//             failureMessage = failureMessage ??
//                 Strings.ErrorWhilePredicateFormat.Interpolate(
//                     Strings.SymbolTypeSymbol,
//                     Strings.PredicateUnspecified);

//             return Parser.Create<ReadOnlyMemory<char>>(
//                 parse: input => {
//                     var span = input.Span;
//                     for (int i = 0; i < span.Length; i++)
//                     {
//                         if (!predicate(span[i]))
//                         {
//                             var symbols = span.Slice(0,i);
//                             return new Parse<ReadOnlyMemory<char>>(
//                                     node: symbols,
//                                     remainder: span.Slice(i), //advance the input
//                                     error: null  //Success
//                                 );
//                         }
//                     }


//                 }
//             );
//         }

//         /// <summary>
//         /// Creates a parser that parses input symbols while the supplied predicate matches them
//         /// </summary>
//         /// <param name="predicate">A function to test each input symbol for a condition</param>
//         /// <returns>The parser.</returns>
//         public static IParser<ReadOnlyMemory<char>> While(Func<char, bool> predicate)
//         {
//             return While(predicate: predicate, failureMessage: null);
//         }

//         /// <summary>
//         /// Creates a parser that parses input symbols while the supplied predicate matches them
//         /// </summary>
//         /// <param name="predicate">A function to test each input symbol for a condition; the second parameter of the function represents the index of the source element.</param>
//         /// <param name="failureMessage">An error message returned on failure</param>
//         /// <returns>The parser.</returns>
//         public static IParser<ReadOnlyMemory<char>> While(Func<char, int, bool> predicate, string failureMessage)
//         {
//             failureMessage = failureMessage ??
//                 Strings.ErrorWhilePredicateFormat.Interpolate(
//                     Strings.SymbolTypeSymbol,
//                     Strings.PredicateUnspecified);

//             return Parser.Create< IEnumerable<char>>(
//                 parse: input =>
//                 {
//                     var symbols = input
//                         .TakeWhile(predicate)
//                         .ToList();
//                     return new Parse< IEnumerable<char>>(
//                             node: symbols,
//                             remainder: input, //advance the input
//                             error: null  //Success
//                         );
//                 }
//             );
//         }

//         /// <summary>
//         /// Creates a parser that parses input symbols while the supplied predicate matches them
//         /// </summary>
//         /// <typeparam name="char">The type of an input symbol</typeparam>
//         /// <param name="predicate">A function to test each input symbol for a condition; the second parameter of the function represents the index of the source element.</param>
//         /// <returns>The parser.</returns>
//         public static IParser<IEnumerable<char>> While<char>(Func< int, bool> predicate)
//         {
//             return While<char>(predicate: predicate, failureMessage: null);
//         }
//     }
// }
