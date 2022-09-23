Partial Class TSecAudit_AuditandReports
    Inherits System.Web.UI.Page
    Dim dmbOb As New BindCombo
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Dim strscript As String
            If (txtfrom.Text <> "" And txtto.Text <> "" And cmbCompany.Text <> "") Then

                If (RadioButtonList1.SelectedValue = "0") Then
                    strscript = "<script langauage=JavaScript>"
                    strscript += "window.open('frmNewAuditprint.aspx?fromdate=" & txtfrom.Text & "&todate=" & txtto.Text & "&type=" & RadioButtonList1.SelectedValue & "&company=" & cmbCompany.Text & "&astatus=" & ddlStatus.SelectedValue & "');"
                    strscript += "</script>"
                Else
                    strscript = "<script langauage=JavaScript>"
                    strscript += "window.open('frmAuditprint.aspx?fromdate=" & txtfrom.Text & "&todate=" & txtto.Text & "&type=" & RadioButtonList1.SelectedValue & "&company=" & cmbCompany.Text & "&astatus=" & ddlStatus.SelectedValue & "');"
                    strscript += "</script>"
                End If
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            Else
                msgbox("From and To date is not entered")
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            txtfrom.Focus()
            Calendar1.Visible = False
            Calendar2.Visible = False
            If (Not IsPostBack) Then
                RadioButtonList1.SelectedIndex = 0
                dmbOb.BindCombo("para_company", "company", cmbCompany)

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
        txtfrom.Text = Calendar1.SelectedDate
        Calendar1.SelectedDate = Nothing
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Calendar1.Visible = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Calendar2.Visible = True
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        Calendar2.Visible = False
        txtto.Text = Calendar2.SelectedDate
        Calendar2.SelectedDate = Nothing
    End Sub

    Protected Sub Calendar2_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar2.VisibleMonthChanged
        Calendar2.Visible = True
    End Sub


End Class
