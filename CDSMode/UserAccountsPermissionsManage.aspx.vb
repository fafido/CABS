Imports System.Data
Imports System.Data.SqlClient
Partial Class UserAccountsPermissionsManage
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, A17, A18, A19, A20, A21, A22, A23, A24, A25, A26, A27, A28 As Integer
    Dim P1(28) As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getPendingAccounts()
            GetAccountDetails()
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
    Public Sub getPendingAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from SystemUsers where AllocatePermLevel='O' and AuthorizePerm=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUsers.DataSource = ds.Tables(0)
                cmbUsers.DataValueField = "Username"
                cmbUsers.DataBind()
            Else
                cmbUsers.Items.Clear()
                cmbUsers.DataSource = Nothing
                cmbUsers.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetAccountDetails()
        Try
            If (cmbUsers.Text = "") Then
                txtUsername.Text = ""
                txtForenames.Text = ""
                txtSurname.Text = ""
                txtCompany.Text = ""
                txtDepartment.Text = ""
                txtUserRole.Text = ""
                txtEmail.Text = ""
                txtTelephone.Text = ""
                txtMobile1.Text = ""
                txtMobile2.Text = ""
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from SystemUsers where username='" & cmbUsers.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "SystemUsers")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtUsername.Text = ds.Tables(0).Rows(0).Item("Username").ToString
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                    txtCompany.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                    txtDepartment.Text = ds.Tables(0).Rows(0).Item("Department").ToString
                    txtUserRole.Text = ds.Tables(0).Rows(0).Item("AccountType").ToString
                    txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
                    txtTelephone.Text = ds.Tables(0).Rows(0).Item("tel").ToString
                    txtMobile1.Text = ds.Tables(0).Rows(0).Item("Mobile1").ToString
                    txtMobile2.Text = ds.Tables(0).Rows(0).Item("Mobile2").ToString
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                ChkPledgeAuth.Checked = ds.Tables(0).Rows(0).Item("TransactionBatchCreationAuth").ToString
                chkEnquiriesDetails.Checked = ds.Tables(0).Rows(0).Item("AccountEnquiries").ToString
                chkEventsCalender.Checked = ds.Tables(0).Rows(0).Item("EventsDairy").ToString
                chkFilesExport.Checked = ds.Tables(0).Rows(0).Item("FilesExport").ToString
                ChkFilesImport.Checked = ds.Tables(0).Rows(0).Item("FilesImport").ToString
                chkNewAccountsAuth.Checked = ds.Tables(0).Rows(0).Item("NewAccountsAuthorizations").ToString
                chkOrdersAuth.Checked = ds.Tables(0).Rows(0).Item("OrderAuth").ToString
                chkOrdersPosting.Checked = ds.Tables(0).Rows(0).Item("OrderPosting").ToString
                ChkMandates.Checked = ds.Tables(0).Rows(0).Item("OrderUpdate").ToString
                chkParaset.Checked = ds.Tables(0).Rows(0).Item("ParametersSetting").ToString
                ChkPledgeAuth.Checked = ds.Tables(0).Rows(0).Item("PledgeCreation").ToString
                ChkPledgeCreUp.Checked = ds.Tables(0).Rows(0).Item("PledgeCreationAuth").ToString
                chkPortfolioEnq.Checked = ds.Tables(0).Rows(0).Item("PortfolioEnquiries").ToString
                chkReports.Checked = ds.Tables(0).Rows(0).Item("Report").ToString
                chkSystemAccCreAuth.Checked = ds.Tables(0).Rows(0).Item("UserCreationAuth").ToString
                chkSystemAccounts.Checked = ds.Tables(0).Rows(0).Item("UsersCreation").ToString
                chkAccsMandateAuth.Checked = ds.Tables(0).Rows(0).Item("TransactionsCreations").ToString
            Else

                chkAccountsCre.Checked = False
                chkAccountsLockUn.Checked = False
                chkAccountsUpdate.Checked = False
                chkAccountsUpdatesAuth.Checked = False
                chkBatchCreations.Checked = False
                ChkPledgeAuth.Checked = False
                chkEnquiriesDetails.Checked = False
                chkEventsCalender.Checked = False
                chkFilesExport.Checked = False
                ChkFilesImport.Checked = False
                chkNewAccountsAuth.Checked = False
                chkOrdersAuth.Checked = False
                chkOrdersPosting.Checked = False
                ChkMandates.Checked = False
                chkParaset.Checked = False
                ChkPledgeAuth.Checked = False
                ChkPledgeCreUp.Checked = False
                ChkPledgeCreUp.Checked = False
                chkPortfolioEnq.Checked = False
                chkReports.Checked = False
                chkSystemAccCreAuth.Checked = False
                chkSystemAccounts.Checked = False
                chkAccsMandateAuth.Checked = False
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
                txtCompany.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                txtUserRole.Text = ds.Tables(0).Rows(0).Item("UserRole").ToString
                txtDepartment.Text = ds.Tables(0).Rows(0).Item("Department").ToString

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
                txtCompany.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                txtUserRole.Text = ds.Tables(0).Rows(0).Item("UserRole").ToString
                txtDepartment.Text = ds.Tables(0).Rows(0).Item("Department").ToString

                getPermissions()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
            'chkAccountsCre.Checked = False
            'chkAccountsLockUn.Checked = False
            'chkAccountsUpdate.Checked = False
            'chkAccountsUpdatesAuth.Checked = False
            'chkBatchCreations.Checked = False
            'ChkPledgeAuth.Checked = False
            'chkEnquiriesDetails.Checked = False
            'chkEventsCalender.Checked = False
            'chkFilesExport.Checked = False
            'ChkFilesImport.Checked = False
            'chkNewAccountsAuth.Checked = False
            'chkOrdersAuth.Checked = False
            'chkOrdersPosting.Checked = False
            'ChkMandates.Checked = False
            'chkParaset.Checked = False
            'ChkPledgeAuth.Checked = False
            'ChkPledgeCreUp.Checked = False
            'ChkPledgeCreUp.Checked = False
            'chkPortfolioEnq.Checked = False
            'chkReports.Checked = False
            'chkSystemAccCreAuth.Checked = False
            'chkSystemAccounts.Checked = False
            'chkAccsMandateAuth.Checked = False

            chkAccountsCre.Checked = False
            chkAccountsUpdate.Checked = False
            chkBatchCreations.Checked = False
            chkAccountsLockUn.Checked = False
            ChkFilesImport.Checked = False
            chkFilesExport.Checked = False
            chkLandingBorrowing.Checked = False
            chkEnquiriesDetails.Checked = False
            chkPortfolioEnq.Checked = False
            ChkPledgeCreUp.Checked = False
            chkOrdersPosting.Checked = False
            ChkMandates.Checked = False
            chkParaset.Checked = False
            chkSystemAccounts.Checked = False
            chkSystemAccPerm.Checked = False
            chkNewAccountsAuth.Checked = False
            chkAccountsUpdatesAuth.Checked = False
            chkAccountsLockAuth.Checked = False
            chkBatchesAuthorizations.Checked = False
            chkLandingBorowAuth.Checked = False
            ChkPledgeAuth.Checked = False
            chkOrdersAuth.Checked = False
            chkAccsMandateAuth.Checked = False
            chkSystemParaAuth.Checked = False
            chkSystemAccCreAuth.Checked = False
            chkAccsPermAuth.Checked = False
            chkReports.Checked = False
            chkEventsCalender.Checked = False

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SetSelectedPermissions()
        Try
            If (chkAccountsCre.Checked = True) Then
                P1(1) = 1
            Else
                P1(1) = 0
            End If
            If (chkAccountsUpdate.Checked = True) Then
                P1(2) = 1
            Else
                P1(2) = 0
            End If
            If (chkBatchCreations.Checked = True) Then
                P1(3) = 1
            Else
                P1(3) = 0
            End If
            If (chkAccountsLockUn.Checked = True) Then
                P1(4) = 1
            Else
                P1(4) = 0
            End If
            If (ChkFilesImport.Checked = True) Then
                P1(5) = 1
            Else
                P1(5) = 0
            End If
            If (chkFilesExport.Checked = True) Then
                P1(6) = 1
            Else
                P1(6) = 0
            End If
            If (chkLandingBorrowing.Checked = True) Then
                P1(7) = 1
            Else
                P1(7) = 0
            End If
            If (chkEnquiriesDetails.Checked) = True Then
                P1(8) = 1
            Else
                P1(8) = 0
            End If
            If (chkPortfolioEnq.Checked = True) Then
                P1(9) = 1
            Else
                P1(9) = 0
            End If
            If (ChkPledgeCreUp.Checked = True) Then
                P1(10) = 1
            Else
                P1(10) = 0
            End If
            If (chkOrdersPosting.Checked = True) Then
                P1(11) = 1
            Else
                P1(11) = 0
            End If
            If (ChkMandates.Checked = True) Then
                P1(12) = 1
            Else
                P1(12) = 0
            End If
            If (chkParaset.Checked = True) Then
                P1(13) = 1
            Else
                P1(13) = 0
            End If
            If (chkSystemAccounts.Checked = True) Then
                P1(14) = 1
            Else
                P1(14) = 0
            End If
            If (chkSystemAccPerm.Checked = True) Then
                P1(15) = 1
            Else
                P1(15) = 0
            End If
            If (chkNewAccountsAuth.Checked = True) Then
                P1(16) = 1
            Else
                P1(16) = 0
            End If
            If (chkAccountsUpdatesAuth.Checked = True) Then
                P1(17) = 1
            Else
                P1(17) = 0
            End If
            If (chkAccountsLockAuth.Checked = True) Then
                P1(18) = 1
            Else
                P1(18) = 0
            End If
            If (chkBatchesAuthorizations.Checked = True) Then
                P1(19) = 1
            Else
                P1(19) = 0
            End If
            If (chkLandingBorowAuth.Checked = True) Then
                P1(20) = 1
            Else
                P1(20) = 0
            End If
            If (ChkPledgeAuth.Checked = True) Then
                P1(21) = 1
            Else
                P1(21) = 0
            End If
            If (chkOrdersAuth.Checked = True) Then
                P1(22) = 1
            Else
                P1(22) = 0
            End If
            If (chkAccsMandateAuth.Checked = True) Then
                P1(23) = 1
            Else
                P1(23) = 0
            End If
            If (chkSystemParaAuth.Checked = True) Then
                P1(24) = 1
            Else
                P1(24) = 0
            End If
            If (chkSystemAccCreAuth.Checked = True) Then
                P1(25) = 1
            Else
                P1(25) = 0
            End If
            If (chkAccsPermAuth.Checked = True) Then
                P1(26) = 1
            Else
                P1(26) = 0
            End If
            If (chkReports.Checked = True) Then
                P1(27) = 1
            Else
                P1(27) = 0
            End If
            If (chkEventsCalender.Checked = True) Then
                P1(28) = 1
            Else
                P1(28) = 0
            End If

            cmd = New SqlCommand("delete from BrokersPermissions where UserName='" & txtUsername.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into brokersPermissions (UserName,AccountsCreation,AccountsEdit,TransactionBatchCreation,Accountslocking,FilesImport,FilesExport,LendingAndBorrowing,DetailsEnquiries,PortfolioEnquiries,PledgeCreation,OrderPosting,AccountsMandates,ParametersSetting,SystemUsersCreation,SystemUsersPerm,NewAccountsAuthorizations,AccountUpdatesAuth,AccountslockingAuth,TransactionBatchCreationAuth,LendingAndBorrowingAuth,PledgeCreationAuth,OrderAuth,AccountsMandatesAuth,ParametersSettingAuth,SystemUsersCreationAuth,SystemUsersPermAuth,Report,EventsDairy) values('" & txtUsername.Text & "', " & P1(1) & ", " & P1(2) & ", " & P1(3) & ", " & P1(4) & ", " & P1(5) & ", " & P1(6) & ", " & P1(7) & ", " & P1(8) & ", " & P1(9) & ", " & P1(10) & ", " & P1(11) & ", " & P1(12) & ", " & P1(13) & ", " & P1(14) & ", " & P1(15) & ", " & P1(16) & ", " & P1(17) & ", " & P1(18) & ", " & P1(19) & ", " & P1(20) & ", " & P1(21) & ", " & P1(22) & ", " & P1(23) & ", " & P1(24) & ", " & P1(25) & ", " & P1(26) & ", " & P1(27) & ", " & P1(28) & ")", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("update SystemUsers set password='password', activation=0 , AuthorizePerm=1, AllocatePermLevel=1 where userName='" & txtUsername.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account Saved, Submitted for Activation")
            ClearAll()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnConserve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConserve.Click
        SetSelectedPermissions()
    End Sub
    Protected Sub cmbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsers.SelectedIndexChanged
        GetAccountDetails()
    End Sub
End Class
