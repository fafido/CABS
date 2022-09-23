Partial Class TSecReports_IssuedShareCapitalCheck
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo
    Dim dsIndusty As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        cmbCompany.Focus()
        Dim dsCmbComp As New DataSet
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)

            If (Not IsPostBack) Then
                dmbOb.BindCombo("all_companies", "company", cmbCompany)

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

    Protected Sub btnFromDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFromDate.Click
        Try
            cal1.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cal1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cal1.SelectionChanged
        Try
            txtFromDate.Text = cal1.SelectedDate
            cal1.SelectedDate = Nothing
            cal1.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cal1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal1.VisibleMonthChanged
        Try
            cal1.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Protected Sub btnToDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToDate.Click
    '    Try
    '        cal2.Visible = True
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub cal2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cal2.SelectionChanged
    '    Try
    '        txtToDate.Text = cal2.SelectedDate
    '        cal2.SelectedDate = Nothing
    '        cal2.Visible = False
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub cal2_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal2.VisibleMonthChanged
    '    Try
    '        cal2.Visible = True
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try


            If (cmbCompany.Text <> "" And txtFromDate.Text <> "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('RPTIssuedSharesCapital.aspx?company=" & cmbCompany.Text & "&fromdate=" & txtFromDate.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

            Else
                msgbox("Please Enter Necessary Fields")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
