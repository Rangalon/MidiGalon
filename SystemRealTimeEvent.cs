using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class SystemRealTimeEvent : MidiEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemRealTimeEvent"/> with the specified event type.
        /// </summary>
        /// <param name="eventType">The type of event.</param>
        protected SystemRealTimeEvent(MidiEventType eventType)
            : base(eventType)
        {
        }

        #endregion

        #region Overrides

        internal override sealed void Read(MidiReader reader, ReadingSettings settings, int size)
        {
        }

        internal override sealed void Write(MidiWriter writer, WritingSettings settings)
        {
        }

        internal override sealed int GetSize(WritingSettings settings)
        {
            return 0;
        }

        #endregion
    }
}
