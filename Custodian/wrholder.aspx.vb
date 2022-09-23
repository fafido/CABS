Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class wrholder
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public max As Decimal

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
                getpending()

                Session("Temp") = ""
            End If
            loadall()
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
        cmd = New SqlCommand("select id, commodity+' '+convert(nvarchar(50),quantity)+' '+Unitmeasure as descr from warehoursedeliveries   where [status]='DELIVERED' and warehouseoperator='" + Session("BrokerCode") + "' and quantity<>0 and Holder ='" & txtClientID.Text & "' and id not in (select deliveryid from wr where [status]<>'CANCELLED')", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "sec")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbCompanySelect.DataSource = ds
            cmbCompanySelect.TextField = "descr"
            cmbCompanySelect.ValueField = "id"

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
                cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%' and cds_number in (select holder from WarehourseDeliveries where warehouseoperator='" + Session("BrokerCode") + "' and [status]='DELIVERED') and AccountState='A' order by cds_number", cn)
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
                cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%' and cds_number in (select holder from WarehourseDeliveries where warehouseoperator='" + Session("BrokerCode") + "' and [status]='DELIVERED') AND AccountState='A' order by cds_number", cn)
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
    Public Sub clearitems()
        cmbCompanySelect.Items.Clear()
        cmbCompanySelect.Value = ""
        txtproduct.Text = ""
        txtwarehouse.Text = ""
        txtwarehouseoperator.Text = ""
        txtreceiptquantity.Text = ""
        ASPxComboBox1.Text = ""
        txtLotNumber.Text = ""
        ASPxTextBox1.Text = ""
        cmbshedsilo.Text = ""
        txtexp.Value = ""
        txtsiloNo.Text = ""
        txtmarketvalue.Text = ""
        txtmarks.Text = ""
        txtpackaging.Text = ""
        txtpackages.Text = ""
        txtweight.Text = ""
        txtcharge.Text = ""
        txtwastage.Text = ""
        txtother.Text = ""
        txtdepositdate.Value = ""
        txtremarks.Text = ""
        txtharvestdate.Value = ""
    End Sub
    Protected Sub lstNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNames.SelectedIndexChanged
        clearitems()
        getportfolio(lstNames.SelectedItem.Value)
        loadcomm()
        loadmeasurements()


        'loadCompanies()
        'loadSecurities()
        '    rdBonds.Checked = True
    End Sub




    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("select w.id,case when w.status='REJECTED' THEN 'Edit & Re-Submit' else 'Edit' end as [otp] , W.Holder as [Account No],w.UnitMeasure, W.ReceiptNo as [Details], W.ReceiptNo AS [EWRNo], [Status] as  [Status],  W.[Date_Issued] as [Date], W.Quantity ,w.Commodity, w.Grade, w.Warehouse, w.Date_Issued, w.[Status] as wrstatus    from  WR w where  w.Warehouse='" + Session("BrokerCode") + "' and [Status] in ('PENDING','REJECTED')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView4.DataSource = ds
            ASPxGridView4.DataBind()
        Else
            ASPxGridView4.DataSource = Nothing
            ASPxGridView4.DataBind()
        End If
    End Sub

    Public Sub getportfolio(det As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number = '" & det & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                txtIdNo.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                txtSurnames.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtmobile.Text = ds.Tables(0).Rows(0).Item("mobile").ToString.ToUpper
                txtaddress.Text = ds.Tables(0).Rows(0).Item("add_1").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("add_2").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("add_3").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("add_4").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("Country").ToString.ToUpper
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
                    cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where cds_number like '%' + @clientnosearch +'%' and AccountState='A' order by cds_number", cn)
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
                    cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess,cds_number  from Accounts_Clients where cds_number like '%' + @clientnosearch + '%' AND AccountState='A' ORDER BY CDS_NUMBER ", cn)
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
    Public Function receiptnew() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select  right(convert(nvarchar(50),year(getdate())),2) +'-'+ RIGHT('000000'+CAST(isnull(max(convert(numeric(18,0),right(LEFT(ReceiptNo,LEN(ReceiptNo )-4),LEN(LEFT(ReceiptNo ,LEN(ReceiptNo)-4))-3))),0)+1 AS VARCHAR(100)),6) + '-000' AS [ReceiptNo] from wr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "min_lot")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("ReceiptNo")
        End If
    End Function
    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try

            If txtClientID.Text = "" Then
                msgbox("Please Search and Select Client")
                Exit Sub
            End If
            Dim quant As Decimal = txtreceiptquantity.Text
            If quant < minimumlot(txtproduct.Text) Then
                msgbox("Minimum lot size is " + minimumlot(txtproduct.Text).ToString + "")
                Exit Sub
            End If

            Dim receiptno As String = receiptnew()
            ' Try



            If txtgrade.Text = "" Then
                msgbox("You cannot proceed to save without grading!")
                Exit Sub
            End If

            If btnView.Text = "Update" Then
                deletefin(lblid.Text)
                finsaveupdate(lblid.Text, Session("Temp"), txtgrade.Text)
            Else
                finsave(receiptno, Session("Temp"), txtgrade.Text)
            End If



            Try

                If btnView.Text = "Update" Then
                    cmd = New SqlCommand("update wr set status='PENDING', grade='" + txtgrade.Text + "' WHERE receiptno='" + lblid.Text + "'", cn)

                Else
                    cmd = New SqlCommand("Insert into WR (gRADE, Holder, Commodity, Warehouse, Expiry, Date_Issued, Quantity, InsurancePolicy, Price, Issued_By, receiptNo, financier,HarvestDate, UnitMeasure, InsuranceCompany, InsuranceDetails, InsuranceExpiry, MoistureContent, Broken, Damage, ForeignMatters,WarehousePhysical, [Status],DeliveryID)  values ( '" + txtgrade.Text + "','" + lstNames.SelectedItem.Value.ToString + "','" + txtproduct.Text + "','" + Session("BrokerCode") + "',(select top 1 expiry from WarehourseDeliveries where id= '" + cmbCompanySelect.SelectedItem.Value.ToString + "'),getdate(),'" + txtreceiptquantity.Text + "','" + txtpolicy.Text + "','" + txtcurrentprice.Text + "','" + Session("Username") + "','" + receiptno + "' , '','01-01-1900','" + txtmeasurement.Text + "','" + txtinsrancecompany.Text + "','','" + txtinsuranceexpiry.Text + "','0','0','0','0','" + txtwarehouse.Text + "','PENDING','" + cmbCompanySelect.SelectedItem.Value.ToString + "')", cn)

                End If

                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()

                If btnView.Text = "Update" Then

                    Try
                        Dim a As New passmanagement
                        a.auditlog(Session("BrokerCode"), Session("Username"), "Updated Receipt", txtClientID.Text, lblid.Text)
                    Catch ex As Exception

                    End Try
                Else

                    Try
                        Dim a As New passmanagement
                        a.auditlog(Session("BrokerCode"), Session("Username"), "Created a new Receipt", txtClientID.Text, receiptno)
                    Catch ex As Exception

                    End Try
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try


            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try

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



    Protected Sub cmbCompanySelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompanySelect.SelectedIndexChanged

        loadRECEIPTDETAILS(cmbCompanySelect.SelectedItem.Value.ToString)
        txtgrade.Items.Clear()
        txtgrade.Text = ""
        loadcomps(txtproduct.Text)
        loadcomps_absolute(txtproduct.Text)
        btnView0.Visible = True

        Session("Temp") = createrandomnumber(10)

    End Sub
    Protected Sub loadRECEIPTDETAILS(IDNO As String)
        ' Try
        cmd = New SqlCommand("Select * from warehoursedeliveries where id='" + IDNO + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cntry")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim qnt As Decimal = ds.Tables(0).Rows(0).Item("quantity").ToString
            txtreceiptquantity.Text = qnt.ToString("N")
            txtexpiry.Text = ds.Tables(0).Rows(0).Item("expiry").ToString
            txtwarehouse.Text = ds.Tables(0).Rows(0).Item("warehouse").ToString
            txtwarehouseoperator.Text = ds.Tables(0).Rows(0).Item("warehouseoperator").ToString
            ASPxComboBox1.Text = ds.Tables(0).Rows(0).Item("UnitMeasure").ToString
            txtLotNumber.Text = ds.Tables(0).Rows(0).Item("LotNo").ToString
            ASPxTextBox1.Text = qnt.ToString("N")
            cmbshedsilo.Text = ds.Tables(0).Rows(0).Item("SiloNo").ToString
            txtexp.Value = ds.Tables(0).Rows(0).Item("Expiry").ToString
            txtsiloNo.Text = ds.Tables(0).Rows(0).Item("ShelfNo").ToString
            Dim mktval As Decimal = ds.Tables(0).Rows(0).Item("MarketValue").ToString
            txtmarketvalue.Text = mktval.ToString("N")
            txtmarks.Text = ds.Tables(0).Rows(0).Item("Marks").ToString
            txtpackaging.Text = ds.Tables(0).Rows(0).Item("Packaging").ToString
            Dim pack As Decimal = ds.Tables(0).Rows(0).Item("Packages").ToString
            txtpackages.Text = pack.ToString("N")
            Dim wght As Decimal = ds.Tables(0).Rows(0).Item("Unit_Weight").ToString
            txtweight.Text = wght.ToString("N")
            Dim chrg As Decimal = ds.Tables(0).Rows(0).Item("StorageCharge").ToString
            txtcharge.Text = chrg.ToString("N")
            txtwastage.Text = ds.Tables(0).Rows(0).Item("wastage").ToString
            Dim oth As Decimal = ds.Tables(0).Rows(0).Item("OtherCharges").ToString
            txtother.Text = oth.ToString("N")
            txtdepositdate.Text = ds.Tables(0).Rows(0).Item("Date_Issued").ToString
            txtremarks.Text = ds.Tables(0).Rows(0).Item("Remarks").ToString
            txtharvestdate.Value = ds.Tables(0).Rows(0).Item("HarvestDate").ToString
            Try


                If insurancedetails(Session("BrokerCode")).Tables(0).Rows.Count > 0 Then
                    txtpolicy.Text = insurancedetails(Session("BrokerCode")).Tables(0).Rows(0).Item("PolicyNumber").ToString
                    txtinsrancecompany.Text = insurancedetails(Session("BrokerCode")).Tables(0).Rows(0).Item("InsuranceCompany").ToString()
                    txtinsuranceexpiry.Text = insurancedetails(Session("BrokerCode")).Tables(0).Rows(0).Item("expiry").ToString()
                Else
                    msgbox("Please update your insurance policy!")
                    Exit Sub
                End If
            Catch ex As Exception
                msgbox("Please update your insurance policy!")
                Exit Sub
            End Try

            '   txtinsurancedetails.Text = "N/A"
            max = ds.Tables(0).Rows(0).Item("quantity")
            txtproduct.Text = ds.Tables(0).Rows(0).Item("commodity")
        End If

    End Sub
    Public Sub loadcomps(comm As String)
        cmd = New SqlCommand("select distinct component  from para_commodity_components where commodity='" + comm + "'  and minmax<>'Absolute'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cntry")
        If ds.Tables(0).Rows.Count > 0 Then
            ' msgbox("test")
            grdgrading.DataSource = ds
            grdgrading.DataBind()


        End If

    End Sub
    Public Sub loadcomps_absolute(comm As String)
        cmd = New SqlCommand("select distinct component  from para_commodity_components where commodity='" + comm + "' and minmax='Absolute'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cntry")
        If ds.Tables(0).Rows.Count > 0 Then
            ' msgbox("test")
            grdabsolute.DataSource = ds
            grdabsolute.DataBind()


        End If

    End Sub

    Public Function availablequantity() As Decimal
        cmd = New SqlCommand("Select * from warehoursedeliveries where id='" + cmbCompanySelect.SelectedItem.Value.ToString + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cntry")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("quantity")
        End If


    End Function
    Public Function insurancedetails(warehousecode As String) As DataSet
        cmd = New SqlCommand("select * from InsurancePolicies where participant='" + warehousecode + "' order by id desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cntry")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        Else
            Return Nothing
        End If
    End Function
    Public Function price(item As String) As String
        cmd = New SqlCommand("select ISNULL(initialprice,1) AS  initialprice from para_company where company='" + item + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cntry")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("initialprice")
        Else
            Return "1"
        End If
    End Function



    Protected Sub loadGRADES(commodity As String)
        Try
            cmd = New SqlCommand("SELECT grade from para_commodity_grades where commodity='" + commodity + "'", cn)
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
        cmd = New SqlCommand("  Select ID, Holder, Commodity, Warehouse as [Operator], WarehousePhysical as [Warehouse] , Expiry, FORMAT(Price,'#,###.##','en-us') as Price, FORMAT(Quantity,'#,###.##','en-us') as Quantity, InsurancePolicy, ReceiptNo, [Status]  from WR where Warehouse='" + Session("BrokerCode") + "' and ApprovedOn is not NULL ORDER BY ID DESC ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        End If
    End Sub


    Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
        Dim keys As List(Of Object) = ASPxGridView3.GetSelectedFieldValues(ASPxGridView3.KeyFieldName)

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
        Dim PrintInforCopy As String = ""
        If chkPrintInfoCopy.Checked = True Then
            PrintInforCopy = "Yes"
        Else
            PrintInforCopy = "No"
        End If
        Dim queryString As String = "gvtschedulereport.aspx?id=" + id + "&PrintInforCopy=" & PrintInforCopy & ""
        'Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
        Dim newWin As String = "window.open('" + queryString + "','_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub
    Public Sub unitofmeasure()

        cmd = New SqlCommand("select measurement from para_commodity_grades where grade='" + txtgrade.Text + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            txtmeasurement.Text = ds.Tables(0).Rows(0).Item("measurement")
        End If
    End Sub
    Protected Sub txtreceiptquantity_TextChanged(sender As Object, e As EventArgs) Handles txtreceiptquantity.TextChanged
        Dim changedquantity As Decimal = txtreceiptquantity.Text
        If changedquantity > availablequantity() Then
            txtreceiptquantity.Text = availablequantity().ToString

            msgbox("You cannot enter above the delivered quantity!")
        End If
    End Sub
    Public Function grade_(component As String, value As String) As String
        cmd = New SqlCommand("select grade from para_commodity_components where Component='" + component + "' and [value]>='" + value + "' and commodity='" + txtproduct.Text + "' order by [value] desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("grade").ToString
        Else
            Return "NoGrade"
        End If
    End Function
    Public Function getunitofmeasure(id As String) As String
        cmd = New SqlCommand("select UnitMeasure from warehoursedeliveries where id='" + id + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("UnitMeasure").ToString
        End If
    End Function
    Public Function gettypeyacho(commodity As String, component As String) As String
        cmd = New SqlCommand("select distinct minmax from para_commodity_components where component='" + component + "' and commodity='" + commodity + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("minmax").ToString
        End If
    End Function
    Public Function finalgrade(receiptno As String, commodity As String) As String
        cmd = New SqlCommand("select top 1 [grade],[rank] from para_commodity_grades where grade in (select grade from grade_final where receiptno='" + receiptno + "' and commodity='" + commodity + "') order by [GRADE] desc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("grade").ToString
        Else
            Return ""
        End If
    End Function
    Public Function getindicator(compo As String, commodity As String) As String
        cmd = New SqlCommand("select top 1 minmax from para_commodity_components where commodity='" + commodity + "' and Component='" + compo + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("minmax").ToString
        End If
    End Function
    Public Function getgradeforcompo(indi As String, param As String, valuz As String) As String
        Try


            If indi = "Max" Then
                Dim bv As Decimal = valuz

                cmd = New SqlCommand("select top 1 grade from [para_commodity_components] where convert(numeric(18,4),[value])>=convert(numeric(18,4)," + bv.ToString + ") and component='" + param + "' and commodity='" + txtproduct.Text + "' order by grade asc", cn)
            ElseIf indi = "Min" Then
                Dim bv As Decimal = valuz

                cmd = New SqlCommand("select top 1 grade from [para_commodity_components] where convert(numeric(18,4),[value])<=convert(numeric(18,4)," + bv.ToString + ") and component='" + param + "' and commodity='" + txtproduct.Text + "' order by grade asc", cn)
            Else
                ' msgbox("abso")
                ' cmd = New SqlCommand("select top 1 grade from [para_commodity_components] where value='" + valuz + "' and component='" + param + "' and commodity='" + txtproduct.Text + "' order by grade asc", cn)
                cmd = New SqlCommand("select 'A' as Grade", cn)
            End If

            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pc")
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("grade").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            '  msgbox(ex.Message)
        End Try
    End Function
    'Protected Sub txtforeignmatters_NumberChanged(sender As Object, e As EventArgs) Handles txtforeignmatters.NumberChanged
    '    Try
    '        loadGRADES(txtproduct.Text)

    '        txtgrade.SelectedIndex = 0
    '        unitofmeasure()
    '        txtcurrentprice.Text = price(txtproduct.Text + "/" + txtgrade.Text)
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try

    'End Sub
    Protected Sub btnView0_Click(sender As Object, e As EventArgs) Handles btnView0.Click


        deletecharges(Session("Temp"))
            For Each row As GridViewRow In grdgrading.Rows


                Dim chkView As ASPxTextBox = DirectCast(row.FindControl("txtvalue"), ASPxTextBox)
                Dim moduleId As String = ""
                Dim lblModule As ASPxLabel = CType(row.FindControl("lblcomponent"), ASPxLabel)
                Dim val As String = chkView.Text

                moduleId = lblModule.Text

                If getgradeforcompo(getindicator(moduleId, txtproduct.Text), moduleId, val) = "" Then
                    txtgrade.Items.Clear()
                    txtgrade.Value = ""
                    txtcurrentprice.Text = ""
                    txtmeasurement.Value = ""
                    msgbox("No Grade Available for supplied parameters!")

                    Exit Sub
                End If



                insertcharges(moduleId, val, getgradeforcompo(getindicator(moduleId, txtproduct.Text), moduleId, val), Session("Temp"), txtClientID.Text, txtproduct.Text)

            Next

            For Each row As GridViewRow In grdabsolute.Rows


                Dim chkViewabsolute As DropDownList = DirectCast(row.FindControl("ddabsolutevalue"), DropDownList)
                Dim moduleId As String = ""
                Dim lblabsoluteModule As ASPxLabel = CType(row.FindControl("lblabsolutecomponent"), ASPxLabel)
                Dim val As String = chkViewabsolute.Text

                moduleId = lblabsoluteModule.Text

                insertcharges(moduleId, val, getgradeforcompo(getindicator(moduleId, txtproduct.Text), moduleId, val), Session("Temp"), txtClientID.Text, txtproduct.Text)

            Next

            updatefinal(finalgrade(Session("Temp"), txtproduct.Text), Session("Temp"))
            loadGRADES(txtproduct.Text)
            txtgrade.Value = finalgrade(Session("Temp"), txtproduct.Text)

        txtcurrentprice.Text = price(txtproduct.Text + "/" + txtgrade.Text)
        If btnView.Text = "Update" Then
            txtmeasurement.Text = getunitofmeasure(lbldeliveryid.Text)
        Else

            txtmeasurement.Text = getunitofmeasure(cmbCompanySelect.SelectedItem.Value.ToString)
        End If



    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$&*"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Protected Sub insertcharges(component As String, value As String, grade As String, receiptno As String, clientno As String, commodity As String)
        cmd = New SqlCommand(" insert into grade_final (Component, [Value], Grade, FinalGrade, DateGraded, ReceiptNo, ClientNo, Commodity) values ('" + component + "','" + value + "','" + grade + "',NULL, getdate() ,'" + receiptno + "','" + clientno + "','" + commodity + "')", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Protected Sub deletecharges(idni As String)
        cmd = New SqlCommand(" delete from  grade_final where receiptno='" + idni + "' ", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Protected Sub updatefinal(fingrade As String, receiptno As String)
        cmd = New SqlCommand("update grade_final set finalgrade='" + fingrade + "' where receiptno='" + receiptno + "'", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub finsave(receiptnoorg As String, receipttemp As String, grade As String)
        '   cmd = New SqlCommand("update grade_final set receiptno='" + receiptnoorg + "' where receiptno='" + receipttemp + "'", cn)
        cmd = New SqlCommand("  update grade_final set receiptno='" + receiptnoorg + "', paramvalue=p.[value], paramgrade=p.grade, paramminmax=p.minmax, parammeasure=p.measure  from grade_final g, para_commodity_components  p where receiptno='" + receipttemp + "' and p.grade='" + grade + "' and p.commodity=g.Commodity and p.Component=g.Component", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub finsaveupdate(receiptnoorg As String, receipttemp As String, grade As String)
        '   cmd = New SqlCommand("update grade_final set receiptno='" + receiptnoorg + "' where receiptno='" + receipttemp + "'", cn)
        cmd = New SqlCommand("  update grade_final set receiptno='" + receiptnoorg + "', paramvalue=p.[value], paramgrade=p.grade, paramminmax=p.minmax, parammeasure=p.measure  from grade_final g, para_commodity_components  p where receiptno='" + receipttemp + "'  and p.commodity=g.Commodity and p.Component=g.Component", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub deletefin(receipt As String)
        '   cmd = New SqlCommand("update grade_final set receiptno='" + receiptnoorg + "' where receiptno='" + receipttemp + "'", cn)
        cmd = New SqlCommand("delete from grade_final where receiptno='" + receipt + "'", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub



    Private Sub grdabsolute_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdabsolute.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'Find the DropDownList in the Row
            Dim ddvalue As DropDownList = CType(e.Row.FindControl("ddabsolutevalue"), DropDownList)

            cmd = New SqlCommand("select distinct [value] as valz from para_commodity_components where commodity='" + txtproduct.Text + "' and minmax='Absolute'", cn)
            Dim ds1 As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "pc")
            If ds1.Tables(0).Rows.Count > 0 Then
                ddvalue.DataSource = ds1
                ddvalue.DataTextField = "valz"
                ddvalue.DataValueField = "valz"
                ddvalue.DataBind()

                'Add Default Item in the DropDownList
                ' ddvalue.Items.Insert(0, New ListItem("Please select"))
            End If

            '   Dim lblModule As ASPxLabel = CType(Row.FindControl("lblcomponent"), ASPxLabel)

            '  ddvalue.Visible = False


            'Select the Country of Customer in DropDownList
            'Dim country As String = CType(e.Row.FindControl("lblCountry"), Label).Text
            'ddlCountries.Items.FindByValue(country).Selected = True

            For Each row As GridViewRow In grdgrading.Rows
                Dim lblModule As ASPxLabel = CType(row.FindControl("lblabsolutecomponent"), ASPxLabel)

                ' lblModule.Text = lblModule.Text + " / " + gettypeyacho(txtproduct.Text, lblModule.Text)
                'If gettypeyacho(txtproduct.Text, lblModule.Text) <> "Absolute" Then

                '    ddvalue.Visible = False
                '    txtvalue.Visible = True
                'Else

                '    ddvalue.Visible = True
                '    txtvalue.Visible = False
                'End If
            Next
        End If
    End Sub
    Public Function deletable(idn As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from  WR where [Status]='PENDING' and id='" + idn + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub flagdelete(ref As String)
        cmd = New SqlCommand("update WR set [status]='CANCELLED'  where id='" + ref + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub loaddetails(id As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from  WR where  id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then

        End If
    End Sub
    Public Function holderno(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select holder from  wr where  id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("holder").ToString
        End If
    End Function
    Public Function deliveryid(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select DeliveryID from  wr where  id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("DeliveryID").ToString
        End If
    End Function
    Public Function receiptno(id As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select ReceiptNo from  wr where  id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("ReceiptNo").ToString
        End If
    End Function
    Private Sub ASPxGridView4_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView4.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Delete" Then

            If deletable(id.ToString) = True Then
                flagdelete(id.ToString)
                getpending()

            Else
                msgbox("Approved Transactions cannot be deleted!")
            End If
        ElseIf e.CommandArgs.CommandName.ToString = "Edit" Then

            clearitems()
            getportfolio(holderno(id))
            loadcomm()
            loadmeasurements()
            btnView.Text = "Update"


            cmbCompanySelect.Text = deliveryid(id)
            cmbCompanySelect.Enabled = False
            loadRECEIPTDETAILS(deliveryid(id))
            txtgrade.Items.Clear()
            txtgrade.Text = ""
            loadcomps(txtproduct.Text)
            loadcomps_absolute(txtproduct.Text)
            btnView0.Visible = True
            lblid.Text = receiptno(id)
            lbldeliveryid.Text = id
            Session("Temp") = createrandomnumber(10)



        End If
    End Sub


    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim ds As New DataSet
        cmd = New SqlCommand(" Select ID, Holder, Commodity, Warehouse as [Operator], WarehousePhysical as [Warehouse] , Expiry, FORMAT(Price,'#,###.##','en-us') as Price,FORMAT(Quantity,'#,###.##','en-us') as  Quantity, InsurancePolicy, ReceiptNo, [Status]  from WR where Warehouse='" + Session("BrokerCode") + "' and ApprovedOn is not NULL  and convert(nvarchar(50),id)+' '+Holder+' '+commodity+' '+Warehouse+' '+WarehousePhysical+' '+InsurancePolicy+' '+ReceiptNo+' '+[Status] like '%" + txtsearch.Text + "%' ORDER BY ID DESC", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        End If
    End Sub
End Class
