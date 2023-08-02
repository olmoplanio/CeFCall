using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.olmoplanio.CeFCall.SFCEmulator
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
            var server = new Server();
            server.Listen(serverPort);
        }
    }
}
