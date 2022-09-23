
Partial Class Reporting_RegulatoryPort
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


            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('createdaccountsreport.aspx?Top=" + txtAccountNo.Text + "&As_at=" + ASPxDateEdit1.Text + "&Category=RegulatoryPort');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click

        cmd = New SqlCommand("declare @date nvarchar(50)='" + ASPxDateEdit1.Date.ToString + "' delete from TempValues where convert(date,[RecordDate])='" + ASPxDateEdit1.Date.ToString + "' insert  into TempValues select a.CDS_Number, c.AssetManager,  isnull(dbo.Port_Valuation(cds_number,c.assetmanager,@date),0) as PortfolioTotal,@date     from Accounts_Clients a, (select distinct clientno,Assetmanager from Client_AssetManagers ) c where a.CDS_Number=c.ClientNo", cn)
        cmd.CommandTimeout = 0
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        If dateloaded(ASPxDateEdit1.Date.ToString) = True Then
            btnPrint.Enabled = True
        Else
            btnPrint.Enabled = False
        End If

        msgbox("Portfolios Successfully generated! Proceed to print report")

    End Sub
    Protected Sub ASPxDateEdit1_DateChanged(sender As Object, e As EventArgs) Handles ASPxDateEdit1.DateChanged
        If dateloaded(ASPxDateEdit1.Date.ToString) = True Then
            btnPrint.Enabled = True
        Else
            btnPrint.Enabled = False
        End If
    End Sub
    Public Function dateloaded(dt As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from  TempValues where convert(date,[RecordDate])='" + dt + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
