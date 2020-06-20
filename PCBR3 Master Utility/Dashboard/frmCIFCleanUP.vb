Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmCIFCleanUP

    Private beginyear As Date = Format(Now, "MMMM d, yyyy")
    Private endyear As Date = Format(Now, "MMMM d, yyyy")

    Private columnValues As New List(Of String)()



    Private Sub frmPaymentCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        txtfrmdate.EditValue = Format(Now, "MMMM d, yyyy")
        txttodate.EditValue = Format(Now, "MMMM d, yyyy")


    End Sub

    Public Sub filterPayments()
        Dim datequery As String = "" : Dim datequerycnt As String = ""
        If CheckEdit1.Checked = True Then
            datequery = ""
            datequerycnt = ""
        Else
            datequery = "where recdate between '" & ConvertDate(txtfrmdate.Text) & "' and '" & ConvertDate(txttodate.Text) & "'"
            datequerycnt = "recdate between '" & ConvertDate(txtfrmdate.Text) & "' and '" & ConvertDate(txttodate.Text) & "'"
        End If

        Dim sr As StreamReader = File.OpenText(Application.StartupPath.ToString & "\cif")
        Dim br As String = sr.ReadLine() : sr.Close()
        Try
            If CheckEdit2.Checked = True Then
                Dim strqry As String = "" : Dim strfield As String = ""
                For Each word In br.Split(New Char() {","c})
                    strqry = strqry & "client." & word.Replace(" ", "") & " = dup." & word.Replace(" ", "") & " and "
                    strfield = strfield & "client." & word & ","
                Next
                If strqry <> "" Then
                    strqry = strqry.Remove(strqry.Length - 4, 4)
                    strfield = strfield.Remove(strfield.Length - 1, 1)
                End If
                'MsgBox(strqry)
                LoadXgrid("SELECT client.*,concat(" & strfield & ") as 'identifier',(select branchname from master.branches where branchcode = client.branchcode) as 'Branch' FROM master.client " _
                          + " INNER JOIN (SELECT * FROM master.client " _
                          + " GROUP BY " & strfield & " HAVING count(*) > 1) dup ON " & strqry & " order by " & strfield & " asc", "master.client", Em, gridview1, Me)
            Else
                LoadXgrid("select *,concat(" & br & ") as 'identifier',(select branchname from master.branches where branchcode = client.branchcode) as 'Branch' from master.client " & datequery & " order by lname,fname,mname", "master.client", Em, gridview1, Me)
                gridview1.Columns("identifier").Visible = False
            End If
          

            Dim table As DataTable = (TryCast(Em.DataSource, DataTable))
            Dim values = From myRow In table.AsEnumerable() Select myRow.Field(Of String)("identifier")
            columnValues = values.ToList()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        gridview1.MoveLast()
        ProgressBarControl1.PerformStep()
        ProgressBarControl1.Update()
        SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub gridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles gridview1.RowCellStyle
        On Error Resume Next
        If (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "identifier") = Nothing Then Exit Sub
        Dim val = (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "identifier")
        If val Is Nothing Then
            Return
        End If
        Dim svalue As String = val.ToString()
        If columnValues.Where(Function(s) s.Equals(svalue)).ToList().Count > 1 Then
            ' gridview1.SetRowCellValue(e.RowHandle, "duplicate", "1")
            ' TryCast(sender, GridView).SetRowCellValue(e.RowHandle, "duplicate", "1")
            e.Appearance.ForeColor = Color.Red
        End If
     
    End Sub

    Private Sub gridView2_RowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs)
        On Error Resume Next
        If (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "identifier") = Nothing Then Exit Sub

        Dim val = (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "identifier")
        If val Is Nothing Then
            Return
        End If
        Dim svalue As String = val.ToString()
        If columnValues.Where(Function(s) s.Equals(svalue)).ToList().Count > 1 Then
        Else
            gridview1.DeleteRow(e.RowHandle)
        End If

        'If e.Appearance.ForeColor = Color.Black Then
        '    gridview1.DeleteRow(e.RowHandle)
        'End If
    End Sub
    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        filterPayments()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim dir As String = ""
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog

        If fbd.ShowDialog() = DialogResult.OK Then
            dir = fbd.SelectedPath
            Me.Cursor = Cursors.WaitCursor
             
            Dim branches As String = qrysingledata("br", " group_concat(distinct (select branchname from master.branches where branchcode = master.client.branchcode)) as br", "", "master.client")
            For Each splBranch In branches.Split(New Char() {","c})
                Dim report As New rptplainReport()
                If Not Directory.Exists(dir & "\" & UCase(splBranch)) Then
                    Directory.CreateDirectory(dir & "\" & UCase(splBranch))
                End If

                gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "'"
                report.Landscape = True
                report.PaperKind = System.Drawing.Printing.PaperKind.A2
                report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
                report.ExportToXlsx(dir & "\" & UCase(splBranch) & "\cif-" & LCase(splBranch) & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(True, True, True))
            Next

            Me.Cursor = Cursors.Default
            XtraMessageBox.Show("CIF successfully generated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PaymentHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentHistoryToolStripMenuItem.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.FileName = "CIF.xlsx"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            gridview1.ExportToXlsx(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        frmCIFIdentifier.Show(Me)
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged

    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        AddHandler gridview1.RowStyle, AddressOf gridView2_RowStyle
        gridview1.Focus()
        ' RemoveHandler gridview1.RowStyle, AddressOf gridView2_RowStyle
    End Sub
End Class