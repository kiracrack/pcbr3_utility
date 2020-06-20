Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors

Public Class frmReportDeveloper
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Control + Keys.T Then
            BarButtonItem2.PerformClick()

        ElseIf keyData = Keys.Control + Keys.S Then
            SimpleButton2.PerformClick()

        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmReportDeveloper_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If countqry("tblreportconfig", "rptid='" & id.Text & "' and status=1") <> 0 Then
            If XtraMessageBox.Show("Report template currently Unsaved, Are you sure you want to exit? " & Environment.NewLine & "NOTE: current Configuration will be lost", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                'Me.Close()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmPrintQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        If mode.Text <> "edit" Then
            id.Text = getReportTemplateID()
            com.CommandText = "delete from tblreportconfig where status=1" : com.ExecuteNonQuery()
            ClearColumn()
        End If
    End Sub
    Public Sub ClearReports()
        id.Text = getReportTemplateID()
        txtReportTitle.Text = ""
        txtReportQuery.Text = ""
        CheckEdit1.Checked = False
        mode.Text = ""

        filter()
    End Sub
    Public Sub ClearColumn()
        colid.Text = ""
        txtcolname.Text = ""
        raddisplaytype.SelectedIndex = 0
        chkGroupColumn.Checked = False

        chkGroupSummary.Checked = False
        txtGroupSummary.Text = ""
        cbGroupsummary.Text = ""

        chkGroupGeneral.Checked = False
        txtgeneralSummary.Text = ""
        cbGeneralSummary.Text = ""
        colmode.Text = ""

        Dim Coll As ComboBoxItemCollection = txtsortOrder.Properties.Items
        Coll.Clear()
        For I = countqry("tblreportconfig", "rptid='" & id.Text & "'") + 1 To 1 Step -1
            Coll.Add(I)
        Next I
        txtsortOrder.SelectedIndex = 0
    End Sub
    Public Sub filter()
        LoadXgrid("Select id, sortorder as 'No.', colname as 'Column Name', " _
                    + " case when coltype=0 then 'General' when coltype=1 then 'Currency' when coltype=2 then 'Number' end as 'Display Type',  " _
                    + " colgroup as 'Group', colgrpsum as 'Sum. Group', colgensum as 'General Sum.'  from tblreportconfig where rptid='" & id.Text & "' order by sortorder asc", "tblreportconfig", Em, GridView1, Me)
        GridView1.Columns("id").Visible = False
        GridView1.Columns("No.").Width = 30
        XgridColAlign("No.", GridView1, DevExpress.Utils.HorzAlignment.Center)

    End Sub
    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        If txtcolname.Text = "" Then
            XtraMessageBox.Show("Please enter Column Name!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcolname.Focus()
            Exit Sub
        End If
        If chkGroupSummary.CheckState = CheckState.Checked Then
            If txtGroupSummary.Text = "" Then
                XtraMessageBox.Show("Please select Column to Generate Summary. use separate by COMMA if incase double column!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtGroupSummary.Focus()
                Exit Sub
            ElseIf cbGroupsummary.Text = "" Then
                XtraMessageBox.Show("Please select Group summary type!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbGroupsummary.Focus()
                Exit Sub
            End If
        End If
        If chkGroupGeneral.CheckState = CheckState.Checked Then
            If cbGeneralSummary.Text = "" Then
                XtraMessageBox.Show("Please select General summary type!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbGeneralSummary.Focus()
                Exit Sub
            End If
        End If
        If colmode.Text <> "edit" Then
            com.CommandText = "insert into tblreportconfig set rptid='" & id.Text & "', " _
                                + " colname='" & rchar(txtcolname.Text) & "', " _
                                + " coltype='" & raddisplaytype.SelectedIndex & "', " _
                                + " colgroup='" & chkGroupColumn.CheckState & "', " _
                                + " colgrpsum='" & chkGroupSummary.CheckState & "', " _
                                + " colgrpsumtext='" & rchar(txtGroupSummary.Text) & "', " _
                                + " colgrpsumtype='" & cbGroupsummary.Text & "', " _
                                + " colgensum='" & chkGroupGeneral.CheckState & "', " _
                                + " colgensumtext='" & rchar(txtgeneralSummary.Text) & "', " _
                                + " colgensumtype='" & cbGeneralSummary.Text & "', " _
                                + " sortorder=" & txtsortOrder.Text & ", alignment='" & rdalignment.EditValue.ToString & "'"
            com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblreportconfig set " _
                                + " colname='" & rchar(txtcolname.Text) & "', " _
                                + " coltype='" & raddisplaytype.SelectedIndex & "', " _
                                + " colgroup='" & chkGroupColumn.CheckState & "', " _
                                + " colgrpsum='" & chkGroupSummary.CheckState & "', " _
                                + " colgrpsumtext='" & rchar(txtGroupSummary.Text) & "', " _
                                + " colgrpsumtype='" & cbGroupsummary.Text & "', " _
                                + " colgensum='" & chkGroupGeneral.CheckState & "', " _
                                + " colgensumtext='" & rchar(txtgeneralSummary.Text) & "', " _
                                + " colgensumtype='" & cbGeneralSummary.Text & "', " _
                                + " sortorder=" & txtsortOrder.Text & ",alignment='" & rdalignment.EditValue.ToString & "' " _
                                + " where rptid='" & id.Text & "' and id='" & colid.Text & "'"
            com.ExecuteNonQuery()
        End If
        filter()
        ClearColumn()
    End Sub

    Private Sub mode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mode.EditValueChanged
        If mode.Text = "" Then Exit Sub
        com.CommandText = "select * from tblreporttemplate where rptid='" & id.Text & "'"
        rst = com.ExecuteReader
        While rst.Read
            txtReportTitle.Text = rst("rptname").ToString
            txtReportQuery.Text = rst("rptquery")
            CheckEdit1.Checked = rst("datequery")
        End While
        rst.Close()
        filter()
        Dim Coll As ComboBoxItemCollection = txtsortOrder.Properties.Items
        Coll.Clear()
        For I = countqry("tblreportconfig", "rptid='" & id.Text & "'") + 1 To 1 Step -1
            Coll.Add(I)
        Next I
    End Sub

    Private Sub colmode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colmode.EditValueChanged
        If colmode.Text = "" Then Exit Sub
        Dim strParent As String = ""
        com.CommandText = "select * from tblreportconfig where id='" & colid.Text & "'"
        rst = com.ExecuteReader
        While rst.Read
            txtcolname.Text = rst("colname").ToString
            raddisplaytype.SelectedIndex = Val(rst("coltype").ToString)
            chkGroupColumn.Checked = rst("colgroup")

            chkGroupSummary.Checked = rst("colgrpsum")
            txtGroupSummary.Text = rst("colgrpsumtext").ToString
            cbGroupsummary.Text = rst("colgrpsumtype").ToString

            chkGroupGeneral.Checked = rst("colgensum")
            txtgeneralSummary.Text = rst("colgensumtext").ToString
            cbGeneralSummary.Text = rst("colgensumtype").ToString

            txtsortOrder.Text = rst("sortorder").ToString
            rdalignment.EditValue = rst("alignment").ToString
        End While
        rst.Close()
        Dim Coll As ComboBoxItemCollection = txtsortOrder.Properties.Items
        Coll.Clear()
        For I = countqry("tblreportconfig", "rptid='" & id.Text & "'") + 1 To 1 Step -1
            Coll.Add(I)
        Next I
        ' txtsortOrder.SelectedIndex = 0
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If GridView1.GetFocusedRowCellValue("Column Name") = "" Then
            XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        colmode.Text = ""
        colid.Text = GridView1.GetFocusedRowCellValue("id").ToString
        colmode.Text = "edit"
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        If txtReportTitle.Text = "" Then
            XtraMessageBox.Show("Please enter report name!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReportTitle.Focus()
            Exit Sub
        ElseIf txtReportQuery.Text = "" Then
            XtraMessageBox.Show("Please enter report query!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReportQuery.Focus()
            Exit Sub
        End If
        If mode.Text <> "edit" Then
            com.CommandText = "insert into tblreporttemplate set rptid='" & id.Text & "', rptname='" & rchar(txtReportTitle.Text) & "', rptquery='" & rchar(txtReportQuery.Text) & "',datequery='" & CheckEdit1.CheckState & "'" : com.ExecuteNonQuery()
            com.CommandText = "update tblreportconfig set status=0 where rptid='" & id.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblreporttemplate set rptname='" & rchar(txtReportTitle.Text) & "', rptquery='" & rchar(txtReportQuery.Text) & "',datequery='" & CheckEdit1.CheckState & "' where rptid='" & id.Text & "'" : com.ExecuteNonQuery()
            com.CommandText = "update tblreportconfig set status=0 where rptid='" & id.Text & "'" : com.ExecuteNonQuery()
        End If
        ClearReports()
        ClearColumn()
        filter()
        XtraMessageBox.Show("Report Template Successfully Save!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub chkGroupSummary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGroupSummary.CheckedChanged
        If chkGroupSummary.CheckState = CheckState.Unchecked Then
            txtGroupSummary.Enabled = False
            txtGroupSummary.Text = ""
            cbGroupsummary.Enabled = False
            cbGroupsummary.SelectedIndex = -1
        Else
            txtGroupSummary.Enabled = True
            cbGroupsummary.Enabled = True
        End If
    End Sub

    Private Sub chkGroupGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGroupGeneral.CheckedChanged
        If chkGroupGeneral.CheckState = CheckState.Unchecked Then
            txtgeneralSummary.Enabled = False
            txtgeneralSummary.Text = ""
            cbGeneralSummary.Enabled = False
            cbGeneralSummary.SelectedIndex = -1
        Else
            txtgeneralSummary.Enabled = True
            cbGeneralSummary.Enabled = True
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        frmReportTemplate.ShowDialog(Me)
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        ClearReports()
        ClearColumn()
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        XtraMessageBox.Show("HELP" & Environment.NewLine & Environment.NewLine _
                        + "1. Please run your mysql query first to check your syntax is working. " & Environment.NewLine _
                        + "2. Please set your each column using Ex. [colname as 'Column Name'] " & Environment.NewLine _
                        + "3. Use identifier field for date format using for FROM date and TO date Select " & Environment.NewLine _
                        & Environment.NewLine & "1. Format From [{from_fulldate},{from_year},{from_month},{from_day}]" _
                        & Environment.NewLine & "2. Format To [{to_fulldate},{to_year},{to_month},{to_day}]", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class