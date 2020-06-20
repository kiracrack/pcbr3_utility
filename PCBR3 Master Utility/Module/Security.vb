
Module security

    Public Function keyloger(ByVal str As String)
        com.CommandText = "insert into tblsystemlogs set DESCRIPTION='" & str & "', UPDATEBY='" & globalfullname & "', DATELOGS=CURRENT_TIMESTAMP"
        com.ExecuteNonQuery()
        Return 0
    End Function

    Public Function encryptpass(ByRef usr As String)
        Dim pass As String = usr
        Dim byteArraypass() As Byte
        Dim hexpass As System.Text.StringBuilder = New System.Text.StringBuilder
        byteArraypass = System.Text.ASCIIEncoding.ASCII.GetBytes(pass)

        For i As Integer = 0 To byteArraypass.Length - 1
            hexpass.Append(byteArraypass(i).ToString("x"))
        Next
        'encriptpass = hexpass.ToString
        Return hexpass.ToString
    End Function

    '0 - Super User
    '1 - fullcontrol
    '2 - approver
    '3 - Purchaser
    '4 - read only 

    Public Sub filterUser()
 
    End Sub
    Public Sub userexit()
        globallogin = False
        globalfullname = ""
        globaldesignation = ""
        globalpermission = 0
        globaluserid = ""
        globalfullname = ""
        globalpass = ""
        globaluser = ""
        conn.Close()
    End Sub
End Module
