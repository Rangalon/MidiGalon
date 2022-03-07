using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum FfStatusBytePolicy
    {
        /// <summary>
        /// Read event as an instance <see cref="ResetEvent"/>.
        /// </summary>
        ReadAsResetEvent = 0,

        /// <summary>
        /// Read event as an instance dirived from <see cref="MetaEvent"/>.
        /// </summary>
        ReadAsMetaEvent
    }
}
