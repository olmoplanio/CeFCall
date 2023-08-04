using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int serverPort = 9100;
            string comPort = "COM1";
            if (args.Length > 0)
            {
                Int32.TryParse(args[0], out serverPort);
                comPort = args[0];
            }

            IServer server;
            if (args.Length > 1)
            {
                switch (args[1])
                {
                    case "s":
                        server = new SerialPort(comPort);
                        break;
                    case "2":
                        server = new TcpServer(serverPort);
                        break;
                    default:
                        server = new UdpServer(serverPort);
                        break;
                }
            }
            else
            {
                server = new UdpServer(serverPort);
            }
            server.Listen();

            Console.WriteLine("Press any key to stop listening...");
            Console.ReadKey();

            server.Close();
            Console.WriteLine("Listener closed.");
        }
    }
}
