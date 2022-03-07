using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class UnknownChannelEventException : MidiException
    {
        #region Constructors

        internal UnknownChannelEventException(FourBitNumber statusByte, FourBitNumber channel)
            : base($"Unknown channel event (status byte is {statusByte} and channel is {channel}).")
        {
            StatusByte = statusByte;
            Channel = channel;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the channel of an unknown channel event.
        /// </summary>
        public FourBitNumber Channel { get; }

        /// <summary>
        /// Gets the status byte of an unknown channel event.
        /// </summary>
        public FourBitNumber StatusByte { get; }

        #endregion
    }
}
