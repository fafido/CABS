Partial Class Enquiries_Cash_Deposits_broker
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
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Daily Balance Added")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            ' If (txtClientNameSearch.Text <> "") Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select company_code+'  '+company_name as namess from client_companies where company_name like '%'+ @company +'%' and company_type='BROKER'", cn)
            cmd.Parameters.AddWithValue("@company", txtClientNameSearch.Text)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.TextField = "namess"
                lstNamesSearch.ValueField = "namess"
                lstNamesSearch.DataBind()
            Else
                lstNamesSearch.Items.Clear()
            End If
            '  End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged
        Try
            If (lstNamesSearch.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from client_companies where company_code+'  '+company_name = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientNo.Text = ds.Tables(0).Rows(0).Item("company_code").ToString.ToUpper
                    txtTitle.Text = ds.Tables(0).Rows(0).Item("company_type").ToString.ToUpper
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("company_name").ToString.ToUpper

                    getbal()

                Else

                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("declare @brokercode as nvarchar(50)='" + txtClientNo.Text + "'  declare @tot as money= (select coalesce(Amount,0) from cds.dbo.tbl_cashbalance_broker where CONVERT(VARCHAR(10),transactiondate,10)=CONVERT(VARCHAR(10),GETDATE(),10) and brokercode=@brokercode) declare @pend as money=(select coalesce(sum(quantity),0)*(select coalesce(initialprice,0) from testcds.dbo.para_company where company=testcds.dbo.Order_Live.Company) from testcds.dbo.order_live  where broker_code=@brokercode and CONVERT(VARCHAR(10),create_date,10)=CONVERT(VARCHAR(10),GETDATE(),10) group by testcds.dbo.Order_Live.Company) declare @comm as money=(select coalesce(sum(amount_due),0) from tbl_SettlementSummary where Status_Flag='C' and cds_number in (select cds_number from accounts_clients where BrokerCode=@brokercode) AND left(deal_reference,1)='P' and CONVERT(VARCHAR(10),trade_date,10)=CONVERT(VARCHAR(10),GETDATE(),10)) declare @result as money=@tot-@pend-@comm select coalesce(Amount,0) as [Cleared(Opening)],coalesce(( select coalesce(sum(quantity),0)*(select coalesce(initialprice,0) from testcds.dbo.para_company where company=testcds.dbo.Order_Live.Company) from testcds.dbo.order_live  where broker_code=@brokercode and CONVERT(VARCHAR(10),create_date,10)=CONVERT(VARCHAR(10),GETDATE(),10) group by testcds.dbo.Order_Live.Company),0) AS [Pending Orders],(select coalesce(sum(amount_due),0) from tbl_SettlementSummary where Status_Flag='C' and cds_number in (select cds_number from accounts_clients where BrokerCode=@brokercode) AND left(deal_reference,1)='P' and CONVERT(VARCHAR(10),trade_date,10)=CONVERT(VARCHAR(10),GETDATE(),10)) as [Closed Orders], @result as [Cleared Fund(Available)]  from cds.dbo.tbl_cashbalance_broker where CONVERT(VARCHAR(10),transactiondate,10)=CONVERT(VARCHAR(10),GETDATE(),10) and brokercode=@brokercode ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Panel4.Visible = False
            Panel5.Visible = True
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()

        Else
            Panel4.Visible = True
            Panel5.Visible = False
            '  msgbox("nothing")
        End If

    End Sub
    Public Sub getbal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select top 1 * from tbl_cashbalance_broker where brokercode=(select company_code from client_companies where company_code+'  '+company_name = '" & lstNamesSearch.SelectedItem.Text & "') order by transactiondate desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
         
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()

        Else

            msgbox("No Balance")
        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        If txtClientNo.Text = "" Then
            msgbox("Broker Code Cannot Be Blank")
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            msgbox("Amount must be numbers only")
            Exit Sub
        End If
        Dim result As Integer
        cmd = New SqlCommand("insert into tbl_CashBalance_broker (brokercode, Amount, Description, Counter, CumBal, transactiondate) values ('" & txtClientNo.Text & "',@amount,'Cash Deposit','" & cmbCounter.Text & "','0',getdate())", cn)
        cmd.Parameters.AddWithValue("@amount", txtAmount.Text)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        GetCashBal()

        cn.Close()
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
        'ClearFields()
    End Sub

    Public Sub DepositReg()
        Dim result As Integer
        cmd = New SqlCommand("Update Deposits_Reg  Set Flag_Status='Closed' where CDS_Number='" & txtClientNo.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Dim cashbal As Double
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Deposit_Amount),0.0) as total from Deposits_Reg where CDS_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cashbal = CDbl(ds.Tables(0).Rows(0).Item(0).ToString) + CDbl(txtAmount.Text)
        Else
            cashbal = txtAmount.Text
        End If
        cmd = New SqlCommand("insert into  Deposits_Reg (ORDER_Number, CDS_Number, Deposit_Amount, Date_of_Deposit, Flag_Status) values (999999,'" & txtClientNo.Text & "'," & cashbal & ",GetDate(),'Open')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
    End Sub
    Public Sub ClearFields()
        txtAmount.Text = ""
        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""
        txtTitle.Text = ""
        cmbCounter.SelectedIndex = -1
        chkCounter.Checked = False
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

    End Sub
End Class
