using com.github.olmoplanio.CeFCall;
using com.github.olmoplanio.CeFCall.CeFEmulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class SmokeTests
    {
        private const byte EOT = 4;

        [TestMethod]
        public void TcpHelloWorld()
        {
            IServer server = new TcpServer(9100);
            server.Start();
            Thread.Sleep(534); // Wait for server

            var client = new TcpCaller();
            client.Send("127.0.0.1", 9100, "Hi");
            Thread.Sleep(211);

            client.Send("127.0.0.1", 9100, "Hello");
            Thread.Sleep(211);

            Thread.Sleep(2000);
            Assert.AreEqual("HiHello", server.History);

            client.Send("127.0.0.1", 9100, Char.ToString((char)EOT));
        }

        // [TestMethod]
        public void TcpChallengeXoffXon()
        {
            IServer server = new TcpServer(9100);
            server.Start();

            string message = GenerateString();
            var client = new TcpCaller();
            client.Send("127.0.0.1", 9100, message);
            Thread.Sleep(2000);

            Assert.AreEqual(message, server.History);
            client.Send("127.0.0.1", 9100, Char.ToString((char)EOT));
        }

        private static string GenerateString()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                char randomChar = (char)random.Next(32, 127); // ASCII range: 32 (space) to 126 (tilde)
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }
    }
}