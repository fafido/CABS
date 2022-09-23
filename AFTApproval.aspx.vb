Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_AFTApproval
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
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "rejected" Then
                Session("finish") = ""
                msgbox(Session("msg"))
                Session("msg") = ""
            End If
            If Session("finish") = "otp" Then
                Session("finish") = ""
                msgbox("OTP has been resent!")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                loadreceiptdetails()

                getpending()

                getrejected()

            Else

            End If
            getrejected()
            getpending()

            loadreceiptdetails()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function isOTPsent(ref As String) As Boolean

        Dim ds1 As New DataSet
        cmd = New SqlCommand("select * from AFT where id='" + ref + "' and  OTP is NOT NULL AND OTPStatus<>'Approved'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "account_transfer")
        If (ds1.Tables(0).Rows.Count > 0) Then
            Return False
        Else
            Return True
        End If
    End Function




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



    Protected Sub ASPxButton13_Click(sender As Object, e As EventArgs) Handles ASPxButton13.Click
        'Try

        ' Dim OTP As String = CreateRandomPassword(4)
        Dim cmdstring As String = ""
            If txttype.Text = "Mark AFT" Then
                cmdstring = "UPDATE wr SET [Status]='AFT' WHERE ReceiptNo='" + cmbparaCompany.Text + "' UPDATE AFT SET [Status]='C', ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() WHERE id='" + txtid.Text + "'"
            Else
                cmdstring = "UPDATE wr SET [Status]='ISSUED' WHERE ReceiptNo='" + cmbparaCompany.Text + "' UPDATE AFT SET [Status]='C', ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() WHERE id='" + txtid.Text + "'"
            End If
            cmd = New SqlCommand(cmdstring, cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            Session("finish") = "yes"
            Session("msg") = "AFT request for EWR No. " + cmbparaCompany.Text + " has been successfully authorized. Transaction ID is " + txtid.Text + ""
            Response.Redirect(Request.RawUrl)
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try

    End Sub

    Public Function accountbalance(accountno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0) as [totalowing] from cashtrans where cds_Number='" + accountno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("totalowing").ToString
        Else
            Return 0
        End If
    End Function
    Public Sub getpending()

        Dim ds As New DataSet
        cmd = New SqlCommand("select w.id, W.EWR_Holder as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], W.AFT_Quantity ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from AFT W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        Else
            ASPxGridView3.DataSource = Nothing
            ASPxGridView3.DataBind()
        End If
    End Sub
    Public Sub getrejected()

        Dim ds As New DataSet
        cmd = New SqlCommand("select w.id, W.EWR_Holder as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending'  when w.rejected='1'  THEN 'Rejected' else 'Approved' end as  [Status],  W.[Date], W.AFT_Quantity ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from AFT W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and w.deleted is Null and w.rejected is NOT NULL", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView4.DataSource = ds
            ASPxGridView4.DataBind()
        Else
            ASPxGridView4.DataSource = Nothing
            ASPxGridView4.DataBind()
        End If
    End Sub
    Public Sub loaddetails(holder As String)

        Dim ds As New DataSet
        cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name, a.cds_Number  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + holder + "'", cn)
        ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names1")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            txtewraccountno.Text = ds.Tables(0).Rows(0).Item("cds_number")
        End If
    End Sub
    Public Sub loadcomboforreceipts(holder As String)
        Dim dsport As New DataSet
        cmd = New SqlCommand("select * from WR where holder='" + holder + "' and [Status]='ISSUED' and quantity>0 and status='ISSUED'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbparaCompany.DataSource = dsport

            cmbparaCompany.DataBind()
        End If
    End Sub
    Public Sub loadreceiptdetails()
        Dim xyz As New Common
        Dim dsport As New DataSet
        If xyz.OTPenabled = True Then
            cmd = New SqlCommand("select * from WR where receiptno in (select receiptid from AFT  where status='0' and ParticipantCode='" + Session("Brokercode") + "' and rejected is NULL and approvedby is NULL and OTPStatus='Approved' and deleted is NULL)", cn)
        Else
            cmd = New SqlCommand("select * from WR where receiptno in (select receiptid from AFT  where status='0' and ParticipantCode='" + Session("Brokercode") + "' and rejected is NULL and approvedby is NULL and deleted is NULL) ", cn)
        End If


        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView5.DataSource = dsport
            ASPxGridView5.DataBind()

        End If
    End Sub



    Private Sub cmbparaCompany_ValueChanged(sender As Object, e As EventArgs) Handles cmbparaCompany.ValueChanged
        '   loadcomboforreceipts(ListBox1.SelectedValue.ToString)
    End Sub

    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Select" Then
            getinfortoedit(id.ToString)


        End If
    End Sub
    Public Sub getinfortoedit(receipt As String)
        cmd = New SqlCommand("select wr.holder, wr.receiptno,w.AFT_Type ,w.AFT_Quantity, w.capturedBy, w.capturedate, w.id    from wr , AFT w  where receiptno='" + receipt + "' and wr.receiptno=w.receiptid and w.ApprovedBy is NULL", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("holder").ToString
            loaddetails(txtewrholder.Text)
            cmbparaCompany.Value = receipt
            txtavailableshares.Text = ds.Tables(0).Rows(0).Item("AFT_Quantity").ToString
            txtcapturedate.Text = ds.Tables(0).Rows(0).Item("capturedate").ToString
            txtcapturedby.Text = ds.Tables(0).Rows(0).Item("capturedBy").ToString
            txtshares.Text = ds.Tables(0).Rows(0).Item("AFT_Quantity").ToString
            txtid.Text = ds.Tables(0).Rows(0).Item("id").ToString
            txttype.Text = ds.Tables(0).Rows(0).Item("AFT_Type").ToString
        End If
    End Sub

    Protected Sub ASPxButton14_Click(sender As Object, e As EventArgs) Handles ASPxButton14.Click
        If txtrejectreason.Visible = False Then
            txtrejectreason.Visible = True
            msgbox("Please enter reject reason and press reject!")
        Else
            If txtrejectreason.Text <> "" Then
                Try
                    cmd = New SqlCommand(" update AFT set rejected='1', approveddate=getdate(), rejectionreason='" + txtrejectreason.Text + "' where id='" + txtid.Text + "'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Session("finish") = "rejected"

                    Session("msg") = "AFT request for EWR No. " + cmbparaCompany.Text + " has been rejected successfully. "
                    Response.Redirect(Request.RawUrl)
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            Else
                msgbox("Please enter rejection reason!")
            End If
        End If
    End Sub
    Protected Sub txtcapturedby_TextChanged(sender As Object, e As EventArgs) Handles txtcapturedby.TextChanged

    End Sub

    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Resend" Then
            If isOTPsent(id) = True Then

                msgbox("Transaction status does not allow OTP to be resent!")
            Else
                Dim OTP As String = CreateRandomPassword(4)
                cmd = New SqlCommand(" update AFT set  OTP='" + OTP + "',OTPSent='1' ,OTPCreateTime=getdate() where id='" + id.ToString + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



                Session("finish") = "otp"
                Response.Redirect(Request.RawUrl)
            End If



        End If

    End Sub

End Class
