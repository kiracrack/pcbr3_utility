Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient

Public Class frmdbUpdater2
    Dim dbname As String = ""
    Dim yearcount As Integer = 0
    Private beginyear As Date = Format(Now, "y")
    Private endyear As Date = Format(Now, "y")

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        On Error Resume Next
        If connclient.State = ConnectionState.Closed Then
            XtraMessageBox.Show("Client connection currently close! please update client server", compname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If XtraMessageBox.Show("Are you sure you want to update PCBR3 Database?", compname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            beginyear = txtfrmdate.Text
            endyear = txttodate.Text
            yearcount = DateDiff(DateInterval.Month, beginyear, endyear)

            For I = 0 To yearcount
                Me.Cursor = Cursors.WaitCursor
                dbname = "db" & beginyear.AddMonths(I).ToString("yyyyMM")

              
                comclient.CommandText = "delete from app_bin.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "insert app_bin.loanadj (withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, trackingnumber, approvedby, timeapproved) select withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, '' as trackingnumber, 'PCB' as approvedby, '00:00:00' as timeapproved from " & dbname & ".loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "drop table if exists " & dbname & ".loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "create table " & dbname & ".loanadj like app_bin.loanadj;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "insert " & dbname & ".loanadj select * from app_bin.loanadj;" : comclient.ExecuteNonQuery()

                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`deposittransactions` ADD COLUMN `correctionentry` TINYINT(1) NOT NULL DEFAULT 0 AFTER `validated`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`deposittransactions` ADD COLUMN `correctioncode` CHAR(15) NOT NULL DEFAULT '' AFTER `correctionentry`;" : comclient.ExecuteNonQuery()
                comclient.CommandText = "ALTER TABLE `" & dbname & "`.`vouchers` ADD COLUMN `forhoexpensedistribution` TINYINT(1) NOT NULL DEFAULT 0 AFTER `reference`;" : comclient.ExecuteNonQuery()

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
                'comclient.CommandText = "show tables from " & dbname
                'rstclient = comclient.ExecuteReader
                'While rstclient.Read
                '    Dim tablename As String = rstclient("Tables_in_" & dbname)
                '    comclient.CommandText = "ALTER TABLE `" & dbname & "`.`" & tablename & "` DEFAULT COLLATE utf8_unicode_ci" : comclient.ExecuteNonQuery()
                '    comclient.CommandText = "ALTER TABLE `" & dbname & "`.`" & tablename & "` CONVERT TO CHARACTER SET utf8 COLLATE utf8_unicode_ci " : comclient.ExecuteNonQuery()
                'End While
                'rstclient.Close()
            Next

            comclient.CommandText = "alter table master.depositprod add withinsurance boolean not null default false, add reqminadbforinsurance double(12,2) not null default 0.00, add adbincrementforinsurance double(12,2) not null default 0.00, add notallowdebittransaction boolean not null default false, add allowdebittransactionoverride boolean not null default false;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositprod add annualcompoundingofinterest boolean not null default false, add requiresavingsaccounttieup boolean not null default false, add scheduledfundtransfer boolean not null default false, add automaticmonthlycreditofinterest boolean not null default false, add preterminationrate double(6,2) not null default 0.00;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositprod drop automaticmonthlycreditofinterest, add automaticregularcreditofinterest boolean not null default false, add frequencyofinterestcredit tinyint(1) not null default 0 after automaticregularcreditofinterest;" : comclient.ExecuteNonQuery()

            comclient.CommandText = "alter table master.depositaccounts add intrustfor char(5) not null default '', add insurancebeneficiaries char(120) not null default '', add withpairedsavingsaccount boolean not null default false, add depositaccountinterestrecipient char(9) not null default '', add index (intrustfor), add index (signatory1), add index (signatory2), add index (signatory3), add index (signatory4);" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add closeonage tinyint(2) not null default 0, add monthdayfundtransfer tinyint(2) not null default 0;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add exemptfromwtax boolean not null default false, add exemptfromwtaxby char(3) not null default '', add exemptfromwtaxrecdate date not null default '1900-01-01';" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add cumulativeinterestcredited double(12,2) not null default 0.00, add cumulativewtaxdebited double(12,2) not null default 0.00;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add amountoffundtransfer double(12,2) not null default 0.00 after monthdayfundtransfer;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add numberoffailedfundtransfer tinyint(1) not null default 0 after amountoffundtransfer;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add lastfundtransfer date not null default '1900-01-01' after amountoffundtransfer;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.depositaccounts add cumulativedailybalance double(14,2) not null default 0.00, add adbcurrentmonth double(12,2) not null default 0.00, add adbpreviousmonth double(12,2) not null default 0.00;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "create table master.depositaccountsforpickup (acctnumber char(9) not null default '', accountofficer char(3) not null default '', index (acctnumber), index (accountofficer));" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.deposittransactions add correctionentry boolean not null default false, add correctioncode char(15) not null default '';" : comclient.ExecuteNonQuery()


            comclient.CommandText = "create table master.hoexpensetobranches (reference char(17) not null default '' primary key, voucher_reference char(10) not null default '', ho_matchgroup char(10) not null default '', ho_matchitem char(10) not null default '', branch_matchgroup char(10) not null default '', branch_matchitem char(10) not null default '', purpose char(200) not null default '', recby char(3) not null default '', branchcode char(4) not null default '', recdate date not null default '1900-01-01');" : comclient.ExecuteNonQuery()
            comclient.CommandText = "create table master.hoexpensebranchshare (reference char(17) not null default '', branchcode char(4) not null default '', amount double(12,2) not null default 0.00, index (reference), index (branchcode));" : comclient.ExecuteNonQuery()

            comclient.CommandText = "drop table if exists forapproval.solidary_borrowers;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "create table forapproval.solidary_borrowers (reference char(15) not null default '', custcode char(5) not null default '', index (reference), index (custcode));" : comclient.ExecuteNonQuery()
            comclient.CommandText = "drop table if exists master.solidary_borrowers;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "create table master.solidary_borrowers (reference char(6) not null default '', custcode char(5) not null default '', index (reference), index (custcode));" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table forapproval.lwtermapplication add withcoborrowers boolean not null default false;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "alter table master.loanwithterm add withcoborrowers boolean not null default false;" : comclient.ExecuteNonQuery()

            comclient.CommandText = "alter table master.vouchers add forhoexpensedistribution boolean not null default false after reference;" : comclient.ExecuteNonQuery()

            comclient.CommandText = "DELETE from app_bin.loanadj;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "SELECT * FROM `app_bin`.`loanadj`;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "INSERT app_bin.loanadj (withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, trackingnumber, approvedby, timeapproved) select withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, '' as trackingnumber, 'PCB' as approvedby, '00:00:00' as timeapproved from master.loanadj;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "DROP table if exists master.loanadj;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "CREATE table master.loanadj like app_bin.loanadj;" : comclient.ExecuteNonQuery()
            comclient.CommandText = "INSERT master.loanadj select * from app_bin.loanadj;" : comclient.ExecuteNonQuery()

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
            XtraMessageBox.Show("Update Finish!", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
#Region "UPDATE - BY KIRACRACK"

    Public Sub UpdateMaster_kiracrack()
        '####################### KIRACRACK GENERATED QUERIES ################################
        '# MASTER DATABASE
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

    End Sub

    Public Sub UpdateForApproval()
        comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `withamortinsurance` TINYINT(1) NOT NULL DEFAULT 0 AFTER `dateprocessed`;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `amortinsurancechgcode` CHAR(2) NOT NULL DEFAULT '' AFTER `withamortinsurance`;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `amortinsuranceamt` DOUBLE(9,2) NOT NULL DEFAULT '0.00' AFTER `amortinsurancechgcode`;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `beneficiaries` CHAR(120) NOT NULL DEFAULT '' AFTER `amortinsuranceamt`;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `annualeffectiveintrate` DOUBLE(13,9) NOT NULL DEFAULT '0.000000000' AFTER `beneficiaries`;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "ALTER TABLE `forapproval`.`lwtermapplication` ADD COLUMN `withcoborrowers` TINYINT(1) NOT NULL DEFAULT 0 AFTER `annualeffectiveintrate`;" : comclient.ExecuteNonQuery()
    End Sub

#End Region

#Region "PCBR3 UTILITY - ALLAN DUMALAY"

    Public Sub UpdateMaster_allandumalay()
        comclient.CommandText = "alter table master.depositprod add withinsurance boolean not null default false, add reqminadbforinsurance double(12,2) not null default 0.00, add adbincrementforinsurance double(12,2) not null default 0.00, add notallowdebittransaction boolean not null default false, add allowdebittransactionoverride boolean not null default false;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositprod add annualcompoundingofinterest boolean not null default false, add requiresavingsaccounttieup boolean not null default false, add scheduledfundtransfer boolean not null default false, add automaticmonthlycreditofinterest boolean not null default false, add preterminationrate double(6,2) not null default 0.00;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositprod drop automaticmonthlycreditofinterest, add automaticregularcreditofinterest boolean not null default false, add frequencyofinterestcredit tinyint(1) not null default 0 after automaticregularcreditofinterest;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "alter table master.depositaccounts add intrustfor char(5) not null default '', add insurancebeneficiaries char(120) not null default '', add withpairedsavingsaccount boolean not null default false, add depositaccountinterestrecipient char(9) not null default '', add index (intrustfor), add index (signatory1), add index (signatory2), add index (signatory3), add index (signatory4);" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add closeonage tinyint(2) not null default 0, add monthdayfundtransfer tinyint(2) not null default 0;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add exemptfromwtax boolean not null default false, add exemptfromwtaxby char(3) not null default '', add exemptfromwtaxrecdate date not null default '1900-01-01';" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add cumulativeinterestcredited double(12,2) not null default 0.00, add cumulativewtaxdebited double(12,2) not null default 0.00;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add amountoffundtransfer double(12,2) not null default 0.00 after monthdayfundtransfer;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add numberoffailedfundtransfer tinyint(1) not null default 0 after amountoffundtransfer;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add lastfundtransfer date not null default '1900-01-01' after amountoffundtransfer;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.depositaccounts add cumulativedailybalance double(14,2) not null default 0.00, add adbcurrentmonth double(12,2) not null default 0.00, add adbpreviousmonth double(12,2) not null default 0.00;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "create table master.depositaccountsforpickup (acctnumber char(9) not null default '', accountofficer char(3) not null default '', index (acctnumber), index (accountofficer));" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.deposittransactions add correctionentry boolean not null default false, add correctioncode char(15) not null default '';" : comclient.ExecuteNonQuery()


        comclient.CommandText = "create table master.hoexpensetobranches (reference char(17) not null default '' primary key, voucher_reference char(10) not null default '', ho_matchgroup char(10) not null default '', ho_matchitem char(10) not null default '', branch_matchgroup char(10) not null default '', branch_matchitem char(10) not null default '', purpose char(200) not null default '', recby char(3) not null default '', branchcode char(4) not null default '', recdate date not null default '1900-01-01');" : comclient.ExecuteNonQuery()
        comclient.CommandText = "create table master.hoexpensebranchshare (reference char(17) not null default '', branchcode char(4) not null default '', amount double(12,2) not null default 0.00, index (reference), index (branchcode));" : comclient.ExecuteNonQuery()

        comclient.CommandText = "drop table if exists forapproval.solidary_borrowers;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "create table forapproval.solidary_borrowers (reference char(15) not null default '', custcode char(5) not null default '', index (reference), index (custcode));" : comclient.ExecuteNonQuery()
        comclient.CommandText = "drop table if exists master.solidary_borrowers;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "create table master.solidary_borrowers (reference char(6) not null default '', custcode char(5) not null default '', index (reference), index (custcode));" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table forapproval.lwtermapplication add withcoborrowers boolean not null default false;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "alter table master.loanwithterm add withcoborrowers boolean not null default false;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "alter table master.vouchers add forhoexpensedistribution boolean not null default false after reference;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40103 SET TIME_ZONE='+00:00' */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "DROP TABLE IF EXISTS `app_bin`.`loanadj`;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40101 SET @saved_cs_client     = @@character_set_client */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40101 SET character_set_client = utf8 */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "CREATE TABLE `app_bin`.`loanadj` (  `withterm` tinyint(1) NOT NULL DEFAULT '0',  `trnindex` char(1) NOT NULL DEFAULT '',  `custcode` char(5) NOT NULL DEFAULT '',  `adjdate` date NOT NULL DEFAULT '1998-08-08',  `refno` char(6) NOT NULL DEFAULT '',  `principal` double(10,2) NOT NULL DEFAULT '0.00',  `prin_add` tinyint(1) NOT NULL DEFAULT '1',  `interest` double(10,2) NOT NULL DEFAULT '0.00',  `int_add` tinyint(1) NOT NULL DEFAULT '1',  `penalty` double(10,2) NOT NULL DEFAULT '0.00',  `pen_add` tinyint(1) NOT NULL DEFAULT '1',  `chgadj1` double(9,2) NOT NULL DEFAULT '0.00',  `chg1_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj2` double(9,2) NOT NULL DEFAULT '0.00',  `chg2_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj3` double(9,2) NOT NULL DEFAULT '0.00',  `chg3_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj4` double(9,2) NOT NULL DEFAULT '0.00',  `chg4_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj5` double(9,2) NOT NULL DEFAULT '0.00',  `chg5_add` tinyint(1) NOT NULL DEFAULT '0',  `chgadj6` double(9,2) NOT NULL DEFAULT '0.00',  `chg6_add` tinyint(1) NOT NULL DEFAULT '0',  `recby` char(3) NOT NULL DEFAULT '',  `timerec` char(8) NOT NULL DEFAULT '',  `brief` char(30) NOT NULL DEFAULT '',  `remark` char(250) NOT NULL DEFAULT '',  `trackingnumber` char(17) NOT NULL DEFAULT '',  `approvedby` char(3) NOT NULL DEFAULT '',  `timeapproved` char(8) NOT NULL DEFAULT '',  KEY `loanadj_withterm` (`withterm`),  KEY `loanadj_refno` (`refno`),  KEY `loanadj_custcode` (`custcode`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40101 SET character_set_client = @saved_cs_client */;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "LOCK TABLES `app_bin`.`loanadj` WRITE;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40000 ALTER TABLE `app_bin`.`loanadj` DISABLE KEYS */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "INSERT INTO `app_bin`.`loanadj` VALUES (1,'5','A2186','2013-02-07','A01086',3000.00,0,3000.00,1,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,'B04','16:32:44','To record adjustment on partia','To record adjustment on partial payment charged to interest instead of principal.','20130207163244B04','A21','17:09:36');" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40000 ALTER TABLE `app_bin`.`loanadj` ENABLE KEYS */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "UNLOCK TABLES;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;" : comclient.ExecuteNonQuery()

        comclient.CommandText = "delete from app_bin.loanadj;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "insert app_bin.loanadj (withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, trackingnumber, approvedby, timeapproved) select withterm, trnindex, custcode, adjdate, refno, principal, prin_add, interest, int_add, penalty, pen_add, recby, timerec, brief, remark, '' as trackingnumber, 'PCB' as approvedby, '00:00:00' as timeapproved from " & dbname & ".loanadj;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "drop table if exists master.loanadj;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "create table master.loanadj like app_bin.loanadj;" : comclient.ExecuteNonQuery()
        comclient.CommandText = "insert master.loanadj select * from app_bin.loanadj;" : comclient.ExecuteNonQuery()
    End Sub

#End Region

    Private Sub frmdbUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetIcon()
        txtfrmdate.EditValue = Format(Now, "y")
        txttodate.EditValue = Format(Now, "y")
    End Sub
End Class