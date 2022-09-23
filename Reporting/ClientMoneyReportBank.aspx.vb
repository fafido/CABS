
Partial Class Reporting_ClientMoneyReportBank
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

            'Dim RepType As String = Request.QueryString("RepType")
            Dim cdsno As String = Session("par_cdsno")
            Dim datefrom As String = Request.QueryString("DateFrom")
            Dim dateto As String = Request.QueryString("Dateto")
            Dim assetmanager As String = Request.QueryString("AssetManager")
            Dim bank As String = Request.QueryString("BankAccount")
            Dim recon As String = Request.QueryString("Recon")

            If cdsno = "ALL" Then
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\ClientMoneyReportCons1.rpt"))



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



                Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField4.ParameterFieldName = "passetmanager"
                myDiscreteValue4.Value = assetmanager
                myParameterField4.CurrentValues.Add(myDiscreteValue4)
                myParameterFields.Add(myParameterField4)

                Dim myParameterField5 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField5.ParameterFieldName = "pbank"
                myDiscreteValue5.Value = bank
                myParameterField5.CurrentValues.Add(myDiscreteValue5)
                myParameterFields.Add(myParameterField5)

              

                CrystalReportViewer1.ReportSource = myReport
                Dim sdmail As New sendmail
                myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
                'myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
                CrystalReportViewer1.RefreshReport()
            Else
                myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                myReport.Load(Server.MapPath("..\Reporting\ClientMoneyReportBank.rpt"))



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
                myParameterField2.ParameterFieldName = "pcdsno"
                myDiscreteValue2.Value = cdsno
                myParameterField2.CurrentValues.Add(myDiscreteValue2)
                myParameterFields.Add(myParameterField2)

                Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField3.ParameterFieldName = "pwarehouse"
                myDiscreteValue3.Value = Session("BrokerCode")
                myParameterField3.CurrentValues.Add(myDiscreteValue3)
                myParameterFields.Add(myParameterField3)

                Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField4.ParameterFieldName = "passetmanager"
                myDiscreteValue4.Value = assetmanager
                myParameterField4.CurrentValues.Add(myDiscreteValue4)
                myParameterFields.Add(myParameterField4)

                Dim myParameterField5 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField5.ParameterFieldName = "pbank"
                myDiscreteValue5.Value = bank
                myParameterField5.CurrentValues.Add(myDiscreteValue5)
                myParameterFields.Add(myParameterField5)

                Dim myParameterField6 As New CrystalDecisions.Shared.ParameterField()
                Dim myDiscreteValue6 As New CrystalDecisions.Shared.ParameterDiscreteValue()
                myParameterField6.ParameterFieldName = "precon"
                myDiscreteValue6.Value = recon
                myParameterField6.CurrentValues.Add(myDiscreteValue6)
                myParameterFields.Add(myParameterField6)

                CrystalReportViewer1.ReportSource = myReport
                Dim sdmail As New sendmail
                myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
                'myReport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields
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
