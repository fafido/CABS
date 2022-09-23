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
            If (txtClientNameSearch.Text <> "") Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_Clients where surname like '" & txtClientNameSearch.Text & "%'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lstNamesSearch.DataSource = ds.Tables(0)
                    lstNamesSearch.TextField = "namess"
                    lstNamesSearch.ValueField = "namess"
                    lstNamesSearch.DataBind()
                Else
                    lstNamesSearch.Items.Clear()
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged
        Try
            If (lstNamesSearch.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+surname+' '+forenames = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts_Clients")
                If (ds.Tables(0).Rows.Count > 0) Then
                    txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                    txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                    txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                    txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                    txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                    getCashBal()
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
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from tbl_CashBalance where ClientID = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            lblCashBal.Text = ds.Tables(0).Rows(0).Item("total").ToString.ToUpper
            If lblCashBal.Text > 0 Then
                lblCashBal.ForeColor = Drawing.Color.Green
                lblCashBal0.Visible = True
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                lblCashBal0.Visible = False
            End If
        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        If txtClientNo.Text = "" Then
            msgbox("Client Number Cannot Be Blank")
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            msgbox("Amount must be numbers only")
        End If
       Dim result As Integer
        cmd = New SqlCommand("insert into tbl_CashBalance (ClientID, Amount, Description, Counter, CumBal) values ('" & txtClientNo.Text & "'," & txtAmount.Text & ",'Cash Deposit','" & cmbCounter.Text & "',(select isnull(sum(amount),0) from tbl_CashBalance where ClientID='" & txtClientNo.Text & "')+" & txtAmount.Text & ")", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If result > 0 Then
            Dim total As Double
            total = CDbl(CDbl(txtAmount.Text) + CDbl(lblCashBal.Text))
            DepositReg()
            msgbox("Deposit Saved, New Balance:" & FormatCurrency(total))
        End If
        cn.Close()
        clearfields()
    End Sub

    Public Sub DepositReg()
        Dim result As Integer
        cmd = New SqlCommand("Update Deposits_Reg  Set Flag_Status='Closed' where CDS_Number='" & txtClientNo.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Dim cashbal As Double
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Deposit_Amount),0.0) as total from Deposits_Reg where CDS_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cashbal = CDbl(ds.Tables(0).Rows(0).Item(0).ToString) + CDbl(txtAmount.Text)
        Else
            cashbal = txtAmount.Text
        End If
        cmd = New SqlCommand("insert into  Deposits_Reg (ORDER_Number, CDS_Number, Deposit_Amount, Date_of_Deposit, Flag_Status) values (999999,'" & txtClientNo.Text & "'," & cashbal & ",GetDate(),'Open')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
    End Sub
    Public Sub ClearFields()
        txtAmount.Text = ""
        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""
        txtTitle.Text = ""
        cmbCounter.SelectedIndex = -1
        chkCounter.Checked = False
    End Sub
End Class
