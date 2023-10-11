using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class CustomClient
    {
        public readonly string Version = "V3.2";

        public CallResult Exec(string serverIpAddress, int serverPort, params string[] messagesToSend)
        {
            int errorCode = 0;
            string serverResponse = null;
            try
            {
                // Create a TCP client socket
                var client = new TcpClient(serverIpAddress, serverPort);

                // Get the network stream for sending and receiving data
                NetworkStream stream = client.GetStream();
                int cnt = 0;
                foreach (var messageToSend in messagesToSend)
                {
                    string innerMessage = $"{cnt:D2}0{messageToSend}";
                    string commandToSend = "\u0002" + innerMessage + CheckSum(innerMessage) + "\u0003";
                    // Convert the string to bytes
                    byte[] dataToSend = Encoding.ASCII.GetBytes(commandToSend);
                    // Send the data to the server
                    stream.Write(dataToSend, 0, dataToSend.Length);
                    stream.Flush();


                    // Receive the response from the server
                    byte[] dataReceived = new byte[1024];
                    int bytesRead = stream.Read(dataReceived, 0, dataReceived.Length);


                    if (dataReceived[0] == 21)
                    {
                        errorCode = 21;
                        serverResponse = "NACK";
                        Console.Out.WriteLine("Received from server: " + serverResponse);

                        stream.WriteByte(6);
                        stream.Flush();
                    }
                    else
                    {
                        int skip = 0;
                        while (bytesRead > 0 && (dataReceived[skip] == 6))
                        {
                            skip++;
                            bytesRead--;
                        }
                        if (bytesRead >= 7)
                        {
                            // Convert the received data to a string
                            serverResponse = Encoding.ASCII.GetString(dataReceived, skip + 4, bytesRead - 7);
                            if (serverResponse.Substring(4, 3) == "ERR")
                            {
                                errorCode = int.Parse(serverResponse.Substring(6, 2));
                            }
                            else
                            {
                                errorCode = 0;
                            }
                            Console.Out.WriteLine("Received from server: " + serverResponse);

                            stream.WriteByte(6);
                            stream.Flush();
                        }
                    }

                    cnt++;
                }

                // Close the client socket
                client.Close();

            }
            catch (Exception ex)
            {
                return new CallResult(ex.Message.GetHashCode(), ex.Message);
            }
            return new CallResult(errorCode, serverResponse);
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

