﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class EventType
    {
        #region Constructor
         
        public EventType(Type type, byte statusByte)
        {
            Type = type;
            StatusByte = statusByte;
        }

        #endregion

        #region Properties
         
        public Type Type { get; }
         
        public byte StatusByte { get; }

        #endregion
    }
}
