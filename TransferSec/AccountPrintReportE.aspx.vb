Imports CrystalDecisions.CrystalReports.Engine
Partial Class Reporting_gvtschedulereportE
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            cryRpt.Close()
            cryRpt.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Username1 As String = Request.QueryString("Username")
        Dim AccType As String = Request.QueryString("AccType")
        Dim IDD As String = Request.QueryString("IDD")

        Dim kk As String = ""
        If AccType = "I" Then
            kk = Server.MapPath("rptAccountSingle_E.rpt")
        ElseIf AccType = "C" Then
            kk = Server.MapPath("rptAccountCorp_E.rpt")
        ElseIf AccType = "P" Then
            kk = Server.MapPath("rptAccountPen_E.rpt")
        ElseIf AccType = "J" Then
            kk = Server.MapPath("rptAccountJoint_E.rpt")
        End If
        cryRpt.Load(kk)
        cryRpt.SetParameterValue("Created_By", Username1)
        cryRpt.SetParameterValue("IDD", IDD)
        CrystalReportViewer1.ReportSource = cryRpt
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
