Partial Class Reporting_BatchSummary
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub getSystemUsers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct(Username),id from systemUsers where companyCode='" & Session("BrokerCode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbAccountScrol.DataSource = ds.Tables(0)
                cmbAccountScrol.DataValueField = "username"
                cmbAccountScrol.DataBind()
                txtAccountNum.Text = cmbAccountScrol.Text
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getAccessdata()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select UserName,Company,LoginDate from loginaudit where UserName='" & cmbAccountScrol.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "loginaudit")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
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
                getSystemUsers()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('UserAccountAccessReportCall.aspx?Usern=" & txtAccountNum.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If (txtAccountNum.Text = "") Then
                msgbox("Enter a valid search name")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(username) from loginAudit where username='" & txtAccountNum.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "loginAudit")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('UserAccountAccessReportCall.aspx?Usern=" & txtAccountNum.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else
                msgbox("User name not found, User might not have logged into the system")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbAccountScrol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccountScrol.SelectedIndexChanged
        txtAccountNum.Text = cmbAccountScrol.Text
    End Sub
End Class
