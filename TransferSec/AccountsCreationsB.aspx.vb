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
Partial Class TransferSec_AccountsCreationsB
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim constr2 As String = (System.Configuration.ConfigurationManager.AppSettings("conKshares"))
    Dim cn2 As New SqlConnection(constr2)
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
    Public Sub getcountries()

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from country_code", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "countries")
        If (ds.Tables(0).Rows.Count > 0) Then
            cmbCountry.DataSource = ds
            cmbCountry.TextField = "country"
            cmbCountry.ValueField = "country_code"
            cmbCountry.DataBind()
        End If

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
    Public Function clientcompanyid(ByVal companycode As String) As String
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select RIGHT('00000'+ISNULL(id,''),5) as ids from client_companies where company_code='" + companycode + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ids")
            If (ds.Tables(0).Rows.Count > 0) Then
                Return ds.Tables(0).Rows(0).Item("ids").ToString
            Else
                Return companycode
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function
    Public Sub gettaxes()

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
                cmbBranchDiv.ValueField = "branch_name"
                cmbBranchDiv.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getallBranchName()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (branch_name) from para_BRANCH", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_bank")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBranchDiv.DataSource = ds.Tables(0)
                cmbBranchDiv.TextField = "branch_name"
                cmbBranchDiv.ValueField = "branch_name"
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
        '     If Not IsPostBack = True Then
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
        '   End If

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

                cmbJnationality0.DataSource = ds.Tables(0)
                cmbJnationality0.ValueField = "country"
                cmbJnationality0.TextField = "country"
                cmbJnationality0.DataBind()



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
    Public Sub getdetailsfoindividual()
        Dim ds As New DataSet
        cmd = New SqlCommand("select *,(select bank_name from para_bank where bank=names.bank) as newbank	  ,(select branch_name from para_branch where bank=names.bank and branch=names.bank_branch) as newbranch from names where REPLACE(replace(idrno,'-',''),' ','')=REPLACE(replace('" + Request.QueryString("ID") + "','-',''),' ','')", cn2)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_IdentityDocuments")
        If (ds.Tables(0).Rows.Count > 0) Then
            If IsDBNull(ds.Tables(0).Rows(0).Item("surname")) Then txtSurname.Text = "" Else txtSurname.Text = ds.Tables(0).Rows(0).Item("surname")
            txtCDSNo.Text = Request.QueryString("cds")
            If IsDBNull(ds.Tables(0).Rows(0).Item("forenames")) Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("forenames")
            If IsDBNull(ds.Tables(0).Rows(0).Item("add_1")) Then txtaddress1.text = "" Else txtaddress1.text = ds.Tables(0).Rows(0).Item("add_1")
            If IsDBNull(ds.Tables(0).Rows(0).Item("add_2")) Then txtadd2.text = "" Else txtadd2.text = ds.Tables(0).Rows(0).Item("add_2")
            If IsDBNull(ds.Tables(0).Rows(0).Item("add_3")) Then txtadd3.text = "" Else txtadd3.text = ds.Tables(0).Rows(0).Item("add_3")
            If IsDBNull(ds.Tables(0).Rows(0).Item("add_4")) Then txtadd4.text = "" Else txtadd4.text = ds.Tables(0).Rows(0).Item("add_4")
            If IsDBNull(ds.Tables(0).Rows(0).Item("Bank_Ac")) Then txtAccountNoDiv.Text = "" Else txtAccountNoDiv.Text = ds.Tables(0).Rows(0).Item("Bank_Ac")

            If IsDBNull(ds.Tables(0).Rows(0).Item("tel")) Then txttel.text = "" Else txttel.text = ds.Tables(0).Rows(0).Item("tel")
            cmbTitle.Value = Replace(ds.Tables(0).Rows(0).Item("title").ToString.Trim, ".", "") + "".Trim + "."
            'txtAddress1.Text = ds.Tables(0).Rows(0).Item("add_1").ToString.Trim
            'txtAddress2.Text = ds.Tables(0).Rows(0).Item("add_2").ToString.Trim
            '  txtTel.Text = ds.Tables(0).Rows(0).Item("phone").ToString.Trim
            'txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString.Trim
            cmbBankDiv.Value = ds.Tables(0).Rows(0).Item("newbank").ToString.Trim
            cmbBranchDiv.Value = ds.Tables(0).Rows(0).Item("newbranch").ToString.Trim
            '  txtAccountNoDiv.Text = ds.Tables(0).Rows(0).Item("Bank_Acc").ToString.Trim
            getshares()
        Else
            getstatic()

        End If

    End Sub
    Public Sub Getstatic()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand(" select * from accountnewdetails where idnumber='" + Request.QueryString("ID") + "' and cdsnumber='" + Request.QueryString("cds") + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtCDSNo.Text = Request.QueryString("cds")
                txtIDNo.Text = Request.QueryString("ID")
                If IsDBNull(ds.Tables(0).Rows(0).Item("surname")) Then txtSurname.Text = "" Else txtSurname.Text = ds.Tables(0).Rows(0).Item("surname")
                If IsDBNull(ds.Tables(0).Rows(0).Item("forename")) Then txtOthernames.Text = "" Else txtOthernames.Text = ds.Tables(0).Rows(0).Item("forename")
                If IsDBNull(ds.Tables(0).Rows(0).Item("Custodian")) Then txtOthernames.Text = "" Else cmbCustodian.Text = ds.Tables(0).Rows(0).Item("Custodian")
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
                rdControlled.Checked = True
                rdIndividual.Checked = True
                GetCountry()
                GetNationality()
                GetIddocs()
                cmbIDType.SelectedIndex = -1
                'cmbNationality.SelectedIndex = cmbNationality.Items.Count - 1
                'cmbCountry.SelectedIndex = cmbCountry.Items.Count - 1
                ' cmbCountry_SelectedIndexChanged(Me, e)
                GetBankName()
                getcountries()
                GetBankNamecash()
                getallBranchName()
                '  GetCity()
                GetIndustry()
                gettaxes()
                cmbIDType.Items.Add("NATIONAL ID")
                cmbTax.SelectedIndex = 0
                cmbTax.Text = "0"
                txtDOB.MaxDate = Date.UtcNow.ToString
                txtJdob0.MaxDate = Date.UtcNow.ToString
                rdControlled.Checked = True
                ' codemobile.Text = cmbCode.SelectedValue.ToString


                Try
                    If (rdControlled.Checked = True) Then
                        lblCoust.Visible = True
                        cmbCustodian.Visible = True
                        loadcustodians()

                    End If
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
                If Session("finish") = "yes" Then
                    Session("finish") = ""
                    msgbox(" Account Successfully Created")
                End If
                If Request.QueryString("duplicate") = "1" Then
                    msgbox("Duplicate Saved, sent for authorization by your Administrator!")
                End If
                If Session("finish") = "tes" Then
                    Session("finish") = ""
                    msgbox("Joint Account Successfully Created")
                End If
                If Request.QueryString("acctype") = "I" Then
                    validateidnumber(Request.QueryString("ID"))

                    loadcustodians()
                    getmobilemoney()
                    getdocumenttypes()
                    getdetailsfoindividual()
                    cmbIDType.Value = "NATIONAL ID"
                    txtIDNo.Text = Request.QueryString("ID")
                ElseIf Request.QueryString("acctype") = "J" Then
                    Panel15.Visible = True

                    txtSurname0.Text = jointname(Request.QueryString("ID"))
                    getdetailsfoindividual()
                    rdJoint.Checked = True
                    rdIndividual.Checked = False
                    validate_joint_name()
                    loadcustodians()
                    getdocumenttypes()
                    getmobilemoney()

                    txtSurname.Text = txtSurname0.Text
                End If

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


                Panel8.Visible = False
                Panel3.Visible = False
                Panel11.Visible = True
                Panel9.Visible = False
                Panel12.Visible = False
                Panel2.Visible = False
                Panel16.Visible = False
                Panel4.Visible = False
                panelSave.Visible = False
                ASPxButton9.Visible = False
                Panel10.Visible = True
                Panel13.Enabled = True
                Response.Redirect(Request.RawUrl)
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
                Panel15.Visible = True
                Panel13.Visible = False
                txtIDNo.Text = "N/A"
                txtOthernames.Text = ""

                '   msgbox("You are about to open a Joint Account, please enter the full details of the representative for the Joint Account")
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
                Session("type") = "C"
                Response.Redirect("~/TransferSec/AccountsCreations_corp.aspx")
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
            Session("type") = "B"
            Response.Redirect("~/TransferSec/AccountsCreations_corp.aspx")
        End If
    End Sub

    Protected Sub cmbNationality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNationality.SelectedIndexChanged

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
        '    Try
        SaveNewAccount()
        Page_Load(Me, e)

        'Catch ex As Exception
        '    msgbox("Please Fill all the required fields which are marked with a red (*)!")
        'End Try
    End Sub
    Public Sub validateidnumber(ID As String)
        Dim vid1 As String
        Dim vid2 As String
        Try
            vid1 = cmbIDType.SelectedItem.Text
            vid2 = cmbIDType0.SelectedItem.Text
        Catch ex As Exception
            vid2 = ""
        End Try




        Dim dsid As New DataSet
        cmd = New SqlCommand("Select * from Accounts_Audit where idnopp2='" & ID & "' or idnopp='" + ID + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid, "Accounts_Audit")
        If (dsid.Tables(0).Rows.Count > 0) Then
            Response.Redirect("newaccs.aspx?exists=1")
            Exit Sub
        Else
            showpanels()

        End If



    End Sub
    Public Sub showpanels()
        Panel8.Visible = True
        Panel3.Visible = True
        Panel16.Visible = True
        Panel2.Visible = False
        Panel9.Visible = True
        Panel12.Visible = True
        '  Panel2.Visible = True
        Panel16.Visible = True
        Panel4.Visible = True
        panelSave.Visible = True
        ASPxButton5.Visible = True
        Panel10.Visible = True
        Panel10.Enabled = False

        Panel13.Enabled = False


    End Sub
    Public Sub SaveNewAccount()
        'Try
        'Validation State
        'If ASPxGridView1.VisibleRowCount > 0 Then

        'Else
        '    msgbox("Please add attachments")
        '    Exit Sub
        'End If
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
        Try
            If (Len(cmbCountry.SelectedItem.Text) < 1) Then
                msgbox("Select a valid country of origin")
                Exit Sub
            End If
        Catch ex As Exception
            msgbox("Please select a valid Country!")
        End Try
        Try
            '   txtMobile.Text = codemobile.Text + txtMobile.Text

            'If cmbCode.SelectedValue = "+263" And Len(txtMobile.Text) <> 13 Then

            '    msgbox("mobile not valid")
            '    Exit Sub
            'End If

            'If Len(txtMobile.Text) <= 8 Or IsNumeric(txtMobile.Text) = False Then
            '    msgbox("mobile not valid")
            '    Exit Sub
            'End If
        Catch ex As Exception
            msgbox("Please select a valid Countrycode!")
        End Try

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

        If RadioButtonList2.SelectedIndex.ToString = "-1" Then
            msgbox("Please select whether Indigenous Zimbabwean!")
            Exit Sub
        End If
        If dis.SelectedIndex.ToString = "-1" Then
            msgbox("Please select if your race was previously dis-advantaged!")
            Exit Sub
        End If
        If natBy.SelectedIndex.ToString = "-1" Then
            msgbox("Please select Nationality By!")
            Exit Sub
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

            password = 3
            password = CreateRandomPassword(Integer.Parse(password))
            cdsNo = (CInt(dsh.Tables(0).Rows(0).Item("ID").ToString + 1)).ToString.PadLeft(10, "0") & clientcompanyid(Session("BrokerCode")).ToString & password

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
        If (rdJoint0.Checked = True) Then
            AccountType = "N"
        End If



        Dim Gender As String = "N/A"

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
        Dim custod As String
        Try

            If (cmbCustodian.Items.Count > 0) Then
                Custodian = cmbCustodian.SelectedItem.Text
            Else
                Custodian = ""
            End If

            If Session("Companytype") = "CUSTODIAN" Then
                custod = Session("BrokerCode")
            Else
                custod = cmbCustodian.SelectedItem.Text
            End If
        Catch ex As Exception
            Custodian = ""
            custod = "OMCUS"
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

        Try
            If (cmbTitle.SelectedIndex.ToString > 1) Then
                Title = cmbTitle.SelectedItem.Text
            Else
                Title = ""
            End If
        Catch ex As Exception
            Title = ""
        End Try


        ID = txtIDNo.Text '+ "-" + txtIDNo0.Text + "-" + txtIDNo1.Text


        Dim Nationality As String = ""
        Try
            If (cmbNationality.Items.Count > 0) Then
                Nationality = cmbNationality.SelectedItem.Text
            Else
                Nationality = ""
            End If
        Catch ex As Exception
            Nationality = ""
        End Try



        Dim IDType2 As String = ""
        Try
            If (cmbNationality.Items.Count > 0) Then
                IDType2 = cmbIDType0.SelectedItem.Text
            Else
                IDType2 = ""
            End If
        Catch ex As Exception
            IDType2 = ""
        End Try

        Dim dob As String

        Try
            dob = FormatDateTime(txtDOB.Text, DateFormat.ShortDate)
        Catch ex As Exception
            dob = "1900-01-01"
        End Try
        '  msgbox("ttt")

        Dim titl As String
        Try
            titl = cmbTitle.SelectedItem.Text
        Catch ex As Exception
            titl = ""
        End Try

        If rdJoint.Checked = True Or rdJoint0.Checked = True Then

            cmd = New SqlCommand("insert into Accounts_Audit (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,Indegnous, Race, disadvantaged, nationalityby) values ('" & txtCDSNo.Text & "','" & Session("BrokerCode") & "','" & AccountType & "','" & Surname & "','','','','','','','','','','" & txtAddress1.Text & "','" & txtAdd2.Text & "','" & txtAdd3.Text & "','" & txtAdd4.Text & "','" & cmbCountry.SelectedItem.Text & "','','" & txtTel.Text & "','" & txtMobile.Text & "','" & txtEmail.Text.ToString.ToLower & "','" & Category & "',(select top 1 isnull(custodian,'') from accountnewdetails where cdsnumber='" + Request.QueryString("cds") + "'),'" & TradingStatus & "',(select top 1 code from para_industry where fnam='" & cmbIndustry.SelectedItem.Text & "'),(select top 1 tax from para_industry where fnam='" & cmbIndustry.SelectedItem.Text & "'),'" & BankDiv & "','" & BranchDiv & "','" & txtAccountNoDiv.Text & "','" & BankCash & "','" & BranchCash & "','" & txtAccountNoCash.Text & "','" & Now.Date & "','NEW','" & Session("username") & "','O','" & txtPayee2.Text.ToUpper & "','" & txtPayee1.Text.ToUpper & "','','','" + cmbmobilemoney.SelectedItem.Text + "','" + txtmobilemonephone.Text + "','" + RadioButtonList2.SelectedItem.Text + "', '" + raceText0.Text + "','" + dis.SelectedItem.Text + "','" + natBy.SelectedItem.Text + "')", cn)
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

            ' Sending information to Audit Log
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Created a new joint/nominee account',0,'" + cdsNo + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Catch ex As Exception

            End Try

            Session("numb") = ""
            Panel8.Visible = False
            Panel3.Visible = False
            Panel11.Visible = True
            Panel9.Visible = False
            Panel12.Visible = False
            Panel2.Visible = False
            Panel16.Visible = False
            Panel4.Visible = False
            panelSave.Visible = False
            ASPxButton9.Visible = False
            Panel10.Visible = False
            Panel13.Enabled = False
            panelsaving0.Visible = True
            panelsaving.Visible = False
            Panel13.Visible = False
            Label2.Text = cdsNo
            Panel15.Visible = False


            msgbox("Please add Members/Holders here!")


        Else
            cmd = New SqlCommand("insert into Accounts_Audit (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,Indegnous, Race, disadvantaged, nationalityby) values ('" & txtCDSNo.Text & "','" & Session("BrokerCode") & "','" & AccountType & "','" & Surname & "','" & middlename & "','" & forenames & "','" & txtInitials.Text & "','" & titl & "','" & ID.ToString.ToUpper & "','" & cmbIDType.SelectedItem.Text & "','" & Nationality.ToUpper & "','" & dob & "','" & Gender & "','" & Address1 & "','" & add_2 & "','" & add_3 & "','" & add_4 & "','" & cmbCountry.SelectedItem.Text & "','','" & txtTel.Text & "','" & txtMobile.Text & "','" & txtEmail.Text.ToString.ToLower & "','" & Category & "',(select top 1 isnull(custodian,'') from accountnewdetails where cdsnumber='" + Request.QueryString("cds") + "'),'" & TradingStatus & "',(select code from para_industry where fnam='" & Industry & "'),'" & tax & "','" & BankDiv & "','" & BranchDiv & "','" & txtAccountNoDiv.Text & "','" & BankCash & "','" & BranchCash & "','" & txtAccountNoCash.Text & "','" & Now.Date & "','NEW','" & Session("username") & "','O','" & txtPayee2.Text.ToUpper & "','" & txtPayee1.Text.ToUpper & "','','','" + cmbmobilemoney.Text + "','" + txtmobilemonephone.Text + "','" + RadioButtonList2.SelectedItem.Text + "', '" + raceText0.Text + "','" + dis.SelectedItem.Text + "','" + natBy.SelectedItem.Text + "')", cn)
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
            Try
                cmd = New SqlCommand("insert into audit_log ([userid],[date],[time],[name],[activity], [userid_2], [request_id],[Browser],[IP],[Machine],[Broker_id]) values((select id from systemusers where username='" & Session("username") & "' and companycode='" + Session("Brokercode") + "'),'" & Date.Now.Date & "','" & Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & "','" + Session("username") + "','Created a new account',0,'" + cdsNo + "','" + HttpContext.Current.Request.UserAgent + "','" + HttpContext.Current.Request.UserHostAddress + "','" + HttpContext.Current.Request.UserHostName + "','" + Session("brokercode") + "')", cn)
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
            Response.Redirect("newaccs.aspx")

            '  msgbox("insert into Accounts_Audit (CDS_Number,BrokerCode,AccountType,Surname,Middlename,Forenames,Initials,Title,IDNoPP,IDtype,Nationality,DOB,Gender,Add_1,Add_2,Add_3,Add_4,Country,City,Tel,Mobile,Email,Category,Custodian,TradingStatus,Industry,Tax,Div_Bank,Div_Branch,Div_AccountNo,Cash_Bank,Cash_Branch,Cash_AccountNo,Date_Created,Update_Type,Created_By,AuthorizationState,DivPayee,SettlementPayee,idnopp2, idtype2, mobile_money, mobile_number,Indegnous, Race, disadvantaged, nationalityby) values ('','" & Session("BrokerCode") & "',,'" & txtInitials.Text & "','" & cmbTitle.SelectedItem.Text & "','" & ID.ToString.ToUpper & "','','" & Nationality.ToUpper & "','" & dob & "','" & Gender & "','" & Address1 & "','" & add_2 & "','" & add_3 & "','" & add_4 & "','"','','" & txtTel.Text & "','" & txtMobile.Text & "','" & txtEmail.Text.ToString.ToLower & "','','','','','','','','" & txtAccountNoDiv.Text & "','','','" & txtAccountNoCash.Text & "',getdate(),'NEW','" & Session("username") & "','O','" & txtPayee2.Text.ToUpper & "','" & txtPayee1.Text.ToUpper & "','','','','" + txtmobilemonephone.Text + "')")
        End If


        Dim code As String = ""
        code = (Convert.ToString(random.Next(10, 999999)))
        Try
            If (Len(txtEmail.Text) > 1) Then

                Dim m As New sendmail
                m.sendmail(txtEmail.Text, "No Reply.CDS Trading Account Created", "Your account  has been successfully created. Enjoy our services ")

            End If
        Catch ex As Exception
        End Try
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
    Public Function jointname(ByVal idnumber As String) As String
        Dim dst As New DataSet
        cmd = New SqlCommand("select isnull(surname,'')+' '+isnull(forename,'') as name from accountnewdetails where idnumber='" + idnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dst, "APP")
        If dst.Tables(0).Rows.Count > 0 Then
            Return dst.Tables(0).Rows(0).Item("name")
        Else
            Return "No Name"
        End If
        GridView1.DataBind()

    End Function
    'Protected Sub UploadImage(CDSNumber As String)
    '    Try
    '        'Dim fileUpload1 As FileUpload = CType(Me.FindControl("fileUpload1"), FileUpload)
    '        'Make sure a file has been successfully uploaded

    '        If FileUpload1.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) OrElse FileUpload1.PostedFile.InputStream Is Nothing Then
    '            msgbox("Please Upload Valid picture file")
    '            Exit Sub
    '        End If
    '        'Make sure we are dealing with a JPG or GIF file
    '        Dim extension As String = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
    '        Dim MIMEType As String = Nothing
    '        Select Case extension
    '            Case ".gif"
    '                MIMEType = "image/gif"
    '            Case ".jpg", ".jpeg", ".jpe"
    '                MIMEType = "image/jpeg"
    '            Case ".png"
    '                MIMEType = "image/png"
    '            Case ".doc"
    '                MIMEType = "document/doc"
    '            Case ".docx"
    '                MIMEType = "document/docx"
    '            Case Else
    '                'Invalid file type uploaded
    '                msgbox("Not a Valid file format")
    '                Exit Sub
    '        End Select
    '        'Connect to the database and insert a new record into Products

    '        Dim dsi1 As New DataSet
    '        Dim myCommand = New SqlCommand("select * from Accounts_Attachments", cn)
    '        adp = New SqlDataAdapter(myCommand)
    '        adp.Fill(dsi1, "Accounts_Attachments")

    '        Const SQL As String = "INSERT INTO [Accounts_Attachments] ([CDSNumber], [MIMEType], [FileName],[Extension],[FileContent],[AttachmentType]) VALUES (@CDSNumber, @MIMEType,@FileName,@Extension, @FileContent,@AttachmentType)"
    '        myCommand = New SqlCommand(SQL, cn)
    '        myCommand.Parameters.AddWithValue("@CDSNumber", CDSNumber)
    '        myCommand.Parameters.AddWithValue("@MIMEType", MIMEType)
    '        myCommand.Parameters.AddWithValue("@FileName", FileUpload1.PostedFile.FileName)
    '        myCommand.Parameters.AddWithValue("@Extension", extension)
    '        'Load FileUpload's InputStream into Byte array
    '        Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
    '        FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)
    '        myCommand.Parameters.AddWithValue("@FileContent", imageBytes)
    '        myCommand.Parameters.AddWithValue("@AttachmentType", "AccImage")
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        myCommand.ExecuteNonQuery()
    '        cn.Close()
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    'Protected Sub UploadDoc(CDSNumber As String)
    '    Try
    '        'Dim fileUpload2 As FileUpload = CType(Me.FindControl("fileUpload2"), FileUpload)
    '        'Make sure a file has been successfully uploaded

    '        If FileUpload2.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload2.PostedFile.FileName) OrElse FileUpload2.PostedFile.InputStream Is Nothing Then
    '            msgbox("Please Upload Valid picture file")
    '            Exit Sub
    '        End If
    '        'Make sure we are dealing with a JPG or GIF file
    '        Dim extension As String = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName).ToLower()
    '        Dim MIMEType As String = Nothing
    '        Select Case extension
    '            Case ".gif"
    '                MIMEType = "image/gif"
    '            Case ".jpg", ".jpeg", ".jpe"
    '                MIMEType = "image/jpeg"
    '            Case ".png"
    '                MIMEType = "image/png"
    '            Case ".doc"
    '                MIMEType = "document/doc"
    '            Case ".docx"
    '                MIMEType = "document/docx"
    '            Case Else
    '                'Invalid file type uploaded
    '                msgbox("Not a Valid file format")
    '                Exit Sub
    '        End Select
    '        'Connect to the database and insert a new record into Products

    '        Dim dsi1 As New DataSet
    '        Dim myCommand = New SqlCommand("select * from Accounts_Attachments", cn)
    '        adp = New SqlDataAdapter(myCommand)
    '        adp.Fill(dsi1, "Accounts_Attachments")

    '        Const SQL As String = "INSERT INTO [Accounts_Attachments] ([CDSNumber], [MIMEType], [FileName],[Extension],[FileContent],[AttachmentType]) VALUES (@CDSNumber, @MIMEType,@FileName,@Extension, @FileContent,@AttachmentType)"
    '        myCommand = New SqlCommand(SQL, cn)
    '        myCommand.Parameters.AddWithValue("@CDSNumber", CDSNumber)
    '        myCommand.Parameters.AddWithValue("@MIMEType", MIMEType)
    '        myCommand.Parameters.AddWithValue("@FileName", FileUpload2.PostedFile.FileName)
    '        myCommand.Parameters.AddWithValue("@Extension", extension)
    '        'Load FileUpload's InputStream into Byte array
    '        Dim imageBytes(FileUpload2.PostedFile.InputStream.Length) As Byte
    '        FileUpload2.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)
    '        myCommand.Parameters.AddWithValue("@FileContent", imageBytes)
    '        myCommand.Parameters.AddWithValue("@AttachmentType", "AccDoc")
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        myCommand.ExecuteNonQuery()
    '        cn.Close()
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    'Protected Sub UploadBiometrics(CDSNumber As String)
    '    Try
    '        'Dim fileUpload3 As FileUpload = CType(Me.FindControl("fileUpload3"), FileUpload)
    '        'Make sure a file has been successfully uploaded

    '        If FileUpload3.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload3.PostedFile.FileName) OrElse FileUpload3.PostedFile.InputStream Is Nothing Then
    '            msgbox("Please Upload Valid picture file")
    '            Exit Sub
    '        End If
    '        'Make sure we are dealing with a JPG or GIF file
    '        Dim extension As String = System.IO.Path.GetExtension(FileUpload3.PostedFile.FileName).ToLower()
    '        Dim MIMEType As String = Nothing
    '        Select Case extension
    '            Case ".gif"
    '                MIMEType = "image/gif"
    '            Case ".jpg", ".jpeg", ".jpe"
    '                MIMEType = "image/jpeg"
    '            Case ".png"
    '                MIMEType = "image/png"
    '            Case ".doc"
    '                MIMEType = "document/doc"
    '            Case ".docx"
    '                MIMEType = "document/docx"
    '            Case Else
    '                'Invalid file type uploaded
    '                msgbox("Not a Valid file format")
    '                Exit Sub
    '        End Select
    '        'Connect to the database and insert a new record into Products

    '        Dim dsi1 As New DataSet
    '        Dim myCommand = New SqlCommand("select * from Accounts_Attachments", cn)
    '        adp = New SqlDataAdapter(myCommand)
    '        adp.Fill(dsi1, "Accounts_Attachments")

    '        Const SQL As String = "INSERT INTO [Accounts_Attachments] ([CDSNumber], [MIMEType], [FileName],[Extension],[FileContent],[AttachmentType]) VALUES (@CDSNumber, @MIMEType,@FileName,@Extension, @FileContent,@AttachmentType)"
    '        myCommand = New SqlCommand(SQL, cn)
    '        myCommand.Parameters.AddWithValue("@CDSNumber", CDSNumber)
    '        myCommand.Parameters.AddWithValue("@MIMEType", MIMEType)
    '        myCommand.Parameters.AddWithValue("@FileName", FileUpload3.PostedFile.FileName)
    '        myCommand.Parameters.AddWithValue("@Extension", extension)
    '        'Load FileUpload's InputStream into Byte array
    '        Dim imageBytes(FileUpload3.PostedFile.InputStream.Length) As Byte
    '        FileUpload3.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)
    '        myCommand.Parameters.AddWithValue("@FileContent", imageBytes)
    '        myCommand.Parameters.AddWithValue("@AttachmentType", "AccBio")
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()
    '        myCommand.ExecuteNonQuery()
    '        cn.Close()
    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
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

    Protected Sub txtAdd4_TextChanged(sender As Object, e As EventArgs) Handles txtAdd4.TextChanged

    End Sub


    Public Sub loadcustodians()
        Dim dsi As New DataSet
        cmd = New SqlCommand("select *,Company_name as [Custodian], Company_Code as [Custodian Code], adress_5 as [Country], contact_person as [Contact Person], contact_phone as [Phone]  from client_companies where company_type='CUSTODIAN' and Company_Code in (select isnull(custodian,'') from accountnewdetails where cdsnumber='" + request.Querystring("cds") + "')", cn)
        adp = New SqlDataAdapter(cmd)

        adp.Fill(dsi, "para_cust")
        If (dsi.Tables(0).Rows.Count > 0) Then
            cmbCustodian.DataSource = dsi
            cmbCustodian.TextField = "company_name"
            cmbCustodian.ValueField = "company_code"
            cmbCustodian.DataBind()

        End If


    End Sub


    Protected Sub btnJadd0_Click(sender As Object, e As EventArgs) Handles btnJadd0.Click

        If rdJoint.Checked = True Then
            validate_joint()
            loadcustodians()
            getmobilemoney()
            getdocumenttypes()
        Else
            '    validateidnumber()
            loadcustodians()
            getmobilemoney()
            getdocumenttypes()

        End If
    End Sub
    Public Sub validate_joint()
        If cmbIDType.SelectedItem.Text <> cmbIDType0.SelectedItem.Text Then
            If txtIDNo.Text <> "" And txtIDNo0.Text <> "" Then
                showpanels_joint()
            Else
                msgbox("Please fill the required fields")
            End If
        Else
            msgbox("Please select a different type of Identification")

        End If

    End Sub
    Public Sub validate_joint_name()
        Dim dsid2 As New DataSet
        cmd = New SqlCommand("select * from Accounts_audit where surname='" + txtSurname0.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointname")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            msgbox("Joint Name already exists")
        Else
            Dim dsid3 As New DataSet
            cmd = New SqlCommand("select * from Accounts_clients where surname='" + txtSurname0.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsid3, "jointname2")
            If (dsid3.Tables(0).Rows.Count > 0) Then
                msgbox("Joint Name already exists")
            Else
                showpanels_joint2()
            End If
        End If

    End Sub
    Public Sub showpanels_joint()
        Panel8.Visible = True
        Panel3.Visible = True
        Panel11.Visible = True
        Panel9.Visible = True
        Panel12.Visible = True
        Panel16.Visible = True
        Panel2.Visible = False
        Panel4.Visible = True
        panelSave.Visible = True
        ASPxButton9.Visible = True
        Panel10.Visible = True
        Panel13.Enabled = False


    End Sub
    Public Sub showpanels_joint2()
        Panel8.Visible = False
        Panel3.Visible = True
        Panel11.Visible = True
        Panel9.Visible = True
        Panel12.Visible = True
        Panel2.Visible = False
        Panel16.Visible = True
        Panel4.Visible = True
        panelSave.Visible = True
        ASPxButton9.Visible = True
        Panel10.Visible = True
        Panel13.Enabled = False


    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        '    Try
        SaveNewAccount()
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
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

            cmd = New SqlCommand("insert into accounts_joint (surname, forenames, idno, idtype, nationality, dateofbirth, gender, cdsno, email) values ('" + txtJsurname0.Text.ToUpper + "','" + txtJforenames0.Text.ToUpper + "','" + TXTjiD3.Text.ToUpper + "','" + cmbJIDType0.SelectedItem.Text.ToUpper + "','" + cmbJnationality0.SelectedItem.Text.ToUpper + "','" + txtJdob0.Text.ToUpper + "','" + gender.ToUpper + "','" + txtCDSNo.Text + "','" + txtJemail1.Text + "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Try

                Dim m As New sendmail
                m.sendmail(txtEmail.Text, "No Reply.CDS Trading Account Created", " Your Joint account  has been successfully created. Enjoy our services ")

            Catch ex As Exception

            End Try

            clear_joint_details()
            added_holders()
            msgbox("Holder Added")
        End If

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

    Protected Sub btnJadd3_Click(sender As Object, e As EventArgs) Handles btnJadd3.Click
        Session("numb") = ""
        Session("finish") = "yes"
        Response.Redirect("newaccs.aspx")
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




    Protected Sub btnJadd4_Click(sender As Object, e As EventArgs) Handles btnJadd4.Click
        If txtSurname0.Text <> "" Then

            validate_joint_name()
            loadcustodians()
            getdocumenttypes()
            getmobilemoney()

            txtSurname.Text = txtSurname0.Text
        Else
            msgbox("Please fill the required fields")
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
            cmd.Parameters.Add("@doc_generated", SqlDbType.VarChar).Value = txtCDSNo.Text
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
            & " Upload Image/Word/PDF/Excel formats")
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
        cmd = New SqlCommand("select id, name, contenttype from accounts_documents where doc_generated='" + Session("numb") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid2, "jointn")
        If (dsid2.Tables(0).Rows.Count > 0) Then
            ASPxGridView1.DataSource = dsid2
            ASPxGridView1.DataBind()
        End If
    End Sub

    Protected Sub chkmobilemoney_CheckedChanged(sender As Object, e As EventArgs) Handles chkmobilemoney.CheckedChanged
        txtmobilemonephone.Text = txtMobile.Text

    End Sub

    Protected Sub cmbIDType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIDType.SelectedIndexChanged
        'If cmbIDType.Text = "NATIONAL ID" Then
        '    txtIDNo.MaskSettings.Mask = "00000000"
        '    txtIDNo.MaskSettings.ShowHints = True
        '    txtIDNo.MaskSettings.ErrorText = "Not a valid Kenya ID"
        'Else
        '    txtIDNo.MaskSettings.Mask = ""
        '    '<MaskSettings ErrorText="Not a valid Kenya ID" Mask="00000000" ShowHints="True" />
        'End If
    End Sub

    Protected Sub rdJoint0_CheckedChanged1(sender As Object, e As EventArgs) Handles rdJoint0.CheckedChanged
        Try
            If (rdJoint0.Checked = True) Then
                txtJforenames.Visible = False
                txtJsurname.Visible = False
                lblJforenames.Visible = False
                lblJSurname.Visible = False
                btnJadd.Visible = False
                grdJointAccounts.Visible = False
                Panel16.Visible = True


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
                Panel15.Visible = True
                Panel13.Visible = False
                txtIDNo.Text = "N/A"
                txtOthernames.Text = ""
                Panel15.GroupingText = "Nominee Account Details"
                btnJadd4.Text = "Validate Nominee Account Name"
                '   msgbox("You are about to open a Joint Account, please enter the full details of the representative for the Joint Account")
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



    Protected Sub cmbTax_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTax.SelectedIndexChanged

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbIDType.Items.Clear()
            cmbIDType.Items.Add("PASSPORT")
        Else
            cmbIDType.Items.Clear()
            cmbIDType.Items.Add("NATIONAL ID")
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





End Class
