Imports Microsoft.VisualBasic

Public Class Form1
    'Mechanical_Click, alpha 5
    'by Nicholas Tay 2014, "n2468txd"

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
    Dim voiceActive As Integer
    Dim resourcePath As String
    Dim alreadyPressed As Boolean
    Dim previ As Integer
    Dim specialKey As Boolean

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
        Timer2.Enabled = True
        Timer2.Interval = 100
        Timer1.Interval = 100
        NotifyIcon1.Visible = False
        alreadyPressed = False
        specialKey = False

        'check prev instance - thanks freevbcode
        CheckForExistingInstance()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim i As Byte
        For i = 5 To 254
            If GetAsyncKeyState(i) = -32767 Then
                If i < 255 And alreadyPressed = False Then
                    Form4.Label1.Text = "KeyPressed: " + i.ToString
                    If i > 15 And i < 19 Then
                        specialKey = True
                    Else
                        specialKey = False
                        keyClickGen()
                    End If
                    alreadyPressed = True
                    previ = i
                    Timer1.Enabled = False
                Else
                End If
            End If
        Next
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

            If alreadyPressed = True Then

                Dim i As Byte
                For i = 5 To 254
                    If GetAsyncKeyState(i) = -32767 Then
                        If i < 255 And (Not i = previ) Then
                            keyClickGen()
                            alreadyPressed = False
                            Timer1.Enabled = True
                        Form4.Label1.Text = "KeyPressed: " + i.ToString
                        If i > 15 And i < 19 Then
                            specialKey = True
                            alreadyPressed = False
                        Else
                            specialKey = False
                            keyClickGen()
                        End If
                        Else
                        End If
                    End If

                    'keyup code
                    Static nVal As Boolean
                    If GetAsyncKeyState(previ) = 0 Then
                        If nVal Then
                            alreadyPressed = False
                            previ = 0
                            Timer1.Enabled = True
                        End If
                    End If
                    nVal = CBool(GetAsyncKeyState(previ))

                Next
            End If

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form4.Show()
    End Sub
End Class
