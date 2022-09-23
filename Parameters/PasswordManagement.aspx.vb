Partial Class Parameters_PasswordManagement
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
                getdetails()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getdetails()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from tbl_passwordpolicy", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtminlength.Text = ds.Tables(0).Rows(0).Item("MinPasswordLength").ToString
            txtmaxlength.Text = ds.Tables(0).Rows(0).Item("MaxPasswordLength").ToString
            txtattempts.Text = ds.Tables(0).Rows(0).Item("LockoutAttempt").ToString
            txtvalidity.Text = ds.Tables(0).Rows(0).Item("Validity").ToString
            cmbPasswordType.Text = ds.Tables(0).Rows(0).Item("PasswordType").ToString
        End If
    End Sub


    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try
            cmd = New SqlCommand("update tbl_passwordPolicy set minpasswordlength='" + txtminlength.Text + "', passwordtype='" + cmbPasswordType.Text + "', validity='" + txtvalidity.Text + "', LockoutAttempt='" + txtattempts.Text + "', setby='" + Session("Username") + "', setdate=getdate(), maxpasswordLength='" + txtmaxlength.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getdetails()

            msgbox("Password Policy Updated!")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
