Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.RibbonGalleryBarItem
Imports DevExpress.XtraCharts
Imports System.IO
Imports DevExpress.XtraReports.UI

Public Class PCBR3Main

    Sub New()
        InitSkins()
        InitializeComponent()
        Me.InitSkinGallery()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.OfficeSkins.Register()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(globaltheme)
    End Sub
    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)
    End Sub
    Private Sub pcbr3main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me And My.Application.OpenForms.Item(i) IsNot frmLogin Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i
        Dim gdt As String = GlobalDateTime()
        If XtraMessageBox.Show("Are you sure you want to logoff your account " & globaluser & "@" & globalfullname & " on " & globaldate & " - " & GlobalTime() & ") ?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            com.CommandText = "update tbllogin set outtime='" & gdt & "'  where userid='" & globaluserid & "'"
            com.ExecuteNonQuery()
            frmLogin.Show()
            userexit()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub XtraForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MonitoringDataSet.DataTable1' table. You can move, or remove it, as needed.
        Call ConnectVerify()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.OfficeSkins.Register()
        DevExpress.UserSkins.BonusSkins.Register()
        SkinHelper.InitSkinPopupMenu(skining)
        loadStatus()
        If sqlipaddress = "localhost" Then
            cmdRestoreDatabase.Visibility = BarItemVisibility.Always
        Else
            cmdRestoreDatabase.Visibility = BarItemVisibility.Never
        End If
        If globalpermission = 0 Then
            BarButtonItem44.Visibility = BarItemVisibility.Always
        Else
            BarButtonItem44.Visibility = BarItemVisibility.Never
        End If
        txtuser.Caption = globalfullname
        txtip.Caption = "Host: " & sqlipaddress
        txtServer.Caption = sqlservername
        CreateTableIfNotExists()
    End Sub

    Public Sub CreateTableIfNotExists()
        On Error Resume Next
        com.CommandText = "create database if not exists pcbr3 ;" : com.ExecuteNonQuery()
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblreporttemplate'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblreporttemplate` (  `rptid` varchar(15) NOT NULL,  `rptname` text NOT NULL,  `rptquery` longtext,  `status` int(1) NOT NULL DEFAULT '1',  `datequery` tinyint(1) NOT NULL DEFAULT '0',  `requestby` text NOT NULL,  PRIMARY KEY (`rptid`)) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblreportsetting'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblreportsetting` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `formname` varchar(45) NOT NULL,  `title` text,  `customtext` text,  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblaccounts'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblaccounts` (  `accountid` int(10) unsigned NOT NULL,  `fullname` varchar(45) NOT NULL,  `designation` text,  `username` varchar(45) NOT NULL,  `password` varchar(100) NOT NULL,  `permission` varchar(45) NOT NULL,  `datereg` datetime NOT NULL,  `status` int(10) unsigned NOT NULL DEFAULT '1',  `digitalsign` longblob,  `unitcode` varchar(45) DEFAULT NULL,  `theme` text,  PRIMARY KEY (`accountid`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
            com.CommandText = "INSERT INTO `tblaccounts` VALUES (105,'WINTER BUGAHOD','ADMINISTRATOR','ADMIN','31','0','2012-01-11 11:02:33',1,NULL,'LP1','McSkin'),(107,'ROQUE G. SAJONIA','LOAN OFFICER/RMU','KR5047SB','31323334','2','2012-11-21 18:09:37',1,NULL,'T1','Dark Side'),(108,'ARLYN A.ARAGON','MANAGER','KA0286AB','31323334','2','2013-01-22 11:15:29',1,NULL,'T1',NULL),(109,'MARIBEL T. BAGAY','ACCOUNTANT','KM0546BB','31323334','2','2013-03-06 10:21:58',1,NULL,'KB1',NULL),(110,'ERVIE E. CANE','GENERAL MANAGER','KE0726CB','3331353538343136','1','2013-03-06 11:14:52',1,NULL,'KB1','');" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblaosummary'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblaosummary` (  `ao` varchar(85) NOT NULL,  `branch` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,  `groupname` text NOT NULL,  `datesummary` date NOT NULL,  `areagroup` varchar(100) DEFAULT NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblappearance'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblappearance` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `form` text NOT NULL,  `img` longblob,  `width` int(10) unsigned NOT NULL,  `height` int(10) unsigned NOT NULL,  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblcompanysettings'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblcompanysettings` (  `unitcode` text NOT NULL,  `initialcode` varchar(7) DEFAULT NULL,  `companyname` text NOT NULL,  `compadd` text NOT NULL,  `telephone` text NOT NULL,  `email` text NOT NULL,  `website` text NOT NULL,  `chiefoff` text NOT NULL,  `designation` text NOT NULL,  `logo` longblob,  `kb` int(10) unsigned NOT NULL DEFAULT '0',  `digitalsign` longblob) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
            com.CommandText = "INSERT INTO `tblcompanysettings` VALUES ('KBI1','KB','KATIPUNAN BANK INC. CORPORATE','Quezon Avenue corner Aguilar St., Miputak, Dipolog City','Tel. No. (065) 212-9807','','','','',NULL,0,NULL);" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tbldelinquentlist'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tbldelinquentlist` (  `id` int(10) NOT NULL AUTO_INCREMENT,  `refcode` varchar(15) NOT NULL,  `custcode` varchar(15) NOT NULL,  `fullname` text,  `address` text,  `cellno` text,  `comaker1` text,  `comaker2` text,  `prodcode` varchar(30) NOT NULL,  `loanref` varchar(15) NOT NULL,  `status` text,  `probresult` text,  `sherifincharge` text,  `shrifcontact` text,  `legalincharge` text,  `asofdate` date NOT NULL,  `dayscount` double DEFAULT '0',  `principal` double DEFAULT '0',  `intrate` double DEFAULT '0',  `loandate` date DEFAULT NULL,  `maturdate` date DEFAULT NULL,  `ldtomdcount` double DEFAULT '0',  `pdintstallment` double DEFAULT '0',  `totalpdintstallment` double DEFAULT '0',  `outbal` double DEFAULT '0',  `intintonprincipal` double DEFAULT '0',  `intonprincipal` double DEFAULT '0',  `ckadvance_intonpri` tinyint(1) DEFAULT '1',  `date_from_intonpri` text,  `date_to_intonpri` text,  `cntdays_intonpri` double DEFAULT '0',  `compute_intonpri` int(1) DEFAULT '0',  `intpenalty` double DEFAULT '0',  `totalpenalty` double DEFAULT '0',  `ckoutstanding_penalty` tinyint(1) DEFAULT '1',  `ckadvance_penalty` tinyint(1) DEFAULT '1',  `date_from_penalty` text,  `date_to_penalty` text,  `cntdays_penalty` double DEFAULT '0',  `compute_penalty` int(1) DEFAULT '0',  `intintonint` double DEFAULT '0',  `totalintonint` double DEFAULT '0',  `ckprincipal_intonint` tinyint(1) DEFAULT '1',  `ckadvance_intonint` tinyint(1) DEFAULT '1',  `date_from_intonint` text,  `date_to_intonint` text,  `cntdays_intonint` double DEFAULT '0',  `compute_intonint` int(1) DEFAULT '0',  `intlegalrate` double DEFAULT '0',  `totallegalrate` double DEFAULT '0',  `ckadvance_legalrate` tinyint(1) DEFAULT '1',  `date_from_legalrate` text,  `date_to_legalrate` text,  `cntdays_legalrate` double DEFAULT '0',  `compute_legalrate` int(1) DEFAULT '0',  `attyfees` double DEFAULT '0',  `letigation` double DEFAULT '0',  `intpastdue` double DEFAULT '0',  `totalpastdue` double DEFAULT '0',  `ckadvance_pastdue` tinyint(1) DEFAULT '1',  `date_from_pastdue` text,  `date_to_pastdue` text,  `cntdays_pastdue` double DEFAULT '0',  `compute_pastdue` int(1) DEFAULT '0',  `addonpay` double DEFAULT '0',  `addonpayremarks` text,  `lesspay` double DEFAULT '0',  `grandtotal` double DEFAULT '0',  `notes` longtext,  `trnby` int(10) unsigned NOT NULL,  `datetrn` datetime NOT NULL,  `accstatus` int(1) unsigned NOT NULL DEFAULT '1',  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1 ROW_FORMAT=FIXED;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tbllogin'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tbllogin` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `userid` text NOT NULL,  `intime` datetime DEFAULT NULL,  `outtime` datetime DEFAULT NULL,  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=3917 DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblparredaccsumlist'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblparredaccsumlist` (  `parreddate` date NOT NULL,  `ao` varchar(100) COLLATE utf8_unicode_ci NOT NULL,  `branch` varchar(100) COLLATE utf8_unicode_ci NOT NULL,  `groupname` varchar(100) COLLATE utf8_unicode_ci NOT NULL,  `accdelinquent` bigint(21) DEFAULT NULL,  `ttldelinquent` double(19,2) NOT NULL DEFAULT '0.00',  `accpastdue` bigint(21) DEFAULT NULL,  `ttlaccpastdue` double(19,2) NOT NULL DEFAULT '0.00',  `accounts` bigint(21) DEFAULT NULL,  `ttlpar` double(19,2) NOT NULL DEFAULT '0.00',  `branchgroup` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `areagroup` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblpioneer'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblpioneer` (  `custcode` char(15) NOT NULL DEFAULT '',  `refno` char(10) NOT NULL DEFAULT '',  `fildate` varchar(69) DEFAULT NULL,  `Product` varchar(50) DEFAULT NULL,  `client` varchar(77) DEFAULT NULL,  `branch` varchar(30) DEFAULT NULL,  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `amtpaid` double(12,2) NOT NULL DEFAULT '0.00',  `interest` double(12,2) NOT NULL DEFAULT '0.00',  `pmntdate` date NOT NULL DEFAULT '1988-08-08',  `insurance` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt4` double(9,2) NOT NULL DEFAULT '0.00') ENGINE=MyISAM DEFAULT CHARSET=utf8;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblproductgroup'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblproductgroup` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `daysinterval` varchar(45) NOT NULL,  `productid` text NOT NULL,  `groupname` varchar(65) NOT NULL,  `branchgroup` varchar(45) NOT NULL DEFAULT 'DIPOLOG',  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblportfoliowithpar'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblportfoliowithpar` (  `parreddate` date NOT NULL,  `refno` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `loanprod` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `product` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,  `officer` varchar(101) COLLATE utf8_unicode_ci DEFAULT NULL,  `principal` double(18,2) NOT NULL DEFAULT '0.00',  `pribal` double(18,2) NOT NULL DEFAULT '0.00',  `branch` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,  `groupname` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchgroup` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `custcode` varchar(45) CHARACTER SET utf8 DEFAULT NULL,  `centername` text CHARACTER SET utf8,  `areagroup` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tblportfoliowithpar'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tblportfoliowithpar` (  `parreddate` date NOT NULL,  `refno` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `loanprod` char(20) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `product` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,  `officer` varchar(101) COLLATE utf8_unicode_ci DEFAULT NULL,  `principal` double(18,2) NOT NULL DEFAULT '0.00',  `pribal` double(18,2) NOT NULL DEFAULT '0.00',  `branch` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,  `groupname` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchgroup` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `custcode` varchar(45) CHARACTER SET utf8 DEFAULT NULL,  `centername` text CHARACTER SET utf8,  `areagroup` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : com.ExecuteNonQuery()
        End If
        If countqry("information_schema.tables", "table_schema = 'pcbr3' AND table_name = 'tbldormantsettings'") = 0 Then
            com.CommandText = "CREATE TABLE  `pcbr3`.`tbldormantsettings` (  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,  `depcode` varchar(500) NOT NULL,  `term` double NOT NULL DEFAULT '0',  PRIMARY KEY (`id`) USING BTREE) ENGINE=InnoDB AUTO_INCREMENT=87 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;" : com.ExecuteNonQuery()
        End If
        If countrecord("`pcbr3`.`tbldormantsettings`") = 0 Then
            com.CommandText = "insert into pcbr3.tbldormantsettings values(71, 'CSDEPAS', 730),(72, 'CSCAO', 730),(73, 'CSFRM', 730),(74, 'CSDEPPM2', 730),(75, 'ICARE', 730),(76, 'ICARE2', 730),(77, 'KKODEP', 730),(78, 'KTSC', 730),(79, 'PSDEPAS', 730),(80, 'PSFRM', 730),(81, 'PSDEPPM2', 730),(82, 'REGGRP', 730),(83, 'REGDEP', 730),(84, 'DEMDEPCORP', 180),(85, 'DEMDEPIND', 180),(86, 'DEMDEPSPEC', 180);" : com.ExecuteNonQuery()
        End If
    End Sub

    Public Sub loadStatus()
        Me.Text = compname + " Monitoring System " + " - Login as " & UCase(globaluser) & "@" & globalfullname & " on " & globaldate & " - " & GlobalTime()
    End Sub

    Private Sub BarButtonItem18_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        frmCompanySettings.ShowDialog()
    End Sub

    Private Sub BarButtonItem19_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        frmAppearance.Show()
    End Sub

    Private Sub BarButtonItem20_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        frmUserProfile.ShowDialog()
    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        frmUsersAccounts.Show()
        frmUsersAccounts.MdiParent = Me
        frmUsersAccounts.Show()
        frmUsersAccounts.Focus()
        frmUsersAccounts.filteruser()
    End Sub

    Private Sub BarButtonItem21_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        frmSystemSettings.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRestoreDatabase.ItemClick
        If XtraMessageBox.Show("Are you sure you want to update PCBR3 Database?" & globaluser & "@" & globalfullname & " on " & globaldate & " - " & GlobalTime() & ") ?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim sqlpath As String = ""
            Dim objOpenFileDialog As New OpenFileDialog
            'Set the Open dialog properties
            With objOpenFileDialog
                .Filter = "Backup files sql (*.sql)|*.sql|All files (*.*)|*.*"
                .FilterIndex = 1
                .Title = "Open File Dialog"
            End With

            'Show the Open dialog and if the user clicks the Open button,
            'load the file
            If objOpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim allText As String
                Try
                    'Read the contents of the file
                    allText = My.Computer.FileSystem.GetParentPath(objOpenFileDialog.FileName)
                    'Display the file contents in the TextBox
                    sqlpath = objOpenFileDialog.FileName
                Catch fileException As Exception
                    Throw fileException
                End Try

            End If

            'Clean up
            objOpenFileDialog.Dispose()
            objOpenFileDialog = Nothing

            If sqlpath <> "" Then
                Dim process As System.Diagnostics.Process
                Dim processStartInfo As System.Diagnostics.ProcessStartInfo
                processStartInfo = New System.Diagnostics.ProcessStartInfo
                processStartInfo.FileName = "cmd.exe"
                'processStartInfo.Arguments = "mysqldump --opt --password=1234 --user=root --database monitoring -r D:\test.sql"
                If System.Environment.OSVersion.Version.Major >= 6 Then ' Windows Vista or higher
                    processStartInfo.Verb = "runas"
                Else
                    ' No need to prompt to run as admin
                End If

                processStartInfo.Arguments = "/C mysql -h " & sqlipaddress & " -u" & sqlusername & " -p" & sqlpassword & " < """ & sqlpath & """"
                processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                processStartInfo.UseShellExecute = True
                process = System.Diagnostics.Process.Start(processStartInfo)
                'System.Threading.Thread.Sleep()
                process.WaitForExit()
                If process.HasExited Then
                    XtraMessageBox.Show("Database successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        frmDuplicateManager.MdiParent = Me
        frmDuplicateManager.Show()
        frmDuplicateManager.Focus()
    End Sub

    Private Sub BarButtonItem8_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        frmMasterList.Show(Me)
    End Sub

    Private Sub BarButtonItem9_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        frmCompanySettings.Show()
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        frmPastDueAccounts.MdiParent = Me
        frmPastDueAccounts.Show()
        frmPastDueAccounts.Focus()
        frmPastDueAccounts.filter()
    End Sub

    Private Sub BarButtonItem11_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        frmLitigatedAccounts.MdiParent = Me
        frmLitigatedAccounts.Show()
        frmLitigatedAccounts.Focus()
        frmLitigatedAccounts.filter()
    End Sub

    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        frmAccountStmt.Show()
    End Sub

    Private Sub BarButtonItem31_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        frmBackuptool.Show()
    End Sub

    Private Sub BarButtonItem32_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        frmPaymentCountPioneer.MdiParent = Me
        frmPaymentCountPioneer.Show()
        frmPaymentCountPioneer.Focus()
    End Sub

    Private Sub BarButtonItem33_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        frmPaymentCollection.MdiParent = Me
        frmPaymentCollection.Show()
        frmPaymentCollection.Focus()
    End Sub

    Private Sub BarButtonItem34_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem34.ItemClick
        frmConsolidation.Show()
    End Sub

    Private Sub BarButtonItem36_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem36.ItemClick
        frmConsoleItem.Show()
    End Sub

    Private Sub BarButtonItem37_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem37.ItemClick
        frmConsolidatedList.Show()
    End Sub

    Private Sub BarButtonItem35_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick
        frmConsolidatedCapture.Show()
    End Sub

    Private Sub BarButtonItem38_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        frmConsolidatedBranch.Show()
    End Sub

    Private Sub BarButtonItem39_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        frmConsolidatedHighLights.Show()
    End Sub

    Private Sub BarButtonItem40_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
        frmReportDeveloper.Show()
    End Sub

    Private Sub BarButtonItem41_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        frmReportGenerator.MdiParent = Me
        frmReportGenerator.Show()
        frmReportGenerator.Focus()
    End Sub

    Private Sub BarButtonItem42_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        frmAccountsHistory.MdiParent = Me
        frmAccountsHistory.Show()
        frmAccountsHistory.Focus()
    End Sub

    Private Sub BarButtonItem43_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem43.ItemClick
        rst.Close()
        conn.Close()
        Call ConnectVerify()
    End Sub

    Private Sub BarButtonItem44_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem44.ItemClick
        frmDatabaseUpdater.ShowDialog()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        frmPickProduct.Show(Me)
    End Sub


    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        frmProductChartSummary.MdiParent = Me
        frmProductChartSummary.Show()
        frmProductChartSummary.Focus()
    End Sub

    Private Sub cmdCollectionRate_ItemClick(sender As Object, e As ItemClickEventArgs) Handles cmdCollectionRate.ItemClick
        frmCollectionRate.MdiParent = Me
        frmCollectionRate.Show()
        frmCollectionRate.Focus()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        frmNoticeGenerator.Show()
    End Sub

    Private Sub cmdLiquidation_ItemClick(sender As Object, e As ItemClickEventArgs) Handles cmdLiquidation.ItemClick
        frmLiquidationReport.MdiParent = Me
        frmLiquidationReport.Show()
        frmLiquidationReport.Focus()
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        frmCIFCleanUP.MdiParent = Me
        frmCIFCleanUP.Show()
        frmCIFCleanUP.Focus()
    End Sub

    Private Sub BarButtonItem45_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem45.ItemClick
        frmClientConnetions.Show(Me)
    End Sub

    Private Sub BarButtonItem46_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem46.ItemClick
        frmDormantGenerator.Show(Me)
    End Sub
End Class