Public Class Form1
    Dim rn As New Random
    Dim n As Integer
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal key As Integer) As Integer
    Dim KeyResult As Integer
    Dim mLeft As Boolean
    Dim mRight As Boolean
    Dim mMid As Boolean


    Private Sub keyClickGen()
        n = Convert.ToString(rn.Next(1, 20))
        Select Case n
            Case 1
                My.Computer.Audio.Play(My.Resources.Mechanical_Click, AudioPlayMode.Background)

            Case 2
                My.Computer.Audio.Play(My.Resources.Mechanical_Click2, AudioPlayMode.Background)

            Case 3
                My.Computer.Audio.Play(My.Resources.Mechanical_Click3, AudioPlayMode.Background)

            Case 4
                My.Computer.Audio.Play(My.Resources.Mechanical_Click4, AudioPlayMode.Background)

            Case 5
                My.Computer.Audio.Play(My.Resources.Mechanical_Click5, AudioPlayMode.Background)

            Case 6
                My.Computer.Audio.Play(My.Resources.Mechanical_Click6, AudioPlayMode.Background)

            Case 7
                My.Computer.Audio.Play(My.Resources.Mechanical_Click7, AudioPlayMode.Background)

            Case 8
                My.Computer.Audio.Play(My.Resources.Mechanical_Click8, AudioPlayMode.Background)

            Case 9
                My.Computer.Audio.Play(My.Resources.Mechanical_Click9, AudioPlayMode.Background)

            Case 10
                My.Computer.Audio.Play(My.Resources.Mechanical_Click10, AudioPlayMode.Background)

            Case Else
                My.Computer.Audio.Play(My.Resources.Mechanical_Click, AudioPlayMode.Background)

        End Select

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 1
        mLeft = GetAsyncKeyState(Keys.LButton)
        mRight = GetAsyncKeyState(Keys.RButton)
        mMid = GetAsyncKeyState(Keys.MButton)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i As Byte
        For i = 1 To 254
            KeyResult = GetAsyncKeyState(i)
            If KeyResult = -32767 Then
                If i < 255 Then
                    If Not mLeft Or mRight Or mMid Then
                            keyClickGen()
                    End If
                Else
                End If
            End If
        Next
    End Sub
End Class
