<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptNotice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptNotice))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.txtNotice = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtFullname = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtDateGenerate = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.txtTheManager = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtpredesg = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtContent2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtContent3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtContent1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtDearName = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
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
        Me.TopMargin.HeightF = 134.125!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'logo
        '
        Me.logo.Image = CType(resources.GetObject("logo.Image"), System.Drawing.Image)
        Me.logo.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 0.0!)
        Me.logo.Name = "logo"
        Me.logo.SizeF = New System.Drawing.SizeF(726.0!, 134.125!)
        Me.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.CenterImage
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1})
        Me.BottomMargin.HeightF = 134.125!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(731.0!, 134.125!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtNotice, Me.txtFullname, Me.txtDateGenerate, Me.txtAddress})
        Me.ReportHeader.HeightF = 133.7501!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'txtNotice
        '
        Me.txtNotice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtNotice.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 42.08333!)
        Me.txtNotice.Multiline = True
        Me.txtNotice.Name = "txtNotice"
        Me.txtNotice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtNotice.SizeF = New System.Drawing.SizeF(679.75!, 17.70833!)
        Me.txtNotice.StylePriority.UseFont = False
        Me.txtNotice.StylePriority.UseTextAlignment = False
        Me.txtNotice.Text = "First Notice"
        Me.txtNotice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtFullname
        '
        Me.txtFullname.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtFullname.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 94.37485!)
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
        Me.txtDateGenerate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 58.79166!)
        Me.txtDateGenerate.Multiline = True
        Me.txtDateGenerate.Name = "txtDateGenerate"
        Me.txtDateGenerate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtDateGenerate.SizeF = New System.Drawing.SizeF(679.75!, 18.75!)
        Me.txtDateGenerate.StylePriority.UseFont = False
        Me.txtDateGenerate.StylePriority.UseTextAlignment = False
        Me.txtDateGenerate.Text = "APRIL  8, 2014" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtDateGenerate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtAddress.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 112.5416!)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAddress.SizeF = New System.Drawing.SizeF(679.7501!, 20.20846!)
        Me.txtAddress.StylePriority.UseFont = False
        Me.txtAddress.StylePriority.UseTextAlignment = False
        Me.txtAddress.Text = "Sta. Filomena, Dipolog City, Zamboanga Del Norte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtTheManager, Me.txtpredesg, Me.txtNote})
        Me.GroupFooter2.HeightF = 144.1667!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'txtTheManager
        '
        Me.txtTheManager.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.txtTheManager.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 49.41661!)
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
        Me.txtpredesg.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 64.0416!)
        Me.txtpredesg.Name = "txtpredesg"
        Me.txtpredesg.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtpredesg.SizeF = New System.Drawing.SizeF(382.7083!, 15.625!)
        Me.txtpredesg.StylePriority.UseFont = False
        Me.txtpredesg.StylePriority.UseTextAlignment = False
        Me.txtpredesg.Text = "Branch Manager"
        Me.txtpredesg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtNote.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 114.3751!)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtNote.SizeF = New System.Drawing.SizeF(382.7083!, 15.625!)
        Me.txtNote.StylePriority.UseFont = False
        Me.txtNote.StylePriority.UseTextAlignment = False
        Me.txtNote.Text = "Note: Please disregard this notice if payment has been made."
        Me.txtNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtContent2
        '
        Me.txtContent2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 141.8749!)
        Me.txtContent2.Name = "txtContent2"
        Me.txtContent2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtContent2.SizeF = New System.Drawing.SizeF(721.0!, 69.50003!)
        Me.txtContent2.StylePriority.UseFont = False
        Me.txtContent2.StylePriority.UseTextAlignment = False
        Me.txtContent2.Text = resources.GetString("txtContent2.Text")
        Me.txtContent2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtContent3
        '
        Me.txtContent3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 211.3749!)
        Me.txtContent3.Multiline = True
        Me.txtContent3.Name = "txtContent3"
        Me.txtContent3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtContent3.SizeF = New System.Drawing.SizeF(563.3334!, 133.7502!)
        Me.txtContent3.StylePriority.UseFont = False
        Me.txtContent3.StylePriority.UseTextAlignment = False
        Me.txtContent3.Text = "Please see us anytime during office hours to settle your account on or before the" & _
    " due date." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "We shall appreciate your kind attention on this matter." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Our war" & _
    "mest regards." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Very truly yours,"
        Me.txtContent3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtContent1
        '
        Me.txtContent1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 79.37495!)
        Me.txtContent1.Name = "txtContent1"
        Me.txtContent1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtContent1.SizeF = New System.Drawing.SizeF(721.0!, 62.49999!)
        Me.txtContent1.StylePriority.UseFont = False
        Me.txtContent1.StylePriority.UseTextAlignment = False
        Me.txtContent1.Text = resources.GetString("txtContent1.Text")
        Me.txtContent1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 43.33331!)
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
        Me.txtDearName.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtDearName, Me.txtContent3, Me.txtContent2, Me.txtContent1, Me.XrLabel2})
        Me.PageHeader.HeightF = 358.3335!
        Me.PageHeader.Name = "PageHeader"
        '
        'rptNotice
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupFooter2, Me.PageHeader})
        Me.Margins = New System.Drawing.Printing.Margins(59, 60, 134, 134)
        Me.Version = "12.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents txtTheManager As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtpredesg As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtDateGenerate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtContent2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtContent3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtContent1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtDearName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents logo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents txtNotice As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtFullname As DevExpress.XtraReports.UI.XRLabel
End Class
