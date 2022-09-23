Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_AFT
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
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "resubmit" Then
                Session("finish") = ""
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

            If ASPxButton13.Text = "Mark AFT" Or ASPxButton13.Text = "Un-mark AFT" Then

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


                    End If
                    Dim xyz As New Common
                    If xyz.OTPenabled = True Then
                        Dim OTP As String = CreateRandomPassword(4)
                        Dim z As New sendmail
                        Try
                            z.sendmail(getemail(txtewraccountno.Text), "AFT Authorization Request", "An AFT flagging on EWR No. " + cmbparaCompany.Value + " for " + txtshares.Text + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                        Catch ex As Exception
                            msgbox("Error Sending Email:" + ex.Message + "")
                        End Try

                        cmd = New SqlCommand("insert into AFT (AFT_Quantity,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent,OTPCreateTime, AFT_Type ) values ('" + txtshares.Text + "','" + txtewraccountno.Text + "',getdate(),'0','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + OTP + "','1',getdate(),'" + RadioButtonList1.SelectedValue.ToString + "')", cn)

                    Else
                        cmd = New SqlCommand("insert into AFT (AFT_Quantity,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode, AFT_Type) values ('" + txtshares.Text + "','" + txtewraccountno.Text + "',getdate(),'0','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + RadioButtonList1.SelectedValue.ToString + "')", cn)

                    End If


                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Session("finish") = "yes"
                    Session("msg") = "AFT request on EWR No. " + cmbparaCompany.Value.ToString + " captured successfully.Transaction ID is " + transid.ToString + "."
                    Response.Redirect(Request.RawUrl)

                End If
            Else

                Dim xyz As New Common
                If xyz.OTPenabled = True Then
                    Dim OTP As String = CreateRandomPassword(4)
                    Dim z As New sendmail
                    Try
                        z.sendmail(getemail(txtewraccountno.Text), "AFT Authorization Request", "An AFT flagging on EWR No. " + cmbparaCompany.Value.ToString + " for " + txtshares.Text + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                    Catch ex As Exception
                        msgbox("Error Sending Email:" + ex.Message + "")
                    End Try

                    cmd = New SqlCommand("delete from AFT where id='" + lblid.Text + "' insert into AFT (AFT_Quantity,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent,OTPCreateTime, AFT_Type ) values ('" + txtshares.Text + "','" + txtewraccountno.Text + "',getdate(),'0','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + OTP + "','1',getdate(),'" + RadioButtonList1.SelectedValue.ToString + "')", cn)

                Else
                    cmd = New SqlCommand("delete from AFT where id='" + lblid.Text + "' insert into AFT (AFT_Quantity,EWR_holder, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode, AFT_Type) values ('" + txtshares.Text + "','" + txtewraccountno.Text + "',getdate(),'0','0','" + cmbparaCompany.Text + "','" + cmbparaCompany.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + RadioButtonList1.SelectedValue.ToString + "')", cn)
                End If

                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "resubmit"
                Session("msg") = "AFT request on EWR No. " + cmbparaCompany.Value.ToString + " has been re-submitted successfully.Transaction ID is " + transid.ToString + "."
                Response.Redirect(Request.RawUrl)

            End If
        Catch ex As Exception
            msgbox("Please select the relevant Account to mark AFT! Units should also be numeric")
        End Try

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
        cmd = New SqlCommand("select max(id) as id from AFT", cn)
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
        cmd = New SqlCommand("select w.id,case when w.OTPStatus IS NULL and w.ApprovedBy is NULL THEN 'Enter OTP' else 'N/A' end as [otp] , W.EWR_Holder as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], W.AFT_Quantity ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from AFT W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and deleted is NULL", cn)
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
        cmd = New SqlCommand("select w.id, W.EWR_Holder as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending'  when w.rejected='1'  THEN 'Rejected' else 'Approved' end as  [Status],  W.[Date], W.AFT_Quantity ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from AFT W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and w.deleted is Null and w.rejected is NOT NULL and deleted is NULL", cn)
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
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' order by cds_number", cn)
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
        Dim dsport As New DataSet
        cmd = New SqlCommand("select quantity as available from wr where receiptno='" + cmbparaCompany.Value.ToString + "' and holder='" + txtewraccountno.Text + "' and quantity>0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString
            txtshares.Text = dsport.Tables("trans").Rows(0).Item("available").ToString


        Else

            txtavailableshares.Text = 0
            txtshares.Text = 0
        End If





    End Sub


    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
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



        End If
    End Sub
    Public Sub loadcomboforreceipts(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from WR where holder='" + holder + "' and [Status]='ISSUED' and quantity>0 and status='ISSUED' and warehouse='" + Session("BrokerCode") + "' and receiptno not in (select receiptid from pendingtrans)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport

            cmbparaCompany.DataBind()
        End If
    End Sub
    Public Sub loadcomboforreceipts_AFT(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from WR where holder='" + holder + "' and [Status]='AFT' and quantity>0 and status='AFT' and warehouse='" + Session("BrokerCode") + "' and receiptno not in (select receiptid from pendingtrans)", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport

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


    Private Sub cmbparaCompany_ValueChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.ValueChanged
        loadcomboforreceipts(ListBox1.SelectedValue.ToString)
    End Sub

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
        Try

            Dim dsport As New DataSet
            cmd = New SqlCommand("select w.id, c.Company_name, w.ParticipantCode, w.EWR_holder, w.ReceiptID, w.AFT_Quantity, w.AFT_Type , a.surname+' '+Forenames as [Names]  FROM Client_Companies C, AFT w, wr wr , Accounts_Clients a where c.Company_Code= w.ParticipantCode and w.EWR_holder=a.CDS_Number and w.id='" + id + "' and wr.ReceiptNo=w.ReceiptID", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                txtAccountNo.Text = dsport.Tables(0).Rows(0).Item("ParticipantCode").ToString
                txtavailableshares.Text = dsport.Tables(0).Rows(0).Item("AFT_Quantity").ToString
                txtewraccountno.Text = dsport.Tables(0).Rows(0).Item("EWR_holder").ToString
                txtewrholder.Text = dsport.Tables(0).Rows(0).Item("Names").ToString
                txtparticipantname.Text = dsport.Tables(0).Rows(0).Item("company_name").ToString
                cmbparaCompany.Value = dsport.Tables(0).Rows(0).Item("receiptid").ToString
                txtshares.Text = dsport.Tables(0).Rows(0).Item("AFT_Quantity").ToString
                If dsport.Tables(0).Rows(0).Item("AFT_Type").ToString = "Mark AFT" Then
                    RadioButtonList1.SelectedIndex = 0
                Else
                    RadioButtonList1.SelectedIndex = 1
                End If
                RadioButtonList1.Enabled = False
                ASPxButton13.Text = "Re-Submit AFT"
                lblid.Text = id.ToString
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try


    End Sub
    Public Function getotp(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(OTP,'') as OTP from AFT where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("OTP").ToString
        End If
    End Function

    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Delete" Then

            If deletable(id.ToString) = True Then
                flagdelete(id.ToString)
                getpending()

            Else
                msgbox("Approved Transactions cannot be deleted!")
            End If
        ElseIf e.CommandArgs.CommandName.ToString = "OTP" Then
            If getotp(id) = "" Then
                msgbox("No OTP generated for Transaction! Cancel Transaction and re-capture." + id + "")
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
    Public Function deletable(idn As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from  AFT where ApprovedBy is NULL and id='" + idn + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub flagdelete(ref As String)
        cmd = New SqlCommand("update AFT set deleted='1'  where id='" + ref + "'", cn)
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
            cmd = New SqlCommand("update AFT set OTPStatus='Approved', OTPResponseTime=getdate()   where id='" + lbltransid.Text + "'", cn)
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

            msgbox("OTP Correct! AFT sent for approval")


        Else
            msgbox("Failed")
        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = "Mark AFT" Then
            loadcomboforreceipts(ListBox1.SelectedValue.ToString)
            ASPxButton13.Text = "Mark AFT"
        Else
            loadcomboforreceipts_AFT(ListBox1.SelectedValue.ToString)
            ASPxButton13.Text = "Un-mark AFT"
        End If
    End Sub
End Class
