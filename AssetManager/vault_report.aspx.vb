
Partial Class Vault_report
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
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try






            Dim rep As String
            If Session("usertype") = "CMCAdmin" Or Session("usertype") = "CMCUser" Or Session("usertype") = "CMCADMIN" Or Session("usertype") = "CMCUSER" Then
                rep = "vault_rep"
            Else
                rep = "vault_rep"
            End If
            Dim m202 As String = ""
            If CheckBox1.Checked = True Then
                m202 = "1"
            Else
                m202 = "0"
            End If

           

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('" + rep + ".aspx?fdate=" & txtDateFrom.Text & "&tdate=" & txtDateTo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox("Please select Account!")
        End Try
    End Sub

    

   

    Protected Sub btnPrint0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
