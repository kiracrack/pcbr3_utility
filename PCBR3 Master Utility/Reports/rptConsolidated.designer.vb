<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptConsolidated
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.txtemail = New DevExpress.XtraReports.UI.XRLabel()
        Me.logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.cnumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.caddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.cname = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtdate = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.txtTitleReport = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtconlasofdate = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtbranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtconsolidated = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.name3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.position3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.title3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.position2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.name2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.title2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.name1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.position1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.title1 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtemail, Me.logo, Me.cnumber, Me.caddress, Me.cname, Me.txtdate})
        Me.TopMargin.HeightF = 185.6667!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.txtemail.KeepTogether = True
        Me.txtemail.LocationFloat = New DevExpress.Utils.PointFloat(179.3332!, 119.0417!)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtemail.SizeF = New System.Drawing.SizeF(374.2084!, 19.79167!)
        Me.txtemail.StylePriority.UseFont = False
        Me.txtemail.StylePriority.UseTextAlignment = False
        Me.txtemail.Text = "cnumber"
        Me.txtemail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'logo
        '
        Me.logo.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.logo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 29.1666!)
        Me.logo.Name = "logo"
        Me.logo.SizeF = New System.Drawing.SizeF(179.3333!, 156.5001!)
        Me.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.CenterImage
        '
        'cnumber
        '
        Me.cnumber.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.cnumber.KeepTogether = True
        Me.cnumber.LocationFloat = New DevExpress.Utils.PointFloat(179.3332!, 102.25!)
        Me.cnumber.Name = "cnumber"
        Me.cnumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.cnumber.SizeF = New System.Drawing.SizeF(374.2084!, 19.79167!)
        Me.cnumber.StylePriority.UseFont = False
        Me.cnumber.StylePriority.UseTextAlignment = False
        Me.cnumber.Text = "cnumber"
        Me.cnumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'caddress
        '
        Me.caddress.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.caddress.KeepTogether = True
        Me.caddress.LocationFloat = New DevExpress.Utils.PointFloat(179.3333!, 86.5!)
        Me.caddress.Name = "caddress"
        Me.caddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.caddress.SizeF = New System.Drawing.SizeF(374.2084!, 18.75!)
        Me.caddress.StylePriority.UseFont = False
        Me.caddress.StylePriority.UseTextAlignment = False
        Me.caddress.Text = "cadd"
        Me.caddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cname
        '
        Me.cname.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cname.KeepTogether = True
        Me.cname.LocationFloat = New DevExpress.Utils.PointFloat(179.3333!, 65.625!)
        Me.cname.Name = "cname"
        Me.cname.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.cname.SizeF = New System.Drawing.SizeF(374.2084!, 21.875!)
        Me.cname.StylePriority.UseFont = False
        Me.cname.StylePriority.UseTextAlignment = False
        Me.cname.Text = "cname"
        Me.cname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtdate
        '
        Me.txtdate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdate.LocationFloat = New DevExpress.Utils.PointFloat(480.1249!, 163.7917!)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtdate.SizeF = New System.Drawing.SizeF(240.8751!, 21.875!)
        Me.txtdate.StylePriority.UseFont = False
        Me.txtdate.StylePriority.UseTextAlignment = False
        Me.txtdate.Text = "Date"
        Me.txtdate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 80.41662!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtTitleReport, Me.txtconlasofdate, Me.txtbranch, Me.txtconsolidated})
        Me.ReportHeader.HeightF = 88.63!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'txtTitleReport
        '
        Me.txtTitleReport.BackColor = System.Drawing.Color.Maroon
        Me.txtTitleReport.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtTitleReport.ForeColor = System.Drawing.Color.White
        Me.txtTitleReport.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.txtTitleReport.Name = "txtTitleReport"
        Me.txtTitleReport.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtTitleReport.SizeF = New System.Drawing.SizeF(726.0!, 21.88!)
        Me.txtTitleReport.StylePriority.UseBackColor = False
        Me.txtTitleReport.StylePriority.UseFont = False
        Me.txtTitleReport.StylePriority.UseForeColor = False
        Me.txtTitleReport.StylePriority.UseTextAlignment = False
        Me.txtTitleReport.Text = "FINANCIAL HIGHLIGHTS"
        Me.txtTitleReport.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtconlasofdate
        '
        Me.txtconlasofdate.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtconlasofdate.LocationFloat = New DevExpress.Utils.PointFloat(92.49832!, 57.13!)
        Me.txtconlasofdate.Name = "txtconlasofdate"
        Me.txtconlasofdate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtconlasofdate.SizeF = New System.Drawing.SizeF(531.46!, 15.62501!)
        Me.txtconlasofdate.StylePriority.UseFont = False
        Me.txtconlasofdate.StylePriority.UseForeColor = False
        Me.txtconlasofdate.StylePriority.UseTextAlignment = False
        Me.txtconlasofdate.Text = "As of December 31, 2013"
        Me.txtconlasofdate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtbranch
        '
        Me.txtbranch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbranch.LocationFloat = New DevExpress.Utils.PointFloat(92.49835!, 41.50499!)
        Me.txtbranch.Name = "txtbranch"
        Me.txtbranch.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtbranch.SizeF = New System.Drawing.SizeF(531.46!, 15.625!)
        Me.txtbranch.StylePriority.UseFont = False
        Me.txtbranch.StylePriority.UseForeColor = False
        Me.txtbranch.StylePriority.UseTextAlignment = False
        Me.txtbranch.Text = "Bangko Rural ng Tagoloan - Main"
        Me.txtbranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtconsolidated
        '
        Me.txtconsolidated.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconsolidated.LocationFloat = New DevExpress.Utils.PointFloat(92.49832!, 25.87999!)
        Me.txtconsolidated.Name = "txtconsolidated"
        Me.txtconsolidated.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtconsolidated.SizeF = New System.Drawing.SizeF(531.46!, 15.625!)
        Me.txtconsolidated.StylePriority.UseFont = False
        Me.txtconsolidated.StylePriority.UseForeColor = False
        Me.txtconsolidated.StylePriority.UseTextAlignment = False
        Me.txtconsolidated.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.name3, Me.position3, Me.XrLine2, Me.title3, Me.position2, Me.name2, Me.title2, Me.XrLine1, Me.name1, Me.position1, Me.XrLine3, Me.title1})
        Me.GroupFooter2.HeightF = 170.2084!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'name3
        '
        Me.name3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.name3.LocationFloat = New DevExpress.Utils.PointFloat(512.5!, 84.83337!)
        Me.name3.Name = "name3"
        Me.name3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.name3.SizeF = New System.Drawing.SizeF(208.5!, 15.62502!)
        Me.name3.StylePriority.UseFont = False
        Me.name3.StylePriority.UseTextAlignment = False
        Me.name3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'position3
        '
        Me.position3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.position3.LocationFloat = New DevExpress.Utils.PointFloat(512.5!, 101.3333!)
        Me.position3.Name = "position3"
        Me.position3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.position3.SizeF = New System.Drawing.SizeF(208.5!, 15.625!)
        Me.position3.StylePriority.UseFont = False
        Me.position3.StylePriority.UseTextAlignment = False
        Me.position3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine2
        '
        Me.XrLine2.ForeColor = System.Drawing.Color.Gray
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(512.5!, 75.33331!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(208.5001!, 7.291672!)
        Me.XrLine2.StylePriority.UseForeColor = False
        '
        'title3
        '
        Me.title3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title3.LocationFloat = New DevExpress.Utils.PointFloat(512.5!, 10.00001!)
        Me.title3.Name = "title3"
        Me.title3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.title3.SizeF = New System.Drawing.SizeF(147.1251!, 22.91666!)
        Me.title3.StylePriority.UseFont = False
        Me.title3.StylePriority.UseTextAlignment = False
        Me.title3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'position2
        '
        Me.position2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.position2.LocationFloat = New DevExpress.Utils.PointFloat(255.2083!, 101.3333!)
        Me.position2.Name = "position2"
        Me.position2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.position2.SizeF = New System.Drawing.SizeF(212.5!, 15.625!)
        Me.position2.StylePriority.UseFont = False
        Me.position2.StylePriority.UseTextAlignment = False
        Me.position2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'name2
        '
        Me.name2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.name2.LocationFloat = New DevExpress.Utils.PointFloat(255.2083!, 84.83337!)
        Me.name2.Name = "name2"
        Me.name2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.name2.SizeF = New System.Drawing.SizeF(212.5!, 15.62502!)
        Me.name2.StylePriority.UseFont = False
        Me.name2.StylePriority.UseTextAlignment = False
        Me.name2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'title2
        '
        Me.title2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title2.LocationFloat = New DevExpress.Utils.PointFloat(255.2083!, 10.00001!)
        Me.title2.Name = "title2"
        Me.title2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.title2.SizeF = New System.Drawing.SizeF(147.1251!, 22.91666!)
        Me.title2.StylePriority.UseFont = False
        Me.title2.StylePriority.UseTextAlignment = False
        Me.title2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.ForeColor = System.Drawing.Color.Gray
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(255.2083!, 75.33331!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(212.5!, 7.291672!)
        Me.XrLine1.StylePriority.UseForeColor = False
        '
        'name1
        '
        Me.name1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.name1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 84.83337!)
        Me.name1.Name = "name1"
        Me.name1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.name1.SizeF = New System.Drawing.SizeF(212.5!, 15.62502!)
        Me.name1.StylePriority.UseFont = False
        Me.name1.StylePriority.UseTextAlignment = False
        Me.name1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'position1
        '
        Me.position1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.position1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 101.3333!)
        Me.position1.Name = "position1"
        Me.position1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.position1.SizeF = New System.Drawing.SizeF(212.5!, 15.625!)
        Me.position1.StylePriority.UseFont = False
        Me.position1.StylePriority.UseTextAlignment = False
        Me.position1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine3
        '
        Me.XrLine3.ForeColor = System.Drawing.Color.Gray
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 75.33331!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(212.5!, 7.291664!)
        Me.XrLine3.StylePriority.UseForeColor = False
        '
        'title1
        '
        Me.title1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
        Me.title1.Name = "title1"
        Me.title1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.title1.SizeF = New System.Drawing.SizeF(147.1251!, 22.91666!)
        Me.title1.StylePriority.UseFont = False
        Me.title1.StylePriority.UseTextAlignment = False
        Me.title1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'rptConsolidated
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupFooter2})
        Me.Margins = New System.Drawing.Printing.Margins(59, 60, 186, 80)
        Me.Version = "12.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents logo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents cnumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents caddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cname As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents txtdate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents name1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents position1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents title1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtconlasofdate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtbranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtconsolidated As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtTitleReport As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtemail As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents name3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents position3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents title3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents position2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents name2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents title2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
End Class
