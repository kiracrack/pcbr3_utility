
Class Temporary

    'Public Sub GenerateMasterList()
    '    Dim fbd As New System.Windows.Forms.FolderBrowserDialog
    '    If checkExport.Checked = True Then
    '        If fbd.ShowDialog() = DialogResult.OK Then
    '            dir.Text = fbd.SelectedPath
    '        End If
    '        If dir.Text = "" Then Exit Sub
    '    End If
    '    dst = New DataSet
    '    msda = New MySqlDataAdapter("SELECT id,productid,daysinterval,groupname from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'  order by groupname asc;", conn)
    '    msda.Fill(dst, 0)
    '    For cnt = 0 To dst.Tables(0).Rows.Count - 1
    '        With (dst.Tables(0))
    '            Dim strproduct As String = "" : Dim curraccount As String = ""
    '            Dim daysdel As Integer = 0
    '            Dim RFullDate As String = ConvertDate(date_from.Text)
    '            Me.Cursor = Cursors.WaitCursor
    '            For Each word In .Rows(cnt)("productid").ToString().Split(New Char() {"|"c})
    '                strproduct = strproduct + "loanwithterm.loanprod='" & word & "' or "
    '            Next
    '            strproduct = strproduct.Remove(strproduct.Count - 3, 3)
    '            If ck_updatenew.Checked = True Then
    '                com.CommandText = "drop table if exists tbl_masterlist0" & .Rows(cnt)("id").ToString() & ";" : com.ExecuteNonQuery()
    '                LoadXgrid("CREATE TABLE tbl_masterlist0" & .Rows(cnt)("id").ToString() & " SELECT loanwithterm.refno,loanwithterm.custcode,loanwithterm.loanprod, " _
    '                 + " concat(loanwithterm.refno, '-', loanwithterm.custcode) as 'Reference No.', " _
    '                 + " (select concat(ucase(lname),', ', ucase(fname),' ', ucase(mname)) from master.client where custcode = master.loanwithterm.custcode) as 'Client Fullname', " _
    '                 + " (select concat(IF(res_street IS NULL or res_street = '','',concat(ucase(res_street),', ')), ucase(res_city),', ', ucase(res_province)) from master.client where custcode = master.loanwithterm.custcode) as 'Address', " _
    '                 + " (select concat(IF(telno IS NULL or telno = '0' or telno = '','',concat(ucase(telno),', ')), IF(cellno IS NULL or cellno ='0' or cellno = '','', ucase(cellno))) from master.client where custcode = master.loanwithterm.custcode) as 'Contact Number', " _
    '                 + " (select prodname from master.loanprod where prodcode = loanwithterm.loanprod) as 'Product', " _
    '                 + " (select groupname from master.g_group where groupkey = loanwithterm.groupkey) as `Group`, " _
    '                 + " (select centername from master.g_center where centerkey = loanwithterm.centerkey) as 'Center', " _
    '                 + " (select areaname from master.g_area inner join master.g_center on g_area.areakey = g_center.areakey where g_center.centerkey = loanwithterm.centerkey) as 'Area', " _
    '                 + " date_format(loanwithterm.Loandate,'%m-%d-%Y') as 'Loandate',date_format(loanwithterm.Maturity,'%m-%d-%Y') as 'Maturity', " _
    '                 + " loanwithterm.Principal, loanwithterm.pribal as 'Principal Balance', " _
    '                 + " intdue as 'Interest Due', " _
    '                 + " pendue as 'Penalty Due', " _
    '                 + " case when (loanwithterm.pribal > 0 and loanwithterm.daysdelayed >=  " & .Rows(cnt)("daysinterval").ToString() & ") or (loanwithterm.pribal > 0 and loanwithterm.daysdelayed >=  0  and date_format(maturity,'%Y-%m-%d') < '" & RFullDate & "') then loanwithterm.pribal end as 'PAR Amount', " _
    '                 + " case when (loanwithterm.pribal > 0 and loanwithterm.daysdelayed >=  " & .Rows(cnt)("daysinterval").ToString() & ") or (loanwithterm.pribal > 0 and loanwithterm.daysdelayed >=  0  and date_format(maturity,'%Y-%m-%d') < '" & RFullDate & "') then (pribal+intdue) end as 'Total (Pribal+Intdue)', " _
    '                 + " case " _
    '                 + " when loanwithterm.pribal > 0 and date_format(maturity,'%Y-%m-%d') < '" & RFullDate & "' then 'PAST DUE' " _
    '                 + " when loanwithterm.pribal > 0 and loanwithterm.daysdelayed >= " & .Rows(cnt)("daysinterval").ToString() & " and date_format(maturity,'%Y-%m-%d') > '" & RFullDate & "' then 'DELINQUENT' " _
    '                 + " end as 'Account Status', " _
    '                 + " " & .Rows(cnt)("daysinterval").ToString() & " AS 'Grace Period', " _
    '                 + " loanwithterm.daysdelayed  as 'Days Delayed', " _
    '                 + " numbinst as 'No. Installment', " _
    '                 + " numbpaidinst as 'Paid Installment', " _
    '                 + " ifnull((select concat(username, ' ', '(',userid,')') from master.userinfo inner join master.g_center on g_center.accountofficer = userinfo.userid where  g_center.centerkey= loanwithterm.centerkey), 'NO OFFICER INCHARGE') as 'Account Officer', " _
    '                 + " (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as 'Branch', " _
    '                 + " '" & .Rows(cnt)("groupname").ToString() & "' as 'groupname' " _
    '                 + " FROM master.loanwithterm where loanwithterm.cancelled=0  and loanwithterm.pribal > 0.00 and date_format(loandate,'%Y-%m')<= '" & RFullDate & "' and " _
    '                 + " (" & strproduct & ")  and " _
    '                 + " ((loanwithterm.pribal > 0 and date_format(maturity,'%Y-%m-%d') < '" & RFullDate & "') or (loanwithterm.pribal > 0 and loanwithterm.daysdelayed >= " & .Rows(cnt)("daysinterval").ToString() & " and date_format(maturity,'%Y-%m-%d') > '" & RFullDate & "')) order by loanwithterm.branchcode,(select concat(username, ' ', '(',userid,')') from master.userinfo inner join master.g_center on g_center.accountofficer = userinfo.userid where  g_center.centerkey= loanwithterm.centerkey),(select concat(ucase(lname),', ', ucase(fname),' ', ucase(mname)) from master.client where custcode = master.loanwithterm.custcode) asc; ", "master.loanwithterm", Em, gridview1, Me)
    '            End If

    '            LoadXgrid("select * from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " order by  `Account Status` desc", "tbl_masterlist0" & .Rows(cnt)("id").ToString() & "", Em, gridview1, Me)

    '            If gridview1.RowCount <> 0 Then
    '                gridview1.Columns("Branch").Group()
    '                gridview1.Columns("Account Officer").Group()
    '                gridview1.ExpandAllGroups()

    '                gridview1.Columns("custcode").Visible = False
    '                gridview1.Columns("refno").Visible = False
    '                gridview1.Columns("loanprod").Visible = False
    '                gridview1.BestFitColumns()

    '                gridview1.Columns("Reference No.").Fixed = Columns.FixedStyle.Left
    '                gridview1.Columns("Client Fullname").Fixed = Columns.FixedStyle.Left
    '                gridview1.Columns("Product").Fixed = Columns.FixedStyle.Left

    '                gridview1.Columns("Principal").Width = 90
    '                gridview1.Columns("Principal Balance").Width = 90
    '                gridview1.Columns("PAR Amount").Width = 90

    '                gridview1.Columns("Client Fullname").Width = 200
    '                gridview1.Columns("Client Fullname").ColumnEdit = MemoEdit
    '                'XgridColCurrency("Int Balance", gridview1)

    '                XgridColCurrency("Principal", gridview1)
    '                XgridColCurrency("Principal Balance", gridview1)
    '                XgridColCurrency("PAR Amount", gridview1)


    '                XgridColCurrency("Interest Due", gridview1)
    '                gridview1.Columns("Interest Due").Width = 90

    '                XgridColCurrency("Penalty Due", gridview1)
    '                gridview1.Columns("Penalty Due").Width = 90


    '                XgridColCurrency("Total (Pribal+Intdue)", gridview1)
    '                gridview1.Columns("Total (Pribal+Intdue)").Width = 90

    '                XgridColAlign("Reference No.", gridview1, DevExpress.Utils.HorzAlignment.Center)
    '                XgridColAlign("Loandate", gridview1, DevExpress.Utils.HorzAlignment.Center)
    '                XgridColAlign("Maturity", gridview1, DevExpress.Utils.HorzAlignment.Center)
    '                XgridColAlign("Days Delayed", gridview1, DevExpress.Utils.HorzAlignment.Center)
    '                XgridColAlign("Grace Period", gridview1, DevExpress.Utils.HorzAlignment.Center)

    '                XgridColAlign("No. Installment", gridview1, DevExpress.Utils.HorzAlignment.Center)
    '                XgridColAlign("Paid Installment", gridview1, DevExpress.Utils.HorzAlignment.Center)

    '                Dim item As New GridGroupSummaryItem()
    '                item.FieldName = "Account Officer"
    '                item.SummaryType = DevExpress.Data.SummaryItemType.Count


    '                'Dim item0 As New GridGroupSummaryItem()
    '                'item0.FieldName = "Client Fullname"
    '                'item0.SummaryType = DevExpress.Data.SummaryItemType.Count
    '                'item0.DisplayFormat = "Total number of PAR Accounts {0:N0}"
    '                'item0.ShowInGroupColumnFooter = gridview1.Columns("Client Fullname")
    '                'gridview1.GroupSummary.Add(item0)

    '                Dim item1 As New GridGroupSummaryItem()
    '                item1.FieldName = "Principal"
    '                item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '                item1.DisplayFormat = "{0:n}"
    '                item1.ShowInGroupColumnFooter = gridview1.Columns("Principal")
    '                gridview1.GroupSummary.Add(item1)

    '                Dim item2 As New GridGroupSummaryItem()
    '                item2.FieldName = "Principal Balance"
    '                item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '                item2.DisplayFormat = "{0:n}"
    '                item2.ShowInGroupColumnFooter = gridview1.Columns("Principal Balance")
    '                gridview1.GroupSummary.Add(item2)

    '                Dim item3 As New GridGroupSummaryItem()
    '                item3.FieldName = "PAR Amount"
    '                item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '                item3.DisplayFormat = "{0:n}"
    '                item3.ShowInGroupColumnFooter = gridview1.Columns("PAR Amount")
    '                gridview1.GroupSummary.Add(item3)

    '                Dim item4 As New GridGroupSummaryItem()
    '                item4.FieldName = "Total (Pribal+Intdue)"
    '                item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '                item4.DisplayFormat = "{0:n}"
    '                item4.ShowInGroupColumnFooter = gridview1.Columns("Total (Pribal+Intdue)")
    '                gridview1.GroupSummary.Add(item4)

    '                Dim item5 As New GridGroupSummaryItem()
    '                item5.FieldName = "Interest Due"
    '                item5.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '                item5.DisplayFormat = "{0:n}"
    '                item5.ShowInGroupColumnFooter = gridview1.Columns("Interest Due")
    '                gridview1.GroupSummary.Add(item5)

    '                Dim item6 As New GridGroupSummaryItem()
    '                item6.FieldName = "Penalty Due"
    '                item6.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '                item6.DisplayFormat = "{0:n}"
    '                item6.ShowInGroupColumnFooter = gridview1.Columns("Penalty Due")
    '                gridview1.GroupSummary.Add(item6)

    '                gridview1.Columns("Client Fullname").SummaryItem.SummaryType = SummaryItemType.Count
    '                gridview1.Columns("Client Fullname").SummaryItem.DisplayFormat = " Total Client(s) {0:N0}"
    '                gridview1.Columns("Client Fullname").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("Client Fullname").View, GridView).OptionsView.ShowFooter = True

    '                gridview1.Columns("Principal").SummaryItem.SummaryType = SummaryItemType.Sum
    '                gridview1.Columns("Principal").SummaryItem.DisplayFormat = "{0:n}"
    '                gridview1.Columns("Principal").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("Principal").View, GridView).OptionsView.ShowFooter = True

    '                gridview1.Columns("Principal Balance").SummaryItem.SummaryType = SummaryItemType.Sum
    '                gridview1.Columns("Principal Balance").SummaryItem.DisplayFormat = "{0:n}"
    '                gridview1.Columns("Principal Balance").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("Principal Balance").View, GridView).OptionsView.ShowFooter = True

    '                gridview1.Columns("PAR Amount").SummaryItem.SummaryType = SummaryItemType.Sum
    '                gridview1.Columns("PAR Amount").SummaryItem.DisplayFormat = "{0:n}"
    '                gridview1.Columns("PAR Amount").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("PAR Amount").View, GridView).OptionsView.ShowFooter = True


    '                gridview1.Columns("Interest Due").SummaryItem.SummaryType = SummaryItemType.Sum
    '                gridview1.Columns("Interest Due").SummaryItem.DisplayFormat = "{0:n}"
    '                gridview1.Columns("Interest Due").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("Interest Due").View, GridView).OptionsView.ShowFooter = True

    '                gridview1.Columns("Penalty Due").SummaryItem.SummaryType = SummaryItemType.Sum
    '                gridview1.Columns("Penalty Due").SummaryItem.DisplayFormat = "{0:n}"
    '                gridview1.Columns("Penalty Due").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("Penalty Due").View, GridView).OptionsView.ShowFooter = True


    '                gridview1.Columns("Total (Pribal+Intdue)").SummaryItem.SummaryType = SummaryItemType.Sum
    '                gridview1.Columns("Total (Pribal+Intdue)").SummaryItem.DisplayFormat = "{0:n}"
    '                gridview1.Columns("Total (Pribal+Intdue)").SummaryItem.Tag = 1
    '                CType(gridview1.Columns("Total (Pribal+Intdue)").View, GridView).OptionsView.ShowFooter = True
    '            End If
    '            '#END GRID VIEWING

    '            If checkExport.Checked = True Then

    '                Dim existfilter = gridview1.ActiveFilterString.ToString()
    '                Dim view As ColumnView = gridview1
    '                Dim branches As String = qrysingledata("str", "group_concat(distinct(branch)) as str", "", "tbl_masterlist0" & .Rows(cnt)("id").ToString() & "")

    '                Try
    '                    If branches <> "" Then
    '                        For Each splBranch In branches.Split(New Char() {","c})
    '                            If ckGroupbyOfficer.Checked = False Then ' #UNGROUP BY OFFICER 
    '                                If Not Directory.Exists(dir.Text & "\" & ConvertDate(date_from.Text) & "\PRODUCT EXPORT LIST\" & splBranch) Then
    '                                    Directory.CreateDirectory(dir.Text & "\" & ConvertDate(date_from.Text) & "\PRODUCT EXPORT LIST\" & splBranch)
    '                                End If

    '                                Dim report As New rptOtherReport()
    '                                report.txttitle.Text = UCase(.Rows(cnt)("groupname").ToString()) & " OF " & UCase(splBranch) & " AS OF " & date_from.Text
    '                                If existfilter = "" Then
    '                                    gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "'"
    '                                Else
    '                                    gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' And " & existfilter
    '                                End If
    '                                report.Landscape = True
    '                                report.PaperKind = System.Drawing.Printing.PaperKind.A2
    '                                report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
    '                                report.ExportToXlsx(dir.Text & "\" & ConvertDate(date_from.Text) & "\" & splBranch & "\PRODUCT EXPORT LIST\" & UCase(.Rows(cnt)("groupname").ToString()) & " LOAN LISTING.xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
    '                            Else
    '                                If Not Directory.Exists(dir.Text & "\" & ConvertDate(date_from.Text) & "\" & splBranch & "\AO PAR LIST\" & UCase(.Rows(cnt)("groupname").ToString())) Then
    '                                    Directory.CreateDirectory(dir.Text & "\" & ConvertDate(date_from.Text) & "\" & splBranch & "\AO PAR LIST\" & UCase(.Rows(cnt)("groupname").ToString()))
    '                                End If
    '                                com.CommandText = "select distinct(`Account Officer`) as ao from tbl_masterlist0" & .Rows(cnt)("id").ToString() & " where Branch='" & UCase(splBranch) & "' and  groupname='" & .Rows(cnt)("groupname").ToString() & "'" : rst = com.ExecuteReader
    '                                While rst.Read
    '                                    Dim report As New rptOtherReport()
    '                                    report.txttitle.Text = UCase(.Rows(cnt)("groupname").ToString()) & " OF " & UCase(splBranch) & " AS OF " & date_from.Text & " (" & rst("ao").ToString & ")"
    '                                    If existfilter = "" Then
    '                                        gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' And [Account Officer] = '" & rst("ao").ToString & "'"
    '                                    Else
    '                                        gridview1.ActiveFilterString = "[Branch] = '" & splBranch & "' And [Account Officer] = '" & rst("ao").ToString & "' And " & existfilter
    '                                    End If
    '                                    report.Landscape = True
    '                                    report.PaperKind = System.Drawing.Printing.PaperKind.A2
    '                                    report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
    '                                    report.ExportToXlsx(dir.Text & "\" & ConvertDate(date_from.Text) & "\" & splBranch & "\AO PAR LIST\" & UCase(.Rows(cnt)("groupname").ToString()) & "\" & rst("ao").ToString & ".xlsx", New DevExpress.XtraPrinting.XlsxExportOptions(False, False, True))
    '                                End While
    '                                rst.Close()

    '                            End If

    '                        Next
    '                    End If
    '                    Me.Cursor = Cursors.Default
    '                Catch errMS As Exception
    '                    XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
    '                                 & "Message:" & errMS.Message & vbCrLf _
    '                                 & "Details:" & errMS.StackTrace, _
    '                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try
    '            End If
    '        End With
    '    Next
    '    dst.Clear()
    '    UpdateAccountsSummary()
    '    loadaoportfoliowithpar()
    '    loadaoParredSummary()
    '    LoadSummary()
    '    XtraMessageBox.Show("Data successfully Generated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Me.Cursor = Cursors.Default
    'End Sub
End Class
