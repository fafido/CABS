Imports System.IO
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_vaultout
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

                ' ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                '  ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                'ASPxPopupControl1.AllowDragging = True
                'ASPxPopupControl1.ShowCloseButton = True
                'ASPxPopupControl1.ShowOnPageLoad = True
                'Page.MaintainScrollPositionOnPostBack = True
                lbltransid.Text = Session("mymy")
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "resubmit" Then
                Session("finish") = ""
                'ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
                'ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

                'ASPxPopupControl1.AllowDragging = True
                'ASPxPopupControl1.ShowCloseButton = True
                'ASPxPopupControl1.ShowOnPageLoad = True
                'Page.MaintainScrollPositionOnPostBack = True
                lbltransid.Text = Session("mymy")
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

                getpending()
                'loadcomboforreceipts(txtewrholder.Text)
                getrejected()

                '   RadioButtonList1.SelectedIndex = 0
            Else
                ' loadcomboforreceipts(txtewrholder.Text)
            End If
            getrejected()
            getpending()
            'loadcomboforreceipts(txtewrholder.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
        '  Try

        If ASPxButton13.Text = "Save" Then

            Dim av As Double = txtavailableshares.Text
            Dim totrans As Double = txtavailableshares.Text

            'If av < totrans Then
            '    msgbox("Please enter units less or equal to available units!")
            '    Exit Sub

            'Else
            'Dim bal As Decimal = av - pendingbalance(cmbparaCompany.Value.ToString)
            'If bal < totrans Then
            '    msgbox("Account has a Pending Transaction of " + pendingbalance(cmbparaCompany.Value.ToString).ToString + " Units.")
            '    Exit Sub
            'End If


            'If pendingbalance(cmbparaCompany.Value.ToString) <> "" Then
            '        msgbox(pendingbalance(cmbparaCompany.Value.ToString))
            '        Exit Sub

            '    End If
            Dim xyz As New Common
            If xyz.OTPenabled = True Then
                Dim OTP As String = CreateRandomPassword(4)
                Dim z As New sendmail
                Try
                    z.sendmail(getemail(txtewraccountno.Text), "New Deposit", "A Certificate Deposit on Cert No. " + txtcertno.Text + " for " + cmbparaCompany.SelectedItem.Text + " has been initiated in your account. ")
                Catch ex As Exception
                    msgbox("Error Sending Email:" + ex.Message + "")
                End Try

                cmd = New SqlCommand("insert into Deposit_Cert (quantity,holder, [date], [status], query, company, Certificate_No, CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent,OTPCreateTime,Price, IssueDate, MaturityDate, Charge, DepType, Product, AssetManager, CounterPartBank, CounterPartAccount ) select quantity,holder, [date], [status], query, company, Certificate_No, '" + Session("Username") + "', getdate(), ParticipantCode, OTP, OTPSent,OTPCreateTime,Price, IssueDate, MaturityDate, Charge, 'WITHDRAWAL', Product, AssetManager, CounterPartBank, CounterPartAccount from Deposit_Cert where id='" + cmbitem.SelectedItem.Value + "' ", cn)

            Else
                cmd = New SqlCommand("insert into Deposit_Cert (quantity,holder, [date], [status], query, company, Certificate_No, CapturedBy, CaptureDate, ParticipantCode, Price, IssueDate, MaturityDate, Charge, DepType,Product, AssetManager, CounterPartBank, CounterPartAccount) select quantity,holder, [date], [status], query, company, Certificate_No, '" + Session("Username") + "', getdate(), ParticipantCode, Price, IssueDate, MaturityDate, Charge, 'WITHDRAWAL',Product, AssetManager, CounterPartBank, CounterPartAccount from Deposit_Cert where id='" + cmbitem.SelectedItem.Value + "'", cn)

            End If

            Try
                Dim md As New NaymatBilling
                Dim charge As Double = md.withdrawalcharges("BILL", "DEPOSITOR", txtavailableshares.Text, txtewraccountno.Text.ToString, cmbparaCompany.Text)
                '     txtcharge.Text = charge.ToString("N")
            Catch ex As Exception
                msgbox("Error Charging: " + ex.Message)
            End Try

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()



            updatewithRef(Session("autogen"), transid.ToString, "Withdrawal")


            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Submitted a Certificate. Cert No." + txtcertno.Text + ", Company: " + cmbparaCompany.SelectedItem.Value.ToString + "", txtewraccountno.Text, cmbparaCompany.Text)
            Catch ex As Exception

            End Try

            Session("finish") = "yes"
            Session("mymy") = transid.ToString
            Session("msg") = "Withdrawal request Cert No. " + cmbparaCompany.SelectedItem.Value.ToString + " captured successfully.Transaction ID is " + transid.ToString + "."
            Response.Redirect(Request.RawUrl)

            'End If
        Else

            Dim xyz As New Common
            If xyz.OTPenabled = True Then
                Dim OTP As String = CreateRandomPassword(4)
                Dim z As New sendmail
                Try
                    z.sendmail(getemail(txtewraccountno.Text), "Withdrawal Authorization Request", "A withdrawal on EWR No. " + cmbparaCompany.Value.ToString + " for " + txtavailableshares.Text + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                Catch ex As Exception
                    msgbox("Error Sending Email:" + ex.Message + "")
                End Try

                cmd = New SqlCommand("delete from Deposit_Cert where id='" + lblid.Text + "' insert into withdrawals (amount_to_withdraw,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent,OTPCreateTime ) values ('" + txtavailableshares.Text + "','" + txtewraccountno.Text + "',getdate(),'0','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + OTP + "','1',getdate())", cn)

            Else
                cmd = New SqlCommand("delete from Deposit_Cert where id='" + lblid.Text + "' insert into withdrawals (amount_to_withdraw,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode) values ('" + txtavailableshares.Text + "','" + txtewraccountno.Text + "',getdate(),'0','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "')", cn)
            End If

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "resubmit"
            Session("msg") = "Deposit request on Certificate for " + cmbparaCompany.SelectedItem.Value.ToString + " has been re-submitted successfully.Transaction ID is " + transid.ToString + ". "
            Session("mymy") = transid.ToString
            Response.Redirect(Request.RawUrl)

        End If
        'Catch ex As Exception
        '    msgbox("Please select the relevant Account to Submit for! Units should also be numeric")
        'End Try

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
        cmd = New SqlCommand("select max(id) as id from withdrawals", cn)
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
        cmd = New SqlCommand("select w.AssetManager, a.Surname+' '+a.forenames as Names, Price*quantity as value,charge,CaptureDate,Charge,Price, MaturityDate, IssueDate,  w.id,case when w.OTPStatus IS NULL and w.ApprovedBy is NULL THEN 'N/A' else 'N/A' end as [otp] , W.Holder as [Account No], W.Company as [Details], W.Certificate_No AS [Certificate No], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], FORMAT(W.quantity,'#,###.##','en-us') AS  quantity ,w.Company   from Deposit_cert W, Accounts_Clients a where a.cds_number=w.holder and deleted is NULL and DepType='WITHDRAWAL'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        Else
            ASPxGridView3.DataSource = Nothing
            ASPxGridView3.DataBind()
        End If
    End Sub
    Public Sub getrejected()

        Dim ds As New DataSet
        cmd = New SqlCommand("select w.AssetManager,a.Surname+' '+a.forenames as Names, Price*quantity as value,charge,CaptureDate,RejectionReason,Charge,Price, MaturityDate, IssueDate,  w.id,case when w.OTPStatus IS NULL and w.ApprovedBy is NULL THEN 'N/A' else 'N/A' end as [otp] , W.Holder as [Account No], W.Company as [Details], W.Certificate_No AS [Certificate No], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], FORMAT(W.quantity,'#,###.##','en-us') AS  quantity ,w.Company   from Deposit_cert W, Accounts_Clients a where a.cds_number=w.holder and deleted is NULL and Rejected is not NULL and DepType='WITHDRAWAL'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView4.DataSource = ds
            ASPxGridView4.DataBind()
        Else
            ASPxGridView4.DataSource = Nothing
            ASPxGridView4.DataBind()
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
        'Dim dsport As New DataSet
        'cmd = New SqlCommand("select quantity as available from wr where receiptno='" + cmbparaCompany.Value.ToString + "' and holder='" + txtewraccountno.Text + "' and quantity>0", cn)
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(dsport, "trans")
        'If (dsport.Tables(0).Rows.Count > 0) Then
        '    txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString
        '    txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString

        '    Dim m As New NaymatBilling
        '    Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtavailableshares.Text, ListBox1.SelectedValue.ToString, cmbparaCompany.Value.ToString)
        '    Dim charge As Double = m.getEWRBAL(cmbparaCompany.Value.ToString, ListBox1.SelectedValue.ToString)
        '    Dim globcharge As Double = m.getholderbal(ListBox1.SelectedValue.ToString, Session("BrokerCode"))
        '    txtcharge.Text = charge.ToString("N")
        '    txttotalcharges.Text = globcharge.ToString("N")
        '    txttranscharge.Text = transcharge.ToString("N")
        Session("autogen") = CreateRandomPassword(20)
        'Else

        '    txtavailableshares.Text = 0
        '    txtavailableshares.Text = 0
        'End If







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

            txtavailableshares.Text = 0
            txtavailableshares.Text = 0
            '  loadcomboforreceipts(ListBox1.SelectedValue.ToString)


        End If
    End Sub
    Public Sub loadcomboforreceipts(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_company", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "fnam"
            cmbparaCompany.ValueField = "company"
            cmbparaCompany.DataBind()
        End If
    End Sub
    Public Sub loadcomboforreceipts_PROD()
        Dim dsport As New DataSet
        cmd = New SqlCommand("  select * from Para_Commodity_Type ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "Commodity_type"
            cmbparaCompany.ValueField = "Commodity_type"
            cmbparaCompany.DataBind()
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




    Private Sub ASPxGridView4_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView4.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getdetails(id)
        End If
        If e.CommandArgs.CommandName.ToString = "delete" Then
            flagdelete(id)
            getrejected()

        End If
    End Sub
    Public Sub getdetails(id As String)
        '  Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select w.id, c.Company_name, w.ParticipantCode, w.EWR_holder, w.ReceiptID, w.amount_to_withdraw , a.surname+' '+Forenames as [Names]  FROM Client_Companies C, withdrawals w, wr wr , Accounts_Clients a where c.Company_Code= w.ParticipantCode and w.EWR_holder=a.CDS_Number and w.id='" + id + "' and wr.ReceiptNo=w.ReceiptID", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ' txtAccountNo.Text = dsport.Tables(0).Rows(0).Item("ParticipantCode").ToString
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString
            txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("EWR_holder").ToString
            txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Names").ToString
            '  txtparticipantname.Text = dsport.Tables(0).Rows(0).Item("company_name").ToString
            cmbparaCompany.Value = dsport.Tables(0).Rows(0).Item("receiptid").ToString
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("amount_to_withdraw").ToString
            ASPxButton13.Text = "Re-Submit Withdrawal"
            lblid.Text = id.ToString
            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
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

    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Delete" Then

            If deletable(id.ToString) = True Then
                flagdelete(id.ToString)
                deletedocument(id.ToString, "Withdrawal")
                reversertransaction(id.ToString)
                getpending()

            Else
                msgbox("Approved Transactions cannot be deleted!")
            End If
        ElseIf e.CommandArgs.CommandName.ToString = "OTP" Then
            If getotp(id) = "" Then
                msgbox("No OTP generated for Transaction! Cancel Transaction and re-capture." + id + "")
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
                ' txtcharge.Text = charge
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

        If m.Document_Upload(fs, filePath, txtdocumentname.Text, ext, filename, "Deposit", txtewraccountno.Text, Session("autogen"), bytes).ToString <> "Upload Successful" Then
            msgbox("Document Upload failed!")
            Exit Sub
        Else
            getdocuments(Session("autogen"), "Deposit")
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
                pd(Session("autogen"), "Deposit")
            Catch ex As Exception
            End Try
            Try
                word(Session("autogen"), "Deposit")
            Catch ex As Exception
            End Try
            Try
                xls(Session("autogen"), "Deposit")
            Catch ex As Exception
            End Try
            Try
                Img(Session("autogen"), "Deposit")
            Catch ex As Exception
            End Try
        ElseIf e.CommandArgs.CommandName.ToString = "Remove Document" Then
            deletedocument(Session("autogen"), "Deposit")
            getdocuments(Session("autogen"), "Deposit")
        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = "Certificate" Then
            lblcertificate.Text = "Certificate No"
            lblissuedate.Text = "Issue Date"
            lblmaturity.Text = "Maturity Date"
            lblproduct.Text = "Company"
            lblunitprice.Text = "Current Unit Price"
            cmbparaCompany.Items.Clear()
            loadcomboforreceipts("")
            Try
                getitems(ListBox1.SelectedValue.ToString, "Certificate")

            Catch ex As Exception
                msgbox("Please select valid client!")
            End Try
        Else
            lblcertificate.Text = "Serial No"
            lblissuedate.Text = "Registration Date"
            lblmaturity.Text = "Expiry/Maturity Date"
            lblproduct.Text = "Product"
            lblunitprice.Text = "Value per Unit"
            cmbparaCompany.Items.Clear()
            loadcomboforreceipts_PROD()
            '  Try
            getitems(ListBox1.SelectedValue.ToString, "Other Items")

            'Catch ex As Exception
            '    msgbox("Please select valid client!")
            'End Try
        End If
    End Sub
    Public Sub getitems(holder As String, item As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select 'Product/Company: '+ company + ' Serial No/Certificate No: ' + certificate_No  + ' Quantity: '+convert(nvarchar(50),Quantity)+ ' Price/Value: '+convert(nvarchar(50),Price) as det, id from Deposit_Cert where holder='" + holder + "'  and product='" + item + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbitem.DataSource = dsport
            cmbitem.TextField = "det"
            cmbitem.ValueField = "id"
            cmbitem.DataBind()

        End If
    End Sub
    Protected Sub cmbitem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbitem.SelectedIndexChanged
        getdetailstowith(cmbitem.SelectedItem.Value.ToString)
    End Sub
    Public Sub getbanks()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from para_bank", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbcounterpart.DataSource = dsport
            cmbcounterpart.TextField = "bank_name"
            cmbcounterpart.ValueField = "bank"
            cmbcounterpart.DataBind()

        End If
    End Sub
    Public Sub getdetailstowith(IDs As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Deposit_Cert where id='" + IDs + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.Text = dsport.Tables(0).Rows(0).Item("Company").ToString
            txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("quantity").ToString
            txtcertno.Text = dsport.Tables(0).Rows(0).Item("Certificate_No").ToString
            txtprice.Text = dsport.Tables(0).Rows(0).Item("price").ToString
            dtmaturity.Value = dsport.Tables(0).Rows(0).Item("MaturityDate").ToString
            dtissue.Value = dsport.Tables(0).Rows(0).Item("IssueDate").ToString
            loadcomboforassetmanagers(txtewraccountno.Text)
            cmbassetmanager.Value = dsport.Tables(0).Rows(0).Item("AssetManager").ToString
            cmbcounterpart.Value = dsport.Tables(0).Rows(0).Item("CounterpartBank").ToString
            txtcounterpartbank.Text = dsport.Tables(0).Rows(0).Item("CounterPartAccount").ToString
        End If
    End Sub
End Class