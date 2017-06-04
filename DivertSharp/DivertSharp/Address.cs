using System.Runtime.InteropServices;

namespace DivertSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Address
    {
        public uint IfIdx;

        public uint SubIfIdx;

        public byte Direction;
    }
}
