Imports DevExpress.XtraEditors

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
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmReportTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        LoadXgrid("SELECT rptid,rptname as 'Report Template' from tblreporttemplate order by rptname asc", "tblreporttemplate", Em, gridview1, Me)
        gridview1.Columns("rptid").Visible = False
    End Sub

End Class