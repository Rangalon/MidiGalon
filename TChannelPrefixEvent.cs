using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class ChannelPrefixEvent : MetaEvent
    {
        #region Constructor
         
        public ChannelPrefixEvent()
            : base(MidiEventType.ChannelPrefix)
        {
        }
         
        public ChannelPrefixEvent(byte channel)
            : this()
        {
            Channel = channel;
        }

        #endregion

        #region Properties
         
        public byte Channel { get; set; }

        #endregion

        #region Overrides
         
        protected override void ReadContent(MidiReader reader, ReadingSettings settings, int size)
        {
            Channel = reader.ReadByte();
        }
         
        protected override void WriteContent(MidiWriter writer, WritingSettings settings)
        {
            writer.WriteByte(Channel);
        }
         
        protected override int GetContentSize(WritingSettings settings)
        {
            return 1;
        }
         
        protected override MidiEvent CloneEvent()
        {
            return new ChannelPrefixEvent(Channel);
        }
         
        public override string ToString()
        {
            return $"Channel Prefix ({Channel})";
        }

        #endregion
    }
}
