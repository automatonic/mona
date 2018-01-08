using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Mona
{
    /// <summary>
    /// Represents the ability to read zero or more inputs
    /// </summary>
    public interface IInputFeed 
    {
        /// <summary>
        /// The logger for this input reader
        /// </summary>
        /// <returns>An ILogger instance</returns>
        ILogger Logger { get; }

        /// <summary>
        /// Buffers the next input if possible
        /// </summary>
        /// <returns>The Uri of the next input or null if there is no next input</returns>
        Uri MoveNext();

        /// <summary>
        /// Asynchronously buffers the next input if possible
        /// </summary>
        /// <returns>The Uri of the next input or null if there is no next input</returns>
        Task<Uri> MoveNextAsync();
     
        /// <summary>
        /// Returns the current input
        /// </summary>
        /// <returns></returns>
        ReadOnlyMemory<char> Current { get; }
    }
}
