Imports System.Data
Imports System.Data.SqlClient
Partial Class Custodian_SaleOrderPosting
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
            Else
                getCompany()
                getSharePrice()
                OrderNumber()
                getParaCharge()
                getOrderAttribute()
                lblBuyer.Text = Session("Username").ToString
            End If

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
    Public Sub getParaCharge()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 * from para_fees order by DateUpdate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_fees")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtBasicCharges.Text = ds.Tables(0).Rows(0).Item("BasicFee").ToString
                txtStamp.Text = ds.Tables(0).Rows(0).Item("StampDuty").ToString
                txtBrokerage.Text = ds.Tables(0).Rows(0).Item("PurchaseRegistration").ToString
                txtMinBroke.Text = ds.Tables(0).Rows(0).Item("MinimumBrokerage").ToString
                txtTfees.Text = ds.Tables(0).Rows(0).Item("TransferFees").ToString
                txtSecLevel.Text = ds.Tables(0).Rows(0).Item("SecLevy").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub calculateCosts()
        Try
            Dim sec, tfees, brok, stamp, totCharges As Double
            sec = CDbl(((txtSecLevel.Text) / 100) * (txtTotGross.Text))
            tfees = CDbl(((txtTfees.Text) / 100) * (txtTotGross.Text))
            brok = CDbl(((txtMinBroke.Text) / 100) * (txtTotGross.Text))
            stamp = CDbl(((txtStamp.Text) / 100) * (txtTotGross.Text))
            totCharges = CDbl(sec + tfees + brok + stamp + (txtBrokerage.Text) + (txtBasicCharges.Text))
            txtCharges.Text = totCharges
            txtTotpay.Text = (CDbl(totCharges + (txtTotGross.Text)))
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
    Public Sub getHolder()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select Surname,Forenames,CDS_Number from names where CDS_Number= '" & txtholder.Text & "' and Locked=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtShareholder.Text = ds.Tables(0).Rows(0).Item("CDS_Number").ToString
                txtNames.Text = ((ds.Tables(0).Rows(0).Item("Forenames").ToString) & " " & (ds.Tables(0).Rows(0).Item("Surname").ToString))
            Else
                msgbox("Holder not found")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            getSharePrice()
            getGrossAmount()
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
            txtholder.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            getHolder()
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
            'If (Session("BrokerCode").ToString = "") Then
            ' Response.Redirect("~\loginsystem.aspx")

            'Else
            If (ds.Tables(0).Rows.Count > 0) Then
                orderref = (ds.Tables(0).Rows(0).Item("OrderRef").ToString + 1) & Session("BrokerCode")
                txtOrderNum.Text = orderref
            Else
                orderref = "1USER"
                txtOrderNum.Text = orderref
            End If
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select sum(shares) as shares, sum(Pledge_shares) as Pledges from mast where company='" & cmbCompany.Text & "' and cds_number='" & txtShareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim AvailableShares As Integer
                AvailableShares = CInt((ds.Tables(0).Rows(0).Item("Shares").ToString) - (ds.Tables(0).Rows(0).Item("Pledges").ToString))
                If (AvailableShares >= CInt(txtOrderNumber.Text)) Then
                    saveMainOrder()
                    SaveSaleOrder()
                Else
                    msgbox("Order Quantity greater than current portfolio balance, enter a smaller order")
                    Exit Sub
                End If
            Else
                msgbox("Shareholder does not a valid portfolio")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getGrossAmount()
        Try
            txtTotGross.Text = CDbl((txtOrderNumber.Text) * (txtSharePrice.Text))
            calculateCosts()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub txtOrderNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderNumber.TextChanged
        getGrossAmount()
        calculateCosts()
    End Sub
    Public Sub saveMainOrder()
        Try
            cmd = New SqlCommand("insert into OrdersSummary (OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status,BasePrice,TargetDate,ExpiryDate,OrderAttribute) values ('" & txtOrderNum.Text & "','" & cmbCompany.Text & "','" & txtShareholder.Text & "'," & txtOrderNumber.Text & "," & txtTotpay.Text & ",'SAL','" & Date.Now & "','" & Session("BrokerCode") & "','" & Session("UserName") & "','O'," & CDbl(txtSharePrice.Text) & ",'" & txtTargetDate.Text & "','" & txtExpiryDate.Text & "','" & lblOrderType.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveSaleOrder()
        Try
            cmd = New SqlCommand("insert into SaleOrders (orderNumber,CDS_Number,company,Order_Quantity,Basic_Fee,Stamp_Duty,MinimumBrokerage,TransferFees,SecLevy,ValueBeforeTax,TotalCharges,OrderValue,Order_By) values ('" & txtOrderNum.Text & "','" & txtShareholder.Text & "','" & cmbCompany.Text & "'," & txtOrderNumber.Text & "," & txtBasicCharges.Text & "," & txtStamp.Text & "," & txtBrokerage.Text & "," & txtTfees.Text & "," & txtSecLevel.Text & "," & txtTotGross.Text & "," & txtCharges.Text & "," & txtTotpay.Text & ",'" & Session("UserName") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Order Saved")
            OrderNumber()
            txtShareholder.Text = ""
            txtNames.Text = ""
            txtTotGross.Text = ""
            txtCharges.Text = ""
            txtOrderNumber.Text = "0"
            txtTargetDate.Clear()
            txtExpiryDate.Clear()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnOrderSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrderSearch.Click
        Try
            If (txtOrderNumberSearch.Text = "") Then
                msgbox("Enter a valid order number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select OrdersSummary.OrderNumber,company,OrdersSummary.CDS_Number,OrdersSummary.Order_Quantity,OrdersSummary.OrderValue,OrdersSummary.OrderDate,names.CDS_number,names.Surname,names.Forenames from OrdersSummary,names where orderNumber='" & txtOrderNumberSearch.Text & "' and names.cds_number=ordersSummary.cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                txtOrderNum.Text = ds.Tables(0).Rows(0).Item("OrderNumber").ToString
                txtOrderNumber.Text = ds.Tables(0).Rows(0).Item("Order_Quantity").ToString
                cmbCompany.Text = ds.Tables(0).Rows(0).Item("company").ToString
                txtholder.Text = ds.Tables(0).Rows(0).Item("Cds_Number").ToString
                txtNames.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString + " " + ds.Tables(0).Rows(0).Item("Forenames").ToString)
                getGrossAmount()
                calculateCosts()
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
            txtShareholder.Text = ""
            txtOrderNumber.Text = ""
            txtholder.Text = ""
            txtCharges.Text = ""
            txtTotpay.Text = ""
            txtNames.Text = ""
            OrderNumber()
            getCompany()
            getSharePrice()
            getParaCharge()
            btnPrintStatement.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdateOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateOrder.Click
        Try
            cmd = New SqlCommand("update ordersSummary set Order_Quantity=" & txtOrderNumber.Text & ", OrderValue=" & txtTotpay.Text & ",UPDATED=1,Updated_By='" & Session("UserName") & "',Updated_On='" & Date.Now & "' where orderNumber='" & txtOrderNum.Text & "' and company='" & cmbCompany.Text & "'", cn)
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

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Cleardata()
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

    Protected Sub lstNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNames.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select cds_number from names where surname+' '+forenames+' '+cds_number = '" & lstNames.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            txtholder.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            getHolder()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Protected Sub cmbOrderAttribute_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrderAttribute.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select orderCode from OrderTypeAttribute where orderType = '" & cmbOrderAttribute.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrderTypeAttribute")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblOrderType.Text = ds.Tables(0).Rows(0).Item("OrderCode").ToString
            End If

            If (cmbOrderAttribute.Text = "Day Order") Then
                txtExpiryDate.SelectedDate = txtTargetDate.Text
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
