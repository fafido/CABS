Imports System.Data
Imports System.Data.SqlClient
Partial Class Orders
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim query As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then



            Getorders()

            '   Getorders()

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub
    Public Sub authorise(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim idd As String = CType(sender, LinkButton).CommandArgument
        'cmd = New SqlCommand("insert into [CDS_ROUTER].[dbo].[trans] (company,CDS_Number,Date_Created,Trans_Time,shares,Update_Type,Created_By,Batch_Ref ) (select company,cds_number,date_created,trans_time,shares,update_type,created_by,batch_ref from [CDS_ROUTER].[dbo].[oddlots] where trans_id='" & idd & "') ", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd.ExecuteNonQuery()
        'cn.Close()
        getdetails(idd)
        updateauthorisation(idd)
        updatemarketdata()
        updateparacompany()
        insertprices()
        msgbox("Authorisation Successful")
        Getorders()


    End Sub










    Public Sub Getorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand(" select	id as Id,client_Account as [Client Account], client_Name as [Client Name] ,abs(total_units) as [Total Units],TransType,abs(Value) as Value,Reference from UnitAccounts", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Function updateauthorisation(ByVal id As String)

        cmd = New SqlCommand("update Pending_Prices set status='1' where id='" & id & "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Function updatemarketdata()

        cmd = New SqlCommand("update cds_router.dbo.ZSE_market_data set best_ask='" + txtaskprice.Text + "', best_bid='" + txtbidprice.Text + "', current_price='" + txtpricetoday.Text + "' where ticker='" + txtcompany.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Function insertprices()

        cmd = New SqlCommand("insert into testcds_router.dbo.prices(company_name, price_close, price_open, price_high, price_low, price_best,price_volume, price_date, price_time, havesent) values ('" + txtcompany.Text + "','" + txtpricetoday.Text + "','" + txtpricetoday.Text + "','" + txtpricetoday.Text + "','" + txtpricetoday.Text + "','" + txtpricetoday.Text + "','" + txtpricetoday.Text + "','" + txtdate.Text + "', '" + txtdate.Text + "','1')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Function updateparacompany()

        cmd = New SqlCommand("update [testcds_ROUTER].[dbo].[para_company] set InitialPrice='" + txtpricetoday.Text + "' where company='" + txtcompany.Text + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function


    Public Sub linkDiscard(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim idd As String = CType(sender, LinkButton).CommandArgument
        cmd = New SqlCommand("Delete from [CDS_ROUTER].[dbo].[oddlots] where trans_id='" & idd & "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        msgbox("Delete Successful")
        Getorders()

    End Sub
    Public Sub getdetails(ByVal id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Pending_Prices where id= '" & id & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Pending_Prices")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtaskprice.Text = ds.Tables(0).Rows(0).Item("ask_price").ToString
            txtbidprice.Text = ds.Tables(0).Rows(0).Item("bid_price").ToString
            txtpricetoday.Text = ds.Tables(0).Rows(0).Item("price_today").ToString
            txtcompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
            txtdate.text = ds.Tables(0).Rows(0).Item("date").ToString

        End If


    End Sub



    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)
        inserttoTrans()
        insertintocashTrans()
        getOpenTrades()
        cleartable()
        msgbox("Authorisation Successful")
        Getorders()
    End Sub
    Public Sub cleartable()
        cmd = New SqlCommand("truncate table unitAccounts  ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub inserttoTrans()
        cmd = New SqlCommand("insert into [CDS_ROUTER].[dbo].[trans](Company,CDS_Number,Update_Type,Shares,Date_Created,Trans_Time, Created_By,source) (select  (select company  FROM [testcds_ROUTER].[dbo].[OMUT_Funds] where Abbrev=u.Fund) as fund,(select top 1 cds_number from  Client_InvestorPin_Relation where UTNumber=u.client_Account) as fund ,'Shares' , CASE TRANSTYPE  WHEN  'Purchase'   THEN convert(numeric (18,10) ,replace(total_units,',','')) ELSE  convert(numeric (18,10) ,replace(total_units,',','')) * -1 END AS totalunits ,getdate(),getdate(),'Escrow' ,'unittrusts' from unitAccounts u  where u.client_Account in (select top 1 UTNumber from  Client_InvestorPin_Relation  where UTNumber=u.client_Account))", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub insertintocashTrans()
        cmd = New SqlCommand("insert into [CDSC].[dbo].[CashTrans] (counter , CDS_Number ,Amount,DateCreated,TransType,description) (select  (select company  FROM [testcds_ROUTER].[dbo].[OMUT_Funds] where Abbrev=u.Fund) as fund,(select top 1 cds_number from  Client_InvestorPin_Relation where UTNumber=u.client_Account) as cdsnumber ,Value,getdate() as datecreated,TransType,transtype from unitAccounts u  where u.client_Account in (select top 1 UTNumber from  Client_InvestorPin_Relation  where UTNumber=u.client_Account))", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub


    Public Function settledeal(ByVal orderef As String)
        cmd = New SqlCommand("update [testcds_ROUTER].[dbo].[Pre_Order_Live] set OrderStatus='Matched' where BrokerRef='" + orderef + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return 0
    End Function
    Public Sub getOpenTrades()
        Dim orderef As String
        Dim cmd As SqlCommand = New SqlCommand("select	id as Id,client_Account as [Client Account], client_Name as [Client Name] ,abs(total_units) as [Total Units],TransType,abs(Value) as Value,Reference from UnitAccounts   ", cn)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet("ds")
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)

        If dt.Rows.Count > 0 Then

            For Each dr As DataRow In dt.Rows
                orderef = dr("Reference").ToString()
                settledeal(orderef)

            Next


        End If
    End Sub
    Protected Sub grdRules_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdRules.PageIndexChanging
        grdRules.PageIndex = e.NewPageIndex
        Getorders()
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs)
        cleartable()
        Getorders()
        msgbox("Rejection Successfull")
    End Sub
End Class
