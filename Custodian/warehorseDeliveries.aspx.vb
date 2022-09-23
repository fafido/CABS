


Imports System.Collections.Generic

Partial Class Custodian_warehorseDeliveries
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
            '  cmbCompanySelect.DataBind()
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

                loadall()
                loadwarehouse()
                txtexpiry.MinDate = Date.UtcNow
                txtharvestdate.MaxDate = Date.UtcNow


            End If
                If Session("finish") = "true" Then
                    Session("finish") = ""
                msgbox("Deposit Successfully Captured!")
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
        '   cmbCompanySelect.DataBind()
        'Catch ex As Exception

        'End Try
    End Sub

        Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
            Try
                If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                    Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%' AND AccountState='A' order by cds_number", cn)
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
                cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%' AND AccountState='A' order by cds_number", cn)
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


        'loadCompanies()
        'loadSecurities()
        '    rdBonds.Checked = True
    End Sub
    Public Sub getsilos(warehouse As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select storagefacility from WarehouseStorageFacility where warehousecode='" + warehouse + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbshedsilo.DataSource = ds
            cmbshedsilo.TextField = "storagefacility"
            cmbshedsilo.ValueField = "storagefacility"
            cmbshedsilo.DataBind()
        End If
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
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+forenames+' '+surname = '" & lstNames.SelectedItem.Text & "'", cn)
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
                    cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where cds_number like '%' + @clientnosearch +'%' and AccountState='A' ORDER BY cds_Number", cn)
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
                    cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where cds_number like '%' + @clientnosearch + '%' AND AccountState='A' order by cds_number", cn)
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

        Dim quant As Decimal = txtreceiptquantity.Text
        If quant < minimumlot(cmbCompanySelect.SelectedItem.Text) Then
            msgbox("Minimum lot size is " + minimumlot(cmbCompanySelect.SelectedItem.Text).ToString + "")
            Exit Sub
        End If

        If IsNumeric(txtmarketvalue.Text) = False Then
            msgbox("Please enter Numeric Market Value!")
            Exit Sub
        End If


        Dim quantnew As Decimal
        If txtpackaging.Text = "Bulk" Then
            quantnew = txtreceiptquantity.Text
        Else

            If txtpackages.Text = "" Then
                msgbox("Please enter the number of Packages!")
                Exit Sub
            End If
            If IsNumeric(txtpackages.Text) = False Then
                msgbox("Please enter packages in numeric!")
                Exit Sub
            End If

            Try

                Dim weight As Decimal = txtweight.Text
                Dim quant1 As Decimal = txtreceiptquantity.Text
                Dim packages As Decimal = (quant * 1000) / weight

                quantnew = txtpackages.Text

            Catch ex As Exception
                msgbox(ex.Message)
            End Try


        End If
        Dim oth As Decimal

        If txtother.Text <> "" Then
            If IsNumeric(txtother.Text) = False Then
                msgbox("Please enter other charges in numeric!")
                Exit Sub
            End If
            oth = txtother.Text
        Else
            oth = 0
        End If


        Dim units As Decimal = txtreceiptquantity.Text
        If capacity(cmbwarehouse.SelectedItem.Value) < totalholdingwarheouse(cmbwarehouse.SelectedItem.Value) + units Then
            msgbox("Warehouse does not have capacity to accept deposit!")
            Exit Sub
        End If
        Dim shed As String
        Dim silo As String
        If cmbshedsilo.Text = "Shed" Then
            shed = txtsiloNo.Text
            silo = ""
        Else
            silo = txtsiloNo.Text
            shed = ""

        End If




        Try

            If txtharvestdate.Text = "" Then
                cmd = New SqlCommand("Insert into WarehourseDeliveries (gRADE, Holder, Commodity, Warehouse, Expiry, Date_Issued, Quantity, warehouseNo, Price, Issued_By, receiptNo, financier, UnitMeasure, shelfNo, compatimentNo, boxNo, MoistureContent, Broken, Damage, ForeignMatters, warehouseoperator,[Status],SystemType,Reference,OriginalQuantity, [Marks],[LotNo],[SiloNo],[MarketValue],[Wastage],[OtherCharges],[HarvestDate],Packaging, Packages, Unit_Weight, Remarks,StorageCharge )  values ( '','" + lstNames.SelectedItem.Value.ToString + "','" + cmbCompanySelect.SelectedItem.Text + "','" + cmbwarehouse.SelectedItem.Value.ToString + "','" + txtexpiry.Text + "','" + txtdeliverydate.Text + "','" + txtreceiptquantity.Text + "','" + cmbwarehouse.SelectedItem.Text + "','0','" + Session("Username") + "', (select max(id)+1 from WarehourseDeliveries) , '','" + txtmeasurement.Text + "','" + txtsiloNo.Text + "','" + txtCompatimentNo.Text + "','" + txtBoxNo.Text + "','','','','','" + Session("BrokerCode") + "','DELIVERED','NEW','0','" + txtreceiptquantity.Text + "','" + txtmarks.Text + "','" + txtLotNumber.Text + "','" + cmbshedsilo.Text + "','" + txtmarketvalue.Text + "','" + txtwastage.Text + "','" + oth.ToString + "',NULL,'" + txtpackaging.Text + "','" + quantnew.ToString + "','" + txtweight.Text + "','" + txtremarks.Text + "','" + txtcharge.Text + "')", cn)
            Else
                cmd = New SqlCommand("Insert into WarehourseDeliveries (gRADE, Holder, Commodity, Warehouse, Expiry, Date_Issued, Quantity, warehouseNo, Price, Issued_By, receiptNo, financier, UnitMeasure, shelfNo, compatimentNo, boxNo, MoistureContent, Broken, Damage, ForeignMatters, warehouseoperator,[Status],SystemType,Reference,OriginalQuantity, [Marks],[LotNo],[SiloNo],[MarketValue],[Wastage],[OtherCharges],[HarvestDate],Packaging, Packages, Unit_Weight, Remarks,StorageCharge  )  values ( '','" + lstNames.SelectedItem.Value.ToString + "','" + cmbCompanySelect.SelectedItem.Text + "','" + cmbwarehouse.SelectedItem.Value.ToString + "','" + txtexpiry.Text + "','" + txtdeliverydate.Text + "','" + txtreceiptquantity.Text + "','" + cmbwarehouse.SelectedItem.Text + "','0','" + Session("Username") + "', (select max(id)+1 from WarehourseDeliveries) , '','" + txtmeasurement.Text + "','" + txtsiloNo.Text + "','" + txtCompatimentNo.Text + "','" + txtBoxNo.Text + "','','','','','" + Session("BrokerCode") + "','DELIVERED','NEW','0','" + txtreceiptquantity.Text + "','" + txtmarks.Text + "','" + txtLotNumber.Text + "','" + cmbshedsilo.Text + "','" + txtmarketvalue.Text + "','" + txtwastage.Text + "','" + oth.ToString + "','" + txtharvestdate.Text + "','" + txtpackaging.Text + "','" + quantnew.ToString + "','" + txtweight.Text + "','" + txtremarks.Text + "','" + txtcharge.Text + "')", cn)
            End If

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Captured a new Incoming Deposit", txtClientID.Text, "0")
            Catch ex As Exception

            End Try
        Catch ex As Exception
            msgbox(ex.Message)
        End Try


        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)



    End Sub
    Public Function totalholdingwarheouse(warehouse As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(total),0) as tot from warehousetotal where warehouse='" + warehouse + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tot")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("tot").ToString()
        Else
            Return 0
        End If
    End Function
    Public Function capacity(warehouse As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select totalcapacitymetrictons from WarehouseCreation where WarehouseCode='" + warehouse + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "capacity")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("totalcapacitymetrictons").ToString()
        Else
            Return 0
        End If
    End Function

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
    Public Function minimumlot(product As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select min_lot from para_commodity_type where commodity_type='" + product + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "min_lot")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("min_lot")
        Else
            Return 0
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
    Public Sub loadwarehouse()
        Dim ds As New DataSet
        cmd = New SqlCommand("select warehouseCODE, warehouseNAME from warehousecreation where warehouseCode='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbwarehouse.DataSource = ds
            cmbwarehouse.TextField = "warehousename"
            cmbwarehouse.ValueField = "warehousecode"
            cmbwarehouse.DataBind()

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





    Public Sub loadall()
            Dim ds As New DataSet
        cmd = New SqlCommand("   Select ID, Holder as [Client No], Commodity as [Product], Warehouse, Date_Issued as [Deposit Date], FORMAT(Quantity,'#,0.00') as  Quantity,UnitMeasure as [Measurement], SystemType as [Type]  from WarehourseDeliveries  where warehouseoperator='" + Session("BrokerCode") + "'  ORDER BY ID DESC ", cn)
        adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView3.DataSource = ds
                ASPxGridView3.DataBind()
            End If
        End Sub


        Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
            Dim keys As List(Of Object) = ASPxGridView3.GetSelectedFieldValues(ASPxGridView3.KeyFieldName)

        'Dim id As String = keys(0).ToString
        Dim id As String = ""
        Try
            id = keys(0).ToString
        Catch ex As Exception
            id = ""
        End Try


        If id.Trim = "" Then
            msgbox("please select receipt first")
            Exit Sub
        End If


        Dim queryString As String = "deliveryreport.aspx?id=" + id + ""
        Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        End Sub


    Protected Sub cmbwarehouse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbwarehouse.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct commodity from CommodityToBeStored where warehousecode='" + cmbwarehouse.SelectedItem.Value + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompanySelect.DataSource = ds
                cmbCompanySelect.TextField = "commodity"
                cmbCompanySelect.ValueField = "commodity"
                cmbCompanySelect.DataBind()
            Else
                msgbox("There are no commodities set for the selected warehouse!")
            End If
            getsilos(cmbwarehouse.SelectedItem.Value.ToString)

        Catch ex As Exception
            msgbox("Error picking warehouse Commodities! " + ex.Message)
        End Try
    End Sub

    Protected Sub txtpackaging_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtpackaging.SelectedIndexChanged
        If txtpackaging.SelectedItem.Text = "Bags" Then
            txtpackages.Enabled = False
            txtpackages.Text = "0"
            txtweight.Enabled = True
            txtweight.Text = ""
        Else
            txtpackages.Enabled = False
            txtpackages.Text = "0"
            txtweight.Enabled = False
            txtweight.Text = "0"
        End If
    End Sub
    Protected Sub txtweight_TextChanged(sender As Object, e As EventArgs) Handles txtweight.TextChanged
        Try

            Dim weight As Decimal = txtweight.Text
        Dim quant As Decimal = txtreceiptquantity.Text
            Dim packages As Decimal = Math.Round((quant * 1000) / weight, 0)

            txtpackages.Text = packages.ToString

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub txtwastage_TextChanged(sender As Object, e As EventArgs) Handles txtwastage.TextChanged

    End Sub
    Protected Sub cmbshedsilo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbshedsilo.SelectedIndexChanged
        ASPxLabel42.Text = cmbshedsilo.Text + " No."
    End Sub
End Class
