
Partial Class Reports_Normal_companystatsreport
    Inherits System.Web.UI.Page
    Dim cnstr As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
    Dim cmd As SqlCommand
    Dim cn As SqlConnection
    Dim adp As SqlDataAdapter
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            myreport.Close()
            myreport.Dispose()
            GC.Collect()
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
        Page.MaintainScrollPositionOnPostBack = True
        Dim checkvalue As String = Request.QueryString("checkvalue")
        Dim dateval As String = Request.QueryString("date")
        ' Dim dateval As String = "09/09/2007"
        Dim com As String = Request.QueryString("company")
        Dim ds As New DataSet
        Dim str, str1, str2 As String
        Try
            If (checkvalue = "C") Then
                ''str = "select * from country,stats_active where country.company='" & cmbCompany.SelectedItem.Text & "' and country.company=stats_active.company and stats_active.date_created <='" & dtpDate.Text & "'"


                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsCountry.rpt"))


                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pcompany"
                myDiscreteValue.Value = com
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)
                Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField1.ParameterFieldName = "pdate"
                myDiscreteValue1.Value = dateval
                myParameterField1.CurrentValues.Add(myDiscreteValue1)
                myParameterFields.Add(myParameterField1)




                CrystalReportViewer1.ReportSource = myReport
                Dim sdmail As New sendmail
                myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()

                'str = "select country.country,country.tot_shares,country.holders from country,stats_active,mast where stats_active.company='" & com & "' and country.company=stats_active.company and mast.date_created <='" & dateval & "'and mast.shareholder=stats_active.shareholder and mast.company=country.company group by country.country,country.tot_shares,country.holders"
                'cn = New SqlConnection(cnstr)
                'cmd = New SqlCommand(str, cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(ds, "country")
                'Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                'myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsCountry.rpt"))
                'myReport.SetDataSource(ds.Tables(0))
                'CrystalReportViewer1.ReportSource = myReport
                'myReport.Refresh()
            ElseIf (checkvalue = "I") Then

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsIndustry.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pcompany"
                myDiscreteValue.Value = com
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)
                Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField1.ParameterFieldName = "pdate"
                myDiscreteValue1.Value = dateval
                myParameterField1.CurrentValues.Add(myDiscreteValue1)
                myParameterFields.Add(myParameterField1)




                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()
                ''str1 = "select industry. from industry where company='" & cmbCompany.SelectedItem.Text & "' and date_created <='" & dtpDate.Text & "'"
                'str1 = "select industry.industry,industry.tot_shares,industry.holders from industry,stats_active,mast where stats_active.company='" & com & "' and industry.company=stats_active.company and mast.date_created <='" & dateval & "' and mast.shareholder=stats_active.shareholder and mast.company=industry.company group by industry.industry,industry.tot_shares,industry.holders"
                'cn = New SqlConnection(cnstr)
                'cmd = New SqlCommand(str1, cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(ds, "industry")
                'Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                'myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsIndustry.rpt"))
                'myReport.SetDataSource(ds.Tables(0))
                'CrystalReportViewer1.ReportSource = myReport
                'myReport.Refresh()
            ElseIf (checkvalue = "S") Then
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsShareHolding.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pcompany"
                myDiscreteValue.Value = com
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)
                Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField1.ParameterFieldName = "pdate"
                myDiscreteValue1.Value = dateval
                myParameterField1.CurrentValues.Add(myDiscreteValue1)
                myParameterFields.Add(myParameterField1)




                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()

                ''str2 = "select * from ranges where company='" & cmbCompany.SelectedItem.Text & "' and date_created <='" & dtpDate.Text & "'"
                'str2 = "select ranges.range_number,ranges.range_desc,ranges.ashares,ranges.holders from ranges,stats_active,mast where stats_active.company='" & com & "' and ranges.company=stats_active.company and mast.date_created <='" & dateval & "' and mast.shareholder=stats_active.shareholder and mast.company=ranges.company group by ranges.range_number,ranges.range_desc,ranges.ashares,ranges.holders order by ranges.range_number"
                'cn = New SqlConnection(cnstr)
                'cmd = New SqlCommand(str2, cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(ds, "ranges")
                'Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                'myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsShareHolding.rpt"))
                'myReport.SetDataSource(ds.Tables(0))
                'CrystalReportViewer1.ReportSource = myReport
                'myReport.Refresh()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

   
End Class
