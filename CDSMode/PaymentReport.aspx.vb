Imports CrystalDecisions.CrystalReports.Engine
Partial Class CDSMode_PaymentReport
    Inherits System.Web.UI.Page
    Dim myreport As ReportDocument  = New ReportDocument() 
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'CrystalReportViewer1.ReportSource = DirectCast(Session("Report"), CrystalDecisions.CrystalReports.Engine.ReportDocument)
            '            myreport.Close()
            '            myreport.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
       ' Try
            Dim datefrom As String = ddateFrom.Text
            Dim dateto As String = ddateTo.Text

'            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("PaymentReport.rpt"))


            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

            Session("pdateto") = dateto
            Session("pdatefrom") = datefrom
            Session("Report") = myreport

            CrystalReportViewer1.ReportSource = Session("Report")

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim userName1 As String = Session("pdateto").ToString()
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

            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
'        Catch ex As Exception
'            msgbox(ex.Message)
'            Exit Sub
'        End Try
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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        If Not IsPostBack Then
            If CrystalReportViewer1 IsNot Nothing Then
                CrystalReportViewer1.Dispose()
            End If
            CrystalReportViewer1 = Nothing

            If myreport IsNot Nothing Then
                myreport.Close()
                myreport.Dispose()
            End If
            myreport = Nothing
            GC.Collect()
        End If

    End Sub

End Class
