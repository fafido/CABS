Imports System.IO
Imports System.Array

Partial Class CDSMode_InstrumentsSetUpnew
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
                loadissuers()
                searchVisible()
                getcurr()
                txtISIN.Text = "ZWFIN" + maxid()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveCompany_Click(sender As Object, e As EventArgs) Handles btnSaveCompany.Click
        'Try
        If txtISIN.Text.Length = 12 Then

        Else
            msgbox("Please enter a 12 character ISIN!")
            txtISIN.Focus()
            Exit Sub
        End If
        If rdbType.SelectedValue = "Save Equity" Then
            cmd = New SqlCommand("update para_company set [Company]='" & removeSpecialCharacter(txtSecName.Text) & "',[Fnam]='" & removeSpecialCharacter(txtSecName.Text) & "',[Date_created]='" & dtYear.Text & "',[Issued_shares]='" & txtIssuedCapital.Text & "',[registrar]=(select company_code from client_companies where company_name='" & removeSpecialCharacter(txtcompsecretary.Text) & "'),[Add_1]='" & removeSpecialCharacter(txtRegdOffice1.Text) & "',[Add_2]='" & removeSpecialCharacter(txtRegdOffice2.Text) & "',[Add_3]='" & removeSpecialCharacter(txtRegdOffice3.Text) & "',[Add_4]='" & removeSpecialCharacter(txtRegdOffice4.Text) & "',[City]='',[Country]='" & cmbCountryListed.SelectedItem.Value & "',[Contact_Person]='" & removeSpecialCharacter(txtcompsecretary.Text) & "',[Telephone]='" & txtPhoneNo.Text & "',[Cellphone]='',[Fax]='" & txtFaxNo.Text & "',[Comments]='',[sec_type]='EQUITY',[board]='" & removeSpecialCharacter(txtBoard.Text) & "',[index_type]='Manufacturing',[ticker]='" & removeSpecialCharacter(txtTicker.Text) & "',[ISIN]='" & txtISIN.Text & "',[year_listed]='" & dtYear.Text & "',[comp_secretary]='" & removeSpecialCharacter(txtcompsecretary.Text) & "',[email]='" & txtEmail.Text & "',[website]='" & txtWebsite.Text & "',[issued_capital]='" & txtIssuedCapital.Text & "',[nominal_value]='" & txtNominalValue.Text & "' where id='" & editID & "'", con)
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
            Dim dealallowed As String = cmbIndexType0.SelectedItem.Text
            Dim sec As String = "CORP"
            Dim countr As String = cmbCountryListed.SelectedItem.Text
            Dim board As String = txtboard.Text
            Dim stmnt As String = "insert into para_company([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value]) values (''" & removeSpecialCharacter(txtTicker.Text) & "'',''" & removeSpecialCharacter(txtSecName.Text) & "'',''" & dtYear.Text & "'',''" & txtIssuedCapital.Text & "'',(select company_code from client_companies where company_name=''" & removeSpecialCharacter(txtcompsecretary.Text) & "''),''" & removeSpecialCharacter(txtRegdOffice1.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice2.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice3.Text) & "'',''" & removeSpecialCharacter(txtRegdOffice4.Text) & "'','''',''" & cmbCountryListed.SelectedItem.Value & "'',''" & removeSpecialCharacter(txtcompsecretary.Text) & "'',''" & txtPhoneNo.Text & "'','''',''" & txtFaxNo.Text & "'','''',''EQUITY'',''" & removeSpecialCharacter(txtboard.Text) & "'','''',''" & removeSpecialCharacter(txtTicker.Text) & "'',''" & txtISIN.Text & "'',''" & dtYear.Text & "'',(select company_code from client_companies where company_name=''" & removeSpecialCharacter(txtcompsecretary.Text) & "''),''" & txtEmail.Text & "'',''" & txtWebsite.Text & "'',''" & txtIssuedCapital.Text & "'',''" & txtNominalValue.Text & "'')      insert into testcds.dbo.para_company (company, sector, Issued_shares, [status], Date_created, Contact_Person, Cellphone, email, isin_no, Market_Segment, Instrument, Index_Type, fhl, fel, swl, InitialPrice, fnam, Board) values (''" + txtTicker.Text + "'',(select top 1 board from para_issuer where company=''" + txtSecName.Text + "''),''" + txtIssuedCapital.Text + "'',''0'',getdate(),''ADMIN'',''0'',''0'', ''" + txtISIN.Text + "'',''0'',''EQUITY'',''20 SHARE INDEX'',''0'',''0'',''0'',''" + txtprice.Text + "'',''" + txtsearchsecname.SelectedItem.Text + "'',''Equities Board'')    declare @price numeric(18,4)=''" + txtprice.Text + "'' insert into testcds.dbo.companyprices (company, SHARESINISSUE, LASTPRICE, CHANGEPercent, CHANGEValue, CurrentPrice, [ShareVOL],sharevalue, highestprice, LowestPrice, UpdatedDate, OpeningPrice, bestprice) select company, issued_shares, @price,''0'',''0'',@price,''0'',''0'',@price, @price, getdate(), @price, @price from para_company where company=''" + txtTicker.Text + "''"
            Dim descr As String = "Added a new Instrument with the following details. Company=" + txtSecName.Text + "   Full Company Name=" + txtSecName.Text + " Issued Shares:" + txtIssuedCapital.Text + " Registrar:" + sec + " Address:" + txtRegdOffice1.Text + " " + txtRegdOffice2.Text + " " + txtRegdOffice3.Text + " " + txtRegdOffice4.Text + " Country:" + countr + " Security Type:EQUITY Board:" + board + "  Industry Type Ticker:" + txtTicker.Text + " ISIN" + txtISIN.Text + "  Year Listed " + dtYear.Text + " Nominal Value:" + txtNominalValue.Text + " Status:" + dealallowed + " Term:" + txtNominalValue0.Text + ""
            cmd = New SqlCommand("insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('" + descr + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','New Security')", con)
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

    Protected Sub clearAll()
        Try
            txtBoard.Text = ""
            txtcompsecretary.Text = ""
            txtEmail.Text = ""
            txtFaxNo.Text = ""
            ' txtISIN.Text = ""
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
            txtISIN.Text = "ZWFIN" + maxid()
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
        txtSearchSecName.Visible = True
        lblSearchSecName.Visible = True
        '  btnSearchSecName.Visible = True
    End Sub

    Protected Sub searchInvisible()
        txtSearchSecName.Visible = False
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
            ' txtBoard.Text = ds.Tables(0).Rows(0).Item("board").ToString
            txtcompsecretary.Text = ds.Tables(0).Rows(0).Item("Contact_Person").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtFaxNo.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
            '   txtISIN.Text = ds.Tables(0).Rows(0).Item("ISIN").ToString
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
                dtYear.Date = ds.Tables(0).Rows(0).Item("Date_created").ToString
            Catch ex As Exception
                dtYear.Text = ""
            End Try
        Else
            msgbox("Company not found")
        End If
    End Sub

    Public Function tickerexists(ByVal code As String) As String
        cmd = New SqlCommand("select * from para_company where ticker='" + code + "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return "Available"
        Else
            Return "Not Available"
        End If
    End Function

    Protected Sub txtTicker_TextChanged(sender As Object, e As EventArgs) Handles txtTicker.TextChanged
        If tickerexists(txtTicker.Text) = "Available" Then
            txtTicker.Text = ""
            txtTicker.Focus()
            msgbox("Ticker already exists")
        Else

        End If
    End Sub
    Public Function maxid() As String
        cmd = New SqlCommand("select isnull(count(*)+(select count(*) from tbl_uncommitted where script like '%insert into para_company%' and [status]=0),1)+1 as [max] from para_company", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")

        Dim m As Integer
        m = ds.Tables("pc").Rows(0).Item("max")
        Return m.ToString("D7")
    End Function

    Protected Sub txtIssuedCapital_TextChanged(sender As Object, e As EventArgs) Handles txtIssuedCapital.TextChanged
        If txtprice.Text = "" Or txtprice.Text = "0" Or txtIssuedCapital.Text = "" Then
            txtprice.Focus()
            msgbox("Please input the initial price!")
        Else
            Dim price As Decimal = txtprice.Text
            Dim units As Decimal = txtIssuedCapital.Text

            Dim res As Decimal = price * units
            txtNominalValue.Text = res

        End If
    End Sub
End Class
