Imports DevExpress.Web.ASPxGridView

Partial Class CDSMode_AccountsVerification
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public industry1 As String
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetPendingAccounts()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select a.ID,a.cds_number+' '+ case when a.AccountType IN ('C') THEN isnull(a.Surname,'') else isnull(forenames,'')+' '+isnull(surname,'') end as namess from Accounts_audit a where (a.AuthorizationState='A' or a.AuthorizationState='O') AND CASE WHEN ISNULL(a.OTP,'0')='0' THEN 'APPROVED' ELSE ISNULL(a.OTPStatus,'') END='APPROVED' AND a.Created_By<>'" & Session("Username") & "' order by a.cds_number", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbPendingAccounts.DataSource = ds.Tables(0)
                cmbPendingAccounts.TextField = "namess"
                cmbPendingAccounts.ValueField = "ID"
                cmbPendingAccounts.DataBind()
            Else
                cmbPendingAccounts.DataSource = Nothing
                cmbPendingAccounts.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                GetPendingAccounts()
            End If
            If Session("finish_n") = "yes" Then
                Session("finish_n") = ""
                msgbox(Session("updatemsg"))
                Session("updatemsg") = ""
            End If

            If Session("finish_u") = "yes" Then
                Session("finish_u") = ""
                msgbox(Session("updatemsg"))
                Session("updatemsg") = ""
            End If
            If Session("rej") = "true" Then
                Session("rej") = ""
                msgbox(Session("updatemsg"))
                Session("updatemsg") = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getuploaded()

        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID, Name, ContentType from accounts_documents where doc_generated='" + TXTClientID.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            grdEvent.DataSource = dsid2
            grdEvent.DataBind()
        Else
            grdEvent.DataSource = Nothing
            grdEvent.DataBind()
        End If
    End Sub
    Public Sub getAccountDetails()
        Dim ds As New DataSet
        cmd = New SqlCommand("select FORMAT(AgreementDate,'dd MMMM yyyy') AS AgreementDate1,FORMAT(Password_expiry_date,'dd MMMM yyyy') AS Password_expiry_date1,FORMAT(CNIC_expiry_date,'dd MMMM yyyy') AS CNIC_expiry_date1,FORMAT(BusCommenceDate,'dd MMMM yyyy') AS BusCommenceDate1,FORMAT(DOB,'dd MMMM yyyy') AS DOB1,isnull((select top 1 branch_name from para_branch where bank=Div_Bank and branch=Div_Branch),Div_Branch) as BranchName ,isnull((select top 1 bank_name from para_bank where bank=Div_Bank),Div_Bank) as BankName,*,CASE WHEN AccountType='I' THEN 'Single' when AccountType='J' THEN 'Joint' when AccountType='C' THEN 'Corporate' else AccountType end as myAccType from Accounts_audit where ID='" & cmbPendingAccounts.SelectedItem.Value & "' and (authorizationstate='A' or authorizationstate='O')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            lblUpdateType.Text = ds.Tables(0).Rows(0).Item("Update_Type").ToString
            TXTClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            lblRecordID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
            rdAccountType.Text = ds.Tables(0).Rows(0).Item("myAccType").ToString
            cmbIDType.Text = ds.Tables(0).Rows(0).Item("IDtype").ToString
            txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
            txtSurname0.Text = ds.Tables(0).Rows(0).Item("JointName").ToString
            txtUpdateBy.Text = ds.Tables(0).Rows(0).Item("Created_By").ToString
            If ds.Tables(0).Rows(0).Item("AccountType").ToString = "I" Or ds.Tables(0).Rows(0).Item("AccountType").ToString = "J" Then
                cmbTitle.Text = ds.Tables(0).Rows(0).Item("Title").ToString
                txtCNIC.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString
                txtOthernames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB1").ToString
                txtGender.Text = ds.Tables(0).Rows(0).Item("Gender").ToString
                cmbTypeofAccount.Text = ds.Tables(0).Rows(0).Item("BankAccount_Type").ToString
                Try
                    getAssetmanagersClients()
                Catch ex As Exception
                End Try

                cmbNationality.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString
                txtpassport.Text = ds.Tables(0).Rows(0).Item("Passport").ToString
                cmbCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                txtsourceofIncome.Text = ds.Tables(0).Rows(0).Item("SOI").ToString
                txtAddress1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
                txtFax.Text = ds.Tables(0).Rows(0).Item("PostCode").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
                cmbBankDiv.Text = ds.Tables(0).Rows(0).Item("BankName").ToString
                txtBranchDiv.Text = ds.Tables(0).Rows(0).Item("BranchName").ToString
                txtIBAN.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
                txtSwiftCode.Text = ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString
                txtbankAddress.Text = ds.Tables(0).Rows(0).Item("SettlementPayee").ToString
                txtDateTimeStamp.Text = ds.Tables(0).Rows(0).Item("NTN").ToString
                If ds.Tables(0).Rows(0).Item("AccountType").ToString = "J" Then
                    singleTab("Show")
                    JointTab("Show")
                    CoorporateTab("Hide")
                ElseIf ds.Tables(0).Rows(0).Item("AccountType").ToString = "I" Then
                    singleTab("Show")
                    JointTab("Hide")
                    CoorporateTab("Hide")
                End If
            ElseIf ds.Tables(0).Rows(0).Item("AccountType").ToString = "C" Then
                txtCORPSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                cmbCORPTypeofAccount.Text = ds.Tables(0).Rows(0).Item("BankAccount_Type").ToString
                txtCORPAddress1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtCORPAddress2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                cmbCORPCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                cmbCORPCountryTaxResidence.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString
                txtCORPNatureOfBusiness.Text = ds.Tables(0).Rows(0).Item("Designation").ToString
                txtCORPDOB.Text = ds.Tables(0).Rows(0).Item("DOB1").ToString
                txtCORPSourceofFunds.Text = ds.Tables(0).Rows(0).Item("SOI").ToString
                cmbCORPInvestorType.Text = ds.Tables(0).Rows(0).Item("Industry").ToString
                txtCORPfullname.Text = ds.Tables(0).Rows(0).Item("contactpersonname").ToString
                txtCORPTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
                txtCORPFax.Text = ds.Tables(0).Rows(0).Item("PostCode").ToString
                txtCORPEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtCORPPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
                cmbCORPBankDiv.Text = ds.Tables(0).Rows(0).Item("BankName").ToString
                txtCORPBranchDiv.Text = ds.Tables(0).Rows(0).Item("BranchName").ToString
                txtCORPIBAN.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
                txtCORPSwiftCode.Text = ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString
                txtCORPBankAddress.Text = ds.Tables(0).Rows(0).Item("SettlementPayee").ToString
                CoorporateTab("Show")
                singleTab("Hide")
                JointTab("Hide")
                getuploaded()
            End If
            alwaysShowTabs()
            getuploaded()
            getJointHolders()
            If lblUpdateType.Text = "Update" Then
                Try
                    Dim m As New NaymatBilling
                    Dim charge As Double = m.accountMaintanance("ENQUIRE", "DEPOSITOR", "Account Amendment", TXTClientID.Text, "0")
                    txtcharge.Text = charge
                Catch ex As Exception
                    msgbox("Error Charging: " + ex.Message)
                End Try
            Else
                Try
                    Dim m As New NaymatBilling
                    Dim charge As Double = m.accountMaintanance("ENQUIRE", "DEPOSITOR", "Account Opening", TXTClientID.Text, "0")
                    txtcharge.Text = charge
                Catch ex As Exception
                    msgbox("Error Charging: " + ex.Message)
                End Try
            End If
        End If
    End Sub
    Protected Sub rdReject_CheckedChanged(sender As Object, e As EventArgs) Handles rdReject.CheckedChanged
        Try
            If (rdReject.Checked = True) Then
                lblRejection.Visible = True
                txtReasons.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdApprove_CheckedChanged(sender As Object, e As EventArgs) Handles rdApprove.CheckedChanged
        Try
            If (rdApprove.Checked = True) Then
                lblRejection.Visible = False
                txtReasons.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try
            If (lblUpdateType.Text = "NEW") Then
                If (rdApprove.Checked = True) Then
                    SaveNewAccount()
                End If
                If (rdReject.Checked = True) Then
                    If txtReasons.Text = "" Then
                        msgbox("Please enter reason for rejection!")
                        Exit Sub
                    End If
                    RejectAccount()
                End If
            End If
            If (lblUpdateType.Text = "UPDATE") Then
                If (rdApprove.Checked = True) Then
                    UpdateAccount()
                End If
                If (rdReject.Checked = True) Then
                    If txtReasons.Text = "" Then
                        msgbox("Please enter reason for rejection!")
                        Exit Sub
                    End If
                    RejectAccount()
                End If
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("Username"), Request.Url.ToString, ex.ToString)
        End Try
    End Sub
    Public Sub UpdateAccount()
        cmd = New SqlCommand("UPDATE A SET A.[AgreementDate]=B.[AgreementDate],A.[Surname]=B.[Surname], A.[Middlename]=B.[Middlename], A.[Forenames]=B.[Forenames], A.[Initials]=B.[Initials], A.[Title]=B.[Title], A.[IDNoPP]=B.[IDNoPP], A.[IDtype]=B.[IDtype], A.[Nationality]=B.[Nationality], A.[DOB]=B.[DOB], A.[Gender]=B.[Gender], A.[Add_1]=B.[Add_1], A.[Add_2]=B.[Add_2], A.[Add_3]=B.[Add_3], A.[Add_4]=B.[Add_4], A.[Country]=B.[Country], A.[City]=B.[City], A.[Tel]=B.[Tel],A.[Mobile]=B.[Mobile], A.[Email]=B.[Email], A.[Category]=B.[Category], A.[Custodian]=B.[Custodian], A.[TradingStatus]=B.[TradingStatus], A.[Industry]=B.[Industry], A.[Tax]=B.[Tax], A.[Div_Bank]=B.[Div_Bank], A.[Div_Branch]=B.[Div_Branch], A.[Div_AccountNo]=B.[Div_AccountNo], A.[Cash_Bank]=B.[Cash_Bank], A.[Cash_Branch]=B.[Cash_Branch], A.[Cash_AccountNo]=B.[Cash_AccountNo],A.[Client_Image]=B.[Client_Image], A.[Documents]=B.[Documents], A.[BioMatrix]=B.[BioMatrix], A.[Attached_Documents]=B.[Attached_Documents], A.[Update_Type]=B.[Update_Type], A.[Comments]=B.[Comments], A.[DivPayee]=B.[DivPayee], A.[SettlementPayee]=B.[SettlementPayee],A.[idnopp2]=B.[idnopp2], A.[idtype2]=B.[idtype2], A.[client_image2]=B.[client_image2], A.[documents2]=B.[documents2], A.[isin]=B.[isin], A.[company_code]=B.[company_code], A.[mobile_money]=B.[mobile_money], A.[mobile_number]=B.[mobile_number], A.[currency]=B.[currency], A.[Indegnous]=B.[Indegnous], A.[Race]=B.[Race], A.[Disadvantaged]=B.[Disadvantaged], A.[NationalityBy]=B.[NationalityBy], A.[Custody]=B.[Custody] ,A.[Trading]=B.[Trading], A.[Channel]=B.[Channel], A.[PostCode]=B.[PostCode], A.[Resident]=B.[Resident], A.[IBAN]=B.[IBAN], A.[resident_status]=B.[resident_status], A.[BankAccount_Type]=B.[BankAccount_Type], A.[Confirmation]=B.[Confirmation], A.[FirstWitnessName]=B.[FirstWitnessName], A.[FirstWitnessCNIC]=B.[FirstWitnessCNIC], A.[SecondWitnessName]=B.[SecondWitnessName], A.[SecondWitnessCNIC]=B.[SecondWitnessCNIC], A.[FathersName]=B.[FathersName], A.[ExpectedRevenueCurrentYear]=B.[ExpectedRevenueCurrentYear], A.[NationalTax]=B.[NationalTax], A.[Designation]=B.[Designation], A.[Passport]=B.[Passport], A.[CNIC]=B.[CNIC], A.[CNICExpiry]=B.[CNIC_expiry_date], A.[SalesTaxRegistration]=B.[SalesTaxRegistration], A.[SOI]=B.[SOI], A.[GrossIncome]=B.[GAI], A.[NetAssets]=B.[NetAssets], A.[contactpersonname]=B.[contactpersonname], A.[Status]=B.[marital_status], A.[Nominee_Name]=B.[Nominee_Name], A.[Nominee_Account_Id]=B.[Nominee_Account_Id], A.[Nominee_Email]=B.[Nominee_Email], A.[Nominee_Mobile]=B.[Nominee_Mobile], A.[Nominee_Father_Husband_Name]=B.[Nominee_Father_Husband_Name], A.[Nominee_CNIC]=B.[Nominee_CNIC], A.[Nominee_ress]=B.[Nominee_Address], A.[Nominee_Gender]=B.[Nominee_Gender], A.[nomineerelation]=B.[nomineerelation], A.[Tax_exemption]=B.[Tax_exemption], A.[placeofissue]=B.[placeofissue], A.[BusCommenceDate]=B.[BusCommenceDate], A.[PlaceofBirth]=B.[PlaceofBirth],A.[Occupation]=B.[Occupations], A.[PassportExpiry]=B.[Password_expiry_date],A.[NTN]=B.[NTN], A.[Permanet_Address]=B.[Permanet_Address], A.[Permanet_Address1]=B.[Permanet_Address1], A.[Permanet_Address2]=B.[Permanet_Address2], A.[Permanet_Address3]=B.[Permanet_Address3], A.[Provinces]=B.[Provinces] FROM Accounts_Clients A JOIN Accounts_Audit B ON A.CDS_Number=B.CDS_Number WHERE B.ID=@IDD UPDATE Accounts_Audit set AuthorizationState='C' where ID=@IDD", cn)
        cmd.Parameters.AddWithValue("@IDD", lblRecordID.Text)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        If rdAccountType.Text = "Joint" Then
            'insert new members
            cmd = New SqlCommand("INSERT INTO Accounts_Joint([AgreementDate],[CDS_Number], [BrokerCode], [AccountType], [Surname], [Middlename], [Forenames], [Initials], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Add_2], [Add_3], [Add_4], [Country], [City], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Cash_Bank], [Cash_Branch], [Cash_AccountNo], [Client_Image], [Documents], [BioMatrix], [Attached_Documents], [Date_Created], [Update_Type], [Created_By], [AccountState], [Comments], [DivPayee], [SettlementPayee], [Account_class], [idnopp2], [idtype2], [client_image2], [documents2], [isin], [company_code], [mobile_money], [mobile_number], [sttupdate], [currency], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading], [TaxExempt], [Channel], [PostCode], [Resident], [IBAN], [resident_status], [BankAccount_Type], [Confirmation], [FirstWitnessName], [FirstWitnessCNIC], [SecondWitnessName], [SecondWitnessCNIC], [FathersName], [ExpectedRevenueCurrentYear], [NationalTax], [Designation], [Passport], [PassportExpiry], [CNIC], [CNICExpiry], [SalesTaxRegistration], [SOI], [GrossIncome], [NetAssets], [contactpersonname], [Status], [Nominee_Name], [Nominee_Account_Id], [Nominee_Email], [Nominee_Mobile], [Nominee_Father_Husband_Name], [Nominee_CNIC], [Nominee_ress], [Nominee_Gender], [nomineerelation], [Tax_exemption], [placeofissue], [BusCommenceDate], [PlaceofBirth], [Password], [Occupation], [NTN], [Permanet_Address], [Permanet_Address1], [Permanet_Address2], [Permanet_Address3], [Provinces], [AuthorizationState], [JointName])select [AgreementDate],[CDS_Number], [BrokerCode], [AccountType], [Surname], [Middlename], [Forenames], [Initials], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Add_2], [Add_3], [Add_4], [Country], [City], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Cash_Bank], [Cash_Branch], [Cash_AccountNo], [Client_Image], [Documents], [BioMatrix], [Attached_Documents], [Date_Created], [Update_Type], [Created_By], [AccountState], [Comments], [DivPayee], [SettlementPayee], [Account_class], [idnopp2], [idtype2], [client_image2], [documents2], [isin], [company_code], [mobile_money], [mobile_number], [sttupdate], [currency], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading], [TaxExempt], [Channel], [PostCode], [Resident], [IBAN], [resident_status], [BankAccount_Type], [Confirmation], [FirstWitnessName], [FirstWitnessCNIC], [SecondWitnessName], [SecondWitnessCNIC], [FathersName], [ExpectedRevenueCurrentYear], [NationalTax], [Designation], [Passport], [PassportExpiry], [CNIC], [CNICExpiry], [SalesTaxRegistration], [SOI], [GrossIncome], [NetAssets], [contactpersonname], [Status], [Nominee_Name], [Nominee_Account_Id], [Nominee_Email], [Nominee_Mobile], [Nominee_Father_Husband_Name], [Nominee_CNIC], [Nominee_ress], [Nominee_Gender], [nomineerelation], [Tax_exemption], [placeofissue], [BusCommenceDate], [PlaceofBirth], [Password], [Occupation], [NTN], [Permanet_Address], [Permanet_Address1], [Permanet_Address2], [Permanet_Address3], [Provinces], [AuthorizationState], [JointName] from Accounts_Joint_Audit where JointName=@JointName AND AuthorizationState='O' and IDNoPP not in (select distinct h.IDNoPP from Accounts_Joint h where h.JointName=@JointName)  UPDATE Accounts_Joint_Audit SET AuthorizationState='C' WHERE JointName=@JointName and IDNoPP not in (select distinct h.IDNoPP from Accounts_Joint h where h.JointName=@JointName)", cn)
            cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            'insert new members
            'update other members
            Dim STR_CMD2 As String = ""
            STR_CMD2 = STR_CMD2 & " UPDATE A SET A.[AgreementDate]=B.[AgreementDate],A.[Surname]=B.[Surname], A.[Middlename]=B.[Middlename], A.[Forenames]=B.[Forenames], A.[Initials]=B.[Initials], A.[Title]=B.[Title], A.[IDNoPP]=B.[IDNoPP], A.[IDtype]=B.[IDtype], A.[Nationality]=B.[Nationality], A.[DOB]=B.[DOB], A.[Gender]=B.[Gender], A.[Add_1]=B.[Add_1], A.[Add_2]=B.[Add_2], A.[Add_3]=B.[Add_3], A.[Add_4]=B.[Add_4], A.[Country]=B.[Country], A.[City]=B.[City], A.[Tel]=B.[Tel], A.[Mobile]=B.[Mobile], A.[Email]=B.[Email], A.[Category]=B.[Category], A.[Custodian]=B.[Custodian], A.[TradingStatus]=B.[TradingStatus], A.[Industry]=B.[Industry], A.[Tax]=B.[Tax], A.[Div_Bank]=B.[Div_Bank], A.[Div_Branch]=B.[Div_Branch], A.[Div_AccountNo]=B.[Div_AccountNo], A.[Cash_Bank]=B.[Cash_Bank], A.[Cash_Branch]=B.[Cash_Branch], A.[Cash_AccountNo]=B.[Cash_AccountNo], A.[Client_Image]=B.[Client_Image], A.[Documents]=B.[Documents], A.[BioMatrix]=B.[BioMatrix], A.[Attached_Documents]=B.[Attached_Documents], A.[Date_Created]=B.[Date_Created], A.[Update_Type]=B.[Update_Type], A.[Created_By]=B.[Created_By],A.[Comments]=B.[Comments], A.[DivPayee]=B.[DivPayee], A.[SettlementPayee]=B.[SettlementPayee], A.[Account_class]=B.[Account_class], A.[idnopp2]=B.[idnopp2], A.[idtype2]=B.[idtype2], A.[client_image2]=B.[client_image2], A.[documents2]=B.[documents2], A.[isin]=B.[isin], A.[company_code]=B.[company_code], A.[mobile_money]=B.[mobile_money], A.[mobile_number]=B.[mobile_number], A.[sttupdate]=B.[sttupdate], A.[currency]=B.[currency], A.[Indegnous]=B.[Indegnous], A.[Race]=B.[Race], A.[Disadvantaged]=B.[Disadvantaged], A.[NationalityBy]=B.[NationalityBy], A.[Custody]=B.[Custody], A.[Trading]=B.[Trading], A.[TaxExempt]=B.[TaxExempt], A.[Channel]=B.[Channel], A.[PostCode]=B.[PostCode], A.[Resident]=B.[Resident], A.[IBAN]=B.[IBAN], A.[resident_status]=B.[resident_status], A.[BankAccount_Type]=B.[BankAccount_Type], A.[Confirmation]=B.[Confirmation], A.[FirstWitnessName]=B.[FirstWitnessName], A.[FirstWitnessCNIC]=B.[FirstWitnessCNIC], A.[SecondWitnessName]=B.[SecondWitnessName], A.[SecondWitnessCNIC]=B.[SecondWitnessCNIC], A.[FathersName]=B.[FathersName], A.[ExpectedRevenueCurrentYear]=B.[ExpectedRevenueCurrentYear], A.[NationalTax]=B.[NationalTax], A.[Designation]=B.[Designation], A.[Passport]=B.[Passport], A.[PassportExpiry]=B.[PassportExpiry], A.[CNIC]=B.[CNIC], A.[CNICExpiry]=B.[CNICExpiry], A.[SalesTaxRegistration]=B.[SalesTaxRegistration], A.[SOI]=B.[SOI], A.[GrossIncome]=B.[GrossIncome], A.[NetAssets]=B.[NetAssets], A.[contactpersonname]=B.[contactpersonname], A.[Status]=B.[Status], A.[Nominee_Name]=B.[Nominee_Name], A.[Nominee_Account_Id]=B.[Nominee_Account_Id], A.[Nominee_Email]=B.[Nominee_Email], A.[Nominee_Mobile]=B.[Nominee_Mobile], A.[Nominee_Father_Husband_Name]=B.[Nominee_Father_Husband_Name], A.[Nominee_CNIC]=B.[Nominee_CNIC], A.[Nominee_ress]=B.[Nominee_ress], A.[Nominee_Gender]=B.[Nominee_Gender], A.[nomineerelation]=B.[nomineerelation], A.[Tax_exemption]=B.[Tax_exemption], A.[placeofissue]=B.[placeofissue], A.[BusCommenceDate]=B.[BusCommenceDate], A.[PlaceofBirth]=B.[PlaceofBirth], A.[Password]=B.[Password], A.[Occupation]=B.[Occupation], A.[NTN]=B.[NTN], A.[Permanet_Address]=B.[Permanet_Address], A.[Permanet_Address1]=B.[Permanet_Address1], A.[Permanet_Address2]=B.[Permanet_Address2], A.[Permanet_Address3]=B.[Permanet_Address3], A.[Provinces]=B.[Provinces] FROM Accounts_Joint A JOIN Accounts_Joint_Audit B ON A.CDS_Number=B.CDS_Number AND A.IDNoPP=B.IDNoPP AND A.JointName=B.JointName WHERE A.CDS_Number='" & TXTClientID.Text & "' AND B.AuthorizationState='O' AND A.JointName=@JointName UPDATE Accounts_Joint_Audit SET AuthorizationState='C' WHERE JointName=@JointName AND AuthorizationState='O' "

            cmd = New SqlCommand(STR_CMD2, cn)
            cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
            cmd.Parameters.AddWithValue("@IDD", lblRecordID.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            'update other members
        End If
        GetPendingAccounts()
        Try
            Dim m As New NaymatBilling
            m.accountMaintanance("BILL", "DEPOSITOR", "Account Amendment", TXTClientID.Text, "0")
        Catch ex As Exception
            msgbox("Error Charging: " + ex.Message)
        End Try
        Session("updatemsg") = "You have successfully authorised Existing " & rdAccountType.Text & " Account, Account No. " & TXTClientID.Text
        Session("finish_u") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub SaveNewAccount()
        Dim pas_ As String = CreateRandomPassword(8)
        Dim paswarheouse As String = base64Encode(pas_)
        cmd = New SqlCommand("INSERT INTO Accounts_Clients([JointName],[AgreementDate],[CDS_Number], [BrokerCode], [AccountType], [Surname], [Middlename], [Forenames], [Initials], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Add_2], [Add_3], [Add_4], [Country], [City], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Cash_Bank], [Cash_Branch], [Cash_AccountNo], [Client_Image], [Documents], [BioMatrix], [Attached_Documents], [Date_Created], [Update_Type], [Created_By], [AccountState], [Comments], [DivPayee], [SettlementPayee], [idnopp2], [idtype2], [client_image2], [documents2], [isin], [company_code], [mobile_money], [mobile_number], [currency], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading], [Channel], [PostCode], [Resident], [IBAN], [resident_status], [BankAccount_Type], [Confirmation], [FirstWitnessName], [FirstWitnessCNIC], [SecondWitnessName], [SecondWitnessCNIC], [FathersName], [ExpectedRevenueCurrentYear], [NationalTax], [Designation], [Passport], [CNIC], [CNICExpiry], [SalesTaxRegistration], [SOI], [GrossIncome], [NetAssets], [contactpersonname], [Status], [Nominee_Name], [Nominee_Account_Id], [Nominee_Email], [Nominee_Mobile], [Nominee_Father_Husband_Name], [Nominee_CNIC], [Nominee_ress], [Nominee_Gender], [nomineerelation], [Tax_exemption], [placeofissue], [BusCommenceDate], [PlaceofBirth],[Occupation], [PassportExpiry],[NTN], [Permanet_Address], [Permanet_Address1], [Permanet_Address2], [Permanet_Address3], [Provinces],[Password]) SELECT [JointName],[AgreementDate],[CDS_Number], [BrokerCode], [AccountType], [Surname], [Middlename], [Forenames], [Initials], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Add_2], [Add_3], [Add_4], [Country], [City], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Cash_Bank], [Cash_Branch], [Cash_AccountNo], [Client_Image], [Documents], [BioMatrix], [Attached_Documents], GETDATE(), [Update_Type], [Created_By], 'A', [Comments], [DivPayee], [SettlementPayee], [idnopp2], [idtype2], [client_image2], [documents2], [isin], [company_code], [mobile_money], [mobile_number], [currency], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading], [Channel], [PostCode], [Resident], [IBAN], [resident_status], [BankAccount_Type], [Confirmation], [FirstWitnessName], [FirstWitnessCNIC], [SecondWitnessName], [SecondWitnessCNIC], [FathersName], [ExpectedRevenueCurrentYear], [NationalTax], [Designation], [Passport], [CNIC], [CNIC_expiry_date], [SalesTaxRegistration], [SOI], [GAI], [NetAssets], [contactpersonname], [marital_status], [Nominee_Name], [Nominee_Account_Id], [Nominee_Email], [Nominee_Mobile], [Nominee_Father_Husband_Name], [Nominee_CNIC], [Nominee_Address], [Nominee_Gender], [nomineerelation], [Tax_exemption], [placeofissue], [BusCommenceDate], [PlaceofBirth], [Occupations], [Password_expiry_date], [NTN], [Permanet_Address], [Permanet_Address1], [Permanet_Address2], [Permanet_Address3], [Provinces], @Password FROM Accounts_Audit WHERE ID=@IDD  Update Accounts_Audit set AuthorizationState='C' where ID=@IDD", cn)
        cmd.Parameters.AddWithValue("@Password", pas_)
        cmd.Parameters.AddWithValue("@IDD", lblRecordID.Text)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        If rdAccountType.Text = "Joint" Then
            'insert new members
            cmd = New SqlCommand("INSERT INTO Accounts_Joint([AgreementDate],[CDS_Number], [BrokerCode], [AccountType], [Surname], [Middlename], [Forenames], [Initials], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Add_2], [Add_3], [Add_4], [Country], [City], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Cash_Bank], [Cash_Branch], [Cash_AccountNo], [Client_Image], [Documents], [BioMatrix], [Attached_Documents], [Date_Created], [Update_Type], [Created_By], [AccountState], [Comments], [DivPayee], [SettlementPayee], [Account_class], [idnopp2], [idtype2], [client_image2], [documents2], [isin], [company_code], [mobile_money], [mobile_number], [sttupdate], [currency], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading], [TaxExempt], [Channel], [PostCode], [Resident], [IBAN], [resident_status], [BankAccount_Type], [Confirmation], [FirstWitnessName], [FirstWitnessCNIC], [SecondWitnessName], [SecondWitnessCNIC], [FathersName], [ExpectedRevenueCurrentYear], [NationalTax], [Designation], [Passport], [PassportExpiry], [CNIC], [CNICExpiry], [SalesTaxRegistration], [SOI], [GrossIncome], [NetAssets], [contactpersonname], [Status], [Nominee_Name], [Nominee_Account_Id], [Nominee_Email], [Nominee_Mobile], [Nominee_Father_Husband_Name], [Nominee_CNIC], [Nominee_ress], [Nominee_Gender], [nomineerelation], [Tax_exemption], [placeofissue], [BusCommenceDate], [PlaceofBirth], [Password], [Occupation], [NTN], [Permanet_Address], [Permanet_Address1], [Permanet_Address2], [Permanet_Address3], [Provinces], [AuthorizationState], [JointName])select [AgreementDate],[CDS_Number], [BrokerCode], [AccountType], [Surname], [Middlename], [Forenames], [Initials], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Add_2], [Add_3], [Add_4], [Country], [City], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Cash_Bank], [Cash_Branch], [Cash_AccountNo], [Client_Image], [Documents], [BioMatrix], [Attached_Documents], [Date_Created], [Update_Type], [Created_By], [AccountState], [Comments], [DivPayee], [SettlementPayee], [Account_class], [idnopp2], [idtype2], [client_image2], [documents2], [isin], [company_code], [mobile_money], [mobile_number], [sttupdate], [currency], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading], [TaxExempt], [Channel], [PostCode], [Resident], [IBAN], [resident_status], [BankAccount_Type], [Confirmation], [FirstWitnessName], [FirstWitnessCNIC], [SecondWitnessName], [SecondWitnessCNIC], [FathersName], [ExpectedRevenueCurrentYear], [NationalTax], [Designation], [Passport], [PassportExpiry], [CNIC], [CNICExpiry], [SalesTaxRegistration], [SOI], [GrossIncome], [NetAssets], [contactpersonname], [Status], [Nominee_Name], [Nominee_Account_Id], [Nominee_Email], [Nominee_Mobile], [Nominee_Father_Husband_Name], [Nominee_CNIC], [Nominee_ress], [Nominee_Gender], [nomineerelation], [Tax_exemption], [placeofissue], [BusCommenceDate], [PlaceofBirth], [Password], [Occupation], [NTN], [Permanet_Address], [Permanet_Address1], [Permanet_Address2], [Permanet_Address3], [Provinces], [AuthorizationState], [JointName] from Accounts_Joint_Audit where JointName=@JointName AND AuthorizationState='O' and IDNoPP not in (select distinct h.IDNoPP from Accounts_Joint h where h.JointName=@JointName)  UPDATE Accounts_Joint_Audit SET AuthorizationState='C' WHERE JointName=@JointName and IDNoPP not in (select distinct h.IDNoPP from Accounts_Joint h where h.JointName=@JointName)", cn)
            cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            'insert new members
        End If
        'insert new
        cmd = New SqlCommand("insert into [SystemUsers] (company, companycode, CompanyType, username, Department, [Password], [Activation], Trail, PasswordExpireyDate, AuthorizePerm, AccountType, Forenames, Surname, email, tel, Mobile1, Mobile2, idnopp, gender, [Role], Active_Session)  SELECT 'DEPOSITOR', 'DEP', 'DEPOSITOR',UPPER(CDS_number),'USER','" + paswarheouse + "','1','0',getdate(),'0','USER',UPPER(Forenames),UPPER(surname),Email,tel,Mobile,Mobile,IdNopp,Gender,cds_number,'0' FROM Accounts_Audit WHERE ID=@IDD", cn)
        cmd.Parameters.AddWithValue("@IDD", lblRecordID.Text)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        'insert new
        'insert clientAsset managers
        'insert new
        cmd = New SqlCommand("insert into [Client_AssetManagers] ([ClientNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy])  SELECT [ClientNo], [AssetManager], [BankAccount], [BankName], [BankBranch], [DateLinked], [LinkedBy] FROM Client_AssetManagersAudit WHERE ClientNo=@ClientNo", cn)
        cmd.Parameters.AddWithValue("@ClientNo", TXTClientID.Text)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Dim sendEmail As String = ""
        If rdAccountType.Text = "Single" Or rdAccountType.Text = "Joint" Then
            sendEmail = txtEmail.Text
        Else
            sendEmail = txtCORPEmail.Text
        End If
        Try
            Dim M As New sendmail
            M.sendmail(sendEmail, "New Login Credentials", "Your profile has been successfully setup on Custodial System. Your Username is " + TXTClientID.Text + " and your password is " + pas_ + "")
        Catch ex As Exception
        End Try
        Try
            Dim m As New NaymatBilling
            m.accountMaintanance("BILL", "DEPOSITOR", "Account Opening", TXTClientID.Text, "0")
        Catch ex As Exception
            msgbox("Error Charging: " + ex.Message)
        End Try
        Session("updatemsg") = "You have successfully authorised New " & rdAccountType.Text & " Account, Account No. " & TXTClientID.Text
        Session("finish_n") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@$#"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Public Sub RejectAccount()
        Try
            cmd = New SqlCommand("update Accounts_Audit set AuthorizationState='X',Comments=@Comments where ID=@IDD", cn)
            cmd.Parameters.AddWithValue("@Comments", txtReasons.Text)
            cmd.Parameters.AddWithValue("@IDD", lblRecordID.Text)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetPendingAccounts()
            Session("updatemsg") = "You have rejected updates for " & rdAccountType.Text & " Account, Account No. " & TXTClientID.Text
            Session("rej") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
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
    Private Sub grdEvent_RowCommand(sender As Object, e As ASPxGridViewRowCommandEventArgs) Handles grdEvent.RowCommand
        Dim idD As String = e.KeyValue.ToString
        If e.CommandArgs.CommandName.ToString = "View Document" Then
            Try
                pd(idD)
            Catch ex As Exception
            End Try
            Try
                word(idD)
            Catch ex As Exception
            End Try
            Try
                xls(idD)
            Catch ex As Exception
            End Try
            Try
                Img(idD)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Sub singleTab(ByVal actionNeeded As String)
        If actionNeeded = "Show" Then
            Panel8a.Visible = True
            Panel8b.Visible = True
            Panel8d.Visible = True
            Panel8l.Visible = True
            Panel8f.Visible = True
            Panel8k.Visible = True
            Panel3a.Visible = True
            Panel8i.Visible = True
            Panel3b.Visible = True
            Panel3l.Visible = True
            Panel4a.Visible = True
            Panel4b.Visible = True
            Panel4c.Visible = True
            Panel4d.Visible = True
            Panel4e.Visible = True
            Panel3bb.Visible = True
            Panel3bbbb.Visible = True
            ASPxLabel117.Text = "Personal Details"
        Else
            Panel8a.Visible = False
            Panel8b.Visible = False
            Panel8d.Visible = False
            Panel8l.Visible = False
            Panel8f.Visible = False
            Panel8k.Visible = False
            Panel3a.Visible = False
            Panel8i.Visible = False
            Panel3b.Visible = False
            Panel3l.Visible = False
            Panel4a.Visible = False
            Panel4b.Visible = False
            Panel4c.Visible = False
            Panel4d.Visible = False
            Panel4e.Visible = False
            Panel3bb.Visible = False
            Panel3bbbb.Visible = False
        End If
    End Sub
    Sub CoorporateTab(ByVal actionNeeded As String)
        If actionNeeded = "Show" Then
            PanelCORP1.Visible = True
            PanelCORP2.Visible = True
            PanelCORP3.Visible = True
            PanelCORP4.Visible = True
            PanelCORP5.Visible = True
            PanelCORP6.Visible = True
            PanelCORP7.Visible = True
            PanelCORP8.Visible = True
            PanelCORP9.Visible = True
            PanelCORP10.Visible = True
            PanelCORP11.Visible = True
            PanelCORP12.Visible = True
            PanelCORP13.Visible = True
            PanelCORP14.Visible = True
        Else
            PanelCORP1.Visible = False
            PanelCORP2.Visible = False
            PanelCORP3.Visible = False
            PanelCORP4.Visible = False
            PanelCORP5.Visible = False
            PanelCORP6.Visible = False
            PanelCORP7.Visible = False
            PanelCORP8.Visible = False
            PanelCORP9.Visible = False
            PanelCORP10.Visible = False
            PanelCORP11.Visible = False
            PanelCORP12.Visible = False
            PanelCORP13.Visible = False
            PanelCORP14.Visible = False
        End If
    End Sub
    Sub JointTab(ByVal actionNeeded As String)
        If actionNeeded = "Show" Then
            Panel15a.Visible = True
            Panel15b.Visible = True
            Panel20a.Visible = True
            panel20f.Visible = True
            ASPxLabel117.Text = "Personal Details (Principal Member)"
        Else
            Panel15a.Visible = False
            Panel15b.Visible = False
            Panel20a.Visible = False
            panel20f.Visible = False
        End If
    End Sub
    Sub alwaysShowTabs()
        panelSave1.Visible = True
        panelSave5.Visible = True
        panelLastSection1.Visible = True
        panelLastSection2.Visible = True
        p19new.Visible = True
        panelLastSection3.Visible = True
    End Sub
    Protected Sub cmbPendingAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPendingAccounts.SelectedIndexChanged
        getAccountDetails()
    End Sub
    Sub getJointHolders()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID,Surname,IDNoPP,Add_1,Mobile,Email,nomineerelation from Accounts_Joint_AUDIT where JointName=@JointName", cn)
        cmd.Parameters.AddWithValue("@JointName", txtSurname0.Text)
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
    Private Function base64Encode(ByVal sData As String) As String
        Try
            Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)
            Dim encodedData As String = Convert.ToBase64String(encData_byte)
            Return (encodedData)
        Catch ex As Exception
            Throw (New Exception("Error in base64Encode" & ex.Message))
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
        strSQL = "SELECT * FROM Client_AssetManagers WHERE ClientNo='" & TXTClientID.Text & "'"
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
End Class
