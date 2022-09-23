Imports System.Collections.Generic
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_equitytrade
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
        '    Try
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
            getbrokers()
            getsettled()

            getpending()
            '   loadcomboforreceipts(txtewrholder.Text)
            getrejected()

        Else
            '   loadcomboforreceipts(txtewrholder.Text)
            getrejected()
            '  getpending()
            getsettled()
            geteditable()

        End If

        '    loadcomboforreceipts(txtewrholder.Text)
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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
            ' If cmbordertype.SelectedItem.Text = "RVP" Or cmbordertype.SelectedItem.Text = "DVP" Then


            'If nf.maxallowed(txtewraccountno.Text, cmbcurrencysett.SelectedItem.Value.ToString).Tables("trans") Is Nothing Then

            'Dim settleamt As Decimal = txtsettlementamount.Text
            '    Dim maxamt As Decimal = nf.maxallowed(txtewraccountno.Text, cmbcurrencysett.SelectedItem.Value.ToString).Tables(0).Rows(0).Item("limit").ToString
            '    Dim reaction As String = nf.maxallowed(txtewraccountno.Text, cmbcurrencysett.SelectedItem.Value.ToString).Tables(0).Rows(0).Item("Reaction").ToString
            '    Dim dtt As Date = Date.UtcNow

            '    If settleamt > maxamt Then
            '        If reaction = "Reject Transaction" Then
            '            msgbox("Account Class not allowed to transact more than " + maxamt.ToString + "!")
            '            Exit Sub
            '        ElseIf reaction = "Send Email But Proceed" Then
            '            Dim m As New sendmail
            '            m.sendmail("custodialservicesdivision@cabs.co.zw", "Suspicious Transaction", "Please note that the processed transaction amount of " + cmbcurrencysett.SelectedItem.Text + "" + settleamt.ToString("n") + " dated " + dtt.ToString("dd MMM yyyy") + " for " + txtewrholder.Text + "  is suspicious as this is above the set client limit.")
            '        End If

            '    End If

            'Else

            'End If
            '  End If



            If ASPxButton13.Text = "Save" Then
                If notallowed(txtewraccountno.Text, cmbparaCompany.SelectedItem.Value.ToString, cmbassetmanager.SelectedItem.Value.ToString, dtfrom.Date) = True Then
                    msgbox("You cannot post a transaction with trade date before last reconciliation date which is " + dtfrom.Date.tostring("dd MMM yyyy") + "!")
                    Exit Sub
                End If

                If cmbordertype.SelectedItem.Text = "DVP" Or cmbordertype.SelectedItem.Text = "DF" Then
                    Dim qnt As Decimal = txtavailableshares.Text
                    Dim bal As Decimal = holdingbalance(cmbparaCompany.SelectedItem.Value.ToString, cmbassetmanager.SelectedItem.Value.ToString, txtewraccountno.Text)

                    If qnt > bal Then
                        msgbox("Account has insufficient units to perfom this transaction. Available units for the Account for " + cmbparaCompany.SelectedItem.Text + " is " + bal.ToString("N") + "")
                        Exit Sub
                    End If





                    'ElseIf cmbordertype.SelectedItem.Text = "RVP" Then
                    '  
                    '    Dim moneybal As Decimal = moneybalance(cmbcurrencysett.SelectedItem.Text, cmbassetmanager.SelectedItem.Value.ToString, txtewraccountno.Text)

                    '    If settleamt > moneybal Then
                    '        msgbox("Account has insufficient balance to perfom this transaction. Available " + cmbcurrencysett.SelectedItem.Text + " balance is " + moneybal.ToString("N") + " under " + cmbassetmanager.SelectedItem.Text + "")
                    '        Exit Sub
                    '    End If

                End If




                If refexists(txtereference.Text) = True Then
                    msgbox("Reference already exists!")
                    Exit Sub
                End If



                Dim xyz As New Common

                cmd = New SqlCommand("insert into Custodian_Trades (TradeRef, TradeDate, SettlementDate, Company, Units, Price, ClientNo, CDCAccount, AssetManager,  CapturedBy, CapturedDate, TradeStatus,TradeType, Currency, TradeCharge, SettlementAmount, Broker, SettlementCurrency, ExchangeRate) values ('" + txtereference.Text + "','" + dtfrom.Text + "','" + dtsettlementdate.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + txtavailableshares.Text + "','" + txtprice.Text + "', '" + txtewraccountno.Text + "','" + getcdcnumber(cmbassetmanager.Value.ToString, txtewraccountno.Text) + "','" + cmbassetmanager.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(), 'OUTSTANDING','" + cmbordertype.SelectedItem.Text + "','" + cmbcurrency.SelectedItem.Text + "','" + txttranscharge.Text + "','" + txtsettlementamount.Text + "', '" + cmbbroker.SelectedItem.Value.ToString + "','" + cmbcurrencysett.SelectedItem.Value.ToString + "','" + txtexchangerate.Text + "')", cn)
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
                Session("msg") = "Trade has been successfully captured for " + cmbparaCompany.Value.ToString + " .Transaction ID is " + transid.ToString + "."
                Response.Redirect(Request.RawUrl)


            ElseIf ASPxButton13.Text = "Update" Then


                cmd = New SqlCommand("update Custodian_Trades set ExchangeRate='" + txtexchangerate.Text + "',TradeRef='" + txtereference.Text + "', TradeDate='" + dtfrom.Date.ToString + "', SettlementDate='" + dtsettlementdate.Date.ToString + "', Company='" + cmbparaCompany.Value.ToString + "', Units='" + txtavailableshares.Text + "', Price='" + txtprice.Text + "', ClientNo='" + txtewraccountno.Text + "', CDCAccount='" + getcdcnumber(cmbassetmanager.Value.ToString, txtewraccountno.Text) + "', AssetManager='" + cmbassetmanager.Value.ToString + "',TradeType='" + cmbordertype.Value.ToString + "', Currency='" + cmbcurrency.Value.ToString + "', TradeCharge='" + txttranscharge.Text + "', SettlementAmount='" + txtsettlementamount.Text + "',Broker='" + cmbbroker.SelectedItem.Value.ToString + "' where id='" + lblid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "Update"
                Response.Redirect(Request.RawUrl)


            Else
                cmd = New SqlCommand("update Custodian_Trades set ExchangeRate='" + txtexchangerate.Text + "',TradeStatus='OUTSTANDING',rejected=NULL, RejectionReason=NULL, TradeRef='" + txtereference.Text + "', TradeDate='" + dtfrom.Date.ToString + "', SettlementDate='" + dtsettlementdate.Date.ToString + "', Company='" + cmbparaCompany.Value.ToString + "', Units='" + txtavailableshares.Text + "', Price='" + txtprice.Text + "', ClientNo='" + txtewraccountno.Text + "', CDCAccount='" + getcdcnumber(cmbassetmanager.Value.ToString, txtewraccountno.Text) + "', AssetManager='" + cmbassetmanager.Value.ToString + "',TradeType='" + cmbordertype.Value.ToString + "', Currency='" + cmbcurrency.Value.ToString + "', TradeCharge='" + txttranscharge.Text + "', SettlementAmount='" + txtsettlementamount.Text + "',Broker='" + cmbbroker.SelectedItem.Value.ToString + "' where id='" + lblid.Text + "'", cn)
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
            msgbox(ex.Message)
        End Try

    End Sub
    Public Function refexists(ByVal ref As String) As Boolean

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
    Public Function notallowed(ByVal accountno As String, ByVal security As String, ByVal assetmanager As String, ByVal tradedate As Date) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select top 1 * from Recon_AssetManager_Approvals where CurrentStatus='APPROVED' and [Account No]='" + accountno + "' and [Security]='" + security + "' and AssetManager='" + assetmanager + "' order by recondate desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim recondate As Date = ds.Tables(0).Rows(0).Item("recondate").ToString
            If tradedate <= recondate Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function
    Public Function holdingbalance(ByVal company As String, ByVal assetmanager As String, ByVal clientno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Holding),0) as holding from holdingbalances where cds_Number='" + clientno + "' and company='" + company + "' and assetmanager='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("holding")
        End If
    End Function
    Public Function moneybalance(ByVal currency As String, ByVal assetmanager As String, ByVal clientno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT isnull(sum(amount),0) as amt  FROM moneybals where currency='" + currency + "' and cds_number='" + clientno + "' and AssetManager='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("amt")
        End If
    End Function
    Public Function getemail(ByVal cdsnumber As String) As String
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
        cmd = New SqlCommand("select max(id) as id from custodian_trades", cn)
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
        cmd = New SqlCommand("  select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a  where c.clientno=a.cds_number and rejected is NULL and ApprovedBy is not NULL and tradestatus='OUTSTANDING' AND convert(date, Settlementdate)<=convert(date,getdate())", cn)
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
    Public Function pendingdata() As DataSet

        Dim ds As New DataSet
        cmd = New SqlCommand("  select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a  where c.clientno=a.cds_number and rejected is NULL and ApprovedBy is not NULL and tradestatus='OUTSTANDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds

        Else
            Return Nothing
        End If
    End Function
    Public Function getcdcnumber(ByVal assetmanager As String, ByVal accountno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select cdcnumber from Client_AssetManagers where   clientNo='" + txtAccountNo.Text + "' and AssetManager='" + assetmanager + "'", cn)
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
        cmd = New SqlCommand("select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a where c.clientno=a.cds_number and rejected is NULL and ApprovedBy is NULL and tradestatus='OUTSTANDING'", cn)
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
        cmd = New SqlCommand("  select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a where c.clientno=a.cds_number and rejected='1'  and ApprovedBy is NULL and tradestatus='EDIT'", cn)
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
        cmd = New SqlCommand("select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a where  c.clientno=a.cds_number and  ApprovedBy is NOT NULL and tradestatus='FAILED'", cn)
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
        cmd = New SqlCommand("select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a WHERE tradestatus='SETTLED' and a.cds_number=c.clientno", cn)
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
    Public Function pendingbalance(ByVal receipt As String) As String
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



    Protected Sub ASPxButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton4.Click
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

    Protected Sub cmbparaCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged
        Dim dsport As New DataSet
        cmd = New SqlCommand("select quantity as available from wr where receiptno='" + cmbparaCompany.Value.ToString + "' and holder='" + txtewraccountno.Text + "' and quantity>0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            'txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString
            'txtprice.Text = dsport.Tables("trans").Rows(0).Item("available").ToString

            Dim m As New NaymatBilling
            Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtprice.Text, ListBox1.SelectedValue.ToString, cmbparaCompany.Value.ToString)
            Dim charge As Double = m.getEWRBAL(cmbparaCompany.Value.ToString, ListBox1.SelectedValue.ToString)
            Dim globcharge As Double = m.getholderbal(ListBox1.SelectedValue.ToString, Session("BrokerCode"))
            txtcharge.Text = charge.ToString("N")
            txttotalcharges.Text = globcharge.ToString("N")
            '  txttranscharge.Text = transcharge.ToString("N")
            Session("autogen") = CreateRandomPassword(20)
        Else

            '   txtavailableshares.Text = 0
            '  txtprice.Text = 0
        End If






    End Sub


    Protected Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox1.SelectedIndexChanged
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
        cmd = New SqlCommand("select * from para_company where sec_type='EQUITY'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "fnam"
            cmbparaCompany.ValueField = "company"
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
    Public Sub loadcomboforassetmanagers(ByVal holder As String)
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
    Public Sub getbrokers()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select  broker_code, fnam from para_broker", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbbroker.DataSource = dsport
            cmbbroker.TextField = "fnam"
            cmbbroker.ValueField = "broker_code"
            cmbbroker.DataBind()

        End If
    End Sub
    Public Function partname(ByVal code As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Company_name from client_companies where Company_Code='" + code + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("company_name")
        End If
    End Function





    Public Sub getdetails(ByVal id As String, ByVal transtype As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Custodian_Trades c, Accounts_Clients a where c.ClientNo=a.CDS_Number and c.id='" + id + "'", cn)
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
            cmbbroker.Value = dsport.Tables(0).Rows(0).Item("Broker").ToString



            txtexchangerate.Text = dsport.Tables(0).Rows(0).Item("ExchangeRate").ToString
            cmbcurrency.Value = dsport.Tables(0).Rows(0).Item("currency").ToString
            cmbcurrencysett.Value = dsport.Tables(0).Rows(0).Item("SettlementCurrency").ToString
            cmbordertype.Value = dsport.Tables(0).Rows(0).Item("TradeType").ToString
            txtereference.Text = dsport.Tables(0).Rows(0).Item("TradeRef").ToString
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("Units").ToString
            txtprice.Text = dsport.Tables(0).Rows(0).Item("price").ToString
            dtfrom.Date = dsport.Tables(0).Rows(0).Item("TradeDate").ToString
            dtsettlementdate.Date = dsport.Tables(0).Rows(0).Item("SettlementDate").ToString
            txttranscharge.Text = dsport.Tables(0).Rows(0).Item("TradeCharge").ToString
            txtsettlementamount.Text = dsport.Tables(0).Rows(0).Item("SettlementAmount").ToString

            ASPxButton13.Text = transtype
            If transtype = "" Then
                ASPxButton13.Visible = False
            Else
                ASPxButton13.Visible = True
            End If

            lblid.Text = id.ToString

            Dim grss As Decimal
            Dim quantity As Decimal = txtavailableshares.Text
            Dim price As Decimal = txtprice.Text
            grss = quantity * price
            txtgross.Text = grss.ToString("N")

            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
            getdocuments(lblid.Text, "TRADE")
        End If


    End Sub
    Public Function getotp(ByVal id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTP,'') as OTP from withdrawals where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("OTP").ToString
        End If
    End Function
    Public Function OTPApproved(ByVal id As String) As Boolean
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
    Public Sub updatefailed(ByVal transid As String)
        Try
            cmd = New SqlCommand("insert into custodian_trades_comm ([TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,[CapturedBy]      ,[CapturedDate]      ,[ApprovedBy]      ,[ApprovedDate]      ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,[TradeStatus]      ,[TradeType],[Ref2]) select [TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,'" + Session("Username") + "'   ,GETDATE()    ,NULL     ,NULL   ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,'FAILED'     ,[TradeType], [id] from custodian_trades where id='" + transid + "' update custodian_trades set TradeStatus='OUTSTANDING - FAILED' WHERE ID='" + transid + "'", cn)
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
    Public Sub updatesettled(ByVal transid As String)
        Try
            cmd = New SqlCommand("insert into custodian_trades_comm ([TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,[CapturedBy]      ,[CapturedDate]      ,[ApprovedBy]      ,[ApprovedDate]      ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,[TradeStatus]      ,[TradeType], [Ref2]) select [TradeRef]      ,[TradeDate]      ,[SettlementDate]      ,[Company]      ,[Units]      ,[Price]      ,[ClientNo]      ,[CDCAccount]      ,[AssetManager]      ,[TradeCharge]      ,'" + Session("Username") + "'   ,GETDATE()    ,NULL     ,NULL   ,[Rejected]      ,[RejectionReason]      ,[Deleted]      ,'SETTLED'     ,[TradeType], [id] from custodian_trades where id='" + transid + "' update custodian_trades set TradeStatus='OUTSTANDING - SETTLED' WHERE ID='" + transid + "'", cn)
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

    Private Sub ASPxGridView3_RowCommand(ByVal sender As Object, ByVal e As ASPxGridViewRowCommandEventArgs) Handles grdpendingsettlement.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Update Failed" Then
            updatefailed(id)
            getpending()
            msgbox("Status Successfully Updated!")
        ElseIf e.CommandArgs.CommandName.ToString = "Update Settled" Then
            updatesettled(id)
            getpending()
            msgbox("Status Successfully Updated!")
        ElseIf e.CommandArgs.CommandName.ToString = "View" Then
            getdetails(id, "")
            ASPxButton16.Visible = False
        End If
    End Sub
    Public Sub reversertransaction(ByVal id As String)
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
    Public Function editable(ByVal idn As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from custodian_trades where id='" + idn + "' and tradestatus='OUTSTANDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub flagdelete(ByVal ref As String)
        cmd = New SqlCommand("update withdrawals set deleted='1'  where id='" + ref + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Protected Sub btnSaveContract1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveContract1.Click
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

    Protected Sub ASPxButton14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton14.Click

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
        If m.Document_Upload(fs, filePath, txtdocumentname.Text, ext, filename, "TRADE", txtewraccountno.Text, ref4, bytes).ToString <> "Upload Successful" Then
            msgbox("Document Upload failed!")
            Exit Sub
        Else
            getdocuments(ref4, "TRADE")
            msgbox("Document Uploaded")
        End If

    End Sub
    Public Sub getdocuments(ByVal ref As String, ByVal transtyp As String)
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
    Public Sub deletedocument(ByVal newref As String, ByVal transtyp As String)
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
    Public Sub pd(ByVal id As String, ByVal transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(ByVal id As String, ByVal transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(ByVal id As String, ByVal transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(ByVal id As String, ByVal transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Function apptype(ByVal type As String) As String
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
    Private Sub grddocuments_RowCommand(ByVal sender As Object, ByVal e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
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
            If ASPxButton13.Text = "Save" Then
                deletedocument(Session("autogen"), "TRADE")
                getdocuments(Session("autogen"), "TRADE")
            Else
                deletedocument(lblid.Text, "TRADE")
                getdocuments(lblid.Text, "TRADE")
            End If

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
        'Try
        '    Dim quant As Decimal = txtavailableshares.Text
        '    Dim price As Decimal = txtprice.Text
        '    Dim val As Decimal = quant * price
        '    Dim chrg, TOT As Decimal
        '    If cmbordertype.SelectedItem.Value.ToString = "RVP" Or cmbordertype.SelectedItem.Value.ToString = "RF" Then
        '        chrg = val * 0.016884
        '        TOT = val * 1.016884

        '        txttranscharge.Text = chrg.ToString("N")
        '        txtsettlementamount.Text = TOT.ToString("N")
        '        txtgross.Text = val.ToString("N")
        '    ElseIf cmbordertype.SelectedItem.Value.ToString = "DVP" Or cmbordertype.SelectedItem.Value.ToString = "DF" Then
        '        If CheckBox1.Checked = True Then
        '            chrg = val * 0.014384
        '            TOT = val - (val * 0.014384)
        '            txttranscharge.Text = chrg.ToString("N")
        '            txtsettlementamount.Text = TOT.ToString("N")
        '        Else
        '            chrg = val * 0.024384
        '            TOT = val - (val * 0.024384)
        '            txttranscharge.Text = chrg.ToString("N")
        '            txtsettlementamount.Text = TOT.ToString("N")
        '        End If
        '        txtgross.Text = val.ToString("N")
        '    End If


        'Catch ex As Exception

        'End Try
        calculations()

    End Sub
    Protected Sub txtprice_TextChanged(sender As Object, e As EventArgs) Handles txtprice.TextChanged
        'Try
        '    Dim quant As Decimal = txtavailableshares.Text
        '    Dim price As Decimal = txtprice.Text
        '    Dim val As Decimal = quant * price
        '    Dim chrg, TOT As Decimal
        '    If cmbordertype.SelectedItem.Value.ToString = "RVP" Or cmbordertype.SelectedItem.Value.ToString = "RF" Then
        '        chrg = val * 0.016884
        '        TOT = val * 1.016884
        '        txttranscharge.Text = chrg.ToString("N")
        '        txtsettlementamount.Text = TOT.ToString("N")
        '        txtgross.Text = val.ToString("N")
        '    ElseIf cmbordertype.SelectedItem.Value.ToString = "DVP" Or cmbordertype.SelectedItem.Value.ToString = "DF" Then
        '        If CheckBox1.Checked = True Then
        '            chrg = val * 0.014384
        '            TOT = val - (val * 0.014384)
        '            txttranscharge.Text = chrg.ToString("N")
        '            txtsettlementamount.Text = TOT.ToString("N")
        '        Else
        '            chrg = val * 0.024384
        '            TOT = val - (val * 0.024384)
        '            txttranscharge.Text = chrg.ToString("N")
        '            txtsettlementamount.Text = TOT.ToString("N")
        '        End If
        '        txtgross.Text = val.ToString("N")
        '    End If



        'Catch ex As Exception

        'End Try
        calculations()

    End Sub
    Protected Sub txttranscharge_TextChanged(sender As Object, e As EventArgs) Handles txttranscharge.TextChanged
        Try
            Dim quant As Decimal = txtavailableshares.Text
            Dim price As Decimal = txtprice.Text
            Dim val As Decimal = quant * price
            Dim chrg As Decimal = txttranscharge.Text
            Dim settam As Decimal
            If cmbordertype.SelectedItem.Value.ToString = "RVP" Or cmbordertype.SelectedItem.Value.ToString = "RF" Then
                settam = val + chrg
                txtsettlementamount.Text = settam
            ElseIf cmbordertype.SelectedItem.Value.ToString = "DVP" Or cmbordertype.SelectedItem.Value.ToString = "DF" Then
                settam = val - chrg
                txtsettlementamount.Text = settam
            End If

        Catch ex As Exception

        End Try
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
        calculations()
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
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
    Public Sub calculations()
        Try

            Dim quant As Decimal = txtavailableshares.Text
            Dim price As Decimal = txtprice.Text
            Dim val As Decimal
            If cmbcurrency.SelectedItem.Text = cmbcurrencysett.SelectedItem.Text Then
                val = quant * price
            Else
                val = (quant * price) * txtexchangerate.Text
            End If
            Dim chrg, TOT As Decimal
            If cmbordertype.SelectedItem.Value.ToString = "DVP" Or cmbordertype.SelectedItem.Value.ToString = "DF" Then
                If cmbcurrency.SelectedItem.Text = cmbcurrencysett.SelectedItem.Text Then
                    If CheckBox1.Checked = True Then
                        chrg = val * 0.014384
                        TOT = val - (val * 0.014384)
                        txtgross.Text = val.ToString("N")
                        txttranscharge.Text = chrg.ToString("N")
                        txtsettlementamount.Text = TOT
                    Else
                        chrg = val * 0.024384
                        TOT = val - (val * 0.024384)
                        txtgross.Text = val.ToString("N")
                        txttranscharge.Text = chrg.ToString("N")
                        txtsettlementamount.Text = TOT

                    End If
                Else
                    If CheckBox1.Checked = True Then
                        chrg = val * 0.014384
                        TOT = val - (val * 0.014384)
                        Dim rte As Decimal = txtexchangerate.Text
                        chrg = chrg
                        TOT = TOT
                        txttranscharge.Text = chrg.ToString("N")
                        txtsettlementamount.Text = TOT
                        txtgross.Text = val.ToString("N")
                    Else
                        chrg = val * 0.024384
                        TOT = val - (val * 0.024384)
                        Dim rte As Decimal = txtexchangerate.Text
                        chrg = chrg
                        TOT = TOT
                        txtgross.Text = val.ToString("N")
                        txttranscharge.Text = chrg.ToString("N")
                        txtsettlementamount.Text = TOT
                    End If

                End If
            ElseIf cmbordertype.SelectedItem.Value.ToString = "RVP" Or cmbordertype.SelectedItem.Value.ToString = "RF" Then
                If cmbcurrency.SelectedItem.Text = cmbcurrencysett.SelectedItem.Text Then
                    chrg = val * 0.016884
                    TOT = val * 1.016884
                    txttranscharge.Text = chrg.ToString("N")
                    txtsettlementamount.Text = TOT.ToString("N")
                    txtgross.Text = val.ToString("N")
                Else
                    chrg = val * 0.016884
                    TOT = val * 1.016884
                    Dim rte As Decimal = txtexchangerate.Text
                    chrg = chrg
                    TOT = TOT
                    txttranscharge.Text = chrg.ToString("N")
                    txtsettlementamount.Text = TOT.ToString("N")
                    txtgross.Text = val.ToString("N")
                End If

            End If

            'Try
            '    If cmbcurrency.SelectedItem.Text <> cmbcurrencysett.SelectedItem.Text Then
            '        txtexchangerate.ReadOnly = False
            '        txtexchangerate.Text = ""
            '    Else
            '        txtexchangerate.ReadOnly = True
            '        txtexchangerate.Text = "0"
            '    End If
            'Catch ex As Exception
            'End Try





        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        cmd = New SqlCommand("delete from  Custodian_Trades where id='" + lblid.Text + "'", cn)
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
        If cmbordertype.SelectedItem.Text = "RF" Then

        Else

        End If
    End Sub
    Protected Sub ASPxButton17_Click(sender As Object, e As EventArgs) Handles ASPxButton17.Click
        Dim keys As List(Of Object) = grdpendingsettlement.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grdpendingsettlement.FindRowCellTemplateControlByKey(key, TryCast(grdpendingsettlement.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                updatesettled(key)


            End If
        Next
        getpending()
        msgbox("Status Successfully Updated!")
    End Sub
    Protected Sub ASPxButton18_Click(sender As Object, e As EventArgs) Handles ASPxButton18.Click
        Dim keys As List(Of Object) = grdpendingsettlement.GetCurrentPageRowValues(New String() {"id"})
        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grdpendingsettlement.FindRowCellTemplateControlByKey(key, TryCast(grdpendingsettlement.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                updatefailed(key)

            End If
        Next
        getpending()
        msgbox("Status Successfully Updated!")
    End Sub

    Private Sub grdsettled_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdsettled.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View" Then
            getdetails(id, "")
            ASPxButton16.Visible = False
        End If
    End Sub

    Private Sub grdfailed_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdfailed.RowCommand

    End Sub

    Private Sub grdpendingsettlement_DataBinding(sender As Object, e As EventArgs) Handles grdpendingsettlement.DataBinding
        grdpendingsettlement.DataSource = pendingdata()

    End Sub

    Private Sub grdrejected_DataBinding(sender As Object, e As EventArgs) Handles grdrejected.DataBinding
        grdrejected.DataSource = pendingdata_rejected()

    End Sub
    Public Function pendingdata_rejected() As DataSet

        Dim ds As New DataSet
        cmd = New SqlCommand(" select *, a.Surname+' '+a.forenames as [Names] from custodian_trades c, Accounts_clients a where c.clientno=a.cds_number and rejected='1'  and ApprovedBy is NULL and tradestatus='EDIT'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds

        Else
            Return Nothing
        End If
    End Function
End Class