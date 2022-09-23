Partial Class TransferSec_transfer_UT
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
                getCompany()
                GetBatchTypes()
                Getbrokers()
                getgrid()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from comps where category='Unit Trust'", cn)
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
    Public Sub getgrid()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select s.*, a1.Surname+' '+a1.Forenames as [FromName],a2.Surname+' '+a2.Forenames as [ToName] from transfer_UT s, Accounts_Clients a1, Accounts_Clients a2 where s.transferor=a1.CDS_Number and a2.CDS_Number=s.transferee", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_batch_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdpending.DataSource = ds
                grdpending.DataBind()

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
        If txtclientnumber.Text = "" Then
            msgbox("Please enter Account No/Name to search")
            Exit Sub
        End If
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber.Text + "%' and BankAccount_Type='Unit Trust'  and cds_number in (select  t.cds_number from trans t, Accounts_Clients a where t.CDS_Number=a.CDS_Number and t.company='" + cmbparaCompany.Text + "'  group by t.cds_number,t.company having sum(t.shares)>0 ) ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()

        End If
    End Sub

    Protected Sub txtClientNo3_TextChanged(sender As Object, e As EventArgs) Handles txtclientnumber.TextChanged

    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        If ASPxButton12.Text = "Transfer" Then
            Try
                Dim av As Double = txtavailableshares.Text
                Dim totrans As Double = txtshares.Text

                If av < totrans Then
                    msgbox("Please enter shares less or equal to available units!")
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
                    cmd = New SqlCommand("insert into transfer_UT (amount_to_transfer, transferor, transferee, [date], [status], query, company, ReceiptID, CapturedBy, CaptureDate, ParticipantCode, OTP, OTPStatus) values ('" + txtshares.Text + "', '" + ListBox1.SelectedValue.ToString + "','" + ListBox2.SelectedValue.ToString + "','" + dttransfer.Date.ToString + "','PENDING','" + Session("newid") + "','" + cmbparaCompany.Text + "','0', '" + Session("Username") + "',getdate(), 'CABS','0','Approved')", cn)
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
        Else
            Try
                Dim av As Double = txtavailableshares.Text
                Dim totrans As Double = txtshares.Text

                If av < totrans Then
                    msgbox("Please enter shares less or equal to available Units!")
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
                    cmd = New SqlCommand("update transfer_UT SET  amount_to_transfer= '" + txtshares.Text + "', transferor='" + ListBox1.SelectedValue.ToString + "', transferee='" + ListBox2.SelectedValue.ToString + "', [date]='" + dttransfer.Date.ToString + "', [status]='PENDING', company='" + cmbparaCompany.SelectedItem.Value.ToString + "',  CapturedBy='" + Session("Username") + "', CaptureDate=getdate() where id='" + lblid.Text + "'", cn)
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
                msgbox(ex.Message)
            End Try
        End If


    End Sub

    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select (select sum(shares) from batch_certs where batch_no=" + txtClientNo.Text + ") as certs_total, (select batch_shares from Batch_receipt where batch_no=" + txtClientNo.Text + ") as batch_tot", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "totals")
        If (ds.Tables(0).Rows.Count > 0) Then
            If ds.Tables(0).Rows(0).Item("certs_total") = ds.Tables(0).Rows(0).Item("batch_tot") Then
                cmd = New SqlCommand("update batch_receipt set balanced='1' where batch_no='" + txtClientNo.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Session("finish") = "yes"
                Response.Redirect(Request.RawUrl)
            Else
                msgbox("Specified batch total not balancing with the total shares you added!")
            End If
        End If
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            txtavailableshares.Text = availableshares(cmbparaCompany.SelectedItem.Value.ToString, ListBox1.SelectedValue.ToString)
        Catch ex As Exception

        End Try
    End Sub
    Public Function availableshares(company As String, cdsnumber As String) As Decimal
        Dim dsport As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as ava from trans where company='" + company + "' and cds_number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables("trans").Rows(0).Item("ava").ToString
        Else
            Return 0

        End If
    End Function

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        If txtclientnumber0.Text = "" Then
            msgbox("Please enter Account No/Name to search")
            Exit Sub
        End If

        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtclientnumber0.Text + "%' and BankAccount_Type='Unit Trust'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox2.DataSource = ds
            ListBox2.DataTextField = "names"
            ListBox2.DataValueField = "cds_number"
            ListBox2.DataBind()

        End If
    End Sub

    Private Sub grdpending_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdpending.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select s.*, a1.Surname+' '+a1.Forenames as [FromName],a2.Surname+' '+a2.Forenames as [ToName] from transfer_UT s, Accounts_Clients a1, Accounts_Clients a2 where s.transferor=a1.CDS_Number and a2.CDS_Number=s.transferee and s.id='" + grdpending.SelectedValue.ToString + "' AND s.[status] in ('PENDING','REJECTED')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec_type")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtclientnumber.Text = ds.Tables(0).Rows(0).Item("transferor").ToString

            txtclientnumber0.Text = ds.Tables(0).Rows(0).Item("transferee").ToString



            cmbparaCompany.Value = ds.Tables(0).Rows(0).Item("company").ToString

            Dim li As ListItem = New ListItem(txtclientnumber.Text + " " + ds.Tables(0).Rows(0).Item("FromName").ToString, txtclientnumber.Text)
            ListBox1.Items.Clear()
            ListBox1.Items.Add(li)
            ListBox1.SelectedIndex = 0

            Dim li2 As ListItem = New ListItem(txtclientnumber0.Text + " " + ds.Tables(0).Rows(0).Item("ToName").ToString, txtclientnumber0.Text)
            ListBox2.Items.Clear()
            ListBox2.Items.Add(li2)
            ListBox2.SelectedIndex = 0

            txtavailableshares.Text = availableshares(ds.Tables(0).Rows(0).Item("company").ToString, txtclientnumber.Text)
            ASPxButton12.Text = "Update"
            lblid.Text = ds.Tables(0).Rows(0).Item("id").ToString
            txtshares.Text = ds.Tables(0).Rows(0).Item("amount_to_transfer").ToString
            dttransfer.Date = ds.Tables(0).Rows(0).Item("date").ToString
            ASPxButton15.Visible = True

        Else
            msgbox("You cannot edit an approved entry!")
            Exit Sub
        End If

    End Sub
End Class
