﻿Module Utils

    Public dmx As New clDMX
    Public _Offline As Boolean
    Public _MainForm As MainForm
    Public _Grads2Radians As Single = Math.PI / 180

    Public Function EnumByString(pTypeDescr As String, pType As System.Type) As Integer
        Dim i As Integer = 0, res As String = ""
        For Each t In System.Enum.GetNames(pType)
            If t = pTypeDescr Then Return i
            res &= vbCrLf & t
            i += 1
        Next
        MsgBox(String.Format("«{0}» is not a suported {1}", pTypeDescr, pType.ToString) & vbCrLf & vbCrLf & "Possible values would be:" & res, MsgBoxStyle.Critical)
        End
    End Function



    Public Structure RGB
        Public r As Integer ' 0~255
        Public g As Integer ' 0~255
        Public b As Integer ' 0~255
    End Structure
    Public Structure HSV
        Public h As Integer ' 0~360
        Public s As Integer ' 0~100
        Public v As Integer ' 0~100
    End Structure

    Public Function RGBtoHSV(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As HSV
        ''# Normalize the RGB values by scaling them to be between 0 and 1
        Dim red As Decimal = R / 255D
        Dim green As Decimal = G / 255D
        Dim blue As Decimal = B / 255D

        Dim minValue As Decimal = Math.Min(red, Math.Min(green, blue))
        Dim maxValue As Decimal = Math.Max(red, Math.Max(green, blue))
        Dim delta As Decimal = maxValue - minValue

        Dim h As Decimal
        Dim s As Decimal
        Dim v As Decimal = maxValue

        ''# Calculate the hue (in degrees of a circle, between 0 and 360)
        Select Case maxValue
            Case red
                If green >= blue Then
                    If delta = 0 Then
                        h = 0
                    Else
                        h = 60 * (green - blue) / delta
                    End If
                ElseIf green < blue Then
                    h = 60 * (green - blue) / delta + 360
                End If
            Case green
                h = 60 * (blue - red) / delta + 120
            Case blue
                h = 60 * (red - green) / delta + 240
        End Select

        ''# Calculate the saturation (between 0 and 1)
        If maxValue = 0 Then
            s = 0
        Else
            s = 1D - (minValue / maxValue)
        End If

        ''# Scale the saturation and value to a percentage between 0 and 100
        s *= 100
        v *= 100

        ''# Return a color in the new color space
        Return New HSV With {.h = CInt(Math.Round(h, MidpointRounding.AwayFromZero)),
                            .s = CInt(Math.Round(s, MidpointRounding.AwayFromZero)),
                            .v = CInt(Math.Round(v, MidpointRounding.AwayFromZero))}
    End Function


    Public Function HSVtoRGB(ByVal H As Integer, ByVal S As Integer, ByVal V As Integer) As RGB
        ''# Scale the Saturation and Value components to be between 0 and 1
        Dim hue As Decimal = H
        Dim sat As Decimal = S / 100D
        Dim val As Decimal = V / 100D

        Dim r As Decimal
        Dim g As Decimal
        Dim b As Decimal

        If sat = 0 Then
            ''# If the saturation is 0, then all colors are the same.
            ''# (This is some flavor of gray.)
            r = val
            g = val
            b = val
        Else
            ''# Calculate the appropriate sector of a 6-part color wheel
            Dim sectorPos As Decimal = hue / 60D
            Dim sectorNumber As Integer = CInt(Math.Floor(sectorPos))

            ''# Get the fractional part of the sector
            ''# (that is, how many degrees into the sector you are)
            Dim fractionalSector As Decimal = sectorPos - sectorNumber

            ''# Calculate values for the three axes of the color
            Dim p As Decimal = val * (1 - sat)
            Dim q As Decimal = val * (1 - (sat * fractionalSector))
            Dim t As Decimal = val * (1 - (sat * (1 - fractionalSector)))

            ''# Assign the fractional colors to red, green, and blue
            ''# components based on the sector the angle is in
            Select Case sectorNumber
                Case 0, 6
                    r = val
                    g = t
                    b = p
                Case 1
                    r = q
                    g = val
                    b = p
                Case 2
                    r = p
                    g = val
                    b = t
                Case 3
                    r = p
                    g = q
                    b = val
                Case 4
                    r = t
                    g = p
                    b = val
                Case 5
                    r = val
                    g = p
                    b = q
            End Select
        End If

        ''# Scale the red, green, and blue values to be between 0 and 255
        r *= 255
        g *= 255
        b *= 255

        ''# Return a color in the new color space
        Return New RGB With {.r = CInt(Math.Round(r, MidpointRounding.AwayFromZero)),
                            .g = CInt(Math.Round(g, MidpointRounding.AwayFromZero)),
                            .b = CInt(Math.Round(b, MidpointRounding.AwayFromZero))}
    End Function

    Public Function TextBoxValue(sender As TextBox) As Integer
        With sender
            Dim res As Integer = -99999
            If .Text = "-" Or .Text = "" Then
                res = 0
            Else
                Try
                    res = CInt(.Text)
                Catch ex As Exception
                End Try
                If res > 100 OrElse res < -100 Then
                    res = 0
                    .Text = ""
                End If
            End If
            Return res
        End With
    End Function

End Module
