Partial Class TransferSec_releaseFIN
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
                msgbox("Pledge Successfully Released! ")
            End If
            If Session("finish") = "true1" Then
                Session("finish") = ""
                msgbox("Request Declined!")
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
            cmd = New SqlCommand("select 'Account No: '+ Borrower + '  Collateral: '+ Collateral +'  Amount: '+ convert(nvarchar(50),LoanAmount) +'  Tenure: '+ convert(nvarchar(50),tenure) as [LoanDetails], id from BorrowingRequest where ApprovedBY is NOT NULL  AND [status]='RELEASE PENDING'", cn)
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
            cmd = New SqlCommand("select * from BorrowingRequest where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim n As Decimal = ds.Tables(0).Rows(0).Item("Unit_Price").ToString
                Dim a As Decimal = ds.Tables(0).Rows(0).Item("AvailableQuantity").ToString
                cmbcompany.Text = ds.Tables(0).Rows(0).Item("Collateral").ToString

                txtavailableQuantity.Text = a.ToString("N")

                txtcapturedate.Text = ds.Tables(0).Rows(0).Item("CapturedDate").ToString
                txtEffectiveDate.Text = ds.Tables(0).Rows(0).Item("EffectiveDate").ToString
                txtExpiryDate.Text = ds.Tables(0).Rows(0).Item("MaturityDate").ToString
                Dim amtapprvd As Decimal = ds.Tables(0).Rows(0).Item("AmountApproved").ToString
                txtquantity.Text = amtapprvd.ToString("N")
                Dim prce As Decimal = ds.Tables(0).Rows(0).Item("Unit_Price").ToString
                txtshareprice.Text = prce.ToString("N")
                txtcollateralvalue.Text = (n * a).ToString("N")
                txtmonthlyinstalment.Text = ds.Tables(0).Rows(0).Item("MonthlyInstalment").ToString
                Dim TT As Decimal = ds.Tables(0).Rows(0).Item("AmountApproved").ToString
                txttotal.Text = TT.ToString("N")

                Dim SRVCFEE As Decimal = ds.Tables(0).Rows(0).Item("ServiceCharge").ToString
                txtservicefee.Text = SRVCFEE.ToString("N")
                txttenure.Text = ds.Tables(0).Rows(0).Item("Tenure").ToString
                txtforeclosuredetail.Text = ds.Tables(0).Rows(0).Item("ForeclosureDetails").ToString
                Dim amtpaid As Decimal = ds.Tables(0).Rows(0).Item("AmountPaid").ToString
                txtamountpaid.Text = amtpaid.ToString("N")
                txtloancharges.Text = (loancharges(cmbcompany.Text, txtClientId.Text) - SRVCFEE).ToString("N")
                txtEWRaccumulated.Text = ewrcharges(cmbcompany.Text, txtClientId.Text).ToString("N")
                Dim loanamt As Decimal = txttotal.Text
                Dim servicefee As Decimal = txtservicefee.Text
                Dim chrges As Decimal = txtloancharges.Text
                Dim total As Decimal = loanamt + chrges + servicefee
                txttotalcharges.Text = total.ToString("N")
                '    txtforeclosuretype.Text = ds.Tables(0).Rows(0).Item("ForeClosureType")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function interestcharge(reference As String, cds_Number As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0)*-1 as amt from cashtrans where TransType='Loan Interest' and reference='" + reference + "' and cds_number='" + cds_Number + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "lenders")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("amt").ToString
        End If

    End Function
    Public Function ewrcharges(reference As String, cds_Number As String) As Decimal

        Dim m As New NaymatBilling
        Return m.getEWRBAL_NO_LOAN(reference, cds_Number)

    End Function
    Public Function loancharges(reference As String, cds_Number As String) As Decimal

        Dim n As New NaymatBilling
        Return n.getEWRBAL_LOANcharges(reference, cds_Number)

    End Function

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
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try

            If txtamountpaid.Text = "" Then
                msgbox("Please enter amount paid!")
                Exit Sub
            End If

            Dim amtpaid As Decimal = txtamountpaid.Text.Replace(",", "")
            Dim tot As Decimal = txttotalcharges.Text.Replace(",", "")
            If amtpaid < tot Then
                msgbox("You cannot pay less than the total payment amount!")
                Exit Sub
            End If

            cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Bank Overdraft - Repayment','Bank Overdraft','" & txttotal.Text.Replace(",", "") & "',GETDATE(),'1','" + txtClientId.Text + "',NULL, '" + cmbcompany.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Loan Charges','Loan Charges','" & txtloancharges.Text.Replace(",", "") & "',GETDATE(),'1','" + txtClientId.Text + "',NULL, '" + cmbcompany.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Loan Service Fee Payment','Service Fee','" & txtservicefee.Text.Replace(",", "") & "',GETDATE(),'1','" + txtClientId.Text + "',NULL, '" + cmbcompany.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()




            '  cmd = New SqlCommand("insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares)  values ('" + cmbCompany.Text + "','" + txtClientId.Text + "',getdate(), getdate(), " + txtavailableQuantity.Text + "*-1,'PLEDGE','ADMIN','0','D','0')  INSERT INTO CDSC.DBO.CashTrans (Description, TransType, Amount, DateCreated , TransStatus , CDS_Number, Paid, Reference )  VALUES ('Loan Disbursement','Loan','" + txtquantity.Text + "',getdate(),'1','" + txtClientId.Text + "','1','" + lstNameSearch.SelectedItem.Value.ToString + "')  INSERT INTO CDSC.DBO.CashTrans (Description, TransType, Amount, DateCreated , TransStatus , CDS_Number, Paid, Reference )  VALUES ('Loan Service Fee','Service Fee','-" + txtservicefee.Text + "',getdate(),'1','" + txtClientId.Text + "','1','" + lstNameSearch.SelectedItem.Value.ToString + "') update BorrowingRequest set Approved='1', ApprovedBy='" + Session("Username") + "' , approvedOn=getdate() where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            cmd = New SqlCommand("insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares,reference)  values ((select top 1 commodity+'/'+grade from wr where ReceiptNo='" + cmbcompany.Text + "'),'" + txtClientId.Text + "',getdate(), getdate(), " + txtavailableQuantity.Text.Replace(",", "") + "*1,'PLEDGE RELEASED','ADMIN','0','D','0','" + cmbcompany.Text + "')  insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares,reference)  values ((select top 1 commodity+'/'+grade from wr where ReceiptNo='" + cmbcompany.Text + "'),'PLEDGEACCOUNT',getdate(), getdate(), " + txtavailableQuantity.Text.Replace(",", "") + "*-1,'PLEDGE RELEASE','ADMIN','0','D','0','" + cmbcompany.Text + "')   UPDATE wr set [status]='ISSUED' where  receiptno='" + cmbcompany.Text + "' update BorrowingRequest set [STATUS]='RELEASED'  where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Approved a pledge call request", txtClientId.Text, cmbcompany.Text)
            Catch ex As Exception

            End Try

            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Try

            cmd = New SqlCommand("update BorrowingRequest set [STATUS]='PLEDGED'  where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Declined a pledge call request", txtClientId.Text, cmbcompany.Text)
            Catch ex As Exception

            End Try


            Session("finish") = "true1"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
