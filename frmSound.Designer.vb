<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSound
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
        Me.cmbDevices = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.chkMonitor = New System.Windows.Forms.CheckBox()
        Me.trCompressor = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.trDelay = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.trBeat = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.trNoise = New System.Windows.Forms.TrackBar()
        CType(Me.trCompressor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trBeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trNoise, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbDevices
        '
        Me.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevices.FormattingEnabled = True
        Me.cmbDevices.Location = New System.Drawing.Point(132, 6)
        Me.cmbDevices.Name = "cmbDevices"
        Me.cmbDevices.Size = New System.Drawing.Size(300, 21)
        Me.cmbDevices.TabIndex = 3
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 9)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(44, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Device:"
        '
        'chkMonitor
        '
        Me.chkMonitor.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMonitor.AutoSize = True
        Me.chkMonitor.ForeColor = System.Drawing.Color.Black
        Me.chkMonitor.Location = New System.Drawing.Point(7, 265)
        Me.chkMonitor.Name = "chkMonitor"
        Me.chkMonitor.Size = New System.Drawing.Size(60, 23)
        Me.chkMonitor.TabIndex = 5
        Me.chkMonitor.Text = "Monitor it"
        Me.chkMonitor.UseVisualStyleBackColor = True
        '
        'trCompressor
        '
        Me.trCompressor.AutoSize = False
        Me.trCompressor.LargeChange = 4
        Me.trCompressor.Location = New System.Drawing.Point(124, 52)
        Me.trCompressor.Maximum = 128
        Me.trCompressor.Name = "trCompressor"
        Me.trCompressor.Size = New System.Drawing.Size(314, 24)
        Me.trCompressor.TabIndex = 6
        Me.trCompressor.TickFrequency = 4
        Me.trCompressor.Value = 128
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Compressor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Delay:"
        '
        'trDelay
        '
        Me.trDelay.AutoSize = False
        Me.trDelay.LargeChange = 1
        Me.trDelay.Location = New System.Drawing.Point(124, 82)
        Me.trDelay.Maximum = 57
        Me.trDelay.Minimum = 21
        Me.trDelay.Name = "trDelay"
        Me.trDelay.Size = New System.Drawing.Size(314, 24)
        Me.trDelay.TabIndex = 8
        Me.trDelay.Value = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Factor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Beat:"
        '
        'trBeat
        '
        Me.trBeat.AutoSize = False
        Me.trBeat.LargeChange = 4
        Me.trBeat.Location = New System.Drawing.Point(125, 188)
        Me.trBeat.Maximum = 100
        Me.trBeat.Name = "trBeat"
        Me.trBeat.Size = New System.Drawing.Size(314, 24)
        Me.trBeat.TabIndex = 11
        Me.trBeat.TickFrequency = 4
        Me.trBeat.Value = 99
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Factor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Noise gate:"
        '
        'trNoise
        '
        Me.trNoise.AutoSize = False
        Me.trNoise.LargeChange = 1
        Me.trNoise.Location = New System.Drawing.Point(124, 112)
        Me.trNoise.Maximum = 128
        Me.trNoise.Name = "trNoise"
        Me.trNoise.Size = New System.Drawing.Size(314, 24)
        Me.trNoise.TabIndex = 14
        Me.trNoise.TickFrequency = 2
        Me.trNoise.Value = 10
        '
        'frmSound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(440, 294)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.trNoise)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.trBeat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.trDelay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trCompressor)
        Me.Controls.Add(Me.chkMonitor)
        Me.Controls.Add(Me.cmbDevices)
        Me.Controls.Add(Me.label2)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSound"
        Me.Text = "DMX CV - Sound"
        CType(Me.trCompressor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trBeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trNoise, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents chkMonitor As System.Windows.Forms.CheckBox
    Friend WithEvents trCompressor As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents trDelay As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents trBeat As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents trNoise As System.Windows.Forms.TrackBar

End Class
