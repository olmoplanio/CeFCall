using System;
using System.IO;
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
        private readonly StringBuilder history;
        bool cancel;
        public string History
        {
            get
            {
                return history.ToString();
            }
        }

        public TcpServer(int port = 9100)
        {
            this.port = port;
            history = new StringBuilder();
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Close()
        {
            try
            {
                cancel = true;
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

        public void Start()
        {
            var thread = new Thread(Listen);
            thread.Start();
        }

        public void Listen()
        {
            listener.Start();
            Console.Out.WriteLine($"Listening TCP for incoming connections on port {port}...");

            cancel = false;
            while (!cancel)
            {
                try
                {
                    Console.Out.WriteLine("Waiting for client...");
                    using (TcpClient client = listener.AcceptTcpClient())
                    {
                        using (NetworkStream stream = client.GetStream())
                        {

                            Console.Out.WriteLine("Client connected.");

                            byte[] buffer = new byte[512];
                            int bytesRead;

                            while (!cancel && (bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
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

                                Reply(stream, XOFF);
                                Thread.Sleep(1000);
                                Reply(stream, XON);
                            }
                            stream.Close();
                        }
                        client.Close();
                    }
                }
                catch(IOException iox)
                {
                    if (iox.Message.GetHashCode() == -960292345 || iox.Message.GetHashCode() == -948353057)
                    {
                        Console.Out.WriteLine("Client forcibly disconnected.");
                    }
                    else
                    {
                        Console.Out.WriteLine($"IO Error: {iox.Message}");
                    }
                }
                catch (SocketException tax)
                {
                    if (tax.Message.GetHashCode() != -2120842407)
                    {
                        Console.Out.WriteLine($"Socket Error: {tax.Message.GetHashCode()}: {tax.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void Reply(NetworkStream stream, byte response)
        {
            try
            {
                stream.WriteByte(response);
                stream.Flush();
            }
            catch (System.IO.IOException)
            {
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine($"Error: {ex.GetType()}");
            }
        }

        protected void Ethernet_DataReceived(string receivedMessage)
        {
            Console.Out.WriteLine($"Received data: {receivedMessage}");
            history.Append(receivedMessage);

        }
    }
}
