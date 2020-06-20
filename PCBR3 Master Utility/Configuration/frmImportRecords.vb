Imports System.IO
Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient

Public Class frmImportRecords
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmEditedEntries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        startAsyncButton.Text = "Confirm Update " & (txtsqlQuery.Lines.Count - 1) & " Total Queries Found"
        startAsyncButton.Enabled = True
    End Sub
    Private Sub startAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startAsyncButton.Click
        If XtraMessageBox.Show("Are you sure you want to continue? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = txtsqlQuery.Lines.Count - 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0
            For Each strLine As String In txtsqlQuery.Text.Split(vbLf)
                If strLine <> "" Then
                    com.CommandText = strLine : com.ExecuteNonQuery()
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                End If
            Next
            ''   If txtsqlQuery.Lines(I) <> "" Then
            'com.CommandText = txtsqlQuery.Lines(I) : com.ExecuteNonQuery()
            'ProgressBarControl1.PerformStep()
            'ProgressBarControl1.Update()
            '' End If
            'Next
            txtsqlQuery.Text = ""
            startAsyncButton.Enabled = False
            startAsyncButton.Text = "Confirm Update"
            ProgressBarControl1.Position = 0
            XtraMessageBox.Show("Records Successfully Updated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class