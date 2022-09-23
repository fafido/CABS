Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_BorrowingATS
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
            Dim clientnumber As String = ""
            GetClientType()
            clientnumber = Request.QueryString("clientnumber")
            If (clientnumber.Length > 0) Then
                txtClientCode.Text = clientnumber

                Dim ds As New DataSet
                cmd = New SqlCommand("select * from names where cds_number ='" & txtClientCode.Text & "'", cn)
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
                Dim rs As New DataSet
                cmd = New SqlCommand("select * from borrowers_valuation where client_number='" & txtClientCode.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(rs, "borrowers_valuation")
                If (rs.Tables(0).Rows.Count > 0) Then
                    cmd = New SqlCommand("select sum(value) as value from borrowers_valuation where client_number='" & txtClientCode.Text & "'", cn)
                    Dim ri As New DataSet
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ri, "borrowers_valuation")
                    txtNetValue.Text = ri.Tables(0).Rows(0).Item("value").ToString
                Else
                    txtNetValue.Text = 0.0
                End If


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

            'GetCompany()
            'GetcapturedBorrowers()
        End If
    End Sub
    Public Sub GetSharePrice()
        Try
            If (cmbCompany.Items.Count > 0) Then
                If (Len(cmbCompany.SelectedItem.Text) > 1) Then
                    Dim ds As New DataSet
                    cmd = New SqlCommand("select top 1 price from para_prices where counter='" & cmbCompany.SelectedItem.Text & "' order by pricedate desc", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "para_prices")
                    If (ds.Tables(0).Rows.Count > 0) Then
                        txtCurrentPrice.Text = ds.Tables(0).Rows(0).Item("price").ToString
                    Else
                        txtCurrentPrice.Text = 0.01
                    End If
                End If
            Else
                txtCurrentPrice.Text = 0.01
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

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



    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Response.Redirect("~\brokermode\securitiesborrowingvaluation.aspx")
    End Sub

    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        GetSharePrice()
        If (txtCreditAplied.Text <> "") Then
            If IsNumeric(txtCreditAplied.Text) Then
                txtPossibleUnits.Text = FormatNumber(CInt(CDbl(txtCreditAplied.Text) / CDbl(txtCurrentPrice.Text)), 0)
            End If
        End If
    End Sub

    Protected Sub cmbSecurityType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSecurityType.SelectedIndexChanged
        Try
            If (cmbSecurityType.SelectedItem.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from para_lendingRules where security='" & cmbSecurityType.SelectedItem.Text & "' order by DateCreated desc", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_lendingRules")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtreturnDate.Date = Now.Date.AddDays(ds.Tables(0).Rows(0).Item("LendingPeriod").ToString)
                    txtInterestRate.Text = ds.Tables(0).Rows(0).Item("InterestRate").ToString
                End If


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtCreditAplied_TextChanged(sender As Object, e As EventArgs) Handles txtCreditAplied.TextChanged
        Try
            CalculateRepayments()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub CalculateRepayments()
        Try
            Dim ds As New DataSet
            If (txtCreditAplied.Text <> "") Then
                txtPossibleUnits.Text = FormatNumber(CInt(CDbl(txtCreditAplied.Text) / CDbl(txtCurrentPrice.Text)), 0)
                Dim AmountRepayable As Double = 0.0
                AmountRepayable = CDbl(CDbl(txtCreditAplied.Text) * CDbl(txtInterestRate.Text) / 100)
                Dim totPayable As Double = 0.0
                txtRepaymentAmount.Text = FormatCurrency(CDbl(CDbl(txtCreditAplied.Text) + AmountRepayable), 2)
            Else
                txtPossibleUnits.Text = ""
                txtRepaymentAmount.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
