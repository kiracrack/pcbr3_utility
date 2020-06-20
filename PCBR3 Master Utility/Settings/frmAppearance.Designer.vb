<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppearance
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tablogin = New DevExpress.XtraTab.XtraTabPage()
        Me.cmdUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.logo = New DevExpress.XtraEditors.GroupControl()
        Me.piclogo = New DevExpress.XtraEditors.PictureEdit()
        Me.txtwidth = New DevExpress.XtraEditors.TextEdit()
        Me.txthieght = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.tablogin.SuspendLayout()
        CType(Me.logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.logo.SuspendLayout()
        CType(Me.piclogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtwidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txthieght.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 22)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.tablogin
        Me.XtraTabControl1.Size = New System.Drawing.Size(428, 451)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tablogin})
        '
        'tablogin
        '
        Me.tablogin.Controls.Add(Me.cmdUpdate)
        Me.tablogin.Controls.Add(Me.LabelControl1)
        Me.tablogin.Controls.Add(Me.logo)
        Me.tablogin.Controls.Add(Me.txtwidth)
        Me.tablogin.Controls.Add(Me.txthieght)
        Me.tablogin.Controls.Add(Me.LabelControl4)
        Me.tablogin.Controls.Add(Me.LabelControl3)
        Me.tablogin.Name = "tablogin"
        Me.tablogin.Size = New System.Drawing.Size(422, 425)
        Me.tablogin.Text = "Login Wallpaper"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdUpdate.Location = New System.Drawing.Point(166, 370)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(103, 28)
        Me.cmdUpdate.TabIndex = 388
        Me.cmdUpdate.Text = "Update Form"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LabelControl1.Location = New System.Drawing.Point(217, 328)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl1.TabIndex = 387
        Me.LabelControl1.Text = "x"
        '
        'logo
        '
        Me.logo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logo.Controls.Add(Me.piclogo)
        Me.logo.Location = New System.Drawing.Point(29, 11)
        Me.logo.Name = "logo"
        Me.logo.Size = New System.Drawing.Size(365, 295)
        Me.logo.TabIndex = 386
        Me.logo.Text = "Import File"
        '
        'piclogo
        '
        Me.piclogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.piclogo.Location = New System.Drawing.Point(2, 22)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(361, 271)
        Me.piclogo.TabIndex = 375
        '
        'txtwidth
        '
        Me.txtwidth.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtwidth.EditValue = "237"
        Me.txtwidth.EnterMoveNextControl = True
        Me.txtwidth.Location = New System.Drawing.Point(156, 325)
        Me.txtwidth.Name = "txtwidth"
        Me.txtwidth.Properties.Appearance.Options.UseTextOptions = True
        Me.txtwidth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtwidth.Size = New System.Drawing.Size(57, 20)
        Me.txtwidth.TabIndex = 382
        '
        'txthieght
        '
        Me.txthieght.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txthieght.EditValue = "341"
        Me.txthieght.EnterMoveNextControl = True
        Me.txthieght.Location = New System.Drawing.Point(229, 325)
        Me.txthieght.Name = "txthieght"
        Me.txthieght.Properties.Appearance.Options.UseTextOptions = True
        Me.txthieght.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txthieght.Size = New System.Drawing.Size(57, 20)
        Me.txthieght.TabIndex = 383
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LabelControl4.Location = New System.Drawing.Point(156, 351)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(130, 13)
        Me.LabelControl4.TabIndex = 384
        Me.LabelControl4.Text = "Default login size 273, 341 "
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LabelControl3.Location = New System.Drawing.Point(104, 327)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 385
        Me.LabelControl3.Text = "Form Size"
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
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Close Window"
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(428, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 473)
        Me.barDockControlBottom.Size = New System.Drawing.Size(428, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 451)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(428, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 451)
        '
        'frmAppearance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 473)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(444, 511)
        Me.Name = "frmAppearance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Appearance Settings"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.tablogin.ResumeLayout(False)
        Me.tablogin.PerformLayout()
        CType(Me.logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.logo.ResumeLayout(False)
        CType(Me.piclogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtwidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txthieght.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tablogin As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents logo As DevExpress.XtraEditors.GroupControl
    Friend WithEvents piclogo As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtwidth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txthieght As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
End Class
