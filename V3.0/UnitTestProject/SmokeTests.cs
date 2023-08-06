using com.github.olmoplanio.CeFCall;
using com.github.olmoplanio.CeFCall.CeFEmulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class SmokeTests
    {
        private const string EOT = "\u0004";

        [TestMethod]
        public void UdpHelloWorld()
        {
            var th = new Thread(RunServer);
            th.Start();
            Thread.Sleep(1000);
            var client = new UdpCallerAck(false);
            client.Send("127.0.0.1", 9100, "HelloWorld");
            Thread.Sleep(1000);
            client.Send("127.0.0.1", 9100, EOT);
        }
        public void RunServer()
        {
            var emulator = new UdpServer(9100, false);
            emulator.Listen();
        }

        [TestMethod]
        public void UdpHelloWorldAck()
        {
            var th = new Thread(RunServerAck);
            th.Start();
            Thread.Sleep(1000);
            var client = new UdpCallerAck(true);
            client.Send("127.0.0.1", 9100, "HelloWorld");
            Thread.Sleep(1000);
            client.Send("127.0.0.1", 9100, EOT);
        }
        public void RunServerAck()
        {
            var emulator = new UdpServer(9100, true);
            emulator.Listen();
        }


        [TestMethod]
        public void TcpHelloWorld()
        {
            var th = new Thread(TcpRunServer);
            th.Start();
            Thread.Sleep(1000);
            var client = new TcpCaller();
            client.Send("127.0.0.1", 9100, "HelloWorld");
            Thread.Sleep(1000);
            client.Send("127.0.0.1", 9100, EOT);
        }
        public void TcpRunServer()
        {
            var emulator = new TcpServer(9100);
            emulator.Listen();
        }

        [TestMethod]
        public void TcpAckHelloWorld()
        {
            var th = new Thread(TcpRunServer);
            th.Start();
            Thread.Sleep(1000);
            var client = new TcpCaller2();
            client.Send("127.0.0.1", 9100, "HelloWorld");
            Thread.Sleep(1000);
            client.Send("127.0.0.1", 9100, EOT);
        }
    }
}