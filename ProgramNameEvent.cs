using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class ProgramNameEvent : BaseTextEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramNameEvent"/>.
        /// </summary>
        public ProgramNameEvent()
            : base(MidiEventType.ProgramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramNameEvent"/> with the
        /// specified program name.
        /// </summary>
        /// <param name="programName">Name of the program.</param>
        public ProgramNameEvent(string programName)
            : base(MidiEventType.ProgramName, programName)
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
            return new ProgramNameEvent(Text);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Program Name ({Text})";
        }

        #endregion
    }
}
