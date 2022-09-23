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
Partial Class CDSMode_UserAccountsManagement3
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


                cmbParticipants.SelectedItem.Text = Session("usercompany")
                GetSelectedParticipants()
                rdControlled0.Checked = True


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
            msgbox("Username already exists")
            Exit Sub
        Else

        End If

        If txtUsername.Text <> "" And txtSurname.Text <> "" And txtIDno.Text <> "" And txtEmail.Text <> "" Then
        Else

            msgbox("Please enter a valid Username, ID Number, Surname and Email!")
            Exit Sub
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
        cmd = New SqlCommand("insert into systemUsers (company,companyCode,CompanyType,Username,Department,Password,Activation,Trail,PasswordExpireyDate,AccountType,Forenames,Surname,email) values ('" & cmbParticipants.SelectedItem.Text & "','" & txtParticipant.Text & "','" & txtParticipantType.Text & "','" & txtUsername.Text & "','" & txtDepartment.Text & "','Resetpassword123'," + lock + ",0,'" & Now.Date & "','ADMIN','" & txtOthernames.Text & "','" & txtSurname.Text & "','" & txtEmail.Text & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Try


            Mail.Subject = "New User Account Added"
            Mail.To.Add("" + txtEmail.Text + "")
            Mail.From = New MailAddress("escrowsystems15@googlemail.com ")
            Mail.Body = "Your Account has been successfully created on Central Depository System. Your username is " + txtUsername.Text + " and your password is Resetpassword123 . Upon first Login you must change your password."

            Dim SMTP As New SmtpClient("64.233.167.16")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("escrowsystems15@googlemail.com", "secureaccount2015")
            SMTP.Port = "587"
            SMTP.Send(Mail)

        Catch ex As Exception
            'msgbox("Message not sent")
        End Try

        msgbox("Account Saved")
        txtDepartment.Text = ""
        txtEmail.Text = ""
        txtExpiryDate.Text = ""
        txtIDno.Text = ""
        txtInitials.Text = ""
        txtMobile.Text = ""
        txtOthernames.Text = ""
        txtRole.Text = ""
        txtSurname.Text = ""
        txtTel.Text = ""
        txtUsername.Text = ""
    End Sub
    Public Sub GetParticipantUsers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select userName, Department, case activation when 0 then 'Not Active' when 1 then 'Active' else 'Unknown' end as [Activation Status] , forenames+' '+surname as [Names] from SystemUsers  where companyCode ='" & txtParticipant.Text & "'", cn)
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

    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        Try
            GetSelectedParticipants()
            GetParticipantUsers()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
 

    Protected Sub rdNew_CheckedChanged(sender As Object, e As EventArgs) Handles rdNew.CheckedChanged

    End Sub

    Protected Sub rdControlled1_CheckedChanged(sender As Object, e As EventArgs) Handles rdControlled1.CheckedChanged

    End Sub
End Class
