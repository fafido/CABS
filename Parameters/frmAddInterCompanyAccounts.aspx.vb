Imports DevExpress.Web.ASPxGridView

Partial Class Parameters_InterCompanyAccountsSetup
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
                getSavedAcounts()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clearall()
        txtAccountName.Text = ""
        txtAccountNumber.Text = ""
        txtRecordID.Text = ""
        ASPxButton7.Text = "Save"
        getSavedAcounts()
    End Sub
    Function AccNameExists(ByVal accName As String) As Boolean
        cmd = New SqlCommand("SELECT DISTINCT A.AccountName FROM Para_InterCompanyAccountsAudit A WHERE ISNULL(A.AuditStatus,0)=0 AND A.AccountName=@AccountName UNION SELECT DISTINCT B.AccountName FROM Para_InterCompanyAccounts B WHERE B.AccountName=@AccountName", cn)
        cmd.Parameters.AddWithValue("@AccountName", accName)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_InterCompanyAccounts")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function AccNumberExists(ByVal accNumber As String) As Boolean
        cmd = New SqlCommand("SELECT DISTINCT A.AccountNumber FROM Para_InterCompanyAccountsAudit A WHERE ISNULL(A.AuditStatus,0)=0 AND A.AccountNumber=@AccountNumber UNION SELECT DISTINCT B.AccountNumber FROM Para_InterCompanyAccounts B WHERE B.AccountNumber=@AccountNumber", cn)
        cmd.Parameters.AddWithValue("@AccountNumber", accNumber)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_InterCompanyAccounts")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function PendingAUTHRecord() As Boolean
        cmd = New SqlCommand("SELECT A.* FROM Para_InterCompanyAccountsAudit A WHERE ISNULL(A.AuditStatus,0)=0 AND A.RecordID=@RecordID", cn)
        cmd.Parameters.AddWithValue("@RecordID", txtRecordID.Text.Trim)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_InterCompanyAccounts")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        If ASPxButton7.Text = "Save" Then
            If txtAccountName.Text.Trim <> "" And txtAccountNumber.Text.Trim <> "" Then
                If AccNameExists(txtAccountName.Text.Trim) = True Then
                    msgbox("Account Name exists")
                    Exit Sub
                ElseIf AccNumberExists(txtAccountNumber.Text.Trim) = True Then
                    msgbox("Account Number exists")
                    Exit Sub
                Else
                    cmd = New SqlCommand("INSERT INTO Para_InterCompanyAccountsAudit([AccountName],[AccountNumber],[CreatedBy],[UpdateType])VALUES(@AccountName,@AccountNumber,@CreatedBy,'NEW')", cn)
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text.Trim)
                    cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text.Trim)
                    cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()
                    getSavedAcounts()
                    clearall()
                    msgbox("Account successfully saved, pending authorization")
                End If
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        Else
            If txtAccountName.Text.Trim <> "" And txtAccountNumber.Text.Trim <> "" And IsNumeric(txtRecordID.Text) = True Then
                If PendingAUTHRecord() = True Then
                    msgbox("Same account has been edited and is pending authorization")
                    Exit Sub
                Else
                    cmd = New SqlCommand("INSERT INTO Para_InterCompanyAccountsAudit([AccountName],[AccountNumber],[CreatedBy],[UpdateType],[OldAccountName],[OldAccountNumber],[RecordID])SELECT @AccountName,@AccountNumber,@CreatedBy,'UPDATE',G.AccountName,G.AccountNumber,@RecordID FROM Para_InterCompanyAccounts G WHERE G.ID=@RecordID", cn)
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text.Trim)
                    cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text.Trim)
                    cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
                    cmd.Parameters.AddWithValue("@RecordID", txtRecordID.Text.Trim)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    Dim y As Integer = cmd.ExecuteNonQuery()
                    cn.Close()
                    getSavedAcounts()
                    clearall()
                    msgbox("Account successfully updated, pending authorization")
                End If
            Else
                msgbox("Enter All Details")
                Exit Sub
            End If
        End If
    End Sub
    Protected Sub getSavedAcounts()
        Try
            cmd = New SqlCommand("select * from Para_InterCompanyAccounts ORDER BY ID DESC", cn)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_InterCompanyAccounts")
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
        cmd = New SqlCommand("select * from Para_InterCompanyAccounts where ID='" + RecordID + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Para_InterCompanyAccounts")
        If ds.Tables(0).Rows.Count > 0 Then
            txtAccountName.Text = ds.Tables(0).Rows(0).Item("AccountName").ToString
            txtAccountNumber.Text = ds.Tables(0).Rows(0).Item("AccountNumber").ToString
            txtRecordID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
            ASPxButton7.Text = "Update"
        Else
            txtAccountName.Text = ""
            txtAccountNumber.Text = ""
            txtRecordID.Text = ""
            ASPxButton7.Text = "Save"
        End If
    End Sub
    Private Sub ASPxGridView2_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView2.RowCommand
        Dim idd As String = e.CommandArgs.CommandArgument.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            getinfortoedit(idd)
        ElseIf e.CommandArgs.CommandName.ToString = "Delete" Then
            If PendingAUTHRecord() = True Then
                msgbox("Same account has been edited and is pending authorization")
                Exit Sub
            End If
            cmd = New SqlCommand("INSERT INTO Para_InterCompanyAccountsAudit([AccountName],[AccountNumber],[CreatedBy],[UpdateType],[OldAccountName],[OldAccountNumber],[RecordID])SELECT G.AccountName,G.AccountNumber,@CreatedBy,'DELETE',G.AccountName,G.AccountNumber,@RecordID FROM Para_InterCompanyAccounts G WHERE G.ID=@RecordID", cn)
            cmd.Parameters.AddWithValue("@CreatedBy", Session("Username"))
            cmd.Parameters.AddWithValue("@RecordID", idd)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim y As Integer = cmd.ExecuteNonQuery()
            cn.Close()
            getSavedAcounts()
            clearall()
            msgbox("Account removed, pending authorization")
        End If
    End Sub
End Class
