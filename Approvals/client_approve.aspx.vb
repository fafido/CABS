
Partial Class Approvals_client_approve
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select codes from pledges_release where pledge_Id='" + Request.QueryString("ref") + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "sec_types")
                If (ds.Tables(0).Rows.Count > 0) Then
                    If ds.Tables(0).Rows(0).Item("codes").ToString = Request.QueryString("num") Then
                        cmd = New SqlCommand("Update Pledges_release set codes='Used', release_approval='Yes' where pledge_id='" + Request.QueryString("ref") + "'", cn)
                        If (cn.State = ConnectionState.Open) Then
                            cn.Close()
                        End If
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()

                        msgbox("Pledge release successfully approved")
                    Else
                        msgbox("Invalid Link")
                    End If


                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
