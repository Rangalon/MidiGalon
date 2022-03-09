﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum SmpteFormat : byte
    {
        /// <summary>
        /// 24 frame/sec.
        /// </summary>
        TwentyFour = 24,

        /// <summary>
        /// 25 frame/sec.
        /// </summary>
        TwentyFive = 25,

        /// <summary>
        /// 29.97 frame/sec (dropped 30).
        /// </summary>
        ThirtyDrop = 29,

        /// <summary>
        /// 30 frame/sec.
        /// </summary>
        Thirty = 30
    }
}
