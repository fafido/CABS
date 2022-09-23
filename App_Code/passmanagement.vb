Imports System.Linq
Imports Microsoft.VisualBasic

Public Class passmanagement
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim fromEdit As Boolean = False
    Public Function passrules() As DataSet

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from tbl_passwordpolicy", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "WRSplit")
        ' If (ds.Tables(0).Rows.Count > 0) Then
        Return ds
        ' End If
    End Function
    Public Function CheckForAlphaCharacters(ByVal StringToCheck As String) As Boolean
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next

        Return False

    End Function
    Public Function containsnumeric(s As String) As Boolean
        '  Dim s As String = "This string has numbers65"
        Const numbers = "0123456789"

        If s.IndexOfAny(numbers.ToArray) > -1 Then
            Return True

        Else
            Return False
        End If
    End Function
    Public Function containsspecial(s As String) As Boolean
        '  Dim s As String = "This string has numbers65"
        Const numbers = "~`!@#$%^&*()-+=|{}':;.,<>/?]"

        If s.IndexOfAny(numbers.ToArray) > -1 Then
            Return True

        Else
            Return False
        End If
    End Function
    Public Sub auditlog(participantcode As String, username As String, activity As String, affected As String, receiptid As String)
        Try
            Dim browser As String = HttpContext.Current.Request.Browser.Browser
            Dim ip As String = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList(0).ToString()
            Dim strHostName As String = System.Net.Dns.GetHostName()
            '   Dim clientIPAddress As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
            Dim clientIPAddress As String = HttpContext.Current.Request.UserHostAddress
            cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id],[AffectedTrans]) values((select id from systemusers where username='" & username & "' and companycode='" + participantcode + "'),getdate(),'" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + username + "','" + activity + "',0,'" + affected + "','" + browser.ToString + "','" + clientIPAddress + "','" + strHostName + "','" + participantcode + "','" + receiptid + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetIpAddress(userip As String) As String
        userip = HttpContext.Current.Request.UserHostAddress

        If HttpContext.Current.Request.UserHostAddress IsNot Nothing Then
            Dim macinfo As Int64 = New Int64()
            Dim macSrc As String = macinfo.ToString("X")

            If macSrc = "0" Then

                If userip = "127.0.0.1" Then
                    Return "localhost"
                Else
                    Return userip
                End If
            Else
                Return userip
            End If
        Else
            Return userip
        End If
    End Function
    Public Function maxallowed(ByVal cds As String, ByVal currency As String) As DataSet
        Dim ds As New DataSet
        cmd = New SqlCommand("select top 1 * from Para_Buy_Sell_Limits where AccountClass=(select category from Accounts_clients where cds_number='" + cds + "') and limitCurrency='" + currency + "' order by id desc  ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "lmts")
        'If (ds.Tables(0).Rows.Count > 0) Then
        Return ds
        ' Else
        ' Return Nothing
        ' End If
    End Function
    Public Function lasttrans(ByVal currency As String, AssetManager As String, Account As String) As Date
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT top 1 ForDate  FROM Bank_Recon_Approval where  Account='" + Account + "' and AssetManagerCode='" + AssetManager + "' and Currency='" + currency + "' and [Status]='APPROVED' order by ForDate desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "lmts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("ForDate").ToString
        Else
            Return "01 Jan 1900"
        End If
    End Function
End Class
