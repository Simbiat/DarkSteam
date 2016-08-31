Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports System.Diagnostics.FileVersionInfo
Imports System.Drawing.Drawing2D
Imports System.Security.Cryptography.MD5CryptoServiceProvider
Public Class LoginForm
    Public salt = Nothing
    Public hashedpass = Nothing
    Public logincheck = Nothing
    Public passtocheck = Nothing
    Public loginpassed As String = ""
    Public passpassed As String = ""
    Public supsauth = 0
    Public passstrike = 0
    Public doupdate = Nothing
    Public supsplash = 0
    Public WithEvents bindownwc As New WebClient
    Public bindownname = Nothing
    Public canstat = 0
    Public wholebinlist
    Public initsets As String = "0;!!!;0;!!!;0;!!!;0;!!!;1;!!!;1;!!!;15000;!!!;20;!!!;1;!!!;1;!!!;;!!!;1;!!!;0;!!!;0;!!!;1;!!!;1;!!!;0;!!!;0;!!!;0;!!!;1;!!!;;!!!;1;!!!;5;!!!;1;!!!;0;!!!;1;!!!;0;!!!;0;!!!;0"
    Function MyResolveEventHandler(ByVal sender As Object, _
                           ByVal args As ResolveEventArgs) As System.Reflection.Assembly
        'This handler is called only when the common language runtime tries to bind to the assembly and fails.        
        bindownload()
        'Retrieve the list of referenced assemblies in an array of AssemblyName.
        Dim objExecutingAssemblies As System.Reflection.Assembly
        objExecutingAssemblies = System.Reflection.Assembly.GetExecutingAssembly()
        Dim arrReferencedAssmbNames() As System.Reflection.AssemblyName
        arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies()

        'Loop through the array of referenced assembly names.
        Dim strAssmbName As System.Reflection.AssemblyName
        For Each strAssmbName In arrReferencedAssmbNames

            'Look for the assembly names that have raised the "AssemblyResolve" event.
            If (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) = args.Name.Substring(0, args.Name.IndexOf(","))) Then

                'Build the path of the assembly from where it has to be loaded.
                Dim strTempAssmbPath As String
                strTempAssmbPath = Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & args.Name.Substring(0, args.Name.IndexOf(",")) & ".dll"
                Dim MyAssembly As System.Reflection.Assembly

                'Load the assembly from the specified path. 
                MyAssembly = System.Reflection.Assembly.LoadFrom(strTempAssmbPath)

                'Return the loaded assembly.
                Return MyAssembly
            End If
        Next
        Return Nothing
    End Function

    Public Sub LoginFormStyle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf MyResolveEventHandler
        Dim loginArgument As String = "/login="
        Dim passArgument As String = "/password="
        Dim suppressform As String = "/supform="
        Dim suppresssplash As String = "/supsplash="
        Dim suppresupd As String = "/supupd="
        Dim appiddown As String = "/appid="
        Dim manonly As String = "/manonly="
        Dim downdir As String = "/downdir="
        Dim downcrack As String = "/crack="
        Dim downaddon As String = "/addon="
        Dim apptorun As String = "/run="
        Dim suplogform = 0
        Dim supupd = 0

        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        dscTheme1.Text = "DarkSteam: User Authorisation (v." & My.Application.Info.Version.ToString & ")"
        Me.TopMost = True

        Dim fulllistofarg = Nothing
        For Each s As String In My.Application.CommandLineArgs
            fulllistofarg = fulllistofarg & " " & s
        Next
        dscWindow.fulllistofarg = fulllistofarg

        If fulllistofarg <> "" Then
            If My.Application.CommandLineArgs(0).StartsWith("dsc://install/") Then
                dscWindow.extrahide = False
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://install/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://manifests/") Then
                dscWindow.extrahide = False
                dscWindow.manonly = 1
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://manifests/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://run/") Then
                dscWindow.extrahide = False
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://run/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                dscWindow.apptorun = 1
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://run2/") Then
                dscWindow.extrahide = False
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://run2/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                dscWindow.apptorun = 2
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://run3/") Then
                dscWindow.extrahide = False
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://run3/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                dscWindow.apptorun = 3
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://run4/") Then
                dscWindow.extrahide = False
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://run4/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                dscWindow.apptorun = 4
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://run5/") Then
                dscWindow.extrahide = False
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://run5/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                dscWindow.apptorun = 5
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://crack/") Then
                dscWindow.extrahide = False
                dscWindow.downcrack = 1
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://crack/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://crack2/") Then
                dscWindow.extrahide = False
                dscWindow.downcrack = 2
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://crack2/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://crack3/") Then
                dscWindow.extrahide = False
                dscWindow.downcrack = 3
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://crack3/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://crack4/") Then
                dscWindow.extrahide = False
                dscWindow.downcrack = 4
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://crack4/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://crack5/") Then
                dscWindow.extrahide = False
                dscWindow.downcrack = 5
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://crack5/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://addon/") Then
                dscWindow.extrahide = False
                dscWindow.downaddon = 1
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://addon/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://addon2/") Then
                dscWindow.extrahide = False
                dscWindow.downaddon = 2
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://addon2/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://addon3/") Then
                dscWindow.extrahide = False
                dscWindow.downaddon = 3
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://addon3/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://addon4/") Then
                dscWindow.extrahide = False
                dscWindow.downaddon = 4
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://addon4/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            ElseIf My.Application.CommandLineArgs(0).StartsWith("dsc://addon5/") Then
                dscWindow.extrahide = False
                dscWindow.downaddon = 5
                Dim appidtodown = My.Application.CommandLineArgs(0).Replace("dsc://addon5/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
            Else
                'do nothing
            End If
        End If

        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower.StartsWith(downcrack) Then
                If s.Remove(0, downcrack.Length) > 5 Or s.Remove(0, downcrack.Length) <= 0 Then
                    dscWindow.downcrack = 0
                Else
                    dscWindow.downcrack = s.Remove(0, downcrack.Length)
                End If
            End If
            If s.ToLower.StartsWith(downaddon) Then
                If s.Remove(0, downaddon.Length) > 5 Or s.Remove(0, downaddon.Length) <= 0 Then
                    dscWindow.downaddon = 0
                Else
                    dscWindow.downaddon = s.Remove(0, downaddon.Length)
                End If
            End If
            If s.ToLower.StartsWith(apptorun) Then
                If s.Remove(0, apptorun.Length) > 5 Or s.Remove(0, apptorun.Length) <= 0 Then
                    dscWindow.apptorun = 0
                Else
                    dscWindow.apptorun = s.Remove(0, apptorun.Length)
                End If
            End If
            If s.ToLower.StartsWith(loginArgument) Then
                loginpassed = s.Remove(0, loginArgument.Length)
            End If
            If s.ToLower.StartsWith(passArgument) Then
                passpassed = s.Remove(0, passArgument.Length)
            End If
            If s.ToLower.StartsWith(suppressform) Then
                suplogform = s.Remove(0, suppressform.Length)
            End If
            If s.ToLower.StartsWith(suppresssplash) Then
                supsplash = s.Remove(0, suppresssplash.Length)
            End If
            If s.ToLower.StartsWith(suppresupd) Then
                supupd = s.Remove(0, suppresupd.Length)
                dscWindow.supupd = supupd
            End If
            If s.ToLower.StartsWith(appiddown) Then
                dscWindow.appidtodown = s.Remove(0, appiddown.Length)
            End If
            If s.ToLower.StartsWith(manonly) Then
                dscWindow.manonly = s.Remove(0, manonly.Length)
            End If
            If s.ToLower.StartsWith(downdir) Then
                dscWindow.downdir = s.Remove(0, downdir.Length)
            End If
        Next

        If supupd = 0 Then
            Dim curpath As String = Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "")
            Dim curexe As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim cmdname As String = curpath & "\dscupdate.cmd"
            Dim updsuc = False
            If System.IO.File.Exists(cmdname) = True Then
                File.Delete(cmdname)
                updsuc = True
            End If
            If System.IO.File.Exists(cmdname) = True Then
                File.Delete(curexe & ".old")
                updsuc = True
            End If
            If System.IO.File.Exists(cmdname) = True Then
                File.Delete(curexe & ".update")
                updsuc = True
            End If
            If updsuc = True Then
                Messageboxing("Update successfull!", "DarkSteam client was updated successfully!")
            End If
            If updsuc = False Then

                Dim inStream As StreamReader
                Dim updinitreq As HttpWebRequest
                Dim webresponse As WebResponse = Nothing
                updinitreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/dsc.txt")
                updinitreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Try
                    webresponse = updinitreq.GetResponse()
                Catch ex As Exception
                    Messageboxing("No connection!", "Seems like our website is down =(" & vbCrLf & "Unfortunatelly we'll have to exit =(" & vbCrLf & "Please, try again later")
                    Me.TopMost = False
                    Me.Close()
                End Try
                inStream = New StreamReader(webresponse.GetResponseStream())
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
                    updatewindow.ShowDialog()
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
                    End If
                ElseIf My.Application.Info.Version.ToString > latever Then
                    doupdate = Nothing
                    Messageboxing("DarkSteam Client may be hacked!", "Seems like the client you're using is newer than the one officially released. It's possible it was modified by a third party and thus may harm your system. It's recommended to redownload the client from official server instead of using this one." & vbCrLf & vbCrLf & "Do you want to continue?")
                    If doupdate <> vbYes Then
                        Application.Exit()
                    End If
                End If
            End If
        End If

        UsernameTextBox.Text = loginpassed
        PasswordTextBox.Text = passpassed
        If UsernameTextBox.Text = "" Or UsernameTextBox.Text = Nothing Then
            UsernameTextBox.Select()
        Else
            If PasswordTextBox.Text = "" Or PasswordTextBox.Text = Nothing Then
                PasswordTextBox.Select()
            Else
                OK.Select()
            End If
        End If
        'If suplogform = 1 Then
        OK_Click(Me, Nothing)
        'End If
    End Sub
    Public Sub bindownload()
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        If Not Directory.Exists(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\") Then
            Directory.CreateDirectory(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\")
        End If
        Dim bindownstream As StreamReader
        Dim bindownreq As HttpWebRequest
        Dim bindownres As WebResponse = Nothing
        bindownreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/md5bin.php")
        bindownreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
        Try
            bindownres = bindownreq.GetResponse()
        Catch ex As Exception
        End Try
        bindownstream = New StreamReader(bindownres.GetResponseStream())
        Dim wholebinnonsplit = bindownstream.ReadToEnd
        bindownstream.Close()
        wholebinlist = Split(wholebinnonsplit, "<BR>")
        libsdownworker.RunWorkerAsync()
        While libsdownworker.IsBusy = True
            If canstat = 1 Then
                Exit Sub
            End If
            Application.DoEvents()
        End While
    End Sub
    Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        UsernameTextBox.Enabled = False
        PasswordTextBox.Enabled = False
        OK.Enabled = False
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        logstatbar.Text = "Checking libraries..."
        If Not Directory.Exists(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\") Then
            Directory.CreateDirectory(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\")
        End If
        Dim bindownstream As StreamReader
        Dim bindownreq As HttpWebRequest
        Dim bindownres As WebResponse = Nothing
        bindownreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/md5bin.php")
        bindownreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
        Try
            bindownres = bindownreq.GetResponse()
        Catch ex As Exception
            MsgBox("fail")
        End Try
        bindownstream = New StreamReader(bindownres.GetResponseStream())
        Dim wholebinnonsplit = bindownstream.ReadToEnd
        bindownstream.Close()
        wholebinlist = Split(wholebinnonsplit, "<BR>")
        libsdownworker.RunWorkerAsync()
        While libsdownworker.IsBusy = True
            If canstat = 1 Then
                Exit Sub
            End If
            Application.DoEvents()
        End While
        logincheck = UsernameTextBox.Text
        passtocheck = PasswordTextBox.Text
        dscWindow.encpassram = Encrypt(passtocheck)
        dscWindow.encloginram = Encrypt(logincheck)
        If supsauth = 0 Then
            logstatbar.Text = "Loading DarkSteam Client (v." & My.Application.Info.Version.ToString & ")..."
            dscWindow.Show()
            Me.Visible = False
            Me.TopMost = False
            Me.Close()
        End If
    End Sub
    Private Sub BackgroundWorker1_dowork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles libsdownworker.DoWork
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        For row = 0 To UBound(wholebinlist) - 1
            Dim splitrow = Split(wholebinlist(row), ";!!!;")
            Dim floffset = 0
            If Not File.Exists(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0)) Then
                While filesize(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0)) <> splitrow(2)
                    bindownname = splitrow(0)
                    StartDownload("https://simbiat.ru/darksteam/api/bindown.php?offset=" & floffset & "&file=" & Encrypt(splitrow(0)), Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0))
                End While
            Else
                If splitrow(1) <> MD5File(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0)) Then
                    File.Delete(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0))
                    While filesize(Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0)) <> splitrow(2)
                        bindownname = splitrow(0)
                        StartDownload("https://simbiat.ru/darksteam/api/bindown.php?offset=" & floffset & "&file=" & Encrypt(splitrow(0)), Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & "\dscbin\" & splitrow(0))
                    End While
                End If
            End If
        Next
    End Sub
    Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As FileDownloadProgressChangedEventArgs)
        logstatbar.Text = "Downloading " & bindownname & " (" & e.ProgressPercentage & "%)..."
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
        wClient.DowloadFileAsync(URL, LocalFilePath, logstatbar)
        While wClient.IsBusy = True
            Application.DoEvents()
        End While

        '// Set wClient to Nothing, because we don't need it anymore.
        wClient = Nothing
    End Sub
    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles bindownwc.DownloadProgressChanged
        logstatbar.Text = "Downloading " & bindownname & " (" & e.ProgressPercentage & "%)..."
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If bindownwc.IsBusy = True Then
            bindownwc.CancelAsync()
            canstat = 1
            While bindownwc.IsBusy
                Application.DoEvents()
            End While
        End If
        Me.Close()
        Application.Exit()
    End Sub
    Private Sub UsernameTextBox_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            OK_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub PasswordTextBox_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            OK_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub OK_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles OK.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            OK_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub Cancel_keydown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Cancel.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Cancel_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub RegisterLink_Click(sender As Object, e As EventArgs) Handles RegisterLink.Click
        System.Diagnostics.Process.Start("https://simbiat.ru/darksteam/register.php")
    End Sub

    Private Sub ResetPWLabel_Click(sender As Object, e As EventArgs) Handles ResetPWLabel.Click
        System.Diagnostics.Process.Start("https://simbiat.ru/darksteam/login.php?do=lostpw")
    End Sub
End Class