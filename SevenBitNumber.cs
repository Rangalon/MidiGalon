using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public struct SevenBitNumber : IComparable<SevenBitNumber>, IConvertible
    {
        #region Constants
         
        public static readonly SevenBitNumber MinValue = new SevenBitNumber(Min);
         
        public static readonly SevenBitNumber MaxValue = new SevenBitNumber(Max);
         
        public static readonly SevenBitNumber[] Values = Enumerable.Range(MinValue, MaxValue - MinValue + 1)
                                                                   .Select(value => (SevenBitNumber)value)
                                                                   .ToArray();

        private const byte Min = 0;
        private const byte Max = 127; // 01111111

        #endregion

        #region Fields

        private readonly byte _value;

        #endregion

        #region Constructor
         
        public SevenBitNumber(byte value)
        {
            //ThrowIfArgument.IsOutOfRange(nameof(value), value, Min, Max, "Value is out of range valid for seven-bit number.");

            _value = value;
        }

        #endregion

        #region Methods
         
        public static bool TryParse(string input, out SevenBitNumber SSevenBitNumber)
        {
            SSevenBitNumber = default(SevenBitNumber);

            byte byteValue;
            var parsed = ShortByteParser.TryParse(input, Min, Max, out byteValue).Status == ParsingStatus.Parsed;
            if (parsed)
                SSevenBitNumber = (SevenBitNumber)byteValue;

            return parsed;
        }

  
        public static SevenBitNumber Parse(string input)
        {
            byte byteValue;
            var parsingResult = ShortByteParser.TryParse(input, Min, Max, out byteValue);
            if (parsingResult.Status == ParsingStatus.Parsed)
                return (SevenBitNumber)byteValue;

            throw parsingResult.Exception;
        }

        #endregion

        #region Casting
         
        public static implicit operator byte(SevenBitNumber number)
        {
            return number._value;
        }
         
        public static explicit operator SevenBitNumber(byte number)
        {
            return new SevenBitNumber(number);
        }

        #endregion

        #region IComparable<SSevenBitNumber>

    
        public int CompareTo(SevenBitNumber other)
        {
            return _value.CompareTo(other._value);
        }

        #endregion

        #region IConvertible
         
        public TypeCode GetTypeCode()
        {
            return _value.GetTypeCode();
        }
         
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToBoolean(provider);
        }
 
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToChar(provider);
        }
         
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToSByte(provider);
        }
         
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToByte(provider);
        }
         
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToInt16(provider);
        }
         
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToUInt16(provider);
        }
         
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToInt32(provider);
        }
         
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToUInt32(provider);
        }
         
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToInt64(provider);
        }
         
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToUInt64(provider);
        }
         
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToSingle(provider);
        }
         
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToDouble(provider);
        }
         
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToDecimal(provider);
        }
         
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)_value).ToDateTime(provider);
        }
         
        string IConvertible.ToString(IFormatProvider provider)
        {
            return _value.ToString(provider);
        }
         
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)_value).ToType(conversionType, provider);
        }

        #endregion

        #region Overrides
         
        public override string ToString()
        {
            return _value.ToString();
        }
         
        public override bool Equals(object obj)
        {
            if (!(obj is SevenBitNumber))
                return false;

            var SSevenBitNumber = (SevenBitNumber)obj;
            return SSevenBitNumber._value == _value;
        }
         
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #endregion
    }
}
