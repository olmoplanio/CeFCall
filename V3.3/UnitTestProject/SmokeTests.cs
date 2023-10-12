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

        [TestMethod]
        public void CustomDllHelloWorld()
        {
            IServer server = new CustomDllServer(9104);
            try
            {
                server.Start();
                Thread.Sleep(253); // Wait for server

                var client = new Gateway();
                CallResult r1 = client.Exec("127.0.0.1", 9104, new string[] { "70081" }); //apricassetto

                Assert.AreEqual(0, r1.ErrorCode);
                Assert.AreEqual("", r1.Message);

                CallResult r2 = client.Exec("127.0.0.1", 9104, new string[] { "1001" }); 
                Assert.AreEqual(0, r2.ErrorCode);
                Assert.AreEqual($"1001{DateTime.Now:ddMMyy}", r2.Message);
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
                var r2 = client.Exec("127.0.0.1", 9101, "1109", "1001");  // Data e ora

                Assert.AreEqual(0, r2.ErrorCode);
                Assert.AreEqual($"1001{DateTime.Now:ddMMyy}", r2.Message);

                Thread.Sleep(2000);

                Assert.AreEqual("1109,1001", server.History);
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

                Assert.AreEqual("110900000", r1.Message);

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