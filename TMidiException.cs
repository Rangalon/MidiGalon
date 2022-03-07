using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class MidiException : Exception
    {
        #region Constructors
         
        internal MidiException()
        {
        }
         
        internal MidiException(string message)
            : base(message)
        {
        }
         
        internal MidiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
