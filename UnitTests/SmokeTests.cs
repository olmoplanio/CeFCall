using com.github.olmoplanio.CeFCall;
using com.github.olmoplanio.CeFCall.SFCEmulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class SmokeTests
    {
        private const string EOT = "\u0004";

        private static Server server = new Server();
        private static SFCClient client = new SFCClient();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Task.Run( () => server.Listen(9100) );
            Thread.Sleep(5000);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            client.Send("127.0.0.1", 9100, EOT);
        }

        [TestMethod]
        public void HelloWorld()
        {
            string msg = "Hello world.";
            client.Send("127.0.0.1", 9100, msg);
            Assert.AreEqual(msg, server.LastMessage);
        }
    }
}