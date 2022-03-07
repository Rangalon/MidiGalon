using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal interface IEventReader
    {
        #region Methods

        MidiEvent Read(MidiReader reader, ReadingSettings settings, byte currentStatusByte);

        #endregion
    }
}
