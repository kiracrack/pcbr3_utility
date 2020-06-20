Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class frmAccountStmt

    Private Sub frmAccountStmt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        loadClient()
    End Sub
    Public Sub loadClient()
        LoadXgridLookupSearch("SELECT distinct(custcode), fullname as 'Fullname', " _
                         + " Address FROM tbldelinquentlist where accstatus=1 order by " _
                         + " fullname asc", "tbldelinquentlist", txtClient, gridclient, Me)
        gridclient.Columns("custcode").Visible = False
    End Sub
    Private Sub txtClient_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClient.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtClient.Properties.View.FocusedRowHandle.ToString)
        custcode.Text = txtClient.Properties.View.GetFocusedRowCellValue("custcode").ToString()
        txtClient.Text = txtClient.Properties.View.GetFocusedRowCellValue("Fullname").ToString()
        txtaddress.Text = txtClient.Properties.View.GetFocusedRowCellValue("Address").ToString()
    End Sub

    Public Sub filter()
        LoadXgrid("SELECT refcode as 'Reference No.', " _
                        + " (select prodname from master.loanprod where prodcode=tbldelinquentlist.prodcode) as 'Product', Status, asofdate as 'As of Date', grandtotal as 'Grand Total'  " _
                        + " FROM tbldelinquentlist where custcode = '" & custcode.Text & "' and accstatus=1" _
                        + " order by asofdate asc;", "tbldelinquentlist", Em, gridview1, Me)
        gridview1.Columns("Reference No.").Width = 80
        gridview1.Columns("Grand Total").Width = 100
        XgridColCurrency("Grand Total", gridview1)

        XgridColAlign("Reference No.", gridview1, DevExpress.Utils.HorzAlignment.Center)

        gridview1.Columns("Product").SummaryItem.SummaryType = SummaryItemType.Count
        gridview1.Columns("Product").SummaryItem.DisplayFormat = " Total Account(s) {0:N0}"
        gridview1.Columns("Product").SummaryItem.Tag = 1
        CType(gridview1.Columns("Product").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Grand Total").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Grand Total").SummaryItem.DisplayFormat = "{0:n} Php"
        gridview1.Columns("Grand Total").SummaryItem.Tag = 1
        CType(gridview1.Columns("Grand Total").View, GridView).OptionsView.ShowFooter = True
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        filter()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        PrintPreview()
    End Sub
    Public Sub PrintPreview()
        Dim report As New rptAccountStmt()
        report.txtrefno.Text = custcode.Text
        report.txtclientname.Text = txtClient.Text
        report.txtaddress.Text = txtaddress.Text


        JetMatrixGrid(gridview1)
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
        gridview1.PaintStyleName = "Default"
    End Sub
    Public Sub JetMatrixGrid(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
            xgrid.PaintStyleName = "Web"
            xgrid.Appearance.FooterPanel.BackColor = Color.White
            xgrid.Appearance.FooterPanel.BackColor2 = Color.White

            xgrid.Appearance.GroupFooter.BackColor = Color.White
            xgrid.Appearance.GroupFooter.BackColor2 = Color.White

            xgrid.Appearance.FooterPanel.BorderColor = Color.LightGray
    End Sub

    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
        gridview1.DeleteSelectedRows()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        filter()
    End Sub
End Class