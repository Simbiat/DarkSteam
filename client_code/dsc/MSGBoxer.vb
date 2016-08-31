Public Class MsgBoxer
    Private Sub errormsg2scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles errormsg2.MouseEnter
        sender.Select()
        sender.SelectionLength = 0
    End Sub
    Private Sub msgboxer_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'try center screen
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        If errormsg2.Lines.Length < 1 Then
            errormsg2.Height = 17
            Me.Height = 100
        ElseIf errormsg2.Lines.Length >= 1 And errormsg2.Lines.Length <= 12 Then
            errormsg2.Height = 9 * (errormsg2.Lines.Length + 2)
            Me.Height = 100 - 15 + errormsg2.Height
        ElseIf errormsg2.Lines.Length > 12 Then
            errormsg2.Height = 9 * (errormsg2.Lines.Length + 2)
            Me.Height = 100 + 15 * 11
        End If
        yesbut.Location = New Point(74, errormsg2.Location.Y + errormsg2.Height + 5)
        okbut.Location = New Point(162, errormsg2.Location.Y + errormsg2.Height + 5)
        nobut.Location = New Point(250, errormsg2.Location.Y + errormsg2.Height + 5)
        If msgwind.Text = "Download confirmation" Or msgwind.Text = "DarkSteam Client update released!" Or msgwind.Text = "DarkSteam Client may be hacked!" Then
            yesbut.Visible = True
            nobut.Visible = True
            okbut.Visible = False
            yesbut.Select()
        Else
            yesbut.Visible = False
            nobut.Visible = False
            okbut.Visible = True
            okbut.Select()
        End If
    End Sub
    Public Sub okbut_Click(sender As System.Object, e As System.EventArgs) Handles okbut.Click
        If errormsg2.Text = "Wrong password was entered 5 times. Application will exit now." Or msgwind.Text = "No connection!" Or msgwind.Text = "Wrong usergroup!" Then
            Me.Close()
            Application.Exit()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub yesbut_Click(sender As Object, e As EventArgs) Handles yesbut.Click
        If msgwind.Text = "Download confirmation" Then
            dscWindow.downconf = vbYes
            Me.Close()
        ElseIf msgwind.Text = "DarkSteam Client update released!" Then
            LoginForm.doupdate = vbYes
            Me.Close()
        End If
    End Sub

    Private Sub nobut_Click(sender As Object, e As EventArgs) Handles nobut.Click
        Me.Close()
    End Sub
    Private Sub okbut_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles okbut.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            okbut_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub nobut_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nobut.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nobut_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub yesbut_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles yesbut.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            yesbut_Click(Nothing, Nothing)
        End If
    End Sub
End Class