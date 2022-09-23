Partial Class CDSUser
    Inherits System.Web.UI.MasterPage
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Dim adp As SqlDataAdapter
    Dim validChars As String = "1"
    Dim strClientIP As String
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        'Page.Controls.Add(lbl)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load







        Dim strpage As String
        strpage = Me.Request.Url.ToString
        Dim strq2 As String = Mid(strpage, InStrRev(strpage, "/") + 1, Len(strpage))

        If strq2 = "CDSHome.aspx" Or strq2 = "settlementbroker.aspx" Or strq2 = "settledrecords.aspx" Or strq2 = "brokeraudit2.aspx" Or strq2 = "settlementnew.aspx" Or strq2 = "mailinglist.aspx" Or strq2 = "settlementbroker.aspx?type=2" Or strq2 = "settlementbroker.aspx?type=1" Or strq2 = "brokeraudit2.aspx?type=2" Or strq2 = "mailinglist.aspx?type=2" Or strq2 = "Auditlog2.aspx" Or strq2 = "brokeraudit.aspx" Or strq2 = "audit.aspx" Then
        Else
            '    trasverse()
        End If



        checksession()

        loadmenus()

        setloggeduser()

        TreeView1.CollapseAll()









    End Sub
    Public Sub loadmenus()
        If Session("menu") = "USER" Then
            Try
                If Not (IsPostBack) Then
                    If ((Session("UserName").ToString) <> "") Then
                        label1.Text = "CDS Access level, " & Session("BrokerCode").ToString & " ," & Session("UserCompany").ToString & " :" & Session("Username").ToString
                        ' If Session("usertype") = "CDSUSER" Then
                        Dim dt As DataTable = Me.GetData("SELECT distinct m2.name, m2.id as id,'' as url  FROM ModuleSubs m, Modules m2 where m.id in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + Session("usertype") + "')) and m.ModuleID=m2.Id ") ' where user_type='CDSUser'")
                            Me.PopulateTreeView(dt, 0, Nothing)
                            'Else
                            '    Dim dt As DataTable = Me.GetData("SELECT distinct m2.name, m2.id as id,'' as url  FROM ModuleSubs m, Modules m2 where m.id in (select moduleid from module_permissions_users where userid=(select id from systemusers where username='" + Session("username") + "')) and m.ModuleID=m2.Id ") ' where user_type='CDSUser'")
                            '    Me.PopulateTreeView(dt, 0, Nothing)
                            'End If

                        Else
                        Response.Redirect("~\loginsystem.aspx")
                        label1.Text = "Please log in with valid credidentials"
                    End If
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        Else
            Try
                If Not (IsPostBack) Then
                    If ((Session("UserName").ToString) <> "") Then
                        label1.Text = "CDS Access level, " & Session("BrokerCode").ToString & " ," & Session("UserCompany").ToString & " :" & Session("Username").ToString
                        Dim dt As DataTable = Me.GetData("SELECT distinct m2.name, m2.id as id,'' as url  FROM ModuleSubs m, Modules m2 where m.id in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + Session("usertype") + "')) and m.ModuleID=m2.Id ") ' where user_type='CDSUser'")
                        Me.PopulateTreeView(dt, 0, Nothing)
                    Else
                        Response.Redirect("~\loginsystem.aspx")
                        label1.Text = "Please log in with valid credidentials"
                    End If
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If

    End Sub
    Private Sub PopulateTreeView(dtParent As DataTable, parentId As Integer, treeNode As TreeNode)
        If Session("menu") = "User" Then
            For Each row As DataRow In dtParent.Rows
                Dim child As New TreeNode() With {
                 .Text = row("Name").ToString(),
                 .Value = row("Id").ToString(),
                 .NavigateUrl = row("url").ToString()
                }
                If parentId = 0 Then
                    TreeView1.Nodes.Add(child)

                    Dim dtChild As DataTable = Me.GetData("  SELECT Id, Name, folder+'/'+url as url FROM ModuleSubs WHERE id in (select moduleid from module_permissions_users where userid=(select id from systemusers where username='" + Session("username") + "')) and moduleId = " + child.Value)
                    PopulateTreeView(dtChild, Integer.Parse(child.Value), child)
                Else
                    treeNode.ChildNodes.Add(child)
                End If
            Next

        Else
            For Each row As DataRow In dtParent.Rows
                Dim child As New TreeNode() With {
                 .Text = row("Name").ToString(),
                 .Value = row("Id").ToString(),
                 .NavigateUrl = row("url").ToString()
                }
                If parentId = 0 Then
                    TreeView1.Nodes.Add(child)
                    Dim dtChild As DataTable = Me.GetData("  SELECT Id, Name, folder+'/'+url as url FROM ModuleSubs WHERE id in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + Session("usertype") + "')) and moduleId = " + child.Value)
                    PopulateTreeView(dtChild, Integer.Parse(child.Value), child)
                Else
                    treeNode.ChildNodes.Add(child)
                End If
            Next
        End If

    End Sub

    Private Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("conpath").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function


    Public Sub MOVESHARES()
        cmd = New SqlCommand("insert into trans select company, tocdsnumber, getdate(), getdate(), quantity, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0  insert into trans select company, fromcdsnumber, getdate(), getdate(), quantity*-1, 'DEAL','SETTLEMENT', '0', 'D', '0', '' FROM tbl_units_move where status=0", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub clossession()
        cmd = New SqlCommand("update systemusers set Active_session='' where username='" + Session("username") + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub finish()
        cmd = New SqlCommand("update tbl_units_move set status='1' where status='0'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Public Sub trasverse()
        '   Try
        Dim strpage As String
        strpage = Me.Request.Url.ToString
        Dim strq As String = Mid(strpage, InStrRev(strpage, "/") + 1, Len(strpage))
        If Session("menu") = "User" Then
            Dim ds As New DataSet
            cmd = New SqlCommand("  SELECT Id, Name, folder+'/'+url as url FROM ModuleSubs WHERE id in (select moduleid from module_permissions_users where userid=(select id from systemusers where username='" + Session("username") + "')) and url like '%" + strq + "%' union select 301 as id, '' as name, form from para_transverse where form like '%" + strq + "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_SettlementSummary2")
            If (ds.Tables(0).Rows.Count > 0) Then
            Else
                Session.Abandon()
                Response.Redirect("~/loginsystem.aspx")
            End If
        Else
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Id, Name, folder+'/'+url as url FROM ModuleSubs WHERE id in (select moduleid from module_permissions where roleid=(select role_id from modules_roles where rolename+''+[type]='" + Session("usertype") + "')) and url like '%" + strq + "%' union select 301 as id, '' as name, form from para_transverse where form like '%" + strq + "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_SettlementSummary2")
            If (ds.Tables(0).Rows.Count > 0) Then

            Else
                Session.Abandon()
                Response.Redirect("~/loginsystem.aspx")

            End If
        End If

    End Sub
    Public Sub GetMaturedRec()
        '   Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select company, tocdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.tocdsnumber) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.tocdsnumber and company=tbl_units_move.company) as newbalance, quantity  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds.Tables("tbl_SettlementSummary").Rows(i).Item("mobile") & "&message_body=Your Buy Order is complete and your CDS Account has been credited with  " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds.Tables("tbl_SettlementSummary").Rows(i).Item("newbalance").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                request.Method = "POST"
                request.ContentLength = 0
                Dim responseContent As String
                Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                    Using reader = New System.IO.StreamReader(response.GetResponseStream())
                        responseContent = reader.ReadToEnd()
                    End Using
                End Using
            Next
        End If

    End Sub
    Public Sub Getsells()
        '   Try
        Dim ds2 As New DataSet
        cmd = New SqlCommand("select company, fromcdsnumber, (select MOBILE from Accounts_Clients where cds_number=tbl_units_move.fromcdsnumber ) as mobile, (select sum(shares) from trans where CDS_Number=tbl_units_move.fromcdsnumber  and company=tbl_units_move.company) as newbalance, quantity  FROM tbl_units_move where status=0", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds2, "tbl_SettlementSummary2")
        If (ds2.Tables(0).Rows.Count > 0) Then
            Dim i As Integer = 0
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                Dim request = TryCast(System.Net.WebRequest.Create("http://45.55.246.121:8083/api/send?id=m6brnkdgdhti7kc6d3ea&secret=cdd065d4a323f21d097521348864ccdc&message_from=mAKIBA&message_to=" & ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("mobile") & "&message_body=Your Sell Order is complete and your CDS Account has been debited with  " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("quantity").ToString + " Bond Notes. Your new Balance is " + ds2.Tables("tbl_SettlementSummary2").Rows(i).Item("newbalance").ToString + " Bond Notes&delivery_time=1 day&delivery_report=1&priority=0"), System.Net.HttpWebRequest)
                request.Method = "POST"
                request.ContentLength = 0
                Dim responseContent As String
                Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                    Using reader = New System.IO.StreamReader(response.GetResponseStream())
                        responseContent = reader.ReadToEnd()
                    End Using
                End Using
            Next
        End If

    End Sub
    Public Sub checksession()
        Try

            Dim ds2 As New DataSet
            cmd = New SqlCommand("select active_session from systemusers where username='" + Session("Username").ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds2, "session")
            If (ds2.Tables(0).Rows.Count > 0) Then
                If Session("Active_Session").ToString <> ds2.Tables(0).Rows(0).Item("active_session") Then
                    Session.Abandon()
                    Response.Cache.SetCacheability(HttpCacheability.NoCache)
                    Response.Buffer = True
                    Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
                    Response.Expires = -1000
                    Response.CacheControl = "no-cache"
                    Response.Redirect("~/loginsystem.aspx", True)
                End If
            End If

        Catch ex As Exception
            Response.Redirect("~/loginsystem.aspx", True)
        End Try

    End Sub
    Public Sub moveord()
        cmd = New SqlCommand("insert into cds.dbo.tbl_units_move select SELLERCDSNO, Buyercdsno, Quantity, '0', BuyCompany, deal, case when (select top 1 indicator from CDS.DBO.para_billing order by id desc)='PERCENT' THEN Quantity*(select top 1 PercentageOrValue/100 from CDS.DBO.para_billing order by id desc) ELSE (select top 1 PercentageOrValue from CDS.DBO.para_billing order by id desc) END AS [CHARGE], (select top 1 ChargeCode from CDS.DBO.para_billing order by id desc)   FROM testcds.dbo.Tbl_MatchedOrders where deal not in (select deal from cds.dbo.tbl_units_move) UPDATE  testcds.dbo.Tbl_MatchedOrders SET dealflag='C' where deal in (select deal from cds.dbo.tbl_units_move)", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub setloggeduser()
        Dim ds As New DataSet
        cmd = New SqlCommand("select username, company, Companytype+' '+Accounttype as [AccountType], isnull(Surname,'')+' '+isnull(forenames,'') as [Names] from SystemUsers where id='" + Session("newid") + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_SettlementSummary2")
        If (ds.Tables(0).Rows.Count > 0) Then
            label1.Text = "User: " + StrConv(ds.Tables(0).Rows(0).Item("username"), vbProperCase)
            lblrole.Text = "Role: " + StrConv(ds.Tables(0).Rows(0).Item("AccountType"), vbProperCase)
            lbldate.Text = "Company: " + StrConv(ds.Tables(0).Rows(0).Item("Company"), vbProperCase)
        End If
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        clossession()

        Session.Abandon()
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
        Response.Expires = -1000
        Response.CacheControl = "no-cache"
        Response.Redirect("~/loginsystem.aspx", True)
    End Sub
    Protected Sub image2_Click(sender As Object, e As ImageClickEventArgs) Handles image2.Click
        'Response.Redirect("~/CDSMode/cdshome.aspx")
    End Sub
    Protected Sub Image1_Click(sender As Object, e As ImageClickEventArgs) Handles Image1.Click
        Response.Redirect("~/CDSMode/cdshome.aspx")
    End Sub
End Class

