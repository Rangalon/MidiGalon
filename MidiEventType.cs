using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum MidiEventType : byte
    { 
        NormalSysEx, 
        EscapeSysEx, 
        SequenceNumber, 
        Text, 
        CopyrightNotice, 
        SequenceTrackName, 
        InstrumentName, 
        Lyric, 
        Marker, 
        CuePoint, 
        ProgramName, 
        DeviceName, 
        ChannelPrefix, 
        PortPrefix, 
        EndOfTrack, 
        SetTempo, 
        SmpteOffset, 
        TimeSignature, 
        KeySignature, 
        SequencerSpecific, 
        UnknownMeta, 
        CustomMeta, 
        NoteOff, 
        NoteOn, 
        NoteAftertouch, 
        ControlChange, 
        ProgramChange, 
        ChannelAftertouch, 
        PitchBend, 
        TimingClock, 
        Start, 
        Continue, 
        Stop, 
        ActiveSensing, 
        Reset, 
        MidiTimeCode, 
        SongPositionPointer, 
        SongSelect, 
        TuneRequest
    }
}
