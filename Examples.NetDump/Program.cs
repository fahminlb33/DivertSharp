using DivertSharp;
using System;
using System.Runtime.InteropServices;

namespace Examples.NetDump
{
    unsafe class Program
    {
        private static bool _running = true;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate { _running = false; };

            // open handle
            using (var handle = Diversion.WinDivertOpen("true", WinDivertLayer.Network, 100, 0))
            {
                if (handle.IsInvalid)
                {
                    Console.WriteLine("Unable to open handle. Error: " + Marshal.GetLastWin32Error());
                    return;
                }

                // prepare headers
                var ipHeader = new IPHeader();
                var ipv6Header = new IPv6Header();
                var icmpHeader = new ICMPHeader();
                var icmpv6Header = new ICMPv6Header();
                var tcpHeader = new TCPHeader();
                var udpHeader = new UDPHeader();

                var address = new Address();
                byte[] buffer = new byte[65535];

                uint receiveLength = 0;
                uint sendLength = 0;

                string processName;
                uint pid = 0;

                // loop
                while (_running)
                    pid = 0;
                receiveLength = 0;
                sendLength = 0;

                fixed (byte* data = buffer)
                {
                    Diversion.WinDivertHelperParsePacket(data, receiveLength, ipHeader, ipv6Header, icmpHeader,
                        icmpv6Header, tcpHeader, udpHeader, null, null);
                }
            }
        }
    }
}