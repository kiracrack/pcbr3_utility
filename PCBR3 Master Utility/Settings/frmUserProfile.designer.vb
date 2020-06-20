<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserProfile
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
        Me.components = New System.ComponentModel.Container()
        Me.mode = New DevExpress.XtraEditors.TextEdit()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txttheme = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.signature = New DevExpress.XtraEditors.PictureEdit()
        Me.txtverify = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtpassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtusername = New DevExpress.XtraEditors.TextEdit()
        Me.txtdesignation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtfullname = New DevExpress.XtraEditors.TextEdit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttheme.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.signature.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtverify.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdesignation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfullname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mode
        '
        Me.mode.EnterMoveNextControl = True
        Me.mode.Location = New System.Drawing.Point(170, 411)
        Me.mode.Name = "mode"
        Me.mode.Properties.Appearance.Options.UseTextOptions = True
        Me.mode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.mode.Properties.ReadOnly = True
        Me.mode.Size = New System.Drawing.Size(54, 20)
        Me.mode.TabIndex = 405
        Me.mode.Visible = False
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "&Close Window"
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(333, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 359)
        Me.barDockControlBottom.Size = New System.Drawing.Size(333, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 337)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(333, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 337)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(52, 153)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl1.TabIndex = 447
        Me.LabelControl1.Text = "Theme"
        '
        'txttheme
        '
        Me.txttheme.AllowDrop = True
        Me.txttheme.EditValue = ""
        Me.txttheme.EnterMoveNextControl = True
        Me.txttheme.Location = New System.Drawing.Point(88, 150)
        Me.txttheme.Name = "txttheme"
        Me.txttheme.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txttheme.Properties.ImmediatePopup = True
        Me.txttheme.Properties.Items.AddRange(New Object() {"Seven", "Seven Classic" & Global.Microsoft.VisualBasic.ChrW(9), "VS2010", "DevExpress Style", "DevExpress Dark Style", "Sharp", "Sharp Plus", "Foggy", "Darkroom", "High Contrast", "Springtime", "Pumpkin", "Summer", "Xmas(Blue)", "McSkin", "Valentine", "Dark Side", "Caramel", "Lilian", "Money Twins", "iMaginary", "Black", "Blue", "Blueprint", "Whiteprint", "The Asphalt World", "Coffee", "Glass Oceans", "Stardust", "Liquid Sky", "London Liquid Sky", "Office 2010 Blue", "Office 2010 Black", "Office 2010 Silver", "Office 2007 Blue", "Office 2007 Black", "Office 2007 Silver", "Office 2007 Pink", "Office 2007 Green"})
        Me.txttheme.Properties.PopupSizeable = True
        Me.txttheme.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txttheme.Properties.ValidateOnEnterKey = True
        Me.txttheme.Size = New System.Drawing.Size(227, 20)
        Me.txttheme.TabIndex = 437
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(28, 63)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl11.TabIndex = 444
        Me.LabelControl11.Text = "Designation"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(56, 131)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl19.TabIndex = 443
        Me.LabelControl19.Text = "Verify"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(38, 108)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl18.TabIndex = 442
        Me.LabelControl18.Text = "Password"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(36, 85)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl16.TabIndex = 440
        Me.LabelControl16.Text = "Username"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(42, 39)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl17.TabIndex = 441
        Me.LabelControl17.Text = "Fullname"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(86, 291)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(137, 28)
        Me.SimpleButton3.TabIndex = 439
        Me.SimpleButton3.Text = "Change Password"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.signature)
        Me.GroupControl2.Location = New System.Drawing.Point(86, 173)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(229, 112)
        Me.GroupControl2.TabIndex = 445
        Me.GroupControl2.Text = "Digital Signature"
        '
        'signature
        '
        Me.signature.Dock = System.Windows.Forms.DockStyle.Fill
        Me.signature.Location = New System.Drawing.Point(2, 22)
        Me.signature.Name = "signature"
        Me.signature.Size = New System.Drawing.Size(225, 88)
        Me.signature.TabIndex = 375
        '
        'txtverify
        '
        Me.txtverify.EditValue = ""
        Me.txtverify.EnterMoveNextControl = True
        Me.txtverify.Location = New System.Drawing.Point(88, 128)
        Me.txtverify.Name = "txtverify"
        Me.txtverify.Properties.Appearance.Font = New System.Drawing.Font("Wingdings", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtverify.Properties.Appearance.Options.UseFont = True
        Me.txtverify.Properties.AutoHeight = False
        Me.txtverify.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtverify.Size = New System.Drawing.Size(227, 20)
        Me.txtverify.TabIndex = 436
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(229, 291)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(84, 28)
        Me.SimpleButton4.TabIndex = 438
        Me.SimpleButton4.Text = "Save"
        '
        'txtpassword
        '
        Me.txtpassword.EditValue = ""
        Me.txtpassword.EnterMoveNextControl = True
        Me.txtpassword.Location = New System.Drawing.Point(88, 105)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Properties.Appearance.Font = New System.Drawing.Font("Wingdings", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtpassword.Properties.Appearance.Options.UseFont = True
        Me.txtpassword.Properties.AutoHeight = False
        Me.txtpassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtpassword.Size = New System.Drawing.Size(227, 20)
        Me.txtpassword.TabIndex = 435
        '
        'txtusername
        '
        Me.txtusername.EnterMoveNextControl = True
        Me.txtusername.Location = New System.Drawing.Point(88, 82)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtusername.Size = New System.Drawing.Size(227, 20)
        Me.txtusername.TabIndex = 434
        '
        'txtdesignation
        '
        Me.txtdesignation.AllowDrop = True
        Me.txtdesignation.EditValue = ""
        Me.txtdesignation.EnterMoveNextControl = True
        Me.txtdesignation.Location = New System.Drawing.Point(88, 59)
        Me.txtdesignation.Name = "txtdesignation"
        Me.txtdesignation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtdesignation.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesignation.Properties.ImmediatePopup = True
        Me.txtdesignation.Properties.PopupSizeable = True
        Me.txtdesignation.Properties.ValidateOnEnterKey = True
        Me.txtdesignation.Size = New System.Drawing.Size(227, 20)
        Me.txtdesignation.TabIndex = 432
        '
        'txtfullname
        '
        Me.txtfullname.Location = New System.Drawing.Point(88, 36)
        Me.txtfullname.Name = "txtfullname"
        Me.txtfullname.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfullname.Size = New System.Drawing.Size(227, 20)
        Me.txtfullname.TabIndex = 431
        '
        'frmUserProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 359)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txttheme)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.LabelControl19)
        Me.Controls.Add(Me.LabelControl18)
        Me.Controls.Add(Me.LabelControl16)
        Me.Controls.Add(Me.LabelControl17)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.txtverify)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.txtdesignation)
        Me.Controls.Add(Me.txtfullname)
        Me.Controls.Add(Me.mode)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmUserProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Account Profile"
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttheme.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.signature.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtverify.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdesignation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfullname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txttheme As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents signature As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtverify As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtpassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtusername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtdesignation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtfullname As DevExpress.XtraEditors.TextEdit
End Class
