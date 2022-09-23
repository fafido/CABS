Imports System.Collections.Generic
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ApproveNewStat

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
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "rejected" Then
                Session("finish") = ""
                msgbox(Session("msg"))
                Session("msg") = ""
            End If

            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

                getpending()
                getauthorized()
                GETREJECTED()



            Else

                getauthorized()
                GETREJECTED()


            End If

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
    Public Sub getpending()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.Surname+' '+a.forenames as [Names], (select settlementAmount from custodian_trades where id=c.Ref2) as [SettlementAmount],(select SettlementDate from custodian_trades where id=c.Ref2) as [SettlementDate] from Custodian_Trades_Comm c, Accounts_clients a where a.cds_number=c.clientNo and ApprovedBy is NULL and rejected is NULL and SettlementDate>(select top 1 convert(date,fordate) from Recon_AssetManager where company=c.company and AssetManager=c.AssetManager order by id desc )", cn)
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
    Public Function pendingdat() As DataSet

        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.Surname+' '+a.forenames as [Names], (select settlementAmount from custodian_trades where id=c.Ref2) as [SettlementAmount],(select SettlementDate from custodian_trades where id=c.Ref2) as [SettlementDate] from Custodian_Trades_Comm c, Accounts_clients a where a.cds_number=c.clientNo and ApprovedBy is NULL and rejected is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport
        Else
            Return Nothing
        End If
        End Function
    Public Sub getauthorized()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.surname+' '+a.forenames as [ClientName] from Custodian_Trades c, Accounts_clients a where c.ApprovedBy is NOT NULL and c.rejected is NULL and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdauthorized.DataSource = dsport
            grdauthorized.DataBind()
        Else
            grdauthorized.DataSource = Nothing
            grdauthorized.DataBind()
        End If
    End Sub
    Public Sub GETREJECTED()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, a.surname+' '+a.forenames as [ClientName] from Custodian_Trades c, Accounts_clients a   where c.ApprovedBy is NULL and c.rejected is NOT NULL and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdrejected.DataSource = dsport
            grdrejected.DataBind()
        Else
            grdrejected.DataSource = Nothing
            grdrejected.DataBind()
        End If
    End Sub
    Public Function pendtrans(idn As String) As DataSet
        Dim dsport As New DataSet
        cmd = New SqlCommand("select email, c.Transtype,c.Amount  from Accounts_Clients A, CashTrans_Audit C where a.CDS_Number=c.CDS_Number and c.id='" + idn + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport
        Else
            Return Nothing
        End If

    End Function

    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        '  Try
        con.Open()
        sda.SelectCommand = cmd
        sda.Fill(dt)
        Return dt
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        '    Return Nothing
        'Finally
        '    con.Close()
        '    sda.Dispose()
        '    con.Dispose()
        'End Try
    End Function
    Public Sub pd(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof'  + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof'  + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof'  + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select 'Payment Proof' + Extension as nm, [data],Extension from CashTrans_Audit where ID='" + id + "'"
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
    Public Sub getdetails(id As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from custodian_trades c, accounts_clients a where c.id=(select Ref2 from custodian_trades_comm where id='" + id + "') and c.clientNo=a.cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("Units").ToString
            txtereference.Text = dsport.Tables(0).Rows(0).Item("TradeRef").ToString
            txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("ClientNo").ToString
            txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Surname").ToString + " " + dsport.Tables(0).Rows(0).Item("forenames").ToString
            txtprice.Text = dsport.Tables(0).Rows(0).Item("Price").ToString
            Dim grss As Decimal
            Dim price As Decimal = txtprice.Text
            Dim quant As Decimal = txtavailableshares.Text
            grss = price * quant

            txttranscharge.Text = dsport.Tables(0).Rows(0).Item("TradeCharge").ToString
            cmbassetmanager.Text = dsport.Tables(0).Rows(0).Item("AssetManager").ToString
            cmbcurrency.Text = dsport.Tables(0).Rows(0).Item("Currency").ToString
            cmbordertype.Text = dsport.Tables(0).Rows(0).Item("TradeType").ToString
            cmbparaCompany.Text = dsport.Tables(0).Rows(0).Item("Company").ToString
            dtfrom.Date = dsport.Tables(0).Rows(0).Item("TradeDate").ToString
            dtsettlementdate.Date = dsport.Tables(0).Rows(0).Item("SettlementDate").ToString
            txtcapturedby.Text = dsport.Tables(0).Rows(0).Item("CapturedBy").ToString
            txtcdcaccount.Text = dsport.Tables(0).Rows(0).Item("CDCAccount").ToString
            txtstatus.Text = dsport.Tables(0).Rows(0).Item("TradeStatus").ToString
            txtsettlementamount.Text = dsport.Tables(0).Rows(0).Item("SettlementAmount").ToString
            dtcaptured.Date = dsport.Tables(0).Rows(0).Item("CapturedDate").ToString
            txtgross.Text = grss.ToString
            txtexchangerate.Text = dsport.Tables(0).Rows(0).Item("ExchangeRate").ToString
            txtsettlementcurrency.Text = dsport.Tables(0).Rows(0).Item("SettlementCurrency").ToString

        End If
    End Sub
    Public Function moneybalance(currency As String, assetmanager As String, clientno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT isnull(sum(amount),0) as amt  FROM moneybals where currency='" + currency + "' and cds_number='" + clientno + "' and AssetManager='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("amt")
        End If
    End Function
    Private Function dealdetails(ids As String) As DataSet
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Custodian_Trades where id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + ids + "') ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds
        Else
            Return Nothing
        End If
    End Function
    Public Sub approvetrans(transid As String)

        Dim settleamt As Decimal = dealdetails(transid).Tables(0).Rows(0).Item("SettlementAmount").ToString

        Dim curre As String = dealdetails(transid).Tables(0).Rows(0).Item("SettlementCurrency").ToString
        Dim assetmana As String = dealdetails(transid).Tables(0).Rows(0).Item("AssetManager").ToString
        Dim acnt As String = dealdetails(transid).Tables(0).Rows(0).Item("ClientNo").ToString
        Dim TradeType As String = dealdetails(transid).Tables(0).Rows(0).Item("TradeType").ToString


        'If TradeType = "RVP" Then

        '    Dim moneybal As Decimal = moneybalance(curre, assetmana, acnt)

        '    If settleamt > moneybal Then
        '        Session("failures") = "true"
        '        msgbox("Account has insufficient balance to perfom this transaction. Available " + curre + " balance is " + moneybal.ToString("N") + " under " + assetmana + "")
        '        Exit Sub
        '    End If

        'End If

        cmd = New SqlCommand("update Custodian_Trades_Comm set ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + transid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()

        cmd = New SqlCommand("insert into trans (Company, CDS_Number, Date_Created, Trans_Time, Shares  , Update_Type, Created_By, Batch_Ref, Source, Pledge_shares, Reference, Instrument, [Broker], Custodian, AssetManager) select Company, ClientNo , SettlementDate, getdate(), CASE TradeType when 'RVP'  then Units when 'RF' then Units when 'DVP' then Units*-1  when 'DF' then Units*-1 else 0  end as [Shares], 'EQUITY TRADE - ' + TradeType, '" + Session("Username") + "', id, 'D', '0', TradeRef , 'EQUITY', [Broker], 'CABS', AssetManager from Custodian_Trades where id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='SETTLED')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()

        cmd = New SqlCommand("insert into cashtrans ([Description], TransType , Amount, DateCreated , TransStatus , CDS_Number, Reference,AssetManager, BankName, BankAccount, Ref2, PostedBy, Currency)  select TOP 1 TradeType+ ' - '+ convert(nvarchar(50),Units)+ ' '+ Company +' @ '+ convert(nvarchar(50),price) , 'DVP Equity Trade' , SettlementAmount, SettlementDate , '1' , c.ClientNo , c.id,c.AssetManager, BankName, BankAccount, TradeRef , '" + Session("Username") + "', SettlementCurrency from Custodian_Trades c, Client_AssetManagers ca where ca.clientno=c.ClientNo and c.SettlementCurrency=ca.Currency and c.AssetManager=ca.AssetManager and c.id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='SETTLED') AND TradeType='DVP'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("insert into cashtrans ([Description], TransType , Amount, DateCreated , TransStatus , CDS_Number, Reference,AssetManager, BankName, BankAccount, Ref2, PostedBy, Currency)  select TOP 1 TradeType+ ' - '+ convert(nvarchar(50),Units)+ ' '+ Company +' @ '+ convert(nvarchar(50),price) , 'RVP Equity Trade' , SettlementAmount*-1, SettlementDate , '1' , c.ClientNo , c.id,c.AssetManager, BankName, BankAccount, TradeRef , '" + Session("Username") + "', SettlementCurrency from Custodian_Trades c, Client_AssetManagers ca where ca.clientno=c.ClientNo and c.SettlementCurrency=ca.Currency and c.AssetManager=ca.AssetManager and c.id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='SETTLED') AND TradeType='RVP'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        '
        cmd = New SqlCommand("insert into Bank_Transfers_Audit (DebitAccountNumber, CreditAccountNumber, Currency, Amount, TransactionDate, Response, Processed, DrCDSNumber, CrCDSNumber, BankFrom, BankTo, [Description] ) SELECT ca.BankAccount ,(select top 1 index_type  from para_company where company=c.Company),'USD',SettlementAmount ,format(getdate(),'yyyyMMdd'), NULL,'0' ,ca.ClientNo , 'SETTLEMENT','CABS', 'CABS', convert(nvarchar(50),c.TradeRef)   from Custodian_Trades c, Client_AssetManagers ca where ca.clientno=c.ClientNo and c.SettlementCurrency=ca.Currency and c.AssetManager=ca.AssetManager and c.id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='SETTLED') AND TradeType='RVP'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


        '
        cmd = New SqlCommand("insert into Bank_Transfers_Audit (DebitAccountNumber, CreditAccountNumber, Currency, Amount, TransactionDate, Response, Processed, DrCDSNumber, CrCDSNumber, BankFrom, BankTo, [Description] ) SELECT (select top 1 index_type  from para_company where company=c.Company),ca.BankAccount,'USD',SettlementAmount ,format(getdate(),'yyyyMMdd'), NULL,'0' , 'SETTLEMENT',ca.ClientNo ,'CABS', 'CABS', convert(nvarchar(50), c.TradeRef)   from Custodian_Trades c, Client_AssetManagers ca where ca.clientno=c.ClientNo and c.SettlementCurrency=ca.Currency and c.AssetManager=ca.AssetManager and c.id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='SETTLED') AND TradeType='DVP'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("Update Custodian_Trades set TradeStatus='SETTLED' where id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='SETTLED')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("Update Custodian_Trades set TradeStatus='FAILED' where id=(select top 1 ref2 from Custodian_Trades_Comm where id='" + transid + "' and TradeStatus='FAILED')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub rejecttrans(transid As String)
        cmd = New SqlCommand("update Custodian_Trades_Comm set Rejected='1', RejectionReason='REJECTED BY ADMIN' where id='" + transid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub
    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Details" Then

            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True

            ASPxButton13.Visible = True
            ASPxButton14.Visible = True

            getdetails(id)
            lblid.Text = id.ToString

        ElseIf e.CommandArgs.CommandName.ToString = "Approve Transaction" Then
            'Try


            approvetrans(id)

                If Session("failures") = "true" Then
                    Session("failures") = ""
                    Session("msg") = "Transaction Failed due to insufficient Balance!"
                    Session("finish") = "true"
                Else
                    Session("msg") = "Transaction Successfully Apporoved!"
                    Session("finish") = "true"
                End If

                Response.Redirect(Request.RawUrl)

                'Catch ex As Exception
                '    'msgbox(ex.Message)
                'End Try

                ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then
            Try
                rejecttrans(id)
                Session("msg") = "Transaction Rejected!"
                Session("finish") = "rejected"
                Response.Redirect(Request.RawUrl)

            Catch ex As Exception
                '  msgbox(ex.Message)
            End Try



        End If

    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        approvetrans(lblid.Text)

        If Session("failures") = "true" Then
            Session("failures") = ""
            Session("msg") = "Transaction Failed due to insufficient Balance!"
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Else
            Session("msg") = "Transaction Successfully Approved!"
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        End If

    End Sub
    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        rejecttrans(lblid.Text)
        Session("msg") = "Transaction Rejected!"
        Session("finish") = "rejected"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvetrans(key.ToString)

            End If


        Next
        If Session("failures") = "true" Then
            Session("failures") = ""
            Session("msg") = "Some transactions may have failed due to insufficient Balance!"
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        Else
            Session("msg") = "Transaction(s) Successfully Approved!"
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)
        End If



    End Sub
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
        Dim keys As List(Of Object) = grddocuments.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(grddocuments.FindRowCellTemplateControlByKey(key, TryCast(grddocuments.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                rejecttrans(key.ToString)

            End If


        Next

        Session("msg") = "Transaction(s) Rejected"
        Session("finish") = "rejected"
        Response.Redirect(Request.RawUrl)

    End Sub

    Private Sub grddocuments_DataBinding(sender As Object, e As EventArgs) Handles grddocuments.DataBinding
        grddocuments.DataSource = pendingdat()

    End Sub
End Class