Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
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

            ASPxGridView7.DataSource = unalloc()
            ASPxGridView7.DataBind()

        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("Allocation Successfully Committed")
        End If
        If Session("finish") = "reversed" Then
            Session("finish") = ""
            msgbox("Transaction has been flagged for re-allocation!")
        End If
        If Session("finish") = "multi" Then
            Session("finish") = ""
            msgbox("Transaction(s) Successfully Committed!")
        End If

        If Session("finish") = "multi_rev" Then
            Session("finish") = ""
            msgbox("Allocation(s) Successfully Reversed!")
        End If


        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            '   txtTitle.Text = ""

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
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper + " " + ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtcurrency.Text = ds.Tables(0).Rows(0).Item("Currency").ToString
                GetCashBal()
                GetCompany(txtClientNo.Text)
            Else
                txtClientNo.Text = ""
                '  txtTitle.Text = ""

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
        If txtClientNo.Text = "" Then
            msgbox("Client Number Cannot Be Blank")
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            msgbox("Amount must be numbers only")
        End If
        approvetrans(lblselected.Text)
        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)
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
        cmd = New SqlCommand("select *,a.surname+' '+a.forenames as Name from trans_bank_alloc t, Accounts_Clients a where allocated='PENDING' and a.CDS_Number=t.allocatedto and ISNULL(t.PostedFrom,'') not in ('System-InterestCapital','System-Dividend')", cn)
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
    Public Function unallocated() As DataSet
        Dim ds As New DataSet
        cmd = New SqlCommand("select *,a.surname+' '+a.forenames as Name from trans_bank_alloc t, Accounts_Clients a where allocated='PENDING' and a.CDS_Number=t.allocatedto and ISNULL(t.PostedFrom,'') not in ('System-InterestCapital','System-Dividend')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds

        Else
            Return Nothing
        End If
    End Function
    Public Sub getinfor(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select t.datecreated,T.AssetManager, T.BankAccount, T.BANKNAME, T.AMOUNT, T.REFERENCE, T.OTHER_DETAILS, T.ALLOCATEDBY, A.surname,a.forenames, a.idnopp, t.allocatedto, t.currency  from trans_bank_alloc T, Accounts_Clients a where t.id='" + id + "' and a.CDS_Number=t.allocatedto", cn)
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

            txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString
            txtcurrency.Text = ds.Tables(0).Rows(0).Item("Currency").ToString

        End If
    End Sub
    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Select" Then
            lblselected.Text = id

            getinfor(id)
        End If
    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        If txtClientNo.Text = "" Then
            msgbox("Client Number Cannot Be Blank")
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            msgbox("Amount must be numbers only")
        End If

        declinetransaction(lblselected.Text)
        Session("finish") = "reversed"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub declinetransaction(id As String)



        Dim result As Integer

        cmd = New SqlCommand("delete from trans_bank_alloc  where id='" + id + "'", cn)


        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
        If result > 0 Then

        End If
        cn.Close()
        '  ClearFields()
    End Sub
    Public Sub approvetrans(id As String)
        Try




            Dim result As Integer

            cmd = New SqlCommand("insert into CashTrans ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference, AssetManager, BankName, BankAccount, Ref2, PostedBy, Currency) select Other_Details ,Transcode , Amount, DateCreated, '1' , AllocatedTo , '1', Reference, AssetManager, BankName, BankAccount, Ref2, '" + Session("Username") + "', Currency from trans_bank_alloc where id='" + id + "' update trans_bank_alloc set approveddate=getdate(), approvedby='" + Session("Username") + "',Allocated='ALLOCATED' where id='" + id + "'", cn)


            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            result = cmd.ExecuteNonQuery()
            If result > 0 Then

            End If
            cn.Close()
            '  ClearFields()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim keys As List(Of Object) = ASPxGridView5.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView5.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView5.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvetrans(key.ToString)

            End If


        Next
        Session("finish") = "multi"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Dim keys As List(Of Object) = ASPxGridView5.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView5.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView5.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                declinetransaction(key.ToString)
            End If
        Next
        Session("finish") = "multi_rev"
        Response.Redirect(Request.RawUrl)

    End Sub

    Private Sub ASPxGridView5_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView5.DataBinding
        Try
            ASPxGridView5.DataSource = unallocated()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub approvedasallocated(id As String)
        cmd = New SqlCommand("update trans_bank set ApprovedBy='" + Session("Username") + "', ApprovedDate=getdate() where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub removeasallocated(id As String)
        cmd = New SqlCommand("update trans_bank set Allocated='NOT ALLOCATED' where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Dim keys As List(Of Object) = ASPxGridView7.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView7.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView7.Columns("Selec"), GridViewDataColumn), "chk3"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                approvedasallocated(key.ToString)
            End If


        Next
        Try

            ASPxGridView7.DataSource = unalloc()
            ASPxGridView7.DataBind()


        Catch ex As Exception

        End Try
        msgbox("Transaction(s) Successfully marked as Allocated")
    End Sub
    Private Sub ASPxGridView7_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView7.DataBinding
        ASPxGridView7.DataSource = unalloc()

    End Sub
    Public Function unalloc() As DataSet
        Dim ds As New DataSet
        cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='Marked as Allocated' and T1.ApprovedBy is NULL  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<>t1.Amount", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds
        Else
            Return ds
        End If
    End Function
    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Dim keys As List(Of Object) = ASPxGridView7.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView7.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView7.Columns("Selec"), GridViewDataColumn), "chk3"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                removeasallocated(key.ToString)
            End If


        Next
        Try

            ASPxGridView7.DataSource = unalloc()
            ASPxGridView7.DataBind()


        Catch ex As Exception

        End Try
        msgbox("Transaction(s) Successfully marked as not allocated")
    End Sub
End Class
