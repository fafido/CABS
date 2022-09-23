Imports System.Data
Imports System.Data.SqlClient
Partial Class Pledges_LendingAndBorrowing
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub txtHolderNoSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHolderNoSearch.TextChanged
        Try
            If (txtHolderNoSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from NAMES where cds_number='" & txtHolderNoSearch.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblSelectedName.Text = ds.Tables(0).Rows(0).Item("Surname").ToString.ToUpper & " " & ds.Tables(0).Rows(0).Item("Forenames").ToString.ToUpper
                    lblSelectedName.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString & ", " & ds.Tables(0).Rows(0).Item("Add_2").ToString & ", " & ds.Tables(0).Rows(0).Item("Add_3").ToString & ", " & ds.Tables(0).Rows(0).Item("Add_4").ToString & ", " & ds.Tables(0).Rows(0).Item("city").ToString & ", " & ds.Tables(0).Rows(0).Item("Country").ToString
                Else
                    lblSelectedAddress.Text = ""
                    lblSelectedName.Text = ""
                End If
            Else
                lblSelectedAddress.Text = ""
                lblSelectedName.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtHolderNameSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHolderNameSearch.TextChanged
        Try '

            If (txtHolderNameSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select forenames+' '+surname+' '+cds_number as namess from names where surname like '" & txtHolderNameSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNameSearch.DataSource = ds.Tables(0)
                    lstNameSearch.DataValueField = "namess"
                    lstNameSearch.DataBind()

                End If
            Else

                lstNameSearch.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNameSearch.SelectedIndexChanged
        Try
            If (lstNameSearch.SelectedItem.Text <> "") Then

                Dim ds As New DataSet '

                cmd = New SqlCommand("select * from names where forenames+' '+surname+' '+cds_number= '" & lstNameSearch.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then

                    GetSelectedAccountDetails(ds.Tables(0).Rows(0).Item("cds_number").ToString)

                    GetCompanies(ds.Tables(0).Rows(0).Item("cds_number").ToString)
                Else
                    lblSelectedAccNo.Text = ""
                    lblSelectedAddress.Text = ""
                    lblSelectedName.Text = ""
                    LstCompanies.Items.Clear()
                    lblBorrowedOutstanding.Text = ""
                    lblBorrowedShares.Text = ""
                    lblHoldingShares.Text = ""
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedAccountDetails(ByVal Shareholder As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from names where cds_number='" & Shareholder & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblSelectedName.Text = ds.Tables(0).Rows(0).Item("Surname").ToString & " " & ds.Tables(0).Rows(0).Item("Forenames").ToString
                lblSelectedAddress.Text = ds.Tables(0).Rows(0).Item("add_1").ToString & " " & ds.Tables(0).Rows(0).Item("add_2").ToString & " " & ds.Tables(0).Rows(0).Item("add_3").ToString & " " & ds.Tables(0).Rows(0).Item("add_4").ToString
                lblSelectedAccNo.Text = ds.Tables(0).Rows(0).Item("cds_number")
            Else
                lblSelectedAddress.Text = ""
                lblSelectedName.Text = ""
                lblSelectedAccNo.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCompanies(ByVal Shareholder As String)
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) as company from trans where cds_number='" & Shareholder & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then
                'msgbox("Getting Company")
                LstCompanies.DataSource = ds.Tables(0)
                LstCompanies.DataValueField = "company"
                LstCompanies.DataBind()
            Else
                msgbox("Shareholder not found")
                lstNameSearch.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub LstCompanies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCompanies.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from names where forenames+' '+surname+' '+cds_number ='" & lstNameSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                GettingCompanyBalances(ds.Tables(0).Rows(0).Item("cds_number").ToString)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GettingCompanyBalances(ByVal Shareholder As String)
        Try
            Dim ds As New DataSet
            Dim Transshares As Int32 = 0
            Dim Pledgeshares As Int32 = 0
            Dim Borrowedshares As Int32 = 0

            cmd = New SqlCommand("select sum(shares) as shares from trans where company = '" & LstCompanies.SelectedItem.Text & "' and cds_number='" & Shareholder & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then
                Transshares = ds.Tables(0).Rows(0).Item("shares").ToString
                lblHoldingShares.Text = FormatNumber(Transshares, 0)

            End If
            Dim ros As New DataSet
            cmd = New SqlCommand("select * from Pledges_Trans where company='" & LstCompanies.SelectedItem.Text & "' and cds_number='" & Shareholder & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ros, "Pledges_Trans")
            If (ros.Tables(0).Rows.Count > 0) Then
                Dim dsi As New DataSet
                cmd = New SqlCommand("select sum(shares) as shares, case transtype when 'B' then 'Borrowing' when 'P' then 'Pledging' when 'L' then 'Lending' else 'Other' end as TransType from Pledges_Trans  where company='" & LstCompanies.SelectedItem.Text & "' and cds_number='" & Shareholder & "' group by TransType", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsi, "Pledges_Trans")

                If (dsi.Tables(0).Rows(0).Item("TransType").ToString = "B") Then
                    Label5.Text = "Borrowed Shares"
                    Borrowedshares = dsi.Tables(0).Rows(0).Item("shares").ToString
                    lblBorrowedShares.Text = FormatNumber(Borrowedshares)

                    lblHoldingShares.Text = Transshares - Borrowedshares

                End If

                If (dsi.Tables(0).Rows(0).Item("TransType").ToString = "P") Then
                    Label5.Text = "Pledged Shares"
                    Borrowedshares = dsi.Tables(0).Rows(0).Item("shares").ToString
                    lblBorrowedShares.Text = FormatNumber(Borrowedshares)

                    lblHoldingShares.Text = Transshares - Borrowedshares

                End If

                If (dsi.Tables(0).Rows(0).Item("TransType").ToString = "L") Then
                    Label5.Text = "Lent Shares"
                    Borrowedshares = dsi.Tables(0).Rows(0).Item("shares").ToString
                    lblBorrowedShares.Text = FormatNumber(Borrowedshares)

                    lblHoldingShares.Text = Transshares - Borrowedshares

                End If

            Else

            End If
            
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdReturnBorrow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdReturnBorrow.CheckedChanged
        Try
            If (rdReturnBorrow.Checked = True) Then
                BasicDatePicker1.SelectedDate = Now.Date
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdBorrow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdBorrow.CheckedChanged
        Try
            If (rdBorrow.Checked = True) Then
                BasicDatePicker1.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdLend_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdLend.CheckedChanged
        Try
            If (rdLend.Checked = True) Then
                BasicDatePicker1.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (rdLend.Checked = True) Then
                Dim balanceShares As Int32 = 0
                msgbox(CInt(Replace(lblHoldingShares.Text, ",", "")))

                'Validation 
                If (CInt(txtShares.Text > CInt(Replace(lblHoldingShares.Text, ",", "")))) Then
                    msgbox("An account can not lend more units than the units held")
                    Exit Sub
                Else
                    balanceShares = (CInt(Replace(lblHoldingShares.Text, ",", "") - CInt(txtShares.Text)))
                    cmd = New SqlCommand("insert into trans ")
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
