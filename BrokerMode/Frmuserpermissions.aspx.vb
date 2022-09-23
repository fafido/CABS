Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_Frmuserpermissions
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
            cmd = New SqlCommand("select Forenames+' '+Surname as name, id from systemusers where company='" + Session("usercompany") + "' and CompanyType+''+AccountType='" + Session("CompanyType") + "User'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.DataSource = ds.Tables(0)
                cmbParticipants.DataTextField = "NAME"
                cmbParticipants.DataValueField = "id"
                cmbParticipants.DataBind()
            End If
        Catch ex As Exception
            Dim ds As New DataSet
            cmd = New SqlCommand("select Forenames+' '+Surname as name, id from systemusers where company='" + Session("usercompany") + "' and CompanyType+''+AccountType='RegulatorUser'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.DataSource = ds.Tables(0)
                cmbParticipants.DataTextField = "NAME"
                cmbParticipants.DataValueField = "id"
                cmbParticipants.DataBind()
            End If
        End Try
    End Sub
    Public Sub Getaallpermissions()
        '   If Session("Companytype") = "BROKER" Then
        Try
                Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name, +'~/'+folder+'/'+url as url FROM ModuleSubs where id in (select moduleid from module_permissions where  roleid=(select role_id from modules_roles where rolename+''+Type='" + Session("CompanyType") + "User')) and id not in (select moduleid from module_permissions_users where userid='" + cmbParticipants.SelectedValue.ToString + "')", cn)
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
        'Else
        '    Try
        '        Dim ds As New DataSet
        '        cmd = New SqlCommand("SELECT Id, Name, +'~/'+folder+'/'+url as url FROM ModuleSubs where id in (select moduleid from module_permissions where  roleid=1004) and id not in (select moduleid from module_permissions_users where userid='" + cmbParticipants.SelectedValue.ToString + "')", cn)
        '        adp = New SqlDataAdapter(cmd)
        '        adp.Fill(ds, "Permissions")
        '        If (ds.Tables(0).Rows.Count > 0) Then
        '            GridView1.DataSource = ds
        '            GridView1.DataBind()
        '        Else
        '            GridView1.DataSource = Nothing
        '            GridView1.DataBind()
        '        End If
        '    Catch ex As Exception
        '        msgbox(ex.Message)
        '    End Try
        'End If

    End Sub
    Public Sub Get_available_permissions()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name,+'~/'+folder+'/'+url as url FROM ModuleSubs where id in (select moduleid from module_permissions_users where userid='" + cmbParticipants.SelectedValue.ToString + "')", cn)
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
                Getaallpermissions()
                Get_available_permissions()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        Try
            Get_available_permissions()
            Getaallpermissions()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gridview1.SelectedIndexChanged
        cmd = New SqlCommand("insert into module_permissions_users values ('" + Gridview1.SelectedValue.ToString + "',  '" + cmbParticipants.SelectedValue.ToString + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Try
            cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Added Permission to a user',0,'','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try
        Get_available_permissions()
        Getaallpermissions()
        msgbox("Permission granted to " + cmbParticipants.SelectedItem.Text + "")
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gridview2.SelectedIndexChanged
        cmd = New SqlCommand("delete from module_permissions_users where moduleid='" + Gridview2.SelectedValue.ToString + "' and  userid='" + cmbParticipants.SelectedValue.ToString + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Try
            cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Removed Permission from a user',0,'','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try


        Get_available_permissions()
        Getaallpermissions()
        msgbox("Permission removed for " + cmbParticipants.SelectedItem.Text + "")
    End Sub
End Class


