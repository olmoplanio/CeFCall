using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class SFCEthernet: IServer
    {
        private const string XON = "\u0011"; // ASCII control code for XON
        private const string XOFF = "\u0013"; // ASCII control code for XOFF
        private const string EOT = "\u0004"; // ASCII control code for end of transmission

        private bool transmissionPaused = false;
        private bool transmissionEnded = false;

        private int serverPort;

        public SFCEthernet(int serverPort)
        {
            this.serverPort = serverPort;
            LastMessage = "";
            Console.WriteLine("Instantiating...");
        }

        public string LastMessage { get; private set; }

        public void Listen()
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
                            byte[] xonResponse = { 17 }; // Send XON back to the sender
                            // udpClient.Send(xonResponse, 0, remoteEndPoint);
                            transmissionPaused = false;
                        }
                        else if (receivedMessage == XOFF)
                        {
                            // Handle XOFF flow control
                            Console.WriteLine("Received XOFF - Pause Transmission");
                            byte[] xffResponse = { 19 }; // Send XFF back to the sender
                            // udpClient.Send(xffResponse, 0, remoteEndPoint);
                            transmissionPaused = true;
                        }
                        else if (receivedMessage == EOT)
                        {
                            // Handle EOT
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

        public void Close()
        {
            transmissionEnded = true;
        }
    }
}
