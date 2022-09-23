Partial Class TSecReports_CompanyStats
    Inherits System.Web.UI.Page
    Dim cnstr As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
    Dim cmd As SqlCommand
    Dim cn As SqlConnection
    Dim adp As SqlDataAdapter
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim dmbOb As New BindCombo
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            myreport.Close()
            myreport.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Calendar1.Visible = False
        cmbCompany.Focus()
        Try
            'cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            ' cn = New SqlConnection(cnstr)
            If (Not IsPostBack) Then
                dmbOb.BindCombo("all_companies", "company", cmbCompany)

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
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Dim ds As New DataSet
        'Dim str, str1, str2 As String
        Dim checkval As String = ""
        Dim dateval As String = dtpDateCreated.Text
        Try
            If (rdbCountry.Checked = True) Then
                '        'str = "select * from country,stats_active where country.company='" & cmbCompany.SelectedItem.Text & "' and country.company=stats_active.company and stats_active.date_created <='" & dtpDate.Text & "'"
                '        str = "select country.country,country.tot_shares,country.holders from country,stats_active,mast where stats_active.company='" & cmbCompany.Text & "' and country.company=stats_active.company and mast.date_created <='" & dtpDate.Text & "'and mast.shareholder=stats_active.shareholder and mast.company=country.company group by country.country,country.tot_shares,country.holders"
                '        cn = New SqlConnection(cnstr)
                '        cmd = New SqlCommand(Str, cn)
                '        adp = New SqlDataAdapter(cmd)
                '        adp.Fill(ds, "country")
                '        Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                '        myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsCountry.rpt"))
                '        myReport.SetDataSource(ds.Tables(0))
                '        CrystalReportViewer1.ReportSource = myReport
                '        myReport.Refresh()
                checkval = "C"
            ElseIf (rdbIndustry.Checked = True) Then
                checkval = "I"
                '        'str1 = "select industry. from industry where company='" & cmbCompany.SelectedItem.Text & "' and date_created <='" & dtpDate.Text & "'"
                '        str1 = "select industry.industry,industry.tot_shares,industry.holders from industry,stats_active,mast where stats_active.company='" & cmbCompany.Text & "' and industry.company=stats_active.company and mast.date_created <='" & dtpDate.Text & "' and mast.shareholder=stats_active.shareholder and mast.company=industry.company group by industry.industry,industry.tot_shares,industry.holders"
                '        cn = New SqlConnection(cnstr)
                '        cmd = New SqlCommand(str1, cn)
                '        adp = New SqlDataAdapter(cmd)
                '        adp.Fill(ds, "industry")
                '        Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                '        myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsIndustry.rpt"))
                '        myReport.SetDataSource(ds.Tables(0))
                '        CrystalReportViewer1.ReportSource = myReport
                '        myReport.Refresh()
            ElseIf (rdbShareHolding.Checked = True) Then
                checkval = "S"
                '        'str2 = "select * from ranges where company='" & cmbCompany.SelectedItem.Text & "' and date_created <='" & dtpDate.Text & "'"
                '        str2 = "select ranges.range_number,ranges.range_desc,ranges.ashares,ranges.holders from ranges,stats_active,mast where stats_active.company='" & cmbCompany.Text & "' and ranges.company=stats_active.company and mast.date_created <='" & dtpDate.Text & "' and mast.shareholder=stats_active.shareholder and mast.company=ranges.company group by ranges.range_number,ranges.range_desc,ranges.ashares,ranges.holders"
                '        cn = New SqlConnection(cnstr)
                '        cmd = New SqlCommand(str2, cn)
                '        adp = New SqlDataAdapter(cmd)
                '        adp.Fill(ds, "ranges")
                '        Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                '        myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsShareHolding.rpt"))
                '        myReport.SetDataSource(ds.Tables(0))
                '        CrystalReportViewer1.ReportSource = myReport
                '        myReport.Refresh()
            End If
            Dim strscript As String
            If (dtpDateCreated.Text <> "") Then
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('companystatsreport.aspx?checkvalue=" & checkval & "&date=" & dateval & "&company=" & cmbCompany.SelectedItem.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else
                msgbox("Please Enter The Date")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Calendar1.Visible = False
        dtpDateCreated.Text = Calendar1.SelectedDate
        Calendar1.SelectedDate = Nothing
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Calendar1.Visible = True
    End Sub
End Class
