Imports Microsoft.VisualBasic

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
    '7: Membrane GHEEEYYYYYYYYYYYYYYYY

    Dim rn As New Random
    Dim n As Integer
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal key As Integer) As Integer
    Dim KeyResult As Integer
    Dim voiceActive As Integer
    Dim maxnum As Integer
    Dim resourcePath As String
    Dim alreadyPressed As Boolean

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
        ElseIf voiceActive = 6 Then
            clickSound("ALPS")
        Else
            clickSound("Membrane")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        voiceActive = GetSetting("Mechanical_Click", "settingsStore", "voiceActive", "0")
        ComboBox1.SelectedIndex = Convert.ToInt32(voiceActive)

        Timer1.Enabled = True
        Timer1.Interval = 1
        NotifyIcon1.Visible = False
        alreadyPressed = False

        'check prev instance - thanks freevbcode
        CheckForExistingInstance()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Old logic code (there really is no logic at all but the for loop haha)
        'Dim i As Byte
        'For i = 1 To 254
        '    KeyResult = GetAsyncKeyState(i)
        '    If KeyResult = -32767 Then
        '        If i < 255 And i > 4 Then
        '            keyClickGen()
        '        Else
        '        End If
        '    End If
        'Next

        Dim previ As Integer
        Dim i As Byte
        For i = 5 To 254

            If GetAsyncKeyState(i) = -32767 Then
                keyClickGen()
                alreadyPressed = True
                previ = i
                Timer1.Enabled = False
                ' Thanks SO SO SO much to my dad for this logic below!! :D
                ' stopped the repeated click problem
                Do
                    Dim y As Byte
                    For y = 5 To 254
                        If GetAsyncKeyState(y) = -32767 And (Not y = previ) Then
                            keyClickGen()
                            Timer1.Enabled = True
                        End If
                    Next
                Loop Until Not GetAsyncKeyState(previ) = -32767
                Timer1.Enabled = True
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
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "1")
        ElseIf ComboBox1.Text = "Cherry MX Red" Then
            voiceActive = 2
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "2")
        ElseIf ComboBox1.Text = "Cherry MX Brown" Then
            voiceActive = 3
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "3")
        ElseIf ComboBox1.Text = "Cherry MX Blue" Then
            voiceActive = 4
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "4")
        ElseIf ComboBox1.Text = "Cherry MX Black" Then
            voiceActive = 5
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "5")
        ElseIf ComboBox1.Text = "APC BSW 070WH - ALPS" Then
            voiceActive = 6
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "6")
        ElseIf ComboBox1.Text = "Membrane Keyboard (whyy?)" Then
            voiceActive = 6
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "7")
        Else
            voiceActive = 0
            SaveSetting("Mechanical_Click", "settingsStore", "voiceActive", "0")
        End If
    End Sub

    Private Sub clickSound(ByVal soundFile As String)
        n = Convert.ToString(rn.Next(1, 20))

        Select Case n
            Case 1
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile), AudioPlayMode.Background)

            Case 2
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "2"), AudioPlayMode.Background)

            Case 3
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "3"), AudioPlayMode.Background)

            Case 4
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "4"), AudioPlayMode.Background)

            Case 5
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "5"), AudioPlayMode.Background)

            Case 6
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "6"), AudioPlayMode.Background)

            Case 7
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "7"), AudioPlayMode.Background)

            Case 8
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "8"), AudioPlayMode.Background)

            Case 9
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "9"), AudioPlayMode.Background)

            Case 10
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile & "10"), AudioPlayMode.Background)

            Case Else
                My.Computer.Audio.Play(My.Resources.ResourceManager.GetObject(soundFile), AudioPlayMode.Background)

        End Select
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Enabled = False
        Form2.Show()
    End Sub

    'From FreeVBCode - check for prev instance
    Public Sub CheckForExistingInstance()
        'Get number of processes of you program
        If Process.GetProcessesByName _
          (Process.GetCurrentProcess.ProcessName).Length > 1 Then

            MessageBox.Show _
             ("Another Instance of this process is already running. If you are sure it is closed (it is not making click noises but somehow still running, go to task manager (CTRL-ALT-DEL) and then processes and then choose Mechanical_Click.exe and click Kill Process. Then run this program again. Enjoy!", _
                 "Multiple Instances Forbidden", _
                  MessageBoxButtons.OK, _
                 MessageBoxIcon.Exclamation)
            Application.Exit()
        End If
    End Sub

    'Code now all redundant as I figured out a way to access resources with resourcemanager.getobject
    '
    'Private Sub razerBlackWidow()
    '    n = Convert.ToString(rn.Next(1, 20))
    '    Select Case n
    '-- screw msdn the below resourcefilepathprefix way doesnt work -_-
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
