<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidationReport
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
        Me.gridview1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ckGroupBranch = New DevExpress.XtraEditors.CheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.radGroup = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAmountTo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAmountFrom = New DevExpress.XtraEditors.TextEdit()
        Me.RadReportType = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFilterBy = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.txtDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDateCutof = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtReportTemplate = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cmdPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.ls = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.custcode = New DevExpress.XtraEditors.TextEdit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ckGroupBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadReportType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilterBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateTo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateCutof.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.custcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Em
        '
        Me.Em.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Em.Location = New System.Drawing.Point(0, 0)
        Me.Em.MainView = Me.gridview1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(541, 542)
        Me.Em.TabIndex = 522
        Me.Em.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview1})
        '
        'gridview1
        '
        Me.gridview1.GridControl = Me.Em
        Me.gridview1.Name = "gridview1"
        Me.gridview1.OptionsBehavior.Editable = False
        Me.gridview1.OptionsView.ColumnAutoWidth = False
        Me.gridview1.OptionsView.RowAutoHeight = True
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 22)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ckGroupBranch)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.radGroup)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl8)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtAmountTo)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtAmountFrom)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.RadReportType)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtFilterBy)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtDateTo)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtDateFrom)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl50)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtDateCutof)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtReportTemplate)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmdPrint)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ls)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.custcode)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.Em)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(877, 542)
        Me.SplitContainerControl1.SplitterPosition = 331
        Me.SplitContainerControl1.TabIndex = 523
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ckGroupBranch
        '
        Me.ckGroupBranch.EditValue = True
        Me.ckGroupBranch.Location = New System.Drawing.Point(236, 371)
        Me.ckGroupBranch.MenuManager = Me.BarManager1
        Me.ckGroupBranch.Name = "ckGroupBranch"
        Me.ckGroupBranch.Properties.Caption = "Group Branch"
        Me.ckGroupBranch.Size = New System.Drawing.Size(87, 19)
        Me.ckGroupBranch.TabIndex = 651
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 3
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2, True)})
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
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Print Report"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(877, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 564)
        Me.barDockControlBottom.Size = New System.Drawing.Size(877, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 542)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(877, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 542)
        '
        'radGroup
        '
        Me.radGroup.EditValue = "pcbr3.tblproductgroup"
        Me.radGroup.Location = New System.Drawing.Point(119, 223)
        Me.radGroup.Name = "radGroup"
        Me.radGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radGroup.Properties.Appearance.Options.UseBackColor = True
        Me.radGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.radGroup.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("pg", "Product Group"), New DevExpress.XtraEditors.Controls.RadioGroupItem("cg", "Client Group")})
        Me.radGroup.Size = New System.Drawing.Size(204, 19)
        Me.radGroup.TabIndex = 650
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl8.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl8.Location = New System.Drawing.Point(216, 191)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl8.TabIndex = 649
        Me.LabelControl8.Text = "-"
        '
        'txtAmountTo
        '
        Me.txtAmountTo.EditValue = "0.00"
        Me.txtAmountTo.Location = New System.Drawing.Point(226, 188)
        Me.txtAmountTo.Name = "txtAmountTo"
        Me.txtAmountTo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAmountTo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAmountTo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmountTo.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txtAmountTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtAmountTo.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txtAmountTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtAmountTo.Properties.Mask.EditMask = "n"
        Me.txtAmountTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmountTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAmountTo.Size = New System.Drawing.Size(97, 20)
        Me.txtAmountTo.TabIndex = 648
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl7.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl7.Location = New System.Drawing.Point(12, 191)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl7.TabIndex = 647
        Me.LabelControl7.Text = "Loan Amount Range"
        '
        'txtAmountFrom
        '
        Me.txtAmountFrom.EditValue = "0"
        Me.txtAmountFrom.Location = New System.Drawing.Point(114, 188)
        Me.txtAmountFrom.Name = "txtAmountFrom"
        Me.txtAmountFrom.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAmountFrom.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAmountFrom.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmountFrom.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txtAmountFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtAmountFrom.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txtAmountFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtAmountFrom.Properties.Mask.EditMask = "n"
        Me.txtAmountFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmountFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAmountFrom.Size = New System.Drawing.Size(97, 20)
        Me.txtAmountFrom.TabIndex = 646
        '
        'RadReportType
        '
        Me.RadReportType.EditValue = "rd"
        Me.RadReportType.Location = New System.Drawing.Point(16, 369)
        Me.RadReportType.Name = "RadReportType"
        Me.RadReportType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RadReportType.Properties.Appearance.Options.UseBackColor = True
        Me.RadReportType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RadReportType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("rd", "Report Details"), New DevExpress.XtraEditors.Controls.RadioGroupItem("rs", "Report Summary")})
        Me.RadReportType.Size = New System.Drawing.Size(204, 22)
        Me.RadReportType.TabIndex = 645
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl6.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl6.Location = New System.Drawing.Point(16, 225)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl6.TabIndex = 644
        Me.LabelControl6.Text = "Select Group"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl5.Location = New System.Drawing.Point(70, 166)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 642
        Me.LabelControl5.Text = "Filter By"
        '
        'txtFilterBy
        '
        Me.txtFilterBy.EditValue = ""
        Me.txtFilterBy.Location = New System.Drawing.Point(114, 163)
        Me.txtFilterBy.Name = "txtFilterBy"
        Me.txtFilterBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFilterBy.Properties.DisplayFormat.FormatString = "MMMM"
        Me.txtFilterBy.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFilterBy.Properties.EditFormat.FormatString = "MMMM"
        Me.txtFilterBy.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFilterBy.Properties.Items.AddRange(New Object() {"Loandate", "Maturity"})
        Me.txtFilterBy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtFilterBy.Size = New System.Drawing.Size(209, 20)
        Me.txtFilterBy.TabIndex = 641
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl4.Location = New System.Drawing.Point(97, 141)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl4.TabIndex = 640
        Me.LabelControl4.Text = "To"
        '
        'txtDateTo
        '
        Me.txtDateTo.EditValue = ""
        Me.txtDateTo.Location = New System.Drawing.Point(114, 138)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateTo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDateTo.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txtDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtDateTo.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txtDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDateTo.Properties.Mask.EditMask = "yyyy-MM-dd"
        Me.txtDateTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDateTo.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtDateTo.Size = New System.Drawing.Size(209, 20)
        Me.txtDateTo.TabIndex = 639
        '
        'txtDateFrom
        '
        Me.txtDateFrom.EditValue = ""
        Me.txtDateFrom.Location = New System.Drawing.Point(114, 114)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateFrom.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDateFrom.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txtDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtDateFrom.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txtDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDateFrom.Properties.Mask.EditMask = "yyyy-MM-dd"
        Me.txtDateFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtDateFrom.Size = New System.Drawing.Size(209, 20)
        Me.txtDateFrom.TabIndex = 638
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl3.Location = New System.Drawing.Point(32, 117)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl3.TabIndex = 637
        Me.LabelControl3.Text = "Date Filter From"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(16, 95)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(121, 13)
        Me.LabelControl2.TabIndex = 635
        Me.LabelControl2.Text = "Report Filter Settings"
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl50.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl50.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl50.Location = New System.Drawing.Point(54, 23)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl50.TabIndex = 634
        Me.LabelControl50.Text = "Cut of Date"
        '
        'txtDateCutof
        '
        Me.txtDateCutof.EditValue = ""
        Me.txtDateCutof.Location = New System.Drawing.Point(114, 20)
        Me.txtDateCutof.Name = "txtDateCutof"
        Me.txtDateCutof.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDateCutof.Properties.DisplayFormat.FormatString = "MMMM d, yyyy"
        Me.txtDateCutof.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtDateCutof.Properties.EditFormat.FormatString = "MMMM d, yyyy"
        Me.txtDateCutof.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDateCutof.Properties.Mask.EditMask = "MMMM d, yyyy"
        Me.txtDateCutof.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.txtDateCutof.Properties.ReadOnly = True
        Me.txtDateCutof.Size = New System.Drawing.Size(209, 20)
        Me.txtDateCutof.TabIndex = 633
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 50)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(112, 13)
        Me.LabelControl1.TabIndex = 615
        Me.LabelControl1.Text = "Select Report Template"
        '
        'txtReportTemplate
        '
        Me.txtReportTemplate.EditValue = ""
        Me.txtReportTemplate.Location = New System.Drawing.Point(16, 66)
        Me.txtReportTemplate.Name = "txtReportTemplate"
        Me.txtReportTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtReportTemplate.Properties.DisplayFormat.FormatString = "MMMM"
        Me.txtReportTemplate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtReportTemplate.Properties.EditFormat.FormatString = "MMMM"
        Me.txtReportTemplate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtReportTemplate.Properties.Items.AddRange(New Object() {"Development Bank of the Philippines", "Land Bank of the Philippines", "Bank of the Philippine Island", "Small Business Corporation", "United Coco Planters Bank", "National Livelyhood Development Corporation"})
        Me.txtReportTemplate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtReportTemplate.Size = New System.Drawing.Size(307, 20)
        Me.txtReportTemplate.TabIndex = 614
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(16, 397)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(307, 36)
        Me.cmdPrint.TabIndex = 617
        Me.cmdPrint.Text = "Generate Report"
        '
        'ls
        '
        Me.ls.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ls.Appearance.Options.UseFont = True
        Me.ls.CheckOnClick = True
        Me.ls.HorizontalScrollbar = True
        Me.ls.HotTrackItems = True
        Me.ls.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick
        Me.ls.Location = New System.Drawing.Point(16, 244)
        Me.ls.Name = "ls"
        Me.ls.Size = New System.Drawing.Size(307, 119)
        Me.ls.TabIndex = 643
        '
        'custcode
        '
        Me.custcode.EditValue = ""
        Me.custcode.Location = New System.Drawing.Point(413, 358)
        Me.custcode.Name = "custcode"
        Me.custcode.Properties.Appearance.Options.UseTextOptions = True
        Me.custcode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.custcode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.custcode.Properties.Mask.BeepOnError = True
        Me.custcode.Properties.ReadOnly = True
        Me.custcode.Size = New System.Drawing.Size(57, 20)
        Me.custcode.TabIndex = 523
        Me.custcode.Visible = False
        '
        'frmLiquidationReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 587)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmLiquidationReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidation Report Generator"
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ckGroupBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadReportType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilterBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateTo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateCutof.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.custcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents custcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtReportTemplate As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents cmdPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDateCutof As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFilterBy As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ls As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents RadReportType As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAmountTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAmountFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents radGroup As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents ckGroupBranch As DevExpress.XtraEditors.CheckEdit
End Class
