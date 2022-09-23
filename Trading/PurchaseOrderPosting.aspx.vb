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
Partial Class Trading_PurchaseOrderPosting
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Shared random As New Random()
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Purchase Order Creation Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            OrderNumber()
            getCompany()
            If (cmbOrderPref.SelectedItem.Text = "M") Then
                txtSharePrice.Text = 0.0
            Else
                getSharePrice()
            End If
            getParaCharge()
            getOrderAttribute()
            lblBuyer.Text = Session("username").ToString
        End If
    End Sub
    Public Sub getOrderAttribute()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (OrderType),OrderCode from OrderTypeAttribute", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrderTypeAttribute")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbOrderAttribute.DataSource = ds.Tables(0)
                cmbOrderAttribute.DataValueField = "OrderType"
                cmbOrderAttribute.DataBind()

                lblOrderType.Text = ds.Tables(0).Rows(0).Item("OrderCode").ToString
            Else
                cmbOrderAttribute.DataSource = Nothing
                cmbOrderAttribute.DataBind()
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
                txtBasicCharges.Text = ds.Tables(0).Rows(0).Item("BasicFee").ToString
                txtStamp.Text = ds.Tables(0).Rows(0).Item("StampDuty").ToString
                txtPReg.Text = ds.Tables(0).Rows(0).Item("PurchaseRegistration").ToString
                txtMinBroke.Text = ds.Tables(0).Rows(0).Item("MinimumBrokerage").ToString
                txtTfees.Text = ds.Tables(0).Rows(0).Item("TransferFees").ToString
                txtSecLevel.Text = ds.Tables(0).Rows(0).Item("SecLevy").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getHolder()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Surname,Forenames,CDS_Number from names where CDS_Number= '" & txtshareholder.Text & "' and Locked=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtHolder.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString
                txtNames.Text = ((ds.Tables(0).Rows(0).Item("Forenames").ToString) & " " & (ds.Tables(0).Rows(0).Item("Surname").ToString))
            Else
                MsgBox("Holder not found")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            getHolder()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getCharges()
        Try
            Dim ds As New DataSet
            Dim InitialCost, StampDutyValue, PregValue, MBrokerageValue, TfeesValue, SecLevyValue As Integer
            InitialCost = CInt((txtOrderShares.Text) * CInt(txtSharePrice.Text))
            StampDutyValue = CInt(InitialCost * (CInt(txtStamp.Text) / 100))
            PregValue = CInt(InitialCost * CInt(txtPReg.Text / 100))
            MBrokerageValue = CInt(InitialCost * CInt(txtMinBroke.Text / 100))
            TfeesValue = CInt(txtTfees.Text * CInt(txtTfees.Text / 100))
            SecLevyValue = CInt(txtSecLevel.Text * CInt(txtSecLevel.Text / 100))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub calculateTotalCost()
        Try
            Dim TotalCost, Stamp, Sec, Tfees As Double

            Stamp = CDbl(((txtStamp.Text) / 100) * (txtOrderAmount.Text))
            Tfees = CDbl(((txtTfees.Text) / 100) * (txtOrderAmount.Text))
            Sec = CDbl(((txtSecLevel.Text) / 100) * (txtOrderAmount.Text))
            txtTotCharges.Text = CDbl(Stamp + Tfees + Sec + CDbl(txtMinBroke.Text) + CDbl(txtBasicCharges.Text) + CDbl(txtPReg.Text))
            TotalCost = CDbl((txtTotCharges.Text) + CDbl(txtOrderAmount.Text))
            txtTotalCost.Text = TotalCost
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            If (cmbOrderPref.SelectedItem.Text = "M") Then
                txtSharePrice.Text = 0.0
            Else
                getSharePrice()
            End If
            getNewOrderValue()
            calculateTotalCost()
        Catch ex As Exception
            MsgBox(ex.Message)
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
                txtSharePrice.Text = "0.02"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub txtOrderShares_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderShares.TextChanged
        Try
            If (IsNumeric(txtOrderShares.Text)) Then
                Dim orderPrice As Double
                orderPrice = ((txtOrderShares.Text) * (txtSharePrice.Text))
                txtOrderAmount.Text = CDbl(orderPrice)
                calculateTotalCost()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub txtOrderAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderAmount.TextChanged
        Try
            Dim shares As Integer
            shares = CInt(txtOrderAmount.Text / txtSharePrice.Text)
            txtOrderShares.Text = CInt(shares)
            calculateTotalCost()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub saveOrderMain()
        Try
            Dim Code As String = ""

            Code = (Convert.ToString(Random.Next(10, 999999)))

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
            'cmd = New SqlCommand("insert into ordersSummary(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag,Baseprice) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "','" & cmbOrderPref.Text & "',0," & txtSharePrice.Text & ") ", cn)
            cmd = New SqlCommand("insert into ordersSummary(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag,Baseprice,ActivationCode,ActivationCodeApp) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Now.Date & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & txtTargetDate.Text & "','" & txtExpiryDate.Text & "','" & lblOrderType.Text & "','" & cmbOrderPref.Text & "',0," & txtSharePrice.Text & ",'" & Code & "','0') ", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            'cmd = New SqlCommand("insert into ordersSummaryApproval(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag,BasePrice) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "','" & cmbOrderPref.Text & "',0," & txtSharePrice.Text & ") ", cn)
            cmd = New SqlCommand("insert into ordersSummaryApproval(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag,BasePrice) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & txtTargetDate.Text & "','" & txtExpiryDate.Text & "','" & lblOrderType.Text & "','" & cmbOrderPref.Text & "',0," & txtSharePrice.Text & ") ", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim email As String
            Dim dsi As New DataSet
            Dim Mail As New MailMessage
            Dim SMTP As New SmtpClient("smtp.googlemail.com")

            cmd = New SqlCommand("select * from names where cds_number='" & txtHolder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "names")
            email = dsi.Tables(0).Rows(0).Item("email").ToString

            Mail.Subject = "No Reply. Order Placed"
            Mail.To.Add("" + email + "")
            Mail.From = New MailAddress("cdspresentation@gmail.com")
            Mail.Body = " Your order has been successfully placed for " & txtOrderNumber.Text & ".Your activation code " & Code & ". Thank you for using CDS. Enjoy our services "

            'Dim SMTP As New SmtpClient("smtp.googlemail.com")

            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("cdspresentation@gmail.com", "cdscompany1234")
            SMTP.Port = "587"
            SMTP.Send(Mail)


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
            cmd = New SqlCommand("insert into PurchaseOrders (OrderNumber,CDS_Number,Company,Order_Quantity,Basic_Fee,Stamp_Duty,PurchaseRegistration,MinimumBrokerage,TransferFees,TotalCharges,OrderValue,Order_By,Postdate,Targetdate,ExpiryDate,OrderAttribute) values('" & txtOrderNum.Text & "','" & txtshareholder.Text & "','" & cmbCompany.Text & "'," & txtOrderShares.Text & "," & txtBasicCharges.Text & "," & txtStamp.Text & "," & txtPReg.Text & "," & txtMinBroke.Text & "," & txtTfees.Text & "," & txtTotCharges.Text & "," & txtTotalCost.Text & ",'" & Session("UserName") & "','" & Now.Date & "','" & txtTargetDate.Text & "','" & txtExpiryDate.Text & "','" & lblOrderType.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Order Saved")
            txtOrderAmount.Text = "0"
            txtOrderShares.Text = "0"
            txtshareholder.Text = ""
            txtHolder.Text = ""
            txtNames.Text = ""
            txtTargetDate.Clear()
            txtExpiryDate.Clear()
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
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SaveNewMain()
        Try
            If (Session("username").ToString <> "") Then
            Else
                Response.Redirect("~\loginsystem.aspx")
            End If

            Dim OrderNumberID As String = ""
            Dim company As String = ""
            Dim cdsnumber As String = ""
            Dim shares As Integer = 0
            Dim OrderValue As Double = 0.0
            Dim OrderType As String = ""
            Dim orderDate As DateTime = Date.Now
            Dim Broker As String = ""
            Dim CapturedBy As String = ""
            Dim Status As String = "C"
            Dim BasePrice As Double = 0.0
            Dim TargetDate As Date = Now.Date
            Dim ExpiryDate As Date = Now.Date
            Dim timeforce As String = "" 'order attribute
            Dim orderpref As String = ""
            Dim Marketboard As String = ""
            Dim OrderQualifier As String = ""
            OrderNumberID = txtOrderNum.Text

            If (cmbCompany.Items.Count > 0) Then
                company = cmbCompany.SelectedItem.Text
            End If
            If (txtShareholder.Text <> "") Then
                cdsnumber = txtShareholder.Text.ToUpper
            Else
                msgbox("Select a valid shareholder number")
                txtShareholder.Focus()
                Exit Sub
            End If
            If (txtOrderShares.Text <> "" Or IsNumeric(txtOrderShares.Text)) Then
                shares = CInt(txtOrderShares.Text)
            Else
                msgbox("Enter a valid number of quantity")
                txtOrderShares.Focus()
                Exit Sub
            End If
            OrderValue = 0
            OrderType = "BUY"
            orderDate = Now.Date
            Broker = Session("BrokerCode").ToString.ToUpper
            CapturedBy = Session("Username").ToString.ToUpper
            Status = "C"
            BasePrice = CDbl(txtSharePrice.Text)
            If (Len(txtTargetDate.ToString) > 0) Then
                TargetDate = txtTargetDate.SelectedDate.Date
            Else
                TargetDate = Now.Date
            End If
            If (Len(txtExpiryDate.ToString) > 0) Then
                ExpiryDate = txtExpiryDate.SelectedDate.Date
            Else
                ExpiryDate = Now.Date
            End If
            If (cmbOrderAttribute.SelectedItem.Text <> "") Then
                timeforce = cmbOrderAttribute.SelectedItem.Text.ToUpper
            Else
                timeforce = ""
            End If
            orderpref = cmbOrderPref.SelectedItem.Text.ToUpper
            Marketboard = cmbMarketboard.SelectedItem.Text.ToUpper
            OrderQualifier = cmbOrderQualifier.SelectedValue.ToString.ToUpper
            Dim Code As String = ""
            Code = (Convert.ToString(random.Next(10, 999999)))

            cmd = New SqlCommand("insert into OrdersSummary (OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,BasePrice,TargetDate,ExpiryDate,OrderAttribute,OrderPreference,ApprovalFlag,ActivationCode,ActivationCodeApp,MarketBoard,OrderQualifier) values ('" & OrderNumberID & "','" & company & "','" & cdsnumber & "'," & shares & ", " & OrderValue & ",'" & OrderType & "','" & Date.Now & "','" & Broker & "','" & CapturedBy & "','" & Status & "'," & BasePrice & ",'" & TargetDate & "','" & ExpiryDate & "','" & timeforce & "', '" & orderpref & "',0,'" & Code & "','0','" & Marketboard & "','" & OrderQualifier & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Order saved")


            'OrderNumber()
            txtOrderNumber.Text = ""
            txtShareholder.Text = ""
            txtStamp.Text = ""
            txtTfees.Text = ""
            txtSecLevel.Text = ""
            'txtCharges.Text = ""
            'txtBrokerage.Text = ""
            txtExpiryDate.Clear()
            txtTargetDate.Clear()
            'txtCharges.Text = ""
            'txtBrokerage.Text = ""
            'txtTotGross.Text = ""
            txtOrderShares.Text = ""
            txtOrderAmount.Text = CDbl(txtSharePrice.Text)
            TextBox13.Text = ""
            txtMinBroke.Text = ""
            txtBasicCharges.Text = ""
            'txtTotpay.Text = ""
            OrderNumber()
            getParaCharge()
            getOrderAttribute()
            lblBuyer.Text = Session("Username").ToString
            If (cmbOrderPref.SelectedItem.Text = "M") Then
                txtSharePrice.Text = 0.0
            Else
                getSharePrice()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try
            If (txtHolder.Text = "") Then
                MsgBox("Invalid Shareholder Number")
                Exit Sub
            End If
            If (txtOrderShares.Text = "") Then
                msgbox("Enter Number of shares to Order")
                Exit Sub
            End If
            If (txtOrderShares.Text = 0) Then
                msgbox("Enter Number of shares to Order")
                Exit Sub
            End If
            'saveOrderMain()
            SaveNewMain()
            'SavePurchaseOrder()
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved a purchase order','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnOrderSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrderSearch.Click
        Try
            If (txtOrderNumber.Text = "") Then
                MsgBox("Enter a valid order number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select OrdersSummary.OrderNumber,company,OrdersSummary.CDS_Number,OrdersSummary.Order_Quantity,OrdersSummary.OrderValue,OrdersSummary.OrderDate,names.CDS_number,names.Surname,names.Forenames,ordersSummary.Baseprice,ordersSummary.TargetDate,ordersSummary.Expirydate,OrdersSummary.OrderAttribute,OrdersSummary.OrderPreference from OrdersSummary,names where orderNumber='" & txtOrderNumber.Text & "' and names.cds_number=ordersSummary.cds_number and OrdersSummary.OrderType='PUR' and ordersSummary.ApprovalFlag<> 1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                txtOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                txtOrderShares.Text = ds.Tables(0).Rows(0).Item("Order_Quantity").ToString
                txtOrderAmount.Text = ds.Tables(0).Rows(0).Item("OrderValue").ToString
                cmbCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                txtHolder.Text = ds.Tables(0).Rows(0).Item("Cds_Number").ToString
                txtNames.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString + " " + ds.Tables(0).Rows(0).Item("Forenames").ToString)
                txtTargetDate.SelectedDate = ds.Tables(0).Rows(0).Item("TargetDate").ToString
                txtExpiryDate.SelectedDate = ds.Tables(0).Rows(0).Item("ExpiryDate").ToString

                'Dim dsi As New DataSet
                'cmd = New SqlCommand("select * from OrderTypeAttribute where orderType='" & ds.Tables(0).Rows(0).Item("OrderAttribute").ToString & "'", cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(dsi, "OrderTypeAttribute")

                'cmbOrderAttribute.SelectedItem.Text = dsi.Tables(0).Rows(0).Item("OrderType").ToString
                'lblOrderType.Text = dsi.Tables(0).Rows(0).Item("OrderCode").ToString

                calculateTotalCost()
                btnPrintStatement.Enabled = False
            Else
                msgbox("Order Not Found")
                Cleardata()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Cleardata()
        Try
            txtOrderAmount.Text = ""
            txtOrderShares.Text = ""
            txtHolder.Text = ""
            txtTotCharges.Text = ""
            txtTotalCost.Text = ""
            txtNames.Text = ""
            OrderNumber()
            getCompany()
            getSharePrice()
            getParaCharge()
            btnPrintStatement.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancelOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelOrder.Click
        Try
            cmd = New SqlCommand("update ordersSummary set status='X' where orderNumber='" & txtOrderNum.Text & "' and company='" & cmbCompany.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Cleardata()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnUpdateOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateOrder.Click
        Try
            cmd = New SqlCommand("update ordersSummary set Order_Quantity=" & txtOrderShares.Text & ", OrderValue=" & txtTotalCost.Text & ",UPDATED=1,Updated_By='" & Session("UserName") & "',Updated_On='" & Date.Now & "' where orderNumber='" & txtOrderNum.Text & "' and company='" & cmbCompany.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Order Updated")
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Updated a purchase order','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Cleardata()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            Cleardata()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            If (txtSearch.Text = "") Then
                msgbox("Enter a valid Search Name")
                Exit Sub
            End If
            Dim DS As New DataSet
            cmd = New SqlCommand("Select surname+' '+forenames+' '+cds_number as namess from names where surname like '" & txtSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(DS, "names")
            If (DS.Tables(0).Rows.Count > 0) Then
                lstNames.DataSource = DS.Tables(0)
                lstNames.DataValueField = "namess"
                lstNames.DataBind()
            Else
                lstNames.ClearSelection()
                lstNames.DataSource = Nothing
                lstNames.DataValueField = ""
                lstNames.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select cds_number from names where surname+' '+forenames+' '+cds_number = '" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            txtshareholder.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            getHolder()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbOrderAttribute_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrderAttribute.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select orderCode from OrderTypeAttribute where orderType = '" & cmbOrderAttribute.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrderTypeAttribute")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblOrderType.Text = ds.Tables(0).Rows(0).Item("OrderCode").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNames.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select cds_number from names where surname+' '+forenames+' '+cds_number = '" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            txtshareholder.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            getHolder()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnClear0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear0.Click
        Try
            If (txtOrderNum.Text = "") Then
                msgbox("Select a valid order number")
                Exit Sub
            End If
            Dim strscript As String = ""
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('OrderReceiptStatement.aspx?orderNumber=" & txtOrderNum.Text & "&Reptype=1');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbOrderPref_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrderPref.SelectedIndexChanged
        If (cmbOrderPref.SelectedItem.Text = "M") Then
            txtSharePrice.Text = 0.0
        Else
            getSharePrice()
        End If
    End Sub
End Class
