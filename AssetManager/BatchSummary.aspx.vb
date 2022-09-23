Partial Class Reporting_BatchSummary
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
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
        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getcompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Try
            Dim ClassType As String = ""

            If rdJoint.Checked = True Then
                ClassType = "2"
            End If
            If RdInd.Checked = True Then
                ClassType = "1"
            End If
            If (RdInd.Checked = True) Then
                If (txtBatching.Text = "") Then
                    MsgBox("Enter a valid Batch Reference")
                    Exit Sub
                End If
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                'strscript += "window.open('HolderClassificationIndividual.aspx?company=" & cmbCompany.Text & "&Classfication=" & ClassType & "');"
                strscript += "window.open('BatchSummaryReportCall.aspx?Company=" & cmbCompany.Text & "&batchref=" & txtBatching.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If

            If (rdJoint.Checked = True) Then
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                'strscript += "window.open('BatchSummaryAllReportCall.aspx?Classfication=" & ClassType & "');"
                strscript += "window.open('BatchSummaryAllReportCall.aspx?company=" & cmbCompany.Text & "');"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
