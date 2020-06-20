Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid
Imports System.IO

Public Class frmPaymentCollection
    Public Sub filterPaymentsnojoin()
        Dim currmonth As Date = txtMonth.Text & ", 01,2001"
        Dim years As String = ""
        Dim other As String = ""

        Try
            If CheckEdit2.Checked = True Then
                other = ",chgpmnt1 as 'Charge 1',chgpmnt2 as 'Charge 2',chgpmnt3 as 'Charge 3',chgpmnt4 as 'Charge 4' "
            Else
                other = ""
            End If
            years = "db" & txtyear.Text & currmonth.ToString("MM")

            Dim dst = New DataSet : dst.Clear()
            msda = New MySqlDataAdapter("SELECT lnrefno as Refno, (select branchname from master.branches where branchcode=loanwithterm.branchcode) as 'Branch', (select concat(ucase(lname),', ', ucase(fname)) from master.client where custcode = loanwithterm.custcode ) as 'Client', " _
                                            + " (select prodname from master.loanprod where prodcode = loanwithterm.loanprod) as 'Product',date_format(pmntdate,'%Y-%m-%d') as 'Date Payment', amtpaid as 'Amount Collected',lnwtermdet.Principal,lnwtermdet.Interest,lnwtermdet.Penalty,(lnwtermdet.Principal+lnwtermdet.Interest+lnwtermdet.Penalty) as 'Total Collection' " _
                                            + other _
                                            + " , concat(username, ' ', '(',userid,')') as 'Account Officer' " _
                                            + " FROM " & years & ".lnwtermdet inner join master.loanwithterm on lnwtermdet.lnrefno = loanwithterm.refno " _
                                            + " inner join master.g_center on g_center.centerkey= loanwithterm.centerkey " _
                                            + " inner join master.userinfo on g_center.accountofficer = userinfo.userid " _
                                            + " where lnwtermdet.cancelled=0 order by username ", conn)

            msda.Fill(dst, "master.loanwithterm")
            Em.DataSource = dst.Tables("master.loanwithterm")
            gridview1.PopulateColumns(dst.Tables("master.loanwithterm"))
            Em.ForceInitialize()
            gridview1.BestFitColumns()
            gridview1.Columns("Refno").Width = 100

            XgridColCurrency("Amount Collected", gridview1)
            XgridColCurrency("Principal", gridview1)
            XgridColCurrency("Interest", gridview1)
            XgridColCurrency("Penalty", gridview1)
            XgridColCurrency("Total Collection", gridview1)
            XgridColAlign("Refno", gridview1, DevExpress.Utils.HorzAlignment.Center)
            XgridColAlign("Date Payment", gridview1, DevExpress.Utils.HorzAlignment.Center)
            If CheckEdit2.Checked = True Then
                XgridColCurrency("Charge 1", gridview1)
                XgridColCurrency("Charge 2", gridview1)
                XgridColCurrency("Charge 3", gridview1)
                XgridColCurrency("Charge 4", gridview1)
            End If
            Dim item As New GridGroupSummaryItem()
            item.FieldName = "Account Officer"
            item.SummaryType = DevExpress.Data.SummaryItemType.Count


            Dim item0 As New GridGroupSummaryItem()
            item0.FieldName = "Amount Collected"
            item0.SummaryType = DevExpress.Data.SummaryItemType.Count
            item0.DisplayFormat = "{0:n}"
            item0.ShowInGroupColumnFooter = gridview1.Columns("Amount Collected")
            gridview1.GroupSummary.Add(item0)

            Dim item1 As New GridGroupSummaryItem()
            item1.FieldName = "Principal"
            item1.SummaryType = DevExpress.Data.SummaryItemType.Count
            item1.DisplayFormat = "{0:n}"
            item1.ShowInGroupColumnFooter = gridview1.Columns("Principal")
            gridview1.GroupSummary.Add(item1)

            Dim item2 As New GridGroupSummaryItem()
            item2.FieldName = "Interest"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Count
            item2.DisplayFormat = "{0:n}"
            item2.ShowInGroupColumnFooter = gridview1.Columns("Interest")
            gridview1.GroupSummary.Add(item2)

            Dim item3 As New GridGroupSummaryItem()
            item3.FieldName = "Penalty"
            item3.SummaryType = DevExpress.Data.SummaryItemType.Count
            item3.DisplayFormat = "{0:n}"
            item3.ShowInGroupColumnFooter = gridview1.Columns("Penalty")
            gridview1.GroupSummary.Add(item3)

            Dim item4 As New GridGroupSummaryItem()
            item4.FieldName = "Total Collection"
            item4.SummaryType = DevExpress.Data.SummaryItemType.Count
            item4.DisplayFormat = "{0:n}"
            item4.ShowInGroupColumnFooter = gridview1.Columns("Total Collection")
            gridview1.GroupSummary.Add(item4)

            gridview1.Columns("Amount Collected").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Amount Collected").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Amount Collected").SummaryItem.Tag = 1
            CType(gridview1.Columns("Amount Collected").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Principal").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Principal").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Principal").SummaryItem.Tag = 1
            CType(gridview1.Columns("Principal").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Interest").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Interest").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Interest").SummaryItem.Tag = 1
            CType(gridview1.Columns("Interest").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Penalty").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Penalty").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Penalty").SummaryItem.Tag = 1
            CType(gridview1.Columns("Penalty").View, GridView).OptionsView.ShowFooter = True

            gridview1.Columns("Total Collection").SummaryItem.SummaryType = SummaryItemType.Sum
            gridview1.Columns("Total Collection").SummaryItem.DisplayFormat = "{0:n}"
            gridview1.Columns("Total Collection").SummaryItem.Tag = 1
            CType(gridview1.Columns("Total Collection").View, GridView).OptionsView.ShowFooter = True

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & Me.Text & vbCrLf _
                             & "Message: " & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
    End Sub

    Private Sub frmPaymentHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Coll As ComboBoxItemCollection = txtyear.Properties.Items
        Coll.Clear()
        For I = Now.ToString("yyyy") To 2010 Step -1
            Coll.Add(I)
        Next I
        AddRowXgrid(gridview1)
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If txtMonth.Text = "" Then
            XtraMessageBox.Show("Please select month", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMonth.Focus()
            Exit Sub
        ElseIf txtyear.Text = "" Then
            XtraMessageBox.Show("Please select year", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtyear.Focus()
            Exit Sub
        End If
        filterPaymentsnojoin()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim report As New rptOtherReport
        report.txttitle.Text = "Payments Collection of " & txtMonth.Text & ", " & txtyear.Text
        report.Landscape = True
        report.PaperKind = System.Drawing.Printing.PaperKind.Legal

        Me.WindowState = FormWindowState.Minimized
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim dir As String = ""
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog
        If fbd.ShowDialog() = DialogResult.OK Then
            dir = fbd.SelectedPath
        End If
        If dir = "" Then Exit Sub
        Dim currmonth As Date = txtMonth.Text & ", 01,2001"
        Dim filefolder As String = ""
        Dim years As String = ""
        years = "db" & txtyear.Text & currmonth.ToString("MM")
        filefolder = txtyear.Text & "-" & currmonth.ToString("MM")
        Dim branches As String = qrysingledata("str", "group_concat(distinct((select branchname from master.branches where branchcode = lnwtermdet.branchcode))) as str", "", years & ".lnwtermdet")

        Me.Cursor = Cursors.WaitCursor
        If branches <> "" Then
            ' Dim existfilter = gridview1.ActiveFilterString.ToString()
            For Each splBranch In branches.Split(New Char() {","c})
                If Not Directory.Exists(dir & "\" & filefolder & "\" & splBranch) Then
                    Directory.CreateDirectory(dir & "\" & filefolder & "\" & splBranch)
                End If
                Dim report As New rptOtherReport()
                gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "'"
                report.Landscape = True
                report.PaperKind = System.Drawing.Printing.PaperKind.Legal
                report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
                report.ExportToXlsx(dir & "\" & filefolder & "\" & splBranch & "\collection_" & splBranch.Replace(" ", "") & "_" & filefolder.Replace("-", "") & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
            Next
        End If

        If branches <> "" Then
            gridview1.ActiveFilterString = Nothing
            For Each splBranch In branches.Split(New Char() {","c})
                'Export by account officer
                com.CommandText = "select distinct(concat(username, ' ', '(',userid,')')) as str from " & years & ".lnwtermdet inner join master.loanwithterm on lnwtermdet.lnrefno = loanwithterm.refno" _
                              + " inner join master.g_center on g_center.centerkey= loanwithterm.centerkey " _
                              + " inner join master.userinfo on g_center.accountofficer = userinfo.userid " _
                              + " where lnwtermdet.cancelled=0 and (select branchname from master.branches where branchcode = lnwtermdet.branchcode) = '" & splBranch & "'" : rst = com.ExecuteReader
                While rst.Read
                    ' Dim existfilter = gridview1.ActiveFilterString.ToString()
                    Dim report As New rptOtherReport()
                    If Not Directory.Exists(dir & "\" & filefolder & "\" & splBranch & "\AO Reports") Then
                        Directory.CreateDirectory(dir & "\" & filefolder & "\" & splBranch & "\AO Reports")
                    End If
                    Dim reportao As New rptOtherReport()
                    gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' And [Account Officer] = '" & rst("str").ToString & "'"
                    report.Landscape = True
                    report.PaperKind = System.Drawing.Printing.PaperKind.Legal
                    report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
                    report.ExportToXlsx(dir & "\" & filefolder & "\" & splBranch & "\AO Reports\" & rst("str").ToString & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
                End While
                rst.Close()
            Next
        End If
        Me.Cursor = Cursors.Default
        XtraMessageBox.Show("Report successfully exported!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class