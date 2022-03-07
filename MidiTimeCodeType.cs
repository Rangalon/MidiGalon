using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum MidiTimeCodeType : byte
    {
        /// <summary>
        /// 24 frames per second.
        /// </summary>
        TwentyFour = 0,

        /// <summary>
        /// 25 frames per second.
        /// </summary>
        TwentyFive = 1,

        /// <summary>
        /// 29.97 frames per second (also called "30 drop").
        /// </summary>
        ThirtyDrop = 2,

        /// <summary>
        /// 30 frames per second.
        /// </summary>
        Thirty = 3
    }
}
