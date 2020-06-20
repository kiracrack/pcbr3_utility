Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.Threading
Public Class frmDatabaseUpdater

    Private Sub frmBackuptool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        clientserver = ""
        clientuser = ""
        clientpass = ""
        clientdatabase = ""
        connclient.Close()
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
        If connclient.State <> 0 Then
            XtraMessageBox.Show("Database connection successfully connected!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If XtraMessageBox.Show("Are you sure execute query mother fucker? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If connclient.State = 0 Then
                XtraMessageBox.Show("Connection not connected! Please enter server to execute query!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtServerhost.Focus()
                Exit Sub
            End If
            Try
                com.CommandText = txtQuery.Text : com.ExecuteNonQuery()
                XtraMessageBox.Show("Query successfully excute! Database updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch errMYSQL As MySqlException
                XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                                 & "Message:" & errMYSQL.Message & vbCrLf, _
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PrintError()

            Catch errMS As Exception
                XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                                 & "Message:" & errMS.Message & vbCrLf, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PrintError()
            End Try
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

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If connclient.State = 0 Then
            XtraMessageBox.Show("Connection not connected! Please enter server to execute query!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServerhost.Focus()
            Exit Sub
        End If
        frmDatabaseConvert.ShowDialog()
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        frmdbUpdater.ShowDialog()
    End Sub
End Class