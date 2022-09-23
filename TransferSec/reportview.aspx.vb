Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Partial Class TransferSec_reportview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim myreport As New ReportDocument

        myreport.Load(System.AppDomain.CurrentDomain.BaseDirectory() & "\XML_Report_Files\Report1.rpt", OpenReportMethod.OpenReportByTempCopy)
        ' myReport.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = myreport


    End Sub
End Class
