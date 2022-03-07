using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum UnknownChannelEventInstruction
    {
        /// <summary>
        /// Abort reading and throw <see cref="UnknownChannelEventException"/>.
        /// </summary>
        Abort,

        /// <summary>
        /// Skip data bytes.
        /// </summary>
        SkipData
    }
}
