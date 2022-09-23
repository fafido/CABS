Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class CDSMode_updateusers
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_name) from Client_Companies", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.DataSource = ds.Tables(0)
                cmbParticipants.DataValueField = "company_name"
                cmbParticipants.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetParticipants()
                GetSelectedParticipants()
                rdControlled0.Checked = True
                rdControlled0.Enabled = False
                rdControlled1.Enabled = False
                GetParticipantUsers()
                loadcode()

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from client_companies where company_name='" & cmbParticipants.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtParticipant.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
                txtParticipantType.Text = ds.Tables(0).Rows(0).Item("company_type").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        'Try

        '    If (rdSave.Checked = True) Then
        '        Dim dsi As New DataSet
        '        cmd = New SqlCommand("select * from systemUsers where username='" & txtUsername.Text & "'", cn)
        '        adp = New SqlDataAdapter(cmd)
        '        adp.Fill(dsi, "systemusers")
        '        If (dsi.Tables(0).Rows.Count > 0) Then

        '            Dim Type As String = ""
        '            If (rdControlled0.Checked = True) Then
        '                Type = "ADMIN"
        '            End If
        '            If (rdControlled1.Checked = True) Then
        '                Type = "USER"
        '            End If

        '            cmd = New SqlCommand("Update systemusers set company='" & cmbParticipants.SelectedItem.Text & "',companyCode='" & txtParticipant.Text & "',companyType='" & txtParticipantType.Text & "', department='" & txtDepartment.Text & "', AccountType='" & Type & "', FORENAMES='" & txtOthernames.Text & "', surname='" & txtSurname.Text & "',email='" & txtEmail.Text & "' where username='" & txtUsername.Text & "'", cn)
        '            If (cn.State = ConnectionState.Open) Then
        '                cn.Close()
        '            End If
        '            cn.Open()
        '            cmd.ExecuteNonQuery()
        '            cn.Close()
        '            msgbox("Record Updated")
        '            txtDepartment.Text = ""
        '            txtEmail.Text = ""
        '            txtExpiryDate.Text = ""
        '            txtIDno.Text = ""
        '            txtInitials.Text = ""
        '            txtMobile.Text = ""
        '            txtOthernames.Text = ""
        '            txtRole.Text = ""
        '            txtSurname.Text = ""
        '            txtTel.Text = ""
        '            txtUsername.Text = ""
        '        Else

        '        End If




        '        If (rdNew.Checked = True) Then
        '            msgbox("test")
        '            Dim dsix As New DataSet
        '            cmd = New SqlCommand("select * from systemUsers where username='" & txtUsername.Text & "'", cn)
        '            adp = New SqlDataAdapter(cmd)
        '            adp.Fill(dsix, "systemusers")
        '            If (dsix.Tables(0).Rows.Count > 0) Then
        '                msgbox("Username already exists")
        '            Else

        '            End If
        '            Dim typedat As String = ""
        '            If (rdControlled0.Checked = True) Then
        '                typedat = "ADMIN"
        '            End If
        '            If (rdControlled1.Checked = True) Then
        '                typedat = "USER"
        '            End If
        '            cmd = New SqlCommand("insert into systemUsers (company,companyCode,CompanyType,Username,Department,Password,Activation,Trail,PasswordExpireyDate,AccountType,Forenames,Surname,email) values ('" & cmbParticipants.SelectedItem.Text & "','" & txtParticipant.Text & "','" & txtParticipantType.Text & "','" & txtUsername.Text & "','" & txtDepartment.Text & "','Resetpassword123',1,0,'" & Now.Date & "','" & typedat & "','" & txtOthernames.Text & "','" & txtSurname.Text & "','" & txtEmail.Text & "')", cn)
        '            If (cn.State = ConnectionState.Open) Then
        '                cn.Close()
        '            End If
        '            cn.Open()
        '            cmd.ExecuteNonQuery()
        '            cn.Close()

        '            msgbox("Account Saved")
        '            txtDepartment.Text = ""
        '            txtEmail.Text = ""
        '            txtExpiryDate.Text = ""
        '            txtIDno.Text = ""
        '            txtInitials.Text = ""
        '            txtMobile.Text = ""
        '            txtOthernames.Text = ""
        '            txtRole.Text = ""
        '            txtSurname.Text = ""
        '            txtTel.Text = ""
        '            txtUsername.Text = ""
        '        End If
        '    End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try


        Dim dsix As New DataSet
        cmd = New SqlCommand("select * from systemUsers where username='" & txtUsername.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsix, "systemusers")
        If (dsix.Tables(0).Rows.Count > 0) Then
            'msgbox("Username already exists")
            'Exit Sub
        Else

        End If

       

        Dim typedat As String = ""
        If (rdControlled0.Checked = True) Then
            typedat = "ADMIN"
        End If
        If (rdControlled1.Checked = True) Then
            typedat = "USER"
        End If

        If txtTel.Text <> "" Then
            If IsNumeric(txtTel.Text) = False Then
                msgbox("Please enter numeric telephone!")
                Exit Sub
            End If
            If txtTel.Text.Length <> 10 Then
                msgbox("Please enter 10 digits!")
                Exit Sub
            End If
        End If


        Dim stmnt As String = "update systemusers set Username=''" + txtUsername.Text + "'',Department=''" + txtDepartment.Text + "'',Forenames=''" + txtOthernames.Text + "'',Surname=''" + txtSurname.Text + "'',email=''" + txtEmail.Text + "'', idnopp=''" + txtIDno.Text + "'', tel= ''" + txtTel.Text + "'', mobile1=''" + txtMobile.Text + "''  where id=''" + txtaccountid.Text + "''"
        Dim descr As String = "Updated System User details to  Username:" + txtUsername.Text + "  First Name: " + txtOthernames.Text + " Surname:" + txtSurname.Text + " CNIC Number:" + txtIDno.Text + "  Telephone: " + txtTel.Text + "  Mobile:" + txtMobile.Text + " Email: " + txtEmail.Text + " Department: " + txtDepartment.Text + ""
        cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','System User Updated')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Try


            Mail.Subject = "Account Details Updated"
            Mail.To.Add("" + txtEmail.Text + "")
            Mail.From = New MailAddress("escrowsystems15@googlemail.com ")
            Mail.Body = "Your Account has been successfully updated on Central Depository System. Thank you for using our Services"

            Dim SMTP As New SmtpClient("64.233.167.16")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("escrowsystems15@googlemail.com", "secureaccount2015")
            SMTP.Port = "587"
            SMTP.Send(Mail)

        Catch ex As Exception
            'msgbox("Message not sent")
        End Try

        msgbox("Account Updated, Waiting Approval")
       
    End Sub
    Private Function base64Encode(ByVal sData As String) As String
        Try
            Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)
            Dim encodedData As String = Convert.ToBase64String(encData_byte)
            Return (encodedData)
        Catch ex As Exception
            Throw (New Exception("Error in base64Encode" & ex.Message))
        End Try
    End Function
    Public Sub GetParticipantUsers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id, userName as [User Account], Department ,mobile1,email, case activation when 0 then 'Not Active' when 1 then 'Active' else 'Unknown' end as [Activation Status] , forenames+' '+surname as [Names] from SystemUsers  where companyCode ='" & txtParticipant.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdJointAccounts.DataSource = ds.Tables(0)
                grdJointAccounts.DataBind()
            Else
                grdJointAccounts.DataSource = Nothing
                grdJointAccounts.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub loadcode()
        Dim ds As New DataSet
        cmd = New SqlCommand("select phonecode from para_country where country='Pakistan'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_city")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtcode1.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode2.Text = ds.Tables(0).Rows(0).Item("phonecode")
        End If
    End Sub
    Public Sub getselecteduserdetails()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from systemusers where id='" + txtaccountid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers1")
        If (ds.Tables(0).Rows.Count > 0) Then
            If IsDBNull(ds.Tables(0).Rows(0).Item("IDnopp")) = True Then txtIDno.Text = "" Else txtIDno.Text = ds.Tables(0).Rows(0).Item("IDnopp")
            If IsDBNull(ds.Tables(0).Rows(0).Item("Username")) = True Then txtUsername.Text = "" Else txtUsername.Text = ds.Tables(0).Rows(0).Item("username")
            If IsDBNull(ds.Tables(0).Rows(0).Item("forenames")) = True Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("forenames")
            If IsDBNull(ds.Tables(0).Rows(0).Item("surname")) = True Then txtSurname.Text = "" Else txtSurname.Text = ds.Tables(0).Rows(0).Item("surname")
            If IsDBNull(ds.Tables(0).Rows(0).Item("tel")) = True Then txtTel.Text = "" Else txtTel.Text = ds.Tables(0).Rows(0).Item("tel")
            If IsDBNull(ds.Tables(0).Rows(0).Item("mobile1")) = True Then txtMobile.Text = "" Else txtMobile.Text = ds.Tables(0).Rows(0).Item("mobile1")
            If IsDBNull(ds.Tables(0).Rows(0).Item("IDnopp")) = True Then txtIDno.Text = "" Else txtIDno.Text = ds.Tables(0).Rows(0).Item("IDnopp")
            If IsDBNull(ds.Tables(0).Rows(0).Item("email")) = True Then txtEmail.Text = "" Else txtEmail.Text = ds.Tables(0).Rows(0).Item("email")
            If IsDBNull(ds.Tables(0).Rows(0).Item("department")) = True Then txtDepartment.Text = "" Else txtDepartment.Text = ds.Tables(0).Rows(0).Item("department")

            Try
                If ds.Tables(0).Rows(0).Item("AccountType") = "ADMIN" Then
                    rdControlled0.Checked = True
                    rdControlled1.Checked = False
                Else
                    rdControlled0.Checked = False
                    rdControlled1.Checked = True
                End If
            Catch ex As Exception

            End Try
            '       Try
            If ds.Tables(0).Rows(0).Item("Activation").ToString = "False" Or ds.Tables(0).Rows(0).Item("trail") >= 4 Then
                ASPxButton2.Text = "Unlock Account"
                msgbox("Account Is Locked!")

            Else
                ASPxButton2.Text = "Lock Account"

            End If
            'Catch ex As Exception

            'End Try

        End If
    End Sub

    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        Try
            GetSelectedParticipants()
            GetParticipantUsers()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

   
    Protected Sub grdjointaccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdjointaccounts.SelectedIndexChanged
        txtaccountid.Text = grdjointaccounts.SelectedValue.ToString
        getselecteduserdetails()

    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            Dim stat As String
            If ASPxButton2.Text = "Unlock Account" Then
                stat = "1"
            Else
                stat = "0"
            End If
            Dim stmnt As String = "update systemusers set Activation=''" + stat + "'', trail=0 where id=''" + txtaccountid.Text + "''"
            Dim descr As String
            If stat = "1" Then
                descr = "Unlocked user " + txtUsername.Text + ""
            Else
                descr = "Locked user " + txtUsername.Text + ""
            End If
            cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','Account Unlocked/Locked')", cn)


            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getselecteduserdetails()
            If stat = "1" Then
                msgbox("Unlock sent for Approval")
            Else
                msgbox("Lock Sent for Approval")
            End If
        Catch ex As Exception

        End Try
      
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        cmd = New SqlCommand("update systemusers set password='UmVzZXRwYXNzd29yZDEyMw==', passwordexpireydate=getdate() where id='" + txtaccountid.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim gh As New sendmail
        gh.sendmail(txtEmail.Text, "Password Reset", "Your Password has been Reset to 'Resetpassword123' by Central Depository System Administrator. Please log in to change the password.")

        msgbox("Password Reset, sent by email!")
    End Sub
End Class
