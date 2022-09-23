Partial Class Reporting_OpenSales
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

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            If (txtDateFrom.Text = "" Or txtDateTo.Text = "" Or (rdOpenSale.Checked = False And rdPurchasesOpen.Checked = False)) Then
                msgbox("Invalid Report Parameters Selected")
                Exit Sub
            End If

            If (rdOpenSale.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('OpenSalesReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            End If
            If (rdPurchasesOpen.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('OpenPurchasesReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            End If
            
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    
End Class
