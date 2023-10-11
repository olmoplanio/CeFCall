using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class CallResult: Exception
    {
        public int ErrorCode { get { return HResult; } }

        public CallResult(int errorCode, string message):base(message)
        {
            HResult = errorCode;
        }

        public string[] ToArray()
        {
            return new string[]
            {
                HResult.ToString(),
                Message
            };
        }
    }
}
