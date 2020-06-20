Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports DevExpress.XtraEditors
Public Class frmConnectionSetup
    Private Sub frmConnectionSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub frmBackuptool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        clientserver = ""
        clientuser = ""
        clientpass = ""
        clientdatabase = ""
        connclient.Close()
    End Sub
    Private Sub cmdlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogin.Click
        If txtConnectionName.Text = "Connection Name" Or txtConnectionName.Text = "" Then
            MessageBox.Show("Please enter Connection Name!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtConnectionName.Focus()
            Exit Sub
        ElseIf txtServerhost.Text = "" Then
            MessageBox.Show("Please enter Server host!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServerhost.Focus()
            Exit Sub
        ElseIf txtPort.Text = "" Then
            MessageBox.Show("Please enter Server port!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPort.Focus()
            Exit Sub
        ElseIf txtusername.Text = "" Then
            MessageBox.Show("Please enter username!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtusername.Focus()
            Exit Sub
        ElseIf txtpassword.Text = "" Then
            MessageBox.Show("Please enter password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpassword.Focus()
            Exit Sub
        End If
        clientserver = txtServerhost.Text
        clientport = txtPort.Text
        clientuser = txtusername.Text
        clientpass = txtpassword.Text
        OpenClientServer()
        If connclient.State <> 0 Then
            Try
                If (Not System.IO.Directory.Exists(file_conn_dir)) Then
                    System.IO.Directory.CreateDirectory(file_conn_dir)
                End If
                Dim detailsFile As StreamWriter = Nothing
                If ckDefault.Checked = True Then
                    If System.IO.File.Exists(file_conn) = True Then
                        System.IO.File.Delete(file_conn)
                    End If
                    detailsFile = New StreamWriter(file_conn, True)
                    detailsFile.WriteLine(EncryptTripleDES(txtConnectionName.Text & "," & txtServerhost.Text & "," & txtPort.Text & "," & txtusername.Text & "," & txtpassword.Text))
                    detailsFile.Close()
                End If

                If System.IO.File.Exists(file_conn_dir & "\" & txtConnectionName.Text) = True Then
                    System.IO.File.Delete(file_conn_dir & "\" & txtConnectionName.Text)
                End If
                detailsFile = Nothing
                detailsFile = New StreamWriter(file_conn_dir & "\" & txtConnectionName.Text, True)
                detailsFile.WriteLine(EncryptTripleDES(txtConnectionName.Text & "," & txtServerhost.Text & "," & txtPort.Text & "," & txtusername.Text & "," & txtpassword.Text))
                detailsFile.Close()
                MessageBox.Show("Connection Successfully Added", "PCBR3", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch errMYSQL As MySqlException
                MessageBox.Show("Message:" & errMYSQL.Message, vbCrLf _
                                & "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch errMS As Exception
                MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

   
End Class