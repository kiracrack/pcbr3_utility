Public Class rptConsolidated
    Private Sub rptOtherReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint
        If Me.Landscape = True Then
            cname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            caddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            cnumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Else
            cname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            caddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cnumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        End If

        txtdate.Text = "Date: " + Format(Now)
        cname.Text = compname
        caddress.Text = compadd
        cnumber.Text = compnumber
        txtemail.Text = compemail
        logo.Image = complogo

        com.CommandText = "select * from tblsignatories"
        rst = com.ExecuteReader
        While rst.Read
            title1.Text = rst("title1").ToString
            title2.Text = rst("title2").ToString
            title3.Text = rst("title3").ToString

            name1.Text = rst("name1").ToString
            name2.Text = rst("name2").ToString
            name3.Text = rst("name3").ToString

            position1.Text = rst("position1").ToString
            position2.Text = rst("position2").ToString
            position3.Text = rst("position3").ToString
        End While
        rst.Close()
    End Sub

End Class