using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.ComponentModel.Design;

namespace com.github.olmoplanio.CeFCall
{
    public class TcpCaller2 : ICaller
    {
        private bool startTransmitting;
        const byte XON = 17; // ASCII control code for XON
        const byte XOFF = 19; // ASCII control code for XOFF


        public TcpCaller2(bool startTransmitting = true)
        {
            this.startTransmitting = startTransmitting;
        }

        public string GetVersion()
        {
            return "V3.0.4";
        }

        public int Ping(string s)
        {
            return 0;
        }

        public void Send(string serverIP, int serverPort, IEnumerable<string> commands)
        {
            try
            {
                TcpClient client;
                client = new TcpClient();
                client.Connect(IPAddress.Parse(serverIP), serverPort);
                Console.WriteLine("Connected to the server.");
                foreach (string cmd in commands)
                {
                    TransmitData(client, cmd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        public void Send(string serverIP, int serverPort, string data)
        {
            try
            {
                TcpClient client;
                client = new TcpClient();
                client.Connect(IPAddress.Parse(serverIP), serverPort);
                Console.WriteLine("Connected to the server.");
                TransmitData(client, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        void TransmitData(TcpClient client, string data)
        {
            NetworkStream stream = client.GetStream();
            bool transmitting = startTransmitting;

            int index = 0;

            while (index < data.Length)
            {
                while (!transmitting)
                {
                    Thread.Sleep(100); // wait for XON signal
                }

                if ((int)data[index] == 19) // ASCII code for XOFF
                {
                    transmitting = false;
                    Console.WriteLine("Transmission paused. Waiting for XON signal...");
                    index++;
                    continue;
                }

                if ((int)data[index] == 17) // ASCII code for XON
                {
                    transmitting = true;
                    Console.WriteLine("Resuming transmission...");
                    index++;
                    continue;
                }

                byte[] bytesToSend = Encoding.ASCII.GetBytes(data[index].ToString());
                stream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("Transmitting data: " + data[index]);
                index++;
            }

            client.Close();
            Console.WriteLine("Transmission completed!");
        }
    }
}
