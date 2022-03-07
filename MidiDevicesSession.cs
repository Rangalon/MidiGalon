using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal static class MidiDevicesSession
    {
        #region Events

        internal static event EventHandler<IntPtr> InputDeviceAdded;
        internal static event EventHandler<IntPtr> InputDeviceRemoved;
        internal static event EventHandler<IntPtr> OutputDeviceAdded;
        internal static event EventHandler<IntPtr> OutputDeviceRemoved;

        #endregion

        #region Fields

        private static readonly object _lockObject = new object();

        private static IntPtr _name;
        private static IntPtr _handle;

        private static MidiDevicesSessionApi.InputDeviceCallback _inputDeviceCallback;
        private static MidiDevicesSessionApi.OutputDeviceCallback _outputDeviceCallback;

        #endregion

        #region Methods

        public static IntPtr GetSessionHandle()
        {
            lock (_lockObject)
            {
                if (_handle == IntPtr.Zero)
                {
                    var name = Guid.NewGuid().ToString();
                    _name = Marshal.StringToHGlobalAuto(name);

                    //var apiType = CommonApiProvider.Api.Api_GetApiType();
                    var result = default(MidiDevicesSessionApi.SESSION_OPENRESULT);


                    result = MidiDevicesSessionApiProvider.Api.Api_OpenSession_Win(_name, out _handle);


                    NativeApiUtilities.HandleDevicesNativeApiResult(result);
                }

                return _handle;
            }
        }

        private static void InputDeviceCallback(IntPtr info, bool operation)
        {
            if (operation)
                InputDeviceAdded?.Invoke(null, info);
            else
                InputDeviceRemoved?.Invoke(null, info);
        }

        private static void OutputDeviceCallback(IntPtr info, bool operation)
        {
            if (operation)
                OutputDeviceAdded?.Invoke(null, info);
            else
                OutputDeviceRemoved?.Invoke(null, info);
        }

        #endregion
    }
}
