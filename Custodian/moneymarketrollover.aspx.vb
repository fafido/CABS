Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_moneymarketrollover

    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter

    Dim cmd As SqlCommand
    Public autgen As String
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
            If Session("finish") = "yes" Then
                Session("finish") = ""



                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "resubmit" Then
                Session("finish") = ""


                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "Rollover" Then
                Session("finish") = ""


                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                ' loadcompanies()
                getcurrencies()
                getpendingmoneymarket()
                getbanks()
                getrejectedmoneymarket()
                getcommitted()
                dtmaturitydate.MinDate = Date.UtcNow
                dtsettlementdate.MinDate = Date.UtcNow.AddDays(-1)
                dttradedate.MaxDate = Date.UtcNow

            Else
                '   loadcomboforreceipts(txtewrholder.Text)
            End If
            getpendingmoneymarket()
            getrejectedmoneymarket()
            getcommitted()
            '    loadcomboforreceipts(txtewrholder.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Sub updatewithRef(autog As String, newref As String, typetrans As String)
        cmd = New SqlCommand("update Transaction_Documents set TransactionRef='" + newref + "' where TransactionRef='" + autog + "' and TransactionType='" + typetrans + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub


    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Try

            If ASPxButton13.Text = "Save" Then

                If refexists(txtereference.Text) = True Then
                    msgbox("Reference already exists!")
                    Exit Sub
                End If

                Dim xyz As New Common



                cmd = New SqlCommand("insert into MoneyMarket (TradeRef, TradeDate, SettlementDate, [Description], Amount, SettlementAmount, ClientNo,  AssetManager, TradeCharges, CapturedBy, CapturedDate, TradeStatus,TradeType, Currency,[interest_Type] ,[FixedRate] ,[DayCountBasis],[PaymentFrequency],[Tax], [MaturityDate], CounterPartBank, AccountNo, AccountName, TradeCharge, SettlementCurrency, MaturityValue, ExchangeRate)  values ('" + txtereference.Text + "','" + dttradedate.Text + "','" + dtsettlementdate.Text + "','" + txtdescription.Text + "','" + txtamount.Text + "', '" + txtsettlementamount.Text + "', '" + txtewraccountno.Text + "','" + cmbassetmanager.SelectedItem.Value.ToString + "','0','" + Session("Username") + "',getdate(), 'OUTSTANDING','" + cmbordertype.SelectedItem.Text + "','" + cmbcurrency.SelectedItem.Value + "','" + cmbinteresttype.SelectedItem.Text + "','" + txtfixedrate.Text + "','" + cmbdaycount.SelectedItem.Text + "','" + cmbpaymentfrequency.SelectedItem.Text + "','" + txttax.Text + "','" + dtmaturitydate.Text + "','" + cmbbank.SelectedItem.Value.ToString + "','" + txtAccountNo.Text + "','" + txtAccountName.Text + "','" + txttranscharge.Text + "','" + cmbcurrencysett.SelectedItem.Value + "','" + txtmaturityvalue.Text + "','" + txtexchangerate.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



                updatewithRef(Session("autogen"), transid.ToString, "MONEY MARKET")


                Try
                    Dim a As New passmanagement
                    a.auditlog(Session("BrokerCode"), Session("Username"), "Submitted a Withdrawal Request", txtewraccountno.Text, cmbinteresttype.Text)
                Catch ex As Exception

                End Try

                Session("finish") = "yes"
                Session("mymy") = transid.ToString
                Session("msg") = "Trade has been successfully captured for " + cmbinteresttype.Value.ToString + " .Transaction ID is " + transid.ToString + "."
                Response.Redirect(Request.RawUrl)


            ElseIf ASPxButton13.Text = "Update" Then


                'cmd = New SqlCommand("update MoneyMarket set ExchangeRate='" + txtexchangerate.Text + "', TradeRef='" + txtereference.Text + "', TradeDate='" + dttradedate.Text + "', SettlementDate='" + dtsettlementdate.Text + "', [Description]='" + txtdescription.Text + "', Amount='" + txtamount.Text + "', SettlementAmount='" + txtsettlementamount.Text + "', ClientNo='" + txtewraccountno.Text + "',  AssetManager='" + cmbassetmanager.SelectedItem.Value.ToString + "', TradeType='" + cmbordertype.SelectedItem.Text + "', Currency='" + cmbcurrency.SelectedItem.Value + "',[interest_Type]='" + cmbinteresttype.SelectedItem.Text + "' ,[FixedRate]='" + txtfixedrate.Text + "' ,[DayCountBasis]='" + cmbdaycount.SelectedItem.Text + "',[PaymentFrequency]='" + cmbpaymentfrequency.SelectedItem.Text + "',[Tax]='" + txttax.Text + "', [MaturityDate]='" + dtmaturitydate.Text + "', CounterPartBank='" + cmbbank.SelectedItem.Value.ToString + "', AccountNo='" + txtAccountNo.Text + "', AccountName='" + txtAccountName.Text + "', TradeCharge='" + txttranscharge.Text + "', SettlementCurrency='" + cmbcurrencysett.SelectedItem.Value + "', MaturityValue='" + txtmaturityvalue.Text + "' where id='" + lblid.Text + "'", cn)
                'If (cn.State = ConnectionState.Open) Then
                '    cn.Close()
                'End If
                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()
                'Session("finish") = "resubmit"
                'Session("msg") = "Money Market Transaction has been successfully updated."
                'Response.Redirect(Request.RawUrl)

            ElseIf ASPxButton13.Text = "Update & Re-Submit" Then


                cmd = New SqlCommand("update MoneyMarketRollover set  Rejected=NULL, RejectionReason=NULL, RejectedDate=NULL where traderef='" + lblid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "resubmit"
                Session("msg") = "Money Market Transaction has been successfully updated and re-submitted."
                Response.Redirect(Request.RawUrl)

            ElseIf ASPxButton13.Text = "Submit Rollover" Then

                Dim currentamount As Decimal = lblcurrentamount.Text
                Dim interestamt As Decimal = txtcallbackamount.Text



                Dim redamount As Decimal = txtcurrentvalue.Text

                If redamount > currentamount Then
                    msgbox("You cannot redeem amount more than the Amount invested!")
                    Exit Sub
                End If
                If redamount <= 0 Then
                    msgbox("You cannot redeem amount less than or equal to 0!")
                    Exit Sub
                End If
                cmd = New SqlCommand("  insert into MoneyMarketRollover (TradeRef, Amount, DateCreated,CreatedBy, ClientNo, OriginalAmount, CurrentAmount, RolloverInterest, RolloverAmount, BeginDate, NoOfDays, MaturityDate, NewInterest, NewMaturityValue) values ('" + lblid.Text + "','" + txtcurrentvalue.Text + "',getdate(), '" + Session("Username") + "','" + txtewraccountno.Text + "','" + txtamount.Text + "','" + lblcurrentamount.Text + "','" + txtcallbackamount.Text + "','" + txtcurrentvalue.Text + "','" + dtnewtradedate.Date.ToString + "','" + txtnewnumberofdays.Text + "','" + dtnewmaturitydate.Date.ToString + "','" + txtnewinterest.Text + "','" + txtnewmaturityvalue.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "Rollover"
                Session("msg") = "Money Market Rollover Transaction has been successfully sent for approval!"
                Response.Redirect(Request.RawUrl)

            End If
        Catch ex As Exception
            msgbox("Please select the relevant Account to capture Money Market! Numerical fields should also be numeric")
        End Try

    End Sub
    Public Function refexists(ref As String) As Boolean

        Dim ds As New DataSet
        cmd = New SqlCommand("select TradeRef from custodian_trades where TradeRef='" + ref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
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
    Public Function transid() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select max(id) as id from MoneyMarket", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("id").ToString
        Else
            Return ""
        End If
    End Function

    Public Sub getcommitted()

        Dim ds As New DataSet
        cmd = New SqlCommand(" select *, a.surname+' '+a.forenames as ClientName,(select Amount from MoneyMarketRollover where TradeRef=m.id) as CallbackAmount from MoneyMarket m, Accounts_clients a where m.ApprovedBy is NOT NULL and m.rejected is NULL and a.cds_number=m.clientNo and m.id in (select traderef from MoneyMarketRollover where ApprovedBy is NOT NULL and Rejected is NULL)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            AspxGridview5.DataSource = ds
            AspxGridview5.DataBind()
        Else
            AspxGridview5.DataSource = Nothing
            AspxGridview5.DataBind()
        End If
    End Sub
    Public Sub getpendingmoneymarket()

        Dim ds As New DataSet
        cmd = New SqlCommand(" select *, a.surname+' '+a.forenames as ClientName, (select Amount from MoneyMarketRollover where TradeRef=m.id) as CallbackAmount from MoneyMarket m, Accounts_clients a where m.ApprovedBy is NOT NULL and m.rejected is NULL and a.cds_number=m.clientNo and m.id in (select traderef from MoneyMarketRollover where ApprovedBy is NULL and Rejected is NULL)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            AspxGridview4.DataSource = ds
            AspxGridview4.DataBind()
        Else
            AspxGridview4.DataSource = Nothing
            AspxGridview4.DataBind()
        End If
    End Sub
    Public Sub getrejectedmoneymarket()

        Dim ds As New DataSet
        cmd = New SqlCommand(" select *, a.surname+' '+a.forenames as ClientName,(select Amount from MoneyMarketRollover where TradeRef=m.id) as CallbackAmount from MoneyMarket m, Accounts_clients a where m.ApprovedBy is NOT NULL and a.cds_number=m.clientNo and m.id in (select traderef from MoneyMarketRollover where ApprovedBy is NULL and Rejected is NOT NULL)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            AspxGridview6.DataSource = ds
            AspxGridview6.DataBind()
        Else
            AspxGridview6.DataSource = Nothing
            AspxGridview6.DataBind()
        End If
    End Sub
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



    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        'If txtclientnumber0.Text = "" Then
        '    msgbox("Please enter Account No./Name to search")
        '    Exit Sub
        'End If

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(forenames,'')+' '+isnull(middlename,'')+' '+isnull(surname,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' and AccountState='A' order by cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()

        End If
    End Sub

    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinteresttype.SelectedIndexChanged
        Dim dsport As New DataSet
        cmd = New SqlCommand("select quantity as available from wr where receiptno='" + cmbinteresttype.Value.ToString + "' and holder='" + txtewraccountno.Text + "' and quantity>0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            'txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString
            'txtprice.Text = dsport.Tables("trans").Rows(0).Item("available").ToString

            Dim m As New NaymatBilling
            Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtsettlementamount.Text, ListBox1.SelectedValue.ToString, cmbinteresttype.Value.ToString)
            Dim charge As Double = m.getEWRBAL(cmbinteresttype.Value.ToString, ListBox1.SelectedValue.ToString)
            Dim globcharge As Double = m.getholderbal(ListBox1.SelectedValue.ToString, Session("BrokerCode"))
            ' txtcharge.Text = charge
            txttotalcharges.Text = globcharge
            'txttranscharge.Text = transcharge
            Session("autogen") = CreateRandomPassword(20)
        Else

            '   txtavailableshares.Text = 0
            '  txtprice.Text = 0
        End If






    End Sub


    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name  from Accounts_Clients a, Client_Companies c where  a.cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
        ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names1")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            txtewraccountno.Text = ListBox1.SelectedValue.ToString

            ' txtavailableshares.Text = 0
            ' txtprice.Text = 0
            loadcomboforassetmanagers(ListBox1.SelectedValue.ToString)
            getcallbackmoneymarket(ListBox1.SelectedValue.ToString)
            Session("autogen") = CreateRandomPassword(20)

        End If
    End Sub
    Public Sub loadcompanies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_company", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbinteresttype.DataSource = dsport
            cmbinteresttype.TextField = "fnam"
            cmbinteresttype.ValueField = "company"
            cmbinteresttype.DataBind()
        End If
    End Sub
    Public Sub getbanks()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_bank", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbbank.DataSource = dsport
            cmbbank.TextField = "bank_name"
            cmbbank.ValueField = "bank"
            cmbbank.DataBind()

        End If
    End Sub
    Public Sub getcurrencies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_currencies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbcurrency.DataSource = dsport
            cmbcurrency.TextField = "currencycode"
            cmbcurrency.ValueField = "currencycode"
            cmbcurrency.DataBind()


            cmbcurrencysett.DataSource = dsport
            cmbcurrencysett.TextField = "currencycode"
            cmbcurrencysett.ValueField = "currencycode"
            cmbcurrencysett.DataBind()

        End If
    End Sub
    Public Sub loadcomboforassetmanagers(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select c.AssetManager as code, p.AssetMananger from client_AssetManagers c, para_AssetManager p where clientNo='" + holder + "' and p.AssetManagerCode=c.AssetManager", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbassetmanager.DataSource = dsport
            cmbassetmanager.TextField = "AssetMananger"
            cmbassetmanager.ValueField = "code"
            cmbassetmanager.DataBind()

        End If
    End Sub
    Public Sub getcallbackmoneymarket(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select id , [Description]+' '+convert(nvarchar(50),Amount)+' '+AssetManager+' '+isnull(Currency,'')+' '+interest_Type as descr from moneymarket where  TradeStatus='ON-GOING' AND ClientNo='" + holder + "' and id not in (  select TradeRef from MoneyMarketRollover where rejected is NULL and Approved is NULL)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbmoneymarket.DataSource = dsport
            cmbmoneymarket.TextField = "descr"
            cmbmoneymarket.ValueField = "id"
            cmbmoneymarket.DataBind()

        End If
    End Sub
    Public Function partname(code As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Company_name from client_companies where Company_Code='" + code + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("company_name")
        End If
    End Function




    Private Sub ASPxGridView4_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles AspxGridview4.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getdetails(id, "Update")
        End If

    End Sub
    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles AspxGridview5.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getdetails(id, "Update")
            ASPxButton13.Visible = False

        End If

    End Sub
    Private Sub ASPxGridView6_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles AspxGridview6.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getdetails(id, "Update & Re-Submit")

        End If

    End Sub
    Public Sub getdetails(id As String, transtype As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *,datediff(day, tradeDate, MaturityDate) as days from MoneyMarket c, Accounts_Clients a where c.ClientNo=a.CDS_Number and c.id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ' txtAccountNo.Text = dsport.Tables(0).Rows(0).Item("ParticipantCode").ToString
            ' txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString
            txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("clientno").ToString
            loadcomboforassetmanagers(txtewraccountno.Text)
            txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Surname").ToString + "  " + dsport.Tables(0).Rows(0).Item("Forenames").ToString
            txtdescription.Text = dsport.Tables(0).Rows(0).Item("Description").ToString
            cmbinteresttype.Value = dsport.Tables(0).Rows(0).Item("Interest_Type").ToString
            '  cmbparaCompany.Value = dsport.Tables(0).Rows(0).Item("company").ToString
            '  txtprice.Text = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString

            txtamount.Text = dsport.Tables(0).Rows(0).Item("Amount").ToString
            txtexchangerate.Text = dsport.Tables(0).Rows(0).Item("ExchangeRate").ToString
            cmbassetmanager.Value = dsport.Tables(0).Rows(0).Item("AssetManager").ToString
            cmbcurrency.Value = dsport.Tables(0).Rows(0).Item("currency").ToString
            cmbcurrencysett.Value = dsport.Tables(0).Rows(0).Item("SettlementCurrency").ToString
            txtnumberofdays.Text = dsport.Tables(0).Rows(0).Item("days").ToString
            cmbordertype.Value = dsport.Tables(0).Rows(0).Item("TradeType").ToString
            txtereference.Text = dsport.Tables(0).Rows(0).Item("TradeRef").ToString
            cmbdaycount.Value = dsport.Tables(0).Rows(0).Item("DayCountBasis").ToString
            cmbpaymentfrequency.Value = dsport.Tables(0).Rows(0).Item("PaymentFrequency").ToString
            dtmaturitydate.Date = dsport.Tables(0).Rows(0).Item("MaturityDate").ToString
            txttax.Text = dsport.Tables(0).Rows(0).Item("tax").ToString
            cmbbank.Value = dsport.Tables(0).Rows(0).Item("CounterPartBank").ToString
            txtaccountnumber.Text = dsport.Tables(0).Rows(0).Item("AccountNo").ToString
            txtAccountName.Text = dsport.Tables(0).Rows(0).Item("AccountName").ToString
            '   txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("Units").ToString
            '  txtprice.Text = dsport.Tables(0).Rows(0).Item("price").ToString
            txtfixedrate.Text = dsport.Tables(0).Rows(0).Item("FixedRate").ToString
            dttradedate.Date = dsport.Tables(0).Rows(0).Item("TradeDate").ToString
            dtsettlementdate.Date = dsport.Tables(0).Rows(0).Item("SettlementDate").ToString
            txttranscharge.Text = dsport.Tables(0).Rows(0).Item("TradeCharge").ToString
            txtsettlementamount.Text = dsport.Tables(0).Rows(0).Item("SettlementAmount").ToString
            txtmaturityvalue.Text = dsport.Tables(0).Rows(0).Item("MaturityValue").ToString
            ASPxButton13.Text = transtype
            lblid.Text = id.ToString
            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
            getdocuments(id.ToString, "MONEY MARKET")

            Dim rate As Decimal = txtfixedrate.Text
            Dim amount As Decimal = txtamount.Text
            Dim numberofdays As Decimal = DateDiff(DateInterval.Day, dttradedate.Date, Date.UtcNow)
            Dim dailyrate, totalgain, maturityamount As Decimal
            If cmbdaycount.SelectedItem.Text = "actual/360" Then
                dailyrate = rate / 360
                totalgain = dailyrate * numberofdays
                maturityamount = (totalgain / 100 * amount) + amount
            ElseIf cmbdaycount.SelectedItem.Text = "actual/365" Then
                dailyrate = rate / 365
                totalgain = dailyrate * numberofdays
                maturityamount = (totalgain / 100 * amount) + amount
            End If



            txtcurrentvalue.Text = txtmaturityvalue.Text
            lblcurrentamount.Text = txtmaturityvalue.Text
        End If


    End Sub
    Public Function getotp(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTP,'') as OTP from withdrawals where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("OTP").ToString
        End If
    End Function
    Public Function OTPApproved(id As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTPStatus,'') as [status] from withdrawals where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            If dsport.Tables(0).Rows(0).Item("status").ToString = "Approved" Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function


    Public Sub reversertransaction(id As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select EWR_holder, ReceiptID, amount_to_withdraw  FROM withdrawals where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Dim holder As String = dsport.Tables(0).Rows(0).Item("EWR_holder").ToString
            Dim receiptno As String = dsport.Tables(0).Rows(0).Item("ReceiptID").ToString
            Dim quant As String = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString

            Try
                Dim m As New NaymatBilling
                Dim charge As Double = m.withdrawalcharges_REVERSAL("BILL", "DEPOSITOR", quant, holder, receiptno)
                '  txtcharge.Text = charge
            Catch ex As Exception
                msgbox("Error Reversal Charging: " + ex.Message)
            End Try
        End If

    End Sub
    Public Function deletable(idn As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from  withdrawals where ApprovedBy is NULL and id='" + idn + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub flagdelete(ref As String)
        cmd = New SqlCommand("update withdrawals set deleted='1'  where id='" + ref + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub


    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click

        'Document Upload

        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty

        If filePath = "" Then
            msgbox("Please select document to upload!")
            Exit Sub
        End If
        Dim fs As Stream = FileUpload1.PostedFile.InputStream
        Dim br As New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(fs.Length)

        Dim m As New Common

        If m.Document_Upload(fs, filePath, txtdocumentname.Text, ext, filename, "MONEY MARKET", txtewraccountno.Text, Session("autogen"), bytes).ToString <> "Upload Successful" Then
            msgbox("Document Upload failed!")
            Exit Sub
        Else
            getdocuments(Session("autogen"), "MONEY MARKET")
            msgbox("Document Uploaded")
        End If

    End Sub
    Public Sub getdocuments(ref As String, transtyp As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Transaction_Documents where transactionref='" + ref + "' and TransactionType='" + transtyp + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grddocuments.DataSource = dsport
            grddocuments.DataBind()
        Else
            grddocuments.DataSource = Nothing
            grddocuments.DataBind()
        End If
    End Sub
    Public Sub deletedocument(newref As String, transtyp As String)
        cmd = New SqlCommand("delete from  Transaction_Documents where TransactionRef='" + newref + "' and TransactionType='" + transtyp + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
    Public Sub pd(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Function apptype(type As String) As String
        If type = ".png" Then
            Return "Aplication/vnd.png"
        ElseIf type = ".doc" Or type = ".docx" Then
            Return "Aplication/vnd.ms-word"
        ElseIf type = ".xlsx" Or type = ".xls" Then
            Return "Aplication/vnd.ms-excel"
        ElseIf type = ".jpg" Or type = ".jpeg" Then
            Return "Aplication/vnd.jpg"
        ElseIf type = ".gif" Then
            Return "Aplication/vnd.gif"
        End If
    End Function
    Protected Sub download(ByVal dt As DataTable)
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = apptype(dt.Rows(0)("Extension").ToString())
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("nm").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub
    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then

            Try
                pd(Session("autogen"), "MONEY MARKET")
            Catch ex As Exception
            End Try
            Try
                word(Session("autogen"), "MONEY MARKET")
            Catch ex As Exception
            End Try
            Try
                xls(Session("autogen"), "MONEY MARKET")
            Catch ex As Exception
            End Try
            Try
                Img(Session("autogen"), "MONEY MARKET")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            deletedocument(Session("autogen"), "MONEY MARKET")
            getdocuments(Session("autogen"), "MONEY MARKET")
        End If
    End Sub
    Protected Sub cmbbank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbank.SelectedIndexChanged
        txtdescription.Text = cmbbank.SelectedItem.Value.ToString + " @ " + txtfixedrate.Text + "% P.A " + dtmaturitydate.Date + ""
        Dim rate As Decimal = txtfixedrate.Text
        Dim amount As Decimal = txtamount.Text
        Dim numberofdays As Decimal = txtnumberofdays.Text
        Dim dailyrate, totalgain, maturityamount As Decimal
        If cmbdaycount.SelectedItem.Text = "actual/360" Then
            dailyrate = rate / 360
            totalgain = dailyrate * numberofdays
            maturityamount = (totalgain / 100 * amount) + amount
        ElseIf cmbdaycount.SelectedItem.Text = "actual/365" Then
            dailyrate = rate / 365
            totalgain = dailyrate * numberofdays
            maturityamount = (totalgain / 100 * amount) + amount
        End If



        txtmaturityvalue.Text = maturityamount
    End Sub


    Protected Sub txtnumberofdays_TextChanged(sender As Object, e As EventArgs) Handles txtnumberofdays.TextChanged
        Dim numberdays As Decimal = txtnumberofdays.Text
        dtmaturitydate.Date = DateAdd(DateInterval.Day, numberdays, dttradedate.Date)

    End Sub


    Protected Sub dttradedate_DateChanged(sender As Object, e As EventArgs) Handles dttradedate.DateChanged

    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub cmbdaycount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdaycount.SelectedIndexChanged
        Dim rate As Decimal = txtfixedrate.Text
        Dim amount As Decimal = txtamount.Text
        Dim numberofdays As Decimal = txtnumberofdays.Text
        Dim dailyrate, totalgain, maturityamount As Decimal
        If cmbdaycount.SelectedItem.Text = "actual/360" Then
            dailyrate = rate / 360
            totalgain = dailyrate * numberofdays
            maturityamount = (totalgain / 100 * amount) + amount
        ElseIf cmbdaycount.SelectedItem.Text = "actual/365" Then
            dailyrate = rate / 365
            totalgain = dailyrate * numberofdays
            maturityamount = (totalgain / 100 * amount) + amount
        End If



        txtmaturityvalue.Text = maturityamount
    End Sub
    Protected Sub cmbcurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcurrency.SelectedIndexChanged
        Try
            If cmbcurrency.SelectedItem.Text <> cmbcurrencysett.SelectedItem.Text Then
                txtexchangerate.ReadOnly = False
                txtexchangerate.Text = ""
            Else
                txtexchangerate.ReadOnly = True
                txtexchangerate.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbcurrencysett_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcurrencysett.SelectedIndexChanged
        Try
            If cmbcurrency.SelectedItem.Text <> cmbcurrencysett.SelectedItem.Text Then
                txtexchangerate.ReadOnly = False
                txtexchangerate.Text = ""
            Else
                txtexchangerate.ReadOnly = True
                txtexchangerate.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbmoneymarket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmoneymarket.SelectedIndexChanged
        getdetails(cmbmoneymarket.SelectedItem.Value.ToString, "Submit Rollover")


    End Sub
    'Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    '    If CheckBox1.Checked = True Then
    '        txtinterestamt.Text = ""
    '        txtinterestamt.Enabled = True
    '        txtinterestamt.ReadOnly = True
    '        calculateint()

    '    Else
    '        txtinterestamt.Text = "0"
    '        txtinterestamt.Enabled = False
    '    End If
    'End Sub
    Public Sub calculateint()
        Dim rate As Decimal = txtfixedrate.Text
        Dim amount As Decimal = txtcurrentvalue.Text
        Dim numberofdays As Decimal = DateDiff(DateInterval.Day, dttradedate.Date, dtmaturitydate.Date)
        Dim dailyrate, totalgain, maturityamount As Decimal
        If cmbdaycount.SelectedItem.Text = "actual/360" Then
            dailyrate = rate / 360
            totalgain = dailyrate * numberofdays
            maturityamount = totalgain / 100 * amount
            txtcallbackamount.Text = maturityamount
        ElseIf cmbdaycount.SelectedItem.Text = "actual/365" Then
            dailyrate = rate / 365
            totalgain = dailyrate * numberofdays
            maturityamount = totalgain / 100 * amount
            txtcallbackamount.Text = maturityamount
        End If

    End Sub
    'Protected Sub txtcurrentvalue_TextChanged(sender As Object, e As EventArgs) Handles txtcurrentvalue.TextChanged
    '    If CheckBox1.Checked = True Then
    '        calculateint()
    '        calculateintnewdeal()

    '    Else
    '        txtinterestamt.Text = "0"
    '        calculateintnewdeal()

    '    End If


    'End Sub
    Protected Sub dtnewtradedate_DateChanged(sender As Object, e As EventArgs) Handles dtnewtradedate.DateChanged
        Try
            Dim numberdays As Decimal = txtnewnumberofdays.Text
            dtnewmaturitydate.Date = DateAdd(DateInterval.Day, numberdays, dtnewtradedate.Date)
            Try
                calculateintnewdeal()

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub txtnewnumberofdays_TextChanged(sender As Object, e As EventArgs) Handles txtnewnumberofdays.TextChanged
        Try
            Dim numberdays As Decimal = txtnewnumberofdays.Text
            dtnewmaturitydate.Date = DateAdd(DateInterval.Day, numberdays, dtnewtradedate.Date)
            calculateintnewdeal()

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub txtnewinterest_TextChanged(sender As Object, e As EventArgs) Handles txtnewinterest.TextChanged
        Try
            calculateintnewdeal()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub calculateintnewdeal()
        Dim rate As Decimal = txtnewinterest.Text
        Dim interest As Decimal = txtcallbackamount.Text
        Dim totamt As Decimal = txtcurrentvalue.Text

        Dim amount As Decimal = totamt

        Dim numberofdays As Decimal = txtnewnumberofdays.Text

        Dim dailyrate, totalgain, maturityamount As Decimal
        If cmbdaycount.SelectedItem.Text = "actual/360" Then
            dailyrate = rate / 360
            totalgain = dailyrate * numberofdays
            maturityamount = totalgain / 100 * amount
            maturityamount = amount + maturityamount
            txtnewmaturityvalue.Text = maturityamount
        ElseIf cmbdaycount.SelectedItem.Text = "actual/365" Then
            dailyrate = rate / 365
            totalgain = dailyrate * numberofdays
            maturityamount = totalgain / 100 * amount
            maturityamount = amount + maturityamount

            txtnewmaturityvalue.Text = maturityamount
        End If

    End Sub
    Protected Sub txtcurrentvalue_TextChanged(sender As Object, e As EventArgs) Handles txtcurrentvalue.TextChanged
        Dim roll As Decimal = txtcurrentvalue.Text
        Dim maturity As Decimal = txtmaturityvalue.Text
        Dim callb As Decimal = maturity - roll

        If callb < 0 Then
            txtcurrentvalue.Text = lblcurrentamount.Text
            msgbox("You cannot rollover amount more that the maturity value.")
            Exit Sub
        Else
            txtcallbackamount.Text = callb
        End If

        Try
            calculateintnewdeal()

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub txtcallbackamount_TextChanged(sender As Object, e As EventArgs) Handles txtcallbackamount.TextChanged


        Dim callb As Decimal = txtcallbackamount.Text
        Dim maturity As Decimal = txtmaturityvalue.Text
        Dim roll As Decimal = maturity - callb
        If roll < 0 Then
            txtcallbackamount.Text = "0"
            msgbox("You cannot callback amount more that the maturity value.")
            Exit Sub
        Else
            txtcurrentvalue.Text = roll
        End If
        Try
            calculateintnewdeal()

        Catch ex As Exception

        End Try
    End Sub
End Class