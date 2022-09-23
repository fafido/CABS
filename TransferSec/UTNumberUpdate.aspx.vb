Partial Class Enquiries_PortfolioDetailsEnquiry
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
                ' GETPENDING()
                getcompanies()

                '   loadSecurities()
                ' loadCompanies()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getcompanies()
        Dim ds As New DataSet

        If (Session("usertype") = "UNITTRUSTADMIN") Then

            cmd = New SqlCommand("select company, fnam from [testcds_ROUTER].[dbo].[para_company] where BOARD='UNIT TRUST' AND ISIN_No='OMUT'", cn)
        Else
            cmd = New SqlCommand("select * from (select 1 as ranc, 'All' as fnam, 'ALL' as company union select 2 as ranc, fnam, company from testcds_Router.dbo.para_company) j order by j.ranc", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbFund.DataSource = ds
            cmbFund.TextField = "company"
            cmbFund.ValueField = "company"
            cmbFund.DataBind()
        End If
    End Sub







    Protected Sub GETPENDING()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Forenames,Surname,Idnopp as [IDNumber], CDS_Number as [CDSNumber] from cds_router.dbo.accounts_clients_web where  cds_number in (select cds_ac_no from testcds_ROUTER.dbo.pre_order_live where  OrderStatus='OPEN' AND company ='" + cmbFund.SelectedItem.Value + "') and CDS_Number not in (select cds_number from Client_InvestorPin_Relation where Fund='" + cmbFund.SelectedItem.Value + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            grdvCharges.DataSource = dsport.Tables(0)
            grdvCharges.DataBind()
            grdvCharges.Visible = True
            '    GetCashBal()
        Else

            grdvCharges.DataSource = Nothing
            grdvCharges.DataBind()
            grdvCharges.Visible = False

        End If
    End Sub
    Protected Sub grdvCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCharges.SelectedIndexChanged

        'msgbox(grdvCharges.SelectedRow.Cells(2).Text)
        getDetails(grdvCharges.SelectedRow.Cells(4).Text)
        ' ViewIds(txtClientID.Text)
        'txtChargeCode.Text = grdvCharges.SelectedRow.Cells(1).Text
        'txtChargeName.Text = grdvCharges.SelectedRow.Cells(2).Text
        'txtPercent.Text = grdvCharges.SelectedRow.Cells(3).Text
        'Select Case grdvCharges.SelectedRow.Cells(4).Text
        '    Case "BOTH"
        '        radlistChargeTo.Items(0).Selected = True
        '    Case "SELLER"
        '        radlistChargeTo.Items(1).Selected = True
        '    Case "BUYER"
        '        radlistChargeTo.Items(0).Selected = True
        'End Select
        'Select Case grdvCharges.SelectedRow.Cells(5).Text
        '    Case "PERCENT"
        '        RadioButtonList1.Items(0).Selected = True
        '    Case "FLAT_VALUE"
        '        RadioButtonList1.Items(1).Selected = True
        'End Select
        'Dim cmd1 = New SqlCommand("Delete from  para_billing where ChargeCode = '" & grdvCharges.SelectedRow.Cells(1).Text & "'", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd1.ExecuteNonQuery()
        'cn.Close()
        'FillGrid()
    End Sub
    Public Sub getDetails(ByVal id As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from cds_router.dbo.accounts_clients_web where idnopp = '" & id.ToString() & "'", cn)
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

    Public Sub getClientId(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id As String = (CType(sender, LinkButton)).CommandArgument
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from cds_router.dbo.accounts_clients_web where idnopp = '" & id.ToString() & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                ViewIds(txtClientID.Text)
                'txtIdNo.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                'txtSurnames.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                'txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                'txtmobile.Text = ds.Tables(0).Rows(0).Item("mobile").ToString.ToUpper
                '   rdBonds.Checked = True


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click

    End Sub
    Public Sub ViewIds(ByVal id As String)

        Dim strPopup As String = "<script language='javascript' ID='script1'>" & "window.open('ViewIds.aspx?data=" & HttpUtility.UrlEncode(id.ToString()) & "','new window', 'top=90, left=200, width=1000, height=1000, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=yes, scrollbars=y, toolbar=yes, status=yes, center=yes')" & "</script>"
        ScriptManager.RegisterStartupScript(CType(HttpContext.Current.Handler, Page), GetType(Page), "Script1", strPopup, False)
    End Sub










    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)
        Dim cmd1 = New SqlCommand("insert into Client_InvestorPin_Relation(cds_number,Fund,UTNumber) values('" + txtClientID.Text + "' , '" + cmbFund.SelectedItem.Value + "' , '" + txtInvestorPin.Text + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        msgbox("Update Successful")
        cleardata()
        GETPENDING()
    End Sub
    Public Sub cleardata()
        txtInvestorPin.Text = ""
        txtmobile.Text = ""
        txtForenames.Text = ""
        txtSurnames.Text = ""
        txtIdNo.Text = ""
        txtClientID.Text = ""
    End Sub
    Protected Sub cmbFund_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFund.SelectedIndexChanged
        data.Visible = True
        GETPENDING()
    End Sub
End Class
