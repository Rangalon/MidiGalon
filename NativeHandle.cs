using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal abstract class NativeHandle : SafeHandle
    {
        #region Constructor

        public NativeHandle(IntPtr validHandle)
                : base(IntPtr.Zero, true)
        {
            SetHandle(validHandle);
        }

        #endregion

        #region Properties

        public IntPtr DeviceHandle
        {
            get { return handle; }
        }

        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        #endregion
    }
}
