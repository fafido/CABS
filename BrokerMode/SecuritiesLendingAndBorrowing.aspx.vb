Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_SecuritiesLendingAndBorrowing
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
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            'Label4.Text = "Logged on as " & Session("UserName").ToString & " of " & Session("UserCompany")
            Dim HourofDay As Integer = 0
            HourofDay = TimeOfDay.Hour
            If (HourofDay < 12) Then
                Label4.Text = "Good Morning " & Session("Username").ToString
            ElseIf (HourofDay >= 12 And HourofDay <= 17) Then
                Label4.Text = "Good Afternoon " & Session("Username").ToString
            Else
                Label4.Text = "Good Evening " & Session("username").ToString
            End If
            GetClientType()
            'GetCompany()
            GetcapturedBorrowers()
        End If
    End Sub
    'Public Sub GetCompany()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select distinct (company) from para_company", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "para_company")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            cmbCompany.DataSource = ds.Tables(0)
    '            cmbCompany.ValueField = "company"
    '            cmbCompany.DataBind()



    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select surname+' '+forenames+' '+cds_number as names from names where surname like '" & txtNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.DataValueField = "names"
                lstNamesSearch.DataBind()
            Else
                lstNamesSearch.Items.Clear()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged
        Try
            GetSelectedAccount()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedAccount()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from names where surname+' '+forenames+' '+cds_number ='" & lstNamesSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientCode.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtClientCode.ReadOnly = True
                txtAddress.Text = ds.Tables(0).Rows(0).Item("add_1").ToString & vbCr & ds.Tables(0).Rows(0).Item("city").ToString & vbCr & ds.Tables(0).Rows(0).Item("country").ToString
                txtAddress.ReadOnly = True
                txtBank.Text = ds.Tables(0).Rows(0).Item("bank_name").ToString
                txtBank.ReadOnly = True
                txtBranch.Text = ds.Tables(0).Rows(0).Item("branch_name")
                txtBranch.ReadOnly = True
                If (ds.Tables(0).Rows(0).Item("holder_type").ToString = "1") Then
                    cmbClientType.SelectedItem.Text = "INDIVIDUAL"
                End If
                If (ds.Tables(0).Rows(0).Item("holder_type").ToString = "2") Then
                    cmbClientType.SelectedItem.Text = "JOINT"
                End If
                If (ds.Tables(0).Rows(0).Item("holder_type").ToString = "3") Then
                    cmbClientType.SelectedItem.Text = "NOMINEE"
                End If
                If (ds.Tables(0).Rows(0).Item("holder_type").ToString = "4") Then
                    cmbClientType.SelectedItem.Text = "COMPANY"
                End If
                txtClientName.Text = ds.Tables(0).Rows(0).Item("surname").ToString & " " & ds.Tables(0).Rows(0).Item("forenames").ToString
                cmbClientType.Enabled = False
                txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Account").ToString
                txtAccountNo.ReadOnly = True
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetClientType()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT	distinct (case holder_type when '1' then 'INDIVIDUAL' WHEN '2' THEN 'JOINT' WHEN '3' THEN 'NOMINEE' WHEN '4' THEN 'COMPANY' END ) as clientType from names", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbClientType.DataSource = ds.Tables(0)
                cmbClientType.DataValueField = "clienttype"
                cmbClientType.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try
            Dim rex As New DataSet
            cmd = New SqlCommand("select distinct (client_number) from borrowers_reg where client_number='" & txtClientCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(rex, "borrowers_reg")
            If (rex.Tables(0).Rows.Count > 0) Then
                msgbox("client already exists in the borrowers register")
                Exit Sub
            End If
            If (txtClientCode.Text <> "") Then
                'cmd = New SqlCommand("insert into borrowers_reg (client_type,client_name,client_number,company,securities,unit_price,datecreated,capturedby,status) values ('" & cmbClientType.SelectedItem.Text & "','" & txtClientName.Text & "','" & txtClientCode.Text & "','" & cmbCompan.SelectedItem.Text & "','" & cmbSecurities.SelectedItem.Text & "'," & txtUnitPrice.Text & ",'" & Now.Date & "','" & Session("username") & "',0)", cn)
                cmd = New SqlCommand("insert into borrowers_reg (client_type,client_name,client_number,datecreated,capturedby,status) values ('" & cmbClientType.SelectedItem.Text & "','" & txtClientName.Text & "','" & txtClientCode.Text & "','" & Now.Date & "','" & Session("username") & "',0)", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                ClearData()
                GetcapturedBorrowers()
            Else
                msgbox("select a client code")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientCode.Text = ""
            txtClientName.Text = ""
            txtAddress.Text = ""
            txtBank.Text = ""
            txtBranch.Text = ""
            txtAccountNo.Text = ""

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetcapturedBorrowers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select client_type as [Type], client_name as [Name],client_number as [CDS Number],datecreated as [Date Created] from borrowers_reg where status = 0 ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "borrowers_reg")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdBorrowers.DataSource = ds.Tables(0)
                grdBorrowers.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            If (txtClientCode.Text <> "") Then
                Response.Redirect("~\brokermode\securitiesborrowingvaluation.aspx?clientnumber=" & txtClientCode.Text & "")
            Else
                msgbox("Select a valid account to proceed")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
