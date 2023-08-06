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


        public UdpCallerAck(bool ack)
        {
            this.ack = ack;
        }

        public void Send(string serverIP, int serverPort, IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                Send(serverIP, serverPort, message);
            }
        }

        public void Send(string serverIP, int serverPort, string message)
        {
            try
            {
                UdpClient udpClient = new UdpClient();
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);


                Console.WriteLine("Connected to the server.");

                // Send XON message
                SendMessage(udpClient, remoteEndPoint, XON, ack);

                // Send Message
                SendMessage(udpClient, remoteEndPoint, message, false);

                // Send XOFF message
                SendMessage(udpClient, remoteEndPoint, XOFF, ack);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void SendMessage(UdpClient udpClient,
            IPEndPoint remoteEndPoint, 
            string message,
            bool acknowledge)
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
            return "V3.0.2";
        }

        public int Ping(string v)
        {
            return 0;
        }
    }
}

