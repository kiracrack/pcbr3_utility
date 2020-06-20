Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.IO
Imports DevExpress.XtraReports.UI
Imports DevExpress.Data
Imports DevExpress.XtraGrid

Public Class frmCollectionRate
    Private begindate As Date = Format(Now, "MMMM d, yyyy")
    Private enddate As Date = Format(Now, "MMMM d, yyyy")
    Private Sub frmConsoladation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  txtasof.Text = Format(Now.ToShortDateString)
        txtfrmdate.Properties.MaxValue = qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar")
        txttodate.Properties.MaxValue = qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar")
        LoadOffice()
        txtfrmdate.EditValue = Now
        txttodate.EditValue = Now
    End Sub
    Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim bounds As Rectangle = e.Bounds
        Dim CellPadding As Integer = 15
        e.Appearance.FillRectangle(e.Cache, e.Bounds)
        bounds.X += CellPadding
        bounds.Width -= 2 * CellPadding
        'bounds.Y += CellPadding
        'bounds.Height -= 2 * CellPadding
        e.Cache.DrawString(e.DisplayText, e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), bounds, e.Appearance.GetStringFormat())
        e.Handled = True
    End Sub

    Public Sub CreateGrid()
        LoadXgrid("select '' as Branch,'' as Product, '' as Date, 0.00 as 'Expected Collection', 0.00 as 'Amount Collected','' as Client,  '' as 'Account Officer' from master.loanwithterm limit 0 ", "master.loanwithterm", Em, GridView1, Me)
    End Sub
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

    Public Sub filterPayment()
        CreateGrid()
        Dim years As String = ""
        Dim newdate As String = ""

        Dim daycount As Integer = 0


        begindate = txtfrmdate.Text
        enddate = txttodate.Text
        Dim branchcode As String = ""
        If ckAll.Checked = True Then
            branchcode = ""
        Else
            branchcode = " and branchcode='" & officecode.Text & "'"
        End If

        Dim micro_only As String = ""
        If ckMicro.Checked = True Then
            micro_only = " and microfinance=1"
        Else
            micro_only = ""
        End If
        '  Try
        '02/15/2014

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.PercentView = True
        Me.Cursor = Cursors.WaitCursor
        daycount = DateDiff(DateInterval.Day, begindate, enddate)
        Dim ttlaccounts As Double = 0
        For I = 0 To daycount
            newdate = begindate.AddDays(I).ToString("MM/dd/yyyy")
            ttlaccounts = ttlaccounts + countqry("master.lnamortsked inner join master.loanwithterm on lnamortsked.refno = loanwithterm.refno  inner join master.loanprod on loanwithterm.loanprod = loanprod.prodcode ", "INSTR(amortsched, '" & newdate & "') > 0 " & branchcode & micro_only & ";")
        Next I

        ProgressBarControl1.Properties.Maximum = ttlaccounts
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Position = 0

        For I = 0 To daycount
            newdate = begindate.AddDays(I).ToString("MM/dd/yyyy")
            dst = New DataSet
            msda = New MySqlDataAdapter("select * from master.lnamortsked inner join master.loanwithterm on lnamortsked.refno = loanwithterm.refno  inner join master.loanprod on loanwithterm.loanprod = loanprod.prodcode  where INSTR(amortsched, '" & newdate & "') > 0 " & branchcode & micro_only & ";", conn)
            msda.Fill(dst, 0)
            For cnt = 0 To dst.Tables(0).Rows.Count - 1
                With (dst.Tables(0))
                    Dim loanRefNumber As String = ""
                    Dim clientNAme As String = ""
                    Dim AmortAmount As String = "0"
                    Dim payment As String = "0"
                    Dim branch As String = ""
                    Dim product As String = ""
                    Dim AccountOfficer As String = ""

                    Dim DateFound As Boolean = False

                    'SEARCH AMORTIZATION SCHEDULE
                    For Each word In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                        Dim subcnt As Integer = 0
                        For Each subword In word.Split(New Char() {":"c})
                            If subcnt = 0 Then
                                If subword = newdate Then
                                    DateFound = True
                                Else
                                    DateFound = False
                                End If
                            ElseIf subcnt = 1 Then
                                If DateFound = True Then
                                    loanRefNumber = .Rows(cnt)("refno").ToString()
                                    AmortAmount = subword
                                End If
                            End If
                            subcnt = subcnt + 1
                        Next
                    Next
                    'MsgBox("Loan Ref: " & loanRefNumber & Chr(13) & "Amortization Amount: " & FormatNumber(AmortAmount, 2) & Chr(13) & "Date Amortization: " & newdate)


                    'GET ACCOUNT DETAILS
                    com.CommandText = "SELECT loanwithterm.refno, " _
                      + " (select concat(ucase(lname),', ', ucase(fname),' ', ucase(mname)) from master.client where custcode = master.loanwithterm.custcode) as 'client', " _
                      + " ifnull((select concat(username, ' ', '(',userid,')') from master.userinfo inner join master.g_center on g_center.accountofficer = userinfo.userid where  g_center.centerkey= loanwithterm.centerkey), 'NO OFFICER INCHARGE') as 'ao', " _
                      + " (select prodname from master.loanprod where prodcode = loanwithterm.loanprod) as 'product', " _
                      + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'branch' " _
                      + " FROM master.loanwithterm where refno='" & loanRefNumber & "' and loanwithterm.cancelled=0" : rst = com.ExecuteReader
                    While rst.Read
                        clientNAme = rst("client").ToString()
                        AccountOfficer = rst("ao").ToString()
                        product = rst("product").ToString()
                        branch = rst("branch").ToString()
                    End While
                    rst.Close()

                    'GET Amount CollectedS
                    years = "db" & CDate(newdate).ToString("yyyyMM")
                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & loanRefNumber & "' and pmntdate = '" & ConvertDate(newdate) & "'" : rst = com.ExecuteReader()
                    While rst.Read
                        payment = rst("principal").ToString()
                    End While
                    rst.Close()

                    If branch <> "" Then
                        AddRowXgrid(GridView1)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Branch", branch)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Product", product)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Client", clientNAme)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Date", newdate)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Expected Collection", AmortAmount)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount Collected", payment)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account Officer", AccountOfficer)
                    End If
                End With
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
        Next
        GridView1.Columns("Branch").Group()
        GridView1.ExpandAllGroups()


        Dim item1 As New GridGroupSummaryItem()
        item1.FieldName = "Expected Collection"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "{0:n}"
        item1.ShowInGroupColumnFooter = GridView1.Columns("Expected Collection")
        GridView1.GroupSummary.Add(item1)

        Dim item2 As New GridGroupSummaryItem()
        item2.FieldName = "Amount Collected"
        item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item2.DisplayFormat = "{0:n}"
        item2.ShowInGroupColumnFooter = GridView1.Columns("Amount Collected")
        GridView1.GroupSummary.Add(item2)

        Dim item5 As New GridGroupSummaryItem()
        item5.FieldName = "Client"
        item5.Tag = 0
        item5.DisplayFormat = "Collection Rate {0}"
        item5.SummaryType = DevExpress.Data.SummaryItemType.Custom
        item5.ShowInGroupColumnFooter = GridView1.Columns("Client")
        GridView1.GroupSummary.Add(item5)

        XgridColCurrency("Expected Collection", GridView1)
        XgridColCurrency("Amount Collected", GridView1)

        XgridColAlign("Expected Collection", GridView1, HorzAlignment.Far)
        XgridColAlign("Amount Collected", GridView1, HorzAlignment.Far)

        GridView1.Columns("Expected Collection").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("Expected Collection").SummaryItem.DisplayFormat = "{0:n}"
        GridView1.Columns("Expected Collection").SummaryItem.Tag = 1
        CType(GridView1.Columns("Expected Collection").View, GridView).OptionsView.ShowFooter = True



        GridView1.Columns("Amount Collected").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("Amount Collected").SummaryItem.DisplayFormat = "{0:n}"
        GridView1.Columns("Amount Collected").SummaryItem.Tag = 1
        CType(GridView1.Columns("Amount Collected").View, GridView).OptionsView.ShowFooter = True

        Dim total As String = Format((Val(CC(GridView1.Columns("Amount Collected").SummaryText)) / Val(CC(GridView1.Columns("Expected Collection").SummaryText))) * 100, "0.00")
        GridView1.Columns("Client").SummaryItem.SummaryType = SummaryItemType.Custom
        GridView1.Columns("Client").SummaryItem.DisplayFormat = "Total Collection Rate " & total & "%"
        GridView1.Columns("Client").SummaryItem.Tag = 1
        CType(GridView1.Columns("Client").View, GridView).OptionsView.ShowFooter = True
        GridView1.BestFitColumns()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub filterPaymentSummary()
        CreateGrid()
        Dim years As String = ""
        Dim newdate As String = ""

        Dim daycount As Integer = 0


        begindate = txtfrmdate.Text
        enddate = txttodate.Text
        Dim branchcode As String = ""
        If ckAll.Checked = True Then
            branchcode = ""
        Else
            branchcode = " and branchcode='" & officecode.Text & "'"
        End If

        Dim micro_only As String = ""
        If ckMicro.Checked = True Then
            micro_only = " and microfinance=1"
        Else
            micro_only = ""
        End If

        Dim close_acct As String = ""
        If ckClose.Checked = True Then
            close_acct = " and pribal = 0 "
        End If
        '  Try
        '02/15/2014

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.PercentView = True
        Me.Cursor = Cursors.WaitCursor
        daycount = DateDiff(DateInterval.Day, begindate, enddate)
        Dim ttlaccounts As Double = 0
        For I = 0 To daycount
            newdate = begindate.AddDays(I).ToString("MM/dd/yyyy")
            ttlaccounts = ttlaccounts + countqry("master.lnamortsked inner join master.loanwithterm on lnamortsked.refno = loanwithterm.refno  inner join master.loanprod on loanwithterm.loanprod = loanprod.prodcode ", "INSTR(amortsched, '" & newdate & "') > 0 " & branchcode & micro_only & close_acct & ";")
        Next I

        ProgressBarControl1.Properties.Maximum = ttlaccounts
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Position = 0

        For I = 0 To daycount
            newdate = begindate.AddDays(I).ToString("MM/dd/yyyy")
            dst = New DataSet
            msda = New MySqlDataAdapter("select * from master.lnamortsked inner join master.loanwithterm on lnamortsked.refno = loanwithterm.refno  inner join master.loanprod on loanwithterm.loanprod = loanprod.prodcode  where INSTR(amortsched, '" & newdate & "') > 0 " & branchcode & micro_only & close_acct & ";", conn)
            msda.Fill(dst, 0)
            For cnt = 0 To dst.Tables(0).Rows.Count - 1
                With (dst.Tables(0))
                    Dim loanRefNumber As String = ""
                    Dim clientNAme As String = ""
                    Dim AmortAmount As String = "0"
                    Dim payment As String = "0"
                    Dim branch As String = ""
                    Dim product As String = ""
                    Dim AccountOfficer As String = ""

                    Dim DateFound As Boolean = False

                    'SEARCH AMORTIZATION SCHEDULE
                    For Each word In .Rows(cnt)("amortsched").ToString().Split(New Char() {"|"c})
                        Dim subcnt As Integer = 0
                        For Each subword In word.Split(New Char() {":"c})
                            If subcnt = 0 Then
                                If subword = newdate Then
                                    DateFound = True
                                Else
                                    DateFound = False
                                End If
                            ElseIf subcnt = 1 Then
                                If DateFound = True Then
                                    loanRefNumber = .Rows(cnt)("refno").ToString()
                                    AmortAmount = subword
                                End If
                            End If
                            subcnt = subcnt + 1
                        Next
                    Next
                    'MsgBox("Loan Ref: " & loanRefNumber & Chr(13) & "Amortization Amount: " & FormatNumber(AmortAmount, 2) & Chr(13) & "Date Amortization: " & newdate)


                    'GET ACCOUNT DETAILS
                    com.CommandText = "SELECT loanwithterm.refno, " _
                      + " (select concat(ucase(lname),', ', ucase(fname),' ', ucase(mname)) from master.client where custcode = master.loanwithterm.custcode) as 'client', " _
                      + " ifnull((select concat(username, ' ', '(',userid,')') from master.userinfo inner join master.g_center on g_center.accountofficer = userinfo.userid where  g_center.centerkey= loanwithterm.centerkey), 'NO OFFICER INCHARGE') as 'ao', " _
                      + " (select prodname from master.loanprod where prodcode = loanwithterm.loanprod) as 'product', " _
                      + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'branch' " _
                      + " FROM master.loanwithterm where refno='" & loanRefNumber & "' and loanwithterm.cancelled=0" : rst = com.ExecuteReader
                    While rst.Read
                        clientNAme = rst("client").ToString()
                        AccountOfficer = rst("ao").ToString()
                        product = rst("product").ToString()
                        branch = rst("branch").ToString()
                    End While
                    rst.Close()

                    'GET Amount CollectedS
                    years = "db" & CDate(newdate).ToString("yyyyMM")
                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & loanRefNumber & "' and pmntdate = '" & ConvertDate(newdate) & "'" : rst = com.ExecuteReader()
                    While rst.Read
                        payment = rst("principal").ToString()
                    End While
                    rst.Close()

                    If branch <> "" Then
                        AddRowXgrid(GridView1)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Branch", branch)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Product", product)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Client", clientNAme)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Date", newdate)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Expected Collection", AmortAmount)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount Collected", payment)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account Officer", AccountOfficer)
                    End If
                End With
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
        Next
        GridView1.Columns("Branch").Group()
        GridView1.ExpandAllGroups()


        Dim item1 As New GridGroupSummaryItem()
        item1.FieldName = "Expected Collection"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "{0:n}"
        item1.ShowInGroupColumnFooter = GridView1.Columns("Expected Collection")
        GridView1.GroupSummary.Add(item1)

        Dim item2 As New GridGroupSummaryItem()
        item2.FieldName = "Amount Collected"
        item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item2.DisplayFormat = "{0:n}"
        item2.ShowInGroupColumnFooter = GridView1.Columns("Amount Collected")
        GridView1.GroupSummary.Add(item2)

        Dim item5 As New GridGroupSummaryItem()
        item5.FieldName = "Client"
        item5.Tag = 0
        item5.DisplayFormat = "Collection Rate {0}"
        item5.SummaryType = DevExpress.Data.SummaryItemType.Custom
        item5.ShowInGroupColumnFooter = GridView1.Columns("Client")
        GridView1.GroupSummary.Add(item5)

        XgridColCurrency("Expected Collection", GridView1)
        XgridColCurrency("Amount Collected", GridView1)

        XgridColAlign("Expected Collection", GridView1, HorzAlignment.Far)
        XgridColAlign("Amount Collected", GridView1, HorzAlignment.Far)

        GridView1.Columns("Expected Collection").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("Expected Collection").SummaryItem.DisplayFormat = "{0:n}"
        GridView1.Columns("Expected Collection").SummaryItem.Tag = 1
        CType(GridView1.Columns("Expected Collection").View, GridView).OptionsView.ShowFooter = True



        GridView1.Columns("Amount Collected").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("Amount Collected").SummaryItem.DisplayFormat = "{0:n}"
        GridView1.Columns("Amount Collected").SummaryItem.Tag = 1
        CType(GridView1.Columns("Amount Collected").View, GridView).OptionsView.ShowFooter = True

        Dim total As String = Format((Val(CC(GridView1.Columns("Amount Collected").SummaryText)) / Val(CC(GridView1.Columns("Expected Collection").SummaryText))) * 100, "0.00")
        GridView1.Columns("Client").SummaryItem.SummaryType = SummaryItemType.Custom
        GridView1.Columns("Client").SummaryItem.DisplayFormat = "Total Collection Rate " & total & "%"
        GridView1.Columns("Client").SummaryItem.Tag = 1
        CType(GridView1.Columns("Client").View, GridView).OptionsView.ShowFooter = True
        GridView1.BestFitColumns()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim Value1 As Double = 0 : Dim Value2 As Double = 0
        Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, GridSummaryItem)).Tag)
        Dim View As GridView = TryCast(sender, GridView)

        If e.SummaryProcess = CustomSummaryProcess.Finalize Then
            Value1 = CDbl(GridView1.GetGroupSummaryValue(e.GroupRowHandle, TryCast(GridView1.GroupSummary(1), GridGroupSummaryItem)))
            Value2 = CDbl(GridView1.GetGroupSummaryValue(e.GroupRowHandle, TryCast(GridView1.GroupSummary(0), GridGroupSummaryItem)))
            e.TotalValue = FormatNumber((Value1 / Value2) * 100, 2) & "%"
        End If

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If txtOffice.Text = "" And ckAll.Checked = False Then
            XtraMessageBox.Show("Please select office!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOffice.Focus()
            Exit Sub
        End If
        If ckAll.Checked = True Then
            If XtraMessageBox.Show("Bigger data takes to much longer to query! Are you sure you want to continue?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                filterPayment()
            End If
        Else
            filterPayment()
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        'gridview1.ShowRibbonPrintPreview()
        printreport()
    End Sub
    Public Sub printreport()
        Dim report As New rptConsolidated()

        If ckAll.Checked = True Then
            report.txtbranch.Text = "ALL BRANCHES"
        Else
            report.txtbranch.Text = txtOffice.Text
        End If

        Dim asofdate As Date = txtfrmdate.Text
        Dim astodate As Date = txttodate.Text
        report.txtTitleReport.Text = "COLLECTION RATE REPORT"
        report.txtconsolidated.Text = ""
        report.txtconlasofdate.Text = "From " & Format(asofdate, "MMMM dd, yyyy") & " to " & Format(astodate, "MMMM dd, yyyy")


        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub ckAll_CheckedChanged(sender As Object, e As EventArgs) Handles ckAll.CheckedChanged
        If ckAll.Checked = True Then
            txtOffice.Properties.DataSource = Nothing
            txtOffice.Text = ""
            officecode.Text = ""
            txtOffice.Properties.ReadOnly = True
        Else
            txtOffice.Properties.ReadOnly = False
            LoadOffice()
        End If
    End Sub
End Class