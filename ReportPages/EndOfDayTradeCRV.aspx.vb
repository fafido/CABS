Imports System.Net.Mail
Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Partial Class ReportPages_EndOfDayTradeCRV
    Inherits System.Web.UI.Page

    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim myReport As New ReportDocument
        Try
            Dim broker As String = Request.QueryString("broker")
            Dim ds As New DataSet
            cn.Open()
            cmd = New SqlCommand("Select * from vwEndOfdayTrade Where DealingBroker = '" & broker & "' and year(orderdate)= year(GETDATE()) and month(orderdate)=month(getdate()) and day(orderdate)=day(getdate()) ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "vwEndOfDayTrade")
            ds.WriteXml(System.AppDomain.CurrentDomain.BaseDirectory() & "\XML_Report_Files\EndOfDayTrade.xml", XmlWriteMode.WriteSchema)
            myReport.Load(System.AppDomain.CurrentDomain.BaseDirectory() & "\ReportFiles\rptEndOfDayTrade.rpt", OpenReportMethod.OpenReportByTempCopy)
            myReport.SetDataSource(ds)
            crvEODTrade.ReportSource = myReport
            ' myReport.Close()
            ' myReport.Dispose()
            'GC.Collect()
        Catch ex As Exception
            msgbox("Error")
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
