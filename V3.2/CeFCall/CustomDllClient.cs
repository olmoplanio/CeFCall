using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    class CustomDllMode : ICommandMode
    {
        private Gateway gateway = new Gateway();
        public string[] Execute(string serverAddress, int serverPort, params string[] messages)
        {
            var response = gateway.Exec(serverAddress, serverPort, messages);
            return response;
        }

        public string Ping(string serverAddress, int serverPort)
        {
            var response = gateway.OpenEth(serverAddress, serverPort);
            gateway.Close();
            return response[1];
        }

        public string Version
        {
            get
            {
                return gateway.GetVersion();
            }
        }
    }
}
