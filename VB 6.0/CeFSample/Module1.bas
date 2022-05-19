Attribute VB_Name = "Module1"

' Declare Function for Open Communication Serial
Declare Function VbCEFOpen Lib "CeFdll.dll" (ByVal intCom As Long, ByVal dwBaudRate As Long, ByVal byParity As Byte, ByVal byDataBit As Byte, ByVal byStopBit As Byte, ByVal byFlowControl As Byte, lpdwSysError As Long) As Long
' Declare Function for Open Communication Ethernet
Declare Function VbCEFOpenEth Lib "CeFdll.dll" (textip As String, ByVal dwPort As Long, lpdwSysError As Long) As Long
' Declare Function for Write Command on Communication Port
Declare Function VbCEFWrite Lib "CeFdll.dll" (textcmd As String, lpdwSysError As Long) As Long
' Declare Function for Read from Communication Port
Declare Function VbCEFRead Lib "CeFdll.dll" (RetData() As Byte, pdwByteRead As Long, lpdwSysError As Long) As Long
' Declare Function for Read DLL Version
Declare Function VbCEFGetVersion Lib "CeFdll.dll" (RetData() As Byte, lpdwSysError As Long) As Long
' Declare Function for Close Communication Port
Declare Function VbCEFClose Lib "CeFdll.dll" (lpdwSysError As Long) As Long
