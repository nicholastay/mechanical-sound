Public Class Form2
    Dim timeTicked As Integer
    Dim timeNeeded As Integer
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Interval = 1
        Form1.Close()
        Form1.Dispose()
        Form3.Show()
        Timer1.Start()
        Timer1.Enabled = True
        Me.Hide()
        timeNeeded = 60000 * Convert.ToInt32(ComboBox1.Text)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timeTicked = timeTicked + 1
        Form3.Label1.Text = "Mechanical Keyboard is disabled for " + ComboBox1.Text + " minute(s)."
        If timeTicked = timeNeeded Then
            Form1.Show()
            Me.Close()
            Me.Dispose()
            Timer1.Stop()
            Form3.Close()
            Form3.Dispose()
            MsgBox("Mechanical Keyboard ReEnabled", MsgBoxStyle.Information, "Mechanical Keyboard")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timeTicked = 0
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
        Timer1.Enabled = False
    End Sub
End Class