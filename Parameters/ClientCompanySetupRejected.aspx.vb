Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class Parameters_ClientCompanySetupRejected
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
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

    Public Function loadcode(type As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select code from tbl_participantsType where FULLTYPE='" + type + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_ParticipantsType")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("code")
        End If
    End Function

    Public Function loadnomencle() As String
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT RIGHT('000'+CAST(isnull(max(id),0)+(select isnull(count(*),0)+1 from client_companies_audit where approvedby is NULL) AS VARCHAR(3)),5) AS max1 from client_companies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tbl_ParticipantsType")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("max1")
        End If

    End Function
    Public Sub checkSessionState()
        Try

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
                cmbCountry.Items.Add("--Select--")
                cmbCountry.DataSource = ds.Tables(0)
                cmbCountry.DataTextField = "country"
                'cmbCountry.ValueField = "country"
                cmbCountry.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getphonecodes()
        Dim ds As New DataSet
        cmd = New SqlCommand("select phonecode from para_country where country='" + cmbCountry.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_city")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtcode10.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode6.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode7.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode8.Text = ds.Tables(0).Rows(0).Item("phonecode")
            txtcode9.Text = ds.Tables(0).Rows(0).Item("phonecode")
            'txtcodeFx.Text = ds.Tables(0).Rows(0).Item("phonecode")
        End If
    End Sub
    Public Sub GetCity()
        Try
            'cmbCity.DataSource = Nothing
            'cmbCity.DataBind()
            'cmbCity.Items.Clear()
            'cmbCity.Items.Add(New ListItem("", ""))
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (city) from para_city where country='" & cmbCountry.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCity.Items.Add("--Select--")
                cmbCity.DataSource = ds.Tables(0)
                cmbCity.DataTextField = "city"
                cmbCity.DataValueField = "city"
                cmbCity.DataBind()

            End If




        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub Getstates()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (state) from para_states where country='" & cmbCountry.SelectedItem.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbstate.Items.Add("--Select--")
                cmbstate.DataSource = ds.Tables(0)
                cmbstate.DataTextField = "state"
                cmbstate.DataValueField = "state"
                cmbstate.DataBind()
            Else
                cmbstate.Items.Clear()
                cmbstate.Items.Add("--Select--")
            End If



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GETCURRENCIES()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select currencysymbol from para_currencies where currencysymbol<>'Ksh'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city1")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxComboBox1.DataSource = ds
                ASPxComboBox1.TextField = "currencysymbol"
                ASPxComboBox1.DataBind()



            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcurrenciesforbrokers()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_broker_currency where [broker]='" + txtCode.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_city1")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox1.DataSource = ds
            ASPxListBox1.TextField = "currency"
            ASPxListBox1.ValueField = "currency"
            ASPxListBox1.DataBind()
        End If

    End Sub
    Public Sub GETbanks()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_bank", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_city1")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtmainbankname.DataSource = ds
                txtmainbankname.TextField = "bank_name"
                txtmainbankname.ValueField = "bank"
                txtmainbankname.DataBind()



            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

                GetCountry()
                txtCode.ReadOnly = True
                rdActive0.Visible = False
                ' ASPxButton2.Visible = False
                ' rdCreateNew.Checked = True
                GETCURRENCIES()
                GETbanks()
                '  cmbCountry.SelectedItem.Text = "Pakistan"
                txtCode.Text = loadcode(cmbtype.Text) + "" + loadnomencle()
                '    GetCity()
                '   Getstates()
                getphonecodes()
                ASPxButton4.Visible = False
                Session("rand") = CreateRandomPassword(10)
                loadrejected()

            End If
            If Session("finish1") = "true" Then
                Session("finish1") = ""
                msgbox("Participant Update Successfully Saved, Pending Approval")
            End If
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Participant Successfully Saved, Pending Approval")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$&*"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim updatetype As String
        If rdUpdate.Checked = True Then
            updatetype = "UPDATE"
        Else
            updatetype = "NEW"
        End If
        If txtCompanyName.Text = "" Then
            msgbox("Please enter Participant Name")
            Exit Sub
        End If
        If txtCode.Text = "" Then
            msgbox("Please enter Participant Code")
            Exit Sub
        End If

        If txtAdd1.Text = "" Then
            msgbox("Please enter Address")
            Exit Sub
        End If
        If txtEmail.Text = "" Then
            msgbox("Please enter Email")
            Exit Sub
        End If

        If txtContact.Text = "" Then
            msgbox("Please Contact Person")
            Exit Sub
        End If


        If txtmainbankname.SelectedIndex.ToString = "-1" Then
            msgbox("Please Select Main Bank Name!")
            Exit Sub
        End If

        If txtmainbranch.Text = "" Then
            msgbox("Please Enter Branch Name!")
            Exit Sub
        End If

        If txtfax.Text <> "" Then
            If txtfax.Text.Length <> 10 Then
                msgbox("Please enter 10 digits for fax number!")
                Exit Sub
            End If
            If IsNumeric(txtfax.Text) = False Then
                msgbox("Please enter numeric for fax!")
                Exit Sub
            End If
        End If

        If txtTel.Text <> "" Then
            If txtTel.Text.Length < 12 Then
                msgbox("Please enter less than or equal to 12 digits for telephone number!")
                Exit Sub
            End If
            If IsNumeric(txtTel.Text) = False Then
                msgbox("Please enter numeric for telephone!")
                Exit Sub
            End If
        End If


        'If txtmainbic.Text = "" Then
        '    msgbox("Please enter Main BIC Code!")
        '    Exit Sub

        'End If
        If cmbCity.Text = "--Select--" Then
            msgbox("Please select city!")
            Exit Sub
        End If
        If cmbstate.Text = "--Select--" Then
            msgbox("Please select state!")
            Exit Sub
        End If



        'If txtNTN.Text = "" Then
        '    msgbox("Please enter NTN No.!")
        '    Exit Sub
        'End If

        Dim ownershiptype As String = ""
        If RadioButtonList1.Visible = True Then
            Try
                ownershiptype = RadioButtonList1.SelectedItem.Text
            Catch ex As Exception
                msgbox("Please select whether its a Company or Individual!")
                Exit Sub
            End Try
            Try
                If ownershiptype = "Company" Then

                    If txtsecp.Text = "" Then
                        msgbox("Please enter SECP CUI No.")
                        Exit Sub
                    End If
                End If
            Catch ex As Exception

            End Try

        Else
            ownershiptype = ""
        End If


        Try

            'If (rdCreateNew.Checked = True) Then
            Dim Type As String = ""
                Dim Country As String = ""
                Dim City As String = ""

                If (cmbCountry.Items.Count > 0) Then
                    If (cmbCountry.SelectedIndex.ToString > 1) Then
                        Country = cmbCountry.SelectedItem.Text
                    Else
                        Country = ""
                    End If
                Else
                    Country = ""
                End If
                If (cmbCity.Items.Count > 0) Then
                    If cmbCity.SelectedIndex.ToString > 1 Then
                        City = cmbCity.SelectedItem.Text
                    Else
                        City = ""
                    End If
                End If

                Dim subject As String = "" + cmbType.Text + " Company Added"

                Dim body As String = "Your " + cmbType.Text + " Participant Account. has been successfully added on Custodial System. Accounts under the " + cmbType.Text + " shall be created and Credentials will be sent to the respective Account Holders"
                Dim addtnl As String
                'If cmbType.Text = "WAREHOUSE" Then
                '    addtnl = "insert into para_warehouse ([Company],[Fnam],[Date_created],[Issued_shares],[registrar],[Add_1],[Add_2],[Add_3],[Add_4],[City],[Country],[Contact_Person],[Telephone],[Cellphone],[Fax],[Comments],[sec_type],[board],[index_type],[ticker],[ISIN],[year_listed],[comp_secretary],[email],[website],[issued_capital],[nominal_value],[status],[issuer_code], Capacity, WarehouseType, Commodity) values (''" & txtCode.Text & "'',''" & txtCompanyName.Text & "'',getdate(),''0'','''',''" & txtAdd1.Text & "'',''" & txtAdd2.Text & "'',''" & txtAdd3.Text & "'','''','''',''" & cmbCountry.Text & "'','''',''" & txtContact.Text & "'','''',''" & txtContact.Text & "'','''','''','''',''0'',''" + txtCode.Text + "'',''" & txtCode.Text & "'',getdate(),'''',''" & txtEmail.Text & "'','''',''0'',''0'',''0'',''" & txtCode.Text & "'',''" + txtkey.Text + "'',''" + cmbwarehousetypes.Text + "'',''" + txtcommodity.Text + "'')"
                'Else
                '    addtnl = ""
                'End If

                cmd = New SqlCommand("update client_companies_contacts set participantcode='" + txtCode.Text + "' where participantcode='" + Session("rand") + "'", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Dim stmnt As String = "delete from client_companies_audit where id='" + ASPxListBox2.SelectedItem.Value.ToString + "' insert into Client_Companies_Audit (company_name,company_code,company_type,AccountManager,Account_Pass,Adress_1,Adress_2,Adress_3,adress_4,adress_5,contact_email,contact_phone,contact_person,status,[main_branch],[main_account],[trading_branch],[trading_account],[main_account_name],[trading_account_name],[trading_bank],[main_bank],[settlement_cycle],[main_branch_new], [trading_branch_new],[key_letter], [County],[NTN],[SECP],[fax],[website],[state],[OwnershipType],[MaxUsers],[CapturedBy],UpdateType)values ('" & txtCompanyName.Text & "','" & txtCode.Text & "','" & cmbtype.Text & "','" & txtContact.Text & "','password','" & txtAdd1.Text.ToUpper & "','" & txtAdd2.Text & "','" & txtAdd3.Text & "','" & cmbCity.Text & "','" & cmbCountry.SelectedItem.Text & "','" & txtEmail.Text.ToLower & "','" & txtMobile.Text & "','" & txtContact.Text & "',1,'','" + txtmainaccount.Text + "','','','" + txtmainaccountname.Text + "','','','" + txtmainbankname.Text + "','','" + txtmainbranch.Text + "','','','','" + txtNTN.Text + "','" + txtsecp.Text + "','" + txtfax.Text + "','" + txtwebsite.Text + "','" + cmbstate.Text + "','" + ownershiptype + "','" + txtmaxusers.Text + "','" + Session("Username") + "','" + updatetype + "') "
            cmd = New SqlCommand(stmnt, cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



                Session("finish") = "true"
                Response.Redirect(Request.RawUrl)


            ' End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try


    End Sub
    Public Sub GetParticipants()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct(Company_name) from client_companies ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "client_companies")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbParticipants.Items.Add("--Select--")
                cmbParticipants.DataSource = ds.Tables(0)
                cmbParticipants.DataValueField = "company_name"
                cmbParticipants.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetParticipantsDetials()
        '  Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from client_companies_audit where id = '" & ASPxListBox2.SelectedItem.Value.ToString & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtAdd1.Text = ds.Tables(0).Rows(0).Item("Adress_1").ToString
            txtAdd2.Text = ds.Tables(0).Rows(0).Item("Adress_2").ToString
            txtAdd3.Text = ds.Tables(0).Rows(0).Item("Adress_3").ToString
            txtCode.Text = ds.Tables(0).Rows(0).Item("Company_Code").ToString
            txtCompanyName.Text = ds.Tables(0).Rows(0).Item("Company_name").ToString
            txtContact.Text = ds.Tables(0).Rows(0).Item("AccountManager").ToString
            txtEmail.Text = ds.Tables(0).Rows(0).Item("contact_email").ToString
            txtMobile.Text = ds.Tables(0).Rows(0).Item("contact_phone").ToString
            txtTel.Text = ds.Tables(0).Rows(0).Item("contact_phone").ToString
            txtfax.Text = ds.Tables(0).Rows(0).Item("fax").ToString
            txtwebsite.Text = ds.Tables(0).Rows(0).Item("website").ToString
            cmbCountry.SelectedItem.Text = ds.Tables(0).Rows(0).Item("adress_5").ToString
            txtrejectreason.Text = ds.Tables(0).Rows(0).Item("RejectReason").ToString
            GetCity()
            Getstates()

            If (cmbCity.Items.Count > 0) Then
                cmbCity.SelectedItem.Text = ds.Tables(0).Rows(0).Item("adress_4").ToString
            End If
            cmbtype.Text = ds.Tables(0).Rows(0).Item("Company_type").ToString


            Try
                txtmainaccount.Text = ds.Tables(0).Rows(0).Item("main_account").ToString
            Catch ex As Exception

            End Try
            Try
                txtmainaccountname.Text = ds.Tables(0).Rows(0).Item("main_account_name").ToString
            Catch ex As Exception

            End Try
            Try
                txtmainbranch.Value = ds.Tables(0).Rows(0).Item("main_branch_NEW").ToString
            Catch ex As Exception

            End Try

            Try
                txtmainbankname.Value = ds.Tables(0).Rows(0).Item("main_bank").ToString
            Catch ex As Exception

            End Try
            cmbCity.SelectedItem.Text = ds.Tables(0).Rows(0).Item("adress_4").ToString
            cmbstate.SelectedItem.Text = ds.Tables(0).Rows(0).Item("state").ToString
            cmbtype.Text = ds.Tables(0).Rows(0).Item("company_type").ToString



            txtsecp.Text = ds.Tables(0).Rows(0).Item("SECP").ToString

            txtNTN.Text = ds.Tables(0).Rows(0).Item("NTN").ToString
            loadcontactsgrid(txtCode.Text)

            If cmbtype.Text = "WAREHOUSE" Then
                RadioButtonList1.Visible = True

                Dim participanttype As String = ds.Tables(0).Rows(0).Item("OwnershipType").ToString
                If participanttype = "Individual" Then
                    RadioButtonList1.SelectedIndex = 0
                ElseIf participanttype = "Company" Then
                    RadioButtonList1.SelectedIndex = 1
                End If

                If RadioButtonList1.SelectedItem.Text = "Company" Then
                    lblvar.Text = "SECP CUI"
                    txtsecp.Visible = True
                    txtNTN.Visible = False
                    lblasta.Visible = True
                Else
                    lblvar.Text = "NTN No."
                    txtsecp.Visible = False
                    txtNTN.Visible = True
                    lblasta.Visible = False
                End If
            Else
                RadioButtonList1.Visible = False
            End If




            Dim updatetype As String = ds.Tables(0).Rows(0).Item("UpdateType").ToString
            If updatetype = "NEW" Then
                rdCreateNew.Checked = True
            ElseIf updatetype = "UPDATE" Then
                rdUpdate.Checked = True
            ElseIf updatetype = "DELETION" Then

            End If
            txtmaxusers.Text = ds.Tables(0).Rows(0).Item("MaxUsers").ToString


        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
        'msgbox(cmbCountry.Text)
        GetCity()
        Getstates()
        getphonecodes()

    End Sub

    Protected Sub txtCompanyName_TextChanged(sender As Object, e As EventArgs) Handles txtCompanyName.TextChanged
        'Dim fullname As String = txtCompanyName.Value
        'Dim splitted() As String = fullname.Split(" ")



        'Dim firstlaters As String = splitted(0)

        'If getParticipantCode(firstlaters.ToString().ToUpper()) Then
        '    txtCode.Value = firstlaters.ToString().ToUpper()
        'Else
        '    Dim answer As Char
        '    answer = firstlaters.Substring(0, 1).ToUpper

        '    txtCode.Value = String.Concat(firstlaters.ToString().ToUpper(), answer)


        '    If getParticipantCode(txtCode.Value) Then
        '        Dim answer2 As Char
        '        answer2 = firstlaters.Substring(0, 1).ToUpper

        '        txtCode.Value = String.Concat(firstlaters.ToString().ToUpper(), answer2)
        '    Else
        '        Dim answer1 As Char
        '        answer1 = firstlaters.Substring(2, 3).ToUpper

        '        txtCode.Value = String.Concat(firstlaters.ToString().ToUpper(), answer1)
        '    End If
        'End If



        'txtCode.ReadOnly = True





    End Sub

    Protected Sub rdUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles rdUpdate.CheckedChanged
        Try
            If (rdUpdate.Checked = True) Then
                cmbParticipants.Enabled = True
                GetParticipants()
                cmbParticipants.Visible = True
                ASPxLabel2.Visible = True

                cmbType.Enabled = False
                txtCode.ReadOnly = True
                txtCode.Text = ""
                'cmbType.Items.Clear()

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbParticipants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticipants.SelectedIndexChanged
        '  GetTypes()

        GetParticipantsDetials()
        getcurrenciesforbrokers()
        Session("rand") = txtCode.Text
        ASPxButton4.Visible = True

        GetCity()
        Getstates()
        getphonecodes()



    End Sub

    Protected Sub rdCreateNew_CheckedChanged(sender As Object, e As EventArgs) Handles rdCreateNew.CheckedChanged
        Try
            If (rdCreateNew.Checked = True) Then
                txtAdd1.Text = ""
                txtAdd2.Text = ""
                txtAdd3.Text = ""
                txtCode.Text = ""
                txtCompanyName.Text = ""
                txtContact.Text = ""
                txtEmail.Text = ""
                txtMobile.Text = ""
                txtTel.Text = ""
                ' GetTypes()
                cmbParticipants.Enabled = False

                rdActive0.Visible = False
                cmbType.Enabled = True
                txtCode.ReadOnly = False

                Response.Redirect(Request.RawUrl)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function currencyavailable(broker As String, currency As String) As Boolean
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_broker_currency where [broker]='" + broker + "' and currency='" + currency + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If

    End Function


    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try
            If currencyavailable(txtCode.Text, ASPxComboBox1.Text) = True Then
                msgbox("Currency Already Exist!")
                Exit Sub
            End If

            cmd = New SqlCommand("insert into para_broker_currency values ('0','" + txtCode.Text + "','" + ASPxComboBox1.Text + "',getdate())", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim itm As String = ASPxComboBox1.Text
            ASPxListBox1.Items.Add(ASPxComboBox1.Text)


        Catch ex As Exception

        End Try

    End Sub



    Protected Sub txtmainbankname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtmainbankname.SelectedIndexChanged
        'Try
        '    Dim ds As New DataSet
        '    cmd = New SqlCommand("select * from para_branch where bank='" + txtmainbankname.SelectedItem.Value.ToString + "'", cn)
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(ds, "para_city1")
        '    If (ds.Tables(0).Rows.Count > 0) Then
        '        txtmainbranch.DataSource = ds
        '        txtmainbranch.TextField = "branch_name"
        '        txtmainbranch.ValueField = "branch_code"
        '        txtmainbranch.DataBind()
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Public Sub loadcontactsgrid(code As String)
        Dim dscode As New DataSet
        cmd = New SqlCommand("SELECT [ID] AS [Entry ID],[Name]      ,[PhoneNo]      ,[MobileNo]      ,[Designation]      ,[Email]      ,[Other]      ,[DateAdded]      ,[ParticipantCode]  FROM [CDS].[dbo].[Client_Companies_Contacts] where participantcode='" + code + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dscode, "client_companies")
        If dscode.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = dscode
            GridView1.DataBind()

        End If
    End Sub



    Public Function getParticipantCode(ByVal code As String) As Boolean
        Try
            Dim dscode As New DataSet
            cmd = New SqlCommand("select * from client_companies where Company_Code ='" & code & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dscode, "client_companies")
            If dscode.Tables(0).Rows.Count > 0 Then

                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function

    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        Dim stmnt As String = "update client_companies set [status]=''0'' where Company_name = ''" & cmbParticipants.SelectedItem.Text & "''"
        cmd = New SqlCommand(" insert into tbl_uncommitted ([description], script, [status], sender, date_inserted, comment, email_body, email_subject, email_to, category) values ('De-Activated a Participant with the Name: " + cmbParticipants.SelectedItem.Text + "', '" + stmnt + "', '0','" + Session("Username") + "', getdate(), '','','', '','De-Activated a Participant')", cn)

        '    cmd = New SqlCommand("delete from client_companies where Company_name = '" & cmbParticipants.SelectedItem.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Session("finish") = "true"
        Response.Redirect(Request.RawUrl)

    End Sub
    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        If txtContactName.Text = "" Then
            msgbox("Please enter contact Name")
            Exit Sub

        End If
        If txtmobileno.Text = "" Then
            msgbox("Please enter Contact Mobile No")
            Exit Sub
        End If
        If txtdesignation.Text = "" Then
            msgbox("Please enter Contact Designation")
            Exit Sub
        End If
        If IsValidEmailFormat(txtpersonalemail.Text) = False Then
            msgbox("Please enter valid Email format!")
            Exit Sub
        End If
        If txtphoneNo.Text.Length <> 10 Then
            msgbox("Telephone should have 10 digits!")
            Exit Sub
        End If
        If txtmobileno.Text.Length <> 10 Then
            msgbox("Mobile No. should have 10 digits!")
            Exit Sub
        End If
        If IsNumeric(txtphoneNo.Text) = False Then
            msgbox("Telephone should contain only digits!")
            Exit Sub
        End If
        If IsNumeric(txtmobileno.Text) = False Then
            msgbox("Mobile No. should contain only digits!")
            Exit Sub
        End If

        cmd = New SqlCommand("insert into client_companies_contacts (Name, PhoneNo, MobileNo, Designation, Email, Other, DateAdded, ParticipantCode) values ('" + txtContactName.Text + "','" + txtphoneNo.Text + "','" + txtmobileno.Text + "','" + txtdesignation.Text + "','" + txtpersonalemail.Text + "','" + txtother.Text + "',getdate(),'" + txtCode.Text + "')", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        txtContactName.Text = ""
        txtphoneNo.Text = ""
        txtmobileno.Text = ""
        txtdesignation.Text = ""
        txtpersonalemail.Text = ""
        txtother.Text = ""
        loadcontactsgrid(txtCode.Text)

    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        cmd = New SqlCommand("DELETE from client_companies_contacts where id='" + GridView1.SelectedValue.ToString + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        loadcontactsgrid(txtCode.Text)
    End Sub


    Protected Sub ASPxButton6_Click(sender As Object, e As EventArgs) Handles ASPxButton6.Click

        Dim ds As New DataSet
        cmd = New SqlCommand("select ID, Company_Name +' '+ company_code +' '+ company_type + ' '+ contact_email as [Det] from client_companies_audit where ApprovedBy is NULL  and Company_Name +' '+ company_code +' '+ company_type + ' '+ contact_email like '%" + txtsearchtext.Text + "%' and capturedBy='" + Session("Username") + "' and rejectreason is NOT NULL and rejectedby<>'" + Session("Username") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox2.DataSource = ds
            ASPxListBox2.TextField = "Det"
            ASPxListBox2.ValueField = "ID"
            ASPxListBox2.DataBind()

        End If

    End Sub
    Public Sub loadrejected()
        Dim ds As New DataSet
        cmd = New SqlCommand("select ID, Company_Name +' '+ company_code +' '+ company_type + ' '+ contact_email as [Det] from client_companies_audit where ApprovedBy is NULL   and capturedBy='" + Session("Username") + "' and rejectreason is NOT NULL and rejectedby<>'" + Session("Username") + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "client_companies")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxListBox2.DataSource = ds
            ASPxListBox2.TextField = "Det"
            ASPxListBox2.ValueField = "ID"
            ASPxListBox2.DataBind()

        End If
    End Sub

    Protected Sub ASPxListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ASPxListBox2.SelectedIndexChanged
        ' GetTypes()

        GetParticipantsDetials()
        getcurrenciesforbrokers()
        '  Session("rand") = txtCode.Text
        ASPxButton4.Visible = True

        GetCity()
        Getstates()
        getphonecodes()
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedItem.Text = "Company" Then
            lblvar.Text = "SECP CUI"
            txtsecp.Visible = True
            txtNTN.Visible = False
            lblasta.Visible = True
        Else
            lblvar.Text = "NTN No."
            txtsecp.Visible = False
            txtNTN.Visible = True
            lblasta.Visible = False
        End If
    End Sub
End Class
