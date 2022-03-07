using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public interface IInputDevice
    {
        /// <summary>
        /// Occurs when a MIDI event is received.
        /// </summary>
        event EventHandler<MidiEventReceivedEventArgs> EventReceived;

        /// <summary>
        /// Gets a value that indicates whether the current input device is currently listening for
        /// incoming MIDI events.
        /// </summary>
        bool IsListeningForEvents { get; }

        /// <summary>
        /// Starts listening for incoming MIDI events on the current input device.
        /// </summary>
        void StartEventsListening();

        /// <summary>
        /// Stops listening for incoming MIDI events on the current input device.
        /// </summary>
        void StopEventsListening();
    }
}
