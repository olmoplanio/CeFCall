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
            char mode = 'c';
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
                    Console.Out.WriteLine($"Custom server starting on port {serverPort}...");
                    server = new CustomServer();
                    break;
                case 'd':
                    Console.Out.WriteLine($"CustomDll server starting on port {serverPort}...");
                    server = new CustomDllServer();
                    break;
                case 'x':
                    Console.Out.WriteLine($"XON/XOFF server starting on port {serverPort}...");
                    server = new SfcServer();
                    break;
                default:
                    Console.Out.WriteLine($"Server starting on port {serverPort}...");
                    server = new BaseServer();
                    break;
            }
            server.Start();

            Console.Out.WriteLine("Press any key to stop listening...");
            Console.In.ReadLine();

            server.Close();
            Console.Out.WriteLine("Listener closed.");
            Thread.Sleep(1000);
        }
    }
}
