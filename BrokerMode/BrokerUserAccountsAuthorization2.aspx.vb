Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerUserAccountsAuthorization
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed User Accounts Authorization Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
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
    Public Sub getNewAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Username) from SystemUsers where password='password' and activation=0 and companyCode='" & Session("BrokerCode") & "'", cn)
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
                txtTelephone.Text = ds.Tables(0).Rows(0).Item("telephone").ToString
                txtOrganization.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                txtRole.Text = ds.Tables(0).Rows(0).Item("UserRole").ToString
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

            cmd = New SqlCommand("insert i'nto UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Rejected a system user account change','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
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
        cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Authorized system user account','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
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
