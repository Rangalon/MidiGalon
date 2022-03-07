

namespace MidiGalon.MidiFile
{
    public class TMidiNoteEvent
    { 
        public int Date; 
        public int Note; 
        public int Velocity;

        public override string ToString()
        {
            return Date.ToString() + " " + Note.ToString() + " " + Velocity.ToString();
        }
    }
}
