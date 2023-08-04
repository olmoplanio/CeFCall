using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;




namespace com.github.olmoplanio.CeFCall.CeFEmulator
{

    public class SFCEthernet3: IServer
    {
        private TcpListener listener;
        private bool isListening;

        protected void Ethernet_DataReceived(string receivedMessage)
        {
            Console.WriteLine($"Received data: {receivedMessage}");
            LastMessage = receivedMessage;
        }

        public SFCEthernet3(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Listen()
        {
            try
            {
                listener.Start();
                isListening = true;
                Console.WriteLine($"Listening for incoming connections on port {((IPEndPoint)listener.LocalEndpoint).Port}...");

                AcceptConnections();
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
                isListening = false;
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

        public string LastMessage { get; private set; }

        private void AcceptConnections()
        {
            while (isListening)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(HandleClient, client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accepting client: {ex.Message}");
                }
            }
        }

        private void HandleClient(object clientObject)
        {
            TcpClient client = clientObject as TcpClient;
            if (client == null) return;

            try
            {
                NetworkStream stream = client.GetStream();

                Console.WriteLine("Client connected.");

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
                        if (buffer[0] == 17) // XON character (ASCII code 17)
                        {
                            // XON received, resume data transmission
                            byte[] xonResponse = { 17 }; // Send XON back to the sender
                            stream.Write(xonResponse, 0, xonResponse.Length);
                            Console.WriteLine("Received XON, data transmission resumed.");
                        }
                        else if (buffer[0] == 19) // XOFF character (ASCII code 19)
                        {
                            // XOFF received, pause data transmission
                            byte[] xoffResponse = { 19 }; // Send XOFF back to the sender
                            stream.Write(xoffResponse, 0, xoffResponse.Length);
                            Console.WriteLine("Received XOFF, data transmission paused.");
                        }
                        else if (buffer[0] == 4)  // Check for EOT character (ASCII code 4) to exit the loop
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
    }
}
