Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSAdminUserAccounts
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Company),companyType,company_code from CompanyAccounts", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "companyAccounts")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()

                lblCompanytype.Text = ds.Tables(0).Rows(0).Item("companyType").ToString
                lblCompanyCodee.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
                getDepartments()
                'getCompanyCode()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            GetCompany()
            'getDepartments()
        End If
    End Sub
    Public Sub getDepartments()
        Try
            Dim ds As New DataSet

            cmd = New SqlCommand(" select distinct (deptName) from para_dept where company='" & lblCompanyCodee.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_dept")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDepartment.DataSource = ds.Tables(0)
                cmbDepartment.DataValueField = "deptName"
                cmbDepartment.DataBind()
            Else
                cmbDepartment.Items.Clear()
                cmbDepartment.DataSource = Nothing
                cmbDepartment.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompanyCode()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Client_Companies where company_name='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblCompanyCode.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
            Else
                lblCompanyCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select company_code,companyType from CompanyAccounts where company='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "companyAccounts")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblCompanyCodee.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
                lblCompanytype.Text = ds.Tables(0).Rows(0).Item("companyType").ToString
                getDepartments()
                'getCompanyCode()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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

    Protected Sub txtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from systemUsers where username='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblPasswordValidation.Text = ("User name already exists")
                lblPasswordValidation.forecolor = Drawing.Color.Red
            Else
                lblPasswordValidation.Text = ""

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub chkRejectedAccounts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRejectedAccounts.CheckedChanged
        Try
            If (chkRejectedAccounts.Checked = True) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    
    Public Sub getRejectedAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Username) from SystemUsers where ActivationStat=3", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbRejections.DataSource = ds.Tables(0)
                cmbRejections.DataValueField = "Username"
                cmbRejections.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedAccountsDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from SystemUsers where Username='" & cmbRejections.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtUsername.Text = ds.Tables(0).Rows(0).Item("Username").ToString
                txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                txtForenames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
                txtMobile1.Text = ds.Tables(0).Rows(0).Item("mobile1").ToString
                txtMobile2.Text = ds.Tables(0).Rows(0).Item("mobile2").ToString
                txtTelephone.Text = ds.Tables(0).Rows(0).Item("telephone").ToString
                cmbCompany.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                cmbRoles.SelectedItem.Text = ds.Tables(0).Rows(0).Item("UserRole").ToString
                cmbDepartment.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Department").ToString


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Unnamed17_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            SaveAccount()
            'If (rdSuperAdmin.Checked = True) Then
            '    If (txtUsername.Text = "") Then
            '        msgbox("Enter a valid user name")
            '        Exit Sub
            '    End If
            '    If (txtSurname.Text = "") Then
            '        msgbox("Enter a valid surname")
            '        Exit Sub
            '    End If
            '    If (txtForenames.Text = "") Then
            '        msgbox("Enter a valid name")
            '        Exit Sub
            '    End If
            '    If (lblPasswordValidation.Text = "User name already exists") Then
            '        msgbox("Username already exists")
            '        Exit Sub
            '    End If

            '    cmd = New SqlCommand("insert into SystemUsers (company, companycode, companyType,UserName,Department,Password,Activation,Trail,PasswordExpireyDate,UserRole,Email,Telephone,Mobile1,Mobile2,CreatedBy,ActivationStat) values ('" & cmbCompany.Text & "','" & lblCompanyCode.Text & "','" & lblCompanytype.Text & "','" & txtUsername.Text & "','" & cmbDepartment.Text & "','password',0,0,'" & Now.Date & "','Super Admin','" & txtEmail.Text & "','" & txtTelephone.Text & "','" & txtMobile1.Text & "','" & txtMobile2.Text & "','" & Session("Username") & "',0)", cn)
            '    If (cn.State = ConnectionState.Open) Then
            '        cn.Close()
            '    End If
            '    cn.Open()
            '    cmd.ExecuteNonQuery()
            '    cn.Close()


            '    cmd = New SqlCommand("insert into BrokersPermissions (Username,AccountCreations,NewAccountsAuthorizations,AccountUpdates,AccountUpdatesAuth,TransactionBatchCreation,TransactionBatchCreationAuth,AccountEnquiries,PledgeCreation,PledgeCreationAuth,Accountslocking,PortfolioEnquiries,CorporateEnquiries,TransactionsCreations,TransactionsAuth,OrderPosting,OrderUpdate,OrderAuth,FilesExport,FilesImport,Report,UsersCreation,UserCreationAuth,ParametersSetting,EventsDairy,Administration,Super_Administration) values ('" & txtUsername.Text & "',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1)", cn)
            '    If (cn.State = ConnectionState.Open) Then
            '        cn.Close()
            '    End If
            '    cn.Open()
            '    cmd.ExecuteNonQuery()
            '    cn.Close()

            '    msgbox("Account Created, pending authorization")

            '    txtUsername.Text = ""
            '    txtTelephone.Text = ""
            '    txtSurname.Text = ""
            '    txtMobile2.Text = ""
            '    txtMobile1.Text = ""
            '    txtForenames.Text = ""
            '    txtEmail.Text = ""

            'End If


            'If (rdAdmin.Checked = True) Then
            '    If (txtUsername.Text = "") Then
            '        msgbox("Enter a valid user name")
            '        Exit Sub
            '    End If
            '    If (txtSurname.Text = "") Then
            '        msgbox("Enter a valid surname")
            '        Exit Sub
            '    End If
            '    If (txtForenames.Text = "") Then
            '        msgbox("Enter a valid name")
            '        Exit Sub
            '    End If
            '    If (lblPasswordValidation.Text = "User name already exists") Then
            '        msgbox("Username already exists")
            '        Exit Sub
            '    End If

            '    cmd = New SqlCommand("insert into SystemUsers (company, companycode, companyType,UserName,Department,Password,Activation,Trail,PasswordExpireyDate,UserRole,Email,Telephone,Mobile1,Mobile2,CreatedBy,ActivationStat) values ('" & cmbCompany.Text & "','" & lblCompanyCode.Text & "','" & lblCompanytype.Text & "','" & txtUsername.Text & "','" & cmbDepartment.Text & "','password',0,0,'" & Now.Date & "','Admin','" & txtEmail.Text & "','" & txtTelephone.Text & "','" & txtMobile1.Text & "','" & txtMobile2.Text & "','" & Session("Username") & "',0)", cn)
            '    If (cn.State = ConnectionState.Open) Then
            '        cn.Close()
            '    End If
            '    cn.Open()
            '    cmd.ExecuteNonQuery()
            '    cn.Close()


            '    cmd = New SqlCommand("insert into BrokersPermissions (Username,AccountCreations,NewAccountsAuthorizations,AccountUpdates,AccountUpdatesAuth,TransactionBatchCreation,TransactionBatchCreationAuth,AccountEnquiries,PledgeCreation,PledgeCreationAuth,Accountslocking,PortfolioEnquiries,CorporateEnquiries,TransactionsCreations,TransactionsAuth,OrderPosting,OrderUpdate,OrderAuth,FilesExport,FilesImport,Report,UsersCreation,UserCreationAuth,ParametersSetting,EventsDairy,Administration,Super_Administration) values ('" & txtUsername.Text & "',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0)", cn)
            '    If (cn.State = ConnectionState.Open) Then
            '        cn.Close()
            '    End If
            '    cn.Open()
            '    cmd.ExecuteNonQuery()
            '    cn.Close()

            '    msgbox("Account Created, pending authorization")

            '    txtUsername.Text = ""
            '    txtTelephone.Text = ""
            '    txtSurname.Text = ""
            '    txtMobile2.Text = ""
            '    txtMobile1.Text = ""
            '    txtForenames.Text = ""
            '    txtEmail.Text = ""
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveAccount()
        Try
            If (lblPasswordValidation.Text = "User name already exists") Then
                msgbox("Username already exists")
                Exit Sub
            End If
            If (rdAdmin.Checked = False And rdStandard.Checked = False And rdSuperAdmin.Checked = False) Then
                msgbox("Select Account Type")
                Exit Sub
            End If
            If (txtSurname.Text = "") Then
                msgbox("Enter a valid surname")
                Exit Sub
            End If
            If (txtForenames.Text = "") Then
                msgbox("Enter a valid first name")
                Exit Sub
            End If
            If (cmbDepartment.Text = "") Then
                msgbox("Selected company has no valid departments entered into the system")
                Exit Sub
            End If
            Dim PermAssign As String = "O"
            If (chkAssign.Checked = True) Then
                PermAssign = "C"
            Else
                PermAssign = "O"
            End If
            Dim AccType As String = ""
            If (rdSuperAdmin.Checked = True) Then
                AccType = "SAdmin"
            End If
            If (rdAdmin.Checked = True) Then
                AccType = "Admin"
            End If
            If (rdStandard.Checked = True) Then
                AccType = "Standard"
            End If
            cmd = New SqlCommand("insert into SystemUsers (company,companyCode,CompanyType,Username,Department,Password,Activation,PasswordExpireyDate,Password1,Password2,AuthorizePerm,AllocatePermlevel,AccountType,Forenames,Surname,Email,Tel,Mobile1,Mobile2) values ('" & cmbCompany.Text & "', '" & lblCompanyCodee.Text & "','" & lblCompanytype.Text & "','" & txtUsername.Text & "','" & cmbDepartment.Text & "', 'Defaultpass1234',0,'" & Now.Date & "','','',0,'" & PermAssign & "','" & AccType & "','" & txtForenames.Text & "','" & txtSurname.Text & "','" & txtEmail.Text & "','" & txtTelephone.Text & "','" & txtMobile1.Text & "','" & txtMobile2.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into BrokersPermissions (Username,AccountCreations,NewAccountsAuthorizations,AccountUpdates,AccountUpdatesAuth,TransactionBatchCreation,TransactionBatchCreationAuth,AccountEnquiries,PledgeCreation,PledgeCreationAuth,Accountslocking,PortfolioEnquiries,CorporateEnquiries,TransactionsCreations,TransactionsAuth,OrderPosting,OrderUpdate,OrderAuth,FilesExport,FilesImport,Report,UsersCreation,UserCreationAuth,ParametersSetting,EventsDairy,Administration,Super_Administration) values ('" & txtUsername.Text & "',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account Created and submitted for permissions assigning")
            txtUsername.Text = ""
            txtEmail.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
            txtMobile1.Text = ""
            txtMobile2.Text = ""
            txtTelephone.Text = ""
            chkAssign.Checked = False
            rdAdmin.Checked = False
            rdStandard.Checked = False
            rdSuperAdmin.Checked = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
