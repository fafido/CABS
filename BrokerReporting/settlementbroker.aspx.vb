
Partial Class Reporting_settlementbroker
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcurrencies()
        Try
            cmd = New SqlCommand("select distinct currencycode as curr from para_currencyrates ", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbcurrency.DataSource = ds
                cmbcurrency.ValueField = "curr"
                cmbcurrency.TextField = "curr"
                cmbcurrency.DataBind()

            Else
                cmbcurrency.DataSource = Nothing
            End If
            cmbcurrency.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getcompanies()
        Try
            cmd = New SqlCommand("select distinct upper(company) as company from para_company", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbcompany.DataSource = ds
                cmbcompany.ValueField = "company"
                cmbcompany.TextField = "company"
                cmbcompany.DataBind()
            Else
                cmbcompany.DataSource = Nothing
            End If
            cmbcompany.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getcompanies()
                getcurrencies()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
          Try

            If (txtDateFrom.Text = "" Or txtDateTo.Text = "") Then
                msgbox("Please select Date from and Date to!")
                Exit Sub
            End If
            Dim curr As String

            Try
                curr = cmbcurrency.SelectedItem.Text
            Catch ex As Exception
                curr = ""
            End Try
            If Request.QueryString("type") = "1" Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('BrokerAuditReport2.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&type=settlementDelivery&currency=" + curr + "&company=" + cmbcompany.SelectedItem.Text + "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            ElseIf Request.QueryString("type") = "2" Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('BrokerAuditReport2.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&type=settlementCDAsumm&currency=" + curr + "&company=" + cmbcompany.SelectedItem.Text + "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('BrokerAuditReport2.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&type=settlementbroker&currency=" + curr + "&company=" + cmbcompany.SelectedItem.Text + "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If

         




        Catch ex As Exception
            msgbox("Please select Company")
        End Try
    End Sub
End Class
