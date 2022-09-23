
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Reporting_AccountsCreated
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Public password, numb, codec As String
    Dim dst As New DataSet

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
'            Dim scdnumber As String = TextBox1.Text.ToString()
            Dim brokerCode = Session("BrokerCode").ToString


            'Dim dateto As String = ddateTo.SelectedValue.ToString()
            Dim cryrpt As ReportDocument = New ReportDocument

            ' myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            ' myreport.Load(Server.MapPath("../Reporting/AccFees.rpt"))

            ' 'Session("pdateto") = ddateFrom.SelectedValue.ToString()
            ' 'Session("pdatefrom") = ddateTo.SelectedValue.ToString()
            ' 'Session("Report") = myreport
            ' 'CrystalReportViewer1.ReportSource = myreport
            ' 'CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            ' 'CrystalReportViewer1.RefreshReport()

            ' Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()

            ' Session("cdsnumber") = datefrom
            ' 'Session("pdatefrom") = datefrom
            ' Session("Report") = myreport

            ' 'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            ' 'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            ' 'Dim userName1 As String = Session("pdatefrom").ToString()
            ' 'myParameterField1.ParameterFieldName = "cdsnumber"
            ' 'myDiscreteValue1.Value = dateto
            ' 'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            ' 'myParameterFields.Add(myParameterField1)

            ' Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            ' Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            '' Dim userName As String = Session("cdsnumber").ToString()
            ' myParameterField.ParameterFieldName = "cdsnumber"
            ' myDiscreteValue.Value = datefrom
            ' myParameterField.CurrentValues.Add(myDiscreteValue)
            ' myParameterFields.Add(myParameterField)

            ' 'Dim myParameterField1 As New CrystalDecisions.Shared.ParameterField()
            ' 'Dim myDiscreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue()
            ' 'myParameterField1.ParameterFieldName = "pdateto"
            ' 'myDiscreteValue1.Value = dateto
            ' 'myParameterField1.CurrentValues.Add(myDiscreteValue1)
            ' 'myParameterFields.Add(myParameterField1)

            ' 'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            ' 'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            ' 'myParameterField.ParameterFieldName = "pdatefrom"
            ' 'myDiscreteValue.Value = datefrom
            ' 'myParameterField.CurrentValues.Add(myDiscreteValue)
            ' 'myParameterFields.Add(myParameterField)

            ' CrystalReportViewer1.ReportSource = Session("Report")
            ' CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            ' CrystalReportViewer1.RefreshReport()

            Dim cds As String = Session("BrokerCode").ToString
            Dim kk As String = Server.MapPath("../Reporting/AccCreated.rpt")
            cryrpt.Load(kk)
'            cryrpt.SetParameterValue("broker", brokerCode)
'            cryrpt.SetParameterValue("cdsnumber", scdnumber)
            CrystalReportViewer1.ReportSource = cryrpt

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try














'        cmd = New SqlCommand("SELECT [CdsNumber] as [ATP Number], [IdNumber], adn.Surname, [Forename], [Date], [CapturedBy], adn.AccountType              ,(case         			when Status=1 then 'Approved By Transfer Sec'        	      when Status=0 then 'Not yet Approved By Transfer Sec'        	   end)  as [Status]          FROM [CDS].[dbo].[AccountNewDetails] adn join [CDS].[dbo].[SystemUsers] su on adn.CapturedBy= su.UserName          where su.companyCode='" + Session("BrokerCode").ToString() + "'          order by adn.Id desc", cn)
'
'        adp = New SqlDataAdapter(cmd)
'        adp.Fill(ds, "APP")
'        If ds.Tables(0).Rows.Count > 0 Then
'            grdApps.DataSource = ds.Tables(0)
'        Else
'            grdApps.DataSource = Nothing
'        End If
'        grdApps.DataBind()


    End Sub

'    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
'        grdApps.PageIndex = e.NewPageIndex
'        '        SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total], [AccountType], [CompanyCode], [ISIN], [DateOfInc]  FROM [CDS].[dbo].[AccountNewDetails] where Status=0
'
'             cmd = New SqlCommand("SELECT [CdsNumber] as [ATP Number], [IdNumber], adn.Surname, [Forename], [Date], [CapturedBy], adn.AccountType              ,(case         			when Status=1 then 'Approved By Transfer Sec'        	      when Status=0 then 'Not yet Approved By Transfer Sec'        	   end)  as [Status]          FROM [CDS].[dbo].[AccountNewDetails] adn join [CDS].[dbo].[SystemUsers] su on adn.CapturedBy= su.UserName          where su.companyCode='" + Session("BrokerCode").ToString() + "'          order by adn.Id desc", cn)
'
'        adp = New SqlDataAdapter(cmd)
'        adp.Fill(ds, "APP")
'        If ds.Tables(0).Rows.Count > 0 Then
'            grdApps.DataSource = ds.Tables(0)
'        Else
'            grdApps.DataSource = Nothing
'        End If
'        grdApps.DataBind()
'    End Sub
End Class
