<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportDeveloper
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
        Me.txtReportQuery = New DevExpress.XtraEditors.MemoEdit()
        Me.txtReportTitle = New DevExpress.XtraEditors.TextEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.raddisplaytype = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtsortOrder = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtcolname = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Em = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkGroupColumn = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.chkGroupSummary = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.id = New DevExpress.XtraEditors.TextEdit()
        Me.txtGroupSummary = New DevExpress.XtraEditors.TextEdit()
        Me.chkGroupGeneral = New DevExpress.XtraEditors.CheckEdit()
        Me.txtgeneralSummary = New DevExpress.XtraEditors.TextEdit()
        Me.cbGroupsummary = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbGeneralSummary = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.mode = New DevExpress.XtraEditors.TextEdit()
        Me.colid = New DevExpress.XtraEditors.TextEdit()
        Me.colmode = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.rdalignment = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtReportQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.raddisplaytype.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsortOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcolname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGroupColumn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGroupSummary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroupSummary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGroupGeneral.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtgeneralSummary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGroupsummary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGeneralSummary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.colid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.colmode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdalignment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtReportQuery
        '
        Me.txtReportQuery.EditValue = ""
        Me.txtReportQuery.Location = New System.Drawing.Point(12, 75)
        Me.txtReportQuery.Name = "txtReportQuery"
        Me.txtReportQuery.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 11.0!)
        Me.txtReportQuery.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtReportQuery.Properties.Appearance.Options.UseFont = True
        Me.txtReportQuery.Properties.Appearance.Options.UseForeColor = True
        Me.txtReportQuery.Size = New System.Drawing.Size(868, 191)
        Me.txtReportQuery.TabIndex = 2
        '
        'txtReportTitle
        '
        Me.txtReportTitle.Location = New System.Drawing.Point(12, 49)
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportTitle.Properties.Appearance.Options.UseFont = True
        Me.txtReportTitle.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReportTitle.Size = New System.Drawing.Size(487, 20)
        Me.txtReportTitle.TabIndex = 1
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 5
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem4, True)})
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
        Me.BarButtonItem2.Caption = "Edit Other Template"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Clear Fileds"
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Help"
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(892, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 601)
        Me.barDockControlBottom.Size = New System.Drawing.Size(892, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 579)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(892, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 579)
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl7.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl7.Location = New System.Drawing.Point(36, 326)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl7.TabIndex = 397
        Me.LabelControl7.Text = "Display Type"
        '
        'raddisplaytype
        '
        Me.raddisplaytype.EditValue = "g"
        Me.raddisplaytype.Location = New System.Drawing.Point(99, 318)
        Me.raddisplaytype.MenuManager = Me.BarManager1
        Me.raddisplaytype.Name = "raddisplaytype"
        Me.raddisplaytype.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.raddisplaytype.Properties.Appearance.Options.UseBackColor = True
        Me.raddisplaytype.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.raddisplaytype.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("g", "General Display"), New DevExpress.XtraEditors.Controls.RadioGroupItem("c", "Currency (123,999.00)"), New DevExpress.XtraEditors.Controls.RadioGroupItem("n", "Number (123,999)")})
        Me.raddisplaytype.Size = New System.Drawing.Size(199, 72)
        Me.raddisplaytype.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl5.Location = New System.Drawing.Point(46, 466)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl5.TabIndex = 559
        Me.LabelControl5.Text = "Sort Order"
        '
        'txtsortOrder
        '
        Me.txtsortOrder.EditValue = ""
        Me.txtsortOrder.Location = New System.Drawing.Point(103, 463)
        Me.txtsortOrder.Name = "txtsortOrder"
        Me.txtsortOrder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtsortOrder.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsortOrder.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtsortOrder.Size = New System.Drawing.Size(174, 20)
        Me.txtsortOrder.TabIndex = 12
        '
        'txtcolname
        '
        Me.txtcolname.EditValue = ""
        Me.txtcolname.Location = New System.Drawing.Point(101, 296)
        Me.txtcolname.Name = "txtcolname"
        Me.txtcolname.Size = New System.Drawing.Size(247, 20)
        Me.txtcolname.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl2.Location = New System.Drawing.Point(32, 299)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 397
        Me.LabelControl2.Text = "Column Name"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl3.Location = New System.Drawing.Point(12, 274)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(121, 13)
        Me.LabelControl3.TabIndex = 397
        Me.LabelControl3.Text = "Column Configuration"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl4.Location = New System.Drawing.Point(12, 30)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(152, 13)
        Me.LabelControl4.TabIndex = 233
        Me.LabelControl4.Text = "Report Title && Mysql Query"
        '
        'Em
        '
        Me.Em.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Em.Location = New System.Drawing.Point(368, 272)
        Me.Em.MainView = Me.GridView1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(512, 277)
        Me.Em.TabIndex = 560
        Me.Em.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripSeparator2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "gridmenustrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.PCBR3_DataPatcher.My.Resources.Resources.clipboard__pencil
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 22)
        Me.ToolStripMenuItem1.Text = "Edit Selected"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.PCBR3_DataPatcher.My.Resources.Resources.clipboard__minus
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(164, 22)
        Me.ToolStripMenuItem2.Text = "Remove Selected"
        Me.ToolStripMenuItem2.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.PCBR3_DataPatcher.My.Resources.Resources._127
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(164, 22)
        Me.ToolStripMenuItem3.Text = "Refresh"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Em
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'chkGroupColumn
        '
        Me.chkGroupColumn.Location = New System.Drawing.Point(101, 389)
        Me.chkGroupColumn.MenuManager = Me.BarManager1
        Me.chkGroupColumn.Name = "chkGroupColumn"
        Me.chkGroupColumn.Properties.Caption = "Group Column"
        Me.chkGroupColumn.Size = New System.Drawing.Size(135, 19)
        Me.chkGroupColumn.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl1.Location = New System.Drawing.Point(30, 392)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 562
        Me.LabelControl1.Text = "Column Option"
        '
        'chkGroupSummary
        '
        Me.chkGroupSummary.Location = New System.Drawing.Point(16, 413)
        Me.chkGroupSummary.MenuManager = Me.BarManager1
        Me.chkGroupSummary.Name = "chkGroupSummary"
        Me.chkGroupSummary.Properties.Appearance.Options.UseTextOptions = True
        Me.chkGroupSummary.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkGroupSummary.Properties.Caption = "Group Summary"
        Me.chkGroupSummary.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkGroupSummary.Size = New System.Drawing.Size(104, 19)
        Me.chkGroupSummary.TabIndex = 6
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(624, 555)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(256, 34)
        Me.SimpleButton2.TabIndex = 14
        Me.SimpleButton2.Text = "Save Report"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(103, 516)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(174, 34)
        Me.SimpleButton3.TabIndex = 13
        Me.SimpleButton3.Text = "Save Column"
        '
        'id
        '
        Me.id.EditValue = ""
        Me.id.Location = New System.Drawing.Point(376, 555)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(56, 20)
        Me.id.TabIndex = 566
        Me.id.Visible = False
        '
        'txtGroupSummary
        '
        Me.txtGroupSummary.EditValue = ""
        Me.txtGroupSummary.Location = New System.Drawing.Point(124, 412)
        Me.txtGroupSummary.Name = "txtGroupSummary"
        Me.txtGroupSummary.Size = New System.Drawing.Size(153, 20)
        Me.txtGroupSummary.TabIndex = 7
        '
        'chkGroupGeneral
        '
        Me.chkGroupGeneral.Location = New System.Drawing.Point(5, 438)
        Me.chkGroupGeneral.MenuManager = Me.BarManager1
        Me.chkGroupGeneral.Name = "chkGroupGeneral"
        Me.chkGroupGeneral.Properties.Appearance.Options.UseTextOptions = True
        Me.chkGroupGeneral.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkGroupGeneral.Properties.Caption = "General Summary"
        Me.chkGroupGeneral.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkGroupGeneral.Size = New System.Drawing.Size(115, 19)
        Me.chkGroupGeneral.TabIndex = 9
        '
        'txtgeneralSummary
        '
        Me.txtgeneralSummary.EditValue = ""
        Me.txtgeneralSummary.Location = New System.Drawing.Point(124, 437)
        Me.txtgeneralSummary.Name = "txtgeneralSummary"
        Me.txtgeneralSummary.Size = New System.Drawing.Size(153, 20)
        Me.txtgeneralSummary.TabIndex = 10
        '
        'cbGroupsummary
        '
        Me.cbGroupsummary.EditValue = ""
        Me.cbGroupsummary.Location = New System.Drawing.Point(283, 412)
        Me.cbGroupsummary.Name = "cbGroupsummary"
        Me.cbGroupsummary.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbGroupsummary.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbGroupsummary.Properties.Items.AddRange(New Object() {"SUM", "COUNT"})
        Me.cbGroupsummary.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbGroupsummary.Size = New System.Drawing.Size(65, 20)
        Me.cbGroupsummary.TabIndex = 8
        '
        'cbGeneralSummary
        '
        Me.cbGeneralSummary.EditValue = ""
        Me.cbGeneralSummary.Location = New System.Drawing.Point(283, 437)
        Me.cbGeneralSummary.Name = "cbGeneralSummary"
        Me.cbGeneralSummary.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbGeneralSummary.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbGeneralSummary.Properties.Items.AddRange(New Object() {"SUM", "COUNT"})
        Me.cbGeneralSummary.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbGeneralSummary.Size = New System.Drawing.Size(65, 20)
        Me.cbGeneralSummary.TabIndex = 11
        '
        'mode
        '
        Me.mode.EditValue = ""
        Me.mode.Location = New System.Drawing.Point(438, 555)
        Me.mode.Name = "mode"
        Me.mode.Size = New System.Drawing.Size(56, 20)
        Me.mode.TabIndex = 577
        Me.mode.Visible = False
        '
        'colid
        '
        Me.colid.EditValue = ""
        Me.colid.Location = New System.Drawing.Point(500, 555)
        Me.colid.Name = "colid"
        Me.colid.Size = New System.Drawing.Size(56, 20)
        Me.colid.TabIndex = 578
        Me.colid.Visible = False
        '
        'colmode
        '
        Me.colmode.EditValue = ""
        Me.colmode.Location = New System.Drawing.Point(562, 555)
        Me.colmode.Name = "colmode"
        Me.colmode.Size = New System.Drawing.Size(56, 20)
        Me.colmode.TabIndex = 579
        Me.colmode.Visible = False
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(743, 108)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(60, 20)
        Me.TextEdit1.TabIndex = 0
        '
        'rdalignment
        '
        Me.rdalignment.EditValue = "L"
        Me.rdalignment.Location = New System.Drawing.Point(103, 488)
        Me.rdalignment.MenuManager = Me.BarManager1
        Me.rdalignment.Name = "rdalignment"
        Me.rdalignment.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rdalignment.Properties.Appearance.Options.UseBackColor = True
        Me.rdalignment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rdalignment.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("L", "(Default)"), New DevExpress.XtraEditors.Controls.RadioGroupItem("C", "Center"), New DevExpress.XtraEditors.Controls.RadioGroupItem("R", "Right")})
        Me.rdalignment.Size = New System.Drawing.Size(195, 22)
        Me.rdalignment.TabIndex = 584
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl6.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl6.Location = New System.Drawing.Point(49, 489)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl6.TabIndex = 585
        Me.LabelControl6.Text = "Alignment"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(504, 49)
        Me.CheckEdit1.MenuManager = Me.BarManager1
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Use date query"
        Me.CheckEdit1.Size = New System.Drawing.Size(135, 19)
        Me.CheckEdit1.TabIndex = 590
        '
        'frmReportDeveloper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 601)
        Me.Controls.Add(Me.CheckEdit1)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.colmode)
        Me.Controls.Add(Me.cbGeneralSummary)
        Me.Controls.Add(Me.colid)
        Me.Controls.Add(Me.mode)
        Me.Controls.Add(Me.cbGroupsummary)
        Me.Controls.Add(Me.txtgeneralSummary)
        Me.Controls.Add(Me.chkGroupGeneral)
        Me.Controls.Add(Me.txtGroupSummary)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.chkGroupSummary)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.chkGroupColumn)
        Me.Controls.Add(Me.Em)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtsortOrder)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtcolname)
        Me.Controls.Add(Me.raddisplaytype)
        Me.Controls.Add(Me.txtReportTitle)
        Me.Controls.Add(Me.txtReportQuery)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.rdalignment)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReportDeveloper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Developer"
        CType(Me.txtReportQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.raddisplaytype.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsortOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcolname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGroupColumn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGroupSummary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroupSummary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGroupGeneral.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtgeneralSummary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGroupsummary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGeneralSummary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.colid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.colmode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdalignment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReportQuery As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtReportTitle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents raddisplaytype As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtsortOrder As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtcolname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkGroupColumn As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkGroupSummary As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtgeneralSummary As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkGroupGeneral As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtGroupSummary As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbGeneralSummary As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbGroupsummary As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents mode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colmode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rdalignment As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class
