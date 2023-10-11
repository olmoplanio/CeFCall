namespace com.github.olmoplanio.CeFCall
{
    class CustomMode : ICommandMode
    {
        private CustomClient client = new CustomClient();
        public string[] Execute(string serverAddress, int serverPort, params string[] messages)
        {
            var response = client.Exec(serverAddress, serverPort, messages);
            return response.ToArray();
        }

        public string Ping(string serverAddress, int serverPort)
        {
            var response = client.Exec(serverAddress, serverPort, "1109");
            return response.Message;
        }

        public string Version
        {
            get
            {
                return client.Version;
            }
        }
    }
}
