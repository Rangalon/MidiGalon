using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class InvalidMetaEventParameterValueException : MidiException
    {
        #region Constructors

        internal InvalidMetaEventParameterValueException(MidiEventType eventType, string propertyName, int value)
            : base($"{value} is invalid value for the {propertyName} property of a meta event of {eventType} type.")
        {
            EventType = eventType;
            PropertyName = propertyName;
            Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of event that caused this exception.
        /// </summary>
        public MidiEventType EventType { get; }

        /// <summary>
        /// Gets the name of event's property which value is invalid.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the value of the meta event's parameter that caused this exception.
        /// </summary>
        public int Value { get; }

        #endregion
    }
}
