using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class InvalidMidiTimeCodeComponentException : MidiException
    {
        #region Constructors

        internal InvalidMidiTimeCodeComponentException(byte midiTimeCodeComponent)
            : base($"Invalid MIDI Time Code component ({midiTimeCodeComponent}).")
        {
            MidiTimeCodeComponent = midiTimeCodeComponent;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value representing MIDI time code component that caused this exception.
        /// </summary>
        public byte MidiTimeCodeComponent { get; }

        #endregion
    }
}
