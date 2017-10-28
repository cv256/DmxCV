Public Class ucFixture

    Public Fixtures As List(Of FixtureTemplate)
    Private SuspendInputEvents As Boolean = False

    Public Sub New(pFixture As List(Of FixtureTemplate))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Fixtures = pFixture
        Me.Text = "DMX CV - " : For Each f As FixtureTemplate In Fixtures : Me.Text &= f.Name & "  " : Next

        Dim biggestBottom As Integer = 0, biggestRight As Integer = 0
        Dim tmpRd As RadioButton
        For Each p As Preset In _MainForm.Presets.Values
            tmpRd = New RadioButton With {.Name = "rd" & p.Name, .Text = p.Name, .Top = biggestBottom, .Left = 0, .AutoSize = True, .ForeColor = Color.White, .Tag = p.Name}
            Me.Controls.Add(tmpRd)
            AddHandler tmpRd.CheckedChanged, AddressOf rd_CheckedChanged
            biggestBottom = tmpRd.Bottom
            If tmpRd.Right > biggestRight Then biggestRight = tmpRd.Right
        Next
        Dim tmpBt As Button = Nothing
        For Each c As Control In Me.Controls
            If Not TypeOf (c) Is RadioButton Then Continue For
            tmpBt = New Button With {.Name = "bt" & c.Tag, .Text = "*", .Top = c.Top, .Left = biggestRight, .Height = c.Height, .Width = c.Height, .ForeColor = Color.Red, .BackColor = SystemColors.ButtonFace, .Tag = c.Tag}
            Me.Controls.Add(tmpBt)
            AddHandler tmpBt.MouseDown, AddressOf bt_MouseDown
            AddHandler tmpBt.MouseUp, AddressOf bt_MouseUp
        Next
        If tmpBt IsNot Nothing Then biggestRight = tmpBt.Right
        Dim tmplabel As Label, tmpTxtSound As TextBox, tmpTxtSeq As TextBox
        For Each c As ChannelType In ChannelTypes.Enum
            If ChannelShow(c) = ChannelData.Modes.Hide Then Continue For
            tmplabel = New Label With {.Name = "lb" & c.Type, .Text = c.Description, .Top = 0, .Left = biggestRight, .AutoSize = True, .ForeColor = Color.LightBlue, .Tag = c}
            Me.Controls.Add(tmplabel)
            biggestRight = tmplabel.Right
            Dim tmpTr As TrackBar = _MainForm.NewTrackBar("tr" & c.Type, pTop:=tmplabel.Bottom, pLeft:=tmplabel.Left, pTag:=c, pScrollHandler:=AddressOf tr_Scroll)
            Me.Controls.Add(tmpTr)
            tmpTxtSound = _MainForm.NewPercent("txtSound" & c.Type, pTop:=tmpTr.Bottom, pLeft:=tmplabel.Left + 3, pTag:=c, pTextChanged:=AddressOf txt_TextChanged)
            Me.Controls.Add(tmpTxtSound)
            tmpTxtSeq = _MainForm.NewPercent("txtSeq" & c.Type, pTop:=tmpTxtSound.Bottom + 2, pLeft:=tmplabel.Left + 3, pTag:=c, pTextChanged:=AddressOf txt_TextChanged)
            Me.Controls.Add(tmpTxtSeq)
            If tmpTr.Right > biggestRight Then biggestRight = tmpTr.Right
        Next
        biggestBottom = tmpTxtSeq.Bottom
        tmplabel = New LinkLabel With {.Name = "lbSound", .Text = "Sound Controller", .Top = tmpTxtSound.Top, .Left = 0, .AutoSize = False, .Width = tmpBt.Right, .Height = tmpTxtSeq.Height, .ForeColor = Color.LightBlue, .Cursor = Cursors.Hand}
        Me.Controls.Add(tmplabel)
        AddHandler tmplabel.Click, AddressOf lbSound_Click
        tmplabel = New LinkLabel With {.Name = "lbSeq", .Text = "Sequencer", .Top = tmpTxtSeq.Top, .Left = 0, .AutoSize = False, .Width = tmpBt.Right, .Height = tmpTxtSeq.Height, .ForeColor = Color.LightBlue, .Cursor = Cursors.Hand}
        Me.Controls.Add(tmplabel)
        AddHandler tmplabel.Click, AddressOf lbSeq_Click

        Me.Size = New Size(biggestRight, biggestBottom)

        If Me.Controls.ContainsKey("rd" & Fixtures(0).LastFixedPreset) Then DirectCast(Me.Controls("rd" & Fixtures(0).LastFixedPreset), RadioButton).Checked = True ' this fires rd_CheckedChanged
    End Sub

    Private Function ChannelShow(Type As ChannelType) As ChannelData.Modes
        Dim res As ChannelData.Modes = ChannelData.Modes.Hide
        For Each f As FixtureTemplate In Me.Fixtures
            For Each p As Preset In _MainForm.Presets.Values
                If Not p.AffectedFixtures.ContainsKey(f) Then Continue For
                If p.AffectedFixtures(f).ChannelMode(Type) = ChannelData.Modes.Hide Then Continue For
                If p.AffectedFixtures(f).ChannelMode(Type) = ChannelData.Modes.Show Then Return p.AffectedFixtures(f).ChannelMode(Type)
            Next
        Next
        Return res
    End Function

    Private Sub rd_CheckedChanged(sender As Object, e As EventArgs)
        With DirectCast(sender, RadioButton)
            .ForeColor = IIf(.Checked, Color.Red, Color.White)
            DirectCast(Me.Controls("bt" & .Name.Substring(2)), Button).Visible = Not .Checked
            If Not .Checked Then Return
        End With
        Dim p As String = sender.tag
        If _MainForm.Debug IsNot Nothing AndAlso _MainForm.Debug.Visible Then _MainForm.Debug.AppendText(Me.Text & " -> Apply Preset «" & p & "»" & vbCrLf)
        For Each f As FixtureTemplate In Me.Fixtures
            f.ActivePreset = p
            f.LastFixedPreset = f.ActivePreset
        Next
        ' enable/disable de controlos e setvalues:
        _MainForm.RefreshSuspended() : SuspendInputEvents = True
        Dim tmpPreset0 As Preset = _MainForm.Presets(p)
        For Each c As ChannelType In ChannelTypes.Enum
            If Not Me.Controls.ContainsKey("tr" & c.ToString) Then Continue For
            With DirectCast(Me.Controls("tr" & c.ToString), TrackBar)
                Dim tmpSound As TextBox = DirectCast(Me.Controls("txtSound" & c.ToString), TextBox)
                Dim tmpSeq As TextBox = DirectCast(Me.Controls("txtSeq" & c.ToString), TextBox)
                .Visible = tmpPreset0.ChannelShow(c) = ChannelData.Modes.Show
                DirectCast(Me.Controls("lb" & c.ToString), Label).Visible = .Visible
                tmpSound.Visible = .Visible
                tmpSeq.Visible = .Visible
                If tmpPreset0.UserValue(c) >= 0 Then
                    .Value = tmpPreset0.UserValue(c) ' this fires tr_Scroll, unless StopUpdates = True
                    tmpSound.Text = tmpPreset0.SoundControllerPercent(c) ' this fires txt_TextChanged, unless StopUpdates = True
                    tmpSeq.Text = tmpPreset0.SeqControllerPercent(c) ' this fires txt_TextChanged, unless StopUpdates = True
                    For Each f As FixtureTemplate In Me.Fixtures ' this could be done automaticaly by tr_Scroll but it fails if tmpPreset0.UserValue(c)=0, because TrackBar.Value allready =0 :
                        _MainForm.Presets(f.ActivePreset).UserValue(c) = tmpPreset0.UserValue(c)
                        _MainForm.Presets(f.ActivePreset).SoundControllerPercent(c) = tmpPreset0.SoundControllerPercent(c)
                        _MainForm.Presets(f.ActivePreset).SeqControllerPercent(c) = tmpPreset0.SeqControllerPercent(c)
                    Next
                End If
            End With
        Next
        SuspendInputEvents = False
        _MainForm.Timer1_Tick(Nothing, Nothing)
    End Sub

    'Public Function UpdateFixtures() As String ' isto agora é o         _MainForm.Timer1_Tick(Nothing, Nothing)
    '    Dim tmpDebug As String = ""
    '    For Each f As FixtureTemplate In Me.Fixture
    '        tmpDebug &= f.Update()
    '    Next
    '    _MainForm.FixtureUpdated(tmpDebug)
    '    Return tmpDebug
    'End Function

    Private Sub bt_MouseDown(sender As Object, e As EventArgs)
        DirectCast(sender, Button).BackColor = Color.Red
        If _MainForm.Debug IsNot Nothing AndAlso _MainForm.Debug.Visible Then _MainForm.Debug.AppendText(Me.Text & " -> Apply Temp Preset «" & sender.tag & "»" & vbCrLf)
        For Each f As FixtureTemplate In Me.Fixtures
            f.ActivePreset = sender.tag
        Next
        _MainForm.Timer1_Tick(Nothing, Nothing)
    End Sub

    Private Sub bt_MouseUp(sender As Object, e As EventArgs)
        Dim tmpF As String = Fixtures(0).LastFixedPreset
        If tmpF > "" Then
            If _MainForm.Debug IsNot Nothing AndAlso _MainForm.Debug.Visible Then _MainForm.Debug.AppendText(Me.Text & " -> ReApply Preset «" & tmpF & "»" & vbCrLf)
            For Each f As FixtureTemplate In Me.Fixtures
                f.ActivePreset = tmpF
            Next
            _MainForm.Timer1_Tick(Nothing, Nothing)
        End If
        DirectCast(sender, Button).BackColor = SystemColors.ButtonFace
    End Sub

    Private Sub tr_Scroll(sender As Object, e As EventArgs)
        If SuspendInputEvents Then Return
        With DirectCast(sender, TrackBar)
            Dim c As ChannelType = DirectCast(.Tag, ChannelType)
            If _MainForm.Debug IsNot Nothing AndAlso _MainForm.Debug.Visible Then _MainForm.Debug.AppendText(Me.Text & " -> Set UserValue «" & c.ToString & "» = " & .Value & vbCrLf)
            For Each f As FixtureTemplate In Me.Fixtures
                _MainForm.Presets(f.ActivePreset).UserValue(c) = .Value
            Next
            'UpdateFixtures() ' no need, Timer1 is doing this every 100ms
        End With
    End Sub

    Private Sub lbSound_Click(sender As Object, e As EventArgs)
        _MainForm._frmSound.Visible = True
    End Sub

    Private Sub lbSeq_Click(sender As Object, e As EventArgs)
        _MainForm._frmSeq.Visible = True
    End Sub

    Private Sub txt_TextChanged(sender As Object, e As EventArgs)
        If SuspendInputEvents Then Return
        With DirectCast(sender, TextBox)
            Dim res As Integer = TextBoxValue(sender)
            Dim c As ChannelType = DirectCast(.Tag, ChannelType)
            For Each f As FixtureTemplate In Me.Fixtures
                If .Name.StartsWith("txtSound") Then
                    _MainForm.Presets(f.ActivePreset).SoundControllerPercent(c) = res
                ElseIf .Name.StartsWith("txtSeq") Then
                    _MainForm.Presets(f.ActivePreset).SeqControllerPercent(c) = res
                End If
            Next
            'UpdateFixtures() ' no need, Timer1 is doing this every 100ms
        End With
    End Sub


    Public Sub PaintVUs()
        If Not Me.Visible Then Return
        Dim tmpPreset0 As Preset = _MainForm.Presets(Fixtures(0).ActivePreset)
        For Each c As Control In Me.Controls
            If Not TypeOf (c) Is TrackBar Then Continue For
            If Not c.Visible Then Continue For
            Using g As Graphics = c.CreateGraphics
                Dim l As Integer = tmpPreset0.TotalValue(c.Tag) / 255 * (c.Height - 12 - 12)
                g.DrawLine(Pens.Orange, c.Width - 15, c.Height - 12, c.Width - 15, c.Height - 12 - l)
                g.DrawLine(Pens.DarkRed, c.Width - 15, c.Height - 12 - l, c.Width - 15, 12)
            End Using
        Next
        Dim cc As Control = Me.Controls("lbSound")
        Using g As Graphics = cc.CreateGraphics
            Dim l As Integer = _MainForm._frmSound.SoundController / 255 * cc.Width
            g.DrawLine(Pens.Orange, 0, cc.Height - 5, l, cc.Height - 5)
            g.DrawLine(Pens.DarkRed, l, cc.Height - 5, cc.Width, cc.Height - 5)
        End Using
        cc = Me.Controls("lbSeq")
        'Using g As Graphics = cc.CreateGraphics
        '    Dim l As Integer = _MainForm._frmSeq.SeqController / 255 * cc.Width
        '    g.DrawLine(Pens.Orange, 0, cc.Height - 5, l, cc.Height - 5)
        '    g.DrawLine(Pens.DarkRed, l, cc.Height - 5, cc.Width, cc.Height - 5)
        '    g.Dispose()
        'End Using
    End Sub


End Class

