Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSMode_ClientCompanies
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
            GetClientCompanyTypes()
        End If
    End Sub
    Public Sub GetClientCompanyTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_type) from para_clientCompanyTypes", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_clientCompanyTypes")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompanyTypes.DataSource = ds.Tables(0)
                cmbCompanyTypes.DataValueField = "company_type"
                cmbCompanyTypes.DataBind()
            Else
                cmbCompanyTypes.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            GetClientCompanyTypes()
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
    Public Sub GetSelectedData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from client_companies where company_name+' '+company_code='" & lstNameSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblCode.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
                txtCompanyName.Text = ds.Tables(0).Rows(0).Item("company_name").ToString
                txtCompanyCode.Text = ds.Tables(0).Rows(0).Item("company_code").ToString
                Dim i As Integer = 0
                For i = 0 To cmbCompanyTypes.Items.Count - 1
                    If (ds.Tables(0).Rows(0).Item("company_type").ToString = cmbCompanyTypes.Items(i).ToString) Then
                        cmbCompanyTypes.SelectedItem.Text = ds.Tables(0).Rows(0).Item("company_type").ToString
                    End If
                Next
                txtCompanyAddress.Text = ds.Tables(0).Rows(0).Item("Adress_1").ToString
                txtCompanyEmail.Text = ds.Tables(0).Rows(0).Item("contact_email").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("contact_phone").ToString
                'txtmobile.Text = ds.Tables(0).Rows(0).Item("").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        Try
            If (lstNameSearch.SelectedItem.Text <> "") Then
                GetSelectedData()
            Else
                lblCode.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If (lblCode.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from client_companies where company_code='" & lblCode.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "client_companies")
                If (ds.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("update client_companies set company_name='" & txtCompanyName.Text.ToString.ToUpper & "', company_code='" & txtCompanyCode.Text.ToString.ToUpper & "',company_type='" & cmbCompanyTypes.SelectedItem.ToString & "', adress_1='" & txtCompanyAddress.Text.ToString.ToUpper & "', contact_email='" & txtCompanyEmail.Text & "', contact_phone='" & txtTel.Text & "' where company_code='" & lblCode.Text & "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Else
                    cmd = New SqlCommand("insert into client_companies (Company_name,Company_Code,Company_type,Adress_1,contact_email,contact_phone,status) values ('" & txtCompanyName.Text & "','" & txtCompanyCode.Text & "','" & cmbCompanyTypes.SelectedItem.Text & "','" & txtCompanyAddress.Text.ToString.ToUpper & "','" & txtCompanyEmail.Text.ToString.ToLower & "','" & txtTel.Text & "',1)", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If

            Else
                msgbox("select a company to update")

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
