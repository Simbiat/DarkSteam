<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.dscTheme1 = New dsc.dscTheme()
        Me.logstatbar = New System.Windows.Forms.Label()
        Me.OK = New dsc.dscButtonBlackBG()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.ResetPWLabel = New System.Windows.Forms.Label()
        Me.RegisterLink = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Cancel = New dsc.dscButtonBlackBG()
        Me.libsdownworker = New System.ComponentModel.BackgroundWorker()
        Me.dscTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dscTheme1
        '
        Me.dscTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dscTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.dscTheme1.Controls.Add(Me.logstatbar)
        Me.dscTheme1.Controls.Add(Me.OK)
        Me.dscTheme1.Controls.Add(Me.PasswordLabel)
        Me.dscTheme1.Controls.Add(Me.ResetPWLabel)
        Me.dscTheme1.Controls.Add(Me.RegisterLink)
        Me.dscTheme1.Controls.Add(Me.PasswordTextBox)
        Me.dscTheme1.Controls.Add(Me.UsernameTextBox)
        Me.dscTheme1.Controls.Add(Me.UsernameLabel)
        Me.dscTheme1.Controls.Add(Me.Cancel)
        Me.dscTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////AAAA////////////lpaW/w=="
        Me.dscTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dscTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dscTheme1.Image = Nothing
        Me.dscTheme1.Location = New System.Drawing.Point(0, 0)
        Me.dscTheme1.Movable = True
        Me.dscTheme1.Name = "dscTheme1"
        Me.dscTheme1.NoRounding = False
        Me.dscTheme1.Sizable = False
        Me.dscTheme1.Size = New System.Drawing.Size(350, 160)
        Me.dscTheme1.SmartBounds = True
        Me.dscTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.dscTheme1.TabIndex = 0
        Me.dscTheme1.Text = "DarkSteam: User Authorisation"
        Me.dscTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.dscTheme1.Transparent = False
        '
        'logstatbar
        '
        Me.logstatbar.BackColor = System.Drawing.Color.Transparent
        Me.logstatbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.logstatbar.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.logstatbar.ForeColor = System.Drawing.Color.Silver
        Me.logstatbar.Location = New System.Drawing.Point(21, 137)
        Me.logstatbar.Name = "logstatbar"
        Me.logstatbar.Size = New System.Drawing.Size(308, 15)
        Me.logstatbar.TabIndex = 16
        Me.logstatbar.Text = "Awaiting user input..."
        '
        'OK
        '
        Me.OK.Colors = New dsc.Bloom(-1) {}
        Me.OK.Customization = ""
        Me.OK.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.OK.Image = Nothing
        Me.OK.Location = New System.Drawing.Point(247, 55)
        Me.OK.Name = "OK"
        Me.OK.NoRounding = False
        Me.OK.Size = New System.Drawing.Size(82, 23)
        Me.OK.TabIndex = 3
        Me.OK.Text = "OK"
        Me.OK.Transparent = False
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.ForeColor = System.Drawing.Color.DarkGray
        Me.PasswordLabel.Location = New System.Drawing.Point(21, 78)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(117, 23)
        Me.PasswordLabel.TabIndex = 15
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ResetPWLabel
        '
        Me.ResetPWLabel.AutoSize = True
        Me.ResetPWLabel.BackColor = System.Drawing.Color.Transparent
        Me.ResetPWLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ResetPWLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.ResetPWLabel.Location = New System.Drawing.Point(144, 83)
        Me.ResetPWLabel.Name = "ResetPWLabel"
        Me.ResetPWLabel.Size = New System.Drawing.Size(97, 13)
        Me.ResetPWLabel.TabIndex = 14
        Me.ResetPWLabel.Text = "Reset password"
        '
        'RegisterLink
        '
        Me.RegisterLink.AutoSize = True
        Me.RegisterLink.BackColor = System.Drawing.Color.Transparent
        Me.RegisterLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RegisterLink.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.RegisterLink.Location = New System.Drawing.Point(187, 34)
        Me.RegisterLink.Name = "RegisterLink"
        Me.RegisterLink.Size = New System.Drawing.Size(54, 13)
        Me.RegisterLink.TabIndex = 13
        Me.RegisterLink.Text = "Register"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.PasswordTextBox.ForeColor = System.Drawing.SystemColors.Info
        Me.PasswordTextBox.Location = New System.Drawing.Point(21, 104)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(220, 20)
        Me.PasswordTextBox.TabIndex = 2
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.UsernameTextBox.ForeColor = System.Drawing.SystemColors.Info
        Me.UsernameTextBox.Location = New System.Drawing.Point(21, 55)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(220, 20)
        Me.UsernameTextBox.TabIndex = 1
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.ForeColor = System.Drawing.Color.DarkGray
        Me.UsernameLabel.Location = New System.Drawing.Point(21, 29)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(117, 23)
        Me.UsernameLabel.TabIndex = 8
        Me.UsernameLabel.Text = "&User name"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cancel
        '
        Me.Cancel.Colors = New dsc.Bloom(-1) {}
        Me.Cancel.Customization = ""
        Me.Cancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Cancel.Image = Nothing
        Me.Cancel.Location = New System.Drawing.Point(247, 101)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.NoRounding = False
        Me.Cancel.Size = New System.Drawing.Size(82, 23)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "Cancel"
        Me.Cancel.Transparent = False
        '
        'libsdownworker
        '
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 160)
        Me.Controls.Add(Me.dscTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoginForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DarkSteam: User Authorisation"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.dscTheme1.ResumeLayout(False)
        Me.dscTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dscTheme1 As dsc.dscTheme
    Friend WithEvents Cancel As dsc.dscButtonBlackBG
    Friend WithEvents ResetPWLabel As System.Windows.Forms.Label
    Friend WithEvents RegisterLink As System.Windows.Forms.Label
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents OK As dsc.dscButtonBlackBG
    Friend WithEvents logstatbar As System.Windows.Forms.Label
    Friend WithEvents libsdownworker As System.ComponentModel.BackgroundWorker
End Class
