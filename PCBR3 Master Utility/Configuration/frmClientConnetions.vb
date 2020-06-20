Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmClientConnetions
    Dim cpass As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmUserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        FillComboFromFile()
    End Sub
    Private Sub FillComboFromFile()
        Dim path As String = ""
        path = Application.StartupPath.ToString & "\Connection\"
        txtServer.Properties.Items.Clear()
        file_conn_dir = path
        For Each file As String In System.IO.Directory.GetFiles(path)
            txtServer.Properties.Items.Add(UCase(System.IO.Path.GetFileNameWithoutExtension(file)))
        Next
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtServer.Text = "" Then Exit Sub
        ChangeConnection(file_conn_dir & "\" & txtServer.Text)
        PCBR3Main.txtip.Caption = "Host: " & sqlipaddress
        PCBR3Main.txtServer.Caption = sqlservername
        PCBR3Main.CreateTableIfNotExists()
        'frmLogin.updateDatabaseEngine()
        Me.Close()
    End Sub
End Class