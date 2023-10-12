using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    interface ICommandMode
    {
        CallResult Execute(string serverAddress, int serverPort, params string[] messages);

        string Ping(string serverAddress, int serverPort);

        string Version { get; }

    }
}
