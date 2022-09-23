Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_BorrowersRequest
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
    Public Sub loadtenure(max As Integer)
        For i As Integer = 1 To 36
            cmbtenure.Items.Add(i.ToString + " Months", i.ToString)
        Next
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


    Public Sub GetCompany(holder As String)
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select * from WR where holder='" + holder + "' and [Status]='ISSUED' and quantity>0 and receiptno not in (select receiptid from pendingtrans) AND warehouse='" + Session("BrokerCode") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = dsport

                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox("Error extracting receipts for holder : " + ex.Message)
        End Try
    End Sub
    Public Function compname(id As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select commodity+'/'+grade as comp from wr where receiptNo='" + id.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "trans")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("comp")
        End If
    End Function
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
                ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
                ASPxPopupControl1.AllowDragging = True
                ASPxPopupControl1.ShowCloseButton = True
                ASPxPopupControl1.ShowOnPageLoad = True
                Page.MaintainScrollPositionOnPostBack = True
                lbltransid.Text = transid.ToString

                msgbox("Successfully captured! Please enter OTP for request to proceed.")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  GetLenders()
                '  loadterms()
                loadtenure(36)
                loadoptions()


                Dim xyz As New Common
                If xyz.OTPenabled = True Then
                    LoadOTPtrans()
                Else


                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (cds_number+' '+forenames+' '+surname) as namess, CDS_NUMBER from Accounts_Clients where forenames+' '+surname like '%" & txtNameSearch.Text & "%' AND AccountState='A' order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "CDS_NUMBER"
                lstNameSearch.TextField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+forenames+' '+surname='" & lstNameSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtClientId.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtSurname.Text = "" + ds.Tables(0).Rows(0).Item("surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString + ""

                txtIdno.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        cmbCompany.Items.Clear()
        cmbCompany.Value = ""
        txtavailableQuantity.Text = ""
        GetSelectedDetails()
        GetCompany(txtClientId.Text)

    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Try

            If ASPxButton8.Text = "Load Lenders" Then
                Dim ds As New DataSet

                Dim reqamount As Long = txtquantity.Text
                Dim maxamount As Long = txtcollateralvalue.Text

                If reqamount > maxamount Then
                    msgbox("Collateral value is below the value of the the required amount therefor cannot continue")
                    Exit Sub
                Else
                    ' msgbox("in")
                    ' Exit Sub
                    cmd = New SqlCommand("select distinct c.company_name, p.bank from Para_lendingRules p, Client_Companies c where p.bank=c.Company_Code ", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "lenders")
                    If (ds.Tables(0).Rows.Count > 0) Then

                        'ASPxGridView1.DataSource = ds
                        'ASPxGridView1.DataBind()
                        cmbfinancier.DataSource = ds
                        cmbfinancier.TextField = "company_name"
                        cmbfinancier.ValueField = "bank"
                        cmbfinancier.DataBind()


                    Else
                        msgbox("No match found!")
                    End If
                End If
            Else
                Response.Redirect(Request.RawUrl)
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try






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

    Public Sub loadterms()
        Dim ds As New DataSet
        cmd = New SqlCommand("select InterestRate, ServiceCharges, LendingPeriod as [Max Tenure], MiniAmount as [Min Amount], MaxiAmount as [Max Amount], Bank from Para_LendingRules", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()

        End If
    End Sub
    Public Sub loadtermswithhaircut(amount As String)
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select InterestRate, ServiceCharges, LendingPeriod as [Max Tenure], MiniAmount as [Min Amount], MaxiAmount as [Max Amount], Bank, Haircut/100*" + amount + " as [Your Max Limit] from Para_LendingRules", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = ds1
            ASPxGridView2.DataBind()

        End If
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (cds_number+' '+forenames+' '+surname) as namess from Accounts_Clients where cds_number like '%" & txtcds_number_search.Text & "%' and brokercode='" + Session("brokercode") + "' and cds_number not in (select borrowercdsNo from lendingpool) AND AccountState='A' ORDER BY CDS_NUMBER", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "namess"
                lstNameSearch.TextField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Sub cmbCompany_ValueChanged(sender As Object, e As EventArgs) Handles cmbCompany.ValueChanged
        GetCompany(txtClientId.Text)
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select FORMAT(isnull(sum(QUANTITY),0),'#,0.00') as totquantity from WR where RECEIPTNO='" + cmbCompany.Value.ToString + "' and Holder='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtavailableQuantity.Text = ds.Tables(0).Rows(0).Item("totquantity").ToString
            Else
                txtavailableQuantity.Text = "0"
            End If
            Dim cmprice As Decimal = getcommprice(cmbCompany.Value.ToString)
            txtshareprice.Text = cmprice.ToString("N")

            Dim price As Decimal = txtshareprice.Text
            Dim quantity As Decimal = txtavailableQuantity.Text
            Dim value As Decimal = price * quantity
            txtcollateralvalue.Text = value.ToString("N")

            Dim m As New NaymatBilling
            ' Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
            Dim charge As Double = m.getEWRBAL(cmbCompany.Value.ToString, txtClientId.Text)
            Dim globcharge As Double = m.getholderbal(txtClientId.Text, Session("BrokerCode"))
            txtaccumulatedcharges.Text = charge.ToString("N")
            txtothercharges.Text = globcharge.ToString("N")
            ' txttransactioncharges.Text = transcharge.ToString

            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            loadtermswithhaircut(txtcollateralvalue.Text)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Function getcommprice(receiptno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select initialprice as price from para_company where company=(select top 1 commodity+'/'+grade from wr where ReceiptNo='" + receiptno + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Price").ToString
        Else
            Return "1"

        End If
    End Function
    Public Shared Function CreateOTP(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Public Function getemail(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select email from accounts_clients where cds_Number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email").ToString
        Else
            Return ""
        End If
    End Function
    Public Function pendingbalance(receipt As String) As String
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select status from pendingtrans where receiptid='" + receipt + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "names")
        If (ds1.Tables(0).Rows.Count > 0) Then
            Return ds1.Tables(0).Rows(0).Item("status").ToString
        Else
            Return ""
        End If
    End Function
    Public Sub loadoptions()
        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct c.company_name, p.bank from Para_lendingRules p, Client_Companies c where p.bank=c.Company_Code ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbfinancier.DataSource = ds
            cmbfinancier.TextField = "company_name"
            cmbfinancier.ValueField = "bank"
            cmbfinancier.DataBind()

        End If
    End Sub
    Public Function transid() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select max(id) as id from BorrowingRequest where Participant='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("id").ToString
        Else
            Return ""
        End If
    End Function
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        '   Try

        If pendingbalance(cmbCompany.Value.ToString) <> "" Then
            msgbox(pendingbalance(cmbCompany.Value.ToString))
            Exit Sub


        End If

        'Dim maxi As Decimal = txtmaxfinancing.Text
        'Dim reqamt As Decimal = txtquantity.Text

        'If reqamt > maxi Then
        '    msgbox("Max financing amount exceeded")
        '    Exit Sub
        'End If


        Dim xyz As New Common
            If xyz.OTPenabled = True Then
                Dim OTP As String = CreateOTP(4)
                Dim z As New sendmail
                Try
                    z.sendmail(getemail(txtClientId.Text).ToString, "Pledge Authorization Request", "A Pledge on EWR No. " + cmbCompany.Value.ToString + "  has been initiated in your account. Please authorize using OTP: " + OTP + "")
                Catch ex As Exception
                    msgbox("Error Sending Email:" + ex.Message + "")
                End Try

            cmd = New SqlCommand("declare @amountrequired money=" + txtquantity.Text.Replace(",", "") + " declare @tenure numeric(18,0)=0   declare @collateralvalue money=" + txtcollateralvalue.Text.Replace(",", "") + "   insert into BorrowingRequest (OptionName,Interest_Interval, Borrower, Collateral, AvailableQuantity, Unit_Price, EffectiveDate, MaturityDate, CapturedDate, Tenure, ServiceCharge, TotalPayment, Bank, LoanAmount, MonthlyInstalment, OTP, OTPSent, OTPCreateTime, Participant)  values  ('','','" + txtClientId.Text + "', '" + cmbCompany.Value.ToString + "','" + txtavailableQuantity.Text + "','" + txtshareprice.Text.Replace(",", "") + "',NULL,NULL,getdate(),@tenure, '0',  NULL, '" + cmbfinancier.SelectedItem.Value.ToString + "','" + txtquantity.Text + "' ,'0','" + OTP + "','1',getdate(),'" + Session("BrokerCode") + "')", cn)
        Else
            cmd = New SqlCommand("declare @amountrequired money=" + txtquantity.Text.Replace(",", "") + " declare @tenure numeric(18,0)=0   declare @collateralvalue money=" + txtcollateralvalue.Text.Replace(",", "") + "   insert into BorrowingRequest (OptionName,Interest_Interval, Borrower, Collateral, AvailableQuantity, Unit_Price, EffectiveDate, MaturityDate, CapturedDate, Tenure, ServiceCharge, TotalPayment, Bank, LoanAmount, MonthlyInstalment, Participant)  values  ('','','" + txtClientId.Text + "', '" + cmbCompany.Value.ToString + "','" + txtavailableQuantity.Text + "','" + txtshareprice.Text.Replace(",", "") + "',NULL,NULL,getdate(),@tenure, '0',  NULL, '" + cmbfinancier.SelectedItem.Value.ToString + "','" + txtquantity.Text + "' ,'0','" + Session("BrokerCode") + "')", cn)
        End If



            ' cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('Permission added for " + cmbParticipants.SelectedItem.Text + ". Permission is " + Gridview1.SelectedRow.Cells(0).Text + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','Pemission Added')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
        cn.Close()

        Try
            Dim a As New passmanagement
            a.auditlog(Session("BrokerCode"), Session("Username"), "Submmited a pledge request of " + txtquantity.Text + "", txtClientId.Text, cmbCompany.Text)
        Catch ex As Exception

        End Try


        Session("finish") = "true"
        Session("pop") = transid.ToString

        Response.Redirect(Request.RawUrl)

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub cmbtenure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtenure.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select convert(date, dateadd(month, " + cmbtenure.SelectedItem.Value.ToString + ", '" + txtEffectiveDate.Text + "')) as [maturitydate]", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtExpiryDate.Text = ds.Tables(0).Rows(0).Item("maturitydate")
        End If
    End Sub

    Public Sub LoadOTPtrans()
        Dim ds As New DataSet
        cmd = New SqlCommand("Select id,Borrower, Collateral, FORMAT(AvailableQuantity,'#,0.00') AS AvailableQuantity ,FORMAT(LoanAmount,'#,0.00') AS LoanAmount , Tenure, MonthlyInstalment,  CapturedDate, ServiceCharge from BorrowingRequest where Participant='" + Session("BrokerCode") + "' and Deleted is NULL and OTPStatus IS NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdOTP.DataSource = ds
            grdOTP.DataBind()
        Else
            grdOTP.DataSource = ds
            grdOTP.DataBind()
        End If
    End Sub
    Public Function getotp(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTP,'') as OTP from BorrowingRequest where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("OTP").ToString
        End If
    End Function

    Private Sub grdOTP_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdOTP.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "OTP" Then

            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True
            lbltransid.Text = id.ToString



        End If
    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        If txtotp.Text = "" Then
            msgbox("Please enter OTP")
            Exit Sub
        End If
        If getotp(lbltransid.Text) <> txtotp.Text Then
            msgbox("Invalid OTP!")
            Exit Sub

        ElseIf getotp(lbltransid.Text) = txtotp.Text Then
            cmd = New SqlCommand("update BorrowingRequest set OTPStatus='Approved', OTPResponseTime=getdate()   where id='" + lbltransid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            ASPxPopupControl1.AllowDragging = False
            ASPxPopupControl1.ShowCloseButton = False
            ASPxPopupControl1.ShowOnPageLoad = False
            Page.MaintainScrollPositionOnPostBack = False
            LoadOTPtrans()


            msgbox("OTP Correct! Pledge sent for approval")


        Else
            msgbox("Failed")
        End If

    End Sub
    Protected Sub cmbfinancier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfinancier.SelectedIndexChanged
        'txtmaxfinancing.Text = gethaircut(cmbfinancier.SelectedItem.Value.ToString)
    End Sub
    Public Function gethaircut(ref As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select convert(numeric(18,2),(100-haircut)/100*" + txtcollateralvalue.Text + ") as tt from Para_lendingRules where id='" + ref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("tt").ToString
        End If
    End Function
    Protected Sub txtshareprice_TextChanged(sender As Object, e As EventArgs) Handles txtshareprice.TextChanged
        Dim prce As Decimal = txtshareprice.Text
        Dim qty As Decimal = txtavailableQuantity.Text
        Dim val As Decimal = prce * qty
        txtcollateralvalue.Text = val.ToString

    End Sub
End Class
