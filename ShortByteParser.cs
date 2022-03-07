using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal static class ShortByteParser
    {
        #region Methods

        internal static TParsingResult TryParse(string input, byte minValue, byte maxValue, out byte result)
        {
            result = default(byte);

            if (string.IsNullOrWhiteSpace(input))
                return TParsingResult.EmptyInputString;

            byte tmpResult;
            if (!byte.TryParse(input.Trim(), out tmpResult) || tmpResult < minValue || tmpResult > maxValue)
                return TParsingResult.Error("Number is invalid or is out of valid range.");

            result = tmpResult;
            return TParsingResult.Parsed;
        }

        #endregion
    }
}
