
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Partial Class Depositor_BorrowersRequest
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

    Public Sub getApproved()

        Dim ds As New DataSet
        cmd = New SqlCommand("select s.ID [S.No], s.ID, Borrower,AvailableQuantity,Unit_Price,Tenure,w.Commodity,w.Grade,Bank, 'Approved'  as [Status] ,convert(date,CapturedDate) CapturedDate   from BorrowingRequest s ,wr w  where w.ReceiptNo=s.Collateral and  Borrower  = '" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') = 'APPROVED' and isnull(s.ApprovedBy,'') <>'' and isnull(s.Rejected,'') ='' ", cn)
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

    Public Shared Function CreateOTP(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Function getemail(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select email from accounts_clients where cds_Number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email").ToString
        Else
            Return ""
        End If
    End Function
    Protected Sub btn_accept(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from BorrowingRequest where  Borrower='" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') = '' and id = '" + container.KeyValue.ToString() + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ViewState("trnsid") = container.KeyValue.ToString()

            otptable.Visible = True
            otptable2.Visible = True

        Else

            msgbox("The transaction is on pending for approval")
            otptable.Visible = False
            otptable2.Visible = False
        End If

    End Sub
    Protected Sub btn_reject(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        ViewState("idReject") = container.KeyValue.ToString()




        If ViewState("idReject") <> "" Then

            cmd = New SqlCommand("update [CDS].[dbo].[BorrowingRequest] set OTPStatus ='REJECTED' where id='" + ViewState("idReject") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                msgbox("Rejected Successfull ")
                txtotp.Text = ""
            End If


        End If
        loadgrid()

        getApproved()
        otptable.Visible = False
        otptable2.Visible = False

    End Sub

    Public Sub loadtenure(max As Integer)
        For i As Integer = 1 To 36
            cmbtenure.Items.Add(i.ToString + " Months", i.ToString)
        Next
    End Sub
    Public Sub GetLenders()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate <='" & Now.Date & "'", cn)
            cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lendersRegister")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstLenders.DataSource = ds.Tables(0)
                lstLenders.TextField = "namess"
                lstLenders.ValueField = "namess"
                lstLenders.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("  SELECT receiptNo, Commodity+' '+ Grade+' '+ convert(nvarchar(50),Quantity)+' '+receiptNo  as detail from WR where ApprovedBy is Not Null and holder='" + getDEPCDS(Session("Username")) + "' and Status = 'ISSUED' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.TextField = "detail"
                cmbCompany.ValueField = "receiptNo"
                cmbCompany.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function compname(id As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select commodity+'/'+grade as comp from wr where receiptNo='" + id.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "trans")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("comp")
        End If
    End Function
    Public Sub checkSessionState()
        Try
            '  GetCompany()
            '  GetSectype()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Successfully captured! Application sent for approval ")
            End If

            If (Not IsPostBack) Then
                checkSessionState()
                '  GetLenders()
                '  loadterms()
                loadtenure(36)
                GetSelectedDetails()
                GetCompany()
                loadgrid()
                getApproved()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton7_Click(sender As Object, e As EventArgs) Handles ASPxButton7.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (cds_number+' '+surname+' '+forenames) as namess, CDS_NUMBER from Accounts_Clients where surname+' '+forenames like '%" & txtNameSearch.Text & "%'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "CDS_NUMBER"
                lstNameSearch.TextField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number='" & getDEPCDS(Session("Username")) & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtClientId.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                txtSurname.Text = "" + ds.Tables(0).Rows(0).Item("surname").ToString + " " + ds.Tables(0).Rows(0).Item("forenames").ToString + ""

                txtIdno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        GetSelectedDetails()
        GetCompany()

    End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        Dim reqamount As Long
        Dim maxamount As Long
        If ASPxButton8.Text = "Load Lenders" Then
            Dim ds As New DataSet
            If txtquantity.Text <> "" Then
                reqamount = txtquantity.Text

            Else
                msgbox("Please provide quantity")
                Exit Sub
            End If


            If txtquantity.Text <> "" Then
                maxamount = txtcollateralvalue.Text

            Else
                msgbox("Please provide collateral value")
                Exit Sub
            End If


            If reqamount > maxamount Then
                msgbox("Collateral value is below the value of the the required amount therefor cannot continue")
                Exit Sub
            Else
                ' msgbox("in")
                ' Exit Sub
                cmd = New SqlCommand("declare @amountrequired money=" + txtquantity.Text + " declare @tenure numeric(18,0)=(select DATEDIFF(month,'" + txtEffectiveDate.Text + "','" + txtExpiryDate.Text + "'))   declare @collateralvalue money=" + txtcollateralvalue.Text + "   select Bank as Bank, [Monthly Instalment] , [Service Charge] , ([Monthly Instalment]*@tenure)+[Service Charge]  as [Total Payment] , [Haircut Maximum] as [Max Haircut Amount] , [Max Tenure] from   (   select Bank as [Bank],convert(numeric(18,2),(@amountrequired/@tenure)*InterestRate/100+(@amountrequired/@tenure)) as [Monthly Instalment] ,   convert(numeric(18,2),@amountrequired*ServiceCharges/100) as [Service Charge]   ,   convert(numeric(18,2),haircut/100*@collateralvalue)  as [Haircut Maximum], LendingPeriod as [Max Tenure] from Para_LendingRules where LendingPeriod>=@tenure  and MiniAmount<=@amountrequired and MaxiAmount>=@amountrequired ) j", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "lenders")
                If (ds.Tables(0).Rows.Count > 0) Then

                    ASPxGridView1.DataSource = ds
                    ASPxGridView1.DataBind()
                    cmbfinancier.DataSource = ds
                    cmbfinancier.TextField = "Bank"
                    cmbfinancier.DataBind()


                Else
                    msgbox("No match found!")
                End If
            End If
        Else
            Response.Redirect(Request.RawUrl)
        End If






    End Sub


    Public Function checkotp(otp As String) As Boolean
        Dim ds As New DataSet

        cmd = New SqlCommand("select *  FROM [CDS].[dbo].[BorrowingRequest] where isnull(OTP,'')='" + otp.Trim + "'  and id in ('" + ViewState("trnsid") + "')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "otp")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return False
        Else
            Return True

        End If
    End Function

    'Protected Sub ASPxGridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles ASPxGridView3.RowCommand

    '    ViewState("idReject") = e.CommandArgument






    '    otptable.Visible = True
    '    otptable2.Visible = True







    'End Sub

    Protected Sub btnotp_Click(sender As Object, e As EventArgs) Handles btnotp.Click
        Try



            ' Dim m As String = getDEPCDS(Session("Username"))
            If txtotp.Text = "" Then
                msgbox("Please enter otp")
                Exit Sub
            End If

            If checkotp(txtotp.Text.ToLower.ToString.Trim) Then
                msgbox("OPT Entered does not match")
                Exit Sub
            End If




            cmd = New SqlCommand("update [CDS].[dbo].[BorrowingRequest] set OTPStatus ='APPROVED' where id ='" + ViewState("trnsid") + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                If cmd.ExecuteNonQuery() = 1 Then
                    msgbox("Transaction Successfully Authorized Waiting For Authorization")

                    txtotp.Text = ""
                End If



            cn.Close()


            loadgrid()
            getApproved()
        Catch ex As Exception
            msgbox("Please make sure you entered all values")
        End Try

    End Sub

    'Protected Sub ASPxGridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxGridView3.SelectedIndexChanged

    '    ViewState("trnsid") = ASPxGridView3.SelectedRow.Cells(1).Text
    '    ViewState("idReject") = ""



    '    otptable.Visible = True
    '    otptable2.Visible = True

    'End Sub

    Public Sub loadgrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("select s.ID [S.No], s.id, Borrower,AvailableQuantity,Unit_Price,Tenure,w.Commodity,w.Grade,Bank, 'Pending'  as [Status] ,convert(date,CapturedDate) CapturedDate   from BorrowingRequest s ,wr w  where w.ReceiptNo=s.Collateral and  Borrower  = '" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') <> 'REJECTED' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()

        End If

    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from lendersregister where cds_Number='" + lstLenders.SelectedItem.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lenders")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdTranShareholder.DataSource = ds
                grdTranShareholder.DataBind()

            Else
                msgbox("No match found!")
            End If

            'Dim ds1 As New DataSet
            'cmd = New SqlCommand("select * from para_lendingrules where security='" + cmbSecurity.SelectedItem.Text + "'", cn)
            'adp = New SqlDataAdapter(cmd)
            'adp.Fill(ds1, "req")
            'If (ds1.Tables(0).Rows.Count > 0) Then
            '    grdTranShareholder0.DataSource = ds1
            '    grdTranShareholder0.DataBind()
            'Else
            '    msgbox("No request parameters found!")
            'End If
        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub

    Public Sub loadterms()
        Dim ds As New DataSet
        cmd = New SqlCommand("select InterestRate, ServiceCharges, LendingPeriod as [Max Tenure], MiniAmount as [Min Amount], MaxiAmount as [Max Amount], Bank from Para_LendingRules", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = ds
            ASPxGridView2.DataBind()

        End If
    End Sub
    Public Sub loadtermswithhaircut(amount As String)
        Dim ds1 As New DataSet
        cmd = New SqlCommand("select InterestRate, ServiceCharges, LendingPeriod as [Max Tenure], MiniAmount as [Min Amount], MaxiAmount as [Max Amount], Bank, Haircut/100*" + amount + " as [Your Max Limit] from Para_LendingRules", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "Accounts_Clients1")
        If (ds1.Tables(0).Rows.Count > 0) Then
            ASPxGridView2.DataSource = ds1
            ASPxGridView2.DataBind()

        End If
    End Sub

    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (cds_number+' '+surname+' '+forenames) as namess from Accounts_Clients where cds_number like '%" & txtcds_number_search.Text & "%' and brokercode='" + Session("brokercode") + "' and cds_number not in (select borrowercdsNo from lendingpool)", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "namess"
                lstNameSearch.TextField = "namess"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(shares),0) as totquantity from trans where company='" + compname(cmbCompany.SelectedItem.Value.ToString) + "' and cds_number='" + getDEPCDS(Session("Username")) + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtavailableQuantity.Text = ds.Tables(0).Rows(0).Item("totquantity")
        Else
            txtavailableQuantity.Text = ds.Tables(0).Rows(0).Item("totquantity")
        End If
        txtshareprice.Text = getcommprice(compname(cmbCompany.SelectedItem.Value.ToString))

        Dim price As Decimal = txtshareprice.Text
        Dim quantity As Decimal = txtavailableQuantity.Text
        Dim value As Decimal = price * quantity
        txtcollateralvalue.Text = value.ToString
        ASPxGridView2.DataSource = Nothing
        ASPxGridView2.DataBind()

        loadtermswithhaircut(txtcollateralvalue.Text)



    End Sub


    'Protected Sub ASPxGridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ASPxGridView3.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim id = DirectCast(e.Row.FindControl("id"), Label).Text




    '        Dim btnView As ImageButton = CType(e.Row.FindControl("LinkButton2"), ImageButton)




    '        e.Row.Enabled = getvalue(id)


    '    End If
    'End Sub


    Public Function getvalue(id As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select OTPStatus   from BorrowingRequest s ,wr w  where w.ReceiptNo=s.Collateral   and  s.id ='" + id + "'  and Borrower  = '" + getDEPCDS(Session("Username")) + "' and isnull(OTPStatus,'') not in ('REJECTED' ,'APPROVED') ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "aft")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function

    Public Function getDEPCDS(CDSno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select Role  FROM [CDS].[dbo].[SystemUsers] where UserName='" + CDSno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Role").ToString
        Else
            Return ""

        End If
    End Function
    Public Function getcommprice(receiptno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select price from WR where receiptno='" + receiptno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Price").ToString
        Else
            Return "1"

        End If
    End Function
    Protected Sub txtshareprice_TextChanged(sender As Object, e As EventArgs) Handles txtshareprice.TextChanged

    End Sub
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()

        Dim xyz As New Common
        If xyz.OTPenabled = True Then


            Dim OTP As String = CreateOTP(4)
            Dim z As New sendmail
            Try
                z.sendmail(getemail(getDEPCDS(Session("Username"))).ToString, "Borrow Authorization Request", "A Borrow on EWR No. " + cmbCompany.SelectedItem.Value.ToString + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
            Catch ex As Exception
                msgbox("Error Sending Email:" + ex.Message + "")
            End Try

            cmd = New SqlCommand("declare @amountrequired money=" + txtquantity.Text + " declare @tenure numeric(18,0)='" + cmbtenure.SelectedItem.Value.ToString + "'   declare @collateralvalue money=" + txtcollateralvalue.Text + "   insert into BorrowingRequest (OTP,OTPSent,Borrower, Collateral, AvailableQuantity, Unit_Price, EffectiveDate, MaturityDate, CapturedDate, Tenure, ServiceCharge, TotalPayment, Bank, LoanAmount, MonthlyInstalment)  select '" + OTP + "','1', '" + txtClientId.Text + "', '" + cmbCompany.SelectedItem.Value.ToString + "','" + txtavailableQuantity.Text + "','" + txtshareprice.Text + "','" + txtEffectiveDate.Text + "','" + txtExpiryDate.Text + "',getdate(),@tenure, [Service Charge],  ([Monthly Instalment]*@tenure)+[Service Charge]  as [Total Payment] , Bank as Bank,'" + txtquantity.Text + "' ,[Monthly Instalment]  from   (   select Bank as [Bank],convert(numeric(18,2),(@amountrequired/@tenure)*InterestRate/100+(@amountrequired/@tenure)) as [Monthly Instalment] ,   convert(numeric(18,2),@amountrequired*ServiceCharges/100) as [Service Charge]   ,   convert(numeric(18,2),haircut/100*@collateralvalue)  as [Haircut Maximum], LendingPeriod as [Max Tenure] from Para_LendingRules where LendingPeriod>=@tenure  and MiniAmount<=@amountrequired and MaxiAmount>=@amountrequired ) j where j.bank='" + cmbfinancier.Text + "'", cn)

        Else

            cmd = New SqlCommand("declare @amountrequired money=" + txtquantity.Text + " declare @tenure numeric(18,0)='" + cmbtenure.SelectedItem.Value.ToString + "'   declare @collateralvalue money=" + txtcollateralvalue.Text + "   insert into BorrowingRequest (Borrower, Collateral, AvailableQuantity, Unit_Price, EffectiveDate, MaturityDate, CapturedDate, Tenure, ServiceCharge, TotalPayment, Bank, LoanAmount, MonthlyInstalment)  select '" + txtClientId.Text + "', '" + cmbCompany.SelectedItem.Value.ToString + "','" + txtavailableQuantity.Text + "','" + txtshareprice.Text + "','" + txtEffectiveDate.Text + "','" + txtExpiryDate.Text + "',getdate(),@tenure, [Service Charge],  ([Monthly Instalment]*@tenure)+[Service Charge]  as [Total Payment] , Bank as Bank,'" + txtquantity.Text + "' ,[Monthly Instalment]  from   (   select Bank as [Bank],convert(numeric(18,2),(@amountrequired/@tenure)*InterestRate/100+(@amountrequired/@tenure)) as [Monthly Instalment] ,   convert(numeric(18,2),@amountrequired*ServiceCharges/100) as [Service Charge]   ,   convert(numeric(18,2),haircut/100*@collateralvalue)  as [Haircut Maximum], LendingPeriod as [Max Tenure] from Para_LendingRules where LendingPeriod>=@tenure  and MiniAmount<=@amountrequired and MaxiAmount>=@amountrequired ) j where j.bank='" + cmbfinancier.Text + "'", cn)

        End If

        cmd.ExecuteNonQuery()
        cn.Close()


        'cmd = New SqlCommand("declare @amountrequired money=" + txtquantity.Text + " declare @tenure numeric(18,0)='" + cmbtenure.SelectedItem.Value.ToString + "'   declare @collateralvalue money=" + txtcollateralvalue.Text + "   insert into BorrowingRequest (Borrower, Collateral, AvailableQuantity, Unit_Price, EffectiveDate, MaturityDate, CapturedDate, Tenure, ServiceCharge, TotalPayment, Bank, LoanAmount, MonthlyInstalment)  select '" + txtClientId.Text + "', '" + cmbCompany.SelectedItem.Value.ToString + "','" + txtavailableQuantity.Text + "','" + txtshareprice.Text + "','" + txtEffectiveDate.Text + "','" + txtExpiryDate.Text + "',getdate(),@tenure, [Service Charge],  ([Monthly Instalment]*@tenure)+[Service Charge]  as [Total Payment] , Bank as Bank,'" + txtquantity.Text + "' ,[Monthly Instalment]  from   (   select Bank as [Bank],convert(numeric(18,2),(@amountrequired/@tenure)*InterestRate/100+(@amountrequired/@tenure)) as [Monthly Instalment] ,   convert(numeric(18,2),@amountrequired*ServiceCharges/100) as [Service Charge]   ,   convert(numeric(18,2),haircut/100*@collateralvalue)  as [Haircut Maximum], LendingPeriod as [Max Tenure] from Para_LendingRules where LendingPeriod>=@tenure  and MiniAmount<=@amountrequired and MaxiAmount>=@amountrequired ) j where j.bank='" + cmbfinancier.Text + "'", cn)
        '' cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('Permission added for " + cmbParticipants.SelectedItem.Text + ". Permission is " + Gridview1.SelectedRow.Cells(0).Text + "' , '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','Pemission Added')", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd.ExecuteNonQuery()
        'cn.Close()

        loadgrid()
        getApproved()
        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub cmbtenure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtenure.SelectedIndexChanged
        Dim ds As New DataSet
        cmd = New SqlCommand("select convert(date, dateadd(month, " + cmbtenure.SelectedItem.Value.ToString + ", '" + txtEffectiveDate.Text + "')) as [maturitydate]", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtExpiryDate.Text = ds.Tables(0).Rows(0).Item("maturitydate")
        End If
    End Sub
End Class
