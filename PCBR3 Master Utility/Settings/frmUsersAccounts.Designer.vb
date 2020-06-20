<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsersAccounts
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.txtfullname = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtunitcodeaccount = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtuserid = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.txtdesignation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.txtusername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.accsysid = New DevExpress.XtraEditors.TextEdit()
        Me.mode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.permission = New DevExpress.XtraEditors.RadioGroup()
        Me.txtpassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl28 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.signature = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.txtverify = New DevExpress.XtraEditors.TextEdit()
        Me.Em = New DevExpress.XtraGrid.GridControl()
        Me.gridmenustrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSave = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdChangepass = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.txtfullname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtunitcodeaccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtuserid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdesignation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.accsysid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.permission.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.signature.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtverify.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridmenustrip.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 22)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.XtraScrollableControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.Em)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(998, 553)
        Me.SplitContainerControl1.SplitterPosition = 291
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.txtfullname)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.txtunitcodeaccount)
        Me.XtraScrollableControl1.Controls.Add(Me.txtuserid)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl16)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl17)
        Me.XtraScrollableControl1.Controls.Add(Me.txtdesignation)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl18)
        Me.XtraScrollableControl1.Controls.Add(Me.txtusername)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl19)
        Me.XtraScrollableControl1.Controls.Add(Me.accsysid)
        Me.XtraScrollableControl1.Controls.Add(Me.mode)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl11)
        Me.XtraScrollableControl1.Controls.Add(Me.permission)
        Me.XtraScrollableControl1.Controls.Add(Me.txtpassword)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl28)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupControl2)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl29)
        Me.XtraScrollableControl1.Controls.Add(Me.txtverify)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(291, 553)
        Me.XtraScrollableControl1.TabIndex = 2
        '
        'txtfullname
        '
        Me.txtfullname.EnterMoveNextControl = True
        Me.txtfullname.Location = New System.Drawing.Point(77, 34)
        Me.txtfullname.Name = "txtfullname"
        Me.txtfullname.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfullname.Size = New System.Drawing.Size(191, 20)
        Me.txtfullname.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(127, 528)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(0, 13)
        Me.LabelControl1.TabIndex = 609
        '
        'txtunitcodeaccount
        '
        Me.txtunitcodeaccount.AllowDrop = True
        Me.txtunitcodeaccount.EditValue = ""
        Me.txtunitcodeaccount.EnterMoveNextControl = True
        Me.txtunitcodeaccount.Location = New System.Drawing.Point(147, 10)
        Me.txtunitcodeaccount.Name = "txtunitcodeaccount"
        Me.txtunitcodeaccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtunitcodeaccount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunitcodeaccount.Properties.MaxLength = 3
        Me.txtunitcodeaccount.Properties.NullText = "UNIT CODE"
        Me.txtunitcodeaccount.Properties.PopupSizeable = True
        Me.txtunitcodeaccount.Properties.ValidateOnEnterKey = True
        Me.txtunitcodeaccount.Size = New System.Drawing.Size(121, 20)
        Me.txtunitcodeaccount.TabIndex = 0
        '
        'txtuserid
        '
        Me.txtuserid.EnterMoveNextControl = True
        Me.txtuserid.Location = New System.Drawing.Point(77, 10)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Properties.Appearance.Options.UseTextOptions = True
        Me.txtuserid.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtuserid.Properties.ReadOnly = True
        Me.txtuserid.Size = New System.Drawing.Size(68, 20)
        Me.txtuserid.TabIndex = 381
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(26, 84)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl16.TabIndex = 368
        Me.LabelControl16.Text = "Username"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(32, 38)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl17.TabIndex = 370
        Me.LabelControl17.Text = "Fullname"
        '
        'txtdesignation
        '
        Me.txtdesignation.AllowDrop = True
        Me.txtdesignation.EditValue = ""
        Me.txtdesignation.EnterMoveNextControl = True
        Me.txtdesignation.Location = New System.Drawing.Point(77, 58)
        Me.txtdesignation.Name = "txtdesignation"
        Me.txtdesignation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtdesignation.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesignation.Properties.PopupSizeable = True
        Me.txtdesignation.Properties.ValidateOnEnterKey = True
        Me.txtdesignation.Size = New System.Drawing.Size(191, 20)
        Me.txtdesignation.TabIndex = 2
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(28, 110)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl18.TabIndex = 372
        Me.LabelControl18.Text = "Password"
        '
        'txtusername
        '
        Me.txtusername.EnterMoveNextControl = True
        Me.txtusername.Location = New System.Drawing.Point(77, 81)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtusername.Size = New System.Drawing.Size(191, 20)
        Me.txtusername.TabIndex = 4
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(46, 134)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl19.TabIndex = 374
        Me.LabelControl19.Text = "Verify"
        '
        'accsysid
        '
        Me.accsysid.EnterMoveNextControl = True
        Me.accsysid.Location = New System.Drawing.Point(146, 464)
        Me.accsysid.Name = "accsysid"
        Me.accsysid.Properties.Appearance.Options.UseTextOptions = True
        Me.accsysid.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.accsysid.Properties.ReadOnly = True
        Me.accsysid.Size = New System.Drawing.Size(54, 20)
        Me.accsysid.TabIndex = 608
        Me.accsysid.Visible = False
        '
        'mode
        '
        Me.mode.EnterMoveNextControl = True
        Me.mode.Location = New System.Drawing.Point(86, 464)
        Me.mode.Name = "mode"
        Me.mode.Properties.Appearance.Options.UseTextOptions = True
        Me.mode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.mode.Properties.ReadOnly = True
        Me.mode.Size = New System.Drawing.Size(54, 20)
        Me.mode.TabIndex = 383
        Me.mode.Visible = False
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(18, 61)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl11.TabIndex = 376
        Me.LabelControl11.Text = "Designation"
        '
        'permission
        '
        Me.permission.Location = New System.Drawing.Point(77, 153)
        Me.permission.Name = "permission"
        Me.permission.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Super Admin"), New DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Administrator"), New DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Management"), New DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Transaction"), New DevExpress.XtraEditors.Controls.RadioGroupItem("4", "Limited User")})
        Me.permission.Size = New System.Drawing.Size(191, 113)
        Me.permission.TabIndex = 7
        '
        'txtpassword
        '
        Me.txtpassword.EditValue = ""
        Me.txtpassword.EnterMoveNextControl = True
        Me.txtpassword.Location = New System.Drawing.Point(77, 105)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Properties.Appearance.Font = New System.Drawing.Font("Wingdings", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtpassword.Properties.Appearance.Options.UseFont = True
        Me.txtpassword.Properties.AutoHeight = False
        Me.txtpassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtpassword.Size = New System.Drawing.Size(191, 20)
        Me.txtpassword.TabIndex = 5
        '
        'LabelControl28
        '
        Me.LabelControl28.Location = New System.Drawing.Point(23, 157)
        Me.LabelControl28.Name = "LabelControl28"
        Me.LabelControl28.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl28.TabIndex = 380
        Me.LabelControl28.Text = "Permission"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.signature)
        Me.GroupControl2.Location = New System.Drawing.Point(17, 272)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(251, 111)
        Me.GroupControl2.TabIndex = 379
        Me.GroupControl2.Text = "Digital Signature"
        '
        'signature
        '
        Me.signature.Dock = System.Windows.Forms.DockStyle.Fill
        Me.signature.Location = New System.Drawing.Point(2, 22)
        Me.signature.Name = "signature"
        Me.signature.Size = New System.Drawing.Size(247, 87)
        Me.signature.TabIndex = 375
        '
        'LabelControl29
        '
        Me.LabelControl29.Location = New System.Drawing.Point(38, 13)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl29.TabIndex = 382
        Me.LabelControl29.Text = "User ID"
        '
        'txtverify
        '
        Me.txtverify.EditValue = ""
        Me.txtverify.EnterMoveNextControl = True
        Me.txtverify.Location = New System.Drawing.Point(77, 129)
        Me.txtverify.Name = "txtverify"
        Me.txtverify.Properties.Appearance.Font = New System.Drawing.Font("Wingdings", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtverify.Properties.Appearance.Options.UseFont = True
        Me.txtverify.Properties.AutoHeight = False
        Me.txtverify.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtverify.Size = New System.Drawing.Size(191, 20)
        Me.txtverify.TabIndex = 6
        '
        'Em
        '
        Me.Em.ContextMenuStrip = Me.gridmenustrip
        Me.Em.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Em.Location = New System.Drawing.Point(0, 0)
        Me.Em.MainView = Me.GridView1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(702, 553)
        Me.Em.TabIndex = 1
        Me.Em.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'gridmenustrip
        '
        Me.gridmenustrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.RemoveItemToolStripMenuItem, Me.ToolStripSeparator3, Me.RefreshToolStripMenuItem1})
        Me.gridmenustrip.Name = "gridmenustrip"
        Me.gridmenustrip.Size = New System.Drawing.Size(144, 76)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.user__pencil
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.EditToolStripMenuItem.Text = "Edit Account"
        '
        'RemoveItemToolStripMenuItem
        '
        Me.RemoveItemToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.user__minus1
        Me.RemoveItemToolStripMenuItem.Name = "RemoveItemToolStripMenuItem"
        Me.RemoveItemToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.RemoveItemToolStripMenuItem.Text = "Remove User"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(140, 6)
        '
        'RefreshToolStripMenuItem1
        '
        Me.RefreshToolStripMenuItem1.Image = Global.PCBR3_Utility.My.Resources.Resources._127
        Me.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1"
        Me.RefreshToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.RefreshToolStripMenuItem1.Text = "Refresh"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Em
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.cmdChangepass, Me.cmdSave, Me.BarButtonItem4})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 4
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdSave, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem4, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdChangepass, True)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Close Window"
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'cmdSave
        '
        Me.cmdSave.Caption = "Confirm && Save"
        Me.cmdSave.Id = 2
        Me.cmdSave.Name = "cmdSave"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Cancel"
        Me.BarButtonItem4.Id = 3
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'cmdChangepass
        '
        Me.cmdChangepass.Caption = "Change Password"
        Me.cmdChangepass.Enabled = False
        Me.cmdChangepass.Id = 1
        Me.cmdChangepass.Name = "cmdChangepass"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(998, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 575)
        Me.barDockControlBottom.Size = New System.Drawing.Size(998, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 553)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(998, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 553)
        '
        'frmUsersAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 575)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmUsersAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Users Accounts"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.txtfullname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtunitcodeaccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtuserid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdesignation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.accsysid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.permission.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.signature.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtverify.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridmenustrip.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents txtunitcodeaccount As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents accsysid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtuserid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents permission As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents signature As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtverify As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtpassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtfullname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtusername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtdesignation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents gridmenustrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdChangepass As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
End Class
