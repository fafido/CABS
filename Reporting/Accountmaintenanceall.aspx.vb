
Partial Class Reporting_HolderClassificationIndividual
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
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            'Dim company As String = Request.QueryString("company")
            Dim holderType As String = Request.QueryString("classification")
            Dim DateFrom As String = Request.QueryString("Datefrom")
            Dim dateTo As String = Request.QueryString("DateTo")
            Dim Sort1 As String = Request.QueryString("Sort1")
            Dim Sort2 As String = Request.QueryString("Sort2")

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("..\Reporting\Allmaintenance.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField.ParameterFieldName = "pcompany"
            'myDiscreteValue.Value = company
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)


            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField.ParameterFieldName = "pclassification"
            'myDiscreteValue.Value = holderType
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "pdatefrom"
            myDiscreteValue1.Value = DateFrom
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "pdateto"
            myDiscreteValue2.Value = dateTo
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)


            Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField3.ParameterFieldName = "psort1"
            myDiscreteValue3.Value = Sort1
            myParameterField3.CurrentValues.Add(myDiscreteValue3)
            myParameterFields.Add(myParameterField3)

            Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField4.ParameterFieldName = "psort1"
            myDiscreteValue4.Value = Sort2
            myParameterField4.CurrentValues.Add(myDiscreteValue4)
            myParameterFields.Add(myParameterField4)


            CrystalReportViewer1.ReportSource = myreport
            ' myreport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
            Dim sdmail As New sendmail
            myreport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
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
