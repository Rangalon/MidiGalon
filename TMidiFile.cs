using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MidiGalon
{
    public class TMidiFile
    {

        [XmlIgnore]
        public readonly int Format = -1;
        [XmlAttribute]
        public readonly int TracksQuantity;
        [XmlAttribute]
        public readonly int TicksPerQuarter;

        public class TReader
        {
            [XmlIgnore]
            byte[] data;
            [XmlIgnore]
            int i;

            public int I { get => i; }

            public string GetMarker()
            {
                string stmp = "";
                while (stmp.Length < 4) { stmp += (char)data[i++]; }
                return stmp;
            }

            public byte Current { get => data[i]; }

            public Int32 GetInt32()
            {
                return (data[i++] << 24) | (data[i++] << 16) | (data[i++] << 8) | data[i++];
            }

            public byte GetByte()
            {
                return data[i++];
            }

            public Int32 GetUInt24()
            {
                return (data[i++] << 16) | (data[i++] << 8) | data[i++];
            }
            public Int32 GetUInt16()
            {
                return (data[i++] << 8) | data[i++];
            }

            public TReader(byte[] vs)
            {
                data = vs;
            }

            public int GetVarInt()
            {
                int result = data[i++];

                if ((result & 0x80) == 0)
                {
                    return result;
                }

                result &= 0x7F;

                for (int j = 0; j < 3; j++)
                {
                    int value = data[i++];

                    result = (result << 7) | (value & 0x7F);

                    if ((value & 0x80) == 0)
                    {
                        break;
                    }
                }

                return result;
            }

            internal string ReadString(int v)
            {
                string s = Encoding.UTF8.GetString(data, i, v);
                i += v;
                return s;
            }


        }

        [XmlIgnore]
        public TReader Reader;

        [XmlIgnore]
        string body = "";

        [XmlAttribute]
        public string Name { get; set; }

        public TMidiFile(string v)
        {
            Name = v.Substring(v.LastIndexOf("\\") + 1);

            Reader = new TReader(System.IO.File.ReadAllBytes(v));
            string stmp = ""; 

            // Primary Header
            stmp = Reader.GetMarker();
            if (stmp != "MThd") throw new Exception("Not expected!");

            // Main Header
            int len = Reader.GetInt32();// GetChunkLength(bts, ref i);
            if (len != 6) throw new Exception("Not expected");

            Format = Reader.GetUInt16();
            TracksQuantity = Reader.GetUInt16();
            TicksPerQuarter = Reader.GetUInt16();
            Tracks = new TMidiTrack[TracksQuantity];

            // Tracks
            for (int j = 0; j < TracksQuantity; j++)
            {
                TMidiTrack track = new TMidiTrack();
                Tracks[j] = track;
                if (j > 0)
                {
                    track.N = Tracks[j - 1].N;
                    track.D = Tracks[j - 1].D;
                    track.T = Tracks[j - 1].T;
                }

                // Track Primary Header
                stmp = Reader.GetMarker();// GetMarker(bts, ref i);
                if (stmp != "MTrk") throw new Exception("Not expected!");

                // Track Main Header
                len = Reader.GetInt32() + Reader.I;

                int time = 0;

                byte status = 0;
                byte peekByte = 0;

                // Objects...
                while (Reader.I < len)
                {
                    time += Reader.GetVarInt();
                    peekByte = Reader.Current;

                    // If the most significant bit is set then this is a status byte
                    if ((peekByte & 0x80) != 0)
                    {
                        status = peekByte;
                        Reader.GetByte();
                    }

                    // If the most significant nibble is not an 0xF this is a channel event
                    if ((status & 0xF0) != 0xF0)
                    {
                        if ((status & 0xC0) == 0xC0)
                        {
                            if (status != 0xc0) throw new Exception("not implemented");
                            Reader.GetByte();
                        }
                        else if ((status & 0xB0) == 0xB0)
                        {
                            Reader.GetUInt16();
                        }
                        else
                        {
                            peekByte = (byte)(status & 0xF0);
                            byte ch = (byte)((status & 0x0F) + 1);
                            TMidiChannel channel = track.GetChannel(ch);
                            byte d1 = Reader.GetByte();
                            byte d2 = (peekByte & 0xE0) != 0xC0 ? Reader.GetByte() : (byte)0;

                            if (peekByte == (byte)0x90 && d2 == 0) peekByte = (byte)0x80;

                            body += time.ToString() + " " + d1.ToString() + " " + d2.ToString() + " " + peekByte.ToString() + "\n";

                            channel.Events.Add(new TMidiNoteEvent() { Date = time, Note = d1, Velocity = d2 });
                        }
                    }
                    else
                    {
                        if (status == 0xFF)
                        {
                            peekByte = Reader.GetByte();

                            if (peekByte >= 0x01 && peekByte <= 0x0F)
                            {
                                string textValue = Reader.ReadString(Reader.GetVarInt());
                                //var textEvent = new TextEvent { Time = time, Type = metaEventType, Value = textValue };
                                //track.TextEvents.Add(textEvent);
                            }
                            else
                            { 
                                switch (peekByte)
                                {
                                    case 0x51:
                                        Reader.GetByte();
                                        track.T = Reader.GetUInt24();
                                        break;
                                    case 0x58:
                                        Reader.GetByte();
                                        track.N = Reader.GetByte();
                                        track.D = Reader.GetByte();
                                        byte b1 = Reader.GetByte();
                                        byte b2 = Reader.GetByte();
                                        break;
                                    case 0x59:
                                        Reader.GetUInt16();
                                        Reader.GetByte();
                                        break;
                                    case 0x21:
                                        Reader.GetUInt16();
                                        break;
                                    case 0x2f:
                                        Reader.GetByte();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }

            /* XmlSerializer xs = new XmlSerializer(typeof(TMidiFile));
             StreamWriter wtr = new StreamWriter("c:\\temp\\test.xml");
             xs.Serialize(wtr, this);
             wtr.Close(); wtr.Dispose();*/
        }

        public void Regularize()
        {
            foreach (TMidiTrack t in Tracks) t.Regularize();
        }
        public TMidiFile()
        { }

        private TMidiTimeSignature GetTimeSignature(byte[] bts, ref int i)
        {
            GetInt(bts, ref i);
            TMidiTimeSignature sign = new TMidiTimeSignature();
            sign.N = GetInt(bts, ref i);
            sign.D = 1 << GetInt(bts, ref i);
            GetInt(bts, ref i);
            GetInt(bts, ref i);
            return sign;
        }


        private int GetInt(byte[] bts, ref int i)
        {
            int j = bts[i]; i++; return j;
        }

        [XmlArray("Trks")]
        [XmlArrayItem("Trk")]
        public TMidiTrack[] Tracks { get; set; }




    }
}
