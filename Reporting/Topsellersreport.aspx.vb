﻿
Partial Class Reporting_topsellersreport
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
        Try
            Dim rpttype As String = Request.QueryString("buysell")
            If rpttype = "Buyers" Then
                Dim ds As New DataSet
                Dim datefrom As String = Request.QueryString("DateFrom")
                Dim dateto As String = Request.QueryString("Dateto")
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\topbuyers.rpt"))

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



                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "Sellers" Then
                Dim ds As New DataSet
                Dim datefrom As String = Request.QueryString("DateFrom")
                Dim dateto As String = Request.QueryString("Dateto")
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\topsellers.rpt"))

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



                CrystalReportViewer1.ReportSource = myReport
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                CrystalReportViewer1.RefreshReport()

            ElseIf rpttype = "participants" Then
                Dim ds As New DataSet
                Dim participants As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                If Request.QueryString("for") = "All" Then
                    myReport.Load(Server.MapPath("..\Reporting\participantsall.rpt"))

                    CrystalReportViewer1.ReportSource = myReport
                    myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                    CrystalReportViewer1.RefreshReport()

                Else
                    myReport.Load(Server.MapPath("..\Reporting\participants.rpt"))


                    Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                    Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField.ParameterFieldName = "ptype"
                    myDiscreteValue.Value = participants
                    myParameterField.CurrentValues.Add(myDiscreteValue)
                    myParameterFields.Add(myParameterField)


                    CrystalReportViewer1.ReportSource = myReport
                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                    myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                    CrystalReportViewer1.RefreshReport()
                End If




            ElseIf rpttype = "systemusers" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                If Request.QueryString("for") = "All" Then
                    myReport.Load(Server.MapPath("..\Reporting\systemusersall.rpt"))
                    CrystalReportViewer1.ReportSource = myReport
                    myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                    CrystalReportViewer1.RefreshReport()
                Else
                    myReport.Load(Server.MapPath("..\Reporting\systemusers.rpt"))
                    Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
                    Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField.ParameterFieldName = "ptype"
                    myDiscreteValue.Value = systemusers
                    myParameterField.CurrentValues.Add(myDiscreteValue)
                    myParameterFields.Add(myParameterField)


                    CrystalReportViewer1.ReportSource = myReport
                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                    myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                    CrystalReportViewer1.RefreshReport()
                End If


               
            ElseIf rpttype = "Securities" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\securities.rpt"))




                CrystalReportViewer1.ReportSource = myReport
                myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                CrystalReportViewer1.RefreshReport()
            ElseIf rpttype = "Lenders" Then
                Dim ds As New DataSet
                Dim systemusers As String = Request.QueryString("for")

                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\lenders.rpt"))



                myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                CrystalReportViewer1.ReportSource = myReport

                CrystalReportViewer1.RefreshReport()
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
