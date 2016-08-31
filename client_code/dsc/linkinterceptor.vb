Public Class linkinterceptor
    Implements Awesomium.Core.IResourceInterceptor
    Public _linktocheck As String = Nothing
    Property linktocheck As String
        Get
            Return _linktocheck
        End Get
        Set(ByVal value As String)
            If value <> _linktocheck Then
                _linktocheck = value
                PropertyChangedSub(EventArgs.Empty)
                '// handle more code changes here.'
            End If
        End Set
    End Property
    Protected Overridable Sub PropertyChangedSub(e As EventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub
    Public Event PropertyChanged As EventHandler
    Public Function OnFilterNavigation(ByVal request As Awesomium.Core.NavigationRequest) As Boolean Implements Awesomium.Core.IResourceInterceptor.OnFilterNavigation
        If request.Url.ToString.Contains("/member.php?u=") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("darksteam/api/") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("dsc://view/") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("dsc://install/") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("dsc://manifests/") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("dsc://run") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("dsc://crack") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.StartsWith("dsc://addon") Then
            linktocheck = request.Url.ToString
            Return True
        ElseIf request.Url.ToString.Contains("gameinfo.php") Then
            Return False
        ElseIf request.Url.ToString.Contains("latestgames.php") Then
            Return False
        ElseIf request.Url.ToString.Contains("faq.php") Then
            Return False
        ElseIf request.Url.ToString.Contains("login.php") Then
            Return False
        ElseIf request.Url.ToString.Contains("shoutbox.php") Then
            Return False
        ElseIf request.Url.ToString.Contains("dscmain.php") Then
            Return False
        Else
            System.Diagnostics.Process.Start(request.Url.ToString)
            Return True
        End If
    End Function
    Public Function OnRequest(ByVal request As Awesomium.Core.ResourceRequest) As Awesomium.Core.ResourceResponse Implements Awesomium.Core.IResourceInterceptor.OnRequest
        linktocheck = Nothing
        Return Nothing
    End Function
End Class
