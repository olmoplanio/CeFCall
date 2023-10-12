using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class BaseServer : IServer
    {
        private const byte EOT = 4; // ASCII control code for EOT
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

        public BaseServer(int port = 9100)
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
                                    Ethernet_DataReceived(receivedData, stream);
                                }

                                // Clear the buffer for the next iteration
                                Array.Clear(buffer, 0, buffer.Length);

                                Thread.Sleep(1000);
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

        private static void Reply(NetworkStream stream, string response)
        {
            try
            {
                // Convert the string to bytes
                byte[] dataToSend = Encoding.ASCII.GetBytes(response);

                // Send the data to the server
                stream.Write(dataToSend, 0, dataToSend.Length);
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

        protected void Ethernet_DataReceived(string receivedMessage, NetworkStream stream)
        {
            Console.Out.WriteLine($"Received data: {receivedMessage}");
            history.Append(receivedMessage);
            string resp = (receivedMessage + "0000").Substring(0, 4);
            Reply(stream, resp);
            Console.Out.WriteLine($"Sent data: {resp}");

        }
    }
}
