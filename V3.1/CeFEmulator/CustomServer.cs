using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class CustomServer : IServer
    {
        private const byte STX = 2; // ASCII control code for STX
        private const byte ETX = 3; // ASCII control code for ETX
        private const byte EOT = 4; // ASCII control code for EOT


        private const string ACK = "\u0006"; 
        private const string NACK = "\u0021";
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

        public CustomServer(int port = 9100)
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
                if (ex != null)
                {
                    Console.Out.WriteLine($"Error while stopping listener: {ex.Message}");
                }
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
            Console.Out.WriteLine($"Listening TCP for incoming Custom connections on port {port}...");

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
                    if (tax.Message.GetHashCode() != -2120842407 && tax.Message.GetHashCode() != 173107983)
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
            string message = CustomParse(receivedMessage);
            if (message == null)
            {
                Reply(stream, NACK);
            }
            Custom_DataReceived(message, stream);
        }

        string CustomParse(string receivedMessage)
        {
            try
            {
                if (receivedMessage[0] != STX || receivedMessage[receivedMessage.Length - 1] != ETX)
                {
                    Console.Out.WriteLine($"Incorrect STX or ETX");
                    return null;
                }
                //string cnt = receivedMessage.Substring(1, 2);
                //char ident = receivedMessage[3];
                if (receivedMessage[3] != '0')
                {
                    Console.Out.WriteLine($"Incorrect IDENT");
                    return null;
                }
                string message = receivedMessage.Substring(4, receivedMessage.Length - 7);
                string chk = receivedMessage.Substring(receivedMessage.Length - 3, 2);
                string cntIdentMsg = receivedMessage.Substring(1, receivedMessage.Length - 4);
                string checksum = CheckSum(cntIdentMsg);
                if (chk != checksum)
                {
                    Console.Out.WriteLine($"Incorrect CHK");
                    return null;
                }
                return message;
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
                return null;
            }
        }

        private static string CheckSum(string s)
        {
            int cs = 0;
            foreach (var c in s)
            {
                cs = (cs + c) % 100;
            }
            return cs.ToString("D2");
        }

        protected void Custom_DataReceived(string receivedMessage, NetworkStream stream)
        {
            string repl = NACK;
            Console.Out.WriteLine($"Received data: {receivedMessage}");
            history.Append(receivedMessage);
            if (receivedMessage == "1109")
            {
                repl = ACK + "110900000";
            }
            else if (receivedMessage == "1001")
            {
                repl = ACK + "10011010231900"; ;
            }
            else if (receivedMessage == "70081")
            {
                repl = ACK + "7008"; ;
            }

            Reply(stream, repl);
            Console.Out.WriteLine($"Sent data: {repl}");
        }
    }
}
