Imports System.Runtime.Serialization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reporting_BrokerAuditReport2
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
        '  Try

        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Dim ds As New DataSet

        'Dim RepType As String = Request.QueryString("RepType")

        Dim datefrom As String = Request.QueryString("DateFrom")
        Dim dateto As String = Request.QueryString("Dateto")



        myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()


        'If (RepType = "B") Then
        '    myReport.Load(Server.MapPath("..\BrokerReporting\TransactionBuysAdvice.rpt"))
        'End If
        'If (RepType = "A") Then
        '    myReport.Load(Server.MapPath("..\BrokerReporting\TransactionAllAdvice.rpt"))
        'End If
        If Request.QueryString("type") = "settlement" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\BrokerAudit2.rpt"))
        ElseIf Request.QueryString("type") = "useraudit" Then

            myReport.Load(Server.MapPath("..\BrokerReporting\audit.rpt"))
        ElseIf Request.QueryString("type") = "pledges" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\pledges.rpt"))
        ElseIf Request.QueryString("type") = "settlementnew" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\settlementnew.rpt"))
        ElseIf Request.QueryString("type") = "settlementbroker" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\settlementCDA.rpt"))
        ElseIf Request.QueryString("type") = "settlementDelivery" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\settlementDelivery.rpt"))
        ElseIf Request.QueryString("type") = "settlementCDAsumm" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\settlementCDAsumm.rpt"))
        ElseIf Request.QueryString("type") = "settlementgroupedcda" Then
            myReport.Load(Server.MapPath("..\BrokerReporting\settlementgroupedcda.rpt"))
        Else
            myReport.Load(Server.MapPath("..\BrokerReporting\tradesumm.rpt"))
        End If
        Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
        If Request.QueryString("type") = "useraudit" Then
            Dim userz As String = Request.QueryString("user")
            Dim myParameterFieldsnew As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterFieldnew As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValuenew As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterFieldnew.ParameterFieldName = "puser"
            myDiscreteValuenew.Value = userz
            myParameterFieldnew.CurrentValues.Add(myDiscreteValuenew)
            myParameterFields.Add(myParameterFieldnew)
        End If
        If Request.QueryString("type") = "settlementnew" Or Request.QueryString("type") = "settlementbroker" Or Request.QueryString("type") = "settlementCDAsumm" Or Request.QueryString("type") = "settlementDelivery" Then
            Dim currency As String = Request.QueryString("currency")
            Dim myParameterFieldscurrency As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterFieldcurrency As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValuecurrency As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterFieldcurrency.ParameterFieldName = "pcurrency"
            myDiscreteValuecurrency.Value = currency
            myParameterFieldcurrency.CurrentValues.Add(myDiscreteValuecurrency)
            myParameterFields.Add(myParameterFieldcurrency)
            myReport.SetParameterValue("pcurrency", currency)
        End If

        If Request.QueryString("type") <> "pledges" Then

            Dim company As String = Request.QueryString("company")
            Dim myParameterFieldscompany As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterFieldcompany As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValuecompany As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterFieldcompany.ParameterFieldName = "pcompany"
            myDiscreteValuecompany.Value = company
            myParameterFieldcompany.CurrentValues.Add(myDiscreteValuecompany)
            myParameterFields.Add(myParameterFieldcompany)


        End If


      


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

        Dim myParameterField5 As New CrystalDecisions.Shared.ParameterField()
        Dim myDiscreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        myParameterField5.ParameterFieldName = "pbroker"
        myDiscreteValue5.Value = Session("BrokerCode")
        myParameterField5.CurrentValues.Add(myDiscreteValue5)
        myParameterFields.Add(myParameterField5)



        CrystalReportViewer1.ReportSource = myReport
        CrystalReportViewer1.ParameterFieldInfo = myParameterFields
        CrystalReportViewer1.RefreshReport()

        '   Try
        '  CType(myReport, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, "G:\ReportTEST.pdf")
        '' '' ''If Request.QueryString("mail") = "true" Then
        '' '' ''    myReport.SetParameterValue("pcompany", company)
        '' '' ''    myReport.SetParameterValue("pdatefrom", datefrom)
        '' '' ''    myReport.SetParameterValue("pdateto", dateto)

        '' '' ''    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, "G:\TODEPLOY\CDSSYSTEM\CDSCONSOL\MailAttachments\" + Today.ToString("MMMM dd, yyyy") + "_Settlement.pdf")

        '' '' ''    myReport.ExportToDisk(ExportFormatType.PortableDocFormat, "G:\TODEPLOY\CDSSYSTEM\CDSCONSOL\MailAttachments\" + Today.ToString("MMMM dd, yyyy") + "_Delivery.pdf")

        '' '' ''    Response.Redirect("~\Reporting\sendmail.aspx?filesready=true")
        '' '' ''End If

        'Catch ex As Exception
        '    msgbox(ex.ToString)
        'End Try

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

    Private Function cryRpt() As Object
        Throw New NotImplementedException
    End Function

End Class
