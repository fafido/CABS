
Imports DevExpress.XtraEditors.Popup

Partial Class Custodian_NewAccountCreation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Public password, numb, codec As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Session("SavedSuccess") = "SavedSuccess" Then
                msgbox("Account created successfully")
            ElseIf Session("SavedSuccess") = "SavedRej" Then
                msgbox("Account Rejected successfully")
                '                  Session("SavedSuccess") = "SavedRej"
            End If
            '            Session("SavedSuccess") = ""


            Session("SavedSuccess") = ""
            panelCorp.Visible = False
            '            grdApps.DataSource = Nothing

            cmd = New SqlCommand("SELECT [Title]     as Title      ,[Surname]     as [Last Name]      ,[Forenames]   as [First Name]      ,[CDS_Number] as [CDS Number]      ,[IDNoPP] as [ID Number]	  ,[BrokerCode] as Broker      ,[AccountType] as [Account Type]      ,[Nationality] as [Nationality]      FROM [CDS].[dbo].[Accounts_Audit] where AuthorizationState='C' and Custodian='" + Session("BrokerCode").ToString() + "' and Update_Type='NEW' and CDS_Number not in (select CDS_Number from [CDS].[dbo].[Accounts_Clients]) order by id desc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
        End If
    End Sub
    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        '        If Not IsPostBack Then
        cmd = New SqlCommand("SELECT [Title]     as Title      ,[Surname]     as [Last Name]      ,[Forenames]   as [First Name]      ,[CDS_Number] as [CDS Number]      ,[IDNoPP] as [ID Number]	  ,[BrokerCode] as Broker      ,[AccountType] as [Account Type]      ,[Nationality] as [Nationality]      FROM [CDS].[dbo].[Accounts_Audit] where AuthorizationState='C' and Update_Type='NEW' order by id desc", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            grdApps.DataSource = ds.Tables(0)
        Else
            grdApps.DataSource = Nothing
        End If
        grdApps.DataBind()
        '        End If
    End Sub

    '    Public Sub getuploaded()
    '        Dim dsid2 As New DataSet
    '        cmd = New SqlCommand("select ID, Name, ContentType from accounts_documents where doc_generated='" + TXTClientID.Text + "'", cn)
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(dsid2, "jointn")
    '        If (dsid2.Tables(0).Rows.Count > 0) Then
    '            grdEvent.DataSource = dsid2
    '            grdEvent.DataBind()
    '        End If
    '    End Sub
    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged

        '        surnameText.Text = grdApps.SelectedRow.Cells(3).Text
        '        forenamesText.Text = grdApps.SelectedRow.Cells(4).Text
        '        cdsNumberText.Text = grdApps.SelectedRow.Cells(1).Text
        '        custodyText.Text = grdApps.SelectedRow.Cells(5).Text
        '        tradingText.Text = grdApps.SelectedRow.Cells(6).Text
        Dim idNumber = grdApps.SelectedRow.Cells(5).Text.Trim()
        panelSave.Visible = True

        Dim cdsNum = grdApps.SelectedRow.Cells(3).Text

        '        msgbox(grdApps.SelectedRow.Cells(4).Text)

        Try
            Dim dsid2 As New DataSet
            cmd = New SqlCommand("select ID, Name, ContentType from accounts_documents where doc_generated='" & grdApps.SelectedRow.Cells(4).Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsid2, "jointn")
            If (dsid2.Tables(0).Rows.Count > 0) Then
                GridView1.DataSource = dsid2
                GridView1.DataBind()
            End If
        Catch ex As Exception

        End Try
        '        where doc_generated='" & dr.Item("CDS_Number").ToString() & "'

        If grdApps.SelectedRow.Cells(7).Text.Trim().Equals("I") Then
            cmd = New SqlCommand("SELECT top 1 *  FROM [CDS].[dbo].[Accounts_Audit] where IDNoPP='" + idNumber + "' and AuthorizationState='C' and Update_Type='NEW' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                panelCorp.Visible = False
                jointDetails.Visible = False
                Panel2.Visible = True


                For Each dr As DataRow In ds.Tables(0).Rows
                    '                     msgbox(dr.Item("Custody").ToString())
                    '----------------------------------
                    '----------------------------------
                    Session("accT") = "I"
                    idNumtext.Text = dr.Item("IDNoPP").ToString()
                    titleText.Text = dr.Item("Title").ToString()
                    forenamesText.Text = dr.Item("Forenames").ToString()
                    surnameText.Text = dr.Item("Surname").ToString()
                    cdsNumberText.Text = dr.Item("CDS_Number").ToString()
                    dateOfBirthText.Text = dr.Item("DOB").ToString()
                    addressText.Text = dr.Item("Add_1").ToString()
                    countryText.Text = dr.Item("Country").ToString()
                    phoneText.Text = dr.Item("Tel").ToString()
                    emailText.Text = dr.Item("Email").ToString()
                    '                ,[Custody]
                    '      ,[]
                    custodyText.Text = dr.Item("Custody").ToString()

                    '                    tradingText.Text = dr.Item("Trading").ToString()
                    custodianText.Text = dr.Item("Custodian").ToString()

                    industryText.Text = dr.Item("Industry").ToString()
                    taxText.Text = dr.Item("Tax").ToString()
                    payeeText.Text = dr.Item("DivPayee").ToString()

                    '                                accountNameText.Text = dr.Item("Address").ToString()

                    bankText.Text = dr.Item("Div_Bank").ToString()
                    branchText.Text = dr.Item("Div_Branch").ToString()

                    accountText.Text = dr.Item("Div_AccountNo").ToString()
                    mobileMonetText.Text = dr.Item("mobile_money").ToString()
                    txtmobilemonephone.Text = dr.Item("mobile_number").ToString()
                    tradingStatusText.Text = dr.Item("TradingStatus").ToString()

                    genderText.Text = dr.Item("Gender").ToString()
                    clientTypeText.Text = dr.Item("Industry").ToString()
                    taxText1.Text = dr.Item("Tax").ToString()


                    indegText.Text = dr.Item("Indegnous").ToString()
                    raceText.Text = dr.Item("Race").ToString()

                    disadvantagedText.Text = dr.Item("Disadvantaged").ToString()
                    nationalityText.Text = dr.Item("Nationality").ToString()
                    nationalityByText.Text = dr.Item("NationalityBy").ToString()




                Next
            Else
                grdApps.DataSource = Nothing
            End If
        ElseIf grdApps.SelectedRow.Cells(7).Text.Trim().Equals("C") Then
            '        grdApps.DataBind()
            cmd = New SqlCommand("SELECT top 1 *  FROM [CDS].[dbo].[Accounts_Audit] where IDNoPP='" + idNumber + "' and AuthorizationState='C' and Update_Type='NEW' order by id desc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                panelCorp.Visible = True
                Panel2.Visible = False


                '                    panelCorp.Visible = False
                jointDetails.Visible = False
                '                Panel2.Visible = True

                For Each dr As DataRow In ds.Tables(0).Rows
                    Session("accT") = "C"

                    txtCdsNumber.Text = dr.Item("CDS_Number").ToString()
                    idNumtext.Text = dr.Item("IDNoPP").ToString()
                    titleText.Text = dr.Item("Title").ToString()
                    forenamesText.Text = dr.Item("Forenames").ToString()
                    txtSurname.Text = dr.Item("Surname").ToString()
                    txtOthernames.Text = dr.Item("company_code").ToString()
                    txtMiddleName.Text = dr.Item("isin").ToString()
                    txtMiddleName0.Text = dr.Item("IDNoPP").ToString()

                    txtDOB.Text = dr.Item("DOB").ToString()





                    addressText.Text = dr.Item("Add_1").ToString()
                    countryText.Text = dr.Item("Country").ToString()
                    phoneText.Text = dr.Item("Tel").ToString()
                    emailText.Text = dr.Item("Email").ToString()
                    '                ,[Custody]
                    '      ,[]
                    custodyText.Text = dr.Item("Custody").ToString()
                    '                    tradingText.Text = dr.Item("Trading").ToString()
                    custodianText.Text = dr.Item("Custodian").ToString()

                    industryText.Text = dr.Item("Industry").ToString()
                    taxText.Text = dr.Item("Tax").ToString()
                    payeeText.Text = dr.Item("DivPayee").ToString()

                    '                                accountNameText.Text = dr.Item("Address").ToString()

                    bankText.Text = dr.Item("Div_Bank").ToString()
                    branchText.Text = dr.Item("Div_Branch").ToString()

                    accountText.Text = dr.Item("Div_AccountNo").ToString()
                    mobileMonetText.Text = dr.Item("mobile_money").ToString()
                    txtmobilemonephone.Text = dr.Item("mobile_number").ToString()
                    tradingStatusText.Text = dr.Item("TradingStatus").ToString()

                    genderText.Text = dr.Item("Gender").ToString()
                    clientTypeText.Text = dr.Item("Industry").ToString()
                    taxText1.Text = dr.Item("Tax").ToString()


                    indegText.Text = dr.Item("Indegnous").ToString()
                    raceText.Text = dr.Item("Race").ToString()

                    disadvantagedText.Text = dr.Item("Disadvantaged").ToString()
                    nationalityText.Text = dr.Item("Nationality").ToString()
                    nationalityByText.Text = dr.Item("NationalityBy").ToString()
                Next
            Else
                '                grdApps.DataSource = Nothing
            End If

        ElseIf grdApps.SelectedRow.Cells(7).Text.Trim().Equals("J") Then
            panelCorp.Visible = False
            jointDetails.Visible = True
            Panel2.Visible = False

            cmd = New SqlCommand("SELECT top 1 *  FROM [CDS].[dbo].[Accounts_Audit] where IDNoPP='" + idNumber + "' and AuthorizationState='C' and Update_Type='NEW' order by id desc", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr As DataRow In ds.Tables(0).Rows
                    Session("accT") = "J"

                    cdsNumbers.Text = dr.Item("CDS_Number").ToString()
                    idNumtext.Text = dr.Item("IDNoPP").ToString()
                    titleText.Text = dr.Item("Title").ToString()
                    forenamesText.Text = dr.Item("Forenames").ToString()
                    joAccName.Text = dr.Item("Surname").ToString()
                    txtOthernames.Text = dr.Item("company_code").ToString()
                    txtMiddleName.Text = dr.Item("isin").ToString()
                    txtMiddleName0.Text = dr.Item("IDNoPP").ToString()

                    txtDOB.Text = dr.Item("DOB").ToString()





                    addressText.Text = dr.Item("Add_1").ToString()
                    countryText.Text = dr.Item("Country").ToString()
                    phoneText.Text = dr.Item("Tel").ToString()
                    emailText.Text = dr.Item("Email").ToString()
                    '                ,[Custody]
                    '      ,[]
                    custodyText.Text = dr.Item("Custody").ToString()
                    '                    tradingText.Text = dr.Item("Trading").ToString()
                    custodianText.Text = dr.Item("Custodian").ToString()

                    industryText.Text = dr.Item("Industry").ToString()
                    taxText.Text = dr.Item("Tax").ToString()
                    payeeText.Text = dr.Item("DivPayee").ToString()

                    '                                accountNameText.Text = dr.Item("Address").ToString()

                    bankText.Text = dr.Item("Div_Bank").ToString()
                    branchText.Text = dr.Item("Div_Branch").ToString()

                    accountText.Text = dr.Item("Div_AccountNo").ToString()
                    mobileMonetText.Text = dr.Item("mobile_money").ToString()
                    txtmobilemonephone.Text = dr.Item("mobile_number").ToString()
                    tradingStatusText.Text = dr.Item("TradingStatus").ToString()

                    genderText.Text = dr.Item("Gender").ToString()
                    clientTypeText.Text = dr.Item("Industry").ToString()
                    taxText1.Text = dr.Item("Tax").ToString()


                    indegText.Text = dr.Item("Indegnous").ToString()
                    raceText.Text = dr.Item("Race").ToString()

                    disadvantagedText.Text = dr.Item("Disadvantaged").ToString()
                    nationalityText.Text = dr.Item("Nationality").ToString()
                    nationalityByText.Text = dr.Item("NationalityBy").ToString()
                Next
            Else
                '                grdApps.DataSource = Nothing
            End If
        End If
        '    Public Sub getuploaded()
        '    End Sub
    End Sub
    Protected Sub Unnamed23_Click(sender As Object, e As EventArgs)
        Dim title = ""
        Dim forename = ""
        Dim surname = ""
        Dim cdsnumber = ""
        Dim dob = ""
        Dim gender = ""
        Dim address = ""
        Dim country = ""
        Dim phone = ""
        Dim email = ""

        Dim custody = ""
        Dim trading = ""
        Dim custodian = ""

        Dim industry = ""
        Dim tax = ""

        Dim payee = ""
        Dim bank = ""
        Dim branch = ""
        Dim account = ""

        Dim mobileMoney = ""
        Dim mobileNumber = ""

        Dim tradingStatus = ""
        Dim clientType = ""

        Dim indeg = ""
        Dim race = ""
        Dim disadvantaged = ""
        Dim nationality = ""
        Dim nationalityBy = ""
        Dim idNum = ""


        '-------------VALIDATION---------------'
        '        address = addressText.Text
        '        country = countryText.Text
        '        phone = phoneText.Text
        '        email = emailText.Text
        '        idNum = idNumtext.Text
        '        indeg = indegText.Text
        '        race = raceText.Text
        '        disadvantaged = disadvantagedText.Text


        If Session("accT").ToString().Equals("I") Then
            cdsnumber = cdsNumberText.Text
            '            msgbox("Individual")

        ElseIf Session("accT").ToString().Equals("C") Then
            cdsnumber = txtCdsNumber.Text
            '            msgbox("Corp")
        ElseIf Session("accT").ToString().Equals("J") Then
            cdsnumber = cdsNumbers.Text
            '            msgbox("Joint")
        End If

        Dim CDS_Number = ""
        Dim BrokerCode = ""
        Dim AccountType = ""
        Dim Surname1 = ""
        Dim Forenames = ""
        Dim Title1 = ""
        Dim IDNoPP = ""
        Dim IDtype = ""
        Dim Nationality1 = ""
        Dim DOB1 = ""
        Dim Gender1 = ""
        Dim Add_1 = ""
        Dim Country1 = ""
        Dim Tel = ""
        Dim Mobile = ""
        Dim Email1 = ""
        Dim Category = ""
        Dim Custodian1 = ""
        Dim TradingStatus1 = ""
        Dim Industry1 = ""
        Dim Tax1 = ""
        Dim Div_Bank = ""
        Dim Div_Branch = ""
        Dim Div_AccountNo = ""
        Dim Date_Created = ""
        Dim Update_Type = ""
        Dim Created_By = ""
        Dim AuthorizationState = ""
        Dim DivPayee = ""
        Dim isin = ""
        Dim company_code = ""
        Dim mobile_money = ""
        Dim mobile_number = ""
        Dim Indegnous = ""
        Dim Race1 = ""
        Dim Disadvantaged1 = ""
        Dim NationalityBy1 = ""
        Dim Custody1 = ""
        Dim Trading1 = ""


        '        msgbox("Here")

        '            If (Len(title) < 1) Then
        '                msgbox("Please enter a valid Id Title")
        '                titleText.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(forename) < 1) Then
        '                msgbox("Please enter a valid Forenames")
        '                forenamesText.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(surname) < 1) Then
        '                msgbox("Please enter a valid Surname")
        '                surnameText.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(cdsnumber) < 1) Then
        '                msgbox("Please enter a valid CDS Number")
        '                cdsNumberText.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(dob) < 1) Then
        '                msgbox("Please enter a valid Date of Birth")
        '                genderText.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(gender) < 1) Then
        '                msgbox("Please select gender")
        '                genderText.Focus()
        '                Exit Sub
        '            End If
        '        ElseIf Session("accT").ToString().Equals("C") Then
        '            cdsnumber = txtCdsNumber.Text
        '
        '            If (Len(txtCdsNumber.Text.Length) < 1) Then
        '                msgbox("Please enter a valid CDS Number")
        '                txtCdsNumber.Focus()
        '                Exit Sub
        '            End If
        '
        '
        '            If (Len(txtSurname.Text.Length) < 1) Then
        '                msgbox("Please enter a valid Company Name")
        '                txtSurname.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(txtOthernames.Text.Length) < 1) Then
        '                msgbox("Please enter a valid Company Code")
        '                txtOthernames.Focus()
        '                Exit Sub
        '            End If
        '
        '            If (Len(txtMiddleName.Text.Length) < 1) Then
        '                msgbox("Please enter a valid Company ISIN")
        '                txtMiddleName.Focus()
        '                Exit Sub
        '            End If
        '
        '
        '            If (Len(txtMiddleName0.Text.Length) < 1) Then
        '                msgbox("Please enter a valid Company Cert of Inc Number")
        '                txtMiddleName.Focus()
        '                Exit Sub
        '            End If
        '
        '
        '            If (Len(txtDOB.Text.Length) < 1) Then
        '                msgbox("Please enter a valid Company Date of Inc")
        '                txtMiddleName.Focus()
        '                Exit Sub
        '            End If
        '        ElseIf Session("accT").ToString().Equals("J") Then
        '
        '            cdsnumber = cdsNumbers.Text
        '            If (Len(cdsnumber.Length) < 1) Then
        '                msgbox("Please enter a valid Company Date of Inc")
        '                txtMiddleName.Focus()
        '                Exit Sub
        '            End If
        '        End If
        '
        '        custody = custodyText.Text
        '        '        trading = tradingText.Text
        '        custodian = custodianText.Text
        '
        '
        '        '
        '        '        If (Len(custody) < 1) Then
        '        '            msgbox("Please enter a valid Custody Shares")
        '        '            custodyText.Focus()
        '        '            Exit Sub
        '        '        End If
        '
        '        If (custodian.Length < 1) Then
        '            msgbox("Please enter a valid Custodian")
        '            custodianText.Focus()
        '            Exit Sub
        '        End If
        '
        '
        '        payee = payeeText.Text
        '        bank = bankText.Text
        '        branch = branchText.Text
        '        account = accountText.Text
        '
        '
        '        If (Len(payee) < 1) Then
        '            msgbox("Please enter a valid Payee")
        '            payeeText.Focus()
        '            Exit Sub
        '        End If
        '
        '        If (Len(bank) < 1) Then
        '            msgbox("Please enter a valid Bank")
        '            bankText.Focus()
        '            Exit Sub
        '        End If
        '        If (Len(branch) < 1) Then
        '            msgbox("Please enter a valid Branch")
        '            branchText.Focus()
        '            Exit Sub
        '        End If
        '
        '        If (Len(account) < 1) Then
        '            msgbox("Please enter a valid Account")
        '            accountText.Focus()
        '            Exit Sub
        '        End If
        '
        '        mobileNumber = txtmobilemonephone.Text
        '
        '      
        '
        '        tradingStatus = tradingStatusText.Text
        '        clientType = clientTypeText.Text
        '
        '
        '
        '        If (Len(tradingStatus) < 1) Then
        '            msgbox("Please enter a valid Mobile Number")
        '            '            txtmobilemonephone.Focus()
        '            Exit Sub
        '        End If
        '
        '
        '
        '



        Using Cony As New SqlConnection(constr)
            Cony.Open()
            Using Comy As New SqlCommand("select top 1 * from Accounts_Audit where CDS_Number ='" & cdsnumber & "' and Update_Type='NEW' order by id desc", Cony)
                Using RDR = Comy.ExecuteReader()
                    If RDR.HasRows Then
                        Do While RDR.Read
                            '                            msgbox("Account Successfully created")
                            CDS_Number = RDR.Item("CDS_Number").ToString()
                            BrokerCode = RDR.Item("BrokerCode").ToString()
                            AccountType = RDR.Item("AccountType").ToString()
                            Surname1 = RDR.Item("Surname").ToString()
                            Forenames = RDR.Item("Forenames").ToString()
                            Title1 = RDR.Item("Title").ToString()
                            IDNoPP = RDR.Item("IDNoPP").ToString()
                            IDtype = RDR.Item("IDtype").ToString()
                            Nationality1 = RDR.Item("Nationality").ToString()
                            DOB1 = RDR.Item("DOB").ToString()
                            Gender1 = RDR.Item("Gender").ToString()
                            Add_1 = RDR.Item("Add_1").ToString()
                            Country1 = RDR.Item("Country").ToString()
                            Tel = RDR.Item("Tel").ToString()
                            Mobile = RDR.Item("Mobile").ToString()
                            Email1 = RDR.Item("Email").ToString()
                            Category = RDR.Item("Category").ToString()
                            Custodian1 = RDR.Item("Custodian").ToString()
                            TradingStatus1 = RDR.Item("TradingStatus").ToString()
                            Industry1 = RDR.Item("Industry").ToString()
                            Tax1 = RDR.Item("Tax").ToString()
                            Div_Bank = RDR.Item("Div_Bank").ToString()
                            Div_Branch = RDR.Item("Div_Branch").ToString()
                            Div_AccountNo = RDR.Item("Div_AccountNo").ToString()
                            Date_Created = RDR.Item("Date_Created").ToString()
                            Update_Type = RDR.Item("Update_Type").ToString()
                            Created_By = RDR.Item("Created_By").ToString()
                            AuthorizationState = RDR.Item("AuthorizationState").ToString()
                            DivPayee = RDR.Item("DivPayee").ToString()
                            isin = RDR.Item("isin").ToString()
                            company_code = RDR.Item("company_code").ToString()
                            mobile_money = RDR.Item("mobile_money").ToString()
                            mobile_number = RDR.Item("mobile_number").ToString()
                            Indegnous = RDR.Item("Indegnous").ToString()
                            Race1 = RDR.Item("Race").ToString()
                            Disadvantaged1 = RDR.Item("Disadvantaged").ToString()
                            NationalityBy1 = RDR.Item("NationalityBy").ToString()
                            Custody1 = RDR.Item("Custody").ToString()
                            Trading1 = RDR.Item("Trading").ToString()
                        Loop
                    Else
                        msgbox("Not found")
                    End If
                End Using
            End Using
            Cony.Close()
        End Using

        Dim query = "INSERT INTO [CDS].[dbo].[Accounts_Clients] ([CDS_Number], [BrokerCode], [AccountType], [Surname] ,[Forenames], [Title], [IDNoPP], [IDtype], [Nationality], [DOB], [Gender], [Add_1], [Country], [Tel], [Mobile], [Email], [Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Date_Created], [Update_Type], [Created_By], [DivPayee], [isin], [company_code], [mobile_money], [mobile_number], [Indegnous], [Race], [Disadvantaged], [NationalityBy], [Custody], [Trading])  VALUES (@CDS_Number, @BrokerCode, @AccountType, @Surname ,@Forenames, @Title, @IDNoPP, @IDtype, @Nationality, @DOB, @Gender, @Add_1, @Country, @Tel, @Mobile, @Email, @Category, @Custodian, @TradingStatus, @Industry, @Tax, @Div_Bank, @Div_Branch, @Div_AccountNo, @Date_Created, @Update_Type, @Created_By, @DivPayee, @isin, @company_code, @mobile_money, @mobile_number, @Indegnous, @Race, @Disadvantaged, @NationalityBy, @Custody, @Trading)"

        Using con As New SqlConnection(constr)
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@CDS_Number", CDS_Number)
                    .Parameters.AddWithValue("@BrokerCode", BrokerCode)
                    .Parameters.AddWithValue("@AccountType", AccountType)
                    .Parameters.AddWithValue("@Surname", Surname1)
                    .Parameters.AddWithValue("@Forenames", Forenames)
                    .Parameters.AddWithValue("@Title", Title1)
                    .Parameters.AddWithValue("@IDNoPP", IDNoPP)
                    .Parameters.AddWithValue("@IDtype", IDtype)
                    .Parameters.AddWithValue("@Nationality", Nationality1)
                    .Parameters.AddWithValue("@DOB", Date.Parse(DOB1))
                    .Parameters.AddWithValue("@Gender", Gender1)
                    .Parameters.AddWithValue("@Add_1", Add_1)
                    .Parameters.AddWithValue("@Country", Country1)
                    .Parameters.AddWithValue("@Tel", Tel)
                    .Parameters.AddWithValue("@Mobile", Mobile)
                    .Parameters.AddWithValue("@Email", Email1)
                    .Parameters.AddWithValue("@Category", Category)
                    .Parameters.AddWithValue("@Custodian", Custodian1)
                    .Parameters.AddWithValue("@TradingStatus", TradingStatus1)
                    .Parameters.AddWithValue("@Industry", Industry1)
                    .Parameters.AddWithValue("@Tax", Tax1)
                    .Parameters.AddWithValue("@Div_Bank", Div_Bank)
                    .Parameters.AddWithValue("@Div_Branch", Div_Branch)
                    .Parameters.AddWithValue("@Div_AccountNo", Div_AccountNo)
                    .Parameters.AddWithValue("@Date_Created", Date.Parse(Date_Created))
                    .Parameters.AddWithValue("@Update_Type", Update_Type)
                    .Parameters.AddWithValue("@Created_By", Created_By)
                    .Parameters.AddWithValue("@DivPayee", DivPayee)
                    .Parameters.AddWithValue("@isin", isin)
                    .Parameters.AddWithValue("@company_code", company_code)
                    .Parameters.AddWithValue("@mobile_money", mobile_money)
                    .Parameters.AddWithValue("@mobile_number", mobile_number)
                    .Parameters.AddWithValue("@Indegnous", Indegnous)
                    .Parameters.AddWithValue("@Race", Race1)
                    .Parameters.AddWithValue("@Disadvantaged", Disadvantaged1)
                    .Parameters.AddWithValue("@NationalityBy", NationalityBy1)
                    .Parameters.AddWithValue("@Custody", Custody1)
                    .Parameters.AddWithValue("@Trading", Trading1)
                End With
                Try
                    con.Open()
                    com.ExecuteNonQuery()
                    '                    GETTING THE COMPANY NAME IN PARA COMPANY
                    Dim comps = ""
                    Dim certs = ""
                    Using Cony As New SqlConnection(constr)
                        Cony.Open()
                        '                        SELECT * FROM [CDS].[dbo].[AccountNewCertificates] where IdNumber ='59-145100B18'
                        Using Comy As New SqlCommand("SELECT top 1 * from [dbo].[AccountNewCertificates] where IdNumber='" & IDNoPP & "'", Cony)
                            Using RDR = Comy.ExecuteReader()
                                If RDR.HasRows Then
                                    Do While RDR.Read
                                        comps = RDR.Item("Company").ToString()
                                        '  certs = RDR.Item("CdsNumber").ToString()
                                        '                                        msgbox("Company Found")
                                    Loop
                                End If
                            End Using
                        End Using
                        Cony.Close()
                    End Using

                    '  msgbox(comps)

                    If Not String.IsNullOrEmpty(comps) Then
                        Dim queryQ = "INSERT INTO [dbo].[trans] ([Company], [CDS_Number], [Date_Created], [Trans_Time], [Shares], [Update_Type], [Created_By], [Batch_Ref], [Source], [Pledge_shares], [Reference], [Instrument], [Broker], [Custodian]) VALUES (@Company, @CDS_Number, @Date_Created, @Trans_Time, @Shares, @Update_Type, @Created_By, @Batch_Ref, @Source, @Pledge_shares, @Reference, @Instrument, @Broker, @Custodian)"
                        Using conq As New SqlConnection(constr)
                            Using comq As New SqlCommand()
                                With comq
                                    .Connection = conq
                                    .CommandType = CommandType.Text
                                    .CommandText = queryQ

                                    'msgbox("Inserting into trans")

                                    Try
                                        .Parameters.AddWithValue("@Company", comps)
                                        .Parameters.AddWithValue("@CDS_Number", CDS_Number)
                                        .Parameters.AddWithValue("@Date_Created", Date.Now)
                                        .Parameters.AddWithValue("@Trans_Time", Date.Now)
                                        .Parameters.AddWithValue("@Shares", Integer.Parse(Custody1))
                                        .Parameters.AddWithValue("@Update_Type", "DEMAT")
                                        .Parameters.AddWithValue("@Created_By", Session("Username").ToString())
                                        .Parameters.AddWithValue("@Batch_Ref", "0")
                                        .Parameters.AddWithValue("@Source", "S")
                                        .Parameters.AddWithValue("@Pledge_shares", 0)
                                        .Parameters.AddWithValue("@Reference", "")
                                        .Parameters.AddWithValue("@Instrument", "EQUITY")
                                        .Parameters.AddWithValue("@Broker", BrokerCode)
                                        .Parameters.AddWithValue("@Custodian", Custodian1)
                                    Catch ex As Exception
                                        msgbox(ex.ToString())
                                    End Try
                                End With

                                Try
                                    conq.Open()
                                    comq.ExecuteNonQuery()
                                Catch ex As SqlException
                                    msgbox(ex.ToString())
                                    '                                                    Logs(ex.ToString())
                                End Try
                            End Using
                        End Using
                    End If

                    cmd = New SqlCommand("Update Accounts_Audit set AuthorizationState='A' where CDS_Number='" & cdsnumber & "' and Update_Type='NEW'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()


                    Session("SavedSuccess") = "SavedSuccess"
                    Response.Redirect(Request.RawUrl)

                    '                    msgbox("Account Successfully created")
                    '                    Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

                Catch ex As SqlException
                    msgbox(ex.ToString())
                End Try
            End Using
        End Using


    End Sub

    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session("SavedSuccess") = ""
        Dim cdsnumber = ""

        If Session("accT").ToString().Equals("I") Then
            cdsnumber = cdsNumberText.Text
            '            msgbox("Individual")

        ElseIf Session("accT").ToString().Equals("C") Then
            cdsnumber = txtCdsNumber.Text
            '            msgbox("Corp")
        ElseIf Session("accT").ToString().Equals("J") Then
            cdsnumber = cdsNumbers.Text
            '            msgbox("Joint")
        End If


        Try
            cmd = New SqlCommand("Update [AccountNewDetails] set [Status]='0' where [CdsNumber]='" & cdsnumber & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            cmd = New SqlCommand("delete from Accounts_Audit where CDS_Number='" & cdsnumber & "' and Update_Type='NEW'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Session("SavedSuccess") = "SavedRej"
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim id As String = GridView1.SelectedRow.Cells(1).Text
        Try
            pd(id)
        Catch ex As Exception

        End Try

        Try
            word(id)
        Catch ex As Exception

        End Try

        Try
            xls(id)
        Catch ex As Exception

        End Try

        Try
            Img(id)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub pd(id As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 4
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub word(id As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub xls(id As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + id + "'"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 2
        Dim dt As DataTable = GetData(cmd)
        If dt IsNot Nothing Then
            download(dt)
        End If
    End Sub
    Public Sub Img(id As String)
        Dim strQuery As String = "select Name, ContentType, Data from accounts_documents where id='" + id + "'"
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
End Class
