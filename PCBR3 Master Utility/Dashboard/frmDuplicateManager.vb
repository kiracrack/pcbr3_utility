Imports MySql.Data.MySqlClient
Imports DevExpress.Skins
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmDuplicateManager
    Private printStr As String = ""
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Control) + (Keys.W) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    'Public Sub loadTables()
    '    LoadXgridLookupSearch("show tables from pcbr3", 0, from_table, gridtables, Me)
    '    from_table.Properties.DisplayMember = "Tables_in_pcbr3"
    '    from_table.Properties.ValueMember = "Tables_in_pcbr3"
    'End Sub
    'Private Sub from_table_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles from_table.EditValueChanged
    '    On Error Resume Next
    '    Dim iCurrentRow As Integer = CInt(from_table.Properties.View.FocusedRowHandle.ToString)
    '    from_table.Text = from_table.Properties.View.GetFocusedRowCellValue("Tables_in_pcbr3").ToString
    'End Sub
    Public Sub LoadTables2()
        Dim Coll As ComboBoxItemCollection = txtTable.Properties.Items
        Coll.Clear()
        com.CommandText = "show tables from master"
        rst = com.ExecuteReader
        Coll.BeginUpdate()
        Try
            While rst.Read
                Coll.Add(rst("Tables_in_master"))
            End While
            rst.Close()
        Finally
            Coll.EndUpdate()
        End Try
    End Sub
    Public Sub FilterFields()
        Dim combogrid As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        com.CommandText = "show fields from master." & txtTable.Text
        rst = com.ExecuteReader
        ls.Items.Clear()
        While rst.Read
            ls.Items.Add(rst("Field"), False)
            ls.Items.Item(rst("Field")).Description = rst("Field").ToString
            ls.Items.Item(rst("Field")).Value = rst("Field").ToString
        End While
        rst.Close()

    End Sub
    Public Sub filter()
        Dim strqry As String = ""
        Dim strfield As String = ""
        Dim strgroupby As String = ""
        Dim strChecked As String = ""
        For n = 0 To ls.CheckedItems.Count - 1
            strChecked = strChecked + ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString + ","
        Next

        If strChecked <> "" Then
            strChecked = strChecked.Remove(strChecked.Count - 1, 1)
            Dim words As String() = strChecked.Split(New Char() {","c})
            ' Use For Each loop over words and display them
            Dim word As String
            Dim cnt = 1
            For Each word In words

                If cnt = 1 Then
                    strgroupby = txtTable.Text & "." & word.Replace(" ", "")
                End If
                If words.Count = cnt Then
                    strqry = strqry & txtTable.Text & "." & word.Replace(" ", "") & " = dup." & word.Replace(" ", "")
                    strfield = strfield & txtTable.Text & "." & word.Replace(" ", "")
                Else
                    strqry = strqry & txtTable.Text & "." & word.Replace(" ", "") & " = dup." & word.Replace(" ", "") & " and "
                    strfield = strfield & txtTable.Text & "." & word.Replace(" ", "") & ","
                End If
                cnt = cnt + 1
            Next
            printStr = strfield
            If CheckEdit1.Checked = True Then
                LoadXgrid("SELECT * FROM master." & txtTable.Text & " " _
                          + " INNER JOIN (SELECT " & strfield & " FROM master." & txtTable.Text & " " _
                          + " GROUP BY " & strfield & " HAVING count(" & strgroupby & ") > 1) dup ON " & strqry & " order by " & strgroupby & " asc", txtTable.Text, Em, gridview1, Me)
            Else
                LoadXgrid("SELECT  " & strfield & " FROM master." & txtTable.Text & " " _
                          + " INNER JOIN (SELECT " & strfield & " FROM master." & txtTable.Text & " " _
                          + " GROUP BY " & strfield & " HAVING count(" & strgroupby & ") > 1) dup ON " & strqry & " order by " & strgroupby & " asc", txtTable.Text, Em, gridview1, Me)
            End If
        Else
            LoadXgrid("SELECT * FROM master." & txtTable.Text, txtTable.Text, Em, gridview1, Me)
        End If
        'MsgBox(strgroupby + Chr(13) + strqry + Chr(13) + Chr(13) + strfield)

        gridview1.Columns(0).Width = 230
        gridview1.Columns(0).SummaryItem.SummaryType = SummaryItemType.Count
        gridview1.Columns(0).SummaryItem.DisplayFormat = "Total Row(s) {0}"
        gridview1.Columns(0).SummaryItem.Tag = 1
        CType(gridview1.Columns(0).View, GridView).OptionsView.ShowFooter = True
    End Sub

    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SkinManager.EnableMdiFormSkins()
        reportcount(Me.Name.ToString)
        txttitle.Text = reportTitle(Me.Name.ToString)
        txtCustom.Text = reportcustomtext(Me.Name.ToString)
        Me.Text = txttitle.Text
        ViewGridtype(gridview1)
        LoadTables2()
    End Sub

    Public Sub printreport()
        com.CommandText = "update tblreportsetting set title='" & txttitle.Text & "', customtext='" & txtCustom.Text & "' where formname='" & Me.Name.ToString & "' " : com.ExecuteNonQuery()
        Dim report As New rptOtherReport()
        report.Landscape = rdoreintation.EditValue.ToString
        report.PaperKind = System.Drawing.Printing.PaperKind.Letter
        report.txttitle.Text = txttitle.Text & " - Query by " & printStr.Replace(txtTable.Text & ".", "")
        
        report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        report.ShowRibbonPreviewDialog()
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        printreport()
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClose.ItemClick
        Me.Close()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        filter()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        FilterFields()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If ls.CheckedItems.Count = 0 Then Exit Sub
        filter()
    End Sub
End Class