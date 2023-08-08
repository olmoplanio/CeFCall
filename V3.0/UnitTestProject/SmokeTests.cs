using com.github.olmoplanio.CeFCall;
using com.github.olmoplanio.CeFCall.CeFEmulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class SmokeTests
    {
        private const byte EOT = 4;
        private const string TestMessage = "HelloWorld";
        private IServer server;

        [TestMethod]
        public void TcpHelloWorld()
        {
            server = new TcpServer(9100);
            var th = new Thread(server.Listen);
            th.Start();
            Thread.Sleep(1987);
            var client = new TcpCaller();
            client.Send("127.0.0.1", 9100, TestMessage);
            Thread.Sleep(836);
            Assert.AreEqual(TestMessage, server.LastMessage);
            client.Send("127.0.0.1", 9100, Char.ToString((char)EOT));
        }

    }
}