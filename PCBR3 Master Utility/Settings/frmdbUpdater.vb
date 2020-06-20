Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient

Public Class frmdbUpdater
    Dim dbname As String = ""
    Dim yearcount As Integer = 0
    Private beginyear As Date = Format(Now, "y")
    Private endyear As Date = Format(Now, "y")

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        If txtOffice.Text = "" Then
            XtraMessageBox.Show("Please select Branch!", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOffice.Focus()
            Exit Sub
        End If

        If connclient.State = ConnectionState.Closed Then
            XtraMessageBox.Show("Client connection currently close! please update client server", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If XtraMessageBox.Show("Are you sure you want to update PCBR3 Database?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            beginyear = txtfrmdate.Text
            endyear = txttodate.Text
            yearcount = DateDiff(DateInterval.Month, beginyear, endyear)

            '####################### appbin ################################
            comclient.CommandText = "DROP TABLE IF EXISTS `app_bin`.`loanadj`;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "/*!40101 SET @saved_cs_client     = @@character_set_client */;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "/*!40101 SET character_set_client = utf8 */;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "CREATE TABLE `app_bin`.`loanadj` (  `withterm` tinyint(1) NOT NULL DEFAULT '0',  `trnindex` char(1) NOT NULL DEFAULT '',  `custcode` char(5) NOT NULL DEFAULT '',  `adjdate` date NOT NULL DEFAULT '1998-08-08',  `refno` char(6) NOT NULL DEFAULT '',  `principal` double(10,2) NOT NULL DEFAULT '0.00',  `prin_add` tinyint(1) NOT NULL DEFAULT '1',  `interest` double(10,2) NOT NULL DEFAULT '0.00',  `int_add` tinyint(1) NOT NULL DEFAULT '1',  `penalty` double(10,2) NOT NULL DEFAULT '0.00',  `pen_add` tinyint(1) NOT NULL DEFAULT '1',  `chgadj1` double(9,2) NOT NULL DEFAULT '0.00',  `chg1_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj2` double(9,2) NOT NULL DEFAULT '0.00',  `chg2_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj3` double(9,2) NOT NULL DEFAULT '0.00',  `chg3_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj4` double(9,2) NOT NULL DEFAULT '0.00',  `chg4_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj5` double(9,2) NOT NULL DEFAULT '0.00',  `chg5_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj6` double(9,2) NOT NULL DEFAULT '0.00',  `chg6_add` tinyint(1) NOT NULL DEFAULT '0',  `recby` char(3) NOT NULL DEFAULT '',  `timerec` char(8) NOT NULL DEFAULT '',  `brief` char(30) NOT NULL DEFAULT '',  `remark` char(250) NOT NULL DEFAULT '',  `trackingnumber` char(17) NOT NULL DEFAULT '',  `approvedby` char(3) NOT NULL DEFAULT '',  `timeapproved` char(8) NOT NULL DEFAULT '',  KEY `loanadj_withterm` (`withterm`),  KEY `loanadj_refno` (`refno`),  KEY `loanadj_custcode` (`custcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "/*!40101 SET character_set_client = @saved_cs_client */;" : comclient.ExecuteNonQuery()

            For I = 0 To yearcount
                Me.Cursor = Cursors.WaitCursor
                dbname = "db" & beginyear.AddMonths(I).ToString("yyyyMM")

                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `" & dbname & "`.`chequesclearedbyho` (  `reference` char(17) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `numberofcheques` int(5) NOT NULL DEFAULT'0',  `amountofcheques` double(13,2) NOT NULL DEFAULT '0.00',  `numberofclearedcheques` int(5) NOT NULL DEFAULT '0',  `amountofclearedcheques` double(13,2) Not NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `branchcode` char(4)COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `entries` mediumtext COLLATE utf8_unicode_ci NOT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `" & dbname & "`.`glslentryasc` (  `reference` char(17) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `entrydate` date NOT NULL DEFAULT '1900-01-01',  `remark` char(240) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `rectime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `moddate` date NOT NULL DEFAULT '1900-01-01',  `modtime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `" & dbname & "`.`othercollections` (  `reference` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `payor` char(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgcode1` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt1` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode2` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt2` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode3` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt3` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode4` char(2) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `chgamt4` double(12,2) NOT NULL DEFAULT '0.00',  `cocipayment` tinyint(1) NOT NULL DEFAULT '0',  `pmntcode` char(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `totalamt` double(12,2) NOT NULL DEFAULT '0.00',  `cociamt` double(12,2) NOT NULL DEFAULT '0.00',  `cashchange` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `rectime` char(8) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `branchcode` char(4) COLLATE utf8_unicode_ci NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "delete from app_bin.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "insert app_bin.loanadj (withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, trackingnumber, approvedby, timeapproved) select withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, '' as trackingnumber, 'PCB' as approvedby, '00:00:00' as timeapproved from " & dbname & ".loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "drop table if exists " & dbname & ".loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "create table " & dbname & ".loanadj like app_bin.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "insert " & dbname & ".loanadj select * from app_bin.loanadj;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`deposittransactions` ADD COLUMN `correctionentry` TINYINT(1) NOT NULL DEFAULT 0 AFTER `validated`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`deposittransactions` ADD COLUMN `correctioncode` CHAR(15) NOT NULL DEFAULT '' AFTER `correctionentry`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`vouchers` ADD COLUMN `forhoexpensedistribution` TINYINT(1) NOT NULL DEFAULT 0 AFTER `reference`;" : comclient.ExecuteNonQuery()

                If ck_par.Checked = True Then
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `amortbal1` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgreg1` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgcurr1` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgarr1` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `amortbal2` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgreg2` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgcurr2` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgarr2` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `amortbal3` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgreg3` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgcurr3` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgarr3` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `amortbal4` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgreg4` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgcurr4` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgarr4` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `amortbal5` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgreg5` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgcurr5` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgarr5` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `amortbal6` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgreg6` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgcurr6` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                    comclient.CommandText = "ALTER TABLE `par`.`" & dbname.Replace("db", "") & "` MODIFY COLUMN `chgarr6` DECIMAL(9,2) NOT NULL DEFAULT '0.00';" : comclient.ExecuteNonQuery()
                End If

                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`collectionforbatching` MODIFY COLUMN `centerkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()

                If ck_updatefields.Checked = True Then ' Warning for Updating this area
                    comclient.CommandText = "UPDATE `" & dbname & "`.`collectionforbatching`  set centerkey=concat('" & branchcode.Text & "',centerkey);" : comclient.ExecuteNonQuery()
                End If

                If ck_utf8.Checked = True Then
                    dst = New DataSet
                    msda = New MySqlDataAdapter("show tables from " & dbname, conn)
                    msda.Fill(dst, 0)
                    For cnt = 0 To dst.Tables(0).Rows.Count - 1
                        With (dst.Tables(0))
                            Dim tablename As String = .Rows(cnt)("Tables_in_" & dbname).ToString()
                            comclient.CommandText = "ALTER TABLE `" & dbname & "`.`" & tablename & "` DEFAULT COLLATE utf8_general_ci" : comclient.ExecuteNonQuery()
                            comclient.CommandText = "ALTER TABLE `" & dbname & "`.`" & tablename & "` CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci " : comclient.ExecuteNonQuery()
                        End With
                    Next
                End If

            Next

            If ck_updateMaster.Checked = True Then
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`chequebookissuance` (  `chqissref` char(9) NOT NULL DEFAULT '',  `acctnumber` char(9) NOT NULL DEFAULT '',  `startchq` int(15) NOT NULL DEFAULT '0',  `endchq` int(15) NOT NULL DEFAULT '0',  `chqcount` int(3) NOT NULL DEFAULT '0',  `recby` char(3) NOT NULL DEFAULT '',  `branchcode` char(4) NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `outstandingchq` varchar(1600) NOT NULL DEFAULT '',  PRIMARY KEY (`chqissref`),  KEY `chqissref` (`chqissref`),  KEY `acctnumber` (`acctnumber`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`chequebookseriesissuance` (  `ref_prefix` char(1) NOT NULL DEFAULT '',  `ref_count` int(8) NOT NULL DEFAULT '0') ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`chequesclearedbyho` (  `reference` char(17) NOT NULL DEFAULT '',  `numberofcheques` int(5) NOT NULL DEFAULT '0',  `amountofcheques` double(13,2) NOT NULL DEFAULT '0.00',  `numberofclearedcheques` int(5) NOT NULL DEFAULT '0',  `amountofclearedcheques` double(13,2) NOT NULL DEFAULT '0.00',  `recby` char(3) NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `branchcode` char(4) NOT NULL DEFAULT '',  `entries` mediumtext NOT NULL) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`depositaccountsforpickup` ( `acctnumber` char(9) NOT NULL DEFAULT '',  `accountofficer` char(3) NOT NULL DEFAULT '',  KEY `acctnumber` (`acctnumber`),  KEY `accountofficer` (`accountofficer`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`hoexpensebranchshare` (  `reference` char(17) NOT NULL DEFAULT '',  `branchcode` char(4) NOT NULL DEFAULT '',  `amount` double(12,2) NOT NULL DEFAULT '0.00',  KEY `reference` (`reference`),  KEY `branchcode` (`branchcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`hoexpensetobranches` (  `reference` char(17) NOT NULL DEFAULT '',  `voucher_reference` char(10) NOT NULL DEFAULT '',  `ho_matchgroup` char(10) NOT NULL DEFAULT '',  `ho_matchitem` char(10) NOT NULL DEFAULT '',  `branch_matchgroup` char(10) NOT NULL DEFAULT '',  `branch_matchitem` char(10) NOT NULL DEFAULT '',  `purpose` char(200) NOT NULL DEFAULT '',  `recby` char(3) NOT NULL DEFAULT '',  `branchcode` char(4) NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  PRIMARY KEY (`reference`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`insurancetable` (  `categorycode` char(10) NOT NULL DEFAULT '',  `description` char(40) NOT NULL DEFAULT '',  `pervalue` double(10,2) NOT NULL DEFAULT '0.00',  `year1rate` double(8,4) NOT NULL DEFAULT '0.0000',  `year2rate` double(8,4) NOT NULL DEFAULT '0.0000',  `year3rate` double(8,4) NOT NULL DEFAULT '0.0000',  `year4rate` double(8,4) NOT NULL DEFAULT '0.0000',  `year5rate` double(8,4) NOT NULL DEFAULT '0.0000',  `ratebelowpervalue` double(8,4) NOT NULL DEFAULT '0.0000') ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`loanpaymentwithterm` (  `refno` char(10) NOT NULL DEFAULT '',  `trackingnumber` char(17) NOT NULL DEFAULT '',  `pmntdate` date NOT NULL DEFAULT '1988-08-08',  `lnrefno` char(6) NOT NULL DEFAULT '',  `branchcode` char(4) NOT NULL DEFAULT '',  `trnbranch` char(4) NOT NULL DEFAULT '',  `interbranch` tinyint(1) NOT NULL DEFAULT '0',  `amtpaid` double(12,2) NOT NULL DEFAULT '0.00',  `principal` double(12,2) NOT NULL DEFAULT '0.00',  `interest` double(12,2) NOT NULL DEFAULT '0.00',  `chgpmnt1` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt2` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt3` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt4` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt5` double(9,2) NOT NULL DEFAULT '0.00',  `chgpmnt6` double(9,2) NOT NULL DEFAULT '0.00',  `penalty` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) NOT NULL DEFAULT '',  `timerec` char(8) NOT NULL DEFAULT '',  `intdisc` double(12,2) NOT NULL DEFAULT '0.00',  `pendisc` double(12,2) NOT NULL DEFAULT '0.00',  `chgdisc1` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc2` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc3` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc4` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc5` double(9,2) NOT NULL DEFAULT '0.00',  `chgdisc6` double(9,2) NOT NULL DEFAULT '0.00',  `approved` tinyint(1) NOT NULL DEFAULT '0',  `approvedby` char(3) NOT NULL DEFAULT '',  `approvedtime` char(8) NOT NULL DEFAULT '',  `executionrefno` char(10) NOT NULL DEFAULT '',  `trnexecuted` tinyint(1) NOT NULL DEFAULT '0',  `trnexecutedby` char(3) NOT NULL DEFAULT '',  `trnexecutedtime` char(8) NOT NULL DEFAULT '',  KEY `lnwtermdet_refno` (`refno`),  KEY `lnwtermdet_lnrefno` (`lnrefno`),  KEY `lnwtermdet_branchcode` (`branchcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`solidary_borrowers` (  `reference` char(6) NOT NULL DEFAULT '',  `custcode` char(5) NOT NULL DEFAULT '',  KEY `reference` (`reference`),  KEY `custcode` (`custcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `master`.`othercollections` (  `reference` char(10) NOT NULL DEFAULT '',  `payor` char(50) NOT NULL DEFAULT '',  `chgcode1` char(2) NOT NULL DEFAULT '',  `chgamt1` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode2` char(2) NOT NULL DEFAULT '',  `chgamt2` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode3` char(2) NOT NULL DEFAULT '',  `chgamt3` double(12,2) NOT NULL DEFAULT '0.00',  `chgcode4` char(2) NOT NULL DEFAULT '',  `chgamt4` double(12,2) NOT NULL DEFAULT '0.00',  `cocipayment` tinyint(1) NOT NULL DEFAULT '0',  `pmntcode` char(10) NOT NULL DEFAULT '',  `totalamt` double(12,2) NOT NULL DEFAULT '0.00',  `cociamt` double(12,2) NOT NULL DEFAULT '0.00',  `cashchange` double(12,2) NOT NULL DEFAULT '0.00',  `recby` char(3) NOT NULL DEFAULT '',  `recdate` date NOT NULL DEFAULT '1900-01-01',  `rectime` char(8) NOT NULL DEFAULT '',  `branchcode` char(4) NOT NULL DEFAULT '') ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE TABLE IF NOT EXISTS `app_bin`.`loanadj` (  `withterm` tinyint(1) NOT NULL DEFAULT '0',  `trnindex` char(1) NOT NULL DEFAULT '',  `custcode` char(5) NOT NULL DEFAULT '',  `adjdate` date NOT NULL DEFAULT '1998-08-08',  `refno` char(6) NOT NULL DEFAULT '',  `principal` double(10,2) NOT NULL DEFAULT '0.00',  `prin_add` tinyint(1) NOT NULL DEFAULT '1',  `interest` double(10,2) NOT NULL DEFAULT '0.00',  `int_add` tinyint(1) NOT NULL DEFAULT '1',  `penalty` double(10,2) NOT NULL DEFAULT '0.00',  `pen_add` tinyint(1) NOT NULL DEFAULT '1',  `chgadj1` double(9,2) NOT NULL DEFAULT '0.00',  `chg1_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj2` double(9,2) NOT NULL DEFAULT '0.00',  `chg2_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj3` double(9,2) NOT NULL DEFAULT '0.00',  `chg3_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj4` double(9,2) NOT NULL DEFAULT '0.00',  `chg4_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj5` double(9,2) NOT NULL DEFAULT '0.00',  `chg5_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj6` double(9,2) NOT NULL DEFAULT '0.00',  `chg6_add` tinyint(1) NOT NULL DEFAULT '0',  `recby` char(3) NOT NULL DEFAULT '',  `timerec` char(8) NOT NULL DEFAULT '',  `brief` char(30) NOT NULL DEFAULT '',  `remark` char(250) NOT NULL DEFAULT '',  `trackingnumber` char(17) NOT NULL DEFAULT '',  `approvedby` char(3) NOT NULL DEFAULT '',  `timeapproved` char(8) NOT NULL DEFAULT '',  KEY `loanadj_withterm` (`withterm`),  KEY `loanadj_refno` (`refno`),  KEY `loanadj_custcode` (`custcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()


                comclient.CommandText = "ALTER TABLE `master`.`client` ADD COLUMN `dependents` CHAR(120) NOT NULL DEFAULT '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`client` ADD COLUMN `emergencycontact` CHAR(5) NOT NULL DEFAULT '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`client` ADD COLUMN `occupation` CHAR(30) NOT NULL DEFAULT '';" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER table master.depositaccounts MODIFY COLUMN psbknumber CHAR(10) NOT NULL DEFAULT '' after acctnumber;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.depositaccounts MODIFY COLUMN eom_balance DOUBLE(12,2) NOT NULL DEFAULT '0.00' after prevbalance;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `trnlocked` TINYINT(1) NOT NULL DEFAULT 0 AFTER `oldpccaptdate`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `trnlockedby` CHAR(3) NOT NULL DEFAULT '' AFTER `trnlocked`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `trnlockdesc` CHAR(250) NOT NULL DEFAULT '' AFTER `trnlockedby`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `trnlockedbranch` CHAR(4) NOT NULL DEFAULT '' AFTER `trnlockdesc`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `intrustfor` CHAR(5) NOT NULL DEFAULT '' AFTER `trnlockedbranch`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `insurancebeneficiaries` CHAR(120) NOT NULL DEFAULT '' AFTER `intrustfor`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `withpairedsavingsaccount` TINYINT(1) NOT NULL DEFAULT 0 AFTER `insurancebeneficiaries`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `depositaccountinterestrecipient` CHAR(9) NOT NULL DEFAULT '' AFTER `withpairedsavingsaccount`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `closeonage` TINYINT(2) NOT NULL DEFAULT 0 AFTER `depositaccountinterestrecipient`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `monthdayfundtransfer` TINYINT(2) NOT NULL DEFAULT 0 AFTER `closeonage`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `amountoffundtransfer` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `monthdayfundtransfer`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `lastfundtransfer` DATE NOT NULL DEFAULT '1900-01-01' AFTER `amountoffundtransfer`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `numberoffailedfundtransfer` TINYINT(1) NOT NULL DEFAULT 0 AFTER `lastfundtransfer`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `exemptfromwtax` TINYINT(1) NOT NULL DEFAULT 0 AFTER `numberoffailedfundtransfer`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `exemptfromwtaxby` CHAR(3) NOT NULL DEFAULT '' AFTER `exemptfromwtax`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `exemptfromwtaxrecdate` DATE NOT NULL DEFAULT '1900-01-01' AFTER `exemptfromwtaxby`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `cumulativeinterestcredited` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `exemptfromwtaxrecdate`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `cumulativewtaxdebited` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `cumulativeinterestcredited`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `cumulativedailybalance` DOUBLE(14,2) NOT NULL DEFAULT '0.00' AFTER `cumulativewtaxdebited`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `adbcurrentmonth` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `cumulativedailybalance`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositaccounts` ADD COLUMN `adbpreviousmonth` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `adbcurrentmonth`;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `master`.`deposittransactions` ADD COLUMN `correctionentry` TINYINT(1) NOT NULL DEFAULT 0 AFTER `validated`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`deposittransactions` ADD COLUMN `correctioncode` CHAR(15) NOT NULL DEFAULT '' AFTER `correctionentry`;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `withinsurance` TINYINT(1) NOT NULL DEFAULT 0 AFTER `chgdate`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `reqminadbforinsurance` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `withinsurance`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `adbincrementforinsurance` DOUBLE(12,2) NOT NULL DEFAULT '0.00' AFTER `reqminadbforinsurance`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `notallowdebittransaction` TINYINT(1) NOT NULL DEFAULT 0 AFTER `adbincrementforinsurance`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `allowdebittransactionoverride` TINYINT(1) NOT NULL DEFAULT 0 AFTER `notallowdebittransaction`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `annualcompoundingofinterest` TINYINT(1) NOT NULL DEFAULT 0 AFTER `allowdebittransactionoverride`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `requiresavingsaccounttieup` TINYINT(1) NOT NULL DEFAULT 0 AFTER `annualcompoundingofinterest`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `scheduledfundtransfer` TINYINT(1) NOT NULL DEFAULT 0 AFTER `requiresavingsaccounttieup`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `preterminationrate` DOUBLE(6,2) NOT NULL DEFAULT '0.00' AFTER `scheduledfundtransfer`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `automaticregularcreditofinterest` TINYINT(1) NOT NULL DEFAULT 0 AFTER `preterminationrate`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`depositprod` ADD COLUMN `frequencyofinterestcredit` TINYINT(1) NOT NULL DEFAULT 0 AFTER `automaticregularcreditofinterest`;" : comclient.ExecuteNonQuery()


                comclient.CommandText = "DELETE from app_bin.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "SELECT * FROM `app_bin`.`loanadj`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "INSERT app_bin.loanadj (withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, trackingnumber, approvedby, timeapproved) select withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, '' as trackingnumber, 'PCB' as approvedby, '00:00:00' as timeapproved from master.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "DROP table if exists master.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "CREATE table master.loanadj like app_bin.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "INSERT master.loanadj select * from app_bin.loanadj;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER table master.loanprod ADD COLUMN chgld1 TINYINT(1) NOT NULL DEFAULT 0 after chgcode1;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod ADD COLUMN chgld2 TINYINT(1) NOT NULL DEFAULT 0 after chgcode2;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod ADD COLUMN chgld3 TINYINT(1) NOT NULL DEFAULT 0 after chgcode3;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod ADD COLUMN chgld4 TINYINT(1) NOT NULL DEFAULT 0 after chgcode4;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod ADD COLUMN chgld5 TINYINT(1) NOT NULL DEFAULT 0 after chgcode5;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod ADD COLUMN chglndiscitem CHAR(2) NOT NULL DEFAULT '' after chgamt5;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE master.loanprod MODIFY COLUMN `prodname` VARCHAR(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod MODIFY COLUMN chgld1 TINYINT(1) NOT NULL DEFAULT 0 after chgcode1;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod MODIFY COLUMN chgld2 TINYINT(1) NOT NULL DEFAULT 0 after chgcode2;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod MODIFY COLUMN chgld3 TINYINT(1) NOT NULL DEFAULT 0 after chgcode3;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod MODIFY COLUMN chgld4 TINYINT(1) NOT NULL DEFAULT 0 after chgcode4;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod MODIFY COLUMN chgld5 TINYINT(1) NOT NULL DEFAULT 0 after chgcode5;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanprod MODIFY COLUMN chglndiscitem CHAR(2) NOT NULL DEFAULT '' after chgamt5;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE master.loanprod ADD COLUMN `withamortinsurance` TINYINT(1) NOT NULL DEFAULT 0 AFTER `waived_pnltyitem`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE master.loanprod ADD COLUMN `amortinsurancechgcode` CHAR(2) NOT NULL DEFAULT '' AFTER `withamortinsurance`;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER table master.loanwithterm add COLUMN numbpaidinst INT(7) NOT NULL DEFAULT 0 after numbinst;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanwithterm modify COLUMN pribal_bod DOUBLE(12,2) NOT NULL DEFAULT '0.00' after intterm;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanwithterm modify COLUMN forinsurance  TINYINT(1) NOT NULL DEFAULT 0 after chgamt7;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanwithterm modify COLUMN categorycode  CHAR(10) NOT NULL DEFAULT '' after forinsurance;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER table master.loanwithterm modify COLUMN insurance DOUBLE(12,2) NOT NULL DEFAULT '0.00' after categorycode;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `master`.`loanwithterm` ADD COLUMN `beneficiaries` CHAR(120) NOT NULL DEFAULT '' AFTER `trnlockremark`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`loanwithterm` ADD COLUMN `annualeffectiveintrate` DOUBLE(13,9) NOT NULL DEFAULT '0.000000000' AFTER `beneficiaries`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`loanwithterm` ADD COLUMN `withcoborrowers` TINYINT(1) NOT NULL DEFAULT 0 AFTER `annualeffectiveintrate`;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `master`.`parms` ADD COLUMN `atasourceaccount` CHAR(10) NOT NULL DEFAULT '' AFTER `denomination`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`parms` ADD COLUMN `atarecipientaccount` CHAR(10) NOT NULL DEFAULT '' AFTER `atasourceaccount`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`parms` ADD COLUMN `hochequesbatchclearing` CHAR(10) NOT NULL DEFAULT '' AFTER `atarecipientaccount`;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER table master.vouchers add COLUMN forhoexpensedistribution TINYINT(1) NOT NULL DEFAULT 0 after reference;" : comclient.ExecuteNonQuery()

                '# ------------------------new-----------------------------
                comclient.CommandText = "ALTER TABLE `master`.`g_center` MODIFY COLUMN `centerkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`g_group` MODIFY COLUMN `centerkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`loanwithterm` MODIFY COLUMN `centerkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`collectionforbatching` MODIFY COLUMN `centerkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` MODIFY COLUMN `centerkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '';" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `master`.`g_group` MODIFY COLUMN `groupkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `master`.`loanwithterm` MODIFY COLUMN `groupkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL default '';" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` MODIFY COLUMN `groupkey` CHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '';" : comclient.ExecuteNonQuery()

            End If

            If ck_updatefields.Checked = True Then ' Warning for Updating this area
                comclient.CommandText = "update `master`.`g_center`  set centerkey=concat('" & branchcode.Text & "',centerkey);" : comclient.ExecuteNonQuery()
                comclient.CommandText = "update `master`.`g_group`  set centerkey=concat('" & branchcode.Text & "',centerkey);" : comclient.ExecuteNonQuery()
                comclient.CommandText = "update `master`.`loanwithterm`  set centerkey=concat('" & branchcode.Text & "',centerkey);" : comclient.ExecuteNonQuery()
                comclient.CommandText = "update `master`.`collectionforbatching`  set centerkey=concat('" & branchcode.Text & "',centerkey);" : comclient.ExecuteNonQuery()
                comclient.CommandText = "update `forapproval`.`lwtermapplication`  set centerkey=concat('" & branchcode.Text & "',centerkey);" : comclient.ExecuteNonQuery()

                comclient.CommandText = "update `master`.`g_group`  set groupkey=concat('" & branchcode.Text & "',groupkey);" : comclient.ExecuteNonQuery()
                comclient.CommandText = "update `master`.`loanwithterm`  set groupkey=concat('" & branchcode.Text & "',groupkey);" : comclient.ExecuteNonQuery()
                comclient.CommandText = "update `forapproval`.`lwtermapplication`  set groupkey=concat('" & branchcode.Text & "',groupkey);" : comclient.ExecuteNonQuery()

                comclient.CommandText = "update `forapproval`.`lwtermapplication` set centerkey=right(centerkey,12), groupkey=right(groupkey,16);" : comclient.ExecuteNonQuery()
            End If

            If ck_updateMaster.Checked = True Then
                If ck_utf8.Checked = True Then
                    dst = New DataSet
                    msda = New MySqlDataAdapter("show tables from master", conn)
                    msda.Fill(dst, 0)
                    For cnt = 0 To dst.Tables(0).Rows.Count - 1
                        With (dst.Tables(0))
                            Dim tablename As String = .Rows(cnt)("Tables_in_master").ToString()
                            comclient.CommandText = "ALTER TABLE `master`.`" & tablename & "` DEFAULT COLLATE utf8_general_ci" : comclient.ExecuteNonQuery()
                            comclient.CommandText = "ALTER TABLE `master`.`" & tablename & "` CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci " : comclient.ExecuteNonQuery()
                        End With
                    Next
                End If
            End If
            If ck_updateMaster.Checked = True Then
                comclient.CommandText = "CREATE TABLE  IF NOT EXISTS `forapproval`.`solidary_borrowers` (  `reference` char(15) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  `custcode` char(5) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',  KEY `reference` (`reference`),  KEY `custcode` (`custcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `withamortinsurance` TINYINT(1) NOT NULL DEFAULT 0 AFTER `dateprocessed`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `amortinsurancechgcode` CHAR(2) NOT NULL DEFAULT '' AFTER `withamortinsurance`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `amortinsuranceamt` DOUBLE(9,2) NOT NULL DEFAULT '0.00' AFTER `amortinsurancechgcode`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `beneficiaries` CHAR(120) NOT NULL DEFAULT '' AFTER `amortinsuranceamt`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `annualeffectiveintrate` DOUBLE(13,9) NOT NULL DEFAULT '0.000000000' AFTER `beneficiaries`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `withcoborrowers` TINYINT(1) NOT NULL DEFAULT 0 AFTER `annualeffectiveintrate`;" : comclient.ExecuteNonQuery()
            End If
            If ck_updateMaster.Checked = True Then
                If ck_utf8.Checked = True Then
                    dst = New DataSet
                    msda = New MySqlDataAdapter("show tables from forapproval", conn)
                    msda.Fill(dst, 0)
                    For cnt = 0 To dst.Tables(0).Rows.Count - 1
                        With (dst.Tables(0))
                            Dim tablename As String = .Rows(cnt)("Tables_in_forapproval").ToString()
                            comclient.CommandText = "ALTER TABLE `forapproval`.`" & tablename & "` DEFAULT COLLATE utf8_general_ci" : comclient.ExecuteNonQuery()
                            comclient.CommandText = "ALTER TABLE `forapproval`.`" & tablename & "` CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci " : comclient.ExecuteNonQuery()
                        End With
                    Next
                    Me.Cursor = Cursors.Default
                End If
            End If
            XtraMessageBox.Show("Update Finish!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub frmdbUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        LoadOffice()
        txtfrmdate.EditValue = Format(Now, "y")
        txttodate.EditValue = Format(Now, "y")
    End Sub
    Public Sub LoadOffice()

        LoadXgridLookupSearch("SELECT branchcode as 'Code', ucase(branchname) as 'Select List' from master.branches where ho = 0 order by branchname asc", "master.branches", txtOffice, GridOffice, Me)
        XgridColAlign("Code", GridOffice, DevExpress.Utils.HorzAlignment.Center)
        GridOffice.Columns("Code").Visible = False

    End Sub
    Private Sub txtoffice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOffice.EditValueChanged
        On Error Resume Next
        Dim iCurrentRow As Integer = CInt(txtOffice.Properties.View.FocusedRowHandle.ToString)
        branchcode.Text = txtOffice.Properties.View.GetFocusedRowCellValue("Code").ToString()
        txtOffice.Text = txtOffice.Properties.View.GetFocusedRowCellValue("Select List").ToString()
    End Sub

End Class