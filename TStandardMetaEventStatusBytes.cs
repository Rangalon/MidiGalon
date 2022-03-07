using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal static class StandardMetaEventStatusBytes
    {
        #region Fields

        private static byte[] _statusBytes;

        #endregion

        #region Methods

        public static byte[] GetStatusBytes()
        {
            return _statusBytes ?? (_statusBytes = typeof(EventStatusBytes.Meta)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(f => (byte)f.GetValue(null))
                .ToArray());
        }

        #endregion
    }
}
