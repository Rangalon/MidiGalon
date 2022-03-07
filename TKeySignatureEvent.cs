using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class KeySignatureEvent : MetaEvent
    {
        #region Constants

        public const sbyte DefaultKey = 0;


        public const byte DefaultScale = 0;

        public const sbyte MinKey = -7;

        public const sbyte MaxKey = 7;

        public const byte MinScale = 0;

        public const byte MaxScale = 1;

        #endregion

        #region Fields

        private sbyte _key = DefaultKey;
        private byte _scale = DefaultScale;

        #endregion

        #region Constructor

        public KeySignatureEvent()
            : base(MidiEventType.KeySignature)
        {
        }


        public KeySignatureEvent(sbyte key, byte scale)
            : this()
        {
            Key = key;
            Scale = scale;
        }

        #endregion

        #region Properties

        public sbyte Key
        {
            get { return _key; }
            set
            {
                //ThrowIfArgument.IsOutOfRange(                    nameof(value),                    value,                    MinKey,                    MaxKey,                    $"Key is out of [{MinKey}; {MaxKey}] range.");

                _key = value;
            }
        }

        public byte Scale
        {
            get { return _scale; }
            set
            {
                //ThrowIfArgument.IsOutOfRange(                    nameof(value),                    value,                    MinScale,                    MaxScale,                    $"Scale is out of {MinScale}-{MaxScale} range.");

                _scale = value;
            }
        }

        #endregion

        #region Methods

        private int ProcessValue(int value, string property, int min, int max, InvalidMetaEventParameterValuePolicy policy)
        {
            if (value >= min && value <= max)
                return value;

            switch (policy)
            {
                case InvalidMetaEventParameterValuePolicy.Abort:
                    throw new InvalidMetaEventParameterValueException(EventType, property, value);
                case InvalidMetaEventParameterValuePolicy.SnapToLimits:
                    return Math.Min(Math.Max(value, min), max);
            }

            return value;
        }

        #endregion

        #region Overrides

        protected override void ReadContent(MidiReader reader, ReadingSettings settings, int size)
        {
            var invalidMetaEventParameterValuePolicy = settings.InvalidMetaEventParameterValuePolicy;

            Key = (sbyte)ProcessValue(reader.ReadSByte(),
                                       nameof(Key),
                                       MinKey,
                                       MaxKey,
                                       invalidMetaEventParameterValuePolicy);

            Scale = (byte)ProcessValue(reader.ReadByte(),
                                        nameof(Scale),
                                        MinScale,
                                        MaxScale,
                                        invalidMetaEventParameterValuePolicy);
        }

        protected override void WriteContent(MidiWriter writer, WritingSettings settings)
        {
            writer.WriteSByte(Key);
            writer.WriteByte(Scale);
        }

        protected override int GetContentSize(WritingSettings settings)
        {
            return 2;
        }

        protected override MidiEvent CloneEvent()
        {
            return new KeySignatureEvent
            {
                _key = _key,
                _scale = _scale
            };
        }

        public override string ToString()
        {
            return $"Key Signature ({Key}, {Scale})";
        }

        #endregion
    }
}
