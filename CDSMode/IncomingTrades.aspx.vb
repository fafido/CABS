
Partial Class IncomingTrades
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
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

        'Try
        '    ' Dim datefrom As String = Request.QueryString("datefrom")
        '    ' Dim dateto As String = Request.QueryString("dateto")
        '    myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        '    myreport.Load(Server.MapPath("../Reporting/IncomingOrders.rpt"))

        '    'Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
        '    'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
        '    'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        '    'myParameterField1.ParameterFieldName = "pdateto"
        '    'myDiscreteValue1.Value = dateto
        '    'myParameterField1.CurrentValues.Add(myDiscreteValue1)
        '    'myParameterFields.Add(myParameterField1)

        '    'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
        '    'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
        '    'myParameterField.ParameterFieldName = "pdatefrom"
        '    'myDiscreteValue.Value = datefrom
        '    'myParameterField.CurrentValues.Add(myDiscreteValue)
        '    'myParameterFields.Add(myParameterField)

        '    CrystalReportViewer1.ReportSource = myreport
        '    ' CrystalReportViewer1.ParameterFieldInfo = myParameterFields
        '    CrystalReportViewer1.RefreshReport()
        'Catch ex As Exception
        '    msgbox(ex.Message)
        '    Exit Sub
        'End Try

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
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Dim datefrom As String = Request.QueryString("datefrom")
            ' Dim dateto As String = Request.QueryString("dateto")

            Dim datefrom As String = ddateFrom.SelectedValue.ToString()
            Dim dateto As String = ddateTo.SelectedValue.ToString()

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("../Reporting/IncomingOrders.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "pdateto"
            myDiscreteValue1.Value = dateto
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pdatefrom"
            myDiscreteValue.Value = datefrom
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
End Class
