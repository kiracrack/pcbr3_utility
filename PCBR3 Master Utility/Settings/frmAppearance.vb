Imports DevExpress.XtraEditors

Public Class frmAppearance
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmAppearance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadLoginApp()
    End Sub
    Public Sub loadLoginApp()
        com.CommandText = "select * from tblappearance"
        rst = com.ExecuteReader
        While rst.Read
            txtwidth.Text = rst("width").ToString
            txthieght.Text = rst("height").ToString
            ShowImage("img", piclogo, Me)
        End While
        rst.Close()
    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        ResizeImage(piclogo, Val(txtwidth.Text), Me)
        If countqry("tblappearance", "form='frmLogin'") = 0 Then
            com.CommandText = "insert into tblappearance set form='frmLogin', width='" & txtwidth.Text & "', height='" & txthieght.Text & "' "
            com.ExecuteNonQuery()
            UpdateImage("form='frmLogin'", "img", "tblappearance", piclogo, Me)
        Else
            com.CommandText = "update tblappearance set form='frmLogin', width='" & txtwidth.Text & "', height='" & txthieght.Text & "' where form='frmLogin'"
            com.ExecuteNonQuery()
            UpdateImage("form='frmLogin'", "img", "tblappearance", piclogo, Me)
        End If
        loadLoginAppearance()
        frmLogin.SetApp()
        XtraMessageBox.Show("Appearance Setting for Login Form Successfully Updated", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub
    Private Sub piclogo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles piclogo.Validating
        ResizeImage(piclogo, Val(txtwidth.Text), Me)
    End Sub

End Class