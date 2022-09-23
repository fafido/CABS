
Partial Class Corp_InvoiceBillSummaryPreview
    Inherits System.Web.UI.Page
    Dim cryRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Try
        Dim AssetManager As String = Request.QueryString("AssetManager")
            Dim ClientNo As String = Request.QueryString("ClientNo")
            Dim DateFrom As String = Request.QueryString("DateFrom")
            Dim DateTo As String = Request.QueryString("DateTo")
            Dim Status As String = Request.QueryString("Status")
            Dim str_cmd As String = " "
            Dim kk As String = ""

            If Status = "NOT Billed" Then
                If AssetManager = "ALL" Then
                    str_cmd = str_cmd & "  "
                Else
                    str_cmd = str_cmd & " AND  E.AssetManager='" & AssetManager & "' "
                End If
                If ClientNo = "ALL" Then
                    str_cmd = str_cmd & "  "
                Else
                    str_cmd = str_cmd & " AND  E.CDS_Number='" & ClientNo & "' "
                End If
                kk = Server.MapPath("ClientInvoiceListingNotBilled.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue("str_cmd", str_cmd)
                cryRpt.SetParameterValue("AssetManager", AssetManager)
                cryRpt.SetParameterValue("ClientNo", ClientNo)
                cryRpt.SetParameterValue("DateFrom", DateFrom)
                cryRpt.SetParameterValue("DateTo", DateTo)
            Else
                If AssetManager = "ALL" Then
                    str_cmd = str_cmd & "  "
                Else
                    str_cmd = str_cmd & " AND  A.AssetManager='" & AssetManager & "' "
                End If
                If ClientNo = "ALL" Then
                    str_cmd = str_cmd & "  "
                Else
                    str_cmd = str_cmd & " AND  A.ClientNo='" & ClientNo & "' "
                End If
                If IsDate(DateFrom) = True And IsDate(DateTo) = True Then
                    str_cmd = str_cmd & " AND A.DateFrom= '" & DateFrom & "' AND A.DateTo = '" & DateTo & "' "
                Else
                    str_cmd = str_cmd & "  "
                End If
                If Status = "ALL" Then
                    str_cmd = str_cmd & "  "
                Else
                    str_cmd = str_cmd & " AND  CASE A.Posted when 0 then 'New' when 1 then 'Authorised' when 2 then 'Rejected' end='" & Status & "' "
                End If
                kk = Server.MapPath("ClientInvoiceListing.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue("str_cmd", str_cmd)
                cryRpt.SetParameterValue("AssetManager", AssetManager)
                cryRpt.SetParameterValue("ClientNo", ClientNo)
                cryRpt.SetParameterValue("DateFrom", DateFrom)
                cryRpt.SetParameterValue("DateTo", DateTo)
                cryRpt.SetParameterValue("Status", Status)
            End If

            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            CrystalReportViewer1.ReportSource = cryRpt
        'Catch ex As Exception
        '    msgbox(ex.Message)
        '    Exit Sub
        'End Try
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
