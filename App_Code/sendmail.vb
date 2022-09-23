Imports Microsoft.VisualBasic
Imports System.Net.Mail

Imports CrystalDecisions.Shared
Public Class sendmail
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Function messagesend(mobile As String, message As String) As String
        Dim client As New Net.WebClient
        client.DownloadString("http://etext.co.zw/sendsms.php?user=263773360785&password=simbaj80&mobile=" + mobile.ToString + "&senderid=CACU&message=" + message + "")
        Return "Success"
    End Function
    Public Function getmobile(ByVal email As String) As String
        cmd = New SqlCommand("select mobile1 from SystemUsers where email='" + email + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Type")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("mobile1").ToString
        Else
            Return ""
        End If
    End Function
    Public Function getmobile2(ByVal email As String) As String
        cmd = New SqlCommand("select mobile from Accounts_clients where email='" + email + "'", cn)
        Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "par")
        If ds1.Tables(0).Rows.Count > 0 Then
            Return ds1.Tables(0).Rows(0).Item("mobile").ToString
        Else
            Return getmobile(email)
        End If
    End Function
    Public Sub sendmail(emailAdd As String, subject As String, emailbody As String)
        'Dim ds As New DataSet
        'cmd = New SqlCommand("select * from para_smtp order by id desc", cn)
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(ds, "Client_Companies")
        'If (ds.Tables(0).Rows.Count > 0) Then
        '    Dim email As String = ds.Tables(0).Rows(0).Item("email").ToString
        '    Dim smtp_ip As String = ds.Tables(0).Rows(0).Item("smtp_ip").ToString
        '    Dim port As String = ds.Tables(0).Rows(0).Item("port").ToString
        '    Dim allias As String = ds.Tables(0).Rows(0).Item("Alias").ToString
        '    Dim pwd As String = ds.Tables(0).Rows(0).Item("Password").ToString

        '    Dim Mail As New MailMessage
        '    Mail.Subject = subject
        '    Mail.To.Add(emailAdd)
        '    Mail.From = New MailAddress(email, allias)

        '    Mail.IsBodyHtml = True
        '    Mail.Body = emailbody
        '    Dim SMTP As New SmtpClient(smtp_ip)
        '    SMTP.EnableSsl = True
        '    SMTP.Credentials = New System.Net.NetworkCredential(email, pwd)
        '    SMTP.Port = port
        '    SMTP.Send(Mail)

        'End If
        Try

            cmd = New SqlCommand("insert into emaillog (email_address, [subject],[body],[status],[date],[sender]) values ('" + emailAdd + "','" + subject + "','" + emailbody + "','0',getdate(), 'ADMIN') insert into SMSLog (recipient, Full_Message, Message_Category, Date_Created, Processed, Username, Password, originator ) values ('+263" + getmobile2(emailAdd) + "', '" + emailbody + "','INFO',GETDATE(), '0',(select top 1 username from SMSInterface),(select top 1 [password] from SMSInterface),'NAYMAT')", cn)
            If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()


        Catch ex As Exception

        End Try

    End Sub
    Public Sub sendmail_2(emailAdd As String, subject As String, emailbody As String)
        Try
            'emailAdd = "shumbafariraishe@gmail.com,fariraishe@escrogroup.com"
            Dim Mail As New MailMessage
            Mail.Subject = subject
            Mail.To.Add("" + emailAdd + "")
            Mail.From = New MailAddress("finsec247@googlemail.com", "Finsec Alerts")
            ' Mail.From = New MailAddress("finsec247@gmail.com")
            Mail.IsBodyHtml = True
            Mail.Body = emailbody
            ' Dim SMTP As New SmtpClient("smtp.googlemail.com")
            System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslerror As System.Net.Security.SslPolicyErrors) True
            'Dim SMTP As New SmtpClient("64.233.167.16")
            Dim SMTP As New SmtpClient("64.233.167.16")
            SMTP.EnableSsl = True

            '   SMTP.Credentials = New System.Net.NetworkCredential("corpservesharepower@googlemail.com", "pavilion$")
            SMTP.Credentials = New System.Net.NetworkCredential("finsec247@gmail.com", "wZFUpdo9vOdG$")
            SMTP.Port = "587"
            ' SMTP.Port = SMTPport
            SMTP.Send(Mail)
        Catch ex As Exception
        End Try
    End Sub

    Public Function CONReports() As ConnectionInfo
        Dim connstring As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
        Dim connStringBuilder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(connstring)
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = connStringBuilder.InitialCatalog
        myConnectionInfo.UserID = connStringBuilder.UserID
        myConnectionInfo.Password = connStringBuilder.Password
        myConnectionInfo.ServerName = connStringBuilder.DataSource
        Return myConnectionInfo
    End Function
End Class
