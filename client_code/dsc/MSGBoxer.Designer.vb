<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsgBoxer
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
        Me.msgwind = New dsc.dscTheme()
        Me.errormsg2 = New System.Windows.Forms.RichTextBox()
        Me.nobut = New dsc.dscButtonBlackBG()
        Me.yesbut = New dsc.dscButtonBlackBG()
        Me.okbut = New dsc.dscButtonBlackBG()
        Me.msgwind.SuspendLayout()
        Me.SuspendLayout()
        '
        'msgwind
        '
        Me.msgwind.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.msgwind.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.msgwind.Controls.Add(Me.errormsg2)
        Me.msgwind.Controls.Add(Me.nobut)
        Me.msgwind.Controls.Add(Me.yesbut)
        Me.msgwind.Controls.Add(Me.okbut)
        Me.msgwind.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////AAAA////////////lpaW/w=="
        Me.msgwind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msgwind.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.msgwind.Image = Nothing
        Me.msgwind.Location = New System.Drawing.Point(0, 0)
        Me.msgwind.Movable = True
        Me.msgwind.Name = "msgwind"
        Me.msgwind.NoRounding = False
        Me.msgwind.Sizable = False
        Me.msgwind.Size = New System.Drawing.Size(408, 100)
        Me.msgwind.SmartBounds = True
        Me.msgwind.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.msgwind.TabIndex = 0
        Me.msgwind.Text = "Ouch!"
        Me.msgwind.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.msgwind.Transparent = False
        '
        'errormsg2
        '
        Me.errormsg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.errormsg2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.errormsg2.ForeColor = System.Drawing.Color.DarkGray
        Me.errormsg2.Location = New System.Drawing.Point(12, 42)
        Me.errormsg2.Name = "errormsg2"
        Me.errormsg2.ReadOnly = True
        Me.errormsg2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.errormsg2.Size = New System.Drawing.Size(384, 17)
        Me.errormsg2.TabIndex = 4
        Me.errormsg2.Text = "You are not autorized to download this game!"
        '
        'nobut
        '
        Me.nobut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nobut.Colors = New dsc.Bloom(-1) {}
        Me.nobut.Customization = ""
        Me.nobut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.nobut.Image = Nothing
        Me.nobut.Location = New System.Drawing.Point(250, 65)
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
        Me.yesbut.Location = New System.Drawing.Point(74, 65)
        Me.yesbut.Name = "yesbut"
        Me.yesbut.NoRounding = False
        Me.yesbut.Size = New System.Drawing.Size(82, 23)
        Me.yesbut.TabIndex = 2
        Me.yesbut.Text = "Yes"
        Me.yesbut.Transparent = False
        '
        'okbut
        '
        Me.okbut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okbut.Colors = New dsc.Bloom(-1) {}
        Me.okbut.Customization = ""
        Me.okbut.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.okbut.Image = Nothing
        Me.okbut.Location = New System.Drawing.Point(162, 65)
        Me.okbut.Name = "okbut"
        Me.okbut.NoRounding = False
        Me.okbut.Size = New System.Drawing.Size(82, 23)
        Me.okbut.TabIndex = 1
        Me.okbut.Text = "OK"
        Me.okbut.Transparent = False
        '
        'MsgBoxer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 100)
        Me.Controls.Add(Me.msgwind)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MsgBoxer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ouch!"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.msgwind.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents msgwind As dsc.dscTheme
    Friend WithEvents okbut As dsc.dscButtonBlackBG
    Friend WithEvents nobut As dsc.dscButtonBlackBG
    Friend WithEvents yesbut As dsc.dscButtonBlackBG
    Friend WithEvents errormsg2 As System.Windows.Forms.RichTextBox
End Class
