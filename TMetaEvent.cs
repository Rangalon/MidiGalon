using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class MetaEvent : MidiEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEvent"/>.
        /// </summary>
        protected MetaEvent()
            : this(MidiEventType.CustomMeta)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEvent"/> with the specified event type.
        /// </summary>
        /// <param name="eventType">The type of event.</param>
        internal MetaEvent(MidiEventType eventType)
            : base(eventType)
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Reads content of a MIDI event.
        /// </summary>
        /// <param name="reader">Reader to read the content with.</param>
        /// <param name="settings">Settings according to which the event's content must be read.</param>
        /// <param name="size">Size of the event's content.</param>
        internal sealed override void Read(MidiReader reader, ReadingSettings settings, int size)
        {
            ReadContent(reader, settings, size);
        }

        /// <summary>
        /// Writes content of a MIDI event.
        /// </summary>
        /// <param name="writer">Writer to write the content with.</param>
        /// <param name="settings">Settings according to which the event's content must be written.</param>
        internal sealed override void Write(MidiWriter writer, WritingSettings settings)
        {
            WriteContent(writer, settings);
        }

        /// <summary>
        /// Gets the size of the content of a MIDI event.
        /// </summary>
        /// <param name="settings">Settings according to which the event's content must be written.</param>
        /// <returns>Size of the event's content.</returns>
        internal sealed override int GetSize(WritingSettings settings)
        {
            return GetContentSize(settings);
        }

        #endregion

        #region Methods

    
        public static byte[] GetStandardMetaEventStatusBytes()
        {
            return StandardMetaEventStatusBytes.GetStatusBytes();
        }
 
        protected abstract void ReadContent(MidiReader reader, ReadingSettings settings, int size);
 
        protected abstract void WriteContent(MidiWriter writer, WritingSettings settings);

         
        protected abstract int GetContentSize(WritingSettings settings);

        #endregion
    }
}
