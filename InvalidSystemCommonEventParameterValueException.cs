using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class InvalidSystemCommonEventParameterValueException : MidiException
    {
        #region Constructors

        internal InvalidSystemCommonEventParameterValueException(MidiEventType eventType, string componentName, int componentValue)
            : base($"{componentValue} is invalid value for the {componentName} property of a system common event of {eventType} type.")
        {
            EventType = eventType;
            ComponentName = componentName;
            ComponentValue = componentValue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of an event that caused this exception.
        /// </summary>
        public MidiEventType EventType { get; }

        /// <summary>
        /// Gets the name of MIDI Time Code event's component which value is invalid.
        /// </summary>
        public string ComponentName { get; }

        /// <summary>
        /// Gets the value of the system common event's parameter that caused this exception.
        /// </summary>
        public int ComponentValue { get; }

        #endregion
    }
}
