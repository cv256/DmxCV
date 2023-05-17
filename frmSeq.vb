Public Class frmSeq

    Private ReadOnly Sequences As New List(Of Sequence)
    Private ActiveSequence As Sequence, SequencePosition As Decimal
    Private ReadOnly SeqControllers As New List(Of Integer)
    Private PresetSeq As PresetSeq

    ''' <summary>
    ''' 0~255
    ''' </summary>
    Public ReadOnly Property SeqController(cIdx As Integer) As Integer
        Get
            Return SeqControllers(IIf(rdFlood.Checked, 0, cIdx))
        End Get
    End Property

    Public Sub Init(pPresetSeq As PresetSeq)
        PresetSeq = pPresetSeq
        If SeqControllers.Count = 0 Then
            ' Inits 4 controller channels:
            For cIdx As Integer = 1 To _MainForm.Fixtures.Count : SeqControllers.Add(0) : Next

            ' Create the available Sequences:
            Dim tmpS As Sequence

            tmpS = New Sequence With {.Name = "Rainbow", .PreviewMode = Sequence.PreviewModes.Color} ' , .Distance = 256 / 4, .SpeedFactor = 1
            For i As Integer = 0 To 255 : tmpS.Values.Add(i) : Next i
            Sequences.Add(tmpS)

            tmpS = New Sequence With {.Name = "Wave", .PreviewMode = Sequence.PreviewModes.Color} ' , .Distance = 256 / 4, .SpeedFactor = 1
            For i As Integer = 0 To 255 : tmpS.Values.Add(127 + Math.Sin(i / 255 * Math.PI * 2) * 127) : Next i
            Sequences.Add(tmpS)

            tmpS = New Sequence With {.Name = "Chase soft", .PreviewMode = Sequence.PreviewModes.Power} ' , .Distance = 256 / 4, .SpeedFactor = 1
            For i As Integer = 0 To 255 : tmpS.Values.Add(If(i > (320 / SeqControllers.Count), 0, Math.Sin(i / (320 / SeqControllers.Count) * Math.PI) * 255)) : Next
            Sequences.Add(tmpS)

            tmpS = New Sequence With {.Name = "Chase", .PreviewMode = Sequence.PreviewModes.Power} ' , .Distance = 1, .SpeedFactor = 0.02
            For i As Integer = 0 To 255 : tmpS.Values.Add(If(i > (255 / SeqControllers.Count), 0, 255)) : Next
            Sequences.Add(tmpS)

            ' Init the Form:
            lstSeq.Items.AddRange(Sequences.ToArray)
            'If lstSeq.Items.Count > 0 Then lstSeq.SelectedIndex = 0
            Me.TopMost = True
        End If

        ' LoadConfiguration:
        For Each s In lstSeq.Items
            If DirectCast(s, Sequence).Name = pPresetSeq.SequenceName Then
                lstSeq.SelectedItem = s
                Exit For
            End If
        Next
        trSpeed.Value = pPresetSeq.BaseSpeed
        trSound.Value = pPresetSeq.SoundSpeed
        trBass.Value = pPresetSeq.BassSpeed
        If Not String.IsNullOrEmpty(pPresetSeq.Mode) Then
            If pPresetSeq.Mode.ToUpper = "FLOOD" Then rdFlood.Checked = True
            If pPresetSeq.Mode.ToUpper = "CHASE" Then rdChase.Checked = True
        End If
    End Sub

    Public Sub Advance()
        If ActiveSequence Is Nothing Then Return
        Dim tmpSpeed As Integer = Math.Min(450, PresetSeq.BaseSpeed + PresetSeq.SoundSpeed / 60 * _MainForm._frmSound.SoundController + PresetSeq.BassSpeed / 60 * _MainForm._frmSound.SoundControllerBass)
        Using g As Graphics = trBass.CreateGraphics
            Dim l As Integer = Math.Min(255, tmpSpeed) / 255 * (trBass.Height - 12 - 12)
            g.DrawLine(Pens.Orange, trBass.Width - 2, trBass.Height - 12, trBass.Width - 2, trBass.Height - 12 - l)
            g.DrawLine(Pens.DarkRed, trBass.Width - 2, trBass.Height - 12 - l, trBass.Width - 2, 12)
        End Using

        SequencePosition += tmpSpeed ^ 1.5 / 80 '* ActiveSequence.SpeedFactor ' speed=255 <=> 4 full cycles per second @ timer.interval=50ms
        SequencePosition = TurnAround(SequencePosition)
        Dim i As Integer = Math.Truncate(SequencePosition)
        Dim sweepAngle As Single = IIf(rdFlood.Checked, 360, 360 / SeqControllers.Count)
        With Panel1.CreateGraphics
            For cIdx As Integer = 0 To IIf(rdFlood.Checked, 0, SeqControllers.Count - 1)
                SeqControllers(cIdx) = ActiveSequence.Values(i)
                Dim rgb As RGB
                Select Case ActiveSequence.PreviewMode
                    Case Sequence.PreviewModes.Color
                        rgb = HSVtoRGB(SeqController(cIdx) / 255 * 360, 100, 100)
                    Case Sequence.PreviewModes.PowerColor
                        rgb = HSVtoRGB(SeqController(cIdx) / 255 * 360, 100, 10 + SeqController(cIdx) / 255 * 90)
                    Case Else
                        rgb = New RGB With {.r = SeqController(cIdx), .g = SeqController(cIdx), .b = SeqController(cIdx)}
                End Select
                .FillPie(New SolidBrush(Color.FromArgb(rgb.r, rgb.g, rgb.b)), Panel1.ClientRectangle, sweepAngle * (cIdx - 2), sweepAngle)
                i = TurnAround(i + (256 / SeqControllers.Count))
            Next
        End With
    End Sub

    Private Function TurnAround(pInput As Decimal) As Decimal
        Do While Math.Truncate(pInput) < 0
            pInput += ActiveSequence.Values.Count
        Loop
        Do While Math.Truncate(pInput) > ActiveSequence.Values.Count - 1
            pInput -= ActiveSequence.Values.Count
        Loop
        Return pInput
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub


    Private Sub frmSeq_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If ActiveSequence Is Nothing Then Return
        With e.Graphics
            Dim xcenter As Decimal = Me.ClientRectangle.Width / 2, ycenter As Decimal = Me.ClientRectangle.Height / 2, angle As Decimal
            .Clear(Me.BackColor)
            For i As Decimal = 0 To ActiveSequence.Values.Count - 1
                angle = i / ActiveSequence.Values.Count * Math.PI * 2
                Dim rgb As RGB = HSVtoRGB(ActiveSequence.Values(i) / 255 * 360, 100, 100)
                .DrawLine(New Pen(Color.FromArgb(rgb.r, rgb.g, rgb.b), 7), xcenter + CInt(xcenter * 0.9 * Math.Cos(angle)), ycenter + CInt(ycenter * 0.9 * Math.Sin(angle)), xcenter + CInt(xcenter * Math.Cos(angle)), ycenter + CInt(ycenter * Math.Sin(angle)))
                .DrawLine(New Pen(Color.FromArgb(ActiveSequence.Values(i), ActiveSequence.Values(i), ActiveSequence.Values(i)), 6), xcenter + CInt(xcenter * 0.8 * Math.Cos(angle)), ycenter + CInt(ycenter * 0.8 * Math.Sin(angle)), xcenter + CInt(xcenter * 0.9 * Math.Cos(angle)), ycenter + CInt(ycenter * 0.9 * Math.Sin(angle)))
            Next
        End With
    End Sub

    Private Sub lstSeq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSeq.SelectedIndexChanged
        Dim s = lstSeq.SelectedItem
        If s Is Nothing Then Return
        SequencePosition = 0
        ActiveSequence = s
        PresetSeq.SequenceName = DirectCast(s, Sequence).Name
        Me.Refresh()
    End Sub

    Private Sub trSpeed_Scroll(sender As Object, e As EventArgs) Handles trSpeed.Scroll
        If PresetSeq IsNot Nothing Then PresetSeq.BaseSpeed = trSpeed.Value
    End Sub
    Private Sub trSound_Scroll(sender As Object, e As EventArgs) Handles trSound.Scroll
        If PresetSeq IsNot Nothing Then PresetSeq.SoundSpeed = trSound.Value
    End Sub
    Private Sub trBass_Scroll(sender As Object, e As EventArgs) Handles trBass.Scroll
        If PresetSeq IsNot Nothing Then PresetSeq.BassSpeed = trBass.Value
    End Sub

    Private Sub rdChase_CheckedChanged(sender As Object, e As EventArgs) Handles rdChase.CheckedChanged
        If PresetSeq IsNot Nothing Then PresetSeq.Mode = "CHASE"
    End Sub
    Private Sub rdFlood_CheckedChanged(sender As Object, e As EventArgs) Handles rdFlood.CheckedChanged
        If PresetSeq IsNot Nothing Then PresetSeq.Mode = "FLOOD"
    End Sub



    Private Class Sequence
        Public Name As String
        Public ReadOnly Values As New List(Of Integer) ' 0~255
        '        Public Distance As Integer
        '       Public SpeedFactor As Decimal
        Public PreviewMode As PreviewModes
        Public Enum PreviewModes
            Power
            PowerColor
            Color
        End Enum
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class


End Class