using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;
using System.IO;
using System.CodeDom;
using System.Runtime.InteropServices.ComTypes;

namespace com.github.olmoplanio.CeFCall
{
    public class TcpCaller: ICaller
    {
        private const byte XON = 17; // ASCII control code for XON
        private const byte XOFF = 19; // ASCII control code for XOFF

        public void Send(string serverIP, int serverPort, string message)
        {
            Send(serverIP, serverPort, new string[1] { message });
        }

        public void Send(string hostIp, int port, IEnumerable<string> messages)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(IPAddress.Parse(hostIp), port);
                WriteLog("Connected to the server.");

                NetworkStream stream = client.GetStream();
                bool pauseTransmission = false;
                int line = 0;

                while (true)
                {
                    if (!pauseTransmission)
                    {
                        string data = messages.ElementAt(line);
                        SendMessage(stream, data);
                        line++;
                        if (line >= messages.Count())
                        {
                            break;
                        }
                    }
                    Thread.Sleep(100);

                    // Check for incoming XOFF and XON signals from the receiver
                    if (stream.DataAvailable)
                    {
                        byte[] incomingSignal = new byte[1];
                        stream.Read(incomingSignal, 0, 1);

                        if (incomingSignal[0] == XOFF)
                        {
                            pauseTransmission = true;
                            WriteLog("Received XOFF, data transmission paused.");
                        }
                        else if (incomingSignal[0] == XON)
                        {
                            pauseTransmission = false;
                            WriteLog("Received XON, data transmission resumed.");
                        }
                    }
                } //wend
                stream.Close();
            } 
            catch (Exception ex)
            {
                WriteLog("An error occurred: " + ex.Message, true);
            }
            finally
            {
                client.Close();
            }
        }

        private static void SendMessage(NetworkStream stream, string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            WriteLog(String.Format("Sent '{0}' to endpoint", message));
        }

        private static void WriteLog(string message, bool asError = false)
        {
            var saveColor = Console.ForegroundColor;
            Console.ForegroundColor = asError ? ConsoleColor.Yellow : ConsoleColor.Cyan;
            Console.Error.WriteLine(message);
            Console.ForegroundColor = saveColor;
        }

        public string GetVersion()
        {
            return "V3.0.3";
        }

        public int Ping(string v)
        {
            return 0;
        }
    }
}

