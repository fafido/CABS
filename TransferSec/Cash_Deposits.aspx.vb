Imports DevExpress.Web.ASPxGridView

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
            If (Not IsPostBack) = True Then
                checkSessionState()
                GetCompany()
                gettrantype()
                getbanks()
                gettrans()


            Else
                GetCompany()
            End If

            GetCompany()
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Transfer Instructions Saved")
            End If
            If Session("finish") = "update" Then
                Session("finish") = ""
                msgbox("Transfer Instructions Updated Successfully")
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
            cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where cds_number+' '+forenames+' '+surname like '%" & txtClientNameSearch.Text & "%' and AccountState='A' order by cds_number", cn)
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

    Protected Sub lstNamesSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNamesSearch.SelectedIndexChanged

        If (lstNamesSearch.Items.Count > 0) Then
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number+' '+forenames+' '+surname = '" & lstNamesSearch.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
                txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
                txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
                txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
                GetCashBal()
                GetCompany()
            Else
                txtClientNo.Text = ""
                txtTitle.Text = ""
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
                lblCashBal0.Visible = True
            Else
                lblCashBal.ForeColor = Drawing.Color.Red
                lblCashBal0.Visible = False
            End If
        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        If Not IsNumeric(txtAmount.Text) Then
            msgbox("Amount must be numbers only")
            Exit Sub
        End If
        Try
            If cmbassetmanagerbank.Value.ToString = "" Then
                msgbox("Please select Asset Manager Bank!")
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        Try
            If cmbbank.SelectedItem.Value = "" Then
                msgbox("Please select Bank!")
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        If txtaccountno.Text = "" Then
            msgbox("Please provide Account No.!")
            Exit Sub
        End If
        If txtrecipientname.Text = "" Then
            msgbox("Please provide Account Name!")
            Exit Sub
        End If

        If ASPxButton3.Text = "Save" Then
            Try

                Dim result As Integer
                cmd = New SqlCommand("insert into CashTrans_Audit ([Description],TransType, Amount, DateCreated, TransStatus , cds_Number, PAID, Reference, ChargeCode, [Type], [CapturedBy],BeneficiaryBank, BeneficiaryBranch, BeneficiaryAccount, BeneficiaryAccountName) VALUES   ('" + txtdesc.Text + "','" + cmbtransactiontype.SelectedItem.Value + "','" & txtAmount.Text & "',GETDATE(),'0','" + cmbassetmanagerbank.Value.ToString + "',NULL, '','" + cmbdeb.SelectedItem.Value.ToString + "','PAYMENT','" + Session("Username") + "','" + cmbbank.SelectedItem.Value.ToString + "', '" + txtbranch.Text + "', '" + txtaccountno.Text + "','" + txtrecipientname.Text + "')", cn)
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
        ElseIf ASPxButton3.Text = "Update" Then
            Try
                Dim result As Integer
                cmd = New SqlCommand("update CashTrans_Audit set [Description]='" + txtdesc.Text + "',TransType='" + cmbtransactiontype.Value.ToString + "', Amount='" + txtAmount.Text + "', cds_Number='" + cmbassetmanagerbank.Value.ToString + "' ,BeneficiaryBank='" + cmbbank.Value.ToString + "', BeneficiaryBranch='" + txtbranch.Text + "', BeneficiaryAccount='" + txtaccountno.Text + "', BeneficiaryAccountName='" + txtrecipientname.Text + "' where id='" + lblid.Text + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                result = cmd.ExecuteNonQuery()
                If result > 0 Then
                    Session("finish") = "update"
                    Response.Redirect(Request.RawUrl)
                End If
                cn.Close()
                ClearFields()

            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If


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
        cmbassetmanagerbank.SelectedIndex = -1

    End Sub

    Public Sub gettrans()
        Dim dsport As New DataSet
        cmd = New SqlCommand("  select ID,  [Description], TransType, FORMAT(Amount,'#,###.##','en-us') AS Amount, DateCreated, BeneficiaryAccountName as [Beneficiary], BeneficiaryBank as Bank, BeneficiaryBranch as Branch, CapturedBy, TransStatus as [Status]  from CashTrans_Audit", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = dsport
            ASPxGridView3.DataBind()

        End If
    End Sub
    Public Sub GetCompany()
        ' Try
        Dim dsport As New DataSet
        cmd = New SqlCommand("select *, AssetManagerCode +'-'+AccountNo as acc, (select AssetMananger from para_assetManager where AssetManagerCode=p.AssetManagerCode) as [AssetMana] from para_assetManager_Banks p", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "trans")
        If (dsport.Tables(0).Rows.Count > 0) Then
            cmbassetmanagerbank.DataSource = dsport

            cmbassetmanagerbank.DataBind()
        End If
        'Catch ex As Exception
        '    msgbox("Error extracting receipts for holder : " + ex.Message)
        'End Try
    End Sub
    Protected Sub cmbassetamanagerbank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbassetmanagerbank.SelectedIndexChanged
        GetCompany()



    End Sub
    Public Function getbals(id As String) As Decimal
        Dim ds As New DataSet
        cmd = New SqlCommand("  select isnull(sum(Amount),0) as bal from trans_bank where AssetManager+''+BankAccount=(select AssetManagerCode+''+AccountNo from para_assetManager_Banks where id='" + id + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("bal").ToString
        End If
    End Function
    Public Sub gettrantype()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from (SELECT 1 as nr,  'Add New' as Category, 'Add New' as [Descri] union select 2 as nr,  Category, TransactionType+' - '+isnull([Action],'') as descri from para_TranType) j  order by j.nr", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbtransactiontype.DataSource = ds
            cmbtransactiontype.TextField = "descri"
            cmbtransactiontype.ValueField = "Category"
            cmbtransactiontype.DataBind()

        End If
    End Sub
    Public Function getdeb(category As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_TranType where category='" + category + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Action")
        Else
            Return ""
        End If

    End Function
    Public Sub getbanks()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_bank", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbbank.DataSource = ds
            cmbbank.TextField = "bank_name"
            cmbbank.ValueField = "bank"
            cmbbank.DataBind()

        End If
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        ' If (txtClientNameSearch.Text <> "") Then
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+forenames+' '+surname as namess from Accounts_Clients where cds_number like '%" & txtClientNoSe.Text & "%' and AccountState='A' order by cds_number", cn)
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
    Protected Sub cmbtransactiontype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtransactiontype.SelectedIndexChanged
        If cmbtransactiontype.SelectedItem.Text = "Add New" Then
            cmbtransactiontype.SelectedIndex = -1

            ASPxPopupControl1.AllowDragging = True
            ASPxPopupControl1.ShowCloseButton = True
            ASPxPopupControl1.ShowOnPageLoad = True
            ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
            ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

            Page.MaintainScrollPositionOnPostBack = True
            alltrantypes()

        Else
            If getdeb(cmbtransactiontype.SelectedItem.Value.ToString) <> "Both" Then
                cmbdeb.ReadOnly = True
                cmbdeb.Value = getdeb(cmbtransactiontype.SelectedItem.Value.ToString)
            Else
                cmbdeb.ReadOnly = False
                cmbdeb.SelectedIndex = -1
            End If

        End If
    End Sub

    Private Sub ASPxGridView3_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles ASPxGridView3.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Edit" Then
            If iseditable(id) = True Then
                getdetails(id)
            Else
                msgbox("Entry can nolonger be edited!")
            End If

        End If
    End Sub
    Public Sub getdetails(id As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from cashtrans_audit where id='" + id + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cash")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbassetmanagerbank.Value = ds.Tables(0).Rows(0).Item("cds_number").ToString
            cmbtransactiontype.Value = ds.Tables(0).Rows(0).Item("transtype").ToString
            cmbbank.Value = ds.Tables(0).Rows(0).Item("BeneficiaryBank").ToString
            txtAmount.Text = ds.Tables(0).Rows(0).Item("Amount").ToString
            txtbranch.Text = ds.Tables(0).Rows(0).Item("BeneficiaryBranch").ToString
            txtaccountno.Text = ds.Tables(0).Rows(0).Item("BeneficiaryAccount").ToString
            txtrecipientname.Text = ds.Tables(0).Rows(0).Item("BeneficiaryAccountName").ToString
            txtdesc.Text = ds.Tables(0).Rows(0).Item("description").ToString
            ASPxButton3.Text = "Update"
            lblid.Text = id
        End If
    End Sub

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Function iseditable(id As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from cashtrans_audit where id='" + id + "' and Locked='0' and TransStatus='0'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cash")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Sub alltrantypes()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_TranType", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "cash")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdactivecharges.DataSource = ds
            grdactivecharges.DataBind()

        End If
    End Sub
    Private Sub grdactivecharges_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdactivecharges.RowCommand
        Dim id As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "Delete" Then
            cmd = New SqlCommand("DELETE from para_TranType where id='" + id.ToString + "'", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()

            txtcode.Text = ""
            txtdescription.Text = ""
            cmbdrcr.Text = ""
            alltrantypes()
            gettrantype()

            msgbox("successfully deleted")

        End If
    End Sub
    Protected Sub btnSaveCompany_Click(sender As Object, e As EventArgs) Handles btnSaveCompany.Click
        Try

            If txtcode.Text <> "" And txtdesc.Text <> "" Then
            msgbox("Please enter required details!")
            Exit Sub
        End If


            cmd = New SqlCommand("insert into para_TranType (Category, TransactionType, Action) values ('" + txtcode.Text + "','" + txtdescription.Text + "','" + cmbdrcr.SelectedItem.Value.ToString + "')", cn)
            If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()

        txtcode.Text = ""
        txtdescription.Text = ""
            cmbdrcr.Text = ""
            alltrantypes()
            gettrantype()


            msgbox("Successfully Added!")



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
