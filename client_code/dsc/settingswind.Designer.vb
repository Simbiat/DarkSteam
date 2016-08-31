<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingswindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settingswindow))
        Me.infoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DscButtonBlackBG1 = New dsc.dscButtonBlackBG()
        Me.resetbut = New dsc.dscButtonBlackBG()
        Me.shortcreatebut = New dsc.dscButtonBlackBG()
        Me.accupdchbox = New System.Windows.Forms.CheckBox()
        Me.BrowseBut = New dsc.dscButtonBlackBG()
        Me.steamdllab = New System.Windows.Forms.Label()
        Me.totray = New System.Windows.Forms.CheckBox()
        Me.autostart = New System.Windows.Forms.CheckBox()
        Me.linkinterceptcheck = New System.Windows.Forms.CheckBox()
        Me.retrieslab = New System.Windows.Forms.Label()
        Me.set_maxretries = New System.Windows.Forms.RichTextBox()
        Me.downresume = New System.Windows.Forms.CheckBox()
        Me.Logging = New System.Windows.Forms.CheckBox()
        Me.ResolutionY = New System.Windows.Forms.RichTextBox()
        Me.ResolutionX = New System.Windows.Forms.RichTextBox()
        Me.ResolutionLabel = New System.Windows.Forms.Label()
        Me.PerFileCheckBox = New System.Windows.Forms.CheckBox()
        Me.StatisticsCheckbox = New System.Windows.Forms.CheckBox()
        Me.aerosnapcheck = New System.Windows.Forms.CheckBox()
        Me.tbprogcheck = New System.Windows.Forms.CheckBox()
        Me.okbut = New dsc.dscButtonBlackBG()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.setwind = New dsc.dscTheme()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.NoticeLabel = New System.Windows.Forms.Label()
        Me.SettingsTabControl = New System.Windows.Forms.TabControl()
        Me.General = New System.Windows.Forms.TabPage()
        Me.steamdlbox = New System.Windows.Forms.RichTextBox()
        Me.Download = New System.Windows.Forms.TabPage()
        Me.GUI = New System.Windows.Forms.TabPage()
        Me.slashlabedl = New System.Windows.Forms.Label()
        Me.Win7 = New System.Windows.Forms.TabPage()
        Me.setwind.SuspendLayout()
        Me.SettingsTabControl.SuspendLayout()
        Me.General.SuspendLayout()
        Me.Download.SuspendLayout()
        Me.GUI.SuspendLayout()
        Me.Win7.SuspendLayout()
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
        'DscButtonBlackBG1
        '
        Me.DscButtonBlackBG1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DscButtonBlackBG1.Colors = New dsc.Bloom(-1) {}
        Me.DscButtonBlackBG1.Customization = ""
        Me.DscButtonBlackBG1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.DscButtonBlackBG1.Image = Nothing
        Me.DscButtonBlackBG1.Location = New System.Drawing.Point(156, 215)
        Me.DscButtonBlackBG1.Name = "DscButtonBlackBG1"
        Me.DscButtonBlackBG1.NoRounding = False
        Me.DscButtonBlackBG1.Size = New System.Drawing.Size(74, 23)
        Me.DscButtonBlackBG1.TabIndex = 1
        Me.DscButtonBlackBG1.Text = "Close"
        Me.infoToolTip.SetToolTip(Me.DscButtonBlackBG1, "Click to exit without saving changes to server. SOme of them will still be keeped" & _
        " for current session")
        Me.DscButtonBlackBG1.Transparent = False
        '
        'resetbut
        '
        Me.resetbut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resetbut.Colors = New dsc.Bloom(-1) {}
        Me.resetbut.Customization = ""
        Me.resetbut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.resetbut.Image = Nothing
        Me.resetbut.Location = New System.Drawing.Point(314, 215)
        Me.resetbut.Name = "resetbut"
        Me.resetbut.NoRounding = False
        Me.resetbut.Size = New System.Drawing.Size(74, 23)
        Me.resetbut.TabIndex = 3
        Me.resetbut.Text = "Reset"
        Me.infoToolTip.SetToolTip(Me.resetbut, "Click to reset settings to their defaults")
        Me.resetbut.Transparent = False
        '
        'shortcreatebut
        '
        Me.shortcreatebut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.shortcreatebut.Colors = New dsc.Bloom(-1) {}
        Me.shortcreatebut.Customization = ""
        Me.shortcreatebut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.shortcreatebut.Image = Nothing
        Me.shortcreatebut.Location = New System.Drawing.Point(288, 77)
        Me.shortcreatebut.Name = "shortcreatebut"
        Me.shortcreatebut.NoRounding = False
        Me.shortcreatebut.Size = New System.Drawing.Size(74, 23)
        Me.shortcreatebut.TabIndex = 95
        Me.shortcreatebut.Text = "Shortcut"
        Me.infoToolTip.SetToolTip(Me.shortcreatebut, "Click to create shortcut on desktop")
        Me.shortcreatebut.Transparent = False
        '
        'accupdchbox
        '
        Me.accupdchbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.accupdchbox.AutoSize = True
        Me.accupdchbox.BackColor = System.Drawing.Color.Transparent
        Me.accupdchbox.Cursor = System.Windows.Forms.Cursors.Help
        Me.accupdchbox.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.accupdchbox.Location = New System.Drawing.Point(6, 77)
        Me.accupdchbox.Name = "accupdchbox"
        Me.accupdchbox.Size = New System.Drawing.Size(113, 17)
        Me.accupdchbox.TabIndex = 94
        Me.accupdchbox.Text = "Accurate check"
        Me.infoToolTip.SetToolTip(Me.accupdchbox, "Check this to allow accurate update check for installed ACF games. If checked fil" & _
        "e contents will be checked, instead of file's modification date. This may prolon" & _
        "g  application launch")
        Me.accupdchbox.UseVisualStyleBackColor = False
        '
        'BrowseBut
        '
        Me.BrowseBut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseBut.Colors = New dsc.Bloom(-1) {}
        Me.BrowseBut.Customization = ""
        Me.BrowseBut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.BrowseBut.Image = Nothing
        Me.BrowseBut.Location = New System.Drawing.Point(288, 19)
        Me.BrowseBut.Name = "BrowseBut"
        Me.BrowseBut.NoRounding = False
        Me.BrowseBut.Size = New System.Drawing.Size(74, 23)
        Me.BrowseBut.TabIndex = 5
        Me.BrowseBut.Text = "Browse"
        Me.infoToolTip.SetToolTip(Me.BrowseBut, "Click to choose a directory")
        Me.BrowseBut.Transparent = False
        '
        'steamdllab
        '
        Me.steamdllab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.steamdllab.AutoSize = True
        Me.steamdllab.BackColor = System.Drawing.Color.Transparent
        Me.steamdllab.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.steamdllab.Location = New System.Drawing.Point(6, 3)
        Me.steamdllab.Name = "steamdllab"
        Me.steamdllab.Size = New System.Drawing.Size(123, 13)
        Me.steamdllab.TabIndex = 93
        Me.steamdllab.Text = "Download directory:"
        Me.infoToolTip.SetToolTip(Me.steamdllab, "Current download directory. Empty the field to revert it to directory where appli" & _
        "cation was started")
        '
        'totray
        '
        Me.totray.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totray.AutoSize = True
        Me.totray.BackColor = System.Drawing.Color.Transparent
        Me.totray.Cursor = System.Windows.Forms.Cursors.Default
        Me.totray.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.totray.Location = New System.Drawing.Point(131, 54)
        Me.totray.Name = "totray"
        Me.totray.Size = New System.Drawing.Size(117, 17)
        Me.totray.TabIndex = 36
        Me.totray.Text = "Minimize to tray"
        Me.infoToolTip.SetToolTip(Me.totray, "Check this to minimize the window to tray (near clock), otherwise window will be " & _
        "minimized to control panel as usual")
        Me.totray.UseVisualStyleBackColor = False
        '
        'autostart
        '
        Me.autostart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.autostart.AutoSize = True
        Me.autostart.BackColor = System.Drawing.Color.Transparent
        Me.autostart.Cursor = System.Windows.Forms.Cursors.Help
        Me.autostart.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.autostart.Location = New System.Drawing.Point(6, 54)
        Me.autostart.Name = "autostart"
        Me.autostart.Size = New System.Drawing.Size(101, 17)
        Me.autostart.TabIndex = 33
        Me.autostart.Text = "Auto-process"
        Me.infoToolTip.SetToolTip(Me.autostart, "Check to supress confirmation dialog on download")
        Me.autostart.UseVisualStyleBackColor = False
        '
        'linkinterceptcheck
        '
        Me.linkinterceptcheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkinterceptcheck.AutoSize = True
        Me.linkinterceptcheck.BackColor = System.Drawing.Color.Transparent
        Me.linkinterceptcheck.Cursor = System.Windows.Forms.Cursors.Help
        Me.linkinterceptcheck.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.linkinterceptcheck.Location = New System.Drawing.Point(3, 51)
        Me.linkinterceptcheck.Name = "linkinterceptcheck"
        Me.linkinterceptcheck.Size = New System.Drawing.Size(108, 17)
        Me.linkinterceptcheck.TabIndex = 90
        Me.linkinterceptcheck.Text = "Intercept links"
        Me.infoToolTip.SetToolTip(Me.linkinterceptcheck, "Check to enable dsc:// links interception. This will enable you to install and ru" & _
        "n games using specific URLs. Also allows creation of application specific shortc" & _
        "uts")
        Me.linkinterceptcheck.UseVisualStyleBackColor = False
        '
        'retrieslab
        '
        Me.retrieslab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.retrieslab.AutoSize = True
        Me.retrieslab.BackColor = System.Drawing.Color.Transparent
        Me.retrieslab.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.retrieslab.Location = New System.Drawing.Point(3, 23)
        Me.retrieslab.Name = "retrieslab"
        Me.retrieslab.Size = New System.Drawing.Size(103, 13)
        Me.retrieslab.TabIndex = 89
        Me.retrieslab.Text = "Maximum retries"
        Me.infoToolTip.SetToolTip(Me.retrieslab, "Set a number of maximum retries in case of errors. If reached download will be ca" & _
        "ncelled. Set it to '0' to infinite number of retries")
        '
        'set_maxretries
        '
        Me.set_maxretries.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.set_maxretries.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.set_maxretries.Location = New System.Drawing.Point(112, 23)
        Me.set_maxretries.Multiline = False
        Me.set_maxretries.Name = "set_maxretries"
        Me.set_maxretries.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.set_maxretries.Size = New System.Drawing.Size(109, 22)
        Me.set_maxretries.TabIndex = 88
        Me.set_maxretries.Text = ""
        Me.infoToolTip.SetToolTip(Me.set_maxretries, "Set a number of maximum retries in case of errors. If reached download will be ca" & _
        "ncelled. Set it to '0' to infinite number of retries")
        '
        'downresume
        '
        Me.downresume.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.downresume.AutoSize = True
        Me.downresume.BackColor = System.Drawing.Color.Transparent
        Me.downresume.Cursor = System.Windows.Forms.Cursors.Help
        Me.downresume.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.downresume.Location = New System.Drawing.Point(128, 3)
        Me.downresume.Name = "downresume"
        Me.downresume.Size = New System.Drawing.Size(108, 17)
        Me.downresume.TabIndex = 39
        Me.downresume.Text = "Resume mode"
        Me.infoToolTip.SetToolTip(Me.downresume, "Check to allow the client to try and resume download in case a file being downloa" & _
        "ded is already present in destination directory. Otherwise file will be overwrit" & _
        "ten")
        Me.downresume.UseVisualStyleBackColor = False
        '
        'Logging
        '
        Me.Logging.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Logging.AutoSize = True
        Me.Logging.BackColor = System.Drawing.Color.Transparent
        Me.Logging.Cursor = System.Windows.Forms.Cursors.Help
        Me.Logging.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.Logging.Location = New System.Drawing.Point(3, 3)
        Me.Logging.Name = "Logging"
        Me.Logging.Size = New System.Drawing.Size(109, 17)
        Me.Logging.TabIndex = 38
        Me.Logging.Text = "Enable logging"
        Me.infoToolTip.SetToolTip(Me.Logging, "Check to enable download logging. Primary needed in case of issues, if requested " & _
        "by service administration")
        Me.Logging.UseVisualStyleBackColor = False
        '
        'ResolutionY
        '
        Me.ResolutionY.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ResolutionY.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResolutionY.Location = New System.Drawing.Point(266, 3)
        Me.ResolutionY.Multiline = False
        Me.ResolutionY.Name = "ResolutionY"
        Me.ResolutionY.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.ResolutionY.Size = New System.Drawing.Size(42, 16)
        Me.ResolutionY.TabIndex = 95
        Me.ResolutionY.Text = ""
        Me.infoToolTip.SetToolTip(Me.ResolutionY, "Height")
        '
        'ResolutionX
        '
        Me.ResolutionX.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ResolutionX.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResolutionX.Location = New System.Drawing.Point(214, 3)
        Me.ResolutionX.Multiline = False
        Me.ResolutionX.Name = "ResolutionX"
        Me.ResolutionX.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.ResolutionX.Size = New System.Drawing.Size(42, 16)
        Me.ResolutionX.TabIndex = 94
        Me.ResolutionX.Text = ""
        Me.infoToolTip.SetToolTip(Me.ResolutionX, "Width")
        '
        'ResolutionLabel
        '
        Me.ResolutionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResolutionLabel.AutoSize = True
        Me.ResolutionLabel.BackColor = System.Drawing.Color.Transparent
        Me.ResolutionLabel.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.ResolutionLabel.Location = New System.Drawing.Point(109, 4)
        Me.ResolutionLabel.Name = "ResolutionLabel"
        Me.ResolutionLabel.Size = New System.Drawing.Size(109, 13)
        Me.ResolutionLabel.TabIndex = 93
        Me.ResolutionLabel.Text = "Resolution (W/H):"
        Me.infoToolTip.SetToolTip(Me.ResolutionLabel, "Presize change of resolution of the window. Press 'Enter' in appropriate textbox " & _
        "to force resizing process. Empty the textbox or set it ot 0 to reset to autosizi" & _
        "ng mode")
        '
        'PerFileCheckBox
        '
        Me.PerFileCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PerFileCheckBox.AutoSize = True
        Me.PerFileCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.PerFileCheckBox.Checked = True
        Me.PerFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PerFileCheckBox.Cursor = System.Windows.Forms.Cursors.Help
        Me.PerFileCheckBox.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.PerFileCheckBox.Location = New System.Drawing.Point(3, 26)
        Me.PerFileCheckBox.Name = "PerFileCheckBox"
        Me.PerFileCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.PerFileCheckBox.TabIndex = 88
        Me.PerFileCheckBox.Text = "Per file bar"
        Me.infoToolTip.SetToolTip(Me.PerFileCheckBox, "Uncheck to hide per-file progress bar")
        Me.PerFileCheckBox.UseVisualStyleBackColor = False
        '
        'StatisticsCheckbox
        '
        Me.StatisticsCheckbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatisticsCheckbox.AutoSize = True
        Me.StatisticsCheckbox.BackColor = System.Drawing.Color.Transparent
        Me.StatisticsCheckbox.Checked = True
        Me.StatisticsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatisticsCheckbox.Cursor = System.Windows.Forms.Cursors.Help
        Me.StatisticsCheckbox.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.StatisticsCheckbox.Location = New System.Drawing.Point(3, 3)
        Me.StatisticsCheckbox.Name = "StatisticsCheckbox"
        Me.StatisticsCheckbox.Size = New System.Drawing.Size(77, 17)
        Me.StatisticsCheckbox.TabIndex = 89
        Me.StatisticsCheckbox.Text = "Statistics"
        Me.infoToolTip.SetToolTip(Me.StatisticsCheckbox, "Uncheck to hide detaild statistics on current download process")
        Me.StatisticsCheckbox.UseVisualStyleBackColor = False
        '
        'aerosnapcheck
        '
        Me.aerosnapcheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.aerosnapcheck.AutoSize = True
        Me.aerosnapcheck.BackColor = System.Drawing.Color.Transparent
        Me.aerosnapcheck.Checked = True
        Me.aerosnapcheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.aerosnapcheck.Cursor = System.Windows.Forms.Cursors.Help
        Me.aerosnapcheck.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.aerosnapcheck.Location = New System.Drawing.Point(4, 26)
        Me.aerosnapcheck.Name = "aerosnapcheck"
        Me.aerosnapcheck.Size = New System.Drawing.Size(86, 17)
        Me.aerosnapcheck.TabIndex = 92
        Me.aerosnapcheck.Text = "Aero Snap"
        Me.infoToolTip.SetToolTip(Me.aerosnapcheck, "Check to simulate behaviour of Aero Snap feature from Windows 7, that is docking " & _
        "to sdies of the screen. Will work on all operating systems. Disabled by default")
        Me.aerosnapcheck.UseVisualStyleBackColor = False
        '
        'tbprogcheck
        '
        Me.tbprogcheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbprogcheck.AutoSize = True
        Me.tbprogcheck.BackColor = System.Drawing.Color.Transparent
        Me.tbprogcheck.Checked = True
        Me.tbprogcheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tbprogcheck.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbprogcheck.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.tbprogcheck.Location = New System.Drawing.Point(4, 3)
        Me.tbprogcheck.Name = "tbprogcheck"
        Me.tbprogcheck.Size = New System.Drawing.Size(126, 17)
        Me.tbprogcheck.TabIndex = 91
        Me.tbprogcheck.Text = "Taskbar progress"
        Me.infoToolTip.SetToolTip(Me.tbprogcheck, "Uncheck to disable showing download progress in taskbar. Setting will be ingored " & _
        "if current operating system does not support it")
        Me.tbprogcheck.UseVisualStyleBackColor = False
        '
        'okbut
        '
        Me.okbut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okbut.Colors = New dsc.Bloom(-1) {}
        Me.okbut.Customization = ""
        Me.okbut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.okbut.Image = Nothing
        Me.okbut.Location = New System.Drawing.Point(12, 215)
        Me.okbut.Name = "okbut"
        Me.okbut.NoRounding = False
        Me.okbut.Size = New System.Drawing.Size(74, 23)
        Me.okbut.TabIndex = 2
        Me.okbut.Text = "Save"
        Me.infoToolTip.SetToolTip(Me.okbut, "Click to save changes and exit")
        Me.okbut.Transparent = False
        '
        'OpenFileDialog1
        '
        '
        'setwind
        '
        Me.setwind.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.setwind.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.setwind.Controls.Add(Me.DscButtonBlackBG1)
        Me.setwind.Controls.Add(Me.resetbut)
        Me.setwind.Controls.Add(Me.TextBox1)
        Me.setwind.Controls.Add(Me.NoticeLabel)
        Me.setwind.Controls.Add(Me.SettingsTabControl)
        Me.setwind.Controls.Add(Me.okbut)
        Me.setwind.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////AAAA////////////lpaW/w=="
        Me.setwind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.setwind.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.setwind.Image = Nothing
        Me.setwind.Location = New System.Drawing.Point(0, 0)
        Me.setwind.Movable = True
        Me.setwind.Name = "setwind"
        Me.setwind.NoRounding = False
        Me.setwind.Sizable = False
        Me.setwind.Size = New System.Drawing.Size(400, 250)
        Me.setwind.SmartBounds = True
        Me.setwind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.setwind.TabIndex = 0
        Me.setwind.Text = "Settings"
        Me.setwind.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.setwind.Transparent = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(72, 166)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(316, 43)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "All settings with checkboxes are saved automatically when changed. Settings with " & _
    "input boxes are saved when you press 'Enter' in appropriate input box or when yo" & _
    "u press 'Save' button"
        '
        'NoticeLabel
        '
        Me.NoticeLabel.AutoSize = True
        Me.NoticeLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.NoticeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NoticeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NoticeLabel.Location = New System.Drawing.Point(9, 178)
        Me.NoticeLabel.Name = "NoticeLabel"
        Me.NoticeLabel.Size = New System.Drawing.Size(59, 13)
        Me.NoticeLabel.TabIndex = 3
        Me.NoticeLabel.Text = "NOTICE:"
        '
        'SettingsTabControl
        '
        Me.SettingsTabControl.Controls.Add(Me.General)
        Me.SettingsTabControl.Controls.Add(Me.Download)
        Me.SettingsTabControl.Controls.Add(Me.GUI)
        Me.SettingsTabControl.Controls.Add(Me.Win7)
        Me.SettingsTabControl.Location = New System.Drawing.Point(12, 28)
        Me.SettingsTabControl.Name = "SettingsTabControl"
        Me.SettingsTabControl.SelectedIndex = 0
        Me.SettingsTabControl.Size = New System.Drawing.Size(376, 131)
        Me.SettingsTabControl.TabIndex = 2
        '
        'General
        '
        Me.General.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.General.Controls.Add(Me.shortcreatebut)
        Me.General.Controls.Add(Me.accupdchbox)
        Me.General.Controls.Add(Me.BrowseBut)
        Me.General.Controls.Add(Me.steamdllab)
        Me.General.Controls.Add(Me.steamdlbox)
        Me.General.Controls.Add(Me.totray)
        Me.General.Controls.Add(Me.autostart)
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Padding = New System.Windows.Forms.Padding(3)
        Me.General.Size = New System.Drawing.Size(368, 105)
        Me.General.TabIndex = 0
        Me.General.Text = "General"
        '
        'steamdlbox
        '
        Me.steamdlbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.steamdlbox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.steamdlbox.Location = New System.Drawing.Point(9, 19)
        Me.steamdlbox.Multiline = False
        Me.steamdlbox.Name = "steamdlbox"
        Me.steamdlbox.Size = New System.Drawing.Size(273, 22)
        Me.steamdlbox.TabIndex = 92
        Me.steamdlbox.Text = ""
        '
        'Download
        '
        Me.Download.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Download.Controls.Add(Me.linkinterceptcheck)
        Me.Download.Controls.Add(Me.retrieslab)
        Me.Download.Controls.Add(Me.set_maxretries)
        Me.Download.Controls.Add(Me.downresume)
        Me.Download.Controls.Add(Me.Logging)
        Me.Download.Location = New System.Drawing.Point(4, 22)
        Me.Download.Name = "Download"
        Me.Download.Size = New System.Drawing.Size(368, 105)
        Me.Download.TabIndex = 3
        Me.Download.Text = "Download"
        '
        'GUI
        '
        Me.GUI.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.GUI.Controls.Add(Me.slashlabedl)
        Me.GUI.Controls.Add(Me.ResolutionY)
        Me.GUI.Controls.Add(Me.ResolutionX)
        Me.GUI.Controls.Add(Me.ResolutionLabel)
        Me.GUI.Controls.Add(Me.PerFileCheckBox)
        Me.GUI.Controls.Add(Me.StatisticsCheckbox)
        Me.GUI.Location = New System.Drawing.Point(4, 22)
        Me.GUI.Name = "GUI"
        Me.GUI.Size = New System.Drawing.Size(368, 105)
        Me.GUI.TabIndex = 2
        Me.GUI.Text = "Interface"
        '
        'slashlabedl
        '
        Me.slashlabedl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.slashlabedl.AutoSize = True
        Me.slashlabedl.BackColor = System.Drawing.Color.Transparent
        Me.slashlabedl.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.slashlabedl.Location = New System.Drawing.Point(256, 4)
        Me.slashlabedl.Name = "slashlabedl"
        Me.slashlabedl.Size = New System.Drawing.Size(12, 13)
        Me.slashlabedl.TabIndex = 96
        Me.slashlabedl.Text = "/"
        '
        'Win7
        '
        Me.Win7.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Win7.Controls.Add(Me.aerosnapcheck)
        Me.Win7.Controls.Add(Me.tbprogcheck)
        Me.Win7.Location = New System.Drawing.Point(4, 22)
        Me.Win7.Name = "Win7"
        Me.Win7.Size = New System.Drawing.Size(368, 105)
        Me.Win7.TabIndex = 5
        Me.Win7.Text = "Win7"
        '
        'settingswindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 250)
        Me.Controls.Add(Me.setwind)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "settingswindow"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.setwind.ResumeLayout(False)
        Me.setwind.PerformLayout()
        Me.SettingsTabControl.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        Me.Download.ResumeLayout(False)
        Me.Download.PerformLayout()
        Me.GUI.ResumeLayout(False)
        Me.GUI.PerformLayout()
        Me.Win7.ResumeLayout(False)
        Me.Win7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents okbut As dsc.dscButtonBlackBG
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents autostart As System.Windows.Forms.CheckBox
    Friend WithEvents GUI As System.Windows.Forms.TabPage
    Friend WithEvents PerFileCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StatisticsCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents setwind As dsc.dscTheme
    Friend WithEvents SettingsTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents NoticeLabel As System.Windows.Forms.Label
    Friend WithEvents totray As System.Windows.Forms.CheckBox
    Friend WithEvents resetbut As dsc.dscButtonBlackBG
    Friend WithEvents infoToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents DscButtonBlackBG1 As dsc.dscButtonBlackBG
    Friend WithEvents slashlabedl As System.Windows.Forms.Label
    Friend WithEvents ResolutionY As System.Windows.Forms.RichTextBox
    Friend WithEvents ResolutionX As System.Windows.Forms.RichTextBox
    Friend WithEvents ResolutionLabel As System.Windows.Forms.Label
    Friend WithEvents BrowseBut As dsc.dscButtonBlackBG
    Friend WithEvents steamdllab As System.Windows.Forms.Label
    Friend WithEvents steamdlbox As System.Windows.Forms.RichTextBox
    Friend WithEvents accupdchbox As System.Windows.Forms.CheckBox
    Friend WithEvents Download As System.Windows.Forms.TabPage
    Friend WithEvents downresume As System.Windows.Forms.CheckBox
    Friend WithEvents Logging As System.Windows.Forms.CheckBox
    Friend WithEvents retrieslab As System.Windows.Forms.Label
    Friend WithEvents set_maxretries As System.Windows.Forms.RichTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Win7 As System.Windows.Forms.TabPage
    Friend WithEvents tbprogcheck As System.Windows.Forms.CheckBox
    Friend WithEvents aerosnapcheck As System.Windows.Forms.CheckBox
    Friend WithEvents linkinterceptcheck As System.Windows.Forms.CheckBox
    Friend WithEvents shortcreatebut As dsc.dscButtonBlackBG
End Class
