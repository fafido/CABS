Partial Class Enquiries_NameEnquiry
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            If (txtshareholder.Text = "") Then
                msgbox("Enter a valid Shareholder Number")
                Exit Sub
            End If

            getHolder()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolder()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from names where CDS_Number='" & txtshareholder.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtSurname.Text = (ds.Tables(0).Rows(0).Item("Surname").ToString) + " " + (ds.Tables(0).Rows(0).Item("Forenames").ToString)
                txtID.Text = (ds.Tables(0).Rows(0).Item("Idpp").ToString)
                txtAdd1.Text = (ds.Tables(0).Rows(0).Item("Add_1")) + " ," + (ds.Tables(0).Rows(0).Item("Add_2").ToString) + ", " + (ds.Tables(0).Rows(0).Item("Add_3").ToString) + ", " + (ds.Tables(0).Rows(0).Item("Add_4").ToString) + " ," + (ds.Tables(0).Rows(0).Item("city").ToString) + " ," + (ds.Tables(0).Rows(0).Item("country").ToString)
                txtEmail.Text = "Email: " + (ds.Tables(0).Rows(0).Item("email").ToString) + "| Fax: " + (ds.Tables(0).Rows(0).Item("Fax").ToString) + "| Cell: " + (ds.Tables(0).Rows(0).Item("Cellphone").ToString)
                txtBank.Text = ds.Tables(0).Rows(0).Item("Bank_Name").ToString '& " " & ds.Tables(0).Rows(0).Item("bank_code").ToString
                txtBranch.Text = ds.Tables(0).Rows(0).Item("Branch_name").ToString '& " " & ds.Tables(0).Rows(0).Item("branch_code").ToString
                txtBnkAccount.Text = ds.Tables(0).Rows(0).Item("Account").ToString
            Else
                MsgBox("Invalid Shareholder Number")
                txtshareholder.Text = ""
                txtshareholder.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            If (txtSearch.Text = "") Then
                MsgBox("Enter a valid search name")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("Select surname+' '+forenames+' '+cds_number as namess  from names where surname like '" & txtSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNames.DataSource = ds.Tables("names")
                lstNames.DataValueField = "namess"
                lstNames.DataBind()
            Else
                lstNames.DataSource = Nothing
                lstNames.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ds As New DataSet
            txtshareholder.Text = ""
            If (lstNames.SelectedItem.Text <> "") Then
                cmd = New SqlCommand("Select cds_number from names where surname+' '+forenames+' '+cds_number= '" & lstNames.SelectedItem.ToString & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtshareholder.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    getHolder()
                Else
                    msgbox("account not found")
                End If
            Else
                msgbox("no value selected")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If (txtshareholder.Text <= "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('NameStatementReportView.aspx?shareholder=" & txtshareholder.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
