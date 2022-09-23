
Partial Class CDSMode_DealSettlementSheet
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim datefrom As String = ddateFrom.SelectedValue.ToString()
            Dim dateto As String = ddateTo.SelectedValue.ToString()

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("../Reporting/DealSettlementSheet.rpt"))

            'Session("pdateto") = ddateFrom.SelectedValue.ToString()
            'Session("pdatefrom") = ddateTo.SelectedValue.ToString()
            'Session("Report") = myreport

            'CrystalReportViewer1.ReportSource = myreport
            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            'CrystalReportViewer1.RefreshReport()

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

            Session("pdateto") = dateto
            Session("pdatefrom") = datefrom
            Session("Report") = myreport

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim userName1 As String = Session("pdatefrom").ToString()
            myParameterField1.ParameterFieldName = "pdateto"
            myDiscreteValue1.Value = dateto
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim userName As String = Session("pdatefrom").ToString()
            myParameterField.ParameterFieldName = "pdatefrom"
            myDiscreteValue.Value = datefrom
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField1.ParameterFieldName = "pdateto"
            'myDiscreteValue1.Value = dateto
            'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            'myParameterFields.Add(myParameterField1)

            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField.ParameterFieldName = "pdatefrom"
            'myDiscreteValue.Value = datefrom
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)

            CrystalReportViewer1.ReportSource = Session("Report")
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Try
                CrystalReportViewer1.ReportSource = DirectCast(Session("Report"), CrystalDecisions.CrystalReports.Engine.ReportDocument)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
End Class
