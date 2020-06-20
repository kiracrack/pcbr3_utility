Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports MySql.Data.MySqlClient

Public Class frmPaymentHistory

    Public Sub filterPaymentsnojoin()
        Dim curryear As Date = Now.ToShortDateString
      
        clearGrid()
        dst = New DataSet
        msda = New MySqlDataAdapter("select * from  master.loanwithterm  inner join master.loanprod on master.loanwithterm.loanprod =  master.loanprod.prodcode where loanwithterm.custcode = '" & custcode.Text & "' order by loandate", conn)
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                Dim years As String = ""
                Dim yearcount As Integer = 0
                Dim totalpayment As Double = 0
                Dim beginyear As Date = ConvertDate(.Rows(cnt)("loandate").ToString())
                Dim endyear As Date = ConvertDate(qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar"))
                Dim year As Date = beginyear
                yearcount = DateDiff(DateInterval.Month, beginyear, curryear)
                For I = 0 To yearcount
                    If year.AddMonths(I).ToString("yyyyMM") >= 201110 And year.AddMonths(I).ToString("yyyyMM") < endyear.ToString("yyyyMM") Then
                        years = "db" & year.AddMonths(I).ToString("yyyyMM")
                        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='" & years & "' and  TABLE_NAME = 'lnwtermdet' AND COLUMN_NAME = 'pmntdate'") <> 0 Then
                            com.CommandText = "SELECT CAST(concat((select prodname from master.loanprod where loanprod.prodcode = master.loanwithterm.loanprod), ' - ',loandate) AS CHAR(50)) as 'Product', " _
                                                          + " lnwtermdet.principal as 'pmntamount', date_format(lnwtermdet.pmntdate, '%M %d, %Y') as pmtdate,chgpmnt1,chgpmnt2,chgpmnt3,chgpmnt4 " _
                                                          + " FROM master.loanwithterm " _
                                                          + " inner join " & years & ".lnwtermdet on " & years & ".lnwtermdet.lnrefno = loanwithterm.refno " _
                                                          + " where loanwithterm.refno = '" & .Rows(cnt)("refno").ToString() & "'" : rst = com.ExecuteReader
                            While rst.Read
                                AddRowXgrid(gridview1)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Product", rst("Product").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Amount", Format(rst("pmntamount"), "n"))
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Date Payment", rst("pmtdate").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges1", rst("chgpmnt1").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges2", rst("chgpmnt2").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges3", rst("chgpmnt3").ToString)
                                gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Charges4", rst("chgpmnt4").ToString)
                            End While
                            rst.Close()
                        End If
                    End If
                Next I
            End With
        Next cnt


        ' gridview1.Columns("Product").Width = 330
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
        gridview1.MoveLast()

    End Sub

    Private Sub frmPaymentHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearGrid()
        filterPaymentsnojoin()
        gridview1.Columns("Product").Group()
        gridview1.CollapseAllGroups()
    End Sub
    Public Sub clearGrid()
        LoadXgrid("select '' as 'Product', '' as Amount,'' as 'Charges1', '' as 'Charges2','' as 'Charges3','' as 'Charges4',   '' as 'Date Payment' from master.loanwithterm where refno='0'", "master.loanwithterm", Em, gridview1, Me)
    End Sub
End Class