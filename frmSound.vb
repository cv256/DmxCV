﻿Imports NAudio

Public Class frmSound

    Public SoundController As Integer, SoundControllerBass As Integer ' 0~255
    Public maxInput As Byte, maxInputBass As Byte

    Private myCapturer 'As Wave.WaveIn
    Private myLowpass As Dsp.BiQuadFilter
    Private lastMax As New Queue(Of Byte), lastMaxB As New Queue(Of Byte)
    Private PresetSound As PresetSound

    Public Sub SetDevice(deviceName As String)
        cmbDevices.Items.Clear()
        cmbDevices.Items.Add("Loopback")
        For i As Integer = 0 To Wave.WaveIn.DeviceCount - 1
            Dim deviceInfo As Wave.WaveInCapabilities = Wave.WaveIn.GetCapabilities(i)
            cmbDevices.Items.Add(deviceInfo.ProductName)
            If deviceInfo.ProductName.ToUpper = deviceName.ToUpper Then cmbDevices.SelectedIndex = cmbDevices.Items.Count - 1
        Next
        If cmbDevices.SelectedIndex < 0 AndAlso cmbDevices.Items.Count > 0 Then cmbDevices.SelectedIndex = 0

        chkMonitor.Checked = True
        Me.TopMost = True
    End Sub

    Public Sub Init(pPresetSound As PresetSound)
        PresetSound = pPresetSound
        trCompressor.Value = Math.Min(Math.Max(PresetSound.Compressor, trCompressor.Minimum), trCompressor.Maximum)
        trDelay.Value = Math.Min(Math.Max(PresetSound.Delay, trDelay.Minimum), trDelay.Maximum)
        trNoise.Value = Math.Min(Math.Max(PresetSound.Noisegate, trNoise.Minimum), trNoise.Maximum)
        trSoften.Value = Math.Min(Math.Max(PresetSound.Soften, trSoften.Minimum), trSoften.Maximum)
        trCompressorB.Value = Math.Min(Math.Max(PresetSound.CompressorB, trCompressorB.Minimum), trCompressorB.Maximum)
        trDelayB.Value = Math.Min(Math.Max(PresetSound.Delayb, trDelayB.Minimum), trDelayB.Maximum)
        trNoiseB.Value = Math.Min(Math.Max(PresetSound.Noisegateb, trNoiseB.Minimum), trNoiseB.Maximum)
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
                    myCapturer.BufferMilliseconds = _MainForm.RefreshRate
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
            myLowpass = Nothing
            If myCapturer IsNot Nothing Then
                myCapturer.StopRecording()
                myCapturer.Dispose()
                myCapturer = Nothing
                chkMonitor.BackColor = SystemColors.Control
            End If
        End If
    End Sub

    Private Sub waveIn_DataAvailable(sender As Object, e As Wave.WaveInEventArgs)
        DataAvailable(e, sender.WaveFormat.BlockAlign, sender.WaveFormat.SampleRate)
    End Sub

    Private Sub Loopback_DataAvailable(sender As NAudio.Wave.WasapiLoopbackCapture, e As Wave.WaveInEventArgs)
        DataAvailable(e, sender.WaveFormat.BlockAlign, sender.WaveFormat.SampleRate)
    End Sub

    Private Sub trCompressor_Scroll(sender As Object, e As EventArgs) Handles trCompressor.Scroll
        PresetSound.Compressor = trCompressor.Value
    End Sub

    Private Sub trDelay_Scroll(sender As Object, e As EventArgs) Handles trDelay.Scroll
        PresetSound.Delay = trDelay.Value
    End Sub

    Private Sub trNoise_Scroll(sender As Object, e As EventArgs) Handles trNoise.Scroll
        PresetSound.Noisegate = trNoise.Value
    End Sub

    Private Sub trCompressorB_Scroll(sender As Object, e As EventArgs) Handles trCompressorB.Scroll
        PresetSound.CompressorB = trCompressorB.Value
    End Sub

    Private Sub trDelayB_Scroll(sender As Object, e As EventArgs) Handles trDelayB.Scroll
        PresetSound.DelayB = trDelayB.Value
    End Sub

    Private Sub trSoften_Scroll(sender As Object, e As EventArgs) Handles trSoften.Scroll
        PresetSound.Soften = trSoften.Value
    End Sub

    Private Sub trNoiseB_Scroll(sender As Object, e As EventArgs) Handles trNoiseB.Scroll
        PresetSound.NoisegateB = trNoiseB.Value
    End Sub


    Private Sub DataAvailable(e As Wave.WaveInEventArgs, pBlockAlign As Integer, pSampleRate As Integer)
        'Dim maxInput As Byte = 0 ' Max over myCapturer.BufferMilliseconds 0~128

        If e.BytesRecorded = 0 Then Return

        If myLowpass Is Nothing Then myLowpass = NAudio.Dsp.BiQuadFilter.LowPassFilter(pSampleRate, 80, 0.7)

        Dim thisSample As Single
        For i As Integer = 1 To e.BytesRecorded Step pBlockAlign
            If pBlockAlign = 1 Then
                thisSample = e.Buffer(i - 1) - 128
            Else
                thisSample = BitConverter.ToSingle(e.Buffer, i - 1) * 128
            End If
            If Math.Abs(thisSample) > maxInput Then maxInput = Math.Abs(thisSample)

            thisSample = myLowpass.Transform(thisSample)
            If Math.Abs(thisSample) > maxInputBass Then maxInputBass = Math.Abs(thisSample)
        Next
    End Sub

    Public Sub CalculateSoundController()
        lastMax.Enqueue(maxInput)
        ' Compressor:
        Dim CompressionLevel As Decimal = PresetSound.Compressor
        Dim compressionDelay As Decimal = PresetSound.Delay ^ 2
        Dim maxOverBPM As Byte = lastMax.Max(Function(v) v)  ' 0~128
        Do While lastMax.Count > compressionDelay / _MainForm.RefreshRate
            lastMax.Dequeue()
        Loop
        Dim amplificationFactor As Decimal = 1
        If maxInput < trNoise.Value Then
            amplificationFactor = 0.5
            lbNoise.ForeColor = Color.Red
        Else
            If CompressionLevel > 0 Then amplificationFactor = (128 + 128 - CompressionLevel + 1) / (maxOverBPM + 128 - CompressionLevel + 1)
            lbNoise.ForeColor = Color.White
        End If
        SoundController = Math.Max(Math.Min(SoundController * (PresetSound.Soften / 100) + (maxInput * amplificationFactor * 2) * (1 - (PresetSound.Soften / 100)), 255), 0) '  0~255

        lastMaxB.Enqueue(maxInputBass)
        ' Compressor:
        Dim CompressionLevelB As Decimal = PresetSound.CompressorB
        Dim compressionDelayB As Decimal = PresetSound.DelayB ^ 2
        maxOverBPM = lastMaxB.Max(Function(v) v)  ' 0~128
        Do While lastMaxB.Count > compressionDelayB / _MainForm.RefreshRate
            lastMaxB.Dequeue()
        Loop
        Dim amplificationFactorB As Decimal = 1
        If maxInputBass < trNoiseB.Value Then
            amplificationFactorB = 0.5
            lbNoiseb.ForeColor = Color.Red
        Else
            If CompressionLevelB > 0 Then amplificationFactorB = (128 + 128 - CompressionLevelB + 1) / (maxOverBPM + 128 - CompressionLevelB + 1)
            lbNoiseb.ForeColor = Color.White
        End If
        SoundControllerBass = Math.Max(Math.Min(maxInputBass * amplificationFactorB * 4, 255), 0) ^ 4 / 16581375 '  0~255

        ' graphs:
        If Me.Visible Then
            Label1.Text = "Compressor " & (CompressionLevel / 128 * 100).ToString("0.00") & "% :"
            Label3.Text = "Delay " & compressionDelay.ToString("0") & " ms :" & lastMax.Count
            Label4.Text = "Factor x " & amplificationFactor.ToString("0.00") & " :"
            Label8.Text = "Compressor " & (CompressionLevelB / 128 * 100).ToString("0.00") & "% :"
            Label7.Text = "Delay " & compressionDelayB.ToString("0") & " ms :" & lastMax.Count
            Label4B.Text = "Factor x " & amplificationFactorB.ToString("0.00") & " :"
            With Me.CreateGraphics
                Dim tmpMax As Integer = maxInput / 128 * cmbDevices.Width
                .DrawLine(Pens.Yellow, cmbDevices.Left, cmbDevices.Bottom + 2, cmbDevices.Left + tmpMax, cmbDevices.Bottom + 2)
                .DrawLine(Pens.DimGray, cmbDevices.Left + tmpMax, cmbDevices.Bottom + 2, cmbDevices.Right, cmbDevices.Bottom + 2)

                tmpMax = Math.Min(amplificationFactor / 30, 1) * trDelay.Width
                .DrawLine(Pens.Blue, cmbDevices.Left, Label4.Bottom + 2, cmbDevices.Left + tmpMax, Label4.Bottom + 2)
                .DrawLine(Pens.DimGray, cmbDevices.Left + tmpMax, Label4.Bottom + 2, cmbDevices.Right, Label4.Bottom + 2)
                tmpMax = Math.Min(amplificationFactorB / 30, 1) * trDelay.Width
                .DrawLine(Pens.Blue, cmbDevices.Left, Label4B.Bottom + 2, cmbDevices.Left + tmpMax, Label4B.Bottom + 2)
                .DrawLine(Pens.DimGray, cmbDevices.Left + tmpMax, Label4B.Bottom + 2, cmbDevices.Right, Label4B.Bottom + 2)

                tmpMax = SoundController / 255 * cmbDevices.Width
                .FillRectangle(Brushes.Red, cmbDevices.Left, chkMonitor.Top + 2, tmpMax, 8)
                .FillRectangle(Brushes.DimGray, cmbDevices.Left + tmpMax, chkMonitor.Top + 2, cmbDevices.Width - tmpMax, 8)

                tmpMax = SoundControllerBass / 255 * cmbDevices.Width
                .FillRectangle(Brushes.Red, cmbDevices.Left, chkMonitor.Bottom - 10, tmpMax, 8)
                .FillRectangle(Brushes.DimGray, cmbDevices.Left + tmpMax, chkMonitor.Bottom - 10, cmbDevices.Width - tmpMax, 8)

                .Dispose()
            End With
        End If
        maxInput = 0 : maxInputBass = 0
    End Sub
End Class