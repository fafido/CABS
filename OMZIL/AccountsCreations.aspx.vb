Imports System.Net.Mail
Imports System.IO
Partial Class TransferSec_AccountsCreations
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetBankName()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBankDiv.DataSource = ds.Tables(0)
                cmbBankDiv.TextField = "bank_name"
                cmbBankDiv.ValueField = "bank_name"
                cmbBankDiv.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBankNamecash()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBankNameCash.DataSource = ds.Tables(0)
                cmbBankNameCash.TextField = "bank_name"
                cmbBankNameCash.ValueField = "bank_name"
                cmbBankNameCash.DataBind()

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub gETbankCode()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_bank where bank_name='" & cmbBankDiv.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblBankCode.Text = ds.Tables(0).Rows(0).Item("bank").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub gETbankCodeCash()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_bank where bank_name='" & cmbBankNameCash.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblBankCode2.Text = ds.Tables(0).Rows(0).Item("bank").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getSelectedBranchName()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (branch_name) from para_BRANCH where bank='" & lblBankCode.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBranchDiv.DataSource = ds.Tables(0)
                cmbBranchDiv.TextField = "branch_name"
                cmbBankDiv.ValueField = "branch_name"
                cmbBranchDiv.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getSelectedBranchNameCash()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (branch_name) from para_BRANCH where bank='" & lblBankCode2.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBranchCash.DataSource = ds.Tables(0)
                cmbBranchCash.TextField = "branch_name"
                cmbBranchCash.ValueField = "branch_name"
                cmbBranchCash.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCity()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (city) from para_city", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCity.DataSource = ds.Tables(0)
                cmbCity.TextField = "city"
                cmbCity.ValueField = "city"
                cmbCity.DataBind()
            Else
                cmbCity.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetIndustry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (code) from para_industry", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_industry")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbIndustry.DataSource = ds.Tables(0)
                cmbIndustry.TextField = "code"
                cmbIndustry.ValueField = "code"
                cmbIndustry.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetBank()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getSelectedCity()
        Try
            Dim ds As New DataSet '
            cmd = New SqlCommand("select distinct (city) from para_city where country='" & cmbCountry.SelectedItem.ToString & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCity.DataSource = ds.Tables(0)
                cmbCity.TextField = "city"
                cmbCity.ValueField = "city"
                cmbCity.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCountry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (country) from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCountry.DataSource = ds.Tables(0)
                cmbCountry.TextField = "country"
                cmbCountry.ValueField = "country"
                cmbCountry.DataBind()
            Else
                cmbCountry.Items.Clear()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetIddocs()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (type) from tbl_IdentityDocuments", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "tbl_IdentityDocuments")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbIDType.DataSource = ds.Tables(0)
                cmbIDType.TextField = "type"
                cmbIDType.ValueField = "type"
                cmbIDType.DataBind()
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

                '                cmbNationality.SelectedItem.Text = ds.Tables(0).Rows(0).Item(0)

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSelectedNationality()
        Try
            If (cmbCountry.Items.Count > 0) Then
                If (Len(cmbCountry.SelectedItem.Text) > 0) Then
                    'msgbox("testt")
                    Dim ros As New DataSet
                    cmd = New SqlCommand("select Nationality,country from para_country where country='" & cmbCountry.SelectedItem.ToString & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    Dim dsi As New DataSet
                    adp.Fill(dsi, "para_country")
                    If (dsi.Tables(0).Rows.Count > 0) Then
                        cmbNationality.SelectedItem.Text = dsi.Tables(0).Rows(0).Item("Nationality").ToString
                    Else
                        'msgbox("test")
                    End If
                End If

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
                rdTrading.Checked = True
                rdNonControlled.Checked = True
                rdIndividual.Checked = True
                GetCountry()
                GetNationality()
                GetIddocs()
                cmbIDType.SelectedIndex = 0
                cmbNationality.SelectedIndex = cmbNationality.Items.Count - 1
                cmbCountry.SelectedIndex = cmbCountry.Items.Count - 1
                cmbCountry_SelectedIndexChanged(Me, e)
                GetBankName()
                GetBankNamecash()
                GetCity()
                cmbTax.SelectedIndex = 0
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles rdIndividual.CheckedChanged
        Try
            If (rdIndividual.Checked = True) Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False

                lblJID.Visible = False
                TXTjiD.Visible = False
                LBLJIDTYPE.Visible = False
                cmbJIDType.Visible = False
                lblJnationality.Visible = False
                cmbJnationality.Visible = False
                lblJdob.Visible = False
                txtJdob.Visible = False
                lbljGender.Visible = False
                rdJfemale.Visible = False
                rdJmale.Visible = False
                rdJNa.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdJoint_CheckedChanged(sender As Object, e As EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Then
                txtJforenames.Visible = True
                txtJsurname.Visible = True
                lblJforenames.Visible = True
                lblJSurname.Visible = True
                btnJadd.Visible = True
                grdJointAccounts.Visible = True
                lblJID.Visible = True
                TXTjiD.Visible = True
                LBLJIDTYPE.Visible = True
                cmbJIDType.Visible = True
                lblJnationality.Visible = True
                cmbJnationality.Visible = True
                lblJdob.Visible = True
                txtJdob.Visible = True
                lbljGender.Visible = True
                rdJfemale.Visible = True
                rdJmale.Visible = True
                rdJNa.Visible = True

            Else
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False

                lblJID.Visible = False
                TXTjiD.Visible = False
                LBLJIDTYPE.Visible = False
                cmbJIDType.Visible = False
                lblJnationality.Visible = False
                cmbJnationality.Visible = False
                lblJdob.Visible = False
                txtJdob.Visible = False
                lbljGender.Visible = False
                rdJfemale.Visible = False
                rdJmale.Visible = False
                rdJNa.Visible = False
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

                lblJID.Visible = False
                TXTjiD.Visible = False
                LBLJIDTYPE.Visible = False
                cmbJIDType.Visible = False
                lblJnationality.Visible = False
                cmbJnationality.Visible = False
                lblJdob.Visible = False
                txtJdob.Visible = False
                lbljGender.Visible = False
                rdJfemale.Visible = False
                rdJmale.Visible = False
                rdJNa.Visible = False
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

            lblJID.Visible = False
            TXTjiD.Visible = False
            LBLJIDTYPE.Visible = False
            cmbJIDType.Visible = False
            lblJnationality.Visible = False
            cmbJnationality.Visible = False
            lblJdob.Visible = False
            txtJdob.Visible = False
            lbljGender.Visible = False
            rdJfemale.Visible = False
            rdJmale.Visible = False
            rdJNa.Visible = False
        End If
    End Sub

    Protected Sub cmbNationality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNationality.SelectedIndexChanged

    End Sub

    Protected Sub rdControlled_CheckedChanged(sender As Object, e As EventArgs) Handles rdControlled.CheckedChanged
        Try
            If (rdControlled.Checked = True) Then
                lblCoust.Visible = True
                cmbCustodian.Visible = True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdNonControlled_CheckedChanged(sender As Object, e As EventArgs) Handles rdNonControlled.CheckedChanged
        Try
            If (rdNonControlled.Checked = True) Then
                lblCoust.Visible = False
                cmbCustodian.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
        'GetSelectedNationality()
        cmbCity.Items.Clear()
        getSelectedCity()
    End Sub

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        Try
            SaveNewAccount()
            Page_Load(Me, e)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub SaveNewAccount()
        Try
            'Validation State
            If (Len(txtSurname.Text) < 1) Then
                msgbox("Please enter a valid surname")
                txtSurname.Focus()
                Exit Sub
            End If
            If (Len(txtIDNo.Text) < 1) Then
                msgbox("Please enter a valid ID number")
                txtIDNo.Focus()
                Exit Sub
            End If
            If (Len(txtAddress1.Text) < 1) Then
                msgbox("Please enter atleast one line of the address")
                txtAddress1.Focus()
                Exit Sub
            End If
            If (Len(cmbCountry.SelectedItem.Text) < 1) Then
                msgbox("Select a valid country of origin")
                Exit Sub
            End If
            If (Len(cmbCity.Text) < 1) Then
                msgbox("Select a valid city")
                Exit Sub
            End If

            If (Len(cmbCity.SelectedItem.Text) < 1) Then
                msgbox("Select a valid city")
                Exit Sub
            End If

            If IsNumeric(txtIDNo1.Text.Substring(0, 1)) Then
                msgbox("1st Charectar of ID suffix must be Alphabetic")
                txtIDNo1.Focus()
                Exit Sub
            End If
            'msgbox("testing")
            If Not IsNumeric(txtIDNo1.Text.Substring(1, 2)) Then
                msgbox("last 2 Charectars of ID suffix must be Numeric")
                txtIDNo1.Focus()
                Exit Sub
            End If

            If Not IsNumeric(txtIDNo0.Text) Then
                msgbox("ID# body  must be Numeric")
                txtIDNo0.Focus()
                Exit Sub
            End If

            If Not IsNumeric(txtIDNo.Text) Then
                msgbox("ID# prefix must be Numeric")
                txtIDNo0.Focus()
                Exit Sub
            End If

            'End validations
            Dim Surname As String = ""
            Dim middlename As String = ""
            Dim forenames As String = ""
            Dim Address1 As String = ""
            Dim add_2 As String = ""
            Dim add_3 As String = ""
            Dim add_4 As String = ""
            Dim ID As String = ""
            If (txtSurname.Text.Contains("'")) Then
                Surname = Replace(txtSurname.Text, "'", " ")
            Else
                Surname = txtSurname.Text.ToString.ToUpper
            End If

            If (txtMiddleName.Text.Contains("'")) Then
                middlename = Replace(txtMiddleName.Text, "'", " ")
            Else
                middlename = txtMiddleName.Text.ToString.ToUpper
            End If

            If (txtOthernames.Text.Contains("'")) Then
                forenames = Replace(txtOthernames.Text, "'", " ")
            Else
                forenames = txtOthernames.Text.ToString.ToUpper
            End If

            If (txtAddress1.Text.Contains("'")) Then
                Address1 = Replace(txtAddress1.Text, "'", " ")
            Else
                Address1 = txtAddress1.Text.ToString.ToUpper
            End If

            If (txtAdd2.Text.Contains("'")) Then
                add_2 = Replace(txtAdd2.Text, "'", " ")
            Else
                add_2 = txtAdd2.Text.ToString.ToUpper
            End If

            If (txtAdd3.Text.Contains("'")) Then
                add_3 = Replace(txtAdd3.Text, "'", " ")
            Else
                add_3 = txtAdd3.Text.ToString.ToUpper
            End If

            If (txtAdd4.Text.Contains("'")) Then
                add_4 = Replace(txtAdd4.Text, "'", " ")
            Else
                add_4 = txtAdd4.Text.ToString.ToUpper
            End If

            Dim Industry As String = ""
            If (cmbIndustry.Items.Count > 0) Then
                Industry = cmbIndustry.SelectedItem.Text
            Else
                Industry = "LI"
            End If


            Dim tax As String = ""
            If (cmbTax.Items.Count > 0) Then
                tax = cmbTax.SelectedItem.Text
            Else
                tax = "00"
            End If
            If cmbCity.SelectedItem.Text = "" Then
                msgbox("Please Select City")
            End If

            Dim BankDiv As String = ""
            If (cmbBankDiv.Items.Count > 0) Then
                If (cmbBankDiv.SelectedIndex.ToString > -1) Then
                    BankDiv = cmbBankDiv.SelectedItem.Text
                Else
                    BankDiv = "NA"
                End If
            Else
                BankDiv = "NA"
            End If

            Dim BranchDiv As String = ""
            If (cmbBranchDiv.Items.Count > 0) Then
                If (cmbBankDiv.SelectedIndex.ToString > -1) Then
                    BranchDiv = cmbBranchDiv.SelectedItem.Text
                Else
                    BranchDiv = "NA"
                End If
            Else
                BranchDiv = "NA"
            End If

            Dim BankCash As String = ""
            If (cmbBankNameCash.Items.Count > 0) Then
                If (cmbBankNameCash.SelectedIndex.ToString > -1) Then
                    BankCash = cmbBankNameCash.SelectedItem.Text
                Else
                    BankCash = "NA"
                End If

            Else
                BankCash = "NA"
            End If
            'msgbox("test")
            Dim BranchCash As String = ""
            If (cmbBranchCash.Items.Count > 0) Then

                If (cmbBranchCash.SelectedIndex.ToString > -1) Then
                    BranchCash = cmbBranchCash.SelectedItem.Text
                Else
                    BranchCash = "NA"
                End If
            Else
                BranchCash = "NA"
            End If
            
            Dim cdsNo As String = ""
            Dim dsi As New DataSet
            cmd = New SqlCommand("select * from Accounts_Audit", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsi, "Accounts_Audit")
            If (dsi.Tables(0).Rows.Count > 0) Then
                Dim dsh As New DataSet
                cmd = New SqlCommand("select max(ID) as ID from Accounts_Audit", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsh, "Accounts_Audit")
                cdsNo = Session("BrokerCode").ToString & (CInt(dsh.Tables(0).Rows(0).Item("ID").ToString + 1)).ToString.PadLeft(6, "0")
            Else
                cdsNo = Session("BrokerCode").ToString & "0000001"
            End If

            Dim AccountType As String = ""
            If (rdIndividual.Checked = True) Then
                AccountType = "I"
            End If
            If (rdJoint.Checked = True) Then
                AccountType = "J"
            End If
            If (rdCorprate.Checked = True) Then
                AccountType = "C"
            End If
            If (rdBroker.Checked = True) Then
                AccountType = "B"
            End If


            Dim Gender As String = ""
            If (rdMale.Checked = True) Then
                Gender = "M"
            End If
            If (rdFemale.Checked = True) Then
                Gender = "F"
            End If
            If (rdNa.Checked = True) Then
                Gender = "N"
            End If
            Dim Category As String = ""
            If (rdControlled.Checked = True) Then
                Category = "C"
            End If
            If (rdNonControlled.Checked = True) Then
                Category = "N"
            End If
            Dim Custodian As String = ""
            If (cmbCustodian.Items.Count > 0) Then
                Custodian = cmbCustodian.SelectedItem.Text
            Else
                Custodian = ""
            End If
            'msgbox("testing")
            Dim TradingStatus As String = ""
            If (rdTrading.Checked = True) Then
                TradingStatus = "Trading"
            End If
            If (rdNonTrading.Checked = True) Then
                TradingStatus = "Non-Trading"
            End If
            Dim Title As String = ""

            If (cmbTitle.SelectedIndex.ToString > 1) Then
                Title = cmbTitle.SelectedItem.Text
            Else
                Title = ""
            End If
            ID = txtIDNo.Text + "-" + txtIDNo0.Text + "-" + txtIDNo1.Text
            If (txtIDNo.Text <> "") Then
                Dim dsid As New DataSet
                cmd = New SqlCommand("Select * from Accounts_Audit where idnopp='" & ID & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsid, "Accounts_Audit")
                If (dsid.Tables(0).Rows.Count > 0) Then
                    msgbox("Entered ID has been saved before")
                    Exit Sub
                End If
            End If
            ''msgbox("insert into Accounts_Audit (  
            'Dim dob As String
            ''Dim dy, mm, yr As Integer
            ''dy = txtDOB.Text.Substring(0, 2)
            ''mm = txtDOB.Text.Substring(3, 2)
            ''yr = txtDOB.Text.Substring(6, 4)
            ''dob = dy & "/" & mm & "/" & yr
            ''msgbox(dob)
            'dob=Format(txtDOB.Text,"MM/dd/yyyy"
            cmd = New SqlCommand("insert into Accounts_Audit (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee) values ('" & cdsNo & "','" & Session("BrokerCode") & "','" & AccountType & "','" & Surname & "','" & middlename & "','" & forenames & "','" & txtInitials.Text & "','" & Title & "','" & ID.ToString.ToUpper & "','" & cmbIDType.SelectedItem.Text & "','" & cmbNationality.SelectedItem.Text.ToString.ToUpper & "','" & FormatDateTime(txtDOB.Text, DateFormat.ShortDate) & "','" & Gender & "','" & Address1 & "','" & add_2 & "','" & add_3 & "','" & add_4 & "','" & cmbCountry.SelectedItem.Text & "','" & cmbCity.SelectedItem.Text & "','" & txtTel.Text & "','" & txtMobile.Text & "','" & txtEmail.Text.ToString.ToLower & "','" & Category & "','" & Custodian & "','" & TradingStatus & "','" & Industry & "','" & tax & "','" & BankDiv & "','" & BranchDiv & "','" & txtAccountNoDiv.Text & "','" & BankCash & "','" & BranchCash & "','" & txtAccountNoCash.Text & "','" & Now.Date & "','NEW','" & Session("username") & "','O','" & txtPayee2.Text.ToUpper & "','" & txtPayee1.Text.ToUpper & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account Saved")

            Dim code As String = ""
            code = (Convert.ToString(random.Next(10, 999999)))
            If (Len(txtEmail.Text) > 1) Then
                Dim email As String = ""

                email = txtEmail.Text

                Mail.Subject = "No Reply.CDS Trading Account Created"
                Mail.To.Add("" + email + "")
                Mail.From = New MailAddress("cdspresentation@gmail.com")
                Mail.Body = " Your account change request has been successfully received. Your account activation number: " & code & " Enjoy our services "

                'Dim SMTP As New SmtpClient("smtp.googlemail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("cdspresentation@gmail.com", "cdscompany1234")
                SMTP.Port = "587"
                SMTP.Send(Mail)
            End If

            txtAccountNoCash.Text = ""
            txtAccountNoDiv.Text = ""
            txtAdd2.Text = ""
            txtAdd3.Text = ""
            txtAdd4.Text = ""
            txtAddress1.Text = ""
            txtCDSNo.Text = ""
            txtDOB.Text = ""
            txtEmail.Text = ""
            txtIDNo.Text = ""
            txtInitials.Text = ""
            txtJdob.Text = ""
            txtJforenames.Text = ""
            TXTjiD.Text = ""
            txtJsurname.Text = ""
            txtMiddleName.Text = ""
            txtMobile.Text = ""
            txtOthernames.Text = ""
            txtSurname.Text = ""
            txtTel.Text = ""
            txtPayee1.Text = ""
            txtPayee2.Text = ""
            txtIDNo0.Text = ""
            txtIDNo1.Text = ""
            cmbBankDiv.SelectedIndex = -1
            cmbBankNameCash.SelectedIndex = -1
            cmbBranchCash.SelectedIndex = -1
            cmbBranchDiv.SelectedIndex = -1
            cmbTax.SelectedIndex = -1
            cmbCity.SelectedIndex = -1
            cmbCustodian.SelectedIndex = -1
            cmbJnationality.SelectedIndex = -1
            cmbTitle.SelectedIndex = -1
            rdIndividual.Checked = True
            rdNonControlled.Checked = True
            chkPayee1.Checked = False
            chkPayee2.Checked = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBankDiv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankDiv.SelectedIndexChanged
        gETbankCode()
        If (lblBankCode.Text <> "") Then
            getSelectedBranchName()
        End If
    End Sub

    Protected Sub cmbBankNameCash_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankNameCash.SelectedIndexChanged
        gETbankCodeCash()
        If (lblBankCode2.Text <> "") Then
            getSelectedBranchNameCash()
        End If
    End Sub

    Protected Sub ASPxCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkPayee1.CheckedChanged
        If chkPayee1.Checked = True Then
            txtPayee1.Text = txtOthernames.Text & " " & txtMiddleName.Text & " " & txtSurname.Text
        Else
            txtPayee1.Text = ""
        End If
    End Sub

    Protected Sub chkPayee2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPayee2.CheckedChanged
        If chkPayee2.Checked = True Then
            txtPayee2.Text = txtOthernames.Text & " " & txtMiddleName.Text & " " & txtSurname.Text
        Else
            txtPayee2.Text = ""
        End If
    End Sub

    Protected Sub chkPayee3_CheckedChanged(sender As Object, e As EventArgs) Handles chkDiv.CheckedChanged
        If chkDiv.Checked = True Then
            chkPayee1.Enabled = False
            cmbBankNameCash.SelectedItem = cmbBankDiv.SelectedItem
            cmbBankNameCash_SelectedIndexChanged(Me, e)
            cmbBranchCash.SelectedItem = cmbBranchDiv.SelectedItem
            txtAccountNoCash.Text = txtAccountNoDiv.Text
            txtPayee1.Text = txtPayee2.Text
        Else
            chkPayee1.Enabled = True
        End If
    End Sub

    Protected Sub txtJdob_DateChanged(sender As Object, e As EventArgs) Handles txtJdob.DateChanged
        Try
            'If (((Year)(txtDOB .Text)) < 1)

            If ((txtDOB.Date.Year - Now.Date.Year) < 2) Then
                msgbox("Are you really from the future?")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
