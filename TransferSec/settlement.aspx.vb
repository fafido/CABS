Imports DevExpress.Web.ASPxGridView

Partial Class TransferSec_settlement
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
        cmd = New SqlCommand("select * from Pmextrans where id='" + ref + "' and  OTP is NOT NULL AND OTPStatus<>'Approved'", cn)
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
    Public Function receiptbala(holder As String, ewr As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as tot from trans where cds_number='" + holder + "' and reference='" + ewr + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("tot").ToString
        End If
    End Function


    Protected Sub ASPxButton13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASPxButton13.Click

        cmd = New SqlCommand("select w.transferor, w.transferee ,wr.receiptno, w.amount_to_transfer, w.capturedBy, w.capturedate, min(w.id) as id, w.warehouse_charges, w.cmc_charges, w.transfer_charges     from wr , pmextrans w  where receiptno='" + cmbparaCompany.Text + "' and wr.receiptno=w.receiptid and w.ApprovedBy is NULL and w.deleted is NULL AND rejectionreason is NULL AND W.[Status] is NULL group by transferor, transferee, ReceiptNo , amount_to_transfer, CapturedBy, CaptureDate,w.warehouse_charges, w.cmc_charges, w.transfer_charges  order by min(w.id) asc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")

        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim bala As Decimal = txtavailableshares.Text
                Dim OTP As String = CreateRandomPassword(4)
                Dim quantity As String = ds.Tables(0).Rows(i).Item("amount_to_transfer").ToString
                Dim transferor As String = ds.Tables(0).Rows(i).Item("transferor").ToString
                Dim transferee As String = ds.Tables(0).Rows(i).Item("transferee").ToString
                Dim warehousecharges As Decimal = ds.Tables(0).Rows(i).Item("warehouse_charges").ToString
                Dim cmc_charges As Decimal = ds.Tables(0).Rows(i).Item("cmc_charges").ToString
                Dim transfer_charges As Decimal = ds.Tables(0).Rows(i).Item("transfer_charges").ToString

                Dim id As String = ds.Tables(0).Rows(i).Item("id").ToString

                cmd = New SqlCommand("insert into trans (company, cds_number, Date_Created, trans_time, shares, update_type, Created_By, Batch_Ref, [source], Pledge_shares, reference, warehouse, WarehouseOperator) select Commodity+'/'+grade, '" + transferee + "', getdate(), getdate(), " + quantity + "*1, 'TRANSFERRED - PMEX', '" + Session("Username") + "', t.id,'D','0','" + cmbparaCompany.Text + "',Warehouse, WarehousePhysical    from wr w, Pmextrans t WHERE w.ReceiptNo='" + cmbparaCompany.Text + "' and t.receiptid=w.receiptno and t.id='" + id + "'  insert into trans (company, cds_number, Date_Created, trans_time, shares, update_type, Created_By, Batch_Ref, [source], Pledge_shares, reference, warehouse, WarehouseOperator) select Commodity+'/'+grade, '" + transferor + "', getdate(), getdate(), " + quantity + "*-1, 'TRANSFERRED - PMEX', '" + Session("Username") + "', t.id,'D','0','" + cmbparaCompany.Text + "',Warehouse, WarehousePhysical    from wr w, Pmextrans t WHERE w.ReceiptNo='" + cmbparaCompany.Text + "' and w.receiptNo=t.receiptID AND  t.id='" + id + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                If warehousecharges <> 0 Then
                    cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Warehouse Charges - PMEX','Warehouse Charges - PMEX','" & warehousecharges & "',GETDATE(),'1','" + transferor + "',NULL, '" + cmbparaCompany.Text + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If

                If cmc_charges <> 0 Then
                    cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('CMC Charges - PMEX','CMC Charges - PMEX','" & cmc_charges & "',GETDATE(),'1','" + transferor + "',NULL, '" + cmbparaCompany.Text + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If

                If transfer_charges <> 0 Then
                    cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Transfer Charges - PMEX','Transfer Charges - PMEX','" & transfer_charges & "',GETDATE(),'1','" + transferor + "',NULL, '" + cmbparaCompany.Text + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('Transfer Charges - PMEX','Transfer Charges - PMEX'," & transfer_charges & "*-1,GETDATE(),'1','" + transferor + "',NULL, '" + cmbparaCompany.Text + "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If

            Next
        End If

        cmd = New SqlCommand("update wr set holder='" + txttransfereeAccountNo.Text + "', [STATUS]='ISSUED' where receiptno='" + cmbparaCompany.Text + "'  Update Settleconfirm set status='Approved' where EWR_reference='" + cmbparaCompany.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


        Try
            Dim a As New passmanagement
            a.auditlog(Session("BrokerCode"), Session("Username"), "Approved a EWR Pmex Settlement Request", txtAccountNo.Text, cmbparaCompany.Text)
        Catch ex As Exception

        End Try

        Session("finish") = "yes"

            Session("msg") = "Transfer request for EWR No. " + cmbparaCompany.Text + " has been successfully authorized. Transaction ID is " + txtid.Text + ""
            Response.Redirect(Request.RawUrl)
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try

    End Sub

    Public Function accountbalance(ByVal accountno As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(amount),0) as [totalowing] from cashtransComb where cds_Number='" + accountno + "'", cn)
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
        cmd = New SqlCommand("select w.id, W.transferor as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending' when w.rejected='1' then 'Rejected' else 'Approved' end as  [Status],  W.[Date], W.amount_to_transfer ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from Pmextrans W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and deleted is NULL", cn)
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
    Public Function partname(ByVal code As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("select Company_name from client_companies where Company_Code='" + code + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("company_name")
        End If
    End Function
    Public Sub getrejected()

        Dim ds As New DataSet
        cmd = New SqlCommand("select w.id, W.transferor as [Account No],wr.UnitMeasure, W.Company as [Details], W.ReceiptID AS [EWRNo], case when W.approvedby is NULL and w.rejected is NULL then 'Pending'  when w.rejected='1'  THEN 'Rejected' else 'Approved' end as  [Status],  W.[Date], W.amount_to_transfer ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] as wrstatus    from Pmextrans W, WR wr where wr.ReceiptNo=w.ReceiptID and ParticipantCode='" + Session("BrokerCode") + "' and w.deleted is Null and w.rejected is NOT NULL", cn)
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
    Public Sub loaddetails(ByVal holder As String)

        Dim ds As New DataSet
        cmd = New SqlCommand("select forenames+' '+surname as [Name], c.company_code, c.Company_name, a.cds_Number  from Accounts_Clients a, Client_Companies c where a.BrokerCode=c.Company_Code and a.cds_number='" + holder + "'", cn)
        ''Commodity+'/'+Grade as [Prod] from WR where holder='" + ListBox1.SelectedItem.Value.ToString + "' and quantity>0 AND ([status]='ISSUED' OR [status]='SPLIT')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names1")
        If (ds.Tables(0).Rows.Count > 0) Then
            ' txtparticipantname.Text = ds.Tables(0).Rows(0).Item("Company_name")
            '  txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Company_Code")
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("name")
            txtewraccountno.Text = ds.Tables(0).Rows(0).Item("cds_number")
            txtAccountNo.Text = Session("BrokerCode")
            txtparticipantname.Text = partname(Session("BrokerCode"))
        End If
    End Sub
    Public Sub loadcomboforreceipts(ByVal holder As String)
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

        cmd = New SqlCommand("select * from WR where receiptno in (select receiptid from Pmextrans  where status is NULL and ParticipantCode='" + Session("Brokercode") + "' and rejected is NULL AND deleted IS NULL and approvedby is NULL and status is NULL)", cn)



        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView5.DataSource = dsport
            ASPxGridView5.DataBind()

        End If
    End Sub



    Private Sub cmbparaCompany_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbparaCompany.ValueChanged
        '   loadcomboforreceipts(ListBox1.SelectedValue.ToString)
    End Sub

    Private Sub ASPxGridView5_RowCommand(ByVal sender As Object, ByVal e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Select" Then
            getinfortoedit(id.ToString)
            Try
                'Dim m As New NaymatBilling
                'Dim charge As Double = m.transfercharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text.ToString, cmbparaCompany.Text)
                'txtcharge.Text = charge

                Dim m As New NaymatBilling
                ' Dim transcharge As Double = m.transfercharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
                Dim charge As Double = m.getEWRBAL(cmbparaCompany.Value.ToString, txtewraccountno.Text)
                Dim globcharge As Double = m.getholderbal(txtewraccountno.Text, Session("BrokerCode"))
                txtaccumulatedcharges.Text = charge.ToString
                'txtothercharges.Text = globcharge.ToString
                '  txtcharge.Text = transcharge.ToString

            Catch ex As Exception
                msgbox("Error Charging: " + ex.Message)
            End Try

        End If
    End Sub
    Public Function getname(ByVal cds_number As String) As String
        cmd = New SqlCommand("select forenames+' '+surname as Names from accounts_clients where cds_number='" + cds_number + "'", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("Names").ToString
        Else
            Return ""
        End If
    End Function
    Public Sub getsubtrans(receipt As String)
        cmd = New SqlCommand("select w.Transferor, w.Transferee ,wr.Receiptno, FORMAT(w.amount_to_transfer,'#,###.##','en-us') as [Quantity], w.CapturedBy, w.Capturedate, min(w.id) as [Transaction ID]    from wr , pmextrans w  where receiptno='" + receipt + "' and wr.receiptno=w.receiptid and w.ApprovedBy is NULL and w.deleted is NULL AND rejectionreason is NULL group by transferor, transferee, ReceiptNo , amount_to_transfer, CapturedBy, CaptureDate  order by min(w.id) asc ", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")
        If ds.Tables(0).Rows.Count > 0 Then
            grdtrans.DataSource = ds
            grdtrans.DataBind()
        End If
    End Sub
    Public Sub getinfortoedit(ByVal receipt As String)
        cmd = New SqlCommand("select w.transferor, w.transferee ,wr.receiptno, w.amount_to_transfer, w.capturedBy, w.capturedate, min(w.id) as id    from wr , pmextrans w  where receiptno='" + receipt + "' and wr.receiptno=w.receiptid and w.ApprovedBy is NULL and w.deleted is NULL AND rejectionreason is NULL group by transferor, transferee, ReceiptNo , amount_to_transfer, CapturedBy, CaptureDate  order by min(w.id) asc", cn)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "pc")

        If ds.Tables(0).Rows.Count > 0 Then
            Dim last As Decimal = ds.Tables(0).Rows.Count - 1
            txtewrholder.Text = ds.Tables(0).Rows(0).Item("transferor").ToString
            loaddetails(txtewrholder.Text)
            cmbparaCompany.Value = receipt
            Dim transamt As Decimal = ds.Tables(0).Rows(0).Item("amount_to_transfer").ToString
            txtavailableshares.Text = transamt.ToString("N")
            txtcapturedate.Text = ds.Tables(0).Rows(0).Item("capturedate").ToString
            txtcapturedby.Text = ds.Tables(0).Rows(0).Item("capturedBy").ToString
            Dim quant As Decimal = ds.Tables(0).Rows(0).Item("amount_to_transfer").ToString
            txtshares.Text = quant.ToString("N")
            txttransfereeAccountNo.Text = ds.Tables(0).Rows(last).Item("transferee").ToString
            txtid.Text = ds.Tables(0).Rows(0).Item("id").ToString
            txttransfereename.Text = getname(txttransfereeAccountNo.Text)
            getsubtrans(receipt)
        End If
    End Sub


    Protected Sub txtcapturedby_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtcapturedby.TextChanged

    End Sub

    Private Sub ASPxGridView3_RowCommand(ByVal sender As Object, ByVal e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Resend" Then
            If isOTPsent(id) = True Then

                msgbox("Transaction status does not allow OTP to be resent!")
            Else
                Dim OTP As String = CreateRandomPassword(4)
                cmd = New SqlCommand(" update Pmextrans set  OTP='" + OTP + "',OTPSent='1' ,OTPCreateTime=getdate() where id='" + id.ToString + "'", cn)
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
