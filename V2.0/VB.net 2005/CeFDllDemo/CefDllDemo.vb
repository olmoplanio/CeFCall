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
Friend Class Form1
	Inherits System.Windows.Forms.Form
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim i As Object
        Dim vRetA As Object
        Dim vRet As Integer
        Dim vRetErr As Integer
        Dim bRate As Integer
        Dim bPort As Integer
        Dim bData As Byte
        Dim bParity As Byte
        Dim bStop As Byte
        Dim bFlow As Byte
        Dim s As String

        bRate = 19200
        bPort = Int(Combo2.SelectedIndex) + 1 'Com Port
        bData = 7
        bParity = 1
        bStop = 0
        bFlow = 1

        ' Open Communication on Com Port
        vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)
        ' Check Init
        If (vRet <> 0) Then
            MsgBox("Error on Init Communication", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "Communication Error")
            Exit Sub
        End If

        vRetA = Int(CDbl(Combo1.Text))

        ' Set to Buffer/NotBuffer Mode
        If (Check7.CheckState = 1) Then
            s = "30161"
        Else
            s = "30160"
        End If
        vRet = VbCEFWrite(s, vRetErr)

        i = 0

        While (i < vRetA)

            If (Check6.CheckState = 1) Then
                CheckStatus()
            End If
            ' Write 1 Line on Printer
            If (i >= 9) Then
                s = "3001111articolo " & CStr(i + 1) & "000000100"
            Else
                s = "3001111articolo 0" & CStr(i + 1) & "000000100"
            End If
            vRet = VbCEFWrite(s, vRetErr)
            i = i + 1
        End While
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

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
  
        Dim vRet As Integer
        Dim vRetErr As Integer
        Dim vRetA As Integer
        Dim bRate As Integer
        Dim bPort As Integer
        Dim bData As Byte
        Dim bParity As Byte
        Dim bStop As Byte
        Dim bFlow As Byte
        Dim s As String
        Dim pBytBuffOut(1000) As Byte
        Dim i As Integer

        bRate = 19200
        bPort = Int(Combo2.SelectedIndex) + 1 'Com Port
        bData = 7
        bParity = 1
        bStop = 0
        bFlow = 1

        ' Open Communication on Com Port
        vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)

        ' Check Init
        If (vRet <> 0) Then
            MsgBox("Error on Init Communication", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "Communication Error")
            Exit Sub
        End If

        ' Get DATE
        s = "1001"
        vRet = VbCEFWrite(s, vRetErr)
        vRet = VbCEFRead(pBytBuffOut, vRetA, vRetErr)
        ' Close Communication on Com Port
        vRet = VbCEFClose(vRetErr)

        i = 1
        Text1.Text = "Data:"

        Text1.Text = Text1.Text & New String(Chr(pBytBuffOut(1)), 1) & New String(Chr(pBytBuffOut(2)), 1) & "/"
        Text1.Text = Text1.Text & New String(Chr(pBytBuffOut(3)), 1) & New String(Chr(pBytBuffOut(4)), 1) & "/"
        Text1.Text = Text1.Text & New String(Chr(pBytBuffOut(5)), 1) & New String(Chr(pBytBuffOut(6)), 1) & "  Ore:"
        Text1.Text = Text1.Text & New String(Chr(pBytBuffOut(7)), 1) & New String(Chr(pBytBuffOut(8)), 1) & ":"
        Text1.Text = Text1.Text & New String(Chr(pBytBuffOut(9)), 1) & New String(Chr(pBytBuffOut(10)), 1)

    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click

        Dim vRet As Integer
        Dim vRetErr As Integer
        Dim vRetA As Integer
        Dim bRate As Integer
        Dim bPort As Integer
        Dim bData As Byte
        Dim bParity As Byte
        Dim bStop As Byte
        Dim bFlow As Byte
        Dim s As String
        Dim strOut As String
        Dim pBytBuffOut(1000) As Byte
        Dim i As Integer

        bRate = 19200
        bPort = Int(Combo2.SelectedIndex) + 1 'Com Port
        bData = 7
        bParity = 1
        bStop = 0
        bFlow = 1

        ' Open Communication on Com Port
        vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)

        ' Check Init
        If (vRet <> 0) Then
            MsgBox("Error on Init Communication", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "Communication Error")
            Exit Sub
        End If

        ' Read the HEAD line
        s = "10021"
        vRet = VbCEFWrite(s, vRetErr)
        vRet = VbCEFRead(pBytBuffOut, vRetA, vRetErr)
        ' Close Communication on Com Port
        vRet = VbCEFClose(vRetErr)

        i = 1
        strOut = ""
        While (i <= vRetA)
            strOut = strOut & New String(Chr(pBytBuffOut(i)), 1)
            i = i + 1
        End While
        Text2.Text = strOut

    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        Dim vRet As Integer
        Dim vRetErr As Integer
        Dim bRate As Integer
        Dim bPort As Integer
        Dim bData As Byte
        Dim bParity As Byte
        Dim bStop As Byte
        Dim bFlow As Byte
        Dim pBytBuffOut(1000) As Byte

        bRate = 19200
        bPort = Int(Combo2.SelectedIndex) + 1 'Com Port
        bData = 7
        bParity = 1
        bStop = 0
        bFlow = 1

        Check1.Enabled = False
        Check2.Enabled = False
        Check3.Enabled = False
        Check4.Enabled = False
        Check5.Enabled = False

        ' Open Communication on Com Port
        vRet = VbCEFOpen(bPort, bRate, bParity, bData, bStop, bFlow, vRetErr)
        ' Check Init
        If (vRet <> 0) Then
            MsgBox("Error on Init Communication", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Communication Error")
            Exit Sub
        End If

        CheckStatus()
        ' Close Communication on Com Port
        vRet = VbCEFClose(vRetErr)

    End Sub

    Sub CheckStatus()

        Dim vRet As Integer
        Dim vRetErr As Integer
        Dim vRetA As Integer
        Dim s As String
        Dim pBytBuffOut(1000) As Byte
        Dim err_Renamed As Integer
        ' Get printer Status
        s = "1109"
        vRet = VbCEFWrite(s, vRetErr)
        vRet = VbCEFRead(pBytBuffOut, vRetA, vRetErr)

        err_Renamed = 0
        If (vRet <> 0) Then
            err_Renamed = err_Renamed + 1
        End If

        Check1.Enabled = True
        Check2.Enabled = True
        Check3.Enabled = True
        Check4.Enabled = True
        Check5.Enabled = True

        'Cover Open
        If (pBytBuffOut(1) = 49) Then
            Check1.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        'End Paper
        If (pBytBuffOut(2) = 49) Then
            Check2.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            Check2.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        'Near Paper End
        If (pBytBuffOut(3) = 49) Then
            Check3.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            Check3.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        'DGFE full
        If (pBytBuffOut(4) = 49) Then
            Check4.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            Check4.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        'DGFE Almost full
        If (pBytBuffOut(5) = 49) Then
            Check5.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            Check5.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If


    End Sub

    Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
        Dim vRet As Integer
        Dim vRetErr As Integer
        Dim bRate As Integer
        Dim bPort As Integer
        Dim bData As Byte
        Dim bParity As Byte
        Dim bStop As Byte
        Dim bFlow As Byte
        Dim strOut As String
        Dim pBytBuffOut(1000) As Byte
        Dim i As Integer

        bRate = 19200
        bPort = Int(Combo2.SelectedIndex) + 1 'Com Port
        bData = 7
        bParity = 1
        bStop = 0
        bFlow = 1

        ' Get DLL Version
        vRet = VbCEFGetVersion(pBytBuffOut, vRetErr)

        i = 1
        strOut = ""
        While (i < 20)
            strOut = strOut & New String(Chr(pBytBuffOut(i)), 1)
            i = i + 1
        End While
        Text3.Text = strOut

    End Sub
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Dim i As Integer
		Dim s As String
		
		i = 0
		Combo1.Items.Clear()
		While (i < 50)
			Combo1.Items.Add(CStr(i + 1))
			i = i + 1
		End While
		Combo1.Text = "5"
		
		i = 0
		Combo2.Items.Clear()
		While (i < 5)
			s = "COM " & CStr(i + 1)
			Combo2.Items.Add((s))
			i = i + 1
		End While
		Combo2.Text = "COM 1"

	End Sub
End Class