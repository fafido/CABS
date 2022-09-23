Imports System.Data
Imports System.Data.SqlClient
Partial Class BrokerMode_RejectedAccountCreation
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetHolderData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pre_names_Creation where approved=3 and brokercode='" & Session("BrokerCode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCdsNumber.DataSource = ds.Tables(0)
                cmbCdsNumber.DataValueField = "cds_number"
                cmbCdsNumber.DataBind()
            Else
                cmbCdsNumber.DataSource = Nothing
                cmbCdsNumber.DataValueField = ""
                cmbCdsNumber.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "' and Approved=3 and brokercode='" & Session("BrokerCode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtforenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString
                txtID.Text = ds.Tables(0).Rows(0).Item("IDpp").ToString
                BasicDatePicker1.SelectedDate = ds.Tables(0).Rows(0).Item("DOB").ToString
                txtAdd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtAdd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                txtadd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
                txtadd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
                cmbCountry.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                CmbCity.SelectedItem.Text = ds.Tables(0).Rows(0).Item("City").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Telephone").ToString

                txtFax.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtCell.Text = ds.Tables(0).Rows(0).Item("Cellphone").ToString
                'cmbBank.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Bank_Name").ToString
                'cmbBranch.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Branch_Name").ToString

                txtBnkAccount.Text = (ds.Tables(0).Rows(0).Item("Account").ToString)
                'cmbIndustry.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Industry").ToString
                'cmbTax.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Tax").ToString
                'cmbBroker.Text = ds.Tables(0).Rows(0).Item("Brokercode").ToString
                'cmbTitle.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Title").ToString
                txtInitials.Text = ds.Tables(0).Rows(0).Item("Initials").ToString

                txtPostal.Text = ds.Tables(0).Rows(0).Item("PostalCode").ToString
                TextBox4.Text = ds.Tables(0).Rows(0).Item("JSurname").ToString
                TextBox5.Text = ds.Tables(0).Rows(0).Item("JForenames").ToString
                TextBox7.Text = ds.Tables(0).Rows(0).Item("JEmail").ToString
                TextBox6.Text = ds.Tables(0).Rows(0).Item("JCell").ToString

                'cmbNat.SelectedItem.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString

                Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
                Image1.ImageUrl = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString
                Image1.width = "200"


                'If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "1") Then
                '    rdIndividual.Checked = True
                'End If
                'If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "2") Then
                '    rdJoint.Checked = True
                'End If
                'If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "3") Then
                '    rdNominee .Checked = True  
                'End If
                'If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "4") Then
                '    rdCompany.Checked = True
                'End If
            Else
                txtSurname.Text = ""
                txtforenames.Text = ""
                txtID.Text = ""
                BasicDatePicker1.Clear()
                txtAdd1.Text = ""
                txtAdd2.Text = ""
                txtadd3.Text = ""
                txtadd4.Text = ""


                txtTel.Text = ""
                txtFax.Text = ""
                txtEmail.Text = ""
                Image1.ImageUrl = Nothing
                txtCell.Text = ""
                txtBnkAccount.Text = ""

                txtInitials.Text = ""
                txtPostal.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SecurityDocuments()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (DocType) from SecurityDocuments", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "SecurityDocuments")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbSecurityDoc.DataSource = ds.Tables(0)
                cmbSecurityDoc.DataValueField = "DocType"
                cmbSecurityDoc.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBrokers()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (fnam), broker_code from para_broker order by broker_code", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBroker.DataSource = ds.Tables(0)
                cmbBroker.DataValueField = "fnam"
                cmbBroker.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If

            Dim AccType As String = ""
            'If (rdIndividual.Checked = False) And (rdJoint.Checked = False) And (rdNominee.Checked = False) And (rdCompany.Checked = False) Then
            '    msgbox("Select an AccountType")
            '    Exit Sub
            'End If
            If (txtSurname.Text = "") Then
                msgbox("Enter a holder's Name/Last Name")
                Exit Sub
            End If
            If (txtID.Text = "") Then
                msgbox("Enter a shareholder's id number/Company Registration ")
                Exit Sub
            End If
            If (txtAdd1.Text = "") Then
                msgbox("Enter Address")
                Exit Sub
            End If
            If (chkBank.Checked = True) Then
                If (txtBnkAccount.Text = "") Then
                    msgbox("Enter a bank account Number")
                    Exit Sub
                End If
            End If
            'If (rdIndividual.Checked = True) Then
            '    AccType = "1"
            'End If
            'If (rdJoint.Checked = True) Then
            '    AccType = "2"
            'End If
            'If (rdNominee.Checked = True) Then
            '    AccType = "3"
            'End If
            'If (rdCompany.Checked = True) Then
            '    AccType = "4"
            'End If
            'validation()

            Dim HolderImage As String
            If (TextBox1.Text = "") Then
                HolderImage = ""
            Else

                Dim lastchar As Integer = CInt(TextBox1.Text.ToString.LastIndexOf("\"))
                HolderImage = Right(TextBox3.Text, (TextBox1.Text.Length - lastchar))
            End If

            'If (rdIndividual.Checked = False) And (rdJoint.Checked = False) And (rdNominee.Checked = False) And (rdCompany.Checked = False) Then
            '    msgbox("Select an AccountType")
            '    Exit Sub
            'End If
            If (txtSurname.Text = "") Then
                msgbox("Enter a holder's Name/Last Name")
                Exit Sub
            End If
            If (txtID.Text = "") Then
                msgbox("Enter a shareholder number/Company Registration ")
                Exit Sub
            End If
            If (txtAdd1.Text = "") Then
                msgbox("Enter Address")
                Exit Sub
            End If
            If (chkBank.Checked = True) Then
                If (txtBnkAccount.Text = "") Then
                    msgbox("Enter a bank account Number")
                    Exit Sub
                End If
            End If

            Dim Surname As String

            If txtSurname.Text.Contains("'") Then
                Surname = txtSurname.Text.Replace("'", " ")
            Else
                Surname = txtSurname.Text
            End If

            Dim forenameas As String
            If (txtforenames.Text.Contains("'")) Then
                forenameas = txtforenames.Text.Replace("'", " ")
            Else
                forenameas = txtforenames.Text
            End If

            getHolderNumber()
            'Dim CDSNUMBER As String = CStr(maxholder.ToString.PadLeft(13, "0"c) & cmbIndustry.Text)
            'MsgBox(CDSNUMBER)
            'msgbox("update pre_names_creation set brokercode='" & cmbBroker.Text & "',Surname='" & txtSurname.Text & "',Forenames='" & txtforenames.Text & "',IDpp='" & txtID.Text & "',DOB='" & BasicDatePicker1.Text & "',add_1='" & txtAdd1.Text & "',add_2='" & txtAdd2.Text & "',add_3='" & txtadd3.Text & "',add_4='" & txtadd4.Text & "',city='" & CmbCity.Text & "',country='" & cmbCountry.Text & "',Telephone='" & txtTel.Text & "',Cellphone='" & txtCell.Text & "',fax='" & txtFax.Text & "',email='" & txtEmail.Text & "',Bank_Name = '" & cmbBank.Text & "',Bank_Code='" & lblBank.Text & "',Branch_Name='" & cmbBranch.Text & "',Branch_Code='" & lblBranch.Text & "',Account='" & txtBnkAccount.Text & "',Tax='" & cmbTax.Text & "',Updated_by='" & Session("Username") & "',Update_on='" & Now.Date & "',Industry='" & cmbIndustry.Text & "',Approved =0 ,Nationality='" & cmbNaT.Text & "' where cds_number='" & cmbCdsNumber.Text & "'")
            'cmd = New SqlCommand("update pre_names_creation set brokercode='" & cmbBroker.Text & "',Surname='" & txtSurname.Text & "',Forenames='" & txtforenames.Text & "',IDpp='" & txtID.Text & "',DOB='" & BasicDatePicker1.Text & "',add_1='" & txtAdd1.Text & "',add_2='" & txtAdd2.Text & "',add_3='" & txtadd3.Text & "',add_4='" & txtadd4.Text & "',city='" & CmbCity.Text & "',country='" & cmbCountry.Text & "',Telephone='" & txtTel.Text & "',Cellphone='" & txtCell.Text & "',fax='" & txtFax.Text & "',email='" & txtEmail.Text & "',Bank_Name = '" & cmbBank.Text & "',Bank_Code='" & lblBank.Text & "',Branch_Name='" & cmbBranch.Text & "',Branch_Code='" & lblBranch.Text & "',Account='" & txtBnkAccount.Text & "',Tax='" & cmbTax.Text & "',Updated_by='" & Session("Username") & "',Update_on='" & Now.Date & "',Industry='" & cmbIndustry.Text & "',Approved =0 ,Nationality='" & cmbNaT.Text & "' where cds_number='" & cmbCdsNumber.Text & "'", cn)
            cmd = New SqlCommand("update pre_names_creation set Approved=0  where cds_number='" & cmbCdsNumber.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Account Details Submitted for Audit")
            cleartext()
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Saved a rejected account','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub validation()
        Try
            If (rdIndividual.Checked = False) And (rdJoint.Checked = False) And (rdNominee.Checked = False) And (rdCompany.Checked = False) Then
                msgbox("Select an AccountType")
                Exit Sub
            End If
            If (txtSurname.Text = "") Then
                msgbox("Enter a holder's Name/Last Name")
                Exit Sub
            End If
            If (txtID.Text = "") Then
                msgbox("Enter a shareholder number/Company Registration ")
                Exit Sub
            End If
            If (txtAdd1.Text = "") Then
                msgbox("Enter Address")
                Exit Sub
            End If
            If (chkBank.Checked = True) Then
                If (txtBnkAccount.Text = "") Then
                    msgbox("Enter a bank account Number")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderNumber()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(shareholder) as shareholder from pre_names_creation ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            maxholder = CInt(ds.Tables(0).Rows(0).Item("shareholder").ToString) + 1
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCountry()
        Try
            cmd = New SqlCommand("Select Country from para_country order by country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            cmbCountry.DataSource = ds.Tables(0)
            cmbCountry.DataValueField = "country"
            cmbCountry.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCoutryShort()
        Try
            cmd = New SqlCommand("Select fnam from para_country where country='" & cmbCountry.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")
            lblCountry.Text = ds.Tables(0).Rows(0).Item("fnam").ToString
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCity()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("Select city from para_city where country='" & cmbCountry.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_city")
            CmbCity.DataSource = ds1.Tables(0)
            CmbCity.DataValueField = "city"
            CmbCity.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBank()
        Try
            Dim ds1 As New DataSet
            'MsgBox("TEST")
            cmd = New SqlCommand("select distinct(bank_name) from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_bank")
            cmbBank.DataSource = ds1.Tables(0)
            cmbBank.DataValueField = "bank_name"
            cmbBank.DataBind()
            getBankShort()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBankShort()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select bank_code from para_bank where bank_name='" & cmbBank.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_bank")
            If (ds1.Tables(0).Rows.Count > 0) Then
                lblBank.Text = (ds1.Tables(0).Rows(0).Item("bank_code").ToString)
                getBranch()
            Else
                lblBank.Text = "0"
            End If


        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getBranch()
        Try
            Dim ds1 As New DataSet
            If (lblBank.Text <> "0") Then
                cmd = New SqlCommand("select branch_name from para_branch where bank ='" & lblBank.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "para_branch")
                If (ds1.Tables(0).Rows.Count > 0) Then
                    cmbBranch.DataSource = ds1.Tables(0)
                    cmbBranch.DataValueField = "branch_name"
                    cmbBranch.DataBind()
                    getBranchShort()
                Else
                    cmbBranch.Items.Clear()
                End If

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBranchShort()
        Try
            Dim ds1 As New DataSet
            cmd = New SqlCommand("select branch_code from para_branch where branch_name='" & cmbBranch.Text & "' and bank='" & lblBank.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "para_branch")
            lblBranch.Text = ds1.Tables(0).Rows(0).Item("branch_code")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbBank_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedIndexChanged
        getBankShort()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Rejected Accounts Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getCountry()
            getCoutryShort()
            getCity()
            getNationality()
            getBank()
            getBrokers()
            fillbrokercode()
            getIndustry()
            SecurityDocuments()
            GetHolderData()
            getHolderDetails()
        End If
    End Sub
    Public Sub getIndustry()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (code) from para_industry", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_industry")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbIndustry.DataSource = ds.Tables(0)
                cmbIndustry.DataValueField = "code"
                cmbIndustry.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCountry.SelectedIndexChanged
        getCoutryShort()
        getCity()
    End Sub

    Protected Sub chkBank_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBank.CheckedChanged
        If (chkBank.Checked = True) Then
            getBank()
            cmbBank.Enabled = True
            cmbBranch.Enabled = True
            txtBnkAccount.Enabled = True
            cmbAccType.Enabled = True
        Else
            cmbBank.Enabled = False
            cmbBranch.Enabled = False
            txtBnkAccount.Enabled = False
            cmbAccType.Enabled = False
        End If
    End Sub
    Public Sub cleartext()
        Try
            txtSurname.Text = ""
            txtforenames.Text = ""
            txtID.Text = ""
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtadd3.Text = ""
            txtadd4.Text = ""
            txtBnkAccount.Text = ""
            txtTel.Text = ""
            txtCell.Text = ""
            txtEmail.Text = ""
            txtFax.Text = ""
            txtpostal.Text = ""
            txtInitials.Text = ""
            BasicDatePicker1.Clear()
            getCountry()
            getCity()
            getBank()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            Image1.ImageUrl = Nothing
            Label27.Visible = False
            TextBox4.Visible = False
            TextBox4.Text = ""
            Label28.Visible = False
            TextBox5.Visible = False
            TextBox5.Text = ""
            Label30.Visible = False
            TextBox7.Visible = False
            TextBox7.Text = ""
            Label29.Visible = False
            TextBox6.Visible = False
            TextBox6.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub fillbrokercode()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_broker where fnam='" & cmbBroker.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblBrokercode.Text = ds.Tables(0).Rows(0).Item("broker_code").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBroker_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBroker.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_broker where fnam='" & cmbBroker.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")
            If (ds.Tables(0).Rows.Count > 0) Then
                lblBrokercode.Text = ds.Tables(0).Rows(0).Item("broker_code").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            FileCopy(TextBox1.Text, TextBox2.Text)
            msgbox("File Copied")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            fDocument.PostedFile.SaveAs(Server.MapPath("ShareholderImages\" & fDocument.Value))
            TextBox1.Text = Server.MapPath("ShareholderImages\" & fDocument.Value)
            TextBox3.Text = TextBox1.Text
            Dim lastchar As Integer = CInt(TextBox1.Text.ToString.LastIndexOf("\"))
            Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
            Image1.ImageUrl = signpath & "/" & Right(TextBox3.Text, (TextBox1.Text.Length - lastchar))
            Image1.width = "200"
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdCompany_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCompany.CheckedChanged
        Try
            If (rdCompany.Checked = True) Then
                cmbSecurityDoc.Items.Clear()
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct (doctype) from securityDocuments where doccode='cr'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "securityDocuments")

                cmbSecurityDoc.DataSource = ds.Tables(0)
                cmbSecurityDoc.DataValueField = "doctype"
                cmbSecurityDoc.DataBind()
            End If
            GetJoint()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdIndividual_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdIndividual.CheckedChanged
        Try
            SecurityDocuments()
            GetJoint()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdJoint_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdJoint.CheckedChanged
        Try
            If (rdJoint.Checked = True) Then
                SecurityDocuments()
                GetJoint()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetJoint()
        Try
            If (rdJoint.Checked = True) Then
                Label27.Visible = True
                TextBox4.Visible = True
                TextBox4.Text = ""
                Label28.Visible = True
                TextBox5.Visible = True
                TextBox5.Text = ""
                Label30.Visible = True
                TextBox7.Visible = True
                TextBox7.Text = ""
                Label29.Visible = True
                TextBox6.Visible = True
                TextBox6.Text = ""
            End If
            If (rdJoint.Checked = False) Then
                Label27.Visible = False
                TextBox4.Visible = False
                TextBox4.Text = ""
                Label28.Visible = False
                TextBox5.Visible = False
                TextBox5.Text = ""
                Label30.Visible = False
                TextBox7.Visible = False
                TextBox7.Text = ""
                Label29.Visible = False
                TextBox6.Visible = False
                TextBox6.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdNominee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdNominee.CheckedChanged
        Try
            If (rdNominee.Checked = True) Then
                SecurityDocuments()
                GetJoint()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getNationality()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (Nationality) from para_country", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbNaT.DataSource = ds.Tables(0)
                cmbNaT.DataValueField = "Nationality"
                cmbNaT.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbCdsNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCdsNumber.SelectedIndexChanged
        getHolderDetails()
    End Sub
End Class
