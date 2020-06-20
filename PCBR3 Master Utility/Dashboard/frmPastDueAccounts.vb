Imports MySql.Data.MySqlClient
Imports DevExpress.Skins
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.XtraEditors

Public Class frmPastDueAccounts

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Control) + (Keys.W) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Public Sub filter()
        '+ " (select concat(UCASE(res_street),' ',UCASE(res_city),' ',UCASE(res_province)) from master.client where custcode = tbldelinquentlist.custcode) as 'Address', " _
        LoadXgrid("SELECT id, refcode as 'Reference No.', " _
                        + " fullname as 'Client Fullname', " _
                        + " (select prodname from master.loanprod where prodcode=tbldelinquentlist.prodcode) as 'Product', grandtotal as 'Grand Total',  " _
                        + " date_format(asofdate, '%M %d, %Y') as 'As of Date', Status , datediff(asofdate,current_date) as 'Remaining Day(s)', Notes, " _
                        + " (select fullname from tblaccounts where accountid = tbldelinquentlist.trnby)  as 'Tagged by', datetrn as 'Date Tagged'" _
                        + " FROM tbldelinquentlist where status = 'PAST DUE'  and accstatus=1" _
                        + " order by asofdate asc;", "tbldelinquentlist", Em, gridview1, Me)
        gridview1.Columns("id").Visible = False
        gridview1.Columns("Reference No.").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        gridview1.Columns("Client Fullname").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        gridview1.Columns("Client Fullname").Width = 250
        gridview1.Columns("Grand Total").Width = 120
        'gridview1.Columns("Address").Width = 250
        gridview1.Columns("Notes").Width = 250
        'gridview1.Columns("Address").ColumnEdit = MemoEdit
        gridview1.Columns("Notes").ColumnEdit = MemoEdit
        XgridColCurrency("Grand Total", gridview1)

        XgridColAlign("Reference No.", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("Status", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("Remaining Day(s)", gridview1, DevExpress.Utils.HorzAlignment.Center)

        gridview1.Columns("Client Fullname").SummaryItem.SummaryType = SummaryItemType.Count
        gridview1.Columns("Client Fullname").SummaryItem.DisplayFormat = " Total Loan Account(s) {0:N0}"
        gridview1.Columns("Client Fullname").SummaryItem.Tag = 1
        CType(gridview1.Columns("Client Fullname").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Grand Total").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Grand Total").SummaryItem.DisplayFormat = "{0:n} Php"
        gridview1.Columns("Grand Total").SummaryItem.Tag = 1
        CType(gridview1.Columns("Grand Total").View, GridView).OptionsView.ShowFooter = True
    End Sub

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles gridview1.RowCellStyle
        If CheckEdit1.Checked = True Then
            Dim View As GridView = sender
            Dim days As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Remaining Day(s)"))
            ' If e.Column.FieldName = "Remaining Day(s)" Then
            If Val(days) > 1 And Val(days) < 7 Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.ForeColor = Color.Black
            ElseIf Val(days) = 0 Then
                e.Appearance.BackColor = Color.Gold
                e.Appearance.ForeColor = Color.Black
            ElseIf Val(days) < 0 Then
               e.Appearance.ForeColor = Color.Red
            End If
            'End If
        End If

    End Sub
    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SkinManager.EnableMdiFormSkins()
        reportcount(Me.Name.ToString)
        txttitle.Text = reportTitle(Me.Name.ToString)
        txtCustom.Text = reportcustomtext(Me.Name.ToString)
        Me.Text = txttitle.Text


        rptsettings = ""
        ViewGridtype(gridview1)
        filter()
    End Sub

    Public Sub printreport()
        com.CommandText = "update tblreportsetting set title='" & txttitle.Text & "', customtext='" & txtCustom.Text & "' where formname='" & Me.Name.ToString & "' " : com.ExecuteNonQuery()
        Dim report As New rptOtherReport()
        report.Landscape = rdoreintation.EditValue.ToString
        report.PaperKind = System.Drawing.Printing.PaperKind.Legal
        report.txttitle.Text = txttitle.Text
         
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        printreport()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        rptsettings = ""
        filter()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClose.ItemClick
        Me.Close()
    End Sub

    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
        If CheckSelectedRow("Reference No.", gridview1) = True Then
            frmDelinquentAccountInfo.id.Text = gridview1.GetFocusedRowCellValue("id").ToString
            frmDelinquentAccountInfo.Show()
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        filter()
    End Sub

    Private Sub CloseAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAccountToolStripMenuItem.Click
        If CheckSelectedRow("Reference No.", gridview1) = True Then
            If XtraMessageBox.Show("Are you sure you want to close selected account? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                com.CommandText = "update tbldelinquentlist set accstatus=0 where id='" & gridview1.GetFocusedRowCellValue("id").ToString & "'" : com.ExecuteNonQuery()
                gridview1.DeleteSelectedRows()
            End If
        End If
    End Sub
End Class