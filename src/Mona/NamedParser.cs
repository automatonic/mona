// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace Mona
// {
//     /// <summary>
//     /// A wrapping parser that enables a name
//     /// </summary>
//     /// <typeparam name="char">The type of the input symbol</typeparam>
//     /// <typeparam name="TNode">The type of the resulting tree node</typeparam>
//     internal class NamedParser< TNode> : IParser<TNode>
//     {
//         readonly string _Name;
//         readonly IParser<TNode> _Parser;
//         public NamedParser(IParser<TNode> parser, string name)
//         {
//             _Parser = parser;
//             _Name = name;
//         }

//         public IParse<TNode> Parse(IEnumerable<char> input)
//         {
//             var parse = _Parser
//                 .Parse(input);

//             if (parse.Failed())
//             {
//                 return new NamedParse< TNode>(parse, Name);
//             }
//             return parse;
//         }

//         public string Name
//         {
//             get { return _Name; }
//         }
//     }
// }
