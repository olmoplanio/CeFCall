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
        bool startTransmitting = true;


        public TcpCaller(bool startTransmitting = true)
        {
            this.startTransmitting = startTransmitting;

        }

        public void Send(string serverIP, int serverPort, string message)
        {
            Send(serverIP, serverPort, new string[1] { message });
        }

        public void Send(string serverIP, int serverPort, IEnumerable<string> messages)
        {
         
            try
            {
                TcpClient client;
                client = new TcpClient();
                client.Connect(IPAddress.Parse(serverIP), serverPort);
                Console.WriteLine("Connected to the server.");

                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("Connected to the server.");

                    bool pauseTransmission = !startTransmitting;
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

                            if (incomingSignal[0] == XOFF)
                            {
                                pauseTransmission = true;
                                Console.WriteLine("Received XOFF, data transmission paused.");
                            }
                            else if (incomingSignal[0] == XON)
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
            return "V3.0.3";
        }

        public int Ping(string v)
        {
            return 0;
        }
    }
}

