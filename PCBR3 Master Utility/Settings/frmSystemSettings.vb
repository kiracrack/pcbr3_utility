Imports DevExpress.XtraEditors

Public Class frmSystemSettings

    Private Sub frmSystemSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        com.CommandText = "select * from tblsettings"
        rst = com.ExecuteReader
        While rst.Read
            If rst("defprintjettype").ToString = False Then
                RadioGroup1.SelectedIndex = 1
            Else
                RadioGroup1.SelectedIndex = 0
            End If

        End While
        rst.Close()
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        If countrecord("tblsettings") = 0 Then
            com.CommandText = "insert into tblsettings set defprintjettype='" & RadioGroup1.EditValue & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblsettings set defprintjettype='" & RadioGroup1.EditValue & "'" : com.ExecuteNonQuery()
        End If
        loadSettings()
        XtraMessageBox.Show("Settings Successfully Save.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class