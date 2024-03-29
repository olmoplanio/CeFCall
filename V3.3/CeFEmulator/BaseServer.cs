﻿using System;
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
            WriteLog($"Listening TCP for incoming connections on port {port}...");

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
                WriteLog($"Error: {ex.GetType()}");
            }
        }

        protected void Ethernet_DataReceived(string receivedMessage, NetworkStream stream)
        {
            WriteLog($"Received data: {receivedMessage}");
            history.Append(receivedMessage);
            string resp = (receivedMessage + "0000").Substring(0, 4);
            Reply(stream, resp);
            WriteLog($"Sent data: {resp}");

        }


        protected static void WriteLog(string message, params object[] args)
        {
            var saveColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteLog(message, args);
            Console.ForegroundColor = saveColor;
        }
    }
}
