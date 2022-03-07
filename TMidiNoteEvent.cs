using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MidiGalon
{
    public class TMidiNoteEvent
    {
        [XmlAttribute("d")]
        public int Date;
        [XmlAttribute("n")]
        public int Note;
        [XmlAttribute("v")]
        public int Velocity;

        public override string ToString()
        {
            return Date.ToString() + " " + Note.ToString() + " " + Velocity.ToString();
        }
    }
}
