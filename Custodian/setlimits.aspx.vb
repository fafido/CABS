Partial Class setlimits
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
    Public Sub getclasses()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Class_name  from para_brokerclasses", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbaccountclass.DataSource = dsport
            cmbaccountclass.TextField = "Class_name"
            cmbaccountclass.DataBind()

        End If
    End Sub
    Public Sub getcurrencies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_currencies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbcurrency.DataSource = dsport
            cmbcurrency.TextField = "currencycode"
            cmbcurrency.ValueField = "currencycode"
            cmbcurrency.DataBind()
        End If
    End Sub


    Protected Sub getlist()
        Dim dsport As New DataSet
        cmd = New SqlCommand("  select AccountClass, Limit, LimitCurrency, Reaction as [System Reaction], SetBy, Date_set as [Date Set] from [Para_Buy_Sell_Limits]", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdPortfolios.DataSource = dsport.Tables(0)
            grdPortfolios.DataBind()
            '    GetCashBal()
        Else
            grdPortfolios.DataSource = Nothing
            grdPortfolios.DataBind()

        End If
    End Sub


    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        If txtlimit.Text <> "" And cmbaccountclass.SelectedIndex <> -1 And cmbcurrency.SelectedIndex <> -1 Then
            cmd = New SqlCommand("insert into para_buy_sell_limits (limit, reaction, Custodian, date_set, setby, AccountClass, LimitCurrency )   values ('" + txtlimit.Text + "','" + rdlreaction.SelectedItem.Text + "','CABS',GETDATE(), '" + Session("Username") + "','" + cmbaccountclass.SelectedItem.Text + "','" + cmbcurrency.SelectedItem.Text + "')", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Else
            msgbox("Please enter all the required fields!")
            Exit Sub

        End If
        Session("finish") = "done"
        Response.Redirect(Request.RawUrl)
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("finish") = "done" Then
            Session("finish") = ""
            msgbox("Successful!")
        End If
        If Not IsPostBack = True Then
            getlist()
            getcurrencies()
            getclasses()

        End If
    End Sub

    'Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click

    '    cmd = New SqlCommand("delete from para_buy_sell_limits where custodian='" + Session("Brokercode") + "'", cn)
    '    cn.Open()
    '    cmd.ExecuteNonQuery()
    '    cn.Close()

    '    Session("finish") = "done"
    '    Response.Redirect(Request.RawUrl)
    'End Sub
End Class
