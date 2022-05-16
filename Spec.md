Ciao Paolo!
come stai?

devo comunicare con protocollo customDll (o custom ma SEMBRA che sia meglio customDLL) da access ad una stampante fiscale
X-KUBE F ETH/KUBE II F ETH

ho scopiazzato da qua
https://www.infolabsrl.it/news/collegamento-ai-registratori-cassa-custom/
dove trovi  il link per la dll. (ocio che sono DUE dll come descritto qua https://www.baccan.it/n445190-quando-il-reverse-engineering-e-l-unica-soluzione.htm
)
link dll 
http://www.infolabsrl.it/download/CeFdllInstallation_140.exe

io in access riesco a definirle cosi'

Option Compare Database

nota che ho provato a metterle ovunque, repetitia dementia est .....
'C:\Program Files\Custom Engineering\CeFdll\CeFdll x64\CeFdll.dll
'C:\Program Files (x86)\Custom\CeFdll\CeFdll x64\CeFdll.dll
'C:\Windows\SysWOW64\CeFdll.dll
'C:\centrosurf\CeFdll.dll

Private Declare PtrSafe Function VbCEFOpen Lib "CeFdll.dll" (ByVal intCom As Long, ByVal dwBaudRate As Long, ByVal byParity As Byte, ByVal byDataBit As Byte, ByVal byStopBit As Byte, ByVal byFlowControl As Byte, lpdwSysError As Long) As Long
' Declare Function for Open Communication Ethernet
Private Declare PtrSafe Function VbCEFOpenEth Lib "CeFdll.dll" (textip As String, ByVal dwPort As Long, lpdwSysError As Long) As Long
' Declare Function for Write Command on Communication Port
Private Declare PtrSafe Function VbCEFWrite Lib "CeFdll.dll" (textcmd As String, lpdwSysError As Long) As Long
' Declare Function for Read from Communication Port
Private Declare PtrSafe Function VbCEFRead Lib "CeFdll.dll" (RetData() As Byte, pdwByteRead As Long, lpdwSysError As Long) As Long
' Declare Function for Read DLL Version
Private Declare PtrSafe Function VbCEFGetVersion Lib "C:\centrosurf\CeFdll.dll" (RetData() As Byte, lpdwSysError As Long) As Long
' Declare Function for Close Communication Port
Private Declare PtrSafe Function VbCEFClose Lib "CeFdll.dll" (lpdwSysError As Long) As Long

comunque ti allego il file access e il file della dll (installa un minimo di documentazione e degli esempi che funzionano, intrerrogano la stampante regolarmente)

your mission is to deply a dll, com ocx or whatever that works in access.
se incapsuli ed esponi le 5  funzioni (la VbCEFOpen non serve, usiamo rete non seriale) sarebbe il top
