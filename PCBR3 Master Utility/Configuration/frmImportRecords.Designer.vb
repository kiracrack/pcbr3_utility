<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportRecords
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
        Me.startAsyncButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.txtsqlQuery = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsqlQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'startAsyncButton
        '
        Me.startAsyncButton.Location = New System.Drawing.Point(8, 325)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(785, 30)
        Me.startAsyncButton.TabIndex = 7
        Me.startAsyncButton.Text = "Confirm Update"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(8, 361)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(785, 30)
        Me.ProgressBarControl1.TabIndex = 6
        '
        'txtsqlQuery
        '
        Me.txtsqlQuery.Location = New System.Drawing.Point(8, 9)
        Me.txtsqlQuery.Name = "txtsqlQuery"
        Me.txtsqlQuery.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.txtsqlQuery.Properties.Appearance.Options.UseTextOptions = True
        Me.txtsqlQuery.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.txtsqlQuery.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.txtsqlQuery.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.txtsqlQuery.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtsqlQuery.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.txtsqlQuery.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.txtsqlQuery.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.txtsqlQuery.Properties.ReadOnly = True
        Me.txtsqlQuery.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtsqlQuery.Properties.WordWrap = False
        Me.txtsqlQuery.Size = New System.Drawing.Size(784, 308)
        Me.txtsqlQuery.TabIndex = 8
        '
        'frmImportRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 397)
        Me.Controls.Add(Me.txtsqlQuery)
        Me.Controls.Add(Me.startAsyncButton)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportRecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Summary Records"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsqlQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents startAsyncButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents txtsqlQuery As DevExpress.XtraEditors.MemoEdit
End Class
