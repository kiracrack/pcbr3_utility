Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraCharts.Wizard

Public Class frmGraph
    Private Sub frmSummaryRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Public Function ViewChartbyAO(ByVal datequery As Date, ByVal productgroup As String)
        dst = New DataSet
        msda = New MySqlDataAdapter("Select distinct(branch) as 'branch' from tblparredaccsumlist where date_format(parreddate,'%Y-%m')='" & datequery.ToString("yyyy-MM") & "' and  groupname='" & productgroup & "'", conn)
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim BarChart As New ChartControl()

                com.CommandText = "SELECT *,ifnull(SUBSTRING_INDEX(SUBSTRING_INDEX(lcase(ao), '_', 1), '_', -1), 'NO OFFICER') as 'Account Officer', " _
                 + " ifnull(round((sum(ttlpar)/(select sum(pribal) from tblportfoliowithpar where groupname='" & productgroup & "' and branch = tblparredaccsumlist.branch and parreddate=tblparredaccsumlist.parreddate  and officer = tblparredaccsumlist.ao) ) * 100,2),0.00)  as 'PAR Ratio' " _
                 + " FROM `tblparredaccsumlist` where  date_format(parreddate,'%Y-%m')='" & datequery.ToString("yyyy-MM") & "' and groupname='" & productgroup & "' and branch='" & .Rows(cnt)("branch").ToString() & "' " _
                 + " group by date_format(parreddate,'%Y-%m'), ao" : rst = com.ExecuteReader
                While rst.Read
                    Dim series1 As New Series(rst("Account Officer").ToString, ViewType.Area)
                    series1.Points.Add(New SeriesPoint(rst("parreddate").ToString, rst("PAR Ratio")))
                    BarChart.Series.AddRange(New Series() {series1})
                    'series1.Points(0).Annotations.AddTextAnnotation(rst("Product Group").ToString, rst("Product Group").ToString)

                    BarChart.Size = New Size(500, 500)
                    BarChart.Dock = DockStyle.Left
                    BarChart.Legend.FillStyle.FillMode = FillMode.Solid
                    'Dim view As SideBySideBarSeriesView = CType(BarChart.Series(rst("Account Officer").ToString).View, SideBySideBarSeriesView)
                    'view.FillStyle.FillMode = FillMode.Solid
                End While
                rst.Close()
                BarChart.Legend.AlignmentVertical = LegendAlignmentVertical.Top
                BarChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right

                Dim chartTitle1 As New ChartTitle()
                chartTitle1.Text = .Rows(cnt)("branch").ToString()
                chartTitle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                BarChart.Titles.Add(chartTitle1)
                BarChart.Legend.Visible = False
                XtraScrollableControl1.Controls.Add(BarChart)
                ' DirectCast(BarChart.Diagram, DevExpress.XtraCharts.XYDiagram).Rotated = True
            End With
        Next

    End Function

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
 
 
End Class