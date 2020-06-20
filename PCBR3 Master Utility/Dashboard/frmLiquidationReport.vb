Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid

Public Class frmLiquidationReport
    Private Sub frmPaymentHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim datequery As Date = qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar")
        txtDateCutof.EditValue = Format(datequery, "MMMM d, yyyy")

        txtDateFrom.Text = Format(datequery)
        txtDateFrom.Properties.MaxValue = Format(datequery)

        txtDateTo.Text = Format(datequery)
        txtDateTo.Properties.MaxValue = Format(datequery)
        radGroup.SelectedIndex = 0
        LoadProductGroup()
    End Sub
    Private Sub radGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles radGroup.SelectedIndexChanged
        LoadProductGroup()
    End Sub
    Public Sub LoadProductGroup()
        Dim combogrid As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        If radGroup.EditValue = "pg" Then
            com.CommandText = "select * from pcbr3.tblproductgroup"
            rst = com.ExecuteReader
            ls.Items.Clear()
            While rst.Read
                ls.Items.Add(rst("groupname"), False)
                ls.Items.Item(rst("groupname")).Description = rst("groupname").ToString
                ls.Items.Item(rst("groupname")).Value = rst("productid").ToString
            End While
            rst.Close()
        Else
            com.CommandText = "select * from master.client_group"
            rst = com.ExecuteReader
            ls.Items.Clear()
            While rst.Read
                ls.Items.Add(UCase(rst("group_name").ToString), False)
                ls.Items.Item(UCase(rst("group_name").ToString)).Description = UCase(rst("group_name").ToString)
                ls.Items.Item(UCase(rst("group_name").ToString)).Value = rst("group_id").ToString
            End While
            rst.Close()
        End If
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        If txtReportTemplate.Text = "" Then
            XtraMessageBox.Show("Please Select Report Template!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReportTemplate.Focus()
            Exit Sub
        ElseIf txtDateFrom.Text = "" Then
            XtraMessageBox.Show("Please Select date from!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDateFrom.Focus()
            Exit Sub
        ElseIf txtDateTo.Text = "" Then
            XtraMessageBox.Show("Please Select date to!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDateTo.Focus()
            Exit Sub
        ElseIf txtFilterBy.Text = "" Then
            XtraMessageBox.Show("Please Select filter by!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilterBy.Focus()
            Exit Sub
        ElseIf Val(txtAmountTo.Text) <= 0 Then
            XtraMessageBox.Show("Please enter proper loan range!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTo.Focus()
            Exit Sub
        ElseIf ls.CheckedItems.Count = 0 Then
            XtraMessageBox.Show("Please check atlease one group!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim ProductQuery As String = ""
        If radGroup.EditValue = "pg" Then
            For n = 0 To ls.CheckedItems.Count - 1
                For Each word In ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString.Split(New Char() {"|"c})
                    ProductQuery = ProductQuery + "loanprod='" + word + "' or "
                Next
            Next
        Else
            For n = 0 To ls.CheckedItems.Count - 1
                For Each word In ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString.Split(New Char() {"|"c})
                    ProductQuery = ProductQuery + "client_group.group_id='" + word + "' or "
                Next
            Next
        End If
       
        Dim CompleteQuery As String = "pribal > 1 and cancelled=0 and (principal between " & CC(txtAmountFrom.Text) & " and " & CC(txtAmountTo.Text) & ") and (" & txtFilterBy.Text & " between '" & txtDateFrom.Text & "' and '" & txtDateTo.Text & "') and (" & ProductQuery.Remove(ProductQuery.Count - 3, 3) & ") order by (select concat(ucase(lname), ', ', ucase(fname), if(mname='','',concat(' ',ucase(mname)))) from master.client where custcode = master.loanwithterm.custcode) asc "
        If txtReportTemplate.Text = "Development Bank of the Philippines" Then
            If RadReportType.EditValue = "rd" Then
                GenerateDBPReportDetails(CompleteQuery)
            Else
                XtraMessageBox.Show("Report not Available!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf txtReportTemplate.Text = "Land Bank of the Philippines" Then
            If RadReportType.EditValue = "rd" Then
                GenerateLBPReportDetails(CompleteQuery)
            Else
                XtraMessageBox.Show("Report not Available!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf txtReportTemplate.Text = "Bank of the Philippine Island" Then
            If RadReportType.EditValue = "rd" Then
                GenerateBPIReportDetails(CompleteQuery)
            Else
                XtraMessageBox.Show("Report not Available!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf txtReportTemplate.Text = "Small Business Corporation" Then
            If RadReportType.EditValue = "rd" Then
                GenerateSBCReportDetails(CompleteQuery)
            Else
                XtraMessageBox.Show("Report not Available!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf txtReportTemplate.Text = "United Coco Planters Bank" Then
            If RadReportType.EditValue = "rd" Then
                GenerateUCPBReportDetails(CompleteQuery)
            Else
                XtraMessageBox.Show("Report not Available!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf txtReportTemplate.Text = "National Livelyhood Development Corporation" Then
            If RadReportType.EditValue = "rd" Then
                GenerateNLDCReportDetails(CompleteQuery)
            Else
                XtraMessageBox.Show("Report not Available!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If


    End Sub

#Region "Development Bank of the Philippines"
    Public Sub GenerateDBPReportDetails(ByVal query As String)
        LoadXgrid("select (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch'," _
                      + " (select concat(ucase(lname), ', ', ucase(fname), if(mname='','',concat(' ',ucase(mname)))) from master.client where custcode = master.loanwithterm.custcode) as 'Sub-borrower', " _
                      + " refno as 'PN Number', " _
                      + " principal as 'Amount', " _
                      + " maturity as 'Due Date', " _
                      + " datediff(maturity, (select trndate from master.syscalendar where forsystem=1) ) as 'Rem. Term', " _
                      + " round((datediff(maturity, (select trndate from master.syscalendar where forsystem=1))*pribal)/(select sum(pribal) from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                      + " inner join master.client_group on client.group_id =  client_group.group_id where pribal>0 and cancelled=0 and group_name = 'deped' and date_format(loandate,'%Y-%m')='{to_year}-{to_month}'),0) as 'Ave. Term', " _
                      + " pribal as 'OPB', " _
                      + " group_name as 'Industry Sector', " _
                      + " 'none' as 'BMBE Registered', " _
                      + " 'PN' as 'Type of Collateral', " _
                      + " '' as 'Employement Startup', " _
                      + " 1 as 'Existing', " _
                      + " 'none' as 'Additional', " _
                      + " loandate as 'Date of PN/Date of Doc.', " _
                      + " 'micro' as 'Asset Size Before Financing', " _
                      + " '' as 'No. of Availment', " _
                      + " 'trading' as 'Livelihood Activity', " _
                      + " res_province as 'Region/Province' " _
                      + " from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                      + " inner join master.client_group on client.group_id =  client_group.group_id where " & query & ";", "master.loanwithterm", Em, gridview1, Me)

        XGridColumnCurrency(gridview1, {"Amount", "OPB"})
        XGridColumnAlignment(gridview1, {"PN Number", "Due Date", "Rem. Term", "Ave. Term", "Industry Sector", "BMBE Registered", "Type of Collateral", "Existing", "Additional", "Date of PN/Date of Doc.", "Asset Size Before Financing", "Livelihood Activity"}, DevExpress.Utils.HorzAlignment.Center)
        XGridColumnFooterSummaryCurrency(gridview1, {"Amount", "OPB"}, SummaryItemType.Sum)
        XGridColumnGroupSummaryCurrency(gridview1, {"Amount", "OPB"}, SummaryItemType.Sum)

        XGridColumnFooterSummaryNumber(gridview1, {"Sub-borrower"}, SummaryItemType.Count)
        XGridColumnGroupSummaryNumber(gridview1, {"Sub-borrower"}, SummaryItemType.Count)

        If ckGroupBranch.Checked = True Then
            gridview1.Columns("Branch").Group()
        End If

    End Sub
#End Region

#Region "Land Bank Philippines"
    Public Sub GenerateLBPReportDetails(ByVal query As String)
        LoadXgrid("select (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch'," _
                      + " (select concat(ucase(lname), ', ', ucase(fname), if(mname='','',concat(' ',ucase(mname)))) from master.client where custcode = master.loanwithterm.custcode) as 'Name of Borrower', " _
                      + " refno as 'PN Number', " _
                      + " concat(if(res_street='','',ucase(res_street)), ', ',if(res_city='','',ucase(res_city)), ', ',if(res_province='','',ucase(res_province))) as 'Address', " _
                      + " birthdate as 'Birth Date', " _
                      + " occupation as 'Main Source of Income', " _
                      + " principal as 'Amount Released', " _
                      + " loandate as 'Date Released', " _
                      + " maturity as 'Due Date', " _
                      + " pribal as 'O/S Balance', " _
                      + " '' as 'Purpose' " _
                      + " from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                      + " inner join master.client_group on client.group_id =  client_group.group_id where " & query, "master.loanwithterm", Em, gridview1, Me)

        XGridColumnCurrency(gridview1, {"Amount Released", "O/S Balance"})
        XGridColumnAlignment(gridview1, {"Birth Date", "Date Released", "Due Date", "PN Number"}, DevExpress.Utils.HorzAlignment.Center)
        XGridColumnFooterSummaryCurrency(gridview1, {"Amount Released", "O/S Balance"}, SummaryItemType.Sum)
        XGridColumnGroupSummaryCurrency(gridview1, {"Amount Released", "O/S Balance"}, SummaryItemType.Sum)

        If ckGroupBranch.Checked = True Then
            gridview1.Columns("Branch").Group()
        End If

    End Sub
#End Region

#Region "Bank of the Philippine Island"
    Public Sub GenerateBPIReportDetails(ByVal query As String)
        LoadXgrid("select (select concat(ucase(lname), ', ', ucase(fname), if(mname='','',concat(' ',ucase(mname)))) from master.client where custcode = master.loanwithterm.custcode) as 'Name of Borrower', " _
                      + " refno as 'PN #', " _
                      + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch'," _
                      + " loandate as 'Date Release', " _
                      + " maturity as 'Mat. Date', " _
                      + " principal as 'Loan Amount', " _
                      + " pribal as 'O/S Balance' " _
                      + " from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                      + " inner join master.client_group on client.group_id =  client_group.group_id where " & query, "master.loanwithterm", Em, gridview1, Me)

        XGridColumnCurrency(gridview1, {"Loan Amount", "O/S Balance"})
        XGridColumnAlignment(gridview1, {"PN #", "Birth Date", "Date Release", "Mat. Date"}, DevExpress.Utils.HorzAlignment.Center)
        XGridColumnFooterSummaryCurrency(gridview1, {"Loan Amount", "O/S Balance"}, SummaryItemType.Sum)
        XGridColumnGroupSummaryCurrency(gridview1, {"Loan Amount", "O/S Balance"}, SummaryItemType.Sum)

        If ckGroupBranch.Checked = True Then
            gridview1.Columns("Branch").Group()
        End If

    End Sub
#End Region

#Region "Small Business Corporation"
    Public Sub GenerateSBCReportDetails(ByVal query As String)
        LoadXgrid("select (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch'," _
                      + " ucase(lname) as 'Last Name'," _
                      + " ucase(fname) as 'First Name'," _
                      + " ucase(LEFT(mname , 1)) as 'MI', " _
                      + " case when sex=0 then 'Male' else 'Female' end as 'Gender', " _
                      + " date_format(birthdate, '%M %d, %Y') as 'Date of Birth', " _
                      + " res_street as 'Barangay'," _
                      + " res_city as 'Municipality', " _
                      + " res_province as 'Province', " _
                      + " 'Retail, Trading & Services' as 'Industry the Business Belongs To', " _
                      + " case when sex=0 then 'Farmers' else 'Women' end as 'Sector Represented', " _
                      + " 'Trading' as 'Type of Business Activity', " _
                      + " 'Existing Business' as 'Business Track Record', " _
                      + " 'NO' as 'BMBE Registered', " _
                      + " 2 as 'No. of workers (excluding self & family members)', " _
                      + " refno as 'Sub Borrowers PN', " _
                      + " principal as 'Loan Amount', " _
                      + " (select count(*) from master.loanwithterm where custcode = client.custcode) as 'Loan Cycle', " _
                      + " loandate as 'Release Date', " _
                      + " maturity as 'Maturity Date', " _
                      + " 'Current' as 'Loan Status', " _
                      + " '" & txtAmountFrom.Text & " - " & txtAmountTo.Text & "' as 'Asset Sized' " _
                      + " from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                      + " inner join master.client_group on client.group_id =  client_group.group_id where " & query, "master.loanwithterm", Em, gridview1, Me)

        XGridColumnCurrency(gridview1, {"Loan Amount"})
        XGridColumnAlignment(gridview1, {"MI", "Gender", "Barangay", "Municipality", "Province", "Sector Represented", "Type of Business Activity", "Business Track Record", "BMBE Registered", "No. of workers (excluding self & family members)", "Sub Borrowers PN", "Loan Cycle", "Release Date", "Maturity Date", "Loan Status"}, DevExpress.Utils.HorzAlignment.Center)
        XGridColumnFooterSummaryCurrency(gridview1, {"Loan Amount"}, SummaryItemType.Sum)
        XGridColumnGroupSummaryCurrency(gridview1, {"Loan Amount"}, SummaryItemType.Sum)

        If ckGroupBranch.Checked = True Then
            gridview1.Columns("Branch").Group()
        End If

    End Sub
#End Region

#Region "United Coco Planters Bank"
    Public Sub GenerateUCPBReportDetails(ByVal query As String)
        LoadXgrid("select (select concat(ucase(lname), ', ', ucase(fname), if(mname='','',concat(' ',ucase(mname)))) from master.client where custcode = master.loanwithterm.custcode) as 'Name of Borrower', " _
                      + " refno as 'PN Number', " _
                      + "  (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch'," _
                      + " principal as 'Amount Release', " _
                      + " loandate as 'Date Release', " _
                      + " maturity as 'Maturity Date', " _
                      + " 'Personal' as 'Loan Purpose', " _
                      + " 'Unsecured' as 'Colateral' " _
                      + " from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                      + " inner join master.client_group on client.group_id = client_group.group_id where " & query & ";", "master.loanwithterm", Em, gridview1, Me)

        XGridColumnCurrency(gridview1, {"Amount Release"})
        XGridColumnAlignment(gridview1, {"PN Number", "Date Release", "Maturity Date", "Loan Purpose", "Colateral"}, DevExpress.Utils.HorzAlignment.Center)
        XGridColumnFooterSummaryCurrency(gridview1, {"Amount Release"}, SummaryItemType.Sum)
        XGridColumnGroupSummaryCurrency(gridview1, {"Amount Release"}, SummaryItemType.Sum)

        If ckGroupBranch.Checked = True Then
            gridview1.Columns("Branch").Group()
        End If

    End Sub
#End Region

#Region "National Livelyhood Development Corporation"
    Public Sub GenerateNLDCReportDetails(ByVal query As String)
        LoadXgrid("select (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch', " _
                            + " (select concat(ucase(lname), ', ', ucase(fname)) from master.client where custcode = master.loanwithterm.custcode) as 'Sub-borrower', " _
                            + " (select if(mname='','',concat(' ',ucase(left(mname,1)))) from master.client where custcode = master.loanwithterm.custcode) as 'M-Name', " _
                            + " refno as 'PN Number', " _
                            + " (select res_street from master.client where custcode = master.loanwithterm.custcode) as 'Brgy.', " _
                            + " (select res_city from master.client where custcode = master.loanwithterm.custcode) as 'Mun.', " _
                            + " (select res_province from master.client where custcode = master.loanwithterm.custcode) as 'Prov.', " _
                            + " principal as 'Amount of Loan', " _
                            + " loandate as 'Date Released', " _
                            + " maturity as 'Maturity Date', " _
                            + " amortcode as 'Mode of Payment', " _
                            + " (principal-pribal) as 'Total Collection' ," _
                            + " ((principal/termindays) * datediff((select trndate from master.syscalendar where forsystem=1),loandate)) as 'Total Amount Due', " _
                            + " pribal as 'Outstanding Balance', " _
                            + " (select sum(currbalance) from master.depositaccounts where signatory1 = loanwithterm.custcode) as 'CBU', " _
                            + " 'current' as 'Status of Account', " _
                            + " 'good' as 'Remarks' " _
                            + " from master.loanwithterm inner join master.client on loanwithterm.custcode = client.custcode " _
                            + " inner join master.client_group on client.group_id =  client_group.group_id where " & query & ";", "master.loanwithterm", Em, gridview1, Me)

        XGridColumnCurrency(gridview1, {"Amount of Loan", "Total Collection", "Total Amount Due", "Outstanding Balance", "CBU"})
        XGridColumnAlignment(gridview1, {"M-Name", "PN Number", "Brgy.", "Mun.", "Prov.", "Date Released", "Maturity Date", "Mode of Payment", "Status of Account", "Remarks"}, DevExpress.Utils.HorzAlignment.Center)
        XGridColumnFooterSummaryCurrency(gridview1, {"Amount of Loan", "Total Collection", "Total Amount Due", "Outstanding Balance", "CBU"}, SummaryItemType.Sum)
        XGridColumnGroupSummaryCurrency(gridview1, {"Amount of Loan", "Total Collection", "Total Amount Due", "Outstanding Balance", "CBU"}, SummaryItemType.Sum)

        If ckGroupBranch.Checked = True Then
            gridview1.Columns("Branch").Group()
        End If

    End Sub
#End Region

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        printreport()
    End Sub
    Public Sub printreport()
        ' com.CommandText = "update tblreportsetting set title='" & txttitle.Text & "', customtext='" & txtCustom.Text & "' where formname='" & Me.Name.ToString & "' " : com.ExecuteNonQuery()
        Dim report As New rptOtherReport()
        report.Landscape = True
        report.PaperKind = System.Drawing.Printing.PaperKind.A2
        report.txttitle.Text = txtReportTemplate.Text
        report.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)

        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub
End Class