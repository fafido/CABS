
Partial Class Trading_OrderAffirmation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As New DataSet

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            accType.SelectedIndex = 0
            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number], [TradePrice] as [Price], [TradeQty] as Quanity, [Account1] as [Buying Investor], ac.Surname, ac.Forenames as [First Name],  [Broker1] as [Buying Broker], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount]  ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date]   FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account1 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "'  and BuyAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("You have successfully rejected the transaction!")
        End If
    End Sub
    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex

        If accType.SelectedIndex = 0 Then

            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number], [TradePrice] as [Price], [TradeQty] as Quanity, [Account1] as [Buying Investor], ac.Surname, ac.Forenames as [First Name], [Broker1] as [Buying Broker], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount] ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date]  FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account1 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and BuyAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()

        ElseIf accType.SelectedIndex = 1 Then

            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number], [TradePrice] as [Price], [TradeQty] as Quanity, [Account2] as [Selling Investor],ac.Surname, ac.Forenames as [First Name], [Broker2] as [Selling Broker], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount] ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date] FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account2 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and SellAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
        End If

    End Sub
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged

        '        If accType.SelectedIndex = 0 Then
        '            
        '            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, [TradePrice] as [Price], [TradeQty] as Quanity, [Account1] as [Buying Investor], [Account2] as [Selling Investor], [Broker1] as [Buying Broker], ac.Custodian,BankSent,[Broker2] as [Selling Broker] FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account1 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and BuyCustodian='" + Session("BrokerCode").ToString() + "' and BuyAffirm is null order by ac.id desc", cn)
        '
        '            adp = New SqlDataAdapter(cmd)
        '            adp.Fill(ds, "APP")
        '            If ds.Tables(0).Rows.Count > 0 Then
        '                grdApps.DataSource = ds.Tables(0)
        '            Else
        '                grdApps.DataSource = Nothing
        '            End If
        '            grdApps.DataBind()
        '
        '        ElseIf accType.SelectedIndex = 1 Then
        '
        '            '            msgbox("Who is selected")
        '            cmd = New SqlCommand("SELECT  tblMatchedOrders.ID, [TimeStamp] as [Time], [TradePrice] as [Price], [TradeQty] as Quanity, [Account1] as [Buying Investor], [Account2] as [Selling Investor],[Broker1] as [Buying Broker], ac.Custodian,BankSent,[Broker2] as [Selling Broker] FROM [CDS].[dbo].[tblMatchedOrders]inner join Accounts_Clients ac on tblMatchedOrders.Account2 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and SellCustodian ='" + Session("BrokerCode").ToString() + "' and SellAffirm is null order by ac.id desc", cn)
        '
        '            adp = New SqlDataAdapter(cmd)
        '            adp.Fill(ds, "APP")
        '            If ds.Tables(0).Rows.Count > 0 Then
        '                grdApps.DataSource = ds.Tables(0)
        '            Else
        '                grdApps.DataSource = Nothing
        '            End If
        '            grdApps.DataBind()
        '        End If
    End Sub
    Protected Sub accType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles accType.SelectedIndexChanged

        If accType.SelectedIndex = 0 Then
            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number],  [TradePrice] as [Price], [TradeQty] as Quanity, [Account1] as [Buying Investor], [Broker1] as [Buying Broker], ac.Surname, ac.Forenames as [First Name], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount] ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date] FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account1 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and BuyCustodian='" + Session("BrokerCode").ToString() + "' and BuyAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()

        ElseIf accType.SelectedIndex = 1 Then

            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number], [TradePrice] as [Price], [TradeQty] as Quanity, [Account2] as [Selling Investor], ac.Surname, ac.Forenames as [First Name], [Broker2] as [Selling Broker], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount] ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date] FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account2 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and SellCustodian ='" + Session("BrokerCode").ToString() + "' and SellAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
        End If

    End Sub

    Protected Sub linkAuthorize_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        Dim id = CType(sender, LinkButton).CommandArgument
        If accType.SelectedIndex = 0 Then
            cmd = New SqlCommand("Update tblMatchedOrders set BuyAffirm=1 where ID='" & id & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number], [TradePrice] as [Price], [TradeQty] as Quanity, [Account2] as [Selling Investor], ac.Surname, ac.Forenames as [First Name], [Broker2] as [Selling Broker], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount] ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date]  FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account2 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and BuyCustodian ='" + Session("BrokerCode").ToString() + "' and BuyAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()

            msgbox("You have successfully confirmed the transaction")
        ElseIf accType.SelectedIndex = 1 Then
            cmd = New SqlCommand("Update tblMatchedOrders set SellAffirm=1 where ID='" & id & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("SELECT tblMatchedOrders.ID, (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) as [Deal Number], [TradePrice] as [Price], [TradeQty] as Quanity, [Account2] as [Selling Investor], ac.Surname, ac.Forenames as [First Name], [Broker2] as [Selling Broker], [Company], ROUND((TradePrice * TradeQty), 2) as [Deal Amount] ,CONVERT(VARCHAR(11),[Date_posted], 100) as [Trade Date], CONVERT(VARCHAR(11),[SettlementDate], 100) as [Settlement Date] FROM [CDS].[dbo].[tblMatchedOrders] inner join Accounts_Clients ac on tblMatchedOrders.Account2 = ac.CDS_Number where tblMatchedOrders.BankSent='0' and ac.Custodian='" + Session("BrokerCode").ToString() + "' and SellCustodian ='" + Session("BrokerCode").ToString() + "' and SellAffirm is null order by (select top 1 deal from tbl_units_move where id=tblMatchedOrders.CommonRef) asc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
            msgbox("You have successfully confirmed the transaction")
        End If
    End Sub
    Protected Sub linkDiscard_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id = CType(sender, LinkButton).CommandArgument
        TextBox2.Text = id.ToString
        Panel9.Visible = True

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '        msgbox("Reject Selected")
        If TextBox1.Text = "" Then
            msgbox("Please enter reason for rejection!")
            Exit Sub
        End If

        '    Dim id = CType(sender, LinkButton).CommandArgument
        If accType.SelectedIndex = 0 Then
            cmd = New SqlCommand("Update tblMatchedOrders set BuyAffirm=0 where ID='" & TextBox2.Text & "' insert into affirmation_rejections (deal_id, reason_for_rejection, date_rejected) values ('" + TextBox2.Text + "','" + TextBox1.Text + "',getdate())", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            ' msgbox("You have successfully rejected the transaction")
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

        ElseIf accType.SelectedIndex = 1 Then
            cmd = New SqlCommand("Update tblMatchedOrders set SellAffirm=0 where ID='" & TextBox1.Text & "' insert into affirmation_rejections (deal_id, reason_for_rejection, date_rejected) values ('" + TextBox2.Text + "','" + TextBox1.Text + "',getdate())", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

            'msgbox("")
        End If
    End Sub
End Class
