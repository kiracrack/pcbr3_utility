<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptDormancy
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDormancy))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.txtProvince = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtFullname = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtDateGenerate = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.txtTheManager = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtpredesg = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtModifiedContent = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtContent3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtContent1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtDearName = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Expanded = False
        Me.Detail.HeightF = 235.2085!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.logo})
        Me.TopMargin.HeightF = 138.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'logo
        '
        Me.logo.BorderWidth = 0.0!
        Me.logo.Image = CType(resources.GetObject("logo.Image"), System.Drawing.Image)
        Me.logo.KeepTogether = False
        Me.logo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.logo.Name = "logo"
        Me.logo.SizeF = New System.Drawing.SizeF(846.875!, 128.125!)
        Me.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize
        Me.logo.StylePriority.UseBorderWidth = False
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1})
        Me.BottomMargin.HeightF = 104.7499!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(846.875!, 104.1667!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel4, Me.txtProvince, Me.txtFullname, Me.txtDateGenerate, Me.txtAddress})
        Me.ReportHeader.HeightF = 192.0834!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'txtProvince
        '
        Me.txtProvince.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtProvince.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 121.5417!)
        Me.txtProvince.Multiline = True
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtProvince.SizeF = New System.Drawing.SizeF(679.7501!, 20.20846!)
        Me.txtProvince.StylePriority.UseFont = False
        Me.txtProvince.StylePriority.UseTextAlignment = False
        Me.txtProvince.Text = "Zamboanga Del Norte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtProvince.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtFullname
        '
        Me.txtFullname.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtFullname.LocationFloat = New DevExpress.Utils.PointFloat(63.00005!, 84.37485!)
        Me.txtFullname.Multiline = True
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtFullname.SizeF = New System.Drawing.SizeF(679.75!, 19.16679!)
        Me.txtFullname.StylePriority.UseFont = False
        Me.txtFullname.StylePriority.UseTextAlignment = False
        Me.txtFullname.Text = "DON JOHN FERNANDEZ"
        Me.txtFullname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtDateGenerate
        '
        Me.txtDateGenerate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtDateGenerate.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 36.79168!)
        Me.txtDateGenerate.Multiline = True
        Me.txtDateGenerate.Name = "txtDateGenerate"
        Me.txtDateGenerate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtDateGenerate.SizeF = New System.Drawing.SizeF(414.125!, 18.75!)
        Me.txtDateGenerate.StylePriority.UseFont = False
        Me.txtDateGenerate.StylePriority.UseTextAlignment = False
        Me.txtDateGenerate.Text = "APRIL  8, 2014" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtDateGenerate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtAddress.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 102.5416!)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAddress.SizeF = New System.Drawing.SizeF(679.7501!, 20.20846!)
        Me.txtAddress.StylePriority.UseFont = False
        Me.txtAddress.StylePriority.UseTextAlignment = False
        Me.txtAddress.Text = "Sta. Filomena, Dipolog City"
        Me.txtAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.txtTheManager, Me.txtpredesg})
        Me.GroupFooter2.HeightF = 107.7084!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'txtTheManager
        '
        Me.txtTheManager.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtTheManager.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 54.62494!)
        Me.txtTheManager.Name = "txtTheManager"
        Me.txtTheManager.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtTheManager.SizeF = New System.Drawing.SizeF(382.7084!, 15.625!)
        Me.txtTheManager.StylePriority.UseFont = False
        Me.txtTheManager.StylePriority.UseTextAlignment = False
        Me.txtTheManager.Text = "WINTER BUGAHOD"
        Me.txtTheManager.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtpredesg
        '
        Me.txtpredesg.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtpredesg.LocationFloat = New DevExpress.Utils.PointFloat(62.99995!, 70.24994!)
        Me.txtpredesg.Name = "txtpredesg"
        Me.txtpredesg.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtpredesg.SizeF = New System.Drawing.SizeF(382.7083!, 15.625!)
        Me.txtpredesg.StylePriority.UseFont = False
        Me.txtpredesg.StylePriority.UseTextAlignment = False
        Me.txtpredesg.Text = "Branch Manager"
        Me.txtpredesg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtModifiedContent
        '
        Me.txtModifiedContent.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModifiedContent.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 139.8749!)
        Me.txtModifiedContent.Name = "txtModifiedContent"
        Me.txtModifiedContent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtModifiedContent.SizeF = New System.Drawing.SizeF(721.0!, 41.37502!)
        Me.txtModifiedContent.StylePriority.UseFont = False
        Me.txtModifiedContent.StylePriority.UseTextAlignment = False
        Me.txtModifiedContent.Text = "Our records indicate that your account has been no sign of activity since 6/25/20" & _
    "14 with a balance of P60.21. If you wish to continue the usage of your account,"
        Me.txtModifiedContent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'txtContent3
        '
        Me.txtContent3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent3.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 185.2499!)
        Me.txtContent3.Multiline = True
        Me.txtContent3.Name = "txtContent3"
        Me.txtContent3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtContent3.SizeF = New System.Drawing.SizeF(721.0!, 53.54189!)
        Me.txtContent3.StylePriority.UseFont = False
        Me.txtContent3.StylePriority.UseTextAlignment = False
        Me.txtContent3.Text = resources.GetString("txtContent3.Text")
        Me.txtContent3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'txtContent1
        '
        Me.txtContent1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent1.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 79.37495!)
        Me.txtContent1.Name = "txtContent1"
        Me.txtContent1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtContent1.SizeF = New System.Drawing.SizeF(721.0!, 58.08327!)
        Me.txtContent1.StylePriority.UseFont = False
        Me.txtContent1.StylePriority.UseTextAlignment = False
        Me.txtContent1.Text = resources.GetString("txtContent1.Text")
        Me.txtContent1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 43.33331!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(277.9167!, 22.91666!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Good day!"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtDearName
        '
        Me.txtDearName.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtDearName.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 10.00001!)
        Me.txtDearName.Name = "txtDearName"
        Me.txtDearName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtDearName.SizeF = New System.Drawing.SizeF(277.9167!, 22.91666!)
        Me.txtDearName.StylePriority.UseFont = False
        Me.txtDearName.StylePriority.UseTextAlignment = False
        Me.txtDearName.Text = "Dear Timtim:"
        Me.txtDearName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.txtDearName, Me.txtContent3, Me.txtModifiedContent, Me.txtContent1, Me.XrLabel2})
        Me.PageHeader.HeightF = 308.6254!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(63.0!, 243.3335!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(721.0!, 47.29189!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Please take this opportunity to re-acquaint yourself with Katipunan Bank,Inc. You" & _
    " can update your account by making a deposit or withdrawal, and your account wil" & _
    "l no longer be reported as dormant."
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(63.00004!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(277.9167!, 22.91666!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Truly yours."
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Segoe UI", 14.75!, System.Drawing.FontStyle.Italic)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(506.0833!, 13.87501!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(277.9167!, 41.66667!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "NOTICE OF DORMANCY "
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptDormancy
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupFooter2, Me.PageHeader})
        Me.Margins = New System.Drawing.Printing.Margins(0, 1, 138, 105)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents txtTheManager As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtpredesg As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtDateGenerate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtModifiedContent As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtContent3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtContent1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtDearName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents logo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents txtFullname As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtProvince As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
End Class
