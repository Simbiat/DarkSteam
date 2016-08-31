Public Class updatewindow
    Private Sub msgboxer_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'try center screen
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub
    Private Sub yesbut_Click(sender As Object, e As EventArgs) Handles yesbut.Click
        LoginForm.doupdate = vbYes
        dscWindow.doupdate = vbYes
        Me.Close()
    End Sub
    Private Sub nobut_Click(sender As Object, e As EventArgs) Handles nobut.Click
        Me.Close()
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