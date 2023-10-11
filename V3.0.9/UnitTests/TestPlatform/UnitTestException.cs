using System;
using System.Runtime.Serialization;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    internal class UnitTestAssertException : Exception
    {
        public UnitTestAssertException()
        {
        }

        public UnitTestAssertException(string message) : base(message)
        {
        }

        public UnitTestAssertException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnitTestAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}