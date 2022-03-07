using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum BufferingPolicy
    { 
        UseFixedSizeBuffer = 0, 
        DontUseBuffering, 
        UseCustomBuffer, 
        BufferAllData
    }
}
