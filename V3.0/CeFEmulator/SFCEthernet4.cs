using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    class SFCEthernet4 : IServer
    {
        private TcpListener listener;
        private TcpClient client;

        public SFCEthernet4(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Listen()
        {
            try
            {
                listener.Start();
                Console.WriteLine($"Listening for incoming connections on port {((IPEndPoint)listener.LocalEndpoint).Port}...");

                AcceptConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Close()
        {
            try
            {
                if (client != null)
                {
                    client.Close();
                    Console.WriteLine("Connection closed.");
                }

                if (listener != null)
                {
                    listener.Stop();
                    Console.WriteLine("Listener stopped.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while closing connection/listener: {ex.Message}");
            }
        }

        private void AcceptConnection()
        {
            try
            {
                client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                HandleClient();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accepting client: {ex.Message}");
            }
        }

        private void HandleClient()
        {
            if (client == null) return;

            try
            {
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead;

                while (true)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
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

                        // Check for EOT character (ASCII code 4) to exit the loop
                        if (receivedData.Contains("\u0004"))
                        {
                            Console.WriteLine("Received EOT, exiting client handler.");
                            break;
                        }

                        // Clear the buffer for the next iteration
                        Array.Clear(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        public string LastMessage { get; private set; }

        private void Ethernet_DataReceived(string receivedMessage)
        {
            Console.WriteLine($"Received data: {receivedMessage}");
            LastMessage = receivedMessage;
        }
    }
}
