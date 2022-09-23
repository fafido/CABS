Partial Class CDSMode_LoginTrail2
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim com As String
    Dim datefrom As String
    Dim dateto As String
    Dim UserId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            com = CStr(Request.QueryString("company"))
            
            UserId = Request.QueryString("UserId")

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("UserLoginTrail2.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pcompany"
            myDiscreteValue.Value = com
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField1.ParameterFieldName = "pdatefrom"
            'myDiscreteValue1.Value = datefrom
            'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            'myParameterFields.Add(myParameterField1)

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "puserId"
            myDiscreteValue1.Value = UserId
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            'Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField2.ParameterFieldName = "pdateto"
            'myDiscreteValue2.Value = dateto
            'myParameterField2.CurrentValues.Add(myDiscreteValue2)
            'myParameterFields.Add(myParameterField2)



            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
