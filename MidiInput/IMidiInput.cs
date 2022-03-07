using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MidiGalon.MidiInput
{
    public interface IMidiInput : IMidiPort, IDisposable
    {
        event EventHandler<MidiReceivedEventArgs> MessageReceived;
    }

    public interface IMidiPort
    {
        IMidiPortDetails Details { get; }
        MidiPortConnectionState Connection { get; }
        Task CloseAsync();
    }

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
            Default = (IMidiAccess)new WinMM.WinMMMidiAccess();
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
            Default = Empty = new EmptyMidiAccess();
            new MidiAccessManager().InitializeDefault();
        }

        private MidiAccessManager()
        {
            // We need this only for that we want to use partial method!
        }

        public static IMidiAccess Default { get; private set; }
        public static IMidiAccess Empty { get; internal set; }

    }

    class EmptyMidiAccess : IMidiAccess
    {
        public IEnumerable<IMidiPortDetails> Inputs
        {
            get { yield return EmptyMidiInput.Instance.Details; }
        }



        public Task<IMidiInput> OpenInputAsync(string portId)
        {
            if (portId != EmptyMidiInput.Instance.Details.Id)
                throw new ArgumentException(string.Format("Port ID {0} does not exist.", portId));
            return Task.FromResult<IMidiInput>(EmptyMidiInput.Instance);
        }



    }

    abstract class EmptyMidiPort : IMidiPort
    {
        Task completed_task = Task.FromResult(false);

        public IMidiPortDetails Details
        {
            get { return CreateDetails(); }
        }
        internal abstract IMidiPortDetails CreateDetails();

        public MidiPortConnectionState Connection { get; private set; }

        public Task CloseAsync()
        {
            // do nothing.
            return completed_task;
        }

        public void Dispose()
        {
        }
    }

    class EmptyMidiInput : EmptyMidiPort, IMidiInput
    {
        static EmptyMidiInput()
        {
            Instance = new EmptyMidiInput();
        }

        public static EmptyMidiInput Instance { get; private set; }

//#pragma warning disable 0067
        // will never be fired.
        public event EventHandler<MidiReceivedEventArgs> MessageReceived;
//#pragma warning restore 0067

        internal override IMidiPortDetails CreateDetails()
        {
            return new EmptyMidiPortDetails("dummy_in", "Dummy MIDI Input");
        }
    }

    class EmptyMidiPortDetails : IMidiPortDetails
    {
        public EmptyMidiPortDetails(string id, string name)
        {
            Id = id;
            Manufacturer = "dummy project";
            Name = name;
            Version = "0.0";
        }

        public string Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }


    public interface IMidiAccess
    {
        IEnumerable<IMidiPortDetails> Inputs { get; }

        Task<IMidiInput> OpenInputAsync(string portId);
    }

    public interface IMidiPortDetails
    {
        string Id { get; }
        string Manufacturer { get; }
        string Name { get; }
        string Version { get; }
    }

    public enum MidiPortConnectionState
    {
        Open,
        Closed,
        Pending
    }
}
