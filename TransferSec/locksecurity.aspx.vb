Partial Class Enquiries_locksecurity
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
        cmd = New SqlCommand("select distinct company from trans where cds_number='" + txtclientid.text + "'", cn)
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
        cmd = New SqlCommand("select distinct instrument from trans where cds_number='" + txtclientid.text + "'", cn)
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
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Lock/Unlock instruction sent! Awaiting Approval")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess,cds_number  from Accounts_Clients where surname+' '+forenames+' '+mobile+' '+idnopp like '%" & txtClientName.Text & "%' and brokercode='" + Session("BrokerCode") + "'", cn)
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

    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If txtClientID.Text = "" Then
            msgbox("Please Search and Select Client")
            Exit Sub
        End If
        If cmbCompanySelect.Text <> "" Then
            GetFromTrans(txtClientID.Text)
            GETPENDING(txtClientID.Text)

            'If cmbSecurities.SelectedItem.Text = "Bankers Acceptance" Then
            '    ASPxGridView2.Caption = "Bankers Acceptance"
            '    loadbas()
            'ElseIf cmbSecurities.SelectedItem.Text = "DERIVATIVE" Then
            '    ASPxGridView2.Caption = "Derivative"
            '    loadderivative()
            'End If
        Else
            msgbox("Select Company and Security")
            Exit Sub
        End If
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

    Protected Sub cmbCompanySelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompanySelect.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from locked_securities where company_locked='" + cmbCompanySelect.SelectedItem.Text + "' and cds_number='" + txtClientID.Text + "' and [status]='1'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            btnView0.Text = "Unlock Security"
            btnView0.Visible = True
            ' msgbox("test")
        Else
            btnView0.Text = "Lock Security"
            btnView0.Visible = True
            ' msgbox("test2")
        End If
    End Sub

    Protected Sub btnView0_Click(sender As Object, e As EventArgs) Handles btnView0.Click
        If btnView0.Text = "Lock Security" Then
            cmd = New SqlCommand("insert into locked_securities (cds_number, company_locked, date_locked,[status],type_) values ('" + txtClientID.Text + "','" + cmbCompanySelect.SelectedItem.Text + "',getdate(),'0','Lock')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            cmd = New SqlCommand("insert into locked_securities (cds_number, company_locked, date_locked,[status],type_) values ('" + txtClientID.Text + "','" + cmbCompanySelect.SelectedItem.Text + "',getdate(),'0','Unlock')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
     
    End Sub
End Class
