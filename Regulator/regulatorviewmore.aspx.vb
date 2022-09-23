
Partial Class Reporting_regulatorviewmore
    Inherits System.Web.UI.Page
    Dim com As SqlCommand
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim da As SqlDataAdapter
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Dim a As CrystalDecisions.CrystalReports.Engine.FieldObject
    Dim b As CrystalDecisions.CrystalReports.Engine.TextObject
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            myReport.Close()
            myReport.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim rpttype As String = Request.QueryString("buysell")
            If rpttype = "Buyers" Then
                Dim ds As New DataSet
                Dim datefrom As String = Request.QueryString("DateFrom")
                Dim dateto As String = Request.QueryString("Dateto")
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\topbuyers.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pdatefrom"
                myDiscreteValue.Value = datefrom
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)

                Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField1.ParameterFieldName = "pdateto"
                myDiscreteValue1.Value = dateto
                myParameterField1.CurrentValues.Add(myDiscreteValue1)
                myParameterFields.Add(myParameterField1)



                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "Sellers" Then
                Dim ds As New DataSet
                Dim datefrom As String = Request.QueryString("DateFrom")
                Dim dateto As String = Request.QueryString("Dateto")
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\topsellers.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pdatefrom"
                myDiscreteValue.Value = datefrom
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)

                Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField1.ParameterFieldName = "pdateto"
                myDiscreteValue1.Value = dateto
                myParameterField1.CurrentValues.Add(myDiscreteValue1)
                myParameterFields.Add(myParameterField1)



                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()

            ElseIf rpttype = "participants" Then
                Dim ds As New DataSet
                Dim participants As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\participants.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "ptype"
                myDiscreteValue.Value = participants
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)


                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()

            ElseIf rpttype = "systemusers" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\systemusers.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "ptype"
                myDiscreteValue.Value = systemusers
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)


                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "buys" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Regulator\buys.rpt"))




                CrystalReportViewer1.ReportSource = myReport

                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "sells" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Regulator\sells.rpt"))




                CrystalReportViewer1.ReportSource = myReport

                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "matched" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Regulator\matched.rpt"))




                CrystalReportViewer1.ReportSource = myReport

                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "Lenders" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\lenders.rpt"))




                CrystalReportViewer1.ReportSource = myReport

                CrystalReportViewer1.RefreshReport()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
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
End Class
