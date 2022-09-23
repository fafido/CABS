Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports DevExpress.Web.ASPxGridView
Partial Class AccountsEDIT
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
    Public Sub getInterCompanyAccounts()
        Try
            Dim ds As New DataSet '
            cmd = New SqlCommand("SELECT AccountName,AccountNumber FROM Para_InterCompanyAccounts ORDER BY AccountName", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_InterCompanyAccounts")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbInterCompanyAccount.DataSource = ds.Tables(0)
                cmbInterCompanyAccount.TextField = "AccountName"
                cmbInterCompanyAccount.ValueField = "AccountNumber"
                cmbInterCompanyAccount.DataBind()

                cmbInterCompanyAccountCORP.DataSource = ds.Tables(0)
                cmbInterCompanyAccountCORP.TextField = "AccountName"
                cmbInterCompanyAccountCORP.ValueField = "AccountNumber"
                cmbInterCompanyAccountCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBankName()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct bank,bank_name from para_bank order by bank_name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBankDiv.DataSource = ds.Tables(0)
                cmbBankDiv.TextField = "bank_name"
                cmbBankDiv.ValueField = "bank"
                cmbBankDiv.DataBind()

                cmbBankDivCORP.DataSource = ds.Tables(0)
                cmbBankDivCORP.TextField = "bank_name"
                cmbBankDivCORP.ValueField = "bank"
                cmbBankDivCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBillingProfiles()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT ProfileCode,ProfileName + ' | ' + ProfileCode as DispName  FROM para_BillingProfiles order by ProfileName", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_BillingProfiles")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBillingProfile.DataSource = ds.Tables(0)
                cmbBillingProfile.ValueField = "ProfileCode"
                cmbBillingProfile.TextField = "DispName"
                cmbBillingProfile.DataBind()

                cmbBillingProfileCORP.DataSource = ds.Tables(0)
                cmbBillingProfileCORP.ValueField = "ProfileCode"
                cmbBillingProfileCORP.TextField = "DispName"
                cmbBillingProfileCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetClassification()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT * FROM para_brokerclasses ORDER BY ID", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_brokerclasses")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbClassification.DataSource = ds.Tables(0)
                cmbClassification.ValueField = "Class_name"
                cmbClassification.TextField = "Class_name"
                cmbClassification.DataBind()

                cmbClassificationCORP.DataSource = ds.Tables(0)
                cmbClassificationCORP.ValueField = "Class_name"
                cmbClassificationCORP.TextField = "Class_name"
                cmbClassificationCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCurrencies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT CurrencyCode,ISNULL(CurrencyCode,'')+' | '+ ISNULL(CurrencyName,'') AS DISPName FROM para_Currencies order by CurrencyCode", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Currencies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBillingCurrency.DataSource = ds.Tables(0)
                cmbBillingCurrency.ValueField = "CurrencyCode"
                cmbBillingCurrency.TextField = "CurrencyCode"
                cmbBillingCurrency.DataBind()

                cmbBillingCurrencyCORP.DataSource = ds.Tables(0)
                cmbBillingCurrencyCORP.ValueField = "CurrencyCode"
                cmbBillingCurrencyCORP.TextField = "CurrencyCode"
                cmbBillingCurrencyCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetUnitTrustFunds()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT Funding_Code as FundCode,Funding_Name  + ' | ' + Funding_Code as DispName  FROM Approved_Unit_Trust_Funding order by Funding_Name", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Fund")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbUnitTrustFund.DataSource = ds.Tables(0)
                cmbUnitTrustFund.ValueField = "FundCode"
                cmbUnitTrustFund.TextField = "DispName"
                cmbUnitTrustFund.DataBind()

                cmbUnitTrustFundCORP.DataSource = ds.Tables(0)
                cmbUnitTrustFundCORP.ValueField = "FundCode"
                cmbUnitTrustFundCORP.TextField = "DispName"
                cmbUnitTrustFundCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getAssetmanagers()
        Try
            Dim ds As New DataSet '
            cmd = New SqlCommand("select * from para_assetManager order by AssetMananger", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbAssetManager.DataSource = ds.Tables(0)
                cmbAssetManager.TextField = "AssetMananger"
                cmbAssetManager.ValueField = "AssetManagerCode"
                cmbAssetManager.DataBind()
                cmbAssetManagerCORP.DataSource = ds.Tables(0)
                cmbAssetManagerCORP.TextField = "AssetMananger"
                cmbAssetManagerCORP.ValueField = "AssetManagerCode"
                cmbAssetManagerCORP.DataBind()
            Else
                cmbAssetManager.DataSource = Nothing
                cmbAssetManager.DataBind()
                cmbAssetManagerCORP.DataSource = Nothing
                cmbAssetManagerCORP.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCountry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCountry.DataSource = ds.Tables(0)
                cmbCountry.TextField = "country"
                cmbCountry.ValueField = "country"
                cmbCountry.DataBind()

                cmbCountryCORP.DataSource = ds.Tables(0)
                cmbCountryCORP.TextField = "country"
                cmbCountryCORP.ValueField = "country"
                cmbCountryCORP.DataBind()

                cmbCountryTaxResidenceCORP.DataSource = ds.Tables(0)
                cmbCountryTaxResidenceCORP.TextField = "country"
                cmbCountryTaxResidenceCORP.ValueField = "country"
                cmbCountryTaxResidenceCORP.DataBind()
            Else
                cmbCountry.Items.Clear()
                cmbCountryCORP.Items.Clear()
                cmbCountryTaxResidenceCORP.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetNationality()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Nationality) from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbNationality.DataSource = ds.Tables(0)
                cmbNationality.ValueField = "Nationality"
                cmbNationality.TextField = "Nationality"
                cmbNationality.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                GetCountry()
                getAssetmanagers()
                GetNationality()
                GetBillingProfiles()
                GetUnitTrustFunds()
                GetClassification()
                GetCurrencies()
                GetBankName()
                getInterCompanyAccounts()
                cmbIDType.Items.Add("ID No.")
                cmbIDType.Items.Add("Passport No.")
                cmbIDType.SelectedIndex = -1
                txtDOBCORP.MaxDate = Date.UtcNow.ToString
                txtDOB.MaxDate = Date.UtcNow.ToString
                Try
                    cmbCountry.Value = "Zimbabwe"
                    cmbNationality.Value = "Zimbabwe"
                Catch ex As Exception
                End Try
                getAccountList()
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox(Session("updatemsg"))
                    Session("AccountNo") = ""
                    Session("updatemsg") = ""
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Sub getAccountList()
        lstNameSearch.Items.Clear()
        lstNameSearch.DataSource = Nothing
        lstNameSearch.DataBind()
        Dim ds As New DataSet
        cmd = New SqlCommand("select a.cds_number,a.cds_number+' '+case when a.AccountType IN ('C') THEN isnull(a.Surname,'') else isnull(forenames,'')+' '+isnull(surname,'') end as namess from accounts_audit a where ISNULL(a.ViewedAuth,0)=0 AND ISNULL(a.AuthorizationState,'') IN ('O') AND a.Created_By=@Created_By and a.CDS_Number NOT IN (SELECT DISTINCT p.CDS_Number FROM Accounts_Clients p) order by a.id desc", cn)
        cmd.Parameters.AddWithValue("Created_By", Session("Username"))
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "accounts_audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            lstNameSearch.DataSource = ds.Tables(0)
            lstNameSearch.TextField = "namess"
            lstNameSearch.ValueField = "cds_number"
            lstNameSearch.DataBind()
        Else
            lstNameSearch.Items.Clear()
            lstNameSearch.DataSource = Nothing
            lstNameSearch.DataBind()
        End If
    End Sub
    Protected Sub lstNameSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameSearch.SelectedIndexChanged
        If AccountNOTViewedByAuthorizer(lstNameSearch.SelectedItem.Value) = False Then
            msgbox("Authorizer has already Reviewed the account")
            Exit Sub
        Else
            getAccountDetails()
        End If
    End Sub
    Public Sub getuploaded()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID, Name, ContentType,CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 'Marked for Deletion' WHEN ISNULL(MarkedForDeletion,0)=3 then 'New' else '' end as UpdateStatus from accounts_documents where doc_generated='" + TXTClientID.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsid2
            ASPxGridView1.DataBind()
        End If
    End Sub
    Public Sub getuploadedCORP()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID, Name, ContentType,CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 'Marked for Deletion' WHEN ISNULL(MarkedForDeletion,0)=3 then 'New' else '' end as UpdateStatus from accounts_documents where doc_generated='" + TXTClientID.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1CORP.DataSource = dsid2
            ASPxGridView1CORP.DataBind()
        End If
    End Sub
    Public Sub getAccountDetails()
        ClearAllFields()
        Dim ds As New DataSet
        cmd = New SqlCommand("select case when ISNULL(BillCashAccount,0)=0 then 0 else 1 end AS BillCashAccount1,FORMAT(AgreementDate,'dd MMMM yyyy') AS AgreementDate1,FORMAT(TRY_PARSE(CNICExpiry as date),'dd MMMM yyyy','en-us') as CNICExpiry1,FORMAT(TRY_PARSE(PassportExpiry as date),'dd MMMM yyyy','en-us') as PassportExpiry1,FORMAT(DOB,'dd MMMM yyyy') AS DOB1,FORMAT(BusCommenceDate,'dd MMMM yyyy') AS BusCommenceDate1,*,CASE WHEN AccountType='I' THEN 'Single' when AccountType='J' THEN 'Joint' when AccountType='C' THEN 'Corporate' when AccountType='P' THEN 'Pension Fund' else AccountType end as myAccType from Accounts_Audit where CDS_Number='" & lstNameSearch.SelectedItem.Value & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            lblRecordID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
            TXTClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            rdAccountType.Text = ds.Tables(0).Rows(0).Item("myAccType").ToString
            If ds.Tables(0).Rows(0).Item("AccountType").ToString = "I" Then
                singleTab("Show")
                JointTab("Hide")
                CoorporateTab("Hide")
            ElseIf ds.Tables(0).Rows(0).Item("AccountType").ToString = "J" Then
                singleTab("Show")
                JointTab("Show")
                CoorporateTab("Hide")
            Else
                singleTab("Hide")
                JointTab("Hide")
                CoorporateTab("Show")
            End If
            If ds.Tables(0).Rows(0).Item("AccountType").ToString = "I" Or ds.Tables(0).Rows(0).Item("AccountType").ToString = "J" Then
                'SHOW/HIDE
                Try
                    cmbIDType.Value = ds.Tables(0).Rows(0).Item("IDtype").ToString
                Catch ex As Exception
                    cmbIDType.SelectedIndex = -1
                End Try
                txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
                'msgbox(ds.Tables(0).Rows(0).Item("JointName").ToString)
                txtSurname0.Text = ds.Tables(0).Rows(0).Item("JointName").ToString
                Try
                    cmbTitle.Value = ds.Tables(0).Rows(0).Item("Title").ToString
                Catch ex As Exception
                    cmbTitle.SelectedIndex = -1
                End Try
                txtCNIC.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString
                txtOthernames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB1").ToString
                If ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "M" Or ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "MALE" Then
                    rdMale.Checked = True
                    rdFemale.Checked = False
                    rdNa.Checked = False
                ElseIf ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "F" Or ds.Tables(0).Rows(0).Item("Gender").ToString.ToUpper = "FEMALE" Then
                    rdMale.Checked = False
                    rdFemale.Checked = True
                    rdNa.Checked = False
                Else
                    rdMale.Checked = False
                    rdFemale.Checked = False
                    rdNa.Checked = True
                End If
                Try
                    cmbTypeofAccount.Value = ds.Tables(0).Rows(0).Item("BankAccount_Type").ToString
                Catch ex As Exception
                    cmbTypeofAccount.SelectedIndex = -1
                End Try
                Try
                    cmbBillingProfile.Value = ds.Tables(0).Rows(0).Item("BillingProfile").ToString
                Catch ex As Exception
                    cmbBillingProfile.SelectedIndex = -1
                End Try
                Try
                    cmbBillingCurrency.Value = ds.Tables(0).Rows(0).Item("BillingCurrency").ToString
                Catch ex As Exception
                    cmbBillingCurrency.SelectedIndex = -1
                End Try
                Dim BillCashAccount As Integer = 0
                Try
                    BillCashAccount = CInt(ds.Tables(0).Rows(0).Item("BillCashAccount1"))
                Catch ex As Exception
                    BillCashAccount = 0
                End Try
                If BillCashAccount = 1 Then
                    chkBillCashAccount.Checked = True
                Else
                    chkBillCashAccount.Checked = False
                End If
                Try
                    cmbClassification.Value = ds.Tables(0).Rows(0).Item("Category").ToString
                Catch ex As Exception
                    cmbClassification.SelectedIndex = -1
                End Try
                Try
                    cmbInvestorType.Value = ds.Tables(0).Rows(0).Item("Industry").ToString
                Catch ex As Exception
                    cmbInvestorType.SelectedIndex = -1
                End Try
                Try
                    cmbUnitTrustFund.Value = ds.Tables(0).Rows(0).Item("Fund").ToString
                Catch ex As Exception
                    cmbUnitTrustFund.SelectedIndex = -1
                End Try
                Try
                    getAssetmanagersClients()
                Catch ex As Exception
                End Try
                Try
                    cmbNationality.Value = ds.Tables(0).Rows(0).Item("Nationality").ToString
                Catch ex As Exception
                    cmbNationality.SelectedIndex = -1
                End Try
                txtpassport.Text = ds.Tables(0).Rows(0).Item("Passport").ToString
                Try
                    cmbCountry.Value = ds.Tables(0).Rows(0).Item("Country").ToString
                Catch ex As Exception
                    cmbCountry.SelectedIndex = -1
                End Try
                txtsourceofIncome.Text = ds.Tables(0).Rows(0).Item("SOI").ToString
                txtAddress1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
                txtCNIC.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString
                txtFax.Text = ds.Tables(0).Rows(0).Item("POSTCODE").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
                txtIBAN.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
                Try
                    cmbBankDiv.Value = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
                Catch ex As Exception
                    cmbBankDiv.SelectedIndex = -1
                End Try

                Try
                    cmbBankCat.Value = ds.Tables(0).Rows(0).Item("Account_class").ToString
                Catch ex As Exception
                    cmbBankCat.SelectedIndex = 0
                End Try
                txtBankForeign.Text = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
                cmbBankCat_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)

                txtBranchDiv.Text = ds.Tables(0).Rows(0).Item("Div_Branch").ToString
                txtSwiftCode.Text = ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString
                txtbankAddress.Text = ds.Tables(0).Rows(0).Item("SettlementPayee").ToString
                txtDateTimeStamp.Text = ds.Tables(0).Rows(0).Item("NTN").ToString
                txtcdcnumber.Text = ds.Tables(0).Rows(0).Item("cdcnumber").ToString
                getuploaded()
                getJointHolders()
                cmbTypeofAccount_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
            ElseIf ds.Tables(0).Rows(0).Item("AccountType").ToString = "C" Or ds.Tables(0).Rows(0).Item("AccountType").ToString = "P" Then
                Try
                    cmbIDTypeCORP.Value = ds.Tables(0).Rows(0).Item("IDtype").ToString
                Catch ex As Exception
                    cmbIDTypeCORP.SelectedIndex = -1
                End Try
                txtIDNoCORP.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
                txtSurnameCORP.Text = ds.Tables(0).Rows(0).Item("surname").ToString

                Try
                    cmbTypeofAccountCORP.Value = ds.Tables(0).Rows(0).Item("BankAccount_Type").ToString
                Catch ex As Exception
                    cmbTypeofAccountCORP.SelectedIndex = -1
                End Try
                Try
                    cmbBillingProfileCORP.Value = ds.Tables(0).Rows(0).Item("BillingProfile").ToString
                Catch ex As Exception
                    cmbBillingProfileCORP.SelectedIndex = -1
                End Try
                Try
                    cmbBillingCurrencyCORP.Value = ds.Tables(0).Rows(0).Item("BillingCurrency").ToString
                Catch ex As Exception
                    cmbBillingCurrencyCORP.SelectedIndex = -1
                End Try
                Dim BillCashAccount As Integer = 0
                Try
                    BillCashAccount = CInt(ds.Tables(0).Rows(0).Item("BillCashAccount1"))
                Catch ex As Exception
                    BillCashAccount = 0
                End Try
                If BillCashAccount = 1 Then
                    chkBillCashAccountCORP.Checked = True
                Else
                    chkBillCashAccountCORP.Checked = False
                End If
                Try
                    cmbClassificationCORP.Value = ds.Tables(0).Rows(0).Item("Category").ToString
                Catch ex As Exception
                    cmbClassificationCORP.SelectedIndex = -1
                End Try
                txtAddress1CORP.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtAddress2CORP.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                Try
                    cmbCountryCORP.Value = ds.Tables(0).Rows(0).Item("Country").ToString
                Catch ex As Exception
                    cmbCountryCORP.SelectedIndex = -1
                End Try
                Try
                    cmbCountryTaxResidenceCORP.Value = ds.Tables(0).Rows(0).Item("Nationality").ToString
                Catch ex As Exception
                    cmbCountryTaxResidenceCORP.SelectedIndex = -1
                End Try
                txtNatureOfBusinessCORP.Text = ds.Tables(0).Rows(0).Item("Designation").ToString
                txtDOBCORP.Text = ds.Tables(0).Rows(0).Item("DOB1").ToString
                txtSourceofFundsCORP.Text = ds.Tables(0).Rows(0).Item("SOI").ToString
                Try
                    cmbInvestorTypeCORP.Value = ds.Tables(0).Rows(0).Item("Industry").ToString
                Catch ex As Exception
                    cmbInvestorTypeCORP.SelectedIndex = -1
                End Try
                txtfullnameCORP.Text = ds.Tables(0).Rows(0).Item("contactpersonname").ToString
                txtTelCORP.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
                txtEmailCORP.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtFaxCORP.Text = ds.Tables(0).Rows(0).Item("PostCode").ToString
                txtPayee2CORP.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
                txtIBANCORP.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
                Try
                    cmbBankDivCORP.Value = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
                Catch ex As Exception
                    cmbBankDivCORP.SelectedIndex = -1
                End Try
                Try
                    cmbBankCatCORP.Value = ds.Tables(0).Rows(0).Item("Account_class").ToString
                Catch ex As Exception
                    cmbBankCatCORP.SelectedIndex = 0
                End Try
                txtBankForeignCORP.Text = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
                cmbBankCatCORP_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
                txtBranchDivCORP.Text = ds.Tables(0).Rows(0).Item("Div_Branch").ToString
                txtBankAddressCORP.Text = ds.Tables(0).Rows(0).Item("SettlementPayee").ToString
                txtSwiftCodeCORP.Text = ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString
                txtcdcnumberCORP.Text = ds.Tables(0).Rows(0).Item("cdcnumber").ToString
                Try
                    cmbUnitTrustFundCORP.Value = ds.Tables(0).Rows(0).Item("Fund").ToString
                Catch ex As Exception
                    cmbUnitTrustFundCORP.SelectedIndex = -1
                End Try
                Try
                    getAssetmanagersClientsCORP()
                Catch ex As Exception
                End Try
                getuploadedCORP()
                cmbTypeofAccountCORP_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
            End If
        End If
    End Sub
    Sub singleTab(ByVal actionNeeded As String)
        If actionNeeded = "Show" Then
            Panel0a.Visible = True
            Panel13a.Visible = True
            'Panel15a.Visible = True
            'Panel15b.Visible = True
            Panel8a.Visible = True
            Panel8b.Visible = True
            Panel8d.Visible = True
            Panel8l.Visible = True
            Panel8f.Visible = True
            Panel8k.Visible = True
            Panel8kc.Visible = True
            Panel8kcA.Visible = True
            Panel3a.Visible = True
            Panel8i.Visible = True
            Panel3b.Visible = True
            Panel3bb.Visible = True
            Panel3bbb.Visible = True
            Panel3bbbb.Visible = True
            Panel3bbbb1.Visible = True
            Panel3bbbb2.Visible = True
            Panel3bbbbc.Visible = True
            Panel3l.Visible = True
            Panel4a.Visible = True
            Panel4b.Visible = True
            Panel4c.Visible = True
            Panel4d.Visible = True
            Panel4e.Visible = True
            panelSave1.Visible = True
            panelSave2.Visible = True
            panelSave3.Visible = True
            panelSave4.Visible = True
            panelSave5.Visible = True
            panelsaving2a.Visible = True
            panelsaving2.Visible = True
        Else
            Panel0a.Visible = False
            Panel13a.Visible = False
            ' Panel15a.Visible = False
            ' Panel15b.Visible = False
            Panel8a.Visible = False
            Panel8b.Visible = False
            Panel8d.Visible = False
            Panel8l.Visible = False
            Panel8f.Visible = False
            Panel8k.Visible = False
            Panel8kc.Visible = False
            Panel8kcA.Visible = False
            Panel3a.Visible = False
            Panel8i.Visible = False
            Panel3b.Visible = False
            Panel3l.Visible = False
            Panel4a.Visible = False
            Panel4b.Visible = False
            Panel4c.Visible = False
            Panel4d.Visible = False
            Panel4e.Visible = False
            panelSave1.Visible = False
            panelSave2.Visible = False
            panelSave3.Visible = False
            panelSave4.Visible = False
            panelSave5.Visible = False
            panelsaving2a.Visible = False
            panelsaving2.Visible = False
            Panel3bb.Visible = False
            Panel3bbb.Visible = False
            Panel3bbbb.Visible = False
            Panel3bbbb1.Visible = False
            Panel3bbbb2.Visible = False
            Panel3bbbbc.Visible = False
        End If
    End Sub
    Sub CoorporateTab(ByVal actionNeeded As String)
        If actionNeeded = "Show" Then
            CORP1.Visible = True
            CORP3.Visible = True
            CORP3a.Visible = True
            CORP3ac.Visible = True
            CORP4.Visible = True
            CORP5.Visible = True
            CORP6.Visible = True
            CORP7.Visible = True
            CORP8.Visible = True
            CORP8b.Visible = True
            CORP8c.Visible = True
            CORP8D.Visible = True
            CORP8E.Visible = True
            CORP9.Visible = True
            CORP10.Visible = True
            CORP11.Visible = True
            CORP12.Visible = True
            CORP13.Visible = True
            CORPTr3.Visible = True
            CORP14.Visible = True
            CORP15.Visible = True
            CORP17.Visible = True
            CORP18.Visible = True
            CORP19.Visible = True
            CORP20.Visible = True
            CORP21.Visible = True
            CORP22.Visible = True
            CORP8Dz.Visible = True
            CORP8Dx.Visible = True
        Else
            CORP1.Visible = False
            CORP3.Visible = False
            CORP3a.Visible = False
            CORP3ac.Visible = False
            CORP4.Visible = False
            CORP5.Visible = False
            CORP6.Visible = False
            CORP7.Visible = False
            CORP8.Visible = False
            CORP8b.Visible = False
            CORP8c.Visible = False
            CORP8D.Visible = False
            CORP8E.Visible = False
            CORP9.Visible = False
            CORP10.Visible = False
            CORP11.Visible = False
            CORP12.Visible = False
            CORP13.Visible = False
            CORPTr3.Visible = False
            CORP14.Visible = False
            CORP15.Visible = False
            CORP17.Visible = False
            CORP18.Visible = False
            CORP19.Visible = False
            CORP20.Visible = False
            CORP21.Visible = False
            CORP22.Visible = False
            CORP8Dz.Visible = False
            CORP8Dx.Visible = False
        End If
    End Sub
    Sub JointTab(ByVal actionNeeded As String)
        If actionNeeded = "Show" Then
            Panel15a.Visible = True
            Panel15b.Visible = True
            Panel20a.Visible = True
            Panel20b.Visible = True
            Panel20c.Visible = True
            Panel20d.Visible = True
            panel20e.Visible = True
            panel20f.Visible = True
        Else
            Panel15a.Visible = False
            Panel15b.Visible = False
            Panel20a.Visible = False
            Panel20b.Visible = False
            Panel20c.Visible = False
            Panel20d.Visible = False
            panel20e.Visible = False
            panel20f.Visible = False
        End If
    End Sub
    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Response.Write(ex.Message)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function
    Public Sub checkuploadCORP()
        Dim filePath As String = FileUpload1CORP.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty
        'Set the contenttype based on File Extension
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
                Exit Select
            Case ".png"
                contenttype = ".png"
                Exit Select
            Case ".gif"
                contenttype = ".gif"
                Exit Select
            Case ".pdf"
                contenttype = ".pdf"
                Exit Select
        End Select
        Dim docname As String = ""
        If txtdocumentnameCORP.SelectedItem.Text = "Other" Then
            docname = txtotherdocCORP.Text
            If docname = "" Then
                msgbox("Please enter document name!")
                Exit Sub
            End If
        Else
            docname = txtdocumentnameCORP.Text
        End If
        If contenttype <> String.Empty Then
            Dim fs As Stream = FileUpload1CORP.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            'insert the file into database 
            Dim strQuery As String = "insert into Accounts_Documents" & "(doc_generated, Name, ContentType, Data,CreatedBy,MarkedForDeletion)" & " values (@doc_generated,@Name, @ContentType, @Data,@CreatedBy,3)"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = TXTClientID.Text
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "" + docname + ""
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Session("Username")
            InsertUpdateData(cmd)
            txtdocumentnameCORP.Text = ""
            txtotherdocCORP.Text = ""
            msgbox("Document Uploaded")
        Else
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF formats")
        End If
    End Sub
    Protected Sub ASPxButton10CORP_Click(sender As Object, e As EventArgs) Handles ASPxButton10CORP.Click
        checkuploadCORP()
        getuploadedCORP()
    End Sub
    Public Function checkupload() As Boolean
        Dim filePath As String = FileUpload1.PostedFile.FileName
        Dim filename As String = Path.GetFileName(filePath)
        Dim ext As String = Path.GetExtension(filename)
        Dim contenttype As String = String.Empty
        'Set the contenttype based on File Extension
        Select Case ext
            Case ".doc"
                contenttype = ".doc"
                Exit Select
            Case ".docx"
                contenttype = ".docx"
                Exit Select
            Case ".jpg"
                contenttype = ".jpg"
                Exit Select
            Case ".png"
                contenttype = ".png"
                Exit Select
            Case ".gif"
                contenttype = ".gif"
                Exit Select
            Case ".pdf"
                contenttype = ".pdf"
                Exit Select
        End Select
        Dim docname As String = ""
        If txtdocumentname.SelectedItem.Text = "Other" Then
            docname = txtotherdoc.Text
            If docname = "" Then
                msgbox("Please enter document name!")
                Return False
            End If
        Else
            docname = txtdocumentname.Text
        End If
        If contenttype <> String.Empty Then
            Dim fs As Stream = FileUpload1.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            'insert the file into database 
            Dim strQuery As String = "insert into Accounts_Documents" & "(doc_generated, Name, ContentType, Data,CreatedBy,MarkedForDeletion)" & " values (@doc_generated,@Name, @ContentType, @Data,@CreatedBy,3)"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = TXTClientID.Text
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "" + docname + ""
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Session("Username")
            InsertUpdateData(cmd)
            Return True
        Else
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF formats")
            Return False
        End If
    End Function
    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        If checkupload() = True Then
            getuploaded()
            txtdocumentname.Text = ""
            txtotherdoc.Text = ""
            msgbox("Document Uploaded")
        End If
    End Sub
    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        If validateIndividualFields() = False Then
        Else
            SaveNewAccount()
        End If
    End Sub
    Public Function validateIndividualFields() As Boolean
        If rdAccountType.Text = "Joint" Then
            If (txtSurname0.Text.Trim = "") Then
                msgbox("Please Enter Full Name")
                txtSurname0.Focus()
                Return False
            End If
        End If
        If (Len(txtSurname.Text.Trim) < 1) Then
            msgbox("Please enter a valid surname")
            txtSurname.Focus()
            Return False
        End If
        If (Len(txtOthernames.Text.Trim) < 1) Then
            msgbox("Please enter Firstname")
            txtOthernames.Focus()
            Return False
        End If
        If cmbNationality.Text = "" Then
            msgbox("Please select Nationality")
            cmbNationality.Focus()
            Return False
        End If
        If cmbCountry.Text = "" And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please select Country")
            cmbCountry.Focus()
            Return False
        End If
        If IsDate(txtDOB.Text) = False Then
            msgbox("Please select Date of Birth")
            txtDOB.Focus()
            Return False
        End If
        If rdMale.Checked = False And rdFemale.Checked = False And rdNa.Checked = False Then
            msgbox("Please select Gender")
            rdMale.Focus()
            Return False
        End If
        If (Len(txtIDNo.Text) < 1) Then
            msgbox("Please enter National ID No./Passport number")
            txtIDNo.Focus()
            Return False
        End If
        If (Len(txtAddress1.Text) < 1) And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please enter at least one line of the address")
            txtAddress1.Focus()
            Return False
        End If
        If (Len(cmbNationality.Text) < 1) Then
            msgbox("Select nationality")
            Return False
        End If
        If (txtTel.Text = "") And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please Enter Tel No.")
            txtTel.Focus()
            Return False
        End If
        If (txtEmail.Text = "") And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please Enter Email")
            txtEmail.Focus()
            Return False
        End If
        If (txtCNIC.Text = "") Then
            msgbox("Please Enter National ID No./Passport No.")
            txtCNIC.Focus()
            Return False
        End If
        If CNICExits() = True Then
            msgbox("National ID No./Passport No. already exists")
            txtCNIC.Focus()
            Return False
        End If
        If Len(txtIBAN.Text) <= 0 And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Enter bank account number")
            txtIBAN.Focus()
            Return False
        End If
        If Len(txtPayee2.Text.Trim) = 0 And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please enter Account Name")
            txtPayee2.Focus()
            Return False
        End If
        Dim BankDiv As String = ""
        If cmbBankCat.Text = "Foreign Bank" Then
            BankDiv = txtBankForeign.Text
        Else
            If (cmbBankDiv.Text.Trim <> "") Then
                BankDiv = cmbBankDiv.Value
            Else
                BankDiv = ""
            End If
        End If

        If Len(BankDiv) = 0 And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please select/Enter Bank Name")
            If cmbBankCat.Text = "Foreign Bank" Then
                txtBankForeign.Focus()
            Else
                cmbBankDiv.Focus()
            End If
            Return False
        End If
        If Len(txtBranchDiv.Text.Trim) = 0 And cmbTypeofAccount.Text <> "Unit Trust" Then
            msgbox("Please enter Branch")
            txtBranchDiv.Focus()
            Return False
        End If
        Dim BillProfile As String = ""
        If (cmbBillingProfile.Text.Trim <> "") Then
            BillProfile = cmbBillingProfile.Value
        Else
            BillProfile = ""
        End If
        Dim UnitTrustFund As String = ""
        If (cmbUnitTrustFund.Text.Trim <> "") Then
            UnitTrustFund = cmbUnitTrustFund.Value
        Else
            UnitTrustFund = ""
        End If
        If cmbTypeofAccount.Text = "Unit Trust" Then
            If Len(UnitTrustFund) = 0 Then
                msgbox("Please select Unit Trust Fund")
                cmbUnitTrustFund.Focus()
                Return False
            End If
        End If
        If cmbTypeofAccount.Text <> "Unit Trust" Then
            If grdAsertManagersClients.VisibleRowCount <= 0 Or ClientHasAssetManagers() = False Then
                msgbox("Please add asset managers")
                Return False
            End If
            If Len(BillProfile) = 0 Then
                msgbox("Please select Billing Profile")
                cmbBillingProfile.Focus()
                Return False
            End If
            If (Len(cmbBillingCurrency.Text) < 1) Then
                msgbox("Select Billing Currency")
                cmbBillingCurrency.Focus()
                Return False
            End If
        End If
        If (Len(cmbClassification.Text) < 1) Then
            msgbox("Select Classification")
            Return False
        End If
        Return True
    End Function
    Public Sub SaveNewAccount()
        Try
            If ASPxGridView1.VisibleRowCount > 0 Then
            Else
                If cmbTypeofAccount.Text <> "Unit Trust" Then
                    msgbox("Please add attachments")
                    Exit Sub
                End If
            End If
            Dim IDD As String = ""
            Dim BankDiv As String = ""
            If cmbBankCat.Text = "Foreign Bank" Then
                BankDiv = txtBankForeign.Text
            Else
                If (cmbBankDiv.Text.Trim <> "") Then
                    BankDiv = cmbBankDiv.SelectedItem.Value
                Else
                    BankDiv = ""
                End If
            End If
            Dim AccountType As String = ""
            Dim Gender As String = "N"
            If (rdMale.Checked = True) Then
                Gender = "M"
            End If
            If (rdFemale.Checked = True) Then
                Gender = "F"
            End If
            If (rdNa.Checked = True) Then
                Gender = "N"
            End If
            Dim myIDGlob As String = ""
            Dim myJointName As String = ""
            If rdAccountType.Text = "Single" Then
                AccountType = "I"
                myJointName = " "
                myIDGlob = txtIDNo.Text
            End If
            If rdAccountType.Text = "Joint" Then
                AccountType = "J"
                myJointName = txtSurname0.Text
                myIDGlob = txtCNIC.Text
            End If
            Dim myEmail As String = ""
            myEmail = txtEmail.Text
            Dim BillingProfile As String = ""
            If (cmbBillingProfile.Text.Trim <> "") Then
                BillingProfile = cmbBillingProfile.Value
            Else
                BillingProfile = ""
            End If

            Dim UnitTrustFund As String = ""
            If (cmbUnitTrustFund.Text.Trim <> "") Then
                UnitTrustFund = cmbUnitTrustFund.Value
            Else
                UnitTrustFund = ""
            End If
            If AccountNOTViewedByAuthorizer(lstNameSearch.SelectedItem.Value) = False Then
                msgbox("Authorizer has already Reviewed/Authorized the account")
                Exit Sub
            End If
            If UpdateOldAccount() = False Then
                msgbox("Authorizer has already Reviewed/Authorized the account")
                Exit Sub
            End If
            Dim BillCashAccount As Integer = 0
            If chkBillCashAccount.Checked = True Then
                BillCashAccount = 1
            Else
                BillCashAccount = 0
            End If
            cmd = New SqlCommand("insert into Accounts_Audit (BillingCurrency,BillCashAccount,Fund,BillingProfile,Account_class,cdcnumber,JointName,AgreementDate,PlaceofBirth,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,FH,marital_status,Occupations,SOI,GAI,CNIC,CNIC_expiry_date,Passport,Password_expiry_date,NTN,Permanet_Address,Permanet_Address1,Permanet_Address2,Permanet_Address3,Provinces,PostCode,Designation,Resident_Status,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC, FathersName,Tax_exemption,placeofissue, OTP, OTPSent, OTPCreateTime, OTPStatus ) values (@BillingCurrency,@BillCashAccount,@Fund,@BillingProfile,@Account_class,@cdcnumber,@JointName,@AgreementDate,@PlaceofBirth,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2, @idtype2, @mobile_money, @mobile_number,@FH,@marital_status,@Occupations,@SOI,@GAI,@CNIC,@CNIC_expiry_date,@Passport,@Password_expiry_date,@NTN,@Permanet_Address,@Permanet_Address1,@Permanet_Address2,@Permanet_Address3,@Provinces,@PostCode,@Designation,@Resident_Status,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName , @FirstWitnessCNIC , @SecondWitnessName , @SecondWitnessCNIC, @FathersName,@Tax_exemption,@placeofissue,'0','1',GETDATE(),@OTPStatus)  UPDATE Client_AssetManagers SET MarkedForDeletion=2 where MarkedForDeletion=1 and ClientNo=@CDS_Number UPDATE Client_AssetManagers SET MarkedForDeletion=4 where MarkedForDeletion=3 and ClientNo=@CDS_Number  UPDATE Accounts_Documents SET MarkedForDeletion=2 where MarkedForDeletion=1 and doc_generated=@CDS_Number  UPDATE Accounts_Documents SET MarkedForDeletion=4 where MarkedForDeletion=3 and doc_generated=@CDS_Number  UPDATE Accounts_Joint SET MarkedForDeletion=2 where MarkedForDeletion=1 and CDS_Number=@CDS_Number  UPDATE Accounts_Joint SET MarkedForDeletion=4 where MarkedForDeletion=3 and CDS_Number=@CDS_Number", cn)
            cmd.Parameters.AddWithValue("@BillingCurrency", cmbBillingCurrency.Text)
            cmd.Parameters.AddWithValue("@BillCashAccount", BillCashAccount)
            cmd.Parameters.AddWithValue("@Fund", UnitTrustFund)
            cmd.Parameters.AddWithValue("@BillingProfile", BillingProfile)
            cmd.Parameters.AddWithValue("@Account_class", cmbBankCat.Text)
            cmd.Parameters.AddWithValue("@AccountType", AccountType)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", myIDGlob)
            cmd.Parameters.AddWithValue("@JointName", myJointName)
            cmd.Parameters.AddWithValue("@Title", cmbTitle.Text)
            cmd.Parameters.AddWithValue("@CNIC", myIDGlob)
            cmd.Parameters.AddWithValue("@Forenames", txtOthernames.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@Gender", Gender)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Custodian", cmbAssetManager.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text)
            cmd.Parameters.AddWithValue("@Passport", txtpassport.Text)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@SOI", txtsourceofIncome.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtbankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@NTN", txtDateTimeStamp.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@PlaceofBirth", " ")
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Add_2", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", cmbClassification.Text)
            cmd.Parameters.AddWithValue("@Industry", cmbInvestorType.Text)
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@mobile_money", " ")
            cmd.Parameters.AddWithValue("@mobile_number", " ")
            cmd.Parameters.AddWithValue("@FH", " ")
            cmd.Parameters.AddWithValue("@marital_status", " ")
            cmd.Parameters.AddWithValue("@Occupations", " ")
            cmd.Parameters.AddWithValue("@GAI", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Permanet_Address", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address1", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address2", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address3", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@Designation", " ")
            cmd.Parameters.AddWithValue("@Resident_Status", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@FathersName", " ")
            cmd.Parameters.AddWithValue("@Tax_exemption", " ")
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumber.Text)
            cmd.Parameters.AddWithValue("@OTPStatus", "Approved")
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select TOP 1 id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Updated an account',0,'" + TXTClientID.Text + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Catch ex As Exception
            End Try

            Session("numb") = ""
            Session("finish") = "yes"
            Session("AccountNo") = TXTClientID.Text
            Session("updatemsg") = "You have successfully submitted updates for " & rdAccountType.Text & " Account, Account No. " & TXTClientID.Text & " pending authorisation"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
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

    Protected Sub ASPxButton9CORP_Click(sender As Object, e As EventArgs) Handles ASPxButton9CORP.Click
        SaveNewAccountCORP()
    End Sub
    Public Sub SaveNewAccountCORP()
        Try
            If ASPxGridView1CORP.VisibleRowCount > 0 Then
            Else
                If cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                    msgbox("Please add attachments")
                    Exit Sub
                End If
            End If
            'Validation State
            If (Len(txtSurnameCORP.Text) < 1) Then
                msgbox("Please enter Corporate Name")
                txtSurnameCORP.Focus()
                Exit Sub
            End If

            If CNICExitsCORP() = True Then
                msgbox("Registration No./Incorporation No. already exists")
                txtIDNoCORP.Focus()
                Exit Sub
            End If
            If (Len(cmbCountryCORP.Text) < 1) Then
                msgbox("Select country of Incorporation")
                cmbCountryCORP.Focus()
                Exit Sub
            End If
            If (Len(txtAddress1CORP.Text) < 1) Then
                msgbox("Please enter Office Address")
                txtAddress1CORP.Focus()
                Exit Sub
            End If
            If (Len(txtfullnameCORP.Text) < 1) Then
                msgbox("Please Enter full name")
                txtfullnameCORP.Focus()
                Exit Sub
            End If
            If (Len(txtEmailCORP.Text) < 1) Then
                msgbox("Please Enter Email")
                txtEmailCORP.Focus()
                Exit Sub
            End If
            Dim BankDivT As String = ""
            If cmbBankCatCORP.Text = "Foreign Bank" Then
                BankDivT = txtBankForeignCORP.Text
            Else
                If (cmbBankDivCORP.Text.Trim <> "") Then
                    BankDivT = cmbBankDivCORP.Value
                Else
                    BankDivT = ""
                End If
            End If

            If Len(BankDivT) = 0 And cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                msgbox("Please select/Enter Bank Name")
                If cmbBankCatCORP.Text = "Foreign Bank" Then
                    txtBankForeignCORP.Focus()
                Else
                    cmbBankDivCORP.Focus()
                End If
                Exit Sub
            End If
            If (Len(txtBranchDivCORP.Text) < 1) And cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                msgbox("Please Enter branch")
                txtBranchDivCORP.Focus()
                Exit Sub
            End If
            If (Len(txtPayee2CORP.Text) < 1) And cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                msgbox("Please enter Account Name")
                txtPayee2CORP.Focus()
                Exit Sub
            End If
            If Len(txtIBANCORP.Text) < 1 And cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                msgbox("Enter Account Number")
                txtIBANCORP.Focus()
                Exit Sub
            End If
            If txtTelCORP.Text.Trim = "" And cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                msgbox("Please enter telephone number")
                Exit Sub
            End If
            Dim BillProfile As String = ""
            If (cmbBillingProfileCORP.Text.Trim <> "") Then
                BillProfile = cmbBillingProfileCORP.Value
            Else
                BillProfile = ""
            End If
            If Len(BillProfile) = 0 Then
                msgbox("Please select Billing Profile")
                cmbBillingProfileCORP.Focus()
                Exit Sub
            End If

            Dim UnitTrustFund As String = ""
            If (cmbUnitTrustFundCORP.Text.Trim <> "") Then
                UnitTrustFund = cmbUnitTrustFundCORP.Value
            Else
                UnitTrustFund = ""
            End If
            If cmbTypeofAccountCORP.Text = "Unit Trust" Then
                If Len(UnitTrustFund) = 0 Then
                    msgbox("Please select Unit Trust Fund")
                    cmbUnitTrustFundCORP.Focus()
                    Exit Sub
                End If
            End If
            If cmbTypeofAccountCORP.Text <> "Unit Trust" Then
                If grdAsertManagersClientsCORP.VisibleRowCount <= 0 Or ClientHasAssetManagers() = False Then
                    msgbox("Please add asset managers")
                    Exit Sub
                End If
            End If
            If (Len(cmbClassificationCORP.Text) < 1) Then
                msgbox("Select Classification")
                cmbClassificationCORP.Focus()
                Exit Sub
            End If
            If (Len(cmbBillingCurrencyCORP.Text) < 1) Then
                msgbox("Select Billing Currency")
                cmbBillingCurrencyCORP.Focus()
                Exit Sub
            End If
            'End validations
            Dim BankDiv As String = ""
            If cmbBankCatCORP.Text = "Foreign Bank" Then
                BankDiv = txtBankForeignCORP.Text
            Else
                If (cmbBankDivCORP.Text.Trim <> "") Then
                    BankDiv = cmbBankDivCORP.SelectedItem.Value
                Else
                    BankDiv = ""
                End If
            End If
            If AccountNOTViewedByAuthorizer(lstNameSearch.SelectedItem.Value) = False Then
                msgbox("Authorizer has already Reviewed the account")
                Exit Sub
            End If
            If UpdateOldAccount() = False Then
                msgbox("Authorizer has already Reviewed/Authorized the account")
                Exit Sub
            End If
            Dim BillCashAccount As Integer = 0
            If chkBillCashAccountCORP.Checked = True Then
                BillCashAccount = 1
            Else
                BillCashAccount = 0
            End If
            cmd = New SqlCommand("insert into Accounts_Audit (BillingCurrency,BillCashAccount,Fund,BillingProfile,Account_class,cdcnumber,SOI,Nominee_CNIC,AgreementDate,Nominee_Address,CNIC_expiry_date,placeofissue,resident_status,Provinces,BusCommenceDate,PostCode,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, isin, company_code,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC,contactpersonname,NationalTax,SalesTaxRegistration,Passport,Password_expiry_date,CNIC,Designation,ExpectedRevenueCurrentYear,NetAssets, OTP, OTPSent, OTPCreateTime, OTPStatus) values(@BillingCurrency,@BillCashAccount,@Fund,@BillingProfile,@Account_class,@cdcnumber,@SOI,@Nominee_CNIC,@AgreementDate,@Nominee_Address,@CNIC_expiry_date,@placeofissue,@resident_status,@Provinces,@BusCommenceDate,@PostCode,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2,@idtype2, @isin, @company_code,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName,@FirstWitnessCNIC,@SecondWitnessName,@SecondWitnessCNIC,@contactpersonname,@NationalTax,@SalesTaxRegistration,@Passport,@Password_expiry_date,@CNIC,@Designation,@ExpectedRevenueCurrentYear,@NetAssets,'0','1',GETDATE(), @OTPStatus)  UPDATE Client_AssetManagers SET MarkedForDeletion=2 where MarkedForDeletion=1 and ClientNo=@CDS_Number UPDATE Client_AssetManagers SET MarkedForDeletion=4 where MarkedForDeletion=3 and ClientNo=@CDS_Number  UPDATE Accounts_Documents SET MarkedForDeletion=2 where MarkedForDeletion=1 and doc_generated=@CDS_Number  UPDATE Accounts_Documents SET MarkedForDeletion=4 where MarkedForDeletion=3 and doc_generated=@CDS_Number", cn)
            cmd.Parameters.AddWithValue("@BillingCurrency", cmbBillingCurrencyCORP.Text)
            cmd.Parameters.AddWithValue("@BillCashAccount", BillCashAccount)
            cmd.Parameters.AddWithValue("@Fund", UnitTrustFund)
            cmd.Parameters.AddWithValue("@BillingProfile", BillProfile)
            cmd.Parameters.AddWithValue("@Account_class", cmbBankCatCORP.Text)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDTypeCORP.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", txtIDNoCORP.Text)
            cmd.Parameters.AddWithValue("@CNIC", txtIDNoCORP.Text)
            cmd.Parameters.AddWithValue("@Surname", txtSurnameCORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccountCORP.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1CORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Add_2", txtAddress2CORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Country", cmbCountryCORP.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbCountryTaxResidenceCORP.Text)
            cmd.Parameters.AddWithValue("@Designation", txtNatureOfBusinessCORP.Text)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOBCORP.Text))
            cmd.Parameters.AddWithValue("@SOI", txtSourceofFundsCORP.Text)
            cmd.Parameters.AddWithValue("@Industry", cmbInvestorTypeCORP.Text)
            cmd.Parameters.AddWithValue("@contactpersonname", txtfullnameCORP.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTelCORP.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTelCORP.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFaxCORP.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmailCORP.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2CORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBANCORP.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBANCORP.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDivCORP.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtBankAddressCORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCodeCORP.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@AccountType", "C")
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@isin", " ")
            cmd.Parameters.AddWithValue("@company_code", " ")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_Address", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@resident_status", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@BusCommenceDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Forenames", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Title", " ")
            cmd.Parameters.AddWithValue("@Gender", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", cmbClassificationCORP.Text)
            cmd.Parameters.AddWithValue("@Custodian", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@NationalTax", " ")
            cmd.Parameters.AddWithValue("@SalesTaxRegistration", " ")
            cmd.Parameters.AddWithValue("@Passport", " ")
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
            cmd.Parameters.AddWithValue("@ExpectedRevenueCurrentYear", " ")
            cmd.Parameters.AddWithValue("@NetAssets", " ")
            cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumberCORP.Text)
            cmd.Parameters.AddWithValue("@OTPStatus", "Approved")
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("numb") = ""
            Session("finish") = "yes"
            Session("AccountNo") = TXTClientID.Text
            Session("updatemsg") = "You have successfully submitted updates for " & rdAccountType.Text & " Account, Account No. " & TXTClientID.Text & " pending authorisation"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Function AccountNOTViewedByAuthorizer(ByVal cdsAccount As String) As Boolean
        Dim sql_str As String = ""
        sql_str = "select a.* from Accounts_Audit a WHERE ISNULL(a.ViewedAuth,0)=0 AND ISNULL(a.AuthorizationState,'') IN ('O') AND a.Created_By=@Created_By and a.CDS_Number NOT IN (SELECT DISTINCT p.CDS_Number FROM Accounts_Clients p) and a.CDS_Number=@CDS_Number"
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conpath").ConnectionString)
            Using cmd As New SqlCommand(sql_str, con)
                cmd.Parameters.AddWithValue("@CDS_Number", cdsAccount)
                cmd.Parameters.AddWithValue("@Created_By", Session("Username"))
                Dim dss As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(dss, "Accounts_Audit")
                If dss.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function
    Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp), DBNull.Value, inp)
    End Function
    Sub getJointHolders()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID,Surname,IDNoPP,Add_1,Mobile,Email,nomineerelation,CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 'Marked for Deletion' WHEN ISNULL(MarkedForDeletion,0)=3 THEN 'New' else '' end as UpdateStatus from Accounts_Joint where  cds_number=@cds_number", cn)
        cmd.Parameters.AddWithValue("@cds_number", TXTClientID.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsid2
            grdJointAccounts.DataBind()
        Else
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
        End If
    End Sub
    Protected Sub ASPxGridView1_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("Update Accounts_Documents set MarkedForDeletion=CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 0 ELSE 1 END WHERE ID=@RecID AND ISNULL(MarkedForDeletion,0) NOT IN (3,4) DELETE FROM Accounts_Documents WHERE ID=@RecID AND ISNULL(MarkedForDeletion,0) IN (3,4)", cn)
                        cmd.Parameters.AddWithValue("@RecID", myID)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getuploaded()
                        msgbox("Record successfully Marked/UnMarked for deletion")
                    End Using
                End Using
            ElseIf e.CommandArgs.CommandName = "View Document" Then
                Try
                    pd(myID)
                Catch ex As Exception
                End Try
                Try
                    word(myID)
                Catch ex As Exception
                End Try
                Try
                    xls(myID)
                Catch ex As Exception
                End Try
                Try
                    Img(myID)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ASPxGridView1CORP_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles ASPxGridView1CORP.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("Update Accounts_Documents set MarkedForDeletion=CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 0 ELSE 1 END WHERE ID=@RecID AND ISNULL(MarkedForDeletion,0) NOT IN (3,4) DELETE FROM Accounts_Documents WHERE ID=@RecID AND ISNULL(MarkedForDeletion,0) IN (3,4)", cn)
                        cmd.Parameters.AddWithValue("@RecID", myID)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getuploadedCORP()
                        msgbox("Record successfully Marked/UnMarked for deletion")
                    End Using
                End Using
            ElseIf e.CommandArgs.CommandName = "View Document" Then
                Try
                    pd(myID)
                Catch ex As Exception
                End Try
                Try
                    word(myID)
                Catch ex As Exception
                End Try
                Try
                    xls(myID)
                Catch ex As Exception
                End Try
                Try
                    Img(myID)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearAllFields()
        lblRecordID.Text = ""
        TXTClientID.Text = ""
        rdAccountType.Text = ""
        cmbIDType.SelectedIndex = -1
        txtIDNo.Text = ""
        txtSurname0.Text = ""
        cmbTitle.SelectedIndex = -1
        txtCNIC.Text = ""
        txtOthernames.Text = ""
        txtSurname.Text = ""
        txtDOB.Text = ""
        rdMale.Checked = False
        rdFemale.Checked = False
        rdNa.Checked = False
        cmbTypeofAccount.SelectedIndex = -1
        cmbAssetManager.SelectedIndex = -1
        cmbNationality.SelectedIndex = -1
        txtpassport.Text = ""
        cmbCountry.SelectedIndex = -1
        txtsourceofIncome.Text = ""
        txtAddress1.Text = ""
        txtTel.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtPayee2.Text = ""
        txtIBAN.Text = ""
        cmbBankDiv.SelectedIndex = -1
        txtBranchDiv.Text = ""
        txtSwiftCode.Text = ""
        txtbankAddress.Text = ""
        txtDateTimeStamp.Text = ""
        ASPxGridView1.DataSource = Nothing
        ASPxGridView1.DataBind()
        grdJointAccounts.DataSource = Nothing
        grdJointAccounts.DataBind()
        txtdocumentname.SelectedIndex = -1
        cmbBillingProfile.SelectedIndex = -1
        cmbBillingCurrency.SelectedIndex = -1
        chkBillCashAccount.Checked = False
        cmbUnitTrustFund.SelectedIndex = -1
        'corp
        cmbIDTypeCORP.SelectedIndex = -1
        txtIDNoCORP.Text = ""
        txtSurnameCORP.Text = ""
        cmbTypeofAccountCORP.SelectedIndex = -1
        txtAddress1CORP.Text = ""
        txtAddress2CORP.Text = ""
        cmbCountryCORP.SelectedIndex = -1
        cmbCountryTaxResidenceCORP.SelectedIndex = -1
        txtNatureOfBusinessCORP.Text = ""
        txtDOBCORP.Text = ""
        txtSourceofFundsCORP.Text = ""
        cmbInvestorTypeCORP.SelectedIndex = -1
        txtfullnameCORP.Text = ""
        txtTelCORP.Text = ""
        txtFaxCORP.Text = ""
        txtEmailCORP.Text = ""
        txtPayee2CORP.Text = ""
        txtIBANCORP.Text = ""
        cmbBankDivCORP.SelectedIndex = -1
        txtBranchDivCORP.Text = ""
        txtBankAddressCORP.Text = ""
        txtSwiftCodeCORP.Text = ""
        txtdocumentnameCORP.SelectedIndex = -1
        ASPxGridView1CORP.DataSource = Nothing
        ASPxGridView1CORP.DataBind()
        txtcdcnumberCORP.Text = ""
        txtcdcnumber.Text = ""
        cmbBillingProfileCORP.SelectedIndex = -1
        cmbBillingCurrencyCORP.SelectedIndex = -1
        chkBillCashAccountCORP.Checked = False
        cmbUnitTrustFundCORP.SelectedIndex = -1
        grdAsertManagersClients.DataSource = Nothing
        grdAsertManagersClients.DataBind()
        grdAsertManagersClientsCORP.DataSource = Nothing
        grdAsertManagersClientsCORP.DataBind()
        grdSelectFromAssetmanagers.DataSource = Nothing
        grdSelectFromAssetmanagers.DataBind()
        grdSelectFromAssetmanagersCORP.DataSource = Nothing
        grdSelectFromAssetmanagersCORP.DataBind()
    End Sub
    Protected Sub txtdocumentname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdocumentname.SelectedIndexChanged
        If txtdocumentname.SelectedItem.Text = "Other" Then
            txtotherdoc.Visible = True
        Else
            txtotherdoc.Visible = False
        End If
    End Sub
    Protected Sub txtdocumentnameCORP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtdocumentnameCORP.SelectedIndexChanged
        If txtdocumentnameCORP.SelectedItem.Text = "Other" Then
            txtotherdocCORP.Visible = True
        Else
            txtotherdocCORP.Visible = False
        End If
    End Sub
    Private Function CNICExits() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select IDNoPP from Accounts_Audit where REPLACE(IDNoPP,'-','')= REPLACE(@idnopp,'-','') and CDS_Number<>@CDS_Number AND BankAccount_Type=@BankAccount_Type union Select IDNoPP from Accounts_Clients where REPLACE(IDNoPP,'-','')= REPLACE(@idnopp,'-','') and CDS_Number<>@CDS_Number AND BankAccount_Type=@BankAccount_Type ", cn)
        cmd.Parameters.AddWithValue("@idnopp", txtCNIC.Text)
        cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
        cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function CNICExitsCORP() As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select IDNoPP from Accounts_Audit where REPLACE(IDNoPP,'-','')= REPLACE(@idnopp,'-','') and CDS_Number<>@CDS_Number AND BankAccount_Type=@BankAccount_Type union Select IDNoPP from Accounts_Clients where REPLACE(IDNoPP,'-','')= REPLACE(@idnopp,'-','') and CDS_Number<>@CDS_Number AND BankAccount_Type=@BankAccount_Type", cn)
        cmd.Parameters.AddWithValue("@idnopp", txtIDNoCORP.Text)
        cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
        cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccountCORP.Text)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub pd(ByVal IDD As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + IDD + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(ByVal IDD As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + IDD + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(ByVal IDD As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + IDD + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(ByVal IDD As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + IDD + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Protected Sub download(ByVal dt As DataTable)
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = apptype(dt.Rows(0)("ContentType").ToString()) ' dt.Rows(0)("ContentType").ToString()
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("Name").ToString() + "" + dt.Rows(0)("ContentType").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub
    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            con.Close()
            sda.Dispose()
            con.Dispose()
        End Try
    End Function
    Public Function apptype(type As String) As String
        If type = ".png" Then
            Return "Aplication/vnd.png"
        ElseIf type = ".doc" Or type = ".docx" Then
            Return "Aplication/vnd.ms-word"
        ElseIf type = ".xlsx" Or type = ".xls" Then
            Return "Aplication/vnd.ms-excel"
        ElseIf type = ".jpg" Or type = ".jpeg" Then
            Return "Aplication/vnd.jpg"
        ElseIf type = ".gif" Then
            Return "Aplication/vnd.gif"
        End If
    End Function
    Sub getAssetmanagersClients()
        Dim strSQL As String = ""
        strSQL = "SELECT *,CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 'Marked for Deletion' WHEN ISNULL(MarkedForDeletion,0)=3 then 'New' else '' end as UpdateStatus,(SELECT TOP 1 H.AccountName+' - '+H.AccountNumber FROM Para_InterCompanyAccounts H WHERE H.AccountNumber=Client_AssetManagers.InterCompanyAccount) AS DispInterAccNumber FROM Client_AssetManagers WHERE ClientNo='" & TXTClientID.Text & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_AssetManagers")
            If ds.Tables(0).Rows.Count > 0 Then
                grdAsertManagersClients.DataSource = ds
                grdAsertManagersClients.DataBind()
            Else
                grdAsertManagersClients.DataSource = Nothing
                grdAsertManagersClients.DataBind()
            End If
        End Using
    End Sub
    Protected Sub btnAddAMs_Click(sender As Object, e As EventArgs) Handles btnAddAMs.Click
        Try
            If CDCNumberAlreadyExists(txtIDNo.Text, txtcdcnumber.Text) = True And Session("dupli") <> "yes" Then
                showPopUp()
                Exit Sub
            Else
                commitAM()
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Sub commitAM()
        Dim numTicked As Long = multipleTicked()
        If numTicked <= 0 Then
            msgbox("Select Account")
            Exit Sub
        End If
        If numTicked > 1 Then
            msgbox("Select only 1 Account")
            Exit Sub
        End If
        If cmbInterCompanyAccount.Text = "" Then
            msgbox("Select InterCompany Account")
            Exit Sub
        End If
        For Each row As RepeaterItem In grdSelectFromAssetmanagers.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim BankCode As String = CType(row.FindControl("lblBank"), Label).Text
            Dim BranchCode As String = CType(row.FindControl("lblBranch"), Label).Text
            Dim AccountNumber As String = CType(row.FindControl("lblAccountNumber"), Label).Text
            Dim BankName As String = CType(row.FindControl("lblAccountName"), Label).Text
            Dim Currency As String = CType(row.FindControl("lblCurrency"), Label).Text
            Dim AssetManagerCode As String = CType(row.FindControl("lblAssetManagerCode"), Label).Text
            If chkView.Checked = True Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("IF NOT EXISTS(SELECT TOP 1 * FROM Client_AssetManagers H WHERE H.ClientNo=@ClientNo AND H.AssetManager=@AssetManager AND H.BankAccount=@BankAccount) BEGIN INSERT INTO Client_AssetManagers([ClientNo],[IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy], [cdcnumber], [AccountName],[Currency],[MarkedForDeletion],[InterCompanyAccount])VALUES(@ClientNo,@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy,@cdcnumber, @AccountName,@Currency,3,@InterCompanyAccount) INSERT INTO Client_AssetManagersAudit([ClientNo],[IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy],[cdcnumber], [AccountName],[Currency],[InterCompanyAccount])VALUES(@ClientNo,@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy, @cdcnumber,@AccountName,@Currency,@InterCompanyAccount) END", cn)
                        cmd.Parameters.AddWithValue("@ClientNo", TXTClientID.Text)
                        cmd.Parameters.AddWithValue("@IDNo", txtIDNo.Text)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManagerCode)
                        cmd.Parameters.AddWithValue("@BankAccount", AccountNumber)
                        cmd.Parameters.AddWithValue("@BankName", BankCode)
                        cmd.Parameters.AddWithValue("@BankBranch", BranchCode)
                        cmd.Parameters.AddWithValue("@LinkedBy", Session("Username"))
                        cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumber.Text)
                        cmd.Parameters.AddWithValue("@AccountName", BankName)
                        cmd.Parameters.AddWithValue("@Currency", Currency)
                        cmd.Parameters.AddWithValue("@InterCompanyAccount", cmbInterCompanyAccount.Value)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getAssetmanagersClients()
    End Sub
    Protected Sub grdAsertManagersClients_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdAsertManagersClients.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("Update Client_AssetManagers set MarkedForDeletion=CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 0 ELSE 1 END WHERE ID='" & myID & "' AND ISNULL(MarkedForDeletion,0) NOT IN (3,4) DELETE FROM Client_AssetManagers WHERE ID='" & myID & "' AND ISNULL(MarkedForDeletion,0) IN (3,4)", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getAssetmanagersClients()
                        msgbox("Record successfully Marked/UnMarked for deletion")
                    End Using
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbAssetManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManager.SelectedIndexChanged
        getAssetmanagersBanks()
    End Sub
    Sub getAssetmanagersBanks()
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM para_assetManager_Banks WHERE AssetManagerCode='" & cmbAssetManager.Value & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager_Banks")
            If ds.Tables(0).Rows.Count > 0 Then
                grdSelectFromAssetmanagers.DataSource = ds
                grdSelectFromAssetmanagers.DataBind()
                dfPanel2.Visible = True
            Else
                grdSelectFromAssetmanagers.DataSource = Nothing
                grdSelectFromAssetmanagers.DataBind()
                dfPanel2.Visible = False
            End If
        End Using
    End Sub
    'CORP ASSET MANAGERS
    Sub getAssetmanagersClientsCORP()
        Dim strSQL As String = ""
        strSQL = "SELECT *,CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 'Marked for Deletion' WHEN ISNULL(MarkedForDeletion,0)=3 then 'New' else '' end as UpdateStatus,(SELECT TOP 1 H.AccountName+' - '+H.AccountNumber FROM Para_InterCompanyAccounts H WHERE H.AccountNumber=Client_AssetManagers.InterCompanyAccount) AS DispInterAccNumber FROM Client_AssetManagers WHERE ClientNo='" & TXTClientID.Text & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_AssetManagers")
            If ds.Tables(0).Rows.Count > 0 Then
                grdAsertManagersClientsCORP.DataSource = ds
                grdAsertManagersClientsCORP.DataBind()
            Else
                grdAsertManagersClientsCORP.DataSource = Nothing
                grdAsertManagersClientsCORP.DataBind()
            End If
        End Using
    End Sub
    Protected Sub btnAddAMsCORP_Click(sender As Object, e As EventArgs) Handles btnAddAMsCORP.Click
        Try
            If CDCNumberAlreadyExists(txtIDNoCORP.Text, txtcdcnumberCORP.Text) = True And Session("dupli") <> "yes" Then
                showPopUpCORP()
                Exit Sub
            Else
                commitAMCORP()
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Sub commitAMCORP()
        Dim numTicked As Long = multipleTickedCORP()
        If numTicked <= 0 Then
            msgbox("Select Account")
            Exit Sub
        End If
        If numTicked > 1 Then
            msgbox("Select only 1 Account")
            Exit Sub
        End If
        If cmbInterCompanyAccountCORP.Text = "" Then
            msgbox("Select InterCompany Account")
            Exit Sub
        End If
        For Each row As RepeaterItem In grdSelectFromAssetmanagersCORP.Items
            Dim chkView As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
            Dim BankCode As String = CType(row.FindControl("lblBank"), Label).Text
            Dim BranchCode As String = CType(row.FindControl("lblBranch"), Label).Text
            Dim AccountNumber As String = CType(row.FindControl("lblAccountNumber"), Label).Text
            Dim BankName As String = CType(row.FindControl("lblAccountName"), Label).Text
            Dim Currency As String = CType(row.FindControl("lblCurrency"), Label).Text
            Dim AssetManagerCode As String = CType(row.FindControl("lblAssetManagerCode"), Label).Text
            If chkView.Checked = True Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("IF NOT EXISTS(SELECT TOP 1 * FROM Client_AssetManagers H WHERE H.ClientNo=@ClientNo AND H.AssetManager=@AssetManager AND H.BankAccount=@BankAccount) BEGIN INSERT INTO Client_AssetManagers([ClientNo],[IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy], [cdcnumber], [AccountName],[Currency],[MarkedForDeletion],[InterCompanyAccount])VALUES(@ClientNo,@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy,@cdcnumber, @AccountName,@Currency,3,@InterCompanyAccount) INSERT INTO Client_AssetManagersAudit([ClientNo],[IDNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy],[cdcnumber], [AccountName],[Currency],[InterCompanyAccount])VALUES(@ClientNo,@IDNo, @AssetManager,@BankAccount,@BankName,@BankBranch,getdate(),@LinkedBy, @cdcnumber,@AccountName,@Currency,@InterCompanyAccount) END", cn)
                        cmd.Parameters.AddWithValue("@ClientNo", TXTClientID.Text)
                        cmd.Parameters.AddWithValue("@IDNo", txtIDNoCORP.Text)
                        cmd.Parameters.AddWithValue("@AssetManager", AssetManagerCode)
                        cmd.Parameters.AddWithValue("@BankAccount", AccountNumber)
                        cmd.Parameters.AddWithValue("@BankName", BankCode)
                        cmd.Parameters.AddWithValue("@BankBranch", BranchCode)
                        cmd.Parameters.AddWithValue("@LinkedBy", Session("Username"))
                        cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumberCORP.Text)
                        cmd.Parameters.AddWithValue("@AccountName", BankName)
                        cmd.Parameters.AddWithValue("@Currency", Currency)
                        cmd.Parameters.AddWithValue("@InterCompanyAccount", cmbInterCompanyAccountCORP.Value)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    End Using
                End Using
            End If
        Next
        getAssetmanagersClientsCORP()
    End Sub
    Protected Sub grdAsertManagersClientsCORP_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdAsertManagersClientsCORP.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("Update Client_AssetManagers set MarkedForDeletion=CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 0 ELSE 1 END WHERE ID='" & myID & "' AND ISNULL(MarkedForDeletion,0) NOT IN (3,4) DELETE FROM Client_AssetManagers WHERE ID='" & myID & "' AND ISNULL(MarkedForDeletion,0) IN (3,4)", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getAssetmanagersClientsCORP()
                        msgbox("Record successfully Marked/UnMarked for deletion")
                    End Using
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbAssetManagerCORP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssetManagerCORP.SelectedIndexChanged
        getAssetmanagersBanksCORP()
    End Sub
    Sub getAssetmanagersBanksCORP()
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM para_assetManager_Banks WHERE AssetManagerCode='" & cmbAssetManagerCORP.Value & "'"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_assetManager_Banks")
            If ds.Tables(0).Rows.Count > 0 Then
                grdSelectFromAssetmanagersCORP.DataSource = ds
                grdSelectFromAssetmanagersCORP.DataBind()
                dfPanel2CORP.Visible = True
            Else
                grdSelectFromAssetmanagersCORP.DataSource = Nothing
                grdSelectFromAssetmanagersCORP.DataBind()
                dfPanel2CORP.Visible = False
            End If
        End Using
    End Sub
    'CORP ASSET MANAGERS
    Private Function CDCNumberAlreadyExists(ByVal myIDNo As String, ByVal mycdc As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("Select * from Client_AssetManagers where cdcnumber=@cdcnumber AND IDNo<>@IDNo", cn)
        cmd.Parameters.AddWithValue("@cdcnumber", mycdc)
        cmd.Parameters.AddWithValue("@IDNo", myIDNo)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Client_AssetManagers")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub cmbBankCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankCat.SelectedIndexChanged
        If cmbBankCat.Text = "Foreign Bank" Then
            txtBankForeign.Visible = True
            cmbBankDiv.Visible = False
        Else
            cmbBankDiv.Visible = True
            txtBankForeign.Visible = False
        End If
    End Sub
    Protected Sub cmbBankCatCORP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankCatCORP.SelectedIndexChanged
        If cmbBankCatCORP.Text = "Foreign Bank" Then
            txtBankForeignCORP.Visible = True
            cmbBankDivCORP.Visible = False
        Else
            cmbBankDivCORP.Visible = True
            txtBankForeignCORP.Visible = False
        End If
    End Sub
    Private Function multipleTicked() As Long
        Dim numTicked As Long = 0
        For Each row As RepeaterItem In grdSelectFromAssetmanagers.Items
            If DirectCast(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                numTicked += 1
            Else
                numTicked += 0
            End If
        Next
        Return numTicked
    End Function
    Private Function multipleTickedCORP() As Long
        Dim numTicked As Long = 0
        For Each row As RepeaterItem In grdSelectFromAssetmanagersCORP.Items
            If DirectCast(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                numTicked += 1
            Else
                numTicked += 0
            End If
        Next
        Return numTicked
    End Function
    Sub showPopUp()
        ASPxPopupControl2x.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl2x.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl2x.AllowDragging = True
        ASPxPopupControl2x.ShowCloseButton = True
        ASPxPopupControl2x.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = False
    End Sub
    Protected Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Session("dupli") = "Yes"
        hidePopUP()
        commitAM()
    End Sub
    Protected Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Session("dupli") = "No"
        hidePopUP()
    End Sub
    Sub hidePopUP()
        ASPxPopupControl2x.AllowDragging = False
        ASPxPopupControl2x.ShowCloseButton = False
        ASPxPopupControl2x.ShowOnPageLoad = False
    End Sub

    Sub showPopUpCORP()
        ASPxPopupControl2CORPX.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl2CORPX.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter
        ASPxPopupControl2CORPX.AllowDragging = True
        ASPxPopupControl2CORPX.ShowCloseButton = True
        ASPxPopupControl2CORPX.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = False
    End Sub
    Protected Sub btnYesCORP_Click(sender As Object, e As EventArgs) Handles btnYesCORP.Click
        Session("dupli") = "Yes"
        hidePopUPCORP()
        commitAMCORP()
    End Sub
    Protected Sub btnNoCORP_Click(sender As Object, e As EventArgs) Handles btnNoCORP.Click
        Session("dupli") = "No"
        hidePopUPCORP()
    End Sub
    Sub hidePopUPCORP()
        ASPxPopupControl2CORPX.AllowDragging = False
        ASPxPopupControl2CORPX.ShowCloseButton = False
        ASPxPopupControl2CORPX.ShowOnPageLoad = False
    End Sub
    Protected Sub cmbTypeofAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeofAccount.SelectedIndexChanged
        If cmbTypeofAccount.Text = "Unit Trust" Then
            showHideUnitTrust("Show")
        Else
            showHideUnitTrust("Hide")
        End If
    End Sub
    Sub showHideUnitTrust(ByVal showHide As String)
        If showHide = "Show" Then
            Panel8kb.Visible = True
            Panel8kbb.Visible = True
            Panel3bb.Visible = False
            Panel3bbb.Visible = False
            Panel3bbbb1.Visible = False
            Panel3bbbb2.Visible = False
            Panel3bbbb.Visible = False
            showHideMandatoryFields("Hide")
            Panel8kc.Visible = False
        Else
            Panel8kb.Visible = False
            Panel8kbb.Visible = False
            Panel3bb.Visible = True
            Panel3bbb.Visible = True
            Panel3bbbb1.Visible = True
            Panel3bbbb2.Visible = True
            Panel3bbbb.Visible = True
            showHideMandatoryFields("Show")
            Panel8kc.Visible = True
        End If
    End Sub
    Protected Sub cmbTypeofAccountCORP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeofAccountCORP.SelectedIndexChanged
        If cmbTypeofAccountCORP.Text = "Unit Trust" Then
            showHideUnitTrustCORP("Show")
        Else
            showHideUnitTrustCORP("Hide")
        End If
    End Sub
    Sub showHideUnitTrustCORP(ByVal showHide As String)
        If showHide = "Show" Then
            CORP8a.Visible = True
            CORP8ab.Visible = True
            CORP8b.Visible = False
            CORP8c.Visible = False
            CORP8D.Visible = False
            CORP8Dz.Visible = False
            CORP8Dx.Visible = False
            showHideMandatoryFieldsCORP("Hide")
            CORP3a.Visible = False
        Else
            CORP8a.Visible = False
            CORP8ab.Visible = False
            CORP8b.Visible = True
            CORP8c.Visible = True
            CORP8D.Visible = True
            CORP8Dz.Visible = True
            CORP8Dx.Visible = True
            showHideMandatoryFieldsCORP("Show")
            CORP3a.Visible = True
        End If
    End Sub
    Sub showHideMandatoryFields(ByVal showHide As String)
        If showHide = "Show" Then
            'bank
            b_ASPxLabel37.Visible = True
            b_ASPxLabel40.Visible = True
            b_ASPxLabel38.Visible = True
            b_ASPxLabel39.Visible = True
            'attachments
            ASPxLabel9.Visible = True
            'contact/address
            ASPxLabel22.Visible = True
            ASPxLabel58.Visible = True
            req_Pwd2.Enabled = True
            ASPxLabel78.Visible = True
            txtEmail.ValidationSettings.RequiredField.IsRequired = True
        Else
            'bank
            b_ASPxLabel37.Visible = False
            b_ASPxLabel40.Visible = False
            b_ASPxLabel38.Visible = False
            b_ASPxLabel39.Visible = False
            'attachments
            ASPxLabel9.Visible = False
            'contact/address
            ASPxLabel22.Visible = False
            ASPxLabel58.Visible = False
            req_Pwd2.Enabled = False
            ASPxLabel78.Visible = False
            txtEmail.ValidationSettings.RequiredField.IsRequired = False
        End If
    End Sub
    Sub showHideMandatoryFieldsCORP(ByVal showHide As String)
        If showHide = "Show" Then
            'bank
            ASPxLabel91.Visible = True
            ASPxLabel80.Visible = True
            ASPxLabel92.Visible = True
            ASPxLabel88.Visible = True
            'attachments
            ASPxLabel90.Visible = True
            'contact/address
            ASPxLabel60.Visible = True
            RequiredFieldValidator3.Enabled = True
            ASPxLabel78.Visible = True
            txtEmailCORP.ValidationSettings.RequiredField.IsRequired = True
        Else
            'bank
            ASPxLabel91.Visible = False
            ASPxLabel36.Visible = False
            ASPxLabel92.Visible = False
            ASPxLabel88.Visible = False
            'attachments
            ASPxLabel90.Visible = False
            'contact/address
            ASPxLabel60.Visible = False
            RequiredFieldValidator3.Enabled = False
            ASPxLabel78.Visible = False
            txtEmailCORP.ValidationSettings.RequiredField.IsRequired = False
        End If
    End Sub
    Private Function ClientHasAssetManagers() As Boolean
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM Client_AssetManagers WHERE ClientNo='" & TXTClientID.Text & "' and ISNULL(MarkedForDeletion,0)<>1"
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand(strSQL, cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Client_AssetManagers")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        If validateJOINTFields() = False Then
            Exit Sub
        Else
            SaveNewAccountJOINT()
        End If
    End Sub
    Public Function validateJOINTFields() As Boolean
        If (Len(txtnexofkeenName.Text.Trim) < 1) Then
            msgbox("Please enter a Fullname")
            txtnexofkeenName.Focus()
            Return False
        End If
        If (Len(txtrelation.Text.Trim) < 1) Then
            msgbox("Please enter Relation")
            txtrelation.Focus()
            Return False
        End If
        If txtnexofkeenAddress.Text = "" Then
            msgbox("Please enter mailing address")
            txtnexofkeenAddress.Focus()
            Return False
        End If
        If txtnextofKeenMobile.Text = "" Then
            msgbox("Please enter mobile")
            txtnextofKeenMobile.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub SaveNewAccountJOINT()
        Try
            Dim joinaccs As String = " insert into Accounts_Joint (CDS_Number,JointName,BrokerCode,Surname,nomineerelation,Add_1,Tel,Mobile,Email,IDNoPP,Passport,Update_Type,Created_By,AuthorizationState,CNIC,Date_Created,MarkedForDeletion) values (@CDS_Number,@JointName,@BrokerCode,@Surname,@nomineerelation,@Add_1,@Tel,@Mobile,@Email,@IDNoPP,@Passport,@Update_Type,@Created_By,@AuthorizationState,@CNIC,getdate(),3) "
            cmd = New SqlCommand(" insert into Accounts_Joint_Audit (CDS_Number,JointName,BrokerCode,Surname,nomineerelation,Add_1,Tel,Mobile,Email,IDNoPP,Passport,Update_Type,Created_By,AuthorizationState,CNIC,Date_Created) values (@CDS_Number,@JointName,@BrokerCode,@Surname,@nomineerelation,@Add_1,@Tel,@Mobile,@Email,@IDNoPP,@Passport,@Update_Type,@Created_By,@AuthorizationState,@CNIC,getdate()) " & joinaccs, cn)
            cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Surname", txtnexofkeenName.Text.ToString.ToUpper)
            cmd.Parameters.AddWithValue("@nomineerelation", txtrelation.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtnexofkeenAddress.Text)
            cmd.Parameters.AddWithValue("@Tel", txtnextofKeenMobile.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtnextofKeenMobile.Text)
            cmd.Parameters.AddWithValue("@Email", txtnomineemail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@IDNoPP", txtnomineepass.Text)
            cmd.Parameters.AddWithValue("@Passport", txtnomineepass.Text)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@CNIC", txtnomineepass.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            txtnexofkeenName.Text = ""
            txtrelation.Text = ""
            txtnexofkeenAddress.Text = ""
            txtnextofKeenMobile.Text = ""
            txtnomineemail.Text = ""
            txtnomineepass.Text = ""
            getJointHolders()
            msgbox("Joint Member Successfully Added")
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Protected Sub grdJointAccounts_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs) Handles grdJointAccounts.RowCommand
        Try
            Dim myID As String = e.CommandArgs.CommandArgument.ToString
            If e.CommandArgs.CommandName = "Delete" Then
                Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                    Using cmd As New SqlCommand("Update Accounts_Joint set MarkedForDeletion=CASE WHEN ISNULL(MarkedForDeletion,0)=1 THEN 0 ELSE 1 END WHERE ID='" & myID & "' AND ISNULL(MarkedForDeletion,0) NOT IN (3,4) DELETE FROM Accounts_Joint WHERE ID='" & myID & "' AND ISNULL(MarkedForDeletion,0) IN (3,4)", cn)
                        If cn.State = ConnectionState.Open Then cn.Close()
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                        getJointHolders()
                        msgbox("Record successfully Marked/UnMarked for deletion")
                    End Using
                End Using
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            cmd = New SqlCommand("delete Accounts_Print where Created_By=@Created_By AND CDS_Number=@CDS_Number", cn)
            cmd.Parameters.AddWithValue("@Created_By", Session("Username"))
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim BankDiv As String = ""
            If cmbBankCat.Text = "Foreign Bank" Then
                BankDiv = txtBankForeign.Text
            Else
                If (cmbBankDiv.Text.Trim <> "") Then
                    BankDiv = cmbBankDiv.Value
                Else
                    BankDiv = ""
                End If
            End If
            Dim BillingProfile As String = ""
            If (cmbBillingProfile.Text.Trim <> "") Then
                BillingProfile = cmbBillingProfile.Value
            Else
                BillingProfile = ""
            End If
            Dim UnitTrustFund As String = ""
            If (cmbUnitTrustFund.Text.Trim <> "") Then
                UnitTrustFund = cmbUnitTrustFund.Value
            Else
                UnitTrustFund = ""
            End If
            Dim AccountType As String = ""
            Dim Gender As String = "N"
            If (rdMale.Checked = True) Then
                Gender = "M"
            End If
            If (rdFemale.Checked = True) Then
                Gender = "F"
            End If
            If (rdNa.Checked = True) Then
                Gender = "N"
            End If
            Dim myIDGlob As String = ""
            Dim myJointName As String = ""
            If rdAccountType.Text = "Single" Then
                AccountType = "I"
                myJointName = " "
                myIDGlob = txtIDNo.Text
            End If
            If rdAccountType.Text = "Joint" Then
                AccountType = "J"
                myJointName = txtSurname0.Text
                myIDGlob = txtCNIC.Text
            End If
            Dim BillCashAccount As Integer = 0
            If chkBillCashAccount.Checked = True Then
                BillCashAccount = 1
            Else
                BillCashAccount = 0
            End If
            cmd = New SqlCommand("insert into Accounts_Print (BillingCurrency,BillCashAccount,Fund,BillingProfile,Account_class,JointName,AgreementDate,PlaceofBirth,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,FH,marital_status,Occupations,SOI,GAI,CNIC,CNIC_expiry_date,Passport,Password_expiry_date,NTN,Permanet_Address,Permanet_Address1,Permanet_Address2,Permanet_Address3,Provinces,PostCode,Designation,Resident_Status,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC, FathersName,Tax_exemption,placeofissue, cdcnumber ) values (@BillingCurrency,@BillCashAccount,@Fund,@BillingProfile,@Account_class,@JointName,@AgreementDate,@PlaceofBirth,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2, @idtype2, @mobile_money, @mobile_number,@FH,@marital_status,@Occupations,@SOI,@GAI,@CNIC,@CNIC_expiry_date,@Passport,@Password_expiry_date,@NTN,@Permanet_Address,@Permanet_Address1,@Permanet_Address2,@Permanet_Address3,@Provinces,@PostCode,@Designation,@Resident_Status,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName , @FirstWitnessCNIC , @SecondWitnessName , @SecondWitnessCNIC, @FathersName,@Tax_exemption,@placeofissue,@cdcnumber) SET @increamentID=SCOPE_IDENTITY()", cn)
            cmd.Parameters.AddWithValue("@BillingCurrency", cmbBillingCurrency.Text)
            cmd.Parameters.AddWithValue("@BillCashAccount", BillCashAccount)
            cmd.Parameters.AddWithValue("@Fund", UnitTrustFund)
            cmd.Parameters.AddWithValue("@BillingProfile", BillingProfile)
            cmd.Parameters.AddWithValue("@Account_class", cmbBankCat.Text)
            cmd.Parameters.AddWithValue("@AccountType", AccountType)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", myIDGlob)
            cmd.Parameters.AddWithValue("@JointName", myJointName)
            cmd.Parameters.AddWithValue("@Title", cmbTitle.Text)
            cmd.Parameters.AddWithValue("@CNIC", myIDGlob)
            cmd.Parameters.AddWithValue("@Forenames", txtOthernames.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOB.Text))
            cmd.Parameters.AddWithValue("@Gender", Gender)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccount.Text)
            cmd.Parameters.AddWithValue("@Custodian", cmbAssetManager.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text)
            cmd.Parameters.AddWithValue("@Passport", txtpassport.Text)
            cmd.Parameters.AddWithValue("@Country", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@SOI", txtsourceofIncome.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTel.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFax.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDiv.Text)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCode.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtbankAddress.Text.ToUpper)
            cmd.Parameters.AddWithValue("@NTN", txtDateTimeStamp.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@PlaceofBirth", " ")
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Add_2", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", cmbClassification.Text)
            cmd.Parameters.AddWithValue("@Industry", cmbInvestorType.Text)
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@mobile_money", " ")
            cmd.Parameters.AddWithValue("@mobile_number", " ")
            cmd.Parameters.AddWithValue("@FH", " ")
            cmd.Parameters.AddWithValue("@marital_status", " ")
            cmd.Parameters.AddWithValue("@Occupations", " ")
            cmd.Parameters.AddWithValue("@GAI", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Permanet_Address", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address1", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address2", " ")
            cmd.Parameters.AddWithValue("@Permanet_Address3", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@Designation", " ")
            cmd.Parameters.AddWithValue("@Resident_Status", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@FathersName", " ")
            cmd.Parameters.AddWithValue("@Tax_exemption", " ")
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumber.Text)
            cmd.Parameters.Add("@increamentID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim outputString = cmd.Parameters("@increamentID").Value.ToString()
            Dim queryString As String = ""
            If rdAccountType.Text = "Single" Then
                queryString = "AccountPrintReportE.aspx?Username=" & Session("Username") & "&AccType=I&IDD=" & outputString & ""
            ElseIf rdAccountType.Text = "Joint" Then
                queryString = "AccountPrintReportE.aspx?Username=" & Session("Username") & "&AccType=J&IDD=" & outputString & ""
            End If
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Protected Sub btnPrintCORP_Click(sender As Object, e As EventArgs) Handles btnPrintCORP.Click
        Try
            cmd = New SqlCommand("delete Accounts_Print where Created_By=@Created_By AND CDS_Number=@CDS_Number", cn)
            cmd.Parameters.AddWithValue("@Created_By", Session("Username"))
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim BankDivT As String = ""
            If cmbBankCatCORP.Text = "Foreign Bank" Then
                BankDivT = txtBankForeignCORP.Text
            Else
                If (cmbBankDivCORP.Text.Trim <> "") Then
                    BankDivT = cmbBankDivCORP.Value
                Else
                    BankDivT = ""
                End If
            End If

            Dim BillProfile As String = ""
            If (cmbBillingProfileCORP.Text.Trim <> "") Then
                BillProfile = cmbBillingProfileCORP.Value
            Else
                BillProfile = ""
            End If

            Dim UnitTrustFund As String = ""
            If (cmbUnitTrustFundCORP.Text.Trim <> "") Then
                UnitTrustFund = cmbUnitTrustFundCORP.Value
            Else
                UnitTrustFund = ""
            End If
            Dim BankDiv As String = ""
            If cmbBankCatCORP.Text = "Foreign Bank" Then
                BankDiv = txtBankForeignCORP.Text
            Else
                If (cmbBankDivCORP.Text.Trim <> "") Then
                    BankDiv = cmbBankDivCORP.SelectedItem.Value
                Else
                    BankDiv = ""
                End If
            End If
            Dim ACType As String = ""
            If rdAccountType.Text = "Corporate" Then
                ACType = "C"
            Else
                ACType = "P"
            End If
            Dim BillCashAccount As Integer = 0
            If chkBillCashAccountCORP.Checked = True Then
                BillCashAccount = 1
            Else
                BillCashAccount = 0
            End If
            cmd = New SqlCommand("insert into Accounts_Print (BillingCurrency,BillCashAccount,Fund,BillingProfile,Account_class,cdcnumber,SOI,Nominee_CNIC,AgreementDate,Nominee_Address,CNIC_expiry_date,placeofissue,resident_status,Provinces,BusCommenceDate,PostCode,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, isin, company_code,IBAN,BankAccount_Type,Confirmation,FirstWitnessName , FirstWitnessCNIC , SecondWitnessName , SecondWitnessCNIC,contactpersonname,NationalTax,SalesTaxRegistration,Passport,Password_expiry_date,CNIC,Designation,ExpectedRevenueCurrentYear,NetAssets) values(@BillingCurrency,@BillCashAccount,@Fund,@BillingProfile,@Account_class,@cdcnumber,@SOI,@Nominee_CNIC,@AgreementDate,@Nominee_Address,@CNIC_expiry_date,@placeofissue,@resident_status,@Provinces,@BusCommenceDate,@PostCode,@CDS_Number,@BrokerCode,@AccountType,@Surname,@Middlename,@Forenames,@Initials,@Title,@IDNoPP,@IDtype,@Nationality,@DOB,@Gender,@Add_1,@Add_2,@Add_3,@Add_4,@Country,@City,@Tel,@Mobile,@Email,@Category,@Custodian,@TradingStatus,@Industry,@Tax,@Div_Bank,@Div_Branch,@Div_AccountNo,@Cash_Bank,@Cash_Branch,@Cash_AccountNo,@Date_Created,@Update_Type,@Created_By,@AuthorizationState,@DivPayee,@SettlementPayee,@idnopp2,@idtype2, @isin, @company_code,@IBAN,@BankAccount_Type,@Confirmation,@FirstWitnessName,@FirstWitnessCNIC,@SecondWitnessName,@SecondWitnessCNIC,@contactpersonname,@NationalTax,@SalesTaxRegistration,@Passport,@Password_expiry_date,@CNIC,@Designation,@ExpectedRevenueCurrentYear,@NetAssets)  SET @increamentID=SCOPE_IDENTITY() ", cn)
            cmd.Parameters.AddWithValue("@BillingCurrency", cmbBillingCurrencyCORP.Text)
            cmd.Parameters.AddWithValue("@BillCashAccount", BillCashAccount)
            cmd.Parameters.AddWithValue("@Fund", UnitTrustFund)
            cmd.Parameters.AddWithValue("@BillingProfile", BillProfile)
            cmd.Parameters.AddWithValue("@Account_class", cmbBankCatCORP.Text)
            cmd.Parameters.AddWithValue("@IDtype", cmbIDTypeCORP.Text)
            cmd.Parameters.AddWithValue("@IDNoPP", txtIDNoCORP.Text)
            cmd.Parameters.AddWithValue("@CNIC", txtIDNoCORP.Text)
            cmd.Parameters.AddWithValue("@Surname", txtSurnameCORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@BankAccount_Type", cmbTypeofAccountCORP.Text)
            cmd.Parameters.AddWithValue("@Add_1", txtAddress1CORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Add_2", txtAddress2CORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Country", cmbCountryCORP.Text)
            cmd.Parameters.AddWithValue("@Nationality", cmbCountryTaxResidenceCORP.Text)
            cmd.Parameters.AddWithValue("@Designation", txtNatureOfBusinessCORP.Text)
            cmd.Parameters.AddWithValue("@DOB", validateDate(txtDOBCORP.Text))
            cmd.Parameters.AddWithValue("@SOI", txtSourceofFundsCORP.Text)
            cmd.Parameters.AddWithValue("@Industry", cmbInvestorTypeCORP.Text)
            cmd.Parameters.AddWithValue("@contactpersonname", txtfullnameCORP.Text)
            cmd.Parameters.AddWithValue("@Tel", txtTelCORP.Text)
            cmd.Parameters.AddWithValue("@Mobile", txtTelCORP.Text)
            cmd.Parameters.AddWithValue("@PostCode", txtFaxCORP.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmailCORP.Text.ToString.ToLower)
            cmd.Parameters.AddWithValue("@DivPayee", txtPayee2CORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Div_AccountNo", txtIBANCORP.Text)
            cmd.Parameters.AddWithValue("@IBAN", txtIBANCORP.Text)
            cmd.Parameters.AddWithValue("@Div_Bank", BankDiv)
            cmd.Parameters.AddWithValue("@Div_Branch", txtBranchDivCORP.Text)
            cmd.Parameters.AddWithValue("@SettlementPayee", txtBankAddressCORP.Text.ToUpper)
            cmd.Parameters.AddWithValue("@Cash_AccountNo", txtSwiftCodeCORP.Text)
            cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
            cmd.Parameters.AddWithValue("@BrokerCode", Session("BrokerCode"))
            cmd.Parameters.AddWithValue("@AccountType", ACType)
            cmd.Parameters.AddWithValue("@Date_Created", Now.Date)
            cmd.Parameters.AddWithValue("@Update_Type", "NEW")
            cmd.Parameters.AddWithValue("@Created_By", Session("username"))
            cmd.Parameters.AddWithValue("@AuthorizationState", "O")
            cmd.Parameters.AddWithValue("@TradingStatus", "Trading")
            cmd.Parameters.AddWithValue("@idnopp2", " ")
            cmd.Parameters.AddWithValue("@idtype2", " ")
            cmd.Parameters.AddWithValue("@isin", " ")
            cmd.Parameters.AddWithValue("@company_code", " ")
            cmd.Parameters.AddWithValue("@AgreementDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_Address", " ")
            cmd.Parameters.AddWithValue("@CNIC_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@placeofissue", " ")
            cmd.Parameters.AddWithValue("@resident_status", " ")
            cmd.Parameters.AddWithValue("@Provinces", " ")
            cmd.Parameters.AddWithValue("@BusCommenceDate", validateDate(" "))
            cmd.Parameters.AddWithValue("@Middlename", " ")
            cmd.Parameters.AddWithValue("@Forenames", " ")
            cmd.Parameters.AddWithValue("@Initials", " ")
            cmd.Parameters.AddWithValue("@Title", " ")
            cmd.Parameters.AddWithValue("@Gender", " ")
            cmd.Parameters.AddWithValue("@Add_3", " ")
            cmd.Parameters.AddWithValue("@Add_4", " ")
            cmd.Parameters.AddWithValue("@City", " ")
            cmd.Parameters.AddWithValue("@Category", cmbClassificationCORP.Text)
            cmd.Parameters.AddWithValue("@Custodian", " ")
            cmd.Parameters.AddWithValue("@Tax", " ")
            cmd.Parameters.AddWithValue("@Cash_Bank", " ")
            cmd.Parameters.AddWithValue("@Cash_Branch", " ")
            cmd.Parameters.AddWithValue("@Confirmation", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessName", " ")
            cmd.Parameters.AddWithValue("@FirstWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessName", " ")
            cmd.Parameters.AddWithValue("@SecondWitnessCNIC", " ")
            cmd.Parameters.AddWithValue("@NationalTax", " ")
            cmd.Parameters.AddWithValue("@SalesTaxRegistration", " ")
            cmd.Parameters.AddWithValue("@Passport", " ")
            cmd.Parameters.AddWithValue("@Password_expiry_date", validateDate(" "))
            cmd.Parameters.AddWithValue("@Nominee_CNIC", " ")
            cmd.Parameters.AddWithValue("@ExpectedRevenueCurrentYear", " ")
            cmd.Parameters.AddWithValue("@NetAssets", " ")
            cmd.Parameters.AddWithValue("@cdcnumber", txtcdcnumberCORP.Text)
            cmd.Parameters.Add("@increamentID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim outputString = cmd.Parameters("@increamentID").Value.ToString()
            Dim queryString = "AccountPrintReportE.aspx?Username=" & Session("Username") & "&AccType=" & ACType & "&IDD=" & outputString & ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Private Function UpdateOldAccount() As Boolean
        Try
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd As New SqlCommand("declare @RecID numeric(18,0)=(select TOP 1 a.ID from Accounts_Audit a WHERE ISNULL(a.ViewedAuth,0)=0 AND ISNULL(a.AuthorizationState,'') IN ('O') AND a.Created_By=@Created_By and a.CDS_Number NOT IN (SELECT DISTINCT p.CDS_Number FROM Accounts_Clients p) and a.CDS_Number=@CDS_Number ORDER BY A.ID DESC) IF EXISTS(SELECT * FROM Accounts_Audit K WHERE K.ID=@RecID) BEGIN UPDATE Accounts_Audit SET AuthorizationState='E' WHERE ID=@RecID SET @doneDeal='Success' END ELSE BEGIN SET @doneDeal='Fail' END", cn)
                    cmd.Parameters.AddWithValue("@Created_By", Session("Username"))
                    cmd.Parameters.AddWithValue("@CDS_Number", TXTClientID.Text)
                    cmd.Parameters.Add("@doneDeal", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output
                    If cn.State = ConnectionState.Open Then cn.Close()
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Dim outputString = cmd.Parameters("@doneDeal").Value.ToString()
                    If outputString = "Success" Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
            Return False
        End Try
    End Function
End Class
