using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal sealed class CommonApi32 : CommonApi
    {
        #region Constants

        private const string LibraryName = LibraryName32;

        #endregion

        #region Extern functions

        [DllImport(LibraryName, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern API_TYPE GetApiType();

        [DllImport(LibraryName, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CanCompareDevices();

        #endregion

        #region Methods

        public override API_TYPE Api_GetApiType()
        {
            return GetApiType();
        }

        public override bool Api_CanCompareDevices()
        {
            return CanCompareDevices();
        }

        #endregion
    }
}
