Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class TransferSec_PledgeAmendments
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
            If Session("end") = "Yes" Then
                Session("end") = ""
                msgbox("Pledge Release Approved")
            Else

            End If
            If Session("end") = "Yes1" Then
                Session("end") = ""
                msgbox("Email Sent to Pledgee and Pledgor for Approval")
            Else

            End If

            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                getlst()
                GetSec_Types()
                GetCompanies()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
    '    Try
    '        Dim ds As New DataSet '
    '        cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='A' and released is null and transferred is null  and id like '" & txtpledgeid.Text & "%'  and id not in (select pledge_id from Pledges_release where release_approval='Yes' and codes is null)", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "Accounts_Clients")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            lstpledgesearch.DataSource = ds.Tables(0)
    '            lstpledgesearch.TextField = "pleadgeinf"
    '            lstpledgesearch.ValueField = "id"
    '            lstpledgesearch.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
    '    Try
    '        Dim dsname As New DataSet '
    '        cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='A' and released is null and transferred is null  and surname like '" & txtpledgorname.Text & "%'  and id not in (select pledge_id from Pledges_release where release_approval='Yes') and codes is null", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dsname, "Accounts_Clients1")
    '        If (dsname.Tables(0).Rows.Count > 0) Then
    '            lstpledgeSearch.DataSource = dsname.Tables(0)
    '            lstpledgeSearch.TextField = "pleadgeinf"
    '            lstpledgeSearch.ValueField = "id"
    '            lstpledgeSearch.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
    '    Try
    '        Dim dspledgee As New DataSet '
    '        cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='A' and released is null  and transferred is null and pledgee_surname like '" & txtpledgeename.Text & "%'  and id not in (select pledge_id from Pledges_release where release_approval='Yes') and codes is null", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dspledgee, "Accounts_Clients2")
    '        If (dspledgee.Tables(0).Rows.Count > 0) Then
    '            lstpledgeSearch.DataSource = dspledgee.Tables(0)
    '            lstpledgeSearch.TextField = "pleadgeinf"
    '            lstpledgeSearch.ValueField = "id"
    '            lstpledgeSearch.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    Public Sub getlst()
        Try
            Dim dspledgee1 As New DataSet '
            cmd = New SqlCommand("select CONVERT(varchar(10), id)+' '+ company+' '+ securitytype+' '+ CONVERT(varchar(10), Quantity ) as pleadgeinf, id from pledges_recording where Pledge_Status='A' and released is null  and transferred is null and amendment is null or amendment='Done'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dspledgee1, "Accounts_Clients21")
            If (dspledgee1.Tables(0).Rows.Count > 0) Then
                lstpledgeSearch.DataSource = dspledgee1.Tables(0)
                lstpledgeSearch.TextField = "pleadgeinf"
                lstpledgeSearch.ValueField = "id"
                lstpledgeSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstpledgeSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstpledgeSearch.SelectedIndexChanged
        '  Try
        'If (lstNameSearch.SelectedIndex.ToString > 1) Then
        Dim dsinfor As New DataSet
        cmd = New SqlCommand("select * from pledges_recording where id ='" & lstpledgeSearch.Value.ToString & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsinfor, "pledge_infor")
        If (dsinfor.Tables(0).Rows.Count > 0) Then
            txtreasons.Text = dsinfor.Tables(0).Rows(0).Item("PledgeReason").ToString

            ' Pledgor Information
            txtpledgor_surname.Text = dsinfor.Tables(0).Rows(0).Item("surname").ToString
            txtpledgor_Id.Text = dsinfor.Tables(0).Rows(0).Item("cds_number").ToString
            txtpledgor_othernames.Text = dsinfor.Tables(0).Rows(0).Item("forenames").ToString

            'Pledge Information
            txtcompany.Text = dsinfor.Tables(0).Rows(0).Item("company").ToString
            txtsecuritytype.Text = dsinfor.Tables(0).Rows(0).Item("SecurityType").ToString
            txtquantity.Text = dsinfor.Tables(0).Rows(0).Item("quantity").ToString
            txteffectivedate.Text = dsinfor.Tables(0).Rows(0).Item("effectivedate").ToString
            txtexpirydate.Text = dsinfor.Tables(0).Rows(0).Item("Expirydate").ToString

            'Pledgee Details
            txtpledgee_address.Text = dsinfor.Tables(0).Rows(0).Item("pledgeee_add_1").ToString
            txtpledgee_client_id.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_cds_number").ToString
            txtpledgee_other_names.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_forenames").ToString
            txtpledgee_surname.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_surname").ToString
            txtpledgee_address2.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_add_2").ToString
            txtpledgee_address3.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_add_3").ToString
            txtpledgee_city.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_city").ToString
            txtpledgee_country.Text = dsinfor.Tables(0).Rows(0).Item("pledgee_country").ToString

            Try
                txtcapitalbenefits.Text = dsinfor.Tables(0).Rows(0).Item("pledge_capital_benefits").ToString
            Catch ex As Exception
                txtcapitalbenefits.Text = "Not Available"
            End Try

            Try
                txtrelease_income.Text = dsinfor.Tables(0).Rows(0).Item("pledge_with_income").ToString
            Catch ex As Exception
                txtrelease_income.Text = "Not Available"
            End Try

            Try
                txtrelease_option.Text = dsinfor.Tables(0).Rows(0).Item("release_option").ToString
                txtrelease_option.Enabled = False
            Catch ex As Exception
                txtrelease_option.Text = ""
            End Try





            If dsinfor.Tables(0).Rows(0).Item("pledgee_type").ToString = "ACCOUNT HOLDER" Then
                rdAccHolder.Checked = True
                rdAccHolder0.Checked = False

            Else
                rdAccHolder.Checked = False
                rdAccHolder0.Checked = True

            End If
            If dsinfor.Tables(0).Rows(0).Item("pledgetype").ToString = "Voluntary" Then
                rdVoluntary.Checked = True
                rdPledgeType.Checked = False

            ElseIf dsinfor.Tables(0).Rows(0).Item("pledgetype").ToString = "FORCED" Then
                rdVoluntary.Checked = False
                rdPledgeType.Checked = True

            End If


            'getrelease()



        Else
            txtreasons.Text = ""
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Sub getrelease()
        Try
            Dim dsrel As New DataSet
            cmd = New SqlCommand("select release_reseason, codes from pledges_release where pledge_id='" + lstpledgeSearch.Value.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsrel, "trans")
            If (dsrel.Tables(0).Rows.Count > 0) Then
                ' cmbcompany.DataSource = dscomps.Tables(0)
                txtreleasereason.Text = dsrel.Tables(0).Rows(0).Item("release_reseason")
                If IsDBNull(dsrel.Tables(0).Rows(0).Item("codes")) = True Then

                Else
                    txtrelease_option.Text = "Pledgee Confirmation[SENT]"
                    msgbox("This request has already been sent to the pledgee for confirmation")
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCompanies()
        Try
            Dim dscomps As New DataSet
            cmd = New SqlCommand("select distinct (company) from trans", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscomps, "trans")
            If (dscomps.Tables(0).Rows.Count > 0) Then
                cmbcompany.DataSource = dscomps.Tables(0)
                cmbcompany.TextField = "company"
                cmbcompany.ValueField = "company"
                cmbcompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSec_Types()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (seccode) as seccode from sec_types ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec_types")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbsecurity_type.DataSource = ds.Tables(0)
                cmbsecurity_type.TextField = "seccode"
                cmbsecurity_type.ValueField = "seccode"
                cmbsecurity_type.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        Try
            If txtrelease_option.Text = "Pledgee Confirmation[SENT]" Then
                msgbox("Email Already sent to the pledgee for confirmation")
            Else
                If txtrelease_option.Text = "Pledgee Confirmation" Then
                    Dim password As String
                    password = 50
                    password = CreateRandomPassword(Integer.Parse(password))

                    cmd = New SqlCommand("Update Pledges_release set codes='" + password + "' where pledge_id='" + lstpledgeSearch.Value.ToString + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Dim Mail As New MailMessage
                    Mail.Subject = "Pledge Release Approval"
                    Mail.To.Add("clivetaps@gmail.com")
                    Mail.From = New MailAddress("escrowcds@googlemail.com")
                    Mail.Body = "Please click the following link to  release the pledge with ID " + lstpledgeSearch.Value.ToString + " Pledgor Name:" & txtpledgor_othernames.Text & " " & txtpledgor_surname.Text & " and Quantity of Share:" & txtquantity.Text & ". Please the following Link to Approve or ignore if you don't want to Approve http://localhost/CDSVers-1/Approvals/client_approve.aspx?ref=" + lstpledgeSearch.Value.ToString + "&num=" + password + "."

                    'Dim SMTP As New SmtpClient("smtp.googlemail.com")
                    Dim SMTP As New SmtpClient("smtp.googlemail.com")
                    SMTP.EnableSsl = True
                    SMTP.Credentials = New System.Net.NetworkCredential("escrowcds@googlemail.com", "escrowcds2014")
                    SMTP.Port = "587"
                    SMTP.Send(Mail)

                    Session("end") = "Yes1"
                    Response.Redirect(Request.RawUrl)

                Else

                    cmd = New SqlCommand("Update Pledges_release set release_approval='Yes' where pledge_id='" + lstpledgeSearch.Value.ToString + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Session("end") = "Yes"
                    Response.Redirect(Request.RawUrl)

                End If
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        Try
            If lstpledgesearch.Value.ToString <> "" Then
                Panel11.Visible = True
                Panel13.Visible = True
                Panelselect.Visible = False
            Else

                msgbox("Please select a pledge first")
            End If
        Catch ex As Exception
            msgbox("Please select a pledge first")
        End Try
       


    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Try
            If lstpledgesearch.Value.ToString <> "" Then
                Panel12.Visible = True
                Panel14.Visible = True
                Panelselect.Visible = False
            Else

                msgbox("Please select a pledge first")
            End If
        Catch ex As Exception
            msgbox("Please select a pledge first")
        End Try

    End Sub

    

    Protected Sub ASPxButton15_Click(sender As Object, e As EventArgs) Handles ASPxButton15.Click
        Dim password, password2 As String
        password = 50
        password = CreateRandomPassword(Integer.Parse(password))

       


        cmd = New SqlCommand("insert into pledgee_amendment (pledge_id, updated_by, date_updated, command_query, code_pledgor, code_pledgee, updated) values ('" + lstpledgesearch.Value.ToString + "','" + Session("username") + "','" + Now() + "','update pledges_recording set company=''" + cmbCompany.SelectedItem.Text + "'', securitytype=''" + cmbSecurity_Type.SelectedItem.Text + "'', Quantity=''" + txtQuantity0.Text + "'', effectivedate=''" + txtEffectiveDate0.Text + "'',expirydate=''" + txtExpiryDate0.Text + "'', release_option=''" + cmbreleaseoption.SelectedItem.Text + "'', pledge_with_income=''" + cmb_withincome.Value.ToString + "'', pledge_capital_benefits=''" + cmbcapital_benefits.Value.ToString + "'', amendment=''Done'' where id=''" + lstpledgesearch.Value.ToString + "''','" + password + "','','No')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


        cmd = New SqlCommand("update pledges_recording set amendment='Yes' where id='" + lstpledgesearch.Value.ToString + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Try
            Dim Mail As New MailMessage
            Mail.Subject = "Pledge Amendment Approval"
            Mail.To.Add("clivetaps@gmail.com")
            Mail.To.Add("clive@escrogroup.com")
            Mail.From = New MailAddress("escrowcds@googlemail.com")
            Mail.Body = "Please click the following link to approve the amendment made to the pledge with ID " + lstpledgesearch.Value.ToString + " Pledgor Name:" & txtpledgor_othernames.Text & " " & txtpledgor_surname.Text & " and Quantity of Share:" & txtQuantity0.Text & ". Please the following Link to Approve or ignore if you don't want to Approve http://localhost/CDSVers-1/Approvals/amend_approve.aspx?ref=" + lstpledgesearch.Value.ToString + "&num=" + password + "."

            'Dim SMTP As New SmtpClient("smtp.googlemail.com")
            Dim SMTP As New SmtpClient("smtp.googlemail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("escrowcds@googlemail.com", "escrowcds2014")
            SMTP.Port = "587"
            SMTP.Send(Mail)
        Catch ex As Exception

        End Try
      
        Try
            cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Amended a pledge request',0,'" + txtpledgor_Id.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try



        Session("end") = "Yes1"
        Response.Redirect(Request.RawUrl)
    End Sub

  
End Class
