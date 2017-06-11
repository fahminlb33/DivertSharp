using System;
using System.Diagnostics;
using System.Net;

namespace DivertSharp
{
    public unsafe struct IPv6Header
    {
        private ushort bitvector1;
        internal ushort FlowLabel1;
        public ushort Length;
        public byte NextHdr;
        public byte HopLimit;
        private fixed uint SourceAddress [4];
        private fixed uint DestinationAddress [4];

        public uint Version
        {
            get { return (bitvector1 & 240u)/16; }
            set { bitvector1 = (ushort) ((value*16) | bitvector1); }
        }

        public IPAddress SrcAddr
        {
            get
            {
                fixed (uint* addr = SourceAddress)
                {
                    var b1 = BitConverter.GetBytes(addr[0]);
                    var b2 = BitConverter.GetBytes(addr[1]);
                    var b3 = BitConverter.GetBytes(addr[2]);
                    var b4 = BitConverter.GetBytes(addr[3]);
                    var bytes = new[]
                    {
                        b1[0], b1[1], b1[2], b1[3],
                        b2[0], b2[1], b2[2], b2[3],
                        b3[0], b3[1], b3[2], b3[3],
                        b4[0], b1[1], b4[2], b4[3]
                    };
                    return new IPAddress(bytes);
                }
            }
            set
            {
                fixed (uint* addr = SourceAddress)
                {
                    var valueBytes = value.GetAddressBytes();

                    Debug.Assert(valueBytes.Length == 16, "Not a valid IPV6 address.");

                    if (valueBytes.Length != 16)
                    {
                        throw new ArgumentException("Not a valid IPV6 address.", nameof(SrcAddr));
                    }

                    addr[0] = BitConverter.ToUInt32(valueBytes, 0);
                    addr[1] = BitConverter.ToUInt32(valueBytes, 4);
                    addr[2] = BitConverter.ToUInt32(valueBytes, 8);
                    addr[3] = BitConverter.ToUInt32(valueBytes, 12);
                }
            }
        }

        public IPAddress DstAddr
        {
            get
            {
                fixed (uint* addr = DestinationAddress)
                {
                    var b1 = BitConverter.GetBytes(addr[0]);
                    var b2 = BitConverter.GetBytes(addr[1]);
                    var b3 = BitConverter.GetBytes(addr[2]);
                    var b4 = BitConverter.GetBytes(addr[3]);
                    var bytes = new[]
                    {
                        b1[0], b1[1], b1[2], b1[3],
                        b2[0], b2[1], b2[2], b2[3],
                        b3[0], b3[1], b3[2], b3[3],
                        b4[0], b1[1], b4[2], b4[3]
                    };
                    return new IPAddress(bytes);
                }
            }
            set
            {
                fixed (uint* addr = DestinationAddress)
                {
                    var valueBytes = value.GetAddressBytes();

                    Debug.Assert(valueBytes.Length == 16, "Not a valid IPV6 address.");

                    if (valueBytes.Length != 16)
                    {
                        throw new ArgumentException("Not a valid IPV6 address.", nameof(DstAddr));
                    }

                    addr[0] = BitConverter.ToUInt32(valueBytes, 0);
                    addr[1] = BitConverter.ToUInt32(valueBytes, 4);
                    addr[2] = BitConverter.ToUInt32(valueBytes, 8);
                    addr[3] = BitConverter.ToUInt32(valueBytes, 12);
                }
            }
        }
        
        internal uint TrafficClass0
        {
            get { return bitvector1 & 15u; }
            set { bitvector1 = (ushort) (value | bitvector1); }
        }

        internal uint FlowLabel0
        {
            get { return (bitvector1 & 3840u)/256; }
            set { bitvector1 = (ushort) ((value*256) | bitvector1); }
        }

        internal uint TrafficClass1
        {
            get { return (bitvector1 & 61440u)/4096; }
            set { bitvector1 = (ushort) ((value*4096) | bitvector1); }
        }
    }
}
