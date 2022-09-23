Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.Net.Mail

Partial Class BA_issueBA
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
    Public Sub GetLenders()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate <='" & Now.Date & "'", cn)
            cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lendersRegister")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSectype()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (SecCode) from sec_types", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec_types")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcollateral()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (collateral_name) from para_collateral", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans1")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from trans", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkSessionState()
        Try
            GetCompany()
            GetSectype()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("BA Successfully created!")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  GetLenders()
                getcollateral()
                ASPxCheckBox1.Checked = True
                '    getparticipants()

                getcounterparts()

                txtpurpose.Text = FormatNumber(12345, TriState.False)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
    '    If txtbanumber.Text <> "" Then
    '        cmd = New SqlCommand("insert into counterparts values ('" + txtbanumber.Text + "',(select company_code from client_companies where company_name='" + ASPxComboBox1.Text + "'))", cn)
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '        cn.Close()
    '        txtbanumber.Enabled = False
    '        getcounterparts()

    '    End If

    'End Sub
    Public Sub getcounterparts()


        Dim ds As New DataSet
        cmd = New SqlCommand("select cc.company_name as country from BANKERSACCEPTANCE.DBO.client_companies cc where  company_type='BANK' or company_type='Asset Manager' and cc.company_code<>'" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = ds
            ASPxGridView1.DataBind()
        End If

    End Sub

    'Public Sub getparticipants()

    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("  select company_name from Client_Companies where Company_type  in (select Companytype  from tbl_ParticipantsType) and company_code<>'" + Session("BrokerCode") + "'", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "SystemUsers")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        ASPxComboBox1.DataSource = ds
    '        ASPxComboBox1.TextField = "company_name"
    '        ASPxComboBox1.DataBind()
    '    End If
    'End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        ' Try
        Dim disc_amount As Decimal = 0
        Dim disc_perc As Decimal = 0
        Dim face_val As Decimal = 0

        If txtdiscount.Enabled = True Then
            disc_perc = txtdiscount.Text
            face_val = txtfacevalue.Text
            disc_amount = disc_perc / 100 * face_val
        Else
            disc_amount = txtdiscountamount.Text
            face_val = txtfacevalue.Text
            disc_perc = disc_amount / face_val * 100
        End If
      

        Dim broadcast As Integer
        If chkbroadcast.Checked = True Then
            broadcast = 1
        Else
            broadcast = 0
        End If

        cmd = New SqlCommand("select * from client_companies where company_name='" + Session("UserCompany") + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim txtWIDNo As String = ds.Tables("deriv_contract").Rows(0).Item("ID")
            Dim txtWEmail As String = ds.Tables("deriv_contract").Rows(0).Item("contact_email")
            Dim txtWCds As String = ds.Tables("deriv_contract").Rows(0).Item("ID")
            Dim txtWforename As String = ds.Tables("deriv_contract").Rows(0).Item("company_name")
            Dim txtWsurname As String = ds.Tables("deriv_contract").Rows(0).Item("company_name")
            Dim txtWaddress As String = "" + ds.Tables("deriv_contract").Rows(0).Item("adress_1") + " " + ds.Tables("deriv_contract").Rows(0).Item("adress_2") + " " + ds.Tables("deriv_contract").Rows(0).Item("adress_3") + ""
            Dim txtWPhone As String = ds.Tables("deriv_contract").Rows(0).Item("contact_phone")

            If checknames(txtWCds) = "available" Then
                cmd = New SqlCommand("insert into Bas (Purpose,Loan_ref,Date_sent,BA_number, Principal_name, Principal_Code,Principal_Email, Principal_Phone,Principal_Add1, Principal_Add2,Principal_Add3,Principal_Add4,Face_value,tenor, Maturity_Date,Discount_Percentage,Discounted_Amount,Ba_Status, Expired,Negotiated,Accept_Participant,issuer,broadcast) values ('" + txtpurpose.Text + "','" + txtloanref.Text + "',GETDATE(),'" + txtbanumber.Text + "','" + txtcompany_name.Text + "','" + txtcompany.Text + "','" + txtemail.Text + "','" + txtphone.Text + "','" + txtaddress.Text + "','" + txtadd2.Text + "','" + txtadd3.Text + "','" + txtadd4.Text + "'," + txtfacevalue.Text + "," + txttenor.Text + ",'" + txtmaturity.Text + "'," + disc_perc.ToString + ",'" + disc_amount.ToString + "','0','0','0','','" + Session("Brokercode") + "','" + broadcast.ToString + "') insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], Pledge_shares, Reference, instrument) values ('" + txtbanumber.Text + "','" + txtWCds + "',getdate(),getdate(),'" + txtfacevalue.Text + "','ALLOT','BA ISSUANCE','0','S','0','" + txtbanumber.Text + "','Bankers Acceptance')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Else
                cmd = New SqlCommand("insert into Bas (Purpose,Loan_ref,Date_sent,BA_number, Principal_name, Principal_Code,Principal_Email, Principal_Phone,Principal_Add1, Principal_Add2,Principal_Add3,Principal_Add4,Face_value,tenor, Maturity_Date,Discount_Percentage,Discounted_Amount,Ba_Status, Expired,Negotiated,Accept_Participant,issuer,broadcast) values ('" + txtpurpose.Text + "','" + txtloanref.Text + "',GETDATE(),'" + txtbanumber.Text + "','" + txtcompany_name.Text + "','" + txtcompany.Text + "','" + txtemail.Text + "','" + txtphone.Text + "','" + txtaddress.Text + "','" + txtadd2.Text + "','" + txtadd3.Text + "','" + txtadd4.Text + "'," + txtfacevalue.Text + "," + txttenor.Text + ",'" + txtmaturity.Text + "'," + disc_perc.ToString + ",'" + disc_amount.ToString + "','0','0','0','','" + Session("Brokercode") + "','" + broadcast.ToString + "')   insert into accounts_clients (cds_number, brokercode, accounttype, surname, middlename, forenames, initials, title, idnopp, idtype, nationality, dob, gender, add_1, add_2,add_3,  add_4, country, city, tel, mobile, email, category, custodian, tradingstatus, industry, tax, div_bank, div_branch, div_accountno, cash_bank, cash_branch, cash_accountno, date_created, update_type, created_by, accountstate) values ('" + txtWCds + "','AIG','C','" + txtWforename + "','','" + txtWsurname + "','','','" + txtWIDNo + "','CDS','','20 Jan 1900','M','" + txtWaddress + "','','','','','','" + txtWPhone + "','" + txtWPhone + "','" + txtWEmail + "','N','','TRADING','LC','5','','','','','','',getdate(),'NEW','NEW BA','A') insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], Pledge_shares, Reference, instrument) values ('" + txtbanumber.Text + "','" + txtWCds + "',getdate(),getdate(),'" + txtfacevalue.Text + "','ALLOT','BA ISSUANCE','0','S','0','" + txtbanumber.Text + "','Bankers Acceptance')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
           
        End If


      
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try

        If broadcast = 1 Then
            sendmail()

        End If
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)

    End Sub
    Public Function checknames(cdsnum As String) As String
        cmd = New SqlCommand("select * from accounts_clients where cds_number='" + cdsnum + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "deriv_contract")
        If ds.Tables(0).Rows.Count > 0 Then
            Return "available"
        Else
            Return "notavailable"
        End If
    End Function

    Protected Sub txttenor_TextChanged(sender As Object, e As EventArgs) Handles txttenor.TextChanged
        Dim mat_date As Date
        Dim tenor As Integer = txttenor.Text
        mat_date = Now.AddDays(tenor)
        txtmaturity.Text = mat_date

    End Sub

    Protected Sub ASPxCheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles ASPxCheckBox4.CheckedChanged
        txtdiscount.Enabled = True
        txtdiscountamount.Enabled = False
        ASPxCheckBox5.Checked = False

    End Sub

    Protected Sub ASPxCheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles ASPxCheckBox5.CheckedChanged
        txtdiscountamount.Enabled = True
        txtdiscount.Enabled = False
        ASPxCheckBox4.Checked = False
    End Sub
    Public Sub sendmail()

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select contact_email as email from client_companies where company_code='" + Session("Brokercode") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "emails")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim Mail As New MailMessage
                Mail.Subject = "New Document with Reference No:" + Session("autogen") + " Uploaded"
                Mail.To.Add("" + ds.Tables("emails").Rows(0).Item("email") + "")
                Mail.From = New MailAddress("corpservesharepower@googlemail.com")
                Mail.Body = "BA " + txtbanumber.Text + " has been successfully broadcasted."
                Dim SMTP As New SmtpClient("smtp.googlemail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("corpservesharepower@googlemail.com", "pavilion$")
                SMTP.Port = "587"
                SMTP.Send(Mail)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
