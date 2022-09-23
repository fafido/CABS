Partial Class TSecEnquiries_RPTPrintStatementReport
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
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

            Dim company As String = Request.QueryString("company")
            Dim shareholder As String = Request.QueryString("shareholder")

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            myreport.Load(Server.MapPath("..\Cheque Recon\RPTPrint Statement Report.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pcompany"
            myDiscreteValue.Value = company
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField4.ParameterFieldName = "pshareholder"
            myDiscreteValue4.Value = shareholder
            myParameterField4.CurrentValues.Add(myDiscreteValue4)
            myParameterFields.Add(myParameterField4)


            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception

            msgbox(ex.Message)
        End Try


    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            myreport.Close()
            myreport.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class