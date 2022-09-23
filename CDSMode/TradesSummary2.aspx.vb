Partial Class CDSMode_TradesSummary2
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter

    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

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
        Try
            If (Not IsPostBack) Then
                getcompany()
                hidecontrols()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub hidecontrols()
        Try
            Label1.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            BasicDatePicker1.Visible = False
            BasicDatePicker2.Visible = False
            Label2.Visible = False
            cmbCompany.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate.CheckedChanged
        Try
            hidecontrols()
            If (rdDate.Checked = True) Then
                Label1.Visible = True
                Label6.Visible = True
                Label7.Visible = True
                BasicDatePicker1.Visible = True
                BasicDatePicker2.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdDate1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDate1.CheckedChanged
        Try
            hidecontrols()
            If (rdDate1.Checked = True) Then
                Label2.Visible = True
                cmbCompany.Visible = True
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct (company) from TblSettlementData where updateflag=1", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "tblsettlementData")
                If (ds.Tables(0).Rows.Count > 0) Then
                    cmbCompany.DataSource = ds.Tables(0)
                    cmbCompany.DataValueField = "company"
                    cmbCompany.DataBind()
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If (rdDate.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('ATSTradesSummary.aspx?Date1=" & BasicDatePicker1.Text & "&Date2=" & BasicDatePicker2.Text & "&RepType=1');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If

            If (rdDate1.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('ATSTradesSummary.aspx?company=" & BasicDatePicker1.Text & "&RepType=2');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
