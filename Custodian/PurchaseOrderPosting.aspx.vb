Imports System.Data
Imports System.Data.SqlClient
Partial Class Custodian_PurchaseOrderPosting
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
            End If

            OrderNumber()
            getCompany()
            getSharePrice()
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
            msgbox(ex.Message)
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
                msgbox("Holder not found")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            getHolder()
        Catch ex As Exception
            msgbox(ex.Message)
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
            msgbox(ex.Message)
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
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getSharePrice()
            getNewOrderValue()
            calculateTotalCost()
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

    Protected Sub txtOrderShares_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderShares.TextChanged
        Try
            If (IsNumeric(txtOrderShares.Text)) Then
                Dim orderPrice As Double
                orderPrice = ((txtOrderShares.Text) * (txtSharePrice.Text))
                txtOrderAmount.Text = CDbl(orderPrice)
                calculateTotalCost()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtOrderAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderAmount.TextChanged
        Try
            Dim shares As Integer
            shares = CInt(txtOrderAmount.Text / txtSharePrice.Text)
            txtOrderShares.Text = CInt(shares)
            calculateTotalCost()
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
            cmd = New SqlCommand("insert into ordersSummary(OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,TargetDate,ExpiryDate,OrderAttribute) values ('" & orderNum & "','" & cmbCompany.Text & "','" & txtshareholder.Text & "'," & txtOrderShares.Text & "," & txtOrderAmount.Text & ",'PUR','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "') ", cn)

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
            cmd = New SqlCommand("insert into PurchaseOrders (OrderNumber,CDS_Number,Company,Order_Quantity,Basic_Fee,Stamp_Duty,PurchaseRegistration,MinimumBrokerage,TransferFees,TotalCharges,OrderValue,Order_By,Postdate,Targetdate,ExpiryDate,OrderAttribute) values('" & txtOrderNum.Text & "','" & txtshareholder.Text & "','" & cmbCompany.Text & "'," & txtOrderShares.Text & "," & txtBasicCharges.Text & "," & txtStamp.Text & "," & txtPReg.Text & "," & txtMinBroke.Text & "," & txtTfees.Text & "," & txtTotCharges.Text & "," & txtTotalCost.Text & ",'" & Session("UserName") & "','" & Now.Date & "','" & TargetDate.Text & "','" & ExpiryDate.Text & "','" & lblOrderType.Text & "')", cn)
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
                orderref = (ds.Tables(0).Rows(0).Item("OrderRef").ToString + 1) & Session("BrokerCode")
                txtOrderNum.Text = orderref
            Else
                orderref = "1USER"
                txtOrderNum.Text = orderref
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try
            If (txtHolder.Text = "") Then
                msgbox("Invalid Shareholder Number")
                Exit Sub
            End If
            saveOrderMain()
            SavePurchaseOrder()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnOrderSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrderSearch.Click
        Try
            If (txtOrderNumber.Text = "") Then
                msgbox("Enter a valid order number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select OrdersSummary.OrderNumber,company,OrdersSummary.CDS_Number,OrdersSummary.Order_Quantity,OrdersSummary.OrderValue,OrdersSummary.OrderDate,names.CDS_number,names.Surname,names.Forenames from OrdersSummary,names where orderNumber='" & txtOrderNumber.Text & "' and names.cds_number=ordersSummary.cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                txtOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                txtOrderShares.Text = ds.Tables(0).Rows(0).Item("Order_Quantity").ToString
                txtOrderAmount.Text = ds.Tables(0).Rows(0).Item("OrderValue").ToString
                cmbCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                txtHolder.Text = ds.Tables(0).Rows(0).Item("Cds_Number").ToString
                txtNames.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString + " " + ds.Tables(0).Rows(0).Item("Forenames").ToString)
                calculateTotalCost()
                btnPrintStatement.Enabled = False
            Else
                msgbox("Order Not Found")
                Cleardata()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
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
End Class
