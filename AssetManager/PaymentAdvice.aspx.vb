
Partial Class Reporting_PaymentAdvice
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Try
                CrystalReportViewer1.ReportSource = DirectCast(Session("Report"), CrystalDecisions.CrystalReports.Engine.ReportDocument)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim datefrom As String = ddateFrom.SelectedValue.ToString()
            Dim dateto As String = ddateTo.SelectedValue.ToString()
            Dim broker As String = Session("BrokerCode").ToString()



            If String.IsNullOrEmpty(ddateFrom.SelectedValue) Or String.IsNullOrEmpty(ddateTo.SelectedValue) Or String.IsNullOrEmpty(broker) Then
                msgbox("Please select dates")
            Else
                If accType0.SelectedIndex = 1 Then
                    myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    myreport.Load(Server.MapPath("../Reporting/PaymentAdvice.rpt"))


                    Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

                    Session("pdateto") = dateto
                    Session("pdatefrom") = datefrom
                    Session("Report") = myreport

                    CrystalReportViewer1.ReportSource = Session("Report")

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



                    Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    Dim userName2 As String = Session("BrokerCode").ToString()
                    myParameterField2.ParameterFieldName = "broker"
                    myDiscreteValue2.Value = broker
                    myParameterField2.CurrentValues.Add(myDiscreteValue2)
                    myParameterFields.Add(myParameterField2)
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


                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                    myreport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                    CrystalReportViewer1.RefreshReport()

                ElseIf accType0.SelectedIndex = 0 Then
                    myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    myreport.Load(Server.MapPath("../Reporting/PaymentConfirmation.rpt"))

                    Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

                    Session("pdateto") = dateto
                    Session("pdatefrom") = datefrom
                    Session("Report") = myreport

                    CrystalReportViewer1.ReportSource = Session("Report")

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



                    Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    Dim userName2 As String = Session("BrokerCode").ToString()
                    myParameterField2.ParameterFieldName = "broker"
                    myDiscreteValue2.Value = broker
                    myParameterField2.CurrentValues.Add(myDiscreteValue2)
                    myParameterFields.Add(myParameterField2)
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


                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                    CrystalReportViewer1.RefreshReport()
                Else
                    msgbox("Please Select Option")
                End If
            End If

            'Session("pdateto") = ddateFrom.SelectedValue.ToString()
            'Session("pdatefrom") = ddateTo.SelectedValue.ToString()
            'Session("Report") = myreport

            'CrystalReportViewer1.ReportSource = myreport
            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            'CrystalReportViewer1.RefreshReport()

            'Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

            'Session("pdateto") = dateto
            'Session("pdatefrom") = datefrom
            'Session("Report") = myreport

            'CrystalReportViewer1.ReportSource = Session("Report")

            'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'Dim userName1 As String = Session("pdatefrom").ToString()
            'myParameterField1.ParameterFieldName = "pdateto"
            'myDiscreteValue1.Value = dateto
            'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            'myParameterFields.Add(myParameterField1)

            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'Dim userName As String = Session("pdatefrom").ToString()
            'myParameterField.ParameterFieldName = "pdatefrom"
            'myDiscreteValue.Value = datefrom
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)



            'Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'Dim userName2 As String = Session("BrokerCode").ToString()
            'myParameterField2.ParameterFieldName = "broker"
            'myDiscreteValue2.Value = broker
            'myParameterField2.CurrentValues.Add(myDiscreteValue2)
            'myParameterFields.Add(myParameterField2)
            ''Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            ''Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            ''myParameterField1.ParameterFieldName = "pdateto"
            ''myDiscreteValue1.Value = dateto
            ''myParameterField1.CurrentValues.Add(myDiscreteValue1)
            ''myParameterFields.Add(myParameterField1)

            ''Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            ''Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            ''myParameterField.ParameterFieldName = "pdatefrom"
            ''myDiscreteValue.Value = datefrom
            ''myParameterField.CurrentValues.Add(myDiscreteValue)
            ''myParameterFields.Add(myParameterField)


            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            'CrystalReportViewer1.RefreshReport()
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
