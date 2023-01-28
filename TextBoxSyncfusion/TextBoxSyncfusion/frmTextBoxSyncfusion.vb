#Region "About"
' / --------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gsoft.com/
' /
' / Purpose: TextBox Control Extend from Syncfusion Community License Free.
' / Microsoft Visual Basic .NET (2010)
' /
' / This is open source code under @CopyLeft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------------
#End Region

Public Class frmTextBoxSyncfusion

    Private Sub frmTextBoxSyncfusion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '// ตัวอย่างการกำหนดคุณสมบัติให้กับ Control ของ Syncfusion
        '// สามารถกำหนดในแบบ Design Time เลยจะง่ายกว่า
        With DoubleTextBox1
            '// จะต้องกำหนดให้เป็น FixedSingle ถึงจะทำมุม (CornerRadius) ได้
            .BorderStyle = BorderStyle.FixedSingle
            .CornerRadius = 0
            '// ใช้ DoubleTextBox เพื่อรับค่าเลขจำนวนเต็ม
            .NumberDecimalDigits = 0
            '// ให้แสดงเครื่องหมาย - นำหน้าเลขลบ (ค่าเริ่มต้นเป็น 0 ทำให้แสดงเครื่องหมายวงเล็บ)
            .NumberNegativePattern = 1
            .TextAlign = HorizontalAlignment.Right  '// จัดชิดขวา
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007 '// Theme
            .PositiveColor = Color.Blue '// สีเลขบวก
            .ZeroColor = Color.Red      '// สีเลขศูนย์
        End With
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / เหตุการณ์กด KeyPress เพื่อดักคีย์ Enter
    ' / --------------------------------------------------------------------------------
    Private Sub DoubleTextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DoubleTextBox1.KeyPress
        '// เมื่อกด Enter ให้โฟกัสไปยัง Control ตัวถัดไป
        If Asc(e.KeyChar) = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub


    ' / --------------------------------------------------------------------------------
    ' / ฟังค์ชั่นที่ใช้งานกับ TextBox Control ของ Microsoft
    ' / --------------------------------------------------------------------------------
    ' / ฟังค์ชั่นในการป้อนเฉพาะค่าตัวเลขได้เท่านั้น
    Function CheckDigitOnly(ByVal index As Integer) As Boolean
        Select Case index
            Case 48 To 57 ' เลข 0 - 9
                CheckDigitOnly = False
            Case 8, 13 ' Backspace = 8, Enter = 13
                CheckDigitOnly = False
            Case Else
                CheckDigitOnly = True
        End Select
    End Function

    ' / --------------------------------------------------------------------------------
    ' / ฟังค์ชั่นในการป้อนเฉพาะค่าตัวเลขและทศนิยมได้ตัวเดียวเท่านั้น
    Function CheckCurrency(index As Integer, tmpStr As String) As Boolean
        CheckCurrency = False
        Select Case index
            Case 48 To 57 ' เลข 0 - 9
                ' Allowed "."
            Case 46
                ' can present "." only one
                If InStr(tmpStr, ".") Then CheckCurrency = True

            Case 8, 13 ' Backspace = 8, Enter = 13
            Case Else
                CheckCurrency = True
        End Select
    End Function

    ' / --------------------------------------------------------------------------------
    ' / ต้องเพิ่มโค้ดในการดักการกดคีย์จากผู้ใช้ (Validate Data)
    Private Sub txtInteger_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtInteger.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = CheckDigitOnly(Asc(e.KeyChar))
        End If
    End Sub

    Private Sub txtDouble_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDouble.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = CheckCurrency(Asc(e.KeyChar), txtDouble.Text)
        End If
    End Sub
    ' / --------------------------------------------------------------------------------

End Class
