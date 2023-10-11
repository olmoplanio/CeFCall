using System;
using System.Runtime.Serialization;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    [Serializable]
    internal class AssertFailedException : UnitTestAssertException
    {
        public AssertFailedException()
        {
        }

        public AssertFailedException(string message) : base(message)
        {
        }

        public AssertFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}