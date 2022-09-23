Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Enquiries_CashAllocation
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
            loadassetmanagers()
            loadtranstype()

            ASPxGridView3.DataSource = loadtrans()
            ASPxGridView3.DataBind()

        Else
            'Try
            '    getunallocated(cmbassetmanager.SelectedItem.Value.ToString, cmbaccount.SelectedItem.Value)
            'Catch ex As Exception

            'End Try
        End If
        If Session("finish") = "true" Then
            Session("finish") = ""
            msgbox("Entry Allocated! Awaiting Approval")
        End If


        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Public Sub loadassetmanagers()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select * from para_assetManager ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbassetmanager.DataSource = ds1
            cmbassetmanager.TextField = "AssetMananger"
            cmbassetmanager.ValueField = "AssetManagerCode"
            cmbassetmanager.DataBind()

        End If
    End Sub
    Public Sub loadtranstype()
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select * from para_trans_type ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            cmbtransactioncode.DataSource = ds1
            cmbtransactioncode.TextField = "chargename"
            cmbtransactioncode.ValueField = "chargecode"
            cmbtransactioncode.DataBind()

        End If
    End Sub
    Public Function loadtrans() As DataSet
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select *,a.surname+' '+a.forenames as Names from trans_bank_alloc t, accounts_clients a where a.cds_number=t.Allocatedto order by t.id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables("Accounts_Clients1").Rows.Count > 0) Then
            Return ds1
        End If

    End Function
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            If lblselected.Text = "" Then
                msgbox("Please select valid account to allocate from!")
                Exit Sub
            End If
            ' If (txtClientNameSearch.Text <> "") Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where cds_number+' '+forenames+' '+surname like '%" & txtClientNameSearch.Text & "%' and AccountState='A' and cds_number in (select clientno from Client_assetmanagers where assetmanager='" + cmbassetmanager.SelectedItem.Value.ToString + "' and BankAccount='" + cmbaccount.SelectedItem.Value.ToString + "' ) order by cds_number", cn)
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
            '  End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub searchafterselection(Ids As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where  AccountState='A' and cds_number in (select clientno from Client_assetmanagers where assetmanager='" + cmbassetmanager.SelectedItem.Value.ToString + "' and BankAccount='" + cmbaccount.SelectedItem.Value.ToString + "') order by cds_number", cn)
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

    End Sub

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged

        If (lstNamesSearch.Items.Count > 0) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select cds_number, surname+' '+forenames as [Names] from Accounts_Clients where cds_number+' '+forenames+' '+surname = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                '   txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                ' txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                '  txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtSurname.Text = ds.Tables(0).Rows(0).Item("Names").ToString.ToUpper

                GetCompany(txtClientNo.Text)
            Else
                txtClientNo.Text = ""
                '  txtTitle.Text = ""

                txtSurname.Text = ""

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

            Dim allamt As Decimal = txtAmount.Text
            Dim ava As Decimal = lblCashBal.Text

            If ava > 0 Then
                If ava < allamt Then
                    msgbox("Please enter amount equivalent or less than the transaction amount!")
                    Exit Sub
                End If
            End If
            If ava < 0 Then
                If ava > allamt Then
                    msgbox("Please enter amount equivalent or less than the transaction amount!")
                    Exit Sub
                End If
            End If

            Dim lt As New passmanagement
            Dim transdate As Date = txtdate.Text
            Dim ltrans As Date = lt.lasttrans(txtcurrency.Text, txtassetmanager.Text, txtaccountno.Text)
            If ltrans <> "01 Jan 1900" Then
                If transdate < ltrans Then
                    msgbox("You cannot allocate with a date after the Last Reconciliation Date")
                    Exit Sub
                End If
            End If



            Dim result As Integer
            '  cmd = New SqlCommand("update Trans_bank set AllocatedBy='" + Session("Username") + "', Allocated='PENDING', AllocatedTo='" + txtClientNo.Text + "' where id='" + lblselected.Text + "' ", cn)
            cmd = New SqlCommand("insert into trans_bank_alloc ([AssetManager]      ,[BankAccount]      ,[BankName]      ,[Amount]      ,[Reference]      ,[Other_Details]      ,[DateCreated]      ,[Allocated]      ,[AllocatedBy]      ,[ApprovedBy]      ,[ApprovedDate]      ,[ReceivedVia]      ,[AllocatedTo]      ,[Currency],[Ref2], [Transcode]) select 	  [AssetManager]      ,[BankAccount]      ,[BankName]      ,'" + txtAmount.Text + "'  ,[Reference]      ,'" + txtdesc.Text + "'      ,DateCreated      ,'PENDING'      ,'" + Session("Username") + "'      ,NULL      ,NULL      ,'API'      ,'" + txtClientNo.Text + "'      ,[Currency]	  ,id, '" + cmbtransactioncode.SelectedItem.Value.ToString + "'	  from trans_bank where id='" + lblselected.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            result = cmd.ExecuteNonQuery()
            If result > 0 Then

                ASPxGridView5.DataSource = Nothing
                ASPxGridView5.DataBind()
                lstNamesSearch.Items.Clear()
                lstNamesSearch.SelectedIndex = -1

                Try
                    '     getunallocated(cmbassetmanager.SelectedItem.Value.ToString)
                Catch ex As Exception

                End Try

                searchafterselection(lblselected.Text)
                getinfor(lblselected.Text)
                cmbtransactioncode.SelectedIndex = -1
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


    Protected Sub cmbassetmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbassetmanager.SelectedIndexChanged
        getaccounts(cmbassetmanager.SelectedItem.Value)
    End Sub
    Public Sub getaccounts(assetmanager As String)
        Dim ds As New DataSet
        cmd = New SqlCommand(" select AccountName+' '+convert(nvarchar(50),AccountNo)+' '+currency as fnam, AccountNo from para_assetManager_Banks WHERE AssetManagerCode='" + assetmanager + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbaccount.DataSource = ds
            cmbaccount.TextField = "fnam"
            cmbaccount.ValueField = "AccountNo"
            cmbaccount.DataBind()

        End If
    End Sub

    Public Sub getunallocated(assetmanager As String, account As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED' and T1.AssetManager='" + assetmanager + "' and t1.BankAccount='" + account + "'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<>t1.Amount", cn)
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
    Public Function unallocated(assetmanager As String, account As String) As DataSet
        Dim ds As New DataSet
        cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED' and T1.AssetManager='" + assetmanager + "' and t1.BankAccount='" + account + "'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<>t1.Amount", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds
        Else
            Return ds
        End If
    End Function
    Public Sub getinfor(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select t1.id,t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount-ISNULL(sum(t2.amount),0) as Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency from Trans_Bank t1 LEFT join trans_bank_alloc t2 on t1.id=t2.Ref2 where T1.allocated='NOT ALLOCATED' and T1.ID='" + id + "'  group by t1.AssetManager, t1.BankAccount, t1.BankName, t1.Amount, t1.Reference, t1.Other_Details, t1.DateCreated, t1.Allocated, t1.AllocatedBy, t1.ApprovedBy, t1.ApprovedDate,t1.ReceivedVia, t1.AllocatedTo, t1.Currency, t1.id having isnull(sum(t2.amount),0)<>t1.Amount", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim amt As Decimal = ds.Tables(0).Rows(0).Item("amount").ToString
            txtdesc.Text = ds.Tables(0).Rows(0).Item("Other_Details").ToString
            txtAmount.Text = amt.ToString("N")
            txtaccountno.Text = ds.Tables(0).Rows(0).Item("BankAccount").ToString
            txtbankname.Text = ds.Tables(0).Rows(0).Item("BankName").ToString
            txtcurrency.Text = ds.Tables(0).Rows(0).Item("Currency").ToString
            lblCashBal.Text = amt.ToString("N")
            txtdate.Text = ds.Tables(0).Rows(0).Item("DateCreated").ToString
            txtassetmanager.Text = ds.Tables(0).Rows(0).Item("AssetManager").ToString
        End If
    End Sub
    Private Sub ASPxGridView5_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView5.RowCommand
        Dim id As String = e.KeyValue.ToString

        If e.CommandArgs.CommandName.ToString = "Select" Then
            lblselected.Text = id
            searchafterselection(id)
            getinfor(id)
        End If
    End Sub

    Private Sub ASPxGridView3_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView3.DataBinding
        ASPxGridView3.DataSource = loadtrans()
    End Sub
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Try
            getunallocated(cmbassetmanager.SelectedItem.Value.ToString, cmbaccount.SelectedItem.Value)
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Dim keys As List(Of Object) = ASPxGridView5.GetCurrentPageRowValues(New String() {"id"})

        For Each key As Object In keys
            Dim chk As ASPxCheckBox = TryCast(ASPxGridView5.FindRowCellTemplateControlByKey(key, TryCast(ASPxGridView5.Columns("Selec"), GridViewDataColumn), "chk1"), ASPxCheckBox)

            Dim check As Boolean = chk.Checked
            If check = True Then
                markasallocated(key.ToString)
            End If


        Next
        Try
            getunallocated(cmbassetmanager.SelectedItem.Value.ToString, cmbaccount.SelectedItem.Value)
        Catch ex As Exception

        End Try
        msgbox("Transaction(s) marked as allocated! Awaiting Approval")
    End Sub
    Public Sub markasallocated(id As String)
        cmd = New SqlCommand("update trans_bank set Allocated='Marked as Allocated', AllocatedBy='" + Session("Username") + "' where id='" + id + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub ASPxGridView5_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView5.DataBinding
        ASPxGridView5.DataSource = unallocated(cmbassetmanager.SelectedItem.Value.ToString, cmbaccount.SelectedItem.Value)
    End Sub
End Class
