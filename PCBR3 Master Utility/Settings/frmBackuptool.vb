Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.Threading
Public Class frmBackuptool
   
    Private Sub frmBackuptool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clientserver = ""
        clientuser = ""
        clientpass = ""
        clientdatabase = ""
        connclient.Close()
    End Sub
    Public Sub FilterDatabase()
        OpenClientServer()
        Dim combogrid As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        comclient.CommandText = "show databases;"
        rstclient = comclient.ExecuteReader
        ls.Items.Clear()
        While rstclient.Read
            ls.Items.Add(rstclient("Database"), False)
            ls.Items.Item(rstclient("Database")).Description = rstclient("Database").ToString
            ls.Items.Item(rstclient("Database")).Value = rstclient("Database").ToString
        End While
        rstclient.Close()

    End Sub

    Private Sub cmdlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogin.Click
        If CheckEdit1.Checked = True Then
            clientserver = "10.1.0.100"
            clientuser = "sysad"
            clientpass = "12sysad10134"
        Else
            clientserver = txtServerhost.Text
            clientuser = txtusername.Text
            clientpass = txtpassword.Text
        End If
        clientdatabase = "mysql"
        OpenClientServer()
        If connclient.State = 0 Then Exit Sub
        FilterDatabase()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim strChecked As String = ""
        Dim strdbname As String = ""
        If ls.CheckedItems.Count = 0 Then
            XtraMessageBox.Show("Please select database to be backup!", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        For n = 0 To ls.CheckedItems.Count - 1
            strChecked = strChecked + ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString + " "
            strdbname = strdbname + ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString + ","
        Next
        strdbname = strdbname.Remove(strdbname.Length - 1, 1)
        If XtraMessageBox.Show("Are you sure continue backup data? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            Dim MyInput As String
            MyInput = InputBox("Please enter filename or modify default.", Me.Text, strdbname & " - " & GlobalDateTime.ToString.Replace(":", "") & ".sql")

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
            Dim fbd As New System.Windows.Forms.FolderBrowserDialog
            Dim selectedFolder As String
            If fbd.ShowDialog() = DialogResult.OK Then
                selectedFolder = fbd.SelectedPath + "\" + MyInput
                Try

                    processStartInfo.Arguments = "/C mysqldump --opt --host " & clientserver & " --password=" & clientpass & " --user=" & clientuser & " --database " & strChecked & " -r """ & selectedFolder & """"
                    processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                    processStartInfo.UseShellExecute = True
                    process = System.Diagnostics.Process.Start(processStartInfo)
                    'System.Threading.Thread.Sleep()
                    process.WaitForExit()
                    If process.HasExited Then
                        XtraMessageBox.Show("Query successfully excute! Database updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Catch errMS As Exception
                    XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
 _
                                 & "Message:" & errMS.Message & vbCrLf _
                                 & "Details:" & errMS.StackTrace, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If


        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            txtServerhost.Enabled = False
            txtusername.Enabled = False
            txtpassword.Enabled = False
        Else
            txtServerhost.Enabled = True
            txtusername.Enabled = True
            txtpassword.Enabled = True
        End If
    End Sub
End Class