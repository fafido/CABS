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
            cmd = New SqlCommand("select cds_number+' '+surname+' '+forenames as namess from Accounts_audit where (AuthorizationState='A' or AuthorizationState='O')  order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Audit")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbPendingAccounts.DataSource = ds.Tables(0)
                cmbPendingAccounts.TextField = "namess"
                cmbPendingAccounts.ValueField = "namess"
                cmbPendingAccounts.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
                GetPendingAccounts()
            End If
            If Session("finish_n") = "yes" Then
                Session("finish_n") = ""
                msgbox("New Account Aprroved")
            End If

            If Session("finish_u") = "yes" Then
                Session("finish_u") = ""
                msgbox("Account Update Aprroved")
            End If
            If Session("rej") = "true" Then
                Session("rej") = ""
                msgbox("Account Rejected!")
            End If
            '  Panel5.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getshares(ByVal idnumber As String)
        Dim dst As New DataSet
        cmd = New SqlCommand("SELECT [IdNumber] as [National Id], [CertificateNumber] as [Certificate Number], [Holder] as [Shareholder Number], [Company] as [Company], [Units] as [Units]  FROM [CDS].[dbo].[AccountNewCertificates] where replace(replace(IdNumber,' ',''), '-', '') ='" + idnumber + "' order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dst, "APP")
        If dst.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = dst.Tables(0)
        Else
            GridView1.DataSource = Nothing
        End If
        GridView1.DataBind()

    End Sub
    Protected Sub rdIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles rdIndividual.CheckedChanged
        Try
            If (rdIndividual.Checked = True) Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                '    Panel5.Visible = True
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdJoint_CheckedChanged(sender As Object, e As EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Or (rdJoint0.Checked = True) Then
                txtJforenames.Visible = True
                txtJsurname.Visible = True
                lblJforenames.Visible = True
                lblJSurname.Visible = True
                btnJadd.Visible = True
                grdJointAccounts.Visible = True
            Else
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdJoint0_CheckedChanged(sender As Object, e As EventArgs) Handles rdCorprate.CheckedChanged
        Try
            If rdCorprate.Checked = True Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdBroker_CheckedChanged(sender As Object, e As EventArgs) Handles rdBroker.CheckedChanged
        If (rdBroker.Checked = True) Then
            txtJforenames.Visible = False
            txtJsurname.Visible = False
            lblJforenames.Visible = False
            lblJSurname.Visible = False
            btnJadd.Visible = False
            grdJointAccounts.Visible = False
        End If
    End Sub
    Protected Sub cmbPendingAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPendingAccounts.SelectedIndexChanged
        getAccountDetails()
        If rdJoint.Checked = True Or rdJoint0.Checked = True Then
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()

            tax.Visible = False
            Revenue.Visible = False
            txtpassportexpirydate.Visible = False
            txtpassportexpirydate.Visible = False
            ASPxLabel1318.Visible = False
            txtpassport.Visible = False
            ASPxLabel3124.Visible = False
            txtNTN.Visible = False
            ASPxLabel120.Visible = False
            ASPxLabel312.Visible = False
            txtCNICExpiry.Visible = False
            getjoint()

            Panel8.Visible = False
        ElseIf rdBroker.Checked = True Then
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            Panel8.Visible = False
            getjoint()


        ElseIf rdCorprate.Checked = True Then
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            tax.Visible = True
            Revenue.Visible = True
            Panel8.Visible = False
            getjoint()

        Else
            Panel8.Visible = True
            grdJointAccounts.DataSource = Nothing
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = False

        End If
    End Sub
    Public Sub getcorp()
        Dim dsi2 As New DataSet
        cmd = New SqlCommand("select distinct Surname+' '+forenames+' '+Middlename as Names, idnopp as [ID Number], idtype as [ID Type], Nationality, DOB, Gender from Accounts_audit where CDS_Number=(select top 1 cds_number from Accounts_audit where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "')", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi2, "para_cust2")
        If (dsi2.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsi2
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = True
            ASPxLabel41.Visible = True


        End If
    End Sub
    Public Sub getjoint()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select distinct Surname+' '+Forenames as Names, IDNo as [ID Number], IDTYPE AS [ID Type], Nationality, DateofBirth as [DOB],Gender from Accounts_Joint where CDSNo=(select top 1 cds_number from Accounts_audit where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "')", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cust1")
        If (dsi.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsi
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = True
            ASPxLabel41.Visible = True
            tax.Visible = True
            Revenue.Visible = True

        End If
    End Sub
    Public Sub getindustryfull()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select fnam from para_industry where code='" + industry1 + "'", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cu")
        If (dsi.Tables(0).Rows.Count > 0) Then
            txtIndustry.Text = dsi.Tables(0).Rows(0).Item("fnam")
        End If
    End Sub
    Public Sub getgender()
        If lblgender.Text = "M" Then
            lblgender.Text = "Male"
        ElseIf lblgender.Text = "F" Then
            lblgender.Text = "Female"
        Else
            lblgender.Text = "N/A"
        End If
    End Sub
    Public Sub getAccountDetails()
        '  Try

        lblSurname.Text = ""
        lblForenames.Text = ""
        lblMiddlename.Text = ""
        lblIdNo.Text = ""
        lblIdtype.Text = ""
        lblInitials.Text = ""
        lblTitle.Text = ""
        lblNationality.Text = ""
        lblDob.Text = ""
        lblAdd1.Text = ""
        lblAdd2.Text = ""
        lblAdd3.Text = ""
        lblAdd4.Text = ""
        lblCountry.Text = ""
        lblCity.Text = ""
        txtJsurname.Text = ""
        lblJSurname.Visible = False
        txtJsurname.Visible = False
        lblJSurname.Text = "Surname"
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Accounts_audit where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "' and (authorizationstate='A' or authorizationstate='O') order by Date_Created desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            If (ds.Tables(0).Rows(0).Item("Update_Type").ToString = "NEW") Then
                lblUpdateType.Text = "NEW"
                TXTClientID.Text = ""
            Else
                lblUpdateType.Text = "UPDATE"
                TXTClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            End If

            txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
            txtMiddlename.Text = ds.Tables(0).Rows(0).Item("Middlename").ToString
            txtOtherNames.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString
            txtInitials.Text = ds.Tables(0).Rows(0).Item("Initials").ToString
            txtIDNo.Text = ds.Tables(0).Rows(0).Item("IDNoPP").ToString
            txtDOB.Text = FormatDateTime(ds.Tables(0).Rows(0).Item("DOB").ToString, DateFormat.LongDate)
            TXTClientID.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
            txtIBAN.Text = ds.Tables(0).Rows(0).Item("IBAN").ToString
            txtFirstWitnessName.Text = ds.Tables(0).Rows(0).Item("FirstWitnessName").ToString
            txtFirstWitnessCNIC.Text = ds.Tables(0).Rows(0).Item("FirstWitnessCNIC").ToString
            txtSecondWitnesName.Text = ds.Tables(0).Rows(0).Item("SecondWitnessName").ToString
            txtSecondWitnessCNIC.Text = ds.Tables(0).Rows(0).Item("SecondWitnessCNIC").ToString
            txtHusband.Text = ds.Tables(0).Rows(0).Item("FathersName").ToString
            txtResidentialStatus.Text = ds.Tables(0).Rows(0).Item("Resident_Status").ToString
            txtgrossincome.Text = ds.Tables(0).Rows(0).Item("GAI").ToString
            txtsourceofIncome.Text = ds.Tables(0).Rows(0).Item("SOI").ToString
            txtNTN.Text = ds.Tables(0).Rows(0).Item("NTN").ToString
            txtpassport.Text = ds.Tables(0).Rows(0).Item("Passport").ToString
            txtpassportexpirydate.Text = ds.Tables(0).Rows(0).Item("Password_expiry_date").ToString
            txtCNIC.Text = ds.Tables(0).Rows(0).Item("CNIC").ToString
            txtCNICExpiry.Text = ds.Tables(0).Rows(0).Item("CNIC_expiry_date").ToString
            txtdesignation.Text = ds.Tables(0).Rows(0).Item("Designation").ToString
            txtOccupation.Text = ds.Tables(0).Rows(0).Item("Occupations").ToString
            txtCountry.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString
            txtTel.Text = ds.Tables(0).Rows(0).Item("mobile").ToString
            txtNationalTax.Text = ds.Tables(0).Rows(0).Item("NationalTax").ToString
            txtTaxRegistration.Text = ds.Tables(0).Rows(0).Item("SalesTaxRegistration").ToString
            txtRevenue.Text = ds.Tables(0).Rows(0).Item("ExpectedRevenueCurrentYear").ToString
            txtNetAssets.Text = ds.Tables(0).Rows(0).Item("NetAssets").ToString
            'literal1.Text = "<a href='viewdocument.aspx?id=" + ds.Tables(0).Rows(0).Item("Client_Image2").ToString + "' target='_blank'>Click here for Client Image</a>"
            'literal2.Text = "<a href='viewdocument.aspx?id=" + ds.Tables(0).Rows(0).Item("Documents2").ToString + "' target='_blank'>Click here for Client Document</a>"
            '    getshares(txtIDNo.Text)


            If (ds.Tables(0).Rows(0).Item("GENDER").ToString = "M") Then
                rdMale.Checked = True
                rdFemale.Checked = False
                rdNa.Checked = False
            End If
            If (ds.Tables(0).Rows(0).Item("GENDER").ToString = "F") Then
                rdMale.Checked = False
                rdFemale.Checked = True
                rdNa.Checked = False
            End If
            If (ds.Tables(0).Rows(0).Item("GENDER").ToString = "N") Then
                rdMale.Checked = False
                rdFemale.Checked = False
                rdNa.Checked = True
            End If
            If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "I") Then
                rdIndividual.Checked = True
                rdJoint.Checked = False
                rdCorprate.Checked = False
                rdBroker.Checked = False
            End If
            If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "J") Then
                rdIndividual.Checked = False
                rdJoint.Checked = True
                rdCorprate.Checked = False
                rdBroker.Checked = False
                txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                lblJSurname.Visible = True
                txtJsurname.Visible = True
                lblJSurname.Text = "Account Name"
            End If
            If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "N") Then
                rdIndividual.Checked = False
                rdJoint0.Checked = True
                rdCorprate.Checked = False
                rdBroker.Checked = False
                txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                lblJSurname.Visible = True
                txtJsurname.Visible = True
                lblJSurname.Text = "Account Name"
            End If
            If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "C") Then
                rdIndividual.Checked = False
                rdJoint.Checked = True
                rdCorprate.Checked = True
                rdBroker.Checked = False
                txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                lblJSurname.Visible = True
                txtJsurname.Visible = True
                lblJSurname.Text = "Account Name"
            End If
            If (ds.Tables(0).Rows(0).Item("AccountType").ToString = "B") Then
                rdIndividual.Checked = False
                rdJoint.Checked = False
                rdCorprate.Checked = False
                rdBroker.Checked = True
                txtJsurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString
                lblJSurname.Visible = True
                txtJsurname.Visible = True
                lblJSurname.Text = "Broker Name"
            End If
            txtAdd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
            txtAdd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
            txtAdd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
            txtAdd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
            txtMobile.Text = ds.Tables(0).Rows(0).Item("Mobile").ToString
            txtTel.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
            '  txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB").ToString
            '
            '                 ,[Div_Bank]
            '      ,[Div_Branch]
            '      ,[Div_AccountNo]


            '                txtPayee2.Text = ds.Tables(0).Rows(0).Item("Tel").ToString
            txtBankName.Text = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
            txtBranch.Text = ds.Tables(0).Rows(0).Item("Div_Branch").ToString
            txtAccountNo.Text = ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString

            txtbnkname.Text = ds.Tables(0).Rows(0).Item("Div_Bank").ToString
            txtbranchname.Text = ds.Tables(0).Rows(0).Item("Div_Branch").ToString
            txtaccno.Text = ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString

            If (ds.Tables(0).Rows(0).Item("Category").ToString = "C") Then
                rdControlled.Checked = True
                rdNonControlled.Checked = False
            Else
                rdNonControlled.Checked = True
                rdControlled.Checked = False

            End If
            If (ds.Tables(0).Rows(0).Item("TradingStatus").ToString = "DEALING ALLOWED") Then
                rdTrading.Checked = True
                rdNonTrading.Checked = False
            Else
                rdNonTrading.Checked = True
                rdTrading.Checked = False
            End If
            getuploaded()

            txtNationality.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString
            txtCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
            txtCity.Text = ds.Tables(0).Rows(0).Item("City").ToString
            industry1 = ds.Tables(0).Rows(0).Item("Industry").ToString
            getindustryfull()
            txtTax.Text = ds.Tables(0).Rows(0).Item("tax").ToString
            txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString
            txtIDType.Text = ds.Tables(0).Rows(0).Item("IDtype").ToString
            txtBankName.Text = ds.Tables(0).Rows(0).Item("div_bank").ToString
            txtBranch.Text = ds.Tables(0).Rows(0).Item("div_branch").ToString
            txtAccountNo.Text = ds.Tables(0).Rows(0).Item("div_AccountNo").ToString
            txtCashBank.Text = ds.Tables(0).Rows(0).Item("Cash_Bank").ToString
            txtAccountNo.Text = ds.Tables(0).Rows(0).Item("div_AccountNo").ToString
            txtCashAccount.Text = ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString
            txtCashBrach.Text = ds.Tables(0).Rows(0).Item("Cash_Branch").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtPayee1.Text = ds.Tables(0).Rows(0).Item("SettlementPayee").ToString
            txtPayee2.Text = ds.Tables(0).Rows(0).Item("DivPayee").ToString
            txtcust.Text = ds.Tables(0).Rows(0).Item("Custodian").ToString
            txtmobilemoney.Text = ds.Tables(0).Rows(0).Item("mobile_money").ToString
            txtmobilemonephone.Text = ds.Tables(0).Rows(0).Item("mobile_number").ToString

            If (ds.Tables(0).Rows(0).Item("Indegnous").ToString = "YES") Then
                rbtLstRating.Items(0).Selected = True
            Else
                rbtLstRating.Items(1).Selected = True
            End If


            raceText.Text = ds.Tables(0).Rows(0).Item("Race").ToString

            '                ds.Tables(0).Rows(0).Item("Disadvantaged").ToString
            '                ds.Tables(0).Rows(0).Item("Indegnous").ToString
            '                ds.Tables(0).Rows(0).Item("Disadvantaged").ToString

            If (ds.Tables(0).Rows(0).Item("Disadvantaged").ToString = "YES") Then
                dis.Items(0).Selected = True
            Else
                dis.Items(1).Selected = True
            End If

            If (ds.Tables(0).Rows(0).Item("NationalityBy").ToString = "Birth") Then
                natBy.Items(0).Selected = True
            ElseIf (ds.Tables(0).Rows(0).Item("NationalityBy").ToString = "Descendancy") Then
                natBy.Items(1).Selected = True
            ElseIf (ds.Tables(0).Rows(0).Item("NationalityBy").ToString = "Adoption") Then
                natBy.Items(2).Selected = True
            End If


            If (lblUpdateType.Text = "UPDATE") Then
                Dim rod As New DataSet
                cmd = New SqlCommand("select * from cds_router.dbo.Accounts_Clients_WEB where cds_number = '" & Trim(TXTClientID.Text) & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(rod, "Accounts_Clients")
                If (rod.Tables(0).Rows.Count > 0) Then
                    If (ds.Tables(0).Rows(0).Item("surname").ToString <> rod.Tables(0).Rows(0).Item("surname").ToString) Then
                        lblSurname.Text = rod.Tables(0).Rows(0).Item("surname").ToString
                        lblSurname.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("forenames").ToString <> rod.Tables(0).Rows(0).Item("forenames").ToString) Then
                        lblForenames.Text = rod.Tables(0).Rows(0).Item("forenames").ToString
                        lblForenames.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("middlename").ToString <> rod.Tables(0).Rows(0).Item("middlename").ToString) Then
                        lblMiddlename.Text = rod.Tables(0).Rows(0).Item("middlename").ToString
                        lblMiddlename.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("gender").ToString <> rod.Tables(0).Rows(0).Item("gender").ToString) Then
                        lblgender.Text = rod.Tables(0).Rows(0).Item("gender").ToString
                        lblgender.ForeColor = Drawing.Color.Red
                        getgender()

                    End If
                    If (ds.Tables(0).Rows(0).Item("surname").ToString <> rod.Tables(0).Rows(0).Item("surname").ToString) Then
                        lbljsur.Text = rod.Tables(0).Rows(0).Item("surname").ToString
                        lbljsur.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("title").ToString <> rod.Tables(0).Rows(0).Item("title").ToString) Then
                        lblTitle.Text = rod.Tables(0).Rows(0).Item("title").ToString
                        lblTitle.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("DOB").ToString <> rod.Tables(0).Rows(0).Item("DOB").ToString) Then
                        lblDob.Text = rod.Tables(0).Rows(0).Item("DOB").ToString
                        lblDob.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("Add_4").ToString <> rod.Tables(0).Rows(0).Item("add_4").ToString) Then
                        lblAdd4.Text = rod.Tables(0).Rows(0).Item("add_4").ToString
                        lblAdd4.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("country").ToString <> rod.Tables(0).Rows(0).Item("country").ToString) Then
                        lblCountry.Text = rod.Tables(0).Rows(0).Item("country").ToString
                        lblCountry.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("city").ToString <> rod.Tables(0).Rows(0).Item("city").ToString) Then
                        lblCity.Text = rod.Tables(0).Rows(0).Item("city").ToString
                        lblCity.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("email").ToString <> rod.Tables(0).Rows(0).Item("email").ToString) Then
                        lblEmail.Text = rod.Tables(0).Rows(0).Item("email").ToString
                        lblEmail.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("custodian").ToString <> rod.Tables(0).Rows(0).Item("custodian").ToString) Then
                        lblcustodian.Text = rod.Tables(0).Rows(0).Item("custodian").ToString
                        lblcustodian.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("industry").ToString <> rod.Tables(0).Rows(0).Item("industry").ToString) Then
                        lblindustry.Text = rod.Tables(0).Rows(0).Item("industry").ToString
                        lblindustry.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("Divpayee").ToString <> rod.Tables(0).Rows(0).Item("Divpayee").ToString) Then
                        lbldivpayee.Text = rod.Tables(0).Rows(0).Item("divpayee").ToString
                        lbldivpayee.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("Div_bank").ToString <> rod.Tables(0).Rows(0).Item("Div_bank").ToString) Then
                        lbldivbank.Text = rod.Tables(0).Rows(0).Item("div_bank").ToString
                        lbldivbank.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("Div_branch").ToString <> rod.Tables(0).Rows(0).Item("Div_branch").ToString) Then
                        lbldivbranch.Text = rod.Tables(0).Rows(0).Item("div_branch").ToString
                        lbldivbranch.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("Div_Accountno").ToString <> rod.Tables(0).Rows(0).Item("Div_Accountno").ToString) Then
                        lbldivaccountno.Text = rod.Tables(0).Rows(0).Item("div_Accountno").ToString
                        lbldivaccountno.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("settlementpayee").ToString <> rod.Tables(0).Rows(0).Item("settlementpayee").ToString) Then
                        lblcashpayee.Text = rod.Tables(0).Rows(0).Item("settlementpayee").ToString
                        lblcashpayee.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("cash_bank").ToString <> rod.Tables(0).Rows(0).Item("cash_bank").ToString) Then
                        lblcashbank.Text = rod.Tables(0).Rows(0).Item("cash_bank").ToString
                        lblcashbank.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("cash_branch").ToString <> rod.Tables(0).Rows(0).Item("cash_branch").ToString) Then
                        lblcashbranch.Text = rod.Tables(0).Rows(0).Item("cash_branch").ToString
                        lblcashbranch.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("cash_accountno").ToString <> rod.Tables(0).Rows(0).Item("cash_accountno").ToString) Then
                        lblcashaccountno.Text = rod.Tables(0).Rows(0).Item("cash_accountno").ToString
                        lblcashaccountno.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("tax").ToString <> rod.Tables(0).Rows(0).Item("tax").ToString) Then
                        lbltax.Text = rod.Tables(0).Rows(0).Item("tax").ToString
                        lbltax.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("idtype").ToString <> rod.Tables(0).Rows(0).Item("idtype").ToString) Then
                        lblIdtype.Text = rod.Tables(0).Rows(0).Item("idtype").ToString
                        lblIdtype.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("initials").ToString <> rod.Tables(0).Rows(0).Item("initials").ToString) Then
                        lblInitials.Text = rod.Tables(0).Rows(0).Item("initials").ToString
                        lblInitials.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("idnopp").ToString <> rod.Tables(0).Rows(0).Item("idnopp").ToString) Then
                        lblIdNo.Text = rod.Tables(0).Rows(0).Item("idnopp").ToString
                        lblIdNo.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("nationality").ToString <> rod.Tables(0).Rows(0).Item("nationality").ToString) Then
                        lblNationality.Text = rod.Tables(0).Rows(0).Item("nationality").ToString
                        lblNationality.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("add_1").ToString <> rod.Tables(0).Rows(0).Item("add_1").ToString) Then
                        lblAdd1.Text = rod.Tables(0).Rows(0).Item("add_1").ToString
                        lblAdd1.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("add_2").ToString <> rod.Tables(0).Rows(0).Item("add_2").ToString) Then
                        lblAdd2.Text = rod.Tables(0).Rows(0).Item("add_2").ToString
                        lblAdd2.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("add_3").ToString <> rod.Tables(0).Rows(0).Item("add_3").ToString) Then
                        lblAdd3.Text = rod.Tables(0).Rows(0).Item("add_3").ToString
                        lblAdd3.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("add_4").ToString <> rod.Tables(0).Rows(0).Item("add_4").ToString) Then
                        lblAdd4.Text = rod.Tables(0).Rows(0).Item("add_4").ToString
                        lblAdd4.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("tel").ToString <> rod.Tables(0).Rows(0).Item("tel").ToString) Then
                        lblTel.Text = rod.Tables(0).Rows(0).Item("tel").ToString
                        lblTel.ForeColor = Drawing.Color.Red
                    End If
                    If (ds.Tables(0).Rows(0).Item("mobile").ToString <> rod.Tables(0).Rows(0).Item("mobile").ToString) Then
                        lblMobile.Text = rod.Tables(0).Rows(0).Item("mobile").ToString
                        lblMobile.ForeColor = Drawing.Color.Red
                    End If                        'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                    'End If
                    'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                    'End If
                    'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                    'End If
                    'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                    'End If
                    'If (ds.Tables(0).Rows(0).Item("").ToString <> rod.Tables(0).Rows(0).Item("").ToString) Then

                    'End If
                End If
            End If
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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
        '   Try
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
        lblSurname.Text = ""
        lblForenames.Text = ""
        lblMiddlename.Text = ""
        lblIdNo.Text = ""
        lblIdtype.Text = ""
        lblInitials.Text = ""
        lblTitle.Text = ""
        lblNationality.Text = ""
        lblDob.Text = ""
        lblAdd1.Text = ""
        lblAdd2.Text = ""
        lblAdd3.Text = ""
        lblAdd4.Text = ""
        lblCountry.Text = ""
        lblCity.Text = ""
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Sub UpdateAccount()
        '  Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Accounts_Audit where CDS_Number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "' and Update_Type='UPDATE' and (AuthorizationState='A' OR AuthorizationState='O') order by Date_Created desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            'msgbox("Update Accounts_Clients set broker_code='" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "',AccountType='" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "',surname='" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "',middlename='" & ds.Tables(0).Rows(0).Item("middlename").ToString.ToString.ToUpper & "',forenames='" & ds.Tables(0).Rows(0).Item("forenames").ToString.ToString.ToUpper & "',initials='" & ds.Tables(0).Rows(0).Item("initials").ToString.ToString.ToUpper & "',title='" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "',idnopp='" & ds.Tables(0).Rows(0).Item("idnopp").ToString.ToString.ToUpper & "',idtype='" & ds.Tables(0).Rows(0).Item("idtype").ToString.ToString.ToUpper & "',nationality='" & ds.Tables(0).Rows(0).Item("nationality").ToString.ToString.ToUpper & "',DOB='" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "',GENDER='" & ds.Tables(0).Rows(0).Item("gender").ToString.ToString.ToUpper & "',add_1='" & ds.Tables(0).Rows(0).Item("add_1").ToString.ToString.ToUpper & "',add_2='" & ds.Tables(0).Rows(0).Item("add_2").ToString.ToString.ToUpper & "',add_3='" & ds.Tables(0).Rows(0).Item("add_3").ToString.ToString.ToUpper & "',add_4='" & ds.Tables(0).Rows(0).Item("add_4").ToString.ToString.ToUpper & "',country='" & ds.Tables(0).Rows(0).Item("country").ToString.ToString.ToUpper & "',city='" & ds.Tables(0).Rows(0).Item("city").ToString.ToString.ToUpper & "',tel='" & ds.Tables(0).Rows(0).Item("tel").ToString.ToString.ToUpper & "',mobile='" & ds.Tables(0).Rows(0).Item("mobile").ToString.ToString.ToUpper & "',email='" & ds.Tables(0).Rows(0).Item("email").ToString.ToString.ToUpper & "',Category='" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "',Custodian='" & ds.Tables(0).Rows(0).Item("Custodian").ToString.ToString.ToUpper & "',TradingStatus='" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "',Industry='" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "',Tax='" & ds.Tables(0).Rows(0).Item("tax").ToString.ToString.ToUpper & "',Div_Bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Div_branch='" & ds.Tables(0).Rows(0).Item("Div_branch").ToString.ToString.ToUpper & "',Div_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Cash_bank='" & ds.Tables(0).Rows(0).Item("Cash_Bank").ToString.ToString.ToUpper & "',Cash_Branch='" & ds.Tables(0).Rows(0).Item("Cash_Branch").ToString.ToString.ToUpper & "',Cash_AccountNo='" & ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString.ToString.ToUpper & "',Date_Created='" & ds.Tables(0).Rows(0).Item("Date_Created").ToString.ToString.ToUpper & "',Update_Type='UPDATE',created_by='" & Session("Username") & "',AccountState ='A' WHERE cds_number='" & ds.Tables(0).Rows(0).Item("cds_number").ToString & "'")
            cmd = New SqlCommand("Update Accounts_Clients set brokercode='" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "',mobile_money='" & ds.Tables(0).Rows(0).Item("mobile_money").ToString.ToString.ToUpper & "',passport='" & ds.Tables(0).Rows(0).Item("Passport").ToString.ToString.ToUpper & "',SOI='" & ds.Tables(0).Rows(0).Item("SOI").ToString.ToString.ToUpper & "', GrossIncome='" & ds.Tables(0).Rows(0).Item("GAI").ToString.ToString.ToUpper & "' ,  IBAN='" & ds.Tables(0).Rows(0).Item("IBAN").ToString.ToString.ToUpper & "'  ,BankAccount_Type='" & ds.Tables(0).Rows(0).Item("BankAccount_Type").ToString.ToString.ToUpper & "' ,FirstWitnessName='" & ds.Tables(0).Rows(0).Item("FirstWitnessName").ToString.ToString.ToUpper & "', FirstWitnessCNIC='" & ds.Tables(0).Rows(0).Item("FirstWitnessCNIC").ToString.ToString.ToUpper & "' ,SecondWitnessName='" & ds.Tables(0).Rows(0).Item("SecondWitnessName").ToString.ToString.ToUpper & "'  , SecondWitnessCNIC='" & ds.Tables(0).Rows(0).Item("SecondWitnessCNIC").ToString.ToString.ToUpper & "'   ,  Designation='" & ds.Tables(0).Rows(0).Item("Designation").ToString.ToString.ToUpper & "' ,mobile_number='" & ds.Tables(0).Rows(0).Item("mobile_number").ToString.ToString.ToUpper & "' ,AccountType='" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "',surname='" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "',middlename='" & ds.Tables(0).Rows(0).Item("middlename").ToString.ToString.ToUpper & "',forenames='" & ds.Tables(0).Rows(0).Item("forenames").ToString.ToString.ToUpper & "',initials='" & ds.Tables(0).Rows(0).Item("initials").ToString.ToString.ToUpper & "',title='" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "',idnopp='" & ds.Tables(0).Rows(0).Item("idnopp").ToString.ToString.ToUpper & "',idtype='" & ds.Tables(0).Rows(0).Item("idtype").ToString.ToString.ToUpper & "',nationality='" & ds.Tables(0).Rows(0).Item("nationality").ToString.ToString.ToUpper & "',DOB='" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "',GENDER='" & ds.Tables(0).Rows(0).Item("gender").ToString.ToString.ToUpper & "',add_1='" & ds.Tables(0).Rows(0).Item("add_1").ToString.ToString.ToUpper & "',add_2='" & ds.Tables(0).Rows(0).Item("add_2").ToString.ToString.ToUpper & "',add_3='" & ds.Tables(0).Rows(0).Item("add_3").ToString.ToString.ToUpper & "',add_4='" & ds.Tables(0).Rows(0).Item("add_4").ToString.ToString.ToUpper & "',country='" & ds.Tables(0).Rows(0).Item("country").ToString.ToString.ToUpper & "',city='" & ds.Tables(0).Rows(0).Item("city").ToString.ToString.ToUpper & "',tel='" & ds.Tables(0).Rows(0).Item("tel").ToString.ToString.ToUpper & "',mobile='" & ds.Tables(0).Rows(0).Item("mobile").ToString.ToString.ToUpper & "',email='" & ds.Tables(0).Rows(0).Item("email").ToString.ToString.ToUpper & "',Category='" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "',TradingStatus='" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "',Industry='" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "',Tax='" & ds.Tables(0).Rows(0).Item("tax").ToString.ToString.ToUpper & "',Div_Bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Div_branch='" & ds.Tables(0).Rows(0).Item("Div_branch").ToString.ToString.ToUpper & "',Div_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Cash_bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Cash_Branch='" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "',DivPayee='" & txtPayee2.Text & "',SettlementPayee='" & txtPayee2.Text & "',Cash_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Date_Created='" & ds.Tables(0).Rows(0).Item("Date_Created").ToString.ToString.ToUpper & "',Update_Type='UPDATE',created_by='" & Session("Username") & "',AccountState ='A' WHERE cds_number='" & ds.Tables(0).Rows(0).Item("cds_number").ToString & "'  Update cds_router.dbo.Accounts_Clients set brokercode='" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "',mobile_money='" & ds.Tables(0).Rows(0).Item("mobile_money").ToString.ToString.ToUpper & "',mobile_number='" & ds.Tables(0).Rows(0).Item("mobile_number").ToString.ToString.ToUpper & "' ,AccountType='" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "',surname='" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "',middlename='" & ds.Tables(0).Rows(0).Item("middlename").ToString.ToString.ToUpper & "',forenames='" & ds.Tables(0).Rows(0).Item("forenames").ToString.ToString.ToUpper & "',initials='" & ds.Tables(0).Rows(0).Item("initials").ToString.ToString.ToUpper & "',title='" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "',idnopp='" & ds.Tables(0).Rows(0).Item("idnopp").ToString.ToString.ToUpper & "',idtype='" & ds.Tables(0).Rows(0).Item("idtype").ToString.ToString.ToUpper & "',nationality='" & ds.Tables(0).Rows(0).Item("nationality").ToString.ToString.ToUpper & "',DOB='" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "',GENDER='" & ds.Tables(0).Rows(0).Item("gender").ToString.ToString.ToUpper & "',add_1='" & ds.Tables(0).Rows(0).Item("add_1").ToString.ToString.ToUpper & "',add_2='" & ds.Tables(0).Rows(0).Item("add_2").ToString.ToString.ToUpper & "',add_3='" & ds.Tables(0).Rows(0).Item("add_3").ToString.ToString.ToUpper & "',add_4='" & ds.Tables(0).Rows(0).Item("add_4").ToString.ToString.ToUpper & "',country='" & ds.Tables(0).Rows(0).Item("country").ToString.ToString.ToUpper & "',city='" & ds.Tables(0).Rows(0).Item("city").ToString.ToString.ToUpper & "',tel='" & ds.Tables(0).Rows(0).Item("tel").ToString.ToString.ToUpper & "',mobile='" & ds.Tables(0).Rows(0).Item("mobile").ToString.ToString.ToUpper & "',email='" & ds.Tables(0).Rows(0).Item("email").ToString.ToString.ToUpper & "',Category='" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "',TradingStatus='" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "',Industry='" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "',Tax='" & ds.Tables(0).Rows(0).Item("tax").ToString.ToString.ToUpper & "',Div_Bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Div_branch='" & ds.Tables(0).Rows(0).Item("Div_branch").ToString.ToString.ToUpper & "',Div_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Cash_bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Cash_Branch='" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "',DivPayee='" & txtPayee2.Text & "',SettlementPayee='" & txtPayee2.Text & "',Cash_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Date_Created='" & ds.Tables(0).Rows(0).Item("Date_Created").ToString.ToString.ToUpper & "',Update_Type='UPDATE',created_by='" & Session("Username") & "',AccountState ='A' WHERE cds_number='" & ds.Tables(0).Rows(0).Item("cds_number").ToString & "'  Update cds_router.dbo.Accounts_Clients_web set brokercode='" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "',mobile_money='" & ds.Tables(0).Rows(0).Item("mobile_money").ToString.ToString.ToUpper & "',mobile_number='" & ds.Tables(0).Rows(0).Item("mobile_number").ToString.ToString.ToUpper & "' ,AccountType='" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "',surname='" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "',middlename='" & ds.Tables(0).Rows(0).Item("middlename").ToString.ToString.ToUpper & "',forenames='" & ds.Tables(0).Rows(0).Item("forenames").ToString.ToString.ToUpper & "',initials='" & ds.Tables(0).Rows(0).Item("initials").ToString.ToString.ToUpper & "',title='" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "',idnopp='" & ds.Tables(0).Rows(0).Item("idnopp").ToString.ToString.ToUpper & "',idtype='" & ds.Tables(0).Rows(0).Item("idtype").ToString.ToString.ToUpper & "',nationality='" & ds.Tables(0).Rows(0).Item("nationality").ToString.ToString.ToUpper & "',DOB='" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "',GENDER='" & ds.Tables(0).Rows(0).Item("gender").ToString.ToString.ToUpper & "',add_1='" & ds.Tables(0).Rows(0).Item("add_1").ToString.ToString.ToUpper & "',add_2='" & ds.Tables(0).Rows(0).Item("add_2").ToString.ToString.ToUpper & "',add_3='" & ds.Tables(0).Rows(0).Item("add_3").ToString.ToString.ToUpper & "',add_4='" & ds.Tables(0).Rows(0).Item("add_4").ToString.ToString.ToUpper & "',country='" & ds.Tables(0).Rows(0).Item("country").ToString.ToString.ToUpper & "',city='" & ds.Tables(0).Rows(0).Item("city").ToString.ToString.ToUpper & "',tel='" & ds.Tables(0).Rows(0).Item("tel").ToString.ToString.ToUpper & "',mobile='" & ds.Tables(0).Rows(0).Item("mobile").ToString.ToString.ToUpper & "',email='" & ds.Tables(0).Rows(0).Item("email").ToString.ToString.ToUpper & "',Category='" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "',TradingStatus='" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "',Industry='" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "',Tax='" & ds.Tables(0).Rows(0).Item("tax").ToString.ToString.ToUpper & "',Div_Bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Div_branch='" & ds.Tables(0).Rows(0).Item("Div_branch").ToString.ToString.ToUpper & "',Div_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Cash_bank='" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "',Cash_Branch='" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "',DivPayee='" & txtPayee2.Text & "',SettlementPayee='" & txtPayee2.Text & "',Cash_AccountNo='" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "',Date_Created='" & ds.Tables(0).Rows(0).Item("Date_Created").ToString.ToString.ToUpper & "',Update_Type='UPDATE',created_by='" & Session("Username") & "',AccountState ='A' WHERE cds_number='" & ds.Tables(0).Rows(0).Item("cds_number").ToString & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            'cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='C' where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='C' where cds_number='" & ds.Tables(0).Rows(0).Item("cds_number").ToString & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account Updated")
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtAdd3.Text = ""
            txtAdd4.Text = ""
            txtCity.Text = ""
            TXTClientID.Text = ""
            txtAccountNo.Text = ""
            txtCountry.Text = ""
            txtDOB.Text = ""
            txtIDNo.Text = ""
            txtInitials.Text = ""
            txtJforenames.Text = ""
            txtMiddlename.Text = ""
            txtMobile.Text = ""
            txtNationality.Text = ""
            txtOtherNames.Text = ""
            txtReasons.Text = ""
            txtSurname.Text = ""
            txtTel.Text = ""

            GetPendingAccounts()
            Session("finish_u") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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
    Public Sub SaveNewAccount()
        '  Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Accounts_Audit where CDS_Number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Audit")
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim cdsNo As String = ""
            Dim dsi As New DataSet
            cmd = New SqlCommand("select * from Accounts_Clients", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "Accounts_Clients")
            If (dsi.Tables(0).Rows.Count > 0) Then
                Dim ros As New DataSet
                cmd = New SqlCommand("select max(id) as id from Accounts_Clients", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ros, "Accounts_Clients")
                cdsNo = Session("BrokerCode") & (CInt(ros.Tables(0).Rows(0).Item("id").ToString + 1)).ToString.PadLeft(6, "0")
            Else
                cdsNo = Session("BrokerCode") & CInt(1).ToString.PadLeft(6, "0")
            End If
            'cmd = New SqlCommand("insert into Accounts_Clients (                                                                                                                                                                                                                                                                                                                                                                                                                   CDS_Number,             BrokerCode,                                                                 AccountType,                                                            Surname,                                                                Middlename,                                                                         Forenames,                                                          Initials,                                                                   Title,                                                                              IDNoPP,                                                         IDtype,                                                                             Nationality,                                                            DOB,                                                                            Gender,                                                                     Add_1,                                                          Add_2,                                                          Add_3,                                                                          Add_4,                                                                  Country,                                                City,                                                                   Tel,                                                            Mobile,                                                                         Email,                                                      Category,                                                                   Custodian,                                                              TradingStatus,                                                                      Industry,                                                               Tax,                                                            Div_Bank,                                                                                       Div_Branch,                                                     Div_AccountNo,                                                              Cash_Bank,                                                              Cash_Branch,                                                                Cash_AccountNo,                                                                 Client_Image,                                                               Documents,BioMatrix,Attached_Documents,Date_Created,Update_Type,Created_By,AccountState,Comments) values ('" & cdsNo & "','" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Middlename").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Initials").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDNoPP").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDtype").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Nationality").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Gender").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_1").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_2").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_3").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_4").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Country").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("City").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tel").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Mobile").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Email").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Custodian").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tax").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Client_Image").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Documents").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("BioMatrix").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Attached_Documents").ToString.ToString.ToUpper & "','" & Now.Date & "','NEW','" & Session("USERNAME") & "','A','')", cn)

            Dim pas_ As String = CreateRandomPassword(8)

            Dim pasctrade As String = EncryptIt(pas_)
            Dim paswarheouse As String = base64Encode(pas_)




            '                raceText.Text = ds.Tables(0).Rows(0).Item("Race").ToString
            '                ds.Tables(0).Rows(0).Item("Disadvantaged").ToString
            '                ds.Tables(0).Rows(0).Item("Indegnous").ToString
            '                ds.Tables(0).Rows(0).Item("Disadvantaged").ToString

            cmd = New SqlCommand("insert into Accounts_Clients (SOI,GrossIncome,CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Client_Image,Documents,BioMatrix,Attached_Documents,Date_Created,Update_Type,Created_By,AccountState,Comments, divpayee,settlementpayee, mobile_money, mobile_Number, [Indegnous], [Race], [Disadvantaged], [NationalityBy],resident_status, IBAN,BankAccount_Type,Confirmation,FirstWitnessName,FirstWitnessCNIC,SecondWitnessName,SecondWitnessCNIC,FathersName,ExpectedRevenueCurrentYear, NationalTax ,SalesTaxRegistration ,Designation,Passport, PassportExpiry, CNIC , CNICExpiry, Password) values ('" & ds.Tables(0).Rows(0).Item("SOI").ToString.ToString.ToUpper & "', '" & ds.Tables(0).Rows(0).Item("GAI").ToString.ToString.ToUpper & "'  ,'" & ds.Tables(0).Rows(0).Item("CDS_number").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("AccountType").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Middlename").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Initials").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("title").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDNoPP").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("IDtype").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Nationality").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Gender").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_1").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_2").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_3").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Add_4").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Country").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("City").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tel").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Mobile").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Email").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Category").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Custodian").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("TradingStatus").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Tax").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Div_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Bank").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_Branch").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Cash_AccountNo").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Client_Image").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Documents").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("BioMatrix").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Attached_Documents").ToString.ToString.ToUpper & "','" & Now.Date & "','NEW','" & Session("USERNAME") & "','A','','" & ds.Tables(0).Rows(0).Item("Divpayee").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("Settlementpayee").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("mobile_money").ToString.ToString.ToUpper & "','" & ds.Tables(0).Rows(0).Item("mobile_number").ToString.ToString.ToUpper & "', '" + ds.Tables(0).Rows(0).Item("Indegnous").ToString + "', '" + ds.Tables(0).Rows(0).Item("Race").ToString + "', '" + ds.Tables(0).Rows(0).Item("Disadvantaged").ToString + "', '" + ds.Tables(0).Rows(0).Item("NationalityBy").ToString + "','" + ds.Tables(0).Rows(0).Item("resident_status").ToString + "','" + ds.Tables(0).Rows(0).Item("IBAN").ToString + "','" + ds.Tables(0).Rows(0).Item("BankAccount_Type").ToString + "','" + ds.Tables(0).Rows(0).Item("Confirmation").ToString + "','" + ds.Tables(0).Rows(0).Item("FirstWitnessName").ToString + "','" + ds.Tables(0).Rows(0).Item("FirstWitnessCNIC").ToString + "','" + ds.Tables(0).Rows(0).Item("SecondWitnessName").ToString + "','" + ds.Tables(0).Rows(0).Item("SecondWitnessCNIC").ToString + "','" + ds.Tables(0).Rows(0).Item("FathersName").ToString + "','" + ds.Tables(0).Rows(0).Item("ExpectedRevenueCurrentYear").ToString + "','" + ds.Tables(0).Rows(0).Item("NationalTax").ToString + "','" + ds.Tables(0).Rows(0).Item("SalesTaxRegistration").ToString + "' , '" + ds.Tables(0).Rows(0).Item("Designation").ToString + "', '" + ds.Tables(0).Rows(0).Item("Passport").ToString + "','" + ds.Tables(0).Rows(0).Item("Password_expiry_date").ToString + "','" + ds.Tables(0).Rows(0).Item("CNIC").ToString + "','" + ds.Tables(0).Rows(0).Item("CNIC_expiry_date").ToString + "','" + pas_ + "') insert into trans (company, cds_number, date_created, trans_time, shares, update_type, created_by, batch_ref, source, Pledge_shares, reference, instrument, [broker], custodian)   select company, '" & ds.Tables(0).Rows(0).Item("CDS_number").ToString.ToString.ToUpper & "', getdate(), getdate(), units, 'DEMAT','" + Session("Username").ToString() + "','0','S','0',certificatenumber, 'EQUITY','" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString.ToString.ToUpper & "', '" + Session("BrokerCode") + "' from AccountNewCertificates where idnumber='" + txtIDNo.Text + "' update accountnewcertificates set [status]=1 where idnumber='" + txtIDNo.Text + "' update accountnewdetails set [status]='1' where idnumber='" + txtIDNo.Text + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()



            cmd = New SqlCommand("insert into [SystemUsers] (company, companycode, CompanyType, username, Department, [Password], [Activation], Trail, PasswordExpireyDate, AuthorizePerm, AccountType, Forenames, Surname, email, tel, Mobile1, Mobile2, idnopp, gender, [Role], Active_Session)  values ('DEPOSITOR', 'DEP', 'DEPOSITOR','" + ds.Tables(0).Rows(0).Item("CDS_number").ToString.ToString.ToUpper + "','USER','" + paswarheouse + "','1','0','2021-11-11','0','USER','" + ds.Tables(0).Rows(0).Item("Forenames").ToString.ToString.ToUpper + "', '" + ds.Tables(0).Rows(0).Item("surname").ToString.ToString.ToUpper + "', '" + ds.Tables(0).Rows(0).Item("Email").ToString.ToString.ToUpper + "','" + ds.Tables(0).Rows(0).Item("tel").ToString.ToString.ToUpper + "','" + ds.Tables(0).Rows(0).Item("Mobile").ToString.ToString.ToUpper + "','" + ds.Tables(0).Rows(0).Item("Mobile").ToString.ToString.ToUpper + "','" + ds.Tables(0).Rows(0).Item("IdNopp").ToString.ToString.ToUpper + "','" + ds.Tables(0).Rows(0).Item("Gender").ToString.ToString.ToUpper + "','" + ds.Tables(0).Rows(0).Item("cds_number").ToString.ToString.ToUpper + "','0')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='C' where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Try
                Dim M As New sendmail
                M.sendmail(ds.Tables(0).Rows(0).Item("Email").ToString.ToString, "New Login Credentials", "Your profile has been successfully setup on Custodial System. Your username is your email and your password is " + pas_ + "")
            Catch ex As Exception

            End Try

            cmd = New SqlCommand("Update names set Broker_code=(select brokercode from accounts_audit where CDS_Number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "')   where CDS_Number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            '    msgbox("New account created")
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtAdd3.Text = ""
            txtAdd4.Text = ""
            txtCity.Text = ""
            TXTClientID.Text = ""
            txtAccountNo.Text = ""
            txtCountry.Text = ""
            txtDOB.Text = ""
            txtIDNo.Text = ""
            txtInitials.Text = ""
            txtJforenames.Text = ""
            txtMiddlename.Text = ""
            txtMobile.Text = ""
            txtNationality.Text = ""
            txtOtherNames.Text = ""
            txtReasons.Text = ""
            txtSurname.Text = ""
            txtTel.Text = ""


            Session("finish_n") = "yes"
            Response.Redirect(Request.RawUrl)
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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
    Public Shared Function EncryptIt(ByVal password As String) As String
        Dim i As Integer = password.Length
        Dim theEncrypteOne As String = ""
        Dim j As Integer

        For j = 0 To i - 1
            theEncrypteOne += Strings.ChrW((Strings.AscW(password.Substring(j, 1)) - 10))
        Next

        Dim EncryptIt1 As String = theEncrypteOne
        Return EncryptIt1
    End Function
    Public Sub RejectAccount()
        Try
            cmd = New SqlCommand("update Accounts_Audit set AuthorizationState='X',Comments='" & txtReasons.Text & "' where cds_number+' '+surname+' '+forenames='" & cmbPendingAccounts.SelectedItem.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtAdd3.Text = ""
            txtAdd4.Text = ""
            txtCity.Text = ""
            TXTClientID.Text = ""
            txtAccountNo.Text = ""
            txtCountry.Text = ""
            txtDOB.Text = ""
            txtIDNo.Text = ""
            txtInitials.Text = ""
            txtJforenames.Text = ""
            txtMiddlename.Text = ""
            txtMobile.Text = ""
            txtNationality.Text = ""
            txtOtherNames.Text = ""
            txtReasons.Text = ""
            txtSurname.Text = ""
            txtTel.Text = ""
            GetPendingAccounts()
            Session("rej") = "true"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub pd()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img()
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + grdEvent.SelectedValue.ToString + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Protected Sub download(ByVal dt As DataTable)

        '  If ds.Tables("ck").Rows.Count > 0 Then
        Dim bytes() As Byte = CType(dt.Rows(0)("Data"), Byte())
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = dt.Rows(0)("ContentType").ToString()

        ' Response.ContentType = ds.Tables("ck").Rows(0).Item("ContentType").ToString
        'Response.AddHeader("content-disposition", "attachment;filename=" & dt.Rows(0)("Name").ToString())
        Response.AddHeader("content-disposition", "attachment;filename=""" + dt.Rows(0)("Name").ToString() + "" + dt.Rows(0)("ContentType").ToString() + "")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()

        ' End If

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
    Public Sub getuploaded()

        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select ID, Name, ContentType from accounts_documents where doc_generated='" + TXTClientID.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            grdEvent.DataSource = dsid2
            grdEvent.DataBind()
        End If
    End Sub

    Protected Sub grdEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdEvent.SelectedIndexChanged
        Try
            pd()
        Catch ex As Exception

        End Try
        Try
            word()
        Catch ex As Exception

        End Try

        Try
            xls()
        Catch ex As Exception

        End Try
        Try
            Img()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnJadd_Click(sender As Object, e As EventArgs) Handles btnJadd.Click

    End Sub
End Class
