
Partial Class presettlement
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
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
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        

        myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        myreport.Load(Server.MapPath("../Reporting/LockedPeople.rpt"))
        CrystalReportViewer1.ReportSource = myreport
        myreport.DataSourceConnections(0).SetConnection(sendmail.CONReports.ServerName, sendmail.CONReports.DatabaseName, sendmail.CONReports.UserID, sendmail.CONReports.Password)
        CrystalReportViewer1.RefreshReport()
       

        

        'Catch ex As Exception
        '    msgbox("Please select valid dates or Indicate whether Report is for Buys or Sells!")
        'End Try

    End Sub
End Class
