'Imports CrystalDecisions.CrystalReports.Engine

'Partial Class CDSMode_ChargesReport
'    Inherits System.Web.UI.Page
'    Dim cryRpt As New ReportDocument
'    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


'        Page.MaintainScrollPositionOnPostBack = True
'        If Not IsPostBack Then
'            '  Dim constr As String = ConfigurationManager.ConnectionStrings("conpath").ConnectionString



'            'Using con As New SqlConnection(constr)
'            '    Using cmd As New SqlCommand("SELECT MeetID,MeetingName FROM tblMeetings")
'            '        cmd.CommandType = CommandType.Text
'            '        cmd.Connection = con
'            '        con.Open()
'            '      DropDownList7.DataSource = cmd.ExecuteReader()
'            '    DropDownList7.DataTextField = "MeetingName"
'            '     DropDownList7.DataValueField = "MeetID"
'            '     DropDownList7.DataBind()
'            '        con.Close()
'            '    End Using
'            'End Using

'            'DropDownList7.Items.Insert(0, New ListItem("--Select Meeting--", "0"))
'            '          Using con As New SqlConnection(constr)
'            '       Using cmd As New SqlCommand("SELECT InstanceID FROM tblMeetingInstance")
'            '           cmd.CommandType = CommandType.Text
'            '           cmd.Connection = con
'            '           con.Open()
'            '         DropDownList8.DataSource = cmd.ExecuteReader()
'            '       DropDownList8.DataTextField = "InstanceID"
'            '        DropDownList8.DataValueField = "InstanceID"
'            '        DropDownList8.DataBind()
'            '           con.Close()
'            '       End Using
'            '   End Using
'            '        DropDownList8.Items.Insert(0, New ListItem("--Select Instance--", "0"))
'        End If
'        'Dim cryRpt As New ReportDocument
'        '  Dim kk As String = ""
'        '  kk = Server.MapPath("~/Reporting/CrystalReport.rpt")
'        'cryRpt.Load(kk)
'        ' CrystalReportViewer1.ReportSource = cryRpt
'        If IsPostBack Then
'            Try

'                CrystalReportViewer1.ReportSource = DirectCast(Session("Report"), ReportDocument)

'            Catch ex As Exception


'                Throw ex

'            End Try
'        End If

'    End Sub
'    Private Sub Button1_Click(ByVal sender As System.Object,
'  ByVal e As System.EventArgs) Handles Button1.Click



'        Dim datefrom As String = Request.QueryString("datefrom")
'        Dim dateto As String = Request.QueryString("dateto")


'        Dim kk As String = ""
'        kk = Server.MapPath("../Reporting/ChargesReport.rpt")

'        Session("datefrom") = "2016-01-01"
'        Session("dateto") = "2016-06-31"
'        Session("Report") = cryRpt


'        'Dim edate = "2009-06-15"
'        'Dim expenddt As Date = Date.ParseExact(Session("datefrom"), "yyyy-MM-dd",
'        '           System.Globalization.DateTimeFormatInfo.InvariantInfo)

'        ' Dim expenddt1 As Date = Date.ParseExact(Session("dateto"), "yyyy-MM-dd",
'        '           System.Globalization.DateTimeFormatInfo.InvariantInfo)
'        cryRpt.Load(kk)




'        cryRpt.SetParameterValue("pdatefrom", datefrom)
'        cryRpt.SetParameterValue("pdateto", dateto)
'        CrystalReportViewer1.ReportSource = Session("Report")

'    End Sub
'    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
'        If Not IsPostBack Then
'            If CrystalReportViewer1 IsNot Nothing Then
'                CrystalReportViewer1.Dispose()
'            End If
'            CrystalReportViewer1 = Nothing

'            If cryRpt IsNot Nothing Then
'                cryRpt.Close()
'                cryRpt.Dispose()
'            End If
'            cryRpt = Nothing

'            GC.Collect()
'        End If

'    End Sub
'End Class




Partial Class CDSMode_ChargesReport
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack Then
            Try
                CrystalReportViewer1.ReportSource = DirectCast(Session("Report"), CrystalDecisions.CrystalReports.Engine.ReportDocument)
            Catch ex As Exception
                Throw ex
            End Try
        Else
            loadSecurities()
        End If
    End Sub

    Protected Sub loadSecurities()
        cmd = New SqlCommand("SELECT [ChargeCode],[ChargeName] FROM [CDS].[dbo].[para_Billing]", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_securities")
        If ds.Tables(0).Rows.Count > 0 Then
            ddateTo.DataSource = ds
            ddateTo.TextField = "ChargeCode"
            ddateTo.ValueField = "ChargeName"
            ddateTo.DataBind()
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim datefrom As String = ddateFrom.SelectedValue.ToString()
            Dim dateto As String = ddateTo.SelectedItem.ToString()

            'cmbSecurities.SelectedItem.Tex

            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("../Reporting/ChargesReport.rpt"))

            'Session("pdateto") = ddateFrom.SelectedValue.ToString()
            'Session("pdatefrom") = ddateTo.SelectedValue.ToString()
            'Session("Report") = myreport
            'CrystalReportViewer1.ReportSource = myreport
            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            'CrystalReportViewer1.RefreshReport()

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

            Session("pdateto") = dateto
            Session("pdatefrom") = datefrom
            Session("Report") = myreport

            Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim userName1 As String = Session("pdatefrom").ToString()
            myParameterField1.ParameterFieldName = "pdateto"
            myDiscreteValue1.Value = dateto
            myParameterField1.CurrentValues.Add(myDiscreteValue1)
            myParameterFields.Add(myParameterField1)

            Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim userName As String = Session("pdatefrom").ToString()
            myParameterField.ParameterFieldName = "pdatefrom"
            myDiscreteValue.Value = datefrom
            myParameterField.CurrentValues.Add(myDiscreteValue)
            myParameterFields.Add(myParameterField)

            'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField1.ParameterFieldName = "pdateto"
            'myDiscreteValue1.Value = dateto
            'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            'myParameterFields.Add(myParameterField1)

            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField.ParameterFieldName = "pdatefrom"
            'myDiscreteValue.Value = datefrom
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)

            CrystalReportViewer1.ReportSource = Session("Report")
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        If Not IsPostBack Then
            If CrystalReportViewer1 IsNot Nothing Then
                CrystalReportViewer1.Dispose()
            End If
            CrystalReportViewer1 = Nothing

            If myreport IsNot Nothing Then
                myreport.Close()
                myreport.Dispose()
            End If
            myreport = Nothing
            GC.Collect()
        End If

    End Sub
End Class

