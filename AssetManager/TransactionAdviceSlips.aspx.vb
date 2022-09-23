Partial Class Reporting_TransactionAdviceSlips
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
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
 
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim repType As String = ""
            If (rdPurchaseAdvice.Checked = True) Then
                repType = "P"
            End If
            If (rdSalesAdvice.Checked = True) Then
                repType = "S"
            End If
            If (rdAllAdvice.Checked = True) Then
                repType = "A"
            End If
            If repType = Nothing Then
                msgbox("Please select the report type!")
                Exit Sub
            Else
                If txtDateFrom.Text = "" Then
                    msgbox("Please select the Date from!")
                Else
                    If txtDateTo.Text = "" Then
                        msgbox("Please select the Date to!")
                    End If
                End If
            End If
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('TransactionAdviceReports.aspx?Reptype=" & repType & "&id=" & ASPxComboBox1.SelectedItem.Value.ToString & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click

        If rdSalesAdvice.Checked = True Then
            Dim ds As New DataSet
            If Session("Companytype") = "CDS" Then
                cmd = New SqlCommand("select ac.cds_number+' '+ac.surname+ ' '+ac.forenames+' Deal No:'+convert(nvarchar(50),tb.ID)  as namess, tb.id  from accounts_clients ac, tblMatchedOrders tb where tb.Account2=ac.cds_number and tb.Date_posted between '" + txtDateFrom.Text + "' and '" + txtDateTo.Text + "'  order by tb.id desc", cn)
            Else
                cmd = New SqlCommand("select ac.cds_number+' '+ac.surname+ ' '+ac.forenames+' Deal No:'+convert(nvarchar(50),tb.ID)  as namess, tb.id  from accounts_clients ac, tblMatchedOrders tb where tb.Account2=ac.cds_number and tb.Date_posted between '" + txtDateFrom.Text + "' and '" + txtDateTo.Text + "' AND tb.broker2='" + Session("BrokerCode") + "' order by tb.id desc", cn)

            End If
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "namess"
                ASPxComboBox1.ValueField = "id"
                ASPxComboBox1.DataBind()


            End If


        End If
        If rdPurchaseAdvice.Checked = True Then

            Dim ds As New DataSet
            If Session("Companytype") = "CDS" Then
                cmd = New SqlCommand("select ac.cds_number+' '+ac.surname+ ' '+ac.forenames+' Deal No:'+convert(nvarchar(50),tb.ID)  as namess, tb.id  from accounts_clients ac, tblMatchedOrders tb where tb.Account1=ac.cds_number and tb.Date_posted between '" + txtDateFrom.Text + "' and '" + txtDateTo.Text + "'  order by tb.id desc", cn)
            Else
                cmd = New SqlCommand("select ac.cds_number+' '+ac.surname+ ' '+ac.forenames+' Deal No:'+convert(nvarchar(50),tb.ID)  as namess, tb.id  from accounts_clients ac, tblMatchedOrders tb where tb.Account1=ac.cds_number and tb.Date_posted between '" + txtDateFrom.Text + "' and '" + txtDateTo.Text + "' AND tb.broker1='" + Session("BrokerCode") + "' order by tb.id desc", cn)
            End If
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "namess"
                ASPxComboBox1.ValueField = "id"
                ASPxComboBox1.DataBind()

            End If

        End If
    End Sub
End Class
