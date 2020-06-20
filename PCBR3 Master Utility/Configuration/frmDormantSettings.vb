Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class frmDormantSettings
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadSavingAccount()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            For Each i As Object In ls.CheckedItems
                Dim getDepcode As String = qrysingledata("depcode", "depcode", "where concat('(',depcode,') - ',lcase(description)) = '" & i.ToString & "'", "master.depositprod ")
                If countqry("`pcbr3`.`tbldormantsettings`", "depcode='" & getDepcode & "'") > 0 Then
                    com.CommandText = "delete from pcbr3.tbldormantsettings where depcode='" & getDepcode & "'" : com.ExecuteNonQuery()
                End If
                com.CommandText = "INSERT into pcbr3.tbldormantsettings set depcode='" & getDepcode & "', term='" & txtTerm.Text & "'" : com.ExecuteNonQuery()
            Next
            LoadSavingAccount()
            LoadDormantSettings()
            MsgBox("Successfully Saved!", MsgBoxStyle.Information)
        End If
    End Sub


    Public Sub LoadSavingAccount()
        ls.Items.Clear()
        com.CommandText = "select * from master.depositprod where depcode like '%" & txtSearch.Text & "%' or description like '%" & txtSearch.Text & "%' order by description asc" : rst = com.ExecuteReader
        While rst.Read
            ls.Items.Add("(" & rst("depcode").ToString & ") - " & LCase(rst("description").ToString))
        End While
        rst.Close()
    End Sub

    Public Sub LoadDormantSettings()
        dst = New DataSet
        msda = New MySqlDataAdapter("select '' as No, depcode as 'Code', (select description from master.depositprod where depcode = tbldormantsettings.depcode) as 'Deposit Product',Term from pcbr3.tbldormantsettings order by (select description from master.depositprod where depcode = tbldormantsettings.depcode) asc ", conn)
        MyDataGridView.DataSource = Nothing
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        'MyDataGridView.Columns("Details").Width = 300
        'MyDataGridView.Columns("id").Visible = False
        GridColumnAlignment(MyDataGridView, {"Code", "Term", "No"}, DataGridViewContentAlignment.MiddleCenter)

        For i = 0 To MyDataGridView.RowCount - 1
            Me.MyDataGridView.Rows(i).Cells(0).Value = i + 1
        Next
    End Sub

    Private Sub ls_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ls.SelectedIndexChanged, ls.ItemCheck
        If ls.CheckedItems.Count - 1 > 0 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        For i = 0 To ls.Items.Count - 1
            If CheckBox1.Checked = True Then
                ls.SetItemCheckState(i, CheckState.Checked)
                Button1.Enabled = True
            Else
                ls.SetItemCheckState(i, CheckState.Unchecked)
                Button1.Enabled = False
            End If
        Next
        If ls.CheckedItems.Count - 1 > 0 Then
            Button1.Text = "Save Settings (Selected " & ls.CheckedItems.Count & ")"
        Else
            Button1.Text = "Save Settings"
        End If
    End Sub

    Private Sub frmUnblockClearLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSavingAccount()
        LoadDormantSettings()
    End Sub

    Private Sub ViewTransactionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTransactionDetailsToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to continue? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
            For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
                com.CommandText = "delete from pcbr3.tbldormantsettings where depcode='" & rw.Cells("Code").Value.ToString & "'" : com.ExecuteNonQuery()
            Next
            LoadDormantSettings()
        End If
    End Sub

   
End Class
