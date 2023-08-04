using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class UdpCaller
    {
        const string XON = "\u0011"; // ASCII control code for XON
        const string XOFF = "\u0013"; // ASCII control code for XOFF
        readonly bool ack;
        readonly UdpClient udpClient;
        readonly IPEndPoint remoteEndPoint;


        public UdpCaller(string serverIP, int serverPort, bool ack)
        {
            this.ack = ack;
            this.udpClient = new UdpClient();
            this.remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

        }

        public void Send(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                Send(message);
            }
        }

        public void Send(string message)
        {
            try
            {
                // Send XON message
                SendMessage(XON);

                // Send Message
                SendMessage(message);

                // Send XOFF message
                SendMessage(XOFF);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            var ep = remoteEndPoint;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
            Console.WriteLine(String.Format("Sent '{0}' to {1}", message, remoteEndPoint));

            bool wait = ack;
            while (wait)
            {
                byte[] receivedData = udpClient.Receive(ref ep);
                Console.WriteLine(String.Format("Received acknoledgment {0}", receivedData));
                wait = receivedData != messageBytes;
            }
        }

        public static string GetVersion()
        {
            return "V3.0";
        }

        public static int Ping(string v)
        {
            return 0;
        }
    }
}

