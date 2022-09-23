Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_ApproveInterCompanyAccountsSetup
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getPendingAuthAccounts()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtAccountName.Text = ""
        txtAccountNumber.Text = ""
        txtRecordID.Text = ""
        txtAuditID.Text = ""
        txtCreatedUpdateBy.Text = ""
        txtDateTimeCreatedUpdated.Text = ""
        txtUpdateType.Text = ""
        txtOLDAccountName.Text = ""
        txtOLDAccountNumber.Text = ""
        getPendingAuthAccounts()
    End Sub
    Function OwnCreation(ByVal AuditID As String) As Boolean
        cmd = New SqlCommand("SELECT A.* FROM Para_InterCompanyAccountsAudit A WHERE A.ID=@AuditID", cn)
        cmd.Parameters.AddWithValue("@AuditID", AuditID)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_InterCompanyAccountsAudit")
        If ds.Tables(0).Rows.Count > 0 Then
            If Session("Username") = ds.Tables(0).Rows(0).Item("CreatedBy").ToString Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Protected Sub getPendingAuthAccounts()
        Try
            cmd = New SqlCommand("SELECT * FROM Para_InterCompanyAccountsAudit where isnull(AuditStatus,0)=0 ORDER BY ID DESC", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_InterCompanyAccountsAudit")
            If ds.Tables(0).Rows.Count > 0 Then
                ASPxGridView2.DataSource = ds.Tables(0)
            Else
                ASPxGridView2.DataSource = Nothing
            End If
            ASPxGridView2.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getinfortoedit(ByVal RecordID As String)
        cmd = New SqlCommand("select *,FORMAT(DateCreated,'dd-MMM-yyyy hh:mm tt','en-us') AS DateTimeCreated1 from Para_InterCompanyAccountsAudit where ID='" + RecordID + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_InterCompanyAccountsAudit")
        If ds.Tables(0).Rows.Count > 0 Then
            txtAccountName.Text = ds.Tables(0).Rows(0).Item("AccountName").ToString
            txtAccountNumber.Text = ds.Tables(0).Rows(0).Item("AccountNumber").ToString
            txtRecordID.Text = ds.Tables(0).Rows(0).Item("RecordID").ToString
            txtAuditID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
            txtCreatedUpdateBy.Text = ds.Tables(0).Rows(0).Item("CreatedBy").ToString
            txtDateTimeCreatedUpdated.Text = ds.Tables(0).Rows(0).Item("DateTimeCreated1").ToString
            txtUpdateType.Text = ds.Tables(0).Rows(0).Item("UpdateType").ToString
            txtOLDAccountName.Text = ds.Tables(0).Rows(0).Item("OLDAccountName").ToString
            txtOLDAccountNumber.Text = ds.Tables(0).Rows(0).Item("OLDAccountNumber").ToString
        Else
            txtAccountName.Text = ""
            txtAccountNumber.Text = ""
            txtRecordID.Text = ""
            txtAuditID.Text = ""
            txtCreatedUpdateBy.Text = ""
            txtDateTimeCreatedUpdated.Text = ""
            txtUpdateType.Text = ""
            txtOLDAccountName.Text = ""
            txtOLDAccountNumber.Text = ""
        End If
    End Sub
    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim idd As String = e.CommandArgs.CommandArgument.ToString
        If e.CommandArgs.CommandName.ToString = "Select" Then
            getinfortoedit(idd)
        End If
    End Sub
    Protected Sub rdReject_CheckedChanged(sender As Object, e As EventArgs) Handles rdReject.CheckedChanged
        Try
            If (rdReject.Checked = True) Then
                lblRejection.Visible = True
                txtReasons.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdApprove_CheckedChanged(sender As Object, e As EventArgs) Handles rdApprove.CheckedChanged
        Try
            If (rdApprove.Checked = True) Then
                lblRejection.Visible = False
                txtReasons.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        If IsNumeric(txtAuditID.Text.Trim) = False Then
            msgbox("Select record to approve/reject")
            Exit Sub
        ElseIf OwnCreation(txtAuditID.Text.Trim) = True Then
            msgbox("You cannot approve your own creation")
            Exit Sub
        ElseIf rdApprove.Checked = False And rdReject.Checked = False Then
            msgbox("Select Option Approve or Reject")
            Exit Sub
        ElseIf rdReject.Checked = True And txtReasons.Text.Trim = "" Then
            msgbox("Enter Rejection reason")
            Exit Sub
        Else
            Dim str_dispMsg As String = ""
            Dim Str_comms As String = ""
            If rdApprove.Checked = True Then
                If txtUpdateType.Text = "NEW" Then
                    str_dispMsg = "Account successfully approved"
                    Str_comms = " INSERT INTO Para_InterCompanyAccounts([AccountName], [AccountNumber], [CreatedBy]) SELECT A.[AccountName], A.[AccountNumber], A.[CreatedBy] FROM Para_InterCompanyAccountsAudit A WHERE A.ID=@RecordID UPDATE Para_InterCompanyAccountsAudit SET AuditStatus=1,AuthorizedBy=@AuthorizedBy,AuthorizedDate=GETDATE() WHERE ID=@RecordID "
                ElseIf txtUpdateType.Text = "UPDATE" Then
                    str_dispMsg = "Account successfully approved"
                    Str_comms = " UPDATE A SET A.[AccountName]=B.[AccountName],A.[AccountNumber]=B.[AccountNumber] FROM Para_InterCompanyAccounts A JOIN Para_InterCompanyAccountsAudit B ON A.ID=B.RecordID WHERE B.ID=@RecordID UPDATE Para_InterCompanyAccountsAudit SET AuditStatus=1,AuthorizedBy=@AuthorizedBy,AuthorizedDate=GETDATE() WHERE ID=@RecordID "
                ElseIf txtUpdateType.Text = "DELETE" Then
                    str_dispMsg = "Account successfully deleted"
                    Str_comms = " DELETE A FROM Para_InterCompanyAccounts A JOIN Para_InterCompanyAccountsAudit B ON A.ID=B.RecordID WHERE B.ID=@RecordID UPDATE Para_InterCompanyAccountsAudit SET AuditStatus=1,AuthorizedBy=@AuthorizedBy,AuthorizedDate=GETDATE() WHERE ID=@RecordID "
                End If
            ElseIf rdReject.Checked = True Then
                str_dispMsg = "Entry has been rejected"
                Str_comms = " UPDATE Para_InterCompanyAccountsAudit SET AuditStatus=2,AuthorizedBy=@AuthorizedBy,AuthorizedDate=GETDATE(),RejectReason=@RejectReason WHERE ID=@RecordID "
            End If
            cmd = New SqlCommand(Str_comms, cn)
            cmd.Parameters.AddWithValue("@AuthorizedBy", Session("Username"))
            cmd.Parameters.AddWithValue("@RecordID", txtAuditID.Text.Trim)
            cmd.Parameters.AddWithValue("@RejectReason", txtReasons.Text.Trim)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim y As Integer = cmd.ExecuteNonQuery()
            cn.Close()
            clearall()
            msgbox(str_dispMsg)
        End If
    End Sub
End Class
