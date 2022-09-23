
Partial Class Reporting_mailinglist
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


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcompanies()
        Try
            cmd = New SqlCommand("select upper(email) as company from para_mailing_list", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxListBox1.DataSource = ds
                ASPxListBox1.ValueField = "company"
                ASPxListBox1.TextField = "company"
                ASPxListBox1.DataBind()

            Else
                ASPxListBox1.DataSource = Nothing
            End If
            ASPxListBox1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If ASPxTextBox1.Text = "" Then

            Else
                cmd = New SqlCommand("insert into para_mailing_list values ('" + ASPxTextBox1.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                ASPxTextBox1.Text = ""
                getcompanies()
            End If







        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
