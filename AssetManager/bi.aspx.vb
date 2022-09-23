
Partial Class Reporting_bi
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand

    Public Sub msgbox(ByVal strMessage As String)
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
    Public Sub loadcompanies()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from (select 1 as ranc,'All' as fnam, 'All' as company union select 2 as ranc, fnam, company from para_company) j order by j.ranc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SystemUsers")

        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxComboBox1.DataSource = ds
            ASPxComboBox1.TextField = "fnam"
            ASPxComboBox1.ValueField = "company"
            ASPxComboBox1.DataBind()
        End If
    End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        If ASPxMemo1.Text <> "" Then
            cmd = New SqlCommand("insert into audit_comments (auditor, report, comment, date_posted) values ('" + Session("newid") + "','BUSINESS REPORTS','" + ASPxMemo1.Text + "',getdate())", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            msgbox("Please enter the comment!")
        End If

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
                checkcomment()
                loadcompanies()
            End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Comment Sent")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkcomment()
        If Session("usertype") <> "AuditAdmin" Then
            ASPxButton5.Visible = False

        Else
            ASPxButton5.Visible = True

        End If
    End Sub
    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        ASPxButton5.Visible = False
        Panel6.Visible = True

    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Panel6.Visible = False
        ASPxButton5.Visible = True
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim strscript As String
        Session("comp") = ASPxComboBox1.SelectedItem.Value.ToString
        strscript = "<script langauage=JavaScript>"
        'strscript += "window.open('HolderClassificationIndividual.aspx?company=" & cmbCompany.Text & "&Classfication=" & ClassType & "');"
        If Session("Companytype") = "CUSTODIAN" Then
            strscript += "window.open('Dashboard/dash.aspx?Classfication=0&company=" + ASPxComboBox1.SelectedItem.Value.ToString + "&Custodian=" + Session("Brokercode") + "');"
        Else
            strscript += "window.open('Dashboard/dashadmin.aspx?Classfication=0&company=" + ASPxComboBox1.SelectedItem.Value.ToString + "&Custodian=" + Session("Brokercode") + "');"
        End If

        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)


    End Sub
End Class
