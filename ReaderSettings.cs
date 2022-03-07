using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class ReaderSettings
    {
        #region Fields

        private int _nonSeekableStreamBufferSize = 1024;
        private int _nonSeekableStreamIncrementalBytesReadingThreshold = 16384;
        private int _nonSeekableStreamIncrementalBytesReadingStep = 2048;

        private int _bufferSize = 4096;
        private BufferingPolicy _bufferingPolicy = BufferingPolicy.UseFixedSizeBuffer;

        #endregion

        #region Properties
         
        public int NonSeekableStreamBufferSize
        {
            get { return _nonSeekableStreamBufferSize; }
            set
            {
                //ThrowIfArgument.IsNonpositive(nameof(value), value, "Value is zero or negative.");

                _nonSeekableStreamBufferSize = value;
            }
        }
         
        public int NonSeekableStreamIncrementalBytesReadingThreshold
        {
            get { return _nonSeekableStreamIncrementalBytesReadingThreshold; }
            set
            {
                //ThrowIfArgument.IsNegative(nameof(value), value, "Value is negative.");

                _nonSeekableStreamIncrementalBytesReadingThreshold = value;
            }
        }
         
        public int NonSeekableStreamIncrementalBytesReadingStep
        {
            get { return _nonSeekableStreamIncrementalBytesReadingStep; }
            set
            {
                //ThrowIfArgument.IsNonpositive(nameof(value), value, "Value is zero or negative.");

                _nonSeekableStreamIncrementalBytesReadingStep = value;
            }
        }
         
        public BufferingPolicy BufferingPolicy
        {
            get { return _bufferingPolicy; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _bufferingPolicy = value;
            }
        }
         
        public int BufferSize
        {
            get { return _bufferSize; }
            set
            {
                //ThrowIfArgument.IsNonpositive(nameof(value), value, "Value is zero or negative.");

                _bufferSize = value;
            }
        }
         
        public byte[] Buffer { get; set; }

        #endregion
    }
}
