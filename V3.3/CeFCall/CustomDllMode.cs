using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    class CustomDllMode : ICommandMode
    {
        private Gateway gateway = new Gateway();
        public CallResult Execute(string serverAddress, int serverPort, params string[] messages)
        {
            try
            {
                return gateway.Exec(serverAddress, serverPort, messages);
            }
            catch(Exception ex)
            {
                return new CallResult(ex);
            }
        }

        public string Ping(string serverAddress, int serverPort)
        {
            try
            {
                var response = gateway.OpenEth(serverAddress, serverPort);
                gateway.Close();
                return response.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
    }

        public string Version
        {
            get
            {
                try
                {
                    return gateway.GetVersion();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
