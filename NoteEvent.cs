using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class NoteEvent : ChannelEvent
    {
        #region Constructor

        protected NoteEvent(MidiEventType eventType) : base(eventType)
        {
        }


        protected NoteEvent(MidiEventType eventType, SevenBitNumber noteNumber, SevenBitNumber velocity)
            : this(eventType)
        {
            NoteNumber = noteNumber;
            Velocity = velocity;
        }

        #endregion

        #region Properties


        public SevenBitNumber NoteNumber
        {
            get { return (SevenBitNumber)_dataByte1; }
            set { _dataByte1 = value; }
        }


        public SevenBitNumber Velocity
        {
            get { return (SevenBitNumber)_dataByte2; }
            set { _dataByte2 = value; }
        }

        #endregion

        #region Overrides

        internal sealed override void Read(MidiReader reader, ReadingSettings settings, int size)
        {
            _dataByte1 = ReadDataByte(reader, settings);
            _dataByte2 = ReadDataByte(reader, settings);
        }

        internal sealed override void Write(MidiWriter writer, WritingSettings settings)
        {
            writer.WriteByte(_dataByte1);
            writer.WriteByte(_dataByte2);
        }

        internal sealed override int GetSize(WritingSettings settings)
        {
            return 2;
        }

        #endregion
    }
}
