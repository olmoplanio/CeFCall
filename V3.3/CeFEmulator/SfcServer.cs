using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class SfcServer : IServer
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

        public SfcServer(int port = 9100)
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
                    WriteLog("Listener stopped.");
                }
            }
            catch (Exception ex)
            {
                WriteLog($"Error while stopping listener: {ex.Message}");
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
            WriteLog($"Listening TCP for incoming SFC connections on port {port}...");

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
                        WriteLog("Client forcibly disconnected.");
                    }
                    else
                    {
                        WriteLog($"IO Error: {iox.Message}");
                    }
                }
                catch (SocketException tax)
                {
                    if (tax.Message.GetHashCode() != -2120842407)
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
                WriteLog($"Error: {ex.GetType()}");
            }
        }

        protected void Ethernet_DataReceived(string receivedMessage)
        {
            WriteLog($"Received data: {receivedMessage}");
            history.Append(receivedMessage);
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
