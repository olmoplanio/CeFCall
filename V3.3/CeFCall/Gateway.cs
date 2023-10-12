using System.Text;

namespace com.github.olmoplanio.CeFCall
{
    public class Gateway
    {
        
        public CallResult OpenEth(string ip, int port)
        {
            int vRetErr = int.MinValue;
            int vRet = IntercomModule.CEFOpenEth(ip, port, ref vRetErr);
            return new CallResult(vRet, vRet.ToString());
        }


        public CallResult Exec(string ip, int port, string[] commands)
        {
            int vRetErr = 0;
            int vRet;
            vRet = IntercomModule.CEFOpenEth(ip, port, ref vRetErr);
            if(vRet > 0) return new CallResult(vRet, "openeth: " + vRetErr.ToString());
            foreach(var command in commands)
            {
                vRet = IntercomModule.CEFWrite(command, ref vRetErr);
                if (vRet > 0) return new CallResult(vRet, command + ": "+ vRetErr.ToString() );
            }
            int _ = 0;
            StringBuilder strOut = new StringBuilder(1024);
            vRet = IntercomModule.CEFRead(strOut, ref _, ref vRetErr);
            if (vRet > 0) return new CallResult(vRet, "read: " + vRetErr.ToString() );
            vRet = IntercomModule.CEFClose(ref vRetErr);
            if (vRet > 0) return new CallResult(vRet, "close: " + vRetErr.ToString() );
            return new CallResult (vRet, strOut.ToString());
        }
        

        public CallResult Send(string command)
        {
            int vRetErr = int.MinValue;
            int vRet = IntercomModule.CEFWrite(command, ref vRetErr);
            return new CallResult(  vRet, vRet.ToString() );
        }

        public CallResult Read()
        {
            int vRetErr = int.MinValue;
            int _ = 0;
            StringBuilder strOut = new StringBuilder(1024);
            int vRet = IntercomModule.CEFRead(strOut, ref _, ref vRetErr);
            return new CallResult( vRet, strOut.ToString() );
        }

        public string GetVersion()
        {
            int vRetErr = int.MinValue;
            StringBuilder strOut = new StringBuilder(256);
            int vRet = IntercomModule.CEFGetVersion(strOut, ref vRetErr);
            return strOut.ToString();
        }

        public CallResult Close()
        {
            int vRetErr = int.MinValue;
            int vRet = IntercomModule.CEFClose(ref vRetErr);
            return new CallResult( vRetErr, vRet.ToString() );
        }
    }
}
