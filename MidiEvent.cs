using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class MidiEvent
    {
        #region Constants

        public const int UnknownContentSize = -1;

        #endregion

        #region Fields

        internal long _deltaTime;

        #endregion

        #region Constructor


        public MidiEvent(MidiEventType eventType)
        {
            EventType = eventType;
        }

        #endregion

        #region Properties


        public MidiEventType EventType { get; }

        public long DeltaTime
        {
            get { return _deltaTime; }
            set
            {
                //ThrowIfArgument.IsNegative(nameof(value), value, "Delta-time is negative.");

                _deltaTime = value;
            }
        }

        internal bool Flag { get; set; }

        #endregion

        #region Methods


        internal abstract void Read(MidiReader reader, ReadingSettings settings, int size);


        internal abstract void Write(MidiWriter writer, WritingSettings settings);

        internal abstract int GetSize(WritingSettings settings);


        protected abstract MidiEvent CloneEvent();


        public MidiEvent Clone()
        {
            var TMidiEvent = CloneEvent();
            TMidiEvent._deltaTime = _deltaTime;
            return TMidiEvent;
        }


        public static bool Equals(MidiEvent midiEvent1, MidiEvent midiEvent2)
        {
            string message;
            return Equals(midiEvent1, midiEvent2, out message);
        }

        public static bool Equals(MidiEvent midiEvent1, MidiEvent midiEvent2, out string message)
        {
            return Equals(midiEvent1, midiEvent2, null, out message);
        }

        public static bool Equals(MidiEvent midiEvent1, MidiEvent midiEvent2, MidiEventEqualityCheckSettings settings)
        {
            string message;
            return Equals(midiEvent1, midiEvent2, settings, out message);
        }


        public static bool Equals(MidiEvent midiEvent1, MidiEvent midiEvent2, MidiEventEqualityCheckSettings settings, out string message)
        {
            return MidiEventEquality.Equals(midiEvent1, midiEvent2, settings ?? new MidiEventEqualityCheckSettings(), out message);
        }

        #endregion
    }
}
