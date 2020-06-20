<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoticeGenerator
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.gridmenustrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.txt1stNotice = New DevExpress.XtraEditors.LabelControl()
        Me.txt2ndNotice = New DevExpress.XtraEditors.LabelControl()
        Me.txt3rdNotice = New DevExpress.XtraEditors.LabelControl()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.ck1 = New DevExpress.XtraEditors.CheckEdit()
        Me.ck2 = New DevExpress.XtraEditors.CheckEdit()
        Me.ck3 = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridmenustrip.SuspendLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(286, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 143)
        Me.barDockControlBottom.Size = New System.Drawing.Size(286, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 143)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(286, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 143)
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 88)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(262, 30)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Generate PDF"
        '
        'gridmenustrip
        '
        Me.gridmenustrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveItemToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.gridmenustrip.Name = "gridmenustrip"
        Me.gridmenustrip.Size = New System.Drawing.Size(118, 54)
        '
        'RemoveItemToolStripMenuItem
        '
        Me.RemoveItemToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources.clipboard__minus
        Me.RemoveItemToolStripMenuItem.Name = "RemoveItemToolStripMenuItem"
        Me.RemoveItemToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveItemToolStripMenuItem.Text = "Remove"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(114, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = Global.PCBR3_Utility.My.Resources.Resources._125
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'SearchLookUpEdit1
        '
        Me.SearchLookUpEdit1.Location = New System.Drawing.Point(112, 38)
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEdit1.Properties.DisplayMember = "Fullname"
        Me.SearchLookUpEdit1.Properties.NullText = ""
        Me.SearchLookUpEdit1.Properties.ValueMember = "Fullname"
        Me.SearchLookUpEdit1.Size = New System.Drawing.Size(305, 20)
        Me.SearchLookUpEdit1.TabIndex = 0
        '
        'txt1stNotice
        '
        Me.txt1stNotice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txt1stNotice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txt1stNotice.Location = New System.Drawing.Point(118, 22)
        Me.txt1stNotice.Name = "txt1stNotice"
        Me.txt1stNotice.Size = New System.Drawing.Size(112, 13)
        Me.txt1stNotice.TabIndex = 614
        Me.txt1stNotice.Text = "data"
        '
        'txt2ndNotice
        '
        Me.txt2ndNotice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txt2ndNotice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txt2ndNotice.Location = New System.Drawing.Point(115, 41)
        Me.txt2ndNotice.Name = "txt2ndNotice"
        Me.txt2ndNotice.Size = New System.Drawing.Size(115, 13)
        Me.txt2ndNotice.TabIndex = 615
        Me.txt2ndNotice.Text = "data"
        '
        'txt3rdNotice
        '
        Me.txt3rdNotice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txt3rdNotice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txt3rdNotice.Location = New System.Drawing.Point(117, 60)
        Me.txt3rdNotice.Name = "txt3rdNotice"
        Me.txt3rdNotice.Size = New System.Drawing.Size(113, 13)
        Me.txt3rdNotice.TabIndex = 616
        Me.txt3rdNotice.Text = "data"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBarControl1.Location = New System.Drawing.Point(0, 124)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(286, 19)
        Me.ProgressBarControl1.TabIndex = 692
        Me.ProgressBarControl1.Visible = False
        '
        'ck1
        '
        Me.ck1.EditValue = True
        Me.ck1.Location = New System.Drawing.Point(20, 16)
        Me.ck1.MenuManager = Me.BarManager1
        Me.ck1.Name = "ck1"
        Me.ck1.Properties.Caption = "First Notice:"
        Me.ck1.Size = New System.Drawing.Size(88, 19)
        Me.ck1.TabIndex = 700
        '
        'ck2
        '
        Me.ck2.EditValue = True
        Me.ck2.Location = New System.Drawing.Point(20, 37)
        Me.ck2.MenuManager = Me.BarManager1
        Me.ck2.Name = "ck2"
        Me.ck2.Properties.Caption = "Second Notice:"
        Me.ck2.Size = New System.Drawing.Size(100, 19)
        Me.ck2.TabIndex = 701
        '
        'ck3
        '
        Me.ck3.EditValue = True
        Me.ck3.Location = New System.Drawing.Point(20, 58)
        Me.ck3.MenuManager = Me.BarManager1
        Me.ck3.Name = "ck3"
        Me.ck3.Properties.Caption = "Third Notice:"
        Me.ck3.Size = New System.Drawing.Size(88, 19)
        Me.ck3.TabIndex = 702
        '
        'frmNoticeGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 143)
        Me.Controls.Add(Me.ck3)
        Me.Controls.Add(Me.ck2)
        Me.Controls.Add(Me.ck1)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.txt3rdNotice)
        Me.Controls.Add(Me.txt2ndNotice)
        Me.Controls.Add(Me.txt1stNotice)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmNoticeGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notice Generator"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridmenustrip.ResumeLayout(False)
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents gridmenustrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt3rdNotice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt2ndNotice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt1stNotice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents ck3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ck2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ck1 As DevExpress.XtraEditors.CheckEdit
End Class
