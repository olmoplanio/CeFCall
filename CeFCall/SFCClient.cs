using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class SFCClient
    {
        private const string XON = "\u0011"; // ASCII control code for XON
        private const string XOFF = "\u0013"; // ASCII control code for XOFF


        public void Send(string serverIP, int serverPort, string message)
        {
            Send(serverIP, serverPort, new string[1] {message});
        }

        public void Send(string serverIP, int serverPort, IEnumerable<string> messages)
        {
            try
            {
                using (var udpClient = new UdpClient())
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

                    // Send XON message
                    SendXONXOFFMessage(udpClient, remoteEndPoint, XON);

                    foreach(var message in messages)
                    {
                        SendXONXOFFMessage(udpClient, remoteEndPoint, message);
                    }

                    // Send XOFF message
                    SendXONXOFFMessage(udpClient, remoteEndPoint, XOFF);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void SendXONXOFFMessage(UdpClient udpClient, IPEndPoint remoteEndPoint, string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
            Console.WriteLine($"Sent '{message}' to {remoteEndPoint}");
        }

        internal string GetVersion()
        {
            return "V3.0";
        }

        internal int Ping(string v)
        {
            return 0;
        }
    }
}

