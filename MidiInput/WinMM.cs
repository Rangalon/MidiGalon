using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace MidiGalon.MidiInput
{
    public class WinMM
    {

        public class WinMMMidiAccess : IMidiAccess
        {
            public IEnumerable<IMidiPortDetails> Inputs
            {
                get
                {
                    int devs = WinMMNatives.midiInGetNumDevs();
                    for (uint i = 0; i < devs; i++)
                    {
                        MidiInCaps caps;
                        WinMMNatives.midiInGetDevCaps((UIntPtr)i, out caps, (uint)Marshal.SizeOf<MidiInCaps>());
                        yield return new WinMMPortDetails(i, caps.Name, caps.DriverVersion);
                    }
                }
            }

            public IEnumerable<IMidiPortDetails> Outputs
            {
                get
                {
                    int devs = WinMMNatives.midiOutGetNumDevs();
                    for (uint i = 0; i < devs; i++)
                    {
                        MidiOutCaps caps;
                        var err = WinMMNatives.midiOutGetDevCaps((UIntPtr)i, out caps, (uint)Marshal.SizeOf<MidiOutCaps>());
                        if (err != 0)
                            throw new Win32Exception(err);
                        yield return new WinMMPortDetails(i, caps.Name, caps.DriverVersion);
                    }
                }
            }

            // RDU public event EventHandler<MidiConnectionEventArgs> StateChanged;

            public Task<IMidiInput> OpenInputAsync(string portId)
            {
                IMidiPortDetails details = Inputs.FirstOrDefault(d => d.Id == portId);
                if (details == null)
                    throw new InvalidOperationException($"The device with ID {portId} is not found.");
                return Task.FromResult((IMidiInput)new WinMMMidiInput(details));
            }


        }

        public class MidiConnectionEventArgs : EventArgs
        {
            public IMidiPortDetails Port { get; private set; }
        }


        public class WinMMPortDetails : IMidiPortDetails
        {
            public WinMMPortDetails(uint deviceId, string name, int version)
            {
                Id = deviceId.ToString();
                Name = name;
                Version = version.ToString();
            }

            public string Id { get; private set; }

            public string Manufacturer { get; private set; }

            public string Name { get; private set; }

            public string Version { get; private set; }
        }

        public class WinMMMidiInput : IMidiInput
        {
            MidiInProc midiInProc;

            static WinMMMidiInput()
            {
                // prevent garbage collection of the delegate
            }

            void KeepAlive()
            {
                while (true)
                {
                    midiInProc.Invoke(0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
                    Thread.Sleep(100);
                }
            }

            public WinMMMidiInput(IMidiPortDetails details)
            {

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Details = details;

                midiInProc = HandleMidiInProc;


                //WinMMNatives.midiInOpen(out handle, uint.Parse(Details.Id), null, IntPtr.Zero, MidiInOpenFlags.Function | MidiInOpenFlags.MidiIoStatus);
                WinMMNatives.midiInOpen(out handle, uint.Parse(Details.Id), midiInProc, IntPtr.Zero, MidiInOpenFlags.Function);
                /*  DieOnError(WinMMNatives.midiInOpen(out handle, uint.Parse(Details.Id), midiInProc, IntPtr.Zero, MidiInOpenFlags.Function | MidiInOpenFlags.MidiIoStatus)); */

                WinMMNatives.midiInStart(handle);
                /*    DieOnError(WinMMNatives.midiInStart(handle));*/
                Thread th = new Thread(KeepAlive) { Priority = ThreadPriority.Highest }; th.Start();


                while (lmBuffers.Count < LONG_BUFFER_COUNT)
                {
                    LongMessageBuffer buffer = new LongMessageBuffer(handle);

                    buffer.PrepareHeader();
                    buffer.AddBuffer();

                    lmBuffers.Add(buffer.Ptr, buffer);

                    Thread.Sleep(10);
                }

                Connection = MidiPortConnectionState.Open;

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            const int LONG_BUFFER_COUNT = 16;

            Dictionary<IntPtr, LongMessageBuffer> lmBuffers = new Dictionary<IntPtr, LongMessageBuffer>();

            IntPtr handle;
            object lockObject = new object();

            byte[] data1b = new byte[1];
            byte[] data2b = new byte[2];
            byte[] data3b = new byte[3];

            void HandleData(IntPtr param1, IntPtr param2)
            {
                byte status = (byte)((int)param1 & 0xFF);
                byte msb = (byte)(((int)param1 & 0xFF00) >> 8);
                byte lsb = (byte)(((int)param1 & 0xFF0000) >> 16);
                byte size = MidiEvent.FixedDataSize(status);
                byte[] data = size == 1 ? data2b : size == 2 ? data3b : data1b;
                data[0] = status;
                if (data.Length >= 2)
                    data[1] = msb;
                if (data.Length >= 3)
                    data[2] = lsb;

                MessageReceived(this, new MidiReceivedEventArgs() { Data = data, Start = 0, Length = data.Length, Timestamp = (long)param2 });
            }

            void HandleLongData(IntPtr param1, IntPtr param2)
            {
                byte[] data = null;

                lock (lockObject)
                {
                    var buffer = lmBuffers[param1];
                    // FIXME: this is a nasty workaround for https://github.com/atsushieno/managed-midi/issues/49
                    // We have no idea when/how this message is sent (midi in proc is not well documented).
                    if (buffer.Header.BytesRecorded == 0)
                        return;

                    data = new byte[buffer.Header.BytesRecorded];

                    Marshal.Copy(buffer.Header.Data, data, 0, buffer.Header.BytesRecorded);

                    if (Connection == MidiPortConnectionState.Open)
                    {
                        buffer.Recycle();
                    }
                    else
                    {
                        lmBuffers.Remove(buffer.Ptr);
                        buffer.Dispose();
                    }
                }

                if (data != null && data.Length != 0)
                    MessageReceived(this, new MidiReceivedEventArgs() { Data = data, Start = 0, Length = data.Length, Timestamp = (long)param2 });
            }

            void HandleMidiInProc(UInt32 midiIn, MidiInMessage msg, IntPtr instance, IntPtr param1, IntPtr param2)
            {
                //GC.KeepAlive(midiInProc);
                //Console.WriteLine(DateTime.Now.ToLongTimeString());

                //midiInProc = HandleMidiInProc;


                if (MessageReceived != null)
                {
                    switch (msg)
                    {
                        case MidiInMessage.Data:
                            HandleData(param1, param2);
                            break;

                        case MidiInMessage.LongData:
                            HandleLongData(param1, param2);
                            break;

                        case MidiInMessage.MoreData:
                            // TODO input too slow, handle.
                            break;

                        case MidiInMessage.Error:
                            throw new InvalidOperationException($"Invalid MIDI message: {param1}");

                        case MidiInMessage.LongError:
                            throw new InvalidOperationException("Invalid SysEx message.");

                        default:
                            break;
                    }
                }
            }

            public IMidiPortDetails Details { get; private set; }

            public MidiPortConnectionState Connection { get; private set; }

            public event EventHandler<MidiReceivedEventArgs> MessageReceived;

            public Task CloseAsync()
            {
                return Task.Run(() =>
                {
                    lock (lockObject)
                    {
                        Connection = MidiPortConnectionState.Pending;

                        DieOnError(WinMMNatives.midiInReset(handle));
                        DieOnError(WinMMNatives.midiInStop(handle));
                        DieOnError(WinMMNatives.midiInClose(handle));

                        // wait for the device driver to hand back the long buffers through HandleMidiInProc

                        for (int i = 0; i < 1000; i++)
                        {
                            lock (lockObject)
                            {
                                if (lmBuffers.Count < 1)
                                    break;
                            }

                            Thread.Sleep(10);
                        }

                        Connection = MidiPortConnectionState.Closed;
                    }
                });
            }

            public void Dispose()
            {
                CloseAsync().Wait();
            }

            static void DieOnError(int code)
            {
                /* RDU   if (code != 0)
                       throw new Win32Exception(code, $"{WinMMNatives.GetMidiInErrorText(code)} ({code})");*/
            }

            class LongMessageBuffer : IDisposable
            {
                public IntPtr Ptr { get; set; } = IntPtr.Zero;
                public MidiHdr Header => (MidiHdr)Marshal.PtrToStructure(Ptr, typeof(MidiHdr));

                IntPtr inputHandle;
                static int midiHdrSize = Marshal.SizeOf(typeof(MidiHdr));

                bool prepared = false;

                public LongMessageBuffer(IntPtr inputHandle, int bufferSize = 4096)
                {
                    this.inputHandle = inputHandle;

                    MidiHdr header = new MidiHdr()
                    {
                        Data = Marshal.AllocHGlobal(bufferSize),
                        BufferLength = bufferSize,
                    };

                    try
                    {
                        Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MidiHdr)));
                        Marshal.StructureToPtr(header, Ptr, false);
                    }
                    catch
                    {
                        Free();
                        throw;
                    }
                }

                public void PrepareHeader()
                {
                    if (!prepared)
                        DieOnError(WinMMNatives.midiInPrepareHeader(inputHandle, Ptr, midiHdrSize));

                    prepared = true;
                }

                public void UnPrepareHeader()
                {
                    if (prepared)
                        DieOnError(WinMMNatives.midiInUnprepareHeader(inputHandle, Ptr, midiHdrSize));

                    prepared = false;
                }

                public void AddBuffer() =>
                    DieOnError(WinMMNatives.midiInAddBuffer(inputHandle, Ptr, midiHdrSize));

                public void Dispose()
                {
                    Free();
                }

                public void Recycle()
                {
                    UnPrepareHeader();
                    PrepareHeader();
                    AddBuffer();
                }

                void Free()
                {
                    UnPrepareHeader();

                    if (Ptr != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(Header.Data);
                        Marshal.FreeHGlobal(Ptr);
                    }
                }
            }
        }

    }
}
