Partial Class TSecEnquiries_DividendHistoryEnquiry
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim adp As New SqlDataAdapter
    Dim cnstr As String
    Dim dmbOb As New BindCombo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True

        Try
            cnstr = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
            cn = New SqlConnection(cnstr)

            If (Not IsPostBack) Then
                dmbOb.BindCombo("div_instr", "company", cmbCompany)

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

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If (Not IsNumeric(txtShareholder.Text)) Then
                msgbox("Please Enter Numeric value for Shareholder")
                txtShareholder.Focus()
                Exit Sub
            End If

            If (cmbCompany.Text <> "" And txtShareholder.Text <> "") Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('RPTPrintStatementReport.aspx?company=" & cmbCompany.Text & "&shareholder=" & txtShareholder.Text & "');"
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
