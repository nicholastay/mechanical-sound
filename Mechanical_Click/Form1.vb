Public Class Form1
    'Mechanical_Click, alpha 2
    'by Nicholas Tay 2013, "n2468txd"

    'Voices active:
    '0: Razer Black Widow
    '1: Duck
    '2: Cherry MX Red
    '3: Cherry MX Brown
    '4: Cherry MX Blue
    '5: Cherry MX Black
    '6: ALPS

    Dim rn As New Random
    Dim n As Integer
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal key As Integer) As Integer
    Dim KeyResult As Integer
    Dim voiceActive As Integer
    Dim maxnum As Integer
    Dim ResourceFilePathPrefix As String

    Private Sub keyClickGen()
        If voiceActive = 0 Then
            clickSound("Mechanical_Click")
        ElseIf voiceActive = 1 Then
            clickSound("DuckQuack")
        ElseIf voiceActive = 2 Then
            clickSound("MXRed")
        ElseIf voiceActive = 3 Then
            clickSound("MXBrown")
        ElseIf voiceActive = 4 Then
            clickSound("MXBlue")
        ElseIf voiceActive = 5 Then
            clickSound("MXBlack")
        Else
            clickSound("ALPS")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
        Timer1.Enabled = True
        Timer1.Interval = 1
        ComboBox1.Text = "Razer Black Widow (default)"
        voiceActive = 0
        NotifyIcon1.Visible = False

        'From MSDN, access resources with variable name. Thanks so much!
        If System.Diagnostics.Debugger.IsAttached() Then
            'In Debugging mode     
            ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\resources\")
        Else
            'In Published mode     
            ResourceFilePathPrefix = Application.StartupPath & "\resources\"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i As Byte
        For i = 1 To 254
            KeyResult = GetAsyncKeyState(i)
            If KeyResult = -32767 Then
                If i < 255 And i > 4 Then
                    keyClickGen()
                Else
                End If
            End If
        Next
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Visible = False
        NotifyIcon1.Visible = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Duck Quack (bonus!)" Then
            voiceActive = 1
        ElseIf ComboBox1.Text = "Cherry MX Red" Then
            voiceActive = 2
        ElseIf ComboBox1.Text = "Cherry MX Brown" Then
            voiceActive = 3
        ElseIf ComboBox1.Text = "Cherry MX Blue" Then
            voiceActive = 4
        ElseIf ComboBox1.Text = "Cherry MX Black" Then
            voiceActive = 5
        ElseIf ComboBox1.Text = "APC BSW 070WH - ALPS" Then
            voiceActive = 6
        Else
            voiceActive = 0
        End If
    End Sub

    Private Sub clickSound(ByVal soundFile As String)
        n = Convert.ToString(rn.Next(1, 20))
        Select Case n
            Case 1
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & ".wav", AudioPlayMode.Background)

            Case 2
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "2.wav", AudioPlayMode.Background)

            Case 3
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "3.wav", AudioPlayMode.Background)

            Case 4
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "4.wav", AudioPlayMode.Background)

            Case 5
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "5.wav", AudioPlayMode.Background)

            Case 6
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "6.wav", AudioPlayMode.Background)

            Case 7
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "7.wav", AudioPlayMode.Background)

            Case 8
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "8.wav", AudioPlayMode.Background)

            Case 9
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "9.wav", AudioPlayMode.Background)

            Case 10
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & "10.wav", AudioPlayMode.Background)

            Case Else
                My.Computer.Audio.Play(ResourceFilePathPrefix & soundFile & ".wav", AudioPlayMode.Background)

        End Select
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Enabled = False
        Form2.Show()
    End Sub

    'Code now ALL redundant as MSDN showed how to access resource file path
    'which leads us to be able to make a generic function!
    'With so many keyboards, yes, we have to pretty much do that or...
    '
    'Private Sub razerBlackWidow()
    '    n = Convert.ToString(rn.Next(1, 20))
    '    Select Case n
    '        Case 1
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click.wav", AudioPlayMode.Background)

    '        Case 2
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click2.wav", AudioPlayMode.Background)

    '        Case 3
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click3.wav", AudioPlayMode.Background)

    '        Case 4
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click4.wav", AudioPlayMode.Background)

    '        Case 5
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click5.wav", AudioPlayMode.Background)

    '        Case 6
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click6.wav", AudioPlayMode.Background)

    '        Case 7
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click7.wav", AudioPlayMode.Background)

    '        Case 8
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click8.wav", AudioPlayMode.Background)

    '        Case 9
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click9.wav", AudioPlayMode.Background)

    '        Case 10
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click10.wav", AudioPlayMode.Background)

    '        Case Else
    '            My.Computer.Audio.Play(ResourceFilePathPrefix & "Mechanical_Click.wav", AudioPlayMode.Background)

    '    End Select
    'End Sub

    'Private Sub duckQuack()
    '    n = Convert.ToString(rn.Next(1, 9))
    '    Select Case n
    '        Case 1
    '            My.Computer.Audio.Play(My.Resources.DuckQuack, AudioPlayMode.Background)

    '        Case 2
    '            My.Computer.Audio.Play(My.Resources.DuckQuack2, AudioPlayMode.Background)

    '        Case 3
    '            My.Computer.Audio.Play(My.Resources.DuckQuack3, AudioPlayMode.Background)

    '        Case 4
    '            My.Computer.Audio.Play(My.Resources.DuckQuack4, AudioPlayMode.Background)

    '        Case Else
    '            My.Computer.Audio.Play(My.Resources.DuckQuack, AudioPlayMode.Background)

    '    End Select
    'End Sub

   
End Class
