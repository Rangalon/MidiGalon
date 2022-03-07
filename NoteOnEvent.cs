using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class NoteOnEvent : NoteEvent
    {
        #region Constructor

        public NoteOnEvent()
            : base(MidiEventType.NoteOn)
        {
        }


        public NoteOnEvent(SevenBitNumber noteNumber, SevenBitNumber velocity)
            : base(MidiEventType.NoteOn, noteNumber, velocity)
        {
        }

        #endregion

        #region Overrides


        protected override MidiEvent CloneEvent()
        {
            return new NoteOnEvent
            {
                _dataByte1 = _dataByte1,
                _dataByte2 = _dataByte2,
                Channel = Channel
            };
        }



        #endregion
    }
}
