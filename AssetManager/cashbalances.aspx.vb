
Partial Class Reporting_cashbalances
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
    Public Sub loadcomboforassetmanagers()
        Dim dsport As New DataSet

        cmd = New SqlCommand("select * from (select 1 as rankz, 'All' as AssetMananger, 'All' as AssetManagerCode union select 2 as rankz, AssetMananger, AssetManagerCode from para_AssetManager) j order by j.rankz", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then

            cmbassetmanager.DataSource = dsport
            cmbassetmanager.TextField = "AssetMananger"
            cmbassetmanager.ValueField = "AssetManagerCode"
            cmbassetmanager.DataBind()

        End If
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
                loadcomboforassetmanagers()
                getcurrencies()
                cmbassetmanager.Value = Session("BrokerCode")
                cmbassetmanager.Enabled = False

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcurrencies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select 'All' as currencycode union select currencycode from para_currencies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbcurrency.DataSource = dsport
            cmbcurrency.TextField = "currencycode"
            cmbcurrency.ValueField = "currencycode"
            cmbcurrency.DataBind()

        End If
    End Sub


    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try


            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('createdaccountsreport.aspx?As_at=" + ASPxDateEdit1.Text + "&currency=" + cmbcurrency.SelectedItem.Text + "&assetmanager=" + cmbassetmanager.SelectedItem.Value.ToString + "&Category=CashBalance');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


End Class
