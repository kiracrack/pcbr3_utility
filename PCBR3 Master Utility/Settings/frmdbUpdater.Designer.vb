<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdbUpdater
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
        Me.txttodate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtfrmdate = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtOffice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridOffice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.branchcode = New DevExpress.XtraEditors.TextEdit()
        Me.ck_updateMaster = New DevExpress.XtraEditors.CheckEdit()
        Me.ck_utf8 = New DevExpress.XtraEditors.CheckEdit()
        Me.ck_updatefields = New DevExpress.XtraEditors.CheckEdit()
        Me.ck_par = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txttodate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttodate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfrmdate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfrmdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.branchcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_updateMaster.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_utf8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_updatefields.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_par.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txttodate
        '
        Me.txttodate.EditValue = New Date(CType(0, Long))
        Me.txttodate.EnterMoveNextControl = True
        Me.txttodate.Location = New System.Drawing.Point(297, 33)
        Me.txttodate.Name = "txttodate"
        Me.txttodate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txttodate.Properties.DisplayFormat.FormatString = "y"
        Me.txttodate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txttodate.Properties.EditFormat.FormatString = "y"
        Me.txttodate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txttodate.Properties.Mask.EditMask = "y"
        Me.txttodate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txttodate.Size = New System.Drawing.Size(180, 20)
        Me.txttodate.TabIndex = 619
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(275, 38)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl3.TabIndex = 620
        Me.LabelControl3.Text = "To"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(27, 36)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl1.TabIndex = 618
        Me.LabelControl1.Text = "Start From"
        '
        'txtfrmdate
        '
        Me.txtfrmdate.EditValue = New Date(CType(0, Long))
        Me.txtfrmdate.EnterMoveNextControl = True
        Me.txtfrmdate.Location = New System.Drawing.Point(84, 33)
        Me.txtfrmdate.Name = "txtfrmdate"
        Me.txtfrmdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtfrmdate.Properties.DisplayFormat.FormatString = "y"
        Me.txtfrmdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtfrmdate.Properties.EditFormat.FormatString = "y"
        Me.txtfrmdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtfrmdate.Properties.Mask.EditMask = "y"
        Me.txtfrmdate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtfrmdate.Size = New System.Drawing.Size(180, 20)
        Me.txtfrmdate.TabIndex = 617
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(84, 83)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(393, 30)
        Me.SimpleButton1.TabIndex = 621
        Me.SimpleButton1.Text = "Confirm Update"
        '
        'txtOffice
        '
        Me.txtOffice.EditValue = ""
        Me.txtOffice.EnterMoveNextControl = True
        Me.txtOffice.Location = New System.Drawing.Point(84, 10)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtOffice.Properties.DisplayMember = "Select List"
        Me.txtOffice.Properties.NullText = ""
        Me.txtOffice.Properties.ValueMember = "Select List"
        Me.txtOffice.Properties.View = Me.GridOffice
        Me.txtOffice.Size = New System.Drawing.Size(393, 20)
        Me.txtOffice.TabIndex = 626
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
        Me.LabelControl21.Location = New System.Drawing.Point(13, 12)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl21.TabIndex = 627
        Me.LabelControl21.Text = "Select Branch"
        '
        'branchcode
        '
        Me.branchcode.EditValue = ""
        Me.branchcode.Location = New System.Drawing.Point(20, 182)
        Me.branchcode.Name = "branchcode"
        Me.branchcode.Size = New System.Drawing.Size(58, 20)
        Me.branchcode.TabIndex = 628
        Me.branchcode.Visible = False
        '
        'ck_updateMaster
        '
        Me.ck_updateMaster.EditValue = True
        Me.ck_updateMaster.Location = New System.Drawing.Point(82, 57)
        Me.ck_updateMaster.Name = "ck_updateMaster"
        Me.ck_updateMaster.Properties.Caption = "Update Master"
        Me.ck_updateMaster.Size = New System.Drawing.Size(103, 19)
        Me.ck_updateMaster.TabIndex = 629
        '
        'ck_utf8
        '
        Me.ck_utf8.EditValue = True
        Me.ck_utf8.Location = New System.Drawing.Point(179, 57)
        Me.ck_utf8.Name = "ck_utf8"
        Me.ck_utf8.Properties.Caption = "Utf8 Convert"
        Me.ck_utf8.Size = New System.Drawing.Size(95, 19)
        Me.ck_utf8.TabIndex = 630
        '
        'ck_updatefields
        '
        Me.ck_updatefields.Location = New System.Drawing.Point(270, 58)
        Me.ck_updatefields.Name = "ck_updatefields"
        Me.ck_updatefields.Properties.Caption = "Update Fields"
        Me.ck_updatefields.Size = New System.Drawing.Size(92, 19)
        Me.ck_updatefields.TabIndex = 631
        '
        'ck_par
        '
        Me.ck_par.Location = New System.Drawing.Point(368, 57)
        Me.ck_par.Name = "ck_par"
        Me.ck_par.Properties.Caption = "Update PAR Table"
        Me.ck_par.Size = New System.Drawing.Size(120, 19)
        Me.ck_par.TabIndex = 632
        '
        'frmdbUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 122)
        Me.Controls.Add(Me.ck_par)
        Me.Controls.Add(Me.ck_updatefields)
        Me.Controls.Add(Me.ck_utf8)
        Me.Controls.Add(Me.ck_updateMaster)
        Me.Controls.Add(Me.branchcode)
        Me.Controls.Add(Me.txtOffice)
        Me.Controls.Add(Me.LabelControl21)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txttodate)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtfrmdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdbUpdater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PCBR3 Master Database Table Updater"
        CType(Me.txttodate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttodate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfrmdate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfrmdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.branchcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_updateMaster.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_utf8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_updatefields.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_par.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txttodate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Public WithEvents txtfrmdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtOffice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridOffice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents branchcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ck_updateMaster As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ck_utf8 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ck_updatefields As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ck_par As DevExpress.XtraEditors.CheckEdit
End Class
