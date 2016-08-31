Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            If e.CommandLine(0).StartsWith("dsc://install/") Then
                Dim appidtodown = e.CommandLine(0).Replace("dsc://install/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
            ElseIf e.CommandLine(0).StartsWith("dsc://manifests/") Then
                dscWindow.manonly = 1
                Dim appidtodown = e.CommandLine(0).Replace("dsc://manifests/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.manonly = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://run/") Then
                dscWindow.apptorun = 1
                Dim appidtodown = e.CommandLine(0).Replace("dsc://run/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.apptorun = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://run2/") Then
                dscWindow.apptorun = 2
                Dim appidtodown = e.CommandLine(0).Replace("dsc://run2/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.apptorun = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://run3/") Then
                dscWindow.apptorun = 3
                Dim appidtodown = e.CommandLine(0).Replace("dsc://run3/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.apptorun = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://run4/") Then
                dscWindow.apptorun = 4
                Dim appidtodown = e.CommandLine(0).Replace("dsc://run4/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.apptorun = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://run5/") Then
                dscWindow.apptorun = 5
                Dim appidtodown = e.CommandLine(0).Replace("dsc://run5/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.apptorun = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://crack/") Then
                dscWindow.downcrack = 1
                Dim appidtodown = e.CommandLine(0).Replace("dsc://crack/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downcrack = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://crack2/") Then
                dscWindow.downcrack = 2
                Dim appidtodown = e.CommandLine(0).Replace("dsc://crack2/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downcrack = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://crack3/") Then
                dscWindow.downcrack = 3
                Dim appidtodown = e.CommandLine(0).Replace("dsc://crack3/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downcrack = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://crack4/") Then
                dscWindow.downcrack = 4
                Dim appidtodown = e.CommandLine(0).Replace("dsc://crack4/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downcrack = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://crack5/") Then
                dscWindow.downcrack = 5
                Dim appidtodown = e.CommandLine(0).Replace("dsc://crack5/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downcrack = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://addon/") Then
                dscWindow.downaddon = 1
                Dim appidtodown = e.CommandLine(0).Replace("dsc://addon/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downaddon = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://addon2/") Then
                dscWindow.downaddon = 2
                Dim appidtodown = e.CommandLine(0).Replace("dsc://addon2/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downaddon = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://addon3/") Then
                dscWindow.downaddon = 3
                Dim appidtodown = e.CommandLine(0).Replace("dsc://addon3/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downaddon = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://addon4/") Then
                dscWindow.downaddon = 4
                Dim appidtodown = e.CommandLine(0).Replace("dsc://addon4/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downaddon = 0
            ElseIf e.CommandLine(0).StartsWith("dsc://addon5/") Then
                dscWindow.downaddon = 5
                Dim appidtodown = e.CommandLine(0).Replace("dsc://addon5/", "")
                dscWindow.appidtodown = appidtodown.Replace("/", "")
                batchdownloadstarter(False)
                dscWindow.downaddon = 0
            Else
                'do nothing
            End If
        End Sub
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

        End Sub
    End Class


End Namespace

