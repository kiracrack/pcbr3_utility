<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptAccountStmt
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
        Me.logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.cnumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.caddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.cname = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtdate = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtaddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtrefno = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtclientname = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.txtprename = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtpredesg = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtcomp = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.txtcomp2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.logo, Me.cnumber, Me.caddress, Me.cname, Me.txtdate})
        Me.TopMargin.HeightF = 176.6667!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'logo
        '
        Me.logo.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.logo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 29.1666!)
        Me.logo.Name = "logo"
        Me.logo.SizeF = New System.Drawing.SizeF(179.3333!, 147.5001!)
        Me.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.CenterImage
        '
        'cnumber
        '
        Me.cnumber.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.cnumber.KeepTogether = True
        Me.cnumber.LocationFloat = New DevExpress.Utils.PointFloat(179.3332!, 106.25!)
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
        Me.caddress.LocationFloat = New DevExpress.Utils.PointFloat(179.3333!, 87.5!)
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
        Me.txtdate.LocationFloat = New DevExpress.Utils.PointFloat(480.1249!, 154.7917!)
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel6, Me.XrLabel11, Me.txtaddress, Me.XrLabel9, Me.txtrefno, Me.XrLabel8, Me.txtclientname})
        Me.ReportHeader.HeightF = 129.255!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.Maroon
        Me.XrLabel6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.ForeColor = System.Drawing.Color.White
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(726.0!, 21.88!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "ACCOUNT INFORMATION"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 68.95333!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(194.54!, 15.62!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "ADDRESS:"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtaddress
        '
        Me.txtaddress.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Italic)
        Me.txtaddress.ForeColor = System.Drawing.Color.DimGray
        Me.txtaddress.LocationFloat = New DevExpress.Utils.PointFloat(194.54!, 68.95832!)
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtaddress.SizeF = New System.Drawing.SizeF(531.46!, 15.62501!)
        Me.txtaddress.StylePriority.UseFont = False
        Me.txtaddress.StylePriority.UseForeColor = False
        Me.txtaddress.StylePriority.UseTextAlignment = False
        Me.txtaddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 53.33332!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(194.54!, 15.62!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "BORROWER'S NAME:"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtrefno
        '
        Me.txtrefno.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Italic)
        Me.txtrefno.ForeColor = System.Drawing.Color.DimGray
        Me.txtrefno.LocationFloat = New DevExpress.Utils.PointFloat(194.54!, 37.70832!)
        Me.txtrefno.Name = "txtrefno"
        Me.txtrefno.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtrefno.SizeF = New System.Drawing.SizeF(531.46!, 15.625!)
        Me.txtrefno.StylePriority.UseFont = False
        Me.txtrefno.StylePriority.UseForeColor = False
        Me.txtrefno.StylePriority.UseTextAlignment = False
        Me.txtrefno.Text = "SAMPLE TEXT"
        Me.txtrefno.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 37.71331!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(194.54!, 15.62!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "ACCOUNT NO."
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtclientname
        '
        Me.txtclientname.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Italic)
        Me.txtclientname.ForeColor = System.Drawing.Color.DimGray
        Me.txtclientname.LocationFloat = New DevExpress.Utils.PointFloat(194.54!, 53.33332!)
        Me.txtclientname.Name = "txtclientname"
        Me.txtclientname.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtclientname.SizeF = New System.Drawing.SizeF(531.46!, 15.625!)
        Me.txtclientname.StylePriority.UseFont = False
        Me.txtclientname.StylePriority.UseForeColor = False
        Me.txtclientname.StylePriority.UseTextAlignment = False
        Me.txtclientname.Text = "SAMPLE TEXT"
        Me.txtclientname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtprename, Me.txtpredesg, Me.txtcomp, Me.XrLine3, Me.XrLine1, Me.txtcomp2, Me.XrLabel1, Me.XrLabel2, Me.XrLabel5, Me.XrLabel4})
        Me.GroupFooter2.HeightF = 170.2084!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'txtprename
        '
        Me.txtprename.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprename.LocationFloat = New DevExpress.Utils.PointFloat(35.41667!, 117.0834!)
        Me.txtprename.Name = "txtprename"
        Me.txtprename.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtprename.SizeF = New System.Drawing.SizeF(365.0!, 15.625!)
        Me.txtprename.StylePriority.UseFont = False
        Me.txtprename.StylePriority.UseTextAlignment = False
        Me.txtprename.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtpredesg
        '
        Me.txtpredesg.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtpredesg.LocationFloat = New DevExpress.Utils.PointFloat(35.41667!, 133.5833!)
        Me.txtpredesg.Name = "txtpredesg"
        Me.txtpredesg.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtpredesg.SizeF = New System.Drawing.SizeF(365.0!, 15.625!)
        Me.txtpredesg.StylePriority.UseFont = False
        Me.txtpredesg.StylePriority.UseTextAlignment = False
        Me.txtpredesg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtcomp
        '
        Me.txtcomp.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtcomp.LocationFloat = New DevExpress.Utils.PointFloat(35.41667!, 154.5834!)
        Me.txtcomp.Name = "txtcomp"
        Me.txtcomp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtcomp.SizeF = New System.Drawing.SizeF(365.0!, 15.625!)
        Me.txtcomp.StylePriority.UseFont = False
        Me.txtcomp.StylePriority.UseTextAlignment = False
        Me.txtcomp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine3
        '
        Me.XrLine3.ForeColor = System.Drawing.Color.Gray
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(22.91667!, 104.5833!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(282.7082!, 7.291672!)
        Me.XrLine3.StylePriority.UseForeColor = False
        '
        'XrLine1
        '
        Me.XrLine1.ForeColor = System.Drawing.Color.Gray
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(422.9167!, 104.5833!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(282.7082!, 7.291672!)
        Me.XrLine1.StylePriority.UseForeColor = False
        '
        'txtcomp2
        '
        Me.txtcomp2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtcomp2.LocationFloat = New DevExpress.Utils.PointFloat(435.4167!, 154.5834!)
        Me.txtcomp2.Name = "txtcomp2"
        Me.txtcomp2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtcomp2.SizeF = New System.Drawing.SizeF(282.7083!, 15.625!)
        Me.txtcomp2.StylePriority.UseFont = False
        Me.txtcomp2.StylePriority.UseTextAlignment = False
        Me.txtcomp2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 42.08333!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(147.1251!, 22.91666!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Prepared by:"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(435.4167!, 117.0834!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(282.7083!, 15.625!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(422.9167!, 42.08333!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(147.1251!, 22.91666!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Checked by:"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(435.4167!, 133.5833!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(282.7083!, 15.625!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.Maroon
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.ForeColor = System.Drawing.Color.White
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(1.0!, 97.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(726.0!, 21.88!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Account Due"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rptAccountStmt
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupFooter2})
        Me.Margins = New System.Drawing.Printing.Margins(59, 60, 177, 80)
        Me.Version = "11.1"
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
    Friend WithEvents txtprename As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtpredesg As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtcomp As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents txtcomp2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtaddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtrefno As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtclientname As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
End Class
