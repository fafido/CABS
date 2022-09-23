Partial Class Parameters_AccountsManagement
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub chkMonths_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonths.CheckedChanged
        Try
            If (chkMonths.Checked = True) Then
                chkMonths0.Checked = False
                lblPeriod1.Text = "Months"
                lblPeriod2.Text = "Months"
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub chkMonths0_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonths0.CheckedChanged
        If (chkMonths0.Checked = True) Then
            chkMonths.Checked = False
            lblPeriod1.Text = "Years"
            lblPeriod2.Text = "Years"
        End If
    End Sub
End Class
