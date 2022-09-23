Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_ReceiptTransfer
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
            If Session("finish") = "yes" Then
                Session("finish") = ""
                ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                ASPxPopupControl1.AllowDragging = True
                ASPxPopupControl1.ShowCloseButton = True
                ASPxPopupControl1.ShowOnPageLoad = True
                Page.MaintainScrollPositionOnPostBack = True
                lbltransid.Text = Session("mymy")
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "resubmit" Then
                Session("finish") = ""
                ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                ASPxPopupControl1.AllowDragging = True
                ASPxPopupControl1.ShowCloseButton = True
                ASPxPopupControl1.ShowOnPageLoad = True
                Page.MaintainScrollPositionOnPostBack = True
                lbltransid.Text = Session("mymy")

                msgbox(Session("msg"))
                Session("msg") = ""

            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

                getpending()
                loadcomboforreceipts(txtewrholder.Text)
                getrejected()

            Else
                loadcomboforreceipts(txtewrholder.Text)
            End If
            getrejected()
            getpending()
            loadcomboforreceipts(txtewrholder.Text)
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




    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Try

            If ASPxButton13.Text = "Transfer" Then

                Dim av As Double = txtavailableshares.Text
                Dim totrans As Double = txtshares.Text

                If av < totrans Then
                    msgbox("Please enter units less or equal to available units!")
                    Exit Sub

                Else
                    'Dim bal As Decimal = av - pendingbalance(cmbparaCompany.Value.ToString)
                    'If bal < totrans Then
                    '    msgbox("Account has a Pending Transaction of " + pendingbalance(cmbparaCompany.Value.ToString).ToString + " Units.")
                    '    Exit Sub
                    'End If
                    If pendingbalance(cmbparaCompany.Value.ToString) <> "" Then
                        msgbox(pendingbalance(cmbparaCompany.Value.ToString))
                        Exit Sub

                        Exit Sub
                    End If
                    Dim xyz As New Common

                    If xyz.OTPenabled = True Then
                        Dim OTP As String = CreateRandomPassword(4)
                        Dim z As New sendmail
                        Try
                            z.sendmail(getemail(txtewraccountno.Text), "Transfer Authorization Request", "A transfer on EWR No. " + cmbparaCompany.Value + " for " + txtshares.Text + " has been initiated in your account. Please authorize using OTP: " + OTP.ToString + "")
                        Catch ex As Exception
                            msgbox("Error Sending Email:" + ex.Message + "")
                        End Try

                        cmd = New SqlCommand("insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent, OTPCreateTime) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + txttransfereeaccount.Text + "',getdate(),'0','0','" + cmbparaCompany.Value + "','" + cmbparaCompany.Value + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + OTP + "','1',getdate())", cn)
                    Else
                        cmd = New SqlCommand("insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + txttransfereeaccount.Text + "',getdate(),'0','0','" + cmbparaCompany.Value + "','" + cmbparaCompany.Value + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "')", cn)
                    End If


                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Try
                        Dim m As New NaymatBilling
                        Dim charge As Double = m.transfercharges("BILL", "DEPOSITOR", txtshares.Text, txtewraccountno.Text.ToString, cmbparaCompany.Text)
                        txtcharge.Text = charge
                    Catch ex As Exception
                        msgbox("Error Charging: " + ex.Message)
                    End Try

                    updatewithRef(Session("autogen"), transid.ToString, "Transfer")

                    Try
                        Dim a As New passmanagement
                        a.auditlog(Session("BrokerCode"), Session("Username"), "Submitted a Transfer Request", txtewraccountno.Text, cmbparaCompany.Text)
                    Catch ex As Exception

                    End Try

                    Session("finish") = "yes"
                    Session("mymy") = transid.ToString
                    Session("msg") = "Transfer request on EWR No. " + cmbparaCompany.Value.ToString + " captured successfully.Transaction ID is " + transid.ToString + "."
                    Response.Redirect(Request.RawUrl)

                End If
            Else

                Dim xyz As New Common
                If xyz.OTPenabled = True Then
                    Dim OTP As String = CreateRandomPassword(4)
                    Dim z As New sendmail
                    Try
                        z.sendmail(getemail(txtewraccountno.Text), "Transfer Authorization Request", "A Transfer on EWR No. " + cmbparaCompany.Value.ToString + " for " + txtshares.Text + " to " + txttransfereeaccount.Text + " has been initiated in your account. Please authorize using OTP: " + OTP.ToString + "")
                    Catch ex As Exception
                        msgbox("Error Sending Email:" + ex.Message + "")
                    End Try

                    cmd = New SqlCommand("delete from share_transfer where id='" + lblid.Text + "' insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent, OTPCreateTime) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + txttransfereeaccount.Text + "',getdate(),'0','0','" + cmbparaCompany.SelectedItem.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + OTP + "','1',getdate())", cn)

                Else
                    cmd = New SqlCommand("delete from share_transfer where id='" + lblid.Text + "' insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + txttransfereeaccount.Text + "',getdate(),'0','0','" + cmbparaCompany.SelectedItem.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "')", cn)
                End If

                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "resubmit"
                Session("mymy") = transid.ToString
                Session("msg") = "Transfer request on EWR No. " + cmbparaCompany.Value.ToString + " has been re-submitted  successfully.Transaction ID is " + transid.ToString + "."
                Response.Redirect(Request.RawUrl)

            End If
        Catch ex As Exception
            msgbox("Error saving transaction, Error details: " + ex.Message)
        End Try

    End Sub
    Public Sub updatewithRef(autog As String, newref As String, typetrans As String)
        cmd = New SqlCommand("update Transaction_Documents set TransactionRef='" + newref + "' where TransactionRef='" + autog + "' and TransactionType='" + typetrans + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
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
        cmd = New SqlCommand("select max(id) as id from share_transfer", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("id").ToString
        Else
            Return ""
        End If
    End Function

    Public Sub getpending()
        Try
            Dim ds As New DataSet
            Dim xyz As New Common
            If xyz.OTPenabled = True Then
                cmd = New SqlCommand("select w.id, case when w.OTPStatus IS NULL and w.ApprovedBy is NULL THEN 'Enter OTP' else 'N/A' end as [otp] , W.transferor as [Account No],w.transferee, wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], FORMAT(W.amount_to_transfer,'#,###.##','en-us') AS amount_to_transfer ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from share_transfer W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and deleted is NULL", cn)
            Else
                cmd = New SqlCommand("select w.id, 'N/A' as otp , W.transferor as [Account No],w.transferee, wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date],  FORMAT(W.amount_to_transfer,'#,###.##','en-us') AS amount_to_transfer ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from share_transfer W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and deleted is NULL", cn)
            End If

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView3.DataSource = ds
                ASPxGridView3.DataBind()
            Else
                ASPxGridView3.DataSource = Nothing
                ASPxGridView3.DataBind()
            End If
        Catch ex As Exception
            msgbox("Error getting pending : " + ex.Message)
        End Try
    End Sub
    Public Sub getrejected()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select w.id, W.transferor as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending'  when w.rejected='1'  THEN 'Rejected' else 'Approved' end as  [Status],  W.[Date], FORMAT(W.amount_to_transfer,'#,###.##','en-us') AS amount_to_transfer ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from share_transfer W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and w.deleted is Null and w.rejected is NOT NULL and deleted is NULL", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView4.DataSource = ds
                ASPxGridView4.DataBind()
            Else
                ASPxGridView4.DataSource = Nothing
                ASPxGridView4.DataBind()
            End If
        Catch ex As Exception
            msgbox("Error getting rejected: " + ex.Message)
        End Try
    End Sub
    Public Function pendingbalance(receipt As String) As String
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select status from pendingtrans where receiptid='" + receipt + "' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "names")
            If (ds1.Tables(0).Rows.Count > 0) Then
                Return ds1.Tables(0).Rows(0).Item("status").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            msgbox("Error getting pending transactions : " + ex.Message)
        End Try
    End Function



    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        'If txtclientnumber0.Text = "" Then
        '    msgbox("Please enter Account No./Name to search")
        '    Exit Sub
        'End If
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+ isnull(forenames,'') +' '+isnull(surname,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' and AccountState='A' order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                ListBox1.DataSource = ds
                ListBox1.DataTextField = "names"
                ListBox1.DataValueField = "cds_number"
                ListBox1.DataBind()

            End If

        Catch ex As Exception
            msgbox("Error searching clients: " + ex.Message)
        End Try
    End Sub

    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select quantity as available from wr where receiptno='" + cmbparaCompany.Value.ToString + "' and holder='" + txtewraccountno.Text + "' and quantity>0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString
                txtshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString

                Dim m As New NaymatBilling
                Dim transcharge As Double = m.transfercharges("ENQUIRE", "DEPOSITOR", txtshares.Text, ListBox1.SelectedValue.ToString, cmbparaCompany.Value.ToString)
                Dim charge As Double = m.getEWRBAL(cmbparaCompany.Value.ToString, ListBox1.SelectedValue.ToString)
                Dim globcharge As Double = m.getholderbal(ListBox1.SelectedValue.ToString, Session("BrokerCode"))
                txtcharge.Text = charge.ToString("N")
                txttotalcharges.Text = globcharge.ToString("N")
                txttranscharge.Text = transcharge.ToString("N")
                Session("autogen") = CreateRandomPassword(20)
            Else

                txtavailableshares.Text = 0
                txtshares.Text = 0
            End If

        Catch ex As Exception
            msgbox("Error getting details for selected EWR: " + ex.Message)
        End Try



    End Sub


    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
            ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names1")
            If (ds.Tables(0).Rows.Count > 0) Then


                txtAccountNo.Text = Session("BrokerCode")
                txtparticipantname.Text = partname(Session("BrokerCode"))
                txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
                txtewraccountno.Text = ListBox1.SelectedValue.ToString

                txtavailableshares.Text = 0
                txtshares.Text = 0
                loadcomboforreceipts(ListBox1.SelectedValue.ToString)


            End If
        Catch ex As Exception
            msgbox("Error getting transferor details: " + ex.Message)
        End Try
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
    Public Sub loadcomboforreceipts(holder As String)
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select * from WR where holder='" + holder + "' and [Status]='ISSUED' and quantity>0 and status='ISSUED' and warehouse='" + Session("BrokerCode") + "' and receiptno not in (select receiptid from pendingtrans)", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                cmbparaCompany.DataSource = dsport

                cmbparaCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox("Error extracting receipts for holder : " + ex.Message)
        End Try
    End Sub



    Private Sub cmbparaCompany_ValueChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.ValueChanged

        loadcomboforreceipts(ListBox1.SelectedValue.ToString)

    End Sub

    Private Sub ASPxGridView4_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView4.RowCommand
        Try
            Dim id As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName.ToString = "Edit" Then
                getdetails(id)
            End If
            If e.CommandArgs.CommandName.ToString = "delete" Then
                flagdelete(id)
                getrejected()

            End If
        Catch ex As Exception
            msgbox("Error GRD 4 Row Command: " + ex.Message)
        End Try
    End Sub
    Public Sub getdetails(id As String)
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select w.id, c.Company_name, w.ParticipantCode, w.transferor, w.ReceiptID, w.amount_to_transfer , a.surname+' '+Forenames as [Names]  FROM Client_Companies C, share_transfer w, wr wr , Accounts_Clients a where c.Company_Code= w.ParticipantCode and w.transferor=a.CDS_Number and w.id='" + id + "' and wr.ReceiptNo=w.ReceiptID", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                txtAccountNo.Text = dsport.Tables(0).Rows(0).Item("ParticipantCode").ToString
                txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("amount_to_transfer").ToString
                txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("transferor").ToString
                txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Names").ToString
                txtparticipantname.Text = dsport.Tables(0).Rows(0).Item("company_name").ToString
                cmbparaCompany.Value = dsport.Tables(0).Rows(0).Item("receiptid").ToString
                txtshares.Text = dsport.Tables(0).Rows(0).Item("amount_to_transfer").ToString
                ASPxButton13.Text = "Re-Submit Transfer"
                lblid.Text = id.ToString
            End If
        Catch ex As Exception
            msgbox("Error on getting transfer details : " + ex.Message)
        End Try

    End Sub
    Public Function getotp(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTP,'') as OTP from share_transfer where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("OTP").ToString
        End If
    End Function
    Public Function OTPApproved(id As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTPStatus,'') as [status] from share_transfer where id='" + id + "'", cn)
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
    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Try
            Dim id As String = e.KeyValue.ToString
            If e.CommandArgs.CommandName.ToString = "Delete" Then
                If deletable(id.ToString) = True Then
                    flagdelete(id.ToString)
                    reversertransaction(id.ToString)
                    getpending()

                Else
                    msgbox("Approved Transactions cannot be deleted!")
                End If
            ElseIf e.CommandArgs.CommandName.ToString = "OTP" Then
                If getotp(id) = "" Then
                    msgbox("No OTP generated for Transaction! Cancel Transaction and re-capture.")
                    Exit Sub
                End If
                If OTPApproved(id) = True Then

                    Exit Sub
                End If

                ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                ASPxPopupControl1.AllowDragging = True
                ASPxPopupControl1.ShowCloseButton = True
                ASPxPopupControl1.ShowOnPageLoad = True
                Page.MaintainScrollPositionOnPostBack = True
                lbltransid.Text = id.ToString
            End If
        Catch ex As Exception
            msgbox("Error row command deletable: " + ex.Message)
        End Try
    End Sub
    Public Sub reversertransaction(id As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select transferor, ReceiptID, amount_to_transfer  FROM share_transfer where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Dim holder As String = dsport.Tables(0).Rows(0).Item("transferor").ToString
            Dim receiptno As String = dsport.Tables(0).Rows(0).Item("ReceiptID").ToString
            Dim quant As String = dsport.Tables(0).Rows(0).Item("amount_to_transfer").ToString

            Try
                Dim m As New NaymatBilling
                Dim charge As Double = m.transfercharges_REVERSAL("BILL", "DEPOSITOR", quant, holder, receiptno)
                txtcharge.Text = charge
            Catch ex As Exception
                msgbox("Error Reversal Charging: " + ex.Message)
            End Try
        End If

    End Sub
    Public Function deletable(idn As String) As Boolean
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select * from  share_transfer where ApprovedBy is NULL and id='" + idn + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            msgbox("Error checking deletable : " + ex.Message)
        End Try
    End Function
    Public Sub flagdelete(ref As String)
        Try
            cmd = New SqlCommand("update share_transfer set deleted='1'  where id='" + ref + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox("Error updating cancelled: " + ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select cds_number, cds_number+' '+forenames+' '+surname as names  from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'')  like '%" + txtsearchtransferee.Text + "%' and cds_number<>'" + txtewraccountno.Text + "' and AccountState='A' ORDER BY cds_number ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                lsttransferee.DataSource = dsport
                lsttransferee.DataTextField = "names"
                lsttransferee.DataValueField = "cds_number"
                lsttransferee.DataBind()

            End If
        Catch ex As Exception
            msgbox("Error loading transferee: " + ex.Message)
        End Try
    End Sub
    Protected Sub lsttransferee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsttransferee.SelectedIndexChanged
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select cds_number,+forenames+' '+surname as names  from accounts_clients where cds_number='" + lsttransferee.SelectedValue.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                txttransfereeaccount.Text = lsttransferee.SelectedValue.ToString
                txttransfereename.Text = dsport.Tables(0).Rows(0).Item("names").ToString

            End If
        Catch ex As Exception
            msgbox("Error loading transferee: " + ex.Message)
        End Try

    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click
        If getotp(lbltransid.Text) <> txtotp.Text Then
            msgbox("Invalid OTP!")
            Exit Sub
        ElseIf getotp(lbltransid.Text) = txtotp.Text Then
            cmd = New SqlCommand("update share_transfer set OTPStatus='Approved', OTPResponseTime=getdate()   where id='" + lbltransid.Text + "'", cn)
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

            msgbox("OTP Correct! Transfer sent for approval")


        Else
            msgbox("Failed")
        End If

    End Sub
    Protected Sub ASPxButton16_Click(sender As Object, e As EventArgs) Handles ASPxButton16.Click
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

        Dim ma As New Common

        If ma.Document_Upload(fs, filePath, txtdocumentname.Text, ext, filename, "Transfer", txtewraccountno.Text, Session("autogen"), bytes).ToString <> "Upload Successful" Then
            msgbox("Document Upload failed!")
            Exit Sub
        Else
            getdocuments(Session("autogen"), "Transfer")
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

    Private Sub grddocuments_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grddocuments.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then

            Try
                pd(Session("autogen"), "Transfer")
            Catch ex As Exception
            End Try
            Try
                word(Session("autogen"), "Transfer")
            Catch ex As Exception
            End Try
            Try
                xls(Session("autogen"), "Transfer")
            Catch ex As Exception
            End Try
            Try
                Img(Session("autogen"), "Transfer")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            deletedocument(Session("autogen"), "Transfer")
            getdocuments(Session("autogen"), "Transfer")
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
End Class
