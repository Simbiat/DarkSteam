Public Class faqwindow
    Public WithEvents faqContext As New ContextMenuStrip
    Private Sub msgboxer_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'try center screen
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Me.faqweb.Invoke(Sub() Me.faqweb.Source = New Uri("https://simbiat.ru/darksteam/api/faq.php"))
    End Sub
    Private Sub yesbut_Click(sender As Object, e As EventArgs) Handles yesbut.Click
        Me.Close()
    End Sub
    Private Sub yesbut_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles yesbut.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            yesbut_Click(Nothing, Nothing)
        End If
    End Sub
    Public Sub faqwebcontext() Handles faqweb.ShowContextMenu
        faqContext.Items.Clear()
        faqweb.Invoke(Sub() faqweb.ContextMenuStrip = faqContext)
    End Sub
End Class