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
        public const byte EOT = 4; // ASCII control code for EOT

        private class CustomMessage
        {
            public byte Counter { get; private set; }
            public string InnerMessage { get; private set; }

            public CustomMessage(byte counter, string innerMessage)
            {
                Counter = counter;
                InnerMessage = innerMessage;
            }
        }

        private const string STX = "\u0002";
        private const string ETX = "\u0003";
        protected const string ACK = "\u0006";
        protected const string NACK = "\u0021";
        protected readonly int port;
        protected readonly StringBuilder history;
        private readonly TcpListener listener;
        private bool cancel;
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
            catch
            {
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

        protected static void Reply(NetworkStream stream, string response)
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

        protected virtual void Ethernet_DataReceived(string msg, NetworkStream stream)
        {
            if (msg == null)
            {
                Reply(stream, NACK);
            }
            short start = 0;
            while(start < msg.Length && msg[start] == 6)
            {
                start++;
            }
            var receivedMessage = msg.Substring(start);

            var countedMessage = CustomParse(receivedMessage);
            if (countedMessage == null)
            {
                Reply(stream, NACK);
            }
            Custom_DataReceived(countedMessage.InnerMessage, countedMessage.Counter, stream);
        }

        private CustomMessage CustomParse(string receivedMessage)
        {
            try
            {
                if (!receivedMessage.StartsWith(STX) || !receivedMessage.EndsWith(ETX))
                {
                    Console.Out.WriteLine($"Incorrect STX or ETX");
                    return null;
                }
                byte cnt = Byte.Parse(receivedMessage.Substring(1, 2));
                char ident = receivedMessage[3];
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
                return new CustomMessage(cnt, message);
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
                return null;
            }
        }

        protected static string CheckSum(string s)
        {
            int cs = 0;
            foreach (var c in s)
            {
                cs = (cs + c) % 100;
            }
            return cs.ToString("D2");
        }

        protected virtual void Custom_DataReceived(string receivedMessage, byte nonce, NetworkStream stream)
        {
            Console.Out.WriteLine($"Received data: {receivedMessage}");
            history.Append(receivedMessage);

            string response = Emulate(receivedMessage);
            string innerMessage = $"{nonce:D2}0{response}";
            string chk = CheckSum(innerMessage);

            string repl = $"{ACK}{STX}{innerMessage}{chk}{ETX}";

            Reply(stream, repl);
            Console.Out.WriteLine($"Sent data: {repl}");
        }

        protected static string Emulate(string receivedMessage)
        {
            if (receivedMessage == "1109")
            {
                return "110900000";
            }
            else if (receivedMessage == "1001")
            {
                var now = DateTime.Now;
                return $"10011{now:ddMMYY}";
            }
            else if (receivedMessage == "70081")
            {
                return "7008";
            }
            return receivedMessage.Substring(0, 4);
        }
    }
}
