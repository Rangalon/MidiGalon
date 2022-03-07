using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class CuePointEvent : BaseTextEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CuePointEvent"/>.
        /// </summary>
        public CuePointEvent()
            : base(MidiEventType.CuePoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CuePointEvent"/> with the
        /// specified text of cue.
        /// </summary>
        /// <param name="text">Text of the cue.</param>
        public CuePointEvent(string text)
            : base(MidiEventType.CuePoint, text)
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
            return new CuePointEvent(Text);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Cue Point ({Text})";
        }

        #endregion
    }
}
