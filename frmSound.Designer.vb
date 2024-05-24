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
        Me.lbNoise = New System.Windows.Forms.Label()
        Me.trNoise = New System.Windows.Forms.TrackBar()
        Me.lbNoiseB = New System.Windows.Forms.Label()
        Me.trNoiseB = New System.Windows.Forms.TrackBar()
        Me.Label4B = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.trDelayB = New System.Windows.Forms.TrackBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.trCompressorB = New System.Windows.Forms.TrackBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.trSoften = New System.Windows.Forms.TrackBar()
        CType(Me.trCompressor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trNoise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trNoiseB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trDelayB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trCompressorB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trSoften, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.chkMonitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMonitor.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMonitor.AutoSize = True
        Me.chkMonitor.ForeColor = System.Drawing.Color.Black
        Me.chkMonitor.Location = New System.Drawing.Point(7, 382)
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
        Me.trCompressor.Location = New System.Drawing.Point(124, 59)
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
        Me.Label1.Location = New System.Drawing.Point(7, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Compressor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Delay:"
        '
        'trDelay
        '
        Me.trDelay.AutoSize = False
        Me.trDelay.LargeChange = 1
        Me.trDelay.Location = New System.Drawing.Point(124, 89)
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
        Me.Label4.Location = New System.Drawing.Point(7, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Factor:"
        '
        'lbNoise
        '
        Me.lbNoise.AutoSize = True
        Me.lbNoise.Location = New System.Drawing.Point(7, 123)
        Me.lbNoise.Name = "lbNoise"
        Me.lbNoise.Size = New System.Drawing.Size(61, 13)
        Me.lbNoise.TabIndex = 15
        Me.lbNoise.Text = "Noise gate:"
        '
        'trNoise
        '
        Me.trNoise.AutoSize = False
        Me.trNoise.LargeChange = 1
        Me.trNoise.Location = New System.Drawing.Point(124, 119)
        Me.trNoise.Maximum = 128
        Me.trNoise.Name = "trNoise"
        Me.trNoise.Size = New System.Drawing.Size(314, 24)
        Me.trNoise.TabIndex = 14
        Me.trNoise.TickFrequency = 2
        Me.trNoise.Value = 10
        '
        'lbNoiseB
        '
        Me.lbNoiseB.AutoSize = True
        Me.lbNoiseB.Location = New System.Drawing.Point(5, 312)
        Me.lbNoiseB.Name = "lbNoiseB"
        Me.lbNoiseB.Size = New System.Drawing.Size(61, 13)
        Me.lbNoiseB.TabIndex = 22
        Me.lbNoiseB.Text = "Noise gate:"
        '
        'trNoiseB
        '
        Me.trNoiseB.AutoSize = False
        Me.trNoiseB.LargeChange = 1
        Me.trNoiseB.Location = New System.Drawing.Point(122, 308)
        Me.trNoiseB.Maximum = 128
        Me.trNoiseB.Name = "trNoiseB"
        Me.trNoiseB.Size = New System.Drawing.Size(314, 24)
        Me.trNoiseB.TabIndex = 21
        Me.trNoiseB.TickFrequency = 2
        Me.trNoiseB.Value = 10
        '
        'Label4B
        '
        Me.Label4B.AutoSize = True
        Me.Label4B.Location = New System.Drawing.Point(5, 342)
        Me.Label4B.Name = "Label4B"
        Me.Label4B.Size = New System.Drawing.Size(40, 13)
        Me.Label4B.TabIndex = 20
        Me.Label4B.Text = "Factor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Delay:"
        '
        'trDelayB
        '
        Me.trDelayB.AutoSize = False
        Me.trDelayB.LargeChange = 1
        Me.trDelayB.Location = New System.Drawing.Point(122, 278)
        Me.trDelayB.Maximum = 57
        Me.trDelayB.Minimum = 21
        Me.trDelayB.Name = "trDelayB"
        Me.trDelayB.Size = New System.Drawing.Size(314, 24)
        Me.trDelayB.TabIndex = 18
        Me.trDelayB.Value = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Compressor:"
        '
        'trCompressorB
        '
        Me.trCompressorB.AutoSize = False
        Me.trCompressorB.LargeChange = 4
        Me.trCompressorB.Location = New System.Drawing.Point(122, 248)
        Me.trCompressorB.Maximum = 128
        Me.trCompressorB.Name = "trCompressorB"
        Me.trCompressorB.Size = New System.Drawing.Size(314, 24)
        Me.trCompressorB.TabIndex = 16
        Me.trCompressorB.TickFrequency = 4
        Me.trCompressorB.Value = 128
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(7, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(425, 16)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Bass:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(7, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(425, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "FullRange:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Soften:"
        '
        'trSoften
        '
        Me.trSoften.AutoSize = False
        Me.trSoften.LargeChange = 2
        Me.trSoften.Location = New System.Drawing.Point(125, 178)
        Me.trSoften.Maximum = 100
        Me.trSoften.Name = "trSoften"
        Me.trSoften.Size = New System.Drawing.Size(314, 24)
        Me.trSoften.SmallChange = 2
        Me.trSoften.TabIndex = 25
        Me.trSoften.TickFrequency = 2
        Me.trSoften.Value = 34
        '
        'frmSound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(440, 409)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.trSoften)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbNoiseB)
        Me.Controls.Add(Me.trNoiseB)
        Me.Controls.Add(Me.Label4B)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.trDelayB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.trCompressorB)
        Me.Controls.Add(Me.lbNoise)
        Me.Controls.Add(Me.trNoise)
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
        CType(Me.trNoise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trNoiseB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trDelayB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trCompressorB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trSoften, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lbNoise As System.Windows.Forms.Label
    Friend WithEvents trNoise As System.Windows.Forms.TrackBar
    Friend WithEvents lbNoiseB As Label
    Friend WithEvents trNoiseB As TrackBar
    Friend WithEvents Label4B As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents trDelayB As TrackBar
    Friend WithEvents Label8 As Label
    Friend WithEvents trCompressorB As TrackBar
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents trSoften As TrackBar
End Class
