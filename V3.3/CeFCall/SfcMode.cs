using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    internal class SfcMode : ICommandMode
    {
        private readonly SfcCaller client = new SfcCaller();
        public CallResult Execute(string serverAddress, int serverPort, params string[] messages)
        {
            try
            {
                client.Send(serverAddress, serverPort, messages);
                return new CallResult(0, "OK");
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
                client.Send(serverAddress, serverPort, "K");
                return "OK";
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
                    return client.GetVersion();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
