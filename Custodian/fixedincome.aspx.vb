Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_fixedincome
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


                lbltransid.Text = Session("mymy")
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "Update" Then
                Session("finish") = ""
                msgbox("Transaction updated successfully")

            End If
            If Session("finish") = "Re-Submit" Then
                Session("finish") = ""
                msgbox("Transaction re-submitted successfully")

            End If
            If Session("finish") = "Delete" Then
                Session("finish") = ""
                msgbox("Transaction has been successfully dropped")

            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                dtfrom.MaxDate = Date.UtcNow

                loadcompanies()
                getcurrencies()
                GETREJECTEDBYADMIN()
                geteditable()

                getsettled()
                getbanks()


                getpending()
                '   loadcomboforreceipts(txtewrholder.Text)
                getrejected()

            Else
                '   loadcomboforreceipts(txtewrholder.Text)
            End If
            getrejected()
            getpending()
            '    loadcomboforreceipts(txtewrholder.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getbanks()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select bank, bank_name from para_bank", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbbank.DataSource = dsport
            cmbbank.TextField = "bank_name"
            cmbbank.ValueField = "bank"
            cmbbank.DataBind()


        End If
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
            Dim nf As New passmanagement
            If cmbordertype.SelectedItem.Text = "RVP" Or cmbordertype.SelectedItem.Text = "DVP" Then


                If nf.maxallowed(txtewraccountno.Text, cmbcurrencysett.SelectedItem.Value.ToString).Tables(0).Rows.Count > 0 Then
                    Dim settleamt As Decimal = txtsettlementamount.Text
                    Dim maxamt As Decimal = nf.maxallowed(txtewraccountno.Text, cmbcurrencysett.SelectedItem.Value.ToString).Tables(0).Rows(0).Item("limit").ToString
                    Dim reaction As String = nf.maxallowed(txtewraccountno.Text, cmbcurrencysett.SelectedItem.Value.ToString).Tables(0).Rows(0).Item("Reaction").ToString
                    Dim dtt As Date = Date.UtcNow

                    If settleamt > maxamt Then
                        If reaction = "Reject Transaction" Then
                            msgbox("Account Class not allowed to transact more than " + maxamt.ToString + "!")
                            Exit Sub
                        ElseIf reaction = "Send Email But Proceed" Then
                            Dim m As New sendmail
                            m.sendmail("custodialservicesdivision@cabs.co.zw", "Suspicious Transaction", "Please note that the processed transaction amount of " + cmbcurrencysett.SelectedItem.Text + "" + settleamt.ToString("n") + " dated " + dtt.ToString("dd MMM yyyy") + " for " + txtewrholder.Text + "  is suspicious as this is above the set client limit.")
                        End If

                    End If

                Else

                End If
            End If

            If ASPxButton13.Text = "Save" Then
                If cmbordertype.SelectedItem.Text = "DVP" Or cmbordertype.SelectedItem.Text = "DF" Then
                    Dim qnt As Decimal = txtavailableshares.Text
                    Dim bal As Decimal = holdingbalance(cmbparaCompany.SelectedItem.Value.ToString, cmbassetmanager.SelectedItem.Value.ToString, txtewraccountno.Text)

                    If qnt > bal Then
                        msgbox("Account has insufficient balance to perfom this transaction. Available balance for the Account for " + cmbparaCompany.SelectedItem.Text + " is " + bal.ToString("N") + "")
                        Exit Sub
                    End If

                ElseIf cmbordertype.SelectedItem.Text = "RVP" Then
                    Dim settleamt As Decimal = txtsettlementamount.Text
                    Dim moneybal As Decimal = moneybalance(cmbcurrencysett.SelectedItem.Text, cmbassetmanager.SelectedItem.Value.ToString, txtewraccountno.Text)

                    If settleamt > moneybal Then
                        msgbox("Account has insufficient balance to perfom this transaction. Available " + cmbcurrencysett.SelectedItem.Text + " balance is " + moneybal.ToString("N") + " under " + cmbassetmanager.SelectedItem.Text + "")
                        Exit Sub
                    End If

                End If




                If refexists(txtereference.Text) = True Then
                    msgbox("Reference already exists!")
                    Exit Sub
                End If



                Dim xyz As New Common

                cmd = New SqlCommand("insert into Bond_Trades (TradeRef, TradeDate, SettlementDate, Company, Units, Price, ClientNo, CDCAccount, AssetManager,  CapturedBy, CapturedDate, TradeStatus,TradeType, Currency, TradeCharge, SettlementAmount, Broker, SettlementCurrency, ExchangeRate, CleanPrice, DirtyPrice, DiscountRate, Bank, AccountNo, AccountName) values ('" + txtereference.Text + "','" + dtfrom.Text + "','" + dtsettlementdate.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + txtavailableshares.Text + "','0', '" + txtewraccountno.Text + "','" + getcdcnumber(cmbassetmanager.Value.ToString, txtewraccountno.Text) + "','" + cmbassetmanager.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(), 'OUTSTANDING','" + cmbordertype.SelectedItem.Text + "','" + cmbcurrency.SelectedItem.Text + "','" + txttranscharge.Text + "','" + txtsettlementamount.Text + "', '','" + cmbcurrencysett.SelectedItem.Value.ToString + "','" + txtexchangerate.Text + "','0','0','" + txtdiscountrate.Text + "','" + cmbbank.SelectedItem.Value.ToString + "','" + txtAccountNo.Text + "','" + txtaccountname.Text + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



                updatewithRef(Session("autogen"), transid.ToString, "TRADE")


                Try
                    Dim a As New passmanagement
                    a.auditlog(Session("BrokerCode"), Session("Username"), "Submitted a Withdrawal Request", txtewraccountno.Text, cmbparaCompany.Text)
                Catch ex As Exception

                End Try

                Session("finish") = "yes"
                Session("mymy") = transid.ToString
                Session("msg") = "Trade has been successfully captured for " + cmbparaCompany.Value.ToString + " .Transaction ID is " + transid.ToString + ""
                Response.Redirect(Request.RawUrl)


            ElseIf ASPxButton13.Text = "Update" Then


                cmd = New SqlCommand("update Bond_Trades set AccountNo='" + txtAccountNo.Text + "', AccountName='" + txtaccountname.Text + "', Bank='" + cmbbank.SelectedItem.Value.ToString + "', DiscountRate='" + txtdiscountrate.Text + "', CleanPrice='0',DirtyPrice='0',ExchangeRate='" + txtexchangerate.Text + "',TradeRef='" + txtereference.Text + "', TradeDate='" + dtfrom.Date.ToString + "', SettlementDate='" + dtsettlementdate.Date.ToString + "', Company='" + cmbparaCompany.Value.ToString + "', Units='" + txtavailableshares.Text + "', Price='0', ClientNo='" + txtewraccountno.Text + "', CDCAccount='" + getcdcnumber(cmbassetmanager.Value.ToString, txtewraccountno.Text) + "', AssetManager='" + cmbassetmanager.Value.ToString + "',TradeType='" + cmbordertype.Value.ToString + "', Currency='" + cmbcurrency.Value.ToString + "', TradeCharge='" + txttranscharge.Text + "', SettlementAmount='" + txtsettlementamount.Text + "',Broker='' where id='" + lblid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "Update"
                Response.Redirect(Request.RawUrl)


            Else
                cmd = New SqlCommand("update Bond_Trades set AccountNo='" + txtAccountNo.Text + "', AccountName='" + txtaccountname.Text + "', Bank='" + cmbbank.SelectedItem.Value.ToString + "',DiscountRate='" + txtdiscountrate.Text + "', CleanPrice='0',DirtyPrice='0',ExchangeRate='" + txtexchangerate.Text + "',TradeStatus='OUTSTANDING',rejected=NULL, RejectionReason=NULL, TradeRef='" + txtereference.Text + "', TradeDate='" + dtfrom.Date.ToString + "', SettlementDate='" + dtsettlementdate.Date.ToString + "', Company='" + cmbparaCompany.Value.ToString + "', Units='" + txtavailableshares.Text + "', Price='0', ClientNo='" + txtewraccountno.Text + "', CDCAccount='" + getcdcnumber(cmbassetmanager.Value.ToString, txtewraccountno.Text) + "', AssetManager='" + cmbassetmanager.Value.ToString + "',TradeType='" + cmbordertype.Value.ToString + "', Currency='" + cmbcurrency.Value.ToString + "', TradeCharge='" + txttranscharge.Text + "', SettlementAmount='" + txtsettlementamount.Text + "',Broker='' where id='" + lblid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "Re-Submit"
                Response.Redirect(Request.RawUrl)

            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
            msgbox("Please select the relevant Account to Withdraw! Units to withdraw should also be numeric")
        End Try

    End Sub
    Public Function refexists(ref As String) As Boolean

        Dim ds As New DataSet
        cmd = New SqlCommand("select TradeRef from Bond_Trades where TradeRef='" + ref + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function
    Public Function holdingbalance(company As String, assetmanager As String, clientno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Holding),0) as holding from holdingbalances where cds_Number='" + clientno + "' and company='" + company + "' and assetmanager='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("holding")
        End If
    End Function
    Public Function moneybalance(currency As String, assetmanager As String, clientno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT isnull(sum(amount),0) as amt  FROM moneybals where currency='" + currency + "' and cds_number='" + clientno + "' and AssetManager='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("amt")
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
        cmd = New SqlCommand("select max(id) as id from Bond_Trades", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("id").ToString
        Else
            Return ""
        End If
    End Function

    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("  select * from Bond_Trades where rejected is NULL and ApprovedBy is not NULL and tradestatus='OUTSTANDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdpendingsettlement.DataSource = ds
            grdpendingsettlement.DataBind()
        Else
            grdpendingsettlement.DataSource = Nothing
            grdpendingsettlement.DataBind()
        End If
    End Sub
    Public Function getcdcnumber(assetmanager As String, accountno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select cdcnumber from Client_AssetManagers where clientNo='" + txtAccountNo.Text + "' and AssetManager='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("cdcnumber").ToString
        Else
            Return ""
        End If
    End Function
    Public Sub geteditable()

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Bond_Trades where rejected is NULL and ApprovedBy is NULL and tradestatus='OUTSTANDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdeditable.DataSource = ds
            grdeditable.DataBind()
        Else
            grdeditable.DataSource = Nothing
            grdeditable.DataBind()
        End If
    End Sub
    Public Sub GETREJECTEDBYADMIN()

        Dim ds As New DataSet
        cmd = New SqlCommand("  select * from Bond_Trades where rejected='1'  and ApprovedBy is NULL and tradestatus='EDIT'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdrejected.DataSource = ds
            grdrejected.DataBind()
        Else
            grdrejected.DataSource = Nothing
            grdrejected.DataBind()
        End If
    End Sub
    Public Sub getrejected()

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Bond_Trades where ApprovedBy is NOT NULL and tradestatus='FAILED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdfailed.DataSource = ds
            grdfailed.DataBind()
        Else
            grdfailed.DataSource = Nothing
            grdfailed.DataBind()
        End If
    End Sub
    Public Sub getsettled()

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Bond_Trades WHERE tradestatus='SETTLED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdsettled.DataSource = ds
            grdsettled.DataBind()
        Else
            grdsettled.DataSource = Nothing
            grdsettled.DataBind()
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

    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged




        getbank(cmbparaCompany.SelectedItem.Value.ToString)


    End Sub
    Public Sub getbank(series As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Bank, AccountNo, AccountName from Bond where code='" + series + "' and [status]='ACTIVE'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbbank.Value = dsport.Tables(0).Rows(0).Item("Bank").ToString
            txtaccountname.Text = dsport.Tables(0).Rows(0).Item("AccountName").ToString
            txtcounterpartaccount.Text = dsport.Tables(0).Rows(0).Item("AccountNo").ToString
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
            Session("autogen") = CreateRandomPassword(20)

        End If
    End Sub
    Public Sub loadcompanies()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select issuer+' '+code as fnam, code  from ActiveBonds where category='BOND'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "fnam"
            cmbparaCompany.ValueField = "code"
            cmbparaCompany.DataBind()
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

    Public Function partname(code As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Company_name from client_companies where Company_Code='" + code + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("company_name")
        End If
    End Function





    Public Sub getdetails(id As String, transtype As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Bond_Trades c, Accounts_Clients a where c.ClientNo=a.CDS_Number and c.id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ' txtAccountNo.Text = dsport.Tables(0).Rows(0).Item("ParticipantCode").ToString
            ' txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString
            txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("clientno").ToString
            txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Surname").ToString + "  " + dsport.Tables(0).Rows(0).Item("Forenames").ToString
            '  txtparticipantname.Text = dsport.Tables(0).Rows(0).Item("company_name").ToString
            cmbparaCompany.Value = dsport.Tables(0).Rows(0).Item("company").ToString
            '  txtprice.Text = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString

            loadcomboforassetmanagers(txtewraccountno.Text)

            cmbassetmanager.Value = dsport.Tables(0).Rows(0).Item("AssetManager").ToString




            txtexchangerate.Text = dsport.Tables(0).Rows(0).Item("ExchangeRate").ToString
            cmbcurrency.Value = dsport.Tables(0).Rows(0).Item("currency").ToString
            cmbcurrencysett.Value = dsport.Tables(0).Rows(0).Item("SettlementCurrency").ToString
            cmbordertype.Value = dsport.Tables(0).Rows(0).Item("TradeType").ToString
            txtereference.Text = dsport.Tables(0).Rows(0).Item("TradeRef").ToString
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("Units").ToString
            '    txtprice.Text = dsport.Tables(0).Rows(0).Item("price").ToString
            dtfrom.Date = dsport.Tables(0).Rows(0).Item("TradeDate").ToString
            dtsettlementdate.Date = dsport.Tables(0).Rows(0).Item("SettlementDate").ToString
            txttranscharge.Text = dsport.Tables(0).Rows(0).Item("TradeCharge").ToString
            txtsettlementamount.Text = dsport.Tables(0).Rows(0).Item("SettlementAmount").ToString
            ASPxButton13.Text = transtype
            lblid.Text = id.ToString


            Dim grss As Decimal = txtavailableshares.Text
            txtgross.Text = grss.ToString("N")

            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
            getdocuments(id.ToString, "TRADE")
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

    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdpendingsettlement.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Update Failed" Then
            cmd = New SqlCommand("insert into Bond_Trades_comm ([TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,[CapturedBy]      ,[CapturedDate]      ,[ApprovedBy]      ,[ApprovedDate]      ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,[TradeStatus]      ,[TradeType],[Ref2]) select [TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,'" + Session("Username") + "'   ,GETDATE()    ,NULL     ,NULL   ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,'FAILED'     ,[TradeType], [id] from Bond_Trades where id='" + id + "' update Bond_Trades set TradeStatus='OUTSTANDING - FAILED' WHERE ID='" + id + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getpending()
            msgbox("Status Successfully Updated!")
        ElseIf e.CommandArgs.CommandName.ToString = "Update Settled" Then
            cmd = New SqlCommand("insert into Bond_Trades_comm ([TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,[CapturedBy]      ,[CapturedDate]      ,[ApprovedBy]      ,[ApprovedDate]      ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,[TradeStatus]      ,[TradeType], [Ref2]) select [TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,'" + Session("Username") + "'   ,GETDATE()    ,NULL     ,NULL   ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,'SETTLED'     ,[TradeType], [id] from Bond_Trades where id='" + id + "' update Bond_Trades set TradeStatus='OUTSTANDING - SETTLED' WHERE ID='" + id + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getpending()
            msgbox("Status Successfully Updated!")
        End If
    End Sub
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
                txtcharge.Text = charge
            Catch ex As Exception
                msgbox("Error Reversal Charging: " + ex.Message)
            End Try
        End If

    End Sub
    Public Function editable(idn As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Bond_Trades where id='" + idn + "' and tradestatus='OUTSTANDING'", cn)
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
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        If getotp(lbltransid.Text) <> txtotp.Text Then
            msgbox("Invalid OTP!")
            Exit Sub
        ElseIf getotp(lbltransid.Text) = txtotp.Text Then
            cmd = New SqlCommand("update withdrawals set OTPStatus='Approved', OTPResponseTime=getdate()   where id='" + lbltransid.Text + "'", cn)
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
            getpending()

            msgbox("OTP Correct! Withdrawal sent for approval")


        Else
            msgbox("Failed")
        End If
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
        Dim ref4 As String = ""
        If ASPxButton13.Text = "Save" Then
            ref4 = Session("autogen")
        Else
            ref4 = lblid.Text
        End If
        If m.Document_Upload(fs, filePath, txtdocumentname.Text, ext, filename, "TRADE", txtewraccountno.Text, Session("autogen"), bytes).ToString <> "Upload Successful" Then
            msgbox("Document Upload failed!")
            Exit Sub
        Else
            getdocuments(Session("autogen"), "TRADE")
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
                pd(Session("autogen"), "TRADE")
            Catch ex As Exception
            End Try
            Try
                word(Session("autogen"), "TRADE")
            Catch ex As Exception
            End Try
            Try
                xls(Session("autogen"), "TRADE")
            Catch ex As Exception
            End Try
            Try
                Img(Session("autogen"), "TRADE")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            deletedocument(Session("autogen"), "TRADE")
            getdocuments(Session("autogen"), "TRADE")
        End If
    End Sub
    Protected Sub dtfrom_DateChanged(sender As Object, e As EventArgs) Handles dtfrom.DateChanged
        dtsettlementdate.Date = addDays_WithoutWeekend(dtfrom.Date, 3)
    End Sub
    Function addDays_WithoutWeekend(Dateinput As Date, NumofDays As Integer) As Date
        Do Until NumofDays = 0
            Dateinput = Dateinput.AddDays(1)
            If Dateinput.DayOfWeek <> DayOfWeek.Saturday And Dateinput.DayOfWeek <> DayOfWeek.Sunday Then
                NumofDays = NumofDays - 1
            End If
        Loop
        Return Dateinput
    End Function


    Private Sub grdeditable_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdeditable.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            If editable(id) = True Then
                getdetails(id, "Update")
            Else
                msgbox("Entry can nolonger be edited!")
            End If
        End If
    End Sub

    Private Sub grdrejected_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdrejected.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit & Re-Submit" Then
            getdetails(id, "Re-Submit")
            ASPxButton16.Visible = True
        End If
        If e.CommandArgs.CommandName.ToString = "delete" Then
            flagdelete(id)
            getrejected()

        End If
    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub txtavailableshares_TextChanged(sender As Object, e As EventArgs) Handles txtavailableshares.TextChanged

        calculations()

    End Sub

    Protected Sub txttranscharge_TextChanged(sender As Object, e As EventArgs) Handles txttranscharge.TextChanged
        calculations()

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
        calculations()

    End Sub

    Public Sub calculations()
        Try

            Dim quant As Decimal = txtavailableshares.Text

            Dim val As Decimal
            If cmbcurrency.SelectedItem.Text = cmbcurrencysett.SelectedItem.Text Then
                val = quant
            Else
                val = quant * txtexchangerate.Text
            End If
            Dim chrg, TOT As Decimal
            Dim discount As Decimal
            Dim rt As Decimal
            Try
                rt = txtdiscountrate.Text
                discount = rt / 100 * val
            Catch ex As Exception
                discount = 0
            End Try
            If cmbordertype.SelectedItem.Value.ToString = "DVP" Or cmbordertype.SelectedItem.Value.ToString = "DF" Then
                If cmbcurrency.SelectedItem.Text = cmbcurrencysett.SelectedItem.Text Then
                    chrg = txttranscharge.Text
                    TOT = val - chrg

                    txttranscharge.Text = chrg
                    txtsettlementamount.Text = (TOT - discount)
                    txtgross.Text = val
                Else
                    chrg = txttranscharge.Text
                    Dim rte As Decimal = txtexchangerate.Text


                    chrg = chrg * rte

                    TOT = val - chrg

                    txttranscharge.Text = chrg
                    txtsettlementamount.Text = (TOT - discount)
                    txtgross.Text = val
                End If
            ElseIf cmbordertype.SelectedItem.Value.ToString = "RVP" Or cmbordertype.SelectedItem.Value.ToString = "RF" Then
                If cmbcurrency.SelectedItem.Text = cmbcurrencysett.SelectedItem.Text Then
                    chrg = txttranscharge.Text
                    TOT = val + chrg

                    txttranscharge.Text = chrg
                    txtsettlementamount.Text = (TOT - discount)
                    txtgross.Text = val
                Else
                    chrg = txttranscharge.Text
                    Dim rte As Decimal = txtexchangerate.Text


                    chrg = chrg * rte

                    TOT = val + chrg

                    txttranscharge.Text = chrg
                    txtsettlementamount.Text = (TOT - discount)

                    txtgross.Text = val
                End If

            End If






        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        cmd = New SqlCommand("delete from  Bond_Trades where id='" + lblid.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Session("finish") = "Delete"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub txtexchangerate_TextChanged(sender As Object, e As EventArgs) Handles txtexchangerate.TextChanged
        'Try

        '    Dim currentrate As Decimal = txtexchangerate.Text
        '    Dim quant As Decimal = txtavailableshares.Text
        '    Dim price As Decimal = txtprice.Text
        '    Dim tradeamt As Decimal = quant * price
        '    Dim settlementamt As Decimal
        '    settlementamt = tradeamt * currentrate

        '    txtsettlementamount.Text = settlementamt.ToString("N")

        'Catch ex As Exception

        'End Try
        calculations()

    End Sub



    Protected Sub cmbordertype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbordertype.SelectedIndexChanged

    End Sub
    Protected Sub dtsettlementdate_DateChanged(sender As Object, e As EventArgs) Handles dtsettlementdate.DateChanged
        If dtsettlementdate.Date < dtfrom.Date Then
            dtsettlementdate.Text = ""
            msgbox("Settlement date cannot be before transaction date!")
        End If
    End Sub
    Protected Sub txtdiscountrate_TextChanged(sender As Object, e As EventArgs) Handles txtdiscountrate.TextChanged
        calculations()

    End Sub
    Public Function OUTSTANDING_() As DataSet
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Bond_Trades where rejected is NULL and ApprovedBy is NULL and tradestatus='OUTSTANDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds
        Else
            Return Nothing
        End If
    End Function
    Private Sub grdeditable_DataBinding(sender As Object, e As EventArgs) Handles grdeditable.DataBinding
        grdeditable.DataSource = OUTSTANDING_()
    End Sub
End Class