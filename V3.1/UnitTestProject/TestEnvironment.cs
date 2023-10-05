using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestEnvironment
    {
        [TestMethod]
        public void CheckAssert()
        {
            Assert.IsTrue(true);
        }
    }
}