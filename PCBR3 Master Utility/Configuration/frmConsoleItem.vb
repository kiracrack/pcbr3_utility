Imports DevExpress.XtraEditors
Imports DevExpress
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls
Imports MySql.Data.MySqlClient

Public Class frmConsoleItem
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

#Region "CONSOLIDATION ITEMS"
    Public Sub LoadItem()
        LoadXgridLookupEdit("SELECT itemcode as 'Code', itemname as 'Select Parent'  from tblconsolitem where parentcode = '' order by itemname asc", "tblconsolitem", txtCategory, gridview2, Me)
        XgridColAlign("Code", gridview2, DevExpress.Utils.HorzAlignment.Center)
        gridview2.Columns("Code").Visible = False

    End Sub
    Private Sub txtArea_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCategory.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtCategory.Properties.View.FocusedRowHandle.ToString)
        catid.Text = txtCategory.Properties.View.GetFocusedRowCellValue("Code").ToString()
        txtCategory.Text = txtCategory.Properties.View.GetFocusedRowCellValue("Select List").ToString()
    End Sub
    Public Sub filter()
        LoadXgrid("Select itemcode, sortorder as 'No.',itemcode as 'Item Code', " _
                    + " case when parentcode='' then itemname when parentcode<>'' then concat('  -  ', itemname) end as 'Item Name' from tblconsolitem order by sortorder asc", "tblconsolitem", Em, GridView1, Me)
        GridView1.Columns("itemcode").Visible = False
        'GridView1.Columns("Code").Visible = False
        GridView1.Columns("Item Code").Width = 80
        XgridColAlign("Item Code", GridView1, Utils.HorzAlignment.Center)
        XgridColAlign("No.", GridView1, Utils.HorzAlignment.Center)

    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        If txtdesc.Text = "" Then
            XtraMessageBox.Show("Please provide Item Name!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtdesc.Focus()
            Exit Sub
        End If
        RemoveSpecialChar(PanelControl1)
        If mode.Text <> "edit" Then
            If countqry("tblconsolitem", "itemcode='" & id.Text & "'") <> 0 Then
                XtraMessageBox.Show("Duplicate Item ID Please use unique one!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                id.Focus()
                Exit Sub
            End If
            com.CommandText = "insert into tblconsolitem set itemcode='" & id.Text & "', parentcode='" & catid.Text & "', itemname='" & txtdesc.Text & "', computetype='" & txtcomtype.Text & "', strquery='" & txtQuerystring.Text & "', displaytype='" & RadioGroup1.SelectedIndex & "', sortorder='" & txtsort.Text & "'"
            com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblconsolitem set itemname='" & txtdesc.Text & "', parentcode='" & catid.Text & "', computetype='" & txtcomtype.Text & "', strquery='" & txtQuerystring.Text & "',displaytype='" & RadioGroup1.SelectedIndex & "', sortorder='" & txtsort.Text & "' where  itemcode='" & id.Text & "'"
            com.ExecuteNonQuery()
        End If
        clearfields()
        'filter()
        XtraMessageBox.Show("Item successfully save!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub clearfields()
        id.Text = getconsoleItemcode()

        Dim Coll As ComboBoxItemCollection = txtsort.Properties.Items
        Coll.Clear()
        For I = countrecord("tblconsolitem") + 1 To 1 Step -1
            Coll.Add(I)
        Next I
        txtsort.SelectedIndex = 0

        txtdesc.Text = ""
        txtcomtype.SelectedIndex = -1
        RadioGroup1.SelectedIndex = 0
        txtCategory.Properties.DataSource = Nothing
        txtCategory.Text = ""
        catid.Text = ""
        LoadItem()
        txtQuerystring.Text = ""
        mode.Text = ""
    End Sub

    Private Sub mode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mode.EditValueChanged
        If mode.Text = "" Then Exit Sub
        Dim strParent As String = ""
        txtCategory.Properties.DataSource = Nothing
        txtCategory.Text = ""
        catid.Text = ""
        com.CommandText = "select * from tblconsolitem where itemcode='" & id.Text & "'"
        rst = com.ExecuteReader
        While rst.Read
            txtdesc.Text = rst("itemname").ToString
            catid.Text = rst("parentcode").ToString
            txtcomtype.Text = rst("computetype").ToString
            txtQuerystring.Text = rst("strquery").ToString
            RadioGroup1.SelectedIndex = rst("displaytype")
            txtsort.Text = rst("sortorder").ToString
        End While
        rst.Close()
        LoadItem()
        txtCategory.Text = qrysingledata("itemname", "itemname", " where itemcode = '" & catid.Text & "'", "tblconsolitem")
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If GridView1.GetFocusedRowCellValue("itemcode") = "" Then
            XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        mode.Text = ""
        id.Text = GridView1.GetFocusedRowCellValue("itemcode").ToString
        mode.Text = "edit"
    End Sub


    Private Sub frmProductCat_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        clearfields()
    End Sub

    Private Sub frmProductCat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        LoadSignatories()
        LoadOffice()
        clearfields()
        LoadItem()
        filter()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        filter()
    End Sub

    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
        If GridView1.GetFocusedRowCellValue("itemcode") = "" Then
            XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If XtraMessageBox.Show("Are you sure you want to permanently delete this item? " & todelete, compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            DeleteRow("itemcode", "itemcode", "tblconsolitem", GridView1, Me)
        End If
        id.Text = getconsoleItemcode()
    End Sub

    Private Sub BarLargeButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClose.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        clearfields()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        txtCategory.Properties.DataSource = Nothing
        txtCategory.Text = ""
        catid.Text = ""
        LoadItem()
    End Sub

    Private Sub txtcomtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcomtype.SelectedIndexChanged
        If txtcomtype.Text = "MANUAL" Then
            tblTip.Text = "This feature is alow user to manual entry data"

        ElseIf txtcomtype.Text = "SQL QUERY" Then
            tblTip.Text = " please use [ as total ] for identifier field and for date query use [ {datefull},{year},{month},{day} ]"

        ElseIf txtcomtype.Text = "SQL QUERY GENERATOR" Then
            tblTip.Text = "please use [ select concat('YOUR FINAL QUERY HERE') as query ] and , for date query use [ {datefull},{year},{month},{day} ]"

        ElseIf txtcomtype.Text = "PARENT" Then
            tblTip.Text = "This feature is automatically generate total from child computation"

        ElseIf txtcomtype.Text = "SUM OF ITEM" Then
            tblTip.Text = "Please use separated by computation sign (+ - * / % ) then item ID. Ex. [ (itemid+itemid)/itemid ]"

        Else
            tblTip.Text = "Please select Computation type"

        End If
    End Sub
#End Region

#Region "SIGNATORIES"
    Public Sub LoadOffice()
        LoadXgridLookupSearch("SELECT branchcode as 'Code', ucase(branchname) as 'Select List' from master.branches where ho = 0 order by branchname asc", "master.branches", txtOffice, GridOffice, Me)
        XgridColAlign("Code", GridOffice, DevExpress.Utils.HorzAlignment.Center)
        GridOffice.Columns("Code").Visible = False

    End Sub
    Private Sub txtoffice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOffice.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtOffice.Properties.View.FocusedRowHandle.ToString)
        officecode.Text = txtOffice.Properties.View.GetFocusedRowCellValue("Code").ToString()
        txtOffice.Text = txtOffice.Properties.View.GetFocusedRowCellValue("Select List").ToString()
    End Sub
    Public Sub LoadSignatories()
        Try
            Dim stroffice As String = ""
            com.CommandText = "select *, (select ucase(branchname) from master.branches where branchcode=tblsignatories.officecode) as office from tblsignatories"
            rst = com.ExecuteReader
            While rst.Read
                txttitle1.Text = rst("title1").ToString
                txtname1.Text = rst("name1").ToString
                txtposition1.Text = rst("position1").ToString
                txttitle2.Text = rst("title2").ToString
                txtname2.Text = rst("name2").ToString
                txtposition2.Text = rst("position2").ToString
                txttitle3.Text = rst("title3").ToString
                txtname3.Text = rst("name3").ToString
                txtposition3.Text = rst("position3").ToString
                officecode.Text = rst("officecode").ToString
                stroffice = rst("office").ToString
            End While
            rst.Close()
            txtOffice.Text = stroffice
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        If countrecord("tblsignatories") = 0 Then
            com.CommandText = "insert into tblsignatories set " _
                                + " title1='" & txttitle1.Text & "', " _
                                + " name1='" & txtname1.Text & "', " _
                                + " position1='" & txtposition1.Text & "', " _
                                + " title2='" & txttitle2.Text & "', " _
                                + " name2='" & txtname2.Text & "', " _
                                + " position2='" & txtposition2.Text & "', " _
                                + " title3='" & txttitle3.Text & "', " _
                                + " name3='" & txtname3.Text & "', " _
                                + " position3='" & txtposition3.Text & "', " _
                                + " officecode='" & officecode.Text & "'"
            com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblsignatories set " _
                                + " title1='" & txttitle1.Text & "', " _
                                + " name1='" & txtname1.Text & "', " _
                                + " position1='" & txtposition1.Text & "', " _
                                + " title2='" & txttitle2.Text & "', " _
                                + " name2='" & txtname2.Text & "', " _
                                + " position2='" & txtposition2.Text & "', " _
                                + " title3='" & txttitle3.Text & "', " _
                                + " name3='" & txtname3.Text & "', " _
                                + " position3='" & txtposition3.Text & "', " _
                                + " officecode='" & officecode.Text & "'"
            com.ExecuteNonQuery()
        End If
        XtraMessageBox.Show("Signatories Successfully Updated", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        loadcompsettings()
    End Sub
#End Region

   
    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        frmPickProduct.ShowDialog(Me)
    End Sub

    Private Sub ReIndexSortOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReIndexSortOrderToolStripMenuItem.Click
        Dim c As Integer = 1
        For I = 0 To GridView1.DataRowCount - 1
            com.CommandText = "update tblconsolitem set sortorder=" & c & " where itemcode='" & GridView1.GetRowCellValue(I, "itemcode").ToString() & "'" : com.ExecuteNonQuery()
            c = c + 1
        Next
        filter()
    End Sub

    Private Sub DuplicateItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateItemToolStripMenuItem.Click
        com.CommandText = "insert into tblconsolitem (itemcode,parentcode,itemname,computetype,strquery,displaytype,sortorder) select '" & getconsoleItemcode() & "' ,parentcode,itemname,computetype,strquery,displaytype,sortorder from tblconsolitem where itemcode='" & GridView1.GetFocusedRowCellValue("itemcode").ToString & "'" : com.ExecuteNonQuery()
        filter()
    End Sub
End Class