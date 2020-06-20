Imports System.IO
Imports DevExpress.XtraEditors

Public Class frmConsolidatedCapture
    Public Sub LoadOffice()

        LoadXgridLookupSearch("SELECT branchcode as 'Code', ucase(branchname) as 'Select List' from master.branches where ho = 0 order by branchname asc", "master.branches", txtOffice, GridOffice, Me)
        XgridColAlign("Code", GridOffice, DevExpress.Utils.HorzAlignment.Center)
        GridOffice.Columns("Code").Visible = False

    End Sub
    Private Sub txtoffice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOffice.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtOffice.Properties.View.FocusedRowHandle.ToString)
        officecode.Text = txtOffice.Properties.View.GetFocusedRowCellValue("Code").ToString()
        txtOffice.Text = txtOffice.Properties.View.GetFocusedRowCellValue("Select List").ToString()
    End Sub

    Private Sub frmConsoCapture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadOffice()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        'Declare a OpenFileDialog object
        Dim objOpenFileDialog As New OpenFileDialog
        'Set the Open dialog properties
        With objOpenFileDialog
            .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
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
                txtpath.Text = objOpenFileDialog.FileName
            Catch fileException As Exception
                Throw fileException
            End Try

        End If

        'Clean up
        objOpenFileDialog.Dispose()
        objOpenFileDialog = Nothing
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtpath.Text = "" Then
            XtraMessageBox.Show("Please select file!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpath.Focus()
            Exit Sub
        ElseIf txtOffice.Text = "" Then
            XtraMessageBox.Show("Please select office!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOffice.Focus()
            Exit Sub
        End If
        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.PercentView = True
        ProgressBarControl1.Properties.Maximum = countrecord("tblconsolitem")
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Position = 0
        Dim sr As StreamReader = File.OpenText(txtpath.Text)
        Dim input As String
        input = sr.ReadLine()
        Dim str As String = ""
        While Not input Is Nothing

            Dim c As Integer = 0
            Dim words As String() = input.Split(New Char() {","c})
            Dim word As String
            Dim batchcode As String = ""
            Dim itemcode As String = ""
            Dim total As Double = 0
            Dim datetrn As String = ""
            For Each word In words
                If c = 0 Then
                    batchcode = word
                ElseIf c = 1 Then
                    itemcode = word
                ElseIf c = 2 Then
                    total = word
                ElseIf c = 3 Then
                    datetrn = word
                End If
                c = c + 1
            Next
            If input <> "" Then
                com.CommandText = "delete from tblconsolidated where batchcode='" & ConvertDate(batchcode) & "' and  officecode='" & officecode.Text & "' and particularcode='" & itemcode & "'" : com.ExecuteNonQuery()
                com.CommandText = "insert into tblconsolidated set batchcode='" & batchcode & "', officecode='" & officecode.Text & "'," _
                                                        + " particularcode='" & itemcode & "', " _
                                                        + " total='" & total & "', " _
                                                        + " datebatch='" & ConvertDate(datetrn) & "', " _
                                                        + " trnby='" & globaluserid & "'" : com.ExecuteNonQuery()
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            End If
            input = sr.ReadLine()
        End While
        sr.Close()
        XtraMessageBox.Show("Voters successfully Loaded to database!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class