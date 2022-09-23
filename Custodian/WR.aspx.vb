Imports System.IO
Imports System.Array
Imports DevExpress.Web.ASPxGridView

Partial Class CDSMode_WR

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
                '   loadIndexType()
                ' loadSecurityType()

                rdbType.SelectedValue = "New"
                searchInvisible()
                cmbCountryListed.SelectedIndex = 3
                getcompsec()
                loadcomm()
                loadissuers()
                loadwarehouse()
                getall()

                searchVisible()
                getcurr()
                loadmeasurements()

            End If
            If Session("finish") = "True" Then
                Session("finish") = ""
                msgbox("Successfully Captured, Awaiting Approval")
            End If
            If Session("finish") = "delete" Then
                Session("finish") = ""
                msgbox("Successfully Deleted!")
            End If
            If Session("finish") = "update" Then
                Session("finish") = ""
                msgbox("Successfully Updated!")
            End If
            getall()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveCompany_Click(sender As Object, e As EventArgs) Handles btnSaveCompany.Click
        'Try
        If btnSaveCompany.Text = "Save" Then

            If rdbType.SelectedValue = "Save Equity" Then
                cmd = New SqlCommand("update para_company set [Company]='" & removeSpecialCharacter(txtSecName.Text) & "',[Fnam]='" & removeSpecialCharacter(txtSecName.Text) & "',[Date_created]='" & dtYear.Text & "',[Issued_shares]='0',[registrar]=(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),[Add_1]='" & removeSpecialCharacter(txtRegdOffice1.Text) & "',[Add_2]='" & removeSpecialCharacter(txtRegdOffice2.Text) & "',[Add_3]='" & removeSpecialCharacter(txtRegdOffice3.Text) & "',[Add_4]='" & removeSpecialCharacter(txtRegdOffice4.Text) & "',[City]='',[Country]='" & cmbCountryListed.SelectedItem.Value & "',[Contact_Person]='" & removeSpecialCharacter(txtcompsecretary.Text) & "',[Telephone]='" & txtPhoneNo.Text & "',[Cellphone]='',[Fax]='" & txtFaxNo.Text & "',[Comments]='',[sec_type]='EQUITY',[board]='" & removeSpecialCharacter(txtBoard.Text) & "',[index_type]='Manufacturing',[ticker]='" & removeSpecialCharacter(txtTicker.Text) & "',[ISIN]='" & txtisin.Text & "',[year_listed]='" & dtYear.Text & "',[comp_secretary]='" & removeSpecialCharacter(txtcompsecretary.Text) & "',[email]='" & txtEmail.Text & "',[website]='" & txtWebsite.Text & "',[issued_capital]='0',[nominal_value]='0' where id='" & editID & "'", con)
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

                Dim stmnt As String = "insert into para_company([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value],[currency], Issuer_code, series, validity, initialprice, measurement, TradingStatus) values (''" & removeSpecialCharacter(txtcommodity.Text + "/" + txtisin.Text) & "'',''" & removeSpecialCharacter(txtcommodity.Text + "/" + txtisin.Text) & "'',getdate(),''0'','''',''" & removeSpecialCharacter(txtRegdOffice1.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice2.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice3.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice4.Text) & "'','''','''','''',''" & txtPhoneNo.Text & "'','''',''" & txtFaxNo.Text & "'','''',''GDR'','''','''','''',''" & txtisin.Text & "'',getdate(),'''',''" & txtEmail.Text & "'',''" & txtWebsite.Text & "'',''0'',''0'',''" + cmbcurrency.Text + "'',''" + txtcommodity.Text + "'',''" + txtisin.Text + "'',''" + txtNominalValue0.Text + "'',''" + txtprice.Text + "'',''" + cmbmeasurement.Text + "'',''" + cmbIndexType0.Text + "'' ) "
                'insert into testcds_ROUTER.dbo.para_company (company, Sector,  Issued_shares, status, Date_created, country, Contact_Person , ISIN_No, Market_Segment, Instrument, Index_Type,InitialPrice,fnam, Board, exchange, comp_sector )  values (''" + txtisin.Text + "'',''Commodity'',''0'',''0'',getdate(),''ZIMBABWE'',''ADMIN'',''" + txtisin.Text + "'',''" + txtcommodity.Text + "'',''GDR'',''PRIMARY'',''" + txtprice.Text + "'',''" + txtisin.Text + "'',''COMMODITY'',''FINSEC'','''')"
                Dim descr As String = "Added a new Commodity with the following details. Commodity: " + txtcommodity.Text + "   Grade: " + txtisin.Text + "  Security Type:Product   Initial Price: " + txtprice.Text + " Unit of Measure: " + cmbmeasurement.Text + "  "
                cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Product')", con)
                'cmd = New SqlCommand("insert into para_company([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value], currency) values ('" & removeSpecialCharacter(txtSecName.Text) & "','" & removeSpecialCharacter(txtSecName.Text) & "','" & dtYear.Text & "','" & txtIssuedCapital.Text & "',(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),'" & removeSpecialCharacter(txtRegdOffice1.Text) & "','" & removeSpecialCharacter(txtRegdOffice2.Text) & "','" & removeSpecialCharacter(txtRegdOffice3.Text) & "','" & removeSpecialCharacter(txtRegdOffice4.Text) & "','','" & cmbCountryListed.SelectedItem.Value & "','" & removeSpecialCharacter(txtcompsecretary.Text) & "','" & txtPhoneNo.Text & "','','" & txtFaxNo.Text & "','','" & cmbSecType.SelectedItem.Value & "','" & removeSpecialCharacter(txtBoard.Text) & "','" & cmbIndexType.SelectedItem.Value & "','" & removeSpecialCharacter(txtTicker.Text) & "','" & txtISIN.Text & "','" & dtYear.Text & "',(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),'" & txtEmail.Text & "','" & txtWebsite.Text & "','" & txtIssuedCapital.Text & "','" & txtNominalValue.Text & "','" + cmbcurrency.SelectedItem.Text + "')", con)
                'msgbox(cmd.CommandText)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    ' msgbox("Sent for Approval")
                    Session("finish") = "True"
                    Response.Redirect(Request.RawUrl)
                Else
                    msgbox("Error saving company details")
                End If
            End If
        Else
            cmd = New SqlCommand("Update para_company set validity='" + txtNominalValue0.Text + "', InitialPrice='" + txtprice.Text + "', TradingStatus='" + cmbIndexType0.Text + "', Currency='" + cmbcurrency.SelectedItem.Text + "' where id='" + lblid.Text + "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            Session("finish") = "update"
            Response.Redirect(Request.RawUrl)

        End If


    End Sub
    Public Sub getall()
        cmd = New SqlCommand("select ID,Issuer_Code as [Commodity], Series as [Grade], Validity, format(InitialPrice,'#,0.00') as [Price], Currency, Measurement, TradingStatus from para_company", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec")
        If ds.Tables(0).Rows.Count > 0 Then
            ASPxTreeList1.DataSource = ds
            ASPxTreeList1.DataBind()

        End If
    End Sub

    Protected Sub loadissuers()
        Try
            cmd = New SqlCommand(" select distinct company from para_issuer", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                txtsearchsecname.DataSource = ds
                txtsearchsecname.TextField = "company"

            Else
                txtsearchsecname.DataSource = Nothing
            End If
            txtsearchsecname.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub loadwarehouse()
        Try
            cmd = New SqlCommand(" select distinct company from para_warehouse", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbwarehouse.DataSource = ds
                cmbwarehouse.TextField = "company"

            Else
                cmbwarehouse.DataSource = Nothing
            End If
            cmbwarehouse.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub loadmeasurements()
        Try
            cmd = New SqlCommand("select unit_of_measurement from para_measurements", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbmeasurement.DataSource = ds
                cmbmeasurement.TextField = "unit_of_measurement"

            Else
                cmbmeasurement.DataSource = Nothing
            End If
            cmbmeasurement.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub loadcomm()
        Try
            cmd = New SqlCommand("  select commodity_type from para_commodity_type ", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                txtcommodity.DataSource = ds
                txtcommodity.TextField = "commodity_type"

            Else
                txtcommodity.DataSource = Nothing
            End If
            txtcommodity.DataBind()
        Catch ex As Exception

        End Try
    End Sub



    Public Sub getcompsec()
        Try
            cmd = New SqlCommand("select * from client_companies where company_type='TSec'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                txtcompsecretary.DataSource = ds
                txtcompsecretary.ValueField = "company_name"
                txtcompsecretary.TextField = "company_name"
                txtcompsecretary.DataBind()

            Else

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub getcurr()
        Try
            cmd = New SqlCommand("select currencycode from para_currencies", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbcurrency.DataSource = ds
                cmbcurrency.ValueField = "currencycode"
                cmbcurrency.TextField = "currencycode"
                cmbcurrency.DataBind()
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadCountry()
        Try
            cmd = New SqlCommand("select * from para_country", con)
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
    Protected Sub loadGRADES()
        Try
            cmd = New SqlCommand("SELECT grade from para_commodity_grades where commodity='" + txtcommodity.Text + "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "cntry")
            If ds.Tables(0).Rows.Count > 0 Then
                txtisin.DataSource = ds.Tables(0)
                txtisin.ValueField = "grade"
                txtisin.TextField = "grade"
            Else
                txtisin.DataSource = Nothing
            End If
            txtisin.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Function gradeexists(commodity As String) As Boolean
        Try
            cmd = New SqlCommand("select * from testcds_router.dbo.para_company where company='" + commodity + "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "cntry")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

        End Try
    End Function

    Protected Sub clearAll()
        Try
            txtBoard.Text = ""
            txtcompsecretary.Text = ""
            txtEmail.Text = ""
            txtFaxNo.Text = ""
            txtisin.Text = ""

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
        cmd = New SqlCommand("select * from para_globsecurities where company='" & txtsearchsecname.Text & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            'fill text boxes
            txtBoard.Text = ds.Tables(0).Rows(0).Item("board").ToString
            txtcompsecretary.Text = ds.Tables(0).Rows(0).Item("Contact_Person").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtFaxNo.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
            txtisin.Text = ds.Tables(0).Rows(0).Item("ISIN").ToString

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
                '  cmbIndexType.SelectedItem = cmbIndexType.Items.FindByValue(ds.Tables(0).Rows(0).Item("index_type").ToString)
            Catch ex As Exception
                '  cmbIndexType.SelectedIndex = -1
            End Try
            Try
                '  cmbSecType.SelectedItem = cmbSecType.Items.FindByValue(ds.Tables(0).Rows(0).Item("sec_type").ToString)
            Catch ex As Exception
                '  cmbSecType.SelectedIndex = -1
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


    Protected Sub searchVisible()
        txtsearchsecname.Visible = True
        lblSearchSecName.Visible = True
        '  btnSearchSecName.Visible = True
    End Sub

    Protected Sub searchInvisible()
        txtsearchsecname.Visible = False
        lblSearchSecName.Visible = False
        btnSearchSecName.Visible = False
    End Sub



    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

    End Sub

    Protected Sub txtsearchsecname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtsearchsecname.SelectedIndexChanged
        clearAll()
        cmd = New SqlCommand("select * from para_issuer where company='" & txtsearchsecname.Text & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            'fill text boxes
            txtBoard.Text = ds.Tables(0).Rows(0).Item("board").ToString
            txtcompsecretary.Text = ds.Tables(0).Rows(0).Item("Contact_Person").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtFaxNo.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
            txtisin.Text = ds.Tables(0).Rows(0).Item("ISIN").ToString

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
                dtYear.Date = ds.Tables(0).Rows(0).Item("Date_created").ToString
            Catch ex As Exception
                dtYear.Text = ""
            End Try
        Else
            msgbox("Company not found")
        End If
    End Sub


    Protected Sub txtcommodity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtcommodity.SelectedIndexChanged
        Try
            loadGRADES()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtisin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtisin.SelectedIndexChanged
        cmd = New SqlCommand("select measurement from para_commodity_grades where grade='" + txtisin.Text + "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbmeasurement.Value = ds.Tables(0).Rows(0).Item("measurement")
        End If
    End Sub



    Protected Sub ASPxTreeList1_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxTreeList1.RowCommand
        Dim myID As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            lblid.Text = myID
            getinfortoedit(myID)

        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("delete from  para_company where id='" + myID + "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            Session("finish") = "delete"
            Response.Redirect(Request.RawUrl)
        End If

    End Sub
    Public Sub getinfortoedit(id As String)
        cmd = New SqlCommand("select * from para_company where id='" + id + "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            txtcommodity.Value = ds.Tables(0).Rows(0).Item("issuer_code").ToString
            txtcommodity.Enabled = False
            txtisin.Value = ds.Tables(0).Rows(0).Item("series").ToString
            txtisin.Enabled = False
            Dim prce As Decimal = ds.Tables(0).Rows(0).Item("InitialPrice").ToString
            txtprice.Text = prce.ToString("N")
            cmbmeasurement.Value = ds.Tables(0).Rows(0).Item("Measurement").ToString
            txtNominalValue0.Text = ds.Tables(0).Rows(0).Item("Validity").ToString
            cmbIndexType0.Value = ds.Tables(0).Rows(0).Item("TradingStatus").ToString
            cmbcurrency.Value = ds.Tables(0).Rows(0).Item("Currency").ToString
            btnSaveCompany.Text = "Update"
        End If
    End Sub
    Protected Sub btnSaveCompany0_Click(sender As Object, e As EventArgs) Handles btnSaveCompany0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
