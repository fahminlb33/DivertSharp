
using System.Runtime.InteropServices;

namespace DivertSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ICMPHeader
    {
        public byte Type;

        public byte Code;

        public ushort Checksum;

        public uint Body;
    }
}
