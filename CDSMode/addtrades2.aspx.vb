Partial Class TransferSec_addtrades2
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
        Try
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Batch successfully captured")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()


                getcompanies()
                getbrokers()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdetails()
        Try
            Dim ds As New DataSet
            If checkbox1.checked = False Then
                cmd = New SqlCommand("select Broker_Code as [Broker],BrokerRef, ClientName, Company ,Quantity, Baseprice,OrderStatus, OrderType, Create_date as Date, TimeInForce, (select sum(amount) from cdsc.dbo.cashtrans where cds_number=testcds_router.dbo.pre_order_Live.cds_ac_no) as [Available Cash]  from testcds_router.dbo.pre_order_Live where convert(date, create_date)>='" + txtdatefrom.Text + "' and convert(date, create_date)<='" + txtdateto.Text + "' and broker_code='" + cmbbroker.SelectedItem.Text + "' and company='" + cmbcompany.SelectedItem.Text + "' and orderstatus in ('OPEN','PENDING CANCELLATION') and brokerref in (select orderref from cds_router.dbo.receiveussdorders where [status] IN ('ATS','Matched')) order by orderno desc", cn)
            Else
                cmd = New SqlCommand("select Broker_Code as [Broker],BrokerRef, ClientName, Company ,Quantity, Baseprice,OrderStatus, OrderType, Create_date as Date, TimeInForce, (select sum(amount) from cdsc.dbo.cashtrans where cds_number=testcds_router.dbo.pre_order_Live.cds_ac_no) as [Available Cash]  from testcds_router.dbo.pre_order_Live where convert(date, create_date)>='" + txtdatefrom.Text + "' and convert(date, create_date)<='" + txtdateto.Text + "' and broker_code='" + cmbbroker.SelectedItem.Text + "' and company='" + cmbcompany.SelectedItem.Text + "' and orderstatus not in ('Matched') and brokerref in (select orderref from cds_router.dbo.receiveussdorders where [status] in ('ATS','Matched','Rejected')) order by orderno desc", cn)
            End If

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If ds.Tables("para_company").Rows.Count > 0 Then
                grdApps.DataSource = ds
                grdApps.DataBind()
            Else
                grdApps.DataSource = Nothing
                grdApps.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        txtbrokerref.Text = grdApps.SelectedRow.Cells(2).Text.Trim
        txtquantity.Text = grdApps.SelectedRow.Cells(5).Text.Trim
        txtprice.Text = grdApps.SelectedRow.Cells(6).Text.Trim
        txtorderstatus.text = grdApps.SelectedRow.Cells(7).Text.Trim
        txtordertype.text = grdApps.SelectedRow.Cells(8).Text.Trim
        txtav.text = grdApps.SelectedRow.Cells(5).Text.Trim
        ' ASPxDateEdit1.Text = grdApps.SelectedRow.Cells(8).Text.Trim

        'Response.Redirect("AccountsCreationsB.aspx?acctype=" + grdApps.SelectedRow.Cells(6).Text.Trim + "&ID=" + grdApps.SelectedRow.Cells(2).Text.Trim + "&cds=" + grdApps.SelectedRow.Cells(1).Text.Trim + "")
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        getdetails()


    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click




        If txtorderstatus.text = "OPEN" Or txtorderstatus.text = "PENDING CANCELLATION" Then
            Dim brokerref As String
            If txtav.text = txtquantity.text Then
                brokerref = txtbrokerref.Text

            Else
                Dim newbrokerref As String = txtbrokerref.Text + "" + CreateRandomPassword(3).ToString
                Dim newordernumber As String = getordernumber(txtbrokerref.Text) + "" + CreateRandomPassword(3).ToString
                brokerref = newbrokerref
                splitorder(txtbrokerref.Text, txtquantity.Text, newordernumber, newbrokerref)

            End If
            cmd = New SqlCommand("testcds_router.dbo.Update_matched", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@brokerref", brokerref)
            cmd.Parameters.AddWithValue("@quantity", txtquantity.Text)
            cmd.Parameters.AddWithValue("@date_created", txtmatchdate.Text)
            cmd.Parameters.AddWithValue("@exec_price", txtprice.Text)
            cmd.Parameters.AddWithValue("@zse_exec_id", txtexchangeref.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getdetails()
            msgbox("Updated")
            ASPxPopupControl1.ShowOnPageLoad = False
        Else
            Dim brokerref As String
            If txtav.text = txtquantity.text Then
                brokerref = txtbrokerref.Text

            Else
                Dim newbrokerref As String = txtbrokerref.Text + "" + CreateRandomPassword(3).ToString
                Dim newordernumber As String = getordernumber(txtbrokerref.Text) + "" + CreateRandomPassword(3).ToString
                brokerref = newbrokerref
                splitorder(txtbrokerref.Text, txtquantity.Text, newordernumber, newbrokerref)

            End If
            If txtordertype.text = "BUY" Then
                cmd = New SqlCommand("	insert into CDSC.dbo.CashTrans ([Description],[TransType],[Amount],[DateCreated] ,[TransStatus]	 ,[CDS_Number] ,[Paid], reference) values ('Buy Order Reversal','BUY REVERSAL'," + txtquantity.text + "*" + txtprice.text + "* 1.01693*-1, getdate(),'1','" + getcds(txtbrokerref.text) + "',NULL,'" + brokerref + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
            cmd = New SqlCommand("testcds_router.dbo.Update_matched", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@brokerref", brokerref)
                cmd.Parameters.AddWithValue("@quantity", txtquantity.Text)
                cmd.Parameters.AddWithValue("@date_created", txtmatchdate.Text)
                cmd.Parameters.AddWithValue("@exec_price", txtprice.Text)
                cmd.Parameters.AddWithValue("@zse_exec_id", txtexchangeref.Text)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                getdetails()
                msgbox("Updated")
                ASPxPopupControl1.ShowOnPageLoad = False
            End If




    End Sub
    Public Function getordernumber(brokerref As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select ordernumber from testcds_router.dbo.pre_order_live where brokerref='" + brokerref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "ord")
        If ds.Tables("ord").Rows.Count > 0 Then
            Return ds.Tables("ord").Rows(0).Item("ordernumber").ToString
        End If
    End Function

    Public Function getcds(brokerref As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_ac_no from testcds_router.dbo.pre_order_live where brokerref='" + brokerref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cds")
        If ds.Tables("cds").Rows.Count > 0 Then
            Return ds.Tables("cds").Rows(0).Item("cds_ac_no").ToString
        End If
    End Function


    Public Sub getcompanies()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company from cds_router.dbo.para_company", cn)
        ' cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (Ack<>'SETTLED' or Error_details is not NULL) AND  date_posted<='" + txtdateto.Text + "' and Date_posted>='" + txtdatefrom.Text + "'", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables("para_company").Rows.Count > 0 Then
            cmbcompany.DataSource = ds
            cmbcompany.TextField = "company"
            cmbcompany.ValueField = "company"
            cmbcompany.DataBind()
        End If
    End Sub
    Public Sub getbrokers()
        Dim ds As New DataSet
        cmd = New SqlCommand("select company_code from cds_router.dbo.client_companies where company_type='BROKER'", cn)
        ' cmd = New SqlCommand("select ID , Account1 as [Buyer],(select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account1) as [Buyer Names],  Account2 as [Seller], (select isnull(surname,'')+' '+isnull(forenames,'') from accounts_clients where cds_number=tblMatchedOrders.Account2) as [Seller Names], tradeprice as Price, tradeqty as [Quantity], SettlementDate from tblmatchedorders where (Ack<>'SETTLED' or Error_details is not NULL) AND  date_posted<='" + txtdateto.Text + "' and Date_posted>='" + txtdatefrom.Text + "'", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables("para_company").Rows.Count > 0 Then
            cmbbroker.DataSource = ds
            cmbbroker.TextField = "company_code"
            cmbbroker.ValueField = "company_code"
            cmbbroker.DataBind()
        End If
    End Sub
    Public Sub splitorder(brokerref As String, newquantity As String, newordernumber As String, newbrokerref As String)
        cmd = New SqlCommand("update testcds_router.dbo.pre_order_Live set quantity=quantity-" + newquantity + "  where brokerref='" + brokerref + "' insert into testcds_ROUTER.dbo.Pre_Order_Live ([OrderType]      ,[Company]      ,[SecurityType]      ,[CDS_AC_No]      ,[Broker_Code]      ,[Client_Type]      ,[Tax]      ,[Shareholder]      ,[ClientName]      ,[TotalShareHolding]      ,[OrderStatus]      ,[Create_date]      ,[Deal_Begin_Date]      ,[Expiry_Date]      ,[Quantity]      ,[BasePrice]      ,[AvailableShares]      ,[OrderPref]      ,[OrderAttribute]      ,[Marketboard]      ,[TimeInForce]      ,[OrderQualifier]      ,[BrokerRef]      ,[ContraBrokerId]      ,[MaxPrice]      ,[MiniPrice]      ,[Flag_oldorder]      ,[OrderNumber]      ,[Currency]      ,[FOK]      ,[Affirmation]      ,[trading_platform]      ,[Symbol]      ,[MatchedPrice]      ,[MatchedDate]      ,[Custodian]      ,[Source]      ,[borrowStatus]      ,[AmountValue]      ,[Source_of_Funds]      ,[Purpose_of_Investment]) select [OrderType]      ,[Company]      ,[SecurityType]      ,[CDS_AC_No]      ,[Broker_Code]      ,[Client_Type]      ,[Tax]      ,[Shareholder]      ,[ClientName]      ,[TotalShareHolding]      ,[OrderStatus]      ,[Create_date]      ,[Deal_Begin_Date]      ,[Expiry_Date]      ,'" + newquantity + "'      ,[BasePrice]      ,[AvailableShares]      ,[OrderPref]      ,[OrderAttribute]      ,[Marketboard]      ,[TimeInForce]      ,[OrderQualifier]      ,'" + newbrokerref + "'  ,[ContraBrokerId]      ,[MaxPrice]      ,[MiniPrice]      ,[Flag_oldorder]      , '" + newordernumber + "'    ,[Currency]      ,[FOK]      ,[Affirmation]      ,[trading_platform]      ,[Symbol]      ,[MatchedPrice]      ,[MatchedDate]      ,[Custodian]      ,[Source]      ,[borrowStatus]      ,[AmountValue]      ,[Source_of_Funds]      ,[Purpose_of_Investment] from testcds_ROUTER.dbo.Pre_Order_Live where BrokerRef='" + brokerref + "'    insert into [testcds_ROUTER].[dbo].[sent_orders] values ('" + newordernumber + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Private Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex

        getdetails()

    End Sub
End Class
