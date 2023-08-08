using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;

namespace com.github.olmoplanio.CeFCall
{
    public class TcpCaller: ICaller
    {
        private const byte XON = 17; // ASCII control code for XON
        private const byte XOFF = 19; // ASCII control code for XOFF

        public void Send(string serverIP, int serverPort, string message)
        {
            Send(serverIP, serverPort, new string[1] { message });
        }

        public void Send(string hostIp, int port, IEnumerable<string> messages)
        {
         
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(hostIp), port);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Error.WriteLine("Connected to the server.");

                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("Connected to the server.");

                    bool pauseTransmission = false;
                    int line = 0;

                    while (true)
                    {
                        if (pauseTransmission)
                        {
                            Thread.Sleep(100);
                        }
                        else
                        {
                            string data = messages.ElementAt(line);
                            SendMessage(stream, data);
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

                            if (incomingSignal[0] == XOFF)
                            {
                                pauseTransmission = true;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Error.WriteLine("Received XOFF, data transmission paused.");
                            }
                            else if (incomingSignal[0] == XON)
                            {
                                pauseTransmission = false;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Error.WriteLine("Received XON, data transmission resumed.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Error.WriteLine("An error occurred: " + ex.Message);
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
            return "V3.0.3";
        }

        public int Ping(string v)
        {
            return 0;
        }
    }
}

