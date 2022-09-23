
Partial Class Reporting_tradesumm
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
    Public Sub getcompanies()
        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct company from para_company", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxComboBox1.DataSource = ds.Tables(0)
            ASPxComboBox1.TextField = "company"
            ASPxComboBox1.ValueField = "company"
            ASPxComboBox1.DataBind()
        Else
            ASPxComboBox1.Items.Clear()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName").ToString = "" Then
                Session.Abandon()
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.Buffer = True
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
                Response.Expires = -1000
                Response.CacheControl = "no-cache"
                Response.Redirect("~/loginsystem.aspx", True)
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getcompanies()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If (txtDateFrom.Text = "" Or txtDateTo.Text = "" Or ASPxComboBox1.Text = "") Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If


            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('BrokerAuditReport2.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&type=trade&company=" + ASPxComboBox1.SelectedItem.Text + "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)




        Catch ex As Exception
            msgbox("Invalid Report Parameters Selected")
            Exit Sub
        End Try
    End Sub
End Class
