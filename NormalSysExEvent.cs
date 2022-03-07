using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class NormalSysExEvent : SysExEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalSysExEvent"/>.
        /// </summary>
        public NormalSysExEvent()
            : base(MidiEventType.NormalSysEx)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalSysExEvent"/> with the
        /// specified data.
        /// </summary>
        /// <param name="data">Data of the sysex event.</param>
        public NormalSysExEvent(byte[] data)
            : this()
        {
            //ThrowIfArgument.StartsWithInvalidValue(                nameof(data),                data,                EventStatusBytes.Global.NormalSysEx,                $"First data byte mustn't be {EventStatusBytes.Global.NormalSysEx} ({EventStatusBytes.Global.NormalSysEx:X2}) since it will be used automatically.");

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
            return new NormalSysExEvent(Data?.ToArray());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Normal SysEx";
        }

        #endregion
    }
}
