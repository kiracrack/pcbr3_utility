Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraCharts.Wizard

Public Class frmProductChartSummary
    Private Sub frmSummaryRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim datequerymin As Date = qrysingledata("parreddate", "parreddate", "order by parreddate asc limit 1", "tblparredaccsumlist")
        Dim datequerymax As Date = qrysingledata("parreddate", "parreddate", "order by parreddate desc limit 1", "tblparredaccsumlist")
        txtfrmdate.EditValue = Format(datequerymin, "yyyy-MM-dd")
        txtfrmdate.Properties.MinValue = Format(datequerymin, "yyyy-MM-dd")
        txtfrmdate.Properties.MaxValue = Format(datequerymax, "yyyy-MM-dd")

        txttodate.EditValue = Format(datequerymax, "yyyy-MM-dd")
        txttodate.Properties.MinValue = Format(datequerymin, "yyyy-MM-dd")
        txttodate.Properties.MaxValue = Format(datequerymax, "yyyy-MM-dd")
        LoadOffice()
        reportcount(Me.Name.ToString)
    End Sub

    Public Sub LoadOffice()
        LoadToComboBox("branch", "tblportfoliowithpar", txtoffice, True)
    End Sub
    Private Sub ckPurchasetype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckPurchasetype.CheckedChanged
        If ckPurchasetype.Checked = True Then
            txtoffice.SelectedIndex = -1
            txtoffice.Enabled = False
        Else
            txtoffice.Enabled = True
        End If
    End Sub
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        ViewChart()
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        ' printreport()
    End Sub
    Public Sub ViewChart()
        Dim ckbranch As String = ""
        If ckPurchasetype.Checked = True Then
            ckbranch = ""
        Else
            If txtoffice.Text = "" Then
                XtraMessageBox.Show("Please select office type from the list!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtoffice.Focus()
                Exit Sub
            End If
            ckbranch = "and branch='" & txtoffice.Text & "'"
        End If
        For i As Integer = (XtraScrollableControl1.Controls.Count - 1) To 0 Step -1
            Dim ctrl As Control = XtraScrollableControl1.Controls(i)
            XtraScrollableControl1.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next i
        dst = New DataSet
        msda = New MySqlDataAdapter("Select distinct(branch) as 'branch',groupname from tblportfoliowithpar where date_format(parreddate,'%Y-%m-%d') between '" & ConvertDate(txtfrmdate.Text) & "'  and '" & ConvertDate(txttodate.Text) & "' " & ckbranch & "  group by groupname order by branch asc", conn)
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim BarChart As New ChartControl()

                com.CommandText = "SELECT  tblportfoliowithpar.branch as 'Branch',(sum(ifnull(round((ttlpar/sum(pribal)) * 100,2),0.00))/count(*)) as 'PAR Ratio',  tblportfoliowithpar.groupname as 'Product Group' FROM `tblparredaccsumlist` " _
                                + " right join tblportfoliowithpar on tblparredaccsumlist.groupname = tblportfoliowithpar.groupname and tblparredaccsumlist.ao = tblportfoliowithpar.officer and tblparredaccsumlist.parreddate=tblportfoliowithpar.parreddate where tblportfoliowithpar.parreddate between '" & ConvertDate(txtfrmdate.Text) & "' and '" & ConvertDate(txttodate.Text) & "' and tblportfoliowithpar.branch='" & .Rows(cnt)("branch").ToString() & "'" _
                                + " group by tblportfoliowithpar.branch,tblportfoliowithpar.groupname order by (sum(ifnull(round((ttlpar/sum(pribal)) * 100,2),0.00))/count(*));" : rst = com.ExecuteReader
                While rst.Read
                    Dim series1 As New Series(rst("Product Group").ToString, ViewType.Bar)
                    series1.Points.Add(New SeriesPoint(rst("Product Group").ToString, rst("PAR Ratio")))
                    BarChart.Series.AddRange(New Series() {series1})
                    'series1.Points(0).Annotations.AddTextAnnotation(rst("Product Group").ToString, rst("Product Group").ToString)

                    BarChart.Size = New Size(300, 200)
                    BarChart.Dock = DockStyle.Left
                    BarChart.Legend.FillStyle.FillMode = FillMode.Solid
                    Dim view As SideBySideBarSeriesView = CType(BarChart.Series(rst("Product Group").ToString).View, SideBySideBarSeriesView)
                    view.FillStyle.FillMode = FillMode.Solid
                End While
                rst.Close()
                BarChart.Legend.AlignmentVertical = LegendAlignmentVertical.Top
                BarChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right

                Dim chartTitle1 As New ChartTitle()
                chartTitle1.Text = .Rows(cnt)("branch").ToString() & Environment.NewLine
                chartTitle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                BarChart.Titles.Add(chartTitle1)
                BarChart.Legend.Visible = False
                XtraScrollableControl1.Controls.Add(BarChart)
                ' DirectCast(BarChart.Diagram, DevExpress.XtraCharts.XYDiagram).Rotated = True
            End With
        Next

    End Sub

    'Public Sub printreport()
    '    Dim report As New rptOtherReport()
    '    com.CommandText = "update tblreportsetting set title='" & txttitle.Text & "', customtext='" & txtCustom.Text & "' where formname='" & Me.Name.ToString & "' " : com.ExecuteNonQuery()

    '    report.txttitle.Text = txttitle.Text
    '    report.txtcustom.Text = txtCustom.Text
    '    report.txtfrom.Text = txtfrmdate.Text
    '    report.txtto.Text = txttodate.Text
    '    'report.Landscape = True
    '    ChartControl1.Dock = DockStyle.None
    '    ChartControl1.Size = New Size(730, 450)
    '    report.Bands(BandKind.Detail).Controls.Add(CopyChartControl(Me.ChartControl1))
    '    report.ShowRibbonPreviewDialog()
    '    ChartControl1.Dock = DockStyle.Fill
    'End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ViewChart()
    End Sub

    'Private Sub ChartWizzardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChartWizzardToolStripMenuItem.Click

    '    ' Create a new Wizard.
    '    Dim wizard As New ChartWizard(Me.ChartControl1)

    '    ' Obtain a Data page.
    '    Dim page As WizardDataPage = wizard.DataPage

    '    ' Hide the tabs related to a data source on the Data page.
    '    page.HiddenPageTabs.Add(DataPageTab.AutoCreatedSeries)
    '    page.HiddenPageTabs.Add(DataPageTab.SeriesBinding)

    '    ' Invoke the Wizard window.
    '    wizard.ShowDialog()
    'End Sub

    Private Sub cmdClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClose.ItemClick
        Me.Close()
    End Sub

    Private Sub BarCheckItem1_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItem1.CheckedChanged
        If BarCheckItem1.Checked = True Then
            pnlchart.Show()
        Else
            pnlchart.Hide()
        End If
    End Sub
End Class