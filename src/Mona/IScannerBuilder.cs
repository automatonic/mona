using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using InputBuffer = System.Buffers.ReadOnlyBuffer<byte>;

namespace Mona
{
    /// <summary>
    /// Represents an environment for parsing input
    /// </summary>
    public interface IScannerBuilder
    {
        
        IParser Build();
    }
}
