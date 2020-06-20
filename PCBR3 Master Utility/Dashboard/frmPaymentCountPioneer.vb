Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports DevExpress.XtraPrinting

Public Class frmPaymentCountPioneer

    Private beginyear As Date = Format(Now, "MMMM d, yyyy")
    Private endyear As Date = Format(Now, "MMMM d, yyyy")
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Control) + Keys.P Then
            BarButtonItem2.PerformClick()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmPaymentCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        txtfrmdate.EditValue = Format(Now, "MMMM d, yyyy")
        txttodate.EditValue = Format(Now, "MMMM d, yyyy")

    End Sub

    Public Sub filterPayments()
        Dim loandate As Date
        Dim years As String = ""
        Dim yearcount As Integer = 0
        Dim cntpayment As Double = 0
        Dim totalpayment As Double = 0
        Dim loanNumber As String = ""
        Dim currcustcode As String = ""
        Dim paymentbreakdown As String = ""
        Try
            SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Both
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = qrysingledata("cnt", "count(*) as cnt", "inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where microfinance = 1 and cancelled=0", "master.loanprod")
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0

            dst = New DataSet
            msda = New MySqlDataAdapter("select *,(select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'branch' from master.loanprod inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where microfinance = 1 and cancelled=0 order by custcode,loandate;", conn)
            msda.Fill(dst, 0)
            For cnt = 0 To dst.Tables(0).Rows.Count - 1
                With (dst.Tables(0))
                    If currcustcode <> .Rows(cnt)("custcode").ToString() Then
                        AddRowXgrid(gridview1)
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "custcode", .Rows(cnt)("custcode").ToString())

                        com.CommandText = "select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) as fullname from master.client where custcode = '" & .Rows(cnt)("custcode").ToString() & "'"
                        rst = com.ExecuteReader()
                        While rst.Read
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Client", rst("fullname").ToString())
                        End While
                        rst.Close()
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Branch", .Rows(cnt)("branch").ToString())
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Product", .Rows(cnt)("prodname").ToString())
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Date Membership", .Rows(cnt)("loandate").ToString())
                        cntpayment = 0
                        totalpayment = 0
                        paymentbreakdown = ""

                        beginyear = txtfrmdate.Text
                        endyear = txttodate.Text
                        yearcount = DateDiff(DateInterval.Month, beginyear, endyear)
                        For I = 0 To yearcount
                            Me.Cursor = Cursors.WaitCursor
                            years = "db" & beginyear.AddMonths(I).ToString("yyyyMM")
                            com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "' and amtpaid >=20 " : rst = com.ExecuteReader
                            While rst.Read
                                cntpayment = cntpayment + 1
                                'If beginyear.AddMonths(I).ToString("yyyyMM") < 201207 Then
                                '    totalpayment = totalpayment + 20
                                '    paymentbreakdown = paymentbreakdown + "20+"
                                'Else
                                '    totalpayment = totalpayment + 25
                                '    paymentbreakdown = paymentbreakdown + "25+"
                                'End If
                                totalpayment = totalpayment + Val(rst("chgpmnt1").ToString)
                                paymentbreakdown = paymentbreakdown + rst("chgpmnt1").ToString + "+"
                            End While
                            rst.Close()
                        Next I
                    Else ' BREAK IF THERE OTHER ACCOUNT
                        beginyear = txtfrmdate.Text
                        endyear = txttodate.Text
                        yearcount = DateDiff(DateInterval.Month, beginyear, endyear)
                        For I = 0 To yearcount
                            Me.Cursor = Cursors.WaitCursor
                            years = "db" & beginyear.AddMonths(I).ToString("yyyyMM")
                            com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "'  and amtpaid >=20 " : rst = com.ExecuteReader
                            While rst.Read
                                cntpayment = cntpayment + 1
                                'If beginyear.AddMonths(I).ToString("yyyyMM") < 201207 Then
                                '    totalpayment = totalpayment + 20
                                '    paymentbreakdown = paymentbreakdown + "20+"
                                'Else
                                '    totalpayment = totalpayment + 25
                                '    paymentbreakdown = paymentbreakdown + "25+"
                                'End If
                                totalpayment = totalpayment + Val(rst("chgpmnt1").ToString)
                                paymentbreakdown = paymentbreakdown + rst("chgpmnt1").ToString + "+"
                            End While
                            rst.Close()
                        Next I
                    End If '# END OF BREAK OTHER ACCOUNT
                    Dim fpmtbreadown As String = ""
                    If paymentbreakdown = "" Then
                        fpmtbreadown = "0.00"
                    Else
                        fpmtbreadown = paymentbreakdown.Remove(paymentbreakdown.Count - 1, 1)
                    End If
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "No. of Payment", cntpayment)
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Total of Payments", Format(totalpayment, "n"))
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Breakdown Payments", fpmtbreadown & " = " & Format(totalpayment, "n"))
                    currcustcode = .Rows(cnt)("custcode").ToString()
                End With
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next


            XgridColCurrency("Total of Payments", gridview1)
            XgridColAlign("Total of Payments", gridview1, DevExpress.Utils.HorzAlignment.Far)
            XgridColCurrency("Total of Payments", gridview1)

            XgridColAlign("Date Membership", gridview1, DevExpress.Utils.HorzAlignment.Center)
            XgridColAlign("No. of Payment", gridview1, DevExpress.Utils.HorzAlignment.Center)
            XgridColAlign("Total of Payments", gridview1, DevExpress.Utils.HorzAlignment.Far)
            gridview1.Columns("Breakdown Payments").ColumnEdit = MemoEdit
            gridview1.Columns("Breakdown Payments").Width = 530
            gridview1.BestFitColumns()

            gridview1.Columns("Client").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            gridview1.Columns("Product").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            gridview1.Columns("Client").Width = 230
            gridview1.Columns("Product").Width = 180
            gridview1.Columns("No. of Payment").Width = 120
            gridview1.Columns("Total of Payments").Width = 120

            gridview1.Columns("Client").Summary.Add(DevExpress.Data.SummaryItemType.Count, "Client", "Total Client {0:N0}")
            gridview1.Columns("No. of Payment").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "No. of Payment", "Total {0:N0}")
            gridview1.Columns("Total of Payments").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total of Payments", "Total {0:n} Php")

            CType(gridview1.Columns("Client").View, GridView).OptionsView.ShowFooter = True

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

    Public Sub FilterDetails()
        Dim curryear As Date = txttodate.Text
        Try
            SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Both
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = qrysingledata("cnt", "count(*) as cnt", "inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where  microfinance = 1 and cancelled=0", "master.loanprod")
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0

            dst = New DataSet
            msda = New MySqlDataAdapter("select * from master.loanprod inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where  microfinance = 1 and cancelled=0 order by custcode,loandate;", conn)
            msda.Fill(dst, 0)
            For cnt = 0 To dst.Tables(0).Rows.Count - 1
                With (dst.Tables(0))
                    Dim years As String = ""
                    Dim yearcount As Integer = 0
                    Dim totalpayment As Double = 0
                    Dim beginyear As Date = ConvertDate(txtfrmdate.Text)
                    Dim endyear As Date = ConvertDate(qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar"))
                    Dim year As Date = beginyear
                    yearcount = DateDiff(DateInterval.Month, beginyear, curryear)
                    For I = 0 To yearcount
                        If year.AddMonths(I).ToString("yyyyMM") >= 201110 And year.AddMonths(I).ToString("yyyyMM") < endyear.ToString("yyyyMM") Then
                            years = "db" & year.AddMonths(I).ToString("yyyyMM")
                            com.CommandText = "SELECT date_format(pmntdate,'%Y-%M') as fildate, CAST(concat((select prodname from master.loanprod where loanprod.prodcode = master.loanwithterm.loanprod), ' - ',loandate) AS CHAR(50)) as 'Product', " _
                                 + " (select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) as fullname from master.client where custcode = loanwithterm.custcode) as client, " _
                                 + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'branch', " _
                                  + " lnwtermdet.principal,amtpaid,interest, date_format(lnwtermdet.pmntdate, '%M %d, %Y') as pmtdate,chgpmnt1,chgpmnt2,chgpmnt3,chgpmnt4 " _
                                  + " FROM master.loanwithterm " _
                                  + " inner join " & years & ".lnwtermdet on " & years & ".lnwtermdet.lnrefno = loanwithterm.refno " _
                                  + " where loanwithterm.refno = '" & .Rows(cnt)("refno").ToString() & "' order by pmntdate asc" : rst = com.ExecuteReader
                            While rst.Read
                                AddRowXgrid(gridview1)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Date Filtered", rst("fildate").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Client", rst("client").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Branch", rst("branch").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Product", rst("Product").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Amount Paid", Format(rst("amtpaid"), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Principal", Format(rst("principal"), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Interest", Format(rst("interest"), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges1", Format(Val(rst("chgpmnt1").ToString), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges2", Format(Val(rst("chgpmnt2").ToString), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges3", Format(Val(rst("chgpmnt3").ToString), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges4", Format(Val(rst("chgpmnt4").ToString), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Date Payment", rst("pmtdate").ToString)
                            End While
                            rst.Close()
                        End If
                    Next I
                End With
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next cnt

            gridview1.Columns("Amount").Width = 120
            XgridColCurrency("Amount", gridview1)
            XgridColAlign("Amount", gridview1, DevExpress.Utils.HorzAlignment.Far)
            gridview1.Columns("Date Payment").SummaryItem.SummaryType = SummaryItemType.Count
            gridview1.Columns("Date Payment").SummaryItem.DisplayFormat = " Number of Payments {0:N0}"
            gridview1.Columns("Date Payment").SummaryItem.Tag = 1
            CType(gridview1.Columns("Date Payment").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Amount").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Amount").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Amount").SummaryItem.Tag = 1
            CType(gridview1.Columns("Amount").View, GridView).OptionsView.ShowFooter = True

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

    Public Sub FilterDetailsAdvance()
        Dim years As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            com.CommandText = "DROP TABLE IF EXISTS `tblpioneer`;" : com.ExecuteNonQuery()
            com.CommandText = "CREATE TABLE  `tblpioneer` ( `custcode` char(15) NOT NULL DEFAULT '', `refno` char(10) NOT NULL DEFAULT '',  `fildate` varchar(69) DEFAULT NULL,  `Product` varchar(50) DEFAULT NULL,  `client` varchar(77) DEFAULT NULL,  `branch` varchar(30) DEFAULT NULL,  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `amtpaid` double(12,2) NOT NULL DEFAULT '0.00',  `interest` double(12,2) NOT NULL DEFAULT '0.00',  `pmntdate` date NOT NULL DEFAULT '1988-08-08', `insurance` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt4` double(9,2) NOT NULL DEFAULT '0.00') ENGINE=MyISAM DEFAULT CHARSET=utf8;" : com.ExecuteNonQuery()
            Dim yearcount As Integer = 0
            Dim beginyear As Date = ConvertDate(txtfrmdate.Text)
            Dim curryear As Date = txttodate.Text
            Dim year As Date = beginyear
            yearcount = DateDiff(DateInterval.Month, beginyear, curryear)
            For I = 0 To yearcount
                years = "db" & year.AddMonths(I).ToString("yyyyMM")
                
                '## FOR TAGOLOAN  
                'IF((select prodname from master.loanprod where loanprod.prodcode = master.loanwithterm.loanprod) like '%PM2%', chgpmnt4, chgpmnt3)
                com.CommandText = "INSERT INTO tblpioneer SELECT custcode,lnwtermdet.refno,date_format(pmntdate,'%Y-%M') as fildate, CAST(concat((select prodname from master.loanprod where loanprod.prodcode = master.loanwithterm.loanprod), ' - ',loandate) AS CHAR(50)) as 'Product', " _
                                            + " (select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) as fullname from master.client where custcode = loanwithterm.custcode) as client, " _
                                            + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'branch', " _
                                            + "  lnwtermdet.principal,amtpaid,interest, pmntdate, " _
                                            + "  case when loandate < '2012-07-01' then '20.00' else " _
                                            + "  " & txtfields.Text & " end as 'insurance', " _
                                            + "  chgpmnt1,chgpmnt2,chgpmnt3,chgpmnt4 " _
                                            + "  FROM master.loanwithterm " _
                                            + "  inner join " & years & ".lnwtermdet on " & years & ".lnwtermdet.lnrefno = loanwithterm.refno " _
                                            + "  where (select microfinance from master.loanprod where master.loanprod.prodcode = master.loanwithterm.loanprod)  = 1 " _
                                            + "  and loanwithterm.cancelled=0 and lnwtermdet.cancelled=0 and lnwtermdet.amtpaid>=20 and " _
                                            + "  (left(lnwtermdet.refno,3) <> 'ADJ' and left(lnwtermdet.refno,3) <> 'ADA') and " _
                                            + "  lnwtermdet.lnrefno not in (select refno from " & years & ".loanadj) order by lnwtermdet.refno asc;"
                com.ExecuteNonQuery()
            Next I
            Filter()
            XtraMessageBox.Show("Data successfully Imported", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Cursor = Cursors.Default
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & " - database " & years & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & " - database " & years & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            If XtraMessageBox.Show("Bigger data takes to much longer to query! Are you sure you want to continue?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                FilterDetailsAdvance()
            End If

        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim report As New rptOtherReport()
        ' report.txttitle.Text = "PRODUCT NAME " + txtSearch.Text + " - " + txtfrmdate.Text + " to " + txttodate.Text
        report.Landscape = True
        report.PaperKind = System.Drawing.Printing.PaperKind.Legal
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()

    End Sub

    Private Sub PaymentHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentHistoryToolStripMenuItem.Click
        frmPaymentHistory.custcode.Text = gridview1.GetFocusedRowCellValue("custcode").ToString
        frmPaymentHistory.Show()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtfrmdate.Text = "" Then
            XtraMessageBox.Show("Please Select Proper date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfrmdate.Focus()
            Exit Sub
        ElseIf txttodate.Text = "" Then
            XtraMessageBox.Show("Please Select Proper date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfrmdate.Focus()
            Exit Sub
        ElseIf txtfields.Text = "" Then
            XtraMessageBox.Show("Please Select fields!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfields.Focus()
            Exit Sub
        End If
        If XtraMessageBox.Show("Bigger data takes to much longer to query! Are you sure you want to continue?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            FilterDetailsAdvance()
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If txtfrmdate.Text = "" Then
            XtraMessageBox.Show("Please Select Proper date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfrmdate.Focus()
            Exit Sub
        ElseIf txttodate.Text = "" Then
            XtraMessageBox.Show("Please Select Proper date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfrmdate.Focus()
            Exit Sub
        End If
        Filter()
    End Sub

    Public Sub Filter()
        LoadXgrid("select custcode,fildate as 'Date Filtered',client as Client,branch as 'Branch',Product as 'Product',refno as 'Reference Number', amtpaid as 'Amount Paid',principal as 'Principal', interest as 'Interest', insurance as 'Insurance',  date_format(pmntdate, '%M %d, %Y') as 'Date Payment' from tblpioneer where date_format(pmntdate, '%Y-%m-%d') between '" & ConvertDate(txtfrmdate.Text) & "' and '" & ConvertDate(txttodate.Text) & "' order by pmntdate asc", "tblpioneer", Em, gridview1, Me)
        gridview1.Columns("custcode").Visible = False
        gridview1.Columns("Branch").Group()
        gridview1.Columns("Date Filtered").Group()
        gridview1.ExpandAllGroups()
        gridview1.BestFitColumns()
        gridview1.Columns("Client").Width = 200
        gridview1.Columns("Product").Width = 290
        gridview1.Columns("Amount Paid").Width = 120
        gridview1.Columns("Principal").Width = 120
        gridview1.Columns("Interest").Width = 120
        gridview1.Columns("Insurance").Width = 120

        XgridColCurrency("Amount Paid", gridview1)
        XgridColCurrency("Principal", gridview1)
        XgridColCurrency("Interest", gridview1)
        XgridColCurrency("Insurance", gridview1)
        XgridColAlign("Reference Number", gridview1, DevExpress.Utils.HorzAlignment.Center)

        XgridColAlign("Date Payment", gridview1, DevExpress.Utils.HorzAlignment.Far)
        gridview1.Columns("Date Payment").SummaryItem.SummaryType = SummaryItemType.Count
        gridview1.Columns("Date Payment").SummaryItem.DisplayFormat = " Number of Payments {0:N0}"
        gridview1.Columns("Date Payment").SummaryItem.Tag = 1
        CType(gridview1.Columns("Date Payment").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Amount Paid").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Amount Paid").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Amount Paid").SummaryItem.Tag = 1
        CType(gridview1.Columns("Amount Paid").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Principal").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Principal").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Principal").SummaryItem.Tag = 1
        CType(gridview1.Columns("Principal").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Insurance").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Insurance").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Insurance").SummaryItem.Tag = 1
        CType(gridview1.Columns("Insurance").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Interest").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Interest").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Interest").SummaryItem.Tag = 1
        CType(gridview1.Columns("Interest").View, GridView).OptionsView.ShowFooter = True
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog

        Dim view As ColumnView = gridview1
        Dim branches As String = qrysingledata("str", "group_concat(distinct(branch)) as str", "", "`tblpioneer`")
        Dim dtquery As String = qrysingledata("str", "group_concat(distinct(fildate)) as str", " where date_format(pmntdate, '%Y-%m-%d') between '" & ConvertDate(txtfrmdate.Text) & "' and '" & ConvertDate(txttodate.Text) & "'", "`tblpioneer`")
        If fbd.ShowDialog() = DialogResult.OK Then
            dir.Text = fbd.SelectedPath
            Try
                Me.Cursor = Cursors.WaitCursor
                For Each splBranch In branches.Split(New Char() {","c})
                    If Not Directory.Exists(dir.Text & "\" & splBranch) Then
                        Directory.CreateDirectory(dir.Text & "\" & splBranch)
                    End If

                    For Each spldatefilter In dtquery.Split(New Char() {","c})
                        Dim report As New rptOtherReport()
                        gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' AND [Date Filtered] = '" & spldatefilter & "'"
                        ' gridview1.ExportToXlsx(dir.Text & "\" & splBranch & "\" & spldatefilter & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(True, True, False))
                        report.Landscape = True
                        report.PaperKind = System.Drawing.Printing.PaperKind.A2
                        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
                        report.ExportToXlsx(dir.Text & "\" & splBranch & "\" & spldatefilter & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(True, True, False))
                    Next
                Next
                Me.Cursor = Cursors.Default
            Catch errMS As Exception
                XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            XtraMessageBox.Show("Data successfully exported", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class