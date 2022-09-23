Imports System.IO
Imports System.Array
Imports DevExpress.Web.ASPxGridView

Partial Class CDSMode_issuersetup

    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim con As New SqlConnection(cnstr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Public Shared editID As String

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
        Try
            If (Not IsPostBack) Then
                loadCountry()
                loadIndexType()
                loadSecurityType()
                rdbType.SelectedValue = "New"
                searchInvisible()
                cmbCountryListed.SelectedIndex = 3
                getcompsec()
                loadcurrencies()
                getindustries()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveCompany_Click(sender As Object, e As EventArgs) Handles btnSaveCompany.Click
        'Try
        If rdbType.SelectedValue = "Update" Then
            cmd = New SqlCommand("update para_company set [Company]='" & removeSpecialCharacter(txtSecName.Text) & "',[Fnam]='" & removeSpecialCharacter(txtSecName.Text) & "',[Date_created]='" & dtYear.Text & "',[Issued_shares]='" & txtIssuedCapital.Text & "',[registrar]=(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),[Add_1]='" & removeSpecialCharacter(txtRegdOffice1.Text) & "',[Add_2]='" & removeSpecialCharacter(txtRegdOffice2.Text) & "',[Add_3]='" & removeSpecialCharacter(txtRegdOffice3.Text) & "',[Add_4]='" & removeSpecialCharacter(txtRegdOffice4.Text) & "',[City]='',[Country]='" & cmbCountryListed.SelectedItem.Value & "',[Contact_Person]='" & removeSpecialCharacter(txtcompsecretary.Text) & "',[Telephone]='" & txtPhoneNo.Text & "',[Cellphone]='',[Fax]='" & txtFaxNo.Text & "',[Comments]='',[sec_type]='" & cmbSecType.SelectedItem.Value & "',[board]='" & removeSpecialCharacter(txtBoard.Text) & "',[index_type]='" & cmbIndexType.SelectedItem.Value & "',[ticker]='" & removeSpecialCharacter(txtTicker.Text) & "',[ISIN]='" & txtISIN.Text & "',[year_listed]='" & dtYear.Text & "',[comp_secretary]='" & removeSpecialCharacter(txtcompsecretary.Text) & "',[email]='" & txtEmail.Text & "',[website]='" & txtWebsite.Text & "',[issued_capital]='" & txtIssuedCapital.Text & "',[nominal_value]='" & txtNominalValue.Text & "' where id='" & editID & "'", con)
            'msgbox(cmd.CommandText)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Company details saved")
                clearAll()
            Else
                msgbox("Error saving company details")
            End If
        Else
            Dim stmnt As String = "insert into para_ISSUER ([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value],[status],[issuer_code]) values (''" & removeSpecialCharacter(txtSecName.Text) & "'',''" & removeSpecialCharacter(txtSecName.Text) & "'',''" & dtYear.Text & "'',''0'',(select company_code from client_companies where company_name=''" & removeSpecialCharacter(txtcompsecretary.Text) & "''),''" & removeSpecialCharacter(txtRegdOffice1.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice2.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice3.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice4.Text) & "'','''',''" & cmbCountryListed.SelectedItem.Value & "'',''" & removeSpecialCharacter(txtcompsecretary.Text) & "'',''" & txtPhoneNo.Text & "'','''',''" & txtFaxNo.Text & "'','''','''',''" & removeSpecialCharacter(cmbIndexType.SelectedItem.Text) & "'',''0'',''" & removeSpecialCharacter(txtTicker.Text) & "'',''" & txtISIN.Text & "'',''" & dtYear.Text & "'',(select company_code from client_companies where company_name=''" & removeSpecialCharacter(txtcompsecretary.Text) & "''),''" & txtEmail.Text & "'',''" & txtWebsite.Text & "'',''0'',''0'',''0'',''" & txtissuercode.Text & "'')"
            Dim descr As String = "Added a new Instrument with the following details. Company=" + txtSecName.Text + "   Full Company Name=" + txtSecName.Text + " Registrar:" + txtcompsecretary.SelectedItem.Text + " Address:" + txtRegdOffice1.Text + " " + txtRegdOffice2.Text + " " + txtRegdOffice3.Text + " " + txtRegdOffice4.Text + " Country:" + cmbCountryListed.SelectedItem.Text + "  Board:" + txtBoard.Text + "   Ticker:" + txtTicker.Text + " ISIN" + txtISIN.Text + "  Year Listed " + dtYear.Text + ""
            cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Issuer')", con)
            'cmd = New SqlCommand("insert into para_company([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value], currency) values ('" & removeSpecialCharacter(txtSecName.Text) & "','" & removeSpecialCharacter(txtSecName.Text) & "','" & dtYear.Text & "','" & txtIssuedCapital.Text & "',(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),'" & removeSpecialCharacter(txtRegdOffice1.Text) & "','" & removeSpecialCharacter(txtRegdOffice2.Text) & "','" & removeSpecialCharacter(txtRegdOffice3.Text) & "','" & removeSpecialCharacter(txtRegdOffice4.Text) & "','','" & cmbCountryListed.SelectedItem.Value & "','" & removeSpecialCharacter(txtcompsecretary.Text) & "','" & txtPhoneNo.Text & "','','" & txtFaxNo.Text & "','','" & cmbSecType.SelectedItem.Value & "','" & removeSpecialCharacter(txtBoard.Text) & "','" & cmbIndexType.SelectedItem.Value & "','" & removeSpecialCharacter(txtTicker.Text) & "','" & txtISIN.Text & "','" & dtYear.Text & "',(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),'" & txtEmail.Text & "','" & txtWebsite.Text & "','" & txtIssuedCapital.Text & "','" & txtNominalValue.Text & "','" + cmbcurrency.SelectedItem.Text + "')", con)
            'msgbox(cmd.CommandText)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Sent for Approval")
                clearAll()
            Else
                msgbox("Error saving company details")
            End If
        End If
        'Catch ex As Exception
        '    msgbox("Please Provide all the required fields!")
        'Finally
        '    con.Close()
        'End Try
    End Sub

    Protected Sub loadSecurityType()
        Try
            cmd = New SqlCommand("select * from Sec_Types", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbSecType.DataSource = ds.Tables(0)
                cmbSecType.ValueField = "SecCode"
                cmbSecType.TextField = "SecName"
            Else
                cmbSecType.DataSource = Nothing
            End If
            cmbSecType.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub loadcurrencies()
        Try
            cmd = New SqlCommand("select * from para_currencies", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbcurrency.DataSource = ds.Tables(0)
                cmbcurrency.ValueField = "Currencycode"
                cmbcurrency.TextField = "Currencycode"
            Else
                cmbcurrency.DataSource = Nothing
            End If
            cmbcurrency.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadIndexType()
        Try
            cmd = New SqlCommand("select * from (select 2 as nr, 'Add New' as code, 'Add New' as fname union select 1 as nr,  code, fname from para_type) k order by k.nr", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbIndexType.DataSource = ds.Tables(0)
                cmbIndexType.ValueField = "code"
                cmbIndexType.TextField = "fname"
            Else
                cmbIndexType.DataSource = Nothing
            End If
            cmbIndexType.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub getcompsec()
        Try
            cmd = New SqlCommand("select * from para_Tsec", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                txtcompsecretary.DataSource = ds
                txtcompsecretary.ValueField = "code"
                txtcompsecretary.TextField = "name"
                txtcompsecretary.DataBind()

            Else
                cmbIndexType.DataSource = Nothing
            End If
            cmbIndexType.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadCountry()
        Try
            cmd = New SqlCommand("select * from para_country order by country", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "cntry")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCountryListed.DataSource = ds.Tables(0)
                cmbCountryListed.ValueField = "country"
                cmbCountryListed.TextField = "country"
            Else
                cmbCountryListed.DataSource = Nothing
            End If
            cmbCountryListed.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtBoard.Text = ""
            txtcompsecretary.Text = ""
            txtEmail.Text = ""
            txtFaxNo.Text = ""
            txtISIN.Text = ""
            txtIssuedCapital.Text = ""
            txtNominalValue.Text = ""
            txtPhoneNo.Text = ""
            txtRegdOffice1.Text = ""
            txtRegdOffice2.Text = ""
            txtRegdOffice3.Text = ""
            txtRegdOffice4.Text = ""
            txtSecName.Text = ""
            txtTicker.Text = ""
            txtWebsite.Text = ""
            dtYear.Text = ""
            cmbCountryListed.SelectedIndex = -1
            cmbIndexType.SelectedIndex = -1
            cmbSecType.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Protected Function removeSpecialCharacter(str As String) As String
        If str.Contains("'") Then
            str = str.Replace("'", "''")
        End If
        Return str
    End Function

    Protected Sub btnSearchSecName_Click(sender As Object, e As EventArgs) Handles btnSearchSecName.Click
        clearAll()
        cmd = New SqlCommand("select * from para_company where company='" & txtSearchSecName.Text & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            'fill text boxes
            txtBoard.Text = ds.Tables(0).Rows(0).Item("board").ToString
            txtcompsecretary.Text = ds.Tables(0).Rows(0).Item("Contact_Person").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtFaxNo.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
            txtISIN.Text = ds.Tables(0).Rows(0).Item("ISIN").ToString
            txtIssuedCapital.Text = ds.Tables(0).Rows(0).Item("issued_capital").ToString
            txtNominalValue.Text = ds.Tables(0).Rows(0).Item("nominal_value").ToString
            txtPhoneNo.Text = ds.Tables(0).Rows(0).Item("Telephone").ToString
            txtRegdOffice1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
            txtRegdOffice2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
            txtRegdOffice3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
            txtRegdOffice4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
            txtSecName.Text = ds.Tables(0).Rows(0).Item("Fnam").ToString
            txtTicker.Text = ds.Tables(0).Rows(0).Item("ticker").ToString
            txtWebsite.Text = ds.Tables(0).Rows(0).Item("website").ToString
            editID = ds.Tables(0).Rows(0).Item("id").ToString
            Try
                cmbCountryListed.SelectedItem = cmbCountryListed.Items.FindByValue(ds.Tables(0).Rows(0).Item("country").ToString)
            Catch ex As Exception
                cmbCountryListed.SelectedIndex = -1
            End Try
            Try
                cmbIndexType.SelectedItem = cmbIndexType.Items.FindByValue(ds.Tables(0).Rows(0).Item("index_type").ToString)
            Catch ex As Exception
                cmbIndexType.SelectedIndex = -1
            End Try
            Try
                cmbSecType.SelectedItem = cmbSecType.Items.FindByValue(ds.Tables(0).Rows(0).Item("sec_type").ToString)
            Catch ex As Exception
                cmbSecType.SelectedIndex = -1
            End Try
            Try
                dtYear.Date = ds.Tables(0).Rows(0).Item("Date_created").ToString
            Catch ex As Exception
                dtYear.Text = ""
            End Try
        Else
            msgbox("Company not found")
        End If
    End Sub

    Protected Sub rdbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbType.SelectedIndexChanged
        If rdbType.SelectedValue = "Update" Then
            searchVisible()
        Else
            searchInvisible()
            clearAll()
            txtSearchSecName.Text = ""
        End If
    End Sub

    Protected Sub searchVisible()
        txtSearchSecName.Visible = True
        lblSearchSecName.Visible = True
        btnSearchSecName.Visible = True
    End Sub

    Protected Sub searchInvisible()
        txtSearchSecName.Visible = False
        lblSearchSecName.Visible = False
        btnSearchSecName.Visible = False
    End Sub

    Protected Sub cmbSecType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSecType.SelectedIndexChanged

    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

    End Sub

    Protected Sub txtissuercode_TextChanged(sender As Object, e As EventArgs) Handles txtissuercode.TextChanged
        If Issuecodeexists(txtissuercode.Text) = "Available" Then
            txtissuercode.Text = ""
            txtissuercode.Focus()
            msgbox("Issuer Code already exists")
        Else

        End If
    End Sub
    Public Function Issuecodeexists(ByVal code As String) As String
        cmd = New SqlCommand("select * from para_issuer where issuer_code='" + code + "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return "Available"
        Else
            Return "Not Available"
        End If
    End Function
    Public Sub getindustries()
        cmd = New SqlCommand("select * from para_type ", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            grdactivecharges.DataSource = ds
            grdactivecharges.DataBind()

        End If
    End Sub
    Protected Sub cmbIndexType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIndexType.SelectedIndexChanged
        If cmbIndexType.SelectedItem.Text = "Add New" Then
            cmbIndexType.SelectedIndex = -1

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            Page.MaintainScrollPositionOnPostBack = True
        End If
    End Sub
    Protected Sub btnSaveCompany0_Click(sender As Object, e As EventArgs) Handles btnSaveCompany0.Click
        Try
            If txtindustryname.Text <> "" And txtindustrycode.Text <> "" Then


                cmd = New SqlCommand("insert into para_type (code, Fname) values ('" + txtindustrycode.Text + "','" + txtindustryname.Text + "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                getindustries()
                loadIndexType()

                txtindustrycode.Text = ""
                txtindustryname.Text = ""
                msgbox("successfully added")
            Else
                msgbox("Please enter Industry code and and Industry name!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdactivecharges_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdactivecharges.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE from para_type where code='" + id.ToString + "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            getindustries()
            loadIndexType()

            txtindustrycode.Text = ""
            txtindustryname.Text = ""
            msgbox("successfully deleted")

        End If
    End Sub
End Class
