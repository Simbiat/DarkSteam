Imports System.Net
Imports System.IO
Imports System.Text
Imports Rebex
Imports Rebex.IO
Imports Rebex.Net
Imports Rebex.Security.Certificates
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Public Class dscWindow
    'Global declarations
    Dim elapsedtimesec As Integer = 0
    Dim newsno As Integer
    Dim newsurlclick As String
    Public ftptocancel = 0
    Public WithEvents TrayContext As New ContextMenuStrip
    Public WithEvents GamesListContext As New ContextMenuStrip
    'Public WithEvents ChatContext As New ContextMenuStrip
    Public WithEvents usercontext As New ContextMenuStrip
    Public WithEvents ActiveUsersContext As New ContextMenuStrip
    Public WithEvents WebUserContext As New ContextMenuStrip
    Public WithEvents latestgamescontext As New ContextMenuStrip
    Public WithEvents newscontext As New ContextMenuStrip
    Public WithEvents mainwincontext As New ContextMenuStrip
    Public downloading = False
    Public lastheight
    Public downres = 1
    Public previouswinsize As FormWindowState = FormWindowState.Normal
    Public wasminimized = False
    Public failedonfile = Nothing
    Public prefailedonfile = Nothing
    Public sizeprocessed = 0
    Public errnegcount = 0
    Public maxretries = 0
    Public curretries = 0
    Public startorinput = False
    Public altshoutupd = Nothing
    Public win7progress = 1
    Public windowwasdocked = 0
    Public dlctextboxloaded = 0
    Public bwtocancel = 0
    Public autoproc = False
    Public apptorun = 0
    Public extrahide = True
    Public clicksound = Nothing
    Public disclksnd = 0
    Public DLCidext = Nothing
    Public initsets As String = "amempty"
    Public md5hpass = Nothing
    Public salt = Nothing
    'Public chatwintemp = "Loading..."
    Public currshouts = "empty"
    Public userlistnonsplitcached = Nothing
    Public clickuserid = Nothing
    Public clickusername = Nothing
    Public supupd = 0
    Public doupdate = Nothing
    Public fulllistofarg = Nothing
    Public updateav = 0
    Public gameisplus = 0

    'game to download
    Public gameloaded As String
    Public exe1path = Nothing
    Public exe2path = Nothing
    Public exe3path = Nothing
    Public exe4path = Nothing
    Public exe5path = Nothing
    Public exe1desc = Nothing
    Public exe2desc = Nothing
    Public exe3desc = Nothing
    Public exe4desc = Nothing
    Public exe5desc = Nothing
    Public crack1path = Nothing
    Public crack2path = Nothing
    Public crack3path = Nothing
    Public crack4path = Nothing
    Public crack5path = Nothing
    Public crack1desc = Nothing
    Public crack2desc = Nothing
    Public crack3desc = Nothing
    Public crack4desc = Nothing
    Public crack5desc = Nothing
    Public addon1path = Nothing
    Public addon2path = Nothing
    Public addon3path = Nothing
    Public addon4path = Nothing
    Public addon5path = Nothing
    Public addon1desc = Nothing
    Public addon2desc = Nothing
    Public addon3desc = Nothing
    Public addon4desc = Nothing
    Public addon5desc = Nothing
    Public alldlcids = Nothing
    Public alldlcnames = Nothing
    Public downconf
    Public format As String
    Public commonfolder As String
    Public steamappsdata As String
    Public manifests As String
    Public depotcache As String
    Public usersgroup = Nothing
    Public encpassram = Nothing
    Public encloginram = Nothing
    Public gamelink
    Public appid
    Public appidtodown = Nothing
    Public supconf = 0
    Public manonly = 0
    Public nocommondir = 0
    Public appidok = 0
    Public index As Integer
    Public appformat As String
    Public downdir As String = Nothing
    Private balloonShown As Boolean = False
    Public settingsloaded = False
    Public shusername
    Public shusergroupid
    'Public supsauth = 0
    Public setpath = Nothing
    Public showlatest = 1
    Public Logging, PerFileCheckBox, StatisticsCheckbox
    Public invis = 0
    Public settingsshoutupdsounden = 1
    Public widthbeforedocking = 0
    Public heightbeforedocking = 0
    Public crackdown As String = Nothing
    Public downcrack = 0
    Public downaddon = 0
    Public gamebank(1)()
    Public userbank(1)()
    Public whoelistnonsplit = Nothing

    'shoutbox parameters
    Dim webbrowserbckclr = Color.FromArgb(51, 51, 51)
    Public shoutena = 0
    Public shoutscroll = 1
    Public shoutupdint = 15
    Public shoutcounts = 20
    Public shoutdateform = "d.m.Y H:i:s"
    Public soundallowed = 0

    'tray icon animator
    Dim icon0 As Icon = My.Resources.icon_ico_format
    Dim icon1 As Icon = My.Resources.icon_dl_1
    Dim icon2 As Icon = My.Resources.icon_dl_2
    Dim iconstate As Integer

    'status of download
    Public status As String = "Idle"

    'client setup
    Private currentlog As String = My.Application.Info.DirectoryPath & "\connection.log"
    Public steamlocation As String
    Public ihaveloaded = 0

    Private FTP As Sftp
    'darksteam
    Dim ip As String = "simbiat.ru/darksteam"
    Dim username As String
    Public password As String
    Public WithEvents navinter As New linkinterceptor
    Public clientstat = Nothing
    Private Sub dsc_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If ihaveloaded = 1 Then
            elementsplacing()
        End If
    End Sub
    Private Sub dsc_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        If wasminimized = True Then
            Me.Height = settingswindow.ResolutionY.Text
            Me.Width = settingswindow.ResolutionX.Text
            Me.wasminimized = False
        Else
            'If Me.WindowState = FormWindowState.Minimized Then
            '    Me.WindowState = FormWindowState.Normal
            'End If
        End If
    End Sub
    Private Sub scrollableelements(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.Select()
    End Sub
    Private Sub controlelements(ByVal sender As Object, ByVal e As System.EventArgs) Handles homeicon.MouseEnter, websiteicon.MouseEnter, settingsicon.MouseEnter
        Dim img As New Bitmap(homeicon.Width, homeicon.Height)
        Dim brush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(0, img.Height), Color.FromArgb(80, 80, 80), Color.FromArgb(60, 60, 60))
        Dim gr As Graphics = Graphics.FromImage(img)
        gr.FillRectangle(brush, New RectangleF(0, 0, img.Width, img.Height))
        sender.BackgroundImage = img
    End Sub
    Private Sub controlelements2(ByVal sender As Object, ByVal e As System.EventArgs) Handles homeicon.MouseLeave, websiteicon.MouseLeave, settingsicon.MouseLeave
        Dim img As New Bitmap(homeicon.Width, homeicon.Height)
        Dim brush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(0, img.Height), Color.FromArgb(66, 66, 66), Color.FromArgb(50, 50, 50))
        Dim gr As Graphics = Graphics.FromImage(img)
        gr.FillRectangle(brush, New RectangleF(0, 0, img.Width, img.Height))
        sender.BackgroundImage = img
    End Sub
    Private Sub dsc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set title 
        AddHandler shoutboxweb.CertificateError, AddressOf Me.certintr
        clientstat = "Pre-building interface..."
        LoginForm.logstatbar.Text = "Pre-building interface..."
        Application.DoEvents()
        initsets = LoginForm.initsets

        'try center screen
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        BaseTheme.Text = "DarkSteam Client (v." & My.Application.Info.Version.ToString & ")"
        Me.Text = BaseTheme.Text

        Dim img As New Bitmap(homeicon.Width, homeicon.Height)
        Dim brush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(0, img.Height), Color.FromArgb(66, 66, 66), Color.FromArgb(50, 50, 50))
        Dim gr As Graphics = Graphics.FromImage(img)
        gr.FillRectangle(brush, New RectangleF(0, 0, img.Width, img.Height))
        homeicon.BackgroundImage = img
        websiteicon.BackgroundImage = img
        settingsicon.BackgroundImage = img

        NotifyIcon.BalloonTipText = "DarkSteam Client is idle"

        'load from settings
        LoginForm.logstatbar.Text = "Loading settings..."
        Application.DoEvents()
        settings_load()

        'size on start
        Me.Width = settingswindow.ResolutionX.Text
        Me.Height = settingswindow.ResolutionY.Text
        elementsplacing()

        'Awesomium init
        Awesomium.Core.WebCore.ResourceInterceptor = navinter


        LoginForm.logstatbar.Text = "Loading shoutbox..."
        Application.DoEvents()
        'chatwindow.Invoke(Sub() chatwindow.LoadHTML("Loading..."))
        'chatwindow.Refresh()
        'shoutsloader()
        'shoutboxweb.ExecuteJavascriptWithResult("var textbox1 = document.getElementById('navbar_username');textbox1.value = '" & Decrypt(encloginram).Replace("\", "\\").Replace("'", "\'").Replace("""", "\""") & "';var textbox2 = document.getElementById('navbar_password');textbox2.value = '" & Decrypt(encpassram).Replace("\", "\\").Replace("'", "\'").Replace("""", "\""") & "';document.querySelector('[type=""submit""]').click();")

        LoginForm.logstatbar.Text = "Loading context menus..."
        Application.DoEvents()
        TrayContext.Items.Clear()
        TrayContext.Items.Add("Restore")
        TrayContext.Items.Add("Maximize")
        TrayContext.Items.Add("Minimize")
        TrayContext.Items.Add("To Tray")
        TrayContext.Items.Add("Exit")
        NotifyIcon.ContextMenuStrip = TrayContext


        LoginForm.logstatbar.Text = "Finalizing interface..."
        Application.DoEvents()
        settingsloaded = True
        If settingsloaded = True Then
            settingswindow.SettingsTabControl.Enabled = True
        End If
        hourlyupdate.Start()
        ihaveloaded = 1
        elementsplacing()


        'LoginForm.Invoke(Sub() LoginForm.logstatbar.Text = "Checking for batch commands...")
        batchdownloadstarter()
        'Awesomium.Core.WebCore.Update()
        'Dim stringtosplit = "test;!!!;test2;!!!;test3"
        'Dim myDelims As String() = New String() {";!!!;"}
        'Dim splitstring = stringtosplit.Split(myDelims, StringSplitOptions.None)
        'MsgBox(stringtosplit & vbCrLf & splitstring(0) & vbCrLf & splitstring(1) & vbCrLf & splitstring(2))

    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        If Awesomium.Core.WebCore.IsInitialized = False Then
            'WebCore.Initialize(New WebConfig() With {.LogLevel = Awesomium.Core.LogLevel.None})
            Awesomium.Core.WebCore.Initialize(New Awesomium.Core.WebConfig() With {.UserAgent = "dsc" & My.Application.Info.Version.ToString, .LogLevel = Awesomium.Core.LogLevel.None, .ChildProcessPath = Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\dscweb.exe"})
        End If
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    'Public Sub chatwindowcontext() Handles shoutboxweb.ShowContextMenu
    '    ChatContext.Items.Clear()
    '    ChatContext.Items.Add("Refresh")
    '    shoutboxweb.Invoke(Sub() shoutboxweb.ContextMenuStrip = ChatContext)
    '    ChatContext.Show(Me, Cursor.Position - Me.Bounds.Location)
    'End Sub
    'Private Sub chatcontext_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ChatContext.ItemClicked
    '    Select Case e.ClickedItem.ToString()
    '        Case "Refresh"
    '            shoutboxweb.Reload(True)
    '    End Select
    'End Sub
    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        If Me.Visible = False Then
            Me.Visible = True
            Me.Height = settingswindow.ResolutionY.Text
            Me.Width = settingswindow.ResolutionX.Text
            Me.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
            Me.WindowState = previouswinsize
            If WindowState = FormWindowState.Normal Then
                elementsplacing()
            End If
            Me.ShowInTaskbar = True
        Else
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = True
                Me.Height = settingswindow.ResolutionY.Text
                Me.Width = settingswindow.ResolutionX.Text
                Me.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                Me.WindowState = previouswinsize
                If WindowState = FormWindowState.Normal Then
                    elementsplacing()
                End If
                Me.ShowInTaskbar = True
            Else
                If settingswindow.totray.Checked = True Then
                    Me.previouswinsize = FindForm.WindowState
                    Me.ShowInTaskbar = True
                    Me.WindowState = FormWindowState.Minimized
                    Me.wasminimized = True
                    Me.Visible = False
                Else
                    Me.previouswinsize = FindForm.WindowState
                    Me.ShowInTaskbar = True
                    Me.WindowState = FormWindowState.Minimized
                    Me.wasminimized = True
                    Me.Visible = True
                End If
            End If
        End If
    End Sub
    Private Sub hourlytimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hourlyupdate.Tick
        If ihaveloaded = 1 And updateav = 0 Then
            If supupd = 0 Then
                Dim curpath As String = Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "")
                Dim curexe As String = System.Reflection.Assembly.GetExecutingAssembly().Location
                Dim cmdname As String = curpath & "\dscupdate.cmd"
                Dim inStream As StreamReader
                Dim updreq As HttpWebRequest
                Dim updrep As WebResponse = Nothing
                updreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/dsc.txt")
                updreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
                Try
                    updrep = updreq.GetResponse()
                Catch ex As Exception
                    Messageboxing("No connection!", "Seems like our website is down =(" & vbCrLf & "Unfortunatelly we'll have to exit =(" & vbCrLf & "Please, try again later")
                    Me.TopMost = False
                    Me.Close()
                End Try
                inStream = New StreamReader(updrep.GetResponseStream())
                Dim latever = inStream.ReadLine
                'Dim changelog = inStream.ReadToEnd
                inStream.Close()
                If My.Application.Info.Version.ToString < latever Then
                    doupdate = Nothing
                    updatewindow.updwind.Text = "DarkSteam Client " & latever & " released!"
                    updatewindow.Text = "DarkSteam Client " & latever & " released!"
                    updatewindow.updbrowser.Navigate("https://simbiat.ru/darksteam/api/patchnotes.php")
                    Do While updatewindow.updbrowser.ReadyState <> WebBrowserReadyState.Complete
                        Application.DoEvents()
                    Loop
                    updateav = 1
                    updatewindow.ShowDialog()
                    MsgBox(doupdate)
                    If doupdate = vbYes Then
                        Dim downupd As New WebClient()
                        File.Copy(curexe, curexe & ".old", True)
                        downupd.DownloadFile("https://simbiat.ru/darksteam/api/dsc.exe", curexe & ".update")
                        If System.IO.File.Exists(cmdname) = True Then
                            File.Delete(cmdname)
                        End If
                        Dim i As Integer
                        Dim aryText(7) As String
                        aryText(0) = "@echo off"
                        aryText(1) = "taskkill /f /im """ & Replace(Replace(curexe & "\", curpath, ""), "\", "") & """"
                        aryText(2) = "ping 127.0.0.1 -n 1 >nul"
                        aryText(3) = "del /q /f """ & curexe & """"
                        aryText(4) = "REN """ & curexe & ".update"" """ & Replace(Replace(curexe & "\", curpath, ""), "\", "") & """"
                        aryText(5) = "del /q /f """ & curexe & ".old"""
                        aryText(6) = "start ""DSC"" """ & curexe & """" & fulllistofarg
                        aryText(7) = "exit"

                        Dim objWriter As New System.IO.StreamWriter(cmdname, True)

                        For i = 0 To 7
                            objWriter.WriteLine(aryText(i))
                        Next

                        objWriter.Close()
                        Process.Start(cmdname)
                    Else
                        updateav = 0
                    End If
                ElseIf My.Application.Info.Version.ToString > latever Then
                    doupdate = Nothing
                    Messageboxing("DarkSteam Client may be hacked!", "Seems like the client you're using is newer than the one officially released. It's possible it was modified by a third party and thus may harm your system. It's recommended to redownload the client from official server instead of using this one." & vbCrLf & vbCrLf & "Do you want to continue?")
                    If doupdate <> vbYes Then
                        NotifyIcon.Dispose()
                        Application.Exit()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub traytimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles traytimer.Tick
        If iconstate = 0 Then
            NotifyIcon.Icon = icon1
            iconstate = 1
        Else
            NotifyIcon.Icon = icon2
            iconstate = 0
        End If
        If elapsedtime.Text = "unknown" Then
            elapsedtimesec = 0
        End If
        elapsedtimesec = elapsedtimesec + 1
        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(elapsedtimesec)
        elapsedtime.Text = iSpan.Days.ToString.PadLeft(2, "0"c) & ":" & iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" & iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" & iSpan.Seconds.ToString.PadLeft(2, "0"c)
    End Sub

    Private Sub TransferProgressChanged(ByVal sender As Object, ByVal e As SftpTransferProgressChangedEventArgs)
        dscProgressBar.Value = e.ProgressPercentage
        If Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported And win7progress = 1 Then
            Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100)
        End If
        If PerFileCheckBox = 1 Then
            dscProgressBar2.Value = e.CurrentFileProgressPercentage
        End If
        If StatisticsCheckbox = 1 Then
            currentfiledown.Text = e.SourceItem.Name
            curfilesizenum.Text = FormatFileSize(e.SourceItem.Length)
            filesprocessed.Text = e.FilesProcessed
            speedlbl.Text = FormatFileSize(e.BytesPerSecond) & "\s"
            currentsize.Text = FormatFileSize(e.BytesTransferred + sizeprocessed)
            errneg.Text = errnegcount
            Dim timeleftsec
            If timeleft.Text = "unknown" Then
                timeleftsec = 0
            End If
            If e.BytesPerSecond > 0 And (e.BytesTotal - e.BytesTransferred) >= 0 Then
                timeleftsec = Math.Round((e.BytesTotal - e.BytesTransferred - sizeprocessed) / e.BytesPerSecond)
                Dim iSpan As TimeSpan = TimeSpan.FromSeconds(timeleftsec)
                timeleft.Text = iSpan.Days.ToString.PadLeft(2, "0"c) & ":" & iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" & iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" & iSpan.Seconds.ToString.PadLeft(2, "0"c)
            Else
                timeleft.Text = "unknown"
            End If
            Me.infoToolTip.SetToolTip(Me.currentfiledown, e.SourceItem.Name)
        End If
        If dscProgressBar.Value = 100 Then
            processbtn.Text = "Idle"
            Me.infoToolTip.SetToolTip(Me.processbtn, "I'm not a download button, but I can stop current download")
            processbtn.Enabled = False
            processbtn.SideColor = dscSideButton._Color.Red
            processbtn.DisplayIcon = dscSideButton._Icon.Circle
        Else
            processbtn.Text = "Downloading" & vbCrLf & "Click me to stop!"
            processbtn.Enabled = True
            processbtn.SideColor = dscSideButton._Color.Green
            processbtn.DisplayIcon = dscSideButton._Icon.Square
        End If
    End Sub
    Sub client_ProblemDetected(ByVal sender As Object, ByVal e As SftpProblemDetectedEventArgs)
        ' handle only existing files problem
        failedonfile = e.RemoteItem.Name
        If NetworkSessionExceptionStatus.AsyncError = 1 Or NetworkSessionExceptionStatus.ConnectFailure = 1 Or NetworkSessionExceptionStatus.ConnectionClosed = 1 Or NetworkSessionExceptionStatus.NameResolutionFailure = 1 Or NetworkSessionExceptionStatus.ProtocolError = 1 Or NetworkSessionExceptionStatus.ServerProtocolViolation = 1 Or NetworkSessionExceptionStatus.SocketError = 1 Or NetworkSessionExceptionStatus.Timeout = 1 Or NetworkSessionExceptionStatus.UnclassifiableError = 1 Then
            sizeprocessed = sizeprocessed - e.LocalItem.Length
            errnegcount = errnegcount + 1
            If maxretries > 0 Then
                If prefailedonfile = failedonfile Then
                    If curretries = maxretries Then
                        curretries = 0
                        e.Fail()
                        Return
                    Else
                        curretries = curretries + 1
                    End If
                Else
                    prefailedonfile = failedonfile
                    curretries = 1
                End If
            End If
            e.Retry()
            Return
        End If
        If e.ProblemType = TransferProblemType.CannotTransferFile Then
            If e.RemoteItem.Name = "stdout.txt" Or e.RemoteItem.Name = "stderr.txt" Then
                errnegcount = errnegcount + 1
                e.Skip()
                Return
            Else
                sizeprocessed = sizeprocessed - e.LocalItem.Length
                errnegcount = errnegcount + 1
                If maxretries > 0 Then
                    If prefailedonfile = failedonfile Then
                        If curretries = maxretries Then
                            curretries = 0
                            e.Fail()
                            Return
                        Else
                            curretries = curretries + 1
                        End If
                    Else
                        prefailedonfile = failedonfile
                        curretries = 1
                    End If
                End If
                e.Retry()
                Return
            End If
        End If
        If e.ProblemType <> TransferProblemType.FileExists Then
            sizeprocessed = sizeprocessed - e.LocalItem.Length
            errnegcount = errnegcount + 1
            If maxretries > 0 Then
                If prefailedonfile = failedonfile Then
                    If curretries = maxretries Then
                        curretries = 0
                        e.Fail()
                        Return
                    Else
                        curretries = curretries + 1
                    End If
                Else
                    prefailedonfile = failedonfile
                    curretries = 1
                End If
            End If
            e.Retry()
            Return
        End If

        Dim overflag = False

        ' initialize source and target dates (use whole date granularity)
        Dim sourcecreate = e.RemoteItem.CreationTime.Value.Date
        Dim targetcreate = e.LocalItem.CreationTime.Value.Date
        Dim sourcewrite = e.RemoteItem.LastWriteTime.Value.Date
        Dim targetwrite = e.LocalItem.LastWriteTime.Value.Date
        Dim sourcelength = e.RemoteItem.Length
        Dim targetlength = e.LocalItem.Length
        Dim fInfo As New FileInfo(e.LocalItem.FullPath)
        Dim isReadOnly As Boolean = fInfo.IsReadOnly

        If sourcecreate > targetcreate Then
            overflag = True
        End If
        If sourcewrite > targetwrite Then
            overflag = True
        End If
        If sourcelength <> targetlength Then
            overflag = True
        End If
        If isReadOnly = True Then
            overflag = False
        End If

        If overflag = True Then
            If e.IsReactionPossible(TransferProblemReaction.Resume) Then
                If e.RemoteItem.Name.Length >= 5 Then
                    If e.RemoteItem.Name.Substring(e.RemoteItem.Name.Length - 4) = ".acf" Then
                        e.Overwrite()
                        Return
                    End If
                End If
                If e.RemoteItem.Name.Length >= 10 Then
                    If e.RemoteItem.Name.Substring(e.RemoteItem.Name.Length - 9) = ".manifest" Then
                        e.Overwrite()
                        Return
                    End If
                End If
                If e.RemoteItem.Path.Contains("DarkSteam\Addons\") Or e.RemoteItem.Path.Contains("DarkSteam\Cracks\") Then
                    If isReadOnly = False Then
                        e.Overwrite()
                    Else
                        e.Skip()
                    End If
                End If
                If downres = 1 Then
                    sizeprocessed = sizeprocessed + targetlength
                    e.Resume()
                    Return
                Else
                    e.Overwrite()
                    Return
                End If
            Else
                e.Overwrite()
                Return
            End If
        Else
            sizeprocessed = sizeprocessed + targetlength
            Return
        End If
    End Sub
    Private Sub Traversing(ByVal sender As Object, ByVal e As SftpTraversingEventArgs)
        totalfiles.Text = e.FilesTotal
        gsize.Text = FormatFileSize(e.BytesTotal)
        Select Case (e.TraversingState)
            Case TraversingState.HierarchyRetrieving
                processbtn.Text = "Retrieving hierarchy"
                processbtn.Enabled = True
                processbtn.SideColor = dscSideButton._Color.Yellow
                processbtn.DisplayIcon = dscSideButton._Icon.Square
                Exit Select
        End Select
    End Sub
    Private Sub SetState(ByVal transferring As Boolean)
        If transferring Then
            downloading = True
            traytimer.Enabled = True
            status = "Downloading"
            currentdownload.Text = gameloaded
            Me.infoToolTip.SetToolTip(Me.currentdownload, gameloaded)
        Else
            downloading = False
            gsize.Text = "unknown"
            filesprocessed.Text = "unknown"
            totalfiles.Text = "unknown"
            currentdownload.Text = "N/A"
            Me.infoToolTip.SetToolTip(Me.currentdownload, "N/A")
            currentsize.Text = "unknown"
            traytimer.Stop()
            traytimer.Enabled = False
            status = "Idle"
            NotifyIcon.Icon = icon0
            speedlbl.Text = "0 KB/s"
            elapsedtime.Text = "unknown"
            sizeprocessed = 0
            errnegcount = 0
            errneg.Text = "unknown"
            timeleft.Text = "unknown"
            currentfiledown.Text = "N/A"
            curfilesizenum.Text = FormatFileSize(0)
            speedlbl.Text = FormatFileSize(0) & "\s"
            Me.infoToolTip.SetToolTip(Me.currentfiledown, "N/A")
            dscProgressBar.Value = 0
            dscProgressBar2.Value = 0
            If Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported And win7progress = 1 Then
                Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress)
            End If
            processbtn.Text = "Idle"
            Me.infoToolTip.SetToolTip(Me.processbtn, "I'm not a download button, but I can stop current download")
            processbtn.Enabled = False
            processbtn.SideColor = dscSideButton._Color.Red
            processbtn.DisplayIcon = dscSideButton._Icon.Circle
        End If
    End Sub

    Private Sub traydetails_Tick(sender As System.Object, e As System.EventArgs) Handles traydetails.Tick
        If status = "Idle" Then
            NotifyIcon.BalloonTipText = "DarkSteam Client is idle"
        Else
            NotifyIcon.BalloonTipText = "DarkSteam Client is downloading" & Chr(10) & gameloaded & Chr(10) & "Current speed: " & speedlbl.Text & Chr(10) & "Completed: " & dscProgressBar.Value & "%"
        End If
    End Sub
    Private Sub NotifyIcon_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseMove
        ' only show balloon if not already shown or it will flicker!
        If balloonShown = False Then
            balloonShown = True
            NotifyIcon.ShowBalloonTip(1000)
        End If
    End Sub
    Private Sub NotifyIcon_BalloonTipClosed(sender As Object, e As System.EventArgs) Handles NotifyIcon.BalloonTipClosed
        balloonShown = False ' clear flag
    End Sub

    Private Sub NotifyIcon_BalloonTipShown(sender As Object, e As System.EventArgs) Handles NotifyIcon.BalloonTipShown
        balloonShown = True ' set flag
    End Sub

    Private Sub dscWindow_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If gameloaded = vbNullString Then
            Awesomium.Core.WebCore.Shutdown()
            NotifyIcon.Dispose()
            Application.Exit()
            End
        Else
            'If Connect() Then
            'Disconnect()
            Awesomium.Core.WebCore.Shutdown()
            NotifyIcon.Dispose()
            Application.Exit()
            End
        End If
    End Sub
    Private Sub TrayContext_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TrayContext.ItemClicked
        Select Case e.ClickedItem.ToString()
            Case "Exit"
                Awesomium.Core.WebCore.Shutdown()
                NotifyIcon.Dispose()
                Application.Exit()
            Case "Restore"
                If Me.Visible = False Then
                    Me.Visible = True
                End If
                Me.Height = settingswindow.ResolutionY.Text
                Me.Width = settingswindow.ResolutionX.Text
                Me.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                Me.WindowState = previouswinsize
                If WindowState = FormWindowState.Normal Then
                    elementsplacing()
                End If
                Me.ShowInTaskbar = True
            Case "To Tray"
                Me.previouswinsize = FindForm.WindowState
                Me.ShowInTaskbar = True
                Me.WindowState = FormWindowState.Minimized
                Me.wasminimized = True
                Me.Visible = False
            Case "Minimize"
                Me.previouswinsize = FindForm.WindowState
                Me.ShowInTaskbar = True
                Me.WindowState = FormWindowState.Minimized
                Me.wasminimized = True
                Me.Visible = True
            Case "Maximize"
                Me.ShowInTaskbar = True
                Me.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                Me.WindowState = FormWindowState.Maximized
                elementsplacing()
                Me.Visible = True
        End Select
    End Sub

    'Private Sub shoutstimer_Tick(sender As Object, e As EventArgs) Handles shoutstimer.Tick
    '    If ShoutsUpdater.IsBusy = False Then
    '        'ShoutsUpdater.CancelAsync()
    '        ShoutsUpdater.RunWorkerAsync()
    '    End If
    'End Sub
    'Public Sub lastactivity_update()
    '    Dim lastactreq As HttpWebRequest
    '    Dim lastactres As WebResponse = Nothing
    '    lastactreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/lastactupd.php?login=" & encloginram & "&pass=" & Encrypt(salt & UCase(md5hpass)))
    '    lastactreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
    '    Try
    '        lastactres = lastactreq.GetResponse()
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Public Sub certintr(ByVal sender As Object, ByVal e As Awesomium.Core.CertificateErrorEventArgs)
        e.Handled = True
        e.Ignore = True
    End Sub
    Private Sub linkintr() Handles navinter.PropertyChanged
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf linkintr))
        Else
            If navinter.linktocheck <> Nothing Then
                If navinter.linktocheck.Contains("/member.php?u=") Then
                    clickuserid = Regex.Replace(navinter.linktocheck, "(^[^=]*=)+", "")
                    Dim clickusernamestream As StreamReader
                    Dim clickusernamereq As HttpWebRequest
                    Dim clickusernameres As WebResponse = Nothing
                    clickusernamereq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/usernamegrab.php?id=" & clickuserid)
                    clickusernamereq.UserAgent = "dsc" & My.Application.Info.Version.ToString
                    Try
                        clickusernameres = clickusernamereq.GetResponse()
                    Catch ex As Exception
                    End Try
                    clickusernamestream = New StreamReader(clickusernameres.GetResponseStream())
                    clickusername = clickusernamestream.ReadToEnd
                    clickusernamestream.Close()
                    WebUserContext.Items.Clear()
                    WebUserContext.Items.Add("@" & clickusername)
                    WebUserContext.Items.Add("Whisper")
                    WebUserContext.Items.Add("View profile")
                    WebUserContext.Items.Add("Send PM")
                    WebUserContext.Show(Me, Cursor.Position - Me.Bounds.Location)
                    navinter.linktocheck = Nothing
                ElseIf navinter.linktocheck.StartsWith("dsc://view/") Then
                    navinter.linktocheck = Nothing
                ElseIf navinter.linktocheck.StartsWith("dsc://manifests/") Then
                    nocommondir = 1
                    download_func()
                ElseIf navinter.linktocheck.StartsWith("dsc://install/") Then
                    nocommondir = 0
                    download_func()
                ElseIf navinter.linktocheck.StartsWith("dsc://crack/") Then
                    Dim acdownpath As String = Nothing
                    If navinter.linktocheck.StartsWith("dsc://crack/") Then
                        acdownpath = crack1path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://crack2/") Then
                        acdownpath = crack2path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://crack3/") Then
                        acdownpath = crack3path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://crack4/") Then
                        acdownpath = crack4path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://crack5/") Then
                        acdownpath = crack5path
                    End If
                    download_func(acdownpath)
                ElseIf navinter.linktocheck.StartsWith("dsc://addon/") Then
                    Dim acdownpath As String = Nothing
                    If navinter.linktocheck.StartsWith("dsc://addon/") Then
                        acdownpath = addon1path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://addon2/") Then
                        acdownpath = addon2path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://addon3/") Then
                        acdownpath = addon3path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://addon4/") Then
                        acdownpath = addon4path
                    End If
                    If navinter.linktocheck.StartsWith("dsc://addon5/") Then
                        acdownpath = addon5path
                    End If
                    download_func(acdownpath)
                End If
            End If
        End If
    End Sub
    Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As FileDownloadProgressChangedEventArgs)
        dscProgressBar.Value = e.ProgressPercentage
    End Sub
    Private Sub DownloadCompleted(ByVal sender As Object, ByVal e As FileDownloadCompletedEventArgs)

    End Sub
    Public Sub StartDownload(ByVal URL As String, ByVal LocalFilePath As String)
        Dim wClient As New DownloadFileAsyncExtended

        '// Add Event handlers, so we can update the progress to the user.
        AddHandler wClient.DownloadProgressChanged, AddressOf DownloadProgressChanged
        AddHandler wClient.DownloadCompleted, AddressOf DownloadCompleted

        '// IMPORTANT !!
        '// If you don't add this line, then all events are raised on a separate
        '// thread and you will get cross-thread errors when accessing the Listview
        '// or other controls directly in the raised events.
        wClient.SynchronizingObject = Me

        '// Update frequency. You can select NoDelay, HalfSecond or Second.
        '// HalfSecond and Second will prevent the DownloadProgressChanged event
        '// from firing continuously and hogging CPU when updating the controls.
        '// If you download small files that could be downloaded within a second,
        '// then set it to NoDelay or the progress might not be visible.
        wClient.ProgressUpdateFrequency = DownloadFileAsyncExtended.UpdateFrequency.Second

        '// The method to actually download a file. The userToken parameter can
        '// for example be a control you wish to update in the DownloadProgressChanged
        '// and DownloadCompleted events. A ListViewItem in this example.
        wClient.DowloadFileAsync(URL, LocalFilePath, Me)
        While wClient.IsBusy = True
            Application.DoEvents()
        End While

        '// Set wClient to Nothing, because we don't need it anymore.
        wClient = Nothing
    End Sub
    Private Sub BGDownloader_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BGDownloader.DoWork
        If supconf = 1 And Me.extrahide = True Then
            Me.wasminimized = True
            Me.ShowInTaskbar = True
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
        End If

        ftptocancel = 0

        If steamlocation = vbNullString Then
            Exit Sub
        Else
            If Not Directory.Exists(steamlocation) Then
                Directory.CreateDirectory(steamlocation)
            End If
            If Not Directory.Exists(steamlocation & "\steamapps") Then
                Directory.CreateDirectory(steamlocation & "\steamapps")
            End If
        End If

        steamlocation = steamlocation.Replace("/", "\")

        If username = "" Then
            username = Decrypt(encloginram)
        End If
        If password = "" Then
            password = Decrypt(encpassram)
        End If
        If password = vbNullString Then
            Messageboxing("Wrong password!", "Empty password was provided!")
            Exit Sub
        End If

        Try

            FTP = New Sftp
            FTP.Settings.UseLargeBuffers = True
            FTP.Settings.MultiFileLinkMode = LinkProcessingMode.SkipLinks
            FTP.Settings.RestoreDateTime = ItemDateTimes.All
            FTP.Settings.SshParameters.Compression = False
            FTP.Timeout = 180000
            Dim par As New SshParameters
            par.Compression = True

            FTP.Connect(ip, 19913, par)
            If usersgroup = 2 Then
                'FTP.Login(username, password)
                FTP.Login("dsappregular", "gq75g3fy")
            ElseIf usersgroup = 13 Then
                FTP.Login("dsapppl", "4QB1xY2H")
            End If


            AddHandler FTP.TransferProgressChanged, AddressOf TransferProgressChanged
            AddHandler FTP.Traversing, AddressOf Traversing
            AddHandler FTP.ProblemDetected, AddressOf client_ProblemDetected
        Catch x As SftpException
            Messageboxing("Failed to connect to server!", x.Message)
            Exit Sub
        End Try

        If Logging = 1 Then
            FTP.LogWriter = New Rebex.FileLogWriter(currentlog, Rebex.LogLevel.Verbose)
        End If

        'see if ACF or NCF
        If crackdown <> Nothing Then
            Try
                sizeprocessed = 0
                errnegcount = 0
                If Not Directory.Exists(steamlocation & "\steamapps\common") Then
                    Directory.CreateDirectory(steamlocation & "\steamapps\common")
                End If
                FTP.Download(crackdown, steamlocation & "\steamapps\common", TraversalMode.Recursive, TransferMethod.Copy, ActionOnExistingFiles.SkipAll)
                If invis = 0 Then
                    'lastactivity_update()
                End If
            Catch ex As Exception
                FTP.Disconnect()
                SetState(False)
                If ftptocancel = 0 Then
                    Messageboxing("Failed to download common files!", "Failed on " & failedonfile & vbCrLf & vbCrLf & ex.Message)
                End If
                Exit Sub
            End Try
            crackdown = Nothing
        Else
            If nocommondir = 1 Then
                Select Case format
                    Case "NCF"
                        SetState(True)
                        Dim files As String() = Split(manifests, ",")
                        For Each filetd As String In files
                            If File.Exists(steamlocation & "\steamapps\" & filetd) = False Then
                                currentfiledown.Text = filetd
                                StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\steamapps\" & filetd)
                            Else
                                Dim fInfo As New FileInfo(steamlocation & "\steamapps\" & filetd)
                                Dim isReadOnly As Boolean = fInfo.IsReadOnly
                                If isReadOnly = False Then
                                    currentfiledown.Text = filetd
                                    StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\steamapps\" & filetd)
                                End If
                            End If
                        Next
                        If invis = 0 Then
                            'lastactivity_update()
                        End If
                    Case "ACF"
                        SetState(True)
                        'download .acf
                        sizeprocessed = 0
                        errnegcount = 0
                        Dim newpath = Nothing
                        Dim linetochange = Nothing
                        Dim pathshch = 0
                        If File.Exists(steamlocation & "\steamapps\" & "appmanifest_" & appid & ".acf") = False Then
                            currentfiledown.Text = "appmanifest_" & appid & ".acf"
                            StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt("appmanifest_" & appid & ".acf"), steamlocation & "\steamapps\" & "appmanifest_" & appid & ".acf")
                            For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & appid & ".acf")
                                If k.ToLower.Contains("appinstalldir") Then
                                    pathshch = 1
                                    linetochange = k
                                    Dim gamecom = commonfolder.Split("\")
                                    If k.Contains("\\") Then
                                        newpath = (vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """").Replace("\", "\\")
                                    Else
                                        newpath = vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """"
                                    End If
                                    Exit For
                                End If
                            Next
                            If pathshch = 1 Then
                                Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & appid & ".acf")
                                filetoupd = filetoupd.Replace(linetochange, newpath)
                                Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & appid & ".acf"
                                Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                objWriter.Write(filetoupd)
                                objWriter.Close()
                            End If
                        Else
                            Dim fInfo As New FileInfo(steamlocation & "\steamapps\" & "appmanifest_" & appid & ".acf")
                            Dim isReadOnly As Boolean = fInfo.IsReadOnly
                            If isReadOnly = False Then
                                currentfiledown.Text = "appmanifest_" & appid & ".acf"
                                StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt("appmanifest_" & appid & ".acf"), steamlocation & "\steamapps\" & "appmanifest_" & appid & ".acf")
                                pathshch = 0
                                For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & appid & ".acf")
                                    If k.ToLower.Contains("appinstalldir") Then
                                        pathshch = 1
                                        linetochange = k
                                        Dim gamecom = commonfolder.Split("\")
                                        If k.Contains("\\") Then
                                            newpath = (vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """").Replace("\", "\\")
                                        Else
                                            newpath = vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """"
                                        End If
                                        Exit For
                                    End If
                                Next
                                If pathshch = 1 Then
                                    Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & appid & ".acf")
                                    filetoupd = filetoupd.Replace(linetochange, newpath)
                                    Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & appid & ".acf"
                                    Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                    objWriter.Write(filetoupd)
                                    objWriter.Close()
                                End If
                            End If
                        End If
                        If invis = 0 Then
                            'lastactivity_update()
                        End If
                        'download manifests
                        If manifests <> Nothing And manifests <> "" Then
                            If Not Directory.Exists(steamlocation & "\depotcache") Then
                                Directory.CreateDirectory(steamlocation & "\depotcache")
                            End If
                            Dim files As String() = Split(manifests, ",")
                            For Each filetd As String In files
                                If File.Exists(steamlocation & "\depotcache\" & filetd) = False Then
                                    currentfiledown.Text = filetd
                                    StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\depotcache\" & filetd)
                                Else
                                    Dim fInfo As New FileInfo(steamlocation & "\depotcache\" & filetd)
                                    Dim isReadOnly As Boolean = fInfo.IsReadOnly
                                    If isReadOnly = False Then
                                        currentfiledown.Text = filetd
                                        StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\depotcache\" & filetd)
                                    End If
                                End If
                            Next
                            If invis = 0 Then
                                'lastactivity_update()
                            End If
                        End If
                End Select
            Else
                Select Case format
                    Case "NCF"
                        SetState(True)
                        For gamerow = 0 To gamebank.GetUpperBound(gamebank.Rank - 1)
                            If gamebank(gamerow)(8) = commonfolder Then
                                Dim files As String() = Split(gamebank(gamerow)(11), ",")
                                For Each filetd As String In files
                                    If File.Exists(steamlocation & "\steamapps\" & filetd) = False Then
                                        currentfiledown.Text = filetd
                                        StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\steamapps\" & filetd)
                                    Else
                                        Dim fInfo As New FileInfo(steamlocation & "\steamapps\" & filetd)
                                        Dim isReadOnly As Boolean = fInfo.IsReadOnly
                                        If isReadOnly = False Then
                                            currentfiledown.Text = filetd
                                            StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\steamapps\" & filetd)
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        If invis = 0 Then
                            'lastactivity_update()
                        End If
                    Case "ACF"
                        SetState(True)
                        'download .acf
                        sizeprocessed = 0
                        errnegcount = 0
                        For gamerow = 0 To gamebank.GetUpperBound(gamebank.Rank - 1)
                            If gamebank(gamerow)(8) = commonfolder Then
                                Dim newpath = Nothing
                                Dim linetochange = Nothing
                                Dim pathshch = 0
                                If File.Exists(steamlocation & "\steamapps\" & "appmanifest_" & gamebank(gamerow)(0) & ".acf") = False Then
                                    currentfiledown.Text = "appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                    StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt("appmanifest_" & gamebank(gamerow)(0) & ".acf"), steamlocation & "\steamapps\" & "appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                    For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        If k.ToLower.Contains("userid") Then
                                            pathshch = 1
                                            linetochange = k
                                            newpath = ""
                                            Exit For
                                        End If
                                    Next
                                    If pathshch = 1 Then
                                        Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        filetoupd = filetoupd.Replace(ControlChars.Cr & ControlChars.Lf & linetochange, newpath)
                                        filetoupd = filetoupd.Replace(ControlChars.Lf & ControlChars.Cr & linetochange, newpath)
                                        filetoupd = filetoupd.Replace(ControlChars.Lf & linetochange, newpath)
                                        filetoupd = filetoupd.Replace(ControlChars.Cr & linetochange, newpath)
                                        Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                        objWriter.Write(filetoupd)
                                        objWriter.Close()
                                    End If
                                    pathshch = 0
                                    For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        If k.ToLower.Contains("lastowner") Then
                                            pathshch = 1
                                            linetochange = k
                                            newpath = ""
                                            Exit For
                                        End If
                                    Next
                                    If pathshch = 1 Then
                                        Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        filetoupd = filetoupd.Replace(ControlChars.Cr & ControlChars.Lf & linetochange, newpath)
                                        filetoupd = filetoupd.Replace(ControlChars.Lf & ControlChars.Cr & linetochange, newpath)
                                        filetoupd = filetoupd.Replace(ControlChars.Lf & linetochange, newpath)
                                        filetoupd = filetoupd.Replace(ControlChars.Cr & linetochange, newpath)
                                        Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                        objWriter.Write(filetoupd)
                                        objWriter.Close()
                                    End If
                                    pathshch = 0
                                    For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        If k.ToLower.Contains("appinstalldir") Then
                                            pathshch = 1
                                            linetochange = k
                                            Dim gamecom = commonfolder.Split("\")
                                            If k.Contains("\\") Then
                                                newpath = (vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """").Replace("\", "\\")
                                            Else
                                                newpath = vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """"
                                            End If
                                            Exit For
                                        End If
                                    Next
                                    If pathshch = 1 Then
                                        Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        filetoupd = filetoupd.Replace(linetochange, newpath)
                                        Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                        objWriter.Write(filetoupd)
                                        objWriter.Close()
                                    End If
                                Else
                                    Dim fInfo As New FileInfo(steamlocation & "\steamapps\" & "appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                    Dim isReadOnly As Boolean = fInfo.IsReadOnly
                                    If isReadOnly = False Then
                                        currentfiledown.Text = "appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                        StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt("appmanifest_" & gamebank(gamerow)(0) & ".acf"), steamlocation & "\steamapps\" & "appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                        For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                            If k.ToLower.Contains("userid") Then
                                                pathshch = 1
                                                linetochange = k
                                                newpath = ""
                                                Exit For
                                            End If
                                        Next
                                        If pathshch = 1 Then
                                            Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                            filetoupd = filetoupd.Replace(ControlChars.Cr & ControlChars.Lf & linetochange, newpath)
                                            filetoupd = filetoupd.Replace(ControlChars.Lf & ControlChars.Cr & linetochange, newpath)
                                            filetoupd = filetoupd.Replace(ControlChars.Lf & linetochange, newpath)
                                            filetoupd = filetoupd.Replace(ControlChars.Cr & linetochange, newpath)
                                            Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                            objWriter.Write(filetoupd)
                                            objWriter.Close()
                                        End If
                                        pathshch = 0
                                        For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                            If k.ToLower.Contains("lastowner") Then
                                                pathshch = 1
                                                linetochange = k
                                                newpath = ""
                                                Exit For
                                            End If
                                        Next
                                        If pathshch = 1 Then
                                            Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                            filetoupd = filetoupd.Replace(ControlChars.Cr & ControlChars.Lf & linetochange, newpath)
                                            filetoupd = filetoupd.Replace(ControlChars.Lf & ControlChars.Cr & linetochange, newpath)
                                            filetoupd = filetoupd.Replace(ControlChars.Lf & linetochange, newpath)
                                            filetoupd = filetoupd.Replace(ControlChars.Cr & linetochange, newpath)
                                            Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                            objWriter.Write(filetoupd)
                                            objWriter.Close()
                                        End If
                                        pathshch = 0
                                        For Each k As String In File.ReadLines(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                            If k.ToLower.Contains("appinstalldir") Then
                                                pathshch = 1
                                                linetochange = k
                                                Dim gamecom = commonfolder.Split("\")
                                                If k.Contains("\\") Then
                                                    newpath = (vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """").Replace("\", "\\")
                                                Else
                                                    newpath = vbTab & vbTab & """appinstalldir""" & vbTab & vbTab & """" & steamlocation & "\steamapps\common\" & gamecom(UBound(gamecom)) & """"
                                                End If
                                                Exit For
                                            End If
                                        Next
                                        If pathshch = 1 Then
                                            Dim filetoupd As String = File.ReadAllText(steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf")
                                            filetoupd = filetoupd.Replace(linetochange, newpath)
                                            Dim FILE_NAME As String = steamlocation & "\steamapps\appmanifest_" & gamebank(gamerow)(0) & ".acf"
                                            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
                                            objWriter.Write(filetoupd)
                                            objWriter.Close()
                                        End If
                                    End If
                                End If
                                If gamebank(gamerow)(11) <> Nothing And gamebank(gamerow)(11) <> "" Then
                                    If Not Directory.Exists(steamlocation & "\depotcache") Then
                                        Directory.CreateDirectory(steamlocation & "\depotcache")
                                    End If
                                    Dim files As String() = Split(gamebank(gamerow)(11), ",")
                                    For Each filetd As String In files
                                        If File.Exists(steamlocation & "\depotcache\" & filetd) = False Then
                                            currentfiledown.Text = filetd
                                            StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\depotcache\" & filetd)
                                        Else
                                            Dim fInfo As New FileInfo(steamlocation & "\depotcache\" & filetd)
                                            Dim isReadOnly As Boolean = fInfo.IsReadOnly
                                            If isReadOnly = False Then
                                                currentfiledown.Text = filetd
                                                StartDownload("https://simbiat.ru/darksteam/api/mandown.php?file=" & Encrypt(filetd), steamlocation & "\depotcache\" & filetd)
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        If invis = 0 Then
                            'lastactivity_update()
                        End If
                End Select
                'download common folder
                If gameisplus = 0 Then
                    If usersgroup <> 13 Then
                        Messageboxing("Failed to download common files!", "Subscription required")
                        Exit Sub
                    End If
                End If
                Dim compath As String() = Split(commonfolder, "\")
                Dim comset = New FileSet(commonfolder)
                comset.Include("**", TraversalMode.Recursive)
                comset.Exclude("**.lnk", TraversalMode.Recursive)
                comset.Exclude("**.url", TraversalMode.Recursive)
                Try
                    sizeprocessed = 0
                    errnegcount = 0
                    If nocommondir = 0 Then
                        If Not Directory.Exists(steamlocation & "\steamapps\common") Then
                            Directory.CreateDirectory(steamlocation & "\steamapps\common")
                        End If
                        If Not Directory.Exists(steamlocation & "\steamapps\common\" & compath(UBound(compath))) Then
                            Directory.CreateDirectory(steamlocation & "\steamapps\common\" & compath(UBound(compath)))
                        End If
                        FTP.Download(comset, steamlocation & "\steamapps\common\" & compath(UBound(compath)), TransferMethod.Copy, ActionOnExistingFiles.SkipAll)
                        If invis = 0 Then
                            'lastactivity_update()
                        End If
                    End If
                Catch ex As Exception
                    FTP.Disconnect()
                    SetState(False)
                    If ftptocancel = 0 Then
                        Messageboxing("Failed to download common files!", "Failed on " & failedonfile & vbCrLf & vbCrLf & ex.Message)
                    End If
                    Exit Sub
                End Try
            End If
        End If
        FTP.Disconnect()

        If supconf = 0 Then
            SetState(False)
            If autoproc = False Then
                Messageboxing("Download Completed!", "Your download of " & gameloaded & " is now completed" & vbNewLine & "Enjoy :)")
            End If
        ElseIf supconf = 1 Then
            Awesomium.Core.WebCore.Shutdown()
            NotifyIcon.Dispose()
            Application.Exit()
        End If
    End Sub
    Private Sub sdateformatlab_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx")
    End Sub
    Private Sub latestgamesgroup_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            latestgamescontext.Items.Clear()
            latestgamescontext.Items.Add("Refresh")
            sender.ContextMenuStrip = latestgamescontext
        End If
    End Sub
    Private Sub processbtn_Click(sender As Object, e As EventArgs) Handles processbtn.Click
        If BGDownloader.IsBusy = True Then
            ftptocancel = 1
            FTP.Disconnect()
            BGDownloader.CancelAsync()
            SetState(False)
            Messageboxing("Download stopped!", "Your download of " & gameloaded & " was stopped!")
        End If
    End Sub
    Public Sub download_func(Optional foldertodownoad As String = Nothing)
        crackdown = foldertodownoad
        If downdir <> "" And downdir <> Nothing Then
            steamlocation = downdir
        Else
            If setpath = "" Or setpath = Nothing Then
                setpath = SteamLoc()
            End If
            steamlocation = setpath
        End If
        downconf = Nothing
        If settingswindow.autostart.Checked = False And supconf = 0 Then
            If crackdown <> Nothing Then
                If crackdown = crack1path Then
                    Messageboxing("Download confirmation", "Do you want to download crack 1 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = crack2path Then
                    Messageboxing("Download confirmation", "Do you want to download crack 2 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = crack3path Then
                    Messageboxing("Download confirmation", "Do you want to download crack 3 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = crack4path Then
                    Messageboxing("Download confirmation", "Do you want to download crack 4 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = crack5path Then
                    Messageboxing("Download confirmation", "Do you want to download crack 5 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = addon1path Then
                    Messageboxing("Download confirmation", "Do you want to download addon 1 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = addon2path Then
                    Messageboxing("Download confirmation", "Do you want to download addon 2 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = addon3path Then
                    Messageboxing("Download confirmation", "Do you want to download addon 3 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = addon4path Then
                    Messageboxing("Download confirmation", "Do you want to download addon 4 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf crackdown = addon5path Then
                    Messageboxing("Download confirmation", "Do you want to download addon 5 for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                End If
            Else
                If nocommondir = 0 Then
                    Messageboxing("Download confirmation", "Do you want to download " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                ElseIf nocommondir = 1 Then
                    Messageboxing("Download confirmation", "Do you want to download manifests for " & gameloaded & vbCrLf & "to " & steamlocation & "?")
                End If
            End If
        Else
            downconf = vbYes
        End If
        If downconf = vbYes Then
            traytimer.Start()
            BGDownloader.RunWorkerAsync()
        End If
    End Sub
    Private Sub SettingsCall_Click(sender As Object, e As EventArgs)
        settingswindow.ShowDialog()
    End Sub

    Private Sub websiteicon_Click(sender As Object, e As EventArgs) Handles websiteicon.Click
        System.Diagnostics.Process.Start("https://simbiat.ru/darksteam")
    End Sub

    Private Sub settingsicon_Click(sender As Object, e As EventArgs) Handles settingsicon.Click
        settingswindow.ShowDialog()
    End Sub
    Public Sub homeicon_Click(sender As Object, e As EventArgs) Handles homeicon.Click

    End Sub
    Private Sub webControl_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs)
        If dlctextboxloaded = 1 Then
            e.Cancel = True
            System.Diagnostics.Process.Start(e.Url.ToString)
        End If
    End Sub
    Public Sub dlcUpdater_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Dim nodlcsup = "This game either does not support DLCs, have only subscription-based DLCs or there are none available on the server"
        Dim currworker = e.Argument
        Dim currgame = gameloaded

        If alldlcids <> "" And alldlcnames <> "" Then
            If currgame = gameloaded Then
                dlctextboxloaded = 0
                dlctextboxloaded = 1
            Else
                Exit Sub
            End If
            Dim dlcstoappend = Nothing
            Dim dlcwebtext = Nothing
            Dim alldlcidssplited = Split(alldlcids, ";")
            Dim alldlcnamessplitted = Split(alldlcnames, ";")
            If currgame = gameloaded Then
                dlctextboxloaded = 1
            Else
                Exit Sub
            End If
        Else
            If currgame = gameloaded Then
                dlctextboxloaded = 0
                dlctextboxloaded = 1
            Else
                Exit Sub
            End If
        End If
    End Sub
    Public Sub settings_load()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf settings_load))
        Else
            Dim settingsarray = Me.initsets.Split(New String() {";!!!;"}, StringSplitOptions.None)
            Dim settray = settingsarray(0)
            Dim setauto = settingsarray(1)
            Dim setlogs = settingsarray(2)
            If settingsarray(3) <> Nothing And settingsarray(3) <> "" And settingsarray(3) <> "exe" Then
                Me.setpath = Decrypt(settingsarray(3))
            Else
                Me.setpath = SteamLoc()
            End If
            Dim setasscroll = settingsarray(4)
            'Dim shoutenable = settingsarray(5)
            'Dim settingshouttimer = settingsarray(6)
            'Dim settingshoutcount = settingsarray(7)
            Dim settingperfile = settingsarray(8)
            Dim settingstatena = settingsarray(9)
            Dim settingsdate = settingsarray(10)
            Dim settingslateadd = settingsarray(11)
            Dim settingslateupd = settingsarray(12)
            Dim settingsinvis = settingsarray(13)
            Dim settingsgamedet = settingsarray(14)
            Dim settingsdownres = settingsarray(15)
            Dim settingsresx = settingsarray(16)
            Dim settingsresy = settingsarray(17)
            Dim settingsaccupd = settingsarray(18)
            Dim settingsmaxretries = settingsarray(22)
            'Dim settingsshoutupdsounden = settingsarray(19)
            Dim settingsaltshupdsound = ""
            If settingsarray(20) <> Nothing And settingsarray(20) <> "" And settingsarray(20) <> "default" Then
                settingsaltshupdsound = Decrypt(settingsarray(20))
            Else
                settingsaltshupdsound = ""
            End If
            Dim settingwin7prog = settingsarray(23)
            Dim settingwin7snap = settingsarray(24)
            Dim settinglink = settingsarray(27)
            Dim settinghourupd = settingsarray(25)
            Dim settinghourgam = settingsarray(26)
            Dim settinclicksnd = settingsarray(28)
            If settinglink = 1 Then
                settingswindow.linkinterceptcheck.Checked = True
                regdsclinks()
            Else
                settingswindow.linkinterceptcheck.Checked = False
                remdsclinks()
            End If
            If settingwin7snap = 1 Then
                settingswindow.aerosnapcheck.Checked = True
            Else
                settingswindow.aerosnapcheck.Checked = False
            End If
            If settingwin7prog = 1 Then
                settingswindow.tbprogcheck.Checked = True
                Me.win7progress = 1
            Else
                settingswindow.tbprogcheck.Checked = False
                Me.win7progress = 0
            End If
            Me.maxretries = settingsmaxretries
            settingswindow.set_maxretries.Text = Me.maxretries
            If settingsaccupd = 1 Then
                settingswindow.accupdchbox.Checked = True
            Else
                settingswindow.accupdchbox.Checked = False
            End If
            If settingsresx = 0 Then
                settingswindow.ResolutionX.Text = Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.67)
            Else
                settingswindow.ResolutionX.Text = settingsresx
            End If
            If settingsresy = 0 Then
                settingswindow.ResolutionY.Text = Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.67)
            Else
                settingswindow.ResolutionY.Text = settingsresy
            End If
            If settingsgamedet = 1 Then
                Me.downres = 1
                settingswindow.downresume.Checked = True
            Else
                Me.downres = 0
                settingswindow.downresume.Checked = False
            End If
            If settray = 1 Then
                settingswindow.totray.Checked = True
            Else
                settingswindow.totray.Checked = False
            End If
            If setauto = 1 Then
                Me.autoproc = True
                settingswindow.autostart.Checked = True
            Else
                Me.autoproc = False
                settingswindow.autostart.Checked = False
            End If
            If setlogs = 1 Then
                settingswindow.Logging.Checked = True
                Me.Logging = 1
            Else
                settingswindow.Logging.Checked = False
                Me.Logging = 0
            End If
            If Me.setpath = "exe" Or Me.setpath = Nothing Or Me.setpath = "" Then
                Me.setpath = SteamLoc()
                settingswindow.steamdlbox.Text = Me.setpath
            Else
                settingswindow.steamdlbox.Text = Decrypt(Me.setpath)
                Me.setpath = settingswindow.steamdlbox.Text
            End If
            'If shoutenable = 1 Then
            '    Me.shoutena = 1
            '    Me.shoutboxweb.Visible = True
            'Else
            '    Me.shoutena = 0
            '    Me.shoutboxweb.Visible = False
            'End If
            'If settingstatena = 1 Then
            settingswindow.StatisticsCheckbox.Checked = True
            Me.StatisticsGroupBox.Visible = True
            Me.StatisticsCheckbox = 1
            'Else
            '   settingswindow.StatisticsCheckbox.Checked = False
            '   Me.StatisticsGroupBox.Visible = False
            '   Me.StatisticsCheckbox = 0
            'End If
            'If settingperfile = 1 Then
            settingswindow.PerFileCheckBox.Checked = True
            Me.PerFileCheckBox = 1
            Me.dscProgressBar2.Visible = True
            'Else
            'settingswindow.PerFileCheckBox.Checked = False
            'Me.PerFileCheckBox = 0
            'Me.dscProgressBar2.Visible = False
            'End If
            'Me.shoutupdint = settingshouttimer.Substring(0, settingshouttimer.Length - 3)
        End If
    End Sub

    Private Sub mainwindwebcontext(sender As Object, e As Awesomium.Core.ContextMenuEventArgs)

    End Sub

    Private Sub noticebrowcontext(sender As Object, e As Awesomium.Core.ContextMenuEventArgs)

    End Sub

    Private Sub NewsFeedTextBoxcontext(sender As Object, e As Awesomium.Core.ContextMenuEventArgs)

    End Sub

    'Private Sub chatwindowcontext(sender As Object, e As Awesomium.Core.ContextMenuEventArgs) Handles shoutboxweb.ShowContextMenu

    'End Sub

    'Private Sub chatwindowloaded(sender As Object, e As Awesomium.Core.UrlEventArgs)

    'End Sub
End Class
