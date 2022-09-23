Partial Class Reporting_gvtschedulereport
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





        Dim id As String = Request.QueryString("id")
        Dim PrintInforCopy As String = Request.QueryString("PrintInforCopy")


                myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        myreport.Load(Server.MapPath("..\Reporting\warehousekenya.rpt"))


        Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField.ParameterFieldName = "pid"
            myDiscreteValue.Value = id
            myParameterField.CurrentValues.Add(myDiscreteValue)
                myParameterFields.Add(myParameterField)


        Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
        Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        myParameterField2.ParameterFieldName = "PrintInforCopy"
        myDiscreteValue2.Value = PrintInforCopy
        myParameterField2.CurrentValues.Add(myDiscreteValue2)
        myParameterFields.Add(myParameterField2)

        CrystalReportViewer1.ReportSource = myreport
        Dim sdmail As New sendmail
        myreport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
        'myreport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
        CrystalReportViewer1.ParameterFieldInfo = myParameterFields
        CrystalReportViewer1.RefreshReport()

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
