Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Public Class frmGridFormat

    Public grid As DevExpress.XtraGrid.Views.Grid.GridView
    Dim fontstyle As String = "Tahoma"
    Dim gridsize As Double = 6.75
    Dim sz As String
    Public Function formatGrid(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        grid = xgrid
        Return grid
    End Function
    Public Sub customizecolor()
        If txtdsply.Text = "Header" Then
            customcolorHeader(grid)
        ElseIf txtdsply.Text = "Footer" Then
            customcolorFooter(grid)
        Else
            customcolorRow(grid)
        End If
        grid.BestFitColumns()
    End Sub
    Public Sub customizeGrid()
        If txtdsply.Text = "Header" Then
            If sz = "IN" Then
                gridsize = gridsize + 0.25
            Else
                gridsize = gridsize - 0.25
            End If

            fontstyle = FontEdit1.Text
            customGridHeader(fontstyle, gridsize, grid)

        ElseIf txtdsply.Text = "Footer" Then
            If sz = "IN" Then
                gridsize = gridsize + 0.25
            Else
                gridsize = gridsize - 0.25
            End If
            fontstyle = FontEdit1.Text
            customGridFooter(fontstyle, gridsize, grid)
        Else
            If sz = "IN" Then
                gridsize = gridsize + 0.25
            Else
                gridsize = gridsize - 0.25
            End If
            fontstyle = FontEdit1.Text
            customGridRow(fontstyle, gridsize, grid)
        End If
        grid.BestFitColumns()
    End Sub

#Region "CUSTOMIZE "

    Public Function customGridRow(ByVal f As String, ByVal val As Double, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        xgrid.Appearance.Row.Font = New System.Drawing.Font(f, val, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        grid.BestFitColumns()
        Return xgrid
    End Function

    Public Function customGridHeader(ByVal f As String, ByVal val As Double, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        xgrid.Appearance.HeaderPanel.Font = New System.Drawing.Font(f, val, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        Return xgrid
    End Function

    Public Function customGridFooter(ByVal f As String, ByVal val As Double, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        xgrid.Appearance.FooterPanel.Font = New System.Drawing.Font(f, val, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        Return xgrid
    End Function

    Public Function customcolorRow(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        xgrid.Appearance.Row.ForeColor = ColorEdit1.Color
        grid.BestFitColumns()
        Return xgrid
    End Function

    Public Function customcolorHeader(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        xgrid.Appearance.HeaderPanel.ForeColor = ColorEdit1.Color
        grid.BestFitColumns()
        Return xgrid
    End Function

    Public Function customcolorFooter(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        xgrid.Appearance.FooterPanel.ForeColor = ColorEdit1.Color
        grid.BestFitColumns()
        Return xgrid
    End Function

#End Region

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        sz = "IN"
        customizeGrid()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        sz = "DE"
        customizeGrid()
    End Sub
    Private Sub FontEdit1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontEdit1.SelectedValueChanged
        customizeGrid()
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Me.Close()
    End Sub

    Private Sub ColorEdit1_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColorEdit1.EditValueChanged
        customizecolor()
    End Sub

    Public Sub JetMatrixPrint(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        If CheckEdit1.Checked = True Then
            xgrid.PaintStyleName = "Web"
            xgrid.Appearance.FooterPanel.BackColor = Color.White
            xgrid.Appearance.FooterPanel.BackColor2 = Color.White

            xgrid.Appearance.GroupFooter.BackColor = Color.White
            xgrid.Appearance.GroupFooter.BackColor2 = Color.White

            xgrid.Appearance.FooterPanel.BorderColor = Color.LightGray
            xgrid.BestFitColumns()
            'xgrid.Appearance.GroupPanel.BorderColor = Color.LightGray
        Else
            xgrid.PaintStyleName = "Default"
            xgrid.BestFitColumns()
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        JetMatrixPrint(grid)
    End Sub

    Private Sub CheckButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButton1.CheckedChanged

    End Sub

    Private Sub CheckButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButton2.CheckedChanged

    End Sub
End Class