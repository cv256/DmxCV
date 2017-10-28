Public Class frmSetup

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTimer.Text = _MainForm.RefreshRate
    End Sub

    Private Sub btApply_Click(sender As Object, e As EventArgs) Handles btApply.Click
        Dim res As Integer

        res = 9999999
        Try
            res = CInt(txtTimer.Text)
        Catch ex As Exception
        End Try
        If res < 20 Or res > 2000 Then
            txtTimer.Focus()
            txtTimer.BackColor = Color.Orange
        Else
            txtTimer.BackColor = SystemColors.Window
            _MainForm.RefreshRate = txtTimer.Text
        End If
    End Sub

End Class