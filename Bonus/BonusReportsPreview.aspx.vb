
Partial Class Corp_BonusReportsPreview
    Inherits System.Web.UI.Page
    Dim cryRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim comp As String = Request.QueryString("Company")
            Dim IssueNo As String = Request.QueryString("IssueNo")
            Dim RepType As String = Request.QueryString("RepType")
            Dim AssetManager As String = Request.QueryString("AssetManager")
            Dim kk As String = ""
            If RepType = "CS" Then
                kk = Server.MapPath("BonusControlSummary.rpt")
                cryRpt.Load(kk)
            ElseIf RepType = "DS" Then
                kk = Server.MapPath("BonusSchedule.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue("AssetManager", AssetManager)
            End If

            cryRpt.SetParameterValue("pcompany", comp)
            cryRpt.SetParameterValue("pdiv_no", IssueNo)
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception
            msgbox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            cryRpt.Close()
            cryRpt.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
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
