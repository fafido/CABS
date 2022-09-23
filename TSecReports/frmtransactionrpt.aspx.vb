Imports System.Runtime.InteropServices
Partial Class frmtransactionrpt
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim myReport As CrystalDecisions.CrystalReports.Engine.ReportDocument

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
        Page.MaintainScrollPositionOnPostBack = True
        Dim company As String = CStr(Request.QueryString("company"))
        Dim datefrom As String = CStr(Request.QueryString("datefrom"))
        Dim dateto As String = CStr(Request.QueryString("dateto"))
        Dim ds As New DataSet

        Try
            'If company = " " Then
            '    str = "select * from portfolio where datetoday>='" & datefrom & "' and datetoday<='" & dateto & "'"
            'Else
            '    ' str = "select * from mast where cert >=  " & certfrom & " and cert<= " & certto & " and company='" & com & "'"
            '    str = "select * from portfolio where company='" & company & "' and datetoday>='" & datefrom & "' and datetoday<='" & dateto & "'"
            'End If
            'cn = New SqlConnection(cnstr)
            'cmd = New SqlCommand(str, cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds, "portfolio")
            myReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            myReport.Load(Server.MapPath("rptFullTransactionReport.rpt"))
            'myReport.SetDataSource(ds.Tables(0))



            'displaying the cmpy and dates on 23/11/07
            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "pcompany"
            myDiscreteValue.Value = company
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)
            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField1.ParameterFieldName = "pfromdate"
            myDiscreteValue1.Value = datefrom
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField2.ParameterFieldName = "ptodate"
            myDiscreteValue2.Value = dateto
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)


            CrystalReportViewer1.ReportSource = myReport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()

            'myReport.Refresh()

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


    Protected Sub CrystalReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init

    End Sub
End Class
