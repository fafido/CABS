
Partial Class Reporting_ClientBill
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
                RadioButtonList1.SelectedIndex = 0
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            Dim group As String
            If RadioButtonList1.SelectedIndex = 0 Then
                group = "0"
            Else
                group = "1"
            End If


            Session("par_cdsno") = lstSearchAcc.SelectedItem.Value.ToString

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Viewed Money Statement", lstSearchAcc.SelectedItem.Value.ToString, "")
            Catch ex As Exception

            End Try

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('ClientBillReport.aspx?Datefrom=" & txtDateFrom.Text & "&Dateto=" & txtDateTo.Text & "&AssetManager=ALL&Group=" + group + "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

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
            If RadioButtonList1.SelectedIndex = 0 Then
                cmd = New SqlCommand("select cds_Number+' '+Name  as name, cds_number from (select forenames+' '+surname as [Name], CDS_Number, Add_1 as add1, Add_2 as add2 from Accounts_Clients union select company_name as [Name], company_code as CDS_Number, Adress_1 as add1 , Adress_2 as add2  from Client_Companies) j where j.name+''+j.cds_number like '%" + txtSeachName.Text + "%' order by cds_number", cn)
            Else
                cmd = New SqlCommand("  select groupname as name, groupcode as cds_number from para_BillingGroups  where Groupcode+' '+groupname like '%" + txtSeachName.Text + "%'", cn)
            End If





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


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    'Public Sub loadcomboforassetmanagers(holder As String)
    '    Dim dsport As New DataSet
    '    cmd = New SqlCommand("select c.AssetManager as code, p.AssetMananger from client_AssetManagers c, para_AssetManager p where clientNo='" + holder + "' and p.AssetManagerCode=c.AssetManager", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(dsport, "trans")
    '    If (dsport.Tables(0).Rows.Count > 0) Then
    '        cmbassetmanager.DataSource = dsport
    '        cmbassetmanager.TextField = "AssetMananger"
    '        cmbassetmanager.ValueField = "code"
    '        cmbassetmanager.DataBind()

    '    End If
    'End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub

End Class
