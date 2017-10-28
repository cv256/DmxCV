Public Class frmDebug

    Public Sub AppendText(pText As String)
        Me.TextBox1.AppendText(pText) ' = Me.TextBox1.TextLength - 1
    End Sub

End Class