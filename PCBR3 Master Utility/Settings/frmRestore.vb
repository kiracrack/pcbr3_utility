Imports DevExpress.XtraEditors

Public Class frmRestore

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If XtraMessageBox.Show("Are you sure you want to update PCBR3 Database?" & globaluser & "@" & globalfullname & " on " & globaldate & " - " & GlobalTime() & ") ?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim sqlpath As String = ""
            Dim objOpenFileDialog As New OpenFileDialog
            'Set the Open dialog properties
            With objOpenFileDialog
                .Filter = "Backup files sql (*.sql)|*.sql|All files (*.*)|*.*"
                .FilterIndex = 1
                .Title = "Open File Dialog"
            End With


            'Show the Open dialog and if the user clicks the Open button,
            'load the file
            If objOpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim allText As String
                Try
                    'Read the contents of the file
                    allText = My.Computer.FileSystem.GetParentPath(objOpenFileDialog.FileName)
                    'Display the file contents in the TextBox
                    sqlpath = objOpenFileDialog.FileName
                Catch fileException As Exception
                    Throw fileException
                End Try

            End If

            'Clean up
            objOpenFileDialog.Dispose()
            objOpenFileDialog = Nothing

            If sqlpath <> "" Then
                Dim process As System.Diagnostics.Process
                Dim processStartInfo As System.Diagnostics.ProcessStartInfo
                processStartInfo = New System.Diagnostics.ProcessStartInfo
                processStartInfo.FileName = "cmd.exe"
                'processStartInfo.Arguments = "mysqldump --opt --password=1234 --user=root --database monitoring -r D:\test.sql"
                If System.Environment.OSVersion.Version.Major >= 6 Then ' Windows Vista or higher
                    processStartInfo.Verb = "runas"
                Else
                    ' No need to prompt to run as admin
                End If

                processStartInfo.Arguments = "/C mysql -h " & sqlipaddress & " -u" & sqlusername & " -p" & sqlpassword & " < """ & sqlpath & """"
                processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                processStartInfo.UseShellExecute = True
                process = System.Diagnostics.Process.Start(processStartInfo)
                'System.Threading.Thread.Sleep()
                process.WaitForExit()
                If process.HasExited Then
                    XtraMessageBox.Show("Database successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
End Class