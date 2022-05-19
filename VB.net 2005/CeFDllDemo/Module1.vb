''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' This document contains programming examples.                                     '
'                                                                                  '
' Custom Engineering grants you a nonexclusive copyright license to use            '
' all programming code examples from which you can generate similar                '
' function tailored to your own specific needs.                                    '
'                                                                                  '
' All sample code is provided by Custom Engineering for illustrative purposes      '
' only. These examples have not been thoroughly tested under all conditions.       '
' Custom Engineering, therefore, cannot guarantee or imply reliability,            '
' serviceability, or function of these programs.                                   '
'                                                                                  '
' In no event shall Custom Engineering be liable for any direct, indirect,         '
' incidental, special, exemplary, or consequential damages (including, but not     '
' limited to, procurement of substitute goods or services; loss of use, data,      '
' or profits; or business interruption) however caused and on any theory of        '
' liability, whether in contract, strict liability, or tort (including negligence  '
' or otherwise) arising in any way out of the use of this software, even if        '
' advised of the possibility of such damage.                                       '
'                                                                                  '
' All programs contained herein are provided to you "as is" without any            '
' warranties of any kind.                                                          '
' The implied warranties of non-infringement, merchantability and fitness for a    '
' particular purpose are expressly disclaimed.                                     '
'                                                                                  '
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Option Strict Off
Option Explicit On
Module Module1

    ' Declare Function for Open Communication Port
    Public Declare Function VbCEFOpen Lib "CeFdll.dll" (ByVal intCom As Integer, ByVal dwBaudRate As Integer, ByVal byParity As Byte, ByVal byDataBit As Byte, ByVal byStopBit As Byte, ByVal byFlowControl As Byte, ByRef lpdwSysError As Integer) As Integer
    ' Declare Function for Write Command on Communication Port
    Public Declare Function VbCEFWrite Lib "CeFdll.dll" (ByRef textcmd As String, ByRef lpdwSysError As Integer) As Integer
    ' Declare Function for Read from Communication Port
    Public Declare Function VbCEFRead Lib "CeFdll.dll" (<MarshalAs(UnmanagedType.SafeArray)> ByRef RetData() As Byte, ByRef pdwByteRead As Integer, ByRef lpdwSysError As Integer) As Integer
    ' Declare Function for Read DLL Version
    Public Declare Function VbCEFGetVersion Lib "CeFdll.dll" (<MarshalAs(UnmanagedType.SafeArray)> ByRef RetData() As Byte, ByRef lpdwSysError As Integer) As Integer
    ' Declare Function for Close Communication Port
    Public Declare Function VbCEFClose Lib "CeFdll.dll" (ByRef lpdwSysError As Integer) As Integer
End Module