
Public Class MainForm
    Public ReadOnly Fixtures As New List(Of FixtureTemplate)
    Public Presets As New Dictionary(Of String, Preset)
    Public ReadOnly FrmSound As New frmSound
    Public ReadOnly FrmSeq As New frmSeq
    Public Debug As frmDebug
    Public FrmFixture As ucFixture
    Private _BackgroundImage As Image
    Public LastUpdate As Date
    Private FileName As String, DefaultPath As String

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        _MainForm = Me

        _Dmx = New uDMX ' usb controller
        If My.Application.CommandLineArgs.Count = 1 Then
            LoadFromFile(My.Application.CommandLineArgs(0))
        Else
            btLoad_Click(Nothing, Nothing)
        End If

        'ckOffline.Checked = False ' tries to open _Dmx

        'Try
        '    ' _BackgroundImage = Image.FromFile(Application.StartupPath & "\Background.jpg")
        'Catch ex As Exception
        '    If MsgBox(TypeName(ex) & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation) = MsgBoxResult.Cancel Then End
        'End Try

        FrmSound.Init()

        For Each f As FixtureTemplate In Me.Fixtures
            f.Update()
        Next
        LastUpdate = Now
        PaintBackground(Me, New PaintEventArgs(Me.CreateGraphics, Nothing))
    End Sub



    Private Sub FixtureUpdated(pDebugInfo As String)
        If Not String.IsNullOrEmpty(pDebugInfo) Then
            If Debug IsNot Nothing AndAlso Debug.Visible Then
                Debug.AppendText("   Last update was " & CLng(Now.Subtract(LastUpdate).TotalMilliseconds) & "ms ago" & vbCrLf & pDebugInfo)
            End If
            LastUpdate = Now
            If Me.Visible AndAlso ckPreview.Checked Then
                Using g As Graphics = Me.CreateGraphics
                    PaintBackground(Me, New PaintEventArgs(g, Nothing)) ' se faço Me.Invalidate ou Me.Refresh ele executa o Paint 3 vezes nao sei porquê
                End Using
            End If
        End If
        If FrmFixture IsNot Nothing AndAlso FrmFixture.Visible Then FrmFixture.PaintVUs()
    End Sub

    Private Sub PaintBackground(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If Not _MainForm.Visible OrElse _MainForm.WindowState = FormWindowState.Minimized Then Return
        If _MainForm.Debug IsNot Nothing AndAlso _MainForm.Debug.Visible Then _MainForm.Debug.AppendText("Form.Paint " & Now.ToLongTimeString & vbCrLf)

        Dim currentContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
        Dim myBuffer As BufferedGraphics = currentContext.Allocate(Me.CreateGraphics, Me.DisplayRectangle)
        With myBuffer.Graphics
            If _BackgroundImage IsNot Nothing Then
                .DrawImage(_BackgroundImage, Me.DisplayRectangle)
            Else
                .Clear(Me.BackColor)
            End If
            For Each f As FixtureTemplate In Fixtures
                Dim tmpRect As Rectangle = f.MyRectangle(Me.ClientSize)
                .FillPolygon(f.LightBrush, f.LightArea(Me.ClientSize))
                ' todo: pintar o white
                .FillEllipse(Brushes.DimGray, tmpRect)
                Dim tmpPoint As Point = tmpRect.Location
                tmpPoint.Offset(0, tmpRect.Width / 2 - 4)
                .DrawString(f.Name, Me.Font, Brushes.White, tmpPoint)
            Next
        End With
        myBuffer.Render(e.Graphics)
        myBuffer.Dispose()
    End Sub


    Private Sub MainForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        For Each f As FixtureTemplate In Fixtures
            With f.MyRectangle(Me.ClientSize)
                If e.X > .X AndAlso e.X < .X + .Width AndAlso e.Y > .Y AndAlso e.Y < .Y + .Height Then
                    Me.Cursor = Cursors.Hand
                    Return
                End If
            End With
        Next
        Me.Cursor = Me.DefaultCursor
    End Sub


    Private Sub btnAllFixtures_Click(sender As Object, e As EventArgs) Handles btnAllFixtures.Click
        If FrmFixture IsNot Nothing AndAlso FrmFixture.Fixtures.Equals(Me.Fixtures) Then Return
        If FrmFixture IsNot Nothing Then
            Me.Controls.Remove(FrmFixture)
            FrmFixture = Nothing
        End If
        FrmFixture = New ucFixture(Fixtures)
        FrmFixture.Location = btnAllFixtures.Location
        Me.Controls.Add(FrmFixture)
        FrmFixture.BringToFront()
    End Sub

    Private Sub MainForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        For Each f As FixtureTemplate In Fixtures
            With f.MyRectangle(Me.ClientSize)
                If e.X > .X AndAlso e.X < .X + .Width AndAlso e.Y > .Y AndAlso e.Y < .Y + .Height Then
                    If FrmFixture IsNot Nothing AndAlso FrmFixture.Fixtures.Equals(f) = False Then
                        Me.Controls.Remove(FrmFixture)
                        FrmFixture = Nothing
                    End If
                    If FrmFixture IsNot Nothing Then Return
                    Dim tmpF As New List(Of FixtureTemplate) : tmpF.Add(f)
                    FrmFixture = New ucFixture(tmpF)
                    Me.Controls.Add(FrmFixture)
                    FrmFixture.Location = e.Location
                    With _MainForm.ClientSize
                        If FrmFixture.Bottom > .Height - 50 Then FrmFixture.Top = .Height - 50 - FrmFixture.Height
                        If FrmFixture.Right > .Width - 30 Then FrmFixture.Left = .Width - 10 - FrmFixture.Width
                    End With
                    Return
                End If
            End With
        Next
        If FrmFixture IsNot Nothing Then
            Me.Controls.Remove(FrmFixture)
            FrmFixture = Nothing
        End If
    End Sub


    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _Dmx.Dispose()
        _Dmx = Nothing
    End Sub

    Private Sub ckDebug_CheckedChanged(sender As Object, e As EventArgs) Handles ckDebug.CheckedChanged
        If ckDebug.Checked Then
            If Debug Is Nothing Then Debug = New frmDebug
            Debug.Show(Me)
        Else
            Debug.Visible = False
        End If
    End Sub

    Private Sub ckOffline_CheckedChanged(sender As Object, e As EventArgs) Handles ckOffline.CheckedChanged
        _Offline = True
        If Not ckOffline.Checked Then
            If Not _Dmx.IsOpen Then
                ckOffline.Checked = MsgBox("O dispositivo uDMX não está disponivel." & vbCrLf & "prima «Yes» para prosseguir Online, «No» para Offline", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No
            Else
                _Offline = False
            End If
        End If
    End Sub

    Public Function NewTrackBar(pName As String, pTop As Integer, pLeft As Integer, pTag As Object, pScrollHandler As System.EventHandler) As TrackBar
        Dim res As New TrackBar
        With res
            .Name = pName
            .Orientation = Orientation.Vertical
            .TickFrequency = 5
            .TickStyle = TickStyle.BottomRight
            .LargeChange = 5
            .SmallChange = 1
            .Maximum = 255
            .Minimum = 0
            .Location = New Point(pLeft, pTop)
            .Size = New Size(45, 200)
            .Tag = pTag
            AddHandler .Scroll, pScrollHandler
        End With
        Return res
    End Function

    Public Function NewPercent(pName As String, pTop As Integer, pLeft As Integer, pTag As Object, pTextChanged As System.EventHandler) As TextBox
        Dim res As New TextBox
        With res
            .Name = pName
            .Location = New Point(pLeft, pTop)
            .Size = New Size(29, 20)
            .TextAlign = HorizontalAlignment.Right
            .MaxLength = 4
            .Tag = pTag
            AddHandler .TextChanged, pTextChanged
        End With
        Return res
    End Function

    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        FrmSeq.Advance()
        Dim tmpDebug As String = "" ', cIdx As Integer = 0
        For Each f As FixtureTemplate In Fixtures
            'Dim p As Preset = Presets(f.ActivePreset)
            'For Each c As ChannelData In p.values
            'If c.SoundControllerPercent <> 0 Then c.SoundControllerValue = _frmSound.SoundController
            'If c.SeqControllerPercent <> 0 Then c.SeqControllerValue = _frmSeq.SeqController(cIdx)
            'Next
            tmpDebug &= f.Update()
            'cIdx += 1
        Next
        FixtureUpdated(tmpDebug)
        Timer1.Enabled = True
    End Sub

    Public Sub RefreshSuspended()
        Timer1.Enabled = False
    End Sub

    Public Property RefreshRate() As Integer
        Get
            Return Timer1.Interval
        End Get
        Set(ByVal value As Integer)
            Timer1.Interval = value
            FrmSound.RefreshRate = value
        End Set
    End Property


    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        Dim tmpFrm As New frmSetup
        tmpFrm.Show(Me)
    End Sub






    Public Property FileName As String
        Get
            Return FileName
        End Get
        Private Set(value As String)
            DefaultPath = IO.Path.GetDirectoryName(value)
            FileName = value
            Me.Text = "DMX CV " & My.Application.Info.Version.ToString & "- " & IO.Path.GetFileNameWithoutExtension(FileName)
        End Set
    End Property
    Public ReadOnly Property DefaultPath As String
        Get
            Return DefaultPath
        End Get
    End Property


    Public Function SaveToFile(pFileName As String) As Boolean
        If pFileName.Length = 0 Then pFileName = Me.FileName

        Try
            Dim xDoc As XDocument = New XDocument
            Dim root As New XElement("DMXCV",
              New XElement("SaveDate", Now),
              New XElement("RefreshRate", RefreshRate),
              New XElement("Offline", ckOffline.Checked),
              New XElement("Debug", ckDebug.Checked),
              New XElement("Preview", ckPreview.Checked)
            )

            root.Add(FrmSeq.Serialize())

            For Each f As FixtureTemplate In Me.Fixtures
                root.Add(f.Serialize)
            Next

            For Each f As Preset In Me.Presets.Values
                root.Add(f.Serialize)
            Next

            root.Add(New XAttribute("Version", My.Application.Info.Version.ToString))
            xDoc.Add(root)
            xDoc.Declaration = New XDeclaration("1.0", "UTF-8", "yes")
            xDoc.Save(pFileName, SaveOptions.None) ' save indentado 

        Catch ex As Exception
            MsgBox(String.Format("Problem saving «{0}»", pFileName) & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        Me.FileName = pFileName
        Return True
    End Function


    Public Sub LoadFromFile(ByVal pFileName As String)
        Try
            Timer1.Enabled = False
            DefaultPath = IO.Path.GetDirectoryName(pFileName)
            Dim xDoc As XDocument
            xDoc = XDocument.Load(pFileName)
            With xDoc.<DMXCV>
                RefreshRate = Math.Max(CInt(.<RefreshRate>.Value), 20)
                ckOffline.CheckState = IIf(.<Offline>.Value = "true", CheckState.Checked, CheckState.Unchecked)
                ckDebug.CheckState = IIf(.<Debug>.Value = "true", CheckState.Checked, CheckState.Unchecked)
                ckPreview.CheckState = IIf(.<Preview>.Value = "true", CheckState.Checked, CheckState.Unchecked)
                For Each xFixt As XElement In .<Fixture>
                    Fixtures.Add(New FixtureTemplate(xFixt))
                Next
                For Each xPreset As XElement In .<Preset>
                    Dim p As New Preset(xPreset)
                    Presets.Add(p.Name, p)
                Next
                If Fixtures.Count < 1 Then
                    MsgBox(String.Format("You need to add some <Fixture> to «{0}»", pFileName), MsgBoxStyle.Critical)
                    End
                End If
                If Presets.Count < 1 Then
                    MsgBox(String.Format("You need to add some <Preset> to «{0}»", pFileName), MsgBoxStyle.Critical)
                    End
                End If
                For Each f As FixtureTemplate In Fixtures
                    Dim foundIt As Boolean = False
                    For Each p As Preset In Presets.Values
                        If p.AffectedFixtures.ContainsKey(f) Then
                            foundIt = True
                            Exit For
                        End If
                    Next
                    If Not foundIt Then
                        MsgBox(String.Format("Fixture «{0}» is not Affected by any of the <Preset> in {1}", f.Name, pFileName), MsgBoxStyle.Critical)
                        End
                    End If
                Next
                FrmSeq.Init(.<Sequencer>.<ActiveSequence>.Value, .<Sequencer>.<BaseSpeed>.Value, .<Sequencer>.<SoundSpeed>.Value, .<Sequencer>.<Mode>.Value)
            End With

            Me.FileName = pFileName

        Catch ex As Exception
            MsgBox(String.Format("Problem loading «{0}»", pFileName) & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

        If String.IsNullOrEmpty(Me.FileName) Then
            MsgBox("No file loaded", MsgBoxStyle.Critical)
            End
        End If
    End Sub

    Private Sub btLoad_Click(sender As Object, e As EventArgs) Handles btLoad.Click
        Dim t As New OpenFileDialog
        t.DefaultExt = "dmxcv.xml"
        t.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
        If Not String.IsNullOrEmpty(Me.FileName) Then t.FileName = Me.FileName
        If t.ShowDialog() <> DialogResult.OK Then Return
        LoadFromFile(t.FileName)
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        Dim t As New SaveFileDialog
        t.DefaultExt = "dmxcv.xml"
        t.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
        If Not String.IsNullOrEmpty(Me.FileName) Then t.FileName = Me.FileName
        If t.ShowDialog() <> DialogResult.OK Then Return
        SaveToFile(t.FileName)
    End Sub

    Private Sub btLoad_MouseUp(sender As Object, e As MouseEventArgs) Handles btLoad.MouseUp
        If e.Button = MouseButtons.Right Then
            System.Diagnostics.Process.Start(FileName)
        End If
    End Sub

End Class