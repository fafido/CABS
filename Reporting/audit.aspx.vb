
Partial Class Reporting_audit
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
    Public Sub bindduser()
        If Session("usertype") = "CMCAdmin" Or Session("usertype") = "CMCUser" Or Session("usertype") = "CMCADMIN" Or Session("usertype") = "CMCUSER" Then
            Try
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct username from systemusers", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_company")
                If (ds.Tables(0).Rows.Count > 0) Then
                    DropDownList1.DataSource = ds.Tables(0)
                    DropDownList1.DataTextField = "username"
                    DropDownList1.DataBind()
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        Else
            Try
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct username from systemusers WHERE companycode='" + Session("BrokerCode") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_company")
                If (ds.Tables(0).Rows.Count > 0) Then
                    DropDownList1.DataSource = ds.Tables(0)
                    DropDownList1.DataTextField = "username"
                    DropDownList1.DataBind()
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
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
                bindduser()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If (txtDateFrom.Text = "" Or txtDateTo.Text = "") Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If


            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('../Reporting/useractivity.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&type=useraudit&user=" & DropDownList1.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)




        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
