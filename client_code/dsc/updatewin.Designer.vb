<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class updatewindow
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
        Me.updwind = New dsc.dscTheme()
        Me.updbrowser = New System.Windows.Forms.WebBrowser()
        Me.nobut = New dsc.dscButtonBlackBG()
        Me.yesbut = New dsc.dscButtonBlackBG()
        Me.updwind.SuspendLayout()
        Me.SuspendLayout()
        '
        'updwind
        '
        Me.updwind.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.updwind.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.updwind.Controls.Add(Me.updbrowser)
        Me.updwind.Controls.Add(Me.nobut)
        Me.updwind.Controls.Add(Me.yesbut)
        Me.updwind.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////AAAA////////////lpaW/w=="
        Me.updwind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.updwind.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.updwind.Image = Nothing
        Me.updwind.Location = New System.Drawing.Point(0, 0)
        Me.updwind.Movable = True
        Me.updwind.Name = "updwind"
        Me.updwind.NoRounding = False
        Me.updwind.Sizable = False
        Me.updwind.Size = New System.Drawing.Size(408, 158)
        Me.updwind.SmartBounds = True
        Me.updwind.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.updwind.TabIndex = 0
        Me.updwind.Text = "Ouch!"
        Me.updwind.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.updwind.Transparent = False
        '
        'updbrowser
        '
        Me.updbrowser.AllowNavigation = False
        Me.updbrowser.AllowWebBrowserDrop = False
        Me.updbrowser.IsWebBrowserContextMenuEnabled = False
        Me.updbrowser.Location = New System.Drawing.Point(3, 28)
        Me.updbrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.updbrowser.Name = "updbrowser"
        Me.updbrowser.Size = New System.Drawing.Size(402, 89)
        Me.updbrowser.TabIndex = 4
        Me.updbrowser.TabStop = False
        Me.updbrowser.Url = New System.Uri("https://simbiat.ru/darksteam/api/patchnotes.php", System.UriKind.Absolute)
        '
        'nobut
        '
        Me.nobut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nobut.Colors = New dsc.Bloom(-1) {}
        Me.nobut.Customization = ""
        Me.nobut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.nobut.Image = Nothing
        Me.nobut.Location = New System.Drawing.Point(250, 123)
        Me.nobut.Name = "nobut"
        Me.nobut.NoRounding = False
        Me.nobut.Size = New System.Drawing.Size(82, 23)
        Me.nobut.TabIndex = 3
        Me.nobut.Text = "No"
        Me.nobut.Transparent = False
        '
        'yesbut
        '
        Me.yesbut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.yesbut.Colors = New dsc.Bloom(-1) {}
        Me.yesbut.Customization = ""
        Me.yesbut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.yesbut.Image = Nothing
        Me.yesbut.Location = New System.Drawing.Point(74, 123)
        Me.yesbut.Name = "yesbut"
        Me.yesbut.NoRounding = False
        Me.yesbut.Size = New System.Drawing.Size(82, 23)
        Me.yesbut.TabIndex = 2
        Me.yesbut.Text = "Yes"
        Me.yesbut.Transparent = False
        '
        'updatewindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 158)
        Me.Controls.Add(Me.updwind)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "updatewindow"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ouch!"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.updwind.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents updwind As dsc.dscTheme
    Friend WithEvents nobut As dsc.dscButtonBlackBG
    Friend WithEvents yesbut As dsc.dscButtonBlackBG
    Friend WithEvents updbrowser As System.Windows.Forms.WebBrowser
End Class
