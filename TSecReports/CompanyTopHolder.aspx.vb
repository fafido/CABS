Partial Class TSecReports_CompanyTopHolder
    Inherits System.Web.UI.Page
    Dim com As SqlCommand
    Dim con As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim da As SqlDataAdapter
    Dim dmbob As New BindCombo


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        cmbCompany.Focus()
        Calendar1.Visible = False
        Try
            'cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            'cn = New SqlConnection(cnstr)
            If (Not IsPostBack) Then
                dmbOb.BindCombo("mast", "company", cmbCompany)
                'BindShareholder()
            End If
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

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim str As String
            Dim ds As New DataSet
            If (cmbCompany.Text = "" Or Top.Text = "" Or DateCreated.Text = "") Then
                msgbox("Please Enter Required Values")
                Exit Sub
            End If


            If IsNumeric(Top.Text) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('topshareholderrept.aspx?comp=" & cmbCompany.Text & "&dat=" & DateCreated.Text & "&top=" & Top.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

                'str = "select top " & CInt(Top.Text) & " * from top_table where company='" & cmbCompany.Text & "' and date_created<='" & DateCreated.SelectedDate & "'"
                ''con = New SqlConnection(cnstr)
                'com = New SqlCommand(str, cn)
                'da = New SqlDataAdapter(com)
                'da.Fill(ds, "country")
                'Dim myReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                'myReport.Load(Server.MapPath("..\Reports(Normal)\rptcompanystatsCountry.rpt"))
                'myReport.SetDataSource(ds.Tables(0))
                'CrystalReportViewer1.ReportSource = myReport
                'myReport.Refresh()

            Else
                msgbox("Entered top value is invalid")

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Calendar1.Visible = False
        DateCreated.Text = Calendar1.SelectedDate
        Calendar1.SelectedDate = Nothing
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Calendar1.Visible = True
    End Sub
End Class
