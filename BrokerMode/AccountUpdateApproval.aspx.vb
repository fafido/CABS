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
Partial Class BrokerMode_AccountUpdateApproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim maxholder As Integer = 0
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
    Public Sub GetHolderData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pre_names_Creation where approved=4 and brokercode='" & Session("BrokerCode") & "' and RecType='UPDATE'", cn)
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
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getHolderDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "' and Approved=4 and brokercode='" & Session("BrokerCode") & "' and RecType='UPDATE'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then

                Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
                Image1.ImageUrl = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString
                'txtTax.Text = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString

                txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                txtforenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString
                txtID.Text = ds.Tables(0).Rows(0).Item("IDpp").ToString
                txtDOB.Text = ds.Tables(0).Rows(0).Item("DOB").ToString
                txtAdd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                txtAdd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                txtadd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
                txtadd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
                txtCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                txtCity.Text = ds.Tables(0).Rows(0).Item("City").ToString
                txtTel.Text = ds.Tables(0).Rows(0).Item("Telephone").ToString
                txtFax.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                txtCell.Text = ds.Tables(0).Rows(0).Item("Cellphone").ToString
                txtBank.Text = ds.Tables(0).Rows(0).Item("Bank_Name").ToString
                txtBranch.Text = ds.Tables(0).Rows(0).Item("Branch_Name").ToString
                txtBnkAccount.Text = (ds.Tables(0).Rows(0).Item("Account").ToString)
                txtIndustry.Text = ds.Tables(0).Rows(0).Item("Industry").ToString
                txtTax.Text = ds.Tables(0).Rows(0).Item("Tax").ToString



                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "1") Then
                    lblAccount.Text = "Individual Account"
                End If
                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "2") Then
                    lblAccount.Text = "Joint Account"
                End If
                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "3") Then
                    lblAccount.Text = "Nominee Account"
                End If
                If (ds.Tables(0).Rows(0).Item("Holder_type").ToString = "4") Then
                    lblAccount.Text = "Company Account"
                End If


                Image1.width = "100"

            Else
                txtSurname.Text = ""
                txtforenames.Text = ""
                txtID.Text = ""
                txtDOB.Text = ""
                txtAdd1.Text = ""
                txtAdd2.Text = ""
                txtadd3.Text = ""
                txtadd4.Text = ""
                txtCountry.Text = ""
                txtCity.Text = ""
                txtTel.Text = ""
                txtFax.Text = ""
                txtEmail.Text = ""
                txtCell.Text = ""
                txtBank.Text = ""
                txtBranch.Text = ""
                txtBnkAccount.Text = ""
                txtIndustry.Text = ""
                txtTax.Text = ""
                lblAccount.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getPreviousHolderDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from names where cds_number='" & cmbCdsNumber.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "names")
            If (ds.Tables(0).Rows.Count > 0) Then

                Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
                Image1.ImageUrl = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString
                'txtTax.Text = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString

                txtPsurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString
                If (txtSurname.Text = txtPsurname.Text) Then
                    txtSurname.forecolor = Drawing.Color.Black
                Else
                    txtSurname.forecolor = Drawing.Color.Red
                End If
                txtPforenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString
                If (txtforenames.Text = txtPforenames.Text) Then
                    txtforenames.forecolor = Drawing.Color.Black
                Else
                    txtforenames.forecolor = Drawing.Color.Red
                End If
                txtPIDnumber.Text = ds.Tables(0).Rows(0).Item("IDpp").ToString
                If (txtID.Text = txtPIDnumber.Text) Then
                    txtID.forecolor = Drawing.Color.Black
                Else
                    txtID.forecolor = Drawing.Color.Red
                End If
                txtPDOB.Text = ds.Tables(0).Rows(0).Item("DOB").ToString
                If (txtDOB.Text = txtPDOB.Text) Then
                    txtDOB.forecolor = Drawing.Color.Black
                Else
                    txtDOB.forecolor = Drawing.Color.Red
                End If
                txtPadd1.Text = ds.Tables(0).Rows(0).Item("Add_1").ToString
                If (txtAdd1.Text = txtPadd1.Text) Then
                    txtAdd1.forecolor = Drawing.Color.Black
                Else
                    txtAdd1.forecolor = Drawing.Color.Red
                End If
                txtPadd2.Text = ds.Tables(0).Rows(0).Item("Add_2").ToString
                If (txtAdd2.Text = txtPadd2.Text) Then
                    txtAdd2.forecolor = Drawing.Color.Black
                Else
                    txtAdd2.forecolor = Drawing.Color.Red
                End If
                txtPadd3.Text = ds.Tables(0).Rows(0).Item("Add_3").ToString
                If (txtadd3.Text = txtPadd3.Text) Then
                    txtadd3.forecolor = Drawing.Color.Black
                Else
                    txtadd3.forecolor = Drawing.Color.Red
                End If
                txtPadd4.Text = ds.Tables(0).Rows(0).Item("Add_4").ToString
                If (txtadd4.Text = txtPadd4.Text) Then
                    txtadd4.forecolor = Drawing.Color.Black
                Else
                    txtadd4.forecolor = Drawing.Color.Red
                End If
                txtPcountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString
                If (txtPcountry.Text = txtCountry.Text) Then
                    txtCountry.forecolor = Drawing.Color.Black
                Else
                    txtCountry.forecolor = Drawing.Color.Red
                End If
                txtPcity.Text = ds.Tables(0).Rows(0).Item("City").ToString
                If (txtCity.Text = txtPcity.Text) Then
                    txtCity.forecolor = Drawing.Color.Black
                Else
                    txtCity.forecolor = Drawing.Color.Red
                End If
                Ptel.Text = ds.Tables(0).Rows(0).Item("Telephone").ToString
                If (Trim(txtTel.Text) = Trim(Ptel.Text)) Then
                    txtTel.forecolor = Drawing.Color.Black
                Else
                    txtTel.forecolor = Drawing.Color.Red
                End If
                txtPfax.Text = ds.Tables(0).Rows(0).Item("Fax").ToString
                txtPemail.Text = ds.Tables(0).Rows(0).Item("Email").ToString
                If (txtPemail.Text = txtEmail.Text) Then
                    txtEmail.forecolor = Drawing.Color.Black
                Else
                    txtEmail.forecolor = Drawing.Color.Red
                End If
                txtPcell.Text = ds.Tables(0).Rows(0).Item("Cellphone").ToString
                If (txtPcell.Text = txtCell.Text) Then
                    txtCell.forecolor = Drawing.Color.Black
                Else
                    txtCell.forecolor = Drawing.Color.Red
                End If

                Image1.width = "100"

            Else
                txtPsurname.Text = ""
                txtPforenames.Text = ""
                txtPIDnumber.Text = ""
                txtPDOB.Text = ""
                txtPadd1.Text = ""
                txtPadd2.Text = ""
                txtPadd3.Text = ""
                txtPadd4.Text = ""
                txtPcountry.Text = ""
                txtPcity.Text = ""
                Ptel.Text = ""
                txtPfax.Text = ""
                txtPemail.Text = ""
                txtPcell.Text = ""

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim AccType As String = ""

            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (Session("Username").ToString = ds.Tables(0).Rows(0).Item("Updated_by").ToString) Then
                msgbox("User cannot commit to own transaction")
                Exit Sub
            End If
            If (ds.Tables(0).Rows.Count > 0) Then
                'cmd = New SqlCommand("update names set surname='" & ds.Tables(0).Rows(0).Item("surname").ToString & "', forenames='" & ds.Tables(0).Rows(0).Item("forenames").ToString & "',idpp='" & ds.Tables(0).Rows(0).Item("idpp").ToString & "',dob='" & ds.Tables(0).Rows(0).Item("dob").ToString & "',add_1='" & ds.Tables(0).Rows(0).Item("add_1").ToString & "',add_2='" & ds.Tables(0).Rows(0).Item("add_2").ToString & "',add_3='" & ds.Tables(0).Rows(0).Item("add_3").ToString & "',add_4='" & ds.Tables(0).Rows(0).Item("add_4").ToString & "',city='" & ds.Tables(0).Rows(0).Item("city").ToString & "',country='" & ds.Tables(0).Rows(0).Item("country").ToString & "',telephone='" & ds.Tables(0).Rows(0).Item("telephone").ToString & "',cellphone='" & ds.Tables(0).Rows(0).Item("cellphone").ToString & "',fax='" & ds.Tables(0).Rows(0).Item("fax").ToString & "',email='" & ds.Tables(0).Rows(0).Item("email").ToString & "',bank_name='" & ds.Tables(0).Rows(0).Item("bank_name").ToString & "',bank_code='" & ds.Tables(0).Rows(0).Item("bank_code").ToString & "',branch_name='" & ds.Tables(0).Rows(0).Item("branch_name").ToString & "',branch_code='" & ds.Tables(0).Rows(0).Item("branch_code").ToString & "',account='" & ds.Tables(0).Rows(0).Item("account").ToString & "',tax='" & ds.Tables(0).Rows(0).Item("tax").ToString & "',hfc='" & ds.Tables(0).Rows(0).Item("hfc").ToString & "',locked='" & ds.Tables(0).Rows(0).Item("locked").ToString & "',updated_by='" & ds.Tables(0).Rows(0).Item("updated_by").ToString & "',updated_on='" & ds.Tables(0).Rows(0).Item("update_on").ToString & "' where cds_number='" & cmbCdsNumber.Text & "'", cn)
                ''MsgBox("Insert into names (shareholder,broker_code,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_name,Branch_Code,Account,Tax,Updated_by,Updated_on,Industry,Approved,Approved_by,Approved_On,Holder_type) values(" & ds.Tables(0).Rows(0).Item("Shareholder").ToString & ",'" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString & "','" & ds.Tables(0).Rows(0).Item("CDS_Number").ToString & "','" & ds.Tables(0).Rows(0).Item("Surname").ToString & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString & "','" & ds.Tables(0).Rows(0).Item("IDPP").ToString & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_1").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_2").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_3").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_4").ToString & "','" & ds.Tables(0).Rows(0).Item("CITY").ToString & "','" & ds.Tables(0).Rows(0).Item("COUNTRY").ToString & "','" & ds.Tables(0).Rows(0).Item("TELEPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("CELLPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("FAX").ToString & "','" & ds.Tables(0).Rows(0).Item("EMAIL").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("ACCOUNT").ToString & "'," & ds.Tables(0).Rows(0).Item("TAX").ToString & ",'" & ds.Tables(0).Rows(0).Item("Updated_By").ToString & "','" & ds.Tables(0).Rows(0).Item("Update_On").ToString & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString & "',1,'" & Session("UserName") & "','" & Date.Now & "','" & ds.Tables(0).Rows(0).Item("Holder_type").ToString & "')")
                'If (cn.State = ConnectionState.Open) Then
                '    cn.Close()
                'End If
                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()

                Dim Code As String = ""
                Code = (Convert.ToString(random.Next(10, 999999)))

                cmd = New SqlCommand("Update pre_names_creation set Approved=0, activationCode='" & Code & "' where cds_number='" & cmbCdsNumber.Text & "' and brokercode='" & Session("BrokerCode") & "' and approved=4", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Dim email As String = ""

                email = txtEmail.Text

                Mail.Subject = "No Reply.CDS Trading Account Created"
                Mail.To.Add("" + email + "")
                Mail.From = New MailAddress("cdspresentation@gmail.com")
                Mail.Body = " Your account change request has been successfully received. Your account activation number: " & Code & " Enjoy our services "

                'Dim SMTP As New SmtpClient("smtp.googlemail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("cdspresentation@gmail.com", "cdscompany1234")
                SMTP.Port = "587"
                SMTP.Send(Mail)

                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Authorized an account update','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msgbox("Account Approved")
                cleartext()
                GetHolderData()
                getHolderDetails()
            Else
                msgbox("Unable to Update")
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed Accounts Update Approval Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            GetHolderData()
            getHolderDetails()
            getPreviousHolderDetails()
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


            txtPsurname.Text = ""
            txtPforenames.Text = ""
            txtPIDnumber.Text = ""
            txtPadd1.Text = ""
            txtPadd2.Text = ""
            txtPadd3.Text = ""
            txtPadd4.Text = ""
            Ptel.Text = ""
            txtPcell.Text = ""
            txtPemail.Text = ""
            txtPfax.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCdsNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCdsNumber.SelectedIndexChanged
        Try
            getHolderDetails()
            getPreviousHolderDetails()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If (CheckBox1.Checked = True) Then
                txtRejection.Visible = True
                txtRejection.Text = ""
                btnSave0.Visible = True
                btnSave.Visible = False
            End If
            If (CheckBox1.Checked = False) Then
                txtRejection.Visible = False
                txtRejection.Text = ""
                btnSave0.Visible = False
                btnSave.Visible = True
            End If

        Catch ex As Exception

            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")

            If (Session("Username").ToString = ds.Tables(0).Rows(0).Item("Updated_by").ToString) Then
                msgbox("User cannot commit to own transaction")
                Exit Sub
            End If

            cmd = New SqlCommand("Update pre_names_creation set Approved=3, RejectionReason='" & txtRejection.Text & "' where cds_number='" & cmbCdsNumber.Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Rejected an account update','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            msgbox("Account Updated Rejected")
            cleartext()
            GetHolderData()
            getHolderDetails()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
End Class
