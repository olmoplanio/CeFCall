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
        public void CustomHelloWorld()
        {
            IServer server = new CustomServer(9101);
            server.Start();
            Thread.Sleep(203); // Wait for server

            var client = new CustomClient();
            var r1 = client.Exec("127.0.0.1", 9101, "Hi");

            Assert.AreEqual("Hi00", r1);
            Thread.Sleep(211);

            var r2 = client.Exec("127.0.0.1", 9101, "Hello");
            Assert.AreEqual("Hell", r2);
            Thread.Sleep(211);

            Thread.Sleep(2000);

            Assert.AreEqual("HiHello", server.History);

            client.Exec("127.0.0.1", 9101, Char.ToString((char)EOT));
        }


        [TestMethod]
        public void SfcHelloWorld()
        {
            IServer server = new SfcServer(9100);
            server.Start();
            Thread.Sleep(534); // Wait for server

            var client = new SfcCaller();
            client.Send("127.0.0.1", 9100, "Hi");
            Thread.Sleep(211);

            client.Send("127.0.0.1", 9100, "Hello");
            Thread.Sleep(211);

            Thread.Sleep(2000);
            Assert.AreEqual("HiHello", server.History);

            client.Send("127.0.0.1", 9100, Char.ToString((char)EOT));
        }

        // [TestMethod]
        public void SfcChallengeXonXoff()
        {
            IServer server = new SfcServer(9100);
            server.Start();

            string message = GenerateString();
            var client = new SfcCaller();
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