Partial Class Enquiries_Cash_Deposits
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
            End If
            If session("finish") = "true" Then
                session("finish") = ""
                'msgbox("Deposit Saved")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            ' If (txtClientNameSearch.Text <> "") Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select ReceiptNo,ReceiptNo+' '+Holder+' '+Commodity+' '+Grade as namess from WR where Holder+' '+Commodity+' '+Grade  like '%" & txtClientNameSearch.Text & "%'  and approved_by is not null", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNamesSearch.DataSource = ds.Tables(0)
                lstNamesSearch.TextField = "namess"
                lstNamesSearch.ValueField = "ReceiptNo"
                lstNamesSearch.DataBind()
            Else
                lstNamesSearch.Items.Clear()
            End If
            '  End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged
       Try
            If (lstNamesSearch.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from WR where ReceiptNo = '" & lstNamesSearch.SelectedItem.Value.ToString & "' and approved_by is not null", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "WR")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientNo.Text = ds.Tables(0).Rows(0).Item("Holder").ToString.ToUpper
                    txtTitle.Text = ds.Tables(0).Rows(0).Item("ReceiptNo").ToString.ToUpper
                    txtIDno.Text = ds.Tables(0).Rows(0).Item("Commodity").ToString.ToUpper
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("Quantity").ToString.ToUpper
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("Price").ToString.ToUpper
                    txtReason.Text = ds.Tables(0).Rows(0).Item("Date_Issued").ToString.ToUpper
                    GetCashBal()
                Else
                    txtClientNo.Text = ""
                    txtTitle.Text = ""
                    txtIDno.Text = ""
                    txtForenames.Text = ""
                    txtSurname.Text = ""
                  
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
       End Try
    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from cdsc.dbo.cashtrans where cds_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lblCashBal.Text = ds.Tables(0).Rows(0).Item("total").ToString.ToUpper
            If lblCashBal.Text > 0 Then
                lblCashBal.ForeColor = Drawing.Color.Green
                lblCashBal0.Visible = False
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                lblCashBal0.Visible = False
            End If
        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        'If txtClientNo.Text = "" Then
        '    msgbox("Client Number Cannot Be Blank")
        '    Exit Sub
        'End If

        'If Not IsNumeric(txtAmount.Text) Then
        '    msgbox("Amount must be numbers only")
        'End If
        If txtIDno.Text = "" Then
            msgbox("Client Number Cannot Be Blank")
            Exit Sub
        End If


        Dim result As Integer
        cmd = New SqlCommand("update WR  set transportcharges='" + txtAmount.Text + "' where ReceiptNo='" + txtTitle.Text + "' and Holder='" + txtClientNo.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If result > 0 Then
            'msgbox("Update Successful")

        End If
        cn.Close()
        DebitStatement()
        ClearFields()

        Response.Write("<script>alert('Update Successful') ; location.href='UpdateTransactionCharges.aspx'</script>")
        ' 
    End Sub
    Public Sub updateaccountsclients()
        cmd = New SqlCommand("update cds_router.dbo.Accounts_Clients set AccountState='locked' where cds_number = '" + txtClientNo.Text + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        ClearFields()

    End Sub

    Public Sub ClearFields()
        'txtAmount.Text = ""
        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""
        txtTitle.Text = ""
        'cmbCounter.SelectedIndex = -1
        'chkCounter.Checked = False
    End Sub
    Public Sub DebitStatement()
        Dim result As Integer
        Dim value As Double = Convert.ToDouble(txtAmount.Text) * -1
        cmd = New SqlCommand("insert into cdsc.dbo.CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference) VALUES   ('" + txtDescription.Text + "','Charge','" & value & "',GETDATE(),'1','" + txtClientNo.Text + "',NULL, NULL)", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()

    End Sub
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs)
        If txtReason.Text = "" Then
            msgbox("Enter Reason")
            Exit Sub
        End If
        Dim result As Integer
        cmd = New SqlCommand("insert into [CDS_ROUTER].[dbo].[AccountsLock](name,surname,cdsnumber,reason,status) values('" + txtForenames.Text + "' ,'" + txtSurname.Text + "' ,'" + txtClientNo.Text + "','" + txtReason.Text + "','active') ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If result > 0 Then
            Session("finish") = "true"
            'response.redirect(request.rawurl)

        End If
        cn.Close()
        'updateaccountsclients()
        Response.Write("<script>alert('Account UnLocked Now Awaits Authorisation') ; location.href='CtradeAccountsLock.aspx'</script>")
    End Sub
    Public Sub unlock()
        cmd = New SqlCommand("update cds_router.dbo.Accounts_Clients set AccountState='active' where cds_number = '" + txtClientNo.Text + "' ", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        ClearFields()

    End Sub
End Class
