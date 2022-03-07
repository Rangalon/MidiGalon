using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class ErrorOccurredEventArgs : EventArgs
    {
        #region Constructor

        internal ErrorOccurredEventArgs(Exception exception)
        {
            Exception = exception;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the exception caused an error.
        /// </summary>
        public Exception Exception { get; }

        #endregion
    }
}
