﻿
Partial Class CashTransfer
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
            If Session("finish") = "True" Then
                Session("finish") = ""
                msgbox("Transfer successfully captured. Awaiting Approval")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  loadassetmanagers()
                Dim mindate As Date = DateAdd(DateInterval.Day, -2, Date.UtcNow)
                txtvaluedate.MinDate = mindate
                Dim maxdate As Date = Date.UtcNow
                txtvaluedate.MaxDate = maxdate

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Function AssetManager(clientno As String, bankaccount As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select AssetManager, Currency  from Client_AssetManagers where ClientNo='" + clientno + "' and BankAccount='" + cmbassetmanager.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("AssetManager").ToString
        Else
            Return ""
        End If

    End Function
    Private Function Currency(clientno As String, bankaccount As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select AssetManager, Currency  from Client_AssetManagers where ClientNo='" + clientno + "' and BankAccount='" + cmbassetmanager.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("Currency").ToString
        Else
            Return ""
        End If

    End Function

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            Dim avamt As Decimal = txtavailableaamt.Text
            Dim transamt As Decimal = txttransferamt.Text

            If transamt > avamt Then
                msgbox("You cannot transfer amount more than the available amount!")
                Exit Sub
            End If


            cmd = New SqlCommand(" insert into Cashtransfer (CreatedBy, TransactionID, DateCreated, ValueDate, ReAllocateTo,Amount, Available_at_Transfer, FromAccount, BankAccount, AssetManager,Currency,Narration)  values  ('" + Session("Username") + "','0',getdate(), '" + txtvaluedate.Date + "','" + lstreceiver.SelectedItem.Value.ToString + "','" + txttransferamt.Text + "','" + txtavailableaamt.Text + "','" + lstSearchAcc.SelectedItem.Value.ToString + "','" + cmbassetmanager.SelectedItem.Value.ToString + "','" + AssetManager(lstSearchAcc.SelectedItem.Value.ToString, cmbassetmanager.SelectedItem.Value.ToString) + "','" + Currency(lstSearchAcc.SelectedItem.Value.ToString, cmbassetmanager.SelectedItem.Value.ToString) + "','" + txtnarration.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()



            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Transfered cash", "", "")
            Catch ex As Exception

            End Try

            Session("finish") = "True"
            Response.Redirect(Request.RawUrl)


        Catch ex As Exception
            msgbox(ex.Message)
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
            cmbassetmanager.Items.Clear()
            cmbassetmanager.SelectedIndex = -1

            loadcomboforassetmanagers(lstSearchAcc.SelectedItem.Value.ToString)

            loadamountavailableondate()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Sub loadcomboforassetmanagers(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from (select 2 as NR,  c.BankAccount as code, p.AssetMananger+' '+c.BankAccount+' '+c.Currency as fnam from client_AssetManagers c, para_AssetManager p where clientNo='" + holder + "' and p.AssetManagerCode=c.AssetManager) j order by j.nr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbassetmanager.DataSource = dsport
            cmbassetmanager.TextField = "fnam"
            cmbassetmanager.ValueField = "code"
            cmbassetmanager.DataBind()

        End If
    End Sub

    Public Sub loadassetmanagers()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from (select 2 as NR,  c.BankAccount as code, p.AssetMananger+' '+c.BankAccount+' '+c.Currency as fnam from para_assetManager) j order by j.nr ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbassetmanager.DataSource = dsport
            cmbassetmanager.TextField = "fnam"
            cmbassetmanager.ValueField = "code"
            cmbassetmanager.DataBind()


        End If
    End Sub
    Public Function alreadyallocated(id As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from Reallocations where transactionID='" + id + "' AND ApprovedBy IS NULL and Rejected is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub cmbassetmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbassetmanager.SelectedIndexChanged
        Try
            loadamountavailableondate()
            lstreceiver.SelectedIndex = -1
            lstreceiver.Items.Clear()

        Catch ex As Exception

        End Try


    End Sub
    Public Sub loadamountavailableondate()

        Try

            Dim dsport As New DataSet


            cmd = New SqlCommand("select isnull(sum(amount),0) as amt from cashtrans where cds_Number='" + lstSearchAcc.SelectedItem.Value.ToString + "' and bankAccount='" + cmbassetmanager.SelectedItem.Value.ToString + "'  and convert(date, datecreated)<='" + txtvaluedate.Date.ToString + "'", cn)


            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then

                txtavailableaamt.Text = dsport.Tables(0).Rows(0).Item("amt").ToString
            Else
                txtavailableaamt.Text = 0
            End If


        Catch ex As Exception
            txtavailableaamt.Text = 0
        End Try
    End Sub
    Protected Sub btnSearch0_Click(sender As Object, e As EventArgs) Handles btnSearch0.Click
        Try


            Dim ds As New DataSet

            cmd = New SqlCommand("select cds_Number+' '+Name  as name, cds_number from (select forenames+' '+surname as [Name], CDS_Number, Add_1 as add1, Add_2 as add2 from Accounts_Clients) j where j.name+''+j.cds_number like '%" + txtSeachName0.Text + "%' AND CDS_number in (select clientno  from Client_AssetManagers where BankAccount='" + cmbassetmanager.SelectedItem.Value.ToString + "') order by cds_number", cn)



            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstreceiver.DataSource = ds.Tables(0)
                lstreceiver.TextField = "name"
                lstreceiver.ValueField = "cds_number"
                lstreceiver.DataBind()
            Else
                lstreceiver.Items.Clear()
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub txtvaluedate_DateChanged(sender As Object, e As EventArgs) Handles txtvaluedate.DateChanged
        loadamountavailableondate()

    End Sub
End Class
