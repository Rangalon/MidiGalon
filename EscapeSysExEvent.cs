﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class EscapeSysExEvent : SysExEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EscapeSysExEvent"/>.
        /// </summary>
        public EscapeSysExEvent()
            : base(MidiEventType.EscapeSysEx)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EscapeSysExEvent"/> with the
        /// specified data.
        /// </summary>
        /// <param name="data">Data of the "escape" sysex event.</param>
        public EscapeSysExEvent(byte[] data)
            : this()
        {
            //ThrowIfArgument.StartsWithInvalidValue(                nameof(data),                data,                EventStatusBytes.Global.EscapeSysEx,                $"First data byte mustn't be {EventStatusBytes.Global.EscapeSysEx} ({EventStatusBytes.Global.EscapeSysEx:X2}) since it will be used automatically.");

            Data = data;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Clones event by creating a copy of it.
        /// </summary>
        /// <returns>Copy of the event.</returns>
        protected override MidiEvent CloneEvent()
        {
            return new EscapeSysExEvent(Data?.ToArray());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Escape SysEx";
        }

        #endregion
    }
}
