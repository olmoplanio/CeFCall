using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class SFCOneWay
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
                    SendMessage(udpClient, remoteEndPoint, XON, true);

                    foreach(var message in messages)
                    {
                        SendMessage(udpClient, remoteEndPoint, message);
                    }

                    // Send XOFF message
                    SendMessage(udpClient, remoteEndPoint, XOFF, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void SendMessage(UdpClient udpClient, IPEndPoint remoteEndPoint, string message, bool ack = false)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
            Console.WriteLine(String.Format("Sent '{0}' to {1}", message, remoteEndPoint));

            bool wait = ack;
            while (wait)
            {
                byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                wait = receivedData != messageBytes;
            }
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

