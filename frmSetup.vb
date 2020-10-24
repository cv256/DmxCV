Public Class frmSetup
    Public txtTimer_Value As Integer

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTimer.Text = _MainForm.RefreshRate
        txtPort.Text = dmx.ComPort
    End Sub

    Private Sub btApply_Click(sender As Object, e As EventArgs) Handles btApply.Click
        If lbHertz.Text = "???" Then
            Beep()
            Return
        End If

        _MainForm.RefreshRate = txtTimer.Text
        Try
            dmx.ComPort = CInt(txtPort.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clDMX.Configure()
    End Sub

    Private Sub txtTimer_TextChanged(sender As Object, e As EventArgs) Handles txtTimer.TextChanged
        txtTimer_Value = 9999999
        Try
            txtTimer_Value = CInt(txtTimer.Text)
        Catch ex As Exception
        End Try
        If txtTimer_Value < 10 Or txtTimer_Value > 5000 Then
            txtTimer.Focus()
            txtTimer.BackColor = Color.Orange
            lbHertz.Text = "???"
        Else
            txtTimer.BackColor = SystemColors.Window
            lbHertz.Text = CInt(1 / (txtTimer_Value / 1000)) & " Hz"
        End If
    End Sub



End Class