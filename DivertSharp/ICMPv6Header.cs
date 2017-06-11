using System.Runtime.InteropServices;

namespace DivertSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ICMPv6Header
    {
        public byte Type;

        public byte Code;

        public ushort Checksum;

        public uint Body;
    }
}
