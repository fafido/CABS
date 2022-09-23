Partial Class Trading_PostedOrdersReportView
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
        Try

            Dim holderType As String = Request.QueryString("Classfication")
            Dim company As String = Request.QueryString("company")
            Dim Repdate As String = Request.QueryString("RepDate")

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("..\Trading\ClearedOrders.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pcompany"
            myDiscreteValue.Value = company
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "pdate"
            myDiscreteValue1.Value = Repdate
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)


            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "pAppFlag"
            myDiscreteValue2.Value = holderType
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)

            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
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
