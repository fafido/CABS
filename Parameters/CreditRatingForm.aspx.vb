Partial Class Parameters_CreditRatingForm
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Sub msgbox(ByVal strMessage As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company_name) from Client_Companies", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_Companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.DataSource = ds.Tables(0)
                cmbParticipants.DataValueField = "company_name"
                cmbParticipants.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetTypes()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                GetParticipants()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
