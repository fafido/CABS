
Partial Class Reporting_rpttransaction
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


            Dim fdate As String = Request.QueryString("Datefrom")
            Dim tdate As String = Request.QueryString("Dateto")
            Dim produce As String = Request.QueryString("commodity")
            Dim status As String = Request.QueryString("status")
            Dim category As String = Request.QueryString("ActivityPerformed")
            'Dim EWRno As String = Request.QueryString("EWRno")
            'Dim holder As String = Request.QueryString("holder")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

           
            Dim displayStr As String = ""
            Dim strSQL As String = ""
            If IsDate(fdate) = True And IsDate(tdate) = True Then
                strSQL = strSQL & " and convert(date, CaptureDate) between '" & fdate & "' and '" & tdate & "'"
                displayStr = "From " & fdate & " to " & tdate
            Else
                strSQL = strSQL & ""
                displayStr = ""
            End If
            If status = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and Status='" & status & "'"
            End If
            If produce = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and Produce='" & produce & "'"
            End If
            If category = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and Category='" & category & "'"
            End If
          

            myReport.Load(Server.MapPath("..\Reporting\rpttransaction.rpt"))
            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "strSQL"
            myDiscreteValue.Value = strSQL
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "displayStr"
            myDiscreteValue1.Value = displayStr
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            CrystalReportViewer1.ReportSource = myReport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.ReportSource = myReport
            Dim sdmail As New sendmail
            myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
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




            'Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField.ParameterFieldName = "category"
            'myDiscreteValue.Value = category
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)

            'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField1.ParameterFieldName = "fdate"
            'myDiscreteValue1.Value = fdate
            'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            'myParameterFields.Add(myParameterField1)

            'Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField2.ParameterFieldName = "produce"
            'myDiscreteValue2.Value = produce
            'myParameterField2.CurrentValues.Add(myDiscreteValue2)
            'myParameterFields.Add(myParameterField2)

            'Dim myParameterField3 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField3.ParameterFieldName = "status"
            'myDiscreteValue3.Value = status
            'myParameterField3.CurrentValues.Add(myDiscreteValue3)
            'myParameterFields.Add(myParameterField3)


            'Dim myParameterField4 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField4.ParameterFieldName = "tdate"
            'myDiscreteValue4.Value = tdate
            'myParameterField4.CurrentValues.Add(myDiscreteValue4)
            'myParameterFields.Add(myParameterField4)

            'Dim myParameterField6 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue6 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField6.ParameterFieldName = "strSQL"
            'myDiscreteValue6.Value = strSQL
            'myParameterField6.CurrentValues.Add(myDiscreteValue6)
            'myParameterFields.Add(myParameterField6)

            'CrystalReportViewer1.ReportSource = myReport
            'Dim sdmail As New sendmail
            'myReport.DataSourceConnections(0).SetConnection(sdmail.CONReports.ServerName, sdmail.CONReports.DatabaseName, sdmail.CONReports.UserID, sdmail.CONReports.Password)
            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            'CrystalReportViewer1.RefreshReport()

'        Catch ex As Exception
'            MsgBox(ex.Message)
'            Exit Sub
'        End Try
'    End Sub

'End Class
