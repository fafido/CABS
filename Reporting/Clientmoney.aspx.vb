
Partial Class Reporting_Clientmoney
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
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                loadassetmanagers()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try



            If lstSearchAcc.SelectedIndex = -1 Then
                Session("par_cdsno") = "ALL"
            Else
                Session("par_cdsno") = lstSearchAcc.SelectedItem.Value.ToString
            End If


            Dim recon As String
            If CheckBox1.Checked = True Then
                recon = "1"
            Else
                recon = "0"
            End If

            Dim rep As String
            If Session("usertype") = "CMCAdmin" Or Session("usertype") = "CMCUser" Or Session("usertype") = "CMCADMIN" Or Session("usertype") = "CMCUSER" Then
                rep = "ClientmoneyReport_ADMIN"
            Else
                rep = "ClientmoneyReport"
            End If
            Dim m202 As String = ""
            If CheckBox1.Checked = True Then
                m202 = "1"
            Else
                m202 = "0"
            End If

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Viewed Money Statement", lstSearchAcc.SelectedItem.Value.ToString, "")
            Catch ex As Exception

            End Try

            If cmbbank.SelectedItem.Value = "ALL" Then

                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('" + rep + ".aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&Summarized=" + m202 + "&AssetManager=" + cmbassetmanager.SelectedItem.Value.ToString + "&Recon=" + recon + "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else

                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('" + rep + "Bank.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&Summarized=" + m202 + "&AssetManager=" + cmbassetmanager.SelectedItem.Value.ToString + "&Recon=" + recon + "&BankAccount=" + cmbbank.SelectedItem.Value.ToString + "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If


        Catch ex As Exception
            msgbox("Please select Account!")
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try

            lstSearchAcc.Items.Clear()
            lblCDsAccount.Text = ""
            lblCDsNumber.Text = ""
            Dim ds As New DataSet

            cmd = New SqlCommand("select cds_Number+' '+Name  as name, cds_number from (select forenames+' '+surname as [Name], CDS_Number, Add_1 as add1, Add_2 as add2 from Accounts_Clients) j where j.name+''+j.cds_number like '%" + txtSeachName.Text + "%' order by cds_number", cn)



            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds.Tables(0)
                lstSearchAcc.TextField = "name"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()
            Else
                lstSearchAcc.Items.Clear()
            End If
            'Else
            '    lstSearchAcc.Items.Clear()
            '    lblCDsAccount.Text = ""
            '    lblCDsNumber.Text = ""
            '    Dim ds As New DataSet
            '    cmd = New SqlCommand("select cds_number+' '+surname+ ' '+forenames as namess from names where cds_number+' '+surname+ ' '+forenames+' '+cellphone like '%" & txtSeachName.Text & "%' and Broker_code='" + Session("BrokerCode") + "'", cn)
            '    adp = New SqlDataAdapter(cmd)
            '    adp.Fill(ds, "names")
            '    If (ds.Tables(0).Rows.Count > 0) Then
            '        lstSearchAcc.DataSource = ds.Tables(0)
            '        lstSearchAcc.TextField = "namess"
            '        lstSearchAcc.ValueField = "namess"
            '        lstSearchAcc.DataBind()
            '    Else
            '        lstSearchAcc.Items.Clear()
            '    End If
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        Try

            loadcomboforassetmanagers(lstSearchAcc.SelectedItem.Value.ToString)


        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Sub loadcomboforassetmanagers(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from (SELECT 1 AS NR, 'ALL' as code, 'ALL' as AssetMananger union  select 2 as NR,  c.AssetManager as code, p.AssetMananger from client_AssetManagers c, para_AssetManager p where clientNo='" + holder + "' and p.AssetManagerCode=c.AssetManager) j order by j.nr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbassetmanager.DataSource = dsport
            cmbassetmanager.TextField = "AssetMananger"
            cmbassetmanager.ValueField = "code"
            cmbassetmanager.DataBind()

        End If
    End Sub
    Public Sub loadassetmanagers()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from (select 1 as nr,  'ALL' AS AssetMananger, 'ALL' AS AssetManagerCode union select 2 as nr,  AssetMananger,AssetManagerCode from para_assetManager) j order by j.nr ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbassetmanager.DataSource = dsport
            cmbassetmanager.TextField = "AssetMananger"
            cmbassetmanager.ValueField = "AssetManagerCode"
            cmbassetmanager.DataBind()


        End If
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub cmbassetmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbassetmanager.SelectedIndexChanged

        If cmbassetmanager.SelectedItem.Value.ToString = "ALL" Then
            cmbbank.Items.Add("ALL")
            cmbbank.Value = "ALL"
            CheckBox1.Visible = False
        Else
            If lstSearchAcc.SelectedIndex = -1 Then
                Dim dsport As New DataSet
                cmd = New SqlCommand("select AccountNo+' '+Currency as fnam, accountno as BankAccount from para_assetManager_Banks where AssetManagerCode='" + cmbassetmanager.SelectedItem.Value.ToString + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsport, "trans")
                If (dsport.Tables(0).Rows.Count > 0) Then
                    cmbbank.DataSource = dsport
                    cmbbank.TextField = "fnam"
                    cmbbank.ValueField = "BankAccount"
                    cmbbank.DataBind()

                End If
            Else
                Dim dsport As New DataSet
                cmd = New SqlCommand("select BankName+' '+ BankAccount+' '+Currency as fnam, BankAccount  from Client_AssetManagers where AssetManager='" + cmbassetmanager.SelectedItem.Value.ToString + "' and clientNo='" + lstSearchAcc.SelectedItem.Value.ToString + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsport, "trans")
                If (dsport.Tables(0).Rows.Count > 0) Then
                    cmbbank.DataSource = dsport
                    cmbbank.TextField = "fnam"
                    cmbbank.ValueField = "BankAccount"
                    cmbbank.DataBind()

                End If
            End If

            CheckBox1.Checked = False
            CheckBox1.Visible = True
        End If


    End Sub
    Protected Sub cmbbank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbank.SelectedIndexChanged

    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class
