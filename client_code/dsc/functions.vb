Imports System.Security.Principal
Imports Microsoft.Win32
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Collections.Generic
Module Functionsv75
    Class JaggedComparer
        Implements IComparer
        'IComparable
        Public columnsorter
        Property sortbycolumn() As Integer
            Get
                Return columnsorter
            End Get
            Set(ByVal Value As Integer)
                columnsorter = Value
            End Set
        End Property
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            ' x and y are arrays of integers
            ' sort on the 2nd item in each array
            Dim a1() = DirectCast(x, String())
            Dim a2() = DirectCast(y, String())
            Return a1(columnsorter).CompareTo(a2(columnsorter))
        End Function
    End Class
    Public Sub elementsplacing()

        'sizelimit
        If dscWindow.Width < 400 Then
            dscWindow.Width = 400
        End If
        If dscWindow.Height < 400 Then
            dscWindow.Height = 400
        End If

        If dscWindow.WindowState = FormWindowState.Normal Then
            settingswindow.ResolutionX.Text = dscWindow.Width
            settingswindow.ResolutionY.Text = dscWindow.Height
        End If

        Dim dscwindwidthforcent = dscWindow.Width - dscWindow.StatisticsGroupBox.Width

        dscWindow.homeicon.Location = New Point(dscWindow.ControlBox1.Location.X + 1, dscWindow.ControlBox1.Location.Y)
        dscWindow.websiteicon.Location = New Point(dscWindow.homeicon.Location.X + 25, dscWindow.ControlBox1.Location.Y)
        dscWindow.settingsicon.Location = New Point(dscWindow.websiteicon.Location.X + 25, dscWindow.ControlBox1.Location.Y)

        'left column
        dscWindow.shoutboxweb.Location = New Point(dscwindwidthforcent * 0.0148, 33)
        Dim dscwindheight = dscWindow.Height - dscWindow.shoutboxweb.Location.Y
        If dscWindow.dscProgressBar2.Visible = False Then
            dscWindow.shoutboxweb.Height = (dscwindheight - dscWindow.dscProgressBar.Height) * 0.97
        Else
            dscWindow.shoutboxweb.Height = (dscwindheight - dscWindow.dscProgressBar.Height) * 0.92
        End If


        'progress bars
        dscWindow.dscProgressBar2.Location = New Point(dscWindow.shoutboxweb.Location.X, dscwindheight)
        If dscWindow.dscProgressBar2.Location.Y <= dscWindow.shoutboxweb.Location.Y + dscWindow.shoutboxweb.Height Then
            dscWindow.dscProgressBar2.Location = New Point(dscWindow.shoutboxweb.Location.X, dscWindow.shoutboxweb.Location.Y + dscWindow.shoutboxweb.Height + 1)
        End If
        dscWindow.dscProgressBar2.Width = dscWindow.shoutboxweb.Location.X + dscWindow.shoutboxweb.Width - dscWindow.shoutboxweb.Location.X - dscWindow.processbtn.Width - dscWindow.Width * 0.0048
        If dscWindow.dscProgressBar2.Visible = True Then
            dscWindow.dscProgressBar.Location = New Point(dscWindow.shoutboxweb.Location.X, dscwindheight * 1.04)
            If dscWindow.dscProgressBar.Location.Y + dscWindow.dscProgressBar.Height >= dscWindow.Height Then
                dscWindow.dscProgressBar.Location = New Point(dscWindow.dscProgressBar.Location.X, dscWindow.Height - dscWindow.dscProgressBar.Height - 5)
            End If
            If dscWindow.dscProgressBar.Location.Y <= dscWindow.dscProgressBar2.Location.Y + dscWindow.dscProgressBar2.Height Then
                dscWindow.dscProgressBar.Location = New Point(dscWindow.dscProgressBar2.Location.X, dscWindow.dscProgressBar2.Location.Y + dscWindow.dscProgressBar2.Height + 1)
            End If
        Else
            dscWindow.dscProgressBar.Location = New Point(dscWindow.shoutboxweb.Location.X, dscwindheight * 1.04)
            If dscWindow.dscProgressBar.Location.Y <= dscWindow.shoutboxweb.Location.Y + dscWindow.shoutboxweb.Height Then
                dscWindow.dscProgressBar.Location = New Point(dscWindow.shoutboxweb.Location.X, dscWindow.shoutboxweb.Location.Y + dscWindow.shoutboxweb.Height + 1)
            End If
        End If
        dscWindow.dscProgressBar.Width = dscWindow.dscProgressBar2.Width

        'right buttons
        'If dscWindow.shoutboxweb.Location.Y < dscWindow.StatisticsGroupBox.Location.Y + dscWindow.StatisticsGroupBox.Height Then
        '    dscWindow.StatisticsGroupBox.Visible = False
        'Else
        '    dscWindow.StatisticsGroupBox.Visible = True
        'End If

        'center blocks
        If dscWindow.shoutboxweb.Visible = True Then

        Else
            If dscWindow.dscProgressBar2.Visible = True Then

            Else

            End If
        End If

        'latest games
        dscWindow.shoutboxweb.Width = dscWindow.Width - dscWindow.shoutboxweb.Location.X - dscWindow.StatisticsGroupBox.Width - 20

        'statistics
        'If dscWindow.StatisticsGroupBox.Visible = True Then
        dscWindow.StatisticsGroupBox.Location = New Point(dscWindow.shoutboxweb.Location.X + dscWindow.shoutboxweb.Width + dscWindow.Width * 0.0048, dscWindow.shoutboxweb.Location.Y)
        'End If
        If dscWindow.StatisticsGroupBox.Visible = True Then
            If dscWindow.StatisticsGroupBox.Location.X + dscWindow.StatisticsGroupBox.Width > dscWindow.Width Then
                dscWindow.StatisticsGroupBox.Location = New Point(dscWindow.shoutboxweb.Location.X + dscWindow.shoutboxweb.Width + dscWindow.Width * 0.0048, dscWindow.shoutboxweb.Location.Y)
            End If
        End If

        dscWindow.processbtn.Location = New Point(dscWindow.StatisticsGroupBox.Location.X + dscWindow.processbtn.Width * 0.7, dscWindow.shoutboxweb.Location.Y + dscWindow.shoutboxweb.Height + dscWindow.Height * 0.02)
        If dscWindow.processbtn.Location.Y + dscWindow.processbtn.Height >= dscWindow.Height Then
            dscWindow.processbtn.Location = New Point(dscWindow.StatisticsGroupBox.Location.X + dscWindow.processbtn.Width * 0.7, dscWindow.shoutboxweb.Location.Y + dscWindow.shoutboxweb.Height + 1)
        End If

    End Sub
    Public Sub Messageboxing(title As String, body As String)
        MsgBoxer.Text = title
        MsgBoxer.msgwind.Text = title
        MsgBoxer.errormsg2.Text = body
        MsgBoxer.errormsg2.SelectAll()
        MsgBoxer.errormsg2.SelectionAlignment = HorizontalAlignment.Center
        'MsgBoxer.Owner = dscWindow
        MsgBoxer.TopMost = True
        MsgBoxer.ShowDialog()
    End Sub
    Public Function SteamLoc() As String
        Dim localization As String = Nothing
        localization = Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "")
        Return localization
    End Function
    Public Function FindForm(ByVal frmName As String, ByVal rent As Form) As Form
        Dim children As Form
        Dim frmFound As Form = Nothing
        If rent.HasChildren() Then
            For Each children In rent.MdiChildren
                If children.Name = frmName Then
                    frmFound = children
                End If
            Next
        Else
            frmFound = Nothing
        End If
        Return frmFound
    End Function
    ' Keys required for Symmetric encryption / decryption
    Dim rijnKey As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
    Dim rijnIV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
    Function Decrypt(S As String)
        If S = "" Then
            Return S
        End If
        ' Turn the cipherText into a ByteArray from Base64
        Dim cipherText As Byte()
        Try
            ' Replace any + that will lead to the error
            cipherText = Convert.FromBase64String(S.Replace("BIN00101011BIN", "+"))
        Catch ex As Exception
            ' There is a problem with the string, perhaps it has bad base64 padding
            Return S
        End Try
        'Creates the default implementation, which is RijndaelManaged.
        Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Try
            ' Create the streams used for decryption.
            Using msDecrypt As New MemoryStream(cipherText)
                Using csDecrypt As New CryptoStream(msDecrypt, rijn.CreateDecryptor(rijnKey, rijnIV), CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(csDecrypt)
                        ' Read the decrypted bytes from the decrypting stream and place them in a string.
                        S = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        Catch E As CryptographicException
            Return S
        End Try
        Return S
    End Function
    Function Encrypt(S As String)
        'Creates the default implementation, which is RijndaelManaged.
        Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Dim encrypted() As Byte
        Using msEncrypt As New MemoryStream()
            Dim csEncrypt As New CryptoStream(msEncrypt, rijn.CreateEncryptor(rijnKey, rijnIV), CryptoStreamMode.Write)
            Using swEncrypt As New StreamWriter(csEncrypt)
                'Write all data to the stream.
                swEncrypt.Write(S)
            End Using
            encrypted = msEncrypt.ToArray()
        End Using

        ' You cannot convert the byte to a string or you will get strange characters so base64 encode the string
        ' Replace any + that will lead to the error
        Return Convert.ToBase64String(encrypted).Replace("+", "BIN00101011BIN")
    End Function
    Function wrappedString(inputString As String, Optional maxLength As Integer = 100) As String
        Dim inputRRay As Object
        Dim outline As String = ""
        wrappedString = ""
        Dim i As Long
        If 2 > maxLength Then maxLength = 100
        inputRRay = Split(inputString)
        For i = 0 To UBound(inputRRay)
            If Len(outline) + Len(inputRRay(i)) > (maxLength - 1) Then
                If wrappedString = "" Then
                    wrappedString = inputRRay(i)
                Else
                    wrappedString = wrappedString & inputRRay(i)
                End If
                outline = inputRRay(i)
            Else
                wrappedString = wrappedString & " " & inputRRay(i)
                outline = outline & "" & inputRRay(i)
            End If
        Next i
        wrappedString = Trim(wrappedString)
    End Function
    Sub game_removal()
        If dscWindow.format = "acf" Or dscWindow.format = "ncf" Then
            Dim dirs As String() = Split(dscWindow.commonfolder, "\")
            If System.IO.Directory.Exists(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs))) Then
                For Each filetodel In System.IO.Directory.GetFiles(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs)), "*", SearchOption.AllDirectories)
                    If File.Exists(filetodel) Then
                        Dim filereadonly = New FileInfo(filetodel)
                        If filereadonly.IsReadOnly Then
                            File.SetAttributes(filetodel, FileAttributes.Normal)
                        End If
                        File.Delete(filetodel)
                    End If
                Next
                For Each dirtodel In System.IO.Directory.GetDirectories(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs)), "*", SearchOption.AllDirectories)
                    If System.IO.Directory.Exists(dirtodel) Then
                        If System.IO.Directory.GetFiles(dirtodel).Length = 0 And System.IO.Directory.GetDirectories(dirtodel).Length = 0 Then
                            Dim filereadonly = New DirectoryInfo(dirtodel)
                            If filereadonly.Attributes = FileAttributes.ReadOnly Then
                                filereadonly.Attributes = FileAttributes.Normal
                            End If
                            System.IO.Directory.Delete(dirtodel, True)
                        End If
                    End If
                Next
                If System.IO.Directory.GetFiles(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs))).Length = 0 And System.IO.Directory.GetDirectories(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs))).Length = 0 Then
                    Dim filereadonly = New DirectoryInfo(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs)))
                    If filereadonly.Attributes = FileAttributes.ReadOnly Then
                        filereadonly.Attributes = FileAttributes.Normal
                    End If
                    System.IO.Directory.Delete(dscWindow.setpath & "\steamapps\common\" & dirs(UBound(dirs)), True)
                End If
            End If
        End If

        If dscWindow.format = "acf" Then
            If dscWindow.manifests <> Nothing And dscWindow.manifests <> "" Then
                Dim files As String() = Split(dscWindow.manifests, ",")
                For Each filetodel As String In files
                    If File.Exists(dscWindow.setpath & "\depotcache\" & filetodel) Then
                        Dim filereadonly = New FileInfo(dscWindow.setpath & "\depotcache\" & filetodel)
                        If filereadonly.IsReadOnly Then
                            File.SetAttributes(dscWindow.setpath & "\depotcache\" & filetodel, FileAttributes.Normal)
                        End If
                        File.Delete(dscWindow.setpath & "\depotcache\" & filetodel)
                    End If
                Next
            End If
            If File.Exists(dscWindow.setpath & "\steamapps\appmanifest_" & dscWindow.appid & ".acf") Then
                Dim filereadonly = New FileInfo(dscWindow.setpath & "\steamapps\appmanifest_" & dscWindow.appid & ".acf")
                If filereadonly.IsReadOnly Then
                    File.SetAttributes(dscWindow.setpath & "\steamapps\appmanifest_" & dscWindow.appid & ".acf", FileAttributes.Normal)
                End If
                File.Delete(dscWindow.setpath & "\steamapps\appmanifest_" & dscWindow.appid & ".acf")
            End If
        End If
        If dscWindow.format = "ncf" Then
            Dim filestocheck As String() = Split(dscWindow.manifests, ",")
            For Each filetocheck As String In filestocheck
                If File.Exists(dscWindow.setpath & "\steamapps\" & filetocheck) Then
                    Dim filereadonly = New FileInfo(dscWindow.setpath & "\steamapps\" & filetocheck)
                    If filereadonly.IsReadOnly Then
                        File.SetAttributes(dscWindow.setpath & "\steamapps\" & filetocheck, FileAttributes.Normal)
                    End If
                    File.Delete(dscWindow.setpath & "\steamapps\" & filetocheck)
                End If
            Next
        End If
        If System.IO.Directory.Exists(dscWindow.setpath & "\depotcache\") Then
            If System.IO.Directory.GetFiles(dscWindow.setpath & "\depotcache\").Length = 0 And System.IO.Directory.GetDirectories(dscWindow.setpath & "\depotcache\").Length = 0 Then
                Dim filereadonly = New DirectoryInfo(dscWindow.setpath & "\depotcache\")
                If filereadonly.Attributes = FileAttributes.ReadOnly Then
                    filereadonly.Attributes = FileAttributes.Normal
                End If
                System.IO.Directory.Delete(dscWindow.setpath & "\depotcache\", True)
            End If
        End If
        If System.IO.Directory.Exists(dscWindow.setpath & "\steamapps\common\") Then
            If System.IO.Directory.GetFiles(dscWindow.setpath & "\steamapps\common\").Length = 0 And System.IO.Directory.GetDirectories(dscWindow.setpath & "\steamapps\common\").Length = 0 Then
                Dim filereadonly = New DirectoryInfo(dscWindow.setpath & "\steamapps\common\")
                If filereadonly.Attributes = FileAttributes.ReadOnly Then
                    filereadonly.Attributes = FileAttributes.Normal
                End If
                System.IO.Directory.Delete(dscWindow.setpath & "\steamapps\common\", True)
            End If
        End If
        If System.IO.Directory.Exists(dscWindow.setpath & "\steamapps\") Then
            If System.IO.Directory.GetFiles(dscWindow.setpath & "\steamapps\").Length = 0 And System.IO.Directory.GetDirectories(dscWindow.setpath & "\steamapps\").Length = 0 Then
                Dim filereadonly = New DirectoryInfo(dscWindow.setpath & "\steamapps\")
                If filereadonly.Attributes = FileAttributes.ReadOnly Then
                    filereadonly.Attributes = FileAttributes.Normal
                End If
                System.IO.Directory.Delete(dscWindow.setpath & "\steamapps\", True)
            End If
        End If

        'shortcuts removal
        Dim wsh As Object = CreateObject("WScript.Shell")
        wsh = CreateObject("WScript.Shell")
        Dim DesktopPath
        DesktopPath = wsh.SpecialFolders("Desktop")
        Dim spaceappid As String = dscWindow.appid
        For i As Integer = spaceappid.Length - 1 To 1 Step -1
            spaceappid = spaceappid.Insert(i, " ")
        Next
        Dim Directory As New IO.DirectoryInfo(DesktopPath)
        Dim shortcuts As IO.FileInfo() = Directory.GetFiles("*.lnk")
        For Each shortcut In shortcuts
            Dim objShell As Shell32.Shell
            Dim objFolder As Shell32.Folder
            objShell = New Shell32.Shell
            objFolder = objShell.NameSpace(DesktopPath)
            If (Not objFolder Is Nothing) Then
                Dim objFolderItem As Shell32.FolderItem
                objFolderItem = objFolder.ParseName(shortcut.FullName)
                If (Not objFolderItem Is Nothing) Then
                    Dim szItem As String
                    szItem = objFolder.GetDetailsOf(objFolderItem, 11)
                    If shortcut.FullName.Contains(dscWindow.gameloaded) And Not szItem.Contains(";") Then
                        File.Delete(shortcut.FullName)
                    End If
                End If
                objFolderItem = Nothing
            End If
            objFolder = Nothing
            objShell = Nothing
        Next

        dscWindow.homeicon_Click(dscWindow.GamesListContext, Nothing)
        Messageboxing("Game removed!", dscWindow.gameloaded & " was successfully removed!")
    End Sub
    Public Function MD5File(ByVal Filename As String) As String

        Dim MD5 = System.Security.Cryptography.MD5.Create
        Dim Hash As Byte()
        Dim sb As New System.Text.StringBuilder

        Using st As New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            Hash = MD5.ComputeHash(st)
        End Using

        For Each b In Hash
            sb.Append(b.ToString("X2"))
        Next

        Return sb.ToString
    End Function
    Public Sub gamebanker()
        ReDim dscWindow.gamebank(1)
        Dim inStream As StreamReader
        Dim gamebankreq As HttpWebRequest
        Dim gamebankrep As WebResponse = Nothing
        gamebankreq = HttpWebRequest.Create("https://simbiat.ru/darksteam/api/list.php")
        gamebankreq.UserAgent = "dsc" & My.Application.Info.Version.ToString
        Try
            gamebankrep = gamebankreq.GetResponse()
        Catch ex As Exception
            Messageboxing("No connection!", "Seems like our website is down =(" & vbCrLf & "Unfortunatelly we'll have to exit =(" & vbCrLf & "Please, try again later")
        End Try
        inStream = New StreamReader(gamebankrep.GetResponseStream())
        Dim wholelistnonsplit = inStream.ReadToEnd
        inStream.Close()
        If wholelistnonsplit <> dscWindow.whoelistnonsplit Then
            Dim wholelist = Split(wholelistnonsplit, "<BR>")
            ReDim dscWindow.gamebank(UBound(wholelist) - 1)
            For row = 0 To UBound(wholelist) - 1
                Dim splitrow = Split(wholelist(row), ";!!!;")
                dscWindow.gamebank(row) = New String(47) {}
                'appID
                dscWindow.gamebank(row)(0) = splitrow(0)
                'Format
                dscWindow.gamebank(row)(1) = splitrow(1)
                'PathToACF
                dscWindow.gamebank(row)(2) = splitrow(2)
                'LastUpdated
                dscWindow.gamebank(row)(3) = splitrow(3)
                'UpdatedOn
                dscWindow.gamebank(row)(4) = splitrow(4)
                'Addedon
                dscWindow.gamebank(row)(5) = splitrow(5)
                'UpToDate
                dscWindow.gamebank(row)(6) = splitrow(6)
                'gamename
                dscWindow.gamebank(row)(7) = splitrow(7)
                'GameCommonFolder
                dscWindow.gamebank(row)(8) = splitrow(8)
                'CommonFolderSize
                dscWindow.gamebank(row)(9) = splitrow(9)
                'Language
                dscWindow.gamebank(row)(10) = splitrow(10)
                'ActiveDepots
                dscWindow.gamebank(row)(11) = splitrow(11)
                'DepotFolder
                dscWindow.gamebank(row)(12) = splitrow(12)
                'RegUser
                dscWindow.gamebank(row)(13) = splitrow(13)
                'GenAva
                dscWindow.gamebank(row)(14) = splitrow(14)
                'exe1path
                dscWindow.gamebank(row)(15) = splitrow(15)
                'exe1desc
                dscWindow.gamebank(row)(16) = splitrow(16)
                'exe2path
                dscWindow.gamebank(row)(17) = splitrow(17)
                'exe2desc
                dscWindow.gamebank(row)(18) = splitrow(18)
                'exe3path
                dscWindow.gamebank(row)(19) = splitrow(19)
                'exe3desc
                dscWindow.gamebank(row)(20) = splitrow(20)
                'exe4path
                dscWindow.gamebank(row)(21) = splitrow(21)
                'exe4desc
                dscWindow.gamebank(row)(22) = splitrow(22)
                'exe5path
                dscWindow.gamebank(row)(23) = splitrow(23)
                'exe5desc
                dscWindow.gamebank(row)(24) = splitrow(24)
                'crack1path
                dscWindow.gamebank(row)(25) = splitrow(25)
                'crack2path
                dscWindow.gamebank(row)(26) = splitrow(26)
                'crack3path
                dscWindow.gamebank(row)(27) = splitrow(27)
                'crack4path
                dscWindow.gamebank(row)(28) = splitrow(28)
                'crack5path
                dscWindow.gamebank(row)(29) = splitrow(29)
                'addon1path
                dscWindow.gamebank(row)(30) = splitrow(30)
                'addon2path
                dscWindow.gamebank(row)(31) = splitrow(31)
                'addon3path
                dscWindow.gamebank(row)(32) = splitrow(32)
                'addon4path
                dscWindow.gamebank(row)(33) = splitrow(33)
                'addon5path
                dscWindow.gamebank(row)(34) = splitrow(34)
                'alldlcids
                dscWindow.gamebank(row)(35) = splitrow(35)
                'gamefeatures
                dscWindow.gamebank(row)(36) = splitrow(36)
                'reqage
                dscWindow.gamebank(row)(37) = splitrow(37)
                'headerimg
                dscWindow.gamebank(row)(38) = splitrow(38)
                'offwebsite
                dscWindow.gamebank(row)(39) = splitrow(39)
                'developers
                dscWindow.gamebank(row)(40) = splitrow(40)
                'publishers
                dscWindow.gamebank(row)(41) = splitrow(41)
                'genres
                dscWindow.gamebank(row)(42) = splitrow(42)
                'releasedate
                dscWindow.gamebank(row)(43) = splitrow(43)
                'misstorr
                dscWindow.gamebank(row)(44) = splitrow(44)
                'tirrinpr
                dscWindow.gamebank(row)(45) = splitrow(45)
                'torrname
                dscWindow.gamebank(row)(46) = splitrow(46)
            Next
        End If
    End Sub
    Public Function FormatFileSize(ByVal FileSizeBytes As Long) As String
        Dim sizeTypes() As String = {"b", "Kb", "Mb", "Gb"}
        Dim Len As Decimal = FileSizeBytes
        Dim sizeType As Integer = 0
        Do While Len > 1024
            Len = Decimal.Round(Len / 1024, 2)
            sizeType += 1
            If sizeType >= sizeTypes.Length - 1 Then Exit Do
        Loop

        Dim Resp As String = Len.ToString & " " & sizeTypes(sizeType)
        Return Resp
    End Function
    Function StripTags(ByVal html As String) As String
        ' Remove HTML tags.
        Return RegularExpressions.Regex.Replace(html, "<.*?>", "")
    End Function
    Function htmlstripper(stringtostrip As String)
        stringtostrip = stringtostrip.Replace("&rsquo;", "'")
        stringtostrip = stringtostrip.Replace("&#039;", "'")
        stringtostrip = stringtostrip.Replace("&amp;", "&")
        stringtostrip = stringtostrip.Replace("&hellip;", "...")
        stringtostrip = stringtostrip.Replace("&lsquo;", "‘")
        stringtostrip = stringtostrip.Replace("&rsquo;", "’")
        stringtostrip = stringtostrip.Replace("&sbquo;", "‚")
        stringtostrip = stringtostrip.Replace("&ldquo;", """")
        stringtostrip = stringtostrip.Replace("&rdquo;", """")
        stringtostrip = stringtostrip.Replace("&bdquo;", "„")
        stringtostrip = stringtostrip.Replace("&lsaquo;", "<")
        stringtostrip = stringtostrip.Replace("&rsaquo;", ">")
        stringtostrip = stringtostrip.Replace("&frasl;", "/")
        stringtostrip = stringtostrip.Replace("&lt;", "<")
        stringtostrip = stringtostrip.Replace("&gt;", ">")
        stringtostrip = stringtostrip.Replace("&ndash;", "–")
        stringtostrip = stringtostrip.Replace("&mdash;", "—")
        stringtostrip = stringtostrip.Replace("&nbsp;", " ")
        stringtostrip = stringtostrip.Replace("&copy;", "©")
        stringtostrip = stringtostrip.Replace("&laquo;", "«")
        stringtostrip = stringtostrip.Replace("&reg;", "®")
        stringtostrip = stringtostrip.Replace("&deg;", "°")
        stringtostrip = stringtostrip.Replace("&plusmn;", "±")
        stringtostrip = stringtostrip.Replace("&sup2;", "²")
        stringtostrip = stringtostrip.Replace("&sup3;", "³")
        stringtostrip = stringtostrip.Replace("&acute;", "´")
        stringtostrip = stringtostrip.Replace("&raquo;", "»")
        stringtostrip = stringtostrip.Replace("&quot;", """")
        Return stringtostrip
    End Function
    Public Sub batchdownloadstarter(Optional hideme As Boolean = True)
        If dscWindow.appidtodown <> "" And dscWindow.appidtodown <> Nothing Then
            If hideme = True And dscWindow.extrahide = True Then
                dscWindow.wasminimized = True
                dscWindow.ShowInTaskbar = True
                dscWindow.WindowState = FormWindowState.Minimized
                dscWindow.Visible = False
            End If
            For gamerow = 0 To dscWindow.gamebank.GetUpperBound(dscWindow.gamebank.Rank - 1)
                If dscWindow.gamebank(gamerow)(0) = dscWindow.appidtodown Then
                    dscWindow.appformat = dscWindow.gamebank(gamerow)(1)
                    If dscWindow.index = -1 Then
                        Messageboxing("AppID is not available!", "AppID is not found on server!")
                    Else
                        dscWindow.appidok = 1
                    End If
                End If
            Next
            dscWindow.appidtodown = Nothing

            If dscWindow.appidok = 1 Then
                If hideme = True And dscWindow.extrahide = True Then
                    dscWindow.wasminimized = True
                    dscWindow.ShowInTaskbar = True
                    dscWindow.WindowState = FormWindowState.Minimized
                    dscWindow.Visible = False
                End If
                If hideme = True And dscWindow.extrahide = True Then
                    dscWindow.supconf = 1
                Else
                    dscWindow.supconf = 0
                End If
                If dscWindow.downcrack > 0 Or dscWindow.downaddon > 0 Then
                    If dscWindow.downcrack = 1 And dscWindow.crack1path <> "" And dscWindow.crack1path <> Nothing Then
                        dscWindow.downcrack = 0
                        dscWindow.download_func(dscWindow.crack1path)
                    ElseIf dscWindow.downcrack = 2 And dscWindow.crack2path <> "" And dscWindow.crack2path <> Nothing Then
                        dscWindow.downcrack = 0
                        dscWindow.download_func(dscWindow.crack2path)
                    ElseIf dscWindow.downcrack = 3 And dscWindow.crack3path <> "" And dscWindow.crack3path <> Nothing Then
                        dscWindow.downcrack = 0
                        dscWindow.download_func(dscWindow.crack3path)
                    ElseIf dscWindow.downcrack = 4 And dscWindow.crack4path <> "" And dscWindow.crack4path <> Nothing Then
                        dscWindow.downcrack = 0
                        dscWindow.download_func(dscWindow.crack4path)
                    ElseIf dscWindow.downcrack = 5 And dscWindow.crack5path <> "" And dscWindow.crack5path <> Nothing Then
                        dscWindow.downcrack = 0
                        dscWindow.download_func(dscWindow.crack5path)
                    ElseIf dscWindow.downaddon = 1 And dscWindow.addon1path <> "" And dscWindow.addon1path <> Nothing Then
                        dscWindow.downaddon = 0
                        dscWindow.download_func(dscWindow.addon1path)
                    ElseIf dscWindow.downaddon = 2 And dscWindow.addon2path <> "" And dscWindow.addon2path <> Nothing Then
                        dscWindow.downaddon = 0
                        dscWindow.download_func(dscWindow.addon2path)
                    ElseIf dscWindow.downaddon = 3 And dscWindow.addon3path <> "" And dscWindow.addon3path <> Nothing Then
                        dscWindow.downaddon = 0
                        dscWindow.download_func(dscWindow.addon3path)
                    ElseIf dscWindow.downaddon = 4 And dscWindow.addon4path <> "" And dscWindow.addon4path <> Nothing Then
                        dscWindow.downaddon = 0
                        dscWindow.download_func(dscWindow.addon4path)
                    ElseIf dscWindow.downaddon = 5 And dscWindow.addon5path <> "" And dscWindow.addon5path <> Nothing Then
                        dscWindow.downaddon = 0
                        dscWindow.download_func(dscWindow.addon5path)
                    End If
                ElseIf dscWindow.apptorun > 0 Then
                    Dim dirscom As String() = Split(dscWindow.commonfolder, "\")
                    If dscWindow.apptorun = 1 And dscWindow.exe1path <> "" And dscWindow.exe1desc <> "" Then
                        dscWindow.apptorun = 0
                        If File.Exists(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe1path) Then
                            System.Diagnostics.Process.Start(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe1path)
                        End If
                    End If
                    If dscWindow.apptorun = 2 And dscWindow.exe2path <> "" And dscWindow.exe2desc <> "" Then
                        dscWindow.apptorun = 0
                        If File.Exists(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe2path) Then
                            System.Diagnostics.Process.Start(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe2path)
                        End If
                    End If
                    If dscWindow.apptorun = 3 And dscWindow.exe3path <> "" And dscWindow.exe3desc <> "" Then
                        dscWindow.apptorun = 0
                        If File.Exists(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe3path) Then
                            System.Diagnostics.Process.Start(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe3path)
                        End If
                    End If
                    If dscWindow.apptorun = 4 And dscWindow.exe4path <> "" And dscWindow.exe4desc <> "" Then
                        dscWindow.apptorun = 0
                        If File.Exists(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe4path) Then
                            System.Diagnostics.Process.Start(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe4path)
                        End If
                    End If
                    If dscWindow.apptorun = 2 And dscWindow.exe5path <> "" And dscWindow.exe5desc <> "" Then
                        dscWindow.apptorun = 0
                        If File.Exists(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe5path) Then
                            System.Diagnostics.Process.Start(dscWindow.setpath & "\steamapps\common\" & dirscom(UBound(dirscom)) & "\" & dscWindow.exe5path)
                        End If
                    End If
                Else
                    If dscWindow.manonly = 1 Then
                        dscWindow.nocommondir = 1
                        dscWindow.download_func()
                    Else
                        dscWindow.nocommondir = 1
                        dscWindow.download_func()
                    End If
                End If
            End If
        End If
    End Sub
    Public Function filesize(ByVal Filepath As String) As Integer
        Try
            Dim fileDetail = My.Computer.FileSystem.GetFileInfo(Filepath)
            filesize = fileDetail.Length
            Return filesize
        Catch fail As Exception
            filesize = 0
            Return filesize
        End Try
    End Function
    Sub regdsclinks()
        Dim regKey As RegistryKey
        regKey = Registry.ClassesRoot.OpenSubKey("", True)
        regKey.CreateSubKey("dsc")
        regKey.CreateSubKey("dsc\DefaultIcon")
        regKey.CreateSubKey("dsc\Shell")
        regKey.CreateSubKey("dsc\Shell\Open")
        regKey.CreateSubKey("dsc\Shell\Open\Command")
        regKey = Registry.ClassesRoot.OpenSubKey("dsc", True)
        regKey.SetValue("", "URL:dsc protocol")
        regKey.SetValue("URL Protocol", "")
        regKey = Registry.ClassesRoot.OpenSubKey("dsc\DefaultIcon", True)
        regKey.SetValue("", Replace(Replace(System.Reflection.Assembly.GetExecutingAssembly().Location & "\", Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", ""), ""), "\", ""))
        regKey = Registry.ClassesRoot.OpenSubKey("dsc\Shell\Open\Command", True)
        regKey.SetValue("", """" & System.Reflection.Assembly.GetExecutingAssembly().Location & """ ""%1""")
        regKey.Close()
    End Sub
    Sub remdsclinks()
        Dim regKey As RegistryKey
        regKey = Registry.ClassesRoot.OpenSubKey("", True)
        Try
            regKey.DeleteSubKeyTree("dsc")
        Catch ex As Exception
            'do nothing
        End Try
        regKey.Close()
    End Sub
    Public Sub shortcut_create(Optional GameName = Nothing, Optional SecondName = Nothing, Optional appid = Nothing, Optional runid = Nothing, Optional exepath = Nothing)
        Dim wsh As Object = CreateObject("WScript.Shell")
        wsh = CreateObject("WScript.Shell")
        Dim MyShortcut, DesktopPath

        ' Read desktop path using WshSpecialFolders object
        DesktopPath = wsh.SpecialFolders("Desktop")
        MyShortcut = Nothing

        ' Create a shortcut object on the desktop
        If GameName = Nothing Then
            MyShortcut = wsh.CreateShortcut(DesktopPath & "\DarkSteam.lnk")
        Else
            If runid = 1 Then
                MyShortcut = wsh.CreateShortcut(DesktopPath & "\" & GameName & ".lnk")
            Else
                MyShortcut = wsh.CreateShortcut(DesktopPath & "\" & GameName & " (" & SecondName & ").lnk")
            End If
        End If

        ' Set shortcut object properties and save it
        If appid <> Nothing And runid <> Nothing Then
            If runid = 1 Then
                runid = ""
            End If
            MyShortcut.TargetPath = wsh.ExpandEnvironmentStrings("dsc://run" & runid & "/" & appid)
        Else
            MyShortcut.TargetPath = wsh.ExpandEnvironmentStrings("""" & System.Reflection.Assembly.GetExecutingAssembly().Location & """")
        End If
        MyShortcut.WorkingDirectory = wsh.ExpandEnvironmentStrings("""" & Replace(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "") & """")
        MyShortcut.WindowStyle = 4

        'Use this next line to assign a icon other then the default icon for the exe
        If exepath <> Nothing Then
            MyShortcut.IconLocation = exepath
        End If

        'Save the shortcut
        MyShortcut.Save()

    End Sub
End Module
