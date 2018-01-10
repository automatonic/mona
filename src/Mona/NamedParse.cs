// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     /// <summary>
//     /// A wrapping parse that enables a name on the exception
//     /// </summary>
//     /// <typeparam name="TNode">The type of the resulting tree node</typeparam>
//     internal class NamedParse<TNode> : IParse<TNode>
//     {
//         public NamedParse(IParse<TNode> parse, string name)
//         {
//             Parse = parse;
//             Name = name;
//         }
//         public IParse<TNode> Parse {get;}
//         public string Name {get;}

//         public TNode Node => Parse.Node;
//         public ReadOnlyMemory<char> Remainder => Parse.Remainder; 
//         public Exception Error
//         {
//             get 
//             {
//                 if (Parse.Error == null)
//                 {
//                     return null;
//                 }
//                 return new Exception(Name, Parse.Error);
//             }
//         }
//     }
// }
