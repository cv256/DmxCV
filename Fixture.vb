Public Class FixtureTemplate
    Public Name As String, Address As Byte, Location As New Point, Rotation As Integer, FixtureModelFileName As String
    Public Channels As New Dictionary(Of ChannelType, Channel)
    Public ActivePreset As String, LastFixedPreset As String

    Public Function Update() As String
        Dim strResult As String, strDebug As String = ""
        If String.IsNullOrEmpty(ActivePreset) OrElse _MainForm.Presets.ContainsKey(ActivePreset) = False OrElse _MainForm.Presets(ActivePreset).AffectedFixtures.ContainsKey(Me) = False Then Return "NO PRESET ACTIVE"
        Dim a As FixtureValues = _MainForm.Presets(ActivePreset).AffectedFixtures(Me)
        For Each c As ChannelData In a.Channels.Values
            Dim v As Integer = a.ValueToSend(c.ChannelType)
            If v < 0 Then Continue For
            If v = Channels(c.ChannelType).LastSentValue Then Continue For
            If _Offline Then
                strResult = "offline"
                Channels(c.ChannelType).LastSentValue = v
            Else
                If ChannelSet(Address + Channels(c.ChannelType).Address, v) Then
                    Channels(c.ChannelType).LastSentValue = v
                    strResult = ""
                Else
                    strResult = "ERROR"
                End If
            End If
            strDebug &= "   Ch " & (Address + Channels(c.ChannelType).Address) & " = " & v & "   result = " & strResult & "   (" & c.ChannelType.ToString & ")" & vbCrLf
        Next
        Return strDebug
    End Function

    Public Function MyRectangle(pFormClientSize As Size) As Rectangle
        Dim fR As Decimal = 4
        Dim fX As Decimal = (pFormClientSize.Width - 7) / (100 + fR)
        Dim fY As Decimal = (pFormClientSize.Height - 35) / (100 + fR)
        fR *= fX
        Return New Rectangle(Me.Location.X * fX, Me.Location.Y * fY, fR, fR)
    End Function

    Public Function LightArea(pFormClientSize As Size) As Point()
        Dim fLen As Decimal = 93 ' percentage
        Dim fOverture As Decimal = 13 / 2 ' grads
        fLen = (pFormClientSize.Width - 7) / 100 * fLen
        With MyRectangle(pFormClientSize)
            Dim res(2) As Point
            res(0) = New Point(.X + .Width / 2, .Y + .Height / 2)
            res(1) = New Point(.X + .Width / 2 + fLen * Math.Sin((Me.Rotation + fOverture) * _Grads2Radians), .Y + .Height / 2 + fLen * -Math.Cos((Me.Rotation + fOverture) * _Grads2Radians))
            res(2) = New Point(.X + .Width / 2 + fLen * Math.Sin((Me.Rotation - fOverture) * _Grads2Radians), .Y + .Height / 2 + fLen * -Math.Cos((Me.Rotation - fOverture) * _Grads2Radians))
            Return res
        End With
    End Function

    Public Function LightBrush() As Brush
        If Channels(ChannelTypes.Mode).LastSentValue <> 0 Then Return New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Cross, Color.Gray)
        If Channels(ChannelTypes.Red).LastSentValue < 0 OrElse Channels(ChannelTypes.Red).LastSentValue > 255 _
            OrElse Channels(ChannelTypes.Green).LastSentValue < 0 OrElse Channels(ChannelTypes.Green).LastSentValue > 255 _
            OrElse Channels(ChannelTypes.Blue).LastSentValue < 0 OrElse Channels(ChannelTypes.Blue).LastSentValue > 255 _
            OrElse Channels(ChannelTypes.Intensity).LastSentValue < 0 OrElse Channels(ChannelTypes.Intensity).LastSentValue > 255 _
            Then Return New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Cross, Color.Gray)
        ' todo: misturar o WHITE com as cores
        Return New SolidBrush(Color.FromArgb(Channels(ChannelTypes.Intensity).LastSentValue / 1.5, Channels(ChannelTypes.Red).LastSentValue, Channels(ChannelTypes.Green).LastSentValue, Channels(ChannelTypes.Blue).LastSentValue))
    End Function

    Friend Sub New(ByVal fld As XElement)
        With fld
            Name = .<Name>.Value
            Address = .<Address>.Value
            Location = New Point(.<LocationXPercent>.Value, .<LocationYPercent>.Value)
            Rotation = .<RotationDegrees>.Value
            FixtureModelFileName = .<FixtureModelFileName>.Value
            If Not FixtureModelFileName.Contains(":") AndAlso _MainForm.DefaultPath > "" Then FixtureModelFileName = _MainForm.DefaultPath & "\" & FixtureModelFileName
            Try
                Dim xDoc As XDocument
                xDoc = XDocument.Load(FixtureModelFileName)
                With xDoc.<DMXCVFixtureModel>
                    For Each xC As XElement In .<Channel>
                        Dim c As New Channel(ChannelTypes.ByName(xC.<Type>.Value), CByte(xC.<Address>.Value))
                        Channels.Add(c.Type, c)
                    Next
                End With
            Catch ex As Exception
                MsgBox("Problem loading fixture" & vbCrLf & fld.ToString & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical)
                End
            End Try

            If Channels.Count < 1 Then
                MsgBox(String.Format("FixtureModel «{0}» used by «{1}» needs to have some <Channel> !", FixtureModelFileName, Name), MsgBoxStyle.Critical)
                End
            End If

            LastFixedPreset = .<LastFixedPreset>.Value
        End With
    End Sub
    Friend Function Serialize() As XElement
        Dim res As New XElement("Fixture",
            New XElement("Name", Name),
            New XElement("Address", Address),
            New XElement("LocationXPercent", Location.X),
            New XElement("LocationYPercent", Location.Y),
            New XElement("RotationDegrees", Rotation),
            New XElement("FixtureModelFileName", FixtureModelFileName),
            New XElement("LastFixedPreset", LastFixedPreset)
        )
        Return res
    End Function
End Class




Public Class ChannelType
    Public Type As String
    Public Sub New(pType As String)
        Type = pType
    End Sub
    Public Function Description() As String
        If Me.Type = "Red" Then Return "Hue"
        If Me.Type = "Green" Then Return "Satur."
        If Me.Type = "Blue" Then Return "Lumin."
        Return Me.Type.ToString
    End Function
    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj.type = Me.Type
    End Function
    Public Shadows Function ToString() As String
        Return Me.Type
    End Function
End Class

Public Class ChannelTypes
    Public Shared ReadOnly Mode As New ChannelType("Mode")
    Public Shared ReadOnly SubMode As New ChannelType("SubMode")
    Public Shared ReadOnly Red As New ChannelType("Red")
    Public Shared ReadOnly Green As New ChannelType("Green")
    Public Shared ReadOnly Blue As New ChannelType("Blue")
    Public Shared ReadOnly White As New ChannelType("White")
    Public Shared ReadOnly Speed As New ChannelType("Speed")
    Public Shared ReadOnly Intensity As New ChannelType("Intensity")
    Public Shared Function [Enum]() As List(Of ChannelType)
        Dim res As New List(Of ChannelType)
        res.Add(Mode)
        res.Add(SubMode)
        res.Add(Red)
        res.Add(Green)
        res.Add(Blue)
        res.Add(White)
        res.Add(Speed)
        res.Add(Intensity)
        Return res
    End Function
    Public Shared Function ByName(pName As String) As ChannelType
        Return [Enum].First(Function(f) f.Type = pName)
    End Function
End Class


Public Class Channel
    Public Const ValueUnkown = -1
    Public Type As ChannelType
    Public Address As Byte
    Public LastSentValue As Integer

    Public Sub New(pType As ChannelType, pAddress As Byte)
        Type = pType
        Address = pAddress
        LastSentValue = ValueUnkown
    End Sub

End Class

