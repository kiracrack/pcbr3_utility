Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmDelinquentAccountInfo
    Private NewAccount As Boolean = False
    Private StatusPastdue As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        ElseIf keyData = Keys.Control + Keys.S Then
            cmdSave.PerformClick()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmDelinquentAccountInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        If countqry("tbldelinquentlist", "refcode = '" & refcode.Text & "'") = 0 Then
            NewAccount = True
            ShowClientInfo()
        Else
            NewAccount = False
        End If

        ShowGeneralInfo()
        If txtfullname.Text = "" Then
            ShowClientInfo()
        End If
        If txtcomaker1.Text = "" Then
            ShowClientComaker()
        End If
        showProductInfo()

        FilterStatus()
        ShowDelinquentCalculation()

        LoadToComboBox("probresult", "tbldelinquentlist", txtProbResult, True)
        LoadToComboBox("sherifincharge", "tbldelinquentlist", txtLoanSherif, True)
        LoadToComboBox("legalincharge", "tbldelinquentlist", txtLegal, True)
        LoadXgrid("select  '' as Amount, '' as 'Date Payment' from master.loanwithterm where refno='0'", "master.loanwithterm", Em, gridview1, Me)
        filterPayments()
        gridview1.Focus()

        'If accstatus.Text = "close" Then
        '    ' XtraTabControl1.Enabled = False
        '    tabComputation.PageEnabled = False
        '    'tabNote.PageEnabled = False
        '    For Each Ctl In tabComputation.Controls
        '        If TypeOf Ctl Is DevExpress.XtraEditors.TextEdit _
        '            Or TypeOf Ctl Is DevExpress.XtraEditors.ComboBoxEdit _
        '            Or TypeOf Ctl Is DevExpress.XtraEditors.MemoEdit _
        '            Or TypeOf Ctl Is DevExpress.XtraEditors.CheckEdit _
        '            Or TypeOf Ctl Is DevExpress.XtraEditors.DateEdit _
        '            Or TypeOf Ctl Is DevExpress.XtraEditors.SimpleButton Then

        '            Ctl.Properties.ReadOnly = False
        '        End If
        '    Next Ctl
        '    'txtLegal.Properties.ReadOnly = True
        'Else
        '    tabinformation.PageEnabled = True
        '    tabComputation.PageEnabled = True
        '    tabNote.PageEnabled = True
        'End If
    End Sub
    Public Sub FilterStatus()
        If StatusPastdue = True Then
            lblPrincipal.Text = "Interest on Current"
            If id.Text <> "" Then Exit Sub
            lbllegalrate.Enabled = False : txtLegalRate.Enabled = False : txtLegalRate.Text = "0.00" : cklegalrate.Enabled = False
            lblattyfees.Enabled = False : txtAttyfee.Enabled = False : txtAttyfee.Text = "0.00"
            lbllegalrate.Enabled = False : intLegalRate.Enabled = False : intLegalRate.Enabled = False : lbllegalratepercent.Enabled = False : txtLegalRate.Enabled = False : txtLegalRate.Text = "0.00" : cklegalrate.Enabled = False
            lblletigation.Enabled = False : txtLetigationExpr.Enabled = False : txtLetigationExpr.Text = "0.00"
            lblintonint.Enabled = False : intonint.Enabled = False : lblintonintpercent.Enabled = False : txtIntonInt.Enabled = False : txtIntonInt.Text = "0.00" : ckintonint.Enabled = False : ckusePrincipal.Enabled = False
        Else
            If id.Text <> "" Then Exit Sub
            lblPrincipal.Text = "Interest on Principal"
            lbllegalrate.Enabled = True : txtLegalRate.Enabled = True : txtLegalRate.Text = "0.00" : cklegalrate.Enabled = True
            lblattyfees.Enabled = True : txtAttyfee.Enabled = True : txtAttyfee.Text = "0.00"
            lbllegalrate.Enabled = True : intLegalRate.Enabled = True : intLegalRate.Enabled = True : lbllegalratepercent.Enabled = True : txtLegalRate.Enabled = True : txtLegalRate.Text = "0.00" : cklegalrate.Enabled = True
            lblletigation.Enabled = True : txtLetigationExpr.Enabled = True : txtLetigationExpr.Text = "0.00"
            lblintonint.Enabled = True : intonint.Enabled = True : lblintonintpercent.Enabled = True : txtIntonInt.Enabled = True : txtIntonInt.Text = "0.00" : ckintonint.Enabled = True : ckusePrincipal.Enabled = True
        End If
    End Sub

    Public Sub ShowClientInfo()
        com.CommandText = "select *,concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) as 'fullname' from master.client where custcode = '" & custcode.Text & "'"
        rst = com.ExecuteReader()
        While rst.Read
            txtfullname.Text = UCase(rst("fullname").ToString)
            txtAddress.Text = UCase(rst("res_street").ToString) + " " + UCase(rst("res_city").ToString) + " " + UCase(rst("res_province").ToString)
            txtClientContact.Text = UCase(rst("cellno").ToString)
        End While
        rst.Close()

    End Sub
    Public Sub ShowClientComaker()
        com.CommandText = "SELECT (select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) from master.client where master.client.custcode = master.loanwithterm.comaker1) as 'comakername1', " _
                  + " (select concat(UCASE(lname),' ',UCASE(fname),' ',UCASE(mname)) from master.client where master.client.custcode = master.loanwithterm.comaker2) as 'comakername2' " _
                  + " , loandate FROM master.loanwithterm where refno = '" & loanref.Text & "'; "
        rst = com.ExecuteReader
        While rst.Read
            txtcomaker1.Text = rst("comakername1").ToString
            txtcomaker2.Text = rst("comakername2").ToString
            txtLoanDate.Text = Format(asdate(rst("loandate").ToString), "MMMM dd, yyyy")
        End While
        rst.Close()
    End Sub
    Public Sub showProductInfo()
        com.CommandText = "select * from master.loanprod where prodcode ='" & prodcode.Text & "'"
        rst = com.ExecuteReader
        While rst.Read
            txtLoanProduct.Text = UCase(rst("prodname").ToString)
        End While
        rst.Close()
    End Sub
    Private Sub txtAsOf_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAsOf.EditValueChanged
        If txtAsOf.Text <> "" Then
            lblcntdays.Text = "Count Days as of " + txtAsOf.Text
            showDelinquentInfo()
        End If
    End Sub
    Public Sub showDelinquentInfo()
        Dim getIntmonth As Double = 0
        If NewAccount = True Then
            com.CommandText = "SELECT intrate, Principal,pribal, " _
                     + " loandate, maturity, DATEDIFF('" & ConvertDate(txtAsOf.Text) & "',maturity) as 'cntdays', " _
                     + " DATEDIFF(maturity,loandate) as 'ldtomd' " _
                     + " FROM master.loanwithterm where refno = '" & loanref.Text & "'; "
            rst = com.ExecuteReader
            While rst.Read
                txtCountDays.Text = Format(Val(rst("cntdays").ToString), "N0")
                txtPrincipal.Text = Format(Val(rst("Principal").ToString), "n")
                txtIntRate.Text = Format(Val(rst("intrate").ToString), "n")
                txtIntRate2.Text = Format(Val(rst("intrate").ToString), "n")
                intPastdue.Text = Format(Val(rst("intrate").ToString) + 10, "n")
                txtLoanDate.Text = Format(asdate(rst("loandate").ToString), "MMMM dd, yyyy")
                txtMaturityDate.Text = Format(asdate(rst("maturity").ToString), "MMMM dd, yyyy")

                getIntmonth = Val(Val(txtIntRate.Text) / 12) * Val(txtPDIMonths.Text)
                txtPastDueInstallment.Text = Format(Val(Val(Val(Val(rst("Principal").ToString) * Val(Val(getIntmonth) / 100)) + Val(rst("Principal").ToString)) / Val(txtPDIMonths.Text)), "n")

                If Val(rst("pribal").ToString) = 1 Then
                    txtOutstandingbal.Text = Format(Val(rst("Principal").ToString), "n")
                Else
                    txtOutstandingbal.Text = Format(Val(rst("pribal").ToString), "n")
                End If
                val_ldtomd.Text = Format(Val(rst("ldtomd").ToString), "N0")
            End While
            rst.Close()
        End If
        ShowDelinquentCalculation()
    End Sub
    Public Sub ShowDelinquentCalculation()
        Dim ttlintonprincipal As Double = 0
        Dim ttlpenalty As Double = 0
        Dim ttllegalrate As Double = 0
        Dim ttlintonint As Double = 0
        Dim ttlpdi As Double = 0
        Dim ttlcharges As Double = 0
        Dim getIntmonth As Double = 0

        Try
            getIntmonth = Val(Val(txtIntRate.Text) / 12) * Val(txtPDIMonths.Text)
            txtPastDueInstallment.Text = Format(Val(Val(Val(Val(CC(txtPrincipal.Text)) * Val(Val(getIntmonth) / 100)) + Val(CC(txtPrincipal.Text))) / Val(txtPDIMonths.Text)), "n")
           

            If StatusPastdue = True Then
                ttlintonprincipal = Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(txtIntRate.Text) / 100))
                txtIntonPrincipal.Text = Format(ttlintonprincipal, "n")

                Dim ttlIntPenalty As Double = 0
                If ckuseOustanding.Checked = True Then
                    ttlIntPenalty = Val(CC(txtOutstandingbal.Text))
                Else
                    ttlIntPenalty = Val(CC(txtPastDueInstallment.Text))
                End If

                If ckpenalty.Checked = True Then
                    ttlpenalty = Val(Val(Val(ttlIntPenalty) * Val(Val(intPenalty.Text) / 100)) / Val(radPenalty.EditValue)) * Val(CC(cntDays_penalty.Text))
                    txtPenalty.Text = Format(ttlpenalty, "n")
                Else
                    ttlpenalty = Val(Val(Val(ttlIntPenalty) * Val(Val(intPenalty.Text) / 100)) / 30) * Val(CC(txtCountDays.Text))
                    txtPenalty.Text = Format(ttlpenalty, "n")
                End If

                'ttlpenalty = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(intPenalty.Text) / 100)) / 30) * Val(CC(txtCountDays.Text))
                'txtPenalty.Text = Format(ttlpenalty, "n")

                If ckpastdue.Checked = True Then
                    ttlpdi = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(Val(intPastdue.Text)) / 100)) / Val(radPastdue.EditValue)) * Val(CC(cntDays_pastdue.Text))
                    txtPastDue.Text = Format(ttlpdi, "n")
                Else
                    ttlpdi = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(Val(intPastdue.Text)) / 100)) / 360) * Val(CC(txtCountDays.Text))
                    txtPastDue.Text = Format(ttlpdi, "n")
                End If

                'ttlpdi = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(Val(intPastdue.Text)) / 100)) / 360) * Val(CC(txtCountDays.Text))
                'txtPastDue.Text = Format(ttlpdi, "n")

                txtGrandTotal.Text = Format(Val(CC(txtOutstandingbal.Text)) + Val(CC(txtIntonPrincipal.Text) + Val(CC(txtPenalty.Text)) + Val(CC(txtPastDue.Text)) + Val(CC(txtaddon.Text)) - Val(CC(txtLessPayment.Text))), "n")
            Else
                If ckintonpri.Checked = True Then
                    ttlintonprincipal = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(txtIntRate2.Text) / 100)) / Val(radintonpri.EditValue)) * Val(cntDays_intonPri.Text)
                    txtIntonPrincipal.Text = Format(ttlintonprincipal, "n")
                Else
                    ttlintonprincipal = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(txtIntRate2.Text) / 100)) / 360) * Val(val_ldtomd.Text)
                    txtIntonPrincipal.Text = Format(ttlintonprincipal, "n")
                End If

                Dim ttlIntPenalty As Double = 0
                If ckuseOustanding.Checked = True Then
                    ttlIntPenalty = Val(CC(txtOutstandingbal.Text))
                Else
                    ttlIntPenalty = Val(CC(txtPastDueInstallment.Text))
                End If

                If ckpenalty.Checked = True Then
                    ttlpenalty = Val(Val(Val(ttlIntPenalty) * Val(Val(intPenalty.Text) / 100)) / Val(radPenalty.EditValue)) * Val(CC(cntDays_penalty.Text))
                    txtPenalty.Text = Format(ttlpenalty, "n")
                Else
                    ttlpenalty = Val(Val(Val(ttlIntPenalty) * Val(Val(intPenalty.Text) / 100)) / 30) * Val(CC(txtCountDays.Text))
                    txtPenalty.Text = Format(ttlpenalty, "n")
                End If

                If cklegalrate.Checked = True Then
                    ttllegalrate = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(intLegalRate.Text) / 100)) / Val(radLegalrate.EditValue)) * Val(CC(cntDays_legalRate.Text))
                    txtLegalRate.Text = Format(ttllegalrate, "n")
                Else
                    ttllegalrate = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(intLegalRate.Text) / 100)) / 360) * Val(CC(txtCountDays.Text))
                    txtLegalRate.Text = Format(ttllegalrate, "n")
                End If

                Dim ttlIntoint As Double = 0
                If ckusePrincipal.Checked = True Then
                    ttlIntoint = Val(Val(CC(txtPrincipal.Text)) * Val(Val(Val(txtIntRate.Text) / 100)))
                Else
                    ttlIntoint = Val(CC(txtIntonPrincipal.Text))
                End If

                If ckintonint.Checked = True Then
                    ttlintonint = Val(Val(Val(ttlIntoint) * Val(Val(intonint.Text) / 100)) / Val(radintonint.EditValue)) * Val(CC(cntDays_intonint.Text))
                    txtIntonInt.Text = Format(ttlintonint, "n")
                Else
                    ttlintonint = Val(Val(Val(ttlIntoint) * Val(Val(intonint.Text) / 100)) / 30) * Val(CC(txtCountDays.Text))
                    txtIntonInt.Text = Format(ttlintonint, "n")
                End If

                If ckpastdue.Checked = True Then
                    ttlpdi = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(Val(intPastdue.Text)) / 100)) / Val(radPastdue.EditValue)) * Val(CC(cntDays_pastdue.Text))
                    txtPastDue.Text = Format(ttlpdi, "n")
                Else
                    ttlpdi = Val(Val(Val(CC(txtOutstandingbal.Text)) * Val(Val(Val(intPastdue.Text)) / 100)) / 360) * Val(CC(txtCountDays.Text))
                    txtPastDue.Text = Format(ttlpdi, "n")
                End If



                ttlcharges = Val(CC(txtOutstandingbal.Text)) + Val(CC(txtIntonPrincipal.Text)) + Val(CC(txtPenalty.Text)) + Val(CC(txtLegalRate.Text)) + Val(CC(txtAttyfee.Text)) + Val(CC(txtLetigationExpr.Text)) + Val(CC(txtIntonInt.Text)) + Val(CC(txtPastDue.Text)) + Val(CC(txtaddon.Text))
                txtGrandTotal.Text = Format(ttlcharges - Val(CC(txtLessPayment.Text)), "n")
            End If

        Catch ex As Exception
            XtraMessageBox.Show("Message:" & ex.Message, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
            Exit Sub
        End Try
    End Sub

    Private Sub ck_intonint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowDelinquentCalculation()
    End Sub

    Private Sub ck_pastdue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowDelinquentCalculation()
    End Sub


    Private Sub txtAttyfee_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        txtLessPayment.EditValueChanged, _
        txtIntRate2.EditValueChanged, _
        intPenalty.EditValueChanged, _
        intLegalRate.EditValueChanged, _
        intonint.EditValueChanged, _
        intPastdue.EditValueChanged, _
        txtLetigationExpr.EditValueChanged, _
        txtOutstandingbal.EditValueChanged, _
        txtAttyfee.EditValueChanged, _
        txtPDIMonths.EditValueChanged, _
        ckuseOustanding.CheckedChanged, _
        txtaddon.EditValueChanged, _
        ckusePrincipal.CheckedChanged

        ShowDelinquentCalculation()
    End Sub

    Public Sub SaveGeneralInfo()
        Try
            RemoveSpecialChar(PanelControl1)
            com.CommandText = "insert into tbldelinquentlist set " _
                                        + " refcode='" & refcode.Text & "', " _
                                        + " custcode='" & custcode.Text & "', " _
                                        + " fullname = '" & txtfullname.Text & "', " _
                                        + " address = '" & txtAddress.Text & "', " _
                                        + " comaker1 = '" & txtcomaker1.Text & "', " _
                                        + " comaker2 = '" & txtcomaker2.Text & "', " _
                                        + " cellno = '" & txtClientContact.Text & "', " _
                                        + " prodcode='" & prodcode.Text & "', " _
                                        + " loanref='" & loanref.Text & "', " _
                                        + " status='" & txtStatus.Text & "', " _
                                        + " probresult='" & txtProbResult.Text & "', " _
                                        + " sherifincharge='" & txtLoanSherif.Text & "', " _
                                        + " shrifcontact='" & txtloanSherifContact.Text & "', " _
                                        + " legalincharge='" & txtLegal.Text & "', " _
                                        + " asofdate='" & ConvertDate(txtAsOf.Text) & "', " _
                                        + " dayscount='" & Val(CC(txtCountDays.Text)) & "', " _
                                        + " principal='" & Val(CC(txtPrincipal.Text)) & "', " _
                                        + " intrate='" & txtIntRate.Text & "', " _
                                        + " loandate='" & ConvertDate(txtLoanDate.Text) & "', " _
                                        + " maturdate='" & ConvertDate(txtMaturityDate.Text) & "', " _
                                        + " ldtomdcount='" & Val(CC(val_ldtomd.Text)) & "', " _
                                        + " pdintstallment='" & Val(CC(txtPDIMonths.Text)) & "', " _
                                        + " totalpdintstallment='" & Val(CC(txtPastDueInstallment.Text)) & "', " _
                                        + " outbal='" & Val(CC(txtOutstandingbal.Text)) & "', " _
                                        + " intintonprincipal='" & Val(CC(txtIntRate2.Text)) & "', " _
                                        + " intonprincipal='" & Val(CC(txtIntonPrincipal.Text)) & "', " _
                                        + " ckadvance_intonpri='" & ckintonpri.CheckState & "', " _
                                        + " date_from_intonpri='" & date_from_intonpri.Text & "', " _
                                        + " date_to_intonpri='" & date_to_intonpri.Text & "', " _
                                        + " cntdays_intonpri='" & Val(cntDays_intonPri.Text) & "', " _
                                        + " compute_intonpri='" & radintonpri.SelectedIndex & "', " _
                                        + " intpenalty='" & Val(CC(intPenalty.Text)) & "', " _
                                        + " totalpenalty='" & Val(CC(txtPenalty.Text)) & "', " _
                                        + " ckoutstanding_penalty='" & ckuseOustanding.CheckState & "', " _
                                        + " ckadvance_penalty='" & ckpenalty.CheckState & "', " _
                                        + " date_from_penalty='" & date_from_penalty.Text & "', " _
                                        + " date_to_penalty='" & date_to_penalty.Text & "', " _
                                        + " cntdays_penalty='" & Val(cntDays_penalty.Text) & "', " _
                                        + " compute_penalty='" & radPenalty.SelectedIndex & "', " _
                                        + " intintonint='" & Val(CC(intonint.Text)) & "', " _
                                        + " totalintonint='" & Val(CC(txtIntonInt.Text)) & "', " _
                                        + " ckprincipal_intonint='" & ckusePrincipal.CheckState & "', " _
                                        + " ckadvance_intonint='" & ckintonint.CheckState & "', " _
                                        + " date_from_intonint='" & date_from_intonint.Text & "', " _
                                        + " date_to_intonint='" & date_to_intonint.Text & "', " _
                                        + " cntdays_intonint='" & Val(cntDays_intonint.Text) & "', " _
                                        + " compute_intonint='" & radintonint.SelectedIndex & "', " _
                                        + " intlegalrate='" & Val(CC(intLegalRate.Text)) & "', " _
                                        + " totallegalrate='" & Val(CC(txtLegalRate.Text)) & "', " _
                                        + " ckadvance_legalrate='" & cklegalrate.CheckState & "', " _
                                        + " date_from_legalrate='" & date_from_legalrate.Text & "', " _
                                        + " date_to_legalrate='" & date_to_legalrate.Text & "', " _
                                        + " cntdays_legalrate='" & Val(cntDays_legalRate.Text) & "', " _
                                        + " compute_legalrate='" & radLegalrate.SelectedIndex & "', " _
                                        + " attyfees='" & Val(CC(txtAttyfee.Text)) & "', " _
                                        + " letigation='" & Val(CC(txtLetigationExpr.Text)) & "', " _
                                        + " intpastdue='" & Val(CC(intPastdue.Text)) & "', " _
                                        + " totalpastdue='" & Val(CC(txtPastDue.Text)) & "', " _
                                        + " ckadvance_pastdue='" & ckpastdue.CheckState & "', " _
                                        + " date_from_pastdue='" & date_from_pastdue.Text & "', " _
                                        + " date_to_pastdue='" & date_to_pastdue.Text & "', " _
                                        + " cntdays_pastdue='" & Val(cntDays_pastdue.Text) & "', " _
                                        + " compute_pastdue='" & radPastdue.SelectedIndex & "', " _
                                        + " addonpay='" & Val(CC(txtaddon.Text)) & "', " _
                                        + " addonpayremarks='" & rchar(txtaddonremarks.Text) & "', " _
                                        + " lesspay='" & Val(CC(txtLessPayment.Text)) & "', " _
                                        + " grandtotal='" & Val(CC(txtGrandTotal.Text)) & "', " _
                                        + " notes='" & txtNote.Text & "',trnby='" & globaluserid & "', datetrn=current_timestamp" : com.ExecuteNonQuery()
            If StatusPastdue = True Then
                frmPastDueAccounts.filter()
            Else
                frmLitigatedAccounts.filter()
            End If
            XtraMessageBox.Show("Account successfully save!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show("Message:" & ex.Message, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
            Exit Sub
        End Try
    End Sub

    Public Sub UpdateGeneralInfo()
        Try
            RemoveSpecialChar(PanelControl1)
            com.CommandText = "update tbldelinquentlist set " _
                                        + " custcode='" & custcode.Text & "', " _
                                        + " fullname = '" & txtfullname.Text & "', " _
                                        + " address = '" & txtAddress.Text & "', " _
                                        + " comaker1 = '" & txtcomaker1.Text & "', " _
                                        + " comaker2 = '" & txtcomaker2.Text & "', " _
                                        + " cellno = '" & txtClientContact.Text & "', " _
                                        + " prodcode='" & prodcode.Text & "', " _
                                        + " loanref='" & loanref.Text & "', " _
                                        + " status='" & txtStatus.Text & "', " _
                                        + " probresult='" & txtProbResult.Text & "', " _
                                        + " sherifincharge='" & txtLoanSherif.Text & "', " _
                                        + " shrifcontact='" & txtloanSherifContact.Text & "', " _
                                        + " legalincharge='" & txtLegal.Text & "', " _
                                        + " asofdate='" & ConvertDate(txtAsOf.Text) & "', " _
                                        + " dayscount='" & Val(CC(txtCountDays.Text)) & "', " _
                                        + " principal='" & Val(CC(txtPrincipal.Text)) & "', " _
                                        + " intrate='" & txtIntRate.Text & "', " _
                                        + " loandate='" & ConvertDate(txtLoanDate.Text) & "', " _
                                        + " maturdate='" & ConvertDate(txtMaturityDate.Text) & "', " _
                                        + " ldtomdcount='" & Val(CC(val_ldtomd.Text)) & "', " _
                                        + " pdintstallment='" & Val(CC(txtPDIMonths.Text)) & "', " _
                                        + " totalpdintstallment='" & Val(CC(txtPastDueInstallment.Text)) & "', " _
                                        + " outbal='" & Val(CC(txtOutstandingbal.Text)) & "', " _
                                        + " intintonprincipal='" & Val(CC(txtIntRate2.Text)) & "', " _
                                        + " intonprincipal='" & Val(CC(txtIntonPrincipal.Text)) & "', " _
                                        + " ckadvance_intonpri='" & ckintonpri.CheckState & "', " _
                                        + " date_from_intonpri='" & date_from_intonpri.Text & "', " _
                                        + " date_to_intonpri='" & date_to_intonpri.Text & "', " _
                                        + " cntdays_intonpri='" & Val(cntDays_intonPri.Text) & "', " _
                                        + " compute_intonpri='" & radintonpri.SelectedIndex & "', " _
                                        + " intpenalty='" & Val(CC(intPenalty.Text)) & "', " _
                                        + " totalpenalty='" & Val(CC(txtPenalty.Text)) & "', " _
                                        + " ckoutstanding_penalty='" & ckuseOustanding.CheckState & "', " _
                                        + " ckadvance_penalty='" & ckpenalty.CheckState & "', " _
                                        + " date_from_penalty='" & date_from_penalty.Text & "', " _
                                        + " date_to_penalty='" & date_to_penalty.Text & "', " _
                                        + " cntdays_penalty='" & Val(cntDays_penalty.Text) & "', " _
                                        + " compute_penalty='" & radPenalty.SelectedIndex & "', " _
                                        + " intintonint='" & Val(CC(intonint.Text)) & "', " _
                                        + " totalintonint='" & Val(CC(txtIntonInt.Text)) & "', " _
                                        + " ckprincipal_intonint='" & ckusePrincipal.CheckState & "', " _
                                        + " ckadvance_intonint='" & ckintonint.CheckState & "', " _
                                        + " date_from_intonint='" & date_from_intonint.Text & "', " _
                                        + " date_to_intonint='" & date_to_intonint.Text & "', " _
                                        + " cntdays_intonint='" & Val(cntDays_intonint.Text) & "', " _
                                        + " compute_intonint='" & radintonint.SelectedIndex & "', " _
                                        + " intlegalrate='" & Val(CC(intLegalRate.Text)) & "', " _
                                        + " totallegalrate='" & Val(CC(txtLegalRate.Text)) & "', " _
                                        + " ckadvance_legalrate='" & cklegalrate.CheckState & "', " _
                                        + " date_from_legalrate='" & date_from_legalrate.Text & "', " _
                                        + " date_to_legalrate='" & date_to_legalrate.Text & "', " _
                                        + " cntdays_legalrate='" & Val(cntDays_legalRate.Text) & "', " _
                                        + " compute_legalrate='" & radLegalrate.SelectedIndex & "', " _
                                        + " attyfees='" & Val(CC(txtAttyfee.Text)) & "', " _
                                        + " letigation='" & Val(CC(txtLetigationExpr.Text)) & "', " _
                                        + " intpastdue='" & Val(CC(intPastdue.Text)) & "', " _
                                        + " totalpastdue='" & Val(CC(txtPastDue.Text)) & "', " _
                                        + " ckadvance_pastdue='" & ckpastdue.CheckState & "', " _
                                        + " date_from_pastdue='" & date_from_pastdue.Text & "', " _
                                        + " date_to_pastdue='" & date_to_pastdue.Text & "', " _
                                        + " cntdays_pastdue='" & Val(cntDays_pastdue.Text) & "', " _
                                        + " compute_pastdue='" & radPastdue.SelectedIndex & "', " _
                                        + " addonpay='" & Val(CC(txtaddon.Text)) & "', " _
                                        + " addonpayremarks='" & rchar(txtaddonremarks.Text) & "', " _
                                        + " lesspay='" & Val(CC(txtLessPayment.Text)) & "', " _
                                        + " grandtotal='" & Val(CC(txtGrandTotal.Text)) & "', " _
                                        + " notes='" & txtNote.Text & "',trnby='" & globaluserid & "', datetrn=current_timestamp " _
                                        + " where refcode='" & refcode.Text & "' and asofdate='" & ConvertDate(txtAsOf.Text) & "'" : com.ExecuteNonQuery()
            If StatusPastdue = True Then
                frmPastDueAccounts.filter()
            Else
                frmLitigatedAccounts.filter()
            End If
            XtraMessageBox.Show("Account successfully save!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show("Message:" & ex.Message, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
            Exit Sub
        End Try
    End Sub
    Public Sub ShowGeneralInfo()
        Try
            com.CommandText = "select * from tbldelinquentlist where id = '" & id.Text & "'"
            rst = com.ExecuteReader
            While rst.Read
                refcode.Text = rst("refcode").ToString
                custcode.Text = rst("custcode").ToString
                txtfullname.Text = UCase(rst("fullname").ToString)
                txtAddress.Text = UCase(rst("address").ToString)
                txtcomaker1.Text = UCase(rst("comaker1").ToString)
                txtcomaker2.Text = UCase(rst("comaker2").ToString)
                txtClientContact.Text = UCase(rst("cellno").ToString)
                prodcode.Text = rst("prodcode").ToString
                loanref.Text = rst("loanref").ToString
                txtStatus.Text = rst("status").ToString

                If rst("status").ToString = "PAST DUE" Then
                    StatusPastdue = True
                Else
                    StatusPastdue = False
                End If

                txtProbResult.Text = rst("probresult").ToString
                txtLoanSherif.Text = rst("sherifincharge").ToString
                txtloanSherifContact.Text = rst("shrifcontact").ToString
                txtLegal.Text = rst("legalincharge").ToString
                txtAsOf.Text = ProperDate(rst("asofdate").ToString)
                txtCountDays.Text = Format(Val(rst("dayscount").ToString), "n")
                txtPrincipal.Text = Format(Val(rst("principal").ToString), "n")
                txtIntRate.Text = Format(Val(rst("intrate").ToString), "n")
                txtIntRate2.Text = Format(Val(rst("intrate").ToString), "n")
                txtLoanDate.Text = Format(asdate(rst("loandate").ToString), "MMMM dd, yyyy")
                txtMaturityDate.Text = Format(asdate(rst("maturdate").ToString), "MMMM dd, yyyy")
                val_ldtomd.Text = Format(Val(rst("ldtomdcount").ToString), "n")
                txtPDIMonths.Text = Format(Val(rst("pdintstallment").ToString), "n")
                txtPastDueInstallment.Text = Format(Val(rst("totalpdintstallment").ToString), "n")
                txtOutstandingbal.Text = Format(Val(rst("outbal").ToString), "n")

                txtIntRate2.Text = Format(Val(rst("intintonprincipal").ToString), "n")
                txtIntonPrincipal.Text = Format(Val(rst("intonprincipal").ToString), "n")
                ckintonpri.Checked = rst("ckadvance_intonpri")
                date_from_intonpri.Text = rst("date_from_intonpri").ToString
                date_to_intonpri.Text = rst("date_to_intonpri").ToString
                cntDays_intonPri.Text = rst("cntdays_intonpri").ToString
                radintonpri.SelectedIndex = rst("compute_intonpri")

                intPenalty.Text = Format(Val(rst("intpenalty").ToString), "n")
                txtPenalty.Text = Format(Val(rst("totalpenalty").ToString), "n")
                ckuseOustanding.Checked = rst("ckoutstanding_penalty")
                ckpenalty.Checked = rst("ckadvance_penalty")
                date_from_penalty.Text = rst("date_from_penalty").ToString
                date_to_penalty.Text = rst("date_to_penalty").ToString
                cntDays_penalty.Text = rst("cntdays_penalty").ToString
                radPenalty.SelectedIndex = rst("compute_penalty")

                intonint.Text = Format(Val(rst("intintonint").ToString), "n")
                txtIntonInt.Text = Format(Val(rst("totalintonint").ToString), "n")
                ckusePrincipal.Checked = rst("ckprincipal_intonint")
                ckintonint.Checked = rst("ckadvance_IntonInt")
                date_from_intonint.Text = rst("date_from_IntonInt").ToString
                date_to_intonint.Text = rst("date_to_IntonInt").ToString
                cntDays_intonint.Text = rst("cntdays_IntonInt").ToString
                radintonint.SelectedIndex = rst("compute_IntonInt")


                intLegalRate.Text = Format(Val(rst("intlegalrate").ToString), "n")
                txtLegalRate.Text = Format(Val(rst("totallegalrate").ToString), "n")
                cklegalrate.Checked = rst("ckadvance_legalrate")
                date_from_legalrate.Text = rst("date_from_legalrate").ToString
                date_to_legalrate.Text = rst("date_to_legalrate").ToString
                cntDays_legalRate.Text = rst("cntdays_legalrate").ToString
                radLegalrate.SelectedIndex = rst("compute_legalrate")

                txtAttyfee.Text = Format(Val(rst("attyfees").ToString), "n")
                txtLetigationExpr.Text = Format(Val(rst("letigation").ToString), "n")

                intPastdue.Text = Format(Val(rst("intpastdue").ToString), "n")
                txtPastDue.Text = Format(Val(rst("totalpastdue").ToString), "n")
                ckpastdue.Checked = rst("ckadvance_pastdue")
                date_from_pastdue.Text = rst("date_from_pastdue").ToString
                date_to_pastdue.Text = rst("date_to_pastdue").ToString
                cntDays_pastdue.Text = rst("cntdays_pastdue").ToString
                radPastdue.SelectedIndex = rst("compute_pastdue")

                txtaddon.Text = Format(Val(rst("addonpay").ToString), "n")
                txtaddonremarks.Text = rst("addonpayremarks").ToString

                txtLessPayment.Text = Format(Val(rst("lesspay").ToString), "n")
                txtGrandTotal.Text = Format(Val(rst("grandtotal").ToString), "n")
                txtNote.Text = rst("notes").ToString
            End While
            rst.Close()

        Catch ex As Exception
            XtraMessageBox.Show("Message:" & ex.Message, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
            Exit Sub
        End Try

    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtStatus.Text = "" Then
            XtraMessageBox.Show("Please Select Status!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStatus.Focus()
            Exit Sub
        ElseIf txtAsOf.Text = "" Then
            XtraMessageBox.Show("Please Select as of Date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAsOf.Focus()
            Exit Sub
        End If
        If XtraMessageBox.Show("Are you sure you want to continue?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If countqry("tbldelinquentlist", "refcode = '" & refcode.Text & "'") = 0 Then
                SaveGeneralInfo()
            Else
                If countqry("tbldelinquentlist", "asofdate = '" & ConvertDate(txtAsOf.Text) & "' and refcode = '" & refcode.Text & "'") = 0 Then
                    SaveGeneralInfo()
                Else
                    UpdateGeneralInfo()
                End If

            End If
        End If
    End Sub


    Private Sub XtraTabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XtraTabControl1.TabIndexChanged
        If txtStatus.Text = "" Then
            tabComputation.PageEnabled = False
        Else
            tabComputation.PageEnabled = True
        End If
        FilterStatus()
        ShowDelinquentCalculation()
    End Sub

    Private Sub txtStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStatus.SelectedIndexChanged
        If txtStatus.Text = "PAST DUE" Then
            StatusPastdue = True
        Else
            StatusPastdue = False
        End If
        tabComputation.Text = StrConv(txtStatus.Text, vbProperCase) & " Computation"
        tabComputation.PageEnabled = True
        FilterStatus()
        ShowDelinquentCalculation()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If txtStatus.Text = "" Then
            XtraMessageBox.Show("Please Select Status!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStatus.Focus()
            Exit Sub
        ElseIf txtAsOf.Text = "" Then
            XtraMessageBox.Show("Please Select as of Date!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAsOf.Focus()
            Exit Sub
        End If
        If txtStatus.Text = "PAST DUE" Then
            PrintPastDue()
        Else
            PrintLitigated()
        End If
    End Sub

    Public Sub PrintLitigated()
        Dim report As New rptLetigated()
        Dim comaker As String = ""
        Dim sheriffcontact As String = ""
        If txtcomaker2.Text <> "" Then
            comaker = ", " + txtcomaker2.Text
        End If
        If txtloanSherifContact.Text <> "" Then
            sheriffcontact = "           Contact#: " + txtloanSherifContact.Text
        End If
        report.txtrefno.Text = refcode.Text
        report.txtclientname.Text = txtfullname.Text
        report.txtaddress.Text = txtAddress.Text
        report.txtcomaker.Text = txtcomaker1.Text + comaker
        report.txtProduct.Text = txtLoanProduct.Text
        report.txtstatus.Text = txtStatus.Text
        report.txtprobresult.Text = txtProbResult.Text
        report.txtsheriff.Text = txtLoanSherif.Text + sheriffcontact
        report.txtlegal.Text = txtLegal.Text

        report.txtTitleLab.Text = "Delinquent Loan Computation as of  " + txtAsOf.Text
        report.txtcountdays.Text = txtCountDays.Text
        report.txtPrincipal.Text = txtPrincipal.Text
        report.txtintrate.Text = txtIntRate.Text
        report.txtloandate.Text = txtLoanDate.Text
        report.txtmaturedate.Text = txtMaturityDate.Text
        report.txtoutstandingbal.Text = txtOutstandingbal.Text

        report.txtinterestprincipal.Text = txtIntonPrincipal.Text
        If Val(cntDays_intonPri.Text) <> 0 Then
            report.lblinterestprincipal.Text += " - " + Chr(13) & StrConv(date_from_intonpri.Text, vbProperCase) + " to " + StrConv(date_to_intonpri.Text, vbProperCase) + " (" & cntDays_intonPri.Text & " Days)"
        End If
        report.intpenalty.Text = intPenalty.Text + " %"
        report.txtpenalty.Text = txtPenalty.Text
        If Val(cntDays_penalty.Text) <> 0 Then
            report.lblpenalty.Text += " - " + Chr(13) & StrConv(date_from_penalty.Text, vbProperCase) + " to " + StrConv(date_to_penalty.Text, vbProperCase) + " (" & cntDays_penalty.Text & " Days)"
        End If
        report.intLegalrate.Text = intLegalRate.Text + " %"
        report.txtlegalrate.Text = txtLegalRate.Text
        If Val(cntDays_legalRate.Text) <> 0 Then
            report.lbllegalrate.Text += " - " + Chr(13) & StrConv(date_from_legalrate.Text, vbProperCase) + " to " + StrConv(date_to_legalrate.Text, vbProperCase) + " (" & cntDays_legalRate.Text & " Days)"
        End If
        report.txtattyfees.Text = txtAttyfee.Text
        report.txtletigation.Text = txtLetigationExpr.Text
        report.interestintonint.Text = intonint.Text + " %"
        report.txtintonint.Text = txtIntonInt.Text
        If Val(cntDays_intonint.Text) <> 0 Then
            report.lblintonint.Text += " - " + Chr(13) & StrConv(date_from_intonint.Text, vbProperCase) + " to " + StrConv(date_to_intonint.Text, vbProperCase) + " (" & cntDays_intonint.Text & " Days)"
        End If

        report.intPastdue.Text = intPastdue.Text + " %"
        report.txtpastdue.Text = txtPastDue.Text
        If Val(cntDays_pastdue.Text) <> 0 Then
            report.lblpastdueint.Text += " - " + Chr(13) & StrConv(date_from_pastdue.Text, vbProperCase) + " to " + StrConv(date_to_pastdue.Text, vbProperCase) + " (" & cntDays_pastdue.Text & " Days)"
        End If

        report.txttotal.Text = txtGrandTotal.Text
        report.txtRemarks.Text = "Noted: " & txtNote.Text
        'report.lblinterestprincipal.Dispose()
        'report.txtinterestprincipal.Dispose()
        'report.lblinterestprincipal.Visible = False
        'report.txtinterestprincipal.Visible = False

        If txtaddon.Text <> "0.00" Then
            report.lbladdonremarks.Text = txtaddonremarks.Text
            report.txtaddon.Text = txtaddon.Text
        End If
        report.txtlesspayment.Text = txtLessPayment.Text
        'report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        Me.WindowState = FormWindowState.Minimized
        report.ShowRibbonPreviewDialog()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Public Sub PrintPastDue()
        Dim report As New rptPastdue()
        Dim comaker As String = ""
        Dim sheriffcontact As String = ""
        If txtcomaker2.Text <> "" Then
            comaker = ", " + txtcomaker2.Text
        End If
        If txtloanSherifContact.Text <> "" Then
            sheriffcontact = "           Contact#: " + txtloanSherifContact.Text
        End If
        report.txtrefno.Text = refcode.Text
        report.txtclientname.Text = txtfullname.Text
        report.txtaddress.Text = txtAddress.Text
        report.txtcomaker.Text = txtcomaker1.Text + comaker
        report.txtProduct.Text = txtLoanProduct.Text
        report.txtstatus.Text = txtStatus.Text
        report.txtprobresult.Text = txtProbResult.Text
        report.txtsheriff.Text = txtLoanSherif.Text + sheriffcontact
        report.txtlegal.Text = txtLegal.Text

        report.txtTitleLab.Text = "Delinquent Loan Computation as of  " + txtAsOf.Text
        report.txtcountdays.Text = txtCountDays.Text
        report.txtPrincipal.Text = txtPrincipal.Text
        report.txtintrate.Text = txtIntRate.Text
        report.txtloandate.Text = txtLoanDate.Text
        report.txtmaturedate.Text = txtMaturityDate.Text
        report.txtoutstandingbal.Text = txtOutstandingbal.Text

        report.txtinterestprincipal.Text = txtIntonPrincipal.Text
        If Val(cntDays_intonPri.Text) <> 0 Then
            report.lblinterestprincipal.Text += " - " + Chr(13) & StrConv(date_from_intonpri.Text, vbProperCase) + " to " + StrConv(date_to_intonpri.Text, vbProperCase) + " (" & cntDays_intonPri.Text & " Days)"
        End If
        report.intpenalty.Text = intPenalty.Text + " %"
        report.txtpenalty.Text = txtPenalty.Text
        If Val(cntDays_penalty.Text) <> 0 Then
            report.lblpenalty.Text += " - " + Chr(13) & StrConv(date_from_penalty.Text, vbProperCase) + " to " + StrConv(date_to_penalty.Text, vbProperCase) + " (" & cntDays_penalty.Text & " Days)"
        End If
        report.intPastdue.Text = intPastdue.Text + " %"
        report.txtpastdue.Text = txtPastDue.Text

        If Val(cntDays_pastdue.Text) <> 0 Then
            report.lblpastdueint.Text += " - " + Chr(13) & StrConv(date_from_pastdue.Text, vbProperCase) + " to " + StrConv(date_to_pastdue.Text, vbProperCase) + " (" & cntDays_pastdue.Text & " Days)"
        End If
        report.txttotal.Text = txtGrandTotal.Text
        report.txtRemarks.Text = "Noted: " & txtNote.Text
        'report.lblinterestprincipal.Dispose()
        'report.txtinterestprincipal.Dispose()
        'report.lblinterestprincipal.Visible = False
        'report.txtinterestprincipal.Visible = False

        If txtaddon.Text <> "0.00" Then
            report.txtaddonremarks.Text = txtaddonremarks.Text
            report.txtaddon.Text = txtaddon.Text
        End If

        report.txtlesspayment.Text = txtLessPayment.Text

        'report.Bands(BandKind.Detail).Controls.Add(CopyGridControl(Me.Em))
        Me.WindowState = FormWindowState.Minimized
        report.ShowRibbonPreviewDialog()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub id_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles id.EditValueChanged
        ShowGeneralInfo()
        If txtfullname.Text = "" Then
            ShowClientInfo()
        End If
        If txtcomaker1.Text = "" Then
            ShowClientComaker()
        End If
        showProductInfo()

        FilterStatus()
        ShowDelinquentCalculation()
    End Sub
#Region "CHECKEDIT CONTROL"

#End Region
    Private Sub ckintonpri_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckintonpri.CheckedChanged
        ShowDelinquentCalculation()
        If ckintonpri.Checked = True Then
            cmdintonpri.Enabled = True
        Else
            cmdintonpri.Enabled = False
        End If
    End Sub

    Private Sub ckpenalty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckpenalty.CheckedChanged
        ShowDelinquentCalculation()
        If ckpenalty.Checked = True Then
            cmdpenalty.Enabled = True
        Else
            cmdpenalty.Enabled = False
        End If
    End Sub

    Private Sub ckintonint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckintonint.CheckedChanged
        ShowDelinquentCalculation()
        If ckintonint.Checked = True Then
            cmdintonint.Enabled = True
        Else
            cmdintonint.Enabled = False
        End If
    End Sub

    Private Sub cklegalrate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cklegalrate.CheckedChanged
        ShowDelinquentCalculation()
        If cklegalrate.Checked = True Then
            cmdlegalrate.Enabled = True
        Else
            cmdlegalrate.Enabled = False
        End If
    End Sub

    Private Sub ckpastdue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckpastdue.CheckedChanged
        ShowDelinquentCalculation()
        If ckpastdue.Checked = True Then
            cmdpastdue.Enabled = True
        Else
            cmdpastdue.Enabled = False
        End If
    End Sub

    Private Sub cmdintonpri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdintonpri.Click
        frmDateLoanSelect.comType(txtIntonPrincipal.Name)
        frmDateLoanSelect.ShowDialog(Me)
    End Sub

    Private Sub cmdpenalty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpenalty.Click
        frmDateLoanSelect.comType(txtPenalty.Name)
        frmDateLoanSelect.ShowDialog(Me)
    End Sub

    Private Sub cmdintonint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdintonint.Click
        frmDateLoanSelect.comType(txtIntonInt.Name)
        frmDateLoanSelect.ShowDialog(Me)
    End Sub

    Private Sub cmdlegalrate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlegalrate.Click
        frmDateLoanSelect.comType(txtLegalRate.Name)
        frmDateLoanSelect.ShowDialog(Me)
    End Sub

    Private Sub cmdpastdue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpastdue.Click
        frmDateLoanSelect.comType(txtPastDue.Name)
        frmDateLoanSelect.ShowDialog(Me)
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub BarCheckItem1_CheckedChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItem1.CheckedChanged
        If BarCheckItem1.Checked = True Then
            NewAccount = True
        Else
            NewAccount = False
        End If
    End Sub

  
    Public Sub filterPayments()
        Dim beginyear As Date = ConvertDate(txtLoanDate.Text)
        Dim curryear As Date = Now.ToShortDateString
        Dim year As Date = beginyear
        Dim years As String = ""
        Dim yearcount As Integer = 0
        Dim totalpayment As Double = 0
        yearcount = DateDiff(DateInterval.Month, beginyear, curryear)

        For I = 0 To yearcount
            If year.AddMonths(I).ToString("yyyyMM") >= 201104 Then
                years = "db" & year.AddMonths(I).ToString("yyyyMM")
                com.CommandText = "SELECT (select prodname from master.loanprod inner join master.loanwithterm on master.loanprod.prodcode = master.loanwithterm.loanprod where master.loanwithterm.refno = lnwtermdet.lnrefno) as Product, " _
                              + " totalpmnt, date_format(lnwtermpay.pmntdate, '%M %d, %Y') as pmtdate  FROM master.client " _
                              + " inner join " & years & ".lnwtermpay on " & years & ".lnwtermpay.custcode = master.client.custcode " _
                              + " inner join " & years & ".lnwtermdet on " & years & ".lnwtermdet.refno = " & years & ".lnwtermpay.refno " _
                              + " where master.client.custcode = '" & custcode.Text & "' and " & years & ".lnwtermdet.lnrefno='" & loanref.Text & "'" : rst = com.ExecuteReader
                While rst.Read
                    AddRowXgrid(gridview1)
                    'gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Product", rst("Product").ToString)
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Amount", Format(rst("totalpmnt"), "n"))
                    gridview1.SetRowCellValue(gridview1.FocusedRowHandle, "Date Payment", rst("pmtdate").ToString)
                    totalpayment = totalpayment + Val(rst("totalpmnt").ToString)
                End While
                rst.Close()
            End If

        Next I
        ' gridview1.Columns("Product").Width = 330

        gridview1.Columns("Amount").Width = 120
        XgridColCurrency("Amount", gridview1)
        XgridColAlign("Amount", gridview1, DevExpress.Utils.HorzAlignment.Far)
        gridview1.Columns("Date Payment").SummaryItem.SummaryType = SummaryItemType.Count
        gridview1.Columns("Date Payment").SummaryItem.DisplayFormat = " Number of Payments {0:N0}"
        gridview1.Columns("Date Payment").SummaryItem.Tag = 1
        CType(gridview1.Columns("Date Payment").View, GridView).OptionsView.ShowFooter = True

        gridview1.Columns("Amount").SummaryItem.SummaryType = SummaryItemType.Sum
        gridview1.Columns("Amount").SummaryItem.DisplayFormat = "{0:n}"
        gridview1.Columns("Amount").SummaryItem.Tag = 1
        CType(gridview1.Columns("Amount").View, GridView).OptionsView.ShowFooter = True
        gridview1.MoveLast()
        'If gridview1.Columns("Amount").SummaryText.ToString <> "" Then
        '    txtLessPayment.Text = gridview1.Columns("Amount").SummaryText
        'Else
        '    txtLessPayment.Text = "0.00"
        'End If
    End Sub

End Class