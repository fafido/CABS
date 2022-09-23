
Partial Class Reporting_namesaudit
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
            Session("par_cdsno") = lstSearchAcc.SelectedItem.Value.ToString
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('ClientHoldingReport.aspx?tp=namesaudit');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                lstSearchAcc.Items.Clear()
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number, left(cds_number,100)+' '+surname+ ' '+forenames as namess from names where cds_number+' '+surname+ ' '+forenames+' '+cellphone like '%" & txtSeachName.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstSearchAcc.DataSource = ds.Tables(0)
                    lstSearchAcc.TextField = "namess"
                    lstSearchAcc.ValueField = "cds_number"
                    lstSearchAcc.DataBind()
                Else
                    lstSearchAcc.Items.Clear()
                End If
            ElseIf Session("Companytype") = "CUSTODIAN" Then

                lstSearchAcc.Items.Clear()
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number, left(cds_number,100)+' '+surname+ ' '+forenames as namess from Accounts_clients where cds_number+' '+surname+ ' '+forenames+' '+tel like '%" & txtSeachName.Text & "%'  and Custodian='" + Session("BrokerCode") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstSearchAcc.DataSource = ds.Tables(0)
                    lstSearchAcc.TextField = "namess"
                    lstSearchAcc.ValueField = "cds_number"
                    lstSearchAcc.DataBind()
                Else
                    lstSearchAcc.Items.Clear()
                End If

            Else

                lstSearchAcc.Items.Clear()
                lblCDsAccount.Text = ""
                lblCDsNumber.Text = ""
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number,  cds_number+' '+surname+ ' '+forenames as namess from names where cds_number+' '+surname+ ' '+forenames+' '+cellphone like '%" & txtSeachName.Text & "%' and Broker_code='" + Session("BrokerCode") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstSearchAcc.DataSource = ds.Tables(0)
                    lstSearchAcc.TextField = "namess"
                    lstSearchAcc.ValueField = "cds_number"
                    lstSearchAcc.DataBind()
                Else
                    lstSearchAcc.Items.Clear()
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, LEFT(CDS_NUMBER,100) AS CDS_NUMBER from Accounts_clients where LEFT(cds_number,100)+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "trns")
                    If ds1.Tables("trns").Rows.Count > 0 Then
                        'ASPxComboBox1.DataSource = ds1
                        'ASPxComboBox1.TextField = "company"
                        'ASPxComboBox1.DataBind()
                    End If

                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, CDS_NUMBER AS CDS_NUMBER from names where cds_number+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "trns")
                    If ds1.Tables("trns").Rows.Count > 0 Then
                        'ASPxComboBox1.DataSource = ds1
                        'ASPxComboBox1.TextField = "company"
                        'ASPxComboBox1.DataBind()
                    End If

                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrint0_Click(sender As Object, e As EventArgs) Handles btnPrint0.Click
        Response.Redirect(Request.RawUrl)
    End Sub
End Class
