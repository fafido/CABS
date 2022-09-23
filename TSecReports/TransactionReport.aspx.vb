Partial Class TSecReports_TransactionReport
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbCompany.Focus()
        Calendar1.Visible = False
        Calendar2.Visible = False
        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)
            If (Not IsPostBack) Then
                dmbOb.BindCombo("para_company", "company", cmbCompany)
                cmbCompany.Items.Insert(0, " ")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If (dtpDateFrom.Text <> "" And dtpDateTo.Text <> "" And cmbCompany.Text <> "") Then
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('frmtransactionrpt.aspx?company=" & cmbCompany.Text & "&datefrom=" & dtpDateFrom.Text & "&dateto=" & dtpDateTo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Else
            msgbox("Please Enter The Required Fields")
            Exit Sub

        End If

    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        dtpDateFrom.Text = Calendar1.SelectedDate
        Calendar1.Visible = False
        Calendar1.SelectedDate = Nothing

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Calendar2.Visible = True
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        dtpDateTo.Text = Calendar2.SelectedDate
        Calendar2.Visible = False
        Calendar2.SelectedDate = Nothing
    End Sub

    Protected Sub Calendar2_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar2.VisibleMonthChanged
        Calendar2.Visible = True
    End Sub

    Protected Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        Calendar1.Visible = True
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

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Calendar1.Visible = True
    End Sub
End Class
