using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class NotEnoughBytesException : MidiException
    {
        #region Constructors

        internal NotEnoughBytesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        internal NotEnoughBytesException(string message, long expectedCount, long actualCount)
            : base(message)
        {
            ExpectedCount = expectedCount;
            ActualCount = actualCount;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the expected count of bytes.
        /// </summary>
        public long ExpectedCount { get; }

        /// <summary>
        /// Gets the actual count of bytes available in the reader's underlying stream.
        /// </summary>
        public long ActualCount { get; }

        #endregion
    }
}
