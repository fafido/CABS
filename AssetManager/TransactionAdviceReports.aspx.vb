
Partial Class Reporting_TransactionAdviceReports
    Inherits System.Web.UI.Page
    Dim com As SqlCommand
    Dim cn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim da As SqlDataAdapter
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Dim a As CrystalDecisions.CrystalReports.Engine.FieldObject
    Dim b As CrystalDecisions.CrystalReports.Engine.TextObject
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


            Dim ds As New DataSet

            Dim RepType As String = Request.QueryString("RepType")
            Dim idx As String = Request.QueryString("id")



            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            If (RepType = "S") Then
                myReport.Load(Server.MapPath("..\Reporting\TransactionSalesAdvice.rpt"))
            End If
            If (RepType = "P") Then
                myReport.Load(Server.MapPath("..\Reporting\TransactionBuysAdvice.rpt"))
            End If
            If (RepType = "A") Then
                myReport.Load(Server.MapPath("..\Reporting\TransactionAllAdvice.rpt"))
            End If


            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pid"
            myDiscreteValue.Value = idx
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)


            CrystalReportViewer1.ReportSource = myReport
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
