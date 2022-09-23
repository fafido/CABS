Partial Class TransferSec_BorrowersAccept1
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
                msgbox("Successfully Approved! Application sent for final approval ")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  runasync()


                getpending()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub getpending()
        Try
            Dim ds As New DataSet
            Dim xyz As New Common
            If xyz.OTPenabled = True Then
                cmd = New SqlCommand("select 'Account No: '+ Borrower + '  Collateral: '+ Collateral +'  Amount: '+ convert(nvarchar(50),LoanAmount) +'  Option: '+ isnull(OptionName,'') as [LoanDetails], id from BorrowingRequest where ApprovedBY is NULL and rejected Is null  and OTPStatus='Approved' and Participant='" + Session("BrokerCode") + "'", cn)
            Else
                cmd = New SqlCommand("select 'Account No: '+ Borrower + '  Collateral: '+ Collateral +'  Amount: '+ convert(nvarchar(50),LoanAmount) +'  Option: '+ isnull(OptionName,'') as [LoanDetails], id from BorrowingRequest where ApprovedBY is NULL and rejected Is null and Participant='" + Session("BrokerCode") + "'", cn)
            End If

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

    Public Sub GetDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select *,(select company_name from client_companies where company_code=BorrowingRequest.Bank) as fnam from BorrowingRequest where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
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
                Dim AM As Decimal = ds.Tables(0).Rows(0).Item("LoanAmount").ToString
                txtquantity.Text = AM.ToString("N")
                txtshareprice.Text = n.ToString("N")
                txtcollateralvalue.Text = (n * a).ToString("N")
                txtmonthlyinstalment.Text = ds.Tables(0).Rows(0).Item("MonthlyInstalment")
                txttotal.Text = ds.Tables(0).Rows(0).Item("totalpayment").ToString
                Dim servicechrg As Decimal = ds.Tables(0).Rows(0).Item("ServiceCharge").ToString
                txtservicefee.Text = servicechrg.ToString("N")
                txttenure.Text = ds.Tables(0).Rows(0).Item("Tenure").ToString
                txtfinancier.Text = ds.Tables(0).Rows(0).Item("fnam").ToString

                Try
                    Dim m As New NaymatBilling
                    ' Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
                    Dim charge As Double = m.getEWRBAL(cmbCompany.Value.ToString, txtClientId.Text)
                    Dim globcharge As Double = m.getholderbal(txtClientId.Text, Session("BrokerCode"))
                    txtaccumulatedcharges.Text = charge.ToString("N")
                    txtothercharges.Text = globcharge.ToString("N")
                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        GetSelectedDetails()
        GetDetails()


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
    Public Function accountbalance(accountno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0) as [totalowing] from cashtrans where cds_Number='" + accountno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("totalowing").ToString
        Else
            Return 0
        End If
    End Function
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try            '  cmd = New SqlCommand("insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares)  values ('" + cmbCompany.Text + "','" + txtClientId.Text + "',getdate(), getdate(), " + txtavailableQuantity.Text + "*-1,'PLEDGE','ADMIN','0','D','0')  INSERT INTO CDSC.DBO.CashTrans (Description, TransType, Amount, DateCreated , TransStatus , CDS_Number, Paid, Reference )  VALUES ('Loan Disbursement','Loan','" + txtquantity.Text + "',getdate(),'1','" + txtClientId.Text + "','1','" + lstNameSearch.SelectedItem.Value.ToString + "')  INSERT INTO CDSC.DBO.CashTrans (Description, TransType, Amount, DateCreated , TransStatus , CDS_Number, Paid, Reference )  VALUES ('Loan Service Fee','Service Fee','-" + txtservicefee.Text + "',getdate(),'1','" + txtClientId.Text + "','1','" + lstNameSearch.SelectedItem.Value.ToString + "') update BorrowingRequest set Approved='1', ApprovedBy='" + Session("Username") + "' , approvedOn=getdate() where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)

            Dim m As New NaymatBilling
            ' Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
            Dim charge As Double = m.getEWRBAL(cmbCompany.Value.ToString, txtClientId.Text)
            Dim globcharge As Double = m.getholderbal(txtClientId.Text, Session("BrokerCode"))



            cmd = New SqlCommand(" update BorrowingRequest set ApprovedBy='FOR FINAL'  where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Approved Pledge Request", txtClientId.Text, cmbCompany.Text)
            Catch ex As Exception

            End Try

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub runasync()
        'Try
        cmd = New SqlCommand("insert into BorrowingRequest  select m.csd_number, c.CommodityID, c.PledgedQty, (select top 1 InitialPrice  from testcds_router.dbo.para_company where company=c.CommodityID), getdate(),dateadd(month,m.tenure,m.ApplicationDate), getdate(), m.Tenure, convert(numeric(18,2),M.LoanAmount *p.ServiceCharges/100) as [Service Charge], (m.loanamount/m.tenure)*p.InterestRate/100+(m.loanamount/m.tenure)+ convert(numeric(18,2),M.LoanAmount *p.ServiceCharges/100) AS [TOT] , 'STAN', M.lOANamount,  (m.loanamount/m.tenure)*p.InterestRate/100+(m.loanamount/m.tenure) as [MonthlyInstallment], NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL    from CDS_ROUTER.dbo.tblSecuritiesBorrowing_Main m,  [CDS_ROUTER].[dbo].[tblSecuritiesBorrowing_Collateral]  c, cds.dbo.Para_lendingRules p where c.Application_No=m.id and p.Bank='STAN' and ISNULL(m.[Status],0)='0'  update  [CDS_ROUTER].[dbo].tblSecuritiesBorrowing_Main set [Status]='1' WHERE ISNULL([Status],0)='0' ", cn)

        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub
End Class
