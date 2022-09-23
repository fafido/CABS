
Partial Class Reporting_fundschedulereport
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
        ' msgbox(Session("Companytype"))

        Try
            If Session("Companytype") = "" Then
                Response.Redirect("~/loginsystem.aspx")
            End If
            Dim holderType As String = Request.QueryString("Classfication")
            If (holderType = 5) Then
                If Session("Companytype") = "CUSTODIAN" Then
                    If Request.QueryString("locked") = "True" Then
                        Dim company As String = Request.QueryString("company")
                        Dim Repdate As String = Request.QueryString("RepDate")

                        myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                        myreport.Load(Server.MapPath("..\Reporting\CompanyScheduleAlllockedcust.rpt"))

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
                        myParameterField2.ParameterFieldName = "pcust"
                        myDiscreteValue2.Value = Session("BrokerCode")
                        myParameterField2.CurrentValues.Add(myDiscreteValue2)
                        myParameterFields.Add(myParameterField2)

                        CrystalReportViewer1.ReportSource = myreport
                        CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                        CrystalReportViewer1.RefreshReport()

                    Else
                        Dim company As String = Request.QueryString("company")
                        Dim Repdate As String = Request.QueryString("RepDate")

                        myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                        myreport.Load(Server.MapPath("..\Reporting\fundschedulereport.rpt"))

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
                        myParameterField2.ParameterFieldName = "pcust"
                        myDiscreteValue2.Value = Session("BrokerCode")
                        myParameterField2.CurrentValues.Add(myDiscreteValue2)
                        myParameterFields.Add(myParameterField2)

                        CrystalReportViewer1.ReportSource = myreport
                        CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                        CrystalReportViewer1.RefreshReport()
                    End If
                ElseIf Session("Companytype") = "CDS" Or Session("Companytype") = "TSec" Or Session("Companytype") = "CUSTODY" Then
                    If Request.QueryString("locked") = "True" Then
                        Dim company As String = Request.QueryString("company")
                        Dim Repdate As String = Request.QueryString("RepDate")

                        myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                        myreport.Load(Server.MapPath("..\Reporting\CompanyScheduleAlllocked.rpt"))

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

                        CrystalReportViewer1.ReportSource = myreport
                        CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                        CrystalReportViewer1.RefreshReport()

                    Else
                        Dim company As String = Request.QueryString("company")
                        Dim Repdate As String = Request.QueryString("RepDate")

                        myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                        myreport.Load(Server.MapPath("..\Reporting\CompanyScheduleAll.rpt"))

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

                        CrystalReportViewer1.ReportSource = myreport
                        Dim sdmail As New sendmail
                        myreport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
                        CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                        CrystalReportViewer1.RefreshReport()
                    End If
                End If


            Else
                msgbox("test")
                'Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                ''Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                ''Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                ''myParameterField.ParameterFieldName = "pcompany"
                ''myDiscreteValue.Value = company
                ''myParameterField.CurrentValues.Add(myDiscreteValue)
                ''myParameterFields.Add(myParameterField)
                'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                'myParameterField.ParameterFieldName = "pclassification"
                'myDiscreteValue.Value = holderType
                'myParameterField.CurrentValues.Add(myDiscreteValue)
                'myParameterFields.Add(myParameterField)

                'CrystalReportViewer1.ReportSource = myreport
                'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                'CrystalReportViewer1.RefreshReport()
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
