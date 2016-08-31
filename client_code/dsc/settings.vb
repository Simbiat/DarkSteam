Module settings
    'Sub settings_load()
    '    Dim settingsarray = dscWindow.initsets.Split(New String() {";!!!;"}, StringSplitOptions.None)
    '    Dim settray = settingsarray(0)
    '    Dim setauto = settingsarray(1)
    '    Dim setlogs = settingsarray(2)
    '    If settingsarray(3) <> Nothing And settingsarray(3) <> "" And settingsarray(3) <> "exe" Then
    '        dscWindow.setpath = Decrypt(settingsarray(3))
    '    Else
    '        dscWindow.setpath = SteamLoc()
    '    End If
    '    Dim setasscroll = settingsarray(4)
    '    Dim shoutenable = settingsarray(5)
    '    Dim settingshouttimer = settingsarray(6)
    '    Dim settingshoutcount = settingsarray(7)
    '    Dim settingperfile = settingsarray(8)
    '    Dim settingstatena = settingsarray(9)
    '    Dim settingsdate = settingsarray(10)
    '    Dim settingslateadd = settingsarray(11)
    '    Dim settingslateupd = settingsarray(12)
    '    Dim settingsinvis = settingsarray(13)
    '    Dim settingsgamedet = settingsarray(14)
    '    Dim settingsdownres = settingsarray(15)
    '    Dim settingsresx = settingsarray(16)
    '    Dim settingsresy = settingsarray(17)
    '    Dim settingsaccupd = settingsarray(18)
    '    Dim settingsmaxretries = settingsarray(22)
    '    Dim settingsshoutupdsounden = settingsarray(19)
    '    Dim settingsaltshupdsound = ""
    '    If settingsarray(20) <> Nothing And settingsarray(20) <> "" And settingsarray(20) <> "default" Then
    '        settingsaltshupdsound = Decrypt(settingsarray(20))
    '    Else
    '        settingsaltshupdsound = ""
    '    End If
    '    Dim settingwin7prog = settingsarray(23)
    '    Dim settingwin7snap = settingsarray(24)
    '    Dim settinglink = settingsarray(27)
    '    Dim settinghourupd = settingsarray(25)
    '    Dim settinghourgam = settingsarray(26)
    '    Dim settinclicksnd = settingsarray(28)
    '    If settinglink = 1 Then
    '        settingswindow.linkinterceptcheck.Checked = True
    '        regdsclinks()
    '    Else
    '        settingswindow.linkinterceptcheck.Checked = False
    '        remdsclinks()
    '    End If
    '    If settingwin7snap = 1 Then
    '        settingswindow.aerosnapcheck.Checked = True
    '    Else
    '        settingswindow.aerosnapcheck.Checked = False
    '    End If
    '    If settingwin7prog = 1 Then
    '        settingswindow.tbprogcheck.Checked = True
    '        dscWindow.win7progress = 1
    '    Else
    '        settingswindow.tbprogcheck.Checked = False
    '        dscWindow.win7progress = 0
    '    End If
    '    If settingsaltshupdsound = "default" Or settingsaltshupdsound = Nothing Or settingsaltshupdsound = "" Then
    '        settingswindow.altshoutupdbox.Text = ""
    '        dscWindow.altshoutupd = Nothing
    '    Else
    '        settingswindow.altshoutupdbox.Text = Decrypt(settingsaltshupdsound)
    '        dscWindow.altshoutupd = settingswindow.altshoutupdbox.Text
    '    End If
    '    If settingsshoutupdsounden = 1 Then
    '        settingswindow.shupdsoundench.Checked = True
    '        dscWindow.settingsshoutupdsounden = 1
    '    Else
    '        settingswindow.shupdsoundench.Checked = False
    '        dscWindow.settingsshoutupdsounden = 0
    '    End If
    '    dscWindow.maxretries = settingsmaxretries
    '    settingswindow.set_maxretries.Text = dscWindow.maxretries
    '    If settingsaccupd = 1 Then
    '        settingswindow.accupdchbox.Checked = True
    '    Else
    '        settingswindow.accupdchbox.Checked = False
    '    End If
    '    If settingsresx = 0 Then
    '        settingswindow.ResolutionX.Text = Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.67)
    '    Else
    '        settingswindow.ResolutionX.Text = settingsresx
    '    End If
    '    If settingsresy = 0 Then
    '        settingswindow.ResolutionY.Text = Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.67)
    '    Else
    '        settingswindow.ResolutionY.Text = settingsresy
    '    End If
    '    If settingsgamedet = 1 Then
    '        dscWindow.downres = 1
    '        settingswindow.downresume.Checked = True
    '    Else
    '        dscWindow.downres = 0
    '        settingswindow.downresume.Checked = False
    '    End If
    '    If settingsgamedet = 1 Then
    '        settingswindow.set_gamedetails.Checked = True
    '    Else
    '        settingswindow.set_gamedetails.Checked = False
    '    End If
    '    If settingsinvis = 1 Then
    '        dscWindow.invis = 1
    '        settingswindow.invisibility.Checked = True
    '    Else
    '        dscWindow.invis = 0
    '        settingswindow.invisibility.Checked = False
    '    End If
    '    If settingslateadd = 1 Then
    '        settingswindow.showlateadd.Checked = True
    '        dscWindow.latestgamesgroup.Visible = True
    '        settingswindow.showlateupd.Enabled = True
    '        If settingslateupd = 1 Then
    '            settingswindow.showlateupd.Checked = True
    '        Else
    '            settingswindow.showlateupd.Checked = False
    '        End If
    '    Else
    '        settingswindow.showlateadd.Checked = False
    '        dscWindow.latestgamesgroup.Visible = False
    '        settingswindow.showlateupd.Enabled = False
    '    End If
    '    If settray = 1 Then
    '        settingswindow.totray.Checked = True
    '    Else
    '        settingswindow.totray.Checked = False
    '    End If
    '    If setauto = 1 Then
    '        dscWindow.autoproc = True
    '        settingswindow.autostart.Checked = True
    '    Else
    '        dscWindow.autoproc = False
    '        settingswindow.autostart.Checked = False
    '    End If
    '    If setlogs = 1 Then
    '        settingswindow.Logging.Checked = True
    '        dscWindow.Logging = 1
    '    Else
    '        settingswindow.Logging.Checked = False
    '        dscWindow.Logging = 0
    '    End If
    '    If dscWindow.setpath = "exe" Or dscWindow.setpath = Nothing Or dscWindow.setpath = "" Then
    '        dscWindow.setpath = SteamLoc()
    '        settingswindow.steamdlbox.Text = dscWindow.setpath
    '    Else
    '        settingswindow.steamdlbox.Text = Decrypt(dscWindow.setpath)
    '        dscWindow.setpath = settingswindow.steamdlbox.Text
    '    End If
    '    If setasscroll = 1 Then
    '        settingswindow.set_autoscroll.Checked = True
    '        dscWindow.shoutscroll = 1
    '    Else
    '        settingswindow.set_autoscroll.Checked = False
    '        dscWindow.shoutscroll = 0
    '    End If
    '    If shoutenable = 1 Then
    '        settingswindow.set_shoutbox.Checked = True
    '        settingswindow.set_autoscroll.Enabled = True
    '        settingswindow.shouttimerset.Enabled = True
    '        settingswindow.shoutscountbox.Enabled = True
    '        settingswindow.sdateformatbox.Enabled = True
    '        settingswindow.invisibility.Enabled = True
    '        dscWindow.shoutena = 1
    '        dscWindow.chatwindow.Visible = True
    '        dscWindow.chatinput.Visible = True
    '        dscWindow.ActiveUsersGroupBox.Visible = True
    '    Else
    '        settingswindow.set_shoutbox.Checked = False
    '        settingswindow.set_autoscroll.Enabled = False
    '        settingswindow.shouttimerset.Enabled = False
    '        settingswindow.shoutscountbox.Enabled = False
    '        settingswindow.sdateformatbox.Enabled = False
    '        settingswindow.invisibility.Enabled = False
    '        dscWindow.shoutena = 0
    '        dscWindow.chatwindow.Visible = False
    '        dscWindow.chatinput.Visible = False
    '        dscWindow.ActiveUsersGroupBox.Visible = False
    '    End If
    '    If settingsdate <> "" And settingsdate <> Nothing And settingsdate <> "Null" Then
    '        settingswindow.sdateformatbox.Text = settingsdate
    '        dscWindow.shoutdateform = settingsdate
    '    Else
    '        settingswindow.sdateformatbox.Text = "dd.MM.yyyy HH:mm:ss"
    '    End If
    '    If settingstatena = 1 Then
    '        settingswindow.StatisticsCheckbox.Checked = True
    '        dscWindow.StatisticsGroupBox.Visible = True
    '        dscWindow.StatisticsCheckbox = 1
    '    Else
    '        settingswindow.StatisticsCheckbox.Checked = False
    '        dscWindow.StatisticsGroupBox.Visible = False
    '        dscWindow.StatisticsCheckbox = 0
    '    End If
    '    If settingperfile = 1 Then
    '        settingswindow.PerFileCheckBox.Checked = True
    '        dscWindow.PerFileCheckBox = 1
    '        dscWindow.dscProgressBar2.Visible = True
    '        'dscWindow.GamesList.Height = 602
    '        'dscWindow.chatinput.Location = New Point(345, 640)
    '        'dscWindow.chatwindow.Height = 130
    '    Else
    '        settingswindow.PerFileCheckBox.Checked = False
    '        dscWindow.PerFileCheckBox = 0
    '        dscWindow.dscProgressBar2.Visible = False
    '        'dscWindow.GamesList.Height = 625
    '        'dscWindow.chatinput.Location = New Point(345, 663)
    '        'dscWindow.chatwindow.Height = 153
    '    End If
    '    settingswindow.shouttimerset.Text = settingshouttimer.Substring(0, settingshouttimer.Length - 3)
    '    dscWindow.shoutupdint = settingshouttimer.Substring(0, settingshouttimer.Length - 3)
    '    If settingswindow.shouttimerset.Text = 0 Then
    '        dscWindow.shoutstimer.Stop()
    '        dscWindow.shoutstimer.Enabled = False
    '    Else
    '        dscWindow.shoutstimer.Enabled = True
    '        dscWindow.shoutstimer.Interval = dscWindow.shoutupdint & "000"
    '        dscWindow.shoutstimer.Start()
    '    End If
    '    settingswindow.shoutscountbox.Text = settingshoutcount
    '    dscWindow.shoutcounts = settingswindow.shoutscountbox.Text
    'End Sub
End Module
