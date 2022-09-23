Imports DevExpress.Web.ASPxGridView

Partial Class Enquiries_CashAllocationApproval
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
        '   Try
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            checkSessionState()
            chkCounter.Checked = False
            '  loadassetmanagers()

            getunallocated()

        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("Allocation Successfully Committed")
        End If


        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            '   txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged

        If (lstNamesSearch.Items.Count > 0) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+forenames+' '+surname = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                '   txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                GetCashBal()
                GetCompany(txtClientNo.Text)
            Else
                txtClientNo.Text = ""
                '  txtTitle.Text = ""
                txtIDno.Text = ""
                txtForenames.Text = ""
                txtSurname.Text = ""

            End If
        End If

    End Sub

    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from cashtransCOMB where cds_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim ba As Decimal = ds.Tables(0).Rows(0).Item("total").ToString
            lblCashBal.Text = ba.ToString("N")
            If lblCashBal.Text > 0 Then
                lblCashBal.ForeColor = Drawing.Color.Green
                '  lblCashBal0.Visible = True
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                '  lblCashBal0.Visible = False
            End If
        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try

            If txtClientNo.Text = "" Then
                msgbox("Client Number Cannot Be Blank")
                Exit Sub
            End If

            If Not IsNumeric(txtAmount.Text) Then
                msgbox("Amount must be numbers only")
            End If


            Dim result As Integer

            cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference, AssetManager, BankName, BankAccount, Ref2, PostedBy) VALUES   ('" + txtdesc.Text + "','CASH - ALLOCATION','" & txtAmount.Text & "',GETDATE(),'1','" + txtClientNo.Text + "',NULL, '" + txtreference.Text + "','" + txtassetmanger.Text + "','" + txtbankname.Text + "','" + txtaccountno.Text + "','" + lblselected.Text + "','" + Session("Username") + "') update trans_bank set approveddate=getdate(), approvedby='" + Session("Username") + "',Allocated='ALLOCATED' where id='" + lblselected.Text + "'", cn)


            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            result = cmd.ExecuteNonQuery()
            If result > 0 Then
                Session("finish") = "true"
                Response.Redirect(Request.RawUrl)

            End If
            cn.Close()
            ClearFields()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
        ' txtTitle.Text = ""
        cmbCounter.SelectedIndex = -1
        chkCounter.Checked = False
    End Sub
    Protected Sub chkCounter_CheckedChanged(sender As Object, e As EventArgs) Handles chkCounter.CheckedChanged
        If chkCounter.Checked = True Then
            ' EWR.Visible = False
            cmbCounter.Visible = False
            txtcharges.Visible = False
            '   EWR0.Visible = False
        Else
            'GetCompany(txtClientNo.Text)
            ' EWR.Visible = False
            cmbCounter.Visible = False
            txtcharges.Visible = False
            '  EWR0.Visible = False
        End If

    End Sub
    Public Sub GetCompany(holder As String)
        Try
            Dim dsport As New DataSet
            cmd = New SqlCommand("select * from WR where  receiptno in (  select reference from cashtranscomb where CDS_NUMBER='" + holder + "' group by reference having sum(amount)<0) order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                cmbCounter.DataSource = dsport

                cmbCounter.DataBind()
            End If
        Catch ex As Exception
            msgbox("Error extracting receipts for holder : " + ex.Message)
        End Try
    End Sub
    Protected Sub cmbCounter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCounter.SelectedIndexChanged
        GetCompany(txtClientNo.Text)
        Try
            Dim m As New NaymatBilling
            ' Dim transcharge As Double = m.withdrawalcharges("ENQUIRE", "DEPOSITOR", txtshares.Text, txtewraccountno.Text, cmbparaCompany.Value.ToString)
            Dim charge As Double = Math.Ceiling(m.getEWRBAL_NO_LOAN(cmbCounter.Value.ToString, txtClientNo.Text))

            ' txtaccumulatedcharges.Text = charge.ToString
            txtcharges.Text = charge.ToString("N")

        Catch ex As Exception
            msgbox(ex.Message)
        End Try


    End Sub



    Public Sub getunallocated()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Trans_Bank where allocated='PENDING'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView5.DataSource = ds
            ASPxGridView5.DataBind()
        Else
            ASPxGridView5.DataSource = Nothing
            ASPxGridView5.DataBind()
        End If
    End Sub
    Public Sub getinfor(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select t.datecreated,T.AssetManager, T.BankAccount, T.BANKNAME, T.AMOUNT, T.REFERENCE, T.OTHER_DETAILS, T.ALLOCATEDBY, A.surname,a.forenames, a.idnopp, t.allocatedto  from trans_bank T, Accounts_Clients a where t.id='" + id + "' and a.CDS_Number=t.allocatedto", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim amt As Decimal = ds.Tables(0).Rows(0).Item("amount").ToString
            txtdesc.Text = ds.Tables(0).Rows(0).Item("Other_Details").ToString
            txtAmount.Text = amt.ToString("N")
            txtbankname.Text = ds.Tables(0).Rows(0).Item("BankName").ToString
            txtaccountno.Text = ds.Tables(0).Rows(0).Item("BankAccount").ToString
            txtassetmanger.Text = ds.Tables(0).Rows(0).Item("AssetManager").ToString
            txtcapturedby.Text = ds.Tables(0).Rows(0).Item("AllocatedBy").ToString
            txtdateposted.Text = ds.Tables(0).Rows(0).Item("DateCreated").ToString
            txtreference.Text = ds.Tables(0).Rows(0).Item("Reference").ToString
            txtClientNo.Text = ds.Tables(0).Rows(0).Item("AllocatedTo").ToString
            txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString
            txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
            txtIDno.Text = ds.Tables(0).Rows(0).Item("Idnopp").ToString
        End If
    End Sub
    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Select" Then
            lblselected.Text = id

            getinfor(id)
        End If
    End Sub
End Class
