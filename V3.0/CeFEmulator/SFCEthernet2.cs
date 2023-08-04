using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    class SFCEthernet2 : IServer
    {
        private int port;
        TcpListener listener;
        public string LastMessage { get; private set; }

        public SFCEthernet2(int port = 9100)
        {
            this.port = port;
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Close()
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                    Console.WriteLine("Listener stopped.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while stopping listener: {ex.Message}");
            }
        }

        public void Listen()
        {
            try
            {
                listener.Start();
                Console.WriteLine($"Listening two-way for incoming connections on port {port}...");


                bool cancel = false;
                while (!cancel)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    Console.WriteLine("Client connected.");

                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    while (!cancel)
                    {
                        if ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            Ethernet_DataReceived(receivedData);

                            // Check for XON and XOFF characters (ASCII 17 and 19) and respond accordingly
                            if (receivedData.Contains("\u0011")) // XON character (ASCII code 17)
                            {
                                // XON received, resume data transmission
                                byte[] xonResponse = { 17 }; // Send XON back to the sender
                                stream.Write(xonResponse, 0, xonResponse.Length);
                                Console.WriteLine("Received XON, data transmission resumed.");
                            }
                            else if (receivedData.Contains("\u0013")) // XOFF character (ASCII code 19)
                            {
                                // XOFF received, pause data transmission
                                byte[] xoffResponse = { 19 }; // Send XOFF back to the sender
                                stream.Write(xoffResponse, 0, xoffResponse.Length);
                                Console.WriteLine("Received XOFF, data transmission paused.");
                            }
                            else if (receivedData.Contains("\u0004")) // EOT
                            {
                                cancel = true;
                                Console.WriteLine("Received EOT, end of transmission");
                            }

                            // Clear the buffer for the next iteration
                            Array.Clear(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void Ethernet_DataReceived(string receivedMessage)
        {
            Console.WriteLine($"Received data: {receivedMessage}");
            LastMessage = receivedMessage;
        }
    }
}
