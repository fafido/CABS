
Partial Class Reporting_settlementreports
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)
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
 
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Response.Redirect("~/Reporting/settlementbroker.aspx")
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Response.Redirect("~/TransferSec/settledrecords.aspx")
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../Reporting/presettlement.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Response.Redirect("~/Reporting/settlementnew.aspx")
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        ASPxButton5.Visible = False
        Panel6.Visible = True

    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Panel6.Visible = False
        ASPxButton5.Visible = True
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        If ASPxMemo1.Text <> "" Then
            cmd = New SqlCommand("insert into audit_comments (auditor, report, comment, date_posted) values ('" + Session("newid") + "','SETTLEMENT REPORTS','" + ASPxMemo1.Text + "',getdate())", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            msgbox("Please enter the comment!")
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
                checkcomment()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Comment Sent")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkcomment()
        If Session("usertype") <> "AuditAdmin" Then
            ASPxButton5.Visible = False

        Else
            ASPxButton5.Visible = True

        End If
    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Response.Redirect("~/Reporting/settlementbroker.aspx?type=1")
    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Response.Redirect("~/Reporting/settlementbroker.aspx?type=2")
    End Sub

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Response.Redirect("~/Reporting/brokeraudit2.aspx?type=2")
    End Sub

    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        Response.Redirect("~/Reporting/mailinglist.aspx?type=2")
    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/IncomingTrades.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/FailedTrades.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/OrderRegister.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/PendingSettlement.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton17_Click(sender As Object, e As EventArgs) Handles ASPxButton17.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/SettledTrades.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton18_Click(sender As Object, e As EventArgs) Handles ASPxButton18.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/SettlementMaster.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton19_Click(sender As Object, e As EventArgs) Handles ASPxButton19.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/DealSettlementSheet.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub ASPxButton21_Click(sender As Object, e As EventArgs) Handles ASPxButton21.Click
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('../CDSMode/ChargesReport.aspx');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    
End Class
