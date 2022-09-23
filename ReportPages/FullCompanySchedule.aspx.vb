Imports System.Net.Mail
Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Partial Class FullCompanySchedule
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
  
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetSecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_Company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Company")
            If (ds.Tables(0).Rows.Count > 0) Then

                ddSecurities.DataSource = ds.Tables(0)
                ddSecurities.DataTextField = "Fnam"
                ddSecurities.DataValueField = "Company"
                ddSecurities.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack = True Then GetSecurities()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myReport As New ReportDocument
        Try
            ' Response.Redirect("FullCompanyScheduleCRV.aspx?date=" + dtpAsAt.SelectedDate.ToString + "&security=" + ddSecurities.SelectedItem.Text + "")

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('FullCompanyScheduleCRV.aspx?date=" + dtpAsAt.text + "&security=" + ddSecurities.SelectedValue + "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox("Error")
        End Try
    End Sub
End Class
