using com.github.olmoplanio.CeFCall;
using com.github.olmoplanio.CeFCall.CeFEmulator;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class NoRegression
    {
        private static Gateway client = new Gateway();

        [TestMethod]
        public void CheckVersion()
        {
            string[] version = client.GetVersion();
            Assert.AreEqual("1, 4, 0, 0", version[1]);
        }
    }
}