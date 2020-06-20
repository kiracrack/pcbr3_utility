<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDateLoanSelect
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
        Me.date_from = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl49 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl51 = New DevExpress.XtraEditors.LabelControl()
        Me.radComputation = New DevExpress.XtraEditors.RadioGroup()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCntDays = New DevExpress.XtraEditors.TextEdit()
        Me.txtCompType = New DevExpress.XtraEditors.TextEdit()
        Me.date_to = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.date_from.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_from.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radComputation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCntDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_to.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_to.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'date_from
        '
        Me.date_from.EditValue = ""
        Me.date_from.Location = New System.Drawing.Point(116, 15)
        Me.date_from.Name = "date_from"
        Me.date_from.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.date_from.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.date_from.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.date_from.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.date_from.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.date_from.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.date_from.Properties.Mask.EditMask = "MMMM d, yyyy"
        Me.date_from.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.date_from.Size = New System.Drawing.Size(211, 20)
        Me.date_from.TabIndex = 0
        '
        'LabelControl49
        '
        Me.LabelControl49.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl49.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl49.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl49.Location = New System.Drawing.Point(118, 94)
        Me.LabelControl49.Name = "LabelControl49"
        Me.LabelControl49.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl49.TabIndex = 491
        Me.LabelControl49.Text = "Computation"
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl50.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl50.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl50.Location = New System.Drawing.Point(89, 18)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl50.TabIndex = 489
        Me.LabelControl50.Text = "From"
        '
        'LabelControl51
        '
        Me.LabelControl51.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl51.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl51.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl51.Location = New System.Drawing.Point(101, 41)
        Me.LabelControl51.Name = "LabelControl51"
        Me.LabelControl51.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl51.TabIndex = 488
        Me.LabelControl51.Text = "To"
        '
        'radComputation
        '
        Me.radComputation.EditValue = 0.0!
        Me.radComputation.Location = New System.Drawing.Point(183, 85)
        Me.radComputation.Name = "radComputation"
        Me.radComputation.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radComputation.Properties.Appearance.Options.UseBackColor = True
        Me.radComputation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.radComputation.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0.0!, "Yearly"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1.0!, "Monthly")})
        Me.radComputation.Size = New System.Drawing.Size(144, 31)
        Me.radComputation.TabIndex = 2
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(163, 120)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(164, 30)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Confirm"
        '
        'txtCntDays
        '
        Me.txtCntDays.Location = New System.Drawing.Point(273, 64)
        Me.txtCntDays.Name = "txtCntDays"
        Me.txtCntDays.Properties.ReadOnly = True
        Me.txtCntDays.Size = New System.Drawing.Size(54, 20)
        Me.txtCntDays.TabIndex = 493
        '
        'txtCompType
        '
        Me.txtCompType.Location = New System.Drawing.Point(29, 130)
        Me.txtCompType.Name = "txtCompType"
        Me.txtCompType.Size = New System.Drawing.Size(54, 20)
        Me.txtCompType.TabIndex = 494
        Me.txtCompType.Visible = False
        '
        'date_to
        '
        Me.date_to.EditValue = ""
        Me.date_to.Location = New System.Drawing.Point(116, 38)
        Me.date_to.Name = "date_to"
        Me.date_to.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.date_to.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.date_to.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.date_to.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.date_to.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.date_to.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.date_to.Properties.Mask.EditMask = "MMMM d, yyyy"
        Me.date_to.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.date_to.Size = New System.Drawing.Size(211, 20)
        Me.date_to.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl1.Location = New System.Drawing.Point(184, 67)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl1.TabIndex = 496
        Me.LabelControl1.Text = "Total Days Count"
        '
        'frmDateLoanSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 164)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.date_to)
        Me.Controls.Add(Me.txtCompType)
        Me.Controls.Add(Me.txtCntDays)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.date_from)
        Me.Controls.Add(Me.LabelControl49)
        Me.Controls.Add(Me.LabelControl50)
        Me.Controls.Add(Me.LabelControl51)
        Me.Controls.Add(Me.radComputation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDateLoanSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date Loan Computation"
        CType(Me.date_from.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_from.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radComputation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCntDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_to.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_to.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents date_from As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl49 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl51 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents radComputation As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCntDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCompType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents date_to As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
