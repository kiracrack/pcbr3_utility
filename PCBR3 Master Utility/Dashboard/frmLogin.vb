Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Net
Imports DevExpress.LookAndFeel
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.XtraMessageBoxForm


Public Class frmLogin

    Sub New()
        InitSkins()
        InitializeComponent()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.OfficeSkins.Register()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(globaltheme)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me And My.Application.OpenForms.Item(i) IsNot PCBR3Main Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i
    End Sub
    Public Sub checklog()
        Try
            Call ConnectVerify()
            Dim logpass As String = txtpassword.Text
            Dim byteArraypass() As Byte
            Dim hexpass As System.Text.StringBuilder = New System.Text.StringBuilder
            byteArraypass = System.Text.ASCIIEncoding.ASCII.GetBytes(logpass)

            For i As Integer = 0 To byteArraypass.Length - 1
                hexpass.Append(byteArraypass(i).ToString("x"))
            Next

            globaluser = rchar(txtusername.Text)
            globalpass = hexpass.ToString
            conn = New MySqlConnection
            'com.CommandText = "SELECT * from tblaccounts where username='" & globaluser & "' and password='" & globalpass & "'" : rst = com.ExecuteReader()
            com.CommandText = "SELECT * from tblaccounts where username='" & globaluser & "' and password='" & globalpass & "'" : rst = com.ExecuteReader()
            While rst.Read()
                If rst.GetSchemaTable.Rows.Count <> 0 Then
                    globallogin = True
                    globaluserid = rst("accountid")
                Else
                    globallogin = False
                End If
            End While
            rst.Close()
            If globallogin = True Then
                loadglobaluser()
                loadcompsettings()
                set_login()
                filterUser()
            ElseIf globallogin = False Then
                XtraMessageBox.Show("Invalid Username or Password..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtpassword.Focus()
                txtpassword.Text = ""
                rst.Close()
                Dim t, att As Integer
                t = Val(logtry)
                If t >= 2 Then
                    XtraMessageBox.Show("3 attempt login invalid, system exit..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
                If logtry = "" Then
                    logtry = "1"
                Else
                    att = Val(t) + 1
                    logtry = att
                End If
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                            & "Module:" & "form_load" & vbCrLf _
                            & "Message:" & errMYSQL.Message & vbCrLf _
                            & "Details:" & errMYSQL.StackTrace, _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub set_login()
        com.CommandText = "insert into tbllogin set userid = '" & globaluserid & "',intime='" & GlobalDateTime() & "'"
        com.ExecuteNonQuery()
        Me.Hide()
        txtusername.Text = "Username"
        txtpassword.Text = "password"
        txtusername.Focus()
        PCBR3Main.Show()
    End Sub

    Public Sub clearlog()
        txtusername.Text = ""
        txtpassword.Text = ""
    End Sub

    Private Sub cmdlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogin.Click
        If txtusername.Text = "" Then
            XtraMessageBox.Show("Username field empty! cannot execute", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtusername.Focus()
            Exit Sub
        ElseIf txtpassword.Text = "" Then
            XtraMessageBox.Show("Password field empty! cannot execute", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpassword.Focus()
            Exit Sub
        End If
        checklog()
    End Sub
    Public Sub SetApp()
        Me.Size = New Size(complogwidth, complogheight)
        Me.panelbg.ContentImage = complogimg
    End Sub

    Private Sub frmLogin_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If System.IO.File.Exists(file_conn) = False Then
                frmConnectionSetup.ShowDialog()
                Me.Close()
            End If
            loadIcons()
            SetIcon()
            Call ConnectVerify()
            ' updateDatabaseEngine()
            LoadGlobalDate()
            loadcompsettings()
            loadLoginAppearance()
            SetApp()
            Me.Text = compname
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & Me.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    'Public Sub updateDatabaseEngine()
    '    Dim UPDATE_LOCATION As String = Application.StartupPath.ToString & "\SystemBuildVersion.txt"
    '    Dim fversion As Date
    '    Dim engineupdated As Boolean = False
    '    Dim nVersion As Date
    '    Dim updateVersion As Date
    '    If System.IO.File.Exists(UPDATE_LOCATION) = True Then
    '        Dim sr As StreamReader = File.OpenText(UPDATE_LOCATION)
    '        fversion = sr.ReadLine() : sr.Close()
    '    End If

    '    On Error Resume Next
    '    If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='pcbr3' and TABLE_NAME = 'tblsettings' AND COLUMN_NAME = 'dateversion'") = 0 Then
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblsettings` ADD COLUMN `dateversion` DATE AFTER `defprintjettype`;" : com.ExecuteNonQuery()
    '        com.CommandText = "update pcbr3.tblsettings set dateversion='" & ConvertDate(fversion) & "'" : com.ExecuteNonQuery()
    '    End If
    '    If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='pcbr3' and TABLE_NAME = 'tblreporttemplate' AND COLUMN_NAME = 'usedateasof'") = 0 Then
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblreporttemplate` ADD COLUMN `usedateasof` BOOLEAN NOT NULL DEFAULT 0 AFTER `datequery`;" : com.ExecuteNonQuery()
    '    End If

    '    com.CommandText = "select date_format(dateversion,'%d/%m/%Y') as dt from pcbr3.tblsettings" : rst = com.ExecuteReader
    '    While rst.Read
    '        fversion = CDate(rst("dt"))
    '    End While
    '    rst.Close()

    '    updateVersion = CDate("17/1/2014")
    '    If fversion < CDate(updateVersion) Then
    '        com.CommandTimeout = 600000
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblportfoliowithpar` ADD COLUMN `custcode` VARCHAR(45) CHARACTER SET utf8 COLLATE utf8_general_ci AFTER `branchgroup`, ADD COLUMN `centername` TEXT CHARACTER SET utf8 COLLATE utf8_general_ci AFTER `custcode`;" : com.ExecuteNonQuery()
    '        com.CommandText = "update tblportfoliowithpar set centername = (select centername from master.g_center inner join master.loanwithterm on g_center.centerkey = loanwithterm.centerkey where loanwithterm.refno=tblportfoliowithpar.refno), custcode = (select custcode from master.loanwithterm where loanwithterm.refno=tblportfoliowithpar.refno);" : com.ExecuteNonQuery()
    '        nVersion = CDate(updateVersion) : engineupdated = True
    '    End If

    '    updateVersion = CDate("3/7/2014")
    '    If fversion < CDate(updateVersion) Then
    '        com.CommandTimeout = 600000
    '        com.CommandText = "ALTER TABLE `master`.`branches` ADD COLUMN `category` VARCHAR(100) AFTER `toglitemcode`;" : com.ExecuteNonQuery()

    '        Dim strquery As String = ""
    '        com.CommandText = "select * from master.branches" : rst = com.ExecuteReader
    '        While rst.Read
    '            If UCase(rst("branchname").ToString) = "BANGKO TAGOLOAN - MAIN OFFICE" Then
    '                strquery = strquery + "update master.branches set category='Mindanao' where branchcode='" & rst("branchcode").ToString & "'; " & Chr(13)

    '            ElseIf UCase(rst("branchname").ToString) = "BANGKO TAGOLOAN - CDO BRANCH" Then
    '                strquery = strquery + "update master.branches set category='Mindanao' where branchcode='" & rst("branchcode").ToString & "'; " & Chr(13)

    '            ElseIf UCase(rst("branchname").ToString) = "OROQUIETA BRANCH" Then
    '                strquery = strquery + "update master.branches set category='Mindanao' where branchcode='" & rst("branchcode").ToString & "'; " & Chr(13)

    '            ElseIf UCase(rst("branchname").ToString) = "DUMAGUETE BRANCH" Then
    '                strquery = strquery + "update master.branches set category='Visayas' where branchcode='" & rst("branchcode").ToString & "'; " & Chr(13)

    '            ElseIf UCase(rst("branchname").ToString) = "TAGBILARAN BRANCH" Then
    '                strquery = strquery + "update master.branches set category='Visayas' where branchcode='" & rst("branchcode").ToString & "'; " & Chr(13)
    '            End If

    '        End While
    '        rst.Close()

    '        com.CommandText = strquery : com.ExecuteNonQuery()
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblportfoliowithpar` ADD COLUMN `areagroup` VARCHAR(100) AFTER `centername`;" : com.ExecuteNonQuery()
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblparredaccsumlist` ADD COLUMN `areagroup` VARCHAR(100) AFTER `branchgroup`;" : com.ExecuteNonQuery()
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblaosummary` ADD COLUMN `areagroup` VARCHAR(100) AFTER `datesummary`, ROW_FORMAT = DYNAMIC;" : com.ExecuteNonQuery()

    '        Dim colutf8Unicode As Boolean = True
    '        com.CommandText = "SELECT collation_name FROM information_schema.`COLUMNS` C WHERE table_schema = 'master'  AND table_name = 'branches'  AND column_name = 'branchname';" : rst = com.ExecuteReader
    '        While rst.Read
    '            If rst("collation_name").ToString = "utf8_unicode_ci" Then
    '                colutf8Unicode = True
    '            Else
    '                colutf8Unicode = False
    '            End If
    '        End While
    '        rst.Close()

    '        If colutf8Unicode = True Then
    '            com.CommandText = "ALTER TABLE `pcbr3`.`tblparredaccsumlist` MODIFY COLUMN `branch` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL;" : com.ExecuteNonQuery()
    '            com.CommandText = "ALTER TABLE `pcbr3`.`tblportfoliowithpar` MODIFY COLUMN `branch` VARCHAR(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL;" : com.ExecuteNonQuery()
    '            com.CommandText = "ALTER TABLE `pcbr3`.`tblaosummary` MODIFY COLUMN `branch` TEXT CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL, ROW_FORMAT = DYNAMIC;" : com.ExecuteNonQuery()
    '        Else
    '            com.CommandText = "ALTER TABLE `pcbr3`.`tblparredaccsumlist` MODIFY COLUMN `branch` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL;" : com.ExecuteNonQuery()
    '            com.CommandText = "ALTER TABLE `pcbr3`.`tblportfoliowithpar` MODIFY COLUMN `branch` VARCHAR(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL;" : com.ExecuteNonQuery()
    '            com.CommandText = "ALTER TABLE `pcbr3`.`tblaosummary` MODIFY COLUMN `branch` TEXT CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL, ROW_FORMAT = DYNAMIC;" : com.ExecuteNonQuery()
    '        End If

    '        com.CommandText = "update pcbr3.tblportfoliowithpar set areagroup = (select category from master.branches where ucase(branchname) = tblportfoliowithpar.branch);" : com.ExecuteNonQuery()
    '        com.CommandText = "update pcbr3.tblparredaccsumlist set areagroup = (select category from master.branches where ucase(branchname) = tblparredaccsumlist.branch);" : com.ExecuteNonQuery()
    '        com.CommandText = "update pcbr3.tblaosummary set areagroup = (select category from master.branches where ucase(branchname) = tblaosummary.branch);" : com.ExecuteNonQuery()
    '        nVersion = CDate(updateVersion) : engineupdated = True
    '    End If

    '    updateVersion = CDate("3/4/2015")
    '    If fversion < CDate(updateVersion) Then
    '        com.CommandText = "ALTER TABLE `pcbr3`.`tblreporttemplate` ADD COLUMN `usedateasof` BOOLEAN NOT NULL DEFAULT 0 AFTER `datequery`;" : com.ExecuteNonQuery()
    '        nVersion = CDate(updateVersion) : engineupdated = True
    '    End If

    '    If engineupdated = True Then
    '        com.CommandText = "update pcbr3.tblsettings set dateversion='" & ConvertDate(nVersion) & "'" : com.ExecuteNonQuery()
    '    End If
    '    If engineupdated = True Then
    '        XtraMessageBox.Show("Your system was updated to Build Version v" & nVersion.ToString("yy.MM.dd") & Environment.NewLine & "Please view update list at ""Main System Menu"" > About > What's New! ", compname, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        engineupdated = False
    '    End If


    'End Sub
End Class