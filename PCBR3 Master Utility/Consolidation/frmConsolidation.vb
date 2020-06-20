Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmConsolidation
    Private Sub frmConsoladation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtasof.Text = Now.ToShortDateString
        officecode.Text = qrysingledata("officecode", "officecode", "", "tblsignatories")
        ClearGrid()
        Dim datequery As Date = qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar")
        txtasof.EditValue = Format(datequery, "MMMM d, yyyy")
        gridview1.RowHeight = 15
        gridview1.ColumnPanelRowHeight = 24
        gridview1.BorderStyle = BorderStyles.NoBorder
        gridview1.OptionsBehavior.Editable = False
        gridview1.OptionsBehavior.[ReadOnly] = True

        gridview1.OptionsSelection.EnableAppearanceFocusedCell = False
        gridview1.OptionsView.ShowGroupPanel = False
        gridview1.OptionsView.ShowIndicator = False
        gridview1.OptionsView.ShowHorzLines = False
        gridview1.OptionsView.ShowVertLines = False

    End Sub
    Public Sub ClearGrid()
        LoadXgrid("select itemcode,parentcode, displaytype,computetype,strquery, '' as 'Particular', '' as 'Total' from tblconsolitem where itemcode='0'", "tblconsolitem", Em, gridview1, Me)
        gridview1.Columns("itemcode").Visible = False
        gridview1.Columns("parentcode").Visible = False
        gridview1.Columns("displaytype").Visible = False
        gridview1.Columns("computetype").Visible = False
        gridview1.Columns("strquery").Visible = False
        gridview1.Columns("Particular").SortOrder = DevExpress.Data.ColumnSortOrder.None
        gridview1.Columns("Total").SortOrder = DevExpress.Data.ColumnSortOrder.None
    End Sub
    ' DATE FORMAT {datefull},{month},{day},{year}
    Public Function rDate(ByVal str As String, ByVal sdate As Date)
        Dim dateSel As Date = sdate
        Dim RFullDate As String = ConvertDate(txtasof.Text)
        Dim RMonthDate As String = dateSel.ToString("MM")
        Dim RDayDate As String = dateSel.ToString("dd")
        Dim RYearDate As String = dateSel.Year
        str = str.Replace("{datefull}", RFullDate)
        str = str.Replace("{month}", RMonthDate)
        str = str.Replace("{day}", RDayDate)
        str = str.Replace("{year}", RYearDate)
        Return str
    End Function
    Public Sub LoadData()
        Dim years As String = ""
        Dim yearcount As Integer = 0
        Dim totalpayment As Double = 0
        Dim dt As Date = txtasof.Text
        Try
            '  MsgBox(RFullDate & Environment.NewLine & RMonthDate & Environment.NewLine & RDayDate & Environment.NewLine & RYearDate)
            If XtraMessageBox.Show("Consolidating Transaction as of " & Format(dt, "MMMM dd, yyyy") & "?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                'LoadXgrid("select '' as 'No.', '' as 'Voters ID', '' as 'Fullname', '' as 'Address', '' as 'Sex','' as 'VType', '' as 'Birth Date'", "tblvoters", Em, GridView1, Me)
                SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
                ProgressBarControl1.Properties.Step = 1
                ProgressBarControl1.Properties.PercentView = True
                ProgressBarControl1.Properties.Maximum = countrecord("tblconsolitem") + 2
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Position = 0

                dst = New DataSet
                msda = New MySqlDataAdapter("select * from tblconsolitem order by sortorder asc ", conn)
                msda.Fill(dst, 0)
                For cnt = 0 To dst.Tables(0).Rows.Count - 1
                    With (dst.Tables(0))
                        AddRowXgrid(gridview1)
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "itemcode", .Rows(cnt)("itemcode").ToString())
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "parentcode", .Rows(cnt)("parentcode").ToString())
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "displaytype", .Rows(cnt)("displaytype").ToString())
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "computetype", .Rows(cnt)("computetype").ToString())
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "strquery", .Rows(cnt)("strquery").ToString())
                        If .Rows(cnt)("parentcode").ToString() = "" Then
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", .Rows(cnt)("itemname").ToString())
                        Else
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", "          " & .Rows(cnt)("itemname").ToString())
                        End If

                        If .Rows(cnt)("computetype").ToString() = "SQL QUERY" Then
                            Dim strqueryfortotal As String = .Rows(cnt)("strquery").ToString()
                            strqueryfortotal = rDate(strqueryfortotal, txtasof.Text)
                            com.CommandText = strqueryfortotal : rst = com.ExecuteReader
                            While rst.Read
                                If .Rows(cnt)("displaytype").ToString() = "0" Then
                                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Total", Format(Val(rst("total").ToString), "n"))
                                Else
                                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Total", Format(Val(rst("total").ToString), "N0"))
                                End If

                            End While
                            rst.Close()

                        ElseIf .Rows(cnt)("computetype").ToString() = "SQL QUERY GENERATOR" Then
                            Dim strqueryfortotal As String = .Rows(cnt)("strquery").ToString()
                            strqueryfortotal = rDate(strqueryfortotal, txtasof.Text)
                            com.CommandText = qryGenerator(strqueryfortotal) : rst = com.ExecuteReader
                            While rst.Read
                                If .Rows(cnt)("displaytype").ToString() = "0" Then
                                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Total", Format(Val(rst("total").ToString), "n"))
                                Else
                                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Total", Format(Val(rst("total").ToString), "N0"))
                                End If

                            End While
                            rst.Close()

                        ElseIf .Rows(cnt)("computetype").ToString() = "PARENT" Then
                            Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "Particular").ToString()
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", str + " - Auto Generate Total")

                        ElseIf .Rows(cnt)("computetype").ToString() = "SUM OF ITEM" Then
                            Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "Particular").ToString()
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", str + " - Auto Generate Total")

                        Else
                            Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "Particular").ToString()
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", str + " - Manual Entry")

                            Spinedit.Name = .Rows(cnt)("itemname").ToString()
                            Spinedit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                            Spinedit.Mask.EditMask = "n"
                            Spinedit.Mask.UseMaskAsDisplayFormat = True
                            gridview1.Columns("Total").ColumnEdit = Spinedit
                            gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Total", 0)
                        End If

                    End With
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                Next
                gridview1.MoveLast()

                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()


                gridview1.Columns("Particular").OptionsColumn.AllowEdit = False
                gridview1.Columns("Total").Width = 100
                XgridColCurrency("Total", gridview1)
                XgridColAlign("Total", gridview1, DevExpress.Utils.HorzAlignment.Far)


                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
                SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
                Em.Enabled = True
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try

    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridview1.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "computetype").ToString()
            If str = "MANUAL" Then
                gridview1.Columns("Total").OptionsColumn.AllowEdit = True
            Else
                gridview1.Columns("Total").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub
    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles gridview1.RowCellStyle
        Dim View As GridView = sender
        Dim col As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("computetype"))
        If e.Column.FieldName = "Particular" Then
            If col = "MANUAL" Then
                e.Appearance.BackColor = Color.LemonChiffon
                e.Appearance.ForeColor = Color.Black
                e.Appearance.Font = New Font("Tahoma", 7.75!, System.Drawing.FontStyle.Bold)
                ' gridview1.SetRowCellValue(e.RowHandle, "Total", Format(Val(CC(gridview1.GetRowCellValue(e.RowHandle, "Total").ToString())), "n"))
            ElseIf col = "PARENT" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.ForeColor = Color.Black

            ElseIf col = "SUM OF ITEM" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.ForeColor = Color.Black
            End If
            'Else
            '    If col = "MANUAL" Then
            '        e.Column.OptionsColumn.AllowEdit = True
            '        e.Column.OptionsColumn.ReadOnly = True
            '    Else
            '        e.Column.OptionsColumn.AllowEdit = False
            '        e.Column.OptionsColumn.ReadOnly = False
            '    End If
        End If
    End Sub

    Private Sub gridview1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridview1.MouseMove
        If gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "computetype") = Nothing Then Exit Sub
        Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "computetype").ToString()
        If str = "MANUAL" Then
            gridview1.Columns("Total").OptionsColumn.AllowEdit = True
        Else
            gridview1.Columns("Total").OptionsColumn.AllowEdit = False
        End If
    End Sub
    Private Sub gridview1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridview1.KeyDown
        Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "computetype").ToString()
        If str = "MANUAL" Then
            gridview1.Columns("Total").OptionsColumn.AllowEdit = True
        Else
            gridview1.Columns("Total").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub gridview1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridview1.KeyUp
        Dim str As String = gridview1.GetRowCellValue(gridview1.FocusedRowHandle, "computetype").ToString()
        If str = "MANUAL" Then
            gridview1.Columns("Total").OptionsColumn.AllowEdit = True
        Else
            gridview1.Columns("Total").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If txtasof.Text = "" Then
            XtraMessageBox.Show("Please select Date", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtasof.Focus()
            Exit Sub
      
        ElseIf gridview1.RowCount = 0 Then
            XtraMessageBox.Show("No item found. please generate data properly", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If XtraMessageBox.Show("Are you sure you want to continue? - " & globaluser & "@" & globalfullname & " on " & globaldate & " - " & GlobalTime() & ") ?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            'LoadXgrid("select '' as 'No.', '' as 'Voters ID', '' as 'Fullname', '' as 'Address', '' as 'Sex','' as 'VType', '' as 'Birth Date'", "tblvoters", Em, GridView1, Me)
            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = gridview1.RowCount * 2 + 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0
            Dim mcode As String = CDate(txtasof.Text).ToString("yyyy-MM")
            Dim BatchCode = ConvertDate(txtasof.Text)
            com.CommandText = "delete from tblconsolidated where date_format(batchcode,'%Y-%m')='" & mcode & "' and officecode='" & officecode.Text & "'" : com.ExecuteNonQuery()
            Try
                For X = 0 To gridview1.RowCount - 1
                    Dim ttlamnt As Double = 0
                    Dim total As Double = 0
                    com.CommandText = "insert into tblconsolidated set batchcode='" & BatchCode & "', officecode='" & officecode.Text & "'," _
                                                        + " particularcode='" & gridview1.GetRowCellValue(X, "itemcode").ToString() & "', " _
                                                        + " total='" & Val(CC(gridview1.GetRowCellValue(X, "Total").ToString())) & "', " _
                                                        + " datebatch=current_date, " _
                                                        + " trnby='" & globaluserid & "'" : com.ExecuteNonQuery()
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                Next X
                For X = 0 To gridview1.RowCount - 1
                    If gridview1.GetRowCellValue(X, "computetype").ToString() = "PARENT" Then
                        Dim totalval As Double = Val(qrysingledata("total", "sum(total) as total", "", "tblconsolidated inner join tblconsolitem on tblconsolitem.itemcode =  tblconsolidated.particularcode where parentcode='" & gridview1.GetRowCellValue(X, "itemcode").ToString() & "' and batchcode = '" & BatchCode & "' and officecode='" & officecode.Text & "'"))
                        com.CommandText = "update tblconsolidated set total = ROUND(IFNULL((" & totalval & "),0),2) where batchcode = '" & BatchCode & "' and officecode='" & officecode.Text & "' and particularcode='" & gridview1.GetRowCellValue(X, "itemcode").ToString() & "'" : com.ExecuteNonQuery()

                    ElseIf gridview1.GetRowCellValue(X, "computetype").ToString() = "SUM OF ITEM" Then
                        Dim strQuery As String = gridview1.GetRowCellValue(X, "strquery").ToString()
                        Dim compqry As String = ""
                        Dim comFinal As String = ""

                        compqry = rSymbol(strQuery)
                        comFinal = strQuery
                        Dim words As String() = compqry.Split(New Char() {","c})
                        Dim word As String
                        For Each word In words
                            Dim r As String = qrysingledata("total", "total", "where batchcode = '" & BatchCode & "' and officecode='" & officecode.Text & "' and particularcode='" & word & "'", "tblconsolidated")
                            If r <> "" Then
                                comFinal = comFinal.Replace(word, r)
                            End If

                        Next
                        com.CommandText = "update tblconsolidated set total=ROUND(IFNULL((" & comFinal & "),0),2) " _
                                            + " where batchcode = '" & BatchCode & "' and officecode='" & officecode.Text & "' and particularcode='" & gridview1.GetRowCellValue(X, "itemcode").ToString() & "'" : com.ExecuteNonQuery()


                    End If
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                Next

            Catch ex As Exception
                XtraMessageBox.Show("Message:" & ex.Message, _
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PrintError()
                Exit Sub
            End Try


            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()
            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
            Em.Enabled = True
            ' ClearGrid()
            XtraMessageBox.Show("Data successfully Loaded to database!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Function rSymbol(ByVal str As String)
        str = str.Replace("+", ",")
        str = str.Replace("/", ",")
        str = str.Replace("*", ",")
        str = str.Replace("-", ",")
        str = str.Replace("%", ",")
        str = str.Replace("(", "")
        str = str.Replace(")", "")
        'str = str.Replace(",", "")
        Return str
    End Function
    
    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        LoadData()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtasof.Text = "" Then
            XtraMessageBox.Show("Please select Date", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtasof.Focus()
            Exit Sub
        End If
        LoadData()
    End Sub
End Class