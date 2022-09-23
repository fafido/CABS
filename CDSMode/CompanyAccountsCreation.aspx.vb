Imports System.Data
Imports System.Data.SqlClient
Partial Class CompanyAccountsCreation
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
                cmbCompanyType.DataSource = ds.Tables(0)
                cmbCompanyType.DataValueField = "company"
                cmbCompanyType.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            'GetCompany()
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

    Protected Sub txtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompany.TextChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (username) from systemUsers where username='" & txtCompany.Text & "'", cn)
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


    Protected Sub txtCompanyCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompanyCode.TextChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Company_code) from CompanyAccounts where company_code='" & txtCompanyCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "companyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblPasswordValidation.Text = "Selected Company Code Already Exists"
                lblPasswordValidation.forecolor = Drawing.Color.Red
                btnSave.Enabled = False
            Else
                lblPasswordValidation.Text = ""
                btnSave.Enabled = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdNewAcc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdNewAcc.CheckedChanged
        Try
            If (rdNewAcc.Checked = True) Then
                cmbCompanies.Visible = False
                txtCompany.Text = ""
                txtCompanyCode.Text = ""
                'cmbCompanyType.SelectedValue = "CDS"
                rdActive.Checked = False
                rdInactive.Checked = False
                lblCompanyCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from companyAccounts where company='" & cmbCompanies.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CompanyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtCompany.Text = ds.Tables(0).Rows(0).Item("Company").ToString
                txtCompanyCode.Text = ds.Tables(0).Rows(0).Item("CompanyType").ToString
                cmbCompanyType.SelectedItem.Text = ds.Tables(0).Rows(0).Item("CompanyType").ToString
                lblCompanyCode.Text = ds.Tables(0).Rows(0).Item("Company_code").ToString
                If (ds.Tables(0).Rows(0).Item("Activation").ToString = False) Then
                    rdInactive.Checked = True
                    rdActive.Checked = False
                Else
                    rdActive.Checked = True
                    rdInactive.Checked = False
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompanies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company) from companyAccounts order by company asc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "companyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompanies.DataSource = ds.Tables(0)
                cmbCompanies.DataValueField = "company"
                cmbCompanies.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdNewAcc0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdNewAcc0.CheckedChanged
        Try
            If (rdNewAcc0.Checked = True) Then
                getCompanies()
                GetSelectedCompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Unnamed17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim ActivationCnt As Integer = 0
            If (rdActive.Checked = True) Then
                ActivationCnt = 1
            End If
            If (rdInactive.Checked = True) Then
                ActivationCnt = 0
            End If
            If (rdNewAcc.Checked = True) Then
                If (lblPasswordValidation.Text = "") Then
                    cmd = New SqlCommand("insert into companyAccounts (company,CompanyType,Activation,Company_Code) values ('" & txtCompany.Text & "','" & cmbCompanyType.Text & "'," & ActivationCnt & ",'" & txtCompanyCode.Text & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    msgbox("New Company Created")
                    cmbCompanies.Visible = False
                    txtCompany.Text = ""
                    txtCompanyCode.Text = ""
                    cmbCompanyType.SelectedValue = "CDS"
                    rdActive.Checked = False
                    rdInactive.Checked = False
                Else
                    msgbox("Enter a unique company code")
                    Exit Sub
                End If
            End If

            If (rdNewAcc0.Checked = True) Then
                If (lblPasswordValidation.Text = "") Then

                    cmd = New SqlCommand("Update companyAccounts set company='" & txtCompany.Text & "', companyType='" & cmbCompanyType.Text & "',activation=" & ActivationCnt & ",company_code='" & txtCompanyCode.Text & "' where company_Code='" & lblCompanyCode.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    msgbox("Record Updated")
                    cmbCompanies.Visible = False
                    txtCompany.Text = ""
                    txtCompanyCode.Text = ""
                    'cmbCompanyType.SelectedValue = "CDS"
                    rdActive.Checked = False
                    rdInactive.Checked = False
                    lblCompanyCode.Text = ""
                    getCompanies()
                    GetSelectedCompany()
                Else
                    msgbox("Enter a unique company code")
                    Exit Sub
                End If
            End If
            
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompanies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompanies.SelectedIndexChanged
        Try
            GetSelectedCompany()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
