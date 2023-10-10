using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int serverPort = 9100;
            char mode = 'x';
            if (args.Length > 0)
            {
                Int32.TryParse(args[0], out serverPort);
            }
            if (args.Length > 1)
            {
                mode = args[1][1];
            }

            IServer server;
            switch(mode)
            {
                case 'c':
                    Console.WriteLine("Custom server starting...");
                    server = new SfcServer();
                    break;
                case 'x':
                    Console.WriteLine("SFC server starting...");
                    server = new CustomServer();
                    break;
                default:
                    Console.WriteLine("Server starting...");
                    server = new BaseServer();
                    break;
            }
            new SfcServer(serverPort);
            server.Start();

            Console.WriteLine("Press any key to stop listening...");
            Console.ReadKey();

            server.Close();
            Console.WriteLine("Listener closed.");
            Thread.Sleep(1000);
        }
    }
}
