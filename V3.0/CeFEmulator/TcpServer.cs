using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class TcpServer : IServer
    {
        private const byte EOT = 4; // ASCII control code for EOT
        private const byte XON = 17; // ASCII control code for XON
        private const byte XOFF = 19; // ASCII control code for XOFF
        private readonly int port;
        private readonly TcpListener listener;
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
                    Console.Out.WriteLine("Listener stopped.");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine($"Error while stopping listener: {ex.Message}");
            }
        }

        public void Listen()
        {
            try
            {
                listener.Start();
                Console.Out.WriteLine($"Listening TCP for incoming connections on port {port}...");

                bool cancel = false;
                while (!cancel)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    Console.Out.WriteLine("Client connected.");

                    byte[] buffer = new byte[512];
                    int bytesRead;

                    while (!cancel)
                    {
                        if ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {

                            if (buffer.Contains(EOT)) 
                            {
                                cancel = true;
                                Console.Out.WriteLine("Received EOT, end of transmission");
                            }
                            else
                            {
                                string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                                Ethernet_DataReceived(receivedData);
                            }

                            // Clear the buffer for the next iteration
                            Array.Clear(buffer, 0, buffer.Length);
                        }
                        Reply(stream, XOFF);
                        Thread.Sleep(1000);
                        Reply(stream, XON);
                    }
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void Reply(NetworkStream stream, byte response)
        {
            stream.WriteByte(response);
            stream.Flush();
        }

        protected void Ethernet_DataReceived(string receivedMessage)
        {
            Console.Out.WriteLine($"Received data: {receivedMessage}");
            LastMessage = receivedMessage;
        }
    }
}
