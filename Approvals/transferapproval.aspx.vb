Partial Class transferapproval
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
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxTextBox12_TextChanged(sender As Object, e As EventArgs) Handles txttransferorname.TextChanged

    End Sub



    Public Sub getpending()

        Dim ds As New DataSet
        Dim xyz As New Common
        If xyz.OTPenabled = True Then
            cmd = New SqlCommand("select id, company+' '+ convert(nvarchar(50),amount_to_transfer)+' '+convert(nvarchar(50),[date]) as det from share_transfer where approvedby is NULL and rejected is NULL AND participantcode='" + Session("BrokerCode") + "' AND OTPstatus='Approved'", cn)
        Else
            cmd = New SqlCommand("select id, company+' '+ convert(nvarchar(50),amount_to_transfer)+' '+convert(nvarchar(50),[date]) as det from share_transfer where approvedby is NULL and rejected is NULL AND participantcode='" + Session("BrokerCode") + "'", cn)
        End If

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit2")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbpending.DataSource = ds
            cmbpending.ValueField = "id"
            cmbpending.TextField = "det"
            cmbpending.DataBind()

        End If
    End Sub


    Public Sub loadnames()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from share_transfer where id='" + cmbpending.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            txttransferorid.Text = ds.Tables(0).Rows(0).Item("transferor").ToString

            txttransfereeid.Text = ds.Tables(0).Rows(0).Item("transferee").ToString
            txtshares.Text = ds.Tables(0).Rows(0).Item("amount_to_transfer").ToString
            txtcomp.Text = ds.Tables(0).Rows(0).Item("company").ToString
            txtcapturedby.Text = ds.Tables(0).Rows(0).Item("capturedby").ToString
            '       getclasses()
            txtreceiptno.Text = ds.Tables(0).Rows(0).Item("receiptid").ToString


        End If
    End Sub

    Public Sub getnames()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("  select (select surname+' '+middlename+' '+ forenames from accounts_clients where cds_number='" + txttransferorid.Text + "') as Transferor, (select surname+' '+middlename+' '+ forenames from accounts_clients where cds_number='" + txttransfereeid.Text + "') as transferee  from accounts_clients ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit2")
        If (ds1.Tables(0).Rows.Count > 0) Then
            txttransferorname.Text = ds1.Tables(0).Rows(0).Item("Transferor")
            txttransfereename.Text = ds1.Tables(0).Rows(0).Item("Transferee")

        End If
    End Sub
    Public Sub savenewclass()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select cds_number from account_transfer where cds_number='" + txttransferorid.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Audit3")
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
    Public Function receiptnew() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select '20-'+ RIGHT('000'+CAST(isnull(max(id),0)+1 AS VARCHAR(100)),6) + '-000' AS [ReceiptNo] from wr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "min_lot")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("ReceiptNo")
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

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try


            cmd = New SqlCommand("insert into trans (company, cds_number, Date_Created, trans_time, shares, update_type, Created_By, Batch_Ref, [source], Pledge_shares, reference, warehouse, WarehouseOperator) select Commodity+'/'+grade, '" + txttransfereeid.Text + "', getdate(), getdate(), " + txtshares.Text + "*1, 'Transfer', '" + Session("Username") + "', id,'D','0','" + receiptnew() + "',Warehouse, WarehousePhysical    from wr WHERE ReceiptNo='" + txtreceiptno.Text + "' insert into trans (company, cds_number, Date_Created, trans_time, shares, update_type, Created_By, Batch_Ref, [source], Pledge_shares, reference, warehouse, WarehouseOperator) select Commodity+'/'+grade, holder, getdate(), getdate(), " + txtshares.Text + "*-1, 'Transfer', '" + Session("Username") + "', id,'D','0','" + txtreceiptno.Text + "',Warehouse, WarehousePhysical    from wr WHERE ReceiptNo='" + txtreceiptno.Text + "' update wr set quantity=quantity-" + txtshares.Text + " where receiptno='" + txtreceiptno.Text + "' insert into wr ([Holder]      ,[Commodity]      ,[Grade]      ,[Warehouse]      ,[Expiry]      ,[Date_Issued]      ,[Quantity]      ,[InsurancePolicy]      ,[Price]      ,[Issued_By]      ,[Approved_By]      ,[Financier]      ,[ApprovedBy]      ,[ApprovedOn]      ,[ReceiptNo]      ,[HarvestDate]      ,[UnitMeasure]      ,[InsuranceCompany]      ,[InsuranceDetails]      ,[InsuranceExpiry]      ,[MoistureContent]      ,[Broken]      ,[Damage]      ,[ForeignMatters]      ,[transportcharges]      ,[WarehousePhysical]      ,[Status]      ,[DeliveryID]      ,[OriginalQuantity]      ,[Approve1]      ,[Approve2]) SELECT '" + txttransfereeid.Text + "'     ,[Commodity]      ,[Grade]      ,[Warehouse]      ,[Expiry]      ,getdate()     ,'" + txtshares.Text + "'     ,[InsurancePolicy]      ,[Price]      ,'" + Session("Username") + "'     ,'" + Session("Username") + "'    ,[Financier]      ,[ApprovedBy]      ,[ApprovedOn]      ,'" + receiptnew() + "'  ,[HarvestDate]      ,[UnitMeasure]      ,[InsuranceCompany]      ,[InsuranceDetails]      ,[InsuranceExpiry]      ,[MoistureContent]      ,[Broken]      ,[Damage]      ,[ForeignMatters]      ,[transportcharges]      ,[WarehousePhysical]      ,[Status]      ,[DeliveryID]      ,[OriginalQuantity]      ,[Approve1]      ,[Approve2]  FROM [WR] WHERE ReceiptNo='" + txtreceiptno.Text + "'  Update share_transfer set status='1', approvedby='" + Session("Username") + "',ApprovedDate=getdate() where id='" + cmbpending.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim m As New NaymatBilling
                Dim charge As Double = m.transfercharges("BILL", "DEPOSITOR", txtshares.Text, txttransferorid.Text, txtreceiptno.Text)
                txtcharge.Text = charge
            Catch ex As Exception
                msgbox("Error Charging: " + ex.Message)
            End Try

            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try





    End Sub
 

  
    Protected Sub cmbpending_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpending.SelectedIndexChanged
        loadnames()
        getnames()
        Try
            Dim m As New NaymatBilling
            Dim charge As Double = m.transfercharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txttransferorid.Text, txtreceiptno.Text)
            txtcharge.Text = charge
        Catch ex As Exception
            msgbox("Error Charging: " + ex.Message)
        End Try

    End Sub

End Class