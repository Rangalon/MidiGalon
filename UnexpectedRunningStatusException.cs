using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class UnexpectedRunningStatusException : MidiException
    {
        #region Constructors

        internal UnexpectedRunningStatusException()
            : base("Unexpected running status is encountered.")
        {
        }

        #endregion
    }
}
