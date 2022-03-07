using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public enum UnexpectedTrackChunksCountPolicy
    { 
        Ignore = 0, 
        Abort
    }

    public enum UnknownChunkIdPolicy : byte
    { 
        ReadAsUnknownChunk = 0, 
        Skip, 
        Abort
    }
    public enum ExtraTrackChunkPolicy : byte
    { 
        Read = 0, 
        Skip 
    }

    public enum EndOfTrackStoringPolicy
    { 
        Omit = 0, 
        Store
    }

    public enum InvalidChannelEventParameterValuePolicy : byte
    { 
        Abort = 0, 
        ReadValid, 
        SnapToLimits
    }

    public enum InvalidChunkSizePolicy : byte
    { 
        Abort = 0, 
        Ignore
    }

    public enum InvalidMetaEventParameterValuePolicy
    { 
        Abort = 0, 
        SnapToLimits
    }

    public enum InvalidSystemCommonEventParameterValuePolicy
    { 
        Abort = 0, 
        SnapToLimits
    }

    public enum MissedEndOfTrackPolicy : byte
    { 
        Ignore = 0, 
        Abort
    }

    public enum NoHeaderChunkPolicy
    { 
        Abort = 0, 
        Ignore
    }

    public enum NotEnoughBytesPolicy
    { 
        Abort = 0, 
        Ignore
    }

   

    public enum UnknownChannelEventPolicy
    { 
        Abort = 0, 
        SkipStatusByte, 
        SkipStatusByteAndOneDataByte, 
        SkipStatusByteAndTwoDataBytes, 
        UseCallback
    }

    public enum UnknownFileFormatPolicy
    { 
        Ignore = 0, 
        Abort
    }

    public enum ZeroLengthDataPolicy
    { 
        ReadAsEmptyObject = 0, 
        ReadAsNull
    }

    
}
