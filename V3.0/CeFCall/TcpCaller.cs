using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

namespace com.github.olmoplanio.CeFCall
{
    public class TcpCaller: ICaller
    {
        const byte XON = 17; // ASCII control code for XON
        const byte XOFF = 19; // ASCII control code for XOFF
        TcpClient client;


        public TcpCaller(string serverIP, int serverPort)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse(serverIP), serverPort);
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
                using (NetworkStream stream = client.GetStream())
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
                            SendMessage(stream, messages.ElementAt(line));
                            line++;
                            if (line >= messages.Count())
                            {
                                break;
                            }
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

