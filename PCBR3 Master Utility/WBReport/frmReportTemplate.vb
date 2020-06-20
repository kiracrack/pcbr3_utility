Imports DevExpress.XtraEditors
Imports System.IO

Public Class frmReportTemplate
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            If CheckSelectedRow("Report Template", gridview1) = True Then
                If XtraMessageBox.Show("Are you sure you want to edit selected report? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    frmReportDeveloper.mode.Text = ""
                    frmReportDeveloper.id.Text = gridview1.GetFocusedRowCellValue("rptid").ToString
                    frmReportDeveloper.mode.Text = "edit"
                    frmReportDeveloper.txtReportTitle.Text = gridview1.GetFocusedRowCellValue("Report Template").ToString
                    Me.Close()
                End If
            End If
        ElseIf keyData = Keys.Escape Then
            Me.Close()
        ElseIf keyData = Keys.Control + Keys.Delete Then
            If CheckSelectedRow("Report Template", gridview1) = True Then
                If XtraMessageBox.Show("Are you sure you want to delete selected template? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    com.CommandText = "delete from tblreporttemplate where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
                    com.CommandText = "delete from tblreportconfig where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
                    filter()
                End If
            End If
        ElseIf keyData = Keys.Control + +Keys.Shift + Keys.C Then
            If XtraMessageBox.Show("Are you sure you want to duplicate selected template? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim newid As String = getReportTemplateID()
                com.CommandText = "insert into tblreporttemplate (rptid,rptname,rptquery,status,datequery,requestby) select '" & newid & "','" & gridview1.GetFocusedRowCellValue("Report Template").ToString & " - COPY',rptquery,status,datequery,requestby from tblreporttemplate where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
                com.CommandText = "insert into tblreportconfig (rptid,colname,coltype,colgroup,colgrpsum,colgrpsumtext,colgrpsumtype,colgensum,colgensumtext,colgensumtype,sortorder,alignment,status) " _
                        + " select '" & newid & "',colname,coltype,colgroup,colgrpsum,colgrpsumtext,colgrpsumtype,colgensum,colgensumtext,colgensumtype,sortorder,alignment,status from tblreportconfig where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
                filter()
            End If
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmReportTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        filter()
    End Sub
    Public Sub filter()
        LoadXgrid("SELECT rptid,rptname as 'Report Template' from tblreporttemplate order by rptname asc", "tblreporttemplate", Em, gridview1, Me)
        gridview1.Columns("rptid").Visible = False
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        filter()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If CheckSelectedRow("Report Template", gridview1) = True Then
            If XtraMessageBox.Show("Are you sure you want to edit selected report? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                frmReportDeveloper.mode.Text = ""
                frmReportDeveloper.id.Text = gridview1.GetFocusedRowCellValue("rptid").ToString
                frmReportDeveloper.mode.Text = "edit"
                frmReportDeveloper.txtReportTitle.Text = gridview1.GetFocusedRowCellValue("Report Template").ToString
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If CheckSelectedRow("Report Template", gridview1) = True Then
            If XtraMessageBox.Show("Are you sure you want to delete selected template? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                com.CommandText = "delete from tblreporttemplate where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
                com.CommandText = "delete from tblreportconfig where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
                filter()
            End If
        End If
    End Sub

    Private Sub ExportTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportTemplateToolStripMenuItem.Click
        Dim detailReportTitle As String = ""
        Dim detailReportDetails As String = ""
        Dim detailsFile As StreamWriter = Nothing

        If gridview1.RowCount = 0 Then
            XtraMessageBox.Show("Please generate transaction to continue process", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "Report File (*.rpt)|*.rpt|All files (*.*)|*.*"
        saveFileDialog1.FileName = LCase(gridview1.GetFocusedRowCellValue("Report Template").ToString) & " " & GlobalDateTime.ToString.Replace(":", "") & ".rpt"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True


        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            If System.IO.File.Exists(saveFileDialog1.FileName) = True Then
                System.IO.File.Delete(saveFileDialog1.FileName)
            End If
            detailsFile = New StreamWriter(saveFileDialog1.FileName, True)
            detailReportTitle = "delete from tblreporttemplate where rptid='" & gridview1.GetFocusedRowCellValue("rptid").ToString & "';" + Environment.NewLine
            com.CommandText = "select * from tblreporttemplate where rptid='" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : rst = com.ExecuteReader
            While rst.Read
                detailReportTitle += "insert into tblreporttemplate set rptid='" & rst("rptid").ToString & "', rptname='" & rchar(rst("rptname").ToString) & "', rptquery='" & rchar(rst("rptquery").ToString) & "', status='" & rst("status").ToString & "', datequery=" & rst("datequery") & ", usedateasof=" & rst("usedateasof") & ", requestby='" & rst("requestby").ToString & "';"
            End While
            rst.Close()

            detailReportDetails = "delete from tblreportconfig where rptid='" & gridview1.GetFocusedRowCellValue("rptid").ToString & "';" + Environment.NewLine
            com.CommandText = "select * from tblreportconfig where rptid='" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : rst = com.ExecuteReader
            While rst.Read
                detailReportDetails += "insert into tblreportconfig set rptid='" & rst("rptid").ToString & "', colname='" & rst("colname").ToString & "', coltype='" & rst("coltype").ToString & "', colgroup=" & rst("colgroup") & ", colgrpsum=" & rst("colgrpsum") & ", colgrpsumtext='" & rst("colgrpsumtext").ToString & "',colgrpsumtype='" & rst("colgrpsumtype").ToString & "', colgensum=" & rst("colgensum") & ", colgensumtext='" & rst("colgensumtext").ToString & "', colgensumtype='" & rst("colgensumtype").ToString & "', sortorder='" & rst("sortorder").ToString & "', alignment='" & rst("alignment").ToString & "', status='" & rst("status").ToString & "';"
            End While
            rst.Close()
            detailsFile.WriteLine(EncryptTripleDES(detailReportTitle + detailReportDetails + gridview1.GetFocusedRowCellValue("rptid").ToString))
            detailsFile.Close()
            XtraMessageBox.Show("Report successfully exported", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DuplicateTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateTemplateToolStripMenuItem.Click
        If XtraMessageBox.Show("Are you sure you want to duplicate selected template? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim newid As String = getReportTemplateID()
            com.CommandText = "insert into tblreporttemplate (rptid,rptname,rptquery,status,datequery,requestby) select '" & newid & "','" & gridview1.GetFocusedRowCellValue("Report Template").ToString & " - COPY',rptquery,status,datequery,requestby from tblreporttemplate where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
            com.CommandText = "insert into tblreportconfig (rptid,colname,coltype,colgroup,colgrpsum,colgrpsumtext,colgrpsumtype,colgensum,colgensumtext,colgensumtype,sortorder,alignment,status) " _
                    + " select '" & newid & "',colname,coltype,colgroup,colgrpsum,colgrpsumtext,colgrpsumtype,colgensum,colgensumtext,colgensumtype,sortorder,alignment,status from tblreportconfig where rptid = '" & gridview1.GetFocusedRowCellValue("rptid").ToString & "'" : com.ExecuteNonQuery()
            filter()
        End If
    End Sub
End Class