Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class Trading_OrdersAuditApproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim orderNum As String
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetPendingOrders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (OrderNumber) from OrdersSummary where ApprovalFlag=0 and ActivationCodeApp =1  and PurchasingBroker='" & Session("BrokerCode").ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbOrders.DataSource = ds.Tables(0)
                cmbOrders.DataValueField = "OrderNumber"
                cmbOrders.DataBind()
                GetSelectedOrderData()
            Else
                Cleardata()
                msgbox("No pending orders for approval")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedOrderData1()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary .OrderNumber , OrdersSummary .Company , OrdersSummary .CDS_Number , OrdersSummary .Order_Quantity,OrdersSummary .OrderValue  , case OrdersSummary.OrderType  when 'PUR' then 'Purchase Order' when 'SAL' then 'Sell Order' end as OrderType , names.Surname , names.Forenames , OrdersSummary .OrderDate , OrdersSummary .PurchasingBroker , OrdersSummary .CapturedBy, OrdersSummary .BasePrice , OrdersSummary .TargetDate , OrdersSummary .ExpiryDate , OrdersSummary .OrderAttribute, case names.accountstate  when 1 then 'Account active' when 0 then 'Account inactive' end as AccountState  from OrdersSummary , names where OrdersSummary .ApprovalFlag = 0 and OrdersSummary .CDS_Number = names.CDS_Number and ordersSummary.PurchasingBroker='" & Session("BrokerCode") & "' and ordersSummary.orderNumber='" & txtOrderNumber.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                cmbCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                txtSharePrice.Text = ds.Tables(0).Rows(0).Item("BasePrice").ToString
                cmbOrderAttribute.Text = ds.Tables(0).Rows(0).Item("OrderAttribute").ToString
                txtOrderShares.Text = ds.Tables(0).Rows(0).Item("Order_Quantity").ToString
                txtOrderAmount.Text = ds.Tables(0).Rows(0).Item("OrderValue").ToString
                txtOrderType.Text = ds.Tables(0).Rows(0).Item("OrderType").ToString
                txtOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                txtHolder.Text = ds.Tables(0).Rows(0).Item("Cds_Number").ToString
                txtNames.Text = ds.Tables(0).Rows(0).Item("Surname").ToString & " " & ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtBroker.Text = ds.Tables(0).Rows(0).Item("PurchasingBroker").ToString
                dateplaced.SelectedDate = ds.Tables(0).Rows(0).Item("OrderDate").ToString
                TargetDate.SelectedDate = ds.Tables(0).Rows(0).Item("TargetDate").ToString
                ExpiryDate.SelectedDate = ds.Tables(0).Rows(0).Item("ExpiryDate").ToString
                lblBuyer.Text = ds.Tables(0).Rows(0).Item("CapturedBy").ToString
                lblBuyer0.Text = ds.Tables(0).Rows(0).Item("AccountState").ToString
                If (lblBuyer0.Text = "Account active") Then
                    lblBuyer0.forecolor = Drawing.Color.Green
                    txtOrderNum.forecolor = Drawing.Color.Green
                    lblOrderNum.forecolor = Drawing.Color.Black
                    cmbCompany.forecolor = Drawing.Color.Black
                    txtSharePrice.forecolor = Drawing.Color.Black
                    cmbOrderAttribute.forecolor = Drawing.Color.Black
                    txtOrderShares.forecolor = Drawing.Color.Black
                    txtOrderAmount.forecolor = Drawing.Color.Black
                    txtOrderType.forecolor = Drawing.Color.Black
                    txtHolder.forecolor = Drawing.Color.Black
                    txtNames.forecolor = Drawing.Color.Black
                    txtBroker.forecolor = Drawing.Color.Black
                    dateplaced.forecolor = Drawing.Color.Black
                    TargetDate.forecolor = Drawing.Color.Black
                    ExpiryDate.forecolor = Drawing.Color.Black
                    lblBuyer.forecolor = Drawing.Color.Black
                    lblBuyer0.Font.Bold = True
                    lblBuyer0.Text.ToUpper()
                End If
                If (lblBuyer0.Text = "Account inactive") Then
                    lblBuyer0.Text = "Account inactive - Dormant"
                    lblOrderNum.forecolor = Drawing.Color.Red
                    cmbCompany.forecolor = Drawing.Color.Red
                    txtSharePrice.forecolor = Drawing.Color.Red
                    cmbOrderAttribute.forecolor = Drawing.Color.Red
                    txtOrderShares.forecolor = Drawing.Color.Red
                    txtOrderAmount.forecolor = Drawing.Color.Red
                    txtOrderType.forecolor = Drawing.Color.Red
                    txtOrderNum.forecolor = Drawing.Color.Red
                    txtHolder.forecolor = Drawing.Color.Red
                    txtNames.forecolor = Drawing.Color.Red
                    txtBroker.forecolor = Drawing.Color.Red
                    dateplaced.forecolor = Drawing.Color.Red
                    TargetDate.forecolor = Drawing.Color.Red
                    ExpiryDate.forecolor = Drawing.Color.Red
                    lblBuyer.forecolor = Drawing.Color.Red
                    lblBuyer0.forecolor = Drawing.Color.Red
                    lblBuyer0.forecolor = Drawing.Color.Red
                    txtOrderNum.forecolor = Drawing.Color.Red
                    lblBuyer0.Font.Bold = True
                    lblBuyer0.Text.ToUpper()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedOrderData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary .OrderNumber , OrdersSummary .Company , OrdersSummary .CDS_Number , OrdersSummary .Order_Quantity,OrdersSummary .OrderValue  , case OrdersSummary.OrderType  when 'PUR' then 'Purchase Order' when 'SAL' then 'Sell Order' end as OrderType , names.Surname , names.Forenames , OrdersSummary .OrderDate , OrdersSummary .PurchasingBroker , OrdersSummary .CapturedBy, OrdersSummary .BasePrice , OrdersSummary .TargetDate , OrdersSummary .ExpiryDate , OrdersSummary .OrderAttribute, case names.accountstate  when 1 then 'Account active' when 0 then 'Account inactive' end as AccountState  from OrdersSummary , names where OrdersSummary .ApprovalFlag = 0 and OrdersSummary .CDS_Number = names.CDS_Number and ordersSummary.PurchasingBroker='" & Session("BrokerCode") & "' and ordersSummary.orderNumber='" & cmbOrders.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                cmbCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                txtSharePrice.Text = ds.Tables(0).Rows(0).Item("BasePrice").ToString
                cmbOrderAttribute.Text = ds.Tables(0).Rows(0).Item("OrderAttribute").ToString
                txtOrderShares.Text = ds.Tables(0).Rows(0).Item("Order_Quantity").ToString
                txtOrderAmount.Text = ds.Tables(0).Rows(0).Item("OrderValue").ToString
                txtOrderType.Text = ds.Tables(0).Rows(0).Item("OrderType").ToString
                txtOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                txtHolder.Text = ds.Tables(0).Rows(0).Item("Cds_Number").ToString
                txtNames.Text = ds.Tables(0).Rows(0).Item("Surname").ToString & " " & ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtBroker.Text = ds.Tables(0).Rows(0).Item("PurchasingBroker").ToString
                dateplaced.SelectedDate = ds.Tables(0).Rows(0).Item("OrderDate").ToString
                TargetDate.SelectedDate = ds.Tables(0).Rows(0).Item("TargetDate").ToString
                ExpiryDate.SelectedDate = ds.Tables(0).Rows(0).Item("ExpiryDate").ToString
                lblBuyer.Text = ds.Tables(0).Rows(0).Item("CapturedBy").ToString
                lblBuyer0.Text = ds.Tables(0).Rows(0).Item("AccountState").ToString
                If (lblBuyer0.Text = "Account active") Then
                    lblBuyer0.forecolor = Drawing.Color.Green
                    txtOrderNum.forecolor = Drawing.Color.Green
                    lblOrderNum.forecolor = Drawing.Color.Black
                    cmbCompany.forecolor = Drawing.Color.Black
                    txtSharePrice.forecolor = Drawing.Color.Black
                    cmbOrderAttribute.forecolor = Drawing.Color.Black
                    txtOrderShares.forecolor = Drawing.Color.Black
                    txtOrderAmount.forecolor = Drawing.Color.Black
                    txtOrderType.forecolor = Drawing.Color.Black
                    txtHolder.forecolor = Drawing.Color.Black
                    txtNames.forecolor = Drawing.Color.Black
                    txtBroker.forecolor = Drawing.Color.Black
                    dateplaced.forecolor = Drawing.Color.Black
                    TargetDate.forecolor = Drawing.Color.Black
                    ExpiryDate.forecolor = Drawing.Color.Black
                    lblBuyer.forecolor = Drawing.Color.Black
                    lblBuyer0.Font.Bold = True
                    lblBuyer0.Text.ToUpper()
                End If
                If (lblBuyer0.Text = "Account inactive") Then
                    lblBuyer0.Text = "Account inactive - Dormant"
                    lblOrderNum.forecolor = Drawing.Color.Red
                    cmbCompany.forecolor = Drawing.Color.Red
                    txtSharePrice.forecolor = Drawing.Color.Red
                    cmbOrderAttribute.forecolor = Drawing.Color.Red
                    txtOrderShares.forecolor = Drawing.Color.Red
                    txtOrderAmount.forecolor = Drawing.Color.Red
                    txtOrderType.forecolor = Drawing.Color.Red
                    txtOrderNum.forecolor = Drawing.Color.Red
                    txtHolder.forecolor = Drawing.Color.Red
                    txtNames.forecolor = Drawing.Color.Red
                    txtBroker.forecolor = Drawing.Color.Red
                    dateplaced.forecolor = Drawing.Color.Red
                    TargetDate.forecolor = Drawing.Color.Red
                    ExpiryDate.forecolor = Drawing.Color.Red
                    lblBuyer.forecolor = Drawing.Color.Red
                    lblBuyer0.forecolor = Drawing.Color.Red
                    lblBuyer0.forecolor = Drawing.Color.Red
                    txtOrderNum.forecolor = Drawing.Color.Red
                    lblBuyer0.Font.Bold = True
                    lblBuyer0.Text.ToUpper()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
            End If
            checkPer()
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Orders Approval Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetPendingOrders()

        End If
    End Sub
    Public Sub checkPer()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from BrokersPermissions where username='" & Session("Username").ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BrokersPermissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (ds.Tables(0).Rows(0).Item("AuthorizationPerm").ToString = 1) Then
                Else
                    msgbox("Page access denied")
                    Response.Redirect("~\loginsystem.aspx")
                End If
            Else
                msgbox("Page access denied")
                Response.Redirect("~\loginsystem.aspx")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getParaCharge()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 * from para_fees order by DateUpdate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_fees")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub getNewOrderValue()
        Try
            If (txtOrderShares.Text <> "") Then
                txtOrderAmount.Text = CDbl((txtOrderShares.Text) * (txtSharePrice.Text))
            End If

            If (txtOrderAmount.Text <> "") Then
                txtOrderShares.Text = CInt((txtOrderAmount.Text) / (txtSharePrice.Text))
            End If
            If (txtOrderAmount.Text = "" And txtOrderShares.Text = "") Then
                txtOrderAmount.Text = "0"
                txtOrderShares.Text = "0"
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getSharePrice()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 price from para_Prices where counter='" & cmbCompany.Text & "' order by PriceDate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_prices")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtSharePrice.Text = ds.Tables(0).Rows(0).Item("price").ToString
            Else
                txtSharePrice.Text = "0"
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub saveOrderMain()
        Try
            Dim ds As New DataSet
            If (txtHolder.Text = "") Then
                msgbox("Invalid Shareholder Number")
                Exit Sub
            End If

            If (Session("BrokerCode").ToString = "") Then
                Response.Redirect("~/LoginSystem.aspx")
            End If

            cmd = New SqlCommand("Select top 1 OrderRef from OrdersSummary order by OrderRef desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                orderNum = (Session("BrokerCode") & (ds.Tables(0).Rows(0).Item("OrderRef").ToString + 1))
            Else
                orderNum = ("USER1")
            End If
            'cmd = New SqlCommand("insert into ordersSummary(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "','" & cmbOrderPref.Text & "',0) ", cn)

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            'cmd = New SqlCommand("insert into ordersSummaryApproval(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "','" & cmbOrderPref.Text & "',0) ", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            msgbox("Error on Main Saving")
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub SavePurchaseOrder()
        Try
            If (txtHolder.Text = "") Then
                msgbox("Invalid Shareholder Number")
                Exit Sub
            End If
            'MsgBox("insert into PurchaseOrders (OrderNumber,CDS_Number,Order_Quantity,Basic_Fee,Stamp_Duty,PurchaseRegistration,MinimumBrokerage,TransferFees,WithholdingTax,ValueBefore,TotalCharges,OrderValue,Order_By) values('" & orderNum & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtBasicCharges.Text & "," & txtStamp.Text & "," & txtPReg.Text & "," & txtMinBroke.Text & "," & txtTfees.Text & "," & txtSecLevel.Text & "," & txtTotCharges.Text & "," & txtTotalCost.Text & ",'USER')")
            If (Session("BrokerCode").ToString = "") Then
                Response.Redirect("~\loginsystem.aspx")
            End If
            'cmd = New SqlCommand("insert into PurchaseOrders (OrderNumber,CDS_Number,Company,Order_Quantity,Basic_Fee,Stamp_Duty,PurchaseRegistration,MinimumBrokerage,TransferFees,TotalCharges,OrderValue,Order_By,Postdate,Targetdate,ExpiryDate,OrderAttribute) values('" & txtOrderNum.Text & "','" & txtshareholder.Text & "','" & cmbCompany.Text & "'," & txtOrderShares.Text & "," & txtBasicCharges.Text & "," & txtStamp.Text & "," & txtPReg.Text & "," & txtMinBroke.Text & "," & txtTfees.Text & "," & txtTotCharges.Text & "," & txtTotalCost.Text & ",'" & Session("UserName") & "','" & Now.Date & "','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Order Saved")
            txtOrderAmount.Text = "0"
            txtOrderShares.Text = "0"
            'txtshareholder.Text = ""
            txtHolder.Text = ""
            txtNames.Text = ""
            TargetDate.Clear()
            ExpiryDate.Clear()
            OrderNumber()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub OrderNumber()
        Try
            Dim ds As New DataSet
            Dim orderref As String
            cmd = New SqlCommand("select top 1 orderRef from OrdersSummary order by orderRef desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                orderref = Session("BrokerCode") & (ds.Tables(0).Rows(0).Item("OrderRef").ToString + 1)
                txtOrderNum.Text = orderref
            Else
                orderref = "1USER"
                txtOrderNum.Text = orderref
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnOrderSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrderSearch.Click
        Try
            GetSelectedOrderData1()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Cleardata()
        Try
            lblOrderNum.Text = ""
            cmbCompany.Text = ""
            txtSharePrice.Text = ""
            cmbOrderAttribute.Text = ""
            txtOrderShares.Text = ""
            txtOrderAmount.Text = ""
            txtOrderType.Text = ""
            txtOrderNum.Text = ""
            txtHolder.Text = ""
            txtNames.Text = ""
            txtBroker.Text = ""
            dateplaced.SelectedDate = ""
            TargetDate.SelectedDate = ""
            ExpiryDate.SelectedDate = ""
            lblBuyer.Text = ""
            lblBuyer0.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbOrders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrders.SelectedIndexChanged
        Try
            GetSelectedOrderData()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdApprove0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdApprove0.CheckedChanged
        Try
            If (rdApprove0.Checked = True) Then
                Label51.Visible = True
                txtRejectionReason.Visible = True
                txtRejectionReason.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdApprove_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdApprove.CheckedChanged
        Try

            If (rdApprove.Checked = True) Then
                Label51.Visible = False
                txtRejectionReason.Visible = False
                txtRejectionReason.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Save.Click
        Try
            If (rdApprove.Checked = True) Then
                Dim email As String
                Dim dsi As New DataSet
                Dim Mail As New MailMessage
                Dim SMTP As New SmtpClient("smtp.googlemail.com")

                If (lblBuyer0.Text = "Account active") Then
                    cmd = New SqlCommand("Update ordersSummary set ApprovalFlag=1 where PurchasingBroker='" & Session("BrokerCode") & "' and OrderNumber='" & lblOrderNum.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("Update ordersSummaryApproval set ApprovalFlag=1, ApprovedOn='" & Now.Date & "', ApprovedBy='" & Session("Username") & "' where PurchasingBroker='" & Session("BrokerCode") & "' and OrderNumber='" & lblOrderNum.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("select * from names where cds_number='" & txtHolder.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "names")
                    email = dsi.Tables(0).Rows(0).Item("email").ToString

                    Mail.Subject = "No Reply. Order Placed"
                    Mail.To.Add("" + email + "")
                    Mail.From = New MailAddress("cdspresentation@gmail.com")

                    Mail.Body = " Your order has been successfully placed for " & txtOrderShares.Text & " . Thank you for using CDS. Enjoy our services "

                    'Dim SMTP As New SmtpClient("smtp.googlemail.com")

                    SMTP.EnableSsl = True
                    SMTP.Credentials = New System.Net.NetworkCredential("cdspresentation@gmail.com", "cdscompany1234")
                    SMTP.Port = "587"
                    SMTP.Send(Mail)

                End If


                If (lblBuyer0.Text = "Account inactive - Dormant") Then
                    cmd = New SqlCommand("Update ordersSummary set ApprovalFlag=1 where PurchasingBroker='" & Session("BrokerCode") & "' and OrderNumber='" & lblOrderNum.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("Update ordersSummaryApproval set ApprovalFlag=1, ApprovedOn='" & Now.Date & "', ApprovedBy='" & Session("Username") & "' where PurchasingBroker='" & Session("BrokerCode") & "' and OrderNumber='" & lblOrderNum.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("select * from names where cds_number='" & txtHolder.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dsi, "names")
                    email = dsi.Tables(0).Rows(0).Item("email").ToString

                    Mail.Subject = "No Reply. Order Placed"
                    Mail.To.Add("" + email + "")
                    Mail.From = New MailAddress("cdspresentation@gmail.com")
                    Mail.Body = " Your order has been successfully placed for " & txtOrderShares.Text & " . Thank you for using CDS. Enjoy our services "

                    'Dim SMTP As New SmtpClient("smtp.googlemail.com")

                    SMTP.EnableSsl = True
                    SMTP.Credentials = New System.Net.NetworkCredential("cdspresentation@gmail.com", "cdscompany1234")
                    SMTP.Port = "587"
                    SMTP.Send(Mail)

                End If

                'Dim email As String


            End If

            If (rdApprove0.Checked = True) Then
                If (lblBuyer0.Text = "Account active") Then
                    cmd = New SqlCommand("Update ordersSummary set ApprovalFlag=2 where PurchasingBroker='" & Session("BrokerCode") & "' and OrderNumber='" & lblOrderNum.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("Update ordersSummaryApproval set ApprovalFlag=1, RejectionReason='" & txtRejectionReason.Text & "', ApprovedOn='" & Now.Date & "', ApprovedBy='" & Session("Username") & "' where PurchasingBroker='" & Session("BrokerCode") & "' and OrderNumber='" & lblOrderNum.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                End If

            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved an order approval','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Record saved")
            GetPendingOrders()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
