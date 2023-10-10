using System;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class CustomClient
    {
        public string Exec(string serverIpAddress, int serverPort, string messageToSend)
        {
            string serverResponse = null;
            try
            {
                // Create a TCP client socket
                var client = new TcpClient(serverIpAddress, serverPort);

                // Get the network stream for sending and receiving data
                NetworkStream stream = client.GetStream();

                string commandToSend = "\u0002000" + messageToSend + CheckSum("000" + messageToSend) + "\u0003";
                // Convert the string to bytes
                byte[] dataToSend = Encoding.ASCII.GetBytes(commandToSend);

                // Send the data to the server
                stream.Write(dataToSend, 0, dataToSend.Length);
                stream.Flush();

                // Receive the response from the server
                byte[] dataReceived = new byte[1024];
                int bytesRead = stream.Read(dataReceived, 0, dataReceived.Length);

                // Convert the received data to a string
                serverResponse = Encoding.ASCII.GetString(dataReceived, 0, bytesRead);

                Console.WriteLine("Received from server: " + serverResponse);

                // Close the client socket
                client.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return serverResponse;
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
    }
}

