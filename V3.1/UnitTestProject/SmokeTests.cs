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
        public void BaseHelloWorld()
        {
            IServer server = new BaseServer(9102);
            server.Start();
            Thread.Sleep(192); // Wait for server

            var client = new BaseClient();
            var r1 = client.Exec("127.0.0.1", 9102, "Hi");

            Assert.AreEqual("Hi00", r1);
            Thread.Sleep(194);

            var r2 = client.Exec("127.0.0.1", 9102, "Hello");
            Assert.AreEqual("Hell", r2);
            Thread.Sleep(194);

            Thread.Sleep(1000);

            Assert.AreEqual("HiHello", server.History);

            client.Exec("127.0.0.1", 9102, Char.ToString((char)EOT));
        }

        [TestMethod]
        public void CustomDllHelloWorld()
        {
            IServer server = new CustomDllServer(9104);
            try
            {
                server.Start();
                Thread.Sleep(253); // Wait for server

                var client = new Gateway();
                var r1 = client.Exec("127.0.0.1", 9104, new string[] { "70081" }); //apricassetto
                var err = int.Parse(r1[0]);
                var data = r1[1];
                Assert.AreEqual(0, err);
                Thread.Sleep(281);

                //Assert.AreEqual("1001", server.History);

            }
            finally
            {
                Thread.Sleep(500);
                server.Close();
            }
        }

        [TestMethod]
        public void CustomHelloWorld()
        {
            IServer server = new CustomServer(9101);
            try
            {
                server.Start();
                Thread.Sleep(203); // Wait for server

                var client = new CustomClient();
                var r1 = client.Exec("127.0.0.1", 9101, "1001");  // Data e ora
                
                Assert.AreEqual("\u00061001", r1.Substring(0,5));
                
                Thread.Sleep(2000);

                Assert.AreEqual("1001", server.History);
                client.Exec("127.0.0.1", 9101, Char.ToString((char)EOT));

            }
            finally
            {
                Thread.Sleep(500);
                server.Close();
            }
        }


        [TestMethod]
        public void CustomOpenEth()
        {
            IServer server = new CustomServer(9110);
            try
            {
                server.Start();
                Thread.Sleep(203); // Wait for server

                var client = new CustomClient();
                var r1 = client.Exec("127.0.0.1", 9110, "1109");  //Printerstatus

                Assert.AreEqual("\u0006110900000", r1);

                Thread.Sleep(2000);

                Assert.AreEqual("1109", server.History);
                client.Exec("127.0.0.1", 9110, Char.ToString((char)EOT));

            }
            finally
            {
                Thread.Sleep(500);
                server.Close();
            }
        }
    }
}