using System.Runtime.InteropServices;

namespace DivertSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UDPHeader
    {
        private ushort SourcePort;
        public ushort DestinationPort;
        public ushort Length;
        public ushort Checksum;

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
    }
}
