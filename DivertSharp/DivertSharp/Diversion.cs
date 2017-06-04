using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DivertSharp
{
    [SecurityCritical]
    public static unsafe class Diversion
    {
        /* Main */
        [DllImport("WinDivert.dll", EntryPoint = "WinDivertOpen")]
        public static extern WinDivertSafeHandle WinDivertOpen([In] [MarshalAs(UnmanagedType.LPStr)] string filter, WinDivertLayer layer, short priority, ulong flags);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertClose")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertClose([In] IntPtr handle);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertRecv")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertRecv([In] WinDivertSafeHandle handle, byte[] pPacket, uint packetLen, ref Address pAddr, ref uint readLen);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertRecvEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertRecvEx([In] WinDivertSafeHandle handle, byte[] pPacket, uint packetLen, ulong flags, IntPtr pAddr, IntPtr readLen, IntPtr lpOverlapped);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSend([In] WinDivertSafeHandle handle, [In] byte[] pPacket, uint packetLen, [In] ref Address pAddr, IntPtr writeLen);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertSendEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSendEx([In] WinDivertSafeHandle handle, [In] byte[] pPacket, uint packetLen, ulong flags, [In] ref Address pAddr, IntPtr writeLen, IntPtr lpOverlapped);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertSetParam")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertSetParam([In] WinDivertSafeHandle handle, WinDivertParam param, ulong value);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertGetParam")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertGetParam([In] WinDivertSafeHandle handle, WinDivertParam param, [Out] out ulong pValue);

        /* Helpers */
        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperParsePacket")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParsePacket(byte* pPacket, uint packetLen, IPHeader** ppIpHdr, IPv6Header** ppIpv6Hdr, ICMPHeader** ppIcmpHdr, ICMPv6Header** ppIcmpv6Hdr, TCPHeader** ppTcpHdr, UDPHeader** ppUdpHdr, byte** ppData, uint* pDataLen);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperParseIPv4Address")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParseIPv4Address([In] [MarshalAs(UnmanagedType.LPStr)] string addrStr, IntPtr pAddr);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperParseIPv6Address")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperParseIPv6Address([In] [MarshalAs(UnmanagedType.LPStr)] string addrStr, IntPtr pAddr);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperCalcChecksums")]
        public static extern uint WinDivertHelperCalcChecksums(byte[] pPacket, uint packetLen, ulong flags);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperCheckFilter")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperCheckFilter([In] [MarshalAs(UnmanagedType.LPStr)] string filter, WinDivertLayer layer, ref IntPtr errorStr, IntPtr errorPos);

        [DllImport("WinDivert.dll", EntryPoint = "WinDivertHelperEvalFilter")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinDivertHelperEvalFilter([In] [MarshalAs(UnmanagedType.LPStr)] string filter, WinDivertLayer layer, [In] byte[] pPacket, uint packetLen, [In] ref Address pAddr);
    }
}
