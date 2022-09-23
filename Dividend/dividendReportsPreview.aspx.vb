
Partial Class Corp_divReportsPreview
    Inherits System.Web.UI.Page
    Dim cryRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim comp As String = Request.QueryString("Company")
            Dim divno As String = Request.QueryString("divNo")
            Dim RepType As String = Request.QueryString("RepType")
            Dim EventType As String = Request.QueryString("EventType")
            Dim AssetManager As String = Request.QueryString("AssetManager")
            Dim str_cmd As String = " "
            Dim kk As String = ""
            If RepType = "CS" Then
                If EventType = "Specie" Then
                    kk = Server.MapPath("DividendControlSummarySpecie.rpt")
                ElseIf EventType = "Scrip" Then
                    kk = Server.MapPath("DividendControlSummaryScrip.rpt")
                ElseIf EventType = "Option" Then
                    kk = Server.MapPath("DividendControlSummaryOption.rpt")
                Else
                    kk = Server.MapPath("DividendControlSummary.rpt")
                End If
                cryRpt.Load(kk)
            ElseIf RepType = "DS" Then
                If EventType = "Specie" Then
                    kk = Server.MapPath("DividendScheduleSpecie.rpt")
                ElseIf EventType = "Scrip" Then
                    kk = Server.MapPath("DividendScheduleScrip.rpt")
                ElseIf EventType = "Option" Then
                    kk = Server.MapPath("DividendScheduleOption.rpt")
                Else
                    kk = Server.MapPath("DividendSchedule.rpt")
                End If
                cryRpt.Load(kk)
                cryRpt.SetParameterValue("AssetManager", AssetManager)
            End If

            cryRpt.SetParameterValue("pcompany", comp)
            cryRpt.SetParameterValue("pdivno", divno)
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
