Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_SecuritiesBorrowingValuation
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
            Dim clientno As String = Request.QueryString("clientnumber")
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from names where cds_number = '" & clientno & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientCode.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtClientName.Text = ds.Tables(0).Rows(0).Item("surname").ToString & " " & ds.Tables(0).Rows(0).Item("forenames").ToString
                txtClientCode.ReadOnly = True
                txtClientName.ReadOnly = True
                GetSavedAssets()
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
            'GetcapturedBorrowers()
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
            GetBorrowersSearch()
            'Dim ds As New DataSet
            'cmd = New SqlCommand("select surname+' '+forenames+' '+cds_number as names from names where surname like '" & txtNameSearch.Text & "%'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "names")
            'If (ds.Tables(0).Rows.Count > 0) Then
            '    lstNamesSearch.DataSource = ds.Tables(0)
            '    lstNamesSearch.DataValueField = "names"
            '    lstNamesSearch.DataBind()
            'Else
            '    lstNamesSearch.Items.Clear()

            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBorrowersSearch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select client_name+' '+client_number as namess from borrowers_reg where client_name like '" & txtNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "borrowers_reg")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.DataValueField = "namess"
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
            GetSavedAssets()
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

    Public Sub ClearData()
        Try
            txtClientCode.Text = ""
            txtClientName.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnAdditions_Click(sender As Object, e As EventArgs) Handles btnAdditions.Click
        Try
            If (txtClientCode.Text = "") Then

                msgbox("Select a valid borrowers accounts")
                Exit Sub
            End If
            If (rdAssets.Checked = False And rdLiabilities.Checked = False) Then
                msgbox("select balance sheet item type")
                Exit Sub
            End If

            Dim AssetType As String = ""
            If (rdAssets.Checked = True) Then
                AssetType = "Asset"
            End If
            If (rdLiabilities.Checked = True) Then
                AssetType = "Liability"
            End If
            If (txtValue.Text = "") Then
                If (Not IsNumeric(txtValue.Text)) Then
                    msgbox("Enter a valid value")
                End If
                msgbox("enter value")
                Exit Sub
            End If
            Dim Itemvalue As Double = 0.0
            If (rdAssets.Checked = True) Then
                Itemvalue = CDbl(txtValue.Text)
            End If
            If (rdLiabilities.Checked = True) Then
                Itemvalue = CDbl(txtValue.Text * -1)
            End If

            cmd = New SqlCommand("insert into borrowers_valuation (client_number,BalanceSheetItems,Class,DateCreated,Value,Capturedby) values ('" & txtClientCode.Text & "','" & txtAssetName.Text & "','" & AssetType & "','" & Now.Date & "'," & CDbl(Itemvalue) & ",'" & Session("username") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("update borrowers_reg set status = 1 where client_number='" & txtClientCode.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            GetSavedAssets()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSavedAssets()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select BalanceSheetItems, Class, Value from borrowers_valuation where client_number ='" & txtClientCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "borrowers_valuation")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdBorrowingValuation.DataSource = ds.Tables(0)
                grdBorrowingValuation.DataBind()
            Else
                grdBorrowingValuation.DataSource = Nothing
                grdBorrowingValuation.DataBind()
            End If

            Dim ValuationCost As Double = 0.0
            Dim dsi As New DataSet

            cmd = New SqlCommand("select sum(value) as valuess from borrowers_valuation where client_number='" & txtClientCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "borrowers_valuation")
            If (dsi.Tables(0).Rows.Count > 0) Then
                txtNetValue.Text = dsi.Tables(0).Rows(0).Item("valuess").ToString
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdOther_CheckedChanged(sender As Object, e As EventArgs) Handles rdOther.CheckedChanged
        Try
            If (rdOther.Checked = True) Then
                txtOther.Visible = True
                txtOther.Text = ""
                Fileupload1.Visible = True
                btnUpload.Visible = True
                btnCam.Visible = True
                btnScan.Visible = True
            Else
                txtOther.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdIdentity_CheckedChanged(sender As Object, e As EventArgs) Handles rdIdentity.CheckedChanged
        Try
            If (rdIdentity.Checked = True) Then
                txtOther.Visible = False
                Fileupload1.Visible = True
                btnUpload.Visible = True
                btnCam.Visible = True
                btnScan.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdApplicationForm_CheckedChanged(sender As Object, e As EventArgs) Handles rdApplicationForm.CheckedChanged
        Try
            If (rdApplicationForm.Checked = True) Then
                txtOther.Visible = False
                Fileupload1.Visible = True
                btnUpload.Visible = True
                btnCam.Visible = True
                btnScan.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Response.Redirect("~\brokermode\SecuritiesLendingAndBorrowing.aspx")
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        If (txtClientCode.Text <> "") Then
            Response.Redirect("~\brokermode\BorrowingRequestForm.aspx?clientnumber=" & txtClientCode.Text & "")
        Else
            msgbox("Select a valid Account")
            ' Response.Redirect("~\brokermode\BorrowingRequestForm.aspx")
        End If

    End Sub
End Class
