
Partial Class Reporting_rptewr
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
            MsgBox(ex.Message)
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
            Dim ldate As String = Request.QueryString("Dateto")
            Dim commodity As String = Request.QueryString("commodity")
            Dim ewr As String = Request.QueryString("ewr")
            Dim Participantcode As String = Request.QueryString("code")
            Dim status As String = Request.QueryString("status")

            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            Dim strSQL As String = ""
            If IsDate(fdate) = True And IsDate(ldate) = True Then
                strSQL = strSQL & " and convert(date, Date_Issued) between '" & fdate & "' and '" & ldate & "'"
            Else
                strSQL = strSQL & ""
            End If
            If status = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and PMEXSTATUS='" & status & "'"
            End If
            If commodity = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and Commodity='" & commodity & "'"
            End If
            If ewr = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and ReceiptNo='" & ewr & "'"
            End If
            If Participantcode = "All" Then
                strSQL = strSQL & ""
            Else
                strSQL = strSQL & " and Warehouse ='" & Participantcode & "'"
            End If

            myReport.Load(Server.MapPath("..\Reporting\rptpmex.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "strSQL"
            myDiscreteValue.Value = strSQL
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

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
