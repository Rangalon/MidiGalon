﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal sealed class SystemRealTimeEventReader : IEventReader
    {
        #region IEventReader

        public MidiEvent Read(MidiReader reader, ReadingSettings settings, byte currentStatusByte)
        {
            SystemRealTimeEvent systemRealTimeEvent = null;

            switch (currentStatusByte)
            {
                case EventStatusBytes.SystemRealTime.ActiveSensing:
                    systemRealTimeEvent = new ActiveSensingEvent();
                    break;
                case EventStatusBytes.SystemRealTime.Continue:
                    systemRealTimeEvent = new ContinueEvent();
                    break;
                case EventStatusBytes.SystemRealTime.Reset:
                    systemRealTimeEvent = new ResetEvent();
                    break;
                case EventStatusBytes.SystemRealTime.Start:
                    systemRealTimeEvent = new StartEvent();
                    break;
                case EventStatusBytes.SystemRealTime.Stop:
                    systemRealTimeEvent = new StopEvent();
                    break;
                case EventStatusBytes.SystemRealTime.TimingClock:
                    systemRealTimeEvent = new TimingClockEvent();
                    break;
            }

            systemRealTimeEvent?.Read(reader, settings, MidiEvent.UnknownContentSize);
            return systemRealTimeEvent;
        }

        #endregion
    }
}
