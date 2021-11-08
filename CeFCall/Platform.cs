using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CeFCall
{
    public class Platform
    {

        public int CEFOpen(int intCom, uint dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError)
        {
            return IntercomModule.CEFOpen(intCom, dwBaudRate, byParity, byDataBit, byStopBit, byFlowControl, ref lpdwSysError);
        }

        public int CEFWrite(string textcmd, ref int lpdwSysError)
        {
            return IntercomModule.CEFWrite(textcmd, ref lpdwSysError);
        }

        public int CEFRead(StringBuilder retData, ref int pdwByteRead, ref int lpdwSysError)
        {
            return IntercomModule.CEFRead(retData, ref pdwByteRead, ref lpdwSysError);
        }

        public int CEFGetVersion(StringBuilder retData, ref int lpdwSysError)
        {
            return IntercomModule.CEFGetVersion(retData, ref lpdwSysError);
        }

        public int CEFClose(ref int lpdwSysError)
        {
            return IntercomModule.CEFClose(ref lpdwSysError);
        }

        public int CEFOpenEth(string strIp, int dwPort, ref int lpdwSysError)
        {
            return IntercomModule.CEFOpenEth(strIp, dwPort, ref lpdwSysError);
        }

        public int CEFUnsafeOpen(int intCom, uint dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError)
        {
            return IntercomModule.CEFUnsafeOpen(intCom, dwBaudRate, byParity, byDataBit, byStopBit, byFlowControl, ref lpdwSysError);
        }

        public int CEFUnsafeOpenEth(string strIp, int dwPort, ref int lpdwSysError)
        {
            return IntercomModule.CEFUnsafeOpenEth(strIp, dwPort, ref lpdwSysError);
        }

        public int VbCEFOpen(int intCom, int dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError)
        {
            return IntercomModule.VbCEFOpen(intCom, dwBaudRate, byParity, byDataBit, byStopBit, byFlowControl, ref lpdwSysError);
        }

        public int VbCEFWrite(ref string textcmd, ref int lpdwSysError)
        {
            return IntercomModule.VbCEFWrite(ref textcmd, ref lpdwSysError);
        }

        public int VbCEFRead(ref byte[] RetData, ref int pdwByteRead, ref int lpdwSysError)
        {
            return IntercomModule.VbCEFRead(ref RetData, ref pdwByteRead, ref lpdwSysError);
        }

        public int VbCEFGetVersion(ref byte[] RetData, ref int lpdwSysError)
        {
            return IntercomModule.VbCEFGetVersion(ref RetData, ref lpdwSysError);
        }

        public int VbCEFClose(ref int lpdwSysError)
        {
            return IntercomModule.VbCEFClose(ref lpdwSysError);
        }
    }
}
