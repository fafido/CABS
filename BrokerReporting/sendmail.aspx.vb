Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Runtime.Serialization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class sendmail
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim dsi As New DataSet
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
    Dim com As SqlCommand
    Dim da As SqlDataAdapter
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim a As CrystalDecisions.CrystalReports.Engine.FieldObject
    Dim b As CrystalDecisions.CrystalReports.Engine.TextObject
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim today = DateTime.Now
        Dim fromdate As String = today.AddDays(-1)
        Dim todate As String = today.AddDays(1)




        If Request.QueryString("filesready") = "true" Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select email from para_mailing_list", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Mail.Subject = "Daily Escrow CDS Reports"
                    Mail.To.Add(ds.Tables(0).Rows(i).Item("email"))
                    Mail.From = New MailAddress("cdspresentation@gmail.com")
                    Mail.Body = "Please find attached Daily Settlement and Delivery Reports."
                    Mail.Attachments.Add(New Attachment("G:\TODEPLOY\CDSSYSTEM\CDSCONSOL\MailAttachments\" + today.ToString("MMMM dd, yyyy") + "_Settlement.pdf"))
                    Mail.Attachments.Add(New Attachment("G:\TODEPLOY\CDSSYSTEM\CDSCONSOL\MailAttachments\" + today.ToString("MMMM dd, yyyy") + "_Delivery.pdf"))

                    'Dim SMTP As New SmtpClient("smtp.googlemail.com")
                    SMTP.EnableSsl = True
                    SMTP.Credentials = New System.Net.NetworkCredential("cdspresentation@gmail.com", "cdscompany1234")
                    SMTP.Port = "587"
                    SMTP.Send(Mail)
                Next
            End If
        Else
            frame.Attributes.Add("src", "http://localhost/CDS_MAKIBA/Reporting/BrokerAuditReport2.aspx?Datefrom=" + fromdate + "&Dateto=" + todate + "&type=settlementnew&currency=Ksh&company=GVT&mail=true")
        End If
     


       
    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class
