using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

namespace com.github.olmoplanio.CeFCall
{
    public class UdpCaller: ICaller
    {
        const string XON = "\u0011"; // ASCII control code for XON
        const string XOFF = "\u0013"; // ASCII control code for XOFF
        readonly UdpClient udpClient;
        readonly IPEndPoint remoteEndPoint;


        public UdpCaller(string serverIP, int serverPort)
        {
            this.udpClient = new UdpClient();
            this.remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            Console.WriteLine("Connected to the server.");
        }
        public void Send(string message)
        {
            Send(new string[1] { message });
        }

        public void Send(IEnumerable<string> messages)
        {
            try
            {
                Console.WriteLine("Connected to the server.");

                bool pauseTransmission = false;
                byte xonChar = 17;
                byte xoffChar = 19;
                int line = 0;

                while (true)
                {
                    if (!pauseTransmission)
                    {
                        SendMessage(messages.ElementAt(line));
                        line++;
                        if (line >= messages.Count())
                        {
                            break;
                        }
                    }

                    // Check for incoming XOFF and XON signals from the receiver
                    if (udpClient.Available > 0)
                    {
                        byte[] incomingSignal = receiveSignal();

                        if (incomingSignal[0] == xoffChar)
                        {
                            pauseTransmission = true;
                            Console.WriteLine("Received XOFF, data transmission paused.");
                        }
                        else if (incomingSignal[0] == xonChar)
                        {
                            pauseTransmission = false;
                            Console.WriteLine("Received XON, data transmission resumed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
            Console.WriteLine(String.Format("Sent '{0}' to {1}", message, remoteEndPoint));

        }


        private byte[] receiveSignal()
        {
            var ep = remoteEndPoint;
            return udpClient.Receive(ref ep);
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

