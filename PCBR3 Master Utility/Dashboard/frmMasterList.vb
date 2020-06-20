Imports MySql.Data.MySqlClient
Imports DevExpress.Skins
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports System.IO
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls

Public Class frmMasterList
    Dim strCheckedCode As String
    Dim strCheckedName As String
    Dim selectedProdCode As String

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Control) + (Keys.W) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function

    Public Sub GenerateMasterList()
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog
        If fbd.ShowDialog() = DialogResult.OK Then
            dir.Text = fbd.SelectedPath
        End If
        If dir.Text = "" Then Exit Sub

        dst = New DataSet
        msda = New MySqlDataAdapter("SELECT id,productid,daysinterval,groupname from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'  order by groupname asc;", conn)
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim strproduct As String = "" : Dim curraccount As String = ""
                Dim daysdel As Integer = 0
                Me.Cursor = Cursors.WaitCursor
                For Each word In .Rows(cnt)("productid").ToString().Split(New Char() {"|"c})
                    strproduct = strproduct + "par.`" & txtPARTable.Text & "`.loanprod='" & word & "' or "
                Next
                strproduct = strproduct.Remove(strproduct.Count - 3, 3)
                com.CommandText = "drop table if exists tbl_masterlist0" & .Rows(cnt)("id").ToString() & ";" : com.ExecuteNonQuery()
                LoadXgrid("CREATE TABLE tbl_masterlist0" & .Rows(cnt)("id").ToString() & " SELECT refno, loanprod, " _
                 + " concat(refno) as 'Reference No.', " _
                 + " ucase(cname) as 'Client Fullname', " _
                 + " prodname as 'Product', " _
                 + " groupname as `Group`, " _
                 + " centername as 'Center', " _
                 + " areaname as 'Area', " _
                 + " date_format(Loandate,'%m-%d-%Y') as 'Loandate',date_format(Maturity,'%m-%d-%Y') as 'Maturity', " _
                 + " Principal, " _
                 + " pribal as 'Principal Balance', " _
                 + " intdue as 'Interest Due', " _
                 + " pendue as 'Penalty Due', " _
                 + " pribal as 'PAR Amount', " _
                 + " (pribal+intdue) as 'Total (Pribal+Intdue)', " _
                 + " case when pastdue=1 then 'PAST DUE' else 'DELINQUENT' end as 'Account Status', " _
                 + " daysdelayed  as 'Days Delayed', " _
                 + " numbinstdue as 'No. Installment Due', " _
                 + " if(ao='NO AO','NO OFFICER INCHARGE',ao) as 'Account Officer', " _
                 + " ucase(branchname) as 'Branch', " _
                 + " (select ucase(category) from master.branches where branchcode = par.`" & txtPARTable.Text & "`.branchcode) as 'areagroup', " _
                 + " '" & .Rows(cnt)("groupname").ToString() & "' as 'groupname' " _
                 + " FROM par.`" & txtPARTable.Text & "` where  (" & strproduct & ")  and " _
                 + " (daysdelayed > 0 or  pastdue = 1) and pribal > 0 order by branchname,ao,cname asc;", "par.`" & txtPARTable.Text & "`", Em, gridview1, Me)

                LoadXgrid("select * from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " order by  `Account Status` desc", "tbl_masterlist0" & .Rows(cnt)("id").ToString() & "", Em, gridview1, Me)
                If gridview1.RowCount <> 0 Then
                    gridview1.Columns("refno").Visible = False
                    gridview1.Columns("loanprod").Visible = False
                    gridview1.BestFitColumns()

                    gridview1.Columns("Reference No.").Fixed = Columns.FixedStyle.Left
                    gridview1.Columns("Client Fullname").Fixed = Columns.FixedStyle.Left
                    gridview1.Columns("Product").Fixed = Columns.FixedStyle.Left

                    gridview1.Columns("Principal").Width = 90
                    gridview1.Columns("Principal Balance").Width = 90
                    gridview1.Columns("PAR Amount").Width = 90

                    gridview1.Columns("Client Fullname").Width = 200
                    gridview1.Columns("Client Fullname").ColumnEdit = MemoEdit

                    XgridColCurrency("Principal", gridview1)
                    XgridColCurrency("Principal Balance", gridview1)

                    XgridColCurrency("Interest Due", gridview1)
                    gridview1.Columns("Interest Due").Width = 90

                    XgridColCurrency("Penalty Due", gridview1)
                    gridview1.Columns("Penalty Due").Width = 90

                    XgridColCurrency("Total (Pribal+Intdue)", gridview1)
                    gridview1.Columns("Total (Pribal+Intdue)").Width = 90

                    XgridColAlign("Reference No.", gridview1, DevExpress.Utils.HorzAlignment.Center)
                    XgridColAlign("Loandate", gridview1, DevExpress.Utils.HorzAlignment.Center)
                    XgridColAlign("Maturity", gridview1, DevExpress.Utils.HorzAlignment.Center)
                    XgridColAlign("Days Delayed", gridview1, DevExpress.Utils.HorzAlignment.Center)

                    XgridColAlign("No. Installment Due", gridview1, DevExpress.Utils.HorzAlignment.Center)

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

                    Dim item3 As New GridGroupSummaryItem()
                    item3.FieldName = "PAR Amount"
                    item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item3.DisplayFormat = "{0:n}"
                    item3.ShowInGroupColumnFooter = gridview1.Columns("PAR Amount")
                    gridview1.GroupSummary.Add(item3)

                    Dim item4 As New GridGroupSummaryItem()
                    item4.FieldName = "Total (Pribal+Intdue)"
                    item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item4.DisplayFormat = "{0:n}"
                    item4.ShowInGroupColumnFooter = gridview1.Columns("Total (Pribal+Intdue)")
                    gridview1.GroupSummary.Add(item4)

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

                    gridview1.Columns("PAR Amount").SummaryItem.SummaryType = SummaryItemType.Sum
                    gridview1.Columns("PAR Amount").SummaryItem.DisplayFormat = "{0:n}"
                    gridview1.Columns("PAR Amount").SummaryItem.Tag = 1
                    CType(gridview1.Columns("PAR Amount").View, GridView).OptionsView.ShowFooter = True


                    gridview1.Columns("Interest Due").SummaryItem.SummaryType = SummaryItemType.Sum
                    gridview1.Columns("Interest Due").SummaryItem.DisplayFormat = "{0:n}"
                    gridview1.Columns("Interest Due").SummaryItem.Tag = 1
                    CType(gridview1.Columns("Interest Due").View, GridView).OptionsView.ShowFooter = True

                    gridview1.Columns("Penalty Due").SummaryItem.SummaryType = SummaryItemType.Sum
                    gridview1.Columns("Penalty Due").SummaryItem.DisplayFormat = "{0:n}"
                    gridview1.Columns("Penalty Due").SummaryItem.Tag = 1
                    CType(gridview1.Columns("Penalty Due").View, GridView).OptionsView.ShowFooter = True


                    gridview1.Columns("Total (Pribal+Intdue)").SummaryItem.SummaryType = SummaryItemType.Sum
                    gridview1.Columns("Total (Pribal+Intdue)").SummaryItem.DisplayFormat = "{0:n}"
                    gridview1.Columns("Total (Pribal+Intdue)").SummaryItem.Tag = 1
                    CType(gridview1.Columns("Total (Pribal+Intdue)").View, GridView).OptionsView.ShowFooter = True
                End If
                '#END GRID VIEWING
                Dim existfilter = gridview1.ActiveFilterString.ToString()
                Dim view As ColumnView = gridview1
                Dim branches As String = qrysingledata("str", "group_concat(distinct(branch)) as str", "", "tbl_masterlist0" & .Rows(cnt)("id").ToString() & "")

                Try
                    If branches <> "" Then
                        For Each splBranch In branches.Split(New Char() {","c})
                            If Not Directory.Exists(dir.Text & "\" & ConvertDate(txtLastDateTransaction.Text) & "\" & splBranch & "\AO PAR LIST\" & UCase(.Rows(cnt)("groupname").ToString())) Then
                                Directory.CreateDirectory(dir.Text & "\" & ConvertDate(txtLastDateTransaction.Text) & "\" & splBranch & "\AO PAR LIST\" & UCase(.Rows(cnt)("groupname").ToString()))
                            End If
                            com.CommandText = "select distinct(`Account Officer`) as ao from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where Branch='" & UCase(splBranch) & "' and  groupname='" & .Rows(cnt)("groupname").ToString() & "'" : rst = com.ExecuteReader
                            While rst.Read
                                Dim report As New rptOtherReport()
                                report.txttitle.Text = UCase(.Rows(cnt)("groupname").ToString()) & " OF " & UCase(splBranch) & " AS OF " & txtLastDateTransaction.Text & " (" & rst("ao").ToString & ")"
                                If existfilter = "" Then
                                    gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' And [Account Officer] = '" & rst("ao").ToString & "'"
                                Else
                                    gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' And [Account Officer] = '" & rst("ao").ToString & "' And " & existfilter
                                End If
                                report.Landscape = True
                                report.PaperKind = System.Drawing.Printing.PaperKind.A2
                                report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
                                report.ExportToXlsx(dir.Text & "\" & ConvertDate(txtLastDateTransaction.Text) & "\" & splBranch & "\AO PAR LIST\" & UCase(.Rows(cnt)("groupname").ToString()) & "\" & rst("ao").ToString & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
                            End While
                            rst.Close()
                        Next
                    End If
                    Me.Cursor = Cursors.Default
                Catch errMS As Exception
                    XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                                 & "Message:" & errMS.Message & vbCrLf _
                                 & "Details:" & errMS.StackTrace, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End With
        Next
        dst.Clear()
        UpdateAccountsSummary()
        loadaoportfoliowithpar()
        loadaoParredSummary()
        'LoadSummary()
        XtraMessageBox.Show("Data successfully Generated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub UpdateAccountsSummary()
        Me.Cursor = Cursors.WaitCursor
        dst = New DataSet
        msda = New MySqlDataAdapter("SELECT id,productid,daysinterval,groupname from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'  order by groupname asc;", conn)
        msda.Fill(dst, 0)
        com.CommandText = "delete from tblaosummary where datesummary='" & Format(CDate(txtLastDateTransaction.Text), "yyyy-MM-dd") & "';" : com.ExecuteNonQuery()
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim strproduct As String = ""
                Me.Cursor = Cursors.WaitCursor
                For Each word In .Rows(cnt)("productid").ToString().Split(New Char() {"|"c})
                    strproduct = strproduct + " `" & txtPARTable.Text & "`.loanprod='" & word & "' or "
                Next
                strproduct = strproduct.Remove(strproduct.Count - 3, 3)
                com.CommandText = "insert into tblaosummary select distinct(`Account Officer`) as ao, branch,groupname,'" & Format(CDate(txtLastDateTransaction.Text), "yyyy-MM-dd") & "',`areagroup` from tbl_masterlist0" & .Rows(cnt)("id").ToString() & ";" : com.ExecuteNonQuery()
            End With
        Next

        dst = New DataSet
        msda = New MySqlDataAdapter("SELECT id,productid,daysinterval,groupname from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'  order by groupname asc;", conn)
        msda.Fill(dst, 0)
        com.CommandText = "CREATE TABLE IF NOT EXISTS  `tblparredaccsumlist` ( `parreddate` DATE NOT NULL,  `ao` varchar(100) NOT NULL,  `branch` varchar(100) NOT NULL,  `groupname` varchar(100) NOT NULL,  `accdelinquent` bigint(21) DEFAULT NULL,  `ttldelinquent` double(19,2) NOT NULL DEFAULT '0.00',  `accpastdue` bigint(21) DEFAULT NULL,  `ttlaccpastdue` double(19,2) NOT NULL DEFAULT '0.00',  `accounts` bigint(21) DEFAULT NULL,  `ttlpar` double(19,2) NOT NULL DEFAULT '0.00',`branchgroup` varchar(50) NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        com.CommandText = "DELETE from tblparredaccsumlist where parreddate='" & ConvertDate(txtLastDateTransaction.Text) & "' and branchgroup='" & txtbranchgroup.Text & "'" : com.ExecuteNonQuery()
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                com.CommandText = "insert into `tblparredaccsumlist` select '" & ConvertDate(txtLastDateTransaction.Text) & "', ao,branch,groupname," _
                                        + " (select count(*) from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where `Account Status`='DELINQUENT'  and `Account Officer` = tblaosummary.ao and groupname=tblaosummary.groupname and branch = tblaosummary.branch) as 'accdelinquent', " _
                                        + " ifnull((select sum(`Principal Balance`) from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where `Account Status`='DELINQUENT'  and `Account Officer` = tblaosummary.ao and groupname=tblaosummary.groupname and branch = tblaosummary.branch),0) as 'ttldelinquent', " _
                                        + " (select count(*) from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where `Account Status`='PAST DUE'  and `Account Officer` = tblaosummary.ao and groupname=tblaosummary.groupname and branch = tblaosummary.branch) as 'accpastdue', " _
                                        + " ifnull((select sum(`Principal Balance`) from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where `Account Status`='PAST DUE'  and `Account Officer` = tblaosummary.ao and groupname=tblaosummary.groupname and branch = tblaosummary.branch),0) as 'ttlaccpastdue', " _
                                        + " (select count(*) from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where `Account Officer` = tblaosummary.ao and groupname=tblaosummary.groupname and branch = tblaosummary.branch) as 'accounts', " _
                                        + " ifnull((select sum(`Principal Balance`) from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where `Account Officer` = tblaosummary.ao and groupname=tblaosummary.groupname and branch = tblaosummary.branch),0) as 'ttlpar','" & txtbranchgroup.Text & "', areagroup " _
                                        + " from tblaosummary  where groupname='" & .Rows(cnt)("groupname").ToString() & "' and datesummary='" & Format(CDate(txtLastDateTransaction.Text), "yyyy-MM-dd") & "' order by ao;" : com.ExecuteNonQuery()
            End With
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub loadaoportfoliowithpar()
        dst = New DataSet
        msda = New MySqlDataAdapter("SELECT id,productid,daysinterval,groupname from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'  order by groupname asc;", conn)
        msda.Fill(dst, 0)
        com.CommandText = "CREATE TABLE IF NOT EXISTS `tblportfoliowithpar` (`parreddate` DATE NOT NULL,  `refno` char(15) NOT NULL DEFAULT '',  `loanprod` char(20) NOT NULL DEFAULT '',  `product` varchar(100) DEFAULT NULL,  `officer` varchar(101) DEFAULT NULL,  `principal` double(18,2) NOT NULL DEFAULT '0.00',  `pribal` double(18,2) NOT NULL DEFAULT '0.00',  `branch` varchar(50) DEFAULT NULL,  `groupname` varchar(50) NOT NULL DEFAULT '',`branchgroup` varchar(50) NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        com.CommandText = "DELETE from tblportfoliowithpar where parreddate='" & ConvertDate(txtLastDateTransaction.Text) & "' and branchgroup='" & txtbranchgroup.Text & "'" : com.ExecuteNonQuery()
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim strproduct As String = "" : Dim curraccount As String = ""
                Dim daysdel As Integer = 0
                Dim RFullDate As String = ConvertDate(txtLastDateTransaction.Text)
                Me.Cursor = Cursors.WaitCursor
                For Each word In .Rows(cnt)("productid").ToString().Split(New Char() {"|"c})
                    strproduct = strproduct + " `" & txtPARTable.Text & "`.loanprod='" & word & "' or "
                Next
                strproduct = strproduct.Remove(strproduct.Count - 3, 3)
                com.CommandText = "INSERT INTO tblportfoliowithpar SELECT '" & ConvertDate(txtLastDateTransaction.Text) & "',refno,loanprod, prodname , " _
                                    + " if(ao='NO AO','NO OFFICER INCHARGE',ao) ,principal,  pribal, " _
                                    + "  ucase(branchname), " _
                                    + " '" & .Rows(cnt)("groupname").ToString() & "','" & txtbranchgroup.Text & "','', centername,(select category from master.branches where branchcode = par.`" & txtPARTable.Text & "`.branchcode) " _
                                    + " FROM par.`" & txtPARTable.Text & "` where pribal > 0.00 and  " _
                                    + " (" & strproduct & ")  order by branchname,ao,cname asc; " : com.ExecuteNonQuery()
            End With
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub loadaoParredSummary()
        Me.Cursor = Cursors.WaitCursor
        LoadXgrid("SELECT tblportfoliowithpar.officer as 'Account Officer', " _
                                    + " tblportfoliowithpar.branch as 'Branch', " _
                                    + " tblportfoliowithpar.groupname as 'Product Group', " _
                                    + " ifnull((select sum(accdelinquent) from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0) as 'Delinquent Accounts', " _
                                    + " ifnull((select sum(ttldelinquent) from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0.00) as 'Total Delinquents', " _
                                    + " ifnull((select sum(accpastdue)  from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0) as 'Past Due Accounts',  " _
                                    + " ifnull((select sum(ttlaccpastdue)  from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0.00) as 'Total Past Due', " _
                                    + " ifnull((select sum(accounts)  from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0) as 'PAR Accounts', " _
                                    + " ifnull((select sum(ttlpar)  from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0.00) as 'Total PAR', " _
                                    + " count(refno) as 'Active Accounts', " _
                                    + " sum(pribal) as 'Portfolio', " _
                                    + " ifnull(round((ifnull((select sum(ttlpar)  from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0.00)/sum(pribal)) * 100,2),0.00) as 'PAR Ratio', " _
                                    + " tblportfoliowithpar.areagroup as 'Area Group' " _
                                    + " FROM `tblportfoliowithpar`  where tblportfoliowithpar.parreddate='" & ConvertDate(txtLastDateTransaction.Text) & "' " _
                                    + " group by branch,officer,groupname order by ifnull(round((ifnull((select sum(ttlpar)  from tblparredaccsumlist where branch = tblportfoliowithpar.branch and ao = tblportfoliowithpar.officer and groupname = tblportfoliowithpar.groupname and parreddate =tblportfoliowithpar.parreddate),0.00)/sum(pribal)) * 100,2),0.00);", "`tblportfoliowithpar`", Em, gridview1, Me)

        XgridColAlign("Delinquent Accounts", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColCurrency("Total Delinquents", gridview1)

        XgridColAlign("Past Due Accounts", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColCurrency("Total Past Due", gridview1)

        XgridColAlign("PAR Accounts", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColCurrency("Total PAR", gridview1)

        XgridColAlign("Active Accounts", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColCurrency("Portfolio", gridview1)

        XgridColAlign("PAR Ratio", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColCurrency("PAR Ratio", gridview1)

        Dim item0 As New GridGroupSummaryItem()
        item0.FieldName = "Total Delinquents"
        item0.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item0.DisplayFormat = "{0:n}"
        item0.ShowInGroupColumnFooter = gridview1.Columns("Total Delinquents")
        gridview1.GroupSummary.Add(item0)

        Dim item1 As New GridGroupSummaryItem()
        item1.FieldName = "Total Past Due"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "{0:n}"
        item1.ShowInGroupColumnFooter = gridview1.Columns("Total Past Due")
        gridview1.GroupSummary.Add(item1)

        Dim item2 As New GridGroupSummaryItem()
        item2.FieldName = "Total PAR"
        item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item2.DisplayFormat = "{0:n}"
        item2.ShowInGroupColumnFooter = gridview1.Columns("Total PAR")
        gridview1.GroupSummary.Add(item2)

        Dim item3 As New GridGroupSummaryItem()
        item3.FieldName = "Portfolio"
        item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item3.DisplayFormat = "{0:n}"
        item3.ShowInGroupColumnFooter = gridview1.Columns("Portfolio")
        gridview1.GroupSummary.Add(item3)

        gridview1.Columns("Total Delinquents").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Total Delinquents").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Total Delinquents").SummaryItem.Tag = 1
        CType(gridview1.Columns("Total Delinquents").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Total Past Due").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Total Past Due").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Total Past Due").SummaryItem.Tag = 1
        CType(gridview1.Columns("Total Past Due").View, GridView).OptionsView.ShowFooter = True


        gridview1.Columns("Total PAR").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Total PAR").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Total PAR").SummaryItem.Tag = 1
        CType(gridview1.Columns("Total PAR").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Portfolio").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Portfolio").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Portfolio").SummaryItem.Tag = 1
        CType(gridview1.Columns("Portfolio").View, GridView).OptionsView.ShowFooter = True


        Dim view As ColumnView = gridview1
        Dim branches As String = qrysingledata("str", "group_concat(distinct(branch)) as str", "where parreddate='" & ConvertDate(txtLastDateTransaction.Text) & "'", "tblportfoliowithpar")
        If branches <> "" Then

            For Each splBranch In branches.Split(New Char() {","c})
                If Not Directory.Exists(dir.Text & "\" & ConvertDate(txtLastDateTransaction.Text) & "\" & splBranch) Then
                    Directory.CreateDirectory(dir.Text & "\" & ConvertDate(txtLastDateTransaction.Text) & "\" & splBranch)
                End If

                Dim report As New rptOtherReport()
                report.txttitle.Text = UCase("PORTFOLIO SUMMARY OF " & splBranch & " AS OF " & txtLastDateTransaction.Text)
                gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "'"
                report.Landscape = True
                report.PaperKind = System.Drawing.Printing.PaperKind.A2
                report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
                report.ExportToXlsx(dir.Text & "\" & ConvertDate(txtLastDateTransaction.Text) & "\" & splBranch & "\PORTFOLIO SUMMARY LIST.xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
            Next
        End If
        Me.Cursor = Cursors.Default
        gridview1.Dispose()
    End Sub

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles gridview1.RowCellStyle
        Dim View As GridView = sender
        If Not View.Columns("Account Status") Is Nothing Or Not View.Columns("Principal Balance") Is Nothing Then
            Dim stats As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Account Status"))
            Dim pribal As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Principal Balance"))
            If stats = "PAST DUE" And pribal <> 0 Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If

        If Not View.Columns("PAR Ratio") Is Nothing Then
            Dim ratio As Double = Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("PAR Ratio")))
            Dim ao As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Account Officer"))
            If ratio > 3 Then
                e.Appearance.ForeColor = Color.Red
            End If
            If ao = "NO OFFICER INCHARGE" Then
                e.Appearance.ForeColor = Color.White
                e.Appearance.BackColor = Color.Red
            End If
        End If
    End Sub
    Private Sub frmMasterList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SkinManager.EnableMdiFormSkins()
        reportcount(Me.Name.ToString)
        SetIcon()
        ' LoadToComboBox("prodname", "master.par.`" & txtPARTable.text & "` inner join master.loanprod on loanprod.prodcode= par.`" & txtPARTable.text & "`.loanprod where master.par.`" & txtPARTable.text & "`.cancelled=0", txtproduct, True)
 
        rptsettings = ""
        LoadParTable()
        LoadGroupProduct()
        ViewGridtype(gridview1)
        LoadSummary()
    End Sub
    Public Sub LoadParTable()
        txtPARTable.Properties.Items.Clear()
        com.CommandText = "show tables from par" : rst = com.ExecuteReader
        While rst.Read
            txtPARTable.Properties.Items.Add(rst("Tables_in_par").ToString)
        End While
        rst.Close()
    End Sub
    Public Sub LoadSummary()
        Dim Coll As ComboBoxItemCollection = txtdateGenerated.Properties.Items
        txtdateGenerated.Properties.Items.Clear()
        txtconsodate2.Properties.Items.Clear()
        txtDateConsolidated.Properties.Items.Clear()
        com.CommandText = "select distinct(date_format(parreddate,'%Y-%m-%d')) as dt from tblparredaccsumlist" : rst = com.ExecuteReader()
        While rst.Read
            txtdateGenerated.Properties.Items.Add(rst("dt"))
            txtconsodate2.Properties.Items.Add(rst("dt"))
            txtDateConsolidated.Properties.Items.Add(rst("dt"))
        End While
        rst.Close()

        txtTrendingYear.Properties.Items.Clear()
        com.CommandText = "select distinct date_format(parreddate,'%Y') as dy from tblparredaccsumlist" : rst = com.ExecuteReader()
        While rst.Read
            txtTrendingYear.Properties.Items.Add(rst("dy"))
        End While
        rst.Close()
    End Sub
    Public Sub LoadGroupProduct()
        LoadXgridLookupSearch("SELECT distinct(branchgroup) as 'Branch Group',group_concat(groupname) as productGroup  from tblproductgroup group by branchgroup", "tblproductgroup", txtbranchgroup, gridGroupProduct, Me)
        gridGroupProduct.Columns("productGroup").Visible = False
    End Sub
    Private Sub txtbranchgroup_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbranchgroup.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtbranchgroup.Properties.View.FocusedRowHandle.ToString)
        productgroup.Text = txtbranchgroup.Properties.View.GetFocusedRowCellValue("productGroup").ToString()
        txtbranchgroup.Text = txtbranchgroup.Properties.View.GetFocusedRowCellValue("Branch Group").ToString()
        If txtbranchgroup.Text = "" Then Exit Sub
        LoadXgrid("select groupname as 'Product group' from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'", "tblproductgroup", Em2, GridView2, Me)

    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClose.ItemClick
        Me.Close()
    End Sub

    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
        Dim report As New rptPrintWithHeader
        If mode.text = "details" Then
            report.txttitle.Text = UCase("CONSOLIDATED PAR DETAILS AS OF " & txtDateConsolidated.Text)
        ElseIf mode.text = "product" Then
            report.txttitle.Text = UCase(txtProductGroup.Text & " CONSOLIDATED PAR AS OF " & txtDateConsolidated.Text)
        ElseIf mode.text = "summary" Then
            report.txttitle.Text = UCase("CONSOLIDATED PAR SUMMARY AS OF " & txtDateConsolidated.Text)
        ElseIf mode.Text = "trending" Then
            If RadTrending.EditValue = "tb" Then
                report.txttitle.Text = UCase("PAR TRENDING BY BRANCH PERIOD FROM " & txtTrendingFrom.Text & " TO " & txtTrendingTo.Text & " " & txtTrendingYear.Text)
            Else
                report.txttitle.Text = UCase("PAR TRENDING BY PPRODUCT PERIOD FROM " & txtTrendingFrom.Text & " TO " & txtTrendingTo.Text & " " & txtTrendingYear.Text)
            End If

        End If

        ' report.Landscape = True
        report.PaperKind = System.Drawing.Printing.PaperKind.Letter
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.gridctrl_consolidated))
        'report.ExportToXlsx(fbd.SelectedPath & "\" & txtProductGroup.Text & " CONSOLIDATED PAR AS OF " & txtDateConsolidated.Text & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
        Me.Cursor = Cursors.Default
        'XtraMessageBox.Show("Data successfully Generated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.WindowState = FormWindowState.Minimized
        report.ShowRibbonPreviewDialog()
        Me.WindowState = FormWindowState.Normal
    End Sub


    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtbranchgroup.Text = "" Then
            XtraMessageBox.Show("Please Select branch group!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtbranchgroup.Focus()
            Exit Sub
        End If
        If XtraMessageBox.Show("Bigger data takes to much longer to query! Are you sure you want to continue?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            GenerateMasterList()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If txtdateGenerated.Text = "" Then
            XtraMessageBox.Show("Please Select date transaction summary!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtdateGenerated.Focus()
            Exit Sub
        End If
        Try
            Dim fbd As New System.Windows.Forms.FolderBrowserDialog
            Dim tblparredaccsumlist As String = ""
            Dim tblportfoliowithpar As String = ""
            If radExportType.SelectedIndex = 0 Then
                Dim saveFileDialog1 As New SaveFileDialog()
                saveFileDialog1.Filter = "Parred Summary File (*.psf)|*.psf|All files (*.*)|*.*"
                saveFileDialog1.FileName = "parred summary file " & txtdateGenerated.Text & ".psf"
                saveFileDialog1.FilterIndex = 2
                saveFileDialog1.RestoreDirectory = True
                If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    ProgressBarControl1.Visible = True
                    Dim detailsFile As StreamWriter = Nothing
                    ProgressBarControl1.Properties.Step = 1
                    ProgressBarControl1.Properties.PercentView = True
                    ProgressBarControl1.Properties.Maximum = countqry("tblparredaccsumlist", "parreddate='" & txtdateGenerated.Text & "'") + countqry("tblportfoliowithpar", "parreddate='" & txtdateGenerated.Text & "'") + 2
                    ProgressBarControl1.Properties.Minimum = 0
                    ProgressBarControl1.Position = 0

                    If System.IO.File.Exists(saveFileDialog1.FileName) = True Then
                        System.IO.File.Delete(saveFileDialog1.FileName)
                    End If

                    Dim objWriter As New System.IO.StreamWriter(saveFileDialog1.FileName)

                    com.CommandText = "select distinct(branchgroup) as 'branchgroup' from tblparredaccsumlist where parreddate='" & txtdateGenerated.Text & "'" : rst = com.ExecuteReader
                    While rst.Read
                        tblparredaccsumlist = "delete from tblparredaccsumlist where parreddate='" & txtdateGenerated.Text & "' and branchgroup='" & rst("branchgroup").ToString & "';"
                        objWriter.WriteLine(tblparredaccsumlist)
                        ProgressBarControl1.PerformStep()
                        ProgressBarControl1.Update()
                    End While
                    rst.Close()

                    com.CommandText = "select * from tblparredaccsumlist where parreddate='" & txtdateGenerated.Text & "'" : rst = com.ExecuteReader
                    While rst.Read
                        tblparredaccsumlist = "insert into tblparredaccsumlist set parreddate='" & ConvertDate(rst("parreddate").ToString) & "', ao='" & rst("ao").ToString & "', branch='" & rst("branch").ToString & "', groupname='" & rst("groupname").ToString & "', accdelinquent='" & rst("accdelinquent").ToString & "', ttldelinquent='" & rst("ttldelinquent").ToString & "', accpastdue='" & rst("accpastdue").ToString & "', ttlaccpastdue='" & rst("ttlaccpastdue").ToString & "', accounts='" & rst("accounts").ToString & "', ttlpar='" & rst("ttlpar").ToString & "', branchgroup='" & rst("branchgroup").ToString & "',areagroup='" & rst("areagroup").ToString & "';"
                        objWriter.WriteLine(tblparredaccsumlist)
                        ProgressBarControl1.PerformStep()
                        ProgressBarControl1.Update()
                    End While
                    rst.Close()

                    '#------------------------------ list ---------------------------
                    com.CommandText = "select distinct(branchgroup) as 'branchgroup' from tblportfoliowithpar where parreddate='" & txtdateGenerated.Text & "'" : rst = com.ExecuteReader
                    While rst.Read
                        tblportfoliowithpar = "delete from tblportfoliowithpar where parreddate='" & txtdateGenerated.Text & "' and branchgroup='" & rst("branchgroup").ToString & "';"
                        objWriter.WriteLine(tblportfoliowithpar)
                        ProgressBarControl1.PerformStep()
                        ProgressBarControl1.Update()
                    End While
                    rst.Close()

                    com.CommandText = "select * from tblportfoliowithpar where parreddate='" & txtdateGenerated.Text & "'" : rst = com.ExecuteReader
                    While rst.Read
                        tblportfoliowithpar = "insert into tblportfoliowithpar set parreddate='" & ConvertDate(rst("parreddate").ToString) & "', refno='" & rst("refno").ToString & "', loanprod='" & rst("loanprod").ToString & "', product='" & rst("product").ToString & "', officer='" & rst("officer").ToString & "', principal='" & rst("principal").ToString & "', pribal='" & rst("pribal").ToString & "', branch='" & rst("branch").ToString & "', groupname='" & rst("groupname").ToString & "', branchgroup='" & rst("branchgroup").ToString & "', custcode='" & rst("custcode").ToString & "', centername='" & rst("centername").ToString & "',areagroup='" & rst("areagroup").ToString & "' ;"
                        objWriter.WriteLine(tblportfoliowithpar)
                        ProgressBarControl1.PerformStep()
                        ProgressBarControl1.Update()
                    End While
                    rst.Close()
                    objWriter.Close()
                    Me.Cursor = Cursors.Default
                    XtraMessageBox.Show("Data successfully exported", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ProgressBarControl1.Visible = False
                End If
            Else
                If fbd.ShowDialog() = DialogResult.OK Then
                    dir.Text = fbd.SelectedPath
                    loadaoParredSummary()
                End If
            End If

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message, vbCrLf _
                         & "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim sqlpath As String = ""
        Dim objOpenFileDialog As New OpenFileDialog
        'Set the Open dialog properties
        With objOpenFileDialog
            .Filter = "Parred Summary File (*.psf)|*.psf|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Open File Dialog"
        End With

        'Show the Open dialog and if the user clicks the Open button,
        'load the file
        If objOpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim allText As String
            Try
                'Read the contents of the file
                allText = My.Computer.FileSystem.GetParentPath(objOpenFileDialog.FileName)
                'Display the file contents in the TextBox
                sqlpath = objOpenFileDialog.FileName
            Catch fileException As Exception
                Throw fileException
            End Try
            objOpenFileDialog.Dispose()
            objOpenFileDialog = Nothing
            If XtraMessageBox.Show("Are you sure you want to import parred summary file?" & globaluser & "@" & globalfullname & " on " & globaldate & " - " & GlobalTime() & ") ?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If sqlpath <> "" Then
                    ReadFile(sqlpath)
                    frmImportRecords.ShowDialog(Me)
                End If
            End If
        End If
    End Sub
    Public Function ReadFile(ByVal path As String)
        Me.Cursor = Cursors.WaitCursor
        Dim oReader As StreamReader
        oReader = New StreamReader(path, True)
        frmImportRecords.txtsqlQuery.Text = oReader.ReadToEnd
        ProgressBarControl1.Visible = False
        Me.Cursor = Cursors.Default
        Return 0
    End Function

    Private Sub txtDateConsolidated_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDateConsolidated.SelectedIndexChanged
        LoadProductGroup()
    End Sub
    Public Sub LoadProductGroup()
        LoadXgridLookupSearch("SELECT distinct(groupname) as 'Product Group' from tblportfoliowithpar where parreddate='" & txtDateConsolidated.Text & "'", "tblportfoliowithpar", txtProductGroup, gv_productGroup, Me)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtDateConsolidated.Text = "" Then
            XtraMessageBox.Show("Please Select Date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDateConsolidated.Focus()
            Exit Sub
        ElseIf txtProductGroup.Text = "" Then
            XtraMessageBox.Show("Please Select Product!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProductGroup.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If ck_forAo.Checked = True Then
            LoadXgrid("SELECT tblparredaccsumlist.branch as 'Branch', ifnull(ao, 'NO OFFICER') as 'Account Officer',  (select count(*) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate and officer = tblparredaccsumlist.ao) as 'Outreach (Cur/Past)', " _
                 + " (select sum(pribal) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate  and officer = tblparredaccsumlist.ao)  as 'Portfolio', " _
                 + " sum(ttlpar) as 'Total PAR', " _
                 + " ifnull(round((sum(ttlpar)/(select sum(pribal) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate  and officer = tblparredaccsumlist.ao) ) * 100,2),0.00)  as 'PAR Ratio', " _
                 + " (select count(distinct(centername)) FROM `tblportfoliowithpar` where  tblportfoliowithpar.groupname='" & txtProductGroup.Text & "' and tblportfoliowithpar.branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate and centername is not null  and officer = tblparredaccsumlist.ao) as 'Centers', areagroup as 'Area Group' FROM `tblparredaccsumlist` " _
               + " where  tblparredaccsumlist.parreddate='" & txtDateConsolidated.Text & "' and tblparredaccsumlist.groupname='" & txtProductGroup.Text & "' " _
               + " group by tblparredaccsumlist.branch,ao order by tblparredaccsumlist.branch asc;", "`tblparredaccsumlist`", gridctrl_consolidated, gv_consolidated, Me)

        Else
            LoadXgrid("SELECT tblparredaccsumlist.branch as 'Branch', (select count(*) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate) as 'Outreach (Cur/Past)', " _
                 + " (select sum(pribal) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate)  as 'Portfolio', " _
                 + " sum(ttlpar) as 'Total PAR', " _
                 + " ifnull(round((sum(ttlpar)/(select sum(pribal) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate) ) * 100,2),0.00)  as 'PAR Ratio', " _
                 + " (select count(distinct(officer)) from tblportfoliowithpar where groupname='" & txtProductGroup.Text & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate) as 'AO/PO', " _
                 + " (select count(distinct(centername)) FROM `tblportfoliowithpar` where  tblportfoliowithpar.groupname='" & txtProductGroup.Text & "' and tblportfoliowithpar.branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate and centername is not null) as 'Centers', areagroup as 'Area Group' FROM `tblparredaccsumlist` " _
               + " where  tblparredaccsumlist.parreddate='" & txtDateConsolidated.Text & "' and tblparredaccsumlist.groupname='" & txtProductGroup.Text & "' " _
               + " group by tblparredaccsumlist.branch order by tblparredaccsumlist.branch asc;", "`tblparredaccsumlist`", gridctrl_consolidated, gv_consolidated, Me)
        End If
       
      
        XgridColAlign("Outreach (Cur/Past)", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("PAR Ratio", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)

        If ck_forAo.Checked = False Then
            XgridColAlign("AO/PO", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)
        End If

        XgridColAlign("Centers", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)

        XgridColCurrency("Total PAR", gv_consolidated)
        XgridColCurrency("Portfolio", gv_consolidated)
        XgridColCurrency("PAR Ratio", gv_consolidated)
        'gv_consolidated.BestFitColumns()


        Dim item1 As New GridGroupSummaryItem()
        item1.FieldName = "Outreach (Cur/Past)"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "{0:N0}"
        item1.ShowInGroupColumnFooter = gv_consolidated.Columns("Outreach (Cur/Past)")
        gv_consolidated.GroupSummary.Add(item1)

        Dim item2 As New GridGroupSummaryItem()
        item2.FieldName = "Total PAR"
        item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item2.DisplayFormat = "{0:n}"
        item2.ShowInGroupColumnFooter = gv_consolidated.Columns("Total PAR")
        gv_consolidated.GroupSummary.Add(item2)

        Dim item3 As New GridGroupSummaryItem()
        item3.FieldName = "Portfolio"
        item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item3.DisplayFormat = "{0:n}"
        item3.ShowInGroupColumnFooter = gv_consolidated.Columns("Portfolio")
        gv_consolidated.GroupSummary.Add(item3)

        Dim item4 As New GridGroupSummaryItem()
        item4.FieldName = "Centers"
        item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item4.DisplayFormat = "{0:N0}"
        item4.ShowInGroupColumnFooter = gv_consolidated.Columns("Centers")
        gv_consolidated.GroupSummary.Add(item4)

        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.DisplayFormat = "{0:N0}"
        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Outreach (Cur/Past)").View, GridView).OptionsView.ShowFooter = True

        gv_consolidated.Columns("Total PAR").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Total PAR").SummaryItem.DisplayFormat = "{0:n}"
        gv_consolidated.Columns("Total PAR").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Total PAR").View, GridView).OptionsView.ShowFooter = True

        gv_consolidated.Columns("Portfolio").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Portfolio").SummaryItem.DisplayFormat = "{0:n}"
        gv_consolidated.Columns("Portfolio").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Portfolio").View, GridView).OptionsView.ShowFooter = True

        Dim total As String = Format((Val(CC(gv_consolidated.Columns("Total PAR").SummaryText)) / Val(CC(gv_consolidated.Columns("Portfolio").SummaryText))) * 100, "0.00")
        gv_consolidated.Columns("PAR Ratio").SummaryItem.SummaryType = SummaryItemType.Custom
        gv_consolidated.Columns("PAR Ratio").SummaryItem.DisplayFormat = total & "%"
        gv_consolidated.Columns("PAR Ratio").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("PAR Ratio").View, GridView).OptionsView.ShowFooter = True

        If ck_forAo.Checked = False Then
            gv_consolidated.Columns("AO/PO").SummaryItem.SummaryType = SummaryItemType.Sum
            gv_consolidated.Columns("AO/PO").SummaryItem.DisplayFormat = "{0:N0}"
            gv_consolidated.Columns("AO/PO").SummaryItem.Tag = 1
            CType(gv_consolidated.Columns("AO/PO").View, GridView).OptionsView.ShowFooter = True
        End If

        gv_consolidated.Columns("Centers").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Centers").SummaryItem.DisplayFormat = "{0:N0}"
        gv_consolidated.Columns("Centers").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Centers").View, GridView).OptionsView.ShowFooter = True
        Me.Cursor = Cursors.Default

        XtraTabControl1.SelectedTabPage = tabResult
        mode.Text = "product"
    End Sub

  
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If txtconsodate2.Text = "" Then
            XtraMessageBox.Show("Please Select Date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtconsodate2.Focus()
            Exit Sub
        End If
        LoadXgrid("SELECT tblportfoliowithpar.branch as 'Branch', " _
                           + " groupname as 'Product Group', " _
                           + " count(*) 'Outreach (Cur/Past)', " _
                           + " sum(pribal)   as 'Portfolio', " _
                           + " ifnull((select sum(ttlpar) from tblparredaccsumlist where branch = tblportfoliowithpar.branch and parreddate=tblportfoliowithpar.parreddate and groupname = tblportfoliowithpar.groupname),0) as 'Total PAR', " _
                           + " ifnull(round(((select sum(ttlpar) from tblparredaccsumlist where branch = tblportfoliowithpar.branch and parreddate=tblportfoliowithpar.parreddate and groupname = tblportfoliowithpar.groupname )/ sum(pribal) ) * 100,2),0.00)  as 'PAR Ratio',areagroup as 'Area Group' " _
                           + " FROM `tblportfoliowithpar` where  tblportfoliowithpar.parreddate='" & txtconsodate2.Text & "' group by  branch,groupname order by ifnull(round(((select sum(ttlpar) from tblparredaccsumlist where branch = tblportfoliowithpar.branch and parreddate=tblportfoliowithpar.parreddate and groupname = tblportfoliowithpar.groupname )/ sum(pribal) ) * 100,2),0.00) asc;", "`tblparredaccsumlist`", gridctrl_consolidated, gv_consolidated, Me)

      
        XgridColAlign("Outreach (Cur/Past)", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("PAR Ratio", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)

        XgridColCurrency("Total PAR", gv_consolidated)
        XgridColCurrency("Portfolio", gv_consolidated)
        XgridColCurrency("PAR Ratio", gv_consolidated)
        'gv_consolidated.BestFitColumns()


        Dim item1 As New GridGroupSummaryItem()
        item1.FieldName = "Outreach (Cur/Past)"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "{0:N0}"
        item1.ShowInGroupColumnFooter = gv_consolidated.Columns("Outreach (Cur/Past)")
        gv_consolidated.GroupSummary.Add(item1)

        Dim item2 As New GridGroupSummaryItem()
        item2.FieldName = "Total PAR"
        item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item2.DisplayFormat = "{0:n}"
        item2.ShowInGroupColumnFooter = gv_consolidated.Columns("Total PAR")
        gv_consolidated.GroupSummary.Add(item2)

        Dim item3 As New GridGroupSummaryItem()
        item3.FieldName = "Portfolio"
        item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item3.DisplayFormat = "{0:n}"
        item3.ShowInGroupColumnFooter = gv_consolidated.Columns("Portfolio")
        gv_consolidated.GroupSummary.Add(item3)


        Dim item5 As New GridGroupSummaryItem()
        item5.FieldName = "PAR Ratio"
        item5.Tag = 1
        item5.DisplayFormat = "{0}"
        item5.SummaryType = DevExpress.Data.SummaryItemType.Custom
        item5.ShowInGroupColumnFooter = gv_consolidated.Columns("PAR Ratio")
        gv_consolidated.GroupSummary.Add(item5)

        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.DisplayFormat = "{0:N0}"
        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Outreach (Cur/Past)").View, GridView).OptionsView.ShowFooter = True

        gv_consolidated.Columns("Total PAR").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Total PAR").SummaryItem.DisplayFormat = "{0:n}"
        gv_consolidated.Columns("Total PAR").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Total PAR").View, GridView).OptionsView.ShowFooter = True

        gv_consolidated.Columns("Portfolio").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Portfolio").SummaryItem.DisplayFormat = "{0:n}"
        gv_consolidated.Columns("Portfolio").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Portfolio").View, GridView).OptionsView.ShowFooter = True

        Dim total As String = Format((Val(CC(gv_consolidated.Columns("Total PAR").SummaryText)) / Val(CC(gv_consolidated.Columns("Portfolio").SummaryText))) * 100, "0.00")
        gv_consolidated.Columns("PAR Ratio").SummaryItem.SummaryType = SummaryItemType.Custom
        gv_consolidated.Columns("PAR Ratio").SummaryItem.DisplayFormat = total & "%"
        gv_consolidated.Columns("PAR Ratio").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("PAR Ratio").View, GridView).OptionsView.ShowFooter = True

        XtraTabControl1.SelectedTabPage = tabResult
        mode.Text = "details"
        'End If
    End Sub

    Private Sub GridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs)
        Dim Value1 As Double = 0 : Dim Value2 As Double = 0
        Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, GridSummaryItem)).Tag)
        Dim View As GridView = TryCast(sender, GridView)

        If e.SummaryProcess = CustomSummaryProcess.Finalize Then
            'If View.Name = "colParRatio" Then
            Value1 = CDbl(gv_consolidated.GetGroupSummaryValue(e.GroupRowHandle, TryCast(gv_consolidated.GroupSummary(1), GridGroupSummaryItem)))
            Value2 = CDbl(gv_consolidated.GetGroupSummaryValue(e.GroupRowHandle, TryCast(gv_consolidated.GroupSummary(2), GridGroupSummaryItem)))
            e.TotalValue = FormatNumber((Value1 / Value2) * 100, 2) & "%"
        End If

    End Sub


    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If txtconsodate2.Text = "" Then
            XtraMessageBox.Show("Please Select Date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtconsodate2.Focus()
            Exit Sub
        End If
        LoadXgrid("SELECT groupname as 'Product Group', " _
                           + " count(*) 'Outreach (Cur/Past)', " _
                           + " sum(pribal)   as 'Portfolio', " _
                           + " ifnull((select sum(ttlpar) from tblparredaccsumlist where parreddate=tblportfoliowithpar.parreddate and groupname = tblportfoliowithpar.groupname),0) as 'Total PAR', " _
                           + " ifnull(round(((select sum(ttlpar) from tblparredaccsumlist where parreddate=tblportfoliowithpar.parreddate and groupname = tblportfoliowithpar.groupname )/ sum(pribal) ) * 100,2),0.00)  as 'PAR Ratio',areagroup as 'Area Group' " _
                           + " FROM `tblportfoliowithpar` where  tblportfoliowithpar.parreddate='" & txtconsodate2.Text & "' group by groupname order by ifnull(round(((select sum(ttlpar) from tblparredaccsumlist where parreddate=tblportfoliowithpar.parreddate and groupname = tblportfoliowithpar.groupname )/ sum(pribal) ) * 100,2),0.00) asc;", "`tblparredaccsumlist`", gridctrl_consolidated, gv_consolidated, Me)

        XgridColAlign("Outreach (Cur/Past)", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("PAR Ratio", gv_consolidated, DevExpress.Utils.HorzAlignment.Center)

        XgridColCurrency("Total PAR", gv_consolidated)
        XgridColCurrency("Portfolio", gv_consolidated)
        XgridColCurrency("PAR Ratio", gv_consolidated)
        'gv_consolidated.BestFitColumns()


        Dim item1 As New GridGroupSummaryItem()
        item1.FieldName = "Outreach (Cur/Past)"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "{0:N0}"
        item1.ShowInGroupColumnFooter = gv_consolidated.Columns("Outreach (Cur/Past)")
        gv_consolidated.GroupSummary.Add(item1)

        Dim item2 As New GridGroupSummaryItem()
        item2.FieldName = "Total PAR"
        item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item2.DisplayFormat = "{0:n}"
        item2.ShowInGroupColumnFooter = gv_consolidated.Columns("Total PAR")
        gv_consolidated.GroupSummary.Add(item2)

        Dim item3 As New GridGroupSummaryItem()
        item3.FieldName = "Portfolio"
        item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item3.DisplayFormat = "{0:n}"
        item3.ShowInGroupColumnFooter = gv_consolidated.Columns("Portfolio")
        gv_consolidated.GroupSummary.Add(item3)


        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.DisplayFormat = "{0:N0}"
        gv_consolidated.Columns("Outreach (Cur/Past)").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Outreach (Cur/Past)").View, GridView).OptionsView.ShowFooter = True

        gv_consolidated.Columns("Total PAR").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Total PAR").SummaryItem.DisplayFormat = "{0:n}"
        gv_consolidated.Columns("Total PAR").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Total PAR").View, GridView).OptionsView.ShowFooter = True

        gv_consolidated.Columns("Portfolio").SummaryItem.SummaryType = SummaryItemType.Sum
        gv_consolidated.Columns("Portfolio").SummaryItem.DisplayFormat = "{0:n}"
        gv_consolidated.Columns("Portfolio").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("Portfolio").View, GridView).OptionsView.ShowFooter = True

        Dim total As String = Format((Val(CC(gv_consolidated.Columns("Total PAR").SummaryText)) / Val(CC(gv_consolidated.Columns("Portfolio").SummaryText))) * 100, "0.00")
        gv_consolidated.Columns("PAR Ratio").SummaryItem.SummaryType = SummaryItemType.Custom
        gv_consolidated.Columns("PAR Ratio").SummaryItem.DisplayFormat = total & "%"
        gv_consolidated.Columns("PAR Ratio").SummaryItem.Tag = 1
        CType(gv_consolidated.Columns("PAR Ratio").View, GridView).OptionsView.ShowFooter = True

        XtraTabControl1.SelectedTabPage = tabResult
        mode.Text = "summary"
    End Sub
  
    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Dim fbd As New System.Windows.Forms.SaveFileDialog

        If fbd.ShowDialog() = DialogResult.OK Then
            gv_consolidated.ExportToXlsx(fbd.FileName & ".xlsx")
        End If

    End Sub

    Private Sub cmdTrendingAction_Click(sender As Object, e As EventArgs) Handles cmdTrendingAction.Click
        If txtTrendingYear.Text = "" Then
            XtraMessageBox.Show("Please Select Year!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTrendingYear.Focus()
            Exit Sub
        ElseIf txtTrendingFrom.Text = "" Then
            XtraMessageBox.Show("Please Select period from!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTrendingFrom.Focus()
            Exit Sub
        ElseIf txtTrendingTo.Text = "" Then
            XtraMessageBox.Show("Please Select period to!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTrendingTo.Focus()
            Exit Sub
        End If
        ExecuteTrendingReport()
    End Sub
    Public Sub ExecuteTrendingReport()
        Dim FromMonth As Date = txtTrendingFrom.Text & " 01, " & txtTrendingYear.Text
        Dim ToMonth As Date = txtTrendingTo.Text & " 01, " & txtTrendingYear.Text
        Dim DateQuery As String = "'" & FromMonth.ToString("yyyy-MM") & "' and '" & ToMonth.ToString("yyyy-MM") & "'"

        Dim StrNumber As String = "" : Dim StrMonth As String = "" : Dim StrGridCaption As String = "" : Dim strColumn As String = ""
        'com.CommandText = "select distinct date_format(parreddate,'%M') as m,date_format(parreddate,'%m') as i from tblparredaccsumlist where date_format(parreddate,'%Y-%m') between " & DateQuery & " order by parreddate asc" : rst = com.ExecuteReader()
        com.CommandText = "select distinct date_format(parreddate,'%M') as m,(select date_format(parreddate,'%m-%d') from tblparredaccsumlist as getdate where date_format(getdate.parreddate,'%Y-%m') = date_format(a.parreddate,'%Y-%m') order by getdate.parreddate desc limit 1) as i from tblparredaccsumlist as a where date_format(a.parreddate,'%Y-%m') between " & DateQuery & ";" : rst = com.ExecuteReader()
        While rst.Read
            StrNumber = StrNumber + rst("i").ToString & ":"
            StrMonth = StrMonth + rst("m").ToString & ":"
            StrGridCaption = StrGridCaption + "'' as '" & rst("m").ToString & "',"
            strColumn = strColumn + rst("m").ToString + ","
        End While
        rst.Close()

        If StrNumber <> "" Then
            StrNumber = StrNumber.Remove(StrNumber.Length - 1, 1)
        End If
        If StrMonth <> "" Then
            StrMonth = StrMonth.Remove(StrMonth.Length - 1, 1)
        End If
        If StrGridCaption <> "" Then
            StrGridCaption = StrGridCaption.Remove(StrGridCaption.Length - 1, 1)
        End If
        If strColumn <> "" Then
            strColumn = strColumn.Remove(strColumn.Length - 1, 1)
        End If

        If RadTrending.EditValue = "tb" Then
            LoadXgrid("select distinct Branch, 'Outreach' as Description,  " & StrGridCaption & " from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & " " _
                    + " union select distinct branch, 'Portfolio', " & StrGridCaption & "  from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & " " _
                    + " union select distinct branch, 'PAR', " & StrGridCaption & "  from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & " " _
                    + " union select distinct branch, 'Ratio', " & StrGridCaption & "  from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & "", "tblportfoliowithpar", gridctrl_consolidated, gv_consolidated, Me)

            Dim word As String
            For Each word In StrNumber.Split(New Char() {":"c})
                dst = New DataSet

                msda = New MySqlDataAdapter("select Branch,date_format(parreddate,'%M') as 'm', count(refno) as 'Outreach', " _
                                                               + " sum(pribal) as 'Portfolio', " _
                                                               + " (select sum(ttlpar) from tblparredaccsumlist where date_format(parreddate,'%Y-%m-%d') = '" & txtTrendingYear.Text & "-" & word & "'  and branch = tblportfoliowithpar.branch)  as 'PAR', " _
                                                               + " ((select sum(ttlpar) from tblparredaccsumlist where date_format(parreddate,'%Y-%m-%d') = '" & txtTrendingYear.Text & "-" & word & "'   and branch = tblportfoliowithpar.branch)/ sum(pribal)) * 100 as 'Ratio' " _
                                                               + " from tblportfoliowithpar where date_format(parreddate,'%Y-%m-%d') = '" & txtTrendingYear.Text & "-" & word & "'  group by branch;", conn)

                msda.Fill(dst, 0)
                For cnt = 0 To dst.Tables(0).Rows.Count - 1
                    With (dst.Tables(0))
                        For I = 0 To gv_consolidated.RowCount - 1
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "Outreach" And gv_consolidated.GetRowCellValue(I, "Branch").ToString = .Rows(cnt)("Branch").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("Outreach").ToString()), "n"))
                            End If
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "Portfolio" And gv_consolidated.GetRowCellValue(I, "Branch").ToString = .Rows(cnt)("Branch").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("Portfolio").ToString()), "n"))
                            End If
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "PAR" And gv_consolidated.GetRowCellValue(I, "Branch").ToString = .Rows(cnt)("Branch").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("PAR").ToString()), "n"))
                            End If
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "Ratio" And gv_consolidated.GetRowCellValue(I, "Branch").ToString = .Rows(cnt)("Branch").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("Ratio").ToString()), "n"))
                            End If
                        Next
                    End With
                Next
            Next
            For Each word In strColumn.Split(New Char() {","c})
                XgridColCurrency(word, gv_consolidated)
                XgridColAlign(word, gv_consolidated, DevExpress.Utils.HorzAlignment.Far)
            Next
            gv_consolidated.Columns("Branch").Group()
            gv_consolidated.ExpandAllGroups()
            gv_consolidated.BestFitColumns()
            XtraTabControl1.SelectedTabPage = tabResult
            mode.Text = "trending"

        Else

            LoadXgrid("select distinct groupname as 'Product', 'Outreach' as Description,  " & StrGridCaption & " from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & " " _
                  + " union select distinct groupname, 'Portfolio', " & StrGridCaption & "  from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & " " _
                  + " union select distinct groupname, 'PAR', " & StrGridCaption & "  from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & " " _
                  + " union select distinct groupname, 'Ratio', " & StrGridCaption & "  from tblportfoliowithpar where date_format(parreddate,'%Y-%m') between " & DateQuery & "", "tblportfoliowithpar", gridctrl_consolidated, gv_consolidated, Me)

            Dim word As String
            For Each word In StrNumber.Split(New Char() {":"c})
                dst = New DataSet
                msda = New MySqlDataAdapter("select  groupname as 'Product',date_format(parreddate,'%M') as 'm', count(refno) as 'Outreach', " _
                                                + " sum(pribal) as 'Portfolio', " _
                                                + " (select sum(ttlpar) from tblparredaccsumlist where date_format(parreddate,'%Y-%m-%d') = '" & txtTrendingYear.Text & "-" & word & "'  and groupname = tblportfoliowithpar.groupname)  as 'PAR', " _
                                                + " ((select sum(ttlpar) from tblparredaccsumlist where date_format(parreddate,'%Y-%m-%d') = '" & txtTrendingYear.Text & "-" & word & "'   and groupname = tblportfoliowithpar.groupname)/ sum(pribal)) * 100 as 'Ratio' " _
                                                + " from tblportfoliowithpar where date_format(parreddate,'%Y-%m-%d') = '" & txtTrendingYear.Text & "-" & word & "'  group by groupname order by parreddate asc;", conn)
                msda.Fill(dst, 0)
                For cnt = 0 To dst.Tables(0).Rows.Count - 1
                    With (dst.Tables(0))
                        For I = 0 To gv_consolidated.RowCount - 1
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "Outreach" And gv_consolidated.GetRowCellValue(I, "Product").ToString = .Rows(cnt)("Product").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("Outreach").ToString()), "n"))
                            End If
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "Portfolio" And gv_consolidated.GetRowCellValue(I, "Product").ToString = .Rows(cnt)("Product").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("Portfolio").ToString()), "n"))
                            End If
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "PAR" And gv_consolidated.GetRowCellValue(I, "Product").ToString = .Rows(cnt)("Product").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("PAR").ToString()), "n"))
                            End If
                            If gv_consolidated.GetRowCellValue(I, "Description").ToString = "Ratio" And gv_consolidated.GetRowCellValue(I, "Product").ToString = .Rows(cnt)("Product").ToString() Then
                                gv_consolidated.SetRowCellValue(I, .Rows(cnt)("m").ToString(), Format(Val(.Rows(cnt)("Ratio").ToString()), "n"))
                            End If
                        Next
                    End With
                Next
            Next
            For Each word In strColumn.Split(New Char() {","c})
                XgridColCurrency(word, gv_consolidated)
                XgridColAlign(word, gv_consolidated, DevExpress.Utils.HorzAlignment.Far)
            Next
            gv_consolidated.Columns("Product").Group()
            gv_consolidated.ExpandAllGroups()
            gv_consolidated.BestFitColumns()
            XtraTabControl1.SelectedTabPage = tabResult
            mode.Text = "trending"

        End If
        

        'If StrMonth <> "" Then
        '    Dim words As String() = StrMonth.Split(New Char() {":"c})
        '    Dim word As String
        '    For Each word In words
        '        gridview1.Columns(word).SortOrder = DevExpress.Data.ColumnSortOrder.None
        '    Next
        'End If
        'gridview1.Columns("Variance").OptionsColumn.AllowEdit = False
        'gridview1.Columns("Variance").Width = 100
        'XgridColCurrency("Variance", gridview1)
        'XgridColAlign("Variance", gridview1, DevExpress.Utils.HorzAlignment.Far)
    End Sub
   
    Private Sub txtTrendingYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtTrendingYear.SelectedIndexChanged
        txtTrendingFrom.Properties.Items.Clear() : txtTrendingTo.Properties.Items.Clear()
        com.CommandText = "select distinct date_format(parreddate,'%M') as m from tblparredaccsumlist where date_format(parreddate,'%Y') = '" & txtTrendingYear.Text & "' order by parreddate asc" : rst = com.ExecuteReader()
        While rst.Read
            txtTrendingFrom.Properties.Items.Add(UCase(rst("m")))
            txtTrendingTo.Properties.Items.Add(UCase(rst("m")))
        End While
        rst.Close()
    End Sub
 
    Private Sub txtPARTable_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtPARTable.SelectedValueChanged
        txtLastDateTransaction.Text = Format(CDate(qrysingledata("lasttrn", "lasttrn", "", "par.`" & txtPARTable.Text & "` order by lasttrn desc limit 1")), "MMMM d, yyyy")
    End Sub
 
End Class