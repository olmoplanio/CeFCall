using System;

namespace com.github.olmoplanio.CeFCall
{
    class CustomMode : ICommandMode
    {
        private readonly CustomClient client = new CustomClient();
        public CallResult Execute(string serverAddress, int serverPort, params string[] messages)
        {
            try
            {
                return client.Exec(serverAddress, serverPort, messages);
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
                var response = client.Exec(serverAddress, serverPort, "1109");
                return response.Message;
            }
            catch(Exception ex)
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
                    return client.Version;
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
