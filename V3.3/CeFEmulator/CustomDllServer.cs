using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public class CustomDllServer: CustomServer
    {
        public CustomDllServer(int port = 9100) : base(port) { }


        protected override void Custom_DataReceived(string receivedMessage, byte nonce, NetworkStream stream)
        {
            WriteLog("Received data: {0}", receivedMessage);
            history.Add(receivedMessage);

            string repl = ACK + Emulate(receivedMessage);

            Reply(stream, repl);
            WriteLog("Sent data: {0}", repl);
        }

    }
}
