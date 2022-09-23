Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class TransferSec_AccountsCreations_corpB
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
    Public password, numb, codec As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
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
            cmd = New SqlCommand("select distinct (fnam), code from para_industry", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_industry")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbIndustry.DataSource = ds.Tables(0)
                cmbIndustry.TextField = "fnam"
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

                cmbJnationality0.DataSource = ds.Tables(0)
                cmbJnationality0.ValueField = "Nationality"
                cmbJnationality0.TextField = "Nationality"
                cmbJnationality0.DataBind()

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
    Public Sub getdetailsfoindividual()
        Dim ds As New DataSet
        cmd = New SqlCommand("select *,(select bank_name from para_bank where bank=certnames.bank) as newbank	  ,(select branch_name from para_branch where bank=certnames.bank and branch=certnames.branch) as newbranch from certnames where replace(idnumber,'-','')=replace('" + Request.QueryString("ID") + "','-','')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_IdentityDocuments")
        If (ds.Tables(0).Rows.Count > 0) Then
            If IsDBNull(ds.Tables(0).Rows(0).Item("surname")) Then txtSurname.Text = "" Else txtSurname.Text = ds.Tables(0).Rows(0).Item("surname")
            txtCDSNo.Text = Request.QueryString("cds")
            If IsDBNull(ds.Tables(0).Rows(0).Item("forenames")) Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("forenames")



            txtAddress1.Text = ds.Tables(0).Rows(0).Item("Address").ToString.Trim
            txtTel.Text = ds.Tables(0).Rows(0).Item("phone").ToString.Trim
            'txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString.Trim
            cmbBankDiv.Value = ds.Tables(0).Rows(0).Item("newbank").ToString.Trim
            cmbBranchDiv.Value = ds.Tables(0).Rows(0).Item("newbranch").ToString.Trim
            txtAccountNoDiv.Text = ds.Tables(0).Rows(0).Item("BankAccount").ToString.Trim
            getshares()
        Else
            TRYOTHERNAMES()

        End If

    End Sub
    Public Sub TRYOTHERNAMES()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from AccountNewDetails where replace(idnumber,'-','')=replace('" + Request.QueryString("ID") + "','-','')", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_IdentityDocuments")
        If (ds.Tables(0).Rows.Count > 0) Then
            If IsDBNull(ds.Tables(0).Rows(0).Item("surname")) Then txtSurname.Text = "" Else txtSurname.Text = ds.Tables(0).Rows(0).Item("surname")
            txtCDSNo.Text = Request.QueryString("cds")
            '         If IsDBNull(ds.Tables(0).Rows(0).Item("forename")) Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("forename")
            If IsDBNull(ds.Tables(0).Rows(0).Item("idnumber")) Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("idnumber")
            If IsDBNull(ds.Tables(0).Rows(0).Item("isin")) Then txtMiddleName.Text = "" Else txtMiddleName.Text = ds.Tables(0).Rows(0).Item("isin")
            If IsDBNull(ds.Tables(0).Rows(0).Item("dateofinc")) Then txtDOB.Text = "" Else txtDOB.Text = ds.Tables(0).Rows(0).Item("dateofinc")

            getshares()

        End If

    End Sub
    Public Sub getshares()
        Dim dst As New DataSet
        cmd = New SqlCommand("SELECT [IdNumber] as [National Id], [CertificateNumber] as [Certificate Number], [Holder] as [Shareholder Number], [Company] as [Company], [Units] as [Units]  FROM [CDS].[dbo].[AccountNewCertificates] where replace(replace(IdNumber,' ',''), '-', '') ='" + Request.QueryString("ID") + "' order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dst, "APP")
        If dst.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = dst.Tables(0)
        Else
            GridView1.DataSource = Nothing
        End If
        GridView1.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   Try
        Page.MaintainScrollPositionOnPostBack = True

        If (Not IsPostBack) Then
            checkSessionState()
            rdTrading.Checked = True
            rdControlled.Checked = True
            rdIndividual.Checked = True
            GetCountry()
            GetNationality()
            GetIddocs()
            cmbIDType.SelectedIndex = 0
            'cmbNationality.SelectedIndex = cmbNationality.Items.Count - 1
            'cmbCountry.SelectedIndex = cmbCountry.Items.Count - 1
            'cmbCountry_SelectedIndexChanged(Me, e)
            GetBankName()
            GetBankNamecash()
            '     GetCity()
            GetIndustry()
            getdocumenttypes()
            txtDOB.MaxDate = Date.UtcNow.ToString
            txtJdob0.MaxDate = Date.UtcNow.ToString

            cmbIDType.SelectedIndex = 1
            txtIDNo.Text = Request.QueryString("ID")
            validate_joint()
            getdetailsfoindividual()

            Try
                If (rdControlled.Checked = True) Then
                    lblCoust.Visible = True
                    cmbCustodian.Visible = True
                    loadcustodians()

                End If
            Catch ex As Exception
                '   msgbox(ex.Message)
            End Try
            cmbTax.SelectedIndex = 0
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Corporate Account Successfully Created")
            End If

            If Session("type") = "C" Then
                Panel8.GroupingText = "Company Details"
            End If
            If Session("type") = "B" Then
                Panel8.GroupingText = "Broker Details"
            End If


        End If
        If Request.QueryString("duplicate") = "1" Then
            msgbox("Duplicate Saved, sent for authorization by your Administrator!")
        End If
        If Session("finish") = "tes" Then
            Session("finish") = ""
            msgbox("Corporate Account Successfully Created")
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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


                Panel8.Visible = False
                Panel3.Visible = False
                Panel11.Visible = False
                Panel9.Visible = False
                Panel12.Visible = False
                Panel2.Visible = False
                Panel4.Visible = False
                panelSave.Visible = False
                ASPxButton9.Visible = False
                Panel10.Visible = True
                Panel13.Enabled = True

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdJoint_CheckedChanged(sender As Object, e As EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Then
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
                ASPxButton5.Visible = False

                msgbox("You are about to open a Joint Account, please enter the full details of the representative for the Joint Account")
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



    Protected Sub rdControlled_CheckedChanged(sender As Object, e As EventArgs) Handles rdControlled.CheckedChanged
        Try
            If (rdControlled.Checked = True) Then
                lblCoust.Visible = True
                cmbCustodian.Visible = True
                loadcustodians()

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
    Public Sub validateidnumber()
        Dim vid1 As String
        Dim vid2 As String
        Try
            vid1 = cmbIDType.SelectedItem.Text
            vid2 = cmbIDType0.SelectedItem.Text
        Catch ex As Exception
            vid2 = ""
        End Try


        If vid1 <> vid2 Then
            If (txtIDNo.Text <> "") And (txtIDNo0.Text <> "") And (vid2 <> "") Then
                Dim dsid As New DataSet
                cmd = New SqlCommand("Select * from Accounts_Audit where idnopp2='" & txtIDNo.Text & "' or idnopp='" + txtIDNo.Text + "' or idnopp2='" + txtIDNo0.Text + "' or idnopp='" + txtIDNo0.Text + "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsid, "Accounts_Audit")
                If (dsid.Tables(0).Rows.Count > 0) Then
                    Response.Redirect("duplicateaccount.aspx?id1=" + txtIDNo.Text + "&id2=" + txtIDNo0.Text + "")
                    Exit Sub
                Else
                    showpanels()

                End If
            Else
                msgbox("Please first provide all the details for the 2 identifications required!")
            End If

        Else
            msgbox("Please pick a different type of identification for the second identification")
        End If


    End Sub
    Public Sub showpanels()
        Panel8.Visible = True
        Panel3.Visible = True
        '  Panel11.Visible = True
        Panel9.Visible = True
        Panel12.Visible = True
        Panel2.Visible = False
        Panel4.Visible = True
        panelSave.Visible = True
        ASPxButton5.Visible = True
        Panel10.Visible = True
        Panel13.Enabled = False


    End Sub
    Public Sub SaveNewAccount()
        Try
            If ASPxGridView1.VisibleRowCount > 0 Then

            Else
                msgbox("Please add attachments")
                Exit Sub
            End If
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
            'If (Len(cmbCity.Text) < 1) Then
            '    msgbox("Select a valid city")
            '    Exit Sub
            'End If

            'If (Len(cmbCity.SelectedItem.Text) < 1) Then
            '    msgbox("Select a valid city")
            '    Exit Sub
            'End If

            ' ***********************************************************
            ' 14/08/2014 SJ Commenting out ID Validation for now, to check country specifics and validate with regards to country
            '************************************************************

            'If IsNumeric(txtIDNo1.Text.Substring(0, 1)) Then
            '    msgbox("1st Charectar of ID suffix must be Alphabetic")
            '    txtIDNo1.Focus()
            '    Exit Sub
            'End If
            ''msgbox("testing")
            'If Not IsNumeric(txtIDNo1.Text.Substring(1, 2)) Then
            '    msgbox("last 2 Charectars of ID suffix must be Numeric")
            '    txtIDNo1.Focus()
            '    Exit Sub
            'End If

            'If Not IsNumeric(txtIDNo0.Text) Then
            '    msgbox("ID# body  must be Numeric")
            '    txtIDNo0.Focus()
            '    Exit Sub
            'End If

            'If Not IsNumeric(txtIDNo.Text) Then
            '    msgbox("ID# prefix must be Numeric")
            '    txtIDNo0.Focus()
            '    Exit Sub
            'End If

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
            'If cmbCity.SelectedItem.Text = "" Then
            '    msgbox("Please Select City")
            'End If

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
                '  cdsNo = Session("BrokerCode").ToString & (CInt(dsh.Tables(0).Rows(0).Item("ID").ToString + 1)).ToString.PadLeft(10, "0")
                Dim password As String

                password = 3
                password = CreateRandomPassword(Integer.Parse(password))
                cdsNo = (CInt(dsh.Tables(0).Rows(0).Item("ID").ToString + 1)).ToString.PadLeft(10, "0") & Session("BrokerCode").ToString & password

            Else
                cdsNo = Session("BrokerCode").ToString & "0000001"
            End If

            Dim AccountType As String = Session("type")
            'If (rdIndividual.Checked = True) Then
            '    AccountType = "I"
            'End If
            'If (rdJoint.Checked = True) Then
            '    AccountType = "J"
            'End If
            'If (rdCorprate.Checked = True) Then
            '    AccountType = "C"
            'End If
            'If (rdBroker.Checked = True) Then
            '    AccountType = "B"
            'End If


            Dim Gender As String = "N"
            'If (rdMale.Checked = True) Then
            '    Gender = "M"
            'End If
            'If (rdFemale.Checked = True) Then
            '    Gender = "F"
            'End If
            'If (rdNa.Checked = True) Then
            '    Gender = "N"
            'End If
            Dim Category As String = ""
            If (rdControlled.Checked = True) Then
                Category = "C"
            End If
            If (rdNonControlled.Checked = True) Then
                Category = "N"
            End If
            Dim Custodian As String = ""
            Try
                If (cmbCustodian.Items.Count > 0) Then
                    Custodian = cmbCustodian.SelectedItem.Value.ToString
                Else
                    Custodian = ""
                End If
            Catch ex As Exception
                Custodian = ""
            End Try

            If rdNonControlled.Checked = True Then
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
            '*****14/08/2014 SJ Commenting out composite ID Zim style and leaving one field to capture id
            'ID = txtIDNo.Text + "-" + txtIDNo0.Text + "-" + txtIDNo1.Text
            ID = txtIDNo.Text '+ "-" + txtIDNo0.Text + "-" + txtIDNo1.Text

            ''msgbox("insert into Accounts_Audit (  
            'Dim dob As String
            ''Dim dy, mm, yr As Integer
            ''dy = txtDOB.Text.Substring(0, 2)
            ''mm = txtDOB.Text.Substring(3, 2)
            ''yr = txtDOB.Text.Substring(6, 4)
            ''dob = dy & "/" & mm & "/" & yr
            ''msgbox(dob)
            'dob=Format(txtDOB.Text,"MM/dd/yyyy"

            cmd = New SqlCommand("insert into Accounts_Audit (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, isin, company_code) values ('" & txtCDSNo.Text & "','" & Session("BrokerCode") & "','C','" & Surname & "','','','" & txtInitials.Text & "','" & Title & "','" & ID.ToString.ToUpper & "','" & cmbIDType.SelectedItem.Text & "','" & cmbNationality.SelectedItem.Text.ToString.ToUpper & "','" & FormatDateTime(txtDOB.Text, DateFormat.ShortDate) & "','" & Gender & "','" & Address1 & "','" & add_2 & "','" & add_3 & "','" & add_4 & "','" & cmbCountry.SelectedItem.Text & "','','" & txtTel.Text & "','" & txtMobile.Text & "','" & txtEmail.Text.ToString.ToLower & "','" & Category & "',(select top 1 isnull(custodian,'') from accountnewdetails where cdsnumber='" + request.querystring("cds") + "'),'" & TradingStatus & "',(select code from para_industry where fnam='" & Industry & "'),'" & tax & "','" & BankDiv & "','" & BranchDiv & "','" & txtAccountNoDiv.Text & "','" & BankCash & "','" & BranchCash & "','" & txtAccountNoCash.Text & "','" & Now.Date & "','NEW','" & Session("username") & "','O','" & txtPayee2.Text.ToUpper & "','" & txtPayee1.Text.ToUpper & "','Not Applicable','Not Applicable','" + middlename.ToUpper + "','" + forenames + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


            cmd = New SqlCommand("update accounts_documents set doc_generated='" + cdsNo + "' where doc_generated='" + Session("numb") + "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("numb") = ""

            If rdJoint.Checked = True Then
                Panel8.Visible = False
                Panel3.Visible = False
                Panel11.Visible = False
                Panel9.Visible = False
                Panel12.Visible = False
                Panel2.Visible = False
                Panel4.Visible = False
                panelSave.Visible = False
                ASPxButton9.Visible = False
                Panel10.Visible = False
                Panel13.Enabled = False
                panelsaving0.Visible = True
                panelsaving.Visible = False
                Panel13.Visible = False
                Label2.Text = cdsNo

                msgbox("Please add Company Representatives information here!")
            Else
                Panel8.Visible = False
                Panel3.Visible = False
                Panel11.Visible = False
                Panel9.Visible = False
                Panel12.Visible = False
                Panel2.Visible = False
                Panel4.Visible = False
                panelSave.Visible = False
                ASPxButton9.Visible = False
                Panel10.Visible = False
                Panel13.Enabled = False
                panelsaving0.Visible = True
                panelsaving.Visible = False
                Panel13.Visible = False
                Label2.Text = cdsNo

                msgbox("Please add Company Representatives information here!")

            End If

            Dim code As String = ""
            code = (Convert.ToString(random.Next(10, 999999)))
            If (Len(txtEmail.Text) > 1) Then

                Dim m As New sendmail
                m.sendmail(txtEmail.Text, "No Reply.CDS Trading Account Created", "Your account  has been successfully created. Enjoy our services ")
                Dim email As String = ""

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
            '***SJ 14/08/2014
            'txtIDNo0.Text = ""
            'txtIDNo1.Text = ""
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
            rdControlled.Checked = True
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
            txtPayee2.Text = txtSurname.Text
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

    Protected Sub txtAdd4_TextChanged(sender As Object, e As EventArgs) Handles txtAdd4.TextChanged

    End Sub


    Public Sub loadcustodians()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select * from client_companies where company_type='CUSTODIAN'", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cust")
        If (dsi.Tables(0).Rows.Count > 0) Then
            cmbCustodian.DataSource = dsi
            cmbCustodian.TextField = "company_name"
            cmbCustodian.DataBind()

        End If


    End Sub


    Protected Sub btnJadd0_Click(sender As Object, e As EventArgs) Handles btnJadd0.Click

        '    If rdJoint.Checked = True Then
        validate_joint()

        'Else
        'validateidnumber()
        'End If
    End Sub
    Public Sub validate_joint()

        If txtIDNo.Text <> "" Then
            showpanels_joint()
            rdControlled.Checked = True
        Else
            msgbox("Please fill the required fields")
        End If




    End Sub
    Public Sub showpanels_joint()
        Panel8.Visible = True
        Panel3.Visible = True
        '  Panel11.Visible = True
        Panel9.Visible = True
        Panel12.Visible = True
        Panel2.Visible = False
        Panel4.Visible = True
        panelSave.Visible = True
        ASPxButton9.Visible = True
        Panel10.Visible = False
        Panel13.Enabled = False


    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        Try
            SaveNewAccount()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Protected Sub btnJadd_Click(sender As Object, e As EventArgs) Handles btnJadd.Click

    End Sub

    'Protected Sub btnJadd1_Click(sender As Object, e As EventArgs) Handles btnJadd1.Click
    '    'cmd = New SqlCommand("insert into Accounts_Audit (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2) values ('" & cdsNo & "','" & Session("BrokerCode") & "','" & AccountType & "','" & Surname & "','" & middlename & "','" & forenames & "','" & txtInitials.Text & "','" & Title & "','" & ID.ToString.ToUpper & "','" & cmbIDType.SelectedItem.Text & "','" & cmbNationality.SelectedItem.Text.ToString.ToUpper & "','" & FormatDateTime(txtDOB.Text, DateFormat.ShortDate) & "','" & Gender & "','" & Address1 & "','" & add_2 & "','" & add_3 & "','" & add_4 & "','" & cmbCountry.SelectedItem.Text & "','" & cmbCity.SelectedItem.Text & "','" & txtTel.Text & "','" & txtMobile.Text & "','" & txtEmail.Text.ToString.ToLower & "','" & Category & "','" & Custodian & "','" & TradingStatus & "','" & Industry & "','" & tax & "','" & BankDiv & "','" & BranchDiv & "','" & txtAccountNoDiv.Text & "','" & BankCash & "','" & BranchCash & "','" & txtAccountNoCash.Text & "','" & Now.Date & "','NEW','" & Session("username") & "','O','" & txtPayee2.Text.ToUpper & "','" & txtPayee1.Text.ToUpper & "','" + txtIDNo0.Text + "','" + cmbIDType0.SelectedItem.Text + "')", cn)
    '    'If (cn.State = ConnectionState.Open) Then
    '    '    cn.Close()
    '    'End If
    '    'cn.Open()
    '    'cmd.ExecuteNonQuery()
    '    'cn.Close()
    'End Sub

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

            cmd = New SqlCommand("insert into accounts_joint (surname, forenames, idno, idtype, nationality, dateofbirth, gender, cdsno) values ('" + txtJsurname0.Text.ToUpper + "','" + txtJforenames0.Text.ToUpper + "','" + TXTjiD3.Text.ToUpper + "','" + cmbJIDType0.SelectedItem.Text.ToUpper + "','" + cmbJnationality0.SelectedItem.Text.ToUpper + "','" + txtJdob0.Text.ToUpper + "','" + gender.ToUpper + "','" + Request.QueryString("cds") + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try

                Dim m As New sendmail
                m.sendmail(txtEmail.Text, "No Reply.CDS Trading Account Created", " Your Corporate account  has been successfully created. Enjoy our services ")

            Catch ex As Exception

            End Try
            clear_joint_details()

            added_holders()
            msgbox("Company Representative Added")
        End If

    End Sub
    Public Sub added_holders()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select id as ID, Surname+' '+Forenames as Names, IDNo as [ID Number], IDTYPE AS [ID Type], Nationality, DateofBirth as [DOB],Gender, email from Accounts_Joint where CDSNo='" + Request.QueryString("cds") + "'", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cust1")
        If (dsi.Tables(0).Rows.Count > 0) Then
            grdJointAccounts.DataSource = dsi
            grdJointAccounts.DataBind()
            grdJointAccounts.Visible = True

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
        cmbJnationality0.SelectedIndex = -1
    End Sub

    Protected Sub btnJadd3_Click(sender As Object, e As EventArgs) Handles btnJadd3.Click
        Session("numb") = ""
        Session("finish") = "yes"
        Response.Redirect("newaccs.aspx")
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
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = request.querystring("cds")
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "" + txtdocumentname.Text + ""
            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value _
            = contenttype
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes


            InsertUpdateData(cmd)




            '  msgbox(txtbatchrefnumber.Text)







        Else
            ' lblMessage.ForeColor = System.Drawing.Color.Red
            'ddchecklist.Items.Remove(ddchecklist.SelectedItem.Text)
            'ListBox1.Items.Add(ddchecklist.SelectedItem.Text)
            msgbox("File format not recognised." _
            & " Upload Image/Word/PDF/Excel format")
        End If

    End Sub

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        checkupload()
        getuploaded()
        txtdocumentname.Text = ""
        msgbox("Document Uploaded")
    End Sub
    Public Sub getuploaded()


        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select id, name, contenttype from accounts_documents where doc_generated='" + txtCDSNo.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsid2
            ASPxGridView1.DataBind()
        End If
    End Sub
    Protected Sub cmbIndustry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIndustry.SelectedIndexChanged
        Dim dstax As New DataSet
        cmd = New SqlCommand(" SELECT tax from para_Industry where code='" + cmbIndustry.SelectedItem.Value.ToString + "'", cn)
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
End Class
