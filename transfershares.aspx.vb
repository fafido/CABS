Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_transfershares
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cn1 As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
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

    'Protected Sub grdvCharges_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)


    '    ViewState("myID") = e.KeyValue.ToString
    '    If e.CommandArgs.CommandName = "Select" Then
    '        getExistingCharge(ViewState("myID"))

    '    End If
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Transfer successfully captured")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetSelectedDetails()
                '      getCompany()
                GetBatchTypes()
                Getbrokers()
                loadgrid()
                getApproved()


            End If
            loadgrid()

            getApproved()


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbparaCompany.DataSource = ds.Tables(0)
            cmbparaCompany.TextField = "company"
            cmbparaCompany.ValueField = "company"
            cmbparaCompany.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBatchTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (batch_Type) from Para_Batch_type order by Batch_Type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_batch_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "batch_Type"
                cmbBatchType.TextField = "batch_Type"
                cmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getbrokers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (broker_code), fnam from Para_Broker", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "broker_code"
                cmbBatchType.TextField = "fnam"
                cmbBatchType.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Dim shares As Double = txtBatchShares.Text
        Dim shareprice As Decimal = txtShareprice.Text
        Dim value As Double = shares * shareprice
        txtBatchValue.Text = value

        cmd = New SqlCommand("insert into batch_receipt (id,company, batch_shares, shareprice, batch_value, batch_date, lodger, balanced, verified, successful, batch_type, masttemp,broker_code) values ('0','" + cmbparaCompany.Text + "','" + txtBatchShares.Text + "','" + txtShareprice.Text + "','" + txtBatchValue.Text + "',Getdate(),'" + txtClientNo2.Text + "','0','0','0','Withdrawal','0','" + getoperator(getDEPCDS(Session("Username"))) + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim ds As New DataSet
        cmd = New SqlCommand("select batch_no from batch_receipt order by batch_no desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "batch_no")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtClientNo.Visible = True
            txtClientNo.Text = ds.Tables(0).Rows(0).Item("batch_no")
        End If

        Panel3.Enabled = False
        Panel5.Enabled = True
        Panel9.Enabled = True


        msgbox("Batch Number:" + txtClientNo.Text + " has been successfully created. Please add some Shares and Share Certificates to the batch")


    End Sub


    Public Function checkotp(otp As String) As Boolean
        Dim ds As New DataSet

        cmd = New SqlCommand("select *  FROM [CDS].[dbo].[share_transfer] where isnull(OTP,'')='" + otp.Trim + "'  and id in ('" + ViewState("trnsid") + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "otp")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return False
        Else


            Return True

        End If
    End Function

    Public Function getDEPCDS(CDSno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select Role  FROM [CDS].[dbo].[SystemUsers] where UserName='" + CDSno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Role").ToString
        Else
            Return ""

        End If
    End Function

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        If txtclientnumber.Text = "" Then
            msgbox("Please enter Account No./Name to search")
            Exit Sub
        End If
        Dim ds As New DataSet

        'msgbox(Session("BrokerCode"))
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' and brokercode='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()
            'txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            'txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            'txtewrholder.Text = ds.Tables(0).Rows(0).Item("names")
            'txtewraccountno.Text = ds.Tables(0).Rows(0).Item("cds_number")
            'cmbparaCompany.DataSource = ds
            'cmbparaCompany.TextField = "Commodity"
            'cmbparaCompany.ValueField = "cds_number"
            'cmbparaCompany.DataBind()
        End If
    End Sub
    Public Sub loadgrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("select s.id ,s.id as [S.No],Transferor, Transferee,CONVERT(VARCHAR(10),Date,6) as [Trns. Date],Amount_to_transfer ,  Commodity ,grade,ReceiptID, ReceiptID AS [EWR No.],  'Pending' [Status] from   share_transfer s, wr w where w.ReceiptNo=s.ReceiptID and transferor='" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') <> 'REJECTED'  and isnull(s.ApprovedBy,'') ='' and isnull(Rejected,'') <> '1'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()

        End If

    End Sub

    'Protected Sub chk_CheckedChanged(sender As Object, e As EventArgs)
    '    GetChecked()
    '    otptable.Visible = True
    '    otptable2.Visible = True
    'End Sub



    'Protected Sub ASPxGridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ASPxGridView3.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim id = DirectCast(e.Row.FindControl("id"), Label).Text



    '        e.Row.Enabled = getvalue(id)


    '    End If
    'End Sub


    Public Function getvalue(id As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select OTPStatus from   share_transfer s, wr w where w.ReceiptNo=s.ReceiptID and  s.id ='" + id + "' and transferor='" + getDEPCDS(Session("Username")) + "'  and isnull(OTPStatus,'') not in ('REJECTED' ,'APPROVED') ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "aft")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function

    'Protected Sub ASPxGridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ASPxGridView3.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim chkView As CheckBox
    '        chkView = DirectCast(e.Row.FindControl("chkRow"), CheckBox)
    '        Dim id = DirectCast(e.Row.FindControl("id"), Label).Text

    '        If id <> "" Then
    '            chkView.Checked = getatfdetailts(id)
    '        End If
    '    End If
    'End Sub

    'Protected Sub ASPxGridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxGridView3.SelectedIndexChanged

    '    ViewState("trnsid") = ASPxGridView3.SelectedRow.Cells(1).Text

    '    ViewState("idReject") = ""













    'End Sub
    Public Sub getApproved()

        Dim ds As New DataSet
        cmd = New SqlCommand("select s.id ,s.id as [S.No],Transferor, Transferee,CONVERT(VARCHAR(10),Date,6) as [Trns. Date],Amount_to_transfer ,  Commodity ,grade,ReceiptID, ReceiptID AS [EWR No.],  'Approved' [Status] from   share_transfer s, wr w where w.ReceiptNo=s.ReceiptID and transferor='" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') = 'APPROVED' and  isnull(Rejected,'')  <> '1' and   isnull(s.ApprovedBy,'')<>''", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()



        Else
            ASPxGridView1.DataSource = Nothing
            ASPxGridView1.DataBind()
        End If
    End Sub

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
    Protected Sub btn_accept(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from share_transfer where  transferor='" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') = '' and id = '" + container.KeyValue.ToString() + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ViewState("trnsid") = container.KeyValue.ToString()

            otptable.Visible = True
            otptable2.Visible = True

        Else

            msgbox("The transaction is on pending for approval")
            otptable.Visible = False
            otptable2.Visible = False
        End If

    End Sub
    Protected Sub btn_reject(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        ViewState("idReject") = container.KeyValue.ToString()




        If ViewState("idReject") <> "" Then

            cmd = New SqlCommand("update [CDS].[dbo].[share_transfer] set OTPStatus ='REJECTED' where id='" + ViewState("idReject") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                msgbox("Rejected Successfull ")
                txtotp.Text = ""
            End If

        End If
        loadgrid()

        getApproved()
        otptable.Visible = False
        otptable2.Visible = False

    End Sub



    'Public Function GetChecked(value As String)
    '    msgbox(value)

    '    otptable.Visible = True
    '    otptable2.Visible = True
    'End Function




    Public Sub GetSelectedDetails()
        Try
            'Dim ds As New DataSet
            'cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number like '%" + getDEPCDS(Session("Username")) + "%' and brokercode='" + Session("BrokerCode") + "'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "names")
            'If (ds.Tables(0).Rows.Count > 0) Then
            '    ListBox1.DataSource = ds
            '    ListBox1.DataTextField = "names"
            '    ListBox1.DataValueField = "cds_number"
            '    ListBox1.DataBind()
            'Else

            'End If
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + getDEPCDS(Session("Username")) + "'", cn)
            ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "names1")
            If (ds1.Tables(0).Rows.Count > 0) Then
                txtparticipantname.Text = ds1.Tables(0).Rows(0).Item("Company_name")
                txtAccountNo.Text = ds1.Tables(0).Rows(0).Item("Company_Code")
                txtewrholder.Text = ds1.Tables(0).Rows(0).Item("name")
                txtewraccountno.Text = getDEPCDS(Session("Username"))
                loadcomboforreceipts(getDEPCDS(Session("Username")))


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtClientNo3_TextChanged(sender As Object, e As EventArgs) Handles txtclientnumber.TextChanged

    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Try
            'msgbox(ListBox2.SelectedValue.ToString)
            Dim av As Double = txtavailableshares.Text
            Dim totrans As Double = txtshares.Text

            If av < totrans Then
                msgbox("Please enter units less or equal to available units!")
            Else
                Dim m As String = getDEPCDS(Session("Username"))
                If m = "" Then
                    msgbox("Please select the Transferor")
                    Exit Sub
                End If
                Dim n As String = ListBox2.SelectedItem.Text
                If n = "" Then
                    msgbox("Please select the Transferee")
                    Exit Sub
                End If



                Dim xyz As New Common
                If xyz.OTPenabled = True Then
                    If (cn1.State = ConnectionState.Open) Then
                        cn1.Close()
                    End If
                    cn1.Open()

                    Dim OTP As String = CreateOTP(4)
                    Dim z As New sendmail

                    Try
                        z.sendmail(getemail(getDEPCDS(Session("Username"))).ToString, "Transfer Authorization Request", "A Transfer on EWR No. " + cmbparaCompany.SelectedItem.Value.ToString + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                    Catch ex As Exception
                        msgbox("Error Sending Email:" + ex.Message + "")
                    End Try

                    cmd = New SqlCommand("insert into share_transfer (OTP,OTPSent,amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode) values ('" + OTP + "','1','" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + ListBox2.SelectedValue.ToString + "',getdate(),'C','0','" + cmbparaCompany.SelectedItem.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + getoperator(getDEPCDS(Session("Username"))) + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    If cmd.ExecuteNonQuery() = 1 Then
                        msgbox("Transfer Successfull Waiting For Authorization")

                    End If

                Else

                    cmd = New SqlCommand("insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + ListBox2.SelectedValue.ToString + "',getdate(),'0','0','" + cmbparaCompany.SelectedItem.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + getoperator(getDEPCDS(Session("Username"))) + "')", cn)
                    If cmd.ExecuteNonQuery() = 1 Then
                        msgbox("Transfer Successfull Waiting For Authorization")

                    End If
                End If

                cn.Close()
                loadgrid()
                getApproved()
            End If
        Catch ex As Exception
            msgbox("Please select the relevant Account to Transfer from and Transfer to! Units to transfer should also be numeric")
        End Try

    End Sub

    'Protected Sub ASPxGridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles ASPxGridView3.RowCommand

    '    ViewState("idReject") = e.CommandArgument






    '    otptable.Visible = True
    '        otptable2.Visible = True







    'End Sub

    Protected Sub btnotp_Click(sender As Object, e As EventArgs) Handles btnotp.Click
        Try



            ' Dim m As String = getDEPCDS(Session("Username"))
            If txtotp.Text = "" Then
                msgbox("Please enter otp")
                Exit Sub
            End If

            If checkotp(txtotp.Text.ToLower.ToString.Trim) Then
                msgbox("OTP incorrect please try again")
                Exit Sub
            End If






            cmd = New SqlCommand("update [CDS].[dbo].[share_transfer] set OTPStatus ='APPROVED' where id ='" + ViewState("trnsid") + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                If cmd.ExecuteNonQuery() = 1 Then
                    msgbox("Transaction Successfully Authorized Waiting For Authorization")


                    txtotp.Text = ""
                End If



            cn.Close()

            getApproved()
            loadgrid()
        Catch ex As Exception
            msgbox("Please make sure you entered all values")
        End Try

    End Sub

    Public Function getoperator(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select BrokerCode from accounts_clients where cds_number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("BrokerCode").ToString
        Else
            Return ""
        End If

    End Function

    'Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("select (select sum(shares) from batch_certs where batch_no=" + txtClientNo.Text + ") as certs_total, (select batch_shares from Batch_receipt where batch_no=" + txtClientNo.Text + ") as batch_tot", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "totals")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        If ds.Tables(0).Rows(0).Item("certs_total") = ds.Tables(0).Rows(0).Item("batch_tot") Then
    '            cmd = New SqlCommand("update batch_receipt set balanced='1' where batch_no='" + txtClientNo.Text + "'", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()
    '            End If
    '            cn.Open()
    '            cmd.ExecuteNonQuery()
    '            cn.Close()
    '            Session("finish") = "yes"
    '            Response.Redirect(Request.RawUrl)
    '        Else
    '            msgbox("Specified batch total not balancing with the total shares you added!")
    '        End If
    '    End If
    'End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + ListBox1.SelectedValue.ToString + "'", cn)
        ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names1")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            txtewraccountno.Text = ListBox1.SelectedValue.ToString
            loadcomboforreceipts(ListBox1.SelectedValue.ToString)


        End If
    End Sub
    Public Sub loadcomboforreceipts(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select ReceiptNo, ReceiptNo+' '+ convert(nvarchar(50),Quantity) +' '+ UnitMeasure  +' '+Commodity+'/'+Grade AS [Name]  from WR where holder='" + holder + "' and [Status]='ISSUED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport
            cmbparaCompany.TextField = "Name"
            cmbparaCompany.ValueField = "ReceiptNo"
            cmbparaCompany.DataBind()
        End If
    End Sub

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        If txtclientnumber0.Text = "" Then
            msgbox("Please enter Account No./Name to search")
            Exit Sub
        End If

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox2.DataSource = ds
            ListBox2.DataTextField = "names"
            ListBox2.DataValueField = "cds_number"
            ListBox2.DataBind()

        End If
    End Sub


    Protected Sub cmbparaCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.SelectedIndexChanged
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as available from trans where reference='" + cmbparaCompany.SelectedItem.Value.ToString + "' and cds_Number='" + txtewraccountno.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            txtavailableshares.Text = dsport.Tables("trans").Rows(0).Item("available")
            txtshares.Text = txtavailableshares.Text
        Else
            txtavailableshares.Text = 0

        End If
    End Sub
End Class
