VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "VB CeFSample"
   ClientHeight    =   5430
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7215
   LinkTopic       =   "Form1"
   ScaleHeight     =   5430
   ScaleWidth      =   7215
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text5 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0;(0)"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   1040
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   4200
      MaxLength       =   5
      TabIndex        =   23
      Text            =   "Text5"
      Top             =   4800
      Width           =   975
   End
   Begin VB.TextBox Text4 
      Height          =   285
      Left            =   1080
      TabIndex        =   21
      Text            =   "Text4"
      Top             =   4800
      Width           =   2535
   End
   Begin VB.OptionButton RadioEth 
      Caption         =   "Ethernet"
      Height          =   255
      Left            =   1440
      TabIndex        =   20
      Top             =   360
      Width           =   1095
   End
   Begin VB.OptionButton RadioSerial 
      Caption         =   "Serial"
      Height          =   255
      Left            =   120
      TabIndex        =   19
      Top             =   360
      Width           =   1095
   End
   Begin VB.ComboBox Combo2 
      Height          =   315
      Left            =   1080
      Style           =   2  'Dropdown List
      TabIndex        =   17
      Top             =   4200
      Width           =   1095
   End
   Begin VB.TextBox Text3 
      Height          =   375
      Left            =   2880
      TabIndex        =   16
      Top             =   2160
      Width           =   4095
   End
   Begin VB.CommandButton Command5 
      Caption         =   "Read DLL Version"
      Height          =   375
      Left            =   120
      TabIndex        =   15
      Top             =   2160
      Width           =   2655
   End
   Begin VB.CheckBox Check7 
      Caption         =   "Buffer Ticket"
      Height          =   375
      Left            =   120
      TabIndex        =   14
      Top             =   3480
      Width           =   2535
   End
   Begin VB.CheckBox Check6 
      Caption         =   "Read Status every Ticket Line"
      Height          =   375
      Left            =   120
      TabIndex        =   13
      Top             =   3120
      Width           =   2535
   End
   Begin VB.CheckBox Check5 
      Caption         =   "DGFE Almost Full"
      Height          =   375
      Left            =   3000
      TabIndex        =   12
      Top             =   4200
      Width           =   3855
   End
   Begin VB.CheckBox Check4 
      Caption         =   "DGFE Full"
      Height          =   375
      Left            =   3000
      TabIndex        =   11
      Top             =   3840
      Width           =   3855
   End
   Begin VB.CheckBox Check3 
      Caption         =   "Near Paper End"
      Height          =   375
      Left            =   3000
      TabIndex        =   10
      Top             =   3480
      Width           =   3855
   End
   Begin VB.CheckBox Check2 
      Caption         =   "Paper End"
      Height          =   375
      Left            =   3000
      TabIndex        =   9
      Top             =   3120
      Width           =   3855
   End
   Begin VB.CheckBox Check1 
      Caption         =   "Cover Open"
      Height          =   375
      Left            =   3000
      TabIndex        =   8
      Top             =   2760
      Width           =   3855
   End
   Begin VB.CommandButton Command4 
      Caption         =   "Printer Status"
      Height          =   375
      Left            =   120
      TabIndex        =   7
      Top             =   2640
      Width           =   2655
   End
   Begin VB.TextBox Text2 
      Height          =   375
      Left            =   2880
      TabIndex        =   6
      Top             =   1680
      Width           =   4095
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Read 1st Line of Header"
      Height          =   375
      Left            =   120
      TabIndex        =   5
      Top             =   1680
      Width           =   2655
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Read Date and Time From Printer"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   1200
      Width           =   2655
   End
   Begin VB.TextBox Text1 
      Height          =   375
      Left            =   2880
      TabIndex        =   2
      Top             =   1200
      Width           =   4095
   End
   Begin VB.ComboBox Combo1 
      Height          =   315
      Left            =   5280
      TabIndex        =   1
      Text            =   "1"
      Top             =   720
      Width           =   975
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Print Ticket"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   720
      Width           =   2655
   End
   Begin VB.Label Label4 
      Caption         =   "Port"
      Height          =   255
      Left            =   3840
      TabIndex        =   24
      Top             =   4800
      Width           =   495
   End
   Begin VB.Label Label3 
      Caption         =   "IP"
      Height          =   255
      Left            =   720
      TabIndex        =   22
      Top             =   4800
      Width           =   255
   End
   Begin VB.Label Label2 
      Caption         =   "Com Port"
      Height          =   255
      Left            =   360
      TabIndex        =   18
      Top             =   4200
      Width           =   735
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "Number of Lines on Ticket"
      Height          =   255
      Left            =   2880
      TabIndex        =   4
      Top             =   720
      Width           =   2295
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
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

Private Sub Command1_Click()
Dim vRet As Long
Dim vRetErr As Long
Dim bRate As Long
Dim bPort As Long
Dim bData As Byte
Dim bParity As Byte
Dim bStop As Byte
Dim bFlow As Byte
Dim s As String
Dim ip As String
Dim sPort As String
Dim bPortIp As Long

ip = Text4.Text
sPort = Text5.Text
bPortIp = Val(sPort)

bRate = 19200
bPort = Int(Combo2.ListIndex) + 1   'Com Port
bData = 7
bParity = 1
bStop = 0
bFlow = 1

' Open Communication
If (RadioSerial.Value = True) Then
    vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)
ElseIf (RadioEth.Value = True) Then
    vRet = VbCEFOpenEth(ip, bPortIp, vRetErr)
End If

' Check Init
If (vRet <> 0) Then
    MsgBox "Error on Init Communication", (vbOKOnly + vbCritical), "Communication Error"
     Exit Sub
End If

vRetA = Int(Combo1.Text)

' Set to Buffer/NotBuffer Mode
If (Check7.Value = 1) Then
    s = "30161"
Else
    s = "30160"
End If
vRet = VbCEFWrite(s, vRetErr)

i = 0
While (i < vRetA)
    
    If (Check6.Value = 1) Then
        CheckStatus
    End If
    ' Write 1 Line on Printer
    If (i >= 9) Then
        s = "3001111articolo " + CStr(i + 1) + "000000100"
    Else
        s = "3001111articolo 0" + CStr(i + 1) + "000000100"
    End If
    
    vRet = VbCEFWrite(s, vRetErr)
    i = i + 1
Wend
' Set the payment of 90.00 Euro
s = "300408CONTANTE000009000"
vRet = VbCEFWrite(s, vRetErr)
' Close Document
s = "3011"
vRet = VbCEFWrite(s, vRetErr)
' Print and Cut
s = "3013"
vRet = VbCEFWrite(s, vRetErr)
' Close Communication on Com Port
vRet = VbCEFClose(vRetErr)

End Sub

Private Sub Command2_Click()

Dim vRet As Long
Dim vRetErr As Long
Dim vRetA As Long
Dim vRetB As Long
Dim bRate As Long
Dim bPort As Long
Dim bData As Byte
Dim bParity As Byte
Dim bStop As Byte
Dim bFlow As Byte
Dim s As String
Dim pBytBuffOut(1000) As Byte
Dim i As Long
Dim ip As String
Dim sPort As String
Dim bPortIp As Long

ip = Text4.Text
sPort = Text5.Text
bPortIp = Val(sPort)

bRate = 19200
bPort = Int(Combo2.ListIndex) + 1   'Com Port
bData = 7
bParity = 1
bStop = 0
bFlow = 1

' Open Communication
If (RadioSerial.Value = True) Then
    vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)
ElseIf (RadioEth.Value = True) Then
    vRet = VbCEFOpenEth(ip, bPortIp, vRetErr)
End If

' Check Init
If (vRet <> 0) Then
    MsgBox "Error on Init Communication", (vbOKOnly + vbCritical), "Communication Error"
     Exit Sub
End If

' Get DATE
s = "1001"
vRet = VbCEFWrite(s, vRetErr)
vRet = VbCEFRead(pBytBuffOut(), vRetA, vRetErr)
' Close Communication on Com Port
vRet = VbCEFClose(vRetErr)

i = 1
Text1.Text = "Data:"

Text1.Text = Text1.Text + String(1, pBytBuffOut(1)) + String(1, pBytBuffOut(2)) + "/"
Text1.Text = Text1.Text + String(1, pBytBuffOut(3)) + String(1, pBytBuffOut(4)) + "/"
Text1.Text = Text1.Text + String(1, pBytBuffOut(5)) + String(1, pBytBuffOut(6)) + "  Ore:"
Text1.Text = Text1.Text + String(1, pBytBuffOut(7)) + String(1, pBytBuffOut(8)) + ":"
Text1.Text = Text1.Text + String(1, pBytBuffOut(9)) + String(1, pBytBuffOut(10))

End Sub

Private Sub Command3_Click()

Dim vRet As Long
Dim vRetErr As Long
Dim vRetA As Long
Dim vRetB As Long
Dim bRate As Long
Dim bPort As Long
Dim bData As Byte
Dim bParity As Byte
Dim bStop As Byte
Dim bFlow As Byte
Dim s As String
Dim strOut As String
Dim pBytBuffOut(1000) As Byte
Dim i As Long
Dim ip As String
Dim sPort As String
Dim bPortIp As Long

ip = Text4.Text
sPort = Text5.Text
bPortIp = Val(sPort)

bRate = 19200
bPort = Int(Combo2.ListIndex) + 1   'Com Port
bData = 7
bParity = 1
bStop = 0
bFlow = 1

' Open Communication
If (RadioSerial.Value = True) Then
    vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)
ElseIf (RadioEth.Value = True) Then
    vRet = VbCEFOpenEth(ip, bPortIp, vRetErr)
End If

' Check Init
If (vRet <> 0) Then
    MsgBox "Error on Init Communication", (vbOKOnly + vbCritical), "Communication Error"
     Exit Sub
End If

' Read the HEAD line
s = "10021"
vRet = VbCEFWrite(s, vRetErr)
vRet = VbCEFRead(pBytBuffOut(), vRetA, vRetErr)
' Close Communication on Com Port
vRet = VbCEFClose(vRetErr)

i = 1
strOut = ""
While (i <= vRetA)
    strOut = strOut + String(1, pBytBuffOut(i))
    i = i + 1
Wend
Text2.Text = strOut

End Sub

Private Sub Command4_Click()

Dim vRet As Long
Dim vRetErr As Long
Dim vRetA As Long
Dim vRetB As Long
Dim bRate As Long
Dim bPort As Long
Dim bData As Byte
Dim bParity As Byte
Dim bStop As Byte
Dim bFlow As Byte
Dim s As String
Dim strOut As String
Dim pBytBuffOut(1000) As Byte
Dim i As Long
Dim ip As String
Dim sPort As String
Dim bPortIp As Long

ip = Text4.Text
sPort = Text5.Text
bPortIp = Val(sPort)

bRate = 19200
bPort = Int(Combo2.ListIndex) + 1   'Com Port
bData = 7
bParity = 1
bStop = 0
bFlow = 1

Check1.Enabled = False
Check2.Enabled = False
Check3.Enabled = False
Check4.Enabled = False
Check5.Enabled = False


' Open Communication
If (RadioSerial.Value = True) Then
    vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)
ElseIf (RadioEth.Value = True) Then
    vRet = VbCEFOpenEth(ip, bPortIp, vRetErr)
End If

' Check Init
If (vRet <> 0) Then
    MsgBox "Error on Init Communication", (vbOKOnly + vbCritical), "Communication Error"
     Exit Sub
End If

CheckStatus

' Close Communication on Com Port
vRet = VbCEFClose(vRetErr)

End Sub

Sub CheckStatus()

Dim vRet As Long
Dim vRetErr As Long
Dim vRetA As Long
Dim vRetB As Long
Dim s As String
Dim strOut As String
Dim pBytBuffOut(1000) As Byte
Dim i As Long
Dim err As Long
Dim ip As String
Dim sPort As String
Dim bPortIp As Long

ip = Text4.Text
sPort = Text5.Text
bPortIp = Val(sPort)

' Get printer Status
s = "1109"
vRet = VbCEFWrite(s, vRetErr)
vRet = VbCEFRead(pBytBuffOut(), vRetA, vRetErr)

err = 0
If (vRet <> 0) Then
    err = err + 1
End If

Check1.Enabled = True
Check2.Enabled = True
Check3.Enabled = True
Check4.Enabled = True
Check5.Enabled = True

'Cover Open
If (pBytBuffOut(1) = 49) Then
    Check1.Value = 1
Else
    Check1.Value = 0
End If

'End Paper
If (pBytBuffOut(2) = 49) Then
    Check2.Value = 1
Else
    Check2.Value = 0
End If

'Near Paper End
If (pBytBuffOut(3) = 49) Then
    Check3.Value = 1
Else
    Check3.Value = 0
End If

'DGFE full
If (pBytBuffOut(4) = 49) Then
    Check4.Value = 1
Else
    Check4.Value = 0
End If

'DGFE Almost full
If (pBytBuffOut(5) = 49) Then
    Check5.Value = 1
Else
    Check5.Value = 0
End If


End Sub

Private Sub Command5_Click()
Dim vRet As Long
Dim vRetErr As Long
Dim vRetA As Long
Dim vRetB As Long
Dim bRate As Long
Dim bPort As Long
Dim bData As Byte
Dim bParity As Byte
Dim bStop As Byte
Dim bFlow As Byte
Dim s As String
Dim strOut As String
Dim pBytBuffOut(1000) As Byte
Dim i As Long

bRate = 19200
bPort = Int(Combo2.ListIndex) + 1   'Com Port
bData = 7
bParity = 1
bStop = 0
bFlow = 1

' Get DLL Version
vRet = VbCEFGetVersion(pBytBuffOut(), vRetErr)

i = 1
strOut = ""
While (i < 20)
    strOut = strOut + String(1, pBytBuffOut(i))
    i = i + 1
Wend
Text3.Text = strOut

End Sub

Private Sub Form_Load()

Dim i As Long
Dim s As String

RadioSerial.Value = True

Text5.Text = 9100
Text4.Text = "192.168.1.199"

i = 0
Combo1.Clear
While (i < 50)
    Combo1.AddItem ((i + 1))
    i = i + 1
Wend
Combo1.Text = "5"

i = 0
Combo2.Clear
While (i < 5)
    s = "COM " + CStr(i + 1)
    Combo2.AddItem (s)
    i = i + 1
Wend
Combo2.Text = "COM 1"


End Sub

