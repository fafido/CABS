Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSMode_AdminUserAccounts
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")
            GetClientCompany()
            If (cmbCompany.Items.Count > 0) Then
                GetCompanyDetails()
            End If
        End If
    End Sub
    Public Sub GetCompanyDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from client_companies where company_name='" & cmbCompany.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtCompanyCode.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
                lblCompanyType.Text = ds.Tables(0).Rows(0).Item("company_type").ToString
            Else
                txtCompanyCode.Text = ""
                lblCompanyType.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        Try
            If (txtNameSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select company_name+' '+company_code as namess from client_companies where company_name like '" & txtNameSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "client_companies")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCode.Text = ""
                    lstNameSearch.DataSource = ds.Tables(0)
                    lstNameSearch.DataValueField = "namess"
                    lstNameSearch.DataBind()
                Else
                    lstNameSearch.Items.Clear()
                    lblCode.Text = ""
                End If
            Else
                lstNameSearch.Items.Clear()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetClientCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_name), company_code,company_type from client_companies", cn)
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
    Protected Sub btnCodeSearch_Click(sender As Object, e As EventArgs) Handles btnCodeSearch.Click
        Try
            If (txtcodeSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select company_name+' '+company_code as namess from client_companies where company_code like '" & txtcodeSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "client_companies")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCode.Text = ""
                    lstNameSearch.DataSource = ds.Tables(0)
                    lstNameSearch.DataValueField = "namess"
                    lstNameSearch.DataBind()
                Else
                    lblCode.Text = ""
                    lstNameSearch.Items.Clear()
                End If
            Else
                lstNameSearch.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        Try
            If (lstNameSearch.SelectedItem.Text <> "") Then

            Else
                lblCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        GetCompanyDetails()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim status As Integer = 0
            If (rdActive.Checked = True) Then
                status = 1
            End If
            If (rdInActive.Checked = True) Then
                status = 0
            End If
            If (lblUsername.Text <> "") Then
                cmd = New SqlCommand("update SYSTEMUSERS set username='" & txtUsername.Text & "', company='" & cmbCompany.SelectedItem.Text & "', companyCode='" & txtCompanyCode.Text & "',companyType='" & lblCompanyType.Text & "', department='" & cmbDepartment.SelectedItem.Text & "'")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveUser()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
