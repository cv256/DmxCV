﻿Imports NAudio

Public Class frmSound

    Public SoundController As Integer
    Public maxInput As Byte

    Private myCapturer 'As Wave.WaveIn
    Private lastMax As New Queue(Of Byte)

    Public Sub Init(pDevice As String, pCompressor As Integer, pDelay As Integer, pNoisegate As Integer, pBeat As Integer)
        cmbDevices.Items.Clear()
        cmbDevices.Items.Add("Loopback")
        For i As Integer = 0 To Wave.WaveIn.DeviceCount - 1
            Dim deviceInfo As Wave.WaveInCapabilities = Wave.WaveIn.GetCapabilities(i)
            cmbDevices.Items.Add(deviceInfo.ProductName)
            If deviceInfo.ProductName = pDevice Then cmbDevices.SelectedIndex = cmbDevices.Items.Count - 1
        Next
        If cmbDevices.SelectedIndex < 0 AndAlso cmbDevices.Items.Count > 0 Then cmbDevices.SelectedIndex = 0

        trCompressor.Value = Math.Min(Math.Max(pCompressor, trCompressor.Minimum), trCompressor.Maximum)
        trDelay.Value = Math.Min(Math.Max(pDelay, trDelay.Minimum), trDelay.Maximum)
        trNoise.Value = Math.Min(Math.Max(pNoisegate, trNoise.Minimum), trNoise.Maximum)
        trBeat.Value = Math.Min(Math.Max(pBeat, trBeat.Minimum), trBeat.Maximum)

        chkMonitor.Checked = True
        Me.TopMost = True
    End Sub

    Private Sub cmbDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDevices.SelectedIndexChanged
        chkMonitor.Checked = False
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub

    Private Sub chkMonitor_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonitor.CheckedChanged
        If chkMonitor.Checked Then
            If cmbDevices.SelectedIndex < 0 Then
                MsgBox("Configure o dispositivo de entrada de som")
                chkMonitor.Checked = False
                Return
            End If
            If myCapturer Is Nothing Then
                If cmbDevices.SelectedIndex = 0 Then
                    myCapturer = New Wave.WasapiLoopbackCapture()
                    'myCapturer.WaveFormat = New Wave.WaveFormat(rate:=8000, bits:=8, channels:=1)
                    'myCapturer.BufferMilliseconds = _RefreshRate ' recommended=100ms=10fps   100BPM=600ms=1,7fps   200BPM=300ms=3fps
                    AddHandler DirectCast(myCapturer, Wave.WasapiLoopbackCapture).DataAvailable, AddressOf Loopback_DataAvailable
                Else
                    myCapturer = New Wave.WaveIn()
                    myCapturer.DeviceNumber = cmbDevices.SelectedIndex - 1
                    myCapturer.WaveFormat = New Wave.WaveFormat(rate:=8000, bits:=8, channels:=1)
                    myCapturer.BufferMilliseconds = _MainForm.RefreshRate ' recommended=100ms=10fps   100BPM=600ms=1,7fps   200BPM=300ms=3fps
                    AddHandler DirectCast(myCapturer, Wave.WaveIn).DataAvailable, AddressOf waveIn_DataAvailable
                End If
            End If
            Try
                myCapturer.StartRecording()
                chkMonitor.BackColor = Color.Orange
            Catch ex As Exception
                MsgBox(TypeName(ex) & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                chkMonitor.Checked = False
            End Try
        Else
            If myCapturer IsNot Nothing Then
                myCapturer.StopRecording()
                myCapturer.Dispose()
                myCapturer = Nothing
                chkMonitor.BackColor = SystemColors.Control
            End If
        End If
    End Sub

    Private Sub waveIn_DataAvailable(sender As Object, e As Wave.WaveInEventArgs)
        'Dim maxInput As Byte = 0 ' Max over myCapturer.BufferMilliseconds 0~128
        For i As Integer = 0 To e.BytesRecorded - 1
            If Math.Abs(e.Buffer(i) - 128) > maxInput Then maxInput = Math.Abs(e.Buffer(i) - 128)
        Next
    End Sub

    Private Sub Loopback_DataAvailable(sender As Object, e As Wave.WaveInEventArgs)
        'Dim maxInput As Byte = 0 ' Max over myCapturer.BufferMilliseconds 0~128
        For i As Integer = 0 To e.BytesRecorded - 1 Step 8 ' buffered as 4 bytes per channel, 2 channels, I want just the MSB of 1 of the channels
            Dim v As Byte = Math.Abs(BitConverter.ToSingle(e.Buffer, i)) * 128
            If v > maxInput Then maxInput = v
        Next
    End Sub

    Public Sub CalculateSoundController()
        lastMax.Enqueue(maxInput)
        ' Compressor:
        Dim compressionLevel As Decimal = trCompressor.Value, beatPercent As Decimal = 0
        Dim compressionDelay As Decimal = trDelay.Value ^ 2
        Dim maxOverBPM As Byte = 0, minOverBPM As Byte = 255 ' 0~128
        For Each m As Byte In lastMax
            If m > maxOverBPM Then maxOverBPM = m
            If m < minOverBPM Then minOverBPM = m
        Next
        Do While lastMax.Count > compressionDelay / _MainForm.RefreshRate
            lastMax.Dequeue()
        Loop
        Dim amplificationFactor As Decimal = 1
        If maxInput <= trNoise.Value Then
            amplificationFactor = 0.5
        Else
            If compressionLevel > 0 Then amplificationFactor = (128 + 128 - compressionLevel + 1) / (maxOverBPM + 128 - compressionLevel + 1)
        End If
        Dim tmpMid As Decimal = minOverBPM + (maxInput - minOverBPM) / 2
        If (maxOverBPM - minOverBPM) <> 0 Then beatPercent = Math.Max(((maxInput - tmpMid) / (maxOverBPM - tmpMid)), 0) ' 0 ~ 1
        SoundController = Math.Max(Math.Min(maxInput * amplificationFactor * 2 * ((1 - trBeat.Value / 100) + beatPercent * trBeat.Value / 100), 255), 0) '  0~255

        ' graphs:
        If Me.Visible Then
            Label1.Text = "Compressor " & (compressionLevel / 128 * 100).ToString("0.00") & "% :"
            Label3.Text = "Delay " & compressionDelay.ToString("0") & " ms :" & lastMax.Count
            Label4.Text = "Factor x " & amplificationFactor.ToString("0.00") & " :"
            Label5.Text = "Beat " & trBeat.Value & "% :"
            With Me.CreateGraphics
                Dim tmpMax As Integer = maxInput / 128 * cmbDevices.Width
                .FillRectangle(Brushes.Yellow, cmbDevices.Left, chkMonitor.Top + 2, tmpMax, 8)
                .FillRectangle(Brushes.DimGray, cmbDevices.Left + tmpMax, chkMonitor.Top + 2, cmbDevices.Width - tmpMax, 8)

                tmpMax = Math.Min(amplificationFactor / 30, 1) * trDelay.Width
                .DrawLine(Pens.Blue, cmbDevices.Left, Label4.Bottom + 2, cmbDevices.Left + tmpMax, Label4.Bottom + 2)
                .DrawLine(Pens.DimGray, cmbDevices.Left + tmpMax, Label4.Bottom + 2, cmbDevices.Right, Label4.Bottom + 2)

                tmpMax = beatPercent * trDelay.Width
                .DrawLine(Pens.Blue, cmbDevices.Left, Label6.Bottom + 2, cmbDevices.Left + tmpMax, Label6.Bottom + 2)
                .DrawLine(Pens.DimGray, cmbDevices.Left + tmpMax, Label6.Bottom + 2, cmbDevices.Right, Label6.Bottom + 2)

                tmpMax = SoundController / 255 * cmbDevices.Width
                .FillRectangle(Brushes.Red, cmbDevices.Left, chkMonitor.Bottom - 10, tmpMax, 8)
                .FillRectangle(Brushes.DimGray, cmbDevices.Left + tmpMax, chkMonitor.Bottom - 10, cmbDevices.Width - tmpMax, 8)

                .Dispose()
            End With
        End If
        maxInput = 0
    End Sub

    Friend Function Serialize() As XElement
        Dim res As New XElement("Sound",
            New XElement("Device", cmbDevices.SelectedItem),
            New XElement("Compressor", trCompressor.Value),
            New XElement("Delay", trDelay.Value),
            New XElement("Noisegate", trNoise.Value),
            New XElement("Beat", trBeat.Value)
        )
        Return res
    End Function

End Class