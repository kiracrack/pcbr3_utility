<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.txtpassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtusername = New DevExpress.XtraEditors.TextEdit()
        Me.cmdlogin = New DevExpress.XtraEditors.SimpleButton()
        Me.panelbg = New DevExpress.XtraEditors.PanelControl()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelbg.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtpassword
        '
        Me.txtpassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpassword.EditValue = "Password"
        Me.txtpassword.Location = New System.Drawing.Point(19, 248)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Properties.Appearance.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtpassword.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Properties.Appearance.Options.UseFont = True
        Me.txtpassword.Properties.Appearance.Options.UseForeColor = True
        Me.txtpassword.Properties.Appearance.Options.UseTextOptions = True
        Me.txtpassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtpassword.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtpassword.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtpassword.Properties.AutoHeight = False
        Me.txtpassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtpassword.Size = New System.Drawing.Size(234, 24)
        Me.txtpassword.TabIndex = 374
        '
        'txtusername
        '
        Me.txtusername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusername.EditValue = "Username"
        Me.txtusername.EnterMoveNextControl = True
        Me.txtusername.Location = New System.Drawing.Point(19, 218)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtusername.Properties.Appearance.Options.UseFont = True
        Me.txtusername.Properties.Appearance.Options.UseForeColor = True
        Me.txtusername.Properties.Appearance.Options.UseTextOptions = True
        Me.txtusername.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtusername.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtusername.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtusername.Size = New System.Drawing.Size(234, 24)
        Me.txtusername.TabIndex = 373
        '
        'cmdlogin
        '
        Me.cmdlogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdlogin.Location = New System.Drawing.Point(99, 278)
        Me.cmdlogin.Name = "cmdlogin"
        Me.cmdlogin.Size = New System.Drawing.Size(76, 26)
        Me.cmdlogin.TabIndex = 375
        Me.cmdlogin.Text = "Enter"
        '
        'panelbg
        '
        Me.panelbg.ContentImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.panelbg.Controls.Add(Me.txtpassword)
        Me.panelbg.Controls.Add(Me.cmdlogin)
        Me.panelbg.Controls.Add(Me.txtusername)
        Me.panelbg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelbg.Location = New System.Drawing.Point(0, 0)
        Me.panelbg.Name = "panelbg"
        Me.panelbg.Size = New System.Drawing.Size(267, 312)
        Me.panelbg.TabIndex = 376
        '
        'frmLogin
        '
        Me.AcceptButton = Me.cmdlogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 312)
        Me.Controls.Add(Me.panelbg)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelbg.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtpassword As DevExpress.XtraEditors.TextEdit
    Protected WithEvents cmdlogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents panelbg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtusername As DevExpress.XtraEditors.TextEdit
End Class
