using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class TcpServer : IServer
    {
        private readonly int port;
        TcpListener listener;
        public string LastMessage { get; private set; }

        public TcpServer(int port = 9100)
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
                Console.WriteLine($"Listening TCP for incoming connections on port {port}...");


                bool cancel = false;
                while (!cancel)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    Console.WriteLine("Client connected.");

                    byte[] buffer = new byte[512];
                    int bytesRead;

                    while (!cancel)
                    {
                        if ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                            // Check for XON and XOFF characters (ASCII 17 and 19) and respond accordingly
                            if (receivedData.Contains("\u0013")) // XOFF character (ASCII code 19)
                            {
                                Reply(stream, 19); // Send XOFF back to the sender
                                Console.WriteLine("Received XOFF, data transmission resumed.");
                            }
                            else if (receivedData.Contains("\u0011")) // XON character (ASCII code 17)
                            {
                                Reply(stream, 17); // Send XON back to the sender
                                Console.WriteLine("Received XON, data transmission paused.");
                            }
                            else if (receivedData.Contains("\u0004")) // EOT
                            {
                                cancel = true;
                                Console.WriteLine("Received EOT, end of transmission");
                            }
                            else
                            {
                                Reply(stream, 19); // Send XOFF back to the sender
                                Ethernet_DataReceived(receivedData);
                                Reply(stream, 17); // Send XON back to the sender
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

        private static void Reply(NetworkStream stream, byte response)
        {
            byte[] xResponse = { response }; 
            stream.Write(xResponse, 0, xResponse.Length);
        }

        private void Ethernet_DataReceived(string receivedMessage)
        {
            Console.WriteLine($"Received data: {receivedMessage}");
            LastMessage = receivedMessage;
        }
    }
}
