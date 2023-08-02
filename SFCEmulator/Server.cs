using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall.SFCEmulator
{
    public class Server
    {
        private const string XON = "\u0011"; // ASCII control code for XON
        private const string XOFF = "\u0013"; // ASCII control code for XOFF
        private const string EOT = "\u0004"; // ASCII control code for end of transmission

        private bool transmissionPaused = false;
        private bool transmissionEnded = false;

        public Server()
        {
            LastMessage = "";
            Console.WriteLine("Instantiating...");
        }

        public void Pause()
        {
            transmissionPaused = true;
        }

        public void End()
        {
            transmissionEnded = true;
        }

        public string LastMessage { get; private set; }

        public void Listen(int serverPort)
        {
            try
            {
                transmissionPaused = false;
                transmissionEnded = false;
                using (var udpClient = new UdpClient(serverPort))
                {
                    Console.WriteLine($"Listening for data on port {serverPort}...");

                    var remoteEndPoint = new IPEndPoint(IPAddress.Any, serverPort);

                    while (!transmissionEnded)
                    {
                        // Receive data
                        byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                        string receivedMessage = Encoding.ASCII.GetString(receivedData);

                        // Process received data
                        if (receivedMessage == XON)
                        {
                            // Handle XON flow control
                            Console.WriteLine("Received XON - Resume Transmission");
                            transmissionPaused = false;
                        }
                        else if (receivedMessage == XOFF)
                        {
                            // Handle XOFF flow control
                            Console.WriteLine("Received XOFF - Pause Transmission");
                            transmissionPaused = true;
                        }
                        else if (receivedMessage == EOT)
                        {
                            // Handle XOFF flow control
                            Console.WriteLine("Received EOT - End Transmission");
                            transmissionEnded = true;
                        }
                        else
                        {
                            // Handle regular data received
                            if (!transmissionPaused)
                            {
                                Console.WriteLine($"Received data: {receivedMessage}");
                            }
                            LastMessage = receivedMessage;
                        }
                    }
                }

                Console.WriteLine("Done.");
                transmissionPaused = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
