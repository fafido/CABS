Imports System.Data
Imports System.Data.SqlClient
Partial Class TSecMode_AccountCreation
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
            If (rdIndividual.Checked = False) And (rdJoint.Checked = False) And (rdNominee.Checked = False) And (rdCompany.Checked = False) Then
                msgbox("Select an AccountType")
                Exit Sub
            End If
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
            If (rdIndividual.Checked = True) Then
                AccType = "1"
            End If
            If (rdJoint.Checked = True) Then
                AccType = "2"
            End If
            If (rdNominee.Checked = True) Then
                AccType = "3"
            End If
            If (rdCompany.Checked = True) Then
                AccType = "4"
            End If
            'validation()

            Dim HolderImage As String
            If (TextBox1.Text = "") Then
                HolderImage = ""
            Else

                Dim lastchar As Integer = CInt(TextBox1.Text.ToString.LastIndexOf("\"))
                HolderImage = Right(TextBox3.Text, (TextBox1.Text.Length - lastchar))
            End If

            Dim HolderImage2 As String
            If (TextBox8.Text = "") Then
                HolderImage2 = ""
            Else

                Dim lastchar As Integer = CInt(TextBox8.Text.ToString.LastIndexOf("\"))
                HolderImage2 = Right(TextBox10.Text, (TextBox8.Text.Length - lastchar))
            End If

            Dim HolderImage3 As String
            If (TextBox9.Text = "") Then
                HolderImage3 = ""
            Else

                Dim lastchar As Integer = CInt(TextBox9.Text.ToString.LastIndexOf("\"))
                HolderImage3 = Right(TextBox11.Text, (TextBox9.Text.Length - lastchar))
            End If

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
            Dim CDSNUMBER As String = CStr(maxholder.ToString.PadLeft(13, "0"c) & cmbIndustry.Text)
            'MsgBox(CDSNUMBER)
            If (chkBank.Checked = True) Then
                If (rdJoint.Checked = False) Then
                    'cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,RecType) values(" & maxholder & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "','" & cmbBank.Text & "','" & lblBank.Text & "','" & cmbBranch.Text & "','" & lblBranch.Text & "','" & txtBnkAccount.Text & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW')", cn)
                    cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,RecType,Title,Initials,PostalCode,ImageId,Nationality,Old_Shareholder,idimage,sigimage) values(" & maxholder.ToString.PadLeft(13, "0"c) & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & Surname.ToString.ToUpper & "','" & forenameas.ToString.ToUpper & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text.ToUpper & "','" & txtAdd2.Text.ToUpper & "','" & txtadd3.Text.ToUpper & "','" & txtadd4.Text.ToUpper & "','" & CmbCity.Text.ToUpper & "','" & cmbCountry.Text.ToUpper & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text.ToLower & "','" & cmbBank.Text & "','" & lblBank.Text & "','" & cmbBranch.Text & "','" & lblBranch.Text & "','" & txtBnkAccount.Text & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW','" & cmbTitle.Text & "','" & txtInitials.Text & "','" & txtpostal.Text & "','" & HolderImage & "','" & cmbNaT.Text & "','" & Trim(txtOldShareholder.Text) & "','" & HolderImage2 & "','" & HolderImage3 & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Else
                    cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_Name,Branch_Code,Account,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,RecType,Title,Initials,PostalCode,ImageId,JSurname,JForenames,JEmail,JCell,Nationality,Old_Shareholder,idimage,sigimage) values(" & maxholder.ToString.PadLeft(13, "0"c) & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & Surname.ToString.ToUpper & "','" & forenameas.ToString.ToUpper & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text.ToUpper & "','" & txtAdd2.Text.ToUpper & "','" & txtadd3.Text.ToUpper & "','" & txtadd4.Text.ToUpper & "','" & CmbCity.Text.ToUpper & "','" & cmbCountry.Text.ToUpper & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text.ToLower & "','" & cmbBank.Text & "','" & lblBank.Text & "','" & cmbBranch.Text & "','" & lblBranch.Text & "','" & txtBnkAccount.Text & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW','" & cmbTitle.Text & "','" & txtInitials.Text & "','" & txtpostal.Text & "','" & HolderImage & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "','" & cmbNaT.Text & "','" & Trim(txtOldShareholder.Text) & "','" & HolderImage2 & "', '" & HolderImage3 & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If


            End If
            If (chkBank.Checked = False) Then
                If (rdJoint.Checked = False) Then
                    'cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,rECtYPE) values(" & maxholder & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW')", cn)
                    cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,rECtYPE,Title,Initials,PostalCode,ImageID,Nationality,old_shareholder,idimage,sigimage) values(" & maxholder.ToString.PadLeft(13, "0"c) & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & Surname.ToString.ToUpper & "','" & forenameas.ToString.ToUpper & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text.ToUpper & "','" & txtAdd2.Text.ToUpper & "','" & txtadd3.Text.ToUpper & "','" & txtadd4.Text.ToUpper & "','" & CmbCity.Text.ToUpper & "','" & cmbCountry.Text.ToUpper & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text.ToLower & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW','" & cmbTitle.Text & "','" & txtInitials.Text & "','" & txtpostal.Text & "','" & HolderImage & "','" & cmbNaT.Text & "','" & Trim(txtOldShareholder.Text) & "','" & HolderImage2 & "', '" & HolderImage3 & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Else
                    'cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,rECtYPE) values(" & maxholder & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & txtSurname.Text & "','" & txtforenames.Text & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "','" & txtadd3.Text & "','" & txtadd4.Text & "','" & CmbCity.Text & "','" & cmbCountry.Text & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW')", cn)
                    cmd = New SqlCommand("insert into pre_names_Creation(shareholder,brokercode,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Tax,Updated_by,Update_on,Industry,Approved,Holder_type,rECtYPE,Title,Initials,PostalCode,ImageID,JSurname,JForenames,JEmail,JCell,Nationality,Old_Shareholder,idimage,sigimage) values(" & maxholder.ToString.PadLeft(13, "0"c) & ",'" & Session("BrokerCode") & "','" & CDSNUMBER & "','" & Surname.ToString.ToUpper & "','" & forenameas.ToString.ToUpper & "','" & txtID.Text & "','" & BasicDatePicker1.Text & "','" & txtAdd1.Text.ToUpper & "','" & txtAdd2.Text.ToUpper & "','" & txtadd3.Text.ToUpper & "','" & txtadd4.Text.ToUpper & "','" & CmbCity.Text.ToUpper & "','" & cmbCountry.Text.ToUpper & "','" & txtTel.Text & "','" & txtCell.Text & "','" & txtFax.Text & "','" & txtEmail.Text.ToLower & "',0,'" & Session("UserName") & "','" & Now.Date & "','" & cmbIndustry.Text & "','0','" & AccType & "','NEW','" & cmbTitle.Text & "','" & txtInitials.Text & "','" & txtpostal.Text & "','" & HolderImage & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "','" & cmbNaT.Text & "','" & Trim(txtOldShareholder.Text) & "','" & HolderImage2 & "','" & HolderImage3 & "')", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End If

            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Created New Account','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account Details Submitted for Audit")
            cleartext()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getNationality()
        Try
            If (cmbCountry.Items.Count > 0) Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select distinct (Nationality) from para_country ", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "para_company")
                If (ds.Tables(0).Rows.Count > 0) Then
                    cmbNaT.DataSource = ds.Tables(0)
                    cmbNaT.DataValueField = "Nationality"
                    cmbNaT.DataBind()

                    Dim rz As New DataSet
                    cmd = New SqlCommand("select nationality from para_country where country='" & cmbCountry.SelectedItem.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(rz, "para_country")

                    If (rz.Tables(0).Rows.Count > 0) Then
                        cmbNaT.SelectedItem.Text = rz.Tables(0).Rows(0).Item("nationality").ToString
                    End If

                End If
            End If

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
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Accounts Creation Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
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
        SelectNat()
    End Sub
    Public Sub SelectNat()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select nationality from para_country where country='" & cmbCountry.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_country")

            cmbNaT.SelectedItem.Text = ds.Tables(0).Rows(0).Item("nationality").ToString
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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
    Public Sub SaveImage()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("insert into account_documents (cds_number,image_data,imagetype,imagelength) values ()")
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

    Protected Sub BtnCapture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCapture.Click
        Try
            msgbox("No compatible code detected")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnCapture1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCapture1.Click
        Try
            msgbox("No compatible code detected")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnCapture0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCapture0.Click
        Try
            msgbox("No compatible code detected")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        File1.PostedFile.SaveAs(Server.MapPath("IDImages\" & File1.Value))
        TextBox8.Text = Server.MapPath("IDImages\" & File1.Value)
        TextBox10.Text = TextBox8.Text
        Dim lastchar As Integer = CInt(TextBox8.Text.ToString.LastIndexOf("\"))
        Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
        Image2.ImageUrl = signpath & "/" & Right(TextBox10.Text, (TextBox8.Text.Length - lastchar))
        Image2.width = "200"
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        File2.PostedFile.SaveAs(Server.MapPath("SignatureImages\" & File2.Value))
        TextBox9.Text = Server.MapPath("SignatureImages\" & File2.Value)
        TextBox11.Text = TextBox9.Text
        Dim lastchar As Integer = CInt(TextBox9.Text.ToString.LastIndexOf("\"))
        Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
        Image3.ImageUrl = signpath & "/" & Right(TextBox11.Text, (TextBox9.Text.Length - lastchar))
        Image3.width = "200"
    End Sub
End Class

