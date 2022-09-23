
Partial Class Equity_Reporting
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
                getstatus()
                getcompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try
            Dim client As String
            If lstSearchAcc.SelectedIndex = -1 Then

                client = ""
            Else

                client = lstSearchAcc.SelectedItem.Value.ToString
            End If


            Dim rep As String
            If Session("usertype") = "CMCAdmin" Or Session("usertype") = "CMCUser" Or Session("usertype") = "CMCADMIN" Or Session("usertype") = "CMCUSER" Then
                rep = "Equity_Rep"
            Else
                rep = "Equity_Rep"
            End If
       
           

            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('" + rep + ".aspx?datefrom=" & txtDateFrom.Text & "&dateto=" & txtDateTo.Text & "&Type=" + cmbIssuer.Text + "&Company=" + cmbcompany.Text + "&Client=" + client + "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox("Please select Account!")
        End Try
    End Sub
    Public Sub getstatus()
        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct TradeStatus  from Custodian_Trades ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbissuer.datasource = ds
            cmbissuer.Textfield = "tradestatus"
            cmbissuer.databind()

        End If
    End Sub
    Public Sub getcompany()
        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct company  from Custodian_Trades ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbcompany.datasource = ds
            cmbcompany.Textfield = "company"
            cmbcompany.databind()

        End If
    End Sub
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Try


            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+isnull(forenames,'')+' '+isnull(middlename,'')+' '+isnull(surname,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtAccountNo.Text + "%' and AccountState='A' order by cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstSearchAcc.DataSource = ds
                lstSearchAcc.TextField = "names"
                lstSearchAcc.ValueField = "cds_number"
                lstSearchAcc.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
