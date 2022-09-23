Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ApproveMoneyMarketCallback

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

                Page.MaintainScrollPositionOnPostBack = True
                msgbox(Session("msg"))
                Session("msg") = ""
            End If

            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

                getpending()



            Else
                getpending()

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
        cmd = New SqlCommand("select *, a.Surname+' '+a.forenames as ClientName,  (select Amount from MoneyMarketCallback where TradeRef=m.id) as CallbackAmount from Moneymarket m, Accounts_clients a where  m.rejected is NULL and m.clientno=a.cds_number  and m.id in (select traderef from MoneyMarketCallback where ApprovedBy is NULL and Rejected is NULL)", cn)
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
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and transactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and transactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and transactionType='" + transtype + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String, transtype As String)
        Dim strQuery As String = "select [filename] as nm, [data],Extension from Transaction_Documents where transactionref='" + id + "' and transactionType='" + transtype + "'"
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
        If e.CommandArgs.CommandName.ToString = "View Money Market" Then

            'Try
            '    pd(id, "MONEY MARKET")
            'Catch ex As Exception
            'End Try
            'Try
            '    word(id, "MONEY MARKET")
            'Catch ex As Exception
            'End Try
            'Try

            '    xls(id, "MONEY MARKET")
            '    ' msgbox("m")
            'Catch ex As Exception
            'End Try
            'Try
            '    Img(id, "MONEY MARKET")
            'Catch ex As Exception
            'End Try


            getdetails(id, "Approve")

            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            Page.MaintainScrollPositionOnPostBack = True


        ElseIf e.CommandArgs.CommandName.ToString = "Approve Transaction" Then
            Try

                cmd = New SqlCommand("update Moneymarket set TradeStatus='CALLBACK' where id='" + id + "' update MoneymarketCallback set ApprovedBy='" + Session("Username") + "', Approved='1', DateApproved=getdate() where TradeRef='" + id + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                getpending()
                msgbox("Transaction Successfully Approved")

            Catch ex As Exception
                msgbox(ex.Message)
            End Try

        ElseIf e.CommandArgs.CommandName.ToString = "Decline Transaction" Then
            'Dim m As New sendmail
            'Dim transtyp As String = pendtrans(id).Tables(0).Rows(0).Item("transtype").ToString
            'Dim amt As String = pendtrans(id).Tables(0).Rows(0).Item("Amount").ToString
            'Dim emaill As String = pendtrans(id).Tables(0).Rows(0).Item("email").ToString

            'Try
            '    m.sendmail(emaill, "Trade Declined", "Your trade of " + amt.ToString() + " for " + transtyp + " has been declined, kindly re-submit your deposit and attach proof of payment!")

            'Catch ex As Exception

            'End Try


            cmd = New SqlCommand("update MoneymarketCallback set Rejected='1', RejectionReason='REJECTED BY ADMIN', RejectedDate=getdate() where Traderef='" + id + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getpending()
            msgbox("Transaction Declined")

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
    Public Sub getdetails(id As String, transtype As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * ,datediff(day, tradeDate, MaturityDate) as days, (select Amount from MoneyMarketCallback where TradeRef=c.id) as CallbackAmount  from MoneyMarket c, Accounts_Clients a where c.ClientNo=a.CDS_Number and c.id='" + id + "'", cn)
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
            txtcallbackamount.Text = dsport.Tables(0).Rows(0).Item("CallbackAmount").ToString
            ASPxButton13.Text = transtype
            lblid.Text = id.ToString
            '   txtAccountNo.Text = Session("BrokerCode")
            '  txtparticipantname.Text = partname(Session("BrokerCode"))
            getdocuments(id.ToString, "MONEY MARKET")
        End If


    End Sub
    Public Sub getdocuments(ref As String, transtyp As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Transaction_Documents where transactionref='" + ref + "' and TransactionType='" + transtyp + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsport
            ASPxGridView1.DataBind()
        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
    End Sub

    Private Sub ASPxGridView1_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then

            Try
                pd(lblid.Text, "MONEY MARKET")
            Catch ex As Exception
            End Try
            Try
                word(lblid.Text, "MONEY MARKET")
            Catch ex As Exception
            End Try
            Try
                xls(lblid.Text, "MONEY MARKET")
            Catch ex As Exception
            End Try
            Try
                Img(lblid.Text, "MONEY MARKET")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            msgbox("Not Allowed!")
        End If
    End Sub
    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Try

            cmd = New SqlCommand("update Moneymarket set TradeStatus='CALLBACK' where id='" + lblid.Text + "' update MoneymarketCallback set ApprovedBy='" + Session("Username") + "', Approved='1', DateApproved=getdate() where TradeRef='" + lblid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getpending()

            ASPxPopupControl1.AllowDragging = False
            ASPxPopupControl1.ShowCloseButton = False
            ASPxPopupControl1.ShowOnPageLoad = False

            msgbox("Money Market Callback Transaction Successfully Approved")

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        Try
            cmd = New SqlCommand("update MoneymarketCallback set Rejected='1', RejectionReason='REJECTED BY ADMIN', RejectedDate=getdate() where Traderef='" + lblid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getpending()

            ASPxPopupControl1.AllowDragging = False
            ASPxPopupControl1.ShowCloseButton = False
            ASPxPopupControl1.ShowOnPageLoad = False

            msgbox("Transaction Declined")

        Catch ex As Exception

        End Try
    End Sub
End Class