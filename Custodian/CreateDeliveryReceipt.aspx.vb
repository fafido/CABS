

Imports System.Collections.Generic

Partial Class Custodian_CreateDeliveryReceipt
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



    Public Sub GetDeliveryDetials()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from [WarehourseDeliveries] where Holder = '" & lstNames.SelectedItem.Value & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompanySelect.Text = ds.Tables(0).Rows(0).Item("Commodity").ToString
                txtgrade.Text = ds.Tables(0).Rows(0).Item("Grade").ToString


                txtexpiry.Text = ds.Tables(0).Rows(0).Item("Expiry").ToString
                txtcurrentprice.Text = ds.Tables(0).Rows(0).Item("Price").ToString
                txtpolicy.Text = ds.Tables(0).Rows(0).Item("Price").ToString
                txtinsrancecompany.Text = ds.Tables(0).Rows(0).Item("InsuranceCompany").ToString
                txtinsuranceexpiry.Text = ds.Tables(0).Rows(0).Item("InsuranceExpiry").ToString
                txtinsurancedetails.Text = ds.Tables(0).Rows(0).Item("InsuranceDetails").ToString


                txtharvestdate.Text = ds.Tables(0).Rows(0).Item("HarvestDate").ToString

                txtmoisture.Text = ds.Tables(0).Rows(0).Item("MoistureContent").ToString


                Try
                    txtbroken.Text = ds.Tables(0).Rows(0).Item("Broken").ToString
                Catch ex As Exception

                End Try
                Try
                    txtdamaged.Text = ds.Tables(0).Rows(0).Item("Damage").ToString
                Catch ex As Exception

                End Try
                Try
                    txtforeignmatters.Text = ds.Tables(0).Rows(0).Item("ForeignMatters").ToString
                Catch ex As Exception

                End Try
                Try
                    txtwarehouseinsurance.Text = ds.Tables(0).Rows(0).Item("warehouseNo").ToString
                Catch ex As Exception

                End Try
                Try
                    txtmeasurement.Text = ds.Tables(0).Rows(0).Item("Adress_3").ToString
                Catch ex As Exception

                End Try
                Try
                    txtreceiptquantity.Text = ds.Tables(0).Rows(0).Item("Quantity").ToString
                Catch ex As Exception

                End Try
                'Try
                '    txttradingbankname.Value = ds.Tables(0).Rows(0).Item("trading_bank").ToString
                'Catch ex As Exception

                'End Try
                'Try
                '    txtmainbankname.Value = ds.Tables(0).Rows(0).Item("main_bank").ToString
                'Catch ex As Exception

                'End Try
                'Try
                '    ASPxComboBox2.Value = ds.Tables(0).Rows(0).Item("settlement_cycle").ToString
                'Catch ex As Exception

                'End Try

                'txtmainbic.Text = ds.Tables(0).Rows(0).Item("main_branch").ToString
                'txttradingbic.Text = ds.Tables(0).Rows(0).Item("trading_branch").ToString

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
            cmd = New SqlCommand("select distinct instrument from trans where cds_number='" + txtClientID.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_securities")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbSecurities.DataSource = ds
                cmbSecurities.TextField = "instrument"
                cmbSecurities.ValueField = "instrument"
                cmbSecurities.DataBind()
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
                    loadall()

                End If
                If Session("finish") = "true" Then
                    Session("finish") = ""
                    msgbox("Warehouse Receipt Successfully Captured! Awaiting Authorization")
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End Sub
        Protected Sub loadmeasurements()
            Try
                cmd = New SqlCommand("select unit_of_measurement from para_measurements", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "sec")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtmeasurement.DataSource = ds
                    txtmeasurement.TextField = "unit_of_measurement"

                Else
                    txtmeasurement.DataSource = Nothing
                End If
                txtmeasurement.DataBind()
            Catch ex As Exception

            End Try
        End Sub
        Protected Sub loadcomm()
            ' Try
            cmd = New SqlCommand("  select commodity_type from para_commodity_type ", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompanySelect.DataSource = ds
                cmbCompanySelect.TextField = "commodity_type"

            Else
                cmbCompanySelect.DataSource = Nothing
            End If
            cmbCompanySelect.DataBind()
            'Catch ex As Exception

            'End Try
        End Sub

        Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
            Try
                If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                    Dim ds As New DataSet
                    cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%'", cn)
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
                    cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%' ", cn)
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
            loadcomm()
            loadmeasurements()
        txtwarehouseinsurance.Text = warehouseinsurance(Session("BrokerCode"))

        GetDeliveryDetials()

        'loadCompanies()
        'loadSecurities()
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
                cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames = '" & lstNames.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                    txtIdNo.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                    txtSurnames.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                    txtmobile.Text = ds.Tables(0).Rows(0).Item("mobile").ToString.ToUpper
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

        Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
            If txtClientID.Text = "" Then
                msgbox("Please Search and Select Client")
                Exit Sub
            End If


        ' Try
        cmd = New SqlCommand("Insert into WarehourseDeliveries (gRADE, Holder, Commodity, Warehouse, Expiry, Date_Issued, Quantity, InsurancePolicy, Price, Issued_By, receiptNo, financier,HarvestDate, UnitMeasure, InsuranceCompany, InsuranceDetails, InsuranceExpiry, MoistureContent, Broken, Damage, ForeignMatters)  values ( '" + txtgrade.Text + "','" + lstNames.SelectedItem.Value.ToString + "','" + cmbCompanySelect.SelectedItem.Text + "','" + Session("BrokerCode") + "','" + txtexpiry.Text + "',getdate(),'" + txtreceiptquantity.Text + "','" + txtpolicy.Text + "','" + txtcurrentprice.Text + "','" + Session("Username") + "', (select max(id)+1 from WarehourseDeliveries ) , '','" + txtharvestdate.Text + "','" + txtmeasurement.Text + "','" + txtinsrancecompany.Text + "','" + txtinsurancedetails.Text + "','" + txtinsuranceexpiry.Text + "','" + txtmoisture.Text + "','" + txtbroken.Text + "','" + txtdamaged.Text + "','" + txtforeignmatters.Text + "')", cn)
        If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            'Catch ex As Exception
            '    msgbox(ex.Message)
            'End Try


            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)



        End Sub
        Public Function warehouseinsurance(warehouse As String) As String
            Dim ds As New DataSet
            cmd = New SqlCommand(" select policynumber from insurancepolicies where participant='" + warehouse + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                Return ds.Tables(0).Rows(0).Item("policynumber")
            Else
                Return ""
            End If
        End Function

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
            loadGRADES()

        End Sub
        Protected Sub loadGRADES()
            Try
                cmd = New SqlCommand("SELECT grade from para_commodity_grades where commodity='" + cmbCompanySelect.Text + "'", cn)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "cntry")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtgrade.DataSource = ds.Tables(0)
                    txtgrade.ValueField = "grade"
                    txtgrade.TextField = "grade"
                Else
                    txtgrade.DataSource = Nothing
                End If
                txtgrade.DataBind()
            Catch ex As Exception

            End Try
        End Sub
        Protected Sub cmbSecurities_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSecurities.SelectedIndexChanged

        End Sub
        'Public Sub loadbanks()
        '    Dim ds As New DataSet
        '    cmd = New SqlCommand("select company_code, company_name from client_companies where company_type='BANK'", cn)
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(ds, "Accounts_Clients")
        '    If (ds.Tables(0).Rows.Count > 0) Then
        '        cmbfinancier.DataSource = ds
        '        cmbfinancier.TextField = "company_name"
        '        cmbfinancier.ValueField = "company_code"
        '        cmbfinancier.DataBind()

        '    End If
        'End Sub
        Public Sub loadall()
            Dim ds As New DataSet
        cmd = New SqlCommand("  Select ID, Holder, Commodity, Warehouse, Expiry, Price, Quantity, InsurancePolicy  from WarehourseDeliveries where  ApprovedOn is not NULL ORDER BY ID DESC ", cn)
        adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView3.DataSource = ds
                ASPxGridView3.DataBind()
            End If
        End Sub


        Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
            Dim keys As List(Of Object) = ASPxGridView3.GetSelectedFieldValues(ASPxGridView3.KeyFieldName)

            Dim id As String = keys(0).ToString



            Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        End Sub
        Protected Sub txtgrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtgrade.SelectedIndexChanged
            cmd = New SqlCommand("select measurement from para_commodity_grades where grade='" + txtgrade.Text + "'", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pc")
            If ds.Tables(0).Rows.Count > 0 Then
                txtmeasurement.Text = ds.Tables(0).Rows(0).Item("measurement")
            End If
        End Sub
    End Class

