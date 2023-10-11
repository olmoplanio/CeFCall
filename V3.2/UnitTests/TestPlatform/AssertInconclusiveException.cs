using System;
using System.Runtime.Serialization;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    [Serializable]
    internal class AssertInconclusiveException : UnitTestAssertException
    {
        public AssertInconclusiveException()
        {
        }

        public AssertInconclusiveException(string message) : base(message)
        {
        }

        public AssertInconclusiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}