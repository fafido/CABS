Partial Class TransferSec_transfershares
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
                msgbox("Transfer successfully captured")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                '      getCompany()
                GetBatchTypes()
                Getbrokers()
                loadgrid()


            End If
            loadgrid()

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
            cmbParaCompany.DataBind()
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
                CmbBatchType.DataSource = ds.Tables(0)
                cmbBatchType.ValueField = "batch_Type"
                cmbBatchType.TextField = "batch_Type"
                CmbBatchType.DataBind()
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

        cmd = New SqlCommand("insert into batch_receipt (id,company, batch_shares, shareprice, batch_value, batch_date, lodger, balanced, verified, successful, batch_type, masttemp,broker_code) values ('0','" + cmbparaCompany.Text + "','" + txtBatchShares.Text + "','" + txtShareprice.Text + "','" + txtBatchValue.Text + "',Getdate(),'" + txtClientNo2.Text + "','0','0','0','Withdrawal','0','" + Session("brokercode") + "')", cn)
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

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        'If txtclientnumber.Text = "" Then
        '    msgbox("Please enter Account No./Name to search")
        '    Exit Sub
        'End If
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber.Text + "%' order by cds_number", cn)
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
        cmd = New SqlCommand("  select Transferor, Transferee, [Date],Amount_to_transfer as [Quantity],  Company as [Details], ReceiptID AS [EWR No.], case when approvedby is NULL then 'Pending'  when rejected is NOT NULL then 'Rejected' else 'Pending' end as [Status] from share_transfer where participantcode='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()

        End If
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
    Protected Sub txtClientNo3_TextChanged(sender As Object, e As EventArgs) Handles txtclientnumber.TextChanged

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
    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Try
            Dim av As Double = txtavailableshares.Text
            Dim totrans As Double = txtshares.Text

            If av < totrans Then
                msgbox("Please enter units less or equal to available units!")
            Else
                Dim m As String = ListBox1.SelectedItem.Text
                If m = "" Then
                    msgbox("Please select the Transferor")
                    Exit Sub
                End If
                Dim n As String = ListBox2.SelectedItem.Text
                If n = "" Then
                    msgbox("Please select the Transferee")
                    Exit Sub
                End If

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
                        z.sendmail(getemail(txtewraccountno.Text).ToString, "Transfer Authorization Request", "A transfer on EWR No. " + cmbparaCompany.SelectedItem.Value.ToString + " for " + txtshares.Text + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
                    Catch ex As Exception
                        msgbox("Error Sending Email:" + ex.Message + "")
                    End Try

                    cmd = New SqlCommand("insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode, OTP, OTPSent, OTPCreateTime) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + ListBox2.SelectedValue.ToString + "',getdate(),'0','0','" + cmbparaCompany.SelectedItem.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "','" + OTP + "','1',getdate())", cn)
                Else
                    cmd = New SqlCommand("insert into share_transfer (amount_to_transfer, transferor, transferee, [date], [status], query, company, receiptid,CapturedBy, CaptureDate, ParticipantCode) values ('" + txtshares.Text + "', '" + txtewraccountno.Text + "','" + ListBox2.SelectedValue.ToString + "',getdate(),'0','0','" + cmbparaCompany.SelectedItem.Text + "','" + cmbparaCompany.SelectedItem.Value.ToString + "','" + Session("Username") + "',getdate(),'" + Session("BrokerCode") + "')", cn)
                End If



                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                Session("finish") = "yes"
                Response.Redirect(Request.RawUrl)
            End If
        Catch ex As Exception
            msgbox("Please select the relevant Account to Transfer from and Transfer to! Units to transfer should also be numeric")
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
        'If txtclientnumber0.Text = "" Then
        '    msgbox("Please enter Account No./Name to search")
        '    Exit Sub
        'End If

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' and cds_number<>'" + txtewraccountno.Text + "'", cn)
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
            txtshares.Text = dsport.Tables("trans").Rows(0).Item("available")
            Try
                Dim m As New NaymatBilling
                Dim charge As Double = m.transfercharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text.ToString, cmbparaCompany.SelectedItem.Value.ToString)
                txtcharge.Text = charge
            Catch ex As Exception
                msgbox("Error Charging: " + ex.Message)
            End Try

        Else
            txtavailableshares.Text = 0
            txtshares.Text = 0
        End If
    End Sub
End Class
