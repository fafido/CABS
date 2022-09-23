Partial Class TransferSec_UT_Payment
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
            If Session("finish") = "True" Then
                Session("finish") = ""
                msgbox("Payment Allocation successfully captured")
            End If
            If Session("finish") = "archived" Then
                Session("finish") = ""
                msgbox("Successfully Archived")
            End If
            If Session("finish") = "Update" Then
                Session("finish") = ""
                msgbox("Successfully Updated")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getCompany()
                GetBatchTypes()
                Getbrokers()
                GETLODGER()
                '    loadpending()


                loadsecurities()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select code as company, code as full_name from Bond where Category='Trustee'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbparaCompany.DataSource = ds.Tables(0)
            cmbparaCompany.TextField = "full_name"
            cmbparaCompany.ValueField = "company"
            cmbparaCompany.DataBind()
            cmbparaCompany0.Items.Add("Bond")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBatchTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (batch_Type) from Para_Batch_type order by Batch_Type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_batch_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "batch_Type"
                cmbBatchType.TextField = "batch_Type"
                cmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getbrokers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (broker_code), fnam from Para_Broker", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "broker_code"
                cmbBatchType.TextField = "fnam"
                cmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try


            Dim shares As Double = txtBatchShares.Text
            Dim shareprice As Decimal = txtShareprice.Text
            Dim value As Double = shares * shareprice
            txtBatchValue.Text = value

            'If getissuedcapital(txtisin.Text) < shares Then
            '    msgbox("Batch total cannot exceed Available Shares!")
            '    Exit Sub
            'End If

            cmd = New SqlCommand("insert into batch_receipt (id,company, batch_shares, shareprice, batch_value, batch_date, lodger, balanced, verified, successful, batch_type, masttemp,broker_code, security_type) values ('0','" + cmbparaCompany.SelectedItem.Value.ToString + "',@batchshares,@shareprice,'" + txtBatchValue.Text + "','" + txtBatchDate.Text + "',@lodger,'0','0','0','Allot','0','" + Session("brokercode") + "','" + cmbparaCompany0.SelectedItem.Text + "')", cn)


            cmd.Parameters.AddWithValue("@batchshares", txtBatchShares.Text)
            cmd.Parameters.AddWithValue("@shareprice", txtShareprice.Text)

            cmd.Parameters.AddWithValue("@lodger", txtClientNo2.Text)


            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim ds As New DataSet
            cmd = New SqlCommand("select batch_no from batch_receipt order by batch_no desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batch_no")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo.Visible = True
                txtClientNo.Text = ds.Tables(0).Rows(0).Item("batch_no")
            End If

            Panel3.Enabled = False
            Panel5.Enabled = True
            Panel9.Enabled = True


            msgbox("Batch Number:" + txtClientNo.Text + " has been successfully created. Please add some Shares and Share Certificates to the batch")
        Catch ex As Exception
            msgbox("Please enter all the fields in the Batch Details, they are mandatory. Please Supply numeric fields where necessary. Once the batch details have been saved, please add the Primary batch details below!")
        End Try

    End Sub

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+surname+' '+middlename+' '+forenames as names, cds_number from accounts_clients where cds_number+' '+surname+' '+forenames+' '+tel like '%' + @cdsnum + '%' and BankAccount_Type='Unit Trust'", cn)
        cmd.Parameters.AddWithValue("@cdsnum", txtclientnumber.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()

        End If
    End Sub

    Protected Sub txtClientNo3_TextChanged(sender As Object, e As EventArgs) Handles txtclientnumber.TextChanged

    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click

        Try

            cmd = New SqlCommand("insert into CashTrans_Audit ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference, ChargeCode, [Type], [CapturedBy],BeneficiaryBank, BeneficiaryBranch, BeneficiaryAccount, BeneficiaryAccountName) VALUES   ('Income Payment " + cmbpaymentdetails.SelectedItem.Text + "','UNIT TRUST INCOME " + cmbparaCompany1.SelectedItem.Value.ToString + "','" & txtamountreceived.Text & "',GETDATE(),'0','" + ListBox1.SelectedValue.ToString + "',NULL, '','','PAYMENT','" + Session("Username") + "','" + txtbank.Text + "', '', '" + txtbankAccount.Text + "','" + ListBox1.SelectedItem.Text + "')  Update UT_Income set paid='1' where ClientNo='" + ListBox1.SelectedValue.ToString + "' and IncomeID='" + cmbpaymentdetails.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Session("finish") = "True"
                Response.Redirect(Request.RawUrl)
            Catch ex As Exception
                msgbox(ex.Message)
            End Try









    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select sum(shares) from batch_certs where batch_no=@batchno) as certs_total, (select batch_shares from Batch_receipt where batch_no=@batchno) as batch_tot", cn)
        cmd.Parameters.AddWithValue("@batchno", txtClientNo.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "totals")
        If (ds.Tables(0).Rows.Count > 0) Then
            If ds.Tables(0).Rows(0).Item("certs_total") = ds.Tables(0).Rows(0).Item("batch_tot") Then
                cmd = New SqlCommand("update batch_receipt set balanced='1', verified='2' where batch_no=@batchno", cn)
                cmd.Parameters.AddWithValue("@batchno", txtClientNo.Text)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "yes"
                Response.Redirect(Request.RawUrl)
            Else
                msgbox("Specified batch total not balancing with the total shares you added!")
            End If
        End If
    End Sub

    Protected Sub cmbparaCompany0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany0.SelectedIndexChanged

    End Sub
    Public Sub loadsecurities()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from comps where category='Unit Trust'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbparaCompany1.DataSource = ds
                cmbparaCompany1.TextField = "fnam"
                cmbparaCompany1.ValueField = "company"
                cmbparaCompany1.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function availableunits(company As String, cds_Number As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as tot from trans where cds_number='" + cds_Number + "' and company='" + company + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_broker")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("tot")
        Else
            Return 0
        End If

    End Function
    Public Function currentprice(company As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select convert(numeric(18,4),value/TotalUnits) as Price  from UT_Price where Funding_Code='" + company + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_broker")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Price").ToString
        Else
            Return 0
        End If

    End Function
    Public Sub GETLODGER()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT isnull(surname,'')+' '+isnull(forenames,'') as names from systemusers where id='" + Session("newid") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo2.Text = StrConv(ds.Tables("para_broker").Rows(0).Item("names"), VbStrConv.ProperCase)
                txtClientNo2.ReadOnly = True

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged
        cmbparaCompany0.Items.Clear()
        cmbparaCompany0.Items.Add(securitytype(cmbparaCompany.SelectedItem.Value.ToString))
        cmbparaCompany0.Value = securitytype(cmbparaCompany.SelectedItem.Value.ToString)
        txtisin.Text = cmbparaCompany.SelectedItem.Value.ToString
    End Sub
    Public Function securitytype(ByVal selected As String) As String
        Try
            Dim sel As String = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("select sec_type from para_company where company='" + selected + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                sel = ds.Tables(0).Rows(0).Item("sec_type")
            Else
                sel = ""
            End If

            Return sel


        Catch ex As Exception
            msgbox(ex.Message)
            Return ""
        End Try


    End Function
    Public Sub loadpending()
        Dim ds As New DataSet
        cmd = New SqlCommand("  select a.surname+' '+a.forenames as Names, * from UT_Allocation b, Accounts_clients a where a.CDS_Number=b.cds_number and b.[status]<>'ARCHIVED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type1")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdTranShareholder.DataSource = ds
            grdTranShareholder.DataBind()

        End If
    End Sub
    Public Sub getpaymentsforfund(fund As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select Fund+' '+incomedescription as descr, id from UT_Allocation_Income WHERE [Status]='Approved' and Fund='" + fund + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type1")

        If (ds.Tables(0).Rows.Count > 0) Then
            cmbpaymentdetails.DataSource = ds
            cmbpaymentdetails.TextField = "descr"
            cmbpaymentdetails.ValueField = "id"
            cmbpaymentdetails.DataBind()


        End If
    End Sub
    Public Function getissuedcapital(isin As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select issued_capital-isnull((select sum(shares) from trans where company='" + isin + "'),0) as issued_capital from para_company where company='" + isin + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type1")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("issued_capital")
        Else
            Return 0
        End If
    End Function

    Protected Sub grdTranShareholder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdTranShareholder.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select b.quantity, b.id, b.cds_number, a.surname,a.forenames, b.company, b.Amount, b.Price from UT_Allocation b, accounts_clients a where b.cds_number=a.cds_number and b.id='" + grdTranShareholder.SelectedValue.ToString + "' and (b.[Status]='PENDING' OR b.[status]='REJECTED')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtclientnumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString

            txtClientName.Text = ds.Tables(0).Rows(0).Item("Surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString
            cmbparaCompany1.Value = ds.Tables(0).Rows(0).Item("company").ToString
            Dim li As ListItem = New ListItem(txtclientnumber.Text + " " + txtClientName.Text, txtclientnumber.Text)
            ListBox1.Items.Clear()
            ListBox1.Items.Add(li)
            ListBox1.SelectedIndex = 0
            txtshares.Text = availableunits(ds.Tables(0).Rows(0).Item("company").ToString, txtclientnumber.Text)
            ASPxButton12.Text = "Update"
            lblid.Text = ds.Tables(0).Rows(0).Item("id").ToString
            txtbankAccount.Text = ds.Tables(0).Rows(0).Item("Quantity").ToString
            txtamountreceived.Text = ds.Tables(0).Rows(0).Item("Amount").ToString
            '     txtcurrentprice.Text = ds.Tables(0).Rows(0).Item("Price").ToString
            ASPxButton15.Visible = True

        Else
            msgbox("You cannot edit an approved entry!")
            Exit Sub
        End If

    End Sub

    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        cmd = New SqlCommand("delete from batch_certs where batch_no='" + txtClientNo.Text + "' delete from batch_receipt where batch_no='" + txtClientNo.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Session("finish") = "delete"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub cmbparaCompany1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany1.SelectedIndexChanged
        '   Try
        txtshares.Text = availableunits(cmbparaCompany1.SelectedItem.Value.ToString, ListBox1.SelectedValue.ToString).ToString
        ' txtcurrentprice.Text = currentprice(cmbparaCompany1.SelectedItem.Value.ToString)

        getpaymentsforfund(cmbparaCompany1.SelectedItem.Value.ToString)
        'Catch ex As Exception

        'End Try

    End Sub
    Public Sub getbankingdetails(clientno As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from accounts_clients where cds_number='" + clientno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtbank.Text = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
            txtbankAccount.Text = ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString
        End If
    End Sub
    Public Sub getamountreceived(clientno As String, idss As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select Amount from UT_Income where IncomeID='" + idss + "' AND clientNo='" + clientno + "' and Paid='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtamountreceived.Text = ds.Tables(0).Rows(0).Item("Amount").ToString
        Else
            txtamountreceived.Text = "0"
        End If
    End Sub
    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        '  Try
        Try


            txtshares.Text = availableunits(cmbparaCompany1.SelectedItem.Value.ToString, ListBox1.SelectedValue.ToString).ToString
        Catch ex As Exception

        End Try
        Try


            getbankingdetails(ListBox1.SelectedValue.ToString)
        Catch ex As Exception

        End Try
        '   Try


        'Catch ex As Exception

        'End Try
        'Catch ex As Exception

        'End Try
    End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click

    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        If txtbankAccount.Text = "" Then
            msgbox("Please select transaction to archive!")
            Exit Sub
        End If
        Try
            cmd = New SqlCommand("update UT_Allocation set [Status]='ARCHIVED' where id='" + lblid.Text + "' ", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "archived"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtshares_TextChanged(sender As Object, e As EventArgs) Handles txtshares.TextChanged

    End Sub

    Protected Sub txtamountreceived_TextChanged(sender As Object, e As EventArgs) Handles txtamountreceived.TextChanged


        recalc()

    End Sub
    Public Sub recalc()
        Try

            Dim curr As Decimal = currentprice(cmbparaCompany1.SelectedItem.Value.ToString)
            '     txtcurrentprice.Text = curr.ToString
            Dim amt As Decimal = txtamountreceived.Text

            Dim units As Decimal = amt / curr
            txtbankAccount.Text = units.ToString
            If amt = 0 Then

            End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub txtbankAccount_TextChanged(sender As Object, e As EventArgs) Handles txtbankAccount.TextChanged

    End Sub
    Protected Sub cmbpaymentdetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpaymentdetails.SelectedIndexChanged
        Try


            getamountreceived(ListBox1.SelectedValue.ToString, cmbpaymentdetails.SelectedItem.Value.ToString)
        Catch ex As Exception

        End Try
    End Sub
End Class
