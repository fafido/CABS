
Partial Class BA_Payments
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand

    Protected Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If txtRef.Text <> "" Then
            cmd = New SqlCommand("update Accepted_offers set ref_number='" + txtRef.Text + "'  , payment_notification=1, payment_confirmation=0, trans_date=GETDATE() where id='" + Request.QueryString("id") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "yes"
            Response.Redirect("payment.aspx")
        End If
    End Sub
    Public Sub GetDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_BATranTypes", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_BATranTypes")
            If (ds.Tables(0).Rows.Count > 0) Then
                ddlTransType.DataSource = ds.Tables(0)
                ddlTransType.DataTextField = "Description"
                ddlTransType.DataValueField = "TranType"
                ddlTransType.DataBind()
            End If
        Catch ex As Exception

            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetParticipantBAs()
        'If (Not IsPostBack) Then
        Try
            Dim ds As New DataSet
            If txtBANum.Text = "" Then
                cmd = New SqlCommand("select BA_number,Principal_Name,Issuer,Accept_Participant from BAs where Issuer='" & lblParticipant.Text & "' or Accept_Participant ='" & lblParticipant.Text & "'", cn)
            Else
                cmd = New SqlCommand("select BA_number,Principal_Name,Issuer,Accept_Participant from BAs where (Issuer='" & lblParticipant.Text & "' and BA_number like '" & txtBANum.Text & "%') OR (Accept_Participant ='" & lblParticipant.Text & "' and BA_number like '" & txtBANum.Text & "%')", cn)
            End If
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BAs")
            dtlBAs.Visible = True
            If (ds.Tables(0).Rows.Count > 0) Then
                dtlBAs.DataSource = ds.Tables(0)
                dtlBAs.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
        'End If
    End Sub
    Public Sub msgbox(ByVal strMessage As String)
        'If (Not IsPostBack) Then
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
        'End If

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetDetails()
        lblParticipant.Text = Session("BrokerCode")
        txtBANum.Text = Request.QueryString("ba_number")
        dtpValueDate.Text = Now.Date ' "11/19/2014"



        'GetParticipantBAs()
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles btnSearchBA.Click
        GetParticipantBAs()
    End Sub

    Protected Sub dtlBAs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dtlBAs.SelectedIndexChanged
        txtBANum.Text = dtlBAs.SelectedRow.Cells(1).Text
        dtlBAs.Visible = False
    End Sub
End Class
