using System;
using System.Collections.Generic;
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
        protected readonly List<string> history;
        private readonly TcpListener listener;
        private bool cancel;
        public string History
        {
            get
            {
                return String.Join(",", history.ToArray());
            }
        }

        public CustomServer(int port = 9100)
        {
            this.port = port;
            history = new List<string>(5);
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
                    WriteLog("Listener stopped.");
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
            WriteLog($"Listening TCP for incoming Custom connections on port {port}...");

            cancel = false;
            while (!cancel)
            {
                try
                {
                    WriteLog("Waiting for client...");
                    using (TcpClient client = listener.AcceptTcpClient())
                    {
                        using (NetworkStream stream = client.GetStream())
                        {

                            WriteLog("Client connected.");

                            byte[] buffer = new byte[512];
                            int bytesRead;

                            while (!cancel && (bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                if (buffer.Contains(EOT))
                                {
                                    cancel = true;
                                    WriteLog("Received EOT, end of transmission");
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
                    if (iox.Message.GetHashCode() == -960292345 || iox.Message.GetHashCode() == -948353057 || iox.Message.GetHashCode() == -1207492938)
                    {
                        WriteLog("Client forcibly disconnected.");
                    }
                    else
                    {
                        WriteLog($"IO Error: {iox.Message}");
                    }
                }
                catch (SocketException tax)
                {
                    if (tax.Message.GetHashCode() != -2120842407 && tax.Message.GetHashCode() != 173107983)
                    {
                        WriteLog($"Socket Error: {tax.Message.GetHashCode()}: {tax.Message}");
                    }
                }
                catch (Exception ex)
                {
                    WriteLog($"Error: {ex.Message}");
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
                WriteLog($"Error: {ex.GetType()}");
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
            if (string.IsNullOrEmpty(receivedMessage))
            {
                return;
            }
            var countedMessage = CustomParse(receivedMessage);
            if (countedMessage == null)
            {
                Reply(stream, NACK);
            }
            else
            {
                Custom_DataReceived(countedMessage.InnerMessage, countedMessage.Counter, stream);
            }
        }

        private CustomMessage CustomParse(string receivedMessage)
        {
            try
            {
                if (!receivedMessage.StartsWith(STX) || !receivedMessage.EndsWith(ETX))
                {
                    WriteLog($"Incorrect STX or ETX");
                    return null;
                }
                byte cnt = Byte.Parse(receivedMessage.Substring(1, 2));
                char ident = receivedMessage[3];
                if (receivedMessage[3] != '0')
                {
                    WriteLog($"Incorrect IDENT");
                    return null;
                }
                string message = receivedMessage.Substring(4, receivedMessage.Length - 7);
                string chk = receivedMessage.Substring(receivedMessage.Length - 3, 2);
                string cntIdentMsg = receivedMessage.Substring(1, receivedMessage.Length - 4);
                string checksum = CheckSum(cntIdentMsg);
                if (chk != checksum)
                {
                    WriteLog($"Incorrect CHK");
                    return null;
                }
                return new CustomMessage(cnt, message);
            }
            catch(Exception ex)
            {
                WriteLog(ex.ToString());
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
            WriteLog($"Received data: {receivedMessage}");
            history.Add(receivedMessage);

            string response = Emulate(receivedMessage);
            string innerMessage = $"{nonce:D2}0{response}";
            string chk = CheckSum(innerMessage);

            string repl = $"{ACK}{STX}{innerMessage}{chk}{ETX}";

            Reply(stream, repl);
            WriteLog($"Sent data: {repl}");
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
                return $"1001{now:ddMMyy}";
            }
            else if (receivedMessage == "70081")
            {
                return "7008";
            }
            return receivedMessage.Substring(0, 4);
        }

        protected static void WriteLog(string message, params object[] args)
        {
            var saveColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Out.WriteLine(message, args);
            Console.ForegroundColor = saveColor;
        }
    }
}
