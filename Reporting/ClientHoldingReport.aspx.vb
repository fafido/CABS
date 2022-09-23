
Partial Class Reporting_ClientHoldingReport
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


            Dim ds As New DataSet

            Dim cdsno As String = Session("par_cdsno")
            Dim datefrom As String = Request.QueryString("DateFrom")
            Dim dateto As String = Request.QueryString("Dateto")
            Dim assetmanager As String = Request.QueryString("AssetManager")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            If Request.QueryString("tp") = "namesaudit" Then


                myReport.Load(Server.MapPath("..\Reporting\namesaudit.rpt"))


                Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

                Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField2.ParameterFieldName = "pcdsno"
                myDiscreteValue2.Value = cdsno
                myParameterField2.CurrentValues.Add(myDiscreteValue2)
                myParameterFields.Add(myParameterField2)

                CrystalReportViewer1.ReportSource = myReport
                Dim sdmail As New sendmail
                myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()

            Else
                If cdsno = "ALL" Then

                    myReport.Load(Server.MapPath("..\Reporting\ClientHoldingReportCDScons.rpt"))


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

                    Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField3.ParameterFieldName = "pAssetManager"
                    myDiscreteValue3.Value = assetmanager
                    myParameterField3.CurrentValues.Add(myDiscreteValue3)
                    myParameterFields.Add(myParameterField3)

                    Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField4.ParameterFieldName = "pName"
                    myDiscreteValue4.Value = " - "
                    myParameterField4.CurrentValues.Add(myDiscreteValue3)
                    myParameterFields.Add(myParameterField4)

                    Dim myParameterField5 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField5.ParameterFieldName = "pAdd"
                    myDiscreteValue5.Value = " - "
                    myParameterField5.CurrentValues.Add(myDiscreteValue5)
                    myParameterFields.Add(myParameterField5)

                    'Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
                    'Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    'myParameterField2.ParameterFieldName = "pcdsno"
                    'myDiscreteValue2.Value = cdsno
                    'myParameterField2.CurrentValues.Add(myDiscreteValue2)
                    'myParameterFields.Add(myParameterField2)

                    myReport.SummaryInfo.ReportTitle = "ClientHolding"
                    CrystalReportViewer1.ReportSource = myReport
                    Dim sdmail As New sendmail
                    myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)

                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                    CrystalReportViewer1.RefreshReport()
                Else

                    myReport.Load(Server.MapPath("..\Reporting\ClientHoldingReportCDS.rpt"))


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

                    Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField3.ParameterFieldName = "pAssetManager"
                    myDiscreteValue3.Value = assetmanager
                    myParameterField3.CurrentValues.Add(myDiscreteValue3)
                    myParameterFields.Add(myParameterField3)

                    Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField4.ParameterFieldName = "pName"
                    myDiscreteValue4.Value = Request.QueryString("Name")
                    myParameterField4.CurrentValues.Add(myDiscreteValue3)
                    myParameterFields.Add(myParameterField4)

                    Dim myParameterField5 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField5.ParameterFieldName = "pAdd"
                    myDiscreteValue5.Value = Request.QueryString("Add")
                    myParameterField5.CurrentValues.Add(myDiscreteValue5)
                    myParameterFields.Add(myParameterField5)

                    Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
                    Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    myParameterField2.ParameterFieldName = "pcdsno"
                    myDiscreteValue2.Value = cdsno
                    myParameterField2.CurrentValues.Add(myDiscreteValue2)
                    myParameterFields.Add(myParameterField2)

                    myReport.SummaryInfo.ReportTitle = "ClientHolding"
                    CrystalReportViewer1.ReportSource = myReport
                    Dim sdmail As New sendmail
                    myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)

                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                    CrystalReportViewer1.RefreshReport()
                End If


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
