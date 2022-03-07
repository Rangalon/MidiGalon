using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class TickGeneratorException : MidiException
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TickGeneratorException"/> class with the
        /// specified error message and an error code.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorCode">The error code.</param>
        public TickGeneratorException(string message, int errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the code of an error represented by the current <see cref="MidiDeviceException"/>.
        /// </summary>
        public int ErrorCode { get; }

        #endregion
    }
}
