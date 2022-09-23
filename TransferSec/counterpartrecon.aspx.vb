Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Counterpartrecon
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
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

        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then

            getbank()
            loadcomboforassetmanagers()
            '  firstcombo()


        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub

    Public Sub loadcomboforassetmanagers()
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from (select 0 as nr,  'ALL' AS code, 'ALL' as AssetMananger union  select 1 as nr, AssetManagerCode as code, p.AssetMananger from  para_AssetManager p) j order by nr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then

            cmbassetmanager0.DataSource = dsport
            cmbassetmanager0.TextField = "AssetMananger"
            cmbassetmanager0.ValueField = "code"
            cmbassetmanager0.DataBind()

        End If
    End Sub
    'Public Sub firstcombo()
    '    Dim dsport As New DataSet
    '    cmd = New SqlCommand("select AssetManagerCode as code, p.AssetMananger from  para_AssetManager p", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(dsport, "trans")
    '    If (dsport.Tables(0).Rows.Count > 0) Then
    '        cmbassetmanager.DataSource = dsport
    '        cmbassetmanager.TextField = "AssetMananger"
    '        cmbassetmanager.ValueField = "code"
    '        cmbassetmanager.DataBind()
    '    End If

    'End Sub
    Public Sub deleteprev(assetmanager As String, company As String, accountnumber As String)
        cmd = New SqlCommand("delete from recon_AssetManager where AssetManager='" + assetmanager + "' and Company='" + company + "' and AccountNumber='" + accountnumber + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub


    Public Sub cleartable()
        cmd = New SqlCommand("truncate table unitAccounts  ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub


    Public Sub getbank()
        cmd = New SqlCommand("select * from ( select 0 as nr,  'ALL' as bank_name, 'ALL' as bank union SELECT 1 as nr , bank_name ,bank  from para_bank) j order by nr", cn)
        adp = New SqlDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        adp.Fill(ds1, "company")
        If ds1.Tables(0).Rows.Count > 0 Then
            cmbbank.DataSource = ds1
            cmbbank.TextField = "bank_name"
            cmbbank.ValueField = "bank"
            cmbbank.DataBind()
        End If
    End Sub

    Private Sub MesgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub


    Protected Sub btnupload0_Click(sender As Object, e As EventArgs) Handles btnupload0.Click
        If RadioButtonList1.SelectedItem.Text = "Un-Authorized" Then

            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            getview()
        End If




    End Sub

    Public Sub getview()

        Try

            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            If cmbassetmanager0.SelectedItem.Text = "ALL" And cmbbank.SelectedItem.Text = "ALL" Then

                cmd = New SqlCommand(" declare @as_at date='" + dtdateview.Date + "' select m.CounterPartBank as [Money Market Counterpart], m.AssetManager  ,isnull(sum(amount),0) as [Money Market Total] , isnull(sum(quantity*price),0) as [Vault Total], case when isnull(sum(amount),0)= isnull(sum(quantity*price),0) then 'Balancing' when isnull(sum(amount),0)<isnull(sum(quantity*price),0) then 'More Money in Vault' when isnull(sum(amount),0)>isnull(sum(quantity*price),0) then 'More Money in Money Market Deals' else 'N/A' end as [Description]   from MoneyMarket m left outer join Deposit_Cert d on d.CounterpartBank=m.CounterPartBank and d.AssetManager=m.AssetManager  and convert(date, d.ApprovedDate)<=@as_at    where TradeStatus='ON-GOING' and convert(date, m.ApprovedDate)<=@as_at  group by m.CounterPartBank , m.AssetManager", cn)

            ElseIf cmbassetmanager0.SelectedItem.Text <> "ALL" And cmbbank.SelectedItem.Text = "ALL" Then

                cmd = New SqlCommand(" declare @as_at date='" + dtdateview.Date + "' select m.CounterPartBank as [Money Market Counterpart], m.AssetManager  ,isnull(sum(amount),0) as [Money Market Total] , isnull(sum(quantity*price),0) as [Vault Total], case when isnull(sum(amount),0)= isnull(sum(quantity*price),0) then 'Balancing' when isnull(sum(amount),0)<isnull(sum(quantity*price),0) then 'More Money in Vault' when isnull(sum(amount),0)>isnull(sum(quantity*price),0) then 'More Money in Money Market Deals' else 'N/A' end as [Description]   from MoneyMarket m left outer join Deposit_Cert d on d.CounterpartBank=m.CounterPartBank and d.AssetManager=m.AssetManager  and convert(date, d.ApprovedDate)<=@as_at    where TradeStatus='ON-GOING' and  m.AssetManager='" + cmbassetmanager0.SelectedItem.Value.ToString + "' and convert(date, m.ApprovedDate)<=@as_at  group by m.CounterPartBank , m.AssetManager", cn)

            ElseIf cmbassetmanager0.SelectedItem.Text <> "ALL" And cmbbank.SelectedItem.Text <> "ALL" Then

                cmd = New SqlCommand(" declare @as_at date='" + dtdateview.Date + "' select m.CounterPartBank as [Money Market Counterpart], m.AssetManager  ,isnull(sum(amount),0) as [Money Market Total] , isnull(sum(quantity*price),0) as [Vault Total], case when isnull(sum(amount),0)= isnull(sum(quantity*price),0) then 'Balancing' when isnull(sum(amount),0)<isnull(sum(quantity*price),0) then 'More Money in Vault' when isnull(sum(amount),0)>isnull(sum(quantity*price),0) then 'More Money in Money Market Deals' else 'N/A' end as [Description]   from MoneyMarket m left outer join Deposit_Cert d on d.CounterpartBank=m.CounterPartBank and d.AssetManager=m.AssetManager  and convert(date, d.ApprovedDate)<=@as_at    where TradeStatus='ON-GOING' and m.CounterPartBank='" + cmbbank.SelectedItem.Value.ToString + "' and m.AssetManager='" + cmbassetmanager0.SelectedItem.Value.ToString + "' and convert(date, m.ApprovedDate)<=@as_at  group by m.CounterPartBank , m.AssetManager", cn)

            ElseIf cmbassetmanager0.SelectedItem.Text = "ALL" And cmbbank.SelectedItem.Text <> "ALL" Then

                cmd = New SqlCommand(" declare @as_at date='" + dtdateview.Date + "' select m.CounterPartBank as [Money Market Counterpart], m.AssetManager  ,isnull(sum(amount),0) as [Money Market Total] , isnull(sum(quantity*price),0) as [Vault Total], case when isnull(sum(amount),0)= isnull(sum(quantity*price),0) then 'Balancing' when isnull(sum(amount),0)<isnull(sum(quantity*price),0) then 'More Money in Vault' when isnull(sum(amount),0)>isnull(sum(quantity*price),0) then 'More Money in Money Market Deals' else 'N/A' end as [Description]   from MoneyMarket m left outer join Deposit_Cert d on d.CounterpartBank=m.CounterPartBank and d.AssetManager=m.AssetManager  and convert(date, d.ApprovedDate)<=@as_at    where TradeStatus='ON-GOING' and m.CounterPartBank='" + cmbbank.SelectedItem.Value.ToString + "'  and convert(date, m.ApprovedDate)<=@as_at  group by m.CounterPartBank , m.AssetManager", cn)


            End If





            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "company")
            If ds1.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds1.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnupload1_Click(sender As Object, e As EventArgs) Handles btnupload1.Click
        ' getview()
        If RadioButtonList1.SelectedItem.Text = "Un-Authorized" Then
            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            getview()
        End If


        ASPxGridViewExporter1.WriteXlsToResponse()


    End Sub
End Class
