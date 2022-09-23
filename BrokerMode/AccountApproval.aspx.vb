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
Partial Class BrokerMode_AccountApproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim dsi As New DataSet
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
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
            cmd = New SqlCommand("Select * from pre_names_Creation where approved=0 and brokercode='" & Session("BrokerCode") & "' and RecType='NEW'", cn)
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
            cmd = New SqlCommand("select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "' and Approved=0 and brokercode='" & Session("BrokerCode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
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
                txtBrokerCode.Text = ds.Tables(0).Rows(0).Item("Brokercode").ToString
                txtTitle.Text = ds.Tables(0).Rows(0).Item("Title").ToString
                txtInitials.Text = ds.Tables(0).Rows(0).Item("Initials").ToString
                txtPostal.Text = ds.Tables(0).Rows(0).Item("PostalCode").ToString
                txtJSurname.Text = ds.Tables(0).Rows(0).Item("JSurname").ToString
                txtJForenames.Text = ds.Tables(0).Rows(0).Item("JForenames").ToString
                txtJcellphone.Text = ds.Tables(0).Rows(0).Item("JEmail").ToString
                txtJemail.Text = ds.Tables(0).Rows(0).Item("JCell").ToString
                txtNationality.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString


                Dim signpath As String = ConfigurationManager.AppSettings("Signatures").ToString
                Image1.ImageUrl = signpath & ds.Tables(0).Rows(0).Item("ImageId").ToString
                Image1.width = "200"


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
                Image1.ImageUrl = Nothing
                txtCell.Text = ""
                txtBank.Text = ""
                txtBranch.Text = ""
                txtBnkAccount.Text = ""
                txtIndustry.Text = ""
                txtTax.Text = ""
                lblAccount.Text = ""
                txtBrokerCode.Text = ""
                txtTitle.Text = ""
                txtInitials.Text = ""
                txtPostal.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim AccType As String = ""
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from pre_names_creation where cds_number='" & cmbCdsNumber.Text & "' and approved=0", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "pre_names_creation")
            If (ds.Tables(0).Rows.Count > 0) Then
                If (Session("Username").ToString = ds.Tables(0).Rows(0).Item("updated_by").ToString) Then
                    msgbox("User can not authorize your own transactions")
                    Exit Sub
                End If
                cmd = New SqlCommand("Insert into names (shareholder,broker_code,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_name,Bank_Code,Branch_name,Branch_Code,Account,Tax,Updated_by,Updated_on,Industry,Approved,Approved_by,Approved_On,Holder_type) values(" & ds.Tables(0).Rows(0).Item("Shareholder").ToString & ",'" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString & "','" & ds.Tables(0).Rows(0).Item("CDS_Number").ToString & "','" & ds.Tables(0).Rows(0).Item("Surname").ToString & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString & "','" & ds.Tables(0).Rows(0).Item("IDPP").ToString & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_1").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_2").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_3").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_4").ToString & "','" & ds.Tables(0).Rows(0).Item("CITY").ToString & "','" & ds.Tables(0).Rows(0).Item("COUNTRY").ToString & "','" & ds.Tables(0).Rows(0).Item("TELEPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("CELLPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("FAX").ToString & "','" & ds.Tables(0).Rows(0).Item("EMAIL").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("ACCOUNT").ToString & "'," & ds.Tables(0).Rows(0).Item("TAX").ToString & ",'" & ds.Tables(0).Rows(0).Item("Updated_By").ToString & "','" & ds.Tables(0).Rows(0).Item("Update_On").ToString & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString & "',1,'" & Session("UserName") & "','" & Date.Now & "','" & ds.Tables(0).Rows(0).Item("Holder_type").ToString & "')", cn)
                'MsgBox("Insert into names (shareholder,broker_code,CDS_Number,Surname,Forenames,IDpp,DOB,add_1,add_2,add_3,add_4,city,country,Telephone,Cellphone,fax,email,Bank_Name,Bank_Code,Branch_name,Branch_Code,Account,Tax,Updated_by,Updated_on,Industry,Approved,Approved_by,Approved_On,Holder_type) values(" & ds.Tables(0).Rows(0).Item("Shareholder").ToString & ",'" & ds.Tables(0).Rows(0).Item("BrokerCode").ToString & "','" & ds.Tables(0).Rows(0).Item("CDS_Number").ToString & "','" & ds.Tables(0).Rows(0).Item("Surname").ToString & "','" & ds.Tables(0).Rows(0).Item("Forenames").ToString & "','" & ds.Tables(0).Rows(0).Item("IDPP").ToString & "','" & ds.Tables(0).Rows(0).Item("DOB").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_1").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_2").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_3").ToString & "','" & ds.Tables(0).Rows(0).Item("ADD_4").ToString & "','" & ds.Tables(0).Rows(0).Item("CITY").ToString & "','" & ds.Tables(0).Rows(0).Item("COUNTRY").ToString & "','" & ds.Tables(0).Rows(0).Item("TELEPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("CELLPHONE").ToString & "','" & ds.Tables(0).Rows(0).Item("FAX").ToString & "','" & ds.Tables(0).Rows(0).Item("EMAIL").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BANK_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_NAME").ToString & "','" & ds.Tables(0).Rows(0).Item("BRANCH_CODE").ToString & "','" & ds.Tables(0).Rows(0).Item("ACCOUNT").ToString & "'," & ds.Tables(0).Rows(0).Item("TAX").ToString & ",'" & ds.Tables(0).Rows(0).Item("Updated_By").ToString & "','" & ds.Tables(0).Rows(0).Item("Update_On").ToString & "','" & ds.Tables(0).Rows(0).Item("Industry").ToString & "',1,'" & Session("UserName") & "','" & Date.Now & "','" & ds.Tables(0).Rows(0).Item("Holder_type").ToString & "')")
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                cmd = New SqlCommand("Update pre_names_creation set Approved=1, Approved_By='" & Session("Username").ToString & "', Approved_On='" & Date.Now & "' where cds_number='" & cmbCdsNumber.Text & "' and brokercode='" & Session("BrokerCode") & "' and approved=0", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Dim email As String = ""


                'cmd = New SqlCommand("select * from names where cds_number='" & txtEmail.Text & "'", cn)
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(dsi, "names")

                Try

                    Dim m As New sendmail
                    m.sendmail(txtEmail.Text, "No Reply.CDS Trading Account Created", "Your account has been successfully created. Your account number: " & cmbCdsNumber.Text & " Enjoy our services ")
                    email = txtEmail.Text


                Catch ex As Exception
                    msgbox("Message not sent")
                End Try

                cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Authorized new account creation','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
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
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            If (Session("Username") = Nothing) Then
                Response.Redirect("~\loginsystem.aspx")
                Exit Sub
            End If
            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Accessed New Accounts Creation Approval Form','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            GetHolderData()
            getHolderDetails()
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
            txtBrokerCode.Text = ""
            txtTitle.Text = ""
            txtInitials.Text = ""
            txtPostal.Text = ""
            txtJSurname.Text = ""
            txtJForenames.Text = ""
            txtJcellphone.Text = ""
            txtJemail.Text = ""
            txtNationality.Text = ""
            txtRejection.Visible = False
            txtRejection.Text = ""
            btnSave0.Visible = False
            btnSave.Visible = True
            CheckBox1.Checked = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCdsNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCdsNumber.SelectedIndexChanged
        Try
            getHolderDetails()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
        Try
            cmd = New SqlCommand("Update pre_names_creation set Approved=3, Approved_By='" & Session("Username").ToString & "', Approved_On='" & Date.Now & "' where cds_number='" & cmbCdsNumber.Text & "' and brokercode='" & Session("BrokerCode") & "' and approved=0", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            cmd = New SqlCommand("insert into UserActivityLog (UserName,Activity,TimeOfActivity,DateDone,CompanyCode) values ('" & Session("Username") & "','Rejected new account creation','" & Date.Now & "','" & Now.Date & "','" & Session("BrokerCode") & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msgbox("Account Rejected")
            cleartext()
            GetHolderData()
            getHolderDetails()

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
End Class
