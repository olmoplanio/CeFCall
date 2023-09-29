using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    interface ICaller
    {
        void Send(string ip, int port, IEnumerable<string> commands);
        string GetVersion();
        int Ping(string s);
    }
}
