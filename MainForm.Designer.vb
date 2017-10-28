<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.btnAllFixtures = New System.Windows.Forms.Button()
        Me.ckOffline = New System.Windows.Forms.CheckBox()
        Me.ckDebug = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ckPreview = New System.Windows.Forms.CheckBox()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.btLoad = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAllFixtures
        '
        Me.btnAllFixtures.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAllFixtures.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllFixtures.ForeColor = System.Drawing.Color.Black
        Me.btnAllFixtures.Location = New System.Drawing.Point(465, 340)
        Me.btnAllFixtures.Name = "btnAllFixtures"
        Me.btnAllFixtures.Size = New System.Drawing.Size(67, 23)
        Me.btnAllFixtures.TabIndex = 5
        Me.btnAllFixtures.Text = "All Fixtures"
        Me.btnAllFixtures.UseVisualStyleBackColor = False
        '
        'ckOffline
        '
        Me.ckOffline.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ckOffline.AutoSize = True
        Me.ckOffline.BackColor = System.Drawing.Color.Transparent
        Me.ckOffline.Checked = True
        Me.ckOffline.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.ckOffline.ForeColor = System.Drawing.Color.White
        Me.ckOffline.Location = New System.Drawing.Point(465, 284)
        Me.ckOffline.Name = "ckOffline"
        Me.ckOffline.Size = New System.Drawing.Size(56, 17)
        Me.ckOffline.TabIndex = 4
        Me.ckOffline.Text = "Offline"
        Me.ckOffline.UseVisualStyleBackColor = False
        '
        'ckDebug
        '
        Me.ckDebug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ckDebug.AutoSize = True
        Me.ckDebug.BackColor = System.Drawing.Color.Transparent
        Me.ckDebug.ForeColor = System.Drawing.Color.White
        Me.ckDebug.Location = New System.Drawing.Point(465, 302)
        Me.ckDebug.Name = "ckDebug"
        Me.ckDebug.Size = New System.Drawing.Size(58, 17)
        Me.ckDebug.TabIndex = 3
        Me.ckDebug.Text = "Debug"
        Me.ckDebug.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'ckPreview
        '
        Me.ckPreview.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ckPreview.AutoSize = True
        Me.ckPreview.BackColor = System.Drawing.Color.Transparent
        Me.ckPreview.ForeColor = System.Drawing.Color.White
        Me.ckPreview.Location = New System.Drawing.Point(465, 321)
        Me.ckPreview.Name = "ckPreview"
        Me.ckPreview.Size = New System.Drawing.Size(64, 17)
        Me.ckPreview.TabIndex = 7
        Me.ckPreview.Text = "Preview"
        Me.ckPreview.UseVisualStyleBackColor = False
        '
        'btSetup
        '
        Me.btSetup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btSetup.BackColor = System.Drawing.SystemColors.Control
        Me.btSetup.ForeColor = System.Drawing.Color.Black
        Me.btSetup.Location = New System.Drawing.Point(465, 243)
        Me.btSetup.Name = "btSetup"
        Me.btSetup.Size = New System.Drawing.Size(67, 20)
        Me.btSetup.TabIndex = 9
        Me.btSetup.Text = "Setup"
        Me.btSetup.UseVisualStyleBackColor = False
        '
        'btLoad
        '
        Me.btLoad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btLoad.BackColor = System.Drawing.SystemColors.Control
        Me.btLoad.ForeColor = System.Drawing.Color.Black
        Me.btLoad.Location = New System.Drawing.Point(465, 223)
        Me.btLoad.Name = "btLoad"
        Me.btLoad.Size = New System.Drawing.Size(67, 20)
        Me.btLoad.TabIndex = 10
        Me.btLoad.Text = "Load"
        Me.btLoad.UseVisualStyleBackColor = False
        '
        'btSave
        '
        Me.btSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btSave.BackColor = System.Drawing.SystemColors.Control
        Me.btSave.ForeColor = System.Drawing.Color.Black
        Me.btSave.Location = New System.Drawing.Point(465, 263)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(67, 20)
        Me.btSave.TabIndex = 11
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1004, 657)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.btLoad)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.ckPreview)
        Me.Controls.Add(Me.btnAllFixtures)
        Me.Controls.Add(Me.ckOffline)
        Me.Controls.Add(Me.ckDebug)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "DMX CV"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAllFixtures As System.Windows.Forms.Button
    Friend WithEvents ckOffline As System.Windows.Forms.CheckBox
    Friend WithEvents ckDebug As System.Windows.Forms.CheckBox
    Friend WithEvents ckPreview As System.Windows.Forms.CheckBox
    Friend WithEvents btSetup As System.Windows.Forms.Button
    Private WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btLoad As Button
    Friend WithEvents btSave As Button
End Class
