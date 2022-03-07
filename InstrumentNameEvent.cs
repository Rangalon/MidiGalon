using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class InstrumentNameEvent : BaseTextEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InstrumentNameEvent"/>.
        /// </summary>
        public InstrumentNameEvent()
            : base(MidiEventType.InstrumentName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstrumentNameEvent"/> with the
        /// specified instrument name.
        /// </summary>
        /// <param name="instrumentName">Name of the instrument.</param>
        public InstrumentNameEvent(string instrumentName)
            : base(MidiEventType.InstrumentName, instrumentName)
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Clones event by creating a copy of it.
        /// </summary>
        /// <returns>Copy of the event.</returns>
        protected override MidiEvent CloneEvent()
        {
            return new InstrumentNameEvent(Text);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Instrument Name ({Text})";
        }

        #endregion
    }
}
