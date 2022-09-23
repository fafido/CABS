Partial Class TransferSec_BorrowersAccept
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
    Public Sub GetLenders()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate <='" & Now.Date & "'", cn)
            cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lendersRegister")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstLenders.DataSource = ds.Tables(0)
                lstLenders.TextField = "namess"
                lstLenders.ValueField = "namess"
                lstLenders.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from trans WHERE cds_number='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.TextField = "company"
                cmbCompany.ValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkSessionState()
        Try
            '  GetCompany()
            '  GetSectype()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Pledge Successfully Approved!  ")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  runasync()

                txtEffectiveDate.MaxDate = Date.UtcNow
                getpending()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub getpending()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select 'Account No: '+ Borrower + '  Collateral: '+ Collateral +'  Amount: '+ convert(nvarchar(50),LoanAmount) +'  Tenure: '+ convert(nvarchar(50),tenure) as [LoanDetails], id from BorrowingRequest where ApprovedBY='FOR FINAL' AND BANK='" + Session("BrokerCode") + "'  and rejected Is null", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "id"
                lstNameSearch.TextField = "LoanDetails"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number=(select borrower from BorrowingRequest where id='" & lstNameSearch.SelectedItem.Value.ToString & "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtClientId.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtSurname.Text = "" + ds.Tables(0).Rows(0).Item("surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString + ""

                txtIdno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function getactualoptionID(fullname As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select id from para_lendingrules where Bank+' '+OptionName='" + fullname + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("id").ToString
        End If
    End Function
    Public Sub GetDetails()
        ' Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from BorrowingRequest where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim n As Decimal = ds.Tables(0).Rows(0).Item("Unit_Price").ToString
            Dim a As Decimal = ds.Tables(0).Rows(0).Item("AvailableQuantity").ToString
            cmbCompany.Text = ds.Tables(0).Rows(0).Item("Collateral").ToString
            txtavailableQuantity.Text = a.ToString("N")
            txtcapturedate.Text = ds.Tables(0).Rows(0).Item("CapturedDate").ToString
            txtEffectiveDate.Text = ds.Tables(0).Rows(0).Item("EffectiveDate").ToString
            txtExpiryDate.Text = ds.Tables(0).Rows(0).Item("MaturityDate").ToString
            Dim lnamt As Decimal = ds.Tables(0).Rows(0).Item("LoanAmount").ToString
            txtquantity.Text = lnamt.ToString("N")
            Dim prce As Decimal = ds.Tables(0).Rows(0).Item("Unit_Price").ToString
            txtshareprice.Text = prce.ToString("N")
            txtcollateralvalue.Text = (n * a).ToString("N")
            txtmonthlyinstalment.Text = ds.Tables(0).Rows(0).Item("MonthlyInstalment").ToString
            '  Dim ttlpayme As Decimal = ds.Tables(0).Rows(0).Item("totalpayment").ToString
            txttotal.Text = "0"

            Dim svcechrge As Decimal = ds.Tables(0).Rows(0).Item("ServiceCharge").ToString
            txtservicefee.Text = svcechrge.ToString("N")

            txttenure.Text = ds.Tables(0).Rows(0).Item("Tenure").ToString
            lblunitofmeasure.Text = unitof(ds.Tables(0).Rows(0).Item("Collateral").ToString)
            '    cmbfinancier.Value = getactualoptionID(ds.Tables(0).Rows(0).Item("Bank").ToString + " " + ds.Tables(0).Rows(0).Item("OptionName").ToString)
            '  loadinterest(cmbfinancier.SelectedItem.Value.ToString)
            Try
                Dim m As New NaymatBilling
                ' Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
                Dim charge As Double = m.getEWRBAL(cmbCompany.Value.ToString, txtClientId.Text)
                '  Dim globcharge As Double = m.getholderbal(txtClientId.Text, Session("BrokerCode"))
                txtaccumulatedcharges.Text = charge.ToString("N")
                '  txtothercharges.Text = globcharge.ToString
            Catch ex As Exception

            End Try
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Function unitof(receipt As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select unitmeasure from wr where receiptno='" + receipt + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Unitmeasure").ToString
        Else
            Return ""
        End If
    End Function
    Public Function getreceipt() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from BorrowingRequest where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Collateral").ToString
        End If

    End Function

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        GetSelectedDetails()
        GetDetails()
        loadoptions()


    End Sub
    Public Sub loadoptions()
        Dim ds As New DataSet
        cmd = New SqlCommand("select Bank+' '+OptionName as nm, id  from  para_lendingRules where Bank='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbfinancier.DataSource = ds
            cmbfinancier.TextField = "nm"
            cmbfinancier.ValueField = "id"
            cmbfinancier.DataBind()

        End If
    End Sub


    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from lendersregister where cds_Number='" + lstLenders.SelectedItem.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lenders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdTranShareholder.DataSource = ds
                grdTranShareholder.DataBind()

            Else
                msgbox("No match found!")
            End If

            'Dim ds1 As New DataSet
            'cmd = New SqlCommand("select * from para_lendingrules where security='" + cmbSecurity.SelectedItem.Text + "'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds1, "req")
            'If (ds1.Tables(0).Rows.Count > 0) Then
            '    grdTranShareholder0.DataSource = ds1
            '    grdTranShareholder0.DataBind()
            'Else
            '    msgbox("No request parameters found!")
            'End If
        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub




    Protected Sub txtshareprice_TextChanged(sender As Object, e As EventArgs) Handles txtshareprice.TextChanged
        Dim price As Decimal = txtshareprice.Text
        Dim quantity As Decimal = txtavailableQuantity.Text
        Dim value As Decimal = price * quantity
        txtcollateralvalue.Text = value.ToString

    End Sub
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try
            Dim required As Decimal = txtquantity.Text
            Dim approved As Decimal = txtapprovedamount.Text
            If approved > required Then
                msgbox("You cannot approve amount which is greater then Amount required!")
                Exit Sub
            End If



            Try
                Dim em As New sendmail
                em.sendmail(getemail(txtClientId.Text), "EWR Pledged", "Pledge request on EWR Number " + cmbCompany.Text + " has been authorized successfully.")
            Catch ex As Exception
                msgbox("Error Sending email!")
            End Try

            cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Loan Service Fee','Service Fee'," & txtservicefee.Text.Replace(",", "") & "*-1,GETDATE(),'1','" + txtClientId.Text + "',NULL, '" + cmbCompany.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("update BorrowingRequest set EffectiveDate='" + txtEffectiveDate.Text + "', TotalPayment='" + txttotal.Text.Replace(",", "") + "',ServiceCharge='" + txtservicefee.Text.Replace(",", "") + "' , amountApproved='" + txtapprovedamount.Text.Replace(",", "") + "' ,Approved='1', ApprovedBy='" + Session("Username") + "' ,OptionName='" + cmbfinancier.SelectedItem.Text + "', approvedOn=getdate(), [status]='PLEDGED' where id='" + lstNameSearch.SelectedItem.Value.ToString + "' insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares,reference)  values ((select top 1 commodity+'/'+grade from wr where ReceiptNo='" + cmbCompany.Text + "'),'" + txtClientId.Text + "',getdate(), getdate(), " + txtavailableQuantity.Text.Replace(",", "") + "*-1,'PLEDGED','ADMIN','0','D','0','" + cmbCompany.Text + "')  insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares,reference)  values ((select top 1 commodity+'/'+grade from wr where ReceiptNo='" + cmbCompany.Text + "'),'PLEDGEACCOUNT',getdate(), getdate(), " + txtavailableQuantity.Text.Replace(",", "") + ",'PLEDGED','ADMIN','0','D','0','" + cmbCompany.Text + "')  update WR set [Status]='PLEDGED' where receiptno='" + cmbCompany.Text + "'  insert into cashtrans ([Description],TransType, Amount, DateCreated, TransStatus, CDS_Number, Paid, Reference, ChargeCode) values ('Bank Overdraft','Bank Overdraft'," + txtapprovedamount.Text.Replace(",", "") + "*-1,getdate(), '1','" + txtClientId.Text + "',NULL,'" + cmbCompany.Text + "','" + lstNameSearch.Value.ToString + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()



            Dim startdate As DateTime = txtEffectiveDate.Text
            Dim enddate As DateTime = Date.UtcNow
            enddate = enddate.AddDays(-1)
            If startdate < enddate Then
                Dim numberofdays As Integer = DateDiff(DateInterval.Day, startdate, enddate)
                For i As Integer = 0 To numberofdays
                    Dim currentDate As DateTime = startdate.AddDays(i)
                    '  msgbox(currentDate)
                    cmd = New SqlCommand("insert into cashtrans ([Description], TransType, Amount, DateCreated, TransStatus, cds_number, reference, chargecode)  select 'Loan Interest','Loan Interest',  (b.AmountApproved*(p.InterestRate/100)/365)*-1, '" + currentDate + "', '1', b.Borrower, b.Collateral, 'LOANINTEREST'+b.Collateral  from BorrowingRequest b, Para_lendingRules p where p.ID='" + cmbfinancier.SelectedItem.Value.ToString + "' and b.Deleted is NULL and b.AmountApproved is not NULL AND B.Rejected IS NULL AND b.Status='PLEDGED' and b.Collateral='" + cmbCompany.Text + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    cmd = New SqlCommand("insert into cashtrans ([Description],TransType, Amount, DateCreated, TransStatus, CDS_Number, Paid, Reference, ChargeCode) select Top 1 chargetype, chargetype, case indicator when '%' then (((PercAmount/100)*" + txtapprovedamount.Text.Replace(",", "") + ")/365)*-1 else PercAmount*-1 end as [Charge],'" + currentDate + "', '1','" + txtClientId.Text + "',NULL, '" + cmbCompany.Text + "',CHARGECODE FROM PARACHARGE where chargetype LIKE '%Pledged EWR Fee%' order by id desc", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next


            End If

            cmd = New SqlCommand("insert into cashtrans ([Description], TransType, Amount, DateCreated, TransStatus, cds_number, reference, chargecode)  select 'Loan Interest','Loan Interest',  (b.AmountApproved*(p.InterestRate/100)/365)*-1, getdate(), '1', b.Borrower, b.Collateral, 'LOANINTEREST'+b.Collateral  from BorrowingRequest b, Para_lendingRules p where p.ID='" + cmbfinancier.SelectedItem.Value.ToString + "' and b.Deleted is NULL and b.AmountApproved is not NULL AND B.Rejected IS NULL AND b.Status='PLEDGED' and b.Collateral='" + cmbCompany.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Approved Pledge amount of " + txtapprovedamount.Text + "", txtClientId.Text, cmbCompany.Text)
            Catch ex As Exception

            End Try



            Session("finish") = "true"
        Response.Redirect(Request.RawUrl)
        Catch ex As Exception
        msgbox(ex.Message)
        End Try
    End Sub
    Public Function getemail(accountno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select email from accounts_clients where cds_number='" + accountno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email").ToString

        End If
    End Function

    Public Sub runasync()
        Try

            cmd = New SqlCommand("insert into BorrowingRequest  select m.csd_number, c.CommodityID, c.PledgedQty, (select top 1 InitialPrice  from testcds_router.dbo.para_company where company=c.CommodityID), getdate(),dateadd(month,m.tenure,m.ApplicationDate), getdate(), m.Tenure, convert(numeric(18,2),M.LoanAmount *p.ServiceCharges/100) as [Service Charge], (m.loanamount/m.tenure)*p.InterestRate/100+(m.loanamount/m.tenure)+ convert(numeric(18,2),M.LoanAmount *p.ServiceCharges/100) AS [TOT] , 'STAN', M.lOANamount,  (m.loanamount/m.tenure)*p.InterestRate/100+(m.loanamount/m.tenure) as [MonthlyInstallment], NULL, NULL, NULL, NULL, NULL, NULL,NULL, NULL,NULL    from CDS_ROUTER.dbo.tblSecuritiesBorrowing_Main m,  [CDS_ROUTER].[dbo].[tblSecuritiesBorrowing_Collateral]  c, cds.dbo.Para_lendingRules p where c.Application_No=m.id and p.Bank='STAN' and ISNULL(m.[Status],0)='0'  update  [CDS_ROUTER].[dbo].tblSecuritiesBorrowing_Main set [Status]='1' WHERE ISNULL([Status],0)='0' ", cn)

        If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub loadinterest(financier As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select FORMAT(InterestRate,'#,0.00') AS InterestRate,FORMAT(ServiceCharges,'#,0.00') as [ServiceCharges]   from para_lendingRules where id='" + financier + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "lenders")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtinterestrate.Text = ds.Tables(0).Rows(0).Item("InterestRate").ToString
            txtservicefee.Text = ds.Tables(0).Rows(0).Item("ServiceCharges").ToString
        End If
    End Sub
    Protected Sub cmbfinancier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfinancier.SelectedIndexChanged
        loadinterest(cmbfinancier.SelectedItem.Value.ToString)
    End Sub
    Protected Sub txtapprovedamount_TextChanged(sender As Object, e As EventArgs) Handles txtapprovedamount.TextChanged
        Dim tot As Decimal = txtapprovedamount.Text
        Dim servchrg As Decimal = txtservicefee.Text
        Dim totamt As Decimal = tot + servchrg
        txttotal.Text = totamt.ToString("N")
    End Sub

    Protected Sub txtservicefee_TextChanged(sender As Object, e As EventArgs) Handles txtservicefee.TextChanged

    End Sub
End Class
