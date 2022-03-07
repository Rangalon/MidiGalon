using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MidiGalon
{
    public class TMidiTimeSignature
    {
        [XmlAttribute]
        public int N;

        [XmlAttribute]
        public int D;
    }
}
