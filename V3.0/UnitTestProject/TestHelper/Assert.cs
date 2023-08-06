using System;
using System.Diagnostics;

namespace UnitTests
{
    internal class Assert
    {
        public static void AreEqual(string v1, string v2)
        {
            Debug.Assert(v1 == v2);
        }
    }
}