
Partial Class CDSMode_ATSTradesSummary
    Inherits System.Web.UI.Page
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
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
            Dim RepType As String = Request.QueryString("RepType")
            If (RepType.ToString = "1") Then

                Dim date1 As String = Request.QueryString("date1")
                Dim date2 As String = Request.QueryString("date2")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                myReport.Load(Server.MapPath("ATSTradesSettlement1.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pdate1"
                myDiscreteValue.Value = date1
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)

                Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField1.ParameterFieldName = "pdate2"
                myDiscreteValue1.Value = date2
                myParameterField1.CurrentValues.Add(myDiscreteValue1)
                myParameterFields.Add(myParameterField1)

                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()
            End If


            If (RepType.ToString = "2") Then

                Dim company As String = Request.QueryString("company")
                '                Dim company As String = Request.QueryString("Company")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                myReport.Load(Server.MapPath("NomineeRegisterAll.rpt"))

                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pcompany"
                myDiscreteValue.Value = company
                myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)

                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
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

