using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class InvalidChannelEventParameterValueException : MidiException
    {
        #region Constructors

        internal InvalidChannelEventParameterValueException(MidiEventType eventType, byte value)
            : base($"{value} is invalid value for parameter of channel event of {eventType} type.")
        {
            EventType = eventType;
            Value = value;
        }

        #endregion

        #region Properties
         
        public MidiEventType EventType { get; }
         
        public byte Value { get; }

        #endregion
    }
}
