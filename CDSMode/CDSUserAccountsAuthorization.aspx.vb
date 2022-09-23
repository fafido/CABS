Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSUserAccountsAuthorization
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            getNewAccounts()
            GetSelectedAccountsDetails()
        End If
    End Sub
    Protected Sub cmbusers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbusers.SelectedIndexChanged
        GetSelectedAccountsDetails()
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
    Protected Sub Unnamed2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from SystemUsers where Username='" & txtUsernameSearch.Text & "' and password='password' and activation=0", cn)
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

                getPermissions()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getPermissions()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select * from BrokersPermissions where userName='" & txtUsername.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BrokersPermissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                'msgbox(CBool(ds.Tables(0).Rows(0).Item("FilesExport").ToString))
                chkFilesExport.Checked = CBool(ds.Tables(0).Rows(0).Item("FilesExport").ToString)
                'chkAccountsCre.Checked = CBool(ds.Tables(0).Rows(0).Item("AccountCreations").ToString)
                chkAccountsLockUn.Checked = ds.Tables(0).Rows(0).Item("AccountsLocking").ToString
                chkAccountsUpdate.Checked = ds.Tables(0).Rows(0).Item("AccountsEdit").ToString
                chkAccountsUpdatesAuth.Checked = ds.Tables(0).Rows(0).Item("AccountUpdatesAuth").ToString
                chkBatchCreations.Checked = ds.Tables(0).Rows(0).Item("TransactionBatchCreation").ToString
                chkBatchesAuthorizations.Checked = ds.Tables(0).Rows(0).Item("TransactionBatchCreationAuth").ToString
                chkEventsCalender.Checked = ds.Tables(0).Rows(0).Item("EventsDairy").ToString
                ChkFilesImport.Checked = CBool(ds.Tables(0).Rows(0).Item("FilesImport").ToString)
                chkNewAccountsAuth.Checked = ds.Tables(0).Rows(0).Item("NewAccountsAuthorizations").ToString
                chkOrdersAuth.Checked = ds.Tables(0).Rows(0).Item("OrderAuth").ToString
                chkOrdersPosting.Checked = ds.Tables(0).Rows(0).Item("OrderPosting").ToString
                chkParaset.Checked = ds.Tables(0).Rows(0).Item("ParametersSetting").ToString
                ChkPledgeAuth.Checked = ds.Tables(0).Rows(0).Item("PledgeCreation").ToString
                ChkPledgeCreUp.Checked = ds.Tables(0).Rows(0).Item("PledgeCreationAuth").ToString
                chkPortfolioEnq.Checked = ds.Tables(0).Rows(0).Item("PortfolioEnquiries").ToString
                chkReports.Checked = ds.Tables(0).Rows(0).Item("Report").ToString
                chkSystemAccounts.Checked = ds.Tables(0).Rows(0).Item("SystemUsersCreation").ToString
                chkAccountsCre.Checked = ds.Tables(0).Rows(0).Item("AccountsCreation").ToString
                chkLandingBorrowing.Checked = ds.Tables(0).Rows(0).Item("LendingandBorrowing").ToString
                chkEnquiriesDetails.Checked = ds.Tables(0).Rows(0).Item("DetailsEnquiries").ToString
                ChkMandates.Checked = ds.Tables(0).Rows(0).Item("AccountsMandates").ToString
                chkSystemAccPerm.Checked = ds.Tables(0).Rows(0).Item("SystemUsersPerm").ToString
                chkNewAccountsAuth.Checked = ds.Tables(0).Rows(0).Item("NewAccountsAuthorizations").ToString
                chkAccountsLockAuth.Checked = ds.Tables(0).Rows(0).Item("AccountslockingAuth").ToString
                chkAccsMandateAuth.Checked = ds.Tables(0).Rows(0).Item("AccountsMandatesAuth").ToString
                chkLandingBorowAuth.Checked = ds.Tables(0).Rows(0).Item("LendingAndBorrowingAuth").ToString
                chkSystemParaAuth.Checked = ds.Tables(0).Rows(0).Item("ParameterSettingAuth").ToString
                chkSystemAccCreAuth.Checked = ds.Tables(0).Rows(0).Item("SystemUsersCreationAuth").ToString
                chkAccsPermAuth.Checked = ds.Tables(0).Rows(0).Item("SystemUsersPermAuth").ToString
                chkReports.Checked = ds.Tables(0).Rows(0).Item("Report").ToString
                chkEventsCalender.Checked = ds.Tables(0).Rows(0).Item("EventsDairy").ToString
                Exit Sub
            Else

                chkAccountsCre.Checked = False
                chkAccountsLockUn.Checked = False
                chkAccountsUpdate.Checked = False
                chkAccountsUpdatesAuth.Checked = False
                chkBatchCreations.Checked = False
                chkBatchesAuthorizations.Checked = False
                chkEventsCalender.Checked = False
                chkFilesExport.Checked = False
                ChkFilesImport.Checked = False
                chkNewAccountsAuth.Checked = False
                chkOrdersAuth.Checked = False
                chkOrdersPosting.Checked = False
                chkParaset.Checked = False
                ChkPledgeAuth.Checked = False
                ChkPledgeCreUp.Checked = False
                ChkPledgeCreUp.Checked = False
                chkPortfolioEnq.Checked = False
                chkReports.Checked = False
                chkSystemAccounts.Checked = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getNewAccounts()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Username) from SystemUsers where password='password' and activation=0 and AuthorizePerm=1 and AllocatePermLevel=1", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbusers.DataSource = ds.Tables(0)
                cmbusers.DataValueField = "Username"
                cmbusers.DataBind()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedAccountsDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from SystemUsers where Username='" & cmbusers.Text & "' and password='password' and activation=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "systemUsers")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtUsernameSearch.Text = ds.Tables(0).Rows(0).Item("Username").ToString
                txtUsername.Text = ds.Tables(0).Rows(0).Item("Username").ToString
                txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                txtForenames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
                txtMobile1.Text = ds.Tables(0).Rows(0).Item("mobile1").ToString
                txtMobile2.Text = ds.Tables(0).Rows(0).Item("mobile2").ToString
                txtTelephone.Text = ds.Tables(0).Rows(0).Item("tel").ToString
                txtOrganization.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                txtRole.Text = ds.Tables(0).Rows(0).Item("AccountType").ToString
                txtDepartment.Text = ds.Tables(0).Rows(0).Item("Department").ToString

                getPermissions()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

   

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            cmd = New SqlCommand("update systemUsers set ActivationStat = 3 where username='" & txtUsername.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account authorized")
            getNewAccounts()
            GetSelectedAccountsDetails()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Unnamed16_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        cmd = New SqlCommand("update systemUsers set Activation = 1 , ActivationStat = 1 where username='" & txtUsername.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Authorized a user account','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        msgbox("Account authorized")
        getNewAccounts()
        GetSelectedAccountsDetails()
    End Sub
End Class
