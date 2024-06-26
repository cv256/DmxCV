﻿Public Class PresetSeq
    Public SequenceName As String, BaseSpeed As Integer, SoundSpeed As Integer, BassSpeed As Integer, Mode As String
    Public Function Serialize(pMult As Boolean) As XElement
        Dim res As New XElement("Sequencer" + If(pMult, "Mult", ""),
            New XElement("ActiveSequence", SequenceName),
            New XElement("BaseSpeed", BaseSpeed),
            New XElement("SoundSpeed", SoundSpeed),
            New XElement("BassSpeed", BassSpeed),
            New XElement("Mode", Mode)
        )
        Return res
    End Function
    Public Sub fromXML(xml As XElement, pMult As Boolean)
        Dim x = If(pMult, xml.<SequencerMult>, xml.<Sequencer>)
        SequenceName = x.<ActiveSequence>.Value
        BaseSpeed = x.<BaseSpeed>.Value
        SoundSpeed = x.<SoundSpeed>.Value
        BassSpeed = x.<BassSpeed>.Value
        Mode = x.<Mode>.Value
    End Sub
End Class

Public Class PresetSound
    Public Compressor As Integer, Delay As Integer, Noisegate As Integer, Soften As Integer, CompressorB As Integer, DelayB As Integer, NoisegateB As Integer
    Public Function Serialize() As XElement
        Dim res As New XElement("Sound",
            New XElement("Compressor", Compressor),
            New XElement("Delay", Delay),
            New XElement("Noisegate", Noisegate),
            New XElement("Soften", Soften),
            New XElement("CompressorB", CompressorB),
            New XElement("DelayB", DelayB),
            New XElement("NoisegateB", NoisegateB)
)
        Return res
    End Function
    Public Sub fromXML(xml As XElement)
        With xml
            Compressor = .<Sound>.<Compressor>.Value
            Delay = .<Sound>.<Delay>.Value
            Noisegate = .<Sound>.<Noisegate>.Value
            Soften = .<Sound>.<Soften>.Value
            CompressorB = .<Sound>.<CompressorB>.Value
            DelayB = .<Sound>.<DelayB>.Value
            NoisegateB = .<Sound>.<NoisegateB>.Value
        End With
    End Sub
End Class

Public Class Preset
    Public Name As String
    Public AffectedFixtures As New Dictionary(Of FixtureTemplate, FixtureValues)
    Public Seq As New PresetSeq
    Public SeqMult As New PresetSeq
    Public Sound As New PresetSound

    Public Sub New(xPreset As XElement)
        Name = xPreset.<Name>.Value
        Seq.fromXML(xPreset, False)
        SeqMult.fromXML(xPreset, True)
        Sound.fromXML(xPreset)
        For Each xFixt As XElement In xPreset.<AffectedFixture>
            Dim fixtureName As String = xFixt.<Name>.Value
            Dim fix As FixtureTemplate = _MainForm.Fixtures.First(Function(fff) fff.Name.ToUpper = fixtureName.ToUpper)
            If fix Is Nothing Then
                MsgBox(String.Format("<Preset> «{0}» refers <Fixture> «{1}» that does not exist on this file", Name, fixtureName), MsgBoxStyle.Critical)
                Continue For
            End If
            AffectedFixtures.Add(fix, New FixtureValues(xFixt))
        Next
    End Sub

    Public Function ChannelShow(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As ChannelData.Modes
        Dim res As ChannelData.Modes = ChannelData.Modes.Hide
        For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
            If Not pFixtures.Contains(f) Then Continue For
            If Not Me.AffectedFixtures.ContainsKey(f) Then Continue For
            If Me.AffectedFixtures(f).ChannelMode(pChannelType) = ChannelData.Modes.Hide Then Continue For
            If Me.AffectedFixtures(f).ChannelMode(pChannelType) = ChannelData.Modes.Show Then Return Me.AffectedFixtures(f).ChannelMode(pChannelType)
        Next
        Return res
    End Function

    Public Property UserValue(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As Integer
        Get
            Dim res As Integer = Channel.ValueUnkown
            For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
                If Not pFixtures.Contains(f) Then Continue For
                If Not f.Channels.ContainsKey(pChannelType) Then Continue For
                Return Me.AffectedFixtures(f).UserValue(pChannelType)
            Next
            Return res
        End Get
        Set(value As Integer)
            For Each f As KeyValuePair(Of FixtureTemplate, FixtureValues) In Me.AffectedFixtures
                If Not pFixtures.Contains(f.Key) Then Continue For
                f.Value.UserValue(pChannelType) = value
            Next
        End Set
    End Property
    Public Property SoundControllerPercent(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As Integer
        Get
            Dim res As Integer = Channel.ValueUnkown
            For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
                If Not pFixtures.Contains(f) Then Continue For
                If Not f.Channels.ContainsKey(pChannelType) Then Continue For
                Return Me.AffectedFixtures(f).SoundControllerPercent(pChannelType)
            Next
            Return res
        End Get
        Set(value As Integer)
            For Each f As KeyValuePair(Of FixtureTemplate, FixtureValues) In Me.AffectedFixtures
                If Not pFixtures.Contains(f.Key) Then Continue For
                f.Value.SoundControllerPercent(pChannelType) = value
            Next
        End Set
    End Property
    Public Property SoundControllerBassPercent(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As Integer
        Get
            Dim res As Integer = Channel.ValueUnkown
            For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
                If Not pFixtures.Contains(f) Then Continue For
                If Not f.Channels.ContainsKey(pChannelType) Then Continue For
                Return Me.AffectedFixtures(f).SoundControllerBassPercent(pChannelType)
            Next
            Return res
        End Get
        Set(value As Integer)
            For Each f As KeyValuePair(Of FixtureTemplate, FixtureValues) In Me.AffectedFixtures
                If Not pFixtures.Contains(f.Key) Then Continue For
                f.Value.SoundControllerBassPercent(pChannelType) = value
            Next
        End Set
    End Property
    Public Property SeqControllerPercent(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As Integer
        Get
            Dim res As Integer = Channel.ValueUnkown
            For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
                If Not pFixtures.Contains(f) Then Continue For
                If Not f.Channels.ContainsKey(pChannelType) Then Continue For
                Return Me.AffectedFixtures(f).SeqControllerPercent(pChannelType)
            Next
            Return res
        End Get
        Set(value As Integer)
            For Each f As KeyValuePair(Of FixtureTemplate, FixtureValues) In Me.AffectedFixtures
                If Not pFixtures.Contains(f.Key) Then Continue For
                f.Value.SeqControllerPercent(pChannelType) = value
            Next
        End Set
    End Property
    Public Property SeqControllerPercentMult(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As Integer
        Get
            Dim res As Integer = Channel.ValueUnkown
            For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
                If Not pFixtures.Contains(f) Then Continue For
                If Not f.Channels.ContainsKey(pChannelType) Then Continue For
                Return Me.AffectedFixtures(f).SeqControllerPercentMult(pChannelType)
            Next
            Return res
        End Get
        Set(value As Integer)
            For Each f As KeyValuePair(Of FixtureTemplate, FixtureValues) In Me.AffectedFixtures
                If Not pFixtures.Contains(f.Key) Then Continue For
                f.Value.SeqControllerPercentMult(pChannelType) = value
            Next
        End Set
    End Property
    Public ReadOnly Property TotalValue(pFixtures As List(Of FixtureTemplate), pChannelType As ChannelType) As Integer
        Get
            Dim res As Integer = 0
            For Each f As FixtureTemplate In Me.AffectedFixtures.Keys
                If Not pFixtures.Contains(f) Then Continue For
                If Not f.Channels.ContainsKey(pChannelType) Then Continue For
                Return Me.AffectedFixtures(f).TotalValue(pChannelType)
            Next
            Return res
        End Get
    End Property

    Friend Function Serialize() As XElement
        Dim res As New XElement("Preset",
            New XElement("Name", Name)
        )

        res.Add(Seq.Serialize(False))
        res.Add(SeqMult.Serialize(True))
        res.Add(Sound.Serialize())

        For Each f As KeyValuePair(Of FixtureTemplate, FixtureValues) In Me.AffectedFixtures
            Dim resf As New XElement("AffectedFixture",
                New XElement("Name", f.Key.Name),
                New XElement("SeqControllerIdx", f.Value.SeqControllerIdx)
            )
            For Each p As ChannelData In f.Value.Channels.Values
                Dim resp As New XElement("PresetChannel",
                    New XElement("Type", p.ChannelType.Type),
                    New XElement("Mode", p.Mode.ToString),
                    New XElement("SoundControllerPercent", p.SoundControllerPercent),
                    New XElement("SoundControllerPercentBass", p.SoundControllerBassPercent),
                    New XElement("SeqControllerPercent", p.SeqControllerPercent),
                    New XElement("SeqControllerPercentMult", p.SeqControllerPercentMult),
                    New XElement("Value", p.UserValue)
                )
                resf.Add(resp)
            Next p
            res.Add(resf)
        Next f
        Return res
    End Function
End Class



''' <summary>
''' this is kinda propertybag where I keep a fixture's values for a certain Preset, allowing me to temporarly change into a different preset and then come back to the original preset with its values
''' </summary>
Public Class FixtureValues
    Public Channels As New Dictionary(Of ChannelType, ChannelData)
    Public SeqControllerIdx As Integer

    Friend Sub New(ByVal fld As XElement)
        SeqControllerIdx = fld.<SeqControllerIdx>.Value
        For Each xPc As XElement In fld.<PresetChannel>
            Channels.Add(ChannelTypes.ByName(xPc.<Type>.Value),
                         New ChannelData(
                            ChannelTypes.ByName(xPc.<Type>.Value),
                            EnumByString(xPc.<Mode>.Value, GetType(ChannelData.Modes)),
                            CInt(xPc.<Value>.Value),
                            CInt(xPc.<SoundControllerPercent>.Value),
                            CInt(xPc.<SoundControllerPercentBass>.Value),
                            CInt(xPc.<SeqControllerPercent>.Value),
                            CInt(xPc.<SeqControllerPercentMult>.Value)
                            )
                    )
        Next
    End Sub

    Public ReadOnly Property ChannelMode(pChannelType As ChannelType) As ChannelData.Modes
        Get
            If Not Channels.ContainsKey(pChannelType) Then Return ChannelData.Modes.Ignore
            Return Channels(pChannelType).Mode
        End Get
    End Property

    Public Property UserValue(pChannelType As ChannelType) As Integer
        Get
            If Not Channels.ContainsKey(pChannelType) Then Return Channel.ValueUnkown
            Return Channels(pChannelType).UserValue
        End Get
        Set(value As Integer)
            If Not Channels.ContainsKey(pChannelType) Then Return
            Channels(pChannelType).UserValue = value
        End Set
    End Property

    Public Property SoundControllerPercent(pChannelType As ChannelType) As Integer
        Get
            If Not Channels.ContainsKey(pChannelType) Then Return 0
            Return Channels(pChannelType).SoundControllerPercent
        End Get
        Set(value As Integer)
            If Not Channels.ContainsKey(pChannelType) Then Return
            Channels(pChannelType).SoundControllerPercent = value
        End Set
    End Property
    Public Property SoundControllerBassPercent(pChannelType As ChannelType) As Integer
        Get
            If Not Channels.ContainsKey(pChannelType) Then Return 0
            Return Channels(pChannelType).SoundControllerBassPercent
        End Get
        Set(value As Integer)
            If Not Channels.ContainsKey(pChannelType) Then Return
            Channels(pChannelType).SoundControllerBassPercent = value
        End Set
    End Property

    Public Property SeqControllerPercent(pChannelType As ChannelType) As Integer
        Get
            If Not Channels.ContainsKey(pChannelType) Then Return 0
            Return Channels(pChannelType).SeqControllerPercent
        End Get
        Set(value As Integer)
            If Not Channels.ContainsKey(pChannelType) Then Return
            Channels(pChannelType).SeqControllerPercent = value
        End Set
    End Property

    Public Property SeqControllerPercentMult(pChannelType As ChannelType) As Integer
        Get
            If Not Channels.ContainsKey(pChannelType) Then Return 0
            Return Channels(pChannelType).SeqControllerPercentMult
        End Get
        Set(value As Integer)
            If Not Channels.ContainsKey(pChannelType) Then Return
            Channels(pChannelType).SeqControllerPercentMult = value
        End Set
    End Property


    ''' <summary>
    ''' 0~255
    ''' </summary>
    Public Function TotalValue(pChannelType As ChannelType) As Integer
        If Not Channels.ContainsKey(pChannelType) Then Return 0
        With Channels(pChannelType)
            Dim res = .UserValue _
                            + _MainForm._frmSound.SoundController / 100 * .SoundControllerPercent _
                            + _MainForm._frmSound.SoundControllerBass / 100 * .SoundControllerBassPercent _
                            + _MainForm._frmSeq.SeqController(SeqControllerIdx) / 100 * .SeqControllerPercent

            res = res * _MainForm._frmSeqMult.SeqController(SeqControllerIdx) / 255 * .SeqControllerPercentMult / 100 + res * (1 - .SeqControllerPercentMult / 100)

            Return Math.Max(Math.Min(res, 255), 0)
        End With
    End Function

    Public Function ValueToSend(pChannelType As ChannelType) As Integer
        If Not Channels.ContainsKey(pChannelType) Then Return Channel.ValueUnkown
        With Channels(pChannelType)
            If .UserValue < 0 Then Return Channel.ValueUnkown
            If pChannelType.Equals(ChannelTypes.Red) OrElse pChannelType.Equals(ChannelTypes.Green) OrElse pChannelType.Equals(ChannelTypes.Blue) Then
                With HSVtoRGB(TotalValue(ChannelTypes.Red) / 255 * 360, TotalValue(ChannelTypes.Green) / 2.55, TotalValue(ChannelTypes.Blue) / 2.55)
                    If pChannelType.Equals(ChannelTypes.Red) Then Return .r
                    If pChannelType.Equals(ChannelTypes.Green) Then Return .g
                    If pChannelType.Equals(ChannelTypes.Blue) Then Return .b
                End With
            End If
        End With
        Return TotalValue(pChannelType)
    End Function

End Class




Public Class ChannelData

    Public Enum Modes
        ''' <summary>
        ''' dont ever (on any preset) show to user, send to DMX
        ''' </summary>
        Hide

        ''' <summary>
        ''' show to user, dont allow him to change, dont send to DMX
        ''' </summary>
        Ignore

        ''' <summary>
        ''' show to user, dont allow him to change, send to DMX
        ''' </summary>
        [ReadOnly]

        ''' <summary>
        ''' show to user, allow him to change, send to DMX
        ''' </summary>
        Show
    End Enum


    Public ChannelType As ChannelType
    Public Mode As Modes
    Public UserValue As Integer
    'Public SoundControllerValue As Integer
    Public SoundControllerPercent As Integer
    Public SoundControllerBassPercent As Integer
    'Public SeqControllerValue As Integer
    Public SeqControllerPercent As Integer
    Public SeqControllerPercentMult As Integer

    Public Sub New(pChannelType As ChannelType, pMode As Modes, pUserValue As Integer, pSoundControllerPercent As Integer, pSoundControllerBassPercent As Integer, pSeqControllerPercent As Integer, pSeqControllerPercentMult As Integer)
        ChannelType = pChannelType
        Mode = pMode
        UserValue = pUserValue
        SoundControllerPercent = pSoundControllerPercent
        SoundControllerBassPercent = pSoundControllerBassPercent
        SeqControllerPercent = pSeqControllerPercent
        SeqControllerPercentMult = pSeqControllerPercentMult
    End Sub

End Class


