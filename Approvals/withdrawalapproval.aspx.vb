
Partial Class Approvals_withdrawalapproval
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
            'getclasses_param()
            getpending()
        End If
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Successful")
            End If
            If Session("finish") = "rejected" Then
                Session("finish") = ""
                msgbox("Withdrawal Successful")
            End If
        Catch ex As Exception
        msgbox(ex.Message)
    End Try
End Sub

Protected Sub ASPxTextBox12_TextChanged(sender As Object, e As EventArgs) Handles txttransferorname.TextChanged

End Sub



Public Sub getpending()

    Dim ds As New DataSet
        cmd = New SqlCommand("select id, EWR_holder+' '+ Company+' '+convert(nvarchar(50), amount_to_withdraw) as [Det] from withdrawals where status='0' and ParticipantCode='" + Session("Brokercode") + "' and rejected is NULL and approvedby is NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
    If (ds.Tables(0).Rows.Count > 0) Then
        cmbpending.DataSource = ds
            cmbpending.TextField = "Det"
            cmbpending.ValueField = "id"
            cmbpending.DataBind()

    End If
End Sub


Public Sub loadnames()
    Dim ds As New DataSet
        cmd = New SqlCommand("select * from withdrawals where id='" + cmbpending.SelectedItem.Value + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "withdrawals")
        If (ds.Tables(0).Rows.Count > 0) Then
            txttransferorid.Text = ds.Tables(0).Rows(0).Item("EWR_holder")

            txtreceipt.Text = ds.Tables(0).Rows(0).Item("receiptid")
            txtshares.Text = ds.Tables(0).Rows(0).Item("amount_to_withdraw")
            txtcomp.text = ds.Tables(0).Rows(0).Item("company")
        '       getclasses()


    End If
End Sub

Public Sub getnames()
    Dim ds1 As New DataSet
        cmd = New SqlCommand("select isnull ( Surname,'')+' '+isnull (Middlename,'')+' '+isnull(Forenames,'') as account  from accounts_clients where cds_Number='" + txttransferorid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "accounts_clients")
        If (ds1.Tables(0).Rows.Count > 0) Then
            txttransferorname.Text = ds1.Tables(0).Rows(0).Item("account")


        End If
End Sub
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from account_transfer where cds_number='" + txttransferorid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "account_transfer")
        If (ds1.Tables(0).Rows.Count > 0) Then
            cmd = New SqlCommand("Update account_transfer set to_broker=(select company_code  from client_companies where company_name='" + +"') where cds_number='" + txttransferorid.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        Else
            '   cmd = New SqlCommand("insert into account_transfer values ('" + txtclientid.Text + "','" + Session("brokercode") + "',(select company_code  from client_companies where company_name='" + +"'), '" + txtComments.Text + "',GEtdate(),0)", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
    End Sub

    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            ' insert into trans (company, cds_number, Date_Created, trans_time, shares, update_type, Created_By, Batch_Ref, [source], Pledge_shares, reference, warehouse, WarehouseOperator) select Commodity+'/'+grade, holder, getdate(), getdate(), " + txtshares.Text + "*-1, 'Withdrawal', '" + Session("Username") + "', id,'D','0','" + txtreceipt.Text + "',Warehouse, WarehousePhysical    from wr WHERE ReceiptNo='" + txtreceipt.Text + "' update wr set quantity=quantity-" + txtshares.Text + " where receiptno='" + txtreceipt.Text + "'   
            Dim OTP As String = CreateRandomPassword(4)
            cmd = New SqlCommand("insert into trans (company, cds_number, Date_Created, trans_time, shares, update_type, Created_By, Batch_Ref, [source], Pledge_shares, reference, warehouse, WarehouseOperator) select Commodity+'/'+grade, holder, getdate(), getdate(), quantity *-1, 'Withdrawal','" + Session("Username") + "' , id,'D','0','" + txtreceipt.Text + "',Warehouse, WarehousePhysical    from wr WHERE ReceiptNo='" + txtreceipt.Text + "'  update wr set [Status]='WITHDRAWN'   where receiptno=@receiptno update withdrawals set Approvedby='" + Session("Username") + "', approveddate=getdate() where id='" + cmbpending.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try


    End Sub



Protected Sub cmbpending_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpending.SelectedIndexChanged
    loadnames()
    getnames()

End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Try
            cmd = New SqlCommand("Update withdrawals set rejected='1' where id='" + cmbpending.SelectedItem.Value + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("finish") = "rejected"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
End Class