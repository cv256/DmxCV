﻿Imports System.IO.Ports

Public Class clDMX
    ' Declare Functions for uDMX configurations and data transfer
    Public Declare Function Configure Lib "uDMX.dll" () As Integer
    Private Declare Function ChannelSet Lib "uDMX.dll" (ByVal Channel As Int32, ByVal Data As Int32) As Boolean
    Public Declare Function ChannelsSet Lib "uDMX.dll" (ByVal ChanCnt As Int32, ByVal ChanFirst As Int32, ByRef FirstChan As Byte) As Boolean

    Private WithEvents SerialPort1 As IO.Ports.SerialPort

    Public ComPort As Byte

    Public Function Send(pChannel As Byte, pValue As Byte) As String
        Try

            If ComPort = 0 Then ' uDMX:
                ' TODO:
                If ChannelSet(pChannel, pValue) Then
                    Return "OK"
                Else
                    Return "ERRORuDMX"
                End If

            Else ' Arduino:

                Try
                    If SerialPort1 IsNot Nothing AndAlso SerialPort1.PortName <> "COM" & ComPort Then
                        If SerialPort1.IsOpen Then SerialPort1.Close()
                        SerialPort1 = Nothing
                    End If
                Catch ex As Exception
                End Try

                If SerialPort1 Is Nothing Then
                    SerialPort1 = New IO.Ports.SerialPort("COM" & ComPort)
                    SerialPort1.WriteBufferSize = 2
                    SerialPort1.Open()
                End If

                Dim ChVal(0 To 1) As Byte
                ChVal(0) = pChannel
                ChVal(1) = pValue
                SerialPort1.Write(ChVal, 0, 2)
                Return "OK"

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return ex.Message
        End Try

        Return "???"
    End Function

    Private Sub SerialPort1_DataReceived(sender As SerialPort, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim res As String = ""
        While SerialPort1.BytesToRead > 0
            res &= SerialPort1.ReadExisting()
        End While
        MsgBox(res, MsgBoxStyle.Critical)
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As SerialPort, e As SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        MsgBox("SerialPort1.ErrorReceived", MsgBoxStyle.Critical)
    End Sub

End Class
