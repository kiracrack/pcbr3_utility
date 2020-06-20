Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Public Class frmUsersAccounts

    Private gridsel As String = ""
    Private cpass As Boolean = False
    Private gridid As String = ""

    Private Sub frmUsersAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        txtunitcodeaccount.Text = Nothing
        txtuserid.Text = getuserid()
        LoadToComboBox("designation", "tblaccounts", txtdesignation, True) : txtdesignation.SelectedIndex = -1
        LoadToComboBox("unitcode", "tblaccounts", txtunitcodeaccount, True) : txtunitcodeaccount.SelectedIndex = -1

        filteruser()
        If globalpermission = 0 Then
            permission.Properties.Items.Item(0).Enabled = True
        Else
            permission.Properties.Items.Item(0).Enabled = False
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub
  
    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangepass.ItemClick
        If globalpermission <> 1 And globalpermission <> 0 And globaluserid <> gridid Then
            XtraMessageBox.Show("You have no permission to do this action! please contact your administrative control", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If mode.Text <> "edit" Then
            XtraMessageBox.Show("Please select user to continue process!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        cpass = True
        txtpassword.Properties.ReadOnly = False
        txtverify.Properties.ReadOnly = False
    End Sub
    Private Sub RefreshToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem1.Click
        filteruser()
        clearaccount()
    End Sub
    Public Sub filteruser()
        Dim qry As String = ""
        If globalpermission = 1 Or globalpermission = 0 Then
            qry = " CASE WHEN permission='0' THEN 'Super Admin' WHEN permission='1' THEN 'Administrator'  WHEN permission='2' THEN 'Management'  WHEN permission='3' THEN 'Transaction'  WHEN permission='4' THEN 'Limited user' END  as 'Access Permission', "
        Else
            qry = ""
        End If
        LoadXgrid("Select accountid as 'Account ID',unitcode as 'Unit Code', " _
                                    + " username as 'Username'," _
                                    + " fullname as 'Fullname', " _
                                    + qry _
                                    + " datereg as 'Registered' " _
                                    + " from tblaccounts " _
                                    + " order by fullname asc", "tblaccounts", Em, GridView1, Me)

        If globalpermission = 1 Or globalpermission = 0 Then
            GridView1.Columns("Unit Code").Visible = True
        Else
            GridView1.Columns("Unit Code").Visible = False
        End If
      
        XgridColAlign("Account ID", GridView1, DevExpress.Utils.HorzAlignment.Center)
        XgridColAlign("Unit Code", GridView1, DevExpress.Utils.HorzAlignment.Center)

    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.ItemClick
        If txtunitcodeaccount.Text = "" Or txtunitcodeaccount.Text = "UNIT CODE" Then
            XtraMessageBox.Show("Please select unit code! ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtunitcodeaccount.Focus()
            Exit Sub
        ElseIf txtfullname.Text = "" Then
            XtraMessageBox.Show("Please enter fullname.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfullname.Focus()
            Exit Sub
        ElseIf txtdesignation.Text = "" Then
            XtraMessageBox.Show("Please select designation.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtdesignation.Focus()
            Exit Sub
        ElseIf txtusername.Text = "" Then
            XtraMessageBox.Show("Please enter username!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtusername.Focus()
            Exit Sub
        ElseIf permission.SelectedIndex = -1 Then
            XtraMessageBox.Show("Please select previlege! ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            permission.Focus()
            Exit Sub
        ElseIf countqry("tblaccounts", "fullname = '" & txtfullname.Text & "'") <> 0 And mode.Text = "" Then
            XtraMessageBox.Show("Account name already exist!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtfullname.Focus()
            Exit Sub
        End If

        Dim passqry As String = ""
        If mode.Text = "edit" Then
            If cpass = True Then
                If txtpassword.Text = "" Then
                    XtraMessageBox.Show("Please enter password!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtpassword.Focus()
                    Exit Sub
                ElseIf txtverify.Text = "" Then
                    XtraMessageBox.Show("Please enter verify password!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtverify.Focus()
                    Exit Sub
                ElseIf txtpassword.Text <> txtverify.Text Then
                    XtraMessageBox.Show("Password did not match! ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtpassword.Text = ""
                    txtverify.Text = ""
                    txtpassword.Focus()
                    Exit Sub
                End If
                passqry = " username='" & txtusername.Text & "', password='" & encryptpass(txtverify.Text) & "', "
            Else
                passqry = ""
            End If
            If XtraMessageBox.Show("Are you sure you want update user account of " & txtfullname.Text & "?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                com.CommandText = "update tblaccounts set fullname = '" & txtfullname.Text & "', " _
                                 + " designation='" & txtdesignation.Text & "', " _
                                 + " unitcode = '" & txtunitcodeaccount.Text & "', " _
                                 + passqry _
                                 + " permission = '" & permission.EditValue.ToString & "' where accountid='" & txtuserid.Text & "' "
            Else
                Exit Sub
            End If

        Else
            If txtpassword.Text = "" Then
                XtraMessageBox.Show("Please enter password!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpassword.Focus()
                Exit Sub
            ElseIf txtverify.Text = "" Then
                XtraMessageBox.Show("Please enter verify password!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtverify.Focus()
                Exit Sub
            ElseIf txtpassword.Text <> txtverify.Text Then
                XtraMessageBox.Show("Password did not match! ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpassword.Text = ""
                txtverify.Text = ""
                txtpassword.Focus()
                Exit Sub
            End If
            If XtraMessageBox.Show("Are you sure you want create user account of " & txtfullname.Text & " ? ", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                com.CommandText = "insert into tblaccounts set accountid='" & txtuserid.Text & "', fullname = '" & txtfullname.Text & "', " _
                                                + " designation='" & txtdesignation.Text & "', " _
                                                + " unitcode = '" & txtunitcodeaccount.Text & "', " _
                                                + " username='" & txtusername.Text & "', " _
                                                + " password='" & encryptpass(txtverify.Text) & "', " _
                                                + " permission = '" & permission.EditValue.ToString & "',datereg='" & GlobalDateTime() & "'"
            Else
                Exit Sub
            End If
        End If
        com.ExecuteNonQuery()
        UpdateImage("accountid='" & txtuserid.Text & "'", "digitalsign", "tblaccounts", signature, Me)
        loadglobaluser()
        filteruser()
        clearaccount()
        XtraMessageBox.Show("User successfully save", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        cpass = False
    End Sub
    Public Sub clearaccount()
        txtfullname.Text = ""
        txtusername.Text = ""

        txtpassword.Text = ""
        txtverify.Text = ""
        LoadToComboBox("designation", "tblaccounts", txtdesignation, True) : txtdesignation.SelectedIndex = -1
        LoadToComboBox("unitcode", "tblaccounts", txtunitcodeaccount, True) : txtunitcodeaccount.SelectedIndex = -1
        accsysid.Text = ""

        permission.SelectedIndex = -1
        txtuserid.Text = getuserid()
        mode.Text = ""
        signature.Image = Nothing

        cpass = False
        txtpassword.Properties.ReadOnly = False
        txtverify.Properties.ReadOnly = False
        cmdChangepass.Enabled = False
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim imgBytes As Byte() = Nothing
        Dim stream As MemoryStream = Nothing
        Dim img As Image = Nothing
        cpass = False
        txtpassword.Properties.ReadOnly = True
        txtverify.Properties.ReadOnly = True
        If globalpermission <> 1 And globalpermission <> 0 And globaluserid <> gridid Then
            XtraMessageBox.Show("You have no permission to do this action! please contact your administrative control", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim tempsystem As String = ""
        Dim tempoffice As String = ""
        com.CommandText = "select * from tblaccounts where accountid='" & gridid & "'"

        rst = com.ExecuteReader
        While rst.Read
            txtuserid.Text = rst("accountid").ToString
            txtfullname.Text = rst("fullname").ToString
            txtdesignation.Text = rst("designation").ToString
            txtusername.Text = rst("username").ToString
            permission.SelectedIndex = Val(rst("permission").ToString)
            txtunitcodeaccount.Text = rst("unitcode").ToString

            If rst("digitalsign").ToString <> "" Then
                imgBytes = CType(rst("digitalsign"), Byte())
                'Read the byte array into a MemoryStream
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)

                'Create the new Image from the stream
                img = Image.FromStream(stream)

                'Now add the image to the table
                signature.Image = img
            End If

        End While
        rst.Close()
        mode.Text = "edit"
        cmdChangepass.Enabled = True
    End Sub

    Private Sub signature_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles signature.Validating
        resizesignature()
    End Sub
    Public Sub resizesignature()
        If signature.Image Is Nothing Then Exit Sub
        Dim Original As New Bitmap(signature.Image)
        signature.Image = Original

        Dim m As Int32 = 200
        Dim n As Int32 = m * Original.Height / Original.Width

        Dim Thumb As New Bitmap(m, n, Original.PixelFormat)
        Thumb.SetResolution(Original.HorizontalResolution, Original.VerticalResolution)

        Dim g As Graphics = Graphics.FromImage(Thumb)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High

        g.DrawImage(Original, New Rectangle(0, 0, m, n))
        signature.Image = Thumb
    End Sub
    Public Sub getcolidpack()
        On Error Resume Next
        Dim Rows() As DataRow : Dim I As Integer
        ReDim Rows(GridView1.SelectedRowsCount - 1)
        For I = 0 To GridView1.SelectedRowsCount - 1
            gridid = GridView1.GetRowCellValue(GridView1.GetSelectedRows(I), "Account ID")
        Next
    End Sub

    Private Sub packgrid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Em.MouseDown
        getcolidpack()
    End Sub

    Private Sub packgrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Em.MouseUp
        getcolidpack()
    End Sub
    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
        If globalpermission <> 1 And globalpermission <> 0 Then
            XtraMessageBox.Show("You have no permission to do this action! please contact your administrative control", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf globaluserid = gridid Then
            XtraMessageBox.Show("User is currently in use! cannot delete", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        DeleteRow("Account ID", "accountid", "tblaccounts", GridView1, Me)
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        clearaccount()
    End Sub

End Class