Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.Threading

Module Connection
    Public conn As New MySqlConnection 'for MySQLDatabase Connection
    Public msda As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dst As New DataSet 'miniature of your table - cache table to client
    Public com As New MySqlCommand
    Public rst As MySqlDataReader
    Public cb As MySqlCommandBuilder

    ' LOCALHOST
    Public sqlservername As String
    Public sqlipaddress As String
    Public sqlPort As String
    Public sqlusername As String
    Public sqlpassword As String
    Public sqldatabase As String
    Public sqljoinbase As String
    Public file_conn As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".conn"
    Public file_conn_dir As String = Application.StartupPath.ToString & "\Connection"

    Public connclient As New MySqlConnection 'for MySQLDatabase Connection
    Public msdaclient As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstclient As New DataSet 'miniature of your table - cache table to client
    Public comclient As New MySqlCommand
    Public rstclient As MySqlDataReader
    Public ConnectedServer As Boolean = False

    Public clientserver As String
    Public clientuser As String
    Public clientport As String
    Public clientpass As String
    Public clientdatabase As String

    Public Sub ConnectVerify()
        Dim strSetup As String = ""
        Dim sr As StreamReader = File.OpenText(file_conn)
        Dim br As String = sr.ReadLine() : sr.Close()
        strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
        For Each word In strSetup.Split(New Char() {","c})
            If cnt = 0 Then
                sqlservername = word
            ElseIf cnt = 1 Then
                sqlipaddress = word
            ElseIf cnt = 2 Then
                sqlPort = word
            ElseIf cnt = 3 Then
                sqlusername = word
            ElseIf cnt = 4 Then
                sqlpassword = word
            End If
            cnt = cnt + 1
        Next

        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = "server=" & sqlipaddress & "; Port=" & sqlPort & "; user id=" & sqlusername & "; password=" & sqlpassword & "; database=pcbr3; Connection Timeout=6000000"
        conn.Open()
        com.Connection = conn
        com.CommandTimeout = 6000000
    End Sub

    Public Sub ChangeConnection(ByVal connection_file As String)
        Dim strSetup As String = ""
        Dim sr As StreamReader = File.OpenText(connection_file)
        Dim br As String = sr.ReadLine() : sr.Close()
        strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
        For Each word In strSetup.Split(New Char() {","c})
            If cnt = 0 Then
                sqlservername = word
            ElseIf cnt = 1 Then
                sqlipaddress = word
            ElseIf cnt = 2 Then
                sqlPort = word
            ElseIf cnt = 3 Then
                sqlusername = word
            ElseIf cnt = 4 Then
                sqlpassword = word
            End If
            cnt = cnt + 1
        Next
        If conn.State = ConnectionState.Open Then
            conn.Close()
            com.Connection.Close()
        End If
        Try
            conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = "server=" & sqlipaddress & "; Port=" & sqlPort & "; user id=" & sqlusername & "; password=" & sqlpassword & "; database=pcbr3; Connection Timeout=6000000"
            conn.Open()
            com.Connection = conn
            com.CommandTimeout = 6000000
            MessageBox.Show("Connection Successfully Connected", "PCBR3", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
           
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function OpenClientServer() As Boolean
        Try
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=pcbr3"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenClientServer = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        End Try
    End Function
End Module
