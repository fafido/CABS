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

Partial Class CDSMode_UserAccountsApproval
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

    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Account has been successfully Approved!")
            End If
            If Session("finish") = "rejection" Then
                Session("finish") = ""
                msgbox("Request has been rejected!")
            End If
            If (Not IsPostBack) Then
                checkSessionState()

                GetSelectedParticipants()
                'rdControlled0.Checked = True
                'rdControlled0.Enabled = True
                'rdControlled1.Enabled = True
                '  GetParticipantUsers()
                GetParticipantUsers_temp()
                '  GetParticipantUsers_REJ()


                ' getphonecodes()

            End If
            '  GetParticipantUsers()
            GetParticipantUsers_temp()
            ' GetParticipantUsers_REJ()



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from client_companies where company_name='" & cmbParticipants.Text & "'", cn)
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
    Public Function alreadyexist(email As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from systemusers where email='" & email & "'", cn)
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
        cmd = New SqlCommand("select * from systemusers where Mobile1='" & mobile & "'", cn)
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
            If txtTel.Text.Length <> 10 Then
                msgbox("Please ensure telephone has 10 characters!")
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
            cmd = New SqlCommand("select * from systemUsers where username='" & txtUsername.Text & "'", cn)
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
        ElseIf ASPxButton1.Text = "Update" Then
            updatetype = "UPDATE"
        Else
            updatetype = "UPDATE"
        End If
        'Dim body As String = "Your Account has been successfully created on Custodial System. Your username is " + txtUsername.Text + " and your password is " + pass + " . Upon first Login you must change your password."
        Dim stmnt As String
        If ASPxButton1.Text = "Approve New Account" Then
            stmnt = " insert into SystemUsers  ([company]      ,[companyCode]      ,[CompanyType]      ,[UserName]      ,[Department]      ,[Password]      ,[Activation]      ,[Trail]      ,[PasswordExpireyDate]      ,[Password1]      ,[Password2]      ,[AuthorizePerm]      ,[AllocatePermLevel]      ,[AccountType]      ,[Forenames]      ,[Surname]      ,[email]      ,[Tel]      ,[Mobile1]      ,[Mobile2]      ,[Idnopp]      ,[title]      ,[gender]      ,[Role]      ,[ContractType]      ,[ExpiryDate] ) select [company]      ,[companyCode]      ,[CompanyType]      ,[UserName]      ,[Department]      ,'" + base64Encode(pass).ToString + "'   ,[Activation]      ,[Trail]      ,[PasswordExpireyDate]      ,[Password1]      ,[Password2]      ,[AuthorizePerm]      ,[AllocatePermLevel]      ,[AccountType]      ,[Forenames]      ,[Surname]      ,[email]      ,[Tel]      ,[Mobile1]      ,[Mobile2]      ,[Idnopp]      ,[title]      ,[gender]      ,[Role]      ,[ContractType]      ,[ExpiryDate]  FROM SystemUsers_Temp where id='" + TXTID.Text + "' update systemusers_temp set Approvedby='" + Session("Username") + "',ApprovedOn=getdate() where id='" + TXTID.Text + "'"
        Else
            stmnt = "  update SystemUsers set idnopp='" + txtIDno.Text + "', gender='" + gender + "', forenames='" + txtOthernames.Text + "',surname='" + txtSurname.Text + "', tel ='" + txtTel.Text + "', Mobile1='" + txtMobile.Text + "', Department='" + txtDepartment.Text + "', email='" + txtEmail.Text + "', AccountType='" + typedat + "' where UserName='" + txtUsername.Text + "' update systemusers_temp set Approvedby='" + Session("Username") + "',ApprovedOn=getdate() where id='" + TXTID.Text + "'"
        End If
        cmd = New SqlCommand(stmnt, cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim m As New sendmail

        If ASPxButton1.Text = "Approve New Account" Then
            m.sendmail(txtEmail.Text, "New User Account Approved", "Your new account on Custodial System has been successfully created, your username is " + txtUsername.Text + " and your password is " + pass + "")
        Else
            m.sendmail(txtEmail.Text, "New Account Update Approved", "Your account on Custodial System has been successfully update, your details have been set as follows CNIC No.:" + txtIDno.Text + ", Gender:" + gender + ", Forename:" + txtOthernames.Text + ",Surname:" + txtSurname.Text + ", Telephone :" + txtTel.Text + ", Mobile:" + txtMobile.Text + ", Department:" + txtDepartment.Text + ", Email:" + txtEmail.Text + ", AccountType:" + typedat + ". If you have any queries contact Administrator!")
        End If

        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)





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
            cmd = New SqlCommand("select id,Username,case when Trail>=4 then 'Unlock' else 'Lock' end as [Action] , Department, case when Approvedby is NULL and Rejected is NULL then 'Pending' when ApprovedBy is NOT NULL then 'Approved' when Rejected is not NULL then 'Rejected' else 'Pending' end as [Activation] , forenames+' '+surname as [Names], Mobile1, email, AccountType, isnull(gender,'N/A') AS gender, PasswordExpireyDate as [PasswordExpiry], UpdateType from SystemUsers_Temp  where  rejected is NULL and approvedby is NULL and capturedby<>'" + Session("Username") + "'", cn)
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

    Private Sub grdJointAccounts0_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdJointAccounts0.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getselecteduserdetails(id)
            '   ASPxButton1.Text = "Approve"
            txtUsername.ReadOnly = True

        End If
    End Sub
    Public Sub unlock(newid As String)
        cmd = New SqlCommand("update systemusers set trail='0', activation='1' where id='" + newid + "'", cn)
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
        cmd = New SqlCommand("update systemusers set trail='4', activation='0' where id='" + newid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim gh As New sendmail
        gh.sendmail(getemail(newid), "Account Locked", "Your Account on Custodial System has been locked. Please contact Administrator for further details!")

    End Sub
    Public Sub resetpassword(newpass As String, newid As String)
        cmd = New SqlCommand("update systemusers set password='" + newpass + "', passwordexpireydate=getdate() where id='" + newid + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim gh As New sendmail
        gh.sendmail(getemail(newid), "Password Reset", "Your Password has been Reset to " + newpass + " by Custodial System Administrator. Please log in to change the password.")

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
        cmd = New SqlCommand("select * from systemusers_Temp where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers1")
        If (ds.Tables(0).Rows.Count > 0) Then

            cmbparticipants.Text = ds.Tables(0).Rows(0).Item("Company").ToString
            txtParticipant.Text = ds.Tables(0).Rows(0).Item("CompanyCode").ToString
            txtParticipantType.Text = ds.Tables(0).Rows(0).Item("CompanyType").ToString
            getphonecodes(txtParticipant.Text)
            TXTID.Text = id.ToString

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
            '  Try
            If ds.Tables(0).Rows(0).Item("UpdateType").ToString = "UPDATE" Then
                    ASPxButton1.Text = "Approve Update"
                Else
                    ASPxButton1.Text = "Approve New Account"
                End If

            'Catch ex As Exception

            'End Try


        End If
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        If txtUsername.Text <> "" Then
            If txtreason.Visible = True Then
                If txtreason.Text <> "" Then
                    cmd = New SqlCommand("update systemusers_temp set rejected='1',rejectreason='" + txtreason.Text + "'  where id='" + TXTID.Text + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Session("finish") = "rejection"
                    Response.Redirect(Request.RawUrl)
                Else
                    msgbox("Please enter the reason for the rejection!")
                    Exit Sub
                End If
            Else
                txtreason.Visible = True
                msgbox("Please enter reason for rejection in the text area below and click reject button again!")

            End If
        Else
            msgbox("Please select a pending request first!")
        End If

    End Sub
End Class
