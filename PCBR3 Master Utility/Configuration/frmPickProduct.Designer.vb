<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPickProduct
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
        Me.ls = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.cmdSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtgroupname = New DevExpress.XtraEditors.TextEdit()
        Me.ck_micro = New DevExpress.XtraEditors.CheckEdit()
        Me.Em = New DevExpress.XtraGrid.GridControl()
        Me.gridmenustrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmdEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PickProductCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gridview1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mode = New DevExpress.XtraEditors.TextEdit()
        Me.id = New DevExpress.XtraEditors.TextEdit()
        Me.cmdcancel = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.txtfilter = New DevExpress.XtraEditors.TextEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.txtproductid = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtbranchgroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.gridGroupProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtdaysdelayed = New DevExpress.XtraEditors.TextEdit()
        Me.lblProducts = New DevExpress.XtraEditors.LabelControl()
        Me.lblungroupproduct = New DevExpress.XtraEditors.LabelControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.ls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtgroupname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck_micro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridmenustrip.SuspendLayout()
        CType(Me.gridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproductid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtbranchgroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridGroupProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdaysdelayed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ls
        '
        Me.ls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ls.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ls.Appearance.Options.UseFont = True
        Me.ls.CheckOnClick = True
        Me.ls.HotTrackItems = True
        Me.ls.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick
        Me.ls.Location = New System.Drawing.Point(7, 31)
        Me.ls.MultiColumn = True
        Me.ls.Name = "ls"
        Me.ls.Size = New System.Drawing.Size(531, 361)
        Me.ls.TabIndex = 618
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Location = New System.Drawing.Point(254, 417)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(139, 35)
        Me.cmdSearch.TabIndex = 617
        Me.cmdSearch.Text = "Generate Group Code"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Location = New System.Drawing.Point(399, 417)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(139, 35)
        Me.SimpleButton2.TabIndex = 623
        Me.SimpleButton2.Text = "Save Product Group"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl1.Location = New System.Drawing.Point(7, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(165, 13)
        Me.LabelControl1.TabIndex = 674
        Me.LabelControl1.Text = "PAR Grace period and group name"
        '
        'txtgroupname
        '
        Me.txtgroupname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtgroupname.Location = New System.Drawing.Point(111, 52)
        Me.txtgroupname.Name = "txtgroupname"
        Me.txtgroupname.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtgroupname.Properties.NullText = "Enter product group name"
        Me.txtgroupname.Size = New System.Drawing.Size(278, 20)
        Me.txtgroupname.TabIndex = 675
        '
        'ck_micro
        '
        Me.ck_micro.Location = New System.Drawing.Point(299, 8)
        Me.ck_micro.Name = "ck_micro"
        Me.ck_micro.Properties.Caption = "Micro Product"
        Me.ck_micro.Size = New System.Drawing.Size(98, 19)
        Me.ck_micro.TabIndex = 676
        '
        'Em
        '
        Me.Em.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Em.ContextMenuStrip = Me.gridmenustrip
        Me.Em.Location = New System.Drawing.Point(8, 78)
        Me.Em.MainView = Me.gridview1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(382, 374)
        Me.Em.TabIndex = 677
        Me.Em.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridview1})
        '
        'gridmenustrip
        '
        Me.gridmenustrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdEdit, Me.RemoveItemToolStripMenuItem, Me.PickProductCodeToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.gridmenustrip.Name = "gridmenustrip"
        Me.gridmenustrip.Size = New System.Drawing.Size(176, 98)
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.PCBR3_Utility.My.Resources.Resources.notebook__pencil
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(175, 22)
        Me.cmdEdit.Text = "Edit Product Group"
        '
        'RemoveItemToolStripMenuItem
        '
        Me.RemoveItemToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.notebook__minus
        Me.RemoveItemToolStripMenuItem.Name = "RemoveItemToolStripMenuItem"
        Me.RemoveItemToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.RemoveItemToolStripMenuItem.Text = "Remove Selected"
        '
        'PickProductCodeToolStripMenuItem
        '
        Me.PickProductCodeToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.sql
        Me.PickProductCodeToolStripMenuItem.Name = "PickProductCodeToolStripMenuItem"
        Me.PickProductCodeToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.PickProductCodeToolStripMenuItem.Text = "Pick Product Code"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(172, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.arrow_continue_090_left
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh Group"
        '
        'gridview1
        '
        Me.gridview1.GridControl = Me.Em
        Me.gridview1.Name = "gridview1"
        Me.gridview1.OptionsBehavior.Editable = False
        Me.gridview1.OptionsCustomization.AllowGroup = False
        Me.gridview1.OptionsCustomization.AllowSort = False
        Me.gridview1.OptionsMenu.EnableColumnMenu = False
        Me.gridview1.OptionsView.ShowGroupPanel = False
        '
        'mode
        '
        Me.mode.Location = New System.Drawing.Point(96, 218)
        Me.mode.Name = "mode"
        Me.mode.Size = New System.Drawing.Size(53, 20)
        Me.mode.TabIndex = 678
        Me.mode.Visible = False
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(155, 218)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(53, 20)
        Me.id.TabIndex = 679
        Me.id.Visible = False
        '
        'cmdcancel
        '
        Me.cmdcancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdcancel.Enabled = False
        Me.cmdcancel.Location = New System.Drawing.Point(109, 417)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(139, 35)
        Me.cmdcancel.TabIndex = 680
        Me.cmdcancel.Text = "Cancel Edit"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(403, 8)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Select All Product"
        Me.CheckEdit1.Size = New System.Drawing.Size(119, 19)
        Me.CheckEdit1.TabIndex = 681
        '
        'txtfilter
        '
        Me.txtfilter.EnterMoveNextControl = True
        Me.txtfilter.Location = New System.Drawing.Point(7, 7)
        Me.txtfilter.Name = "txtfilter"
        Me.txtfilter.Size = New System.Drawing.Size(286, 20)
        Me.txtfilter.TabIndex = 682
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
        Me.BarManager1.MaxItemId = 3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.FloatLocation = New System.Drawing.Point(371, 156)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2, True)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "&Close Window"
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Export Group"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(960, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 489)
        Me.barDockControlBottom.Size = New System.Drawing.Size(960, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 467)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(960, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 467)
        '
        'txtproductid
        '
        Me.txtproductid.Location = New System.Drawing.Point(96, 192)
        Me.txtproductid.Name = "txtproductid"
        Me.txtproductid.Size = New System.Drawing.Size(112, 20)
        Me.txtproductid.TabIndex = 687
        Me.txtproductid.Visible = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl2.Location = New System.Drawing.Point(10, 31)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl2.TabIndex = 692
        Me.LabelControl2.Text = "Select Branch Group"
        '
        'txtbranchgroup
        '
        Me.txtbranchgroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbranchgroup.EditValue = ""
        Me.txtbranchgroup.Location = New System.Drawing.Point(111, 28)
        Me.txtbranchgroup.Name = "txtbranchgroup"
        Me.txtbranchgroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtbranchgroup.Properties.DisplayMember = "Branch Group"
        Me.txtbranchgroup.Properties.NullText = ""
        Me.txtbranchgroup.Properties.ValueMember = "Branch Group"
        Me.txtbranchgroup.Properties.View = Me.gridGroupProduct
        Me.txtbranchgroup.Size = New System.Drawing.Size(279, 20)
        Me.txtbranchgroup.TabIndex = 693
        '
        'gridGroupProduct
        '
        Me.gridGroupProduct.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gridGroupProduct.Name = "gridGroupProduct"
        Me.gridGroupProduct.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gridGroupProduct.OptionsView.ShowGroupPanel = False
        '
        'txtdaysdelayed
        '
        Me.txtdaysdelayed.EditValue = "1"
        Me.txtdaysdelayed.Location = New System.Drawing.Point(6, 52)
        Me.txtdaysdelayed.Name = "txtdaysdelayed"
        Me.txtdaysdelayed.Properties.Appearance.Options.UseTextOptions = True
        Me.txtdaysdelayed.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtdaysdelayed.Properties.DisplayFormat.FormatString = "n"
        Me.txtdaysdelayed.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtdaysdelayed.Properties.EditFormat.FormatString = "n"
        Me.txtdaysdelayed.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtdaysdelayed.Size = New System.Drawing.Size(101, 20)
        Me.txtdaysdelayed.TabIndex = 673
        '
        'lblProducts
        '
        Me.lblProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProducts.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblProducts.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblProducts.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblProducts.Location = New System.Drawing.Point(370, 397)
        Me.lblProducts.Name = "lblProducts"
        Me.lblProducts.Size = New System.Drawing.Size(168, 13)
        Me.lblProducts.TabIndex = 698
        Me.lblProducts.Text = "Total Active Products 0"
        '
        'lblungroupproduct
        '
        Me.lblungroupproduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblungroupproduct.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblungroupproduct.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblungroupproduct.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblungroupproduct.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblungroupproduct.Location = New System.Drawing.Point(225, 398)
        Me.lblungroupproduct.Name = "lblungroupproduct"
        Me.lblungroupproduct.Size = New System.Drawing.Size(168, 13)
        Me.lblungroupproduct.TabIndex = 699
        Me.lblungroupproduct.Text = "Ungroup Products"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 22)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.PanelControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PanelControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(960, 467)
        Me.SplitContainerControl1.SplitterPosition = 404
        Me.SplitContainerControl1.TabIndex = 700
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.txtdaysdelayed)
        Me.PanelControl1.Controls.Add(Me.txtgroupname)
        Me.PanelControl1.Controls.Add(Me.Em)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.mode)
        Me.PanelControl1.Controls.Add(Me.txtbranchgroup)
        Me.PanelControl1.Controls.Add(Me.id)
        Me.PanelControl1.Controls.Add(Me.txtproductid)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(404, 467)
        Me.PanelControl1.TabIndex = 391
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txtfilter)
        Me.PanelControl2.Controls.Add(Me.ls)
        Me.PanelControl2.Controls.Add(Me.lblungroupproduct)
        Me.PanelControl2.Controls.Add(Me.cmdSearch)
        Me.PanelControl2.Controls.Add(Me.lblProducts)
        Me.PanelControl2.Controls.Add(Me.SimpleButton2)
        Me.PanelControl2.Controls.Add(Me.ck_micro)
        Me.PanelControl2.Controls.Add(Me.CheckEdit1)
        Me.PanelControl2.Controls.Add(Me.cmdcancel)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(551, 467)
        Me.PanelControl2.TabIndex = 392
        '
        'frmPickProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 489)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.MinimumSize = New System.Drawing.Size(976, 527)
        Me.Name = "frmPickProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Grouping"
        CType(Me.ls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtgroupname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck_micro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridmenustrip.ResumeLayout(False)
        CType(Me.gridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproductid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtbranchgroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridGroupProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdaysdelayed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ls As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents cmdSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtgroupname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ck_micro As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridview1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridmenustrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdcancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtfilter As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents txtproductid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtbranchgroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents gridGroupProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtdaysdelayed As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PickProductCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblProducts As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblungroupproduct As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
End Class
