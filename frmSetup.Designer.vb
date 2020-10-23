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
        Me.txtTimer = New System.Windows.Forms.TextBox()
        Me.btApply = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbHertz = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.btApply.Location = New System.Drawing.Point(103, 139)
        Me.btApply.Name = "btApply"
        Me.btApply.Size = New System.Drawing.Size(75, 23)
        Me.btApply.TabIndex = 2
        Me.btApply.Text = "&Apply"
        Me.btApply.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 22)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "configure/test uDMX"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbHertz
        '
        Me.lbHertz.AutoSize = True
        Me.lbHertz.Location = New System.Drawing.Point(184, 9)
        Me.lbHertz.Name = "lbHertz"
        Me.lbHertz.Size = New System.Drawing.Size(29, 13)
        Me.lbHertz.TabIndex = 6
        Me.lbHertz.Text = "0 Hz"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(116, 55)
        Me.txtPort.MaxLength = 1
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(20, 20)
        Me.txtPort.TabIndex = 7
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 39)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "COM Port :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(0 = uDMX)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(1~9 = Arduino)"
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 167)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.lbHertz)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btApply)
        Me.Controls.Add(Me.txtTimer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSetup"
        Me.Text = "DMX CV - Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTimer As System.Windows.Forms.TextBox
    Friend WithEvents btApply As System.Windows.Forms.Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lbHertz As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
