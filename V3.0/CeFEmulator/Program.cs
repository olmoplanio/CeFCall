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
            if (args.Length > 0)
            {
                Int32.TryParse(args[0], out serverPort);
            }

            IServer server = new TcpServer(serverPort);
            server.Listen();

            Console.WriteLine("Press any key to stop listening...");
            Console.ReadKey();

            server.Close();
            Console.WriteLine("Listener closed.");
        }
    }
}
