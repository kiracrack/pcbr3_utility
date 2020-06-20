Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.IO
Imports DevExpress.XtraReports.UI

Public Class frmConsolidatedHighLights
    Private qryMonth As String = ""
    Private StrMonth As String = ""
    Private intMonth As String = ""

    Public Sub ClearGrid()
        Dim currmonth As Date
         Dim BatchCode = ConvertDate(txtasof.Text)
        com.CommandText = "select distinct(left(CAST(batchcode AS CHAR(20)),7)) as cnt from tblconsolhighlight where date_format(batchcode,'%Y-%m-%d')<='" & BatchCode & "' order by batchcode desc limit 2"
        rst = com.ExecuteReader
        While rst.Read
            currmonth = rst("cnt").ToString & "-01"
            'MsgBox(currmonth)
            intMonth = intMonth + currmonth.Month.ToString & ":"
            StrMonth = StrMonth + currmonth.ToString("MMMM").ToString & ":"
            qryMonth = qryMonth + "'' as '" & currmonth.ToString("MMMM").ToString & "',"
        End While
        rst.Close()

        If intMonth <> "" Then
            intMonth = intMonth.Remove(intMonth.Length - 1, 1)
        End If
        If StrMonth <> "" Then
            StrMonth = StrMonth.Remove(StrMonth.Length - 1, 1)
        End If
        If qryMonth <> "" Then
            qryMonth = qryMonth.Remove(qryMonth.Length - 1, 1)
            qryMonth = "," & qryMonth
        End If

        LoadXgrid("select itemcode,parentcode, displaytype,computetype, '' as 'Particular' " & qryMonth & ", '' as 'Variance' from tblconsolhighlight inner join tblconsolitem on tblconsolitem.itemcode = tblconsolhighlight.particularcode where itemcode='0'", "tblconsolhighlight", Em, gridview1, Me)
        gridview1.Columns("itemcode").Visible = False
        gridview1.Columns("parentcode").Visible = False
        gridview1.Columns("displaytype").Visible = False
        gridview1.Columns("computetype").Visible = False
        gridview1.Columns("Variance").Visible = False
        gridview1.Columns("Particular").SortOrder = DevExpress.Data.ColumnSortOrder.None

        If StrMonth <> "" Then
            Dim words As String() = StrMonth.Split(New Char() {":"c})
            Dim word As String
            For Each word In words
                gridview1.Columns(word).SortOrder = DevExpress.Data.ColumnSortOrder.None
            Next
        End If
        gridview1.Columns("Variance").OptionsColumn.AllowEdit = False
        gridview1.Columns("Variance").Width = 100
        XgridColCurrency("Variance", gridview1)
        XgridColAlign("Variance", gridview1, DevExpress.Utils.HorzAlignment.Far)
    End Sub

    Public Sub LoadData()
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
            msda = New MySqlDataAdapter("select * from tblconsolhighlight inner join tblconsolitem on tblconsolitem.itemcode = tblconsolhighlight.particularcode where batchcode='" & BatchCode & "' order by sortorder asc ", conn)
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
            If intMonth <> "" Then
                Dim words As String() = intMonth.Split(New Char() {":"c})
                Dim word As String

                For Each word In words
                    dst = New DataSet
                    Dim newbatchcode As String = ""
                    Dim newYear As Date = txtasof.Text
                    Dim newMonth As Date = word & "-01"
                    Dim getMonth As String = newMonth.ToString("MMMM")
                    newbatchcode = newYear.Year & "-" & newMonth.ToString("MM")
                    msda = New MySqlDataAdapter("select * from tblconsolhighlight inner join tblconsolitem on tblconsolitem.itemcode = tblconsolhighlight.particularcode where left(batchcode,7)='" & newbatchcode & "' order by sortorder asc ", conn)
                    msda.Fill(dst, 0)
                    For cnt = 0 To dst.Tables(0).Rows.Count - 1
                        With (dst.Tables(0))
                            If .Rows(cnt)("displaytype").ToString() = "0" Then
                                gridview1.SetRowCellValue(cnt, getMonth, Format(Val(.Rows(cnt)("total").ToString()), "n"))
                            Else
                                gridview1.SetRowCellValue(cnt, getMonth, Format(Val(.Rows(cnt)("total").ToString()), "N0"))
                            End If
                        End With
                        ProgressBarControl1.PerformStep()
                        ProgressBarControl1.Update()
                    Next
                    gridview1.MoveLast()
                    gridview1.Columns(getMonth).OptionsColumn.AllowEdit = False
                    gridview1.Columns(getMonth).Width = 100
                    XgridColCurrency(getMonth, gridview1)
                    XgridColAlign(getMonth, gridview1, DevExpress.Utils.HorzAlignment.Far)
                Next
            End If

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
        CheckEdit1.Enabled = True
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        CheckEdit1.Checked = False
        qryMonth = ""
        StrMonth = ""
        intMonth = ""

        Dim BatchCode = ConvertDate(txtasof.Text)
        If countqry("tblconsolhighlight", "batchcode='" & BatchCode & "'") = 0 Then
            com.CommandText = "insert into tblconsolhighlight (batchcode,particularcode,total,trnby) select batchcode, particularcode,sum(total),'105' from tblconsolidated where batchcode='" & BatchCode & "' group by particularcode" : com.ExecuteNonQuery()
        Else
            If checkUpdate.Checked = True Then
                com.CommandText = "delete from tblconsolhighlight where batchcode='" & BatchCode & "'" : com.ExecuteNonQuery()
                com.CommandText = "insert into tblconsolhighlight (batchcode,particularcode,total,trnby) select batchcode, particularcode,sum(total),'105' from tblconsolidated where batchcode='" & BatchCode & "' group by particularcode" : com.ExecuteNonQuery()
            End If
        End If
        LoadData()
    End Sub


    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            gridview1.Columns("Variance").Visible = True
            Dim words As String() = intMonth.Split(New Char() {":"c})
            Dim word As String
            Dim m1 As String = ""
            Dim m2 As String = ""
            Dim c As Integer = 0
            For Each word In words
                dst = New DataSet
                Dim newMonth As Date = word & "/01/2001"
                Dim getMonth As String = newMonth.ToString("MMMM")
                If c = 0 Then
                    m1 = getMonth
                ElseIf c = 1 Then
                    m2 = getMonth
                End If
                c = c + 1
            Next
            For v = 0 To gridview1.RowCount - 1

                Dim dimcol1 As Double = Val(CC(gridview1.GetRowCellValue(v, m1).ToString()))
                Dim dimcol2 As Double
                If m2 <> "" Then
                    dimcol2 = Val(CC(gridview1.GetRowCellValue(v, m2).ToString()))
                Else
                    dimcol2 = 0
                End If

                If gridview1.GetRowCellValue(v, "displaytype").ToString() = "0" Then
                    gridview1.SetRowCellValue(v, "Variance", Format(dimcol1 - dimcol2, "n"))
                Else
                    gridview1.SetRowCellValue(v, "Variance", Format(dimcol1 - dimcol2, "N0"))
                End If
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
        Else
            gridview1.Columns("Variance").Visible = False
        End If

    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        printreport()
    End Sub
    Public Sub printreport()
        Dim report As New rptConsolidated()
        report.txtbranch.Text = ""
        ' report.txtconsolidated.Text = Me.Text
        Dim asofdate As Date = txtasof.Text
        report.txtconsolidated.Text = "CONSOLIDATED"
        report.txtconlasofdate.Text = "As of " + Format(asofdate, "MMMM dd, yyyy")
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub

    Private Sub frmConsolidatedHighLights_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtasof.Text = Format(Now.ToShortDateString)
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
End Class