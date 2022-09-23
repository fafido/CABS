Imports System.Data
Imports System.Data.SqlClient
Partial Class UserLoginTrail
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getCompany()
            getUsersAccs()
        End If
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company),Company_Code from CompanyAccounts where Company_Code in (select distinct (companyCode) from UserActivityLog)", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CompanyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUserId.DataSource = ds.Tables(0)
                cmbUserId.DataValueField = "company"
                cmbUserId.DataBind()

                lblCompanyCode.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getUsersAccs()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from UserActivityLog where companyCode='" & lblCompanyCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "UserActivityLog")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUsers.DataSource = ds.Tables(0)
                cmbUsers.DataValueField = "username"
                cmbUsers.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdDateSelect_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDateSelect.CheckedChanged
        Try
            If (rdDateSelect.Checked = True) Then
                Lblfrom.Visible = True
                txtDateto.Visible = True
                txtDatefrom.Visible = True
                lblTo.Visible = True
                cmbUsers.Visible = False


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdDateSelect0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDateSelect0.CheckedChanged
        Try
            If (rdDateSelect0.Checked = True) Then
                Lblfrom.Visible = False
                txtDateto.Visible = False
                txtDatefrom.Visible = False
                lblTo.Visible = False
                cmbUsers.Visible = True
                getUserAccs()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getUserAccs()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (userName) from UserActivityLog where CompanyCode='" & lblCompanyCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "UserActivityLog")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUsers.DataSource = ds.Tables(0)
                cmbUsers.DataValueField = "Username"
                cmbUsers.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getAccountsMainByDates()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select BrokerCode as [Broker Code], cds_number as [CDS Number], surname as [Surname], forenames as [Forenames], Update_On as [Updated on], case Approved when '0' then 'Pending Authorization' when '1' then 'Approved' when '3' then 'Update Rejected' end as [Approval Status], RecType from  Pre_Names_Creation where updated_by='" & cmbUserId.Text & "' and update_on >='" & txtDatefrom.Text & "' and update_on <='" & txtDateto.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblAccAction.Text = "Accounts Maintenance"
                grdAccountsM.DataSource = ds.Tables(0)
                grdAccountsM.DataBind()


            Else

                lblAccAction.Text = ""
                grdAccountsM.DataSource = Nothing
                grdAccountsM.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getAccountsMainByUser()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select BrokerCode as [Broker Code], cds_number as [CDS Number], surname as [Surname], forenames as [Forenames], Update_On as [Updated on], case Approved when '0' then 'Pending Authorization' when '1' then 'Approved' when '3' then 'Update Rejected' end as [Approval Status], RecType from  Pre_Names_Creation where updated_by='" & cmbUserId.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblAccAction.Text = "Accounts Maintenance"
                grdAccountsM.DataSource = ds.Tables(0)
                grdAccountsM.DataBind()
            Else

                lblAccAction.Text = ""
                grdAccountsM.DataSource = Nothing
                grdAccountsM.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getBatchesByDates()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select broker_batch_header.Batch_ref as [Batch Reference], broker_batch_header.company as [Company], Broker_Batch_Header.Batch_Type as [Batch Transaction] , Broker_Batch_Header.Shares as[Total Batch Shares] , Broker_Batch_Header .Created_on as [Batch Date] , case Broker_Batch_Header .Status when 'C' then 'Batch Pending Balancing' when 'B' then 'Batch Balanced' when 'F' then 'Batch forwarded for verification' when 'V' then 'Batch Verified' end as [Batch Status] from Broker_Batch_Header where Created_by='" & cmbUserId.Text & "' and Created_on >='" & txtDatefrom.Text & "' and Created_on <='" & txtDateto.Text & "' order by Batch_ref asc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Broker_Batch_Header")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblBatchesAction.Text = "Batches Created"
                grdBatches.DataSource = ds.Tables(0)
                grdBatches.DataBind()


            Else

                lblBatchesAction.Text = ""
                grdBatches.DataSource = Nothing
                grdBatches.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetUsers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from SystemUsers", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SystemUsers")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUserId.DataSource = ds.Tables(0)
                cmbUserId.DataValueField = "username"
                cmbUserId.DataBind()
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
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            If (rdDateSelect.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('LoginTrail.aspx?Company=" & lblCompanyCode.Text & "&Datefrom=" & txtDatefrom.Text & "&Dateto=" & txtDateto.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
            If (rdDateSelect0.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('LoginTrail2.aspx?Company=" & lblCompanyCode.Text & "&UserId=" & cmbUsers.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbUserId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUserId.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Company_Code) from companyAccounts where company='" & cmbUserId.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CompanyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblCompanyCode.Text = ds.Tables(0).Rows(0).Item("Company_Code").ToString
                getUserAccs()
            Else
                lblCompanyCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
