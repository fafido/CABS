Partial Class CDSMode_UserPermissions
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
            GetParticipants()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Rolename+''+type as rolename from modules_roles order by rolename", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.DataSource = ds.Tables(0)
                cmbParticipants.DataValueField = "ROLENAME"
                cmbParticipants.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getmenus()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select [Name], id from modules WHERE CLIENT='CABS' order by Name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbmenu.DataSource = ds.Tables(0)
                cmbmenu.DataValueField = "id"
                cmbmenu.DataTextField = "Name"
                cmbmenu.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getaallpermissions_menu(moduleid As String)

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name, +'~/'+folder+'/'+url as Url, (select [Name] from modules where id=modulesubs.moduleid) as [Main Menu] FROM ModuleSubs where CLIENT='CABS' AND  moduleid='" + moduleid + "' and  id not in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + cmbParticipants.SelectedItem.Text + "')) order by Name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Permissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                Gridview1.DataSource = ds
                Gridview1.DataBind()
            Else
                Gridview1.DataSource = Nothing
                Gridview1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Get_available_permissions_menu(moduleid As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name, +'~/'+folder+'/'+url as Url, (select [Name] from modules where id=modulesubs.moduleid) as [Main Menu] FROM ModuleSubs where CLIENT='CABS' AND   moduleid='" + moduleid + "' and  id in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + cmbParticipants.SelectedItem.Text + "')) order by Name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Permissions2")
            If (ds.Tables(0).Rows.Count > 0) Then
                Gridview2.DataSource = ds
                Gridview2.DataBind()
            Else
                Gridview2.DataSource = Nothing
                Gridview2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getaallpermissions()

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name, +'~/'+folder+'/'+url as Url, (select [Name] from modules where id=modulesubs.moduleid) as [Main Menu] FROM ModuleSubs where CLIENT='CABS' AND  id not in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + cmbParticipants.SelectedItem.Text + "')) and name+''+url like '%" + txtsearch.Text + "%' order by Name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Permissions")
            If (ds.Tables(0).Rows.Count > 0) Then
                GridView1.DataSource = ds
                GridView1.DataBind()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Get_available_permissions()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name, +'~/'+folder+'/'+url as Url, (select [Name] from modules where id=modulesubs.moduleid) as [Main Menu] FROM ModuleSubs where CLIENT='CABS' AND  id in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + cmbParticipants.SelectedItem.Text + "'))  and name+''+url like '%" + txtsearch.Text + "%' order by Name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Permissions2")
            If (ds.Tables(0).Rows.Count > 0) Then
                GridView2.DataSource = ds
                GridView2.DataBind()
            Else
                GridView2.DataSource = Nothing
                GridView2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                GetParticipants()
                Getmenus()
                Get_available_permissions_menu(cmbmenu.SelectedValue.ToString)
                Getaallpermissions_menu(cmbmenu.SelectedValue.ToString)


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        Try
            Get_available_permissions_menu(cmbmenu.SelectedValue.ToString)
            Getaallpermissions_menu(cmbmenu.SelectedValue.ToString)


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        ' Dim stmnt As String = "insert into module_permissions values (''" + Gridview1.SelectedValue.ToString + "'',  (select role_id from modules_roles where rolename++type=''" + cmbParticipants.SelectedItem.Text + "''))"
        cmd = New SqlCommand("insert into module_permissions values ('" + Gridview1.SelectedValue.ToString + "',  (select role_id from modules_roles where rolename++type='" + cmbParticipants.SelectedItem.Text + "'))", cn)
        ' cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('Permission added for " + cmbParticipants.SelectedItem.Text + ". Permission is " + Gridview1.SelectedRow.Cells(0).Text + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','Pemission Added')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Get_available_permissions_menu(cmbmenu.SelectedValue.ToString)
        Getaallpermissions_menu(cmbmenu.SelectedValue.ToString)
        ' msgbox("Permission Added now waiting for Authorization")
        '  msgbox(Gridview1.SelectedRow.Cells(0).Text)
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        '  Dim stmnt As String = "delete from module_permissions where moduleid=''" + Gridview2.SelectedValue.ToString + "'' and  roleid= (select role_id from modules_roles where rolename++type=''" + cmbParticipants.SelectedItem.Text + "'')"
        cmd = New SqlCommand("delete from module_permissions where moduleid='" + Gridview2.SelectedValue.ToString + "' and  roleid= (select role_id from modules_roles where rolename++type='" + cmbParticipants.SelectedItem.Text + "')", cn)

        ' cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('Permission removed for " + cmbParticipants.SelectedItem.Text + ". Permission is " + Gridview2.SelectedRow.Cells(0).Text + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','Pemission Added')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Get_available_permissions_menu(cmbmenu.SelectedValue.ToString)
        Getaallpermissions_menu(cmbmenu.SelectedValue.ToString)
        '   msgbox("Permission removed for now waiting for Authorization")
    End Sub


    Protected Sub cmbmenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmenu.SelectedIndexChanged
        Get_available_permissions_menu(cmbmenu.SelectedValue.ToString)
        Getaallpermissions_menu(cmbmenu.SelectedValue.ToString)
    End Sub
    Protected Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Getaallpermissions()
        Get_available_permissions()

    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtsearch.Text = ""
        Get_available_permissions_menu(cmbmenu.SelectedValue.ToString)
        Getaallpermissions_menu(cmbmenu.SelectedValue.ToString)
    End Sub


End Class

