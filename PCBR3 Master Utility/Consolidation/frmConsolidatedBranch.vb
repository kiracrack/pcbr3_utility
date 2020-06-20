Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.IO
Imports DevExpress.XtraReports.UI

Public Class frmConsolidatedBranch
    Private qryMonth As String = ""
    Private StrMonth As String = ""
    Private Sub frmConsoladation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtasof.Text = Format(Now.ToShortDateString)
        ClearGrid()
        gridview1.RowHeight = 15
        gridview1.ColumnPanelRowHeight = 24
        gridview1.BorderStyle = BorderStyles.NoBorder
        gridview1.OptionsBehavior.Editable = False
        gridview1.OptionsBehavior.[ReadOnly] = True

        gridview1.OptionsSelection.EnableAppearanceFocusedCell = False

        gridview1.OptionsView.ShowGroupPanel = False
        gridview1.OptionsView.ShowAutoFilterRow = False
        gridview1.OptionsView.ShowIndicator = False
        gridview1.OptionsView.EnableAppearanceEvenRow = False
        gridview1.OptionsView.EnableAppearanceOddRow = False
        gridview1.OptionsView.ShowHorzLines = False
        gridview1.OptionsView.ShowVertLines = False
        gridview1.OptionsView.ShowViewCaption = False
    End Sub
    Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gridview1.CustomDrawCell
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
    Public Sub ClearGrid()
        com.CommandText = "select ucase(branchname) as 'branch' from master.branches order by branchname asc"
        rst = com.ExecuteReader
        While rst.Read
            StrMonth = StrMonth + rst("branch").ToString + ":"
            qryMonth = qryMonth + "'' as '" & rst("branch").ToString & "',"
        End While
        rst.Close()

        StrMonth = StrMonth.Remove(StrMonth.Length - 1, 1)
        qryMonth = qryMonth.Remove(qryMonth.Length - 1, 1)

        LoadXgrid("select itemcode,parentcode, displaytype,computetype, '' as 'Particular', " & qryMonth & ", '' as 'Variance' from tblconsolidated inner join tblconsolitem on tblconsolitem.itemcode = tblconsolidated.particularcode where itemcode='0'", "tblconsolidated", Em, gridview1, Me)
        gridview1.Columns("itemcode").Visible = False
        gridview1.Columns("parentcode").Visible = False
        gridview1.Columns("displaytype").Visible = False
        gridview1.Columns("computetype").Visible = False
        gridview1.Columns("Variance").Visible = False
        gridview1.Columns("Particular").SortOrder = DevExpress.Data.ColumnSortOrder.None

        Dim words As String() = StrMonth.Split(New Char() {":"c})
        Dim word As String
        For Each word In words
            gridview1.Columns(word).SortOrder = DevExpress.Data.ColumnSortOrder.None
        Next
        gridview1.Columns("Variance").SortOrder = DevExpress.Data.ColumnSortOrder.None

        gridview1.Columns("Variance").OptionsColumn.AllowEdit = False
        gridview1.Columns("Variance").Width = 100
        XgridColCurrency("Variance", gridview1)
        XgridColAlign("Variance", gridview1, DevExpress.Utils.HorzAlignment.Far)
    End Sub

    Public Sub LoadData()
        Dim curryear As Date = Now.ToShortDateString
        Dim years As String = ""
        Dim yearcount As Integer = 0
        Dim totalpayment As Double = 0
        Try

            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = countrecord("tblconsolitem") * 3 + 2
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0

            Dim BatchCode = ConvertDate(txtasof.Text)
            ClearGrid()
            dst = New DataSet
            msda = New MySqlDataAdapter("select * from tblconsolitem order by sortorder asc", conn)
            msda.Fill(dst, 0)
            For cnt = 0 To dst.Tables(0).Rows.Count - 1
                With (dst.Tables(0))
                    AddRowXgrid(gridview1)
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "itemcode", .Rows(cnt)("itemcode").ToString())
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "parentcode", .Rows(cnt)("parentcode").ToString())
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "displaytype", .Rows(cnt)("displaytype").ToString())
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "computetype", .Rows(cnt)("computetype").ToString())

                    If .Rows(cnt)("parentcode").ToString() = "" Then
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", .Rows(cnt)("itemname").ToString())
                    Else
                        gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Particular", "          " & .Rows(cnt)("itemname").ToString())
                    End If
                End With
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
            gridview1.MoveLast()

            dst = New DataSet
            msda = New MySqlDataAdapter("select * from master.branches order by branchcode asc", conn)
            msda.Fill(dst, 0)
            Dim icount As Integer = 0
            For cnt = 0 To dst.Tables(0).Rows.Count - 1
                With (dst.Tables(0))
                    icount = 0
                    com.CommandText = "select * from tblconsolidated inner join tblconsolitem on tblconsolitem.itemcode = tblconsolidated.particularcode where officecode='" & .Rows(cnt)("branchcode").ToString & "' and batchcode='" & BatchCode & "' order by sortorder asc "
                    rst = com.ExecuteReader
                    While rst.Read
                        If rst("displaytype").ToString() = "0" Then
                            gridview1.SetRowCellValue(icount, .Rows(cnt)("codename").ToString, Format(Val(rst("total").ToString()), "n"))
                        Else
                            gridview1.SetRowCellValue(icount, .Rows(cnt)("codename").ToString, Format(Val(rst("total").ToString()), "N0"))
                        End If
                        icount = icount + 1
                        ProgressBarControl1.PerformStep()
                        ProgressBarControl1.Update()
                    End While
                    rst.Close()
                    gridview1.Columns(.Rows(cnt)("codename").ToString).OptionsColumn.AllowEdit = False
                    gridview1.Columns(.Rows(cnt)("codename").ToString).Width = 100
                    XgridColCurrency(.Rows(cnt)("codename").ToString, gridview1)
                    XgridColAlign(.Rows(cnt)("codename").ToString, gridview1, DevExpress.Utils.HorzAlignment.Far)
                End With
                gridview1.MoveLast()
            Next
            gridview1.Columns("Particular").OptionsColumn.AllowEdit = False



        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()
            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
            Em.Enabled = True
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()
            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
            Em.Enabled = True
            PrintError()
        End Try
        ProgressBarControl1.PerformStep()
        ProgressBarControl1.Update()
        SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
        Em.Enabled = True
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        qryMonth = ""
        StrMonth = ""
        LoadData()
        CheckEdit1.Enabled = True
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            gridview1.Columns("Variance").Visible = True
            Dim m1 As String = ""
            Dim m2 As String = ""
            Dim c As Integer = 0
            com.CommandText = "select * from tblbranch order by branchcode asc"
            rst = com.ExecuteReader
            While rst.Read
                If c = 0 Then
                    m1 = rst("codename").ToString
                ElseIf c = 1 Then
                    m2 = rst("codename").ToString
                End If
                c = c + 1
            End While
            rst.Close()
            For v = 0 To gridview1.RowCount - 1

                Dim dimcol1 As Double = Val(CC(gridview1.GetRowCellValue(v, m1).ToString()))
                Dim dimcol2 As Double = Val(CC(gridview1.GetRowCellValue(v, m2).ToString()))
                If gridview1.GetRowCellValue(v, "displaytype").ToString() = "0" Then
                    gridview1.SetRowCellValue(v, "Variance", Format(dimcol1 + dimcol2, "n"))
                Else
                    gridview1.SetRowCellValue(v, "Variance", Format(dimcol1 + dimcol2, "N0"))
                End If
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
        Else
            gridview1.Columns("Variance").Visible = False
        End If

    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        printreport()
    End Sub
    Public Sub printreport()
        Dim report As New rptConsolidated()
        report.txtbranch.Text = "CURRENT MONTH"
        Dim asofdate As Date = txtasof.Text
        report.txtconsolidated.Text = "Consolidated"
        report.txtconlasofdate.Text = "As of " + Format(asofdate, "MMMM dd, yyyy")


        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub
End Class