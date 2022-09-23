Partial Class TransferSec_foreclosure
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


    'Public Sub GetCompany()
    '    Try
    '        Dim ds As New DataSet
    '        cmd = New SqlCommand("select distinct (company) from trans WHERE cds_number='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "trans")
    '        If (ds.Tables(0).Rows.Count > 0) Then
    '            cmbCompany.DataSource = ds.Tables(0)
    '            cmbCompany.TextField = "company"
    '            cmbCompany.ValueField = "company"
    '            cmbCompany.DataBind()
    '        End If
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
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
                '  runasync()

                RadioButtonList1.SelectedIndex = -1
                '     getpending()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub getpending()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select 'CDS Number: '+ Borrower + '  Collateral: '+ Collateral +'  Amount: '+ convert(nvarchar(50),LoanAmount) +'  Tenure: '+ convert(nvarchar(50),tenure) as [LoanDetails], id from BorrowingRequest where ApprovedBY is NOT NULL and rejected Is NOT null and Bank='" + Session("BrokerCode") + "' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "id"
                lstNameSearch.TextField = "LoanDetails"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients where cds_number=(select borrower from BorrowingRequest where id='" & lstNameSearch.SelectedItem.Value.ToString & "')", cn)
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
    Public Sub GetDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from BorrowingRequest where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim n As Decimal = ds.Tables(0).Rows(0).Item("Unit_Price").ToString
                Dim a As Decimal = ds.Tables(0).Rows(0).Item("AvailableQuantity").ToString
                cmbcompany.Text = ds.Tables(0).Rows(0).Item("Collateral").ToString
                txtavailableQuantity.Text = a.ToString("N")
                txtcapturedate.Text = ds.Tables(0).Rows(0).Item("CapturedDate").ToString
                txtEffectiveDate.Value = ds.Tables(0).Rows(0).Item("EffectiveDate").ToString
                '  txtExpiryDate.Text = ds.Tables(0).Rows(0).Item("MaturityDate").ToString
                Dim amtln As Decimal = ds.Tables(0).Rows(0).Item("AmountApproved").ToString
                txtquantity.Text = amtln.ToString("N")
                ' Dim srvcfee As Decimal = ds.Tables(0).Rows(0).Item("ServiceCharge").ToString


                Dim prce As Decimal = ds.Tables(0).Rows(0).Item("Unit_Price").ToString
                txtshareprice.Text = prce.ToString("N")
                txtcollateralvalue.Text = (n * a).ToString("N")
                '  txtmonthlyinstalment.Text = ds.Tables(0).Rows(0).Item("MonthlyInstalment").ToString
                Dim totpaymnt As Decimal = ds.Tables(0).Rows(0).Item("totalpayment").ToString
                Dim tt As Decimal = totpaymnt + loancharges(cmbcompany.Text, txtClientId.Text)
                txttotal.Text = tt.ToString("N")

                Dim srvcfee As Decimal = ds.Tables(0).Rows(0).Item("ServiceCharge").ToString
                txtservicefee.Text = srvcfee.ToString("N")
                txtloancharges.Text = (loancharges(cmbcompany.Text, txtClientId.Text) - srvcfee).ToString("N")
                '  txttenure.Text = ds.Tables(0).Rows(0).Item("Tenure").ToString

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function loancharges(reference As String, cds_Number As String) As Decimal

        Dim n As New NaymatBilling
        Return n.getEWRBAL_LOANcharges(reference, cds_Number)

    End Function
    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        GetSelectedDetails()
        GetDetails()


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




    Protected Sub txtshareprice_TextChanged(sender As Object, e As EventArgs) Handles txtshareprice.TextChanged
        Dim price As Decimal = txtshareprice.Text
        Dim quantity As Decimal = txtavailableQuantity.Text
        Dim value As Decimal = price * quantity
        txtcollateralvalue.Text = value.ToString

    End Sub
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try

            '  cmd = New SqlCommand("insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, [source], pledge_shares)  values ('" + cmbCompany.Text + "','" + txtClientId.Text + "',getdate(), getdate(), " + txtavailableQuantity.Text + "*-1,'PLEDGE','ADMIN','0','D','0')  INSERT INTO CDSC.DBO.CashTrans (Description, TransType, Amount, DateCreated , TransStatus , CDS_Number, Paid, Reference )  VALUES ('Loan Disbursement','Loan','" + txtquantity.Text + "',getdate(),'1','" + txtClientId.Text + "','1','" + lstNameSearch.SelectedItem.Value.ToString + "')  INSERT INTO CDSC.DBO.CashTrans (Description, TransType, Amount, DateCreated , TransStatus , CDS_Number, Paid, Reference )  VALUES ('Loan Service Fee','Service Fee','-" + txtservicefee.Text + "',getdate(),'1','" + txtClientId.Text + "','1','" + lstNameSearch.SelectedItem.Value.ToString + "') update BorrowingRequest set Approved='1', ApprovedBy='" + Session("Username") + "' , approvedOn=getdate() where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            cmd = New SqlCommand(" update BorrowingRequest set [STATUS]='FORECLOSURE PENDING', foreclosuredetails='" + txtforeclosuredetail.Text + "', Foreclosuretype='" + RadioButtonList1.SelectedItem.Text + "', Transferee='" + ListBox1.SelectedValue.ToString + "'  where id='" + lstNameSearch.SelectedItem.Value.ToString + "'", cn)
            If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim a As New passmanagement
                a.auditlog(Session("BrokerCode"), Session("Username"), "Submitted a foreclosure to account: " + ListBox1.SelectedValue.ToString + "", txtClientId.Text, cmbcompany.Text)
            Catch ex As Exception

            End Try
            Session("finish") = "true"
            Response.Redirect(Request.RawUrl)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton11_Click(sender As Object, e As EventArgs) Handles ASPxButton11.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select 'Names: ' + A.forenames+' ' + a.Surname +  ' Account No: '+ Borrower + '  Collateral: '+ Collateral +'  Amount: '+ convert(nvarchar(50),LoanAmount)  as [LoanDetails], b.id from BorrowingRequest b, accounts_clients a  where b.Borrower=a.cds_number and ApprovedBY is NOT NULL and rejected Is null and Bank='" + Session("BrokerCode") + "' AND borrower+''+collateral+''+a.surname+' '+a.forenames like '%" + txtsearch.Text + "%' and ISNULL(b.[status],'PLEDGED')='PLEDGED'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                lstNameSearch.DataSource = ds.Tables(0)
                lstNameSearch.ValueField = "id"
                lstNameSearch.TextField = "LoanDetails"
                lstNameSearch.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("select cds_number+' '+isnull(forenames,'')+' '+isnull(middlename,'')+' '+isnull(surname,'') as names, cds_number from accounts_clients where cds_number+' '+isnull(surname,'')+' '+isnull(middlename,'')+' '+isnull(forenames,'') like '%" + txtaccount.Text + "%' order by cds_number", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            ListBox1.DataSource = ds
            ListBox1.DataTextField = "names"
            ListBox1.DataValueField = "cds_number"
            ListBox1.DataBind()

        End If
    End Sub
End Class
