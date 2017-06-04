namespace DivertSharp
{
    public static class WinDivertHelpers
    {
        internal static ushort SwapOrder(ushort val)
        {
            return (ushort)(((val & 0xFF00) >> 8) | ((val & 0x00FF) << 8));
        }

        internal static uint SwapOrder(uint val)
        {
            val = (val >> 16) | (val << 16);
            return ((val & 0xFF00) >> 8) | ((val & 0x00FF) << 8);
        }

        internal static ulong SwapOrder(ulong val)
        {
            val = (val >> 32) | (val << 32);
            val = ((val & 0xFFFF0000FFFF0000) >> 16) | ((val & 0x0000FFFF0000FFFF) << 16);
            return ((val & 0xFF00FF00FF00FF00) >> 8) | ((val & 0x00FF00FF00FF00FF) << 8);
        }

        /// <summary>
        /// Gets the fragment offset for the given ipv4 header.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <returns>
        /// The extracted fragment offset from the given ipv4 header.
        /// </returns>
        public static ushort IPHeader_GET_FRAGOFF(IPHeader hdr)
        {
            return (ushort)(hdr.FragOff0 & 0xFF1F);
        }

        /// <summary>
        /// Gets whether or not given ipv4 header has the more fragments flag set.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <returns>
        /// True if the given ipv4 has the more fragments flag set, false otherwise.
        /// </returns>
        public static bool IPHeader_GET_MF(IPHeader hdr)
        {
            return (ushort)(hdr.FragOff0 & 0x0020) != 0;
        }

        /// <summary>
        /// Gets whether or not given ipv4 header has the don't fragment flag set.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <returns>
        /// True if the given ipv4 has the don't fragment flag set, false otherwise.
        /// </returns>
        public static bool IPHeader_GET_DF(IPHeader hdr)
        {
            return (ushort)(hdr.FragOff0 & 0x0040) != 0;
        }

        /// <summary>
        /// Gets whether or not given ipv4 header has the reserved flag set.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <returns>
        /// True if the given ipv4 has the reserved flag set, false otherwise.
        /// </returns>
        public static bool IPHeader_GET_RESERVED(IPHeader hdr)
        {
            return (ushort)(hdr.FragOff0 & 0x0080) != 0;
        }

        /// <summary>
        /// Sets the fragment offset for the given ipv4 header.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <param name="val">
        /// The fragment offset.
        /// </param>
        public static void IPHeader_SET_FRAGOFF(IPHeader header, ushort val)
        {
            header.FragOff0 = (ushort)((header.FragOff0 & 0x00E0) | (val & 0xFF1F));
        }

        /// <summary>
        /// Sets the more fragments flag to the given value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <param name="val">
        /// The more fragments flag value.
        /// </param>
        public static void IPHeader_SET_MF(IPHeader header, ushort val)
        {
            header.FragOff0 = (ushort)((header.FragOff0 & 0xFFDF) | ((val & 0x0001) << 5));
        }

        /// <summary>
        /// Sets the don't fragment flag to the given value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <param name="val">
        /// The don't fragment flag value.
        /// </param>
        public static void IPHeader_SET_DF(IPHeader header, ushort val)
        {
            header.FragOff0 = (ushort)((header.FragOff0 & 0xFFBF) | ((val & 0x0001) << 6));
        }

        /// <summary>
        /// Sets the reserved flag to the given value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv4 header.
        /// </param>
        /// <param name="val">
        /// The reserved flag value.
        /// </param>
        public static void IPHeader_SET_RESERVED(IPHeader header, ushort val)
        {
            header.FragOff0 = (ushort)((header.FragOff0 & 0xFF7F) | ((val & 0x0001) << 7));
        }

        /// <summary>
        /// Gets the traffic class value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv6 header.
        /// </param>
        /// <returns>
        /// The traffic class value.
        /// </returns>
        public static uint IPv6Header_GET_TRAFFICCLASS(IPv6Header hdr)
        {
            return (byte)((hdr.TrafficClass0 << 4) | (byte)hdr.TrafficClass1);
        }

        /// <summary>
        /// Gets the flow label value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv6 header.
        /// </param>
        /// <returns>
        /// The flow label value.
        /// </returns>
        public static uint IPv6Header_GET_FLOWLABEL(IPv6Header hdr)
        {
            return (hdr.FlowLabel0 << 16) | hdr.FlowLabel1;
        }

        /// <summary>
        /// Sets the traffic class value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv6 header.
        /// </param>
        /// <param name="val">
        /// The value.
        /// </param>
        public static void IPv6Header_SET_TRAFFICCLASS(IPv6Header hdr, byte val)
        {
            hdr.TrafficClass0 = (byte)(val >> 4);
            hdr.TrafficClass1 = val;
        }

        /// <summary>
        /// Sets the flow label value.
        /// </summary>
        /// <param name="hdr">
        /// The ipv6 header.
        /// </param>
        /// <param name="val">
        /// The value.
        /// </param>
        public static void IPv6Header_SET_FLOWLABEL(IPv6Header hdr, uint val)
        {
            //hdr.FlowLabel0 = (uint)(val >> 16);
            //hdr.FlowLabel1 = (ushort)val;
        }

        /// WINDIVERT_HELPER_NO_IP_CHECKSUM -> 1
        public const int WINDIVERT_HELPER_NO_IP_CHECKSUM = 1;

        /// WINDIVERT_HELPER_NO_ICMP_CHECKSUM -> 2
        public const int WINDIVERT_HELPER_NO_ICMP_CHECKSUM = 2;

        /// WINDIVERT_HELPER_NO_ICMPV6_CHECKSUM -> 4
        public const int WINDIVERT_HELPER_NO_ICMPV6_CHECKSUM = 4;

        /// WINDIVERT_HELPER_NO_TCP_CHECKSUM -> 8
        public const int WINDIVERT_HELPER_NO_TCP_CHECKSUM = 8;

        /// WINDIVERT_HELPER_NO_UDP_CHECKSUM -> 16
        public const int WINDIVERT_HELPER_NO_UDP_CHECKSUM = 16;

        /// WINDIVERT_HELPER_NO_REPLACE -> 2048
        public const int WINDIVERT_HELPER_NO_REPLACE = 2048;
    }
}
