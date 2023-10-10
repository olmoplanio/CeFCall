using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestEnvironment
    {
        [TestMethod]
        public void CheckAssertTrue()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void CheckAssertNotEqual()
        {
            Assert.AreEqual(1, 0);
        }
    }
}