using System;
using System.Collections.Generic;
using System.Text;

namespace CeFDllDemo
{
    public class CeFException: Exception
    {
        public CeFException(int code): base("Errror "+code)
        {
            base.HResult = code;
        }
}
    public class CeF
    {

        private const byte bData = 7;
        private const byte bParity = 1;
        private const byte bFlow = 1;
        private const byte bStop = 0;
        private const uint bRate = 19200;
        
        public CeF()
        {
        }

        public void OpenEth(string ip, int port)
        {
            int vRetErr = int.MinValue;
            IntercomModule.CEFOpenEth(ip, port, ref vRetErr);
            if (vRetErr > int.MinValue)
            {
                throw new CeFException(vRetErr);
            }
        }

        public void Send(string command)
        {
            int vRetErr = int.MinValue;
            IntercomModule.CEFWrite(command, ref vRetErr);
            if (vRetErr > int.MinValue)
            {
                throw new CeFException(vRetErr);
            }
        }

        public string ReadString()
        {
            int vRetErr = int.MinValue;
            int _ = 0;
            StringBuilder strOut = new StringBuilder(null);
            IntercomModule.CEFRead(strOut, ref _, ref vRetErr);
            if (vRetErr > int.MinValue)
            {
                throw new CeFException(vRetErr);
            }
            else
            {
                return strOut.ToString();
            }
        }

        public string GetVersion()
        {
            int vRetErr = int.MinValue;
            StringBuilder strOut = new StringBuilder(null);
            IntercomModule.CEFGetVersion(strOut, ref vRetErr);
            if (vRetErr > int.MinValue)
            {
                throw new CeFException(vRetErr);
            }
            else
            {
                return strOut.ToString();
            }
        }

        public void Close()
        {
            int vRetErr = int.MinValue;
            IntercomModule.CEFClose(ref vRetErr);
            if (vRetErr > int.MinValue)
            {
                throw new CeFException(vRetErr);
            }
        }
    }
}
