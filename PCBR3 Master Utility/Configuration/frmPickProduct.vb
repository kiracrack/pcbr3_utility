Imports DevExpress.XtraEditors
Imports System.IO

Public Class frmPickProduct

    Private Sub frmPickProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        LoadGroupProduct()
        FilterFields()
    End Sub
    Public Sub LoadGroupProduct()
        LoadXgridLookupSearch("SELECT distinct(branchgroup) as 'Branch Group',group_concat(groupname) as productGroup  from tblproductgroup group by branchgroup", "tblproductgroup", txtbranchgroup, gridGroupProduct, Me)
        gridGroupProduct.Columns("productGroup").Visible = False
    End Sub

    Private Sub txtbranchgroup_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbranchgroup.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtbranchgroup.Properties.View.FocusedRowHandle.ToString)
        loadGroup()
    End Sub
    Public Sub loadGroup()
        LoadXgrid("Select id,productid,daysinterval as 'Grace Period', groupname as 'Group Name',LENGTH(productid) - LENGTH(REPLACE(productid, '|', '')) + 1  as 'No. Products' from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "' ", "tblproductgroup", Em, gridview1, Me)
        gridview1.Columns("id").Visible = False
        gridview1.Columns("productid").Visible = False
        gridview1.Columns("Grace Period").Width = 60

        gridview1.Columns("No. Products").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        gridview1.Columns("No. Products").SummaryItem.DisplayFormat = "{0:N0}"
        gridview1.Columns("No. Products").SummaryItem.Tag = 1
        CType(gridview1.Columns("No. Products").View, DevExpress.XtraGrid.Views.Grid.GridView).OptionsView.ShowFooter = True
        XgridColAlign("No. Products", gridview1, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("Grace Period", gridview1, DevExpress.Utils.HorzAlignment.Center)

        If txtbranchgroup.Text = "" Then
            cmdEdit.Enabled = False
        Else
            cmdEdit.Enabled = True
        End If

        If txtbranchgroup.Text = "[EditValue is null]" Or txtbranchgroup.Text = "" Then Exit Sub
        Dim grpproduct As String = ""
        For I = 0 To gridview1.RowCount - 1
            For Each splgroupname In gridview1.GetRowCellValue(I, "productid").ToString.Split(New Char() {"|"c})
                grpproduct = grpproduct + "prodcode <> '" & splgroupname & "' and "
            Next
        Next
        Dim grplessproduct As String = grpproduct.Remove(grpproduct.Length - 4, 4)
        Dim ungrpproduct As String = "" : Dim cntungroup As Integer = 0
        com.CommandText = "select distinct(prodname),prodcode  from master.loanwithterm inner join master.loanprod on loanprod.prodcode = loanwithterm.loanprod where " & grplessproduct & " order by prodname asc;"
        rst = com.ExecuteReader
        While rst.Read
            ungrpproduct = ungrpproduct + rst("prodcode").ToString & " - " & rst("prodname").ToString & Environment.NewLine
            cntungroup = cntungroup + 1
        End While
        rst.Close()
        lblungroupproduct.Text = "Ungroup Products " & cntungroup
    End Sub
    Public Sub FilterFields()
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        com.CommandText = "select distinct(prodname),prodcode  from master.loanwithterm inner join master.loanprod on loanprod.prodcode = loanwithterm.loanprod where prodname like '%" & txtfilter.Text & "%' order by prodname asc;"
        rst = com.ExecuteReader
        ls.Items.Clear()
        While rst.Read
            ls.Items.Add(rst("prodcode"), False)
            ls.Items.Item(rst("prodcode")).Description = rst("prodname").ToString
            ls.Items.Item(rst("prodcode")).Value = rst("prodcode").ToString
        End While
        rst.Close()
        Me.Cursor = Cursors.Default
        lblProducts.Text = "Total Active Products " & ls.Items.Count
    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim strqry As String = ""
        Dim strChecked As String = ""
        For n = 0 To ls.CheckedItems.Count - 1
            strChecked = strChecked + "prodcode='" & ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString + "' or "
        Next
        XtraMessageBox.Show("(" & strChecked.Remove(strChecked.Length - 4, 4) & ")", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        If ls.CheckedItems.Count = 0 Then
            XtraMessageBox.Show("Please select product atlease one in the product list!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ls.Focus()
            Exit Sub
        ElseIf txtdaysdelayed.Text = "" Then
            XtraMessageBox.Show("Please select delayed days!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtdaysdelayed.Focus()
            Exit Sub
        ElseIf txtgroupname.Text = "ENTER PRODUCT GROUP NAME" Or txtgroupname.Text = "" Then
            XtraMessageBox.Show("Please enter product group name!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtgroupname.Focus()
            Exit Sub
        End If
        Dim strChecked As String = ""
        For n = 0 To ls.CheckedItems.Count - 1
            strChecked = strChecked + ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString + "|"
        Next
        If mode.Text <> "edit" Then
            com.CommandText = "insert into tblproductgroup set daysinterval='" & txtdaysdelayed.Text & "', productid='" & strChecked.Remove(strChecked.Length - 1, 1) & "',groupname='" & txtgroupname.Text & "',branchgroup='" & txtbranchgroup.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblproductgroup set daysinterval='" & txtdaysdelayed.Text & "', productid='" & strChecked.Remove(strChecked.Length - 1, 1) & "', groupname='" & txtgroupname.Text & "',branchgroup='" & txtbranchgroup.Text & "' where id='" & id.Text & "'" : com.ExecuteNonQuery()
        End If
        com.CommandText = "delete from tblgroupimport where groupname='" & txtgroupname.Text & "' and branchgroup='" & txtbranchgroup.Text & "'" : com.ExecuteNonQuery()
        For n = 0 To ls.CheckedItems.Count - 1
            com.CommandText = "insert into tblgroupimport set prodcode='" & ls.Items.Item(ls.CheckedItems.Item(n)).Value.ToString & "', prodname='" & ls.Items.Item(ls.CheckedItems.Item(n)).ToString & "', groupname='" & txtgroupname.Text & "', branchgroup='" & txtbranchgroup.Text & "'" : com.ExecuteNonQuery()
        Next
        txtfilter.Text = ""
        mode.Text = "" : txtgroupname.Text = ""
        cmdEdit.Enabled = True
        cmdSearch.Enabled = False
        XtraMessageBox.Show("Product group successfully saved!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ck_micro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_micro.CheckedChanged

        Dim pr As String = ""
        com.CommandText = "select group_concat(distinct(prodcode)) as pr from master.loanwithterm inner join master.loanprod on loanprod.prodcode = loanwithterm.loanprod where  cancelled = 0 and pribal<> 0 and microfinance=1;" : rst = com.ExecuteReader
        While rst.Read
            pr = rst("pr").ToString
        End While
        rst.Close()

        If pr = "" Then
            XtraMessageBox.Show("No microfinance product found!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If ck_micro.Checked = True Then
            For n = 0 To ls.ItemCount - 1
                ls.Items.Item(n).CheckState = CheckState.Unchecked
            Next
            For Each word In pr.Split(New Char() {","c})
                ls.Items.Item(word).CheckState = CheckState.Checked
            Next
        Else
            For Each word In pr.Split(New Char() {","c})
                ls.Items.Item(word).CheckState = CheckState.Unchecked
            Next
        End If
    End Sub


    Private Sub mode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mode.EditValueChanged
        Dim proid As String = ""
        FilterFields()
        For Each word In txtproductid.Text.Split(New Char() {"|"c})
            If word <> "" Then
                ls.Items.Item(word).CheckState = CheckState.Checked
            End If
        Next
        cmdEdit.Enabled = False
        cmdcancel.Enabled = True
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        mode.Text = "" : txtgroupname.Text = ""
        cmdEdit.Enabled = True
        cmdSearch.Enabled = False
        FilterFields()
    End Sub

    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
        If gridview1.GetFocusedRowCellValue("id").ToString = "" Then
            XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If XtraMessageBox.Show("Are you sure you want to permanently delete this item? " & todelete, compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            com.CommandText = "delete from tblproductgroup where id='" & gridview1.GetFocusedRowCellValue("id").ToString & "'" : com.ExecuteNonQuery()
            DeleteRow("id", "id", "tblproductgroup", gridview1, Me)
        End If
        FilterFields()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        For n = 0 To ls.ItemCount - 1
            If CheckEdit1.Checked = True Then
                ls.Items.Item(n).CheckState = CheckState.Checked
            Else
                ls.Items.Item(n).CheckState = CheckState.Unchecked
            End If
        Next
    End Sub

    Private Sub txttitle_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfilter.EditValueChanged

    End Sub

    Private Sub txtfilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfilter.KeyPress
        If e.KeyChar = Chr(13) Then
            FilterFields()
        End If
    End Sub

    Private Sub EditProductGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        id.Text = gridview1.GetFocusedRowCellValue("id").ToString
        txtdaysdelayed.Text = gridview1.GetFocusedRowCellValue("Grace Period").ToString
        txtgroupname.Text = gridview1.GetFocusedRowCellValue("Group Name").ToString
        txtproductid.Text = gridview1.GetFocusedRowCellValue("productid").ToString
        mode.Text = "edit"
    End Sub

    Private Sub PickProductCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickProductCodeToolStripMenuItem.Click
        Dim pro As String = ""
        For Each word In gridview1.GetFocusedRowCellValue("productid").ToString.Split(New Char() {"|"c})
            If word <> "" Then
                pro += "loanprod.prodcode = '" & word & "' or "
            End If
        Next
        If pro <> "" Then
            pro = pro.Remove(pro.Length - 4, 4)
            InputBox("Copy and paste the code below", compname, "(" & pro & ")", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub lblungroupproduct_Click(sender As Object, e As EventArgs) Handles lblungroupproduct.Click
        Dim grpproduct As String = ""
        For I = 0 To gridview1.RowCount - 1
            For Each splgroupname In gridview1.GetRowCellValue(I, "productid").ToString.Split(New Char() {"|"c})
                grpproduct = grpproduct + "prodcode <> '" & splgroupname & "' and "
            Next
        Next
        Dim grplessproduct As String = grpproduct.Remove(grpproduct.Length - 4, 4)
        Dim ungrpproduct As String = "" : Dim cntungroup As Integer = 0
        com.CommandText = "select distinct(prodname),prodcode  from master.loanwithterm inner join master.loanprod on loanprod.prodcode = loanwithterm.loanprod where " & grplessproduct & " order by prodname asc;"
        rst = com.ExecuteReader
        While rst.Read
            ungrpproduct = ungrpproduct + rst("prodcode").ToString & " - " & rst("prodname").ToString & Environment.NewLine
            cntungroup = cntungroup + 1
        End While
        rst.Close()
        XtraMessageBox.Show(ungrpproduct, compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadGroup()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If txtbranchgroup.Text = "" Then
            XtraMessageBox.Show("Please select branch group", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog
        Dim tblparredaccsumlist As String = ""
        Dim tblportfoliowithpar As String = ""
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Parred Summary File (*.psf)|*.psf|All files (*.*)|*.*"
        saveFileDialog1.FileName = LCase(txtbranchgroup.Text) & " profile.psf"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim detailsFile As StreamWriter = Nothing
            If System.IO.File.Exists(saveFileDialog1.FileName) = True Then
                System.IO.File.Delete(saveFileDialog1.FileName)
            End If

            Dim objWriter As New System.IO.StreamWriter(saveFileDialog1.FileName)

            Dim sqlquery As String = ""
            objWriter.WriteLine("delete from tblproductgroup  where branchgroup='" & txtbranchgroup.Text & "';")
            com.CommandText = "select * from tblproductgroup where branchgroup='" & txtbranchgroup.Text & "'" : rst = com.ExecuteReader
            While rst.Read
                objWriter.WriteLine("insert into tblproductgroup set daysinterval='" & rst("daysinterval").ToString & "', productid='" & rst("productid").ToString & "', groupname='" & rst("groupname").ToString & "', branchgroup='" & rst("branchgroup").ToString & "'; ")
            End While
            rst.Close()

            objWriter.WriteLine("delete from tblgroupimport  where branchgroup='" & txtbranchgroup.Text & "';")
            com.CommandText = "select * from tblgroupimport where branchgroup='" & txtbranchgroup.Text & "'" : rst = com.ExecuteReader
            While rst.Read
                objWriter.WriteLine("insert into tblgroupimport set prodcode='" & rst("prodcode").ToString & "', prodname='" & rst("prodname").ToString & "', groupname='" & rst("groupname").ToString & "', branchgroup='" & rst("branchgroup").ToString & "'; ")
            End While
            rst.Close()

            objWriter.Close()
            XtraMessageBox.Show("Data successfully exported", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class
