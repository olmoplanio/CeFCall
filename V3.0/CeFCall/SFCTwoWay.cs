using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class SFCTwoWay
    {
        private const string XON = "\u0011"; // ASCII control code for XON
        private const string XOFF = "\u0013"; // ASCII control code for XOFF


        public void Send(string serverIP, int serverPort, string message)
        {
            Send(serverIP, serverPort, new string[1] { message });
        }

        public void Send(string serverIP, int serverPort, IEnumerable<string> messages)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(serverIP), serverPort);

                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("Connected to the server.");

                    bool pauseTransmission = false;
                    byte xonChar = 17;
                    byte xoffChar = 19;
                    int line = 0;

                    while (line < messages.Count())
                    {
                        if (!pauseTransmission)
                        {
                            SendMessage(stream, messages.ElementAt(line));
                            line++;
                        }

                        // Check for incoming XOFF and XON signals from the receiver
                        if (stream.DataAvailable)
                        {
                            byte[] incomingSignal = new byte[1];
                            stream.Read(incomingSignal, 0, 1);

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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void SendMessage(NetworkStream stream, string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Console.WriteLine(String.Format("Sent '{0}' to endpoint", message));
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

