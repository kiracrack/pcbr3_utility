Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.Threading
Public Class frmDatabaseConvert
    Private inputstr As String = "master"
    Private Sub frmBackuptool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CheckEdit1.Checked = True Then
            FilterTables()
        Else
            FilterDatabase()
        End If

    End Sub
    Public Sub FilterTables()
        OpenClientServer()
        Dim combogrid As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        comclient.CommandText = "show tables from " & inputstr & ";"
        rstclient = comclient.ExecuteReader
        ls.Items.Clear()
        While rstclient.Read
            ls.Items.Add(rstclient("Tables_in_" & inputstr), False)
            ls.Items.Item(rstclient("Tables_in_" & inputstr)).Description = rstclient("Tables_in_" & inputstr).ToString
            ls.Items.Item(rstclient("Tables_in_" & inputstr)).Value = rstclient("Tables_in_" & inputstr).ToString
        End While
        rstclient.Close()
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
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim strChecked As String = ""
        Dim strdbname As String = ""
        If ls.CheckedItems.Count = 0 Then
            XtraMessageBox.Show("Please select tables selected!", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        For n = 0 To ls.CheckedItems.Count - 1
            Dim StrQuery1 As String = ""
            Dim StrQuery2 As String = ""
            

            Dim combogrid As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            comclient.CommandText = "show tables from " & inputstr
            rstclient = comclient.ExecuteReader
            While rstclient.Read
                Dim dbase As String = rstclient("Tables_in_" & inputstr)
                StrQuery1 = StrQuery1 & "ALTER TABLE `" & inputstr & "`.`" & ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString & "` DEFAULT COLLATE utf8_general_ci;" & Environment.NewLine
                StrQuery2 = StrQuery2 & "ALTER TABLE `" & inputstr & "`.`" & ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString & "` CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci;" & Environment.NewLine
            End While
            rstclient.Close()
            ' MsgBox(StrQuery1 & StrQuery2)
            comclient.CommandText = StrQuery1 : comclient.ExecuteNonQuery()
            comclient.CommandText = StrQuery2 : comclient.ExecuteNonQuery()
        Next
        XtraMessageBox.Show("Humana!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



    Private Sub CheckEdit2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit2.CheckedChanged
        For n = 0 To ls.ItemCount - 1
            If CheckEdit2.Checked = True Then
                ls.Items.Item(n).CheckState = CheckState.Checked
            Else
                ls.Items.Item(n).CheckState = CheckState.Unchecked
            End If
        Next
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If ls.CheckedItemsCount = 0 Then
            XtraMessageBox.Show("No item selected!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    
        Dim detail As String = ""
        Dim MyInput As String = ""
        Dim detailsFile As StreamWriter = Nothing

        If ls.CheckedItems.Count = 0 Then
            XtraMessageBox.Show("Please select item to continue process", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        saveFileDialog1.FileName = GlobalDateTime.ToString.Replace(":", "") & ".txt"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True


        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            If System.IO.File.Exists(saveFileDialog1.FileName) = True Then
                System.IO.File.Delete(saveFileDialog1.FileName)
            End If
            detailsFile = New StreamWriter(saveFileDialog1.FileName, True)


            Dim cnt As Integer = 0
            For n = 0 To ls.CheckedItems.Count - 1
                cnt = 0
                comclient.CommandText = "show fields from " & inputstr & "." & ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString : rstclient = comclient.ExecuteReader
                While rstclient.Read
                    cnt = cnt + 1
                End While
                rstclient.Close()
                detail = detail & ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString & " - Total Fields " & cnt & Chr(13)
                ' End If
            Next
            detailsFile.WriteLine(detail)
            detailsFile.Close()
            XtraMessageBox.Show("Data successfully exported", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        '  If InputBox("Set database name..", "Database Name", inputstr, vbOK) = 1 Then
        inputstr = InputBox("Set database name..", "Database Name", inputstr, vbOK)
        FilterDatabase()
        'End If

    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            FilterTables()
        Else
            FilterDatabase()
        End If
    End Sub
End Class