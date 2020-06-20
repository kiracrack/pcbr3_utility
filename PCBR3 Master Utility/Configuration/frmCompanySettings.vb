Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors

Public Class frmCompanySettings
#Region "COMPANY SETTINGS"
    Dim loads As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmCompanySettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        loads = False
    End Sub
    Private Sub frmCompanySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        loadcompsettings()
        loads = True
    End Sub

    Public Sub loadcompsettings()
        Try

            com.CommandText = "select * from tblcompanysettings"
            rst = com.ExecuteReader
            While rst.Read
                txtunit.Text = rst("unitcode").ToString
                txtinitialcode.Text = rst("initialcode").ToString
                txtcomp.Text = rst("companyname").ToString
                txtadd.Text = rst("compadd").ToString
                txttell.Text = rst("telephone").ToString
                txtemail.Text = rst("email").ToString
                txtweb.Text = rst("website").ToString
                txtofficer.Text = rst("chiefoff").ToString
                txtOfficerDesignation.Text = rst("designation").ToString
                ShowImage("logo", piclogo, Me)
                ShowImage("digitalsign", offsignature, Me)
            End While
            rst.Close()


        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub offsignature_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles offsignature.Validating
        If offsignature.Image Is Nothing Then Exit Sub
        Dim Original As New Bitmap(offsignature.Image)
        offsignature.Image = Original

        Dim m As Int32 = 200
        Dim n As Int32 = m * Original.Height / Original.Width

        Dim Thumb As New Bitmap(m, n, Original.PixelFormat)
        Thumb.SetResolution(Original.HorizontalResolution, Original.VerticalResolution)

        Dim g As Graphics = Graphics.FromImage(Thumb)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High

        g.DrawImage(Original, New Rectangle(0, 0, m, n))
        offsignature.Image = Thumb
    End Sub
    Private Sub piclogo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles piclogo.Validating
        ResizeImage(piclogo, 160, Me)
    End Sub
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub
    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim a As Integer
        If globalpermission <> 1 And globalpermission <> 0 Then
            XtraMessageBox.Show("You have no permission to do this action! please contact your administrative control", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ResizeImage(piclogo, 160, Me)
        Try
            com.CommandText = "select count(*) as cnt from tblcompanysettings"
            rst = com.ExecuteReader
            While rst.Read
                a = rst("cnt")
            End While
            rst.Close()
            If a = 0 Then
                com.CommandText = "insert into tblcompanysettings set unitcode='" & txtunit.Text & "', initialcode='" & txtinitialcode.Text & "', companyname='" & txtcomp.Text & "', compadd='" & txtadd.Text & "', telephone='" & txttell.Text & "', email='" & txtemail.Text & "', website='" & txtweb.Text & "', chiefoff='" & txtofficer.Text & "', designation='" & txtOfficerDesignation.Text & "'"
                com.ExecuteNonQuery()
            Else
                com.CommandText = "update tblcompanysettings set unitcode='" & txtunit.Text & "', initialcode='" & txtinitialcode.Text & "', companyname='" & txtcomp.Text & "', compadd='" & txtadd.Text & "', telephone='" & txttell.Text & "', email='" & txtemail.Text & "', website='" & txtweb.Text & "', chiefoff='" & txtofficer.Text & "', designation='" & txtOfficerDesignation.Text & "'"
                com.ExecuteNonQuery()
            End If

            UpdateImage("unitcode='" & txtunit.Text & "'", "logo", "tblcompanysettings", piclogo, Me)
            UpdateImage("unitcode='" & txtunit.Text & "'", "digitalsign", "tblcompanysettings", offsignature, Me)
            loadcompsettings()
            XtraMessageBox.Show("Setting Successfully Updated", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadcompsettings()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class