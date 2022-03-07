using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class NoteOffEvent : NoteEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteOffEvent"/>.
        /// </summary>
        public NoteOffEvent()
            : base(MidiEventType.NoteOff)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteOffEvent"/> with the specified
        /// note number and velocity.
        /// </summary>
        /// <param name="noteNumber">Note number.</param>
        /// <param name="velocity">Velocity.</param>
        public NoteOffEvent(SevenBitNumber noteNumber, SevenBitNumber velocity)
            : base(MidiEventType.NoteOff, noteNumber, velocity)
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
            return new NoteOffEvent(NoteNumber, Velocity)
            {
                Channel = Channel
            };
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Note Off [{Channel}] ({NoteNumber}, {Velocity})";
        }

        #endregion
    }
}
