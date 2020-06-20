<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsolidatedCapture
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtpath = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtOffice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridOffice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.officecode = New DevExpress.XtraEditors.TextEdit()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtpath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.officecode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(29, 19)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl5.TabIndex = 563
        Me.LabelControl5.Text = "Select File"
        '
        'txtpath
        '
        Me.txtpath.EditValue = ""
        Me.txtpath.Location = New System.Drawing.Point(83, 16)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.Properties.ReadOnly = True
        Me.txtpath.Size = New System.Drawing.Size(235, 20)
        Me.txtpath.TabIndex = 562
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(322, 15)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(26, 21)
        Me.SimpleButton2.TabIndex = 561
        Me.SimpleButton2.Text = "..."
        '
        'txtOffice
        '
        Me.txtOffice.EditValue = ""
        Me.txtOffice.EnterMoveNextControl = True
        Me.txtOffice.Location = New System.Drawing.Point(83, 40)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtOffice.Properties.DisplayMember = "Select List"
        Me.txtOffice.Properties.NullText = ""
        Me.txtOffice.Properties.ValueMember = "Select List"
        Me.txtOffice.Properties.View = Me.GridOffice
        Me.txtOffice.Size = New System.Drawing.Size(235, 20)
        Me.txtOffice.TabIndex = 624
        '
        'GridOffice
        '
        Me.GridOffice.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridOffice.Name = "GridOffice"
        Me.GridOffice.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridOffice.OptionsView.ShowGroupPanel = False
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(18, 43)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl21.TabIndex = 625
        Me.LabelControl21.Text = "Office Name"
        '
        'officecode
        '
        Me.officecode.EditValue = ""
        Me.officecode.Location = New System.Drawing.Point(85, 137)
        Me.officecode.Name = "officecode"
        Me.officecode.Size = New System.Drawing.Size(58, 20)
        Me.officecode.TabIndex = 626
        Me.officecode.Visible = False
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(83, 64)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(235, 19)
        Me.ProgressBarControl1.TabIndex = 627
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(135, 87)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(130, 27)
        Me.SimpleButton1.TabIndex = 628
        Me.SimpleButton1.Text = "Start Capture"
        '
        'frmConsolidatedCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 134)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.officecode)
        Me.Controls.Add(Me.txtOffice)
        Me.Controls.Add(Me.LabelControl21)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtpath)
        Me.Controls.Add(Me.SimpleButton2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsolidatedCapture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capture Data"
        CType(Me.txtpath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.officecode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtpath As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtOffice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridOffice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents officecode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
