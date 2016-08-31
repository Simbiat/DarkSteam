Imports System.IO
Imports System.Net
Imports System.ComponentModel
Module gameselector
    Public bw(10) As BackgroundWorker
    Public Sub GameSelected(curitem As String)
        For gamerow = 0 To dscWindow.gamebank.GetUpperBound(dscWindow.gamebank.Rank - 1)
            If dscWindow.gamebank(gamerow)(7).ToLower = curitem.ToLower Then
                dscWindow.gamelink = "http://store.steampowered.com/app/" & dscWindow.gamebank(gamerow)(0)
                'dscWindow.NewsFeedGroupBox.Visible = False
                dscWindow.exe1path = dscWindow.gamebank(gamerow)(15)
                dscWindow.exe2path = dscWindow.gamebank(gamerow)(17)
                dscWindow.exe3path = dscWindow.gamebank(gamerow)(19)
                dscWindow.exe4path = dscWindow.gamebank(gamerow)(21)
                dscWindow.exe5path = dscWindow.gamebank(gamerow)(23)
                dscWindow.exe1desc = dscWindow.gamebank(gamerow)(16)
                dscWindow.exe2desc = dscWindow.gamebank(gamerow)(18)
                dscWindow.exe3desc = dscWindow.gamebank(gamerow)(20)
                dscWindow.exe4desc = dscWindow.gamebank(gamerow)(22)
                dscWindow.exe5desc = dscWindow.gamebank(gamerow)(24)
                dscWindow.crack1path = dscWindow.gamebank(gamerow)(25)
                dscWindow.crack2path = dscWindow.gamebank(gamerow)(26)
                dscWindow.crack3path = dscWindow.gamebank(gamerow)(27)
                dscWindow.crack4path = dscWindow.gamebank(gamerow)(28)
                dscWindow.crack5path = dscWindow.gamebank(gamerow)(29)
                'dscWindow.crack1desc = dscWindow.gamebank(gamerow)(28)
                'dscWindow.crack2desc = dscWindow.gamebank(gamerow)(30)
                'dscWindow.crack3desc = dscWindow.gamebank(gamerow)(32)
                'dscWindow.crack4desc = dscWindow.gamebank(gamerow)(34)
                'dscWindow.crack5desc = dscWindow.gamebank(gamerow)(36)
                dscWindow.addon1path = dscWindow.gamebank(gamerow)(30)
                dscWindow.addon2path = dscWindow.gamebank(gamerow)(31)
                dscWindow.addon3path = dscWindow.gamebank(gamerow)(32)
                dscWindow.addon4path = dscWindow.gamebank(gamerow)(33)
                dscWindow.addon5path = dscWindow.gamebank(gamerow)(34)
                'dscWindow.addon1desc = dscWindow.gamebank(gamerow)(38)
                'dscWindow.addon2desc = dscWindow.gamebank(gamerow)(40)
                'dscWindow.addon3desc = dscWindow.gamebank(gamerow)(42)
                'dscWindow.addon4desc = dscWindow.gamebank(gamerow)(44)
                'dscWindow.addon5desc = dscWindow.gamebank(gamerow)(46)
                dscWindow.alldlcids = dscWindow.gamebank(gamerow)(35)
                'dscWindow.alldlcnames = dscWindow.gamebank(gamerow)(49)

                dscWindow.appid = dscWindow.gamebank(gamerow)(0)
                dscWindow.gameloaded = dscWindow.gamebank(gamerow)(7)
                dscWindow.manifests = dscWindow.gamebank(gamerow)(11)
                dscWindow.depotcache = dscWindow.gamebank(gamerow)(12)
                dscWindow.format = dscWindow.gamebank(gamerow)(1)
                dscWindow.gameisplus = dscWindow.gamebank(gamerow)(13)

                dscWindow.commonfolder = dscWindow.gamebank(gamerow)(8)
                If dscWindow.gamebank(gamerow)(1) = "acf" Then
                    dscWindow.steamappsdata = dscWindow.gamebank(gamerow)(2)
                End If
                If dscWindow.format = "acf" Then
                    'If File.Exists(dscWindow.setpath & "\steamapps\appmanifest_" & dscWindow.appid & ".acf") And dscWindow.InstallButton.Text = "Download" Then

                    'End If
                End If
                If dscWindow.format = "ncf" Then
                    Dim filestocheck As String() = Split(dscWindow.manifests, ",")
                    Dim manifestfound = 0
                    For Each filetocheck As String In filestocheck
                        'If File.Exists(dscWindow.setpath & "\steamapps\" & filetocheck) And dscWindow.InstallButton.Text = "Download" Then
                        '    manifestfound = 1
                        'End If
                    Next
                    If manifestfound = 1 Then

                    End If
                End If
                Dim freeworker = -1
                For worker = 0 To (UBound(bw) - 1)
                    Try
                        If bw(worker).IsBusy = True Then
                            bw(worker).CancelAsync()
                        Else
                            freeworker = worker
                            Exit For
                        End If
                    Catch ex As Exception
                        freeworker = worker
                        Exit For
                    End Try
                Next
                If freeworker = -1 Then
                    ReDim bw(UBound(bw) + 1)
                    bw(UBound(bw)) = New BackgroundWorker
                    bw(UBound(bw)).WorkerReportsProgress = True
                    bw(UBound(bw)).WorkerSupportsCancellation = True
                    AddHandler bw(UBound(bw)).DoWork, AddressOf dscWindow.dlcUpdater_DoWork
                    bw(UBound(bw)).RunWorkerAsync(UBound(bw))
                Else
                    bw(freeworker) = New BackgroundWorker
                    bw(freeworker).WorkerReportsProgress = True
                    bw(freeworker).WorkerSupportsCancellation = True
                    AddHandler bw(freeworker).DoWork, AddressOf dscWindow.dlcUpdater_DoWork
                    bw(freeworker).RunWorkerAsync(freeworker)
                End If

                Exit For
            End If
        Next
    End Sub

End Module
