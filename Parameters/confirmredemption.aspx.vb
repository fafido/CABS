Partial Class Parameters_confirmredemption
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
                getcompanies()
                getinterestsrepayments()
            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Instruction Saved!")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtDesc.Text = ""
        txtinterest.Text = ""
        getSecurities_Types()
    End Sub
    Public Sub getcompanies()
        cmd = New SqlCommand("select issuer+' Payment('+convert(nvarchar(50),payment_no)+')' as pay, id from capital_repayment_instr where Authorized=0", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbsecurity.DataSource = ds
            cmbsecurity.TextField = "pay"
            cmbsecurity.ValueField = "id"
            cmbsecurity.DataBind()
        End If
    End Sub
    Public Function maxpaymentno(ByVal company As String) As Integer
        cmd = New SqlCommand("select isnull(max(payment_no),0)+1 as [PaymentNo] from capital_repayment_instr where issuer='" + company + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("PaymentNo")
        Else
            Return 0
        End If
    End Function
    Public Sub getinterestsrepayments()
        cmd = New SqlCommand("select Issuer as [Company(ISIN)], PAYMENT_no as [Payment No], date_payment as [Payment Date],  datecreated as [Creation Date], Case Authorized when 0 then 'Pending' else 'Completed' end as [Status] from capital_repayment_instr", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "companies")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Try
    
            cmd = New SqlCommand("declare @company nvarchar(50)=(select issuer from capital_repayment_instr where id='" + txtid.Text + "') declare @rate numeric(18,4)=1  declare @datefrom date='" + cmbdatedeclared.Text + "' declare @dateto date='" + cmbpaymentsdate.Text + "' insert into  capital_payments  select @company, 1, (select payment_no from capital_repayment_instr where id='" + txtid.Text + "') as paymentno, cds_number, surname+' '+forenames, ADD_1, ADD_2, ADD_3, add_4, country, div_bank, div_branch, div_branch, Div_AccountNo, (select sum(shares) from trans where cds_number=Accounts_Clients.CDS_Number and company=@company) as bonds, getdate(), getdate(), 0, (select sum(shares) from trans where cds_number=Accounts_Clients.CDS_Number and company=@company and Date_Created<=@dateto)*@rate*100 as interest,convert(numeric(18,2),(select sum(shares) from trans where cds_number=Accounts_Clients.CDS_Number and company=@company and Date_Created<=@dateto)*@rate*100) as interestrounded FROM Accounts_Clients where cds_number in (select cds_number from trans where company=@company and Date_Created<=@dateto  group by cds_number having sum(shares)>0)  update capital_repayment_instr set Authorized='1', Authorizedby='" + Session("Username") + "' where id='" + txtid.Text + "'", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim y As Integer = cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

        

      

    End Sub
    Protected Sub getSecurities_Types()
        Try
            cmd = New SqlCommand("select ID,Security_Type as [TYPE],[Description] from Para_Security_Type", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_Security_Type")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbsecurity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsecurity.SelectedIndexChanged
        txtid.Text = cmbsecurity.SelectedItem.Value
        getdetails()
    End Sub
    Public Sub getdetails()
        cmd = New SqlCommand("select * from capital_repayment_instr where id='" + txtid.Text + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para")
        If ds.Tables(0).Rows.Count > 0 Then
            '  cmbdatedeclared.Text = ds.Tables(0).Rows(0).Item("date_declared")
            ' cmbdateclosed.Text = ds.Tables(0).Rows(0).Item("date_closed")
            cmbpaymentsdate.Text = ds.Tables(0).Rows(0).Item("date_payment")
            '  txtinterest.Text = ds.Tables(0).Rows(0).Item("rate")
            txtDesc.Text = ds.Tables(0).Rows(0).Item("mess_1")
        End If
    End Sub

    Protected Sub txtid_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub
End Class
