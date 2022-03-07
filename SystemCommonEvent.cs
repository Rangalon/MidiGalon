using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public abstract class SystemCommonEvent : MidiEvent
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemCommonEvent"/> with the specified event type.
        /// </summary>
        /// <param name="eventType">The type of event.</param>
        protected SystemCommonEvent(MidiEventType eventType)
            : base(eventType)
        {
        }

        #endregion
    }
}
