Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_UserAccountsCreate
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then

            GetCompanyNames()
            getCompanyTypes()
            GetDepartment()
            'getDepartments()
        End If
    End Sub
  
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub rdCreateNew_CheckedChanged(sender As Object, e As EventArgs) Handles rdCreateNew.CheckedChanged
        Try
            If (rdCreateNew.Checked = True) Then
                btnSave.Text = "save"
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdUpdateAccount_CheckedChanged(sender As Object, e As EventArgs) Handles rdUpdateAccount.CheckedChanged
        Try
            If (rdUpdateAccount.Checked = True) Then
                btnSave.Text = "update"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rdResetPass_CheckedChanged(sender As Object, e As EventArgs) Handles rdResetPass.CheckedChanged
        Try
            If (rdResetPass.Checked = True) Then
                btnSave.Text = "Reset Password"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rdDeleteAccount_CheckedChanged(sender As Object, e As EventArgs) Handles rdDeleteAccount.CheckedChanged
        Try
            If (rdDeleteAccount.Checked = True) Then
                btnSave.Text = "delete"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rdAccountReport_CheckedChanged(sender As Object, e As EventArgs) Handles rdAccountReport.CheckedChanged
        If (rdAccountReport.Checked = True) Then
            btnSave.Text = "print"
        End If
    End Sub
    Public Sub GetCompanyNames()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_name) from client_companies", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company_name"
                cmbCompany.DataBind()
            Else
                cmbCompany.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompanyTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_type),company_code from client_companies where company_name='" & cmbCompany.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbOrganizationType.DataSource = ds.Tables(0)
                cmbOrganizationType.DataValueField = "company_type"
                cmbOrganizationType.DataBind()
                lblcompanyCode.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
            Else
                cmbOrganizationType.Items.Clear()
                lblcompanyCode.Text = ""
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetDepartment()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (role) from userRoles", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "userRoles")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDepartment.DataSource = ds.Tables(0)
                cmbDepartment.DataValueField = "role"
                cmbDepartment.DataBind()
            Else
                cmbDepartment.Items.Clear()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getCompanyTypes()
    End Sub
    Public Sub SaveNewAcc()
        Try
            If (txtUsername.Text.Length < 1) Then
                msgbox("Enter a valid name")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from systemusers where username ='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemusers")
            If (ds.Tables(0).Rows.Count > 0) Then
                msgbox("user name already exist")
                txtUsername.Focus()
                Exit Sub
            Else
                Dim surname As String = ""
                Dim forenames As String = ""
                Dim AccountType As String = ""
                If (rdSystemAdmin.Checked = False And rdSystemUser.Checked = False) Then
                    msgbox("Select Account Type")
                    Exit Sub
                End If
                If (rdSystemAdmin.Checked = True) Then
                    AccountType = "ADMIN"
                End If
                If (rdSystemUser.Checked = True) Then
                    AccountType = "USER"
                End If
                If (txtSurname.Text.Contains("'")) Then
                    surname = Replace(txtSurname.Text, "'", " ")
                Else
                    surname = txtSurname.Text
                End If
                If (txtForenames.Text.Contains("'")) Then
                    forenames = Replace(txtForenames.Text, "'", " ")
                Else
                    forenames = txtForenames.Text
                End If
                cmd = New SqlCommand("insert into systemusers (company,companyCode,CompanyType,UserName,Department,Password,Activation,Trail,PasswordExpireyDate,Password1,Password2,AuthorizePerm,AllocatePermLevel,AccountType,Forenames,Surname,email,Tel,Mobile1,Tel,Mobile1,Mobile2) values ('" & cmbCompany.SelectedItem.Text & "','" & lblcompanyCode.Text & "','" & cmbOrganizationType.SelectedItem.Text & "','" & txtUsername.Text & "','" & cmbDepartment.SelectedItem.Text & "','password123',0,0,'" & Now.Date.AddDays(-1) & "','password123','password123',0,'C','" & AccountType & "','" & forenames & "','" & surname & "','" & txtemail.Text.ToLower & "','" & txtmobile1.Text & "','" & txtmobile2.Text & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()

                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Account is saved ")
                rdAccountReport.Checked = False
                rdCreateNew.Checked = False
                rdDeleteAccount.Checked = False
                rdResetPass.Checked = False
                rdSystemAdmin.Checked = False
                rdUpdateAccount.Checked = False
                rdSystemUser.Checked = False

                txtUsername.Text = ""
                txtemail.Text = ""
                txtForenames.Text = ""
                txtmobile1.Text = ""
                txtmobile2.Text = ""
                txtSurname.Text = ""
                txtTelephone.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetsavedAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from usermanagement where companycode='" & Session("brokercode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "usermanagement")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSavedUsers.DataSource = ds.Tables(0)
                cmbSavedUsers.DataValueField = "username"
                cmbSavedUsers.DataBind()
            Else
                cmbSavedUsers.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
