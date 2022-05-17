using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

namespace CeFDllDemo
{
    /*
     * This document contains programming examples.
     * 
     * Custom Engineering grants you a nonexclusive copyright license to use all programming code examples from which you can generate similar function tailored to your own specific needs.
     * 
     * All sample code is provided by Custom Engineering for illustrative purposes only. These examples have not been thoroughly tested under all conditions. 
     * Custom Engineering, therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
     * 
     * In no event shall Custom Engineering be liable for any direct, indirect, incidental, special, exemplary, or consequential damages (including, but not limited to, procurement of substitute goods or services; loss of use, data, or profits; or business interruption) however caused and on any theory of liability, whether in contract, strict liability, or tort 
     * (including negligence or otherwise) arising in any way out of the use of this software, even if advised of the possibility of such damage.
     * 
     * All programs contained herein are provided to you "as is" without any warranties of any kind.
     * The implied warranties of non-infringement, merchantability and fitness for a particular purpose are expressly disclaimed.
     *  
     */



    internal static class IntercomModule
	{
        /*
         * // Visual C++
            AFX_EXT_CLASS DWORD CEFWrite(unsigned char*, LPDWORD);
            AFX_EXT_CLASS DWORD CEFClose(LPDWORD);
            AFX_EXT_CLASS DWORD CEFRead(unsigned char *, LPDWORD, LPDWORD);
            AFX_EXT_CLASS DWORD CEFOpen(int, DWORD, BYTE, BYTE, BYTE, BYTE, LPDWORD);
            AFX_EXT_CLASS DWORD CEFGetVersion(LPTSTR, LPDWORD );
            AFX_EXT_CLASS DWORD CEFOpenEth(LPTSTR,DWORD,LPDWORD);
            AFX_EXT_CLASS DWORD CEFOpenEth(LPTSTR,DWORD,LPDWORD);
            AFX_EXT_CLASS DWORD CEFOpenEthUnSafe(LPTSTR,DWORD,LPDWORD);
         *
         */


        // Declare Function for Open Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFOpen", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		public static extern int CEFOpen(int intCom, uint dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError);
		// Declare Function for Write Command on Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFWrite", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		public static extern int CEFWrite(string textcmd, ref int lpdwSysError);
		// Declare Function for Read from Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFRead", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int CEFRead(StringBuilder retData, ref int pdwByteRead, ref int lpdwSysError);
		// Declare Function for Read DLL Version
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFGetVersion", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int CEFGetVersion([MarshalAs(UnmanagedType.LPStr)] StringBuilder retData, ref int lpdwSysError);
		// Declare Function for Close Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFClose", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		public static extern int CEFClose(ref int lpdwSysError);
        // Declare Function for Open Communication on Ethernet Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFOpenEth", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int CEFOpenEth(string strIp, int dwPort, ref int lpdwSysError);
        // Declare Function for Unsafe Open Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFOpenUnSafe", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int CEFUnsafeOpen(int intCom, uint dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError);
        // Declare Function for Unsafe Open Communication on Ethernet Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "CEFOpenEthUnSafe", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int CEFUnsafeOpenEth(string strIp, int dwPort, ref int lpdwSysError);



        /*
         * // Visual Basic
            AFX_EXT_CLASS DWORD __stdcall VbCEFClose(LPDWORD);
            AFX_EXT_CLASS DWORD __stdcall VbCEFWrite(DWORD*, LPDWORD);
            AFX_EXT_CLASS DWORD __stdcall VbCEFRead(SAFEARRAY** , LPDWORD, LPDWORD);
            AFX_EXT_CLASS DWORD __stdcall VbCEFOpen(DWORD, DWORD, BYTE, BYTE, BYTE, BYTE, LPDWORD);
            AFX_EXT_CLASS DWORD __stdcall VbCEFGetVersion(SAFEARRAY** , LPDWORD);
        *
        */

        // Declare Function for Open Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "VbCEFOpen", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int VbCEFOpen(int intCom, int dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError);
        // Declare Function for Write Command on Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "VbCEFWrite", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int VbCEFWrite(ref string textcmd, ref int lpdwSysError);
        // Declare Function for Read from Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "VbCEFRead", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int VbCEFRead([MarshalAs(UnmanagedType.SafeArray)] ref byte[] RetData, ref int pdwByteRead, ref int lpdwSysError);
        // Declare Function for Read DLL Version
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "VbCEFGetVersion", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int VbCEFGetVersion([MarshalAs(UnmanagedType.SafeArray)] ref byte[] RetData, ref int lpdwSysError);
        // Declare Function for Close Communication Port
        [System.Runtime.InteropServices.DllImport("CeFdll.dll", EntryPoint = "VbCEFClose", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int VbCEFClose(ref int lpdwSysError);


    }
}