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
Imports DevExpress.Web.ASPxGridView
Imports System.DirectoryServices
Imports System.DirectoryServices.Protocols
Imports System.DirectoryServices.AccountManagement

Partial Class CDSMode_UserAccountsManagement
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
    Public Sub getphonecodes(code As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select phonecode from para_country where country=(select adress_5 from client_companies where company_code='" + code + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_city")
        If (ds.Tables(0).Rows.Count > 0) Then
            '  txtcode1.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode2.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode3.Text = ds.Tables(0).Rows(0).Item("phonecode")

        End If
    End Sub
    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_name) from Client_Companies", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.Items.Add("-Select-")
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
                '  rdControlled0.Checked = True
                rdControlled0.Enabled = True
                rdControlled1.Enabled = True
                GetParticipantUsers()
                GetParticipantUsers_temp()
                GetParticipantUsers_REJ()


                ' getphonecodes()

            End If
            GetParticipantUsers()
            GetParticipantUsers_temp()
            GetParticipantUsers_REJ()



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
                getphonecodes(txtParticipant.Text)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function numberofusers(companycode As String) As Decimal

        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(maxusers,100) as maximum from Client_Companies where Company_Code='" + companycode + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("maximum").ToString
        End If
    End Function
    Public Function limitreached(companycode As String) As Boolean

        Dim ds1 As New DataSet
        cmd = New SqlCommand("select isnull(count(*),0)  as conta from systemusers where companycode='" + companycode + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "client_companies")
        If (ds1.Tables(0).Rows.Count > 0) Then
            Dim max As Decimal = ds1.Tables(0).Rows(0).Item("conta").ToString
            If numberofusers(companycode) <= max Then
                Return True
            Else
                Return False

            End If
        End If
    End Function
    Public Function alreadyexist(email As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from users where email='" & email & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function alreadyexist_mobile(mobile As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from users where Mobile1='" & mobile & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$&*"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        ' If ASPxButton1.Text = "Save" Then

        If txtUsername.Text = "" Then
            msgbox("Enter Username")
            Exit Sub
        End If
        If txtSurname.Text = "" Then
            msgbox("Enter Surname")
            Exit Sub
        End If
        If txtOthernames.Text = "" Then
            msgbox("Enter Forenames")
            Exit Sub
        End If
        If txtIDno.Text = "" Then
            msgbox("Enter ID Number")
            Exit Sub
        End If

        If txtEmail.Text = "" Then
            msgbox("Enter Email")
            Exit Sub

        End If
        If txtTel.Text <> "" Then
            If txtTel.Text.Length > 12 Then
                msgbox("Please enter less than or equal to 12 digits for telephone number!")
                Exit Sub
            End If
            If IsNumeric(txtTel.Text) = False Then
                msgbox("Please enter numeric for telephone!")
                Exit Sub
            End If
        End If


        'If txtUsername.Text <> "" And txtSurname.Text <> "" And txtIDno.Text <> "" And txtEmail.Text <> "" Then
        'Else
        '    msgbox("Please enter a valid Username, ID Number, Surname and Email!")
        '    Exit Sub
        'End If
        If ASPxButton1.Text = "Save" Then


            Dim dsix As New DataSet
            cmd = New SqlCommand("select * from users where username='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsix, "systemusers")
            If (dsix.Tables(0).Rows.Count > 0) Then
                msgbox("Username already exists")
                Exit Sub
            Else

            End If
        End If



        Dim typedat As String = ""
        If (rdControlled0.Checked = True) Then
            typedat = "ADMIN"
        End If
        If (rdControlled1.Checked = True) Then
            typedat = "USER"
        End If
        If typedat = "" Then
            msgbox("Please select User type!")
            Exit Sub
        End If
        Dim lock As Integer
        If rdLockedd.Checked = True Then
            lock = 0

        Else
            lock = 1
        End If
        Dim subject As String
        If typedat = "ADMIN" Then
            subject = "New Admin Account Created"
        Else
            subject = "New User Account Created"
        End If

        Dim pass As String = CreateRandomPassword(12)
        Dim gender As String = ""
        If rdMale.Checked = True Then
            gender = "Male"
        End If
        If rdFemale.Checked = True Then
            gender = "Female"
        End If
        If rdNa.Checked = True Then
            gender = "N/A"
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
        If ASPxButton1.Text = "Save" Then
            If alreadyexist(txtEmail.Text) = True Then
                msgbox("Email Already Exist!")
                Exit Sub
            End If
            If alreadyexist_mobile(txtMobile.Text) = True Then
                msgbox("Mobile Already Exist!")
                Exit Sub
            End If
        End If

        If gender = "" Then
            msgbox("Please select gender!")
            Exit Sub
        End If
        Dim updatetype As String
        If ASPxButton1.Text = "Save" Then
            updatetype = "NEW"
            If limitreached(txtParticipant.Text) = True Then
                msgbox("Maximum number of users reached for participant")
                Exit Sub
            End If
        ElseIf ASPxButton1.Text = "Update" Then
            updatetype = "UPDATE"
        Else
            updatetype = "UPDATE"
        End If


        'Dim body As String = "Your Account has been successfully created on Custodial System. Your username is " + txtUsername.Text + " and your password is " + pass + " . Upon first Login you must change your password."
        Dim stmnt As String
        If ASPxButton1.Text = "Re-Submit" Then
            stmnt = "update systemusers_temp set rejected=NULL, rejectreason=NULL, idnopp='" + txtIDno.Text + "', gender='" + gender + "', forenames='" + txtOthernames.Text + "',surname='" + txtSurname.Text + "', tel ='" + txtTel.Text + "', Mobile1='" + txtMobile.Text + "', Department='" + txtDepartment.Text + "', email='" + txtEmail.Text + "', AccountType='" + typedat + "' where id='" + lblid.Text + "'"
        Else

            stmnt = "insert into systemUsers_Temp (company,companyCode,CompanyType,Username,Department,Password,Activation,Trail,PasswordExpireyDate,AccountType,Forenames,Surname,email, idnopp, gender, mobile1, Tel,  capturedBy, CapturedOn, UpdateType) values ('" & cmbParticipants.SelectedItem.Text & "','" & txtParticipant.Text & "','" & txtParticipantType.Text & "','" & txtUsername.Text & "','" & txtDepartment.Text & "','" + base64Encode(pass) + "','" + lock.ToString + "',0,'" & Now.Date & "','" & typedat & "','" & txtOthernames.Text & "','" & txtSurname.Text & "','" & txtEmail.Text & "','" + txtIDno.Text + "','" + gender + "','" + txtMobile.Text + "','" + txtTel.Text + "','" + Session("Username") + "',getdate(),'" + updatetype + "')"

        End If

        cmd = New SqlCommand(stmnt, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        'Try


        '    Mail.Subject = "New User Account Created"
        '    Mail.To.Add("" + txtEmail.Text + "")
        '    Mail.From = New MailAddress("escrowsystems15@googlemail.com ")
        '    Mail.Body = "Your Account has been successfully created on Central Depository System. Your username is " + txtUsername.Text + " and your password is Resetpassword123 . Upon first Login you must change your password."

        '    Dim SMTP As New SmtpClient("64.233.167.16")
        '    SMTP.EnableSsl = True
        '    SMTP.Credentials = New System.Net.NetworkCredential("escrowsystems15@googlemail.com", "secureaccount2015")
        '    SMTP.Port = "587"
        '    SMTP.Send(Mail)

        'Catch ex As Exception
        '    'msgbox("Message not sent")
        'End Try

        msgbox("Account Saved waiting for Approval")
        txtDepartment.Text = ""
        txtEmail.Text = ""
        txtExpiryDate.Text = ""
        txtIDno.Text = ""
        '  txtInitials.Text = ""
        txtMobile.Text = ""
        txtOthernames.Text = ""
        txtRole.Text = ""
        txtSurname.Text = ""
        txtTel.Text = ""
        txtUsername.Text = ""
        GetParticipantUsers()
        GetParticipantUsers_temp()
        GetParticipantUsers_REJ()




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
            cmd = New SqlCommand("select id,Username,case when Trail>=4 then 'Unlock' else 'Lock' end as [Action] , Department, case activation when 0 then 'Not Active' when 1 then 'Active' else 'Unknown' end as [Activation] , forenames+' '+surname as [Names], Mobile1, email, AccountType, isnull(gender,'N/A') AS gender, PasswordExpireyDate as [PasswordExpiry] from SystemUsers  where companyCode ='" & txtParticipant.Text & "'", cn)
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
    Public Function existinpending(username As String) As Boolean

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from systemusers_temp where username='" + username + "' and rejected is NULL and approvedby is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub GetParticipantUsers_temp()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id,Username,case when Trail>=4 then 'Unlock' else 'Lock' end as [Action] , Department, case when Approvedby is NULL and Rejected is NULL then 'Pending' when ApprovedBy is NOT NULL then 'Approved' when Rejected is not NULL then 'Rejected' else 'Pending' end as [Activation] , forenames+' '+surname as [Names], Mobile1, email, AccountType, isnull(gender,'N/A') AS gender, PasswordExpireyDate as [PasswordExpiry], UpdateType from SystemUsers_Temp  where companyCode ='" & txtParticipant.Text & "' and rejected is NULL and approvedby is NULL", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdJointAccounts0.DataSource = ds.Tables(0)
                grdJointAccounts0.DataBind()
            Else
                grdJointAccounts0.DataSource = Nothing
                grdJointAccounts0.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetParticipantUsers_REJ()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id,Username,case when Trail>=4 then 'Unlock' else 'Lock' end as [Action] , Department, case when Approvedby is NULL and Rejected is NULL then 'Pending' when ApprovedBy is NOT NULL then 'Approved' when Rejected is not NULL then 'Rejected' else 'Pending' end as [Activation] , forenames+' '+surname as [Names], Mobile1, email, AccountType, isnull(gender,'N/A') AS gender, PasswordExpireyDate as [PasswordExpiry], UpdateType from SystemUsers_Temp  where companyCode ='" & txtParticipant.Text & "' and rejected is NOT NULL and approvedby is NULL AND capturedby='" + Session("Username") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdJointAccounts1.DataSource = ds.Tables(0)
                grdJointAccounts1.DataBind()
            Else
                grdJointAccounts1.DataSource = Nothing
                grdJointAccounts1.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        Try
            GetSelectedParticipants()
            GetParticipantUsers()
            GetParticipantUsers_temp()
            GetParticipantUsers_REJ()


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdNew_CheckedChanged(sender As Object, e As EventArgs) Handles rdNew.CheckedChanged

    End Sub

    Protected Sub rdAccPermanent_CheckedChanged(sender As Object, e As EventArgs) Handles rdAccPermanent.CheckedChanged
        txtExpiryDate.Enabled = False
        txtExpiryDate.Text = ""
    End Sub

    Protected Sub rdAccPermanent0_CheckedChanged(sender As Object, e As EventArgs) Handles rdAccPermanent0.CheckedChanged
        txtExpiryDate.Enabled = True

    End Sub


    Protected Sub rdMale_CheckedChanged(sender As Object, e As EventArgs) Handles rdMale.CheckedChanged

    End Sub

    Private Sub grdJointAccounts_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdJointAccounts.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getselecteduserdetails(id)
            ASPxButton1.Text = "Update"
            txtUsername.ReadOnly = True

        ElseIf e.CommandArgs.CommandName.ToString = "PasswordReset" Then
            Dim passnew As String = CreateRandomPassword(9)
            Dim pacrypt As String = base64Encode(passnew)
            resetpassword(pacrypt, passnew, id)
            msgbox("Password Reset Instructions sent by email!")
        ElseIf e.CommandArgs.CommandName.ToString = "Unlock" Then
            unlock(id)
            GetParticipantUsers()
            GetParticipantUsers_temp()
            GetParticipantUsers_REJ()


            msgbox("Account has been unlocked Successfully!")
        ElseIf e.CommandArgs.CommandName.ToString = "Lock" Then
            lock(id)
            GetParticipantUsers()
            GetParticipantUsers_temp()
            GetParticipantUsers_REJ()


            msgbox("Account has been locked Successfully!")
        End If
    End Sub
    Public Sub unlock(newid As String)
        cmd = New SqlCommand("update systemusers set trail='0', activation='1',  Active_session='' where id='" + newid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim gh As New sendmail
        gh.sendmail(getemail(newid), "Account Unlocked", "Your Account on Custodial System has been successfully unlocked. You can now proceed to login.")

    End Sub
    Public Sub lock(newid As String)
        cmd = New SqlCommand("update systemusers set trail='100', activation='0', Active_session='' where id='" + newid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim gh As New sendmail
        gh.sendmail(getemail(newid), "Account Locked", "Your Account on Custodial System has been locked. Please contact Administrator for further details!")

    End Sub
    Public Sub resetpassword(ENCRYPTEDPASS As String, NOT_ENCRYPTED As String, newid As String)
        cmd = New SqlCommand("update systemusers set password='" + ENCRYPTEDPASS + "', passwordexpireydate=getdate() where id='" + newid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim gh As New sendmail
        gh.sendmail(getemail(newid), "Password Reset", "Your Password has been Reset to " + NOT_ENCRYPTED + " by Custodial System Administrator. Please log in to change the password.")

    End Sub
    Public Function getemail(idyacho As String) As String
        cmd = New SqlCommand("select email from systemusers where id='" + idyacho + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_Security_Category1")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("email").ToString
        Else
            Return ""
        End If
    End Function
    Public Sub getselecteduserdetails(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from systemusers where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers1")
        If (ds.Tables(0).Rows.Count > 0) Then

            If existinpending(ds.Tables(0).Rows(0).Item("Username").ToString) = True Then
                msgbox("Account already Updated! Awaiting Authorization!")
                Exit Sub
            End If
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
                If ds.Tables(0).Rows(0).Item("AccountType").ToString = "ADMIN" Then
                    rdControlled0.Checked = True
                    rdControlled1.Checked = False
                Else
                    rdControlled0.Checked = False
                    rdControlled1.Checked = True
                End If
            Catch ex As Exception

            End Try
            Try
                If ds.Tables(0).Rows(0).Item("Gender").ToString = "Male" Then
                    rdMale.Checked = True

                End If
                If ds.Tables(0).Rows(0).Item("Gender").ToString = "Female" Then
                    rdFemale.Checked = True

                End If
                If ds.Tables(0).Rows(0).Item("Gender").ToString = "N/A" Then
                    rdNa.Checked = True

                End If
            Catch ex As Exception

            End Try


        End If
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub grdJointAccounts1_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdJointAccounts1.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getselecteduserdetails_rej(id)
            ASPxButton1.Text = "Re-Submit"
            txtUsername.ReadOnly = True
            lblid.Text = id.ToString
        End If
    End Sub
    Public Sub getselecteduserdetails_rej(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from systemusers_Temp where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers1")
        If (ds.Tables(0).Rows.Count > 0) Then


            If IsDBNull(ds.Tables(0).Rows(0).Item("Username")) = True Then txtUsername.Text = "" Else txtUsername.Text = ds.Tables(0).Rows(0).Item("username")
            If IsDBNull(ds.Tables(0).Rows(0).Item("forenames")) = True Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("forenames")
            If IsDBNull(ds.Tables(0).Rows(0).Item("surname")) = True Then txtSurname.Text = "" Else txtSurname.Text = ds.Tables(0).Rows(0).Item("surname")
            If IsDBNull(ds.Tables(0).Rows(0).Item("tel")) = True Then txtTel.Text = "" Else txtTel.Text = ds.Tables(0).Rows(0).Item("tel")
            If IsDBNull(ds.Tables(0).Rows(0).Item("mobile1")) = True Then txtMobile.Text = "" Else txtMobile.Text = ds.Tables(0).Rows(0).Item("mobile1")
            If IsDBNull(ds.Tables(0).Rows(0).Item("IDnopp")) = True Then txtIDno.Text = "" Else txtIDno.Text = ds.Tables(0).Rows(0).Item("IDnopp")
            If IsDBNull(ds.Tables(0).Rows(0).Item("email")) = True Then txtEmail.Text = "" Else txtEmail.Text = ds.Tables(0).Rows(0).Item("email")
            If IsDBNull(ds.Tables(0).Rows(0).Item("department")) = True Then txtDepartment.Text = "" Else txtDepartment.Text = ds.Tables(0).Rows(0).Item("department")

            Try
                If ds.Tables(0).Rows(0).Item("AccountType").ToString = "ADMIN" Then
                    rdControlled0.Checked = True
                    rdControlled1.Checked = False
                Else
                    rdControlled0.Checked = False
                    rdControlled1.Checked = True
                End If
            Catch ex As Exception

            End Try
            Try
                If ds.Tables(0).Rows(0).Item("Gender").ToString = "Male" Then
                    rdMale.Checked = True

                End If
                If ds.Tables(0).Rows(0).Item("Gender").ToString = "Female" Then
                    rdFemale.Checked = True

                End If
                If ds.Tables(0).Rows(0).Item("Gender").ToString = "N/A" Then
                    rdNa.Checked = True

                End If
            Catch ex As Exception

            End Try


        End If
    End Sub
    Protected Sub btnSearchAD_Click(sender As Object, e As EventArgs) Handles btnSearchAD.Click
        Try
            getUsersNew()
            'searchMyAD2()
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), "usermanagement", ex.ToString)
        End Try
    End Sub
    Sub searchMyAD2()
        Dim dssADDefaults As DataSet = getADCredentials()
        If dssADDefaults.Tables(0).Rows.Count > 0 Then
            Dim adName As String = dssADDefaults.Tables(0).Rows(0).Item("ADName").ToString
            Dim adUserAdmin As String = dssADDefaults.Tables(0).Rows(0).Item("ADUserName").ToString
            Dim adUserPass As String = dssADDefaults.Tables(0).Rows(0).Item("ADPassword").ToString
            'Dim Domain1 As DirectoryEntry = New DirectoryEntry("LDAP://corpserve.local", "Corpserve\Administrator", "lenovo@2021", AuthenticationTypes.ReadonlyServer) 'DC=dept1,DC=com
            Dim Domain1 As DirectoryEntry = New DirectoryEntry("LDAP://" & adName, adUserAdmin, adUserPass, AuthenticationTypes.ReadonlyServer) 'DC=dept1,DC=com
            Dim Searcher1 As DirectorySearcher = New DirectorySearcher("(&(objectCategory=Person)(objectClass=user))")
            Dim Lista1 As New System.Collections.Generic.List(Of String)()

            Searcher1.SearchRoot = Domain1
            Searcher1.SearchScope = DirectoryServices.SearchScope.Subtree
            Dim Results1 As SearchResultCollection
            Results1 = Searcher1.FindAll()
            deleteADUSSERSFromTemp()
            For i As Integer = 0 To Results1.Count - 1
                Lista1.Add(Results1(i).Properties("samaccountname")(0).ToString())
                Dim FullName As String = ""
                Dim FirstName As String = ""
                Dim Surname As String = ""
                Dim username As String = ""
                Dim email As String = ""
                Dim department As String = ""
                Dim userAccountControl As String = ""
                Dim distinguishedName As String = ""
                Try
                    FullName = Results1(i).Properties("displayName")(0).ToString()
                Catch ex As Exception
                End Try
                Try
                    FirstName = Results1(i).Properties("givenName")(0).ToString()
                Catch ex As Exception
                End Try
                Try
                    Surname = Results1(i).Properties("sn")(0).ToString()
                Catch ex As Exception
                End Try
                Try
                    username = Results1(i).Properties("samaccountname")(0).ToString()
                Catch ex As Exception
                End Try
                Try
                    email = Results1(i).Properties("mail")(0).ToString()
                Catch ex As Exception
                End Try
                Try
                    distinguishedName = Results1(i).Properties("distinguishedName")(0).ToString()
                    Dim dpt As String() = Split(distinguishedName, ",")
                    department = dpt(2).Replace("OU=", "")
                Catch ex As Exception
                End Try
                Try
                    userAccountControl = Results1(i).Properties("userAccountControl")(0).ToString()
                Catch ex As Exception
                End Try
                If userAccountControl = "66048" Or userAccountControl = "512" Then
                    ADDADUSSERSTemp(FullName, FirstName, Surname, username, email, department, userAccountControl)
                End If
            Next
            searchADUSERSTempList()
        End If
    End Sub
    Sub ADDADUSSERSTemp(ByVal FullName As String, ByVal FirstName As String, ByVal Surname As String, ByVal MyUsername As String, ByVal Email As String, ByVal Department As String, ByVal AccountState As String)
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmntAUDIT As String = " INSERT INTO ADusersTemp(FullName,FirstName,Surname,Username,Email,Department,AccountState,CreatedBy)VALUES(@FullName,@FirstName,@Surname,@Username,@Email,@Department,@AccountState,@CreatedBy) "
            Using cmd As New SqlCommand(stmntAUDIT, cn)
                cmd.Parameters.AddWithValue("@FullName", FullName)
                cmd.Parameters.AddWithValue("@FirstName", FirstName)
                cmd.Parameters.AddWithValue("@Surname", Surname)
                cmd.Parameters.AddWithValue("@Username", MyUsername)
                cmd.Parameters.AddWithValue("@Email", Email)
                cmd.Parameters.AddWithValue("@Department", Department)
                cmd.Parameters.AddWithValue("@AccountState", AccountState)
                cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
    End Sub
    Sub deleteADUSSERSFromTemp()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim stmntAUDIT As String = " DELETE FROM ADusersTemp WHERE CreatedBy=@CreatedBy "
            Using cmd As New SqlCommand(stmntAUDIT, cn)
                cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
    End Sub
    Sub searchADUSERSTempList()
        Dim strSQL As String = ""
        strSQL = "SELECT A.* FROM [ADusersTemp] A WHERE ISNULL(A.FullName,'')+' '+ISNULL(A.Username,'') LIKE '%'+ @searchname +'%' AND A.CreatedBy=@CreatedBy ORDER BY A.FullName"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@searchname", txtSearchAD.Text)
            cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ADusersTemp")
            If ds.Tables(0).Rows.Count > 0 Then
                lstADNameSearch.DataSource = ds
                lstADNameSearch.TextField = "FullName"
                lstADNameSearch.ValueField = "Username"
                lstADNameSearch.DataBind()
            Else
                lstADNameSearch.DataSource = Nothing
                lstADNameSearch.DataBind()
            End If
        End Using
    End Sub
    Sub populateUserDetailsFromAD()
        Dim strSQL As String = ""
        strSQL = "SELECT A.* FROM [ADusersTemp] A WHERE ISNULL(A.Username,'')=@Username AND A.CreatedBy=@CreatedBy"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            cmd.Parameters.AddWithValue("@Username", lstADNameSearch.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ADusersTemp")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                txtUsername.Text = dr.Item("Username").ToString
                txtSurname.Text = dr.Item("Surname").ToString
                txtOthernames.Text = dr.Item("FirstName").ToString
                txtDepartment.Text = dr.Item("Department").ToString
                txtEmail.Text = dr.Item("Email").ToString
            Else
                txtUsername.Text = ""
                txtSurname.Text = ""
                txtOthernames.Text = ""
                txtDepartment.Text = ""
                txtEmail.Text = ""
            End If
        End Using
    End Sub
    Protected Sub lstADNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstADNameSearch.SelectedIndexChanged
        populateUserDetailsFromAD()
    End Sub
    Private Function getADCredentials() As DataSet
        Dim strSQL As String = ""
        strSQL = "SELECT A.* FROM [Para_AD] A "
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ADusersTemp")
            Return ds
        End Using
    End Function
    Private Sub getUsersNew()
        Dim dssADDefaults As DataSet = getADCredentials()
        If dssADDefaults.Tables(0).Rows.Count > 0 Then
            Dim adName As String = dssADDefaults.Tables(0).Rows(0).Item("ADName").ToString
            Dim adUserAdmin As String = dssADDefaults.Tables(0).Rows(0).Item("ADUserName").ToString
            Dim adUserPass As String = dssADDefaults.Tables(0).Rows(0).Item("ADPassword").ToString
            Dim AD As PrincipalContext = New PrincipalContext(ContextType.Domain, adName, adUserAdmin, adUserPass)
            Dim u As UserPrincipal = New UserPrincipal(AD)
            Dim search As PrincipalSearcher = New PrincipalSearcher(u)
            deleteADUSSERSFromTemp()
            For Each result As UserPrincipal In search.FindAll()
                If result IsNot Nothing AndAlso result.DisplayName IsNot Nothing Then
                    Dim FullName As String = ""
                    Dim FirstName As String = ""
                    Dim Surname As String = ""
                    Dim username As String = ""
                    Dim email As String = ""
                    Dim department As String = ""
                    Dim userAccountControl As String = ""
                    Dim distinguishedName As String = ""
                    Try
                        FullName = result.DisplayName.ToString
                    Catch ex As Exception
                        FullName = ""
                    End Try
                    Try
                        FirstName = result.GivenName.ToString
                    Catch ex As Exception
                        FirstName = ""
                    End Try
                    Try
                        Surname = result.Surname.ToString
                    Catch ex As Exception
                        Surname = ""
                    End Try
                    Try
                        username = result.SamAccountName.ToString
                    Catch ex As Exception
                        username = ""
                    End Try
                    Try
                        email = result.EmailAddress.ToString
                    Catch ex As Exception
                        email = ""
                    End Try
                    Try
                        distinguishedName = result.DistinguishedName.ToString
                        Dim dpt As String() = Split(distinguishedName, ",")
                        department = dpt(2).Replace("OU=", "")
                        'department = distinguishedName
                    Catch ex As Exception
                        department = ""
                    End Try
                    Try
                        userAccountControl = result.Sid.Value.ToString
                    Catch ex As Exception
                        userAccountControl = ""
                    End Try
                    ADDADUSSERSTemp(FullName, FirstName, Surname, username, email, department, userAccountControl)
                End If
            Next
            searchADUSERSTempList()
        End If
    End Sub
End Class
