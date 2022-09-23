
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class TransferSec_NewAccountCreation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Public password, numb, codec As String
    Dim dst As New DataSet

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then

            If Session("SavedSuccess") = "SavedSuccess" Then
                msgbox("Account Submitted for Approval")
            End If
            '                    Session("SavedSuccess") = ""
            Session("SavedSuccess") = ""


            If Session("finish") = "yes" Then
                msgbox("Account Successfully Sumbitted for Approval")
            End If

            Session("finish") = ""



            panelsaving0.Visible = False
            grdApps.DataSource = Nothing
            jointDetails.Visible = False
            panelCorp.Visible = False

            '                                 SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total],  [AccountType], [Date] FROM [CDS].[dbo].[AccountNewDetails] where Status=0
            cmd = New SqlCommand("SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total],  [AccountType], [Date] FROM [CDS].[dbo].[AccountNewDetails] where Status=0", cn)

            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If

            grdApps.DataBind()
            GetBankName()
            GetCountry()

            getmobilemoney()
            GetIndustry()
            getdocumenttypes()
            GetIddocs()
            GetNationality()
            GetIddocs1()
            GetNationality1()

            Try
                Dim ds2 As New DataSet
                Dim cmd1 = New SqlCommand("select distinct (bank_name) from para_bank", cn)
                Dim adp1z = New SqlDataAdapter(cmd1)
                adp1z.Fill(ds2, "para_bank")
                If (ds2.Tables(0).Rows.Count > 0) Then
                    bankText.DataSource = ds2.Tables(0)
                    bankText.DataValueField = "bank_name"
                    bankText.DataTextField = "bank_name"
                    bankText.DataBind()
                    bankText.Items.Insert(0, New ListItem(ds2.Tables(0).Rows(0).Item("bank_name").ToString(), "0"))
                    'bankText.Items.Insert(0, New ListItem("--Select Bank--", "0"))
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If
    End Sub
    Public Sub GetIndustry()
        '     If Not IsPostBack = True Then
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (fnam), code from para_industry", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_industry")
            If (ds.Tables(0).Rows.Count > 0) Then
                clientTypes.DataSource = ds.Tables(0)
                clientTypes.DataValueField = "code"
                clientTypes.DataTextField = "fnam"
                clientTypes.DataBind()
                clientTypes.Items.Insert(0, New ListItem("--Select Client Type--", "0"))
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
        '   End If

    End Sub

    Public Sub GetBankNamecash()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                bankText.DataSource = ds.Tables(0)
                bankText.DataValueField = "bank_name"
                bankText.DataTextField = "bank_name"
                bankText.DataBind()

                'bankText.Items.Insert(0, New ListItem("--Select Bank--", "0"))
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getSelectedBranchNameCash()

        Dim bank As String = ""
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_bank where bank_name='" & bankText.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                bank = ds.Tables(0).Rows(0).Item("bank").ToString
                '                msgbox(bank)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (branch_name) from para_BRANCH where bank='" & bank & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                branchText.DataSource = ds.Tables(0)
                branchText.DataValueField = "branch_name"
                branchText.DataTextField = "branch_name"
                branchText.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetBankName()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select Company_name, Company_Code FROM [CDS].[dbo].[Client_Companies] where Company_type ='CUSTODIAN'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                custodianSelect.DataSource = ds.Tables(0)
                custodianSelect.DataValueField = "Company_Code"
                custodianSelect.DataTextField = "Company_name"
                custodianSelect.DataBind()
            End If
            custodianSelect.Items.Insert(0, New ListItem("--Select Custodian--", "0"))
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Function UppercaseFirstLetter(ByVal val As String) As String
        ' Test for nothing or empty.
        If String.IsNullOrEmpty(val) Then
            Return val
        End If

        ' Convert to character array.
        Dim array() As Char = val.ToCharArray

        ' Uppercase first character.
        array(0) = Char.ToUpper(array(0))

        ' Return new string.
        Return New String(array)
    End Function

    Public Sub GetCountry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                countryText.DataSource = ds.Tables(0)
                countryText.DataValueField = "country"
                countryText.DataTextField = "country"
                countryText.DataBind()

                '                 custodianSelect.DataSource = ds.Tables(0)
                '                custodianSelect.DataValueField = "Company_Code"
                '                custodianSelect.DataTextField = "Company_name"
                '                custodianSelect.DataBind()

                '                cmbJnationality0.DataSource = ds.Tables(0)
                '                cmbJnationality0.ValueField = "country"
                '                cmbJnationality0.TextField = "country"
                '                cmbJnationality0.DataBind()

                countryText.Items.Insert(0, New ListItem("Zimbabwe", "1"))

            Else
                countryText.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged
        '        surnameText.Text = grdApps.SelectedRow.Cells(3).Text
        '        forenamesText.Text = grdApps.SelectedRow.Cells(4).Text
        cdsNumberText.Text = grdApps.SelectedRow.Cells(1).Text
        Dim idNumber = grdApps.SelectedRow.Cells(2).Text.Trim()

        Session("cdsNums") = grdApps.SelectedRow.Cells(1).Text

        Session("numb") = grdApps.SelectedRow.Cells(1).Text
        RadioButtonList1.SelectedIndex = 0


        '         msgbox(grdApps.SelectedRow.Cells(5).Text)
        '        GridView1


        If Not String.IsNullOrEmpty(grdApps.SelectedRow.Cells(5).Text) Then
            cmd = New SqlCommand("SELECT [IdNumber] as [National Id], [CertificateNumber] as [Certificate Number], [Holder] as [Shareholder Number], [Company] as [Company], [Units] as [Units]  FROM [CDS].[dbo].[AccountNewCertificates] where replace(replace(IdNumber,' ',''), '-', '') ='" + idNumber + "' order by id desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dst, "APP")
            If dst.Tables(0).Rows.Count > 0 Then
                GridView1.DataSource = dst.Tables(0)
            Else
                GridView1.DataSource = Nothing
            End If
            GridView1.DataBind()
        End If




        If grdApps.SelectedRow.Cells(6).Text.Trim().Equals("I") Then
            cmd = New SqlCommand("SELECT top 1 [Id], [IdNumber], [Shareholder], [Title], [Surname], [Forenames], [Address], [Phone], [Country], [Email], [Industry], [Tax], [Bank], [Branch], [BankAccount], [OldId], [TakeOnShares],[Lock]  FROM [CDS].[dbo].[CertNames] where replace(replace(IdNumber,' ',''), '-', '') = '" + idNumber + "'", cn)
            '            msgbox(grdApps.SelectedRow.Cells(5).Text)
            personalDetails.Visible = True
            jointDetails.Visible = False
            panelCorp.Visible = False
            Session("accType") = "I"
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Session("title") = dr.Item("Title").ToString()
                    Session("bank") = dr.Item("Bank").ToString()
                    Session("branch") = dr.Item("Branch").ToString()
                    titleText.SelectedItem.Text = dr.Item("Title").ToString()


                    Try
                        Dim ds As New DataSet
                        cmd = New SqlCommand("SELECT [bank_name] FROM [CDS].[dbo].[para_bank]  where bank='" + dr.Item("Bank").ToString().Trim + "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_bank")
                        If (ds.Tables(0).Rows.Count > 0) Then
                            '' GetBankNamecash()
                            Try
                                Dim ds2 As New DataSet
                                cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(ds2, "para_bank")
                                If (ds2.Tables(0).Rows.Count > 0) Then
                                    bankText.DataSource = ds2.Tables(0)
                                    bankText.DataValueField = "bank_name"
                                    bankText.DataTextField = "bank_name"
                                    bankText.DataBind()
                                    bankText.Items.Insert(0, New ListItem(ds.Tables(0).Rows(0).Item("bank_name").ToString(), "0"))
                                    'bankText.Items.Insert(0, New ListItem("--Select Bank--", "0"))
                                End If
                            Catch ex As Exception
                                msgbox(ex.Message)
                            End Try
                        Else
                            'WHEN THE USER"S BANK IS NOT FOUND"
                            Dim dsX As New DataSet
                            cmd = New SqlCommand("SELECT [bank_name] FROM [CDS].[dbo].[para_bank]", cn)
                            adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "para_bank")
                            If (ds.Tables(0).Rows.Count > 0) Then
                                '' GetBankNamecash()
                                Try
                                    Dim ds2 As New DataSet
                                    cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
                                    adp = New SqlDataAdapter(cmd)
                                    adp.Fill(ds2, "para_bank")
                                    If (ds2.Tables(0).Rows.Count > 0) Then
                                        bankText.DataSource = ds2.Tables(0)
                                        bankText.DataValueField = "bank_name"
                                        bankText.DataTextField = "bank_name"
                                        bankText.DataBind()
                                        bankText.Items.Insert(0, New ListItem(ds.Tables(0).Rows(0).Item("bank_name").ToString(), "0"))
                                        'bankText.Items.Insert(0, New ListItem("--Select Bank--", "0"))
                                    End If
                                Catch ex As Exception
                                    msgbox(ex.Message)
                                End Try
                            End If

                        End If
                    Catch ex As Exception
                        msgbox(ex.Message)
                    End Try

                    Try
                        Dim ds As New DataSet
                        cmd = New SqlCommand("select distinct (branch_name) from para_BRANCH where bank='" + dr.Item("Bank").ToString().Trim + "'", cn)
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_bank")
                        If (ds.Tables(0).Rows.Count > 0) Then
                            Try
                                Dim ds3 As New DataSet
                                cmd = New SqlCommand("select distinct (branch_name) from para_BRANCH where branch='" & dr.Item("Branch").ToString() & "'", cn)
                                adp = New SqlDataAdapter(cmd)
                                adp.Fill(ds3, "para_bank")
                                If (ds3.Tables(0).Rows.Count > 0) Then
                                    branchText.DataSource = ds3.Tables(0)
                                    branchText.DataValueField = "branch_name"
                                    branchText.DataTextField = "branch_name"
                                    branchText.DataBind()
                                End If
                            Catch ex As Exception
                                msgbox(ex.Message)
                            End Try

                        End If
                    Catch ex As Exception
                        msgbox(ex.Message)
                    End Try


                    '                    &nbsp;


                    If grdApps.SelectedRow.Cells(5).Text.Equals("&nbsp;") Then
                        '                        msgbox("Empty space")
                    Else
                        custodyText.Text = grdApps.SelectedRow.Cells(5).Text
                    End If
                    '                    If Not String.IsNullOrEmpty(grdApps.SelectedRow.Cells(5).Text) Then
                    '                        custodyText.Text = grdApps.SelectedRow.Cells(5).Text
                    '                    End If


                    '                    custodyText.Text = "TAPIW"
                    '                    msgbox(grdApps.SelectedRow.Cells(5).Text)
                    '                    tradingText.Text = grdApps.SelectedRow.Cells(6).Text
                    forenamesText.Text = dr.Item("Forenames").ToString()
                    surnameText.Text = dr.Item("Surname").ToString()
                    idNumtext.Text = grdApps.SelectedRow.Cells(2).Text.Trim()
                    '                    msgbox("Found")
                    '                titleText.Text = dr.Item("Title").ToString()
                    addressText.Text = dr.Item("Address").ToString()
                    '                countryText.Text = dr.Item("Country").ToString()
                    emailText.Text = dr.Item("Email").ToString()
                    phoneText.Text = dr.Item("Phone").ToString()
                    '                bankText.Text = dr.Item("Bank").ToString()
                    '                branchText.Text = dr.Item("Branch").ToString()
                    accountText.Text = dr.Item("BankAccount").ToString()
                    '                industryText.Text = dr.Item("Industry").ToString()
                    '                taxText.Text = dr.Item("Tax").ToString()
                Next
                '            grdApps.DataSource = ds.Tables(0)
            Else



                '                msgbox("Not Found")
                '                Session("title") = dr.Item("Title").ToString()
                '                Session("bank") = dr.Item("Bank").ToString()
                '                Session("branch") = dr.Item("Branch").ToString()
                Session("accType") = "I"
                idNumtext.Text = grdApps.SelectedRow.Cells(2).Text
                surnameText.Text = grdApps.SelectedRow.Cells(3).Text
                forenamesText.Text = grdApps.SelectedRow.Cells(4).Text
                cdsNumberText.Text = grdApps.SelectedRow.Cells(1).Text
                '                custodyText.Text = String.Empty
                '                custodyText.Text = "0"
                addressText.Text = ""
                phoneText.Text = ""
                emailText.Text = ""
                txtmobilemonephone.Text = ""
                accountText.Text = ""
                raceText.Text = ""


                GetBankNamecash()

                '                custodyText.Controls.Clear()
                '                custodyText.Text = grdApps.SelectedRow.Cells(5).Text
                '                tradingText.Text = grdApps.SelectedRow.Cells(6).Text
            End If


        ElseIf grdApps.SelectedRow.Cells(6).Text.Trim().Equals("J") Then
            jointDetails.Visible = True
            personalDetails.Visible = False
            panelCorp.Visible = False
            cdsNumbers.Text = grdApps.SelectedRow.Cells(1).Text.Trim()

            cmd = New SqlCommand("SELECT [Id], [IdNumber], [Shareholder], [Title], [Surname], [Forenames], [Address], [Phone], [Country], [Email], [Industry], [Tax], [Bank], [Branch], [BankAccount], [OldId], [TakeOnShares],[Lock]  FROM [CDS].[dbo].[CertNames] where Surname='" + idNumber + "'", cn)
            Session("accType") = "J"
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then


                For Each dr As DataRow In ds.Tables(0).Rows
                    Session("title") = dr.Item("Title").ToString()
                    Session("bank") = dr.Item("Bank").ToString()
                    Session("branch") = dr.Item("Branch").ToString()

                    '                    titleText.SelectedItem.Text = dr.Item("Title").ToString()
                    '                    idNumtext.Text = grdApps.SelectedRow.Cells(2).Text.Trim()
                    '                    custodyText.Text = grdApps.SelectedRow.Cells(5).Text
                    '                    If Not String.IsNullOrEmpty(grdApps.SelectedRow.Cells(5).Text) Then
                    '                        custodyText.Text = grdApps.SelectedRow.Cells(5).Text
                    '                    End If


                    If grdApps.SelectedRow.Cells(5).Text.Equals("&nbsp;") Then
                    Else
                        custodyText.Text = grdApps.SelectedRow.Cells(5).Text
                    End If
                    cdsNumbers.Text = grdApps.SelectedRow.Cells(1).Text.Trim()
                    joAccName.Text = dr.Item("Surname").ToString()
                    addressText.Text = dr.Item("Address").ToString()
                    '                countryText.Text = dr.Item("Country").ToString()
                    emailText.Text = dr.Item("Email").ToString()
                    phoneText.Text = dr.Item("Phone").ToString()
                    '                bankText.Text = dr.Item("Bank").ToString()
                    '                branchText.Text = dr.Item("Branch").ToString()
                    accountText.Text = dr.Item("BankAccount").ToString()
                    '                industryText.Text = dr.Item("Industry").ToString()
                    '                taxText.Text = dr.Item("Tax").ToString()
                Next
                '            grdApps.DataSource = ds.Tables(0)
            Else
                joAccName.Text = grdApps.SelectedRow.Cells(3).Text
                custodyText.Text = ""
                '                grdApps.DataSource = Nothing
            End If

        ElseIf grdApps.SelectedRow.Cells(6).Text.Trim().Equals("C") Then
            personalDetails.Visible = False
            jointDetails.Visible = False
            panelCorp.Visible = True
            cdsNumbers.Text = grdApps.SelectedRow.Cells(1).Text.Trim()
            Session("accType") = "C"


            Dim surname = grdApps.SelectedRow.Cells(3).Text
            txtSurname0.Text = grdApps.SelectedRow.Cells(1).Text.Trim()

            cmd = New SqlCommand("SELECT * FROM [CDS].[dbo].[AccountNewDetails] join CertNames on AccountNewDetails.Surname = CertNames.Surname where CertNames.Surname ='" + surname + "'", cn)


            '            msgbox("Looking")
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                personalDetails.Visible = False
                jointDetails.Visible = False
                panelCorp.Visible = True

                For Each dr As DataRow In ds.Tables(0).Rows
                    Session("title") = dr.Item("Title").ToString()
                    Session("bank") = dr.Item("Bank").ToString()
                    Session("branch") = dr.Item("Branch").ToString()
                    txtSurname.Text = dr.Item("Surname").ToString()
                    txtOthernames.Text = dr.Item("CompanyCode").ToString()
                    txtMiddleName.Text = dr.Item("ISIN").ToString()
                    txtMiddleName0.Text = dr.Item("IdNumber").ToString()
                    txtDOB.Text = dr.Item("DateOfInc").ToString()
                    addressText.Text = dr.Item("Address").ToString()
                    phoneText.Text = dr.Item("Phone").ToString()
                    emailText.Text = dr.Item("Email").ToString()

                Next

            Else
                cmd = New SqlCommand("SELECT top 1 * FROM [CDS].[dbo].[AccountNewDetails] where Surname ='" + surname + "'", cn)

                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    personalDetails.Visible = False
                    jointDetails.Visible = False
                    panelCorp.Visible = True

                    For Each dr As DataRow In ds.Tables(0).Rows
                        Session("title") = dr.Item("Title").ToString()
                        Session("bank") = dr.Item("Bank").ToString()
                        Session("branch") = dr.Item("Branch").ToString()
                        txtSurname.Text = dr.Item("Surname").ToString()
                        txtOthernames.Text = dr.Item("CompanyCode").ToString()
                        txtMiddleName.Text = dr.Item("ISIN").ToString()
                        txtMiddleName0.Text = dr.Item("IdNumber").ToString()
                        txtDOB.Text = dr.Item("DateOfInc").ToString()

                        '                        msgbox(dr.Item("DateOfInc").ToString())
                    Next
                End If
            End If
            custodyText.Text = grdApps.SelectedRow.Cells(5).Text
        End If
    End Sub

    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        '        SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total], [AccountType], [CompanyCode], [ISIN], [DateOfInc]  FROM [CDS].[dbo].[AccountNewDetails] where Status=0

        cmd = New SqlCommand("SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total],  [AccountType], [Date] FROM [CDS].[dbo].[AccountNewDetails] where Status=0", cn)

        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            grdApps.DataSource = ds.Tables(0)
        Else
            grdApps.DataSource = Nothing
        End If
        grdApps.DataBind()
    End Sub
    Protected Sub custodianSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles custodianSelect.SelectedIndexChanged

    End Sub
    Protected Sub branchText_SelectedIndexChanged(sender As Object, e As EventArgs) Handles branchText.SelectedIndexChanged

    End Sub
    Protected Sub bankText_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bankText.SelectedIndexChanged
        getSelectedBranchNameCash()

        '        msgbox("Something Changed")
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
    Protected Sub cmbmobilemoney_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmobilemoney.SelectedIndexChanged

    End Sub

    Public Sub getmobilemoney()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_mobile_money", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbmobilemoney.DataSource = ds
                cmbmobilemoney.TextField = "mobile_money_name"
                cmbmobilemoney.ValueField = "mobile_money_name"
                cmbmobilemoney.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub clientTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clientTypes.SelectedIndexChanged
        Dim dstax As New DataSet
        cmd = New SqlCommand(" SELECT tax from para_Industry where code='" + clientTypes.SelectedItem.Value.ToString + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dstax, "taxes")
        If (dstax.Tables(0).Rows.Count > 0) Then
            cmbTax.DataSource = dstax
            cmbTax.TextField = "tax"
            cmbTax.ValueField = "tax"
            cmbTax.DataBind()
            cmbTax.Value = dstax.Tables(0).Rows(0).Item("tax")
        End If
    End Sub

    Public Sub getdocumenttypes()
        ' Try
        Dim ds As New DataSet '
        cmd = New SqlCommand("select * from para_documenttypes", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_city")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtdocumentname.DataSource = ds
            txtdocumentname.TextField = "doocument_name"
            txtdocumentname.ValueField = "doocument_name"
            txtdocumentname.DataBind()

        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        checkupload()
        getuploaded()
        txtdocumentname.Text = ""
        msgbox("Document Uploaded")
    End Sub
    Public Sub getuploaded()


        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select id, name, contenttype from accounts_documents where doc_generated='" + Session("numb") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsid2
            ASPxGridView1.DataBind()
        End If
    End Sub
    Public Sub checkupload()
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
            Case ".xls"
                contenttype = ".xls"
                Exit Select
            Case ".xlsx"
                contenttype = ".xlsx"
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
        If Session("numb") = "" Then
            numb = 5
            codec = CreateRandomPassword(Integer.Parse(numb))
            Session("numb") = codec
        End If
        If contenttype <> String.Empty Then
            Dim fs As Stream = FileUpload1.PostedFile.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(fs.Length)

            'insert the file into database 
            Dim strQuery As String = "insert into Accounts_Documents" _
            & "(doc_generated, Name, ContentType, Data)" _
            & " values (@doc_generated,@Name, @ContentType, @Data)"
            Dim cmd As New SqlCommand(strQuery)
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = Session("numb")
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "" + txtdocumentname.Text + ""
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value _
            = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes


            InsertUpdateData(cmd)

        Else
            ' lblMessage.ForeColor = System.Drawing.Color.Red
            'ddchecklist.Items.Remove(ddchecklist.SelectedItem.Text)
            'ListBox1.Items.Add(ddchecklist.SelectedItem.Text)
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF/Excel formats")
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
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

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



                '                cmbNationality.SelectedItem.Text = ds.Tables(0).Rows(0).Item(0)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetNationality1()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Nationality) from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbJnationality0.DataSource = ds.Tables(0)
                cmbJnationality0.ValueField = "Nationality"
                cmbJnationality0.TextField = "Nationality"
                cmbJnationality0.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Unnamed23_Click(sender As Object, e As EventArgs)

        Session("SavedSuccess") = ""

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

        Dim daby As Date

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

        address = addressText.Text
        country = countryText.Text
        phone = phoneText.Text
        email = emailText.Text

        idNum = idNumtext.Text

        indeg = RadioButtonList2.SelectedValue
        race = raceText.Text
        disadvantaged = dis.SelectedValue


        If (cmbNationality.SelectedIndex > -1) Then
            nationality = cmbNationality.SelectedItem.Text
        Else
            msgbox("Please enter a valid Nationality")
            titleText.Focus()
            Exit Sub
        End If

        nationalityBy = natBy.SelectedValue

        If Session("accType").ToString().Equals("I") Then
            title = titleText.Text
            forename = forenamesText.Text
            surname = surnameText.Text
            cdsnumber = cdsNumberText.Text
            dob = dateOfBirth.Text
            gender = rbtLstRating.SelectedValue


            If (Len(title) < 1) Then
                msgbox("Please enter a valid Id Title")
                titleText.Focus()
                Exit Sub
            End If

            If (Len(forename) < 1) Then
                msgbox("Please enter a valid Forenames")
                forenamesText.Focus()
                Exit Sub
            End If

            If (Len(surname) < 1) Then
                msgbox("Please enter a valid Surname")
                surnameText.Focus()
                Exit Sub
            End If


            If (Len(dob) < 1) Then
                msgbox("Please enter a valid Date of Birth")
                dateOfBirth.Focus()
                Exit Sub
            Else
                Dim doby As Date
                If Date.TryParse(dob, doby) Then
                    If Date.Now <= doby Then
                        msgbox("Date of Birth can not be greater than today")
                        Exit Sub
                    Else
                        daby = doby
                    End If
                Else
                    msgbox("Enter valid Date")
                    Exit Sub
                End If
            End If

            If (Len(gender) < 1) Then
                msgbox("Please select gender")
                Exit Sub
            End If

        ElseIf Session("accType").ToString().Equals("J") Then

            cdsnumber = cdsNumbers.Text
            If (Len(cdsnumber) < 1) Then
                msgbox("Please enter a valid CDS Number")
                cdsNumberText.Focus()
                Exit Sub
            End If

            If (Len(joAccName.Text.Length) < 1) Then
                msgbox("Please enter a valid CDS Number")
                cdsNumberText.Focus()
                Exit Sub
            End If

        ElseIf Session("accType").ToString().Equals("C") Then
            cdsnumber = txtSurname0.Text



        End If

        custody = custodyText.Text
        '        trading = tradingText.Text
        custodian = custodianSelect.SelectedValue



        '        If (Len(custody) < 1) Then
        '            msgbox("Please enter a valid Custody Shares")
        '            custodyText.Focus()
        '            Exit Sub
        '        End If
        '
        '
        '        If (Len(trading) < 1) Then
        '            msgbox("Please enter a valid Trading Shares")
        '            tradingText.Focus()
        '            Exit Sub
        '        End If


        '        If (Len(emailText.Text) < 1) Then
        '            msgbox("Please enter a valid email address")
        '            surnameText.Focus()
        '            Exit Sub
        '        End If


        If (Len(phoneText.Text) < 1) Then
            msgbox("Please enter a valid phone number")
            surnameText.Focus()
            Exit Sub
        End If


        If (countryText.SelectedValue.Equals("0")) Then
            msgbox("Please enter a valid Country")
            countryText.Focus()
            Exit Sub
        End If



        If (bankText.SelectedValue.Equals("0")) Then
            msgbox("Please enter a valid Bank")
            custodianSelect.Focus()
            Exit Sub
        End If

        '        bankText

        If (custodian.Equals("0")) Then
            msgbox("Please enter a valid Custodian")
            custodianSelect.Focus()
            Exit Sub
        End If


        payee = payeeText.Text
        bank = bankText.SelectedValue
        branch = branchText.SelectedValue
        account = accountText.Text


        If (Len(payee) < 1) Then
            msgbox("Please enter a valid Payee")
            payeeText.Focus()
            Exit Sub
        End If

        If (Len(bank) < 1) Then
            msgbox("Please enter a valid Bank")
            bankText.Focus()
            Exit Sub
        End If
        If (Len(branch) < 1) Then
            msgbox("Please enter a valid Branch")
            branchText.Focus()
            Exit Sub
        End If

        If (Len(account) < 1) Then
            msgbox("Please enter a valid Account")
            accountText.Focus()
            Exit Sub
        End If

        '        


        mobileNumber = txtmobilemonephone.Text

        '        If (cmbmobilemoney.SelectedIndex > -1) Then
        '            mobileMoney = cmbmobilemoney.SelectedItem.Text
        '        Else
        '            msgbox("Please enter a valid Id valid Mobile Money Network")
        '            titleText.Focus()
        '            Exit Sub
        '        End If

        '        If (Len(mobileMoney) < 1) Then
        '            msgbox("Please enter a valid Mobile Money Network")
        '            cmbmobilemoney.Focus()
        '            Exit Sub
        '        End If

        '        If (Len(mobileNumber) < 1) Then
        '            msgbox("Please enter a valid Mobile Number")
        '            txtmobilemonephone.Focus()
        '            Exit Sub
        '        End If

        tradingStatus = RadioButtonList1.SelectedValue
        clientType = clientTypes.SelectedValue

        If rbtLstRating.SelectedIndex < -1 Then
            msgbox("Please select gender")
            '            dateOfBirth.Focus()
            Exit Sub
        End If

        If (Len(tradingStatus) < 1) Then
            msgbox("Please enter a valid Trading Status")
            '            txtmobilemonephone.Focus()
            Exit Sub
        End If

        If (clientTypes.SelectedValue.Equals("0")) Then
            msgbox("Please enter a valid Client Type")
            '            txtmobilemonephone.Focus()
            Exit Sub
        End If


        '       RadioButtonList2
        '       raceText
        '       dis
        '       natBy
        '       if 
        'RadioButtonList2
        If RadioButtonList2.SelectedIndex < -1 Then
            msgbox("Please select if you are an Indeginous Zimbabwean")
            '            dateOfBirth.Focus()
            Exit Sub
        End If


        If (Len(raceText.Text) < 1) Then
            msgbox("Please State your Race")
            '            dateOfBirth.Focus()
            Exit Sub
        End If


        If RadioButtonList2.SelectedValue.Length < 0 Then
            msgbox("Please select if you are an Indeginous Zimbabwean")
            '            dateOfBirth.Focus()
            Exit Sub
        End If

        If natBy.SelectedValue.Length < 0 Then
            msgbox("Please select if you were previously disadvantaged")
            '            dateOfBirth.Focus()
            Exit Sub
        End If

        '        clientTypes

        Dim accAudit As Boolean = False

        Using Cony As New SqlConnection(constr)
            Cony.Open()
            Using Comy As New SqlCommand("SELECT * from [dbo].[Accounts_Audit] where CDS_Number='" & cdsnumber & "'", Cony)
                Using RDR = Comy.ExecuteReader()
                    If RDR.HasRows Then
                        Do While RDR.Read
                            accAudit = True
                        Loop
                    End If
                End Using
            End Using
            Cony.Close()
        End Using


        If Not String.IsNullOrEmpty(Session("accType").ToString()) Then
            If Not accAudit Then
                Dim query = "INSERT INTO [dbo].[Accounts_Audit]([CDS_Number], [BrokerCode], [AccountType], [Surname], [Forenames], [Title], [IDNoPP], [IDtype],[Nationality], [DOB], [Gender], [Add_1], [Country], [Tel], [Mobile] ,[Email],[Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], Date_Created, [Update_Type], [Created_By], [AuthorizationState], DivPayee, mobile_money, mobile_number ,[Indegnous], [Race], [Disadvantaged], [NationalityBy] ,[Custody], [Trading], [isin],[company_code])  VALUES (@CdsNumber, @BrokerCode,  @AccountType, @Surname, @Forenames, @Title, @IDNoPP, @IDtype, @Nationality, @DOB, @Gender, @Add_1, @Country, @Tel, @Mobile, @Email, @Category, @Custodian, @TradingStatus, @Industry, @Tax, @Div_Bank, @Div_Branch, @Div_AccountNo, @Date_Created,  @Update_Type, @Created_By, @AuthorizationState, @DivPayee, @mobile_money,  @mobile_number, @Indegnous, @Race, @Disadvantaged, @NationalityBy, @Custody, @Trading,  @isin, @company_code)"

                ' Dim query = "INSERT INTO [dbo].[Accounts_Audit]([CDS_Number], [BrokerCode], [AccountType], [Surname], [Forenames], [Title], [IDNoPP], [Nationality], [DOB], [Gender], [Add_1], [Country], [Tel], [Mobile] ,[Email],[Category], [Custodian], [TradingStatus], [Industry], [Tax], [Div_Bank], [Div_Branch], [Div_AccountNo], [Date_Created], [Update_Type], [Created_By], [AuthorizationState], DivPayee, SettlementPayee, idnopp2, idtype2, mobile_money, mobile_number ,[Indegnous], [Race], [Disadvantaged], [NationalityBy])  VALUES (@CdsNumber, @BrokerCode, @AccountType, @Surname, @Forenames,@Title,@IDNoPP,@Nationality, @DOB, @Gender, @Add_1,@Country,@Tel, @Mobile, @Email, @Category, @Custodian, @TradingStatus, @Industry, @Tax, @Div_Bank, @Div_Branch,@Div_AccountNo, @Date_Created, @Update_Type, @Created_By, @AuthorizationState,@DivPayee, @SettlementPayee, @idnopp2, @idtype2, @mobile_money,  @mobile_number, @Indegnous, @Race, @Disadvantaged, @NationalityBy)"

                Using con As New SqlConnection(constr)
                    Using com As New SqlCommand()
                        With com
                            .Connection = con
                            .CommandType = CommandType.Text
                            .CommandText = query

                            .Parameters.AddWithValue("@BrokerCode", Session("BrokerCode").ToString())
                            .Parameters.AddWithValue("@AccountType", Session("accType").ToString())

                            If Session("accType").ToString().Equals("I") Then
                                .Parameters.AddWithValue("@CdsNumber", cdsnumber)
                                .Parameters.AddWithValue("@Surname", surname)
                                .Parameters.AddWithValue("@Forenames", forename)
                                .Parameters.AddWithValue("@Title", title)
                                .Parameters.AddWithValue("@IDNoPP", idNum)
                                .Parameters.AddWithValue("@IDtype", "NATIONAL ID")
                                .Parameters.AddWithValue("@DOB", Date.Parse(dob))
                                .Parameters.AddWithValue("@Gender", gender)

                                .Parameters.AddWithValue("@isin", "")
                                .Parameters.AddWithValue("@company_code", "")
                            ElseIf Session("accType").ToString().Equals("J") Then
                                .Parameters.AddWithValue("@CdsNumber", cdsnumber)
                                .Parameters.AddWithValue("@Surname", joAccName.Text)
                                .Parameters.AddWithValue("@Forenames", "")
                                .Parameters.AddWithValue("@Title", "")
                                .Parameters.AddWithValue("@IDNoPP", joAccName.Text)
                                .Parameters.AddWithValue("@IDtype", "NATIONAL ID")
                                .Parameters.AddWithValue("@DOB", Date.Now.ToString("yyyy-MM-dd"))
                                .Parameters.AddWithValue("@Gender", "L")
                                .Parameters.AddWithValue("@isin", "")
                                .Parameters.AddWithValue("@company_code", "")

                            ElseIf Session("accType").ToString().Equals("C") Then
                                '                        Session("cdsNums")
                                .Parameters.AddWithValue("@CdsNumber", cdsnumber)
                                .Parameters.AddWithValue("@Surname", txtSurname.Text)
                                .Parameters.AddWithValue("@Forenames", "")
                                .Parameters.AddWithValue("@Title", "")
                                .Parameters.AddWithValue("@IDNoPP", txtMiddleName0.Text)
                                .Parameters.AddWithValue("@IDtype", "CERTIFICATE OF INCORPORATION")
                                .Parameters.AddWithValue("@DOB", Date.Parse(txtDOB.Text))
                                .Parameters.AddWithValue("@Gender", "L")
                                .Parameters.AddWithValue("@isin", txtMiddleName.Text)
                                .Parameters.AddWithValue("@company_code", txtOthernames.Text)
                            End If



                            .Parameters.AddWithValue("@Nationality", nationality)
                            .Parameters.AddWithValue("@Add_1", address)
                            .Parameters.AddWithValue("@Country", country)
                            .Parameters.AddWithValue("@Tel", phone)
                            '------------------------------------------------
                            .Parameters.AddWithValue("@Mobile", phone)
                            .Parameters.AddWithValue("@Email", email)
                            .Parameters.AddWithValue("@Category", "C")
                            .Parameters.AddWithValue("@Custodian", custodian)
                            .Parameters.AddWithValue("@TradingStatus", tradingStatus)
                            .Parameters.AddWithValue("@Industry", clientTypes.SelectedValue)


                            .Parameters.AddWithValue("@Tax", cmbTax.SelectedItem.Text)
                            .Parameters.AddWithValue("@Div_Bank", bank)

                            .Parameters.AddWithValue("@Div_Branch", branch)
                            .Parameters.AddWithValue("@Div_AccountNo", account)
                            .Parameters.AddWithValue("@Date_Created", DateTime.Now.ToString("yyyy-MM-dd"))
                            .Parameters.AddWithValue("@Update_Type", "NEW")
                            .Parameters.AddWithValue("@Created_By", Session("Username").ToString())
                            .Parameters.AddWithValue("@AuthorizationState", "C")
                            .Parameters.AddWithValue("@DivPayee", payee)


                            '                    .Parameters.AddWithValue("@idtype2", "")
                            .Parameters.AddWithValue("@mobile_money", mobileMoney)
                            .Parameters.AddWithValue("@mobile_number", mobileNumber)
                            .Parameters.AddWithValue("@Indegnous", indeg)

                            .Parameters.AddWithValue("@Race", race)
                            .Parameters.AddWithValue("@Disadvantaged", disadvantaged)
                            .Parameters.AddWithValue("@NationalityBy", nationalityBy)
                            .Parameters.AddWithValue("@Custody", custody)
                            .Parameters.AddWithValue("@Trading", trading)

                        End With
                        Try
                            con.Open()
                            com.ExecuteNonQuery()

                            '                    SELECT [CdsNumber], [IdNumber], [Surname], [Forename], [Total], [AccountType], [CompanyCode], [ISIN], [DateOfInc]  FROM [CDS].[dbo].[AccountNewDetails] where Status=0

                            cmd = New SqlCommand("Update AccountNewDetails set Status=1 where CdsNumber='" & cdsnumber & "'", cn)
                            If (cn.State = ConnectionState.Open) Then
                                cn.Close()
                            End If
                            cn.Open()
                            cmd.ExecuteNonQuery()
                            cn.Close()
                            '                    Session("SavedSuccess") = "SavedSuccess"
                            '                    Response.Redirect(Request.RawUrl)
                            If Session("accType").ToString().Equals("J") Then
                                panelsaving0.Visible = True
                                personalDetails.Visible = False
                                Label2.Text = cdsnumber
                                '                        Panel4.Visible = False
                                Panel3.Visible = False
                                Panel6.Visible = False
                                Panel9.Visible = False
                                Panel7.Visible = False
                                panel8.Visible = False
                                panelSave.Visible = False

                            ElseIf Session("accType").ToString().Equals("I") Then
                                Session("SavedSuccess") = "SavedSuccess"
                                Response.Redirect(Request.RawUrl)

                            ElseIf Session("accType").ToString().Equals("C") Then
                                personalDetails.Visible = False
                                Label1.Text = cdsnumber
                                panel2.Visible = True
                                Panel3.Visible = False
                                Panel6.Visible = False
                                Panel9.Visible = False
                                Panel7.Visible = False
                                panel8.Visible = False
                                panelSave.Visible = False
                            End If
                            '                              panelsaving0.Visible = False
                        Catch ex As SqlException
                            msgbox(ex.ToString())
                        End Try
                    End Using
                End Using
            Else
                msgbox("Account Already Added")
                Response.Redirect(Request.RawUrl)
            End If
        Else
            msgbox("Error occured, please re")
        End If
    End Sub
    Public Sub clear_joint_details()
        txtJsurname0.Text = ""
        txtJforenames0.Text = ""
        txtJemail1.Text = ""
        TXTjiD3.Text = ""
        cmbJIDType0.SelectedIndex = -1
        txtJdob0.Text = ""
        rdJmale0.Checked = False
        rdJfemale0.Checked = False
        rdJNa0.Checked = False
        cmbNationality.SelectedIndex = -1

        '        txtJsurname0
        'txtJforenames0
        'txtJemail1
        'TXTjiD3
        'txtJdob0
        'cmbJIDType0
    End Sub
    Public Sub added_holders()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select id as ID, Surname+' '+Forenames as Names, IDNo as [ID Number], IDTYPE AS [ID Type], Nationality, DateofBirth as [DOB],Gender, email as [Email] from Accounts_Joint where CDSNo='" + Label2.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cust1")
        If (dsi.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsi
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = True

        End If
    End Sub

    Public Sub GetIddocs()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (type) from tbl_IdentityDocuments", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_IdentityDocuments")
            If (ds.Tables(0).Rows.Count > 0) Then
                'cmbIDType.DataSource = ds.Tables(0)
                'cmbIDType.TextField = "type"
                'cmbIDType.ValueField = "type"
                'cmbIDType.DataBind()

                'cmbIDType0.DataSource = ds.Tables(0)
                'cmbIDType0.TextField = "type"
                'cmbIDType0.ValueField = "type"
                'cmbIDType0.DataBind()

                cmbJIDType0.DataSource = ds.Tables(0)
                cmbJIDType0.TextField = "type"
                cmbJIDType0.ValueField = "type"
                cmbJIDType0.DataBind()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetIddocs1()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (type) from tbl_IdentityDocuments", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_IdentityDocuments")
            If (ds.Tables(0).Rows.Count > 0) Then
                'cmbIDType.DataSource = ds.Tables(0)
                'cmbIDType.TextField = "type"
                'cmbIDType.ValueField = "type"
                'cmbIDType.DataBind()

                'cmbIDType0.DataSource = ds.Tables(0)
                'cmbIDType0.TextField = "type"
                'cmbIDType0.ValueField = "type"
                'cmbIDType0.DataBind()

                ASPxComboBox1.DataSource = ds.Tables(0)
                ASPxComboBox1.TextField = "type"
                ASPxComboBox1.ValueField = "type"
                ASPxComboBox1.DataBind()


            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnJadd2_Click(sender As Object, e As EventArgs) Handles btnJadd2.Click
        Dim gender As String
        If rdJmale0.Checked = True Then
            gender = "Male"
        ElseIf rdJfemale0.Checked = True Then
            gender = "Female"
        Else
            gender = "Other"
        End If
        If txtJsurname0.Text <> "" And txtJforenames0.Text <> "" And TXTjiD3.Text <> "" And txtJdob0.Text <> "" And gender <> "" Then

            cmd = New SqlCommand("insert into accounts_joint (surname, forenames, idno, idtype, nationality, dateofbirth, gender, cdsno, email) values ('" + txtJsurname0.Text.ToUpper + "','" + txtJforenames0.Text.ToUpper + "','" + TXTjiD3.Text.ToUpper + "','" + cmbJIDType0.SelectedItem.Text.ToUpper + "','" + cmbNationality.SelectedItem.Text.ToUpper + "','" + txtJdob0.Text.ToUpper + "','" + gender.ToUpper + "','" + Label2.Text.ToUpper + "','" + txtJemail1.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try
                Dim m As New sendmail
                m.sendmail(emailText.Text, "No Reply.CDS Trading Account Created", " Your Joint account  has been successfully created. Enjoy our services ")
            Catch ex As Exception

            End Try

            clear_joint_details()
            added_holders()
            msgbox("Holder Added")
        End If
    End Sub
    Protected Sub btnJadd3_Click(sender As Object, e As EventArgs) Handles btnJadd3.Click
        msgbox("Account Successfully Sumbitted for Approval")
        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim gender As String
        If RadioButton1.Checked = True Then
            gender = "Male"
        ElseIf RadioButton2.Checked = True Then
            gender = "Female"
        Else
            gender = "Other"
        End If
        If ASPxTextBox1.Text <> "" And ASPxTextBox2.Text <> "" And ASPxTextBox4.Text <> "" And ASPxDateEdit1.Text <> "" And gender <> "" Then

            cmd = New SqlCommand("insert into accounts_joint (surname, forenames, idno, idtype, nationality, dateofbirth, gender, cdsno) values ('" + ASPxTextBox1.Text.ToUpper + "','" + ASPxTextBox2.Text.ToUpper + "','" + ASPxTextBox4.Text.ToUpper + "','" + ASPxComboBox1.SelectedItem.Text.ToUpper + "','" + cmbJnationality0.SelectedItem.Text.ToUpper + "','" + ASPxDateEdit1.Text.ToUpper + "','" + gender.ToUpper + "','" + Label1.Text.ToUpper + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try
                Dim m As New sendmail
                m.sendmail(ASPxTextBox3.Text, "No Reply.CDS Trading Account Created", " Your Corporate account  has been successfully created. Enjoy our services")

            Catch ex As Exception

            End Try
            clear_joint_details()

            added_holders()
            msgbox("Company Representative Added")
        End If
    End Sub
    '    Protected Sub dateOfBirth_SelectionChanged(sender As Object, e As EventArgs) Handles dateOfBirth.SelectionChanged
    '        If dateOfBirth.Text.Length < 1 Then
    '        Else
    '            msgbox("Please enter date")
    '        End If
    '    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Session("finish") = "yes"
        msgbox("Account Successfully Sumbitted for Approval")
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            'msgbox(forenamesText.Text + " " + surnameText.Text)
            'payeeText.Text = forenamesText.Text + " " + surnameText.Text
            '   If Not String.IsNullOrEmpty(forenamesText.Text) And Not String.IsNullOrEmpty(surnameText.Text) Then



            If surnameText.Text = "" Then
                payeeText.Text = joAccName.Text
            Else
                payeeText.Text = forenamesText.Text + " " + surnameText.Text
            End If
            'msgbox(forenamesText.Text + " " + surnameText.Text)
            'Else
            '    payeeText.Text = ""
            '    'msgbox("not Checked")
            'End If
        Else
        payeeText.Text = ""
        End If
    End Sub
    Public Sub clearall()
        joAccName.Text = ""
        cdsNumbers.Text = ""
        idNumtext.Text = ""
        forenamesText.Text = ""
        cdsNumberText.Text = ""
        addressText.Text = ""
        phoneText.Text = ""
        emailText.Text = ""
        payeeText.Text = ""
        accountText.Text = ""
        txtmobilemonephone.Text = ""
    End Sub
End Class
