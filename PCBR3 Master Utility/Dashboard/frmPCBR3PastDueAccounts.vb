Imports MySql.Data.MySqlClient
Imports DevExpress.Skins
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Public Class frmPCBR3PastDueAccounts

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Control) + (Keys.W) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Public Sub filter()
        '+ " (select concat(UCASE(res_street),' ',UCASE(res_city),' ',UCASE(res_province)) from master.client where custcode = tbldelinquentlist.custcode) as 'Address', " _
        LoadXgrid("SELECT loanwithterm.refno,loanwithterm.custcode,loanwithterm.loanprod, " _
                     + " concat(loanwithterm.refno, '-', loanwithterm.custcode) as 'Reference No.', " _
                     + " (select concat(ucase(lname),', ', ucase(fname),' ', ucase(mname)) from master.client where custcode = master.loanwithterm.custcode) as 'Client Fullname', " _
                     + " (select concat(IF(res_street IS NULL or res_street = '','',concat(ucase(res_street),', ')), ucase(res_city),', ', ucase(res_province)) from master.client where custcode = master.loanwithterm.custcode) as 'Address', " _
                     + " (select concat(IF(telno IS NULL or telno = '0' or telno = '','',concat(ucase(telno),', ')), IF(cellno IS NULL or cellno ='0' or cellno = '','', ucase(cellno))) from master.client where custcode = master.loanwithterm.custcode) as 'Contact Number', " _
                     + " (select prodname from master.loanprod where prodcode = loanwithterm.loanprod) as 'Product', " _
                     + " (select groupname from master.g_group where groupkey = loanwithterm.groupkey) as `Group`, " _
                     + " (select centername from master.g_center where centerkey = loanwithterm.centerkey) as 'Center', " _
                     + " (select areaname from master.g_area inner join master.g_center on g_area.areakey = g_center.areakey where g_center.centerkey = loanwithterm.centerkey) as 'Area', " _
                     + " date_format(loanwithterm.Loandate,'%Y-%m-%d') as 'Loandate',date_format(loanwithterm.Maturity,'%m-%d-%Y') as 'Maturity', " _
                     + " loanwithterm.Principal, loanwithterm.pribal as 'Principal Balance', " _
                     + " intdue as 'Interest Due', " _
                     + " pendue as 'Penalty Due', " _
                     + " loanwithterm.daysdelayed  as 'Days Delayed', " _
                     + " numbinst as 'No. Installment', " _
                     + " numbpaidinst as 'Paid Installment', " _
                     + " ifnull((select concat(username, ' ', '(',userid,')') from master.userinfo inner join master.g_center on g_center.accountofficer = userinfo.userid where  g_center.centerkey= loanwithterm.centerkey), 'NO OFFICER INCHARGE') as 'Account Officer', " _
                     + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch'  " _
                     + "   FROM master.loanwithterm where loanwithterm.cancelled=0  and loanwithterm.pribal = 1", "loanwithterm", Em, gridview1, Me)
        If gridview1.RowCount <> 0 Then
            gridview1.Columns("custcode").Visible = False
            gridview1.Columns("refno").Visible = False
            gridview1.Columns("loanprod").Visible = False
            gridview1.BestFitColumns()

            gridview1.Columns("Reference No.").Fixed = Columns.FixedStyle.Left
            gridview1.Columns("Client Fullname").Fixed = Columns.FixedStyle.Left
            gridview1.Columns("Product").Fixed = Columns.FixedStyle.Left

            gridview1.Columns("Principal").Width = 90
            gridview1.Columns("Principal Balance").Width = 90
            
            gridview1.Columns("Client Fullname").Width = 200
            gridview1.Columns("Client Fullname").ColumnEdit = MemoEdit
            'XgridColCurrency("Int Balance", gridview1)

            XgridColCurrency("Principal", gridview1)
            XgridColCurrency("Principal Balance", gridview1)
            

            XgridColCurrency("Interest Due", gridview1)
            gridview1.Columns("Interest Due").Width = 90

            XgridColCurrency("Penalty Due", gridview1)
            gridview1.Columns("Penalty Due").Width = 90
 
            XgridColAlign("Reference No.", gridview1, DevExpress.Utils.HorzAlignment.Center)
            XgridColAlign("Loandate", gridview1, DevExpress.Utils.HorzAlignment.Center)
            XgridColAlign("Maturity", gridview1, DevExpress.Utils.HorzAlignment.Center)
 

            XgridColAlign("No. Installment", gridview1, DevExpress.Utils.HorzAlignment.Center)
            XgridColAlign("Paid Installment", gridview1, DevExpress.Utils.HorzAlignment.Center)

            Dim item As New GridGroupSummaryItem()
            item.FieldName = "Account Officer"
            item.SummaryType = DevExpress.Data.SummaryItemType.Count


            Dim item1 As New GridGroupSummaryItem()
            item1.FieldName = "Principal"
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item1.DisplayFormat = "{0:n}"
            item1.ShowInGroupColumnFooter = gridview1.Columns("Principal")
            gridview1.GroupSummary.Add(item1)

            Dim item2 As New GridGroupSummaryItem()
            item2.FieldName = "Principal Balance"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0:n}"
            item2.ShowInGroupColumnFooter = gridview1.Columns("Principal Balance")
            gridview1.GroupSummary.Add(item2)

            Dim item5 As New GridGroupSummaryItem()
            item5.FieldName = "Interest Due"
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item5.DisplayFormat = "{0:n}"
            item5.ShowInGroupColumnFooter = gridview1.Columns("Interest Due")
            gridview1.GroupSummary.Add(item5)

            Dim item6 As New GridGroupSummaryItem()
            item6.FieldName = "Penalty Due"
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item6.DisplayFormat = "{0:n}"
            item6.ShowInGroupColumnFooter = gridview1.Columns("Penalty Due")
            gridview1.GroupSummary.Add(item6)

            gridview1.Columns("Client Fullname").SummaryItem.SummaryType = SummaryItemType.Count
            gridview1.Columns("Client Fullname").SummaryItem.DisplayFormat = " Total Client(s) {0:N0}"
            gridview1.Columns("Client Fullname").SummaryItem.Tag = 1
            CType(gridview1.Columns("Client Fullname").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Principal").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Principal").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Principal").SummaryItem.Tag = 1
            CType(gridview1.Columns("Principal").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Principal Balance").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Principal Balance").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Principal Balance").SummaryItem.Tag = 1
            CType(gridview1.Columns("Principal Balance").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Interest Due").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Interest Due").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Interest Due").SummaryItem.Tag = 1
            CType(gridview1.Columns("Interest Due").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Penalty Due").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Penalty Due").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Penalty Due").SummaryItem.Tag = 1
            CType(gridview1.Columns("Penalty Due").View, GridView).OptionsView.ShowFooter = True



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
            frmDelinquentAccountInfo.txtLoanDate.Text = gridview1.GetFocusedRowCellValue("Loandate").ToString
            frmDelinquentAccountInfo.custcode.Text = gridview1.GetFocusedRowCellValue("custcode").ToString
            frmDelinquentAccountInfo.loanref.Text = gridview1.GetFocusedRowCellValue("refno").ToString
            frmDelinquentAccountInfo.refcode.Text = gridview1.GetFocusedRowCellValue("Reference No.").ToString
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