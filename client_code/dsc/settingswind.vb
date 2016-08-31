Imports System.Net
Imports System.IO
Public Class settingswindow
    Public Sub settingswindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dscWindow.settingsloaded = True Then
            If dscWindow.downloading = True Then
                Logging.Enabled = False
                downresume.Enabled = False
                steamdlbox.Enabled = False
            Else
                Logging.Enabled = True
                downresume.Enabled = True
                steamdlbox.Enabled = True
            End If
        End If
    End Sub
    Private Sub okbut_Click(sender As System.Object, e As System.EventArgs) Handles okbut.Click
        If steamdlbox.Enabled = True Then
            steamdlboxupd()
        End If
        autostart_CheckedChanged(okbut, Nothing)
        If Logging.Enabled = True Then
            Logging_CheckedChanged(okbut, Nothing)
        End If
        If downresume.Enabled = True Then
            downresume_CheckedChanged(okbut, Nothing)
        End If
        totray_CheckedChanged(okbut, Nothing)
        StatisticsCheckbox_CheckedChanged(okbut, Nothing)
        PerFileCheckBox_CheckedChanged(okbut, Nothing)
        downresume_CheckedChanged(okbut, Nothing)
        accupdchbox_CheckedChanged(okbut, Nothing)
        tbprogcheck_CheckedChanged(okbut, Nothing)
        aerosnapcheck_CheckedChanged(okbut, Nothing)
        linkinterceptcheck_CheckedChanged(okbut, Nothing)
        resolutionxupd()
        resolutionyupd()
        set_maxretriesupd()
        dscWindow.homeicon_Click(Me.okbut, Nothing)
        Me.Close()
        Messageboxing("Settings saved!", "Settings saved!")
    End Sub
    Private Sub resetbut_Click(sender As Object, e As EventArgs) Handles resetbut.Click
        autostart.Checked = False
        Logging.Checked = False
        totray.Checked = False
        StatisticsCheckbox.Checked = True
        PerFileCheckBox.Checked = True
        downresume.Checked = True
        accupdchbox.Checked = False
        tbprogcheck.Checked = True
        aerosnapcheck.Checked = False
        linkinterceptcheck.Checked = False
        steamdlbox.Text = SteamLoc()
        ResolutionX.Text = Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.67)
        ResolutionY.Text = Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.67)
        set_maxretries.Text = 5
        Messageboxing("Settings reset!", "Settings have been reset!" & vbCrLf & "Press 'Save' to save them, otherwise they will be active only for this session")
    End Sub
    Private Sub okbut_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles okbut.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            okbut_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub DscButtonBlackBG1_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DscButtonBlackBG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            DscButtonBlackBG1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub resetbut_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles resetbut.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            resetbut_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub set_setting(setting As String, value As String)
        'Dim setStream As StreamReader
        'Dim setreq As HttpWebRequest
        'Dim setres As WebResponse = Nothing
        'setreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/settingsupd.php?login=" & dscWindow.encloginram & "&pass=" & Encrypt(dscWindow.salt & UCase(dscWindow.md5hpass)) & "&var=" & Encrypt(setting) & "&val=" & Encrypt(value) & "&invis=" & dscWindow.invis)
        'setreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
        'Try
        '    setres = setreq.GetResponse()
        'Catch ex As Exception
        'End Try
        'setStream = New StreamReader(setres.GetResponseStream())
        'Dim setresult = setStream.ReadToEnd
        'If setresult <> "Success" Then
        '    Messageboxing("Saving settings failed!", setresult)
        'End If
    End Sub
    Private Sub linkinterceptcheck_CheckedChanged(sender As Object, e As EventArgs) Handles linkinterceptcheck.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.linkinterceptcheck.Checked = False Then
                remdsclinks()
                set_setting("settings_linkintercept", "0")
            Else
                regdsclinks()
                set_setting("settings_linkintercept", "1")
            End If
        End If
    End Sub
    Private Sub aerosnapcheck_CheckedChanged(sender As Object, e As EventArgs) Handles aerosnapcheck.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.aerosnapcheck.Checked = False Then
                set_setting("settings_win7shake", "0")
            Else
                set_setting("settings_win7shake", "1")
            End If
        End If
    End Sub
    Private Sub tbprogcheck_CheckedChanged(sender As Object, e As EventArgs) Handles tbprogcheck.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.tbprogcheck.Checked = False Then
                dscWindow.win7progress = 0
                set_setting("settings_win7progress", "0")
            Else
                dscWindow.win7progress = 1
                set_setting("settings_win7progress", "1")
            End If
        End If
    End Sub
    Private Sub accupdchbox_CheckedChanged(sender As Object, e As EventArgs) Handles accupdchbox.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.accupdchbox.Checked = False Then
                set_setting("settings_accupdch", "0")
            Else
                set_setting("settings_accupdch", "1")
            End If
        End If
    End Sub
    Private Sub downresume_CheckedChanged(sender As Object, e As EventArgs) Handles downresume.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.downresume.Checked = False Then
                dscWindow.downres = 0
                set_setting("settings_downres", "0")
            Else
                dscWindow.downres = 1
                set_setting("settings_downres", "1")
            End If
        End If
    End Sub
    Private Sub totray_CheckedChanged(sender As Object, e As EventArgs) Handles totray.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.totray.Checked = False Then
                set_setting("settings_tray", "0")
            Else
                set_setting("settings_tray", "1")
            End If
        End If
    End Sub
    Private Sub autostart_CheckedChanged(sender As Object, e As EventArgs) Handles autostart.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.autostart.Checked = False Then
                dscWindow.autoproc = False
                set_setting("settings_auto", "0")
            Else
                dscWindow.autoproc = True
                set_setting("settings_auto", "1")
            End If
        End If
    End Sub
    Private Sub Logging_CheckedChanged(sender As Object, e As EventArgs) Handles Logging.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.Logging.Checked = False Then
                set_setting("settings_logs", "0")
                dscWindow.Logging = 0
            Else
                set_setting("settings_logs", "1")
                dscWindow.Logging = 1
            End If
        End If
    End Sub
    Private Sub PerFileCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PerFileCheckBox.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.PerFileCheckBox.Checked = False Then
                set_setting("settings_perfileprog", "0")
                dscWindow.dscProgressBar2.Visible = False
                dscWindow.PerFileCheckBox = 0
            Else
                set_setting("settings_perfileprog", "1")
                dscWindow.dscProgressBar2.Visible = True
                dscWindow.PerFileCheckBox = 1
            End If
            elementsplacing()
        End If
    End Sub
    Private Sub StatisticsCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles StatisticsCheckbox.CheckedChanged
        If dscWindow.settingsloaded = True Then
            If Me.StatisticsCheckbox.Checked = False Then
                set_setting("settings_statenab", "0")
                'dscWindow.StatisticsGroupBox.Visible = False
                dscWindow.StatisticsGroupBox.Visible = True
                dscWindow.StatisticsCheckbox = 0
            Else
                set_setting("settings_statenab", "1")
                dscWindow.StatisticsGroupBox.Visible = True
                dscWindow.StatisticsCheckbox = 1
            End If
        End If
    End Sub
    Private Sub set_maxretries_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles set_maxretries.KeyDown
        If dscWindow.settingsloaded = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                set_maxretriesupd()
            End If
        End If
    End Sub
    Private Sub set_maxretriesupd()
        If Me.set_maxretries.Text < 0 Then
            Me.set_maxretries.Text = 5
        End If
        For i = 0 To Me.set_maxretries.Text.Length - 1
            If Char.IsDigit(Me.set_maxretries.Text.Chars(i)) = False Then
                Me.set_maxretries.Text = 5
                dscWindow.maxretries = Me.set_maxretries.Text
                Messageboxing("Incorrect number!", "Please, input only number!")
                Exit Sub
            End If
        Next
        dscWindow.maxretries = Me.set_maxretries.Text
        set_setting("settings_maxretries", Me.set_maxretries.Text)
    End Sub
    Private Sub ResolutionX_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ResolutionX.KeyDown
        If dscWindow.settingsloaded = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                resolutionxupd()
                resolutionyupd()
            End If
        End If
    End Sub
    Private Sub resolutionxupd()
        If Me.ResolutionX.Text.Length = 0 Then
            Me.ResolutionX.Text = Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.67)
        End If
        If Me.ResolutionX.Text = 0 Then
            Me.ResolutionX.Text = Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.67)
        End If
        If Me.ResolutionX.Text < 400 And Me.ResolutionX.Text <> 0 Then
            Me.ResolutionX.Text = 400
        End If
        For i = 0 To Me.ResolutionX.Text.Length - 1
            If Char.IsDigit(Me.ResolutionX.Text.Chars(i)) = False Then
                Me.ResolutionX.Text = Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.67)
                Messageboxing("Incorrect number!", "Please, input only number!")
                Exit Sub
            End If
        Next
        set_setting("settings_resx", Me.ResolutionX.Text)
        dscWindow.Width = Me.ResolutionX.Text
    End Sub
    Private Sub ResolutionY_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ResolutionY.KeyDown
        If dscWindow.settingsloaded = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                resolutionyupd()
                resolutionxupd()
            End If
        End If
    End Sub
    Private Sub resolutionyupd()
        If Me.ResolutionY.Text.Length = 0 Then
            Me.ResolutionY.Text = Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.67)
        End If
        If Me.ResolutionY.Text = 0 Then
            Me.ResolutionY.Text = Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.67)
        End If
        If Me.ResolutionY.Text < 400 And Me.ResolutionX.Text <> 0 Then
            Me.ResolutionY.Text = 400
        End If
        For i = 0 To Me.ResolutionY.Text.Length - 1
            If Char.IsDigit(Me.ResolutionY.Text.Chars(i)) = False Then
                Me.ResolutionY.Text = Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.67)
                Messageboxing("Incorrect number!", "Please, input only number!")
                Exit Sub
            End If
        Next
        set_setting("settings_resy", Me.ResolutionY.Text)
        dscWindow.Height = Me.ResolutionY.Text
    End Sub
    Private Sub sdateformatlab_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("http://php.net/manual/function.date.php")
    End Sub
    Private Sub DscButtonBlackBG1_Click(sender As Object, e As EventArgs) Handles DscButtonBlackBG1.Click
        Me.Close()
    End Sub
    Private Sub BrowseBut_Click(sender As Object, e As EventArgs) Handles BrowseBut.Click
        dscWindow.FBD.ShowDialog()
        steamdlbox.Text = dscWindow.FBD.SelectedPath
        set_setting("settings_path", Encrypt(steamdlbox.Text))
    End Sub
    Private Sub steamdlbox_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles steamdlbox.KeyDown
        If dscWindow.settingsloaded = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                steamdlboxupd()
            End If
        End If
    End Sub
    Private Sub steamdlboxupd()
        If Me.steamdlbox.Text.Length = 0 Then
            Me.steamdlbox.Text = SteamLoc()
        End If
        If Me.steamdlbox.Text(Me.steamdlbox.Text.Length - 1) = "\" Or Me.steamdlbox.Text(Me.steamdlbox.Text.Length - 1) = "/" Then
            Me.steamdlbox.Text = Me.steamdlbox.Text.Substring(0, Me.steamdlbox.Text.Length - 1)
        End If
        If Not System.IO.Path.IsPathRooted(Me.steamdlbox.Text) Then
            Messageboxing("Wrong directory!", "Wrong or non-existing directory!")
            Exit Sub
        End If
        dscWindow.setpath = Me.steamdlbox.Text
        set_setting("settings_path", Encrypt(steamdlbox.Text))
    End Sub
    Private Sub altshoutupdbut_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.Title = "Select a music file"
        OpenFileDialog1.Filter = "Wave Files(*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = SteamLoc()
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub DscButtonBlackBG2_Click(sender As Object, e As EventArgs) Handles shortcreatebut.Click
        shortcut_create()
    End Sub
End Class