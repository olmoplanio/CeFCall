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
    public class SfcCaller
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
                        }
                        else if (incomingSignal[0] == XON)
                        {
                            pauseTransmission = false;
                        }
                    }
                } //wend
                stream.Close();
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
        }
        
        public string GetVersion()
        {
            return "V3.0.3";
        }
    }
}

