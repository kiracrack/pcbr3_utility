Public Class frmDateLoanSelect 
    Public Function DateSelect(ByVal dtfrom As Date, ByVal dtto As Date)
        Dim tsTimeSpan As TimeSpan
        Dim cntdays As Double = 0

        tsTimeSpan = dtto.Subtract(dtfrom)
        cntdays = tsTimeSpan.Days
        Return cntdays
    End Function

    Private Sub date_from_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles date_from.EditValueChanged
        If date_from.Text <> "" And date_to.Text <> "" Then
            txtCntDays.Text = DateSelect(date_from.EditValue, date_to.EditValue)
        End If
    End Sub

    Private Sub date_to_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles date_to.EditValueChanged
        If date_from.Text <> "" And date_to.Text <> "" Then
            txtCntDays.Text = DateSelect(date_from.EditValue, date_to.EditValue)
        End If
    End Sub

    Private Sub frmDateLoanSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()

    End Sub
    Public Function comType(ByVal strtype As String)
        txtCompType.Text = strtype
        If frmDelinquentAccountInfo.txtIntonPrincipal.Name = txtCompType.Text Then
            If frmDelinquentAccountInfo.date_from_intonpri.Text = "" Then
                date_from.EditValue = frmDelinquentAccountInfo.txtLoanDate.EditValue
            Else
                date_from.EditValue = frmDelinquentAccountInfo.date_from_intonpri.Text
                date_to.EditValue = frmDelinquentAccountInfo.date_to_intonpri.Text
                radComputation.SelectedIndex = frmDelinquentAccountInfo.radintonpri.SelectedIndex
            End If

        ElseIf frmDelinquentAccountInfo.txtPenalty.Name = txtCompType.Text Then
            If frmDelinquentAccountInfo.date_from_penalty.Text = "" Then
                date_from.EditValue = frmDelinquentAccountInfo.txtLoanDate.EditValue
            Else
                date_from.EditValue = frmDelinquentAccountInfo.date_from_penalty.Text
                date_to.EditValue = frmDelinquentAccountInfo.date_to_penalty.Text
                radComputation.SelectedIndex = frmDelinquentAccountInfo.radPenalty.SelectedIndex
            End If

        ElseIf frmDelinquentAccountInfo.txtIntonInt.Name = txtCompType.Text Then
            If frmDelinquentAccountInfo.date_from_intonint.Text = "" Then
                date_from.EditValue = frmDelinquentAccountInfo.txtLoanDate.EditValue
            Else
                date_from.EditValue = frmDelinquentAccountInfo.date_from_intonint.Text
                date_to.EditValue = frmDelinquentAccountInfo.date_to_intonint.Text
                radComputation.SelectedIndex = frmDelinquentAccountInfo.radintonint.SelectedIndex
            End If

        ElseIf frmDelinquentAccountInfo.txtLegalRate.Name = txtCompType.Text Then
            If frmDelinquentAccountInfo.date_from_legalrate.Text = "" Then
                date_from.EditValue = frmDelinquentAccountInfo.txtLoanDate.EditValue
            Else
                date_from.EditValue = frmDelinquentAccountInfo.date_from_legalrate.Text
                date_to.EditValue = frmDelinquentAccountInfo.date_to_legalrate.Text
                radComputation.SelectedIndex = frmDelinquentAccountInfo.radLegalrate.SelectedIndex
            End If

        ElseIf frmDelinquentAccountInfo.txtPastDue.Name = txtCompType.Text Then
            If frmDelinquentAccountInfo.date_from_pastdue.Text = "" Then
                date_from.EditValue = frmDelinquentAccountInfo.txtLoanDate.EditValue
            Else
                date_from.EditValue = frmDelinquentAccountInfo.date_from_pastdue.Text
                date_to.EditValue = frmDelinquentAccountInfo.date_to_pastdue.Text
                radComputation.SelectedIndex = frmDelinquentAccountInfo.radPastdue.SelectedIndex
            End If
        End If

        Return 0
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If frmDelinquentAccountInfo.txtIntonPrincipal.Name = txtCompType.Text Then
            frmDelinquentAccountInfo.date_from_intonpri.Text = date_from.Text
            frmDelinquentAccountInfo.date_to_intonpri.Text = date_to.Text
            frmDelinquentAccountInfo.cntDays_intonPri.Text = txtCntDays.Text
            frmDelinquentAccountInfo.radintonpri.SelectedIndex = radComputation.SelectedIndex

        ElseIf frmDelinquentAccountInfo.txtPenalty.Name = txtCompType.Text Then
            frmDelinquentAccountInfo.date_from_penalty.Text = date_from.Text
            frmDelinquentAccountInfo.date_to_penalty.Text = date_to.Text
            frmDelinquentAccountInfo.cntDays_penalty.Text = txtCntDays.Text
            frmDelinquentAccountInfo.radPenalty.SelectedIndex = radComputation.SelectedIndex

        ElseIf frmDelinquentAccountInfo.txtIntonInt.Name = txtCompType.Text Then
            frmDelinquentAccountInfo.date_from_intonint.Text = date_from.Text
            frmDelinquentAccountInfo.date_to_intonint.Text = date_to.Text
            frmDelinquentAccountInfo.cntDays_intonint.Text = txtCntDays.Text
            frmDelinquentAccountInfo.radintonint.SelectedIndex = radComputation.SelectedIndex

        ElseIf frmDelinquentAccountInfo.txtLegalRate.Name = txtCompType.Text Then
            frmDelinquentAccountInfo.date_from_legalrate.Text = date_from.Text
            frmDelinquentAccountInfo.date_to_legalrate.Text = date_to.Text
            frmDelinquentAccountInfo.cntDays_legalRate.Text = txtCntDays.Text
            frmDelinquentAccountInfo.radLegalrate.SelectedIndex = radComputation.SelectedIndex

        ElseIf frmDelinquentAccountInfo.txtPastDue.Name = txtCompType.Text Then
            frmDelinquentAccountInfo.date_from_pastdue.Text = date_from.Text
            frmDelinquentAccountInfo.date_to_pastdue.Text = date_to.Text
            frmDelinquentAccountInfo.cntDays_pastdue.Text = txtCntDays.Text
            frmDelinquentAccountInfo.radPastdue.SelectedIndex = radComputation.SelectedIndex
        End If
        frmDelinquentAccountInfo.ShowDelinquentCalculation()
        Me.Close()
    End Sub
End Class