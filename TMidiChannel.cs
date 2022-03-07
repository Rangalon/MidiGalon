using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MidiGalon
{
    public class TMidiChannel
    {
        [XmlArray("Evnts")]
        [XmlArrayItem("Evnt")]
        public List<TMidiNoteEvent> Events = new List<TMidiNoteEvent>();
    }
}
