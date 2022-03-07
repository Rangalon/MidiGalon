using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{

    public delegate string DecodeTextCallback(byte[] bytes, ReadingSettings settings);

    public delegate UnknownChannelEventAction UnknownChannelEventCallback(FourBitNumber statusByte, FourBitNumber channel);

    public class ReadingSettings
    {
        #region Fields

        private UnexpectedTrackChunksCountPolicy _unexpectedTrackChunksCountPolicy = UnexpectedTrackChunksCountPolicy.Ignore;
        private ExtraTrackChunkPolicy _extraTrackChunkPolicy = ExtraTrackChunkPolicy.Read;
        private UnknownChunkIdPolicy _unknownChunkIdPolicy = UnknownChunkIdPolicy.ReadAsUnknownChunk;
        private MissedEndOfTrackPolicy _missedEndOfTrackPolicy = MissedEndOfTrackPolicy.Ignore;
        private SilentNoteOnPolicy _silentNoteOnPolicy = SilentNoteOnPolicy.NoteOff;
        private InvalidChunkSizePolicy _invalidChunkSizePolicy = InvalidChunkSizePolicy.Abort;
        private UnknownFileFormatPolicy _unknownFileFormatPolicy = UnknownFileFormatPolicy.Ignore;
        private UnknownChannelEventPolicy _unknownChannelEventPolicy = UnknownChannelEventPolicy.Abort;
        private InvalidChannelEventParameterValuePolicy _invalidChannelEventParameterValuePolicy = InvalidChannelEventParameterValuePolicy.Abort;
        private InvalidMetaEventParameterValuePolicy _invalidMetaEventParameterValuePolicy = InvalidMetaEventParameterValuePolicy.Abort;
        private InvalidSystemCommonEventParameterValuePolicy _invalidSystemCommonEventParameterValuePolicy = InvalidSystemCommonEventParameterValuePolicy.Abort;
        private NotEnoughBytesPolicy _notEnoughBytesPolicy = NotEnoughBytesPolicy.Abort;
        private NoHeaderChunkPolicy _noHeaderChunkPolicy = NoHeaderChunkPolicy.Abort;
        private ZeroLengthDataPolicy _zeroLengthDataPolicy = ZeroLengthDataPolicy.ReadAsEmptyObject;
        private EndOfTrackStoringPolicy _endOfTrackStoringPolicy = EndOfTrackStoringPolicy.Omit;

        #endregion

        #region Properties
         
        public UnexpectedTrackChunksCountPolicy UnexpectedTrackChunksCountPolicy
        {
            get { return _unexpectedTrackChunksCountPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _unexpectedTrackChunksCountPolicy = value;
            }
        }
         
        public ExtraTrackChunkPolicy ExtraTrackChunkPolicy
        {
            get { return _extraTrackChunkPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _extraTrackChunkPolicy = value;
            }
        }
         
        public UnknownChunkIdPolicy UnknownChunkIdPolicy
        {
            get { return _unknownChunkIdPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _unknownChunkIdPolicy = value;
            }
        }
         
        public MissedEndOfTrackPolicy MissedEndOfTrackPolicy
        {
            get { return _missedEndOfTrackPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _missedEndOfTrackPolicy = value;
            }
        }
         
        public SilentNoteOnPolicy SilentNoteOnPolicy
        {
            get { return _silentNoteOnPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _silentNoteOnPolicy = value;
            }
        }
         
        public InvalidChunkSizePolicy InvalidChunkSizePolicy
        {
            get { return _invalidChunkSizePolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _invalidChunkSizePolicy = value;
            }
        }
 
        public UnknownFileFormatPolicy UnknownFileFormatPolicy
        {
            get { return _unknownFileFormatPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _unknownFileFormatPolicy = value;
            }
        }
 
        public UnknownChannelEventPolicy UnknownChannelEventPolicy
        {
            get { return _unknownChannelEventPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _unknownChannelEventPolicy = value;
            }
        }
         
        public UnknownChannelEventCallback UnknownChannelEventCallback { get; set; }
         
        public InvalidChannelEventParameterValuePolicy InvalidChannelEventParameterValuePolicy
        {
            get { return _invalidChannelEventParameterValuePolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _invalidChannelEventParameterValuePolicy = value;
            }
        }
         
        public InvalidMetaEventParameterValuePolicy InvalidMetaEventParameterValuePolicy
        {
            get { return _invalidMetaEventParameterValuePolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _invalidMetaEventParameterValuePolicy = value;
            }
        }
         
        public InvalidSystemCommonEventParameterValuePolicy InvalidSystemCommonEventParameterValuePolicy
        {
            get { return _invalidSystemCommonEventParameterValuePolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _invalidSystemCommonEventParameterValuePolicy = value;
            }
        }
         
        public NotEnoughBytesPolicy NotEnoughBytesPolicy
        {
            get { return _notEnoughBytesPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _notEnoughBytesPolicy = value;
            }
        }
         
        public NoHeaderChunkPolicy NoHeaderChunkPolicy
        {
            get { return _noHeaderChunkPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _noHeaderChunkPolicy = value;
            }
        }
 
        public ChunkTypesCollection CustomChunkTypes { get; set; }
         
        public EventTypesCollection CustomMetaEventTypes { get; set; }
         
        public Encoding TextEncoding { get; set; } = Encoding.ASCII;
         
        public DecodeTextCallback DecodeTextCallback { get; set; }
         
        public ZeroLengthDataPolicy ZeroLengthDataPolicy
        {
            get { return _zeroLengthDataPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _zeroLengthDataPolicy = value;
            }
        }
         
        public EndOfTrackStoringPolicy EndOfTrackStoringPolicy
        {
            get { return _endOfTrackStoringPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _endOfTrackStoringPolicy = value;
            }
        }
         
        public ReaderSettings TReaderSettings { get; set; } = new ReaderSettings();

        #endregion
    }
}
