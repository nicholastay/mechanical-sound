Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Timer1.Stop()
        Form1.Show()
        Form2.Close()
        Form2.Dispose()
        Me.Close()
        Me.Dispose()
    End Sub
End Class