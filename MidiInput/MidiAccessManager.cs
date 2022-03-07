using System;
using System.Runtime.InteropServices;

namespace MidiGalon.MidiInput
{


    public class MidiReceivedEventArgs : EventArgs
    {
        public long Timestamp { get; set; }
        public byte[] Data { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }

    public class MidiAccessManager
    {

        void InitializeDefault()
        {
            Default = new WinMMMidiAccess();
        }

        //From Managed.Windows.Forms/XplatUI
        [DllImport("libc")]
        static extern int uname(IntPtr buf);

        static bool IsRunningOnMac()
        {
            IntPtr buf = IntPtr.Zero;
            try
            {
                buf = Marshal.AllocHGlobal(8192);
                // This is a hacktastic way of getting sysname from uname ()
                if (uname(buf) == 0)
                {
                    string os = Marshal.PtrToStringAnsi(buf);
                    if (os == "Darwin")
                        return true;
                }
            }
            catch
            {
            }
            finally
            {
                if (buf != IntPtr.Zero)
                    Marshal.FreeHGlobal(buf);
            }
            return false;
        }

        static MidiAccessManager()
        {
            //Default = Empty = new EmptyMidiAccess();
            new MidiAccessManager().InitializeDefault();
        }

        private MidiAccessManager()
        {
            // We need this only for that we want to use partial method!
        }

        public static WinMMMidiAccess Default { get; private set; }
        public static WinMMMidiAccess Empty { get; internal set; }

    }


    public enum MidiPortConnectionState
    {
        Open,
        Closed,
        Pending
    }
}
