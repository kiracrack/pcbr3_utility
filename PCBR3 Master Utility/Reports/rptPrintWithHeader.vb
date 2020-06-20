Public Class rptPrintWithHeader
    Private Sub rptOtherReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        If txtfrom.Text = "" And txtto.Text = "" Then
            XrLabel7.Visible = False
            XrLabel3.Visible = False
            XrLabel6.Visible = False
            txtfrom.Visible = False
            txtto.Visible = False
        Else
            XrLabel7.Visible = True
            XrLabel3.Visible = True
            XrLabel6.Visible = True
            txtfrom.Visible = True
            txtto.Visible = True
        End If
        txtdate.Text = "Date: " + Format(Now)
        txtcomp.Text = compname

        txtprename.Text = globalfullname
        txtpredesg.Text = globaldesignation

        If txtfrom.Visible = False Then
            GroupHeader1.Visible = False
        Else
            GroupHeader1.Visible = True
        End If

    End Sub

End Class