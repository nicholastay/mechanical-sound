Public Class Form2
    Dim timeTicked As Integer
    Dim howMuchMS As Integer
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        howMuchMS = 60000 * Convert.ToInt32(ComboBox1.Text)
        Timer1.Interval = 1
        Form1.Close()
        Form1.Dispose()
        Form3.Show()
        Timer1.Start()
        Timer1.Enabled = True
        Me.Hide()
    End Sub

    'From vbforums, thanks a lot as well!: http://www.vbforums.com/showthread.php?96290-turning-thousands-of-milliseconds-into-hours-minutes-seconds
    Function Millisecs(Ms As Long) As String
        Dim Hrs As Long
        Dim Mins As Long
        Dim Secs As Long

        Secs = Ms / 1000

        Do Until Secs <= 60
            Secs = Secs - 60
            Mins = Mins + 1
        Loop
        Do Until Mins <= 60
            Mins = Mins - 60
            Hrs = Hrs + 1
        Loop


        Millisecs = Hrs & ":" & Mins & ":" & Secs
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timeTicked = timeTicked + 1
        Form3.Label1.Text = "Mechanical Keyboard will be disabled for: " + Millisecs(howMuchMS)
        If timeTicked = 60000 * Convert.ToInt32(ComboBox1.Text) Then
            Form1.Show()
            Me.Close()
            Me.Dispose()
            Me.Close()
            Me.Dispose()
            MsgBox("Mechanical Keyboard ReEnabled", MsgBoxStyle.Information, "Mechanical Keyboard")
            Timer1.Stop()
        End If
        howMuchMS = howMuchMS - 1
        Timer1.Enabled = True
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timeTicked = 0
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub
End Class