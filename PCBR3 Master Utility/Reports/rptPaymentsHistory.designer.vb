<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPaymentsHistory
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
        Me.txtTitleLab = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtaddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtrefno = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtclientname = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtmaturedate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtloandate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtPrincipal = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.txttotal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.TopMargin.HeightF = 185.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'logo
        '
        Me.logo.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.logo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.1666!)
        Me.logo.Name = "logo"
        Me.logo.SizeF = New System.Drawing.SizeF(179.3333!, 155.8334!)
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
        Me.BottomMargin.HeightF = 72.91666!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtTitleLab, Me.XrLabel6, Me.XrLabel11, Me.txtaddress, Me.XrLabel9, Me.txtrefno, Me.XrLabel8, Me.txtclientname, Me.txtmaturedate, Me.XrLabel21, Me.XrLabel22, Me.txtloandate, Me.XrLabel18, Me.txtPrincipal})
        Me.ReportHeader.HeightF = 206.7082!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'txtTitleLab
        '
        Me.txtTitleLab.BackColor = System.Drawing.Color.Maroon
        Me.txtTitleLab.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtTitleLab.ForeColor = System.Drawing.Color.White
        Me.txtTitleLab.LocationFloat = New DevExpress.Utils.PointFloat(0.2082825!, 177.6649!)
        Me.txtTitleLab.Name = "txtTitleLab"
        Me.txtTitleLab.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtTitleLab.SizeF = New System.Drawing.SizeF(726.0!, 21.875!)
        Me.txtTitleLab.StylePriority.UseBackColor = False
        Me.txtTitleLab.StylePriority.UseFont = False
        Me.txtTitleLab.StylePriority.UseForeColor = False
        Me.txtTitleLab.StylePriority.UseTextAlignment = False
        Me.txtTitleLab.Text = "Payments History"
        Me.txtTitleLab.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 61.95333!)
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
        Me.txtaddress.LocationFloat = New DevExpress.Utils.PointFloat(194.54!, 60.95832!)
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtaddress.SizeF = New System.Drawing.SizeF(530.1683!, 15.625!)
        Me.txtaddress.StylePriority.UseFont = False
        Me.txtaddress.StylePriority.UseForeColor = False
        Me.txtaddress.StylePriority.UseTextAlignment = False
        Me.txtaddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 46.33332!)
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
        Me.txtrefno.LocationFloat = New DevExpress.Utils.PointFloat(194.54!, 29.70833!)
        Me.txtrefno.Name = "txtrefno"
        Me.txtrefno.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtrefno.SizeF = New System.Drawing.SizeF(530.1683!, 15.625!)
        Me.txtrefno.StylePriority.UseFont = False
        Me.txtrefno.StylePriority.UseForeColor = False
        Me.txtrefno.StylePriority.UseTextAlignment = False
        Me.txtrefno.Text = "SAMPLE TEXT"
        Me.txtrefno.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 29.71331!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(194.54!, 15.62!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "LOAN NO."
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtclientname
        '
        Me.txtclientname.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Italic)
        Me.txtclientname.ForeColor = System.Drawing.Color.DimGray
        Me.txtclientname.LocationFloat = New DevExpress.Utils.PointFloat(194.54!, 45.33332!)
        Me.txtclientname.Name = "txtclientname"
        Me.txtclientname.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtclientname.SizeF = New System.Drawing.SizeF(530.1683!, 15.625!)
        Me.txtclientname.StylePriority.UseFont = False
        Me.txtclientname.StylePriority.UseForeColor = False
        Me.txtclientname.StylePriority.UseTextAlignment = False
        Me.txtclientname.Text = "SAMPLE TEXT"
        Me.txtclientname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtmaturedate
        '
        Me.txtmaturedate.Font = New System.Drawing.Font("Arial", 9.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.txtmaturedate.ForeColor = System.Drawing.Color.DimGray
        Me.txtmaturedate.LocationFloat = New DevExpress.Utils.PointFloat(567.1265!, 140.8366!)
        Me.txtmaturedate.Name = "txtmaturedate"
        Me.txtmaturedate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtmaturedate.SizeF = New System.Drawing.SizeF(158.5817!, 15.62001!)
        Me.txtmaturedate.StylePriority.UseFont = False
        Me.txtmaturedate.StylePriority.UseForeColor = False
        Me.txtmaturedate.StylePriority.UseTextAlignment = False
        Me.txtmaturedate.Text = "0.00"
        Me.txtmaturedate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel21
        '
        Me.XrLabel21.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(0.4165649!, 125.2167!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(192.4566!, 15.62!)
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "LOAN DATE"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel22
        '
        Me.XrLabel22.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(0.4165649!, 140.8366!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(192.4566!, 15.62!)
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.Text = "MATURITY DATE"
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtloandate
        '
        Me.txtloandate.Font = New System.Drawing.Font("Arial", 9.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.txtloandate.ForeColor = System.Drawing.Color.DimGray
        Me.txtloandate.LocationFloat = New DevExpress.Utils.PointFloat(567.1265!, 125.2167!)
        Me.txtloandate.Name = "txtloandate"
        Me.txtloandate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtloandate.SizeF = New System.Drawing.SizeF(158.5817!, 15.62001!)
        Me.txtloandate.StylePriority.UseFont = False
        Me.txtloandate.StylePriority.UseForeColor = False
        Me.txtloandate.StylePriority.UseTextAlignment = False
        Me.txtloandate.Text = "0.00"
        Me.txtloandate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel18
        '
        Me.XrLabel18.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(0.624911!, 157.4299!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(270.5816!, 15.62!)
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.StylePriority.UseTextAlignment = False
        Me.XrLabel18.Text = "PRINCIPAL"
        Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.ForeColor = System.Drawing.Color.DimGray
        Me.txtPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(567.6266!, 157.4299!)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtPrincipal.SizeF = New System.Drawing.SizeF(158.0817!, 15.62!)
        Me.txtPrincipal.StylePriority.UseFont = False
        Me.txtPrincipal.StylePriority.UseForeColor = False
        Me.txtPrincipal.StylePriority.UseTextAlignment = False
        Me.txtPrincipal.Text = "0.00"
        Me.txtPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtprename, Me.txtpredesg, Me.txtcomp, Me.XrLine3, Me.XrLine1, Me.txtcomp2, Me.XrLabel1, Me.XrLabel2, Me.XrLabel5, Me.XrLabel4})
        Me.GroupFooter2.HeightF = 136.4583!
        Me.GroupFooter2.Level = 1
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'txtprename
        '
        Me.txtprename.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprename.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 75.0!)
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
        Me.txtpredesg.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 91.5!)
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
        Me.txtcomp.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 112.5!)
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
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 62.5!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(282.7082!, 7.291672!)
        Me.XrLine3.StylePriority.UseForeColor = False
        '
        'XrLine1
        '
        Me.XrLine1.ForeColor = System.Drawing.Color.Gray
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(425.0!, 62.5!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(282.7082!, 7.291672!)
        Me.XrLine1.StylePriority.UseForeColor = False
        '
        'txtcomp2
        '
        Me.txtcomp2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtcomp2.LocationFloat = New DevExpress.Utils.PointFloat(437.5!, 112.5!)
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
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 0.0!)
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
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(437.5!, 75.0!)
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(425.0!, 0.0!)
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(437.5!, 91.5!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(282.7083!, 15.625!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine5, Me.XrLine4, Me.XrLine2, Me.txttotal, Me.XrLabel33})
        Me.GroupFooter1.HeightF = 35.33993!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'XrLine5
        '
        Me.XrLine5.BackColor = System.Drawing.Color.Transparent
        Me.XrLine5.BorderColor = System.Drawing.Color.DimGray
        Me.XrLine5.ForeColor = System.Drawing.Color.DimGray
        Me.XrLine5.LocationFloat = New DevExpress.Utils.PointFloat(533.8749!, 27.49678!)
        Me.XrLine5.Name = "XrLine5"
        Me.XrLine5.SizeF = New System.Drawing.SizeF(190.625!, 2.083344!)
        Me.XrLine5.StylePriority.UseBackColor = False
        Me.XrLine5.StylePriority.UseBorderColor = False
        Me.XrLine5.StylePriority.UseForeColor = False
        '
        'XrLine4
        '
        Me.XrLine4.BackColor = System.Drawing.Color.Transparent
        Me.XrLine4.BorderColor = System.Drawing.Color.DimGray
        Me.XrLine4.ForeColor = System.Drawing.Color.DimGray
        Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(534.0833!, 25.41326!)
        Me.XrLine4.Name = "XrLine4"
        Me.XrLine4.SizeF = New System.Drawing.SizeF(190.625!, 2.083344!)
        Me.XrLine4.StylePriority.UseBackColor = False
        Me.XrLine4.StylePriority.UseBorderColor = False
        Me.XrLine4.StylePriority.UseForeColor = False
        '
        'XrLine2
        '
        Me.XrLine2.BackColor = System.Drawing.Color.Transparent
        Me.XrLine2.BorderColor = System.Drawing.Color.DimGray
        Me.XrLine2.ForeColor = System.Drawing.Color.DimGray
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(534.7083!, 3.37499!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(190.625!, 2.083344!)
        Me.XrLine2.StylePriority.UseBackColor = False
        Me.XrLine2.StylePriority.UseBorderColor = False
        Me.XrLine2.StylePriority.UseForeColor = False
        '
        'txttotal
        '
        Me.txttotal.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.txttotal.KeepTogether = True
        Me.txttotal.LocationFloat = New DevExpress.Utils.PointFloat(566.6268!, 5.626678!)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txttotal.SizeF = New System.Drawing.SizeF(158.0817!, 19.78665!)
        Me.txttotal.StylePriority.UseFont = False
        Me.txttotal.StylePriority.UseTextAlignment = False
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel33
        '
        Me.XrLabel33.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel33.KeepTogether = True
        Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(36.20831!, 5.626678!)
        Me.XrLabel33.Name = "XrLabel33"
        Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel33.SizeF = New System.Drawing.SizeF(323.7066!, 19.78665!)
        Me.XrLabel33.StylePriority.UseFont = False
        Me.XrLabel33.StylePriority.UseTextAlignment = False
        Me.XrLabel33.Text = "Total Payment"
        Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'rptPaymentsHistory
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupFooter2, Me.GroupFooter1})
        Me.Margins = New System.Drawing.Printing.Margins(59, 60, 185, 73)
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
    Friend WithEvents txtTitleLab As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtmaturedate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtloandate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txttotal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine5 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
End Class
