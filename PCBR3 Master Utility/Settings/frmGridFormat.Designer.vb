<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGridFormat
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
        Me.ColorEdit1 = New DevExpress.XtraEditors.ColorEdit()
        Me.FontEdit1 = New DevExpress.XtraEditors.FontEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtdsply = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckButton2 = New DevExpress.XtraEditors.CheckButton()
        Me.CheckButton1 = New DevExpress.XtraEditors.CheckButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ColorEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FontEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdsply.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColorEdit1
        '
        Me.ColorEdit1.EditValue = System.Drawing.Color.Empty
        Me.ColorEdit1.Location = New System.Drawing.Point(346, 49)
        Me.ColorEdit1.Name = "ColorEdit1"
        Me.ColorEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.ColorEdit1.Properties.Appearance.Options.UseFont = True
        Me.ColorEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ColorEdit1.Size = New System.Drawing.Size(155, 21)
        Me.ColorEdit1.TabIndex = 397
        '
        'FontEdit1
        '
        Me.FontEdit1.EditValue = "Tahoma"
        Me.FontEdit1.Location = New System.Drawing.Point(114, 49)
        Me.FontEdit1.Name = "FontEdit1"
        Me.FontEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.FontEdit1.Properties.Appearance.Options.UseFont = True
        Me.FontEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FontEdit1.Size = New System.Drawing.Size(226, 21)
        Me.FontEdit1.TabIndex = 398
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(117, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl2.TabIndex = 400
        Me.LabelControl2.Text = "Font Family"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(348, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl1.TabIndex = 401
        Me.LabelControl1.Text = "Font Color"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 34)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl7.TabIndex = 409
        Me.LabelControl7.Text = "Select Display"
        '
        'txtdsply
        '
        Me.txtdsply.EditValue = "Row"
        Me.txtdsply.EnterMoveNextControl = True
        Me.txtdsply.Location = New System.Drawing.Point(9, 50)
        Me.txtdsply.Name = "txtdsply"
        Me.txtdsply.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtdsply.Properties.DropDownRows = 10
        Me.txtdsply.Properties.ImmediatePopup = True
        Me.txtdsply.Properties.Items.AddRange(New Object() {"Header", "Row", "Footer"})
        Me.txtdsply.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize
        Me.txtdsply.Properties.PopupSizeable = True
        Me.txtdsply.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtdsply.Size = New System.Drawing.Size(98, 20)
        Me.txtdsply.TabIndex = 408
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CheckEdit1)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.CheckButton2)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.CheckButton1)
        Me.GroupControl1.Controls.Add(Me.txtdsply)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.FontEdit1)
        Me.GroupControl1.Controls.Add(Me.ColorEdit1)
        Me.GroupControl1.Location = New System.Drawing.Point(9, 13)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(514, 147)
        Me.GroupControl1.TabIndex = 410
        Me.GroupControl1.Text = "Formating"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(10, 120)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Use dot matrix layout printer output"
        Me.CheckEdit1.Size = New System.Drawing.Size(237, 19)
        Me.CheckEdit1.TabIndex = 410
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Options.UseTextOptions = True
        Me.SimpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton2.Location = New System.Drawing.Point(408, 80)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(91, 29)
        Me.SimpleButton2.TabIndex = 407
        Me.SimpleButton2.Text = "Decease"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Options.UseTextOptions = True
        Me.SimpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton1.Location = New System.Drawing.Point(309, 80)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(91, 29)
        Me.SimpleButton1.TabIndex = 406
        Me.SimpleButton1.Text = "Increase"
        '
        'CheckButton2
        '
        Me.CheckButton2.Appearance.Options.UseTextOptions = True
        Me.CheckButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CheckButton2.Location = New System.Drawing.Point(211, 80)
        Me.CheckButton2.Name = "CheckButton2"
        Me.CheckButton2.Size = New System.Drawing.Size(92, 28)
        Me.CheckButton2.TabIndex = 403
        Me.CheckButton2.Text = "Italic"
        Me.CheckButton2.Visible = False
        '
        'CheckButton1
        '
        Me.CheckButton1.Appearance.Options.UseTextOptions = True
        Me.CheckButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CheckButton1.Location = New System.Drawing.Point(113, 80)
        Me.CheckButton1.Name = "CheckButton1"
        Me.CheckButton1.Size = New System.Drawing.Size(92, 28)
        Me.CheckButton1.TabIndex = 402
        Me.CheckButton1.Text = "Bold"
        Me.CheckButton1.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(398, 166)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(125, 29)
        Me.SimpleButton3.TabIndex = 411
        Me.SimpleButton3.Text = "OK"
        '
        'frmGridFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 200)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmGridFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grid Display Format"
        Me.TopMost = True
        CType(Me.ColorEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FontEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdsply.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColorEdit1 As DevExpress.XtraEditors.ColorEdit
    Friend WithEvents FontEdit1 As DevExpress.XtraEditors.FontEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckButton1 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents CheckButton2 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtdsply As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class
