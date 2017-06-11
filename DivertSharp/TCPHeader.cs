using System.Runtime.InteropServices;

namespace DivertSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCPHeader
    {
        private ushort SourcePort;
        private ushort DestinationPort;

        public uint SeqNum;
        public uint AckNum;

        private ushort bitvector1;

        public ushort Window;
        public ushort Checksum;
        public ushort UrgPtr;

        public ushort SrcPort
        {
            get { return WinDivertHelpers.SwapOrder(SourcePort); }
            set { SourcePort = WinDivertHelpers.SwapOrder(value); }
        }

        public ushort DstPort
        {
            get { return WinDivertHelpers.SwapOrder(DestinationPort); }
            set { DestinationPort = WinDivertHelpers.SwapOrder(value); }
        }

        public uint Reserved1
        {
            get { return bitvector1 & 15u; }
            set { bitvector1 = (ushort) (value | bitvector1); }
        }

        public uint HdrLength
        {
            get { return (bitvector1 & 240u)/16; }
            set { bitvector1 = (ushort) ((value*16) | bitvector1); }
        }

        public uint Fin
        {
            get { return (bitvector1 & 256u)/256; }
            set { bitvector1 = (ushort) ((value*256) | bitvector1); }
        }

        public uint Syn
        {
            get { return (bitvector1 & 512u)/512; }
            set { bitvector1 = (ushort) ((value*512) | bitvector1); }
        }

        public uint Rst
        {
            get { return (bitvector1 & 1024u)/1024; }
            set { bitvector1 = (ushort) ((value*1024) | bitvector1); }
        }

        public uint Psh
        {
            get { return (bitvector1 & 2048u)/2048; }
            set { bitvector1 = (ushort) ((value*2048) | bitvector1); }
        }

        public uint Ack
        {
            get { return (bitvector1 & 4096u)/4096; }
            set { bitvector1 = (ushort) ((value*4096) | bitvector1); }
        }

        public uint Urg
        {
            get { return (bitvector1 & 8192u)/8192; }
            set { bitvector1 = (ushort) ((value*8192) | bitvector1); }
        }

        public uint Reserved2
        {
            get { return (bitvector1 & 49152u)/16384; }
            set { bitvector1 = (ushort) ((value*16384) | bitvector1); }
        }
    }
}
