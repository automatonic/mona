using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InputBuffer = System.Buffers.ReadOnlyBuffer<byte>;

namespace Mona
{
    /// <summary>
    /// Represents the ability to build a parser 
    /// </summary>
    public interface IParserBuilder<TNode, TToken>
        where TToken : IToken
    {
        IList<IInputProvider> InputProviders { get; }
        
        Func<InputBuffer, IObservable<TToken>> Tokenizer { get; set; }

        Func<IObservable<TToken>, Task<TNode>> Parser { get; set; }

        IParser<TNode> Build();
    }
}
