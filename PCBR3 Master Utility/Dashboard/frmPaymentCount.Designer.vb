﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentCount
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
        Me.Em = New DevExpress.XtraGrid.GridControl()
        Me.gridmenustrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PaymentHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gridview1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.loanref = New DevExpress.XtraEditors.TextEdit()
        Me.prodcode = New DevExpress.XtraEditors.TextEdit()
        Me.custcode = New DevExpress.XtraEditors.TextEdit()
        Me.loandate = New DevExpress.XtraEditors.TextEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.txttodate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtfrmdate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.rdInsurance = New DevExpress.XtraEditors.RadioGroup()
        Me.txtSearch = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridmenustrip.SuspendLayout()
        CType(Me.gridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loanref.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prodcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.custcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loandate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.txttodate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttodate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfrmdate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfrmdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdInsurance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Em
        '
        Me.Em.ContextMenuStrip = Me.gridmenustrip
        Me.Em.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Em.Location = New System.Drawing.Point(0, 0)
        Me.Em.MainView = Me.gridview1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(1004, 439)
        Me.Em.TabIndex = 0
        Me.Em.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview1})
        '
        'gridmenustrip
        '
        Me.gridmenustrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaymentHistoryToolStripMenuItem})
        Me.gridmenustrip.Name = "gridmenustrip"
        Me.gridmenustrip.Size = New System.Drawing.Size(163, 26)
        '
        'PaymentHistoryToolStripMenuItem
        '
        Me.PaymentHistoryToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.money_coin
        Me.PaymentHistoryToolStripMenuItem.Name = "PaymentHistoryToolStripMenuItem"
        Me.PaymentHistoryToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PaymentHistoryToolStripMenuItem.Text = "Payment History"
        '
        'gridview1
        '
        Me.gridview1.GridControl = Me.Em
        Me.gridview1.Name = "gridview1"
        Me.gridview1.OptionsBehavior.Editable = False
        Me.gridview1.OptionsView.ColumnAutoWidth = False
        Me.gridview1.OptionsView.RowAutoHeight = True
        '
        'loanref
        '
        Me.loanref.EditValue = ""
        Me.loanref.Location = New System.Drawing.Point(29, 412)
        Me.loanref.Name = "loanref"
        Me.loanref.Properties.Appearance.Options.UseTextOptions = True
        Me.loanref.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.loanref.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.loanref.Properties.Mask.BeepOnError = True
        Me.loanref.Properties.ReadOnly = True
        Me.loanref.Size = New System.Drawing.Size(57, 20)
        Me.loanref.TabIndex = 484
        Me.loanref.Visible = False
        '
        'prodcode
        '
        Me.prodcode.EditValue = ""
        Me.prodcode.Location = New System.Drawing.Point(92, 412)
        Me.prodcode.Name = "prodcode"
        Me.prodcode.Properties.Appearance.Options.UseTextOptions = True
        Me.prodcode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.prodcode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.prodcode.Properties.Mask.BeepOnError = True
        Me.prodcode.Properties.ReadOnly = True
        Me.prodcode.Size = New System.Drawing.Size(57, 20)
        Me.prodcode.TabIndex = 483
        Me.prodcode.Visible = False
        '
        'custcode
        '
        Me.custcode.EditValue = ""
        Me.custcode.Location = New System.Drawing.Point(155, 412)
        Me.custcode.Name = "custcode"
        Me.custcode.Properties.Appearance.Options.UseTextOptions = True
        Me.custcode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.custcode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.custcode.Properties.Mask.BeepOnError = True
        Me.custcode.Properties.ReadOnly = True
        Me.custcode.Size = New System.Drawing.Size(57, 20)
        Me.custcode.TabIndex = 482
        Me.custcode.Visible = False
        '
        'loandate
        '
        Me.loandate.EditValue = ""
        Me.loandate.Location = New System.Drawing.Point(218, 412)
        Me.loandate.Name = "loandate"
        Me.loandate.Properties.Appearance.Options.UseTextOptions = True
        Me.loandate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.loandate.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.loandate.Properties.Mask.BeepOnError = True
        Me.loandate.Properties.ReadOnly = True
        Me.loandate.Size = New System.Drawing.Size(57, 20)
        Me.loandate.TabIndex = 485
        Me.loandate.Visible = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 2
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.FloatLocation = New System.Drawing.Point(253, 139)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2, True)})
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
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Print Report"
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1004, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 548)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1004, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 526)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1004, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 526)
        '
        'CheckEdit3
        '
        Me.CheckEdit3.Location = New System.Drawing.Point(265, 8)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Properties.Caption = "Highlight Search"
        Me.CheckEdit3.Size = New System.Drawing.Size(120, 19)
        Me.CheckEdit3.TabIndex = 611
        '
        'CheckEdit2
        '
        Me.CheckEdit2.Location = New System.Drawing.Point(153, 8)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Properties.Caption = "Advance Search"
        Me.CheckEdit2.Size = New System.Drawing.Size(107, 19)
        Me.CheckEdit2.TabIndex = 610
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(51, 8)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "View all Client"
        Me.CheckEdit1.Size = New System.Drawing.Size(97, 19)
        Me.CheckEdit1.TabIndex = 609
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 22)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.ProgressBarControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1004, 526)
        Me.SplitContainerControl1.SplitterPosition = 22
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.txttodate)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.txtfrmdate)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.CheckEdit3)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.CheckEdit2)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.CheckEdit1)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.rdInsurance)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.txtSearch)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.Em)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1004, 526)
        Me.SplitContainerControl2.SplitterPosition = 82
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'txttodate
        '
        Me.txttodate.EditValue = ""
        Me.txttodate.Location = New System.Drawing.Point(568, 31)
        Me.txttodate.Name = "txttodate"
        Me.txttodate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txttodate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttodate.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txttodate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txttodate.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txttodate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txttodate.Properties.Mask.EditMask = "MMMM d, yyyy"
        Me.txttodate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txttodate.Size = New System.Drawing.Size(201, 20)
        Me.txttodate.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(550, 34)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl3.TabIndex = 616
        Me.LabelControl3.Text = "To"
        '
        'txtfrmdate
        '
        Me.txtfrmdate.EditValue = ""
        Me.txtfrmdate.Location = New System.Drawing.Point(344, 31)
        Me.txtfrmdate.Name = "txtfrmdate"
        Me.txtfrmdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtfrmdate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfrmdate.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txtfrmdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtfrmdate.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txtfrmdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtfrmdate.Properties.Mask.EditMask = "MMMM d, yyyy"
        Me.txtfrmdate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtfrmdate.Size = New System.Drawing.Size(200, 20)
        Me.txtfrmdate.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 34)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 614
        Me.LabelControl2.Text = "Product"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(289, 34)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl1.TabIndex = 613
        Me.LabelControl1.Text = "Start From"
        '
        'rdInsurance
        '
        Me.rdInsurance.EditValue = "kbmbai"
        Me.rdInsurance.Location = New System.Drawing.Point(53, 53)
        Me.rdInsurance.MenuManager = Me.BarManager1
        Me.rdInsurance.Name = "rdInsurance"
        Me.rdInsurance.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rdInsurance.Properties.Appearance.Options.UseBackColor = True
        Me.rdInsurance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rdInsurance.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("kbmbai", "KBMbai"), New DevExpress.XtraEditors.Controls.RadioGroupItem("pioneer", "Pioneer")})
        Me.rdInsurance.Size = New System.Drawing.Size(159, 23)
        Me.rdInsurance.TabIndex = 617
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(53, 31)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtSearch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Properties.Items.AddRange(New Object() {"ASENSO", "PM2"})
        Me.txtSearch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtSearch.Size = New System.Drawing.Size(222, 20)
        Me.txtSearch.TabIndex = 0
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBarControl1.Location = New System.Drawing.Point(0, 0)
        Me.ProgressBarControl1.MenuManager = Me.BarManager1
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(0, 0)
        Me.ProgressBarControl1.TabIndex = 3
        Me.ProgressBarControl1.UseWaitCursor = True
        '
        'frmPaymentCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 548)
        Me.Controls.Add(Me.loandate)
        Me.Controls.Add(Me.loanref)
        Me.Controls.Add(Me.prodcode)
        Me.Controls.Add(Me.custcode)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmPaymentCount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Micro Insurance Tool"
        Me.TopMost = True
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridmenustrip.ResumeLayout(False)
        CType(Me.gridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loanref.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prodcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.custcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loandate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.txttodate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttodate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfrmdate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfrmdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdInsurance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents loanref As DevExpress.XtraEditors.TextEdit
    Friend WithEvents prodcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents custcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents loandate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rdInsurance As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents gridmenustrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PaymentHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearch As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txttodate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtfrmdate As DevExpress.XtraEditors.DateEdit
End Class
