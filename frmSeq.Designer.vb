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
        Me.lstSeq = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdChase = New System.Windows.Forms.RadioButton()
        Me.rdFlood = New System.Windows.Forms.RadioButton()
        Me.trSound = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.trBass = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.trSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trSound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trBass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(99, 100)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(59, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Sequence:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(162, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Speed:"
        '
        'trSpeed
        '
        Me.trSpeed.Location = New System.Drawing.Point(172, 112)
        Me.trSpeed.Maximum = 255
        Me.trSpeed.Name = "trSpeed"
        Me.trSpeed.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trSpeed.Size = New System.Drawing.Size(45, 200)
        Me.trSpeed.TabIndex = 7
        Me.trSpeed.TickFrequency = 5
        Me.trSpeed.Value = 21
        '
        'lstSeq
        '
        Me.lstSeq.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSeq.FormattingEnabled = True
        Me.lstSeq.Location = New System.Drawing.Point(102, 119)
        Me.lstSeq.Name = "lstSeq"
        Me.lstSeq.Size = New System.Drawing.Size(68, 186)
        Me.lstSeq.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.ForeColor = System.Drawing.Color.DarkGray
        Me.Panel1.Location = New System.Drawing.Point(291, 150)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(116, 116)
        Me.Panel1.TabIndex = 11
        '
        'rdChase
        '
        Me.rdChase.BackColor = System.Drawing.Color.Transparent
        Me.rdChase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdChase.ForeColor = System.Drawing.Color.White
        Me.rdChase.Location = New System.Drawing.Point(319, 114)
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
        Me.rdFlood.Location = New System.Drawing.Point(319, 129)
        Me.rdFlood.Name = "rdFlood"
        Me.rdFlood.Size = New System.Drawing.Size(61, 18)
        Me.rdFlood.TabIndex = 13
        Me.rdFlood.TabStop = True
        Me.rdFlood.Text = "Flood"
        Me.rdFlood.UseVisualStyleBackColor = False
        '
        'trSound
        '
        Me.trSound.Location = New System.Drawing.Point(207, 112)
        Me.trSound.Maximum = 255
        Me.trSound.Name = "trSound"
        Me.trSound.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trSound.Size = New System.Drawing.Size(45, 200)
        Me.trSound.TabIndex = 16
        Me.trSound.TickFrequency = 5
        Me.trSound.Value = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(202, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Sound:"
        '
        'trBass
        '
        Me.trBass.Location = New System.Drawing.Point(244, 112)
        Me.trBass.Maximum = 255
        Me.trBass.Name = "trBass"
        Me.trBass.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trBass.Size = New System.Drawing.Size(45, 200)
        Me.trBass.TabIndex = 18
        Me.trBass.TickFrequency = 5
        Me.trBass.Value = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(245, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Bass:"
        '
        'frmSeq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(467, 428)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.trBass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.trSound)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rdFlood)
        Me.Controls.Add(Me.rdChase)
        Me.Controls.Add(Me.lstSeq)
        Me.Controls.Add(Me.trSpeed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeq"
        Me.Text = "DMX CV - Sequencer"
        CType(Me.trSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trSound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trBass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents lstSeq As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdChase As RadioButton
    Friend WithEvents rdFlood As RadioButton
    Friend WithEvents trSound As TrackBar
    Private WithEvents Label3 As Label
    Friend WithEvents trBass As TrackBar
    Private WithEvents Label4 As Label
End Class
