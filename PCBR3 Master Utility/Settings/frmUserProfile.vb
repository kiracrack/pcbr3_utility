Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmUserProfile
    Dim cpass As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmUserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        LoadToComboBox("designation", "tblaccounts", txtdesignation, True)
        editProfile()
    End Sub
    Public Sub editProfile()
        Dim imgBytes As Byte() = Nothing
        Dim stream As MemoryStream = Nothing
        Dim img As Image = Nothing
        cpass = False
        txtpassword.Properties.ReadOnly = True
        txtverify.Properties.ReadOnly = True
        Dim stroffice As String = ""
        com.CommandText = "select * from tblaccounts where accountid='" & globaluserid & "'"
        rst = com.ExecuteReader
        While rst.Read
            txtfullname.Text = rst("fullname").ToString
            txtdesignation.Text = rst("designation").ToString
            txtusername.Text = rst("username").ToString
            txttheme.Text = rst("theme").ToString
            ShowImage("digitalsign", signature, Me)
        End While
        rst.Close()
        mode.Text = "edit"
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        cpass = True
        txtpassword.Properties.ReadOnly = False
        txtverify.Properties.ReadOnly = False
    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        If txtfullname.Text = "" Then
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
            If XtraMessageBox.Show("Are you sure you want to update your account " & globaluser & "@" & globalfullname & " on " & globaldate & " - " & globaltime() & ") ?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                com.CommandText = "update tblaccounts set fullname = '" & txtfullname.Text & "', " _
                                 + " designation='" & txtdesignation.Text & "', " _
                                 + passqry _
                                 + " theme='" & txttheme.Text & "' " _
                                 + " where accountid='" & globaluserid & "' "
                com.ExecuteNonQuery()
                UpdateImage("accountid='" & globaluserid & "'", "digitalsign", "tblaccounts", signature, Me)
                loadglobaluser()
                globaltheme = txttheme.Text
                PCBR3Main.InitSkins()
                PCBR3Main.loadStatus()
                XtraMessageBox.Show("User successfully updated", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cpass = False
            End If
        End If
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

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub signature_EditValueChanged(sender As Object, e As EventArgs) Handles signature.EditValueChanged

    End Sub
End Class