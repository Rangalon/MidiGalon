using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum SilentNoteOnPolicy : byte
    {
        /// <summary>
        /// Read an event as <see cref="NoteOffEvent"/>.
        /// </summary>
        NoteOff = 0,

        /// <summary>
        /// Read an event as <see cref="NoteOnEvent"/>.
        /// </summary>
        NoteOn
    }
}
