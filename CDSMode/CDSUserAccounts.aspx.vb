Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSUserAccounts
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Company),companyType from CompanyAccounts ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "companyAccounts")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()

                lblCompanytype.Text = ds.Tables(0).Rows(0).Item("companyType").ToString
                getDepartments()
                getCompanyCode()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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

            cmd = New SqlCommand(" select distinct (department) from company_departments where company_type='" & lblCompanytype.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "company_departments")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbDepartment.DataSource = ds.Tables(0)
                cmbDepartment.DataValueField = "department"
                cmbDepartment.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
            cmd = New SqlCommand("select companytype from companyaccounts where company='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "companyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblCompanytype.Text = ds.Tables(0).Rows(0).Item("companytype")
                getDepartments()
                getCompanyCode()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub chkRejectedAccounts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRejectedAccounts.CheckedChanged
        Try
            If (chkRejectedAccounts.Checked = True) Then
                getRejectedAccounts()
                btnDel.Visible = True
            End If
            If (chkRejectedAccounts.Checked = False) Then
                btnDel.Visible = False

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getPermissions()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select * from BrokersPermissions where userName='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BrokersPermissions")
            If (ds.Tables(0).Rows.Count > 0) Then

                chkAccountsCre.Checked = CBool(ds.Tables(0).Rows(0).Item("AccountCreations").ToString)
                chkAccountsLockUn.Checked = ds.Tables(0).Rows(0).Item("AccountsLocking").ToString
                chkAccountsUpdate.Checked = ds.Tables(0).Rows(0).Item("AccountUpdates").ToString
                chkAccountsUpdatesAuth.Checked = ds.Tables(0).Rows(0).Item("AccountUpdatesAuth").ToString
                chkBatchCreations.Checked = ds.Tables(0).Rows(0).Item("TransactionBatchCreation").ToString
                chkBatchesAuthorizations.Checked = ds.Tables(0).Rows(0).Item("TransactionBatchCreationAuth").ToString
                chkCorporateEnquiries.Checked = ds.Tables(0).Rows(0).Item("CorporateEnquiries").ToString
                chkEnquiries.Checked = ds.Tables(0).Rows(0).Item("AccountEnquiries").ToString
                chkEventsCalender.Checked = ds.Tables(0).Rows(0).Item("EventsDairy").ToString
                chkFilesExport.Checked = ds.Tables(0).Rows(0).Item("FilesExport").ToString
                ChkFilesImport.Checked = ds.Tables(0).Rows(0).Item("FilesImport").ToString
                chkNewAccountsAuth.Checked = ds.Tables(0).Rows(0).Item("NewAccountsAuthorizations").ToString
                chkOrdersAuth.Checked = ds.Tables(0).Rows(0).Item("OrderAuth").ToString
                chkOrdersPosting.Checked = ds.Tables(0).Rows(0).Item("OrderPosting").ToString
                ChkOrdersUpdates.Checked = ds.Tables(0).Rows(0).Item("OrderUpdate").ToString
                chkParaset.Checked = ds.Tables(0).Rows(0).Item("ParametersSetting").ToString
                ChkPledgeAuth.Checked = ds.Tables(0).Rows(0).Item("PledgeCreation").ToString
                ChkPledgeCreUp.Checked = ds.Tables(0).Rows(0).Item("PledgeCreationAuth").ToString
                chkPortfolioEnq.Checked = ds.Tables(0).Rows(0).Item("PortfolioEnquiries").ToString
                chkReports.Checked = ds.Tables(0).Rows(0).Item("Report").ToString
                chkSystemAccAuth.Checked = ds.Tables(0).Rows(0).Item("UserCreationAuth").ToString
                chkSystemAccounts.Checked = ds.Tables(0).Rows(0).Item("UsersCreation").ToString
                chkTransactionsAuth.Checked = ds.Tables(0).Rows(0).Item("TransactionsAuth").ToString
                ChkTransactionsCre.Checked = ds.Tables(0).Rows(0).Item("TransactionsCreations").ToString
            Else

                chkAccountsCre.Checked = False
                chkAccountsLockUn.Checked = False
                chkAccountsUpdate.Checked = False
                chkAccountsUpdatesAuth.Checked = False
                chkBatchCreations.Checked = False
                chkBatchesAuthorizations.Checked = False
                chkCorporateEnquiries.Checked = False
                chkEnquiries.Checked = False
                chkEventsCalender.Checked = False
                chkFilesExport.Checked = False
                ChkFilesImport.Checked = False
                chkNewAccountsAuth.Checked = False
                chkOrdersAuth.Checked = False
                chkOrdersPosting.Checked = False
                ChkOrdersUpdates.Checked = False
                chkParaset.Checked = False
                ChkPledgeAuth.Checked = False
                ChkPledgeCreUp.Checked = False
                ChkPledgeCreUp.Checked = False
                chkPortfolioEnq.Checked = False
                chkReports.Checked = False
                chkSystemAccAuth.Checked = False
                chkSystemAccounts.Checked = False
                chkTransactionsAuth.Checked = False
                ChkTransactionsCre.Checked = False
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

                GetRejectedSelectedAccountsDetails()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetRejectedSelectedAccountsDetails()
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

                getPermissions()
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

                getPermissions()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub Unnamed17_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (chkRejectedAccounts.Checked = False) Then
            Try
                Dim AccountsCrea As Integer = 0
                If (chkAccountsCre.Checked = True) Then
                    AccountsCrea = 1
                End If
                Dim AccountsCreaAuth As Integer = 0
                If (chkNewAccountsAuth.Checked = True) Then
                    AccountsCreaAuth = 1
                End If

                Dim AccountsUpdate As Integer = 0
                If (chkAccountsUpdate.Checked = True) Then
                    AccountsUpdate = 1
                End If
                Dim AccountsUpdateAuth As Integer = 0
                If (chkAccountsUpdatesAuth.Checked = True) Then
                    AccountsUpdateAuth = 1
                End If
                Dim BatchCrea As Integer = 0
                If (chkBatchCreations.Checked = True) Then
                    BatchCrea = 1
                End If
                Dim BatchCreaAuth As Integer = 0
                If (chkBatchesAuthorizations.Checked = True) Then
                    BatchCreaAuth = 1
                End If
                Dim AccountEnquiries As Integer = 0
                If (chkEnquiries.Checked = True) Then
                    AccountEnquiries = 1
                End If
                Dim PledgesCrea As Integer = 0
                If (ChkPledgeCreUp.Checked = True) Then
                    PledgesCrea = 1
                End If
                Dim PledgesCreaAuth As Integer = 0
                If (ChkPledgeAuth.Checked = True) Then
                    PledgesCreaAuth = 1
                End If
                Dim MemberAccountsLock As Integer = 0
                If (chkAccountsLockUn.Checked = True) Then
                    MemberAccountsLock = 1
                End If
                Dim MemberAccountsLockAuth As Integer = 0
                Dim PortfolioEnq As Integer = 0
                If (chkPortfolioEnq.Checked = True) Then
                    PortfolioEnq = 1
                End If
                Dim CorpEnq As Integer = 0
                If (chkCorporateEnquiries.Checked = True) Then
                    CorpEnq = 1
                End If
                Dim TransactionsCrea As Integer = 0
                If (ChkTransactionsCre.Checked = True) Then
                    TransactionsCrea = 1
                End If
                Dim TransactionsCreaAuth As Integer = 0
                If (chkTransactionsAuth.Checked = True) Then
                    TransactionsCreaAuth = 1
                End If

                Dim OrderPosting As Integer = 0
                If (chkOrdersPosting.Checked = True) Then
                    OrderPosting = 1
                End If
                Dim OrderUpdate As Integer = 0
                If (ChkOrdersUpdates.Checked = True) Then
                    OrderUpdate = 1
                End If
                Dim OrderAuth As Integer = 0
                If (chkOrdersAuth.Checked = True) Then
                    OrderAuth = 1
                End If
                Dim FileExport As Integer = 0
                If (chkFilesExport.Checked = True) Then
                    FileExport = 1
                End If
                Dim FileImport As Integer = 0
                If (ChkFilesImport.Checked = True) Then
                    FileImport = 1
                End If
                Dim Reports As Integer = 0
                If (chkReports.Checked = True) Then
                    Reports = 1
                End If
                Dim UsersCrea As Integer = 0
                If (chkSystemAccounts.Checked = True) Then
                    UsersCrea = 1
                End If
                Dim UsersCreaAuth As Integer = 0
                If (chkSystemAccAuth.Checked = True) Then
                    UsersCreaAuth = 1
                End If
                Dim ParaSet As Integer = 0
                If (chkParaset.Checked = True) Then
                    ParaSet = 1
                End If
                Dim EventsDiary As Integer = 0
                If (chkEventsCalender.Checked = True) Then
                    EventsDiary = 1
                End If


                If (txtUsername.Text = "") Then
                    msgbox("Enter a valid user name")
                    Exit Sub
                End If
                If (txtSurname.Text = "") Then
                    msgbox("Enter a valid surname")
                    Exit Sub
                End If
                If (txtForenames.Text = "") Then
                    msgbox("Enter a valid name")
                    Exit Sub
                End If
                If (lblPasswordValidation.Text = "User name already exists") Then
                    msgbox("Username already exists")
                    Exit Sub
                End If

                cmd = New SqlCommand("insert into SystemUsers (company, companycode, companyType,UserName,Department,Password,Activation,Trail,PasswordExpireyDate,UserRole,Email,Telephone,Mobile1,Mobile2,CreatedBy,ActivationStat) values ('" & cmbCompany.Text & "','" & lblCompanyCode.Text & "','" & lblCompanytype.Text & "','" & txtUsername.Text & "','" & cmbDepartment.Text & "','password',0,0,'" & Now.Date & "','" & cmbRoles.Text & "','" & txtEmail.Text & "','" & txtTelephone.Text & "','" & txtMobile1.Text & "','" & txtMobile2.Text & "','" & Session("Username") & "',0)", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("insert into BrokersPermissions (Username,AccountCreations,NewAccountsAuthorizations,AccountUpdates,AccountUpdatesAuth,TransactionBatchCreation,TransactionBatchCreationAuth,AccountEnquiries,PledgeCreation,PledgeCreationAuth,Accountslocking,PortfolioEnquiries,CorporateEnquiries,TransactionsCreations,TransactionsAuth,OrderPosting,OrderUpdate,OrderAuth,FilesExport,FilesImport,Report,UsersCreation,UserCreationAuth,ParametersSetting,EventsDairy) values ('" & txtUsername.Text & "'," & AccountsCrea & "," & AccountsCreaAuth & "," & AccountsUpdate & "," & AccountsUpdateAuth & "," & BatchCrea & "," & BatchCreaAuth & "," & AccountEnquiries & "," & PledgesCrea & "," & PledgesCreaAuth & "," & MemberAccountsLock & "," & PortfolioEnq & "," & CorpEnq & "," & TransactionsCrea & "," & TransactionsCreaAuth & "," & OrderPosting & "," & OrderUpdate & "," & OrderAuth & "," & FileExport & "," & FileImport & "," & Reports & "," & UsersCrea & "," & UsersCreaAuth & "," & ParaSet & "," & EventsDiary & ")", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                msgbox("Account created, submitted for authorization")
                txtEmail.Text = ""
                txtForenames.Text = ""
                txtMobile1.Text = ""
                txtMobile2.Text = ""
                txtSurname.Text = ""
                txtTelephone.Text = ""
                txtUsername.Text = ""
                chkAccountsCre.Checked = False
                chkAccountsLockUn.Checked = False
                chkAccountsUpdate.Checked = False
                chkAccountsUpdatesAuth.Checked = False
                chkBatchCreations.Checked = False
                chkBatchesAuthorizations.Checked = False
                chkCorporateEnquiries.Checked = False
                chkEnquiries.Checked = False
                chkEventsCalender.Checked = False
                chkFilesExport.Checked = False
                ChkFilesImport.Checked = False
                chkNewAccountsAuth.Checked = False
                chkOrdersAuth.Checked = False
                chkOrdersPosting.Checked = False
                ChkOrdersUpdates.Checked = False
                chkParaset.Checked = False
                ChkPledgeAuth.Checked = False
                ChkPledgeCreUp.Checked = False
                ChkPledgeCreUp.Checked = False
                chkPortfolioEnq.Checked = False
                chkReports.Checked = False
                chkSystemAccAuth.Checked = False
                chkSystemAccounts.Checked = False
                chkTransactionsAuth.Checked = False
                ChkTransactionsCre.Checked = False

            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If

        If (chkRejectedAccounts.Checked = True) Then
            Try


                cmd = New SqlCommand("delete from brokerpermissions where username='" & cmbRejections.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                cmd = New SqlCommand("delete from systemUsers where username='" & cmbRejections.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                Dim AccountsCrea As Integer = 0
                If (chkAccountsCre.Checked = True) Then
                    AccountsCrea = 1
                End If
                Dim AccountsCreaAuth As Integer = 0
                If (chkNewAccountsAuth.Checked = True) Then
                    AccountsCreaAuth = 1
                End If

                Dim AccountsUpdate As Integer = 0
                If (chkAccountsUpdate.Checked = True) Then
                    AccountsUpdate = 1
                End If
                Dim AccountsUpdateAuth As Integer = 0
                If (chkAccountsUpdatesAuth.Checked = True) Then
                    AccountsUpdateAuth = 1
                End If
                Dim BatchCrea As Integer = 0
                If (chkBatchCreations.Checked = True) Then
                    BatchCrea = 1
                End If
                Dim BatchCreaAuth As Integer = 0
                If (chkBatchesAuthorizations.Checked = True) Then
                    BatchCreaAuth = 1
                End If
                Dim AccountEnquiries As Integer = 0
                If (chkEnquiries.Checked = True) Then
                    AccountEnquiries = 1
                End If
                Dim PledgesCrea As Integer = 0
                If (ChkPledgeCreUp.Checked = True) Then
                    PledgesCrea = 1
                End If
                Dim PledgesCreaAuth As Integer = 0
                If (ChkPledgeAuth.Checked = True) Then
                    PledgesCreaAuth = 1
                End If
                Dim MemberAccountsLock As Integer = 0
                If (chkAccountsLockUn.Checked = True) Then
                    MemberAccountsLock = 1
                End If
                Dim MemberAccountsLockAuth As Integer = 0
                Dim PortfolioEnq As Integer = 0
                If (chkPortfolioEnq.Checked = True) Then
                    PortfolioEnq = 1
                End If
                Dim CorpEnq As Integer = 0
                If (chkCorporateEnquiries.Checked = True) Then
                    CorpEnq = 1
                End If
                Dim TransactionsCrea As Integer = 0
                If (ChkTransactionsCre.Checked = True) Then
                    TransactionsCrea = 1
                End If
                Dim TransactionsCreaAuth As Integer = 0
                If (chkTransactionsAuth.Checked = True) Then
                    TransactionsCreaAuth = 1
                End If

                Dim OrderPosting As Integer = 0
                If (chkOrdersPosting.Checked = True) Then
                    OrderPosting = 1
                End If
                Dim OrderUpdate As Integer = 0
                If (ChkOrdersUpdates.Checked = True) Then
                    OrderUpdate = 1
                End If
                Dim OrderAuth As Integer = 0
                If (chkOrdersAuth.Checked = True) Then
                    OrderAuth = 1
                End If
                Dim FileExport As Integer = 0
                If (chkFilesExport.Checked = True) Then
                    FileExport = 1
                End If
                Dim FileImport As Integer = 0
                If (ChkFilesImport.Checked = True) Then
                    FileImport = 1
                End If
                Dim Reports As Integer = 0
                If (chkReports.Checked = True) Then
                    Reports = 1
                End If
                Dim UsersCrea As Integer = 0
                If (chkSystemAccounts.Checked = True) Then
                    UsersCrea = 1
                End If
                Dim UsersCreaAuth As Integer = 0
                If (chkSystemAccAuth.Checked = True) Then
                    UsersCreaAuth = 1
                End If
                Dim ParaSet As Integer = 0
                If (chkParaset.Checked = True) Then
                    ParaSet = 1
                End If
                Dim EventsDiary As Integer = 0
                If (chkEventsCalender.Checked = True) Then
                    EventsDiary = 1
                End If


                If (txtUsername.Text = "") Then
                    msgbox("Enter a valid user name")
                    Exit Sub
                End If
                If (txtSurname.Text = "") Then
                    msgbox("Enter a valid surname")
                    Exit Sub
                End If
                If (txtForenames.Text = "") Then
                    msgbox("Enter a valid name")
                    Exit Sub
                End If
                If (lblPasswordValidation.Text = "User name already exists") Then
                    msgbox("Username already exists")
                    Exit Sub
                End If

                cmd = New SqlCommand("insert into SystemUsers (company, companycode, companyType,UserName,Department,Password,Activation,Trail,PasswordExpireyDate,UserRole,Email,Telephone,Mobile1,Mobile2,CreatedBy,ActivationStat) values ('" & cmbCompany.Text & "','" & lblCompanyCode.Text & "','" & lblCompanytype.Text & "','" & txtUsername.Text & "','" & cmbDepartment.Text & "','password',0,0,'" & Now.Date & "','" & cmbRoles.Text & "','" & txtEmail.Text & "','" & txtTelephone.Text & "','" & txtMobile1.Text & "','" & txtMobile2.Text & "','" & Session("Username") & "',0)", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("insert into BrokersPermissions (Username,AccountCreations,NewAccountsAuthorizations,AccountUpdates,AccountUpdatesAuth,TransactionBatchCreation,TransactionBatchCreationAuth,AccountEnquiries,PledgeCreation,PledgeCreationAuth,Accountslocking,PortfolioEnquiries,CorporateEnquiries,TransactionsCreations,TransactionsAuth,OrderPosting,OrderUpdate,OrderAuth,FilesExport,FilesImport,Report,UsersCreation,UserCreationAuth,ParametersSetting,EventsDairy) values ('" & txtUsername.Text & "'," & AccountsCrea & "," & AccountsCreaAuth & "," & AccountsUpdate & "," & AccountsUpdateAuth & "," & BatchCrea & "," & BatchCreaAuth & "," & AccountEnquiries & "," & PledgesCrea & "," & PledgesCreaAuth & "," & MemberAccountsLock & "," & PortfolioEnq & "," & CorpEnq & "," & TransactionsCrea & "," & TransactionsCreaAuth & "," & OrderPosting & "," & OrderUpdate & "," & OrderAuth & "," & FileExport & "," & FileImport & "," & Reports & "," & UsersCrea & "," & UsersCreaAuth & "," & ParaSet & "," & EventsDiary & ")", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                msgbox("Account created, submitted for authorization")
                txtEmail.Text = ""
                txtForenames.Text = ""
                txtMobile1.Text = ""
                txtMobile2.Text = ""
                txtSurname.Text = ""
                txtTelephone.Text = ""
                txtUsername.Text = ""
                chkAccountsCre.Checked = False
                chkAccountsLockUn.Checked = False
                chkAccountsUpdate.Checked = False
                chkAccountsUpdatesAuth.Checked = False
                chkBatchCreations.Checked = False
                chkBatchesAuthorizations.Checked = False
                chkCorporateEnquiries.Checked = False
                chkEnquiries.Checked = False
                chkEventsCalender.Checked = False
                chkFilesExport.Checked = False
                ChkFilesImport.Checked = False
                chkNewAccountsAuth.Checked = False
                chkOrdersAuth.Checked = False
                chkOrdersPosting.Checked = False
                ChkOrdersUpdates.Checked = False
                chkParaset.Checked = False
                ChkPledgeAuth.Checked = False
                ChkPledgeCreUp.Checked = False
                ChkPledgeCreUp.Checked = False
                chkPortfolioEnq.Checked = False
                chkReports.Checked = False
                chkSystemAccAuth.Checked = False
                chkSystemAccounts.Checked = False
                chkTransactionsAuth.Checked = False
                ChkTransactionsCre.Checked = False

            Catch ex As Exception
                msgbox(ex.Message)
            End Try

        End If
        
    End Sub
    Public Sub ClearAll()
        Try
            txtEmail.Text = ""
            txtForenames.Text = ""
            txtMobile1.Text = ""
            txtMobile2.Text = ""
            txtSurname.Text = ""
            txtTelephone.Text = ""
            txtUsername.Text = ""
            chkAccountsCre.Checked = False
            chkAccountsLockUn.Checked = False
            chkAccountsUpdate.Checked = False
            chkAccountsUpdatesAuth.Checked = False
            chkBatchCreations.Checked = False
            chkBatchesAuthorizations.Checked = False
            chkCorporateEnquiries.Checked = False
            chkEnquiries.Checked = False
            chkEventsCalender.Checked = False
            chkFilesExport.Checked = False
            ChkFilesImport.Checked = False
            chkNewAccountsAuth.Checked = False
            chkOrdersAuth.Checked = False
            chkOrdersPosting.Checked = False
            ChkOrdersUpdates.Checked = False
            chkParaset.Checked = False
            ChkPledgeAuth.Checked = False
            ChkPledgeCreUp.Checked = False
            ChkPledgeCreUp.Checked = False
            chkPortfolioEnq.Checked = False
            chkReports.Checked = False
            chkSystemAccAuth.Checked = False
            chkSystemAccounts.Checked = False
            chkTransactionsAuth.Checked = False
            ChkTransactionsCre.Checked = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            If (chkRejectedAccounts.Checked = True) Then
                cmd = New SqlCommand("delete from brokerpermissions where username='" & cmbRejections.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                cmd = New SqlCommand("delete from systemUsers where username='" & cmbRejections.Text & "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


                msgbox("Account removed")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
