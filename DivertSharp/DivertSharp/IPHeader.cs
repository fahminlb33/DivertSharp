using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace DivertSharp
{
    public struct IPHeader
    {
        private byte bitvector1;
        public byte TOS;
        public ushort Length;
        public ushort Id;
        internal ushort FragOff0;
        public byte TTL;
        public byte Protocol;
        public ushort Checksum;
        private uint SourceAddress;
        private uint DestinationAddress;

        public uint HdrLength
        {
            get { return bitvector1 & 15u; }
            set { bitvector1 = (byte)(value | bitvector1); }
        }

        public uint Version
        {
            get { return (bitvector1 & 240u) / 16; }
            set { bitvector1 = (byte)((value * 16) | bitvector1); }
        }

        public IPAddress SrcAddr
        {
            get { return new IPAddress(SourceAddress); }
            set
            {
                Debug.Assert(value.AddressFamily == AddressFamily.InterNetwork, "Not a valid IPV4 address.");
                if (value.AddressFamily != AddressFamily.InterNetwork)
                {
                    throw new ArgumentException("Not a valid IPV4 address.", nameof(SrcAddr));
                }
                SourceAddress = (uint)BitConverter.ToInt32(value.GetAddressBytes(), 0);
            }
        }

        public IPAddress DstAddr
        {
            get { return new IPAddress(DestinationAddress); }
            set
            {
                Debug.Assert(value.AddressFamily == AddressFamily.InterNetwork, "Not a valid IPV4 address.");
                if (value.AddressFamily != AddressFamily.InterNetwork)
                {
                    throw new ArgumentException("Not a valid IPV4 address.", nameof(DstAddr));
                }
                DestinationAddress = (uint)BitConverter.ToInt32(value.GetAddressBytes(), 0);
            }
        }
    }
}
