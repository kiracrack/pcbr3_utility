Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.IO.Compression


Public Class frmDormantGenerator
    Dim totalAccounts As Integer
    Private Sub frmAccountStmt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim getSystemDate As String = qrysingledata("dt", "date_format(trndate,'%Y-%m-%d') as dt", "where forsystem=1", "master.syscalendar")
        totalAccounts = countqry("master.depositaccounts inner join pcbr3.tbldormantsettings on depositaccounts.depcode = tbldormantsettings.depcode ", "dormant=0 and currbalance > 0 and " _
                                 + " DATEDIFF('" & getSystemDate & "',if(lasttransaction='1900-01-01',opendate,lasttransaction)) >= term-60 and " _
                                 + " DATEDIFF('" & getSystemDate & "',if(lasttransaction='1900-01-01',opendate,lasttransaction)) <= term-30")
        cmdGenerate.Text = "Generate PDF " & FormatNumber(totalAccounts, 0) & " total accounts"

    End Sub
    Public Sub generateNotice()
        Dim finderror As String = ""
        Dim getSystemDate As String = qrysingledata("dt", "date_format(trndate,'%Y-%m-%d') as dt", "where forsystem=1", "master.syscalendar")
        Dim currentDate As String = CDate(qrysingledata("trndate", "trndate", "where forsystem=1", "master.syscalendar")).ToString("yyyy-MM-dd")
        Dim dir As String = ""
        Dim fbd As New System.Windows.Forms.FolderBrowserDialog
        If fbd.ShowDialog() = DialogResult.OK Then
            Try
                dir = fbd.SelectedPath
                Me.Cursor = Cursors.WaitCursor
                ProgressBarControl1.Visible = True
                Dim detailsFile As StreamWriter = Nothing
                ProgressBarControl1.Properties.Step = 1
                ProgressBarControl1.Properties.PercentView = True
                ProgressBarControl1.Properties.Maximum = totalAccounts
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Position = 0
                Dim branches As String = qrysingledata("str", "group_concat(branchcode) as str", "", "master.branches")
                For Each splBranch In branches.Split(New Char() {","c})
                    Dim buildreport As New rptDormancy()
                    Dim branchname As String = qrysingledata("branchname", "branchname", "", "master.branches where branchcode='" & splBranch & "'")
                    If Not Directory.Exists(dir & "\" & currentDate) Then
                        Directory.CreateDirectory(dir & "\" & currentDate)
                    End If
                    If countqry("master.depositaccounts inner join pcbr3.tbldormantsettings on depositaccounts.depcode = tbldormantsettings.depcode ", "dormant=0 and currbalance > 0 and " _
                                 + " DATEDIFF('" & getSystemDate & "',if(lasttransaction='1900-01-01',opendate,lasttransaction)) >= term-60 and " _
                                 + " DATEDIFF('" & getSystemDate & "',if(lasttransaction='1900-01-01',opendate,lasttransaction)) <= term-30 and branchcode='" & splBranch & "'") > 0 Then

                        com.CommandText = "SELECT *, if(lasttransaction='1900-01-01',date_format(opendate,'%m/%d/%Y'),date_format(lasttransaction,'%m/%d/%Y')) as lasttrn, " _
                            + " (select branchhead from master.branches where branchcode = depositaccounts.branchcode) as branchhead, " _
                            + " (select lname from master.client where custcode = depositaccounts.signatory1) as 'lname', (select concat(ucase(lname), ', ' , ucase(fname)) from master.client where custcode = depositaccounts.signatory1) as 'cname', " _
                            + " (select concat(ucase(fname), ' ', if(mname='' or mname=null,' ', concat(ucase(mname),'.')),' ' , ucase(lname))  from master.client where custcode = depositaccounts.signatory1)  as 'completename', " _
                            + " (select concat(IF(res_street IS NULL or res_street = '','',concat(ucase(res_street),', ')), ucase(res_city)) from master.client where custcode = master.depositaccounts.signatory1) as 'Address', " _
                            + " (select concat(ucase(res_province),if(res_zipcode='','',concat(', ',res_zipcode))) from master.client where custcode = master.depositaccounts.signatory1) as 'province', " _
                            + " (select ucase(branchname) from master.branches where branchcode = depositaccounts.branchcode) as branch " _
                            + " from master.depositaccounts inner join pcbr3.tbldormantsettings  on depositaccounts.depcode = tbldormantsettings.depcode where dormant=0 and currbalance > 0 and " _
                            + " DATEDIFF('" & getSystemDate & "',if(lasttransaction='1900-01-01',opendate,lasttransaction)) >= term-60 and " _
                            + " DATEDIFF('" & getSystemDate & "',if(lasttransaction='1900-01-01',opendate,lasttransaction)) <= term-30 and branchcode='" & splBranch & "' order by branchcode,cname" : rst = com.ExecuteReader
                        com.CommandTimeout = 99999999
                        While rst.Read
                            finderror = RemoveSpecialCharacter(rst("cname").ToString)
                            Dim report As New rptDormancy()
                            report.txtDateGenerate.Text = CDate(currentDate).ToString("MMMM dd, yyyy")
                            report.txtFullname.Text = rst("completename").ToString
                            report.txtAddress.Text = StrConv(rst("Address").ToString, vbProperCase)
                            report.txtProvince.Text = StrConv(rst("province").ToString, vbProperCase)
                            report.txtDearName.Text = "Dear Mr/Ms. " & StrConv(rst("lname").ToString, vbProperCase) & ":"

                            report.txtModifiedContent.Text = "Our records indicate that your account " & rst("acctnumber").ToString & " has been no sign of activity since " & rst("lasttrn").ToString & " with a balance of P" & FormatNumber(Val(rst("currbalance").ToString), 2) & ". If you wish to continue the usage of your account, please visit us to reactivate your account. "

                            report.txtTheManager.Text = StrConv(rst("branchhead").ToString, vbProperCase)
                            report.PaperKind = System.Drawing.Printing.PaperKind.Letter
                            report.CreateDocument()
                            'report.ExportToPdf(dir & "\" & currentDate & "\" & rst("branch").ToString & "\" & RemoveSpecialCharacter(rst("cname").ToString) & ".pdf")

                            ProgressBarControl1.PerformStep()
                            ProgressBarControl1.Update()
                            buildreport.Pages.AddRange(report.Pages)
                            buildreport.PrintingSystem.ContinuousPageNumbering = True
                        End While
                        rst.Close()
                        buildreport.ExportToPdf(dir & "\" & currentDate & "\" & branchname & ".pdf")
                    End If
                Next
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show("Notice successfully generated!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message & " " & finderror)
            End Try
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click
        generateNotice()
    End Sub

    Private Sub ck1_CheckedChanged(sender As Object, e As EventArgs)
        'If ck1.Checked = True Or ck2.Checked = True Or ck3.Checked = True Then
        '    SimpleButton1.Enabled = True
        'Else
        '    SimpleButton1.Enabled = False
        'End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        frmDormantSettings.ShowDialog()
    End Sub
End Class