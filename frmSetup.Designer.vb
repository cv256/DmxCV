<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTimer = New System.Windows.Forms.TextBox()
        Me.btApply = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Refresh Rate (ms) :"
        '
        'txtTimer
        '
        Me.txtTimer.Location = New System.Drawing.Point(116, 6)
        Me.txtTimer.MaxLength = 4
        Me.txtTimer.Name = "txtTimer"
        Me.txtTimer.Size = New System.Drawing.Size(62, 20)
        Me.txtTimer.TabIndex = 1
        '
        'btApply
        '
        Me.btApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btApply.Location = New System.Drawing.Point(90, 105)
        Me.btApply.Name = "btApply"
        Me.btApply.Size = New System.Drawing.Size(75, 23)
        Me.btApply.TabIndex = 2
        Me.btApply.Text = "&Apply"
        Me.btApply.UseVisualStyleBackColor = True
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 140)
        Me.Controls.Add(Me.btApply)
        Me.Controls.Add(Me.txtTimer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSetup"
        Me.Text = "DMX CV - Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTimer As System.Windows.Forms.TextBox
    Friend WithEvents btApply As System.Windows.Forms.Button
End Class
