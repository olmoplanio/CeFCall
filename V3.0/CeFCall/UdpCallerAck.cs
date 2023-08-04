using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class UdpCallerAck: ICaller
    {
        const string XON = "\u0011"; // ASCII control code for XON
        const string XOFF = "\u0013"; // ASCII control code for XOFF
        readonly bool ack;
        readonly UdpClient udpClient;
        readonly IPEndPoint remoteEndPoint;


        public UdpCallerAck(string serverIP, int serverPort, bool ack)
        {
            this.ack = ack;
            this.udpClient = new UdpClient();
            this.remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            Console.WriteLine("Connected to the server.");
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
                SendMessage(XON, ack);

                // Send Message
                SendMessage(message, false);

                // Send XOFF message
                SendMessage(XOFF, ack);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void SendMessage(string message, bool acknowledge)
        {
            var ep = remoteEndPoint;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
            Console.WriteLine(String.Format("Sent '{0}' to {1}", message, remoteEndPoint));

            bool wait = acknowledge;
            while (wait)
            {
                byte[] receivedData = udpClient.Receive(ref ep);
                wait = messageBytes[0] != receivedData[0];
                if (wait)
                {
                    Console.WriteLine(String.Format("Received nack: {0}", receivedData[0]));
                }
            }
        }

        public string GetVersion()
        {
            return "V3.0";
        }

        public int Ping(string v)
        {
            return 0;
        }
    }
}

