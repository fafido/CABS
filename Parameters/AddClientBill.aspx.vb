
Partial Class Reporting_AddClientBill
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
            If Session("finish") = "true" Then
                Session("finish") = ""

                msgbox("Client Successfully added to Billing Group")
            End If
            If Session("finish") = "true1" Then
                Session("finish") = ""

                msgbox("Client Successfully Removed from Billing Group")
            End If

            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                loadcomboforassetmanagers()

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If btnPrint.Text = "Add Account" Then
                insertdata("insert into ClientGroups (GroupCode, ClientNo, DateAdded, AddedBy) values ('" + cmbbillgroup.SelectedItem.Value.ToString + "','" + lstSearchAcc.SelectedItem.Value.ToString + "',getdate(),'" + Session("Username") + "')")
                Session("finish") = "true"
                Response.Redirect(Request.RawUrl)
            Else
                insertdata("delete from ClientGroups where groupcode = '" + cmbbillgroup.SelectedItem.Value.ToString + "' and ClientNo='" + lstSearchAcc.SelectedItem.Value.ToString + "'")
                Session("finish") = "true1"
                Response.Redirect(Request.RawUrl)
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

            cmd = New SqlCommand("select cds_Number+' '+Name  as name, cds_number from (select forenames+' '+surname as [Name], CDS_Number, Add_1 as add1, Add_2 as add2 from Accounts_Clients union select company_name as [Name], company_code as CDS_Number, Adress_1 as add1 , Adress_2 as add2  from Client_Companies) j where j.name+''+j.cds_number like '%" + txtSeachName.Text + "%' order by cds_number", cn)



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


    Public Sub loadcomboforassetmanagers()
        Dim dsport As New DataSet
        cmd = New SqlCommand(" select groupname, groupcode from para_BillingGroups ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbbillgroup.DataSource = dsport
            cmbbillgroup.TextField = "groupname"
            cmbbillgroup.ValueField = "groupcode"
            cmbbillgroup.DataBind()

            cmbbillgroupselect.DataSource = dsport
            cmbbillgroupselect.TextField = "groupname"
            cmbbillgroupselect.ValueField = "groupcode"
            cmbbillgroupselect.DataBind()

        End If
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Function accexist(clientno As String, groupcode As String) As Boolean
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from ClientGroups where clientNo='" + clientno + "' and GroupCode='" + groupcode + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub selectgroupdata(group As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select c.ClientNo as [Client No], pbg.GroupName, ac.Surname+' '+ac.Forenames as [Names], c.DateAdded, c.AddedBy  from ClientGroups C, Accounts_Clients AC, para_BillingGroups pbg where pbg.GroupCode=c.GroupCode and ac.CDS_Number=c.ClientNo and c.GroupCode='" + group + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = dsport
            ASPxGridView2.DataBind()
        Else
            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()
        End If

    End Sub
    Protected Sub cmbassetmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbillgroup.SelectedIndexChanged
        controlbuttontext()
    End Sub
    Public Sub controlbuttontext()
        Try
            If accexist(lstSearchAcc.SelectedItem.Value, cmbbillgroup.SelectedItem.Value.ToString) = True Then
                btnPrint.Text = "Remove Account"
            Else
                btnPrint.Text = "Add Account"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub insertdata(qry As String)
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Using cmd As New SqlCommand(qry, cn)
                If cn.State = ConnectionState.Open Then cn.Close()
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            End Using
        End Using
    End Sub
    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        controlbuttontext()

    End Sub
    Protected Sub cmbbillgroupselect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbillgroupselect.SelectedIndexChanged
        Try
            selectgroupdata(cmbbillgroupselect.SelectedItem.Value)
        Catch ex As Exception

        End Try
    End Sub
End Class
