using System;
using System.Linq;
using System.Xml.Serialization;

namespace MidiGalon
{
    public class TMidiTrack
    {
        [XmlAttribute]
        public string Name { get; set; }
        public TMidiTimeSignature TimeSignature { get; set; }


        [XmlArray("Chns")]
        [XmlArrayItem("Chn")]
        public TMidiChannel[] Channels = { };

        [XmlAttribute]
        public byte N { get; set; }

        [XmlAttribute]
        public byte D { get; set; }

        [XmlAttribute]
        public int T { get; set; }

        public void Regularize()
        {
            //float r =  30f;
            //float n;
            //foreach (TMidiChannel ch in Channels)
            //{
            //    foreach (TMidiEvent e in ch.Events.Where(o=>o.Velocity>0))
            //    {
            //        n = (float)e.Date / r;
            //        if (n % 1 > 0)
            //        { 
            //        }
            //    }
            //}

        }

        internal TMidiChannel GetChannel(byte channel)
        {
            if (channel > Channels.Length)
            {
                Array.Resize(ref Channels, channel);
                Channels[channel - 1] = new TMidiChannel();
            }
            return Channels[channel - 1];
        }
    }
}
