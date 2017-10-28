<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeq
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
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.trSpeed = New System.Windows.Forms.TrackBar()
        Me.txtSound = New System.Windows.Forms.TextBox()
        Me.lbSound = New System.Windows.Forms.LinkLabel()
        Me.lstSeq = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdChase = New System.Windows.Forms.RadioButton()
        Me.rdFlood = New System.Windows.Forms.RadioButton()
        CType(Me.trSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(99, 107)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(59, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Sequence:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(250, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Speed:"
        '
        'trSpeed
        '
        Me.trSpeed.Location = New System.Drawing.Point(255, 119)
        Me.trSpeed.Maximum = 255
        Me.trSpeed.Name = "trSpeed"
        Me.trSpeed.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trSpeed.Size = New System.Drawing.Size(45, 200)
        Me.trSpeed.TabIndex = 7
        Me.trSpeed.TickFrequency = 5
        Me.trSpeed.Value = 21
        '
        'txtSound
        '
        Me.txtSound.Location = New System.Drawing.Point(246, 315)
        Me.txtSound.MaxLength = 4
        Me.txtSound.Name = "txtSound"
        Me.txtSound.Size = New System.Drawing.Size(47, 20)
        Me.txtSound.TabIndex = 8
        Me.txtSound.Text = "35"
        Me.txtSound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbSound
        '
        Me.lbSound.AutoSize = True
        Me.lbSound.Location = New System.Drawing.Point(199, 318)
        Me.lbSound.Name = "lbSound"
        Me.lbSound.Size = New System.Drawing.Size(41, 13)
        Me.lbSound.TabIndex = 9
        Me.lbSound.TabStop = True
        Me.lbSound.Text = "Sound:"
        '
        'lstSeq
        '
        Me.lstSeq.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSeq.FormattingEnabled = True
        Me.lstSeq.Location = New System.Drawing.Point(102, 126)
        Me.lstSeq.Name = "lstSeq"
        Me.lstSeq.Size = New System.Drawing.Size(142, 186)
        Me.lstSeq.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.ForeColor = System.Drawing.Color.DarkGray
        Me.Panel1.Location = New System.Drawing.Point(288, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(120, 120)
        Me.Panel1.TabIndex = 11
        '
        'rdChase
        '
        Me.rdChase.BackColor = System.Drawing.Color.Transparent
        Me.rdChase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdChase.ForeColor = System.Drawing.Color.White
        Me.rdChase.Location = New System.Drawing.Point(319, 121)
        Me.rdChase.Name = "rdChase"
        Me.rdChase.Size = New System.Drawing.Size(61, 18)
        Me.rdChase.TabIndex = 12
        Me.rdChase.TabStop = True
        Me.rdChase.Text = "Chase"
        Me.rdChase.UseVisualStyleBackColor = False
        '
        'rdFlood
        '
        Me.rdFlood.BackColor = System.Drawing.Color.Transparent
        Me.rdFlood.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdFlood.ForeColor = System.Drawing.Color.White
        Me.rdFlood.Location = New System.Drawing.Point(319, 136)
        Me.rdFlood.Name = "rdFlood"
        Me.rdFlood.Size = New System.Drawing.Size(61, 18)
        Me.rdFlood.TabIndex = 13
        Me.rdFlood.TabStop = True
        Me.rdFlood.Text = "Flood"
        Me.rdFlood.UseVisualStyleBackColor = False
        '
        'frmSeq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(467, 428)
        Me.Controls.Add(Me.rdFlood)
        Me.Controls.Add(Me.rdChase)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstSeq)
        Me.Controls.Add(Me.txtSound)
        Me.Controls.Add(Me.lbSound)
        Me.Controls.Add(Me.trSpeed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeq"
        Me.Text = "DMX CV - Sequencer"
        CType(Me.trSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents txtSound As System.Windows.Forms.TextBox
    Friend WithEvents lbSound As System.Windows.Forms.LinkLabel
    Friend WithEvents lstSeq As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdChase As RadioButton
    Friend WithEvents rdFlood As RadioButton
End Class
