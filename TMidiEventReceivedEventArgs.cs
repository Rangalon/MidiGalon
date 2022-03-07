using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class MidiEventReceivedEventArgs : EventArgs
    {
        #region Constructor
         
        public MidiEventReceivedEventArgs(MidiEvent midiEvent)
        {
            //ThrowIfArgument.IsNull(nameof(midiEvent), midiEvent);

            Event = midiEvent;
        }

        #endregion

        #region Properties
 
        public MidiEvent Event { get; }

        #endregion
    }
}
