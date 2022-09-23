Partial Class CDSMode_AccountsVerification1
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

    Protected Sub rdIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles rdIndividual.CheckedChanged
        Try
            If (rdIndividual.Checked = True) Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdJoint_CheckedChanged(sender As Object, e As EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Then
                txtJforenames.Visible = True
                txtJsurname.Visible = True
                lblJforenames.Visible = True
                lblJSurname.Visible = True
                btnJadd.Visible = True
                grdJointAccounts.Visible = True
            Else
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdJoint0_CheckedChanged(sender As Object, e As EventArgs) Handles rdCorprate.CheckedChanged
        Try
            If rdCorprate.Checked = True Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdBroker_CheckedChanged(sender As Object, e As EventArgs) Handles rdBroker.CheckedChanged
        If (rdBroker.Checked = True) Then
            txtJforenames.Visible = False
            txtJsurname.Visible = False
            lblJforenames.Visible = False
            lblJSurname.Visible = False
            btnJadd.Visible = False
            grdJointAccounts.Visible = False
        End If
    End Sub

    Protected Sub cmbNationality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNationality.SelectedIndexChanged

    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click

    End Sub
End Class
