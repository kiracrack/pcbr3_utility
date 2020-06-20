Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MySql.Data.MySqlClient

Public Class frmPaymentCount
    Private beginyear As Date = Format(Now, "MMMM d, yyyy")
    Private endyear As Date = Format(Now, "MMMM d, yyyy")
    Private Sub frmPaymentCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        txtfrmdate.EditValue = Format(Now, "MMMM d, yyyy")
        txttodate.EditValue = Format(Now, "MMMM d, yyyy")
        ClearGrid()
    End Sub
    Public Sub ClearGrid()
        LoadXgrid("select '' as custcode, " _
                      + " '' as Client, " _
                      + " '' as Branch, " _
                      + " '' as Product, " _
                      + " '' as 'Date Membership', " _
                      + " '' as 'No. of Payment', " _
                      + " '' as 'Total of Payments', " _
                      + " '' as 'Breakdown Payments' " _
                      + " from master.loanwithterm where refno='0'", "master.loanwithterm", Em, gridview1, Me)
        gridview1.Columns("custcode").Visible = False
        XgridColAlign("Total of Payments", gridview1, DevExpress.Utils.HorzAlignment.Far)
        XgridColAlign("Date Membership", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("No. of Payment", gridview1, DevExpress.Utils.HorzAlignment.Center)
        gridview1.BestFitColumns()

        gridview1.Columns("Client").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        gridview1.Columns("Product").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        gridview1.Columns("Breakdown Payments").ColumnEdit = MemoEdit
        gridview1.Columns("Breakdown Payments").Width = 530
        gridview1.Columns("Client").Width = 230
        gridview1.Columns("Product").Width = 180
        gridview1.Columns("No. of Payment").Width = 120
        gridview1.Columns("Total of Payments").Width = 120

        gridview1.MoveLast()
    End Sub

    Public Sub filterPayments()
        ClearGrid()
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
            ProgressBarControl1.Properties.Maximum = qrysingledata("cnt", "count(distinct(custcode)) as cnt", "inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where prodname like '%" & txtSearch.Text & "%' and cancelled=0", "master.loanprod")
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0

            dst = New DataSet
            msda = New MySqlDataAdapter("select count(distinct(custcode)) as cnt from master.loanprod inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where prodname like '%" & txtSearch.Text & "%' and cancelled=0 order by custcode,loandate;", conn)
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

                            If txtSearch.Text = "ASENSO" Then '#ASSENSO LOAN SEARCH
                                If rdInsurance.SelectedIndex = 0 Then '# IF MBAI INSURANCE
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "' and principal<>0" : rst = com.ExecuteReader
                                    While rst.Read
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + 20
                                        paymentbreakdown = paymentbreakdown + "20+"
                                    End While
                                    rst.Close()

                                Else '# IF PIONEER INSURANCE
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "'  and (chgpmnt1 =20 or chgpmnt1 =25)" : rst = com.ExecuteReader
                                    While rst.Read
                                        'If Val(rst("chgpmnt3").ToString) < 20 Then
                                        '    If Val(rst("chgpmnt4").ToString) >= 20 Then
                                        '        cntpayment = cntpayment + 1
                                        '        totalpayment = totalpayment + Val(rst("chgpmnt4").ToString)
                                        '        paymentbreakdown = paymentbreakdown + rst("chgpmnt4").ToString + "+"
                                        '    End If
                                        'Else
                                        '    cntpayment = cntpayment + 1
                                        '    totalpayment = totalpayment + Val(rst("chgpmnt3").ToString)
                                        '    paymentbreakdown = paymentbreakdown + rst("chgpmnt3").ToString + "+"
                                        'End If
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + Val(rst("chgpmnt1").ToString)
                                        paymentbreakdown = paymentbreakdown + rst("chgpmnt1").ToString + "+"
                                    End While
                                    rst.Close()
                                End If

                            Else '#PM2 LOAN SEARCH
                                If rdInsurance.SelectedIndex = 0 Then
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "' and principal <> 0" : rst = com.ExecuteReader
                                    While rst.Read
                                        'cntpayment = cntpayment + 1
                                        'totalpayment = totalpayment + Val(rst("chgpmnt2").ToString)
                                        'paymentbreakdown = paymentbreakdown + rst("chgpmnt2").ToString + "+"
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + 20
                                        paymentbreakdown = paymentbreakdown + "20+"
                                    End While
                                    rst.Close()
                                Else '# IF PIONEER INSURANCE
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "' and (chgpmnt2 =20 or chgpmnt2 =25)" : rst = com.ExecuteReader
                                    While rst.Read
                                        'If Val(rst("chgpmnt3").ToString) < 20 Then
                                        '    If Val(rst("chgpmnt4").ToString) >= 20 Then
                                        '        cntpayment = cntpayment + 1
                                        '        totalpayment = totalpayment + Val(rst("chgpmnt4").ToString)
                                        '        paymentbreakdown = paymentbreakdown + rst("chgpmnt4").ToString + "+"
                                        '    End If
                                        'Else
                                        '    cntpayment = cntpayment + 1
                                        '    totalpayment = totalpayment + Val(rst("chgpmnt3").ToString)
                                        '    paymentbreakdown = paymentbreakdown + rst("chgpmnt3").ToString + "+"
                                        'End If
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + Val(rst("chgpmnt2").ToString)
                                        paymentbreakdown = paymentbreakdown + rst("chgpmnt2").ToString + "+"
                                    End While
                                    rst.Close()
                                End If

                            End If
                           
                        Next I
                    Else ' BREAK IF THERE OTHER ACCOUNT
                        beginyear = txtfrmdate.Text
                        endyear = txttodate.Text
                        yearcount = DateDiff(DateInterval.Month, beginyear, endyear)
                        For I = 0 To yearcount
                            Me.Cursor = Cursors.WaitCursor
                            years = "db" & beginyear.AddMonths(I).ToString("yyyyMM")

                            If txtSearch.Text = "ASENSO" Then '#ASSENSO LOAN SEARCH
                                If rdInsurance.SelectedIndex = 0 Then '# IF MBAI INSURANCE
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "' and principal<>0" : rst = com.ExecuteReader
                                    While rst.Read
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + 20
                                        paymentbreakdown = paymentbreakdown + "20+"
                                    End While
                                    rst.Close()

                                Else '# IF PIONEER INSURANCE 
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "'  and chgpmnt2 >=20" : rst = com.ExecuteReader
                                    While rst.Read
                                        'If Val(rst("chgpmnt3").ToString) < 20 Then
                                        '    If Val(rst("chgpmnt4").ToString) >= 20 Then
                                        '        cntpayment = cntpayment + 1
                                        '        totalpayment = totalpayment + Val(rst("chgpmnt4").ToString)
                                        '        paymentbreakdown = paymentbreakdown + rst("chgpmnt4").ToString + "+"
                                        '    End If
                                        'Else
                                        '    cntpayment = cntpayment + 1
                                        '    totalpayment = totalpayment + Val(rst("chgpmnt3").ToString)
                                        '    paymentbreakdown = paymentbreakdown + rst("chgpmnt3").ToString + "+"
                                        'End If
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + Val(rst("chgpmnt2").ToString)
                                        paymentbreakdown = paymentbreakdown + rst("chgpmnt2").ToString + "+"
                                    End While
                                    rst.Close()
                                End If

                            Else '#PM2 LOAN SEARCH
                                If rdInsurance.SelectedIndex = 0 Then
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "' and principal <> 0" : rst = com.ExecuteReader
                                    While rst.Read
                                        'cntpayment = cntpayment + 1
                                        'totalpayment = totalpayment + Val(rst("chgpmnt2").ToString)
                                        'paymentbreakdown = paymentbreakdown + rst("chgpmnt2").ToString + "+"
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + 20
                                        paymentbreakdown = paymentbreakdown + "20+"
                                    End While
                                    rst.Close()
                                Else '# IF PIONEER INSURANCE
                                    com.CommandText = "SELECT * from " & years & ".lnwtermdet where lnwtermdet.lnrefno = '" & .Rows(cnt)("refno").ToString() & "'  and (chgpmnt2 =20 or chgpmnt2 =25)" : rst = com.ExecuteReader
                                    While rst.Read
                                        'If Val(rst("chgpmnt3").ToString) < 20 Then
                                        '    If Val(rst("chgpmnt4").ToString) >= 20 Then
                                        '        cntpayment = cntpayment + 1
                                        '        totalpayment = totalpayment + Val(rst("chgpmnt4").ToString)
                                        '        paymentbreakdown = paymentbreakdown + rst("chgpmnt4").ToString + "+"
                                        '    End If
                                        'Else
                                        '    cntpayment = cntpayment + 1
                                        '    totalpayment = totalpayment + Val(rst("chgpmnt3").ToString)
                                        '    paymentbreakdown = paymentbreakdown + rst("chgpmnt3").ToString + "+"
                                        'End If
                                        cntpayment = cntpayment + 1
                                        totalpayment = totalpayment + Val(rst("chgpmnt2").ToString)
                                        paymentbreakdown = paymentbreakdown + rst("chgpmnt2").ToString + "+"
                                    End While
                                    rst.Close()
                                End If

                            End If

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
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                    currcustcode = .Rows(cnt)("custcode").ToString()
                End With
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

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            txtSearch.Enabled = False
            txtSearch.Text = ""
            filterPayments()
        Else
            txtSearch.Enabled = True
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtSearch.Text = "" Then Exit Sub
            filterPayments()
        End If
    End Sub

    Private Sub CheckEdit2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            gridview1.OptionsView.ShowAutoFilterRow = True
        Else
            gridview1.OptionsView.ShowAutoFilterRow = False
        End If
    End Sub

    Private Sub CheckEdit3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit3.CheckedChanged
        If CheckEdit3.Checked = True Then
            gridview1.ShowFindPanel()
        Else
            gridview1.HideFindPanel()
        End If
    End Sub

    Public Sub temp()
        'com.CommandText = "SELECT concat(lname,'. ',fname) as Fullname, totalpmnt,lnwtermpay.pmntdate," _
        '                      + " (select prodname from master.loanprod inner join master.loanwithterm on master.loanprod.prodcode = loanwithterm.loanprod where loanwithterm.refno = lnwtermdet.lnrefno) as Product FROM master.client " _
        '                      + " inner join " & years & ".lnwtermpay on " & years & ".lnwtermpay.custcode = master.client.custcode " _
        '                      + " inner join " & years & ".lnwtermdet on " & years & ".lnwtermdet.refno = " & years & ".lnwtermpay.refno " _
        '                      + " where master.client.custcode = '" & custcode.Text & "' and master.loanwithterm.refno='" & loanref.Text & "';" : rst = com.ExecuteReader

    End Sub
    Public Sub printreport()
        Dim report As New rptOtherReport()
        com.CommandText = "select *,concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) as 'fullname' from master.client where custcode = '" & custcode.Text & "'"
        rst = com.ExecuteReader()
        While rst.Read
            'txtfullname.Text = UCase(rst("fullname").ToString)
            'txtAddress.Text = UCase(rst("res_street").ToString) + " " + UCase(rst("res_city").ToString) + " " + UCase(rst("res_province").ToString)
            'txtClientContact.Text = UCase(rst("cellno").ToString)
        End While
        rst.Close()

        com.CommandText = "SELECT (select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) from master.client where master.client.custcode = master.loanwithterm.comaker1) as 'comakername1', " _
                + " (select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) from master.client where master.client.custcode = master.loanwithterm.comaker2) as 'comakername2' " _
                + " , loandate FROM master.loanwithterm where refno = '" & loanref.Text & "'; "
        rst = com.ExecuteReader
        While rst.Read
            'txtcomaker1.Text = rst("comakername1").ToString
            'txtcomaker2.Text = rst("comakername2").ToString
        End While
        rst.Close()

        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim report As New rptOtherReport()
        report.txttitle.Text = "PRODUCT NAME " + txtSearch.Text + " - " + txtfrmdate.Text + " to " + txttodate.Text
        If txtSearch.Text = "PM2" Then

            report.Landscape = True
            report.PaperKind = System.Drawing.Printing.PaperKind.Legal
        Else
            If rdInsurance.SelectedIndex = 1 Then
                report.Landscape = True
                report.PaperKind = System.Drawing.Printing.PaperKind.Legal
            End If
        End If

        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub

    Private Sub PaymentHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentHistoryToolStripMenuItem.Click
        frmPaymentHistory.custcode.Text = gridview1.GetFocusedRowCellValue("custcode").ToString
        frmPaymentHistory.Show()
    End Sub
End Class