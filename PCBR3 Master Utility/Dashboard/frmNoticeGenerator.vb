Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.IO.Compression


Public Class frmNoticeGenerator

    Private Sub frmAccountStmt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt1stNotice.Text = FormatNumber(countqry("master.`loanwithterm`", "date_format(maturity,'%Y-%m') = (select date_format(trndate+ interval 1 month,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0 ;"), 0) & " Accounts."
        txt2ndNotice.Text = FormatNumber(countqry("master.`loanwithterm`", "date_format(maturity,'%Y-%m') = (select date_format(trndate,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0;"), 0) & " Accounts."
        txt3rdNotice.Text = FormatNumber(countqry("master.`loanwithterm`", "date_format(maturity,'%Y-%m') = (select date_format(trndate- interval 1 month,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0 ;"), 0) & " Accounts."
    End Sub
    Public Sub generate1stNotice()
        Dim currentDate As String = CDate(qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar")).ToString("yyyy-MM-dd")

        Dim dir As String = ""
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog
        If fbd.ShowDialog() = DialogResult.OK Then
            dir = fbd.SelectedPath
            Me.Cursor = Cursors.WaitCursor
            ProgressBarControl1.Visible = True
            Dim detailsFile As StreamWriter = Nothing
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = countqry("master.`loanwithterm`", "date_format(maturity,'%Y-%m') = (select date_format(trndate+ interval 1 month,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0 ;") + countqry("master.`loanwithterm`", "date_format(maturity,'%Y-%m') = (select date_format(trndate,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0;") + countqry("master.`loanwithterm`", "date_format(maturity,'%Y-%m') = (select date_format(trndate- interval 1 month,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0 ;")
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Position = 0

            If ck1.Checked = True Then
                'GENERATE 1ST NOTICE
                com.CommandText = "SELECT *, (select branchhead from master.branches where branchcode = loanwithterm.branchcode) as branchhead, (select lname from master.client where custcode = loanwithterm.custcode) as 'lname', (select concat(ucase(lname), ', ' , ucase(fname)) from master.client where custcode = loanwithterm.custcode) as 'cname',(select concat(ucase(fname), ' ', if(mname='' or mname=null,' ', concat(ucase(mname),'.')),' ' , ucase(lname))  from master.client where custcode = loanwithterm.custcode)  as 'completename',(select concat(IF(res_street IS NULL or res_street = '','',concat(ucase(res_street),', ')), ucase(res_city),', ', ucase(res_province)) from master.client where custcode = master.loanwithterm.custcode) as 'Address', (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as branch FROM master.`loanwithterm` where  date_format(maturity,'%Y-%m') = (select date_format(trndate+ interval 1 month,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0 ;" : rst = com.ExecuteReader
                While rst.Read
                    If Not Directory.Exists(dir & "\" & currentDate & "\" & rst("branch").ToString & "\1st Notice") Then
                        Directory.CreateDirectory(dir & "\" & currentDate & "\" & rst("branch").ToString & "\1st Notice")
                    End If
                    Dim report As New rptNotice()
                    report.txtNotice.Text = "First Notice"
                    report.txtDateGenerate.Text = CDate(currentDate).ToString("MMMM dd, yyyy")
                    report.txtFullname.Text = rst("completename").ToString
                    report.txtAddress.Text = StrConv(rst("Address").ToString, vbProperCase)
                    report.txtDearName.Text = "Dear " & StrConv(rst("lname").ToString, vbProperCase) & ":"

                    report.txtContent1.Text = "The management of Katipunan Bank (ZN), Inc. would like to thank for  your undying loyalty to our company. It is our great honor and privilege that you chose us to be an instrument among the many financial institutions in the city in helping you withstand from the present financial needs."
                    report.txtContent2.Text = "As part of our highly appreciated service to our valued clients we would like to update you in reference to your loan account in the principal amount of " & UCase(ConvertCurrencyToEnglish(rst("principal").ToString)) & " ( P " & FormatNumber(rst("principal").ToString, 2) & " ) that will be due on " & CDate(rst("maturity").ToString).ToString("MMMM dd, yyyy") & " with an outstanding balance of P " & FormatNumber(rst("pribal").ToString, 2) & ", excluding interest."
                    report.txtContent3.Text = "Please see us anytime during office hours to settle your account on or before the due date." & Chr(13) & Chr(13) & "We shall appreciate your kind attention on this matter. " & Chr(13) & Chr(13) & "Our warmest regards." & Chr(13) & Chr(13) & Chr(13) & "Very truly yours,"
                    report.txtNote.Text = "Note: Please disregard this notice if payment has been made."

                    report.txtTheManager.Text = StrConv(rst("branchhead").ToString, vbProperCase)
                    report.PaperKind = System.Drawing.Printing.PaperKind.Letter
                    report.ExportToPdf(dir & "\" & currentDate & "\" & rst("branch").ToString & "\1st Notice\" & RemoveSpecialCharacter(rst("cname").ToString) & ".pdf")

                  
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                End While
                rst.Close()
            End If

            If ck2.Checked = True Then
                'GENERATE 2ND NOTICE
                com.CommandText = "SELECT *, (select branchhead from master.branches where branchcode = loanwithterm.branchcode) as branchhead, (select lname from master.client where custcode = loanwithterm.custcode) as 'lname', (select concat(ucase(lname), ', ' , ucase(fname)) from master.client where custcode = loanwithterm.custcode) as 'cname',(select concat(ucase(fname), ' ', if(mname='' or mname=null,' ', concat(ucase(mname),'.')),' ' , ucase(lname))  from master.client where custcode = loanwithterm.custcode)  as 'completename',(select concat(IF(res_street IS NULL or res_street = '','',concat(ucase(res_street),', ')), ucase(res_city),', ', ucase(res_province)) from master.client where custcode = master.loanwithterm.custcode) as 'Address', (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as branch FROM master.`loanwithterm` where  date_format(maturity,'%Y-%m') = (select date_format(trndate,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0;" : rst = com.ExecuteReader
                While rst.Read
                    If Not Directory.Exists(dir & "\" & currentDate & "\" & rst("branch").ToString & "\2nd Notice") Then
                        Directory.CreateDirectory(dir & "\" & currentDate & "\" & rst("branch").ToString & "\2nd Notice")
                    End If
                    Dim report As New rptNotice()
                    report.txtNotice.Text = "Second Notice"
                    report.txtDateGenerate.Text = CDate(currentDate).ToString("MMMM dd, yyyy")
                    report.txtFullname.Text = rst("completename").ToString
                    report.txtAddress.Text = StrConv(rst("Address").ToString, vbProperCase)
                    report.txtDearName.Text = "Dear " & StrConv(rst("lname").ToString, vbProperCase) & ":"

                    report.txtContent1.Text = "It’s been a while that you’ve received our first notice regarding your loan balance. We hope that we were able to please you for updating your obligation because we know that you’re very busy and you don’t have time to visit in the office for the latest information regarding your loan balance."
                    report.txtContent2.Text = "We would like to remind you once again that your loan account in the principal amount of " & UCase(ConvertCurrencyToEnglish(rst("principal").ToString)) & " ( P " & FormatNumber(rst("principal").ToString, 2) & " ) due last " & CDate(rst("maturity").ToString).ToString("MMMM dd, yyyy") & " with an outstanding balance of P " & FormatNumber(rst("pribal").ToString, 2) & ", excluding interest."
                    report.txtContent3.Text = "Please see us anytime during office hours to settle your account to avoid inconveniences and penalties. " & Chr(13) & Chr(13) & "Your cooperation and special attention on this matter is highly appreciated." & Chr(13) & Chr(13) & "Our warmest regards." & Chr(13) & Chr(13) & Chr(13) & "Very truly yours,"
                    report.txtNote.Text = "Note: Please disregard this notice if payment has been made."

                    report.txtTheManager.Text = StrConv(rst("branchhead").ToString, vbProperCase)

                    report.PaperKind = System.Drawing.Printing.PaperKind.Letter
                    report.ExportToPdf(dir & "\" & currentDate & "\" & rst("branch").ToString & "\2nd Notice\" & RemoveSpecialCharacter(rst("cname").ToString) & ".pdf")

                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                End While
                rst.Close()
            End If

            If ck3.Checked = True Then
                'GENERATE 3RD NOTICE
                com.CommandText = "SELECT *, (select branchhead from master.branches where branchcode = loanwithterm.branchcode) as branchhead, (select lname from master.client where custcode = loanwithterm.custcode) as 'lname', (select concat(ucase(lname), ', ' , ucase(fname)) from master.client where custcode = loanwithterm.custcode) as 'cname',(select concat(ucase(fname), ' ', if(mname='' or mname=null,' ', concat(ucase(mname),'.')),' ' , ucase(lname))  from master.client where custcode = loanwithterm.custcode)  as 'completename',(select concat(IF(res_street IS NULL or res_street = '','',concat(ucase(res_street),', ')), ucase(res_city),', ', ucase(res_province)) from master.client where custcode = master.loanwithterm.custcode) as 'Address', (select ucase(branchname) from master.branches where branchcode = loanwithterm.branchcode) as branch FROM master.`loanwithterm` where  date_format(maturity,'%Y-%m') = (select date_format(trndate- interval 1 month,'%Y-%m')  from master.syscalendar where forsystem=1) and pribal > 1 and cancelled = 0 ;" : rst = com.ExecuteReader
                While rst.Read
                    If Not Directory.Exists(dir & "\" & currentDate & "\" & rst("branch").ToString & "\3rd Notice") Then
                        Directory.CreateDirectory(dir & "\" & currentDate & "\" & rst("branch").ToString & "\3rd Notice")
                    End If
                    Dim report As New rptNotice()
                    report.txtNotice.Text = "Third & Final Notice"
                    report.txtDateGenerate.Text = CDate(currentDate).ToString("MMMM dd, yyyy")
                    report.txtFullname.Text = rst("completename").ToString
                    report.txtAddress.Text = StrConv(rst("Address").ToString, vbProperCase)
                    report.txtDearName.Text = "Dear " & StrConv(rst("lname").ToString, vbProperCase) & ":"

                    report.txtContent1.Text = "It’s been a while that you’ve received our second notice regarding your loan balance. We hope that we were able to please you for updating your obligation because we know that you’re very busy and you don’t have time to visit in the office for the latest information regarding your loan balance."
                    report.txtContent2.Text = "We would like to remind you once again that your loan account in the principal amount of " & UCase(ConvertCurrencyToEnglish(rst("principal").ToString)) & " ( P " & FormatNumber(rst("principal").ToString, 2) & " ) that has been due last " & CDate(rst("maturity").ToString).ToString("MMMM dd, yyyy") & " with an outstanding balance of P " & FormatNumber(rst("pribal").ToString, 2) & ", excluding interest."
                    report.txtContent3.Text = "Please give this matter your preferencial attention. Failure of which shall have legal consequences. " & Chr(13) & Chr(13) & "Your cooperation and special attention on this matter is highly appreciated." & Chr(13) & Chr(13) & "Our warmest regards." & Chr(13) & Chr(13) & Chr(13) & "Very truly yours,"
                    report.txtNote.Text = "Note: Failure of which shall have legal consequences."

                    report.txtTheManager.Text = StrConv(rst("branchhead").ToString, vbProperCase)
                    report.PaperKind = System.Drawing.Printing.PaperKind.Letter
                    report.ExportToPdf(dir & "\" & currentDate & "\" & rst("branch").ToString & "\3rd Notice\" & RemoveSpecialCharacter(rst("cname").ToString) & ".pdf")

                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                End While
                rst.Close()
            End If

            Me.Cursor = Cursors.Default
            XtraMessageBox.Show("Notice successfully generated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        generate1stNotice()
    End Sub

    Private Sub ck1_CheckedChanged(sender As Object, e As EventArgs) Handles ck1.CheckedChanged, ck2.CheckedChanged, ck3.CheckedChanged
        If ck1.Checked = True Or ck2.Checked = True Or ck3.Checked = True Then
            SimpleButton1.Enabled = True
        Else
            SimpleButton1.Enabled = False
        End If
    End Sub
End Class