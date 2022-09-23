
Partial Class Reporting_createdaccountsreport
    Inherits System.Web.UI.Page
    Dim com As SqlCommand
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim da As SqlDataAdapter
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Dim a As CrystalDecisions.CrystalReports.Engine.FieldObject
    Dim b As CrystalDecisions.CrystalReports.Engine.TextObject
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


        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Dim cat As String = Request.QueryString("Category")
        If cat = "AccountCreation" Then
            Accountcreation()
        ElseIf cat = "CashBalance" Then
            cashbalance()
        ElseIf cat = "Regulatory" Then
            regulatory()
        ElseIf cat = "HoldingBalances" Then
            HoldingBalances()
        ElseIf cat = "HoldingBalances_Ind" Then
            HoldingBalances_ind()
        End If




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
    Public Sub Accountcreation()
        Try

            Dim val As String = Request.QueryString("Val")
            Dim datefrom As String = Request.QueryString("datefrom")
            Dim dateto As String = Request.QueryString("dateto")
            Dim reporttype As String = Request.QueryString("reporttype")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myReport.Load(Server.MapPath("../Reporting/AccCreated.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pdatefrom"
            myDiscreteValue.Value = datefrom
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "pdateto"
            myDiscreteValue1.Value = dateto
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "pval"
            myDiscreteValue2.Value = val
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)


            Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField3.ParameterFieldName = "ptype"
            myDiscreteValue3.Value = reporttype
            myParameterField3.CurrentValues.Add(myDiscreteValue3)
            myParameterFields.Add(myParameterField3)

            CrystalReportViewer1.ReportSource = myReport
            Dim sdmail As New sendmail
            myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Sub cashbalance()
        Try


            Dim dates As String = Request.QueryString("As_at")
            Dim assetmanager As String = Request.QueryString("assetmanager")
            Dim currency As String = Request.QueryString("currency")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myReport.Load(Server.MapPath("../Reporting/Cashbalance.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pdate"
            myDiscreteValue.Value = dates
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterFields1 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "passetmanager"
            myDiscreteValue1.Value = assetmanager
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterFields2 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "pcurrency"
            myDiscreteValue2.Value = Currency
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)



            CrystalReportViewer1.ReportSource = myReport
            Dim sdmail As New sendmail
            myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Sub HoldingBalances()
        Try


            Dim dates As String = Request.QueryString("As_at")
            Dim assetmanager As String = Request.QueryString("assetmanager")
            Dim currency As String = Request.QueryString("company")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myReport.Load(Server.MapPath("../Reporting/Holdingbalance.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pdate"
            myDiscreteValue.Value = dates
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterFields1 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "passetmanager"
            myDiscreteValue1.Value = assetmanager
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterFields2 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "pcompany"
            myDiscreteValue2.Value = currency
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)



            CrystalReportViewer1.ReportSource = myReport
            Dim sdmail As New sendmail
            myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Sub HoldingBalances_ind()
        Try


            Dim dates As String = Request.QueryString("As_at")
            Dim assetmanager As String = Request.QueryString("assetmanager")
            Dim currency As String = Request.QueryString("company")
            Dim client As String = Request.QueryString("Client")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myReport.Load(Server.MapPath("../Reporting/Holdingbalance_Ind.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pdate"
            myDiscreteValue.Value = dates
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterFields1 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "passetmanager"
            myDiscreteValue1.Value = assetmanager
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterFields2 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "pcompany"
            myDiscreteValue2.Value = currency
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)

            Dim myParameterFields3 As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField3.ParameterFieldName = "pclient"
            myDiscreteValue3.Value = client
            myParameterField3.CurrentValues.Add(myDiscreteValue3)
            myParameterFields.Add(myParameterField3)



            CrystalReportViewer1.ReportSource = myReport
            Dim sdmail As New sendmail
            myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Sub regulatory()
        Try


            Dim dates As String = Request.QueryString("As_at")


            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myReport.Load(Server.MapPath("../Reporting/Regulatory.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pdate"
            myDiscreteValue.Value = dates
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)



            CrystalReportViewer1.ReportSource = myReport
            Dim sdmail As New sendmail
            '  myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
End Class
