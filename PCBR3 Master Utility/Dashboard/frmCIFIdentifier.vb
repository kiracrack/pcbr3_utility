Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Net
Imports DevExpress.LookAndFeel
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.XtraMessageBoxForm


Public Class frmCIFIdentifier

    Private Sub frmCIFIdentifier_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If System.IO.File.Exists(Application.StartupPath & "\cif") = True Then
            System.IO.File.Delete(Application.StartupPath & "\cif")
        End If
        Dim strChecked As String = ""
        For n = 0 To ls.CheckedItems.Count - 1
            strChecked = strChecked + ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString + ","
        Next

        If strChecked <> "" Then
            strChecked = strChecked.Remove(strChecked.Length - 1, 1)
        End If

        Dim detailsFile As StreamWriter = Nothing
        detailsFile = New StreamWriter(Application.StartupPath.ToString & "\cif", True)
        detailsFile.WriteLine(strChecked)
        detailsFile.Close()
    End Sub

    Private Sub frmCIFIdentifier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilterFields()

        Dim sr As StreamReader = File.OpenText(Application.StartupPath.ToString & "\cif")
        Dim br As String = sr.ReadLine() : sr.Close()
        For Each word In br.Split(New Char() {","c})
            ls.Items.Item(Trim(word)).CheckState = CheckState.Checked
        Next
    End Sub
    Public Sub FilterFields()
        Dim combogrid As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        com.CommandText = "show fields from master.client"
        rst = com.ExecuteReader
        ls.Items.Clear()
        While rst.Read
            ls.Items.Add(rst("Field"), False)
            ls.Items.Item(rst("Field")).Description = rst("Field").ToString
            ls.Items.Item(rst("Field")).Value = rst("Field").ToString
        End While
        rst.Close()
    End Sub
End Class