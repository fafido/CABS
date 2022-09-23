
Partial Class Trading_OrderReceiptStatement
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String = System.Configuration.ConfigurationManager.AppSettings("connpath")
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim com As String
    Dim divno As String
    Dim manco As String
    Dim con As SqlCommand

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Dim RepType As String = Request.QueryString("Reptype")

        If (RepType = "1") Then
            com = CStr(Request.QueryString("OrderNumber"))
            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("PurchaseOrderStatement.rpt"))
            'myreport.SetDataSource(ds.Tables(0))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            myParameterField.ParameterFieldName = "porderNumber"
            myDiscreteValue.Value = com
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        End If
        
    End Sub
End Class
