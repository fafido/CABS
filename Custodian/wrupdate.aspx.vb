Partial Class wrupdate
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub loadCompanies()
        cmd = New SqlCommand("select distinct company from cds_router.dbo.trans where cds_number='" + txtClientID.Text + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_company")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbCompanySelect.DataSource = ds
            cmbCompanySelect.TextField = "company"
            cmbCompanySelect.ValueField = "Company"
            cmbCompanySelect.DataBind()
        End If
    End Sub
    Protected Sub loadSecurities()
        cmd = New SqlCommand("SELECT * FROM WR WHERE ID='" + lstNames.SelectedItem.Value + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_securities")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbCompanySelect.Text = ds.Tables(0).Rows(0).Item("Commodity")
            '    cmbfinancier.Text = ds.Tables(0).Rows(0).Item("financier")
            txtexpiry.Text = ds.Tables(0).Rows(0).Item("expiry")
            txtgrade.Text = ds.Tables(0).Rows(0).Item("grade")
            txtcurrentprice.Text = ds.Tables(0).Rows(0).Item("Price")
            txtpolicy.Text = ds.Tables(0).Rows(0).Item("InsurancePolicy")
            txtreceiptquantity.Text = ds.Tables(0).Rows(0).Item("Quantity")
            txtreceiptno.Text = ds.Tables(0).Rows(0).Item("ReceiptNo")
            txtwarehouse.Text = ds.Tables(0).Rows(0).Item("Warehouse")
            txtinsurancedetails.Text = ds.Tables(0).Rows(0).Item("InsuranceDetails")
            txtinsuranceexpiry.Text = ds.Tables(0).Rows(0).Item("InsuranceExpiry")
            txtbroken.Text = ds.Tables(0).Rows(0).Item("Broken")
            txtmoisture.Text = ds.Tables(0).Rows(0).Item("moisturecontent")
            txtdamaged.Text = ds.Tables(0).Rows(0).Item("damage")
            txtforeignmatters.Text = ds.Tables(0).Rows(0).Item("ForeignMatters")
            txtharvestdate.Text = ds.Tables(0).Rows(0).Item("harvestdate")
            txtwarehousephysical.Text = ds.Tables(0).Rows(0).Item("warehousephysical")
        End If
    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                '   loadSecurities()
                ' loadCompanies()
                ' loadwarehouse()
                ' loadbanks()
                loadpending()

            End If
            If Session("finish") = "True" Then
                Session("finish") = ""
                msgbox("Warehouse Receipt Successfully Updated! ")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub loadpending()
        Dim ds As New DataSet
        cmd = New SqlCommand(" select id as cds_number, receiptNo+' '+ commodity+' '+warehouse as namess  from Wr where     approved_by is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lstNames.DataSource = ds.Tables(0)
            lstNames.TextField = "namess"
            lstNames.ValueField = "cds_number"
            lstNames.DataBind()
        End If
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand(" select id as cds_number, receiptNo+' '+ commodity+' '+warehouse as namess  from Wr where financier='" + Session("BrokerCode") + "' and  receiptNo+' '+ commodity+' '+warehouse like '%" & txtClientName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNames.DataSource = ds.Tables(0)
                    lstNames.TextField = "namess"
                    lstNames.ValueField = "cds_number"
                    lstNames.DataBind()
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand(" select id as cds_number, receiptNo+' '+ commodity+' '+warehouse as [namess]  from Wr where  receiptNo+' '+ commodity+' '+warehouse like '%" & txtClientName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNames.DataSource = ds.Tables(0)
                    lstNames.TextField = "namess"
                    lstNames.ValueField = "cds_number"
                    lstNames.DataBind()
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames.SelectedIndexChanged
        getportfolio()
        loadCompanies()
        loadSecurities()
        '    rdBonds.Checked = True
    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from tbl_CashBalance where ClientID = '" & lstNames.SelectedItem.Value & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lblCashBal.Text = ds.Tables(0).Rows(0).Item("total").ToString.ToUpper

            If lblCashBal.Text > 0 Then
                lblCashBal.ForeColor = Drawing.Color.Green
                '  lblCashBal0.Visible = True
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                '  lblCashBal0.Visible = True
            End If
        End If

    End Sub
    Protected Sub GetFromTrans(ByVal cds As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select  t.company as [Company], sum(t.shares) as [Total Units], sum(t.pledge_shares) as [Pledged Units], (sum(t.shares)-sum(pledge_shares)) as [Available Units] from trans t, Accounts_Clients a where t.cds_number='" + cds + "' and t.CDS_Number=a.CDS_Number and t.company='" & cmbCompanySelect.SelectedItem.Value & "'  group by t.company having sum(t.shares)>0 ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdPortfolios.DataSource = dsport.Tables(0)
            grdPortfolios.DataBind()
            '    GetCashBal()
        Else
            grdPortfolios.DataSource = Nothing
            grdPortfolios.DataBind()

        End If
    End Sub
    Protected Sub GETPENDING(ByVal cds As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select  (select fnam from para_company where isin=tbl_SettlementSummary.company) as [Company],sum(Quantity) as [Quantity], 'Sell' as [Transaction Type]  from tbl_SettlementSummary WHERE ordertype='S' and cds_number='" + cds + "' and Status_Flag not in ('SETTLED','FAILED')  and company=(select ISIN from para_company where COMPANY='" + cmbCompanySelect.SelectedItem.Value + "')  group by company", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdunsettled.DataSource = dsport.Tables(0)
            grdunsettled.DataBind()
            grdunsettled.Visible = True
            '    GetCashBal()
        Else

            grdunsettled.DataSource = Nothing
            grdunsettled.DataBind()
            grdunsettled.Visible = False

        End If
    End Sub
    Public Sub getportfolio()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select *, (SELECT top 1 phone  FROM cds_router.dbo.formattedphone where cds_Number=accounts_clients.cds_number) as newphone from Accounts_Clients where cds_number = (select holder from WR WHERE  id= '" & lstNames.SelectedItem.Value & "')", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                txtIdNo.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                txtSurnames.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtmobile.Text = ds.Tables(0).Rows(0).Item("newphone").ToString.ToUpper
                '   rdBonds.Checked = True


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try

            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Try
                    Dim ds As New DataSet
                    cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where cds_number like '%' + @clientnosearch +'%'", cn)
                    cmd.Parameters.AddWithValue("@clientnosearch", txtClientNoSe.Text)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "Accounts_Clients")
                    If (ds.Tables(0).Rows.Count > 0) Then
                        lstNames.DataSource = ds.Tables(0)
                        lstNames.TextField = "namess"
                        lstNames.ValueField = "cds_number"
                        lstNames.DataBind()
                    End If
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            Else


                Try
                    Dim ds As New DataSet
                    cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where cds_number like '%' + @clientnosearch + '%' and Brokercode='" + Session("BrokerCode") + "'", cn)
                    cmd.Parameters.AddWithValue("@clientnosearch", txtClientNoSe.Text)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "Accounts_Clients")
                    If (ds.Tables(0).Rows.Count > 0) Then
                        lstNames.DataSource = ds.Tables(0)
                        lstNames.TextField = "namess"
                        lstNames.ValueField = "cds_number"
                        lstNames.DataBind()
                    End If
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click

    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Shared Function createrandomnumber(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Function gradeexists(gradenew As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select company from testcds.dbo.companyprices where company='" + gradenew + "'", cn)
        cmd.Parameters.AddWithValue("@clientnosearch", txtClientNoSe.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If txtClientID.Text = "" Then
            msgbox("Please Search and Select Client")
            Exit Sub
        End If


        ' Dim stmnt As String = " "
        '  Dim descr As String = "Added a new Depository Receipt with the following details.    Financier =" + Session("BrokerCode") + "  Security Type:Warehouse Receipt    Commodity: " + cmbCompanySelect.Text + "  Price: " + txtcurrentprice.Text + "     Warehouse: " + txtwarehouse.Text + "   "
        ' cmd = New SqlCommand("insert into para_company([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value]) values ('" & txtreceiptno.Text & "','" & cmbCompanySelect.Text & "',getdate(),'0','','','','','','','','','','','','','WAREHOUSE RECEIPT','','','','" & txtreceiptno.Text & "',GETDATE(),'','','','0','0')      insert into testcds.dbo.para_company (company, sector, Issued_shares, [status], Date_created, Contact_Person, Cellphone, email, isin_no, Market_Segment, Instrument, Index_Type, fhl, fel, swl, InitialPrice, fnam, Board) values ('" + txtreceiptno.Text + "','0','0','0',getdate(),'ADMIN','0','0', '" + txtreceiptno.Text + "','0','GDR','20 SHARE INDEX','0','0','0','" + txtcurrentprice.Text + "','" + cmbCompanySelect.Text + "','Equities Board')  declare @price numeric(18,4)='" + txtcurrentprice.Text + "' insert into testcds.dbo.companyprices (company, SHARESINISSUE, LASTPRICE, CHANGEPercent, CHANGEValue, CurrentPrice, [ShareVOL],sharevalue, highestprice, LowestPrice, UpdatedDate, OpeningPrice, bestprice) select company, issued_shares, @price,'0','0',@price,'0','0',@price, @price, getdate(), @price, @price from para_company where company='" + txtreceiptno.Text + "'   insert into testcds_ROUTER.dbo.para_company (company, Sector,  Issued_shares, status, Date_created, country, Contact_Person , ISIN_No, Market_Segment, Instrument, Index_Type,InitialPrice,fnam, Board, exchange, comp_sector )  values ('" + txtreceiptno.Text + "','Commodity','0','0',getdate(),'ZIMBABWE','ADMIN','" + txtreceiptno.Text + "','" + cmbCompanySelect.Text + "','GDR','20 SHARE INDEX','" + txtcurrentprice.Text + "','" + txtreceiptno.Text + "','COMMODITY','FINSEC','" + txtwarehouse.Text + "')        insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares)  values ('" + txtreceiptno.Text + "','" + txtClientID.Text + "',getdate(), getdate(), '" + txtreceiptquantity.Text + "','ALLOT','ADMIN','" + lstNames.SelectedItem.Value.ToString + "','D','0') update  WR set ApprovedBy='" + Session("Username") + "', Approved_By='" + Session("Username") + "',ApprovedOn=getdate()  WHERE ID='" + lstNames.SelectedItem.Value + "' ", cn)

        cmd = New SqlCommand("update wr set [status]='" + RadioButtonList1.SelectedItem.Text + "' where id='" + lstNames.SelectedItem.Value.ToString + "'", cn)
        ' insertmessage(txtreceiptquantity.Text, txtmobile.Text, txtgrade.Text, cmbCompanySelect.Text)



        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()

        cmd.ExecuteNonQuery()
        insertmessage(txtreceiptquantity.Text, txtmobile.Text, txtgrade.Text, cmbCompanySelect.Text)
        Session("finish") = "True"
        Response.Redirect(Request.RawUrl)






    End Sub
    Public Sub insertmessage(quantity As String, mobile As String, grade As String, company As String)
        cmd = New SqlCommand("insert into cds_router.dbo.SMSLog (recipient, full_message, message_category, date_created, processed, response)   values ('" + mobile + "', 'Your " + quantity + " KG " + company + "/" + grade + " has been successfully allocated to your Account.', 'Deposit',getdate(), '0','')", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub loadbas()
        Dim ds As New DataSet
        cmd = New SqlCommand("select Ba_number as [BA Number], Principal_name as [Principal], face_value as [Face Value], Tenor, Maturity_Date, issue_date as [Issue Date],  Discount_percentage as [Discount(%)] from bas where ba_number='" + cmbCompanySelect.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
            ASPxGridView2.Visible = True
        End If
    End Sub
    Public Sub loadderivative()
        Dim ds As New DataSet
        cmd = New SqlCommand("select contractno as [Contract No],ContractType as [Contract Type], Assetname as [Asset], Assettype as [Asset Type], AssetQuantity as [Asset Quantity], AssetValue as [Asset Value], SettlementDate as [Settlement Date] from deriv_contract where contractno='" + cmbCompanySelect.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()
            ASPxGridView2.Visible = True
        End If
    End Sub
    Public Function totalholding(company As String, holder As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as totl from trans where cds_number='" + holder + "' and company='" + company + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("totl")
        Else
            Return 0
        End If
    End Function

    Protected Sub cmbCompanySelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompanySelect.SelectedIndexChanged
        '  txtavailablequantity.Text = totalholding(cmbCompanySelect.SelectedItem.Text, lstNames.SelectedItem.Value.ToString)
        txtgrade.Text = cmbCompanySelect.SelectedItem.Text
    End Sub




End Class
