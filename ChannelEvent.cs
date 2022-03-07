using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class ChannelEvent : MidiEvent
    {
        #region Fields

        internal byte _dataByte1;
        internal byte _dataByte2;

        #endregion

        #region Constructor
 
        protected ChannelEvent(MidiEventType eventType)
            : base(eventType)
        {
        }

        #endregion

        #region Properties

       
        public FourBitNumber Channel { get; set; }

        #endregion

        #region Methods

 
        protected byte ReadDataByte(MidiReader reader, ReadingSettings settings)
        {
            var value = reader.ReadByte();
            if (value > SevenBitNumber.MaxValue)
            {
                switch (settings.InvalidChannelEventParameterValuePolicy)
                {
                    case InvalidChannelEventParameterValuePolicy.Abort:
                        throw new InvalidChannelEventParameterValueException(EventType, value);
                    case InvalidChannelEventParameterValuePolicy.ReadValid:
                        value &= SevenBitNumber.MaxValue;
                        break;
                    case InvalidChannelEventParameterValuePolicy.SnapToLimits:
                        value = SevenBitNumber.MaxValue;
                        break;
                }
            }

            return value;
        }

        #endregion
    }
}
