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
            if (args.Length > 0)
            {
                Int32.TryParse(args[0], out serverPort);
            }

            IServer server = new SfcServer(serverPort);
            server.Start();

            Console.WriteLine("Press any key to stop listening...");
            Console.ReadKey();

            server.Close();
            Console.WriteLine("Listener closed.");
            Thread.Sleep(1000);
        }
    }
}
