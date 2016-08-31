<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dscWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dscWindow))
        Me.infoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.normalToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.traydetails = New System.Windows.Forms.Timer(Me.components)
        Me.AdsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.shoutstimer = New System.Windows.Forms.Timer(Me.components)
        Me.ShoutsUpdater = New System.ComponentModel.BackgroundWorker()
        Me.traytimer = New System.Windows.Forms.Timer(Me.components)
        Me.BGDownloader = New System.ComponentModel.BackgroundWorker()
        Me.hourlyupdate = New System.Windows.Forms.Timer(Me.components)
        Me.BaseTheme = New dsc.dscTheme()
        Me.shoutboxweb = New Awesomium.Windows.Forms.WebControl(Me.components)
        Me.websiteicon = New System.Windows.Forms.PictureBox()
        Me.settingsicon = New System.Windows.Forms.PictureBox()
        Me.homeicon = New System.Windows.Forms.PictureBox()
        Me.StatisticsGroupBox = New System.Windows.Forms.GroupBox()
        Me.gamesshownlab = New System.Windows.Forms.Label()
        Me.gamesshowncur = New System.Windows.Forms.Label()
        Me.errneg = New System.Windows.Forms.Label()
        Me.timeleft = New System.Windows.Forms.Label()
        Me.gamestotalshown = New System.Windows.Forms.Label()
        Me.errneglab = New System.Windows.Forms.Label()
        Me.elapsedtime = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Elapsedtimelab = New System.Windows.Forms.Label()
        Me.timeleftlab = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.speedlbl = New System.Windows.Forms.Label()
        Me.gsize = New System.Windows.Forms.Label()
        Me.speedlbl2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.currentsize = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.curfilesize = New System.Windows.Forms.Label()
        Me.filesprocessed = New System.Windows.Forms.Label()
        Me.curfilesizenum = New System.Windows.Forms.Label()
        Me.totalfiles = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.currentdownload = New System.Windows.Forms.Label()
        Me.currentfiledown = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dscProgressBar2 = New dsc.dscProgressBar()
        Me.processbtn = New dsc.dscSideButton()
        Me.ControlBox1 = New dsc.ControlBox()
        Me.dscProgressBar = New dsc.dscProgressBar()
        Me.BaseTheme.SuspendLayout()
        CType(Me.websiteicon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.settingsicon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.homeicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatisticsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'infoToolTip
        '
        Me.infoToolTip.AutoPopDelay = 15000
        Me.infoToolTip.InitialDelay = 500
        Me.infoToolTip.IsBalloon = True
        Me.infoToolTip.ReshowDelay = 100
        Me.infoToolTip.ShowAlways = True
        Me.infoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.infoToolTip.ToolTipTitle = "Information"
        '
        'NotifyIcon
        '
        Me.NotifyIcon.BalloonTipText = "DarkSteam Client is idle"
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Visible = True
        '
        'traydetails
        '
        Me.traydetails.Enabled = True
        Me.traydetails.Interval = 1000
        '
        'AdsTimer
        '
        Me.AdsTimer.Enabled = True
        '
        'FBD
        '
        Me.FBD.Description = "Select where would you like dsc to download data to"
        '
        'shoutstimer
        '
        Me.shoutstimer.Interval = 15000
        '
        'ShoutsUpdater
        '
        Me.ShoutsUpdater.WorkerSupportsCancellation = True
        '
        'traytimer
        '
        Me.traytimer.Interval = 1000
        '
        'BGDownloader
        '
        Me.BGDownloader.WorkerSupportsCancellation = True
        '
        'hourlyupdate
        '
        Me.hourlyupdate.Interval = 360000
        '
        'BaseTheme
        '
        Me.BaseTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BaseTheme.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.BaseTheme.Controls.Add(Me.shoutboxweb)
        Me.BaseTheme.Controls.Add(Me.websiteicon)
        Me.BaseTheme.Controls.Add(Me.settingsicon)
        Me.BaseTheme.Controls.Add(Me.homeicon)
        Me.BaseTheme.Controls.Add(Me.StatisticsGroupBox)
        Me.BaseTheme.Controls.Add(Me.dscProgressBar2)
        Me.BaseTheme.Controls.Add(Me.processbtn)
        Me.BaseTheme.Controls.Add(Me.ControlBox1)
        Me.BaseTheme.Controls.Add(Me.dscProgressBar)
        Me.BaseTheme.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////AAAA////////////lpaW/w=="
        Me.BaseTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BaseTheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BaseTheme.Image = Nothing
        Me.BaseTheme.Location = New System.Drawing.Point(0, 0)
        Me.BaseTheme.Margin = New System.Windows.Forms.Padding(6)
        Me.BaseTheme.Movable = True
        Me.BaseTheme.Name = "BaseTheme"
        Me.BaseTheme.NoRounding = True
        Me.BaseTheme.Sizable = True
        Me.BaseTheme.Size = New System.Drawing.Size(2560, 1385)
        Me.BaseTheme.SmartBounds = True
        Me.BaseTheme.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.BaseTheme.TabIndex = 27
        Me.BaseTheme.Text = "DarkSteam Client"
        Me.BaseTheme.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.BaseTheme.Transparent = False
        '
        'shoutboxweb
        '
        Me.shoutboxweb.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.shoutboxweb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.shoutboxweb.Location = New System.Drawing.Point(24, 58)
        Me.shoutboxweb.Margin = New System.Windows.Forms.Padding(6)
        Me.shoutboxweb.Size = New System.Drawing.Size(1766, 323)
        Me.shoutboxweb.Source = New System.Uri("https://simbiat.ru/darksteam/api/dscmain.php", System.UriKind.Absolute)
        Me.shoutboxweb.TabIndex = 107
        '
        'websiteicon
        '
        Me.websiteicon.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.websiteicon.Image = Global.dsc.My.Resources.Resources.globe_icon
        Me.websiteicon.Location = New System.Drawing.Point(2232, 2)
        Me.websiteicon.Margin = New System.Windows.Forms.Padding(6)
        Me.websiteicon.Name = "websiteicon"
        Me.websiteicon.Size = New System.Drawing.Size(48, 29)
        Me.websiteicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.websiteicon.TabIndex = 99
        Me.websiteicon.TabStop = False
        '
        'settingsicon
        '
        Me.settingsicon.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.settingsicon.Image = Global.dsc.My.Resources.Resources.cog_icon
        Me.settingsicon.Location = New System.Drawing.Point(2282, 2)
        Me.settingsicon.Margin = New System.Windows.Forms.Padding(6)
        Me.settingsicon.Name = "settingsicon"
        Me.settingsicon.Size = New System.Drawing.Size(48, 29)
        Me.settingsicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.settingsicon.TabIndex = 98
        Me.settingsicon.TabStop = False
        '
        'homeicon
        '
        Me.homeicon.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.homeicon.Image = Global.dsc.My.Resources.Resources.home_white_icon
        Me.homeicon.Location = New System.Drawing.Point(2182, 2)
        Me.homeicon.Margin = New System.Windows.Forms.Padding(6)
        Me.homeicon.Name = "homeicon"
        Me.homeicon.Size = New System.Drawing.Size(48, 29)
        Me.homeicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.homeicon.TabIndex = 97
        Me.homeicon.TabStop = False
        '
        'StatisticsGroupBox
        '
        Me.StatisticsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatisticsGroupBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.StatisticsGroupBox.Controls.Add(Me.gamesshownlab)
        Me.StatisticsGroupBox.Controls.Add(Me.gamesshowncur)
        Me.StatisticsGroupBox.Controls.Add(Me.errneg)
        Me.StatisticsGroupBox.Controls.Add(Me.timeleft)
        Me.StatisticsGroupBox.Controls.Add(Me.gamestotalshown)
        Me.StatisticsGroupBox.Controls.Add(Me.errneglab)
        Me.StatisticsGroupBox.Controls.Add(Me.elapsedtime)
        Me.StatisticsGroupBox.Controls.Add(Me.Label10)
        Me.StatisticsGroupBox.Controls.Add(Me.Elapsedtimelab)
        Me.StatisticsGroupBox.Controls.Add(Me.timeleftlab)
        Me.StatisticsGroupBox.Controls.Add(Me.Label5)
        Me.StatisticsGroupBox.Controls.Add(Me.speedlbl)
        Me.StatisticsGroupBox.Controls.Add(Me.gsize)
        Me.StatisticsGroupBox.Controls.Add(Me.speedlbl2)
        Me.StatisticsGroupBox.Controls.Add(Me.Label1)
        Me.StatisticsGroupBox.Controls.Add(Me.Label2)
        Me.StatisticsGroupBox.Controls.Add(Me.currentsize)
        Me.StatisticsGroupBox.Controls.Add(Me.Label3)
        Me.StatisticsGroupBox.Controls.Add(Me.curfilesize)
        Me.StatisticsGroupBox.Controls.Add(Me.filesprocessed)
        Me.StatisticsGroupBox.Controls.Add(Me.curfilesizenum)
        Me.StatisticsGroupBox.Controls.Add(Me.totalfiles)
        Me.StatisticsGroupBox.Controls.Add(Me.Label6)
        Me.StatisticsGroupBox.Controls.Add(Me.currentdownload)
        Me.StatisticsGroupBox.Controls.Add(Me.currentfiledown)
        Me.StatisticsGroupBox.Controls.Add(Me.Label4)
        Me.StatisticsGroupBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.StatisticsGroupBox.Location = New System.Drawing.Point(1992, 62)
        Me.StatisticsGroupBox.Margin = New System.Windows.Forms.Padding(6)
        Me.StatisticsGroupBox.Name = "StatisticsGroupBox"
        Me.StatisticsGroupBox.Padding = New System.Windows.Forms.Padding(6)
        Me.StatisticsGroupBox.Size = New System.Drawing.Size(530, 365)
        Me.StatisticsGroupBox.TabIndex = 85
        Me.StatisticsGroupBox.TabStop = False
        Me.StatisticsGroupBox.Text = "Statistics"
        '
        'gamesshownlab
        '
        Me.gamesshownlab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gamesshownlab.AutoSize = True
        Me.gamesshownlab.BackColor = System.Drawing.Color.Transparent
        Me.gamesshownlab.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gamesshownlab.Location = New System.Drawing.Point(12, 33)
        Me.gamesshownlab.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.gamesshownlab.Name = "gamesshownlab"
        Me.gamesshownlab.Size = New System.Drawing.Size(172, 29)
        Me.gamesshownlab.TabIndex = 84
        Me.gamesshownlab.Text = "Games shown:"
        '
        'gamesshowncur
        '
        Me.gamesshowncur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gamesshowncur.AutoSize = True
        Me.gamesshowncur.BackColor = System.Drawing.Color.Transparent
        Me.gamesshowncur.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.gamesshowncur.Location = New System.Drawing.Point(236, 33)
        Me.gamesshowncur.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.gamesshowncur.Name = "gamesshowncur"
        Me.gamesshowncur.Size = New System.Drawing.Size(109, 29)
        Me.gamesshowncur.TabIndex = 85
        Me.gamesshowncur.Text = "unknown"
        '
        'errneg
        '
        Me.errneg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.errneg.AutoSize = True
        Me.errneg.BackColor = System.Drawing.Color.Transparent
        Me.errneg.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.errneg.Location = New System.Drawing.Point(236, 265)
        Me.errneg.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.errneg.Name = "errneg"
        Me.errneg.Size = New System.Drawing.Size(109, 29)
        Me.errneg.TabIndex = 83
        Me.errneg.Text = "unknown"
        '
        'timeleft
        '
        Me.timeleft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.timeleft.AutoSize = True
        Me.timeleft.BackColor = System.Drawing.Color.Transparent
        Me.timeleft.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.timeleft.Location = New System.Drawing.Point(236, 323)
        Me.timeleft.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.timeleft.Name = "timeleft"
        Me.timeleft.Size = New System.Drawing.Size(109, 29)
        Me.timeleft.TabIndex = 81
        Me.timeleft.Text = "unknown"
        '
        'gamestotalshown
        '
        Me.gamestotalshown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gamestotalshown.AutoSize = True
        Me.gamestotalshown.BackColor = System.Drawing.Color.Transparent
        Me.gamestotalshown.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.gamestotalshown.Location = New System.Drawing.Point(394, 33)
        Me.gamestotalshown.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.gamestotalshown.Name = "gamestotalshown"
        Me.gamestotalshown.Size = New System.Drawing.Size(109, 29)
        Me.gamestotalshown.TabIndex = 86
        Me.gamestotalshown.Text = "unknown"
        '
        'errneglab
        '
        Me.errneglab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.errneglab.AutoSize = True
        Me.errneglab.BackColor = System.Drawing.Color.Transparent
        Me.errneglab.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.errneglab.Location = New System.Drawing.Point(12, 265)
        Me.errneglab.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.errneglab.Name = "errneglab"
        Me.errneglab.Size = New System.Drawing.Size(205, 29)
        Me.errneglab.TabIndex = 82
        Me.errneglab.Text = "Errors negotiated:"
        Me.infoToolTip.SetToolTip(Me.errneglab, "Number of errors negotiated during this session and errors that were tried to be " & _
        "negotiated")
        '
        'elapsedtime
        '
        Me.elapsedtime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.elapsedtime.AutoSize = True
        Me.elapsedtime.BackColor = System.Drawing.Color.Transparent
        Me.elapsedtime.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.elapsedtime.Location = New System.Drawing.Point(236, 294)
        Me.elapsedtime.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.elapsedtime.Name = "elapsedtime"
        Me.elapsedtime.Size = New System.Drawing.Size(109, 29)
        Me.elapsedtime.TabIndex = 79
        Me.elapsedtime.Text = "unknown"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(362, 33)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 29)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "/"
        '
        'Elapsedtimelab
        '
        Me.Elapsedtimelab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Elapsedtimelab.AutoSize = True
        Me.Elapsedtimelab.BackColor = System.Drawing.Color.Transparent
        Me.Elapsedtimelab.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Elapsedtimelab.Location = New System.Drawing.Point(12, 294)
        Me.Elapsedtimelab.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Elapsedtimelab.Name = "Elapsedtimelab"
        Me.Elapsedtimelab.Size = New System.Drawing.Size(160, 29)
        Me.Elapsedtimelab.TabIndex = 78
        Me.Elapsedtimelab.Text = "Elapsed time:"
        Me.infoToolTip.SetToolTip(Me.Elapsedtimelab, "Days:Hours:Minutes:Seconds")
        '
        'timeleftlab
        '
        Me.timeleftlab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.timeleftlab.AutoSize = True
        Me.timeleftlab.BackColor = System.Drawing.Color.Transparent
        Me.timeleftlab.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.timeleftlab.Location = New System.Drawing.Point(12, 323)
        Me.timeleftlab.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.timeleftlab.Name = "timeleftlab"
        Me.timeleftlab.Size = New System.Drawing.Size(216, 29)
        Me.timeleftlab.TabIndex = 80
        Me.timeleftlab.Text = "Estimated time left:"
        Me.infoToolTip.SetToolTip(Me.timeleftlab, "Days:Hours:Minutes:Seconds")
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 62)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 31)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Game in process:"
        '
        'speedlbl
        '
        Me.speedlbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.speedlbl.AutoSize = True
        Me.speedlbl.BackColor = System.Drawing.Color.Transparent
        Me.speedlbl.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.speedlbl.Location = New System.Drawing.Point(236, 150)
        Me.speedlbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.speedlbl.Name = "speedlbl"
        Me.speedlbl.Size = New System.Drawing.Size(65, 29)
        Me.speedlbl.TabIndex = 20
        Me.speedlbl.Text = "0 b/s"
        '
        'gsize
        '
        Me.gsize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gsize.AutoSize = True
        Me.gsize.BackColor = System.Drawing.Color.Transparent
        Me.gsize.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.gsize.Location = New System.Drawing.Point(318, 204)
        Me.gsize.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.gsize.Name = "gsize"
        Me.gsize.Size = New System.Drawing.Size(109, 29)
        Me.gsize.TabIndex = 28
        Me.gsize.Text = "unknown"
        '
        'speedlbl2
        '
        Me.speedlbl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.speedlbl2.AutoSize = True
        Me.speedlbl2.BackColor = System.Drawing.Color.Transparent
        Me.speedlbl2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.speedlbl2.Location = New System.Drawing.Point(12, 150)
        Me.speedlbl2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.speedlbl2.Name = "speedlbl2"
        Me.speedlbl2.Size = New System.Drawing.Size(176, 29)
        Me.speedlbl2.TabIndex = 34
        Me.speedlbl2.Text = "Current Speed:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 208)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 29)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Total size to download:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 237)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(267, 29)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Processed this session:"
        '
        'currentsize
        '
        Me.currentsize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentsize.AutoSize = True
        Me.currentsize.BackColor = System.Drawing.Color.Transparent
        Me.currentsize.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.currentsize.Location = New System.Drawing.Point(318, 237)
        Me.currentsize.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.currentsize.Name = "currentsize"
        Me.currentsize.Size = New System.Drawing.Size(109, 29)
        Me.currentsize.TabIndex = 38
        Me.currentsize.Text = "unknown"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 179)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 29)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Files processed:"
        '
        'curfilesize
        '
        Me.curfilesize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.curfilesize.AutoSize = True
        Me.curfilesize.BackColor = System.Drawing.Color.Transparent
        Me.curfilesize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.curfilesize.Location = New System.Drawing.Point(12, 121)
        Me.curfilesize.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.curfilesize.Name = "curfilesize"
        Me.curfilesize.Size = New System.Drawing.Size(185, 29)
        Me.curfilesize.TabIndex = 77
        Me.curfilesize.Text = "Current file size:"
        '
        'filesprocessed
        '
        Me.filesprocessed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filesprocessed.AutoSize = True
        Me.filesprocessed.BackColor = System.Drawing.Color.Transparent
        Me.filesprocessed.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.filesprocessed.Location = New System.Drawing.Point(236, 179)
        Me.filesprocessed.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.filesprocessed.Name = "filesprocessed"
        Me.filesprocessed.Size = New System.Drawing.Size(109, 29)
        Me.filesprocessed.TabIndex = 43
        Me.filesprocessed.Text = "unknown"
        '
        'curfilesizenum
        '
        Me.curfilesizenum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.curfilesizenum.AutoSize = True
        Me.curfilesizenum.BackColor = System.Drawing.Color.Transparent
        Me.curfilesizenum.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.curfilesizenum.Location = New System.Drawing.Point(236, 121)
        Me.curfilesizenum.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.curfilesizenum.Name = "curfilesizenum"
        Me.curfilesizenum.Size = New System.Drawing.Size(46, 29)
        Me.curfilesizenum.TabIndex = 76
        Me.curfilesizenum.Text = "0 b"
        '
        'totalfiles
        '
        Me.totalfiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalfiles.AutoSize = True
        Me.totalfiles.BackColor = System.Drawing.Color.Transparent
        Me.totalfiles.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.totalfiles.Location = New System.Drawing.Point(394, 179)
        Me.totalfiles.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.totalfiles.Name = "totalfiles"
        Me.totalfiles.Size = New System.Drawing.Size(109, 29)
        Me.totalfiles.TabIndex = 46
        Me.totalfiles.Text = "unknown"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 90)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 31)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "File in process:"
        '
        'currentdownload
        '
        Me.currentdownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentdownload.BackColor = System.Drawing.Color.Transparent
        Me.currentdownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.currentdownload.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.currentdownload.Location = New System.Drawing.Point(236, 63)
        Me.currentdownload.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.currentdownload.Name = "currentdownload"
        Me.currentdownload.Size = New System.Drawing.Size(260, 29)
        Me.currentdownload.TabIndex = 53
        Me.currentdownload.Text = "N/A"
        Me.infoToolTip.SetToolTip(Me.currentdownload, "N/A")
        '
        'currentfiledown
        '
        Me.currentfiledown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentfiledown.BackColor = System.Drawing.Color.Transparent
        Me.currentfiledown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.currentfiledown.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.currentfiledown.Location = New System.Drawing.Point(236, 92)
        Me.currentfiledown.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.currentfiledown.Name = "currentfiledown"
        Me.currentfiledown.Size = New System.Drawing.Size(260, 29)
        Me.currentfiledown.TabIndex = 75
        Me.currentfiledown.Text = "N/A"
        Me.infoToolTip.SetToolTip(Me.currentfiledown, "N/A")
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(362, 179)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 29)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "/"
        '
        'dscProgressBar2
        '
        Me.dscProgressBar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dscProgressBar2.Colors = New dsc.Bloom(-1) {}
        Me.dscProgressBar2.Customization = ""
        Me.dscProgressBar2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dscProgressBar2.Image = Nothing
        Me.dscProgressBar2.Location = New System.Drawing.Point(38, 1288)
        Me.dscProgressBar2.Margin = New System.Windows.Forms.Padding(6)
        Me.dscProgressBar2.Maximum = 100
        Me.dscProgressBar2.MinimumSize = New System.Drawing.Size(200, 31)
        Me.dscProgressBar2.Name = "dscProgressBar2"
        Me.dscProgressBar2.NoRounding = False
        Me.dscProgressBar2.Size = New System.Drawing.Size(2140, 31)
        Me.dscProgressBar2.TabIndex = 73
        Me.dscProgressBar2.Text = "File progress"
        Me.dscProgressBar2.Transparent = False
        Me.dscProgressBar2.Value = 0
        '
        'processbtn
        '
        Me.processbtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.processbtn.Colors = New dsc.Bloom(-1) {}
        Me.processbtn.Customization = ""
        Me.processbtn.DisplayIcon = dsc.dscSideButton._Icon.Circle
        Me.processbtn.Enabled = False
        Me.processbtn.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.processbtn.Image = Nothing
        Me.processbtn.Location = New System.Drawing.Point(2202, 1296)
        Me.processbtn.Margin = New System.Windows.Forms.Padding(6)
        Me.processbtn.Name = "processbtn"
        Me.processbtn.NoRounding = False
        Me.processbtn.SideColor = dsc.dscSideButton._Color.Red
        Me.processbtn.Size = New System.Drawing.Size(320, 30)
        Me.processbtn.TabIndex = 49
        Me.processbtn.Text = "Idle"
        Me.infoToolTip.SetToolTip(Me.processbtn, "I'm not a download button, but I can stop current download")
        Me.processbtn.Transparent = False
        '
        'ControlBox1
        '
        Me.ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ControlBox1.Colors = New dsc.Bloom(-1) {}
        Me.ControlBox1.Customization = ""
        Me.ControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ControlBox1.Image = Nothing
        Me.ControlBox1.Location = New System.Drawing.Point(2180, 2)
        Me.ControlBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.ControlBox1.MaxButton = True
        Me.ControlBox1.MinButton = True
        Me.ControlBox1.Name = "ControlBox1"
        Me.ControlBox1.NoRounding = True
        Me.ControlBox1.Size = New System.Drawing.Size(386, 31)
        Me.ControlBox1.TabIndex = 47
        Me.ControlBox1.Text = "ControlBox1"
        Me.ControlBox1.Transparent = False
        '
        'dscProgressBar
        '
        Me.dscProgressBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dscProgressBar.Colors = New dsc.Bloom(-1) {}
        Me.dscProgressBar.Customization = ""
        Me.dscProgressBar.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dscProgressBar.Image = Nothing
        Me.dscProgressBar.Location = New System.Drawing.Point(38, 1331)
        Me.dscProgressBar.Margin = New System.Windows.Forms.Padding(6)
        Me.dscProgressBar.Maximum = 100
        Me.dscProgressBar.MinimumSize = New System.Drawing.Size(200, 31)
        Me.dscProgressBar.Name = "dscProgressBar"
        Me.dscProgressBar.NoRounding = False
        Me.dscProgressBar.Size = New System.Drawing.Size(2140, 31)
        Me.dscProgressBar.TabIndex = 39
        Me.dscProgressBar.Text = "Overall progress"
        Me.dscProgressBar.Transparent = False
        Me.dscProgressBar.Value = 0
        '
        'dscWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(2560, 1385)
        Me.Controls.Add(Me.BaseTheme)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "dscWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "DarkSteam Client"
        Me.normalToolTip.SetToolTip(Me, "DarkSteam Client")
        Me.infoToolTip.SetToolTip(Me, "DarkSteam Client")
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.BaseTheme.ResumeLayout(False)
        CType(Me.websiteicon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.settingsicon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.homeicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatisticsGroupBox.ResumeLayout(False)
        Me.StatisticsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents infoToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents normalToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents traytext As System.Windows.Forms.Timer
    Friend WithEvents setuptimer As System.Windows.Forms.Timer
    Friend WithEvents speedlbl As System.Windows.Forms.Label
    Friend WithEvents gsize As System.Windows.Forms.Label
    Friend WithEvents speedlbl2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents currentsize As System.Windows.Forms.Label
    Friend WithEvents dscProgressBar As dsc.dscProgressBar
    Friend WithEvents BaseTheme As dsc.dscTheme
    Friend WithEvents filesprocessed As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents totalfiles As System.Windows.Forms.Label
    Friend WithEvents traydetails As System.Windows.Forms.Timer
    Friend WithEvents ControlBox1 As dsc.ControlBox
    Friend WithEvents processbtn As dsc.dscSideButton
    Friend WithEvents currentdownload As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AdsTimer As System.Windows.Forms.Timer
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dscProgressBar2 As dsc.dscProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents currentfiledown As System.Windows.Forms.Label
    Friend WithEvents curfilesize As System.Windows.Forms.Label
    Friend WithEvents curfilesizenum As System.Windows.Forms.Label
    Friend WithEvents shoutstimer As System.Windows.Forms.Timer
    Friend WithEvents ShoutsUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents traytimer As System.Windows.Forms.Timer
    Friend WithEvents BGDownloader As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatisticsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Elapsedtimelab As System.Windows.Forms.Label
    Friend WithEvents elapsedtime As System.Windows.Forms.Label
    Friend WithEvents timeleft As System.Windows.Forms.Label
    Friend WithEvents timeleftlab As System.Windows.Forms.Label
    Friend WithEvents errneg As System.Windows.Forms.Label
    Friend WithEvents errneglab As System.Windows.Forms.Label
    Friend WithEvents homeicon As System.Windows.Forms.PictureBox
    Friend WithEvents websiteicon As System.Windows.Forms.PictureBox
    Friend WithEvents settingsicon As System.Windows.Forms.PictureBox
    Friend WithEvents gamesshownlab As System.Windows.Forms.Label
    Friend WithEvents gamesshowncur As System.Windows.Forms.Label
    Friend WithEvents gamestotalshown As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents hourlyupdate As System.Windows.Forms.Timer
    Friend WithEvents shoutboxweb As Awesomium.Windows.Forms.WebControl

End Class
